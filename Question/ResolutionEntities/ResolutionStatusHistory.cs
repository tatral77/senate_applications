using System;

namespace ResolutionEntities
{
    public class ResolutionStatusHistory
    {
        public int ResolutionStatusHistoryId { get; set; }
        public int ResolutionStatusId { get; set; }
        public int ResolutionId { get; set; }
        public string ResolutionStatus { get; set; }
        public int AssemblySessionId { get; set; }
        public string AssemblySession { get; set; }
        public int InsertedBy { get; set; }

        public DateTime StatusDate { get; set; }
        public DateTime ReplyDate { get; set; }
        public string Remarks { get; set; }
    }
}
