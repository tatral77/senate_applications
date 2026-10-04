using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MotionMinistriesEnt
    {
        public int MotionMinistriesId { get; set; }
        public string MinistryName { get; set; }
        public int MotionId { get; set; }
        public int MinistryId { get; set; }

    }
}
