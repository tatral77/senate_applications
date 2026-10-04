using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisEntities
{
    public class BillMovers
    {
        public int BillMoversId { get; set; }
        public int BillsId { get; set; }
        public int SystemUsersId { get; set; }
        public string Mover { get; set; }
    }
}
