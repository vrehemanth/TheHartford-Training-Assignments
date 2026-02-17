using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFSeedingDemo.Models;
using EFSeedingDemo.DTOs;

namespace EFSeedingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CitiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            var cities = await _context.Cities.
                Include(c => c.State)
                .Select(c => new 
                {
                    c.CityId,
                    c.CityName,
                    State = c.State!.StateName
                }).ToListAsync();
            return Ok(cities);
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
            var city = await _context.Cities
                .Where(c => c.CityId == id)
                .Include(c => c.State)
                .Select(c => new
                {
                    c.CityId,
                    c.CityName,
                    State = c.State!.StateName
                })
                .FirstOrDefaultAsync();

            if(city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        // PUT: api/Cities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(int id, CreateCity dto)
        {
            var city = await _context.Cities.FindAsync(id);
            if (id != city.CityId)
            {
                return BadRequest();
            }
            city.CityName = dto.CityName!;
            city.StateId = dto.StateId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
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

        //PATCH: api/Cities/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchState(int id, [FromBody] string cityN)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            city.CityName = cityN;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        // POST: api/Cities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<City>> PostCity(CreateCity dto)
        {
            var city=new City
            {
                CityName = dto.CityName!,
                StateId = dto.StateId
            };
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CityExists(int id)
        {
            return _context.Cities.Any(e => e.CityId == id);
        }
    }
}
