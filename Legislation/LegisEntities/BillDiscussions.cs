using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisEntities
{
    class BillDiscussions
    {
        public int BillDiscussionsId { get; set; }
        public int BillsId { get; set; }
        public int SystemUsersId { get; set; }
        public DateTime DiscussionTime { get; set; }
        public int BillStagesId { get; set; }
        public string DiscussionText { get; set; }
    }
}
