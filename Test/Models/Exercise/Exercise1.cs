namespace Test.Models.Exercise
{
    public class Exercise1
    {
        public Guid EmployeeId { get; set; }
        public Guid DepartmentId { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? PaymentMethod { get; set; } = string.Empty;
        public string? MonthlySalary { get; set; } = string.Empty;
    }
}
