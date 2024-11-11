using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAPIJWT.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPIJWT.Data
{
    public class EmployeeJWTDbContext : DbContext
    {
        public EmployeeJWTDbContext(DbContextOptions<EmployeeJWTDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<User> Users { get; set; } // Add the User DbSet

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding initial data
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = Guid.NewGuid(),
                    Name = "John Doe",
                    Email = "john.doe@example.com",
                    Password = "password123",
                    MobileNumber = "1234567890",
                    Salary = 50000
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    Name = "Jane Smith",
                    Email = "jane.smith@example.com",
                    Password = "password123",
                    MobileNumber = "0987654321",
                    Salary = 60000
                }
            );

            /*  // Seed a default admin user (password is hashed)
             modelBuilder.Entity<User>().HasData(
                 new User
                 {
                     Id = Guid.NewGuid(),
                     Username = "admin",
                     PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"), // Hash password
                     Role = "Admin"
                 }
             );*/
            modelBuilder.Entity<User>().HasData(
             new User
             {
                 Id = Guid.NewGuid(),
                 Username = "admin",
                 PasswordHash = "admin123", // Plain text password
                Role = "Admin"
             },
             new User
             {
                 Id = Guid.NewGuid(),
                 Username = "user1",
                 PasswordHash = "user123", // Plain text password
                Role = "User"
             },
             new User
             {
                 Id = Guid.NewGuid(),
                 Username = "user2",
                 PasswordHash = "user234", // Plain text password
                Role = "User"
             }
         );
        }
    }
}
