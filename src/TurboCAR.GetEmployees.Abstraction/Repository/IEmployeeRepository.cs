using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboCAR.GetEmployees.Model;

namespace TurboCAR.GetEmployees.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAsync();
        Task<List<Employee>> GetAsync(int teamId);
        Task<Employee> GetAsync(string employeeId);
    }
}
