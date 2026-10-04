using IPRENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPRENITITIES
{
    public class FriendshipGroup
    {
        public int FriendshipGroupId { get; set; }
        public string GroupName { get; set; }
        public int ConvinerId { get; set; }
        public string ConvinerName { get; set; }
        public int CountryId { get; set; }
        public string Country { get; set; }
        public int TermId { get; set; }
        public string Term { get; set; }
    }
}
