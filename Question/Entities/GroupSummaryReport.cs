namespace Entities
{
    public class GroupSummaryReport
    {
        public int GroupId { get; set; }
        public int DivisionId { get; set; }
        public int TotalQuestions { get; set; }
        public string Category { get; set; }
        public string Group { get; set; }
        public string Division { get; set; }
        public int Starred { get; set; }
        public int UnStarred { get; set; }
        public int Deferred { get; set; }
        public int DeferredUnstarred { get; set; }
        public string SerialNumber { get; set; }
    }
}
