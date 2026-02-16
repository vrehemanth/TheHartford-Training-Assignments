using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee.Models;

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentModelsController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public DepartmentModelsController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/DepartmentModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentModel>>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        // GET: api/DepartmentModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentModel>> GetDepartmentModel(long id)
        {
            var departmentModel = await _context.Departments.FindAsync(id);

            if (departmentModel == null)
            {
                return NotFound();
            }

            return departmentModel;
        }

        // PUT: api/DepartmentModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartmentModel(long id, DepartmentModel departmentModel)
        {
            if (id != departmentModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(departmentModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentModelExists(id))
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

        // POST: api/DepartmentModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DepartmentModel>> PostDepartmentModel(DepartmentModel departmentModel)
        {
            _context.Departments.Add(departmentModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartmentModel", new { id = departmentModel.Id }, departmentModel);
        }

        // DELETE: api/DepartmentModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartmentModel(long id)
        {
            var departmentModel = await _context.Departments.FindAsync(id);
            if (departmentModel == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(departmentModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartmentModelExists(long id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }
    }
}
