using EFSeedingDemo.DTOs;
using EFSeedingDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFSeedingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CountriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            var countries = await _context.Countries
                .Include(c => c.States)
                .Select(c => new
                {
                    c.CountryId,
                    c.CountryName,
                    c.CountryCode,
                    States = c.States!.Select(s => s.StateName).ToList()
                })
                .ToListAsync();
            return Ok(countries);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await _context.Countries
                .Where(c=>c.CountryId == id)
                .Include(c => c.States)
                .Select(c => new
                {
                    c.CountryId,
                    c.CountryName,
                    c.CountryCode,
                    States = c.States!
                    .Select(s => s.StateName)
                    .ToList()
                }).FirstOrDefaultAsync();
            if(country== null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, CreateCountry dto)
        {
            var country = await _context.Countries.FindAsync(id);

            if (country == null)
                return NotFound();
            country.CountryName = dto.CountryName!;
            country.CountryCode = dto.CountryCode!;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // PATCH: api/Countries/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchCountryCode(int id,[FromBody] string countryCode)
        {
            var country = await _context.Countries.FindAsync(id);

            if (country == null)
                return NotFound();

            country.CountryCode = countryCode;

            await _context.SaveChangesAsync();

            return NoContent();
        }
        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(CreateCountry dto)
        {
            var country = new Country
            {
                CountryName = dto.CountryName!,
                CountryCode = dto.CountryCode!
            };

            _context.Countries.Add(country);
            await _context.SaveChangesAsync();

            return Ok(country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.CountryId == id);
        }
    }
}
