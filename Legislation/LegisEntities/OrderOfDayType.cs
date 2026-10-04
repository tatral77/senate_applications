using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisEntities
{
    public class OrderOfDayType
    {
        public int OrderOfDayTypesId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
