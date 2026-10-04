using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class EmpProfile : PersonalDetail
    {

        public int Age { get; set; }
        public string CurrentDesignation { get; set; }
        public string CurrentBPS { get; set; }
        public string CurrentBranch { get; set; }
        public DateTime GovtServiceStartDate { get; set; }
        public int LeaveOnCredit { get; set; }
        public double GovtService { get; set; }
        public int GovtServiceMonths { get; set; }
        public double HouseService { get; set; }
        public int HouseServiceMonths { get; set; }
        public DateTime SenateServiceStartDate { get; set; }
        public string EmployeeStatus { get; set; }
        public DateTime SuperanuationDate { get; set; }
     }
}
