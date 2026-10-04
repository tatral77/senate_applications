using System;

namespace Entities
{
    public class AssemblySessions
    {
        public int AssemblySessionsId { get; set; }
        public string CalledBy { get; set; }
        public int IsJointSession { get; set; }
        public int SessionNumber { get; set; }
        public string SessionType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SittingTypeId { get; set; }
        public int IsActive { get; set; }
        public int AssembliesId { get; set; }
        public int SittingPlansId { get; set; }
        public int SummonedBy { get; set; }
        public int ProroguedBy { get; set; }
        public int LegislationDiaryNo { get; set; }
        public DateTime LegislationDiaryDate { get; set; }
        public int SessStatusesId { get; set; }
        public int IsQuorumAdjourned { get; set; }
        public int ParliamentaryYearsId { get; set; }
        public string BusinessSessions { get; set; }
        public string MotionSessions { get; set; }
        public string ResolutionSessions { get; set; }
        public int BusinessStatus { get; set; }
        public DateTime LegislationDiaryTime { get; set; }
        public int NoticeDiaryNo { get; set; }
        public DateTime NoticeDiaryDate { get; set; }
        public DateTime NoticeDiaryTime { get; set; }
        public string FileNo { get; set; }
        public DateTime RequisitionDate { get; set; }
        public DateTime RequisitionTime { get; set; }
        public int TotalWorkingDays { get; set; }
        public int ActualSittingDays { get; set; }
        public DateTime SummonNoticeDate { get; set; }
        public DateTime SummonNoticeTime { get; set; }
        public string Purpose { get; set; }
        public int RowId { get; set; }

    }
}
