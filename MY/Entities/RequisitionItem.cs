using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RequisitionItems
    {
        public int RequisitionItemId { get; set; }
        public int RequistionId { get; set; }
        public int ItemId { get; set; }
        public string Item { get; set; }
        public int QuantityDemanded { get; set; }
        public int QuantityIssued { get; set; }
    }
}
