using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackageResortAPI.Models.Domain
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }

        // Navigation property for one-to-many relationship
        public ICollection<State> States { get; set; }
    }

}
