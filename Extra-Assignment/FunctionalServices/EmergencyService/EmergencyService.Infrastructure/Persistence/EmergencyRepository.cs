using EmergencyService.Application.Common.Interfaces;
using EmergencyService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmergencyService.Infrastructure.Persistence
{
    public class EmergencyRepository : IEmergencyRepository
    {
        private readonly EmergencyDbContext _context;

        public EmergencyRepository(EmergencyDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Emergency emergency)
        {
            _context.Emergencies.Add(emergency);
            await _context.SaveChangesAsync();
        }

        public async Task<Emergency?> GetByIdAsync(int id)
        {
            return await _context.Emergencies.FindAsync(id);
        }

        public async Task UpdateAsync(Emergency emergency)
        {
            _context.Emergencies.Update(emergency);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Emergency>> GetAllAsync()
        {
            return await _context.Emergencies.ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var emergency = await _context.Emergencies.FindAsync(id);
            if (emergency != null)
            {
                _context.Emergencies.Remove(emergency);
                await _context.SaveChangesAsync();
            }
        }
    }
}
