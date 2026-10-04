using IPRENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPRENITITIES
{
    public class DADetails
    {
        public int DADetailsId { get; set; }
        public int VisitId { get; set; }
        public int CountryId { get; set; }
        public string Country { get; set; }
        public int LocationId { get; set; }
        public string Location { get; set; }
        public int ArrangementTypeId { get; set; }
        public string Arrangement { get; set; }
        public int FacilityId { get; set; }
        public string Facility { get; set; }
        public int NoOfNights { get; set; }
        public double HotelCharges { get; set; }
        public double HigerSidePayment { get; set; }
        public double EarlyCheckinCharges { get; set; }
        public double LatecheckOutCharges { get; set; }
        public List<DAMember> Members { get; set; }
        public double Total { get; set; }
        public DateTime FromDate { get; set; } //by Ismail
        public DateTime ToDate { get; set; } //by Ismail
        public string Formula { get; set; }
        public int IsChairChargesPaid { get; set; }
    }
}
