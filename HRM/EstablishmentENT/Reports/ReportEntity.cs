using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT.Reports
{
    public class ReportEntity :Rpt_Base
    {
        public DateTime Dob { get; set; }
        public int IsGazetted { get; set; }
        public DateTime GovtServiceDate { get; set; }
        public DateTime SenServiceDate { get; set; }
        public DateTime SuperanuationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime FromDAte { get; set; }
        public int EmpStatusId { get; set; }
        public string Status { get; set; }
        public double years { get; set; }
        public double months { get; set; }
        public string ParantDepartment { get; set; }
        public string permanentaddress { get; set; }
        public string localaddress { get; set; }
        public string ContactNumbers { get; set; }
        public DateTime ExtendedTo { get; set; }
        public string Quota { get; set; }
        public DateTime ToDate { get; set; }
        public string Age { get; set; }
        public string CurrentStatus { get; set; }
        public DateTime CurrentStatusDate { get; set; }
        public string ExtensionDetails { get; set; }
        public string Remarks { get; set; }
        public List<ExtensionDetails> Extensions { get; set; }
    }
}
