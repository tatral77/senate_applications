using System;

namespace Entities
{
    public class CarryForward
    {
        public int CarryFwdId { get; set; }
        public int QuestionId { get; set; }
        public int FromSession { get; set; }
        public int ToSession { get; set; }
        public DateTime CarryFwdDate { get; set; }
    }
}
