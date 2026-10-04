using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinEntities
{
    public class MemberDeduction
    {
        public int MemberDeductionId { get; set; }
        public int MemberId { get; set; }
        public int DeductionId { get; set; }
        public string DeductionDesc { get; set; }
        public double Amount { get; set; }
        public int FinancialYearId { get; set; }
        public string FinancialYear { get; set; }
        public int MonthId { get; set; }
        public string MonthDesc { get; set; }
    }
}
