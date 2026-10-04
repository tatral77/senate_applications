using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class RptOtherCharges
    {
        public int SystemUsersId { get; set; }
        public string EmpName { get; set; }
        public int OtherChargeTypeId { get; set; }
        public string OtherChargeType { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Duration { get; set; }
        public string Remarks { get; set; }
        public string Bps { get; set; }
        public string Post { get; set; }
        public string Branch { get; set; }
    }
}
