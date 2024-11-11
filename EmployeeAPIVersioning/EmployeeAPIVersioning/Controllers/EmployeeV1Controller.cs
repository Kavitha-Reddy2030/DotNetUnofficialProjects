using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAPI.Services;
using EmployeeAPIVersioning.DTO;
using EmployeeAPIVersioning.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPIVersioning.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class EmployeeV1Controller : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeV1Controller(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadEmployeeDTO>>> GetAllEmployees()
        {
            return Ok(await _service.GetAllEmployees());
        }

        [HttpGet("{id}", Name = "GetEmployeeByIdV1")]
        public async Task<ActionResult<ReadEmployeeDTO>> GetEmployeeById(int id)
        {
            var employee = await _service.GetEmployeeById(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee(CreateEmployeeDTO employeeCreateDto)
        {
            await _service.AddEmployee(employeeCreateDto);
            return Ok(employeeCreateDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, UpdateEmployeeDTO employeeUpdateDto)
        {
            await _service.UpdateEmployee(id, employeeUpdateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            await _service.DeleteEmployee(id);
            return NoContent();
        }
    }
}
