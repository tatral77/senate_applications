using System;

namespace Entities
{
    public class SuplementaryListEnt
    {
        public int QuestionSupListId { get; set; }
        public string ListName { get; set; }
        public DateTime ListDate { get; set; }
        public int QuestionListId { get; set; }
        public int GroupsId { get; set; }
        public string Questions { get; set; }
        public int AssemblySessionsId { get; set; }


    }
}
