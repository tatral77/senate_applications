using System;

namespace Entities
{
    public class GroupDiary
    {
        public int QuestionId { get; set; }
        public int QuestionDiaryNo { get; set; }
        public string Mover { get; set; }
        public string QuestionText { get; set; }
        public string DivisionName { get; set; }
        public int NoticeDiaryNo { get; set; }
        public DateTime NoticeDiaryDate { get; set; }
        public DateTime NoticeDiaryTime { get; set; }
        public int QuestionStatusId { get; set; }
        public string QuestionStatus { get; set; }
        public DateTime StatusDate { get; set; }
        public DateTime ReplyDate { get; set; }
        public int ListNo { get; set; }
        public string SupListNo { get; set; }
        public DateTime ListDate { get; set; }
        public string Remarks { get; set; }
        public int DeviceId { get; set; }
    }
}
