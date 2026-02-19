using Employee.Models;
using EmployeeWithSqlDB.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentModelsController :ControllerBase
    {
        private readonly IDepartmentRepository _repo;

        public DepartmentModelsController(IDepartmentRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentModel>>> GetDepartments()
        {
            var departments = await _repo.GetAllAsync();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentModel>> GetDepartmentModel(long id)
        {
            var dept = await _repo.GetByIdAsync(id);
            if (dept == null) return NotFound();

            return Ok(dept);
        }

        [HttpPost]
        public async Task<ActionResult<DepartmentModel>> PostDepartmentModel(DepartmentModel departmentModel)
        {
            var created = await _repo.AddAsync(departmentModel);

            return CreatedAtAction(nameof(GetDepartmentModel),
                new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartmentModel(long id, DepartmentModel departmentModel)
        {
            if (id != departmentModel.Id)
                return BadRequest();

            var exists = await _repo.ExistsAsync(id);
            if (!exists) return NotFound();

            await _repo.UpdateAsync(departmentModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartmentModel(long id)
        {
            var deleted = await _repo.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
