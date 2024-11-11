using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeAPIVersioning.Data;
using EmployeeAPIVersioning.DTO;
using EmployeeAPIVersioning.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPIVersioning.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(EmployeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task AddEmployee(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await GetEmployeeById(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<(IEnumerable<ReadEmployeeDTO> Employees, int TotalCount)> GetFilteredSortedEmployeesAsync(EmployeeFilterDTO filter)
        {
            var query = _context.Employees.AsQueryable();

            // Apply filtering based on parameters
            if (!string.IsNullOrWhiteSpace(filter.FirstName))
            {
                query = query.Where(e => e.FirstName.Contains(filter.FirstName));
            }

            if (!string.IsNullOrWhiteSpace(filter.Department))
            {
                query = query.Where(e => e.Department.Contains(filter.Department));
            }

            if (filter.MinSalary.HasValue)
            {
                query = query.Where(e => e.Salary >= filter.MinSalary.Value);
            }

            if (filter.MaxSalary.HasValue)
            {
                query = query.Where(e => e.Salary <= filter.MaxSalary.Value);
            }

            /* // Sorting
             if (!string.IsNullOrWhiteSpace(filter.SortBy))
             {
                 query = filter.SortDescending
                     ? query.OrderByDescending(e => EF.Property<object>(e, filter.SortBy))
                     : query.OrderBy(e => EF.Property<object>(e, filter.SortBy));
             }*/

            // Sorting
            if (!string.IsNullOrWhiteSpace(filter.SortBy))
            {
                var sortFields = filter.SortBy.Split(',').Select(f => f.Trim()).ToList();
                IOrderedQueryable<Employee> orderedQuery = null;

                foreach (var field in sortFields)
                {
                    if (orderedQuery == null)
                    {
                        orderedQuery = filter.SortDescending
                            ? query.OrderByDescending(e => EF.Property<object>(e, field))
                            : query.OrderBy(e => EF.Property<object>(e, field));
                    }
                    else
                    {
                        orderedQuery = filter.SortDescending
                            ? orderedQuery.ThenByDescending(e => EF.Property<object>(e, field))
                            : orderedQuery.ThenBy(e => EF.Property<object>(e, field));
                    }
                }

                query = orderedQuery ?? query; // Assign the ordered query back to the query variable
            }

            // Pagination
            var totalCount = await query.CountAsync();
            var employees = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return (Employees: employees.Select(e => new ReadEmployeeDTO
            {
                Id = e.Id,
                FullName = $"{e.FirstName} {e.LastName}",
                FirstName = e.FirstName,
                LastName = e.LastName,
                Department = e.Department,
                Salary = e.Salary
            }), TotalCount: totalCount) ;
        }

    }
}
