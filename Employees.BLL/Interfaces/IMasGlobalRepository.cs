using Employees.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employees.BLL.Interfaces
{
    public interface IMasGlobalRepository
    {
        Task<List<Employee>> GetEmployeesAsync();
    }
}
