using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportEntities
{
    public class District
    {
        public int DistrictId { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
        public int ProvinceId { get; set; }

    }
}
