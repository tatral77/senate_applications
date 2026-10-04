using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class Rpt_LeaveSummary
    {
        public int SystemUsersId { get; set; }
        public string EmpName { get; set; }
        public string Post { get; set; }
        public string BPS { get; set; }
        public int ThisYearCredit { get; set; }
        public int CurrentTotalCredit { get; set; }

    }
}
