using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolutionEntities
{
    public class ResolutionRevivalHistory
    {
        public int RevivalHistoryId { get; set; }
        public int ResolutionId { get; set; }
        public DateTime RevivalDate { get; set; }
        public int FromAssemblySessionId { get; set; }
        public string FromAssemblySession { get; set; }
        public int ToAssemblySessionId { get; set; }
        public string ToAssemblySession { get; set; }
        public int NoticeOfficediaryNumber { get; set; }
        public int InsertedBy { get; set; }
        public DateTime InsertedOn { get; set; }
        public string PreviousFile { get; set; }
    }
}
