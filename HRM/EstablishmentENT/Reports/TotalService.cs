using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT.Reports
{
    public class TotalService:EmployeeBasic
    {
        public DateTime GovtServiceEntryDate { get; set; }
        public DateTime SenateEntryDate { get; set; }
        public float TotalGovtService { get; set; }
        public float TotalSenateService { get; set; }
    }
}
