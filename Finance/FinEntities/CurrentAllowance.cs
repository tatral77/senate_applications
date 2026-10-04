using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinEntities
{
    public class CurrentAllowance
    {
        public int CurrentAllowanceId { get; set; }
        public int MemberId { get; set; }
        public int AllowanceId { get; set; }
        public string AllowanceDesc { get; set; }
        public int HeadOfAccountId { get; set; }
        public string HeadOfAccount { get; set; }
        public double Amount { get; set; }
        public int IsStructured { get; set; }
    }
}
