using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUDENTITIES
{
    public class BranchHead
    {
        public int BranchHeadId { get; set; }
        public int BranchId { get; set; }
        public string Branch { get; set; }
        public int FinancialYearId { get; set; }
        public string FundCenter { get; set; }
        public string MajorObject { get; set; }
        public int MinorObjectId { get; set; }
        public string MinorObject { get; set; }
        public int HeadOfAccountId { get; set; }
        public string HeadOfAccount { get; set; }
        public double CurrentAmount { get; set; }
        public double BudgetLimit { get; set; }
    }
}
