using Employee.Models;
using Microsoft.EntityFrameworkCore;
namespace EmployeeWithSqlDB.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeContext _context;

        public DepartmentRepository(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DepartmentModel>> GetAllAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<DepartmentModel?> GetByIdAsync(long id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task<DepartmentModel> AddAsync(DepartmentModel department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<bool> UpdateAsync(DepartmentModel department)
        {
            _context.Entry(department).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var dept = await _context.Departments.FindAsync(id);
            if (dept == null) return false;

            _context.Departments.Remove(dept);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(long id)
        {
            return await _context.Departments.AnyAsync(d => d.Id == id);
        }
    }
}
