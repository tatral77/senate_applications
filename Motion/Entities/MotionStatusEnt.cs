using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionEntities
{
    public class MotionStatusEnt
    {
        public int MotionStatusId { get; set; }
        public string Description { get; set; }
        public string MotionStatus { get; set; }
        public int IsActive { get; set; }
    }
}
