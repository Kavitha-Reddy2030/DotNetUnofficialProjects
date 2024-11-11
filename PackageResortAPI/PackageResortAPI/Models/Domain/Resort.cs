using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackageResortAPI.Models.Domain
{
    public class Resort
    {
        public int Id { get; set; }
        public string ResortName { get; set; }

        // Foreign key for City
        public int CityId { get; set; }
        public City City { get; set; }

        // Navigation property for many-to-many relationship with Package
        public ICollection<PackageResort> PackageResorts { get; set; }
    }

}
