using Employees.Contracts.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Contracts.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
    }
}
