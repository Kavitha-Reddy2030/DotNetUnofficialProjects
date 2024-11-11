using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackageResortAPI.Models.Domain
{
    public class PackageCity
    {
        public int PackageId { get; set; }
        public Package Package { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
    }

}
