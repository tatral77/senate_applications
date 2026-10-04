using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinEntities
{
    public class MemberSalaryDetails
    {
        public int MemberId { get; set; }
        public int FinancialYearId { get; set; }
        public int MonthId { get; set; }
        public double TotalAllowances { get; set; }
        public double TotalDeductions { get; set; }
        public string BankName { get; set; }
        public string BankAccount { get; set; }
        public string ChequeNumber { get; set; }
        public DateTime ChequeDate { get; set; }
    }
}
