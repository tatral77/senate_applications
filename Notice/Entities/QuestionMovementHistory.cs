using System;

namespace Entities
{
    public class QuestionMovementHistory
    {
        public int QuestionMovementHistoryId { get; set; }
        public int QuestionId { get; set; }
        public int AssemblySessionId { get; set; }
        public int FromAssemblySession { get; set; }
        public int ToAssemblySession { get; set; }
        public DateTime MovementDate { get; set; }
        public string Remarks { get; set; }
    }
}
