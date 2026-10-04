using System;

namespace MotionEntities
{
    public class ListEntity
    {
        public int MotionListId { get; set; }
        public int AssemblySessionsId { get; set; }
        public string ListName { get; set; }
        public DateTime ListDate { get; set; }
        public string ListMotions { get; set; }
    }
}
