using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.BLL.Models
{
    public class HourlyEmployee : Employee
    {
        public override double CalculateSalary()
        {
            return 120 * HourlySalary * 12;
        }
    }
}
