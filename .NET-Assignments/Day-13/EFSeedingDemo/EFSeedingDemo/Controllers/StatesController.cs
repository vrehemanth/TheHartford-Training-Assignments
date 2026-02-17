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
    public class StatesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StatesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/States
        [HttpGet]
        public async Task<ActionResult<IEnumerable<State>>> GetStates()
        {
            var states = await _context.States
            .Include(s => s.Country)
            .Include(s => s.Cities)
            .Select(s => new
             {
                 s.StateId,
                 s.StateName,

                Country = s.Country!.CountryName,

                Cities = s.Cities!
                .Select(c => c.CityName)          
                .ToList()
             })
            .ToListAsync();


            return Ok(states);
        }

        // GET: api/States/5
        [HttpGet("{id}")]
        public async Task<ActionResult<State>> GetState(int id)
        {
            var state = await _context.States
            .Where(s=> s.StateId == id)
            .Include(s => s.Country)
            .Include(s => s.Cities)
            .Select(s => new
            {
                s.StateId,
                s.StateName,
                Country = s.Country!.CountryName,

                Cities = s.Cities!.Select(c => c.CityName).ToList()
            })
            .FirstOrDefaultAsync();

            if (state == null)
            {
                return NotFound();
            }

            return Ok(state);
        }

        // PUT: api/States/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutState(int id, CreateState dto)
        {
            var state = await _context.States.FindAsync(id);
            if (state == null)
            {
               return NotFound();
            }
            state.StateName = dto.StateName!;
            state.CountryId = dto.CountryId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StateExists(id))
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

        //PATCH: api/States/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchState(int id, [FromBody] string StateName)
        {
            var state = await _context.States.FindAsync(id);
            if (state == null)
            {
                return NotFound();
            }
            state.StateName = StateName;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/States
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<State>> PostState(CreateState dto)
        {
            var state = new State
            {
                StateName = dto.StateName!,
                CountryId = dto.CountryId
            };
            _context.States.Add(state);
            await _context.SaveChangesAsync();

            return Ok(state);
        }

        // DELETE: api/States/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteState(int id)
        {
            var state = await _context.States.FindAsync(id);
            if (state == null)
            {
                return NotFound();
            }

            _context.States.Remove(state);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StateExists(int id)
        {
            return _context.States.Any(e => e.StateId == id);
        }
    }
}
