using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT.Reports
{
    public class Superanuation :EmployeeBasic
    {
       
        public DateTime DOB { get; set; }
        public DateTime ServiceStartDate { get; set; }
        public DateTime SuperanuationDate { get; set; }
    }
}
