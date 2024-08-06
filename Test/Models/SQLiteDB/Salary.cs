using SQLite;

namespace Test.Models.SQLiteDB
{
    public class Salary
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public Guid SalaryId { get; set; }
        public Guid EmployeeId { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public double MonthlySalary { get; set; }
    }
}
