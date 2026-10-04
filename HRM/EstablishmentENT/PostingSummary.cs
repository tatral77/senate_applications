using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class PostingSummary
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int TotalYears { get; set; }
        public int TotalMonths { get; set; }
        public double TotalPeriod { get; set; }
    }
}
