using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUDENTITIES
{
    public class HeadOfAccountBudget
    {
        public int HeadOfAccountBudgetId { get; set; }
        public int HeadOfAccountId { get; set; }
        public int FinancialYearId { get; set; }
        public double Amount { get; set; }
        public double RemainingBalance { get; set; }
    }
}
