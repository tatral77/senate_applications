using System;

namespace Entities
{
    public class Questions
    {
        public int QuestionsId { get; set; }

        public int QuestionBranchId { get; set; }
        public int PreviousQuestionsId { get; set; }
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
        public string QuestionHtmlText { get; set; }
        public string SORemarks { get; set; }
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
        public int FileStatusId { get; set; }
        public string FileStatus { get; set; }
        public DateTime QuestionStatusDate { get; set; }
        public string QuestionFile { get; set; }
        public int IsActive { get; set; }
        public int IsLattestVer { get; set; }
        public string Reply { get; set; }
        public DateTime ReplyDate { get; set; }
        public string ReplyAttachment { get; set; }
        public string ReplyAttachTitle { get; set; }

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
        public int Checked { get; set; }
        public int SentForTranslationBy { get; set; }
        public DateTime SentForTranslationOn { get; set; }
        public DateTime ReturnedFromTranslationOn { get; set; }
        public int TranslatedBy { get; set; }
        public int TranslatedOn { get; set; }
        public int TranslationStatus { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int InsertedBy { get; set; }
        public DateTime InsertedOn { get; set; }
        public int DeletedBy { get; set; }
        public DateTime DeletedOn { get; set; }
        public int RecoveredBy { get; set; }
        public DateTime RecoveredOn { get; set; }
        public int TranslationApprovedBy { get; set; }
        public DateTime TranslationApprovedOn { get; set; }
        public double MatchingPercentage { get; set; }
        public string PoliticalParty { get; set; }
        public string Coallition { get; set; }
        public int DeviceId { get; set; }

    }
}
