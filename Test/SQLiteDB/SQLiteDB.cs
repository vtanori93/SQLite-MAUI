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
        public async Task<Response<List<Exercise3>>> GetExercise3Async()
        {
            var Response = new Response<List<Exercise3>> { Data = new List<Exercise3>() };
            try
            {
                if (App.Database != null)
                {
                    var Employees = await App.Database.Table<Employee>().ToListAsync();
                    var Departments = await App.Database.Table<Department>().ToListAsync();
                    var Salaries = await App.Database.Table<Salary>().ToListAsync();

                    var DepartmentSalaries = from emp in Employees
                                             join sal in Salaries on emp.EmployeeId equals sal.EmployeeId
                                             join dep in Departments on emp.DepartmentId equals dep.DepartmentId
                                             group new { dep, sal } by new { dep.DepartmentId, dep.Description, sal.PaymentMethod } into g
                                             select new Exercise3
                                             {
                                                 DepartmentId = g.Key.DepartmentId,
                                                 DepartmentDescription = g.Key.Description,
                                                 PaymentMethod = g.Key.PaymentMethod,
                                                 TotalSalary = g.Sum(x => decimal.Parse(x.sal.MonthlySalary))
                                             };
                    Response.Data = DepartmentSalaries.ToList();
                }
            }
            catch (Exception Ex)
            {
                Response.Error = true;
                Response.Message = Ex.ToString();
            }
            return await Task.FromResult(Response);
        }
        public async Task<Response<List<Exercise4>>> GetExercise4Async()
        {
            var Response = new Response<List<Exercise4>> { Data = new List<Exercise4>() };
            try
            {
                if (App.Database != null)
                {
                    var Employees = await App.Database.Table<Employee>().ToListAsync();
                    var Salaries = await App.Database.Table<Salary>().ToListAsync();
                    var EmployeesOver30WithHighSalary = from emp in Employees
                                                        join sal in Salaries on emp.EmployeeId equals sal.EmployeeId
                                                        where (DateTime.Now.Year - emp.DateBirth.Year) > 30 && decimal.Parse(sal.MonthlySalary) > 6000
                                                        orderby decimal.Parse(sal.MonthlySalary) descending
                                                        select new Exercise4
                                                        {
                                                            EmployeeId = emp.EmployeeId,
                                                            Name = emp.Name,
                                                            DateBirth = emp.DateBirth,
                                                            MonthlySalary = decimal.Parse(sal.MonthlySalary)
                                                        };
                    Response.Data = EmployeesOver30WithHighSalary.ToList();
                }
            }
            catch (Exception Ex)
            {
                Response.Error = true;
                Response.Message = Ex.ToString();
            }
            return await Task.FromResult(Response);
        }
        public async Task<Response<List<Exercise5>>> GetExercise5Async()
        {
            var Response = new Response<List<Exercise5>> { Data = new List<Exercise5>() };
            try
            {
                if (App.Database != null)
                {
                    var Employees = await App.Database.Table<Employee>().ToListAsync();
                    var currentYear = DateTime.Now.Year;
                    var EmployeesJoinedThisYear = Employees
                        .Where(emp => emp.DateOfJoining.Year == currentYear)
                        .Select(emp => new Exercise5
                        {
                            EmployeeId = emp.EmployeeId,
                            Name = emp.Name,
                            DateOfJoining = emp.DateOfJoining
                        }).ToList();

                    Response.Data = EmployeesJoinedThisYear;
                }
            }
            catch (Exception Ex)
            {
                Response.Error = true;
                Response.Message = Ex.ToString();
            }
            return await Task.FromResult(Response);
        }
        public async Task<Response<List<Exercise6>>> GetExercise6Async()
        {
            var Response = new Response<List<Exercise6>> { Data = new List<Exercise6>() };
            try
            {
                if (App.Database != null)
                {
                    var Employees = await App.Database.Table<Employee>().ToListAsync();
                    var currentDate = DateTime.Now;
                    var EmployeesWithAge = Employees
                        .Select(emp => new Exercise6
                        {
                            Name = emp.Name,
                            Age = currentDate.Year - emp.DateBirth.Year - (currentDate.DayOfYear < emp.DateBirth.DayOfYear ? 1 : 0),
                            DateBirth = emp.DateBirth
                        })
                        .OrderByDescending(emp => emp.Age)
                        .ToList();
                    Response.Data = EmployeesWithAge;
                }
            }
            catch (Exception Ex)
            {
                Response.Error = true;
                Response.Message = Ex.ToString();
            }
            return await Task.FromResult(Response);
        }
        public async Task<Response<List<Exercise7>>> GetExercise7Async(Guid DepartmentId)
        {
            var Response = new Response<List<Exercise7>> { Data = new List<Exercise7>() };
            try
            {
                if (App.Database != null)
                {
                    var Employees = await App.Database.Table<Employee>().Where(e => e.DepartmentId == DepartmentId).ToListAsync();
                    var Salaries = await App.Database.Table<Salary>().ToListAsync();
                    var EmployeesOver30WithHighSalary = from emp in Employees
                                                        join sal in Salaries on emp.EmployeeId equals sal.EmployeeId
                                                        where (DateTime.Now.Year - emp.DateBirth.Year) > 30
                                                              && decimal.Parse(sal.MonthlySalary) > 6000
                                                        orderby decimal.Parse(sal.MonthlySalary) descending
                                                        select new Exercise7
                                                        {
                                                            EmployeeId = emp.EmployeeId,
                                                            Name = emp.Name,
                                                            DateBirth = emp.DateBirth,
                                                            MonthlySalary = decimal.Parse(sal.MonthlySalary)
                                                        };
                    Response.Data = EmployeesOver30WithHighSalary.ToList();
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
