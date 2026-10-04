using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPRENTITIES
{
    public class Composition
    {
        public int CompositionId { get; set; }
        public int VisitId { get; set; }
        public int SystemUserId { get; set; }
        public string VisitorName { get; set; }
        public string Post { get; set; }
        public int VisitorTypeId { get; set; }
        public string VisitorType { get; set; }
        public int VisitorStatusId { get; set; }
        public string VisitorStatus { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime VisitorStatusDate { get; set; }
        public string Remarks { get; set; }
        public int IsEmployee { get; set; }
        public int IsChairman { get; set; }
    }
}
