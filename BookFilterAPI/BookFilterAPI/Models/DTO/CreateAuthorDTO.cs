using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookFilterAPI.Models.DTO
{
    public class CreateAuthorDTO
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime? Birthdate { get; set; }
        public string ProfileImageUrl { get; set; }
    }
}
