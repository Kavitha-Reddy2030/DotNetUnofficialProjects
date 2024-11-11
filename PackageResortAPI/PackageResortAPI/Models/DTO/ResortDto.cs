using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PackageResortAPI.Models.DTO
{
    public class ResortDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public List<CityDto> Cities { get; set; }
        public int CityId { get; set; } // Reference the City by ID
    }

}
