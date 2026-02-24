using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<UserEntity?> GetByEmailAsync(string email);
        Task AddAsync(UserEntity user);
        Task<int> CountByRoleAsync(UserRole role);
        Task<List<UserEntity>> GetRecentStudentsAsync();
    }
}
