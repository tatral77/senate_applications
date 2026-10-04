using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT.Reports
{
    public class EmployeeContactDetails :EmployeeBasic
    {
        public string PermanentAddress { get; set; }
        public string CurrentAddress { get; set; }
        public string PhoneNumbers { get; set; }
        public string EmailAddress { get; set; }


    }
}
