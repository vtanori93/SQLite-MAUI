namespace Test.Models.Exercise
{
    public class Exercise3
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentDescription { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public decimal TotalSalary { get; set; }
    }
}
