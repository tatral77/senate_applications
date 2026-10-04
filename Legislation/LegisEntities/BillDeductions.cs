using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUDENTITIES
{
    public class BillDeductions
    {
        public int BillDeductionId { get; set; }
        public int BillId { get; set; }
        public string DeductionDetail { get; set; }
        public double Amount { get; set; }
        public string Remarks { get; set; }
    }
}
