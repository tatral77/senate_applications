using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class Correction
    {
        public int CorrectionId { get; set; }
        public string CorrectionTxt { get; set; }
        public int SystemUsersId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime CorrectionDate { get; set; }
        public int Solved { get; set; }
    }
}
