using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisEntities
{
    public class OrderOfDay
    {
        public int OrderOfDaysId { get; set; }
        public int SessionSittingsId { get; set; }
        public string SittingDayDescription { get; set; }
        public int OrderOfDayTypesId { get; set; }
        public string OrderOfTheDayType { get; set; }
        public string MainOrderDescription { get; set; }
        public string SupplementaryOrderDesc { get; set; }
        public int IsActive { get; set; }

        public DateTime? SittingDate { get; set; }
        public int AssemblySessionsId { get; set; }
    }
}
