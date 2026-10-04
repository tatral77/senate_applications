using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisEntities
{
    public class OrdinanceStatusHistory
    {
        public int OrdinanceStatusHistId { get; set; }
        public int OrdinanceStatusesId { get; set; }
        public string OrdinanceStatus { get; set; }
        public DateTime StatusDate { get; set; }
        public int UpdatedById { get; set; }
        public string UpdatedBy { get; set; }
        public int OrdinanceId { get; set; }
    }
}
