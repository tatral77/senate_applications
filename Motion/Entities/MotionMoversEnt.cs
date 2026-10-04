using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionEntities
{
    public class MotionMoversEnt
    {
        public int MotionMoversId { get; set; }
        public int MotionId { get; set; }
        public int SystemUsersId { get; set; }
        public string MoverName { get; set; }
    }
}
