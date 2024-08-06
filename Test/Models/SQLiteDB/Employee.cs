namespace Test.Models.SQLiteDB
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
