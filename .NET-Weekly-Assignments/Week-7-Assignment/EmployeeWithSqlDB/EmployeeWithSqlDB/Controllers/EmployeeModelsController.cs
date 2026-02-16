using Employee.DTOs;
using Employee.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeModelsController : ControllerBase
    {
        // EF Core DbContext for database operations
        private readonly EmployeeContext _context;

        // Constructor injection of DbContext (Dependency Injection)
        public EmployeeModelsController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadEmployeesDTO>>> GetEmployees()
        {
            // Include Department
            // Select maps entity to DTO
            var employees = await _context.EmployeeList
            .Include(e => e.Department)
            .Select(e => new ReadEmployeesDTO
            {
                Id = e.Id,
                Name = e.Name,
                Salary = e.Salary,
                IsActive = e.IsActive,
                // Department info from navigation property
                DepartmentId = e.Department!.Id,
                DepartmentName = e.Department.DeptName
            })
            .ToListAsync();

            return Ok(employees);
        }

        // GET: api/EmployeeModels/id
        [HttpGet("{Id}")]
        public async Task<ActionResult<ReadEmployeesDTO>> GetEmployeeById(long Id)
        {
            // Query employee by Id
            var employee = await _context.EmployeeList
            .Include(e => e.Department)
            .Where(e => e.Id == Id)
            .Select(e => new ReadEmployeesDTO
            {
                Id = e.Id,
                Name = e.Name,
                Salary = e.Salary,
                IsActive = e.IsActive,
                DepartmentId = e.Department!.Id,
                DepartmentName = e.Department.DeptName
            })
            .FirstOrDefaultAsync();

            // If employee not found 
            if (employee == null)
            {
                return NotFound($"Employee with EmpId {Id} not found.");
            }

            return Ok(employee);
        }

        // POST: api/EmployeeModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeModel>> PostEmployeeModel(CreateEmployeeDTO dto)
        {
            // Find department by name
            var department = await _context.Departments
            .FirstOrDefaultAsync(d => d.DeptName == dto.DepartmentName);

            // If department not found
            if (department == null)
            {
                return BadRequest($"Department '{dto.DepartmentName}' not found.");
            }

            // Generate next Employee Id manually
            long nextEmpId = (await _context.EmployeeList.AnyAsync())
            ? await _context.EmployeeList.MaxAsync(e => e.Id) + 1 : 1;

            var employee = new EmployeeModel
            {
                Id = nextEmpId,
                Name = dto.Name,
                Salary = dto.Salary,
                IsActive = dto.IsActive,
                // Foreign key linking to Department
                DepartmentId = department.Id
            };

            _context.EmployeeList.Add(employee);
            await _context.SaveChangesAsync();

            return Ok(new ReadEmployeesDTO
            {
                Id = employee.Id,
                Name = dto.Name,
                Salary = dto.Salary,
                IsActive = dto.IsActive,
                DepartmentId = department.Id,
                DepartmentName= department.DeptName
            });
        }

        // PUT: api/EmployeeModels/id
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutEmployee(int Id, CreateEmployeeDTO dto)
        {
            // Find employee by Id
            var employee = await _context.EmployeeList
                .FirstOrDefaultAsync(e => e.Id == Id);

            // If employee not found
            if (employee == null)
            {
                return NotFound($"Employee with EmpId {Id} not found.");
            }

            // Find department by name
            var department = await _context.Departments
                .FirstOrDefaultAsync(d => d.DeptName.Equals(dto.DepartmentName, StringComparison.OrdinalIgnoreCase));

            if (department == null)
            {
                return BadRequest($"Department '{dto.DepartmentName}' not found.");
            }

            // Update fields
            employee.Name = dto.Name;
            employee.Salary = dto.Salary;
            employee.IsActive = dto.IsActive;
            employee.DepartmentId = department.Id;

            await _context.SaveChangesAsync();

            return Ok("Updation Successful");
        }

        // PATCH: api/EmployeeModels/id
        [HttpPatch("{Id}")]
        public async Task<IActionResult> UpdateSalary(long Id, UpdateSalaryDTO dto)
        {
            // Find employee by Id
            var employee = await _context.EmployeeList.FindAsync(Id);

            // If employee not found
            if (employee == null)
            {
                return NotFound($"Employee with Id {Id} not found.");
            }

            //Update Salary
            employee.Salary = dto.Salary;

            await _context.SaveChangesAsync();

            return Ok("Salary Updation Successfully");
        }
        // DELETE: api/EmployeeModels/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeModel(long id)
        {
            // Find employee by Id
            var employeeModel = await _context.EmployeeList.FindAsync(id);

            // If employee not found
            if (employeeModel == null)
            {
                return NotFound();
            }

            // Remove employee
            _context.EmployeeList.Remove(employeeModel);
            await _context.SaveChangesAsync();

            return Ok("Deletion Successful");
        }
    }
}
