using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrandAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BrandWebAPI.Models
{
    public class BrandDbContext : DbContext
    {
        public BrandDbContext(DbContextOptions<BrandDbContext> options) : base(options)
        {

        }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Brand>().HasData(
                new Brand
                {
                    Id = 1,
                    Name = "Toyota",
                    Model = "Camry"
                },
                new Brand
                {
                    Id = 2,
                    Name = "Ford",
                    Model = "Mustang"
                },
                new Brand
                {
                    Id = 3,
                    Name = "Tesla",
                    Model = "Model S"
                }
            );
        }
    }
    
}
