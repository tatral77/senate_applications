using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RevivalHistory
    {
        public int RevivalHistoryId { get; set; }
        public int MotionsId { get; set; }
        public DateTime RevivalDate { get; set; }
        public int FromAssemblySessionId { get; set; }
        public string FromAssemblySession { get; set; }
        public int ToAssemblySessionId { get; set; }
        public string ToAssemblySession { get; set; }
        public int NoticeOfficediaryNumber { get; set; }
    }
}
