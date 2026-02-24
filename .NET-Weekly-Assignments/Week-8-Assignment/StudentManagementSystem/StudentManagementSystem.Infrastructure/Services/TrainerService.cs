using StudentManagementSystem.Application.DTOS;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Infrastructure.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly UserDbContext _context;

        public TrainerService(UserDbContext context)
        {
            _context = context;
        }

        // ✅ Get Assigned Students
        public async Task<List<StudentDto>> GetAssignedStudents(Guid trainerId)
        {
            return await _context.StudentProfiles
                .Where(s => s.TrainerId == trainerId)
                .Select(s => new StudentDto
                {
                    Id = s.Id,
                    Name = s.User.FullName,
                    Course = string.IsNullOrEmpty(s.Course) ? "Not Assigned" : s.Course,
                    Progress = s.Progress
                })
                .ToListAsync();
        }

        // ✅ Trainer Dashboard Stats
        public async Task<TrainerStatsDto> GetTrainerStats(Guid trainerId)
        {
            // ✅ Active Batches = Distinct Courses
            var activeBatches = await _context.StudentProfiles
                .Where(s => s.TrainerId == trainerId && !string.IsNullOrEmpty(s.Course))
                .Select(s => s.Course)
                .Distinct()
                .CountAsync();

            // ✅ Pending Reviews = Progress < 100
            var pendingReviews = await _context.StudentProfiles
                .CountAsync(s => s.TrainerId == trainerId && s.Progress < 100);

            return new TrainerStatsDto
            {
                ActiveBatches = activeBatches,
                PendingReviews = pendingReviews
            };
        }

        // ✅ Update Progress
        public async Task UpdateStudentProgress(Guid studentId, int progress)
        {
            var student = await _context.StudentProfiles   // ✅ FIXED
                .FirstOrDefaultAsync(s => s.Id == studentId);

            if (student == null)
                throw new Exception("Student not found");

            student.Progress = progress;
            await _context.SaveChangesAsync();
        }

        // ✅ Add Student Note
        public async Task<List<StudyMaterialDto>> GetMaterials(Guid trainerId)
        {
            return await _context.StudyMaterials
                .Where(m => m.TrainerId == trainerId)
                .Select(m => new StudyMaterialDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    Url = m.Url
                })
                .ToListAsync();
        }
        public async Task AddStudyMaterial(StudyMaterialDto dto, Guid trainerId)
        {
            var material = new StudyMaterialEntity
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Description = dto.Description,
                Url = dto.Url,
                TrainerId = trainerId,
            };

            _context.StudyMaterials.Add(material);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateStudyMaterial(Guid materialId, StudyMaterialDto dto, Guid trainerId)
        {
            var material = await _context.StudyMaterials
                .FirstOrDefaultAsync(m => m.Id == materialId);

            if (material == null)
                throw new Exception("Material not found");

            // ✅ SECURITY CHECK
            if (material.TrainerId != trainerId)
                throw new UnauthorizedAccessException("Not your material");

            material.Title = dto.Title;
            material.Description = dto.Description;
            material.Url = dto.Url;

            await _context.SaveChangesAsync();
        }
        public async Task DeleteStudyMaterial(Guid materialId, Guid trainerId)
        {
            var material = await _context.StudyMaterials
                .FirstOrDefaultAsync(m => m.Id == materialId);

            if (material == null)
                throw new Exception("Material not found");

            // ✅ SECURITY CHECK
            if (material.TrainerId != trainerId)
                throw new UnauthorizedAccessException("Not your material");

            _context.StudyMaterials.Remove(material);
            await _context.SaveChangesAsync();
        }
        public async Task AddFeedback(Guid trainerId, FeedbackDto dto)
        {
            var feedback = new FeedbackEntity
            {
                Id = Guid.NewGuid(),
                StudentId = dto.StudentId,
                TrainerId = trainerId,
                MaterialId = dto.MaterialId,
                Comments = dto.Comments,
                Rating = dto.Rating ?? 0,
                CreatedAt = DateTime.UtcNow
            };

            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
        }
    }
}