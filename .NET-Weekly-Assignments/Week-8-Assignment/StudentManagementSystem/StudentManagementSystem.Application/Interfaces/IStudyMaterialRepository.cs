using StudentManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Application.Interfaces
{
    public interface IStudyMaterialRepository
    {
        Task AddAsync(StudyMaterialEntity material);
        Task<List<StudyMaterialEntity>> GetAllAsync();
    }
}
