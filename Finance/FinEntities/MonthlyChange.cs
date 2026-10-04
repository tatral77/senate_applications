using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinEntities
{
    public class MonthlyChange
    {
        public int MonthlyChangeId { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public int MonthId { get; set; }
        public string MonthName { get; set; }
        public int FinancialYearId { get; set; }
        public string FinancialYear { get; set; }
        public float MonthlyRate { get; set; }
        public double Amount { get; set; }
        public double Limit { get; set; }
        public string Remarks { get; set; }
        public int ReferenceId { get; set; }
    }
}
