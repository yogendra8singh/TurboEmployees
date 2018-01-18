using Newtonsoft.Json;
using Serilog;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboCAR.GetEmployees.Model;

namespace TurboCAR.GetEmployees.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public EmployeeRepository()
        {
        }

        public async Task<List<Employee>> GetAsync(int teamId)
        {
            var Employees = await GetAsync();
            return Employees.Where(x => x.TeamId == teamId).ToList();
        }

        public async Task<Employee> GetAsync(string employeeId)
        {
            var Employees = await GetAsync();
            return Employees.Find(x => x.Id == employeeId);
        }


      

        public async Task<List<Employee>> GetAsync()
        {

            try
            {
                ConnectionMultiplexer Connection = ConnectionMultiplexer.Connect("52.163.252.25:6379");
                IDatabase cache = Connection.GetDatabase();
                string value = cache.StringGet("TurboCAR.EmployeeList");
                var Employees = JsonConvert.DeserializeObject<List<Employee>>(value);
                return Employees;
            }
            catch (Exception ex)
            {
                Log.Error<Exception>("Error", ex);
                throw;
            }


        }

       
    }
}
