using EmergencyService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmergencyService.Infrastructure.Persistence
{
    public class EmergencyDbContext : DbContext
    {
        public EmergencyDbContext(DbContextOptions<EmergencyDbContext> options) : base(options) { }

        public DbSet<Emergency> Emergencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Emergency>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.VictimId).HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Location).HasMaxLength(200);
                entity.Property(e => e.Status).HasMaxLength(50);
                entity.Property(e => e.ResponderId).HasMaxLength(100);
                entity.Property(e => e.HospitalId);
            });
        }
    }
}
