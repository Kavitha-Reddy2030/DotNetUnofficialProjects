using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookFilterAPI.Models.DTO
{
    public class DescriptionFilterDTO
    {
        public string Description { get; set; }
        public string DescriptionSubstring { get; set; }
    }
}
