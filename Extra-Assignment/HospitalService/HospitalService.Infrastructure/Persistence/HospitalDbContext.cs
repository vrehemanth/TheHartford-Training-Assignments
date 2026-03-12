using HospitalService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalService.Infrastructure.Persistence
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        public DbSet<Hospital> Hospitals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.HasKey(h => h.Id);
                entity.Property(h => h.Name).IsRequired().HasMaxLength(200);
                entity.Property(h => h.Location).HasMaxLength(500);
                entity.Property(h => h.ContactNumber).HasMaxLength(50);
            });
        }
    }
}
