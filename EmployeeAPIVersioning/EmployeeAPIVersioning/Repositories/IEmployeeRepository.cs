using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAPIVersioning.DTO;
using EmployeeAPIVersioning.Models;

namespace EmployeeAPIVersioning.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int id);
        Task<(IEnumerable<ReadEmployeeDTO> Employees, int TotalCount)> GetFilteredSortedEmployeesAsync(EmployeeFilterDTO filter);
    }
}
