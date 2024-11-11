using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PackageResortAPI.Models.Domain;

namespace PackageResortAPI.Services
{
    public interface IPackageService
    {
        Task<List<Package>> GetAllPackagesAsync();
        Task<Package> GetPackageByIdAsync(int id);
        Task<Package> CreatePackageAsync(Package package);
        Task<Package> UpdatePackageAsync(int id, Package package);
        Task<bool> DeletePackageAsync(int id);
    }
}
