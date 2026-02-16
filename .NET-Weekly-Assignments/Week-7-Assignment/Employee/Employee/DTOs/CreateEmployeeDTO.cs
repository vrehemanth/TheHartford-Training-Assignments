namespace Employee.DTOs
{
    public class CreateEmployeeDTO
    {
        public required string Name { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public required string DepartmentName { get; set; }
    }
}
