using Test.Models;
using Test.Models.SQLiteDB;
namespace Test.SQLiteDB
{
    public interface ISQLiteDB
    {
        Task<Response<bool>> PostDepartmentAsync(Department Department);
        Task<Response<bool>> PostEmployeeAsync(Employee Employee);
        Task<Response<bool>> PostSalaryAsync(Salary Salary);
        Task<Response<List<Department>>> GetDepartmentAsync();
        Task<Response<List<Employee>>> GetEmployeeAsync();
        Task<Response<List<Salary>>> GetSalaryAsync();
        Task<Response<bool>> DeleteDepartmentAsync(Guid DepartmentId);
        Task<Response<bool>> DeleteEmployeeAsync(Guid EmployeeId);
    }
}
