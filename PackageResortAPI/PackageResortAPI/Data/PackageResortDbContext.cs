using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackageResortAPI.Data
{
    using Microsoft.EntityFrameworkCore;
    using PackageResortAPI.Models.Domain;

    public class PackageResortDbContext : DbContext
    {
        public PackageResortDbContext(DbContextOptions<PackageResortDbContext> options) : base(options) { }

        // DbSets for each entity
        public DbSet<Package> Packages { get; set; }
        public DbSet<Resort> Resorts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<PackageResort> PackageResorts { get; set; }
        public DbSet<PackageCity> PackageCities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Package-Resort many-to-many relationship
            modelBuilder.Entity<PackageResort>()
                .HasKey(pr => new { pr.PackageId, pr.ResortId });

            modelBuilder.Entity<PackageResort>()
                .HasOne(pr => pr.Package)
                .WithMany(p => p.PackageResorts)
                .HasForeignKey(pr => pr.PackageId);

            modelBuilder.Entity<PackageResort>()
                .HasOne(pr => pr.Resort)
                .WithMany(r => r.PackageResorts)
                .HasForeignKey(pr => pr.ResortId);

            // Package-City many-to-many relationship
            modelBuilder.Entity<PackageCity>()
                .HasKey(pc => new { pc.PackageId, pc.CityId });

            modelBuilder.Entity<PackageCity>()
                .HasOne(pc => pc.Package)
                .WithMany(p => p.PackageCities)
                .HasForeignKey(pc => pc.PackageId);

            modelBuilder.Entity<PackageCity>()
                .HasOne(pc => pc.City)
                .WithMany()  // No reference to PackageCities in City entity
                .HasForeignKey(pc => pc.CityId);


            // State-City one-to-many relationship
            modelBuilder.Entity<State>()
                .HasMany(s => s.Cities)
                .WithOne(c => c.State)
                .HasForeignKey(c => c.StateId);

            // Country-State one-to-many relationship
            modelBuilder.Entity<Country>()
                .HasMany(c => c.States)
                .WithOne(s => s.Country)
                .HasForeignKey(s => s.CountryId);

            // City-Resort one-to-many relationship
            modelBuilder.Entity<City>()
                .HasMany(c => c.Resorts)
                .WithOne(r => r.City)
                .HasForeignKey(r => r.CityId);

            // Seeding data

            // Seed Countries
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, CountryName = "USA" },
                new Country { Id = 2, CountryName = "India" }
            );

            // Seed States
            modelBuilder.Entity<State>().HasData(
                new State { Id = 1, StateName = "California", CountryId = 1 },
                new State { Id = 2, StateName = "Karnataka", CountryId = 2 }
            );

            // Seed Cities
            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, CityName = "Los Angeles", StateId = 1 },
                new City { Id = 2, CityName = "Bangalore", StateId = 2 }
            );

            // Seed Resorts
            modelBuilder.Entity<Resort>().HasData(
                new Resort { Id = 1, ResortName = "Beach Resort", CityId = 1 },
                new Resort { Id = 2, ResortName = "Mountain Resort", CityId = 2 }
            );

            // Seed Packages
            modelBuilder.Entity<Package>().HasData(
                new Package { Id = 1, Name = "Summer Vacation", Price = 1200.50m },
                new Package { Id = 2, Name = "Winter Getaway", Price = 900.00m }
            );

            // Seed Package-Resort relationship (Many-to-Many)
            modelBuilder.Entity<PackageResort>().HasData(
                new PackageResort { PackageId = 1, ResortId = 1 },
                new PackageResort { PackageId = 1, ResortId = 2 },
                new PackageResort { PackageId = 2, ResortId = 2 }
            );

            // Seed Package-City relationship (Many-to-Many)
            modelBuilder.Entity<PackageCity>().HasData(
                new PackageCity { PackageId = 1, CityId = 1 },
                new PackageCity { PackageId = 1, CityId = 2 },
                new PackageCity { PackageId = 2, CityId = 2 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }

}
