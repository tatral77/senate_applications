using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class GroupDivisions
    {
        public int GroupDivisionsId { get; set; }
        public int GroupsId { get; set; }
        public string Group { get; set; }
        public int DivisionsId { get; set; }
        public string Division { get; set; }
        public int GroupSequence { get; set; }
    }
}
