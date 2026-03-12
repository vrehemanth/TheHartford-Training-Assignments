using HospitalService.Application.Common.Interfaces;
using HospitalService.Application.DTOs;
using HospitalService.Domain.Entities;

namespace HospitalService.Application.Services
{
    public class HospitalLogic
    {
        private readonly IHospitalRepository _repository;

        public HospitalLogic(IHospitalRepository repository)
        {
            _repository = repository;
        }

        public async Task AddHospitalAsync(AddHospitalRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name)) throw new ArgumentException("Hospital name is required.");
            
            var hospital = new Hospital
            {
                Name = request.Name,
                Location = request.Location,
                TotalBeds = request.TotalBeds,
                AvailableBeds = request.TotalBeds, // Initially all beds available
                HasICU = request.HasICU,
                ContactNumber = request.ContactNumber
            };

            await _repository.CreateAsync(hospital);
        }

        public async Task<IEnumerable<Hospital>> GetAllHospitalsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<bool> UpdateBedsAsync(int id, int availableBeds)
        {
            var hospital = await _repository.GetByIdAsync(id);
            if (hospital == null) return false;

            if (availableBeds < 0 || availableBeds > hospital.TotalBeds)
                throw new ArgumentException($"Available beds must be between 0 and {hospital.TotalBeds}");

            hospital.AvailableBeds = availableBeds;
            await _repository.UpdateAsync(hospital);
            return true;
        }

        public async Task<bool> DeleteHospitalAsync(int id)
        {
            var hospital = await _repository.GetByIdAsync(id);
            if (hospital == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
