using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPRENTITIES
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public List<Location> Locations { get; set; }
        public int IsActive { get; set; }
    }
}
