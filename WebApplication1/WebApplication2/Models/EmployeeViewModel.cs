using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class EmployeeViewModel
    {
       public int Id { get; set; }
        public string EmployeeName { get; set; } = default!;
        public string EmployeeAge { get; set; } = default!;
    }
}
