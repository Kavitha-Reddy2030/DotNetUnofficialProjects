using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAPI.Services;
using EmployeeAPIVersioning.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPIVersioning.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v2")]
    public class EmployeeV2Controller : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeV2Controller(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadEmployeeDTO>>> GetAllEmployees()
        {
            return Ok(await _employeeService.GetAllEmployees());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadEmployeeDTO>> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee(CreateEmployeeDTO employeeCreateDto)
        {
            await _employeeService.AddEmployee(employeeCreateDto);
            return Ok(); // You can change this to CreatedAtAction if you want to return a location
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, UpdateEmployeeDTO employeeUpdateDto)
        {
            await _employeeService.UpdateEmployee(id, employeeUpdateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            await _employeeService.DeleteEmployee(id);
            return NoContent();
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<ReadEmployeeDTO>>> GetFilteredSortedEmployees([FromQuery] EmployeeFilterDTO filter)
        {
            // Log the incoming filter parameters
            Console.WriteLine($"Filter Params: FirstName={filter.FirstName}, Department={filter.Department}, MinSalary={filter.MinSalary}, MaxSalary={filter.MaxSalary}, SortBy={filter.SortBy}, SortDescending={filter.SortDescending}, PageNumber={filter.PageNumber}, PageSize={filter.PageSize}");

            var result = await _employeeService.GetFilteredSortedEmployees(filter);
            return Ok(result.Employees);
        }

    }
}
