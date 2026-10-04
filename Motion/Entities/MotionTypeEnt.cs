using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionEntities
{
    public class MotionTypeEnt
    {
        public int MotionTypeId { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
        public int IsForMotions { get; set; }
        public int SortOrder { get; set; }
    }
}
