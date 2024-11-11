using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackageResortAPI.Models.Domain
{
    public class State
    {
        public int Id { get; set; }
        public string StateName { get; set; }

        // Foreign key for Country
        public int CountryId { get; set; }
        public Country Country { get; set; }

        // Navigation property for one-to-many relationship
        public ICollection<City> Cities { get; set; }
    }

}
