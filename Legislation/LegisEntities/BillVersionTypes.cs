using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisEntities
{
    class BillVersionTypes
    {
        public int BillVersionTypesId { get; set; }
        public String Description { get; set; }
        public int IsActive { get; set; }
        public int ConcernedRoleId { get; set; }
    }
}
