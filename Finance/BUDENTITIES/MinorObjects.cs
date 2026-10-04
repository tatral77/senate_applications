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
        public double MinorObjectAmount { get; set; }
        public double MinorObjectSuplementary { get; set; }
        public double MinorObjectRemaining { get; set; }
        public double MinorObjectSaving { get; set; }
        public double MinorObjectSurrender { get; set; }
        public List<HeadOfAccounts> headOfAccounts { get; set; }
        public int IsActive { get; set; }
    }
}
