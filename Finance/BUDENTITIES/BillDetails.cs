using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUDENTITIES
{
    public class BillDetails
    {
        public int BillDetailId { get; set; }
        public int BillId { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public double Amount { get; set; }
    }
}
