using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Application.DTOS;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Infrastructure.Data;
using System.Security.Claims;

namespace StudentManagementSystem.WebAPI.Controllers
{
    [Authorize(Roles = "Trainer")]
    [ApiController]
    [Route("api/trainer")]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService _trainerService;
        private readonly UserDbContext _context;
        private readonly IFeedbackRepository _feedback;

        public TrainerController(ITrainerService trainerService, UserDbContext context, IFeedbackRepository feedback)
        {
            _trainerService = trainerService;
            _context = context;
            _feedback = feedback;
        }

        // ✅ 1. Get Assigned Students
        [HttpGet("students")]
        public async Task<IActionResult> GetStudents()
        {
            var trainerId = GetTrainerId();
            var students = await _trainerService.GetAssignedStudents(trainerId);
            return Ok(students);
        }

        // ✅ 2. Dashboard Stats
        [HttpGet("stats")]
        public async Task<IActionResult> GetTrainerStats()
        {
            var trainerId = GetTrainerId();
            var stats = await _trainerService.GetTrainerStats(trainerId);
            return Ok(stats);
        }

        // ✅ 3. Update Progress
        [HttpPut("progress/{studentId}")]
        public async Task<IActionResult> UpdateProgress(Guid studentId, UpdateProgressDto dto)
        {
            await _trainerService.UpdateStudentProgress(studentId, dto.Progress);
            return Ok(new { message = "Progress updated" });
        }

        // ✅ 4. Add Notes
        [HttpGet("materials")]
        public async Task<IActionResult> GetMaterials()
        {
            var trainerId = GetTrainerId();

            var materials = await _trainerService.GetMaterials(trainerId);

            return Ok(materials);
        }
        [HttpPost("materials")]
        public async Task<IActionResult> AddMaterial(StudyMaterialDto dto)
        {
            var trainerId = GetTrainerId();

            await _trainerService.AddStudyMaterial(dto, trainerId);

            return Ok(new { message = "Material added" });
        }
        [HttpPut("materials/{id}")]
        public async Task<IActionResult> UpdateMaterial(Guid id, StudyMaterialDto dto)
        {
            var trainerId = GetTrainerId();

            await _trainerService.UpdateStudyMaterial(id, dto, trainerId);

            return Ok(new { message = "Material updated" });
        }

        [HttpDelete("materials/{id}")]
        public async Task<IActionResult> DeleteMaterial(Guid id)
        {
            var trainerId = GetTrainerId();

            await _trainerService.DeleteStudyMaterial(id, trainerId);

            return Ok(new { message = "Material deleted" });
        }
        [HttpGet("feedback")]
        public async Task<IActionResult> GetTrainerFeedback()
        {
            var trainerId = GetTrainerId();
            var feedbacks = await _feedback.GetByTrainerIdAsync(trainerId);
            return Ok(feedbacks);
        }

        [HttpPost("feedback")]
        public async Task<IActionResult> AddFeedback([FromBody] FeedbackDto dto)
        {
            var trainerId = GetTrainerId();
            await _trainerService.AddFeedback(trainerId, dto);
            return Ok(new { message = "Feedback submitted successfully" });
        }

        // 🔐 Helper → Resolve TrainerProfile.Id from JWT UserId
        private Guid GetTrainerId()
        {
            var userIdClaim = User.FindFirst("UserId");

            if (userIdClaim == null)
                throw new UnauthorizedAccessException("JWT claim 'UserId' not found");

            Console.WriteLine("JWT UserId → " + userIdClaim.Value);

            var userId = Guid.Parse(userIdClaim.Value);

            var trainerId = _context.TrainerProfiles
                .Where(t => t.UserId == userId)
                .Select(t => (Guid?)t.Id)   // ✅ Nullable to avoid Guid.Empty confusion
                .FirstOrDefault();

            if (trainerId == null)
                throw new Exception("Trainer profile not found");

            Console.WriteLine("Resolved TrainerId → " + trainerId.Value);

            return trainerId.Value;
        }
    }
}