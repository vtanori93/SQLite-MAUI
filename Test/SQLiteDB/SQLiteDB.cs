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
                if (App.Database != null)
                {
                    Response.Data = Convert.ToBoolean(await App.Database.InsertAsync(Department));
                }
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
                if (App.Database != null)
                {
                    Response.Data = Convert.ToBoolean(await App.Database.InsertAsync(Employee));
                }
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
                if (App.Database != null)
                {
                    Response.Data = Convert.ToBoolean(await App.Database.InsertAsync(Salary));
                }
            }
            catch (Exception Ex)
            {
                Response.Error = true;
                Response.Message = Ex.ToString();
            }
            return await Task.FromResult(Response);
        }
        public async Task<Response<List<Department>>> GetDepartmentAsync()
        {
            var Response = new Response<List<Department>>();
            try
            {
                if(App.Database != null)
                {
                    var Result = App.Database.Table<Department>();
                    Response.Data = await Result.ToListAsync();   
                }                
            }
            catch(Exception Ex)
            {
                Response.Error = true;
                Response.Message = Ex.ToString();
            }
            return await Task.FromResult(Response);            
        }
        public async Task<Response<List<Employee>>> GetEmployeeAsync()
        {
            var Response = new Response<List<Employee>>();
            try
            {
                if (App.Database != null)
                {
                    var Result = App.Database.Table<Employee>();
                    Response.Data = await Result.ToListAsync();
                }
            }
            catch (Exception Ex)
            {
                Response.Error = true;
                Response.Message = Ex.ToString();
            }
            return await Task.FromResult(Response);
        }
        public async Task<Response<List<Salary>>> GetSalaryAsync()
        {
            var Response = new Response<List<Salary>>();
            try
            {
                if (App.Database != null)
                {
                    var Result = App.Database.Table<Salary>();
                    Response.Data = await Result.ToListAsync();
                }
            }
            catch (Exception Ex)
            {
                Response.Error = true;
                Response.Message = Ex.ToString();
            }
            return await Task.FromResult(Response);
        }
        public async Task<Response<bool>> DeleteDepartmentAsync(Guid DepartmentId)
        {
            var Response = new Response<bool>();
            try
            {
                if (App.Database != null)
                {
                    var Result = await App.Database.Table<Models.SQLiteDB.Department>().Where(x => x.DepartmentId == DepartmentId).FirstOrDefaultAsync();
                    if (Result != null)
                    {
                        Response.Data = Convert.ToBoolean(await App.Database.DeleteAsync(Result));
                    }
                }
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
