using Employee.Models;
using Employee.DTOs;

namespace EmployeeWithSqlDB.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<ReadEmployeesDTO>> GetAllAsync();
        Task<ReadEmployeesDTO?> GetByIdAsync(long id);
        Task<ReadEmployeesDTO?> AddAsync(CreateEmployeeDTO dto);
        Task<bool> UpdateAsync(long id, CreateEmployeeDTO dto);
        Task<bool> UpdateSalaryAsync(long id, UpdateSalaryDTO dto);
        Task<bool> DeleteAsync(long id);
    }
}
