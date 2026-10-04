using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportEntities
{
    public class Province
    {
        public int ProvincesId { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
        public int Sortorder { get; set; }
        public int ProvinceId { get; set; }
    }
}
