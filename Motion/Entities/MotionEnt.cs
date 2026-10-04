using Entities;
using MotionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionEntities
{
    public class MotionEnt
    {
        public int MotionsId { get; set; }
        public int VersionNo { get; set; }
        public string FileNo { get; set; }
        public int WeekId { get; set; }
        public string WeekName { get; set; }
        public DateTime VersionDate { get; set; }
        public int ParliamentaryYear { get; set; }
        public int CurrentRole { get; set; }
        public int MotionTypeId { get; set; }
        public string MotionType { get; set; }
        public DateTime SubmissionDate { get; set; }
        public DateTime SubmissionTime { get; set; }
        public string Subject { get; set; }
        public int NoticeDiaryNo { get; set; }
        public DateTime NoticeDiaryDate { get; set; }
        public DateTime NoticeDiaryTime { get; set; }
        public string MotionDiaryNo { get; set; }
        public DateTime MotionDiaryDate { get; set; }
        public DateTime MotionDiaryTime { get; set; }
        public int SessionNumber { get; set; }
        public string SessionDesc { get; set; }
        public int SessionSittingsId { get; set; }
        public int TranslationType { get; set; }
        public int MotionStatusId { get; set; }
        public string MotionStatus { get; set; }
        public int ReviewedBy { get; set; }
        public string MotionFile { get; set; }
        public string UrduText { get; set; }
        public int VersionNumber { get; set; }
        public string Remarks { get; set; }
        public int FileId { get; set; }
        public int IsActive { get; set; }
        public int IsLatestVer { get; set; }
        public int UpdatedBy { get; set; }
        public int Decision { get; set; }
        public DateTime SubmissionApprovalDate { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime OrderOfDayDate { get; set; }
        public DateTime PresentHouseDate { get; set; }
        public DateTime RefferedScDate { get; set; }
        public DateTime MovingHouseDate { get; set; }
        public int IsAccepted { get; set; }
        public int YesVotes { get; set; }
        public int NoVotes { get; set; }
        public int NotVoted { get; set; }
        public int AbsentVotes { get; set; }
        public int ChairRuling { get; set; }
        public int MotionIdentifier { get; set; }
        public int SubmittedBy { get; set; }
        public DateTime DiscussionDate { get; set; }
        public int TimeTaken { get; set; }
        public DateTime CmtReportDate { get; set; }
        public DateTime CmtRptDiscDate { get; set; }
        public DateTime RulingReserveDate { get; set; }
        public string Descr { get; set; }
        public string Description { get; set; }
        public string NoteDescription { get; set; }
        public int IsSentToTranslation { get; set; }
        public DateTime SentForTranslationOn { get; set; }
        public DateTime ReturnedFromTranslationOn { get; set; }
        public int IsSelBallot { get; set; }
        public int IsAdmitted { get; set; }
        public int Processed { get; set; }
        public int PrevSessionId { get; set; }
        public string Mover { get; set; }

        public List<MotionMoversEnt> Movers = null;
        public List<MotionMinistriesEnt> MotionMinistries = null;
        public string ReportForMember { get; set; }
        public int DeviceId { get; set; }

    }
}
