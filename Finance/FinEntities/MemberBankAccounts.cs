using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinEntities
{
    public class MemberBankAccounts
    {
        public int MemberId { get; set; }
        public int MemberBankAccountId { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public int IsSalaried { get; set; }
    }
}
