using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class EmpBenevolentFunds
    {
        public int EmpBenevolentFundId { get; set; }
        public int SystemUsersId { get; set; }
        public string EmployeeName { get; set; }
        public int BenevolentFundTypeId { get; set; }
        public string BenevolentFundType { get; set; }
        public DateTime FundDate { get; set; }
        public int Amount { get; set; }
        public string Details { get; set; }

    }
}
