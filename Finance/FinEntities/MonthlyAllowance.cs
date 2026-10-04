using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinEntities
{
    public class MonthlyAllowance
    {
        public int MemberId { get; set; }
        public int AllowanceId { get; set; }
        public string AllowanceDesc { get; set; }
        public int HeadOfAccountId { get; set; }
        public string HeadOfAccount { get; set; }
        public int MonthId { get; set; }
        public string  MonthName { get; set; }
        public int FinancialYearId { get; set; }
        public string FinancialYear { get; set; }
        public double Amount { get; set; }
        public double MonthlyRate { get; set; }
    }
}
