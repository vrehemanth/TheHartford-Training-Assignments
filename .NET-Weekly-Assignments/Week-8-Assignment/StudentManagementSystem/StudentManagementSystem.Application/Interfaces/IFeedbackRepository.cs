using StudentManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Application.Interfaces
{
    public interface IFeedbackRepository
    {
        Task AddAsync(FeedbackEntity feedback);
        Task<List<object>> GetByTrainerIdAsync(Guid trainerId);
        Task<List<FeedbackEntity>> GetByStudentIdAsync(Guid studentId);
    }
}
