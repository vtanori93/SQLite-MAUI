using SQLite;

namespace Test.Models.SQLiteDB
{
    public class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid SalaryId { get; set; }
        public Guid EmployeeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
