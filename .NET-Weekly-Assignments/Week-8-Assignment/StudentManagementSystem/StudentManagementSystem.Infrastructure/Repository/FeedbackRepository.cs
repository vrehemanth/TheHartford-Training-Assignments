using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Infrastructure.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly UserDbContext _context;

        public FeedbackRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(FeedbackEntity feedback)
        {
            await _context.Feedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task<List<object>> GetByTrainerIdAsync(Guid trainerId)
        {
            return await _context.Feedbacks
                .Include(f => f.Student)
                .ThenInclude(s => s.User)
                .Include(f => f.Material)
                .Where(f => f.TrainerId == trainerId)
                .OrderByDescending(f => f.CreatedAt)
                .Select(f => new
                {
                    studentName = f.Student.User != null ? f.Student.User.FullName : (f.Student.Name ?? "Unknown"),
                    comments = f.Comments,
                    rating = f.Rating,
                    materialTitle = f.Material != null ? f.Material.Title : null,
                    createdAt = f.CreatedAt
                })
                .ToListAsync<object>();
        }

        public async Task<List<FeedbackEntity>> GetByStudentIdAsync(Guid studentId)
        {
            return await _context.Feedbacks
                .Where(f => f.StudentId == studentId)
                .OrderByDescending(f => f.CreatedAt)
                .ToListAsync();
        }
    }
}
