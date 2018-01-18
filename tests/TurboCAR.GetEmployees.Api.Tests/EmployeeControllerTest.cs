using Newtonsoft.Json;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboCAR.GetEmployees.Api.Controllers;
using TurboCAR.GetEmployees.Model;
using TurboCAR.GetEmployees.Repository;
using Xunit;

namespace TurboCAR.GetEmployees.Api.Tests
{
    public class EmployeeControllerTest
    {
        private EmployeeController controller = null;
        private IEmployeeRepository repository = null;
        private Employee expectedEmployee = null;
        private List<Employee> employees = null;
        public EmployeeControllerTest()
        {
            repository = Substitute.For<IEmployeeRepository>();
            controller = new EmployeeController(repository);
            expectedEmployee = new Employee() { Id = "E1000280", Name = "Yash Chawla", TeamId = 101 };
            //update data for fix the tests here

            employees = JsonConvert.DeserializeObject<List<Employee>>("[{\"id\":\"E1000280\",\"name\":\"Yash Chawla\",\"teamId\":101},{\"id\":\"E1000281\",\"name\":\"Nithya Dhamodharan\",\"teamId\":102},{\"id\":\"E1000282\",\"name\":\"Thomas Armstrong\",\"teamId\":103},{\"id\":\"E1000283\",\"name\":\"Dino Pillinini\",\"teamId\":104},{\"id\":\"E1000301\",\"name\":\"Daniel Aguilar\",\"teamId\":101},{\"id\":\"E1000302\",\"name\":\"Carley Brandt\",\"teamId\":102},{\"id\":\"E1000303\",\"name\":\"Claudia Canales\",\"teamId\":103},{\"id\":\"E1000304\",\"name\":\"Jamie Davidson\",\"teamId\":104}]");
        }

        [Fact]
        public async Task GetAsyncTest()
        {
            repository.GetAsync().Returns(Task.Run(() => employees));
            var result = controller.Get();
            int actual = result.Result.Count;
            Assert.True(actual == employees.Count);
        }

        [Fact]
        public async Task GetAsyncWithParameterTest()
        {
            repository.GetAsync(Arg.Any<string>()).Returns(Task.Run(() => expectedEmployee));
            var actual = repository.GetAsync("E1000280").Result;
            Assert.True(actual.Id == expectedEmployee.Id && actual.Name == expectedEmployee.Name && actual.TeamId == expectedEmployee.TeamId);
        }
    }
}
