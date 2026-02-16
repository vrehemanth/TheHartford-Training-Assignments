using Employee.DTOs;
using Employee.Models;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeModelsController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public EmployeeModelsController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadEmployeesDTO>>> GetEmployees()
        {
            var employees = await _context.Employees
            .Include(e => e.Department)
            .Select(e => new ReadEmployeesDTO
            {
                Id = e.Id,
                Name = e.Name,
                Salary = e.Salary,
                IsActive = e.IsActive,
                DepartmentId = e.Department!.Id,
                DepartmentName = e.Department.DeptName
            })
            .ToListAsync();

            return Ok(employees);
        }

        // GET: api/EmployeeModels/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<ReadEmployeesDTO>> GetEmployeeById(long Id)
        {
            var employee = await _context.Employees
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
            var department = await _context.Departments
            .FirstOrDefaultAsync(d => d.DeptName == dto.DepartmentName);
            if (department == null)
            {
                return BadRequest($"Department '{dto.DepartmentName}' not found.");
            }
            long nextEmpId = (await _context.Employees.AnyAsync())
            ? await _context.Employees.MaxAsync(e => e.Id) + 1 : 1;
            var employee = new EmployeeModel
            {
                Id = nextEmpId,
                Name = dto.Name,
                Salary = dto.Salary,
                IsActive = dto.IsActive,
                DepartmentId = department.Id
            };

            _context.Employees.Add(employee);
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

        // PUT: api/EmployeeModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutEmployee(int Id, CreateEmployeeDTO dto)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == Id);

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

        // PATCH: api/EmployeeModels
        [HttpPatch("{Id}")]
        public async Task<IActionResult> UpdateSalary(long Id, UpdateSalaryDTO dto)
        {
            var employee = await _context.Employees.FindAsync(Id);

            if (employee == null)
            {
                return NotFound($"Employee with Id {Id} not found.");
            }

            employee.Salary = dto.Salary;

            await _context.SaveChangesAsync();

            return Ok("Salary Updation Successfully");
        }
        // DELETE: api/EmployeeModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeModel(long id)
        {
            var employeeModel = await _context.Employees.FindAsync(id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employeeModel);
            await _context.SaveChangesAsync();

            return Ok("Deletion Successful");
        }
    }
}
