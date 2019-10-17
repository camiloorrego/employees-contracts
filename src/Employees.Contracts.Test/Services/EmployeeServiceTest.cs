using Employees.Contracts.Domain.Entities;
using Employees.Contracts.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Employees.Contracts.Test.Services
{
   public class EmployeeServiceTest
    {
        private readonly Mock<IEmployeeRepository> _employeeRepository;
        private readonly EmployeeService _employeesService;
        public EmployeeServiceTest()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();
            _employeesService = new EmployeeService(_employeeRepository.Object);
        }

        [Fact]
        public async void GetAll()
        {
            var expected = new Employee[]
                 {
                    new HourlyEmployee { Id = 1, Name = "Employee 1" },
                    new HourlyEmployee { Id = 2, Name = "Employee 2" },
                    new HourlyEmployee { Id = 3, Name = "Employee 3" }
                 };
            _employeeRepository.Setup(x => x.GetEmployeesAsync()).ReturnsAsync(expected);

            // Act
            var result = await _employeesService.GetEmployees();

            // Assert
            var okResult = Assert.IsType<Employee[]>(result);
            Assert.Equal(expected.Length, okResult.Length);

        }
    }
}
