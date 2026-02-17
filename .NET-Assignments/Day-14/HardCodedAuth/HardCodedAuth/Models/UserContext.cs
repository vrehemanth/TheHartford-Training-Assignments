using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace AAApi.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options){}
        public DbSet<UserClass> Users { get; set; }
    }
}
