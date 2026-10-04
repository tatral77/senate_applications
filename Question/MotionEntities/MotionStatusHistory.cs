using System;

namespace MotionEntities
{
    public class MotionStatusHistory
    {
        public int MotionStatusHistoryId { get; set; }
        public int MotionStatusId { get; set; }
        public int MotionId { get; set; }
        public string MotionStatus { get; set; }
        public int AssemblySessionId { get; set; }
        public string AssemblySession { get; set; }
        public DateTime StatusDate { get; set; }
        public DateTime ReplyDate { get; set; }
        public string Remarks { get; set; }
    }
}
