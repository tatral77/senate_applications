using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class EmpLeaveDetails
    {
        public int ServiceYear { get; set; }
        public int LeaveMonth { get; set; }
        public int EarnedLeave { get; set; }
        public int CreditOfYear { get; set; }
        public int AvailedLeave { get; set; }
        public int LeavePeriod { get; set; }
        public int LeaveDeducted { get; set; }
        public int LeaveBalance { get; set; }
        public int BalanceTillNow { get; set; }
        public int AvailableForEncashment { get; set; }
        public int EOL { get; set; }
        public int AvailedEncashment { get; set; }
        public int Suspension { get; set; }
        public string Remarks { get; set; }
    }
}
