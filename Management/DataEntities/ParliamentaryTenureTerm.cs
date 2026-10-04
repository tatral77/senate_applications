using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataEntities
{
    public class ParliamentaryTenureTerm
    {
        public int ParliamentaryTenureTermId { get; set; }
        public int ParliamentaryTenureId { get; set; }
        public int ParliamentaryTermId { get; set; }
        public string Description { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
