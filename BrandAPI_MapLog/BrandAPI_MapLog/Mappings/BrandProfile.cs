using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BrandAPI.Models;
using BrandAPI_MapLog.DTO;
using BrandWebAPI.Models;

namespace BrandAPI_MapLog.Mappings
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            // Map from Brand to BrandDTO
            CreateMap<Brand, BrandDTO>().ReverseMap();

            // Map from AddDTO to Brand
            CreateMap<AddDTO, Brand>().ReverseMap();

            // Map from UpdateDTO to Brand
            CreateMap<UpdateDTO, Brand>().ReverseMap();
        }
    }
}
