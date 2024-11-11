using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PackageResortAPI.Models.Domain;
using PackageResortAPI.Models.DTO;

namespace PackageResortAPI.Services
{
    public interface ICityService
    {
        Task<CityDto> GetCityAsync(int id);
        Task<IEnumerable<CityDto>> GetAllCitiesAsync();
        Task<CityDto> CreateCityAsync(CityDto cityDto);
        Task<CityDto> UpdateCityAsync(int id, CityDto cityDto);
        Task<bool> DeleteCityAsync(int id);
    }
}
