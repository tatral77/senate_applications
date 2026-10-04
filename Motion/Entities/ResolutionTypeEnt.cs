using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionEntities
{
    public class ResolutionTypeEnt
    {
        public int ResTypesId { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
        public int BranchesId { get; set; }
    }
}
