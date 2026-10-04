using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinEntities
{
    public class StructureDeduction
    {
        public int StructureId { get; set; }
        public string StructureDesc { get; set; }
        public int DeductionId { get; set; }
        public string DeductionDesc { get; set; }
        public double Amount { get; set; }
    }
}
