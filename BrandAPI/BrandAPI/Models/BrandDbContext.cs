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
    }
    
}
