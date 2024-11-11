using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeAPI.Services;
using EmployeeAPIVersioning.DTO;
using EmployeeAPIVersioning.Models;
using EmployeeAPIVersioning.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPIVersioning.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReadEmployeeDTO>> GetAllEmployees()
        {
            var employees = await _repository.GetAllEmployees();
            return _mapper.Map<IEnumerable<ReadEmployeeDTO>>(employees);
        }

        public async Task<ReadEmployeeDTO> GetEmployeeById(int id)
        {
            var employee = await _repository.GetEmployeeById(id);
            return _mapper.Map<ReadEmployeeDTO>(employee);
        }

        public async Task AddEmployee(CreateEmployeeDTO employeeCreateDto)
        {
            var employee = _mapper.Map<Employee>(employeeCreateDto);
            await _repository.AddEmployee(employee);
        }

        public async Task UpdateEmployee(int id, UpdateEmployeeDTO employeeUpdateDto)
        {
            var employee = await _repository.GetEmployeeById(id);
            if (employee != null)
            {
                _mapper.Map(employeeUpdateDto, employee);
                await _repository.UpdateEmployee(employee);
            }
        }

        public async Task DeleteEmployee(int id)
        {
            await _repository.DeleteEmployee(id);
        }

        public async Task<(IEnumerable<ReadEmployeeDTO> Employees, int TotalCount)> GetFilteredSortedEmployees(EmployeeFilterDTO filter)
        {
            // Calls the repository method for filtering, sorting, and pagination
            var (employees, totalCount) = await _repository.GetFilteredSortedEmployeesAsync(filter);
            return (employees, totalCount);
        }

    }
}
