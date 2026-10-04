using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisEntities
{
    public class BillDivisions
    {
        public int BillDivisionsId { get; set; }
        public int BillsId { get; set; }
        public int DivisionsId { get; set; }
        public string Division { get; set; }
    }
}
