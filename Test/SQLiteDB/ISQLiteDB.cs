using Test.Models;
using Test.Models.SQLiteDB;
namespace Test.SQLiteDB
{
    public interface ISQLiteDB
    {
        Task<Response<bool>> PostDepartmentAsync(Department Department);
        Task<Response<bool>> PostEmployeeAsync(Employee Employee);
        Task<Response<bool>> PostSalaryAsync(Salary Salary);
    }
}
