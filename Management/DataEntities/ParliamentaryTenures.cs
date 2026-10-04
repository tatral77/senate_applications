using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities
{
    public class ParliamentaryTenures
    {
        public int ParliamentaryTenuresId { get; set; }
        public string Description{ get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int IsActive { get; set; }
        public int IsCurrent { get; set; }
        List<ParliamentaryTerms> ParliamentaryTerms { get; set; }
    }
}
