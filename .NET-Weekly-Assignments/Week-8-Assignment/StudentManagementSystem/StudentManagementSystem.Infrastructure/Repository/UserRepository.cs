using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Domain.Enums;
using StudentManagementSystem.Infrastructure.Data;

namespace StudentManagementSystem.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<UserEntity?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u => u.StudentProfile)
                .Include(u => u.TrainerProfile)
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task AddAsync(UserEntity user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<int> CountByRoleAsync(UserRole role)
        {
            return await _context.Users.CountAsync(x => x.Role == role);
        }

        public async Task<List<UserEntity>> GetRecentStudentsAsync()
        {
            return await _context.Users
                .Where(x => x.Role == UserRole.Student)
                .OrderByDescending(x => x.CreatedDate)
                .Take(5)
                .ToListAsync();
        }
    }
}
