using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinEntities
{
    public class SalarySlipEnt
    {
        public int MemberId { get; set; }
        public string FundCenter { get; set; }
        public string MonthHeading { get; set; }
        public string MemberName { get; set; }
        public double AmountPayable { get; set; }
        public string Bank { get; set; }
    }
}
