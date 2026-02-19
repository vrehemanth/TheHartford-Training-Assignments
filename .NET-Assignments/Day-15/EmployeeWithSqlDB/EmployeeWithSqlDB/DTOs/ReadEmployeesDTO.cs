namespace Employee.DTOs
{
    public class ReadEmployeesDTO
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public long DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
    }
}
