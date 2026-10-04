using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisEntities
{
    public class OrderOfTheDayBusiness
    {
        public int OrderOfDayBusinessId { get; set; }
        public int OrderOfDayId { get; set; }
        public int BusinessTypesId { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public string BusinessTypesDescription { get; set; }
        public string BusinessRule { get; set; }
        public int TypeSortOrder { get; set; }
        public List<OrderOfDayBusinessAttachment> Attachemnts { get; set; }
    }
}
