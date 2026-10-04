using System;

namespace Entities
{
    public class ParliamentaryYears
    {
        public int ParliamentaryYearsId { get; set; }
        public string ParliamentaryYear { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int IsActive { get; set; }
        public int ParliamentaryTenuresId { get; set; }
        public string ParliamentaryTenure { get; set; }
        public int ParliamentaryTermId { get; set; }
        public string ParliamentaryTerm { get; set; }


    }
}
