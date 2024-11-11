using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeAPIJWT.Models.Domain;
using EmployeeAPIJWT.Models.DTO;

namespace EmployeeAPIJWT.Mappings
{
    public class EmployeeMapper : Profile
    {

        public EmployeeMapper()
        {

            CreateMap<Employee, EmployeeDTO>();


            CreateMap<AddEmployeeDTO, Employee>();


            CreateMap<UpdateEmployeeDTO, Employee>();
        }
    }
}
