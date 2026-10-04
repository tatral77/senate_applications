using System;

namespace MotionEntities
{
    public class MotionsList
    {
        public int MotionListId { get; set; }
        public int AssemblySessionsId { get; set; }
        public int StartNo { get; set; }
        public string ListName { get; set; }
        public DateTime ListDate { get; set; }
        public string Motions { get; set; }
    }
}
