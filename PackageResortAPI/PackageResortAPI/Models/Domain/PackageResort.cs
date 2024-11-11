using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackageResortAPI.Models.Domain
{
    public class PackageResort
    {
        public int PackageId { get; set; }
        public Package Package { get; set; }

        public int ResortId { get; set; }
        public Resort Resort { get; set; }
    }

}
