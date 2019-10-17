using Employees.Contracts.Controllers;
using Employees.Contracts.Domain.Entities;
using Employees.Contracts.Domain.Exceptions;
using Employees.Contracts.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Linq;
using System.Net;
using Xunit;

namespace Employees.Contracts.Test.Controllers
{
    public class EmployeesControllerTest
    {
        private readonly Mock<IEmployeeService> _employeeService;
        private readonly EmployeesController _employeesController;
        public EmployeesControllerTest()
        {
            _employeeService = new Mock<IEmployeeService>();
            _employeesController = new EmployeesController(_employeeService.Object);
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
            _employeeService.Setup(x => x.GetEmployees()).ReturnsAsync(expected);

            // Act
            var result = await _employeesController.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Same(expected, okResult.Value);

        }

        [Fact]
        public async void GetAllException()
        {

            _employeeService.Setup(x => x.GetEmployees())
                .Callback(() =>
                {
                    throw new Exception("Exception");
                });

            // Act
            var result = await _employeesController.Get();

            // Assert
            var okResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.InternalServerError, okResult.StatusCode);

        }

        [Fact]
        public async void GetById()
        {
            var expected = new HourlyEmployee { Name = "Employee 1" };

            _employeeService.Setup(x => x.GetEmployeeById(It.IsAny<int>())).ReturnsAsync(expected);

            // Act
            var result = await _employeesController.Get(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Same(expected, okResult.Value);

        }

        [Fact]
        public async void GetByIdNotFoundException()
        {
            var expected = new Employee[]
                 {
                    new HourlyEmployee { Id = 1, Name = "Employee 1" },
                    new HourlyEmployee { Id = 2, Name = "Employee 2" }
                 };

            var id = 3;

            _employeeService.Setup(x => x.GetEmployeeById(It.IsAny<int>()))
                .Callback(() =>
                {
                    if (expected.FirstOrDefault(x => x.Id == id) == null)
                    {
                        throw new EmployeeNotFoundException("Employee not found");
                    }
                });

            // Act
            var result = await _employeesController.Get(1);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);

        }
    }
}
