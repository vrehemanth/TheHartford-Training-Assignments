using HospitalService.Application.Common.Interfaces;
using HospitalService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalService.Infrastructure.Persistence
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly HospitalDbContext _context;

        public HospitalRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Hospital hospital)
        {
            _context.Hospitals.Add(hospital);
            await _context.SaveChangesAsync();
        }

        public async Task<Hospital?> GetByIdAsync(int id)
        {
            return await _context.Hospitals.FindAsync(id);
        }

        public async Task<IEnumerable<Hospital>> GetAllAsync()
        {
            return await _context.Hospitals.ToListAsync();
        }

        public async Task UpdateAsync(Hospital hospital)
        {
            _context.Hospitals.Update(hospital);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var hospital = await _context.Hospitals.FindAsync(id);
            if (hospital != null)
            {
                _context.Hospitals.Remove(hospital);
                await _context.SaveChangesAsync();
            }
        }
    }
}
