using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisEntities
{
    public class BusinessType
    {
        public int BusinessTypeId { get; set; }
        public string Description { get; set; }
        public string Rule { get; set; }
        public int IsActive { get; set; }
        public int SortOrder { get; set; }
    }
}
