using Employee.DTOs;
using Employee.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWithSqlDB.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReadEmployeesDTO>> GetAllAsync()
        {
            return await _context.EmployeeList
                .Include(e => e.Department)
                .Select(e => new ReadEmployeesDTO
                {
                    Id = e.Id,
                    Name = e.Name,
                    Salary = e.Salary,
                    IsActive = e.IsActive,
                    DepartmentId = e.Department!.Id,
                    DepartmentName = e.Department.DeptName
                })
                .ToListAsync();
        }

        public async Task<ReadEmployeesDTO?> GetByIdAsync(long id)
        {
            return await _context.EmployeeList
                .Include(e => e.Department)
                .Where(e => e.Id == id)
                .Select(e => new ReadEmployeesDTO
                {
                    Id = e.Id,
                    Name = e.Name,
                    Salary = e.Salary,
                    IsActive = e.IsActive,
                    DepartmentId = e.Department!.Id,
                    DepartmentName = e.Department.DeptName
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ReadEmployeesDTO?> AddAsync(CreateEmployeeDTO dto)
        {
            var department = await _context.Departments
                .FirstOrDefaultAsync(d => d.DeptName == dto.DepartmentName);

            if (department == null) return null;

            long nextEmpId = await _context.EmployeeList.AnyAsync()
                ? await _context.EmployeeList.MaxAsync(e => e.Id) + 1
                : 1;

            var employee = new EmployeeModel
            {
                Id = nextEmpId,
                Name = dto.Name,
                Salary = dto.Salary,
                IsActive = dto.IsActive,
                DepartmentId = department.Id
            };

            _context.EmployeeList.Add(employee);
            await _context.SaveChangesAsync();

            return new ReadEmployeesDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                DepartmentId = department.Id,
                DepartmentName = department.DeptName
            };
        }

        public async Task<bool> UpdateAsync(long id, CreateEmployeeDTO dto)
        {
            var employee = await _context.EmployeeList.FindAsync(id);
            if (employee == null) return false;

            var department = await _context.Departments
                .FirstOrDefaultAsync(d => d.DeptName == dto.DepartmentName);

            if (department == null) return false;

            employee.Name = dto.Name;
            employee.Salary = dto.Salary;
            employee.IsActive = dto.IsActive;
            employee.DepartmentId = department.Id;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateSalaryAsync(long id, UpdateSalaryDTO dto)
        {
            var employee = await _context.EmployeeList.FindAsync(id);
            if (employee == null) return false;

            employee.Salary = dto.Salary;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var employee = await _context.EmployeeList.FindAsync(id);
            if (employee == null) return false;

            _context.EmployeeList.Remove(employee);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
