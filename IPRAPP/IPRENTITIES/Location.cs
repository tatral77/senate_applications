using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPRENTITIES
{
    public class Location
    {
        public int LocationId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string LocationName{ get; set; }
    }
}
