using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PackageResortAPI.Models.Domain;
using PackageResortAPI.Models.DTO;

namespace PackageResortAPI.Mappings
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<City, CityDto>()
                .ReverseMap(); // Maps City to CityDto and vice versa
        }
    }

}
