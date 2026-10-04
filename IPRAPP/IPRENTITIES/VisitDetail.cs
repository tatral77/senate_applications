using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPRENITITIES
{
    public class VisitDetail
    {
        public int VisitDetailId { get; set; }
        public int VisitId { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public DateTime FromDate{ get; set; }
        public DateTime ToDate { get; set; }
        public string Remarks { get; set; }

    }
}
