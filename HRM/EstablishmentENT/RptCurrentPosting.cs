using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class RptCurrentPosting
    {
        public int SystemUsersId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeStatus { get; set; }
        public string Post { get; set; }
        public string Bps { get; set; }
        public string Branch { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public string Remarks { get; set; }
    }
}
