
using SQLite;

namespace Test.Models.SQLiteDB
{
    public class Department
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public Guid DepartmentId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
