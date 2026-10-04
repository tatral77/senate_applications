using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportEntities
{
    public class Terms
    {
        public int TermId { get; set; }
        public string Term { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int TenureId { get; set; }
        public Tenures Tenure { get; set; }
        public int IsActive { get; set; }
        public int IsCurrent { get; set; }
    }
}
