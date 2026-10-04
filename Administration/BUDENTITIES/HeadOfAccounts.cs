using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUDENTITIES
{
    public class HeadOfAccounts
    {
        public int HeadOfAccountId { get; set; }
        public string HeadOfAccount { get; set; }
        public int MinorObjectId { get; set; }
        public double AmountAllocated { get; set; }
        public double RemainingAmount { get; set; }
        public double Savings { get; set; }
        public double Surrendered { get; set; }
        public double Suplementary { get; set; }
        public int IsActive { get; set; }
    }
}
