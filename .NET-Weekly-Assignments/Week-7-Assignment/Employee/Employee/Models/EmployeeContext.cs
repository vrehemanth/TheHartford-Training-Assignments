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
    }
}
