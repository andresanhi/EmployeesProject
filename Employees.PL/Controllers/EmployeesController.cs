using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employees.BLL.Exceptions;
using Employees.BLL.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employees.PL.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        //GET: api/Employees
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _employeeService.GetEmployees());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //GET: api/Employees/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _employeeService.GetEmployeeById(id));
            }
            catch (NotFoundException nfe)
            {
                return NotFound(new { message = nfe.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}