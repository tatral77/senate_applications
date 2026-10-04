using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPRENITITIES
{
    public class OutgoingVisitSanction
    {
        public int SanctionId { get; set; }
        public int VisitId { get; set; }
        public DateTime SanctionDate { get; set; }
        public string FileNo { get; set; }
        public string Subject { get; set; }
        public string MovedBy { get; set; }
        public string IncurredOn { get; set; }
        public string RuleNo { get; set; }
        public string HeadOfAccount { get; set; }
    }
}
