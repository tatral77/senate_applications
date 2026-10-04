using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisEntities
{
    public class BillMinisters
    {
        public int BillMinistersId { get; set; }
        public int BillsId { get; set; }
        public int MinisterId { get; set; }
        public string MinisterName { get; set; }
    }
}
