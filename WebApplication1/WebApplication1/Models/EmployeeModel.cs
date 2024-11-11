using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Entity;

namespace WebApplication1.Models
{
    public class EmployeeModel : EntityBase
    {
        public string EmployeeName { get; set; } = default!;
        public string EmployeeAge { get; set; } = default!;
    }
    
}
