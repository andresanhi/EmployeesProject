using Employees.BLL.Interfaces;
using Employees.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Employees.BLL.Exceptions;

namespace Employees.BLL.Services
{
    public class EmployeeService : IEmployeeServices
    {
        private readonly IMasGlobalRepository _repository;
        public EmployeeService(IMasGlobalRepository repository)
        {
            _repository = repository;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var employees = await _repository.GetEmployeesAsync();
            var item = employees.Find(x => x.Id == id);

            if (item == null)
            {
                throw new NotFoundException($"Employee with id: {id} was not found");
            }
            return item;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _repository.GetEmployeesAsync();
        }
    }
}
