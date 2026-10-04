using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT.Reports
{
    public class RptEmployeesOnLeave :EmployeeLeave
    {
        public string EmployeeName { get; set; }
        public string Post { get; set; }
        public string BPS { get; set; }
    }
}
