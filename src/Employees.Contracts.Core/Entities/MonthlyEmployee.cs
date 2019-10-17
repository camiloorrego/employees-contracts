using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Contracts.Domain.Entities
{
    public class MonthlyEmployee : Employee
    {
        public override double CalculateSalary()
        {
            return MonthlySalary * 12;
        }
    }
}
