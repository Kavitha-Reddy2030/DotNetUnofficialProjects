using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeAPIRepo.Models.Domain;
using EmployeeAPIRepo.Models.DTO;

namespace EmployeeAPIRepo.Mappings

{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            
            CreateMap<Employee, EmployeeDTO>();

            
            CreateMap<AddEmployeeDTO, Employee>();

            
            CreateMap<UpdateEmployeeDTO, Employee>();
        }
    }
}
