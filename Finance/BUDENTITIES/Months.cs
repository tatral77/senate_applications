using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUDENTITIES
{
    public class Months
    {
        public int MonthId { get; set; }
        public string MonthName { get; set; }
        public int FinancialYearId { get; set; }
        public string FinancialYear { get; set; }
        public string MonthDescription { get; set; }
        public int Year { get; set; }
    }
}
