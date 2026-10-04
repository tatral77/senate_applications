using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinEntities
{
    public class CurrentDeduction
    {
        public int CurrentDeductionId { get; set; }
        public int DeductionId { get; set; }
        public string DeductionDesc { get; set; }
        public int MemberId { get; set; }
        public double Amount { get; set; }
        public int IsStructured { get; set; }
    }
}
