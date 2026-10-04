using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public List<City> Cities { get; set; }
        public int IsActive { get; set; }
    }
}
