
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeAPIVersioning.DTO;

namespace EmployeeAPI.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<ReadEmployeeDTO>> GetAllEmployees();
        Task<ReadEmployeeDTO> GetEmployeeById(int id);
        Task AddEmployee(CreateEmployeeDTO employeeCreateDto);
        Task UpdateEmployee(int id, UpdateEmployeeDTO employeeUpdateDto);
        Task DeleteEmployee(int id);
        Task<(IEnumerable<ReadEmployeeDTO> Employees, int TotalCount)> GetFilteredSortedEmployees(EmployeeFilterDTO filter);

    }
}
