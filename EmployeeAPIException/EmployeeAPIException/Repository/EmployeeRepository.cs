using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAPIException.Data;
using EmployeeAPIException.Middleware;
using EmployeeAPIException.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPIException.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _dbContext;

        public EmployeeRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Get all employees
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        // Get employee by ID
        public async Task<Employee> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                // Throw a custom exception if the employee is not found
                throw new EmployeeNotFoundException(id);
            }
            return employee;
        }

        // Add a new employee
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            // Check if an employee with the same email already exists
            var existingEmployee = await _dbContext.Employees
                                    .FirstOrDefaultAsync(e => e.Email == employee.Email);
            if (existingEmployee != null)
            {
                // Throw a custom exception if an employee with the same email exists
                throw new EmployeeAlreadyExistsException(employee.Email);
            }

            employee.Id = Guid.NewGuid();
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return employee;
        }

        // Update an existing employee
        public async Task<Employee> UpdateEmployeeAsync(Guid id, Employee employee)
        {
            var existingEmployee = await _dbContext.Employees.FindAsync(id);
            if (existingEmployee == null)
            {
                // Throw a custom exception if the employee is not found
                throw new EmployeeNotFoundException(id);
            }

            // Update the existing employee's information
            existingEmployee.Name = employee.Name;
            existingEmployee.Email = employee.Email;
            existingEmployee.MobileNumber = employee.MobileNumber;
            existingEmployee.Salary = employee.Salary;

            await _dbContext.SaveChangesAsync();
            return existingEmployee;
        }

        // Delete an employee
        public async Task<bool> DeleteEmployeeAsync(Guid id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                // Throw a custom exception if the employee is not found
                throw new EmployeeNotFoundException(id);
            }

            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        
    }
}
