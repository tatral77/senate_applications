using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities
{
    public class Province
    {
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public int DivisionTypeId { get; set; }
        public string DivisionType { get; set; }
        public int CountryId { get; set; }
        public string Country { get; set; }
        public int IsActive { get; set; }
    }
}
