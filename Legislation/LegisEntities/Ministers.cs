using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisEntities
{
    public class Ministers
    {
        public int MinisterId { get; set; }
        public string MinisterName { get; set; }
        public int PoliticalPartyId { get; set; }
        public string PoliticalParty { get; set; }
        public int IsActive { get; set; }
        public int GenderId { get; set; }
        public string Gender { get; set; }

    }
}
