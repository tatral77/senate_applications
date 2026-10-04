using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPRENTITIES
{
    public class OutgoingVisitDetailEnt
    {
        public int OutgoingVisitDetailId { get; set; }
        public int VisitId { get; set; }
        public int LocationId { get; set; }
        public string Location { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int NoOfNights { get; set; }
    }
}
