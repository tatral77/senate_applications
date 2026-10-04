using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUDENTITIES
{
    public class MinorObjects
    {
        public int MinorObjectId { get; set; }
        public string MinorObject { get; set; }
        public int MajorObjectId { get; set; }
        public int MinorObjectAmount { get; set; }
        public List<HeadOfAccounts> headOfAccounts { get; set; }
        public int IsActive { get; set; }
    }
}
