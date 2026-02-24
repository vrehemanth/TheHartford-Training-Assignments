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
    public class StudyMaterialRepository : IStudyMaterialRepository
    {
        private readonly UserDbContext _context;

        public StudyMaterialRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(StudyMaterialEntity material)
        {
            await _context.StudyMaterials.AddAsync(material);
            await _context.SaveChangesAsync();
        }

        public async Task<List<StudyMaterialEntity>> GetAllAsync()
        {
            return await _context.StudyMaterials.ToListAsync();
        }
    }
}
