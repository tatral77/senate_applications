using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Member
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public int PostId { get; set; }
        public string Post { get; set; }
        public string BPS { get; set; }
        public int IsActive { get; set; }
    }
}
