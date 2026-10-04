using System;

namespace Entities
{
    public class DeferQuestion
    {
        public int DeferId { get; set; }
        public int QuestionId { get; set; }
        public int AssemblySessionId { get; set; }
        public DateTime DeferDate { get; set; }
        public int InsertedBy { get; set; }
        public DateTime InsertedOn { get; set; }
        public string Remarks { get; set; }
    }
}
