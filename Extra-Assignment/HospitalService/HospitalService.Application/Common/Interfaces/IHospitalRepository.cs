using HospitalService.Domain.Entities;

namespace HospitalService.Application.Common.Interfaces
{
    public interface IHospitalRepository
    {
        Task CreateAsync(Hospital hospital);
        Task<Hospital?> GetByIdAsync(int id);
        Task<IEnumerable<Hospital>> GetAllAsync();
        Task UpdateAsync(Hospital hospital);
        Task DeleteAsync(int id);
    }
}
