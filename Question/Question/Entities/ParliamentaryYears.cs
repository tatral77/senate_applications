using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ParliamentaryYears
    {
        public int ParliamentaryYearsId { get; set; }
        public string ParliamentaryYear { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int IsActive { get; set; }
        public int ParliamentaryPeriodsId { get; set; }
        public string ParliamentaryPeriod { get; set; }


    }
}
