using Employee.DTOs;
using Employee.Models;
using EmployeeWithSqlDB.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeModelsController :ControllerBase
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeModelsController(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadEmployeesDTO>>> GetEmployees()
        {
            var employees = await _repo.GetAllAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadEmployeesDTO>> GetEmployeeById(long id)
        {
            var employee = await _repo.GetByIdAsync(id);

            if (employee == null)
                return NotFound($"Employee with Id {id} not found.");

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> PostEmployeeModel(CreateEmployeeDTO dto)
        {
            var created = await _repo.AddAsync(dto);

            if (created == null)
                return BadRequest($"Department '{dto.DepartmentName}' not found.");

            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(long id, CreateEmployeeDTO dto)
        {
            var updated = await _repo.UpdateAsync(id, dto);

            if (!updated)
                return NotFound($"Employee or Department not found.");

            return Ok("Updation Successful");
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateSalary(long id, UpdateSalaryDTO dto)
        {
            var updated = await _repo.UpdateSalaryAsync(id, dto);

            if (!updated)
                return NotFound($"Employee with Id {id} not found.");

            return Ok("Salary Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeModel(long id)
        {
            var deleted = await _repo.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return Ok("Deletion Successful");
        }
    }
}
