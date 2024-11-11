using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PackageResortAPI.Models.Domain;

namespace PackageResortAPI.Services
{
    public interface IResortService
    {
        Task<List<Resort>> GetAllResortsAsync();
        Task<Resort> GetResortByIdAsync(int id);
        Task<Resort> CreateResortAsync(Resort resort);
        Task<Resort> UpdateResortAsync(int id, Resort resort);
        Task<bool> DeleteResortAsync(int id);
    }
}
