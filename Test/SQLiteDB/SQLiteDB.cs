using Test.Models;
using Test.Models.SQLiteDB;
namespace Test.SQLiteDB
{
    public class SQLiteDB : ISQLiteDB
    {
        public async Task<Response<bool>> PostDepartmentAsync(Department Department)
        {
            var Response = new Response<bool>();   
            try
            {

            }
            catch(Exception Ex)
            {
                Response.Error = true;
                Response.Message = Ex.ToString();
            }
            return await Task.FromResult(Response);
        }
        public async Task<Response<bool>> PostEmployeeAsync(Employee Employee)
        {
            var Response = new Response<bool>();
            try
            {

            }
            catch (Exception Ex)
            {
                Response.Error = true;
                Response.Message = Ex.ToString();
            }
            return await Task.FromResult(Response);
        }
        public async Task<Response<bool>> PostSalaryAsync(Salary Salary)
        {
            var Response = new Response<bool>();
            try
            {

            }
            catch (Exception Ex)
            {
                Response.Error = true;
                Response.Message = Ex.ToString();
            }
            return await Task.FromResult(Response);
        }
    }
}
