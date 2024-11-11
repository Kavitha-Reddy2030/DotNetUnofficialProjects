using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackageResortAPI.Models.Domain
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        // Navigation properties for many-to-many relationships
        public ICollection<PackageResort> PackageResorts { get; set; }
        public ICollection<PackageCity> PackageCities { get; set; }
    }

}
