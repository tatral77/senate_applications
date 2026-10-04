using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPRENTITIES
{
    public class LocationRate
    {
        public int LocationRateId { get; set; }
        public int RateListId { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public int CategoryId { get; set; }
        public int Rate { get; set; }
    }
}
