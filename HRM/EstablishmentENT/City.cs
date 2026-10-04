using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class City
    {      
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public int CityId { get; set; }
        public string Description { get; set; }
        public int Is_active { get; set; }
        public int IsDistrict  { get; set; }
        public int CountryId { get; set; }
        public String CountryName { get; set; }
    }
}
 
