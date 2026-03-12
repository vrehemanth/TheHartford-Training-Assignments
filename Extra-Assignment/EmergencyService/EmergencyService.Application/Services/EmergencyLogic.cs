using EmergencyService.Application.Common.Interfaces;
using EmergencyService.Application.DTOs;
using EmergencyService.Domain.Entities;

namespace EmergencyService.Application.Services
{
    public class EmergencyLogic
    {
        private readonly IEmergencyRepository _repository;

        public EmergencyLogic(IEmergencyRepository repository)
        {
            _repository = repository;
        }

        public async Task ReportAsync(ReportEmergencyRequest request, string victimId)
        {
            if (string.IsNullOrWhiteSpace(request.Description))
                throw new ArgumentException("Description cannot be empty.");
            
            if (string.IsNullOrWhiteSpace(request.Location))
                throw new ArgumentException("Location cannot be empty.");

            var emergency = new Emergency
            {
                VictimId = victimId,
                Description = request.Description,
                Location = request.Location,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow
            };

            await _repository.CreateAsync(emergency);
        }

        public async Task<bool> AcceptAsync(int id, string responderId)
        {
            var emergency = await _repository.GetByIdAsync(id);
            if (emergency == null) return false;

            if (emergency.Status == "Assigned")
            {
                throw new InvalidOperationException("This emergency has already been accepted.");
            }

            emergency.Status = "Assigned";
            emergency.ResponderId = responderId;

            await _repository.UpdateAsync(emergency);
            return true;
        }

        public async Task<IEnumerable<Emergency>> GetAllEmergenciesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<bool> UpdateAsync(int id, UpdateEmergencyRequest request)
        {
            var emergency = await _repository.GetByIdAsync(id);
            if (emergency == null) return false;

            if (!string.IsNullOrWhiteSpace(request.Description)) emergency.Description = request.Description;
            if (!string.IsNullOrWhiteSpace(request.Location)) emergency.Location = request.Location;
            if (!string.IsNullOrWhiteSpace(request.Status)) emergency.Status = request.Status;

            await _repository.UpdateAsync(emergency);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var emergency = await _repository.GetByIdAsync(id);
            if (emergency == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
