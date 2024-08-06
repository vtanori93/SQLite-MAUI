namespace Test.Models.SQLiteDB
{
    public class Salary
    {
        public Guid SalaryId { get; set; }
        public Guid EmployeeId { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public double MonthlySalary { get; set; }
    }
}
