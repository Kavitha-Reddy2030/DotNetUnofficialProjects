using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PackageResortAPI.Data;
using PackageResortAPI.Models.Domain;

namespace PackageResortAPI.Services
{
    public class ResortService : IResortService
    {
        private readonly PackageResortDbContext _context;

        public ResortService(PackageResortDbContext context)
        {
            _context = context;
        }

        public async Task<List<Resort>> GetAllResortsAsync()
        {
            return await _context.Resorts.Include(r => r.City).ToListAsync();
        }

        public async Task<Resort> GetResortByIdAsync(int id)
        {
            return await _context.Resorts.Include(r => r.City).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Resort> CreateResortAsync(Resort resort)
        {
            _context.Resorts.Add(resort);
            await _context.SaveChangesAsync();
            return resort;
        }

        public async Task<Resort> UpdateResortAsync(int id, Resort resort)
        {
            var existingResort = await _context.Resorts.FindAsync(id);
            if (existingResort == null) return null;

            existingResort.ResortName = resort.ResortName;
            existingResort.CityId = resort.CityId;
            await _context.SaveChangesAsync();
            return existingResort;
        }

        public async Task<bool> DeleteResortAsync(int id)
        {
            var resort = await _context.Resorts.FindAsync(id);
            if (resort == null) return false;

            _context.Resorts.Remove(resort);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
