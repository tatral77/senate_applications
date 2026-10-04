using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class District
    {
        public int DistrictId { get; set; }
        public string Description { get; set; }
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public int Is_active { get; set; }
    }
}
