using System;

namespace Entities
{
    public class QuestionStatusHistory
    {
        public int QuestionStatusHistoryId { get; set; }
        public int QuestionStatusId { get; set; }
        public int QuestionId { get; set; }
        public string QuestionStatus { get; set; }
        public int AssemblySessionId { get; set; }
        public string AssemblySession { get; set; }
        public DateTime StatusDate { get; set; }
        public string Remarks { get; set; }

    }
}
