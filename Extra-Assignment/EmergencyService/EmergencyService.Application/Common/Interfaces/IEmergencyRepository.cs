using EmergencyService.Domain.Entities;

namespace EmergencyService.Application.Common.Interfaces
{
    public interface IEmergencyRepository
    {
        Task CreateAsync(Emergency emergency);
        Task<Emergency?> GetByIdAsync(int id);
        Task UpdateAsync(Emergency emergency);
        Task<IEnumerable<Emergency>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}
