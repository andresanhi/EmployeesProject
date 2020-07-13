using Employees.BLL.Enums;
using Employees.BLL.Factories;
using Employees.BLL.Models;
using Employees.DAL.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.DAL.Mappers
{
    public static class EmployeeMapper
    {
        internal static List<Employee> Map(this List<EmployeeData> items)
        {
            List<Employee> employees = new List<Employee>();
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
                    employee.AnnualSalary = employee.CalculateSalary();

                    employees.Add(employee);
                }
            }
            return employees;
        }
    }
}
