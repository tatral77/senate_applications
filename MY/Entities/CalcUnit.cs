using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CalcUnit
    {
        public int UnitId { get; set; }
        public string Description { get; set; }
        public int NumberOfItems { get; set; }
        public int IsActive { get; set; }
    }
}
