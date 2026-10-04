using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int CountryDivisionId { get; set; }
        public string  CountryDivisionName { get; set; }
        public int IsDistrict { get; set; }
        public int IsActive { get; set; }
    }
}
