using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PackageResortAPI.Data;
using PackageResortAPI.Models.Domain;
using PackageResortAPI.Models.DTO;

namespace PackageResortAPI.Services
{
    public class CityService : ICityService
    {
        private readonly PackageResortDbContext _context;
        private readonly IMapper _mapper;

        public CityService(PackageResortDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CityDto> GetCityAsync(int id)
        {
            var city = await _context.Cities
                .FirstOrDefaultAsync(c => c.Id == id); // Avoid navigation properties

            return _mapper.Map<CityDto>(city);
        }

        public async Task<IEnumerable<CityDto>> GetAllCitiesAsync()
        {
            return await _context.Cities
                .Include(c => c.Resorts) // Assuming there's a navigation property
                .Select(c => new CityDto
                {
                    Id = c.Id,
                    Name = c.CityName,
                    Resorts = c.Resorts.Select(r => new ResortDto
                    {
                        Id = r.Id,
                        Name = r.ResortName
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<CityDto> CreateCityAsync(CityDto cityDto)
        {
            var city = _mapper.Map<City>(cityDto);
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
            return _mapper.Map<CityDto>(city);
        }

        public async Task<CityDto> UpdateCityAsync(int id, CityDto cityDto)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return null; // or throw an exception
            }

            _mapper.Map(cityDto, city);
            await _context.SaveChangesAsync();
            return _mapper.Map<CityDto>(city);
        }

        public async Task<bool> DeleteCityAsync(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return false; // or throw an exception
            }

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
