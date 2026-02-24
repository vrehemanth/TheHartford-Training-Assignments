using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Application.DTOS;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Domain.Constants;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Domain.Enums;
using StudentManagementSystem.Infrastructure.Data;
using System.Net;
using Umbraco.Core.Security;

namespace StudentManagementSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IJwtService _jwt;
        private readonly UserDbContext _context;

        public AuthController(IUserRepository repo, IJwtService jwt, UserDbContext context)
        {
            _repo = repo;
            _jwt = jwt;
            _context = context;
        }

        // ✅ REGISTER
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            try
            {
                var existingUser = await _repo.GetByEmailAsync(dto.Email);

                if (existingUser != null)
                    return BadRequest(new { message = "User already exists" });

                // ✅ ROLE-BASED VALIDATION
                if (dto.UserRole == UserRole.Admin)
                    return BadRequest(new { message = "Admin registration is not allowed" });

                if (dto.UserRole == UserRole.Student && string.IsNullOrEmpty(dto.Course))
                    return BadRequest(new { message = "Course is required for students" });

                if (dto.UserRole == UserRole.Trainer && string.IsNullOrEmpty(dto.Expertise))
                    return BadRequest(new { message = "Expertise is required for trainers" });

                // ✅ VALIDATE COURSE LIST
                if (dto.UserRole == UserRole.Student &&
                    !CourseList.Courses.Contains(dto.Course!))
                {
                    return BadRequest(new { message = "Invalid course selected" });
                }

                if (string.IsNullOrWhiteSpace(dto.SecurityQuestion) || string.IsNullOrWhiteSpace(dto.SecurityAnswer))
                {
                    return BadRequest(new { message = "Security Question and Answer are required." });
                }

                var user = new UserEntity
                {
                    Id = Guid.NewGuid(),
                    FullName = dto.FullName,
                    Email = dto.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                    Role = dto.UserRole,
                    CreatedDate = DateTime.UtcNow,
                    SecurityQuestion = dto.SecurityQuestion ?? "",
                    SecurityAnswer = (dto.SecurityAnswer ?? "").Trim().ToLowerInvariant()
                };

                await _repo.AddAsync(user);

                // ✅ CREATE ROLE PROFILE
                if (dto.UserRole == UserRole.Trainer)
                {
                    await _context.TrainerProfiles.AddAsync(new TrainerEntity
                    {
                        Id = Guid.NewGuid(),
                        UserId = user.Id,
                        Expertise = dto.Expertise!   // ✅ FIXED
                    });
                }
                else if (dto.UserRole == UserRole.Student)
                {
                    await _context.StudentProfiles.AddAsync(new StudentEntity
                    {
                        Id = Guid.NewGuid(),
                        UserId = user.Id,
                        Course = dto.Course!,   // ✅ FIXED
                        EnrollmentNumber = GenerateEnrollmentNumber()
                    });
                }

                // ✅ SINGLE SAVE
                await _context.SaveChangesAsync();

                return Ok(new { message = "Registration successful" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, inner = ex.InnerException?.Message, stackTrace = ex.StackTrace });
            }
        }

        // ✅ LOGIN
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _repo.GetByEmailAsync(dto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return Unauthorized("Invalid credentials");

            var token = _jwt.GenerateToken(user);

            return Ok(new ResponseDto
            {
                Token = token,
                Email = user.Email,
                Role = user.Role
            });
        }
        [HttpGet("security-question")]
        public async Task<IActionResult> GetSecurityQuestion([FromQuery] string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return BadRequest(new { message = "Email is required" });

            var user = await _repo.GetByEmailAsync(email);

            if (user == null)
                return NotFound(new { message = "User not found" });

            if (string.IsNullOrWhiteSpace(user.SecurityQuestion))
                return BadRequest(new { message = "No security question set for this user." });

            return Ok(new { question = user.SecurityQuestion });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email) ||
                string.IsNullOrWhiteSpace(dto.SecurityAnswer) ||
                string.IsNullOrWhiteSpace(dto.NewPassword))
            {
                return BadRequest(new { message = "Invalid request details" });
            }

            var user = await _repo.GetByEmailAsync(dto.Email);

            if (user == null)
                return BadRequest(new { message = "User not found" });

            var answer = dto.SecurityAnswer.Trim().ToLowerInvariant();

            if (user.SecurityAnswer != answer)
                return BadRequest(new { message = "Incorrect security answer" });

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
            user.ResetToken = null;
            user.ResetTokenExpiry = null;

            await _context.SaveChangesAsync();

            return Ok(new { message = "Password reset successful" });
        }

        // ✅ Enrollment Generator (Simple)
        private string GenerateEnrollmentNumber()
        {
            return "ENR-" + DateTime.UtcNow.Ticks.ToString().Substring(10);
        }
    }
}