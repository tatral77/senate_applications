using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUDENTITIES
{
    public class FinancialYears
    {
        public int FinancialYearId { get; set; }
        public string FinancialYear { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string DemandNumber { get; set; }
    }
}
