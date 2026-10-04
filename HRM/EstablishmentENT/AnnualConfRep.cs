using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class AnnualConfRep
    {
        public int AnConfRepId { get; set; }
        public int SystemUserId { get; set; }
        public int RepYear { get; set; }
        public int BPSID { get; set; }
        public string BPS { get; set; }
        public int PostId { get; set; }
        public string Post { get; set; }
        public int CounterSignOffId { get; set; }
        public string CounterSignOff { get; set; }
        public DateTime? CSInDate { get; set; }
        public DateTime? CSOutDate { get; set; }
        public int ReportingOfficerId { get; set; }
        public string ReportingOfficer { get; set; }
        public DateTime? ROInDate { get; set; }
        public DateTime? ROOutDate { get; set; }
        public int GradeId { get; set; }
        public string AcrGrade { get; set; }
        public int StatusId { get; set; }
        public string AcrStatus { get; set; }
        public string Remarks { get; set; }
    }
}
