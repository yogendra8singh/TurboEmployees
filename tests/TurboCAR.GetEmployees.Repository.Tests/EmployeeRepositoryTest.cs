using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboCAR.GetEmployees.Model;
using Xunit;

namespace TurboCAR.GetEmployees.Repository.Tests
{
    public class EmployeeRepositoryTest
    {
        private EmployeeRepository repository = null;
        private Employee expectedEmployee = null;
        private int expectedCount = 388;
        private int expectedTeamMembersCount = 19;
        public EmployeeRepositoryTest()
        {
            repository = new EmployeeRepository();
            expectedEmployee = new Employee() { Id = "E1000280", Name = "Yash Chawla", TeamId = 101 };
        }

        [Fact]
        public async Task GetAsyncTest()
        {
            var result = repository.GetAsync();
            int actual = result.Result.Count;
            Assert.True(actual == expectedCount);
        }

        [Fact]
        public async Task GetAsyncWithTeamIdTest()
        {
            var result = repository.GetAsync(101);
            int actual = result.Result.Count;
            Assert.True(actual == expectedTeamMembersCount);
        }

        [Fact]
        public async Task GetAsyncWithEmployeeIdTest()
        {
            var actual = repository.GetAsync("E1000280").Result;
            Assert.True(actual.Id == expectedEmployee.Id && actual.Name == expectedEmployee.Name && actual.TeamId == expectedEmployee.TeamId);
        }

    }
}
