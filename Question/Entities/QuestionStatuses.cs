namespace Entities
{
    public class QuestionStatuses
    {
        public int QuestionStatusesId { get; set; }
        public string Description { get; set; }
        public string ActionName { get; set; }
        public int StatusLevelId { get; set; }
        public string StatusLevel { get; set; }
        public int IsActive { get; set; }
        public int DisplaySequence { get; set; }
    }
}
