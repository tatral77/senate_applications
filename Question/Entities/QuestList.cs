using System;

namespace Entities
{
    public class QuestList
    {
        public int QuestionsListId { get; set; }
        public int AssemblySessionsId { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int GroupsId { get; set; }
        public int StartNo { get; set; }
        public int LastNumber { get; set; }
        public string ListName { get; set; }
        public DateTime ListDate { get; set; }
        public string DefQuestions { get; set; }
        public string Questions { get; set; }


    }
}
