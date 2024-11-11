using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeAPIException.Models.Domain;
using EmployeeAPIException.Models.DTO;

namespace EmployeeAPIException.Mappings
{
    public class EmployeeProfile: Profile
    {

        public EmployeeProfile()
        {

            CreateMap<Employee, EmployeeDTO>();


            CreateMap<AddEmployeeDTO, Employee>();


            CreateMap<UpdateEmployeeDTO, Employee>();
        }
    }
}
