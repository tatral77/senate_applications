using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUDENTITIES
{
    public class Bcr :Bills
    {
        public int ReAppropriationId { get; set; }
        public int FromHeadOfAccountId { get; set; }
        public int ToHeadOfAccountId { get; set; }
        public double ReAppAmount { get; set; }
        public DateTime ReApprpriationDate { get; set; }
        public DateTime EntryDate { get; set; }
        public string ReAppropriationType { get; set; }
        public double ProgressiveExpenditure { get; set; }
        public double Balance { get; set; }
    }
}
