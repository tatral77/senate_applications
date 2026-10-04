using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUDENTITIES
{
    public class SavingSurrenderEnt
    {
        public int SavingsId { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int FinancialYearId { get; set; }
        public string FinancialYear { get; set; }
        public int HeadOfAccountId { get; set; }
        public string HeadOfAccount { get; set; }
        public double Amount { get; set; }
        public DateTime SavingDate { get; set; }
    }
}
