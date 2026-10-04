using System;

namespace Entities
{
    public class ListQuestion
    {
        public int QuestionId { get; set; }
        public int QuestionDiaryNo { get; set; }
        public int SessionId { get; set; }
        public DateTime DeferDate { get; set; }
        public int SystemUsersId { get; set; }
        public int CategoryId { get; set; }
        public int ListNo { get; set; }
        public char SuplementaryNo { get; set; }
        public int NoticeDiaryNo { get; set; }
        public DateTime NoticeDiaryDate { get; set; }
        public DateTime NoticeDiaryTime { get; set; }
        public string MoverName { get; set; }
        public int SessionNumber { get; set; }
        public int StatusId { get; set; }
        public string QuestionText { get; set; }
        public int GroupId { get; set; }
        public int DivisionId { get; set; }
        public string Division { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public string Group { get; set; }
        public int CorrespondingGroup { get; set; }
        public string SessionName { get; set; }
        public DateTime StatusDate { get; set; }
        public int DeviceId { get; set; }
    }
}
