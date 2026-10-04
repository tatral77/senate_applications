using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Question
    {
        public int QuestionsId { get; set; }
        public int PreviousQuestionId { get; set; }
        public int ListId { get; set; }
        public string SupNo { get; set; }
        public int VersionNo { get; set; }
        public DateTime VersionDate { get; set; }
        public int ParliamentaryYearsId { get; set; }
        public string ParliamentaryYear { get; set; }
        public int Mover { get; set; }
        public string MoverName { get; set; }
        public int CurrentRole { get; set; }
        public int QuestionCategoriesId { get; set; }
        public string QuestionCategory { get; set; }
        public DateTime QuestionDate { get; set; }
        public string QuestionTime { get; set; }
        public string Subject { get; set; }
        public string QuestionText { get; set; }
        public int MinistryId { get; set; }
        public string Ministry { get; set; }
        public int MinistryGroupId { get; set; }
        public string MinistryGroup { get; set; }
        public int DivisionId { get; set; }
        public string Division { get; set; }
        public int DepartmentsId { get; set; }
        public string Department { get; set; }
        public int NoticeDiaryNo { get; set; }
        public DateTime NoticeDiaryDate { get; set; }
        public DateTime NoticeDiaryTime { get; set; }
        public string AdmittedNumber { get; set; }
        public int QuestionDiaryNo { get; set; }
        public DateTime QuestionDiaryDate { get; set; }
        public DateTime QuestionDiaryTime { get; set; }
        public int SessionNumberId { get; set; }
        public string SessionNumber { get; set; }
        public int SessionSittingsId { get; set; }
        public int PreviousSessionNumber { get; set; }
        public string SessionSitting { get; set; }
        public int TranslationTypeId { get; set; }
        public string TranslationType { get; set; }
        public int QuestionStatusId { get; set; }
        public string QuestionStatus { get; set; }
        public DateTime QuestionStatusDate { get; set; }
        public string QuestionFile { get; set; }
        public int IsActive { get; set; }
        public int IsLattestVer { get; set; }
        public string Reply { get; set; }
        public DateTime ReplyDate { get; set; }
        public string ReplyAttachment { get; set; }
        public string ReplyAttachTitle { get; set; }
        public int UpdatedBy { get; set; }
        public int QuestionIdentifier { get; set; }
        public string ReplyReference { get; set; }
        public int ComputerNo { get; set; }
        public string UrduText { get; set; }
        public int IsSentToTranslation { get; set; }
        public int PrevSessionId { get; set; }
        public string PreviousSession { get; set; }
        public int IsAdmitted { get; set; }
        public DateTime noticetime { get; set; }
        public int IsCarryFwd { get; set; }
        public string UnstarDesc { get; set; }
        public int GroupSequence { get; set; }
        public int Priority { get; set; }
        public DateTime SentForTranslationOn { get; set; }
        public DateTime ReturnedFromTranslationOn { get; set; }
    }
}
