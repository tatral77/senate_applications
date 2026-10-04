using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisEntities
{
    public class BillStatusHistory
    {
        public int BillStatusHistId { get; set; }
        public int BillStatusesId { get; set; }
        public string BillStatus { get; set; }
        public DateTime StatusDate { get; set; }
        public int UpdatedById { get; set; }
        public string UpdatedBy { get; set; }
        public int BillsId { get; set; }
    }
}
