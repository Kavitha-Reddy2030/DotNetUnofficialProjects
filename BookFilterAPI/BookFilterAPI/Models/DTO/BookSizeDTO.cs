using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookFilterAPI.Models.DTO
{
    public class BookSizeDTO
    {
        public Guid Id { get; set; }
        public string Size { get; set; }
    }
}
