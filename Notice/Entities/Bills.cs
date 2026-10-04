using LegisEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Bills
    {
        public int BillsId { get; set; }

        public int ParliamentaryYearId { get; set; }
        public string CurrentRole { get; set; }
        public int BillCategoryId { get; set; }
        public int Priority { get; set; }
        public int BillStatusId { get; set; }
        public DateTime StatusDate { get; set; }
        public int BillTypeId { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime BillTime { get; set; }
        public int AssemblySessionsId { get; set; }
        public int SessionSittingsId { get; set; }
        public string ReviewedBy { get; set; }
        public string Remarks { get; set; }
        public int IsActive { get; set; }
        public int NoticeDiaryNo { get; set; }
        public DateTime NoticeDiaryDate { get; set; }
        public DateTime NoticeDiaryTime { get; set; }
        public string LegislationDiaryNo { get; set; }
        public DateTime LegislationDiaryDate { get; set; }
        public DateTime LegislationDiaryTime { get; set; }
        public string BillTitle { get; set; }
        public DateTime GovtBillDate { get; set; }
        public DateTime MotionDate { get; set; }
        public DateTime BillPassageDate { get; set; }
        public DateTime BillAssentDate { get; set; }
        public int IswithSatndingCommitee { get; set; }
        public DateTime BudgetPresDate { get; set; }
        public DateTime FBillPresDate { get; set; }
        public int DiscussDays { get; set; }
        public int ParticipatedMembers { get; set; }
        public int GovtPMembers { get; set; }
        public int OppPMembers { get; set; }
        public DateTime SntRecDate { get; set; }

        public DateTime SntRecTime { get; set; }
        public DateTime SntEntryDate { get; set; }
        public DateTime SntEntryTime { get; set; }
        public string SntReference { get; set; }
        public string SntRecommendation { get; set; }
        public string BillIdentifier { get; set; }
        public string FileNumber { get; set; }
        public string PassedAsReptBySc { get; set; }
        public string PassedWoStCmt { get; set; }
        public int IsAct { get; set; }
        public int BillCategoriesId { get; set; }
        public int BillStagesId { get; set; }
        public DateTime BillGazettedDate { get; set; }
        public DateTime SentToNaDate { get; set; }
        public DateTime ReceivedFromNADate { get; set; }
        public string NARemarks { get; set; }
        public int IsWithPresident { get; set; }
        public DateTime SendToPresidentDate { get; set; }
        public int HouseTypesId { get; set; }
        public int IsWithNa { get; set; }
        public string AndWhereas { get; set; }
        public string NowTherefore { get; set; }
        public DateTime WithdrawalDate { get; set; }
        public DateTime FirstReadingDate { get; set; }
        public DateTime SecondReadindDate { get; set; }
        public DateTime ThirdReadingDate { get; set; }
        public int IsEnteredByMember { get; set; }
        public DateTime MedCmtRefDate { get; set; }
        public DateTime MedCmtPresDate { get; set; }
        public DateTime AgreedBillConsDate { get; set; }
        public DateTime AgreedBillPassDate { get; set; }
        public DateTime OtherHouseReceiptDate { get; set; }
        public DateTime BillCircDate { get; set; }
        public DateTime MinisterNoticeDate { get; set; }
        public DateTime NoticeCircDate { get; set; }
        public DateTime LawDivSentDate { get; set; }
        public DateTime LawDivRecDate { get; set; }
        public DateTime OtherHouseIntimateDate { get; set; }
        public DateTime OtherHouseReturnDate { get; set; }
        public DateTime ActGazettePubDate { get; set; }
        public string PublicOpinion { get; set; }
        public string CiiOpinion { get; set; }
        public DateTime PublicOpinionCircDate { get; set; }
        public DateTime PublicOpinionDate { get; set; }
        public DateTime CllReferDate { get; set; }
        public DateTime CllReportDate { get; set; }
        public int BillYear { get; set; }
        public DateTime PresidentAssentDate { get; set; }
        public string FinanceBillReference { get; set; }
        public int IsSentToSenate { get; set; }
        public int IsSentToCommittee { get; set; }
        public int IsLeaveGranted { get; set; }
        public string LeaveGrantedBy { get; set; }
        public string Designation { get; set; }
        public DateTime LeaveGranteDate { get; set; }

        public int IsWithMedCommittee { get; set; }
        public string Subject { get; set; }

        public DateTime RejectAmendDate { get; set; }
        public string Letter { get; set; }
        public string Noting { get; set; }
        public int DivisionsId { get; set; }
        public int IsSentToTranslation { get; set; }
        public string UrduText { get; set; }
        public string EnglishText { get; set; }
        public string AmendedContent { get; set; }
        public string MemBillSubject { get; set; }
        public string MemBillContent { get; set; }
        public string NoticeFile { get; set; }
        public string BillFile { get; set; }
        public int CommitteeId { get; set; }
        public string CommitteeName { get; set; }
        public string MinistersCSV { get; set; }
        public string MembersCSV { get; set; }
        public string DivisionsCSV { get; set; }
        public DateTime CommitteeRefDate { get; set; }
        public string CommitteeReportFile { get; set; }
        public string CommitteeRemarks { get; set; }
        public BillTypes BillTypes { get; set; }
        public BillStatuses BillStatuses { get; set; }
        public HouseTypes HouseTypes { get; set; }
        public BillCategories BillCategories { get; set; }
        public List<Divisions> Divisions { get; set; }
        public List<BillMinisters> BillMinisters { get; set; }
        public AssemblySessions AssemblySessions { get; set; }
        public BillStages BillStages { get; set; }
        public List<BillMovers> BillMovers { get; set; }
        public List<BillDivisions> BillDivisions { get; set; }
        public List<BillDocumentsEnt> billDocumentsEnts { get; set; }
        public ParliamentaryYears ParliamentaryYears { get; set; }
        public DateTime IntroducedInHouseOn { get; set; }
        public int CommitteeTimeLimit { get; set; }
        public int CommitteeRecommendationId { get; set; }
        public DateTime CommitteeReportDate { get; set; }
        public int MemberWithdrawStatusId { get; set; }
        public DateTime MemberWithdrawStatusDate { get; set; }
        public DateTime HouseForConsiderationDate { get; set; }
        public int ConsiderationSessionId { get; set; }
        public string MemberRemarks { get; set; }
        public DateTime PassedByNADate { get; set; }
        public string MoverNames { get; set; }
        public string MinisterNames { get; set; }
        public string DivisionNames { get; set; }

        public int InsertedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int DeletedBy { get; set; }
        public int RecoveredBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime InsertedOn { get; set; }
        public DateTime DeletedOn { get; set; }
        public DateTime RecoveredOn { get; set; }
        public int DeviceId { get; set; }
    }
}
