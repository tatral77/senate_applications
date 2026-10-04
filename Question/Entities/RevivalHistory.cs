using System;

namespace Entities
{
    public class RevivalHistory
    {
        public int RevivalHistoryId { get; set; }
        public int QuestionsId { get; set; }
        public DateTime RevivalDate { get; set; }
        public int FromAssemblySessionId { get; set; }
        public string FromAssemblySession { get; set; }
        public int ToAssemblySessionId { get; set; }
        public string ToAssemblySession { get; set; }
        public int NoticeOfficediaryNumber { get; set; }
        public int InsertedBy { get; set; }
        public DateTime InsertedOn { get; set; }

    }
}
