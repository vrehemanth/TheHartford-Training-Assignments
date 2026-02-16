namespace Employee.Models
{
    public class EmployeeModel
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        
        // Foreign Key
        public long DepartmentId { get; set; }
        public DepartmentModel? Department { get; set; }
    }
}