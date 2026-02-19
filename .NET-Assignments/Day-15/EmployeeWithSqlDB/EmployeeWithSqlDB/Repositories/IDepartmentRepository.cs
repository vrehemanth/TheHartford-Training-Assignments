using Employee.Models;

namespace EmployeeWithSqlDB.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<DepartmentModel>> GetAllAsync();
        Task<DepartmentModel?> GetByIdAsync(long id);
        Task<DepartmentModel> AddAsync(DepartmentModel department);
        Task<bool> UpdateAsync(DepartmentModel department);
        Task<bool> DeleteAsync(long id);
        Task<bool> ExistsAsync(long id);
    }
}
