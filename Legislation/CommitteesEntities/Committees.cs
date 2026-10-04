using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitteesEntities
{
    public class Committees
    {
        public int CommitteesId { get; set; }
        public string CommitteeName { get; set; }
        public DateTime FormationDate { get; set; }
        public int CommitteeTypeId { get; set; }
        public string CommitteeType { get; set; }
        public int ParliamentaryTermId { get; set; }
        public string ParliamentaryTerm { get; set; }
        public int IsActive { get; set; }


    }
}
