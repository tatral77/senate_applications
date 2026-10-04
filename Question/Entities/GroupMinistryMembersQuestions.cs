using System.Collections.Generic;

namespace Entities
{
    public class GroupMinistryMembersQuestions
    {
        public string Group { get; set; }
        public string Ministry { get; set; }
        public string MoverName { get; set; }
        public int QuestionId { get; set; }
        public List<MemberQuestions> memberQuestions { get; set; }
        public int MinistryTotal { get; set; }
        public int MemberTotal { get; set; }
        public int GroupTotal { get; set; }


    }
}
