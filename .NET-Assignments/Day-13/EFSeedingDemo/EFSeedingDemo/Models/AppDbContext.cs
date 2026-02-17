using Microsoft.EntityFrameworkCore;

namespace EFSeedingDemo.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Country entity
            modelBuilder.Entity<Country>(entity =>
            {
                // Set the primary key
                entity.HasKey(c => c.CountryId);
                // Configure the one-to-many relationship between Country and State
                entity.HasMany(c => c.States) // A Country has many States
                      .WithOne(s => s.Country) // Each State has one Country
                      .HasForeignKey(s => s.CountryId) // Foreign key in State table
                      .OnDelete(DeleteBehavior.Cascade); // Enable Cascade Delete
            });
            // Configure the State entity
            modelBuilder.Entity<State>(entity =>
            {
                // Set the primary key
                entity.HasKey(s => s.StateId);
                // Configure the one-to-many relationship between State and City
                entity.HasMany(s => s.Cities) // A State has many Cities
                      .WithOne(c => c.State) // Each City has one State
                      .HasForeignKey(c => c.StateId) // Foreign key in City table
                      .OnDelete(DeleteBehavior.Cascade); // Enable Cascade Delete
            });
            // Seed Countries Master Data
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 1, CountryName = "India", CountryCode = "IND" },
                new Country { CountryId = 2, CountryName = "Australia", CountryCode = "AUS" }
            );
            // Seed States Master Data
            modelBuilder.Entity<State>().HasData(
                new State { StateId = 1, StateName = "Odisha", CountryId = 1 },
                new State { StateId = 2, StateName = "Delhi", CountryId = 1 },
                new State { StateId = 3, StateName = "New South Wales", CountryId = 2 }
            );
            // Seed Cities Master Data
            modelBuilder.Entity<City>().HasData(
                new City { CityId = 1, CityName = "Bhubaneswar", StateId = 1 },
                new City { CityId = 2, CityName = "Cuttack", StateId = 1 },
                new City { CityId = 3, CityName = "New Delhi", StateId = 2 },
                new City { CityId = 4, CityName = "Sydney", StateId = 3 }
            );
        }

    }
}
