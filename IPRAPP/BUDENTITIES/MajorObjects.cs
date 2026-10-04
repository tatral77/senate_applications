using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUDENTITIES
{
    public class MajorObjects
    {
        public int MajorObjectId { get; set; }
        public string MajorObject { get; set; }
        public int FundCenterId { get; set; }
        public string FundCenterName { get; set; }
        public int MajorObjectAmount { get; set; }
        public List<MinorObjects> minorObjects { get; set; }
        public int IsActive { get; set; }
    }
}
