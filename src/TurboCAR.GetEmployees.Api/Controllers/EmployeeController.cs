using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TurboCAR.GetEmployees.Repository;
using TurboCAR.GetEmployees.Model;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TurboCAR.GetEmployees.Api.Controllers
{

    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {

        private IEmployeeRepository repository;

        public EmployeeController(IEmployeeRepository _repository)
        {
            repository = _repository;
        }

        [HttpGet("{teamId}")]
      
        public async Task<List<Employee>> Get(int teamId)
        {
            return await repository.GetAsync(teamId);
        }


        // GET: api/values
        [HttpGet]
        public async Task<List<Employee>> Get()
        {
            return await repository.GetAsync();
        }

    }
}
