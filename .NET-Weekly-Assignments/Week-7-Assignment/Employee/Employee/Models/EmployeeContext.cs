using Microsoft.EntityFrameworkCore;

namespace Employee.Models
{
    public class EmployeeContext : DbContext
    {
        // Constructor receives DbContextOptions from dependency injection
        public EmployeeContext(DbContextOptions options) : base(options){}
        // DbSet representing Employees table in the database
        public DbSet<EmployeeModel> Employees { get; set; } = null!;

        // DbSet representing Departments table
        public DbSet<DepartmentModel> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed initial Department data into the InMemory database
            modelBuilder.Entity<DepartmentModel>().HasData(
                new DepartmentModel { Id = 10, DeptName = "IT" },
                new DepartmentModel { Id = 20, DeptName = "HR" },
                new DepartmentModel { Id = 30, DeptName = "Finance" }
            );
        }
    }
}
