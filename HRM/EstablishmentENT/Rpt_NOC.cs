using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class Rpt_NOC
    {
        public int Emp_Noc_Id { get; set; }
        public int System_Users_Id { get; set; }
        public string EmpName { get; set; }
        public DateTime NocDate { get; set; }
        public int Noc_Type_Id { get; set; }
        public string Noc_Type { get; set; }
        public string Remarks { get; set; }
        public string  Post { get; set; }
        public string Bps { get; set; }

    }
}
