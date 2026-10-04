using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinEntities
{
    public class FinancialYearSalaryDetail
    {
        public int FinancialYearId { get; set; }
        public int MonthId { get; set; }
        public int Processed { get; set; }
        public int Finalized { get; set; }
    }
}
