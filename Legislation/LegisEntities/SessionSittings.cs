using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisEntities
{
    public class SessionSittings
    {
        public int SessionSittingsId { get; set; }
        public int AssembliesSessionId { get; set; }
        public string  Description { get; set; }
        public string AssemblySession { get; set; }
        public DateTime SittingDate { get; set; }
        public DateTime Sessiondate { get; set; }
        public int IsMorningSitting { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double TotalTimeConsumed { get; set; }
        public string Remarks { get; set; }
        public string SittingGernal { get; set; }
        public DateTime EvenStartTime { get; set; }
        public DateTime EvenEndTime { get; set; }
        public int IsAdjourned { get; set; }
        public int RowId { get; set; }



    }
}
