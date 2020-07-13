using Employees.BLL.Enums;
using Employees.BLL.Factories;
using Employees.BLL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Test.Factories
{
    [TestClass]
    public class EmployeeFactoryTest
    {
        [TestMethod]
        public void Test_Employee_Factory_Correct_Run_For_Monthly_Salary()
        {
            //Params
            Employee employee;
            var contractTypeName = "MonthlySalaryEmployee";
            if (Enum.TryParse(contractTypeName, out ContractType type))
            {
                employee = EmployeeFactory.Build(type);

                employee.Id = 2020;
                employee.Name = "Andres";
                employee.ContractTypeName = "MonthlySalaryEmployee";
                employee.MonthlySalary = 3500;
                employee.HourlySalary = 1000;
                employee.AnnualSalary = employee.CalculateSalary();

                Assert.AreEqual(employee.AnnualSalary, 42000);
            }
        }

        [TestMethod]
        public void Test_Employee_Factory_Correct_Run_For_Hourly_Salary()
        {
            //Params
            Employee employee;
            var contractTypeName = "HourlySalaryEmployee";
            if (Enum.TryParse(contractTypeName, out ContractType type))
            {
                employee = EmployeeFactory.Build(type);

                employee.Id = 2020;
                employee.Name = "Andres";
                employee.ContractTypeName = "MonthlySalaryEmployee";
                employee.MonthlySalary = 3500;
                employee.HourlySalary = 1000;
                employee.AnnualSalary = employee.CalculateSalary();

                Assert.AreEqual(employee.AnnualSalary, 1440000);
            }
        }
    }
}
