
using EFSeedingDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EFSeedingDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //try
            //{
            //    var options = new DbContextOptionsBuilder<AppDbContext>()
            //    .UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Database=EFSeedingDB;Integrated Security=True;TrustServerCertificate=True")
            //    .Options;
            //    using (var context = new AppDbContext(options))
            //    {
            //        // Retrieve and display Countries
            //        Console.WriteLine("=== Country Master Data ===");
            //        var countries = context.Countries.ToList();
            //        foreach (var country in countries)
            //        {
            //            Console.WriteLine($"Country ID: {country.CountryId}, Name: {country.CountryName}, Code: {country.CountryCode}");
            //        }
            //        // Retrieve and display States
            //        Console.WriteLine("\n=== State Master Data ===");
            //        var states = context.States
            //                            .Include(s => s.Country)
            //                            .ToList();
            //        foreach (var state in states)
            //        {
            //            Console.WriteLine($"State ID: {state.StateId}, Name: {state.StateName}, Country: {state.Country.CountryName}");
            //        }
            //        // Retrieve and display Cities
            //        Console.WriteLine("\n=== City Master Data ===");
            //        var cities = context.Cities
            //                            .Include(c => c.State)
            //                                .ThenInclude(s => s.Country)
            //                            .ToList();
            //        foreach (var city in cities)
            //        {
            //            Console.WriteLine($"City ID: {city.CityId}, Name: {city.CityName}, State: {city.State.StateName}, Country: {city.State.Country.CountryName}");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"An error occurred: {ex.Message}");
            //}

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SeedingDB"))
            );
            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler =
                    System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
