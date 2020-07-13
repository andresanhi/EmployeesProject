using Employees.BLL.Enums;
using Employees.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.BLL.Factories
{
    public static class EmployeeFactory
    {
        public static Employee Build (ContractType type)
        {
            switch (type)
            {
                case ContractType.HourlySalaryEmployee:
                    return new HourlyEmployee();
                case ContractType.MonthlySalaryEmployee:
                    return new MonthlyEmployee();
                default:
                    return null;
            }
        }
    }
}
