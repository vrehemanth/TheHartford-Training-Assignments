using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Application.DTOS;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Domain.Constants;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Infrastructure.Data;
using System.Security.Claims;

namespace StudentManagementSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/student")]
    [Authorize(Roles = "Student")]
    public class StudentController : ControllerBase
    {
        private readonly IStudyMaterialRepository _materials;
        private readonly IFeedbackRepository _feedback;
        private readonly IMapper _mapper;
        private readonly UserDbContext _context;
        public StudentController(
            IStudyMaterialRepository materials,
            IFeedbackRepository feedback,
            IMapper mapper,
            UserDbContext context)
        {
            _materials = materials;
            _feedback = feedback;
            _mapper = mapper;
            _context = context;
        }

        // ✅ Dashboard
        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            return Ok("Welcome to Student Dashboard");
        }

        // ✅ View Materials
        [Authorize(Roles = "Student")]

        [HttpGet("study-materials")]
        public async Task<IActionResult> GetMaterials()
        {
            var materials = await _materials.GetAllAsync();

            var result = _mapper.Map<List<StudyMaterialDto>>(materials);

            return Ok(result);
        }

        // ✅ View Feedback
        [HttpGet("feedback")]
        public async Task<IActionResult> GetMyFeedback()
        {
            var userIdClaim = User.FindFirst("UserId");

            if (userIdClaim == null)
                return Unauthorized();

            var userId = Guid.Parse(userIdClaim.Value);

            var studentProfile = await _context.StudentProfiles
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.UserId == userId);

            if (studentProfile == null)
                return BadRequest("Student profile not found");

            var feedbacks = await _context.Feedbacks
                .AsNoTracking()
                .Where(f => f.StudentId == studentProfile.Id)
                .OrderByDescending(f => f.CreatedAt)
                .Select(f => new FeedbackDto
                {
                    Id = f.Id,
                    Comments = f.Comments,
                    MaterialId = f.MaterialId,
                    Rating = f.Rating,
                    CreatedAt = f.CreatedAt
                })
                .ToListAsync();

            return Ok(feedbacks);
        }
        [HttpPost("feedback")]
        public async Task<IActionResult> SubmitFeedback(FeedbackDto dto)
        {
            var userId = Guid.Parse(User.FindFirst("UserId")!.Value);

            var studentProfile = await _context.StudentProfiles
                .FirstOrDefaultAsync(s => s.UserId == userId);

            if (studentProfile == null)
                return BadRequest("Student profile not found");

            var feedback = new FeedbackEntity
            {
                Id = Guid.NewGuid(),
                StudentId = studentProfile.Id,
                MaterialId = dto.MaterialId,
                Comments = dto.Comments,
                Rating = dto.Rating ?? 0,
                CreatedAt = DateTime.UtcNow
            };

            await _feedback.AddAsync(feedback);

            return Ok(new { message = "Feedback submitted" });
        }
        // ✅ View Own Profile
        [HttpGet("profile")]
        public IActionResult Profile()
        {
            var email = User.Identity?.Name;
            return Ok($"Student Profile → {email}");
        }

        // ✅ Courses List (Public)
        [HttpGet("courses")]
        [AllowAnonymous]
        public IActionResult GetCourses()
        {
            return Ok(CourseList.Courses);
        }

        // 🔐 SAFE CLAIM EXTRACTION
        private Guid GetStudentId()
        {
            var userIdClaim = User.FindFirst("UserId")?.Value;

            if (userIdClaim == null)
                throw new UnauthorizedAccessException("JWT claim 'UserId' missing");

            return Guid.Parse(userIdClaim);
        }
    }
}