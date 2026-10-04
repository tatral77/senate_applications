using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RateListItem
    {
        public int RateListItemId { get; set; }
        public int RateListId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Price { get; set; }
        public int UnitId { get; set; }
        public string Unit { get; set; }
        public int UnitItems { get; set; }
        public int IsActive { get; set; }
    }
}
