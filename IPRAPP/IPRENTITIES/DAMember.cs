using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPRENITITIES
{
    public class DAMember
    {
        public int DADetailId { get; set; }
        public int CompositionId { get; set; }
        public int SystemUserId { get; set; }
        public int CategoryId { get; set; }
        public string Post { get; set; }
        public int IsChairman { get; set; }
        public string VisitorName { get; set; }
        public string Category { get; set; }
        public double TotalDA { get; set; }
        public int DADetailMemberId { get; set; }
        public string DaRemarks { get; set; }
        public string Formula { get; set; }
    }
}
