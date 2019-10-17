using Employees.Contracts.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Contracts.Domain.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(int id);
    }
}
