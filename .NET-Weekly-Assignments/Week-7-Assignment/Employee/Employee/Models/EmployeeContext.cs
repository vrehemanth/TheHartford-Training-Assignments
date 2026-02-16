using Microsoft.EntityFrameworkCore;

namespace Employee.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<EmployeeModel> Employees { get; set; } = null!;
        public DbSet<DepartmentModel> Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentModel>().HasData(
                new DepartmentModel { Id = 10, DeptName = "IT" },
                new DepartmentModel { Id = 20, DeptName = "HR" },
                new DepartmentModel { Id = 30, DeptName = "Finance" }
            );
        }
    }
}
