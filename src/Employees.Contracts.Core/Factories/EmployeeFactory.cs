using Employees.Contracts.Domain.Entities;
using Employees.Contracts.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Contracts.Domain.Factories
{
  public static  class EmployeeFactory
    {
        public static Employee Build(ContractType contractType)
        {
            switch (contractType)
            {
                case ContractType.HourlySalaryEmployee:
                    return new HourlyEmployee();
                case ContractType.MonthlySalaryEmployee:
                    return new MonthlyEmployee();
                default:
                    throw new NotImplementedException("");

            }
        }
    }
}
