using Employees.Contracts.Domain.Entities;
using Employees.Contracts.Domain.Enums;
using Employees.Contracts.Domain.Factories;
using Employees.Contracts.Infraestructure.DataModels;
using System;
using System.Collections.Generic;

namespace Employees.Contracts.Infraestructure.Mappers
{
    public static class EmployeeMapper
    {
        internal static List<Employee> Map(this List<EmployeeResponse> items)
        {
            List<Employee> response = new List<Employee>();
            foreach (var item in items)
            {
                Employee employee;
                if (Enum.TryParse(item.ContractTypeName, out ContractType type))
                {
                    employee = EmployeeFactory.Build(type);

                    employee.Id = item.Id;
                    employee.Name = item.Name;
                    employee.ContractTypeName = item.ContractTypeName;
                    employee.RoleId = item.RoleId;
                    employee.RoleName = item.RoleName;
                    employee.RoleDescription = item.RoleDescription;
                    employee.HourlySalary = item.HourlySalary;
                    employee.MonthlySalary = item.MonthlySalary;

                    employee.Total = employee.CalculateSalary();

                    response.Add(employee);
                }

            }
            return response;
        }
    }
}
