using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolutionEntities
{
    public class ResolutionMinistries
    {
        public int ResolutionMinistriesId { get; set; }
        public string MinistryName { get; set; }
        public int ResolutionId { get; set; }
        public int MinistryId { get; set; }
    }
}
