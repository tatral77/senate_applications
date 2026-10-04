using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisEntities

{
    public class OrdersOfTheDayType
    {
        public int OdTypeId { get; set; }
        public string OdTypeDescription { get; set; }
        public string RuleDescription { get; set; }
        public int DisplayOrder { get; set; }
        public int IsActive { get; set; }
    }
}
