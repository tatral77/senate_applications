using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinEntities
{
    public class Deductions
    {
        public int DeductionId { get; set; }
        public string DeductionDesc { get; set; }
        public int IsActive { get; set; }
    }
}
