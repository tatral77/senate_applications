using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionEntities
{
    public class QuestionStatuses
    {
        public int QuestionStatusesId { get; set; }
        public string Description { get; set; }
        public string ActionName { get; set; }
        public int StatusLevelId{ get; set; }
        public string StatusLevel { get; set; }
        public int IsActive { get; set; }
        public int DisplaySequence { get; set; }
    }
}
