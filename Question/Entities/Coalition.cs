using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Coalition
    {
        public int CoalitionId { get; set; }
        public string CoalitionDesc { get; set; }
        public int SortOrder { get; set; }
        List<PoliticalParty> PoliticalParties = new List<PoliticalParty>();
    }
}
