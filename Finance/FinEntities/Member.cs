using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinEntities
{
    public class Member
    {
        public int MemberId { get; set; }
        public int MemberTypeId { get; set; }
        public string MemberType { get; set; }
        public string MemberName { get; set; }
        public string BankName { get; set; }
        public string BankAccount { get; set; }
        public int MemberSalCategoryId { get; set; }
        public string MemberSalCategory { get; set; }
        public int IsActive { get; set; }
        public int SalaryStatus { get; set; }
        public string ChequeNumber { get; set; }
        public DateTime ChequeDate { get; set; }
        public List<MonthlyAllowance> MonthlyAllowances { get; set; }
        public List<MonthlyDeduction> MonthlyDeductions { get; set; }
        public int HaveBankAccount { get; set; }
    }
}
