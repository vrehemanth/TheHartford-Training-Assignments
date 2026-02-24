using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Infrastructure.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options){}
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<StudentEntity> StudentProfiles { get; set; }
        public DbSet<TrainerEntity> TrainerProfiles { get; set; }
        public DbSet<StudyMaterialEntity> StudyMaterials => Set<StudyMaterialEntity>();
        public DbSet<FeedbackEntity> Feedbacks => Set<FeedbackEntity>();
        public DbSet<StudentNoteEntity> StudentNotes => Set<StudentNoteEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ✅ User → StudentProfile (1:1)
            modelBuilder.Entity<UserEntity>()
                .HasOne(u => u.StudentProfile)
                .WithOne(p => p.User)
                .HasForeignKey<StudentEntity>(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // ✅ User → TrainerProfile (1:1)
            modelBuilder.Entity<UserEntity>()
                .HasOne(u => u.TrainerProfile)
                .WithOne(p => p.User)
                .HasForeignKey<TrainerEntity>(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // ✅ Trainer → StudyMaterials (1:M)
            modelBuilder.Entity<StudyMaterialEntity>()
                .HasOne(m => m.Trainer)
                .WithMany(t => t.StudyMaterials)
                .HasForeignKey(m => m.TrainerId)
                .OnDelete(DeleteBehavior.Cascade);


            // ✅ Student → Trainer (M:1)
            modelBuilder.Entity<StudentEntity>()
                .HasOne(s => s.Trainer)
                .WithMany(t => t.Students)
                .HasForeignKey(s => s.TrainerId)
                .OnDelete(DeleteBehavior.SetNull);

            // ✅ Student → Notes (1:M)
            modelBuilder.Entity<StudentNoteEntity>()
                .HasOne(n => n.Student)
                .WithMany(s => s.Notes)
                .HasForeignKey(n => n.StudentId);
        }
    }
}
