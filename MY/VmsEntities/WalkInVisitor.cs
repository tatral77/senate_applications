using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VmsEntities
{
    public class WalkInVisitor
    {
        public int VisitorId { get; set; }
        public string VisitorName { get; set; }
        public string Details { get; set; }
        public string Cnic { get; set; }
        public int VisitTypeId { get; set; }
        public string  VisitType { get; set; }
        public DateTime VisitDate { get; set; }
        public int PersonToVisitId { get; set; }
        public string PersonToVisitName { get; set; }

    }
}
