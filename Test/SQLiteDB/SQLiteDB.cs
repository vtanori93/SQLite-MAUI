using Test.Models;
using Test.Models.Exercise;
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
        public async Task<Response<bool>> DeleteEmployeeAsync(Guid EmployeeId)
        {
            var Response = new Response<bool>();
            try
            {
                if (App.Database != null)
                {
                    var Result = await App.Database.Table<Models.SQLiteDB.Employee>().Where(x => x.EmployeeId == EmployeeId).FirstOrDefaultAsync();
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
        public async Task<Response<List<Exercise1>>> GetExercise1Async()
        {
            var Response = new Response<List<Exercise1>> { Data = new List<Exercise1>() };
            try
            {
                if (App.Database != null)
                {
                    var Employees = await App.Database.Table<Employee>().ToListAsync();
                    var Salaries = await App.Database.Table<Salary>().ToListAsync();
                    var Departments = await App.Database.Table<Department>().ToListAsync();
                    Response.Data = Employees.Select(e => new Exercise1
                    {
                        EmployeeId = e.EmployeeId,
                        Name = e.Name,
                        DepartmentId = e.DepartmentId,
                        PaymentMethod = Salaries.FirstOrDefault(s => s.EmployeeId == e.EmployeeId)?.PaymentMethod,
                        MonthlySalary = Salaries.FirstOrDefault(s => s.EmployeeId == e.EmployeeId)?.MonthlySalary,
                        Description = Departments.FirstOrDefault(d => d.DepartmentId == e.DepartmentId)?.Description
                    }).ToList();
                }
            }
            catch (Exception Ex)
            {
                Response.Error = true;
                Response.Message = Ex.ToString();
            }
            return await Task.FromResult(Response);
        }
        public async Task<Response<List<Exercise2>>> GetExercise2Async()
        {
            var Response = new Response<List<Exercise2>> { Data = new List<Exercise2>() };
            try
            {
                if (App.Database != null)
                {
                    var Employees = await App.Database.Table<Employee>().ToListAsync();
                    var Departments = await App.Database.Table<Department>().ToListAsync();
                    var DepartmentIdsWithEmployees = Employees.Select(e => e.DepartmentId).Distinct();
                    Response.Data = Departments
                        .Where(d => DepartmentIdsWithEmployees.Contains(d.DepartmentId))
                        .Select(d => new Exercise2 { Description = d.Description }).ToList();
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
