using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PackageResortAPI.Data;
using PackageResortAPI.Models.Domain;

namespace PackageResortAPI.Services
{
    public class PackageService : IPackageService
    {
        private readonly PackageResortDbContext _context;

        public PackageService(PackageResortDbContext context)
        {
            _context = context;
        }

        public async Task<List<Package>> GetAllPackagesAsync()
        {
            return await _context.Packages.Include(p => p.PackageResorts).ThenInclude(pr => pr.Resort)
                                          .Include(p => p.PackageCities).ThenInclude(pc => pc.City)
                                          .ToListAsync();
        }

        public async Task<Package> GetPackageByIdAsync(int id)
        {
            return await _context.Packages.Include(p => p.PackageResorts).ThenInclude(pr => pr.Resort)
                                          .Include(p => p.PackageCities).ThenInclude(pc => pc.City)
                                          .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Package> CreatePackageAsync(Package package)
        {
            _context.Packages.Add(package);
            await _context.SaveChangesAsync();
            return package;
        }

        public async Task<Package> UpdatePackageAsync(int id, Package package)
        {
            var existingPackage = await _context.Packages.FindAsync(id);
            if (existingPackage == null) return null;

            existingPackage.Name = package.Name;
            existingPackage.Price = package.Price;
            // Update other fields as needed
            await _context.SaveChangesAsync();
            return existingPackage;
        }

        public async Task<bool> DeletePackageAsync(int id)
        {
            var package = await _context.Packages.FindAsync(id);
            if (package == null) return false;

            _context.Packages.Remove(package);
            await _context.SaveChangesAsync();
            return true;
        }

        
    }
}
