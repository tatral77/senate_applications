using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RateList
    {
        public int RateListId { get; set; }
        public string RateListDes { get; set; }
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public DateTime RateListDate { get; set; }
        public string Remarks { get; set; }
        public int IsActive { get; set; }

    }
}
