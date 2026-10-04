using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUDENTITIES
{
    public class FundCenters
    {
        public int FundCenterId { get; set; }
        public string FundCenter { get; set; }
        public List<MajorObjects> majorObjects { get; set; }
        public double FundCenterAmount { get; set; }
        public double Suplementary { get; set; }
        public double Remaining { get; set; }
        public double Saving { get; set; }
        public double Surrender { get; set; }
    }
}
 