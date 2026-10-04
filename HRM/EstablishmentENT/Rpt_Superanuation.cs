using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class Rpt_Superanuation :Rpt_Base
    {
       
        public DateTime Dob { get; set; }
        public int IsGazetted { get; set; }
        public DateTime GovtServiceDate { get; set; }
        public DateTime SenServiceDate { get; set; }
        public DateTime SuperanuationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime FromDAte { get; set; }
        public string Status { get; set; }
        public int years { get; set; }
        public int months { get; set; }

    }
}
