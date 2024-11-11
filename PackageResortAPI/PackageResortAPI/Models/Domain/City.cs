using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackageResortAPI.Models.Domain
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }

        // Foreign key for State
        public int StateId { get; set; }
        public State State { get; set; }

        // Navigation property for one-to-many relationship with resorts
        public ICollection<Resort> Resorts { get; set; }
    }

}
