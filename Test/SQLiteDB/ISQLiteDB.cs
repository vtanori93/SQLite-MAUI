using Test.Models;
using Test.Models.Exercise;
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
        Task<Response<List<Exercise1>>> GetExercise1Async();
        Task<Response<List<Exercise2>>> GetExercise2Async();
        Task<Response<List<Exercise3>>> GetExercise3Async();
        Task<Response<List<Exercise4>>> GetExercise4Async();
        Task<Response<List<Exercise5>>> GetExercise5Async();
        Task<Response<List<Exercise6>>> GetExercise6Async();
        Task<Response<List<Exercise7>>> GetExercise7Async(Guid DepartmentId);
    }
}
