using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPRENTITIES
{
    public class OutgoingVisit
    {
        public int VisitId { get; set; }
        public string VisitTitle { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int FinancialYearId { get; set; }
        public string FinancialYear { get; set; }
        public double DollarRate { get; set; }
        public string Details { get; set; }
        public int TransportCharges { get; set; } // by Ismail
        public string TransportChargesDescription { get; set; } // by Ismail
    }
}
