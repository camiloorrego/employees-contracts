
using Employees.Contracts.Domain.Entities;
using Employees.Contracts.Domain.Exceptions;
using Employees.Contracts.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Contracts.Domain.Interfaces
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var employees = await _employeeRepository.GetEmployeesAsync();

            var item = employees.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                throw new EmployeeNotFoundException($"Employee with Id: {id} not found.");
            }
            return item;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _employeeRepository.GetEmployeesAsync();
        }
    }
}
