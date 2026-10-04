using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinEntities
{
    public class MonthlyDeduction
    {
        public int MemberId { get; set; }
        public int DeductionId { get; set; }
        public string DeductionDesc { get; set; }
        public int MonthId { get; set; }
        public string MonthName { get; set; }
        public int FinancialYearId { get; set; }
        public string FinancialYear { get; set; }
        public string Description { get; set; }
        public int ShowInDetail { get; set; }
        public double Amount { get; set; }
    }
}
