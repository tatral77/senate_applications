using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUDENTITIES
{
    public class ReApproprationEnt
    {
        public int ReAppropriationId { get; set; }
        public int FinancialYearId { get; set; }
        public string FinancialYear { get; set; }
        public int FromHeadOfAccountId { get; set; }
        public string FromHeadOfAccount { get; set; }
        public int ToHeadOfAccountId { get; set; }
        public string ToHeadOfAccount { get; set; }
        public double Amount { get; set; }
        public DateTime ReApprpriationDate { get; set; }
        public string Remarks { get; set; }
    }
}
