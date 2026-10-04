using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MotionSummary
    {
        public int AsseblySessionsId { get; set; }
        public int AssemblySession { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public int Motions { get; set; }
    }
}
