using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackageResortAPI.Models.DTO
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ResortDto> Resorts { get; set; } = new List<ResortDto>();
    }

}
