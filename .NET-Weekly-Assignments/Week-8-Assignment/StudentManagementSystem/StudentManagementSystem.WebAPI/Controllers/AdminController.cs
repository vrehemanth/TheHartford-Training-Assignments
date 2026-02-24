using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Application.DTOS;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Infrastructure.Data;
using System;

namespace StudentManagementSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly UserDbContext _context;
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public AdminController(UserDbContext context, IMapper mapper, IUserRepository repo)
        {
            _context = context;
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();

            var result = _mapper.Map<List<UserDto>>(users);

            return Ok(result);
        }
        [HttpGet("dashboard-stats")]
        public async Task<IActionResult> GetStats()
        {
            var stats = new
            {
                totalStudents = await _repo.CountByRoleAsync(Domain.Enums.UserRole.Student),
                totalTrainers = await _repo.CountByRoleAsync(Domain.Enums.UserRole.Trainer),
                totalMaterials = await _context.StudyMaterials.CountAsync(),
                totalFeedbacks = await _context.Feedbacks.CountAsync()
            };

            return Ok(stats);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("assign-trainer")]
        public async Task<IActionResult> AssignTrainer(AssignTrainerDto dto)
        {
            try
            {
                // ✅ Load student profile
                var student = await _context.StudentProfiles
                    .FirstOrDefaultAsync(s => s.Id == dto.StudentId);

                if (student == null)
                    return NotFound("Student not found");

                // ✅ Load trainer profile
                var trainer = await _context.TrainerProfiles
                    .FirstOrDefaultAsync(t => t.Id == dto.TrainerId);

                if (trainer == null)
                    return NotFound("Trainer not found");

                student.TrainerId = trainer.Id;

                Console.WriteLine("Before Save → " + student.TrainerId);

                var rows = await _context.SaveChangesAsync();

                Console.WriteLine("Rows affected → " + rows);

                var check = await _context.StudentProfiles
                    .Where(s => s.Id == dto.StudentId)
                    .Select(s => s.TrainerId)
                    .FirstOrDefaultAsync();

                Console.WriteLine("DB Value → " + check);

                return Ok(new { message = "Trainer assigned successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
        [HttpGet("trainers")]
        public async Task<IActionResult> GetAllTrainers()
        {
            var trainers = await _context.TrainerProfiles
                .Include(t => t.User)
                .Select(t => new
                {
                    id = t.Id,
                    fullName = t.User.FullName,
                    email = t.User.Email,
                    expertise = t.Expertise
                })
                .ToListAsync();

            return Ok(trainers);
        }
        [HttpGet("students")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _context.StudentProfiles
                .Include(s => s.User)
                .Include(s => s.Trainer)
                    .ThenInclude(t => t.User)
                .Select(s => new
                {
                    id = s.Id,
                    fullName = s.User.FullName,
                    email = s.User.Email,
                    course = s.Course,
                    enrollmentNumber = s.EnrollmentNumber,
                    trainerId = s.TrainerId,
                    trainerName = s.Trainer != null ? s.Trainer.User.FullName : null
                })
                .ToListAsync();

            return Ok(students);
        }

        [HttpGet("student/{id}/feedbacks")]
        public async Task<IActionResult> GetStudentFeedbacks(Guid id)
        {
            try
            {
                var feedbacks = await _context.Feedbacks
                    .Where(f => f.StudentId == id)
                    .Join(_context.TrainerProfiles.Include(t => t.User),
                        f => f.TrainerId,
                        t => t.Id,
                        (f, t) => new
                        {
                            f.Id,
                            f.Comments,
                            TrainerName = t.User != null ? t.User.FullName : "Unknown",
                            f.CreatedAt
                        })
                    .OrderByDescending(f => f.CreatedAt)
                    .ToListAsync();

                return Ok(feedbacks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, details = ex.ToString() });
            }
        }
        [HttpDelete("trainer/{id}")]
        public async Task<IActionResult> DeleteTrainer(Guid id)
        {
            try
            {
                var trainer = await _context.TrainerProfiles
                    .Include(t => t.User)
                    .Include(t => t.StudyMaterials)
                    .Include(t => t.Students)
                    .FirstOrDefaultAsync(t => t.Id == id);

                if (trainer == null)
                    return NotFound("Trainer not found");

                // ✅ Unassign students
                foreach (var student in trainer.Students)
                    student.TrainerId = null;

                // ✅ Remove materials
                if (trainer.StudyMaterials.Any())
                    _context.StudyMaterials.RemoveRange(trainer.StudyMaterials);

                // ✅ Remove profile FIRST
                _context.TrainerProfiles.Remove(trainer);

                await _context.SaveChangesAsync();

                // ✅ Remove user AFTER
                _context.Users.Remove(trainer.User);

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
        [HttpDelete("student/{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            try
            {
                var student = await _context.StudentProfiles
                    .Include(s => s.User)
                    .Include(s => s.Feedbacks)
                    .FirstOrDefaultAsync(s => s.Id == id);

                if (student == null)
                    return NotFound("Student not found");

                if (student.Feedbacks.Any())
                    _context.Feedbacks.RemoveRange(student.Feedbacks);

                // ✅ Remove profile FIRST
                _context.StudentProfiles.Remove(student);

                await _context.SaveChangesAsync();

                // ✅ Remove user AFTER
                _context.Users.Remove(student.User);

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
        [Authorize(Roles = "Admin")]

        [HttpGet("materials")]
        public async Task<IActionResult> GetAllMaterials()
        {
            var materials = await _context.StudyMaterials
                .Include(m => m.Trainer)
                .ThenInclude(t => t.User)
                .Select(m => new
                {
                    m.Id,
                    m.Title,
                    m.Description,
                    m.Url,
                    TrainerName = m.Trainer.User.FullName
                })
                .ToListAsync();

            return Ok(materials);
        }

        [HttpDelete("materials/{id}")]
        public async Task<IActionResult> DeleteMaterial(Guid id)
        {
            var material = await _context.StudyMaterials.FindAsync(id);

            if (material == null)
                return NotFound();

            _context.StudyMaterials.Remove(material);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Material deleted by admin" });
        }
    }
}