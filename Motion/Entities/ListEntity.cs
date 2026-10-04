using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class ListEntity
    {
        public int MotionListId { get; set; }
        public int AssemblySessionsId { get; set; }
        public string AsseblySession { get; set; }
        public int MotionWeekId { get; set; }
        public string MotionWeek { get; set; }
        public int MotionTypeId { get; set; }
        public string MotionType { get; set; }
        public string ListName { get; set; }
        public DateTime ListDate { get; set; }
        public string DefferedMotions { get; set; }
        public string ListMotions { get; set; }
    }
}
