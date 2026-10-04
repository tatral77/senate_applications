using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Assemblies
    {
        public int AssembliesId { get; set; }
        public int Term { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int NoOfSeats { get; set; }
        public int ElectionYear { get; set; }
        public int IsActive { get; set; }
        public int MaxStarredAllowed { get; set; }
        public int MaxUnStarredAllowed { get; set; }
        public int MaxSNoticeAllowed { get; set; }
    }
}
