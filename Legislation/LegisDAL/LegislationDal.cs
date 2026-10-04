using BUDENTITIES;
using LegisEntities;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisDAL
{
    public class LegislationDal
    {
        protected Bills BindSearchFields(SqlDataReader dr)
        {
            Bills Temp = new Bills();
            Temp.BillsId = Convert.ToInt32(dr["BILLS_ID"]);
            if (dr["BILL_STATUS_ID"] != DBNull.Value)
            {
                Temp.BillStatusId = Convert.ToInt32(dr["BILL_STATUS_ID"]);
                Temp.BillStatuses = new BillStatuses();
                Temp.BillStatuses.BillStatusesId = Convert.ToInt32(dr["BILL_STATUS_ID"]);
                Temp.BillStatuses.Description = Convert.ToString(dr["BILL_STATUS"]);
            }
            if (dr["Bill_TYPE_ID"] != DBNull.Value)
            {
                Temp.BillTypeId = Convert.ToInt32(dr["Bill_TYPE_ID"]);
                Temp.BillTypes = new BillTypes();
                Temp.BillTypes.BillTypesId = Convert.ToInt32(dr["BILL_TYPE_ID"]);
                Temp.BillTypes.Description = Convert.ToString(dr["BILL_TYPE"]);
            }
            if (dr["BILL_STAGES_ID"] != DBNull.Value)
            {
                Temp.BillStagesId = Convert.ToInt32(dr["BILL_STAGES_ID"]);
                Temp.BillStages = new BillStages();
                Temp.BillStages.BillStagesId = Convert.ToInt32(dr["BILL_STAGES_ID"]);
                Temp.BillStages.Description = Convert.ToString(dr["BILL_STAGE"]);
            }
            if (dr["ASSEMBLY_SESSIONS_ID"] != DBNull.Value)
            {
                Temp.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);
                Temp.AssemblySessions = new AssemblySessions();
                Temp.AssemblySessions.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);
                Temp.AssemblySessions.SessionNumber = Convert.ToInt32(dr["SESSION_NUMBER_DESC"]);
            }
            if (dr["HOUSE_TYPES_ID"] != DBNull.Value)
            {
                Temp.HouseTypesId = Convert.ToInt32(dr["HOUSE_TYPES_ID"]);
                Temp.HouseTypes = new HouseTypes();
                Temp.HouseTypes.HouseTypesId = Convert.ToInt32(dr["HOUSE_TYPES_ID"]);
                Temp.HouseTypes.Description = Convert.ToString(dr["HOUSE_TYPE"]);
            }

            if (dr["BILL_CATEGORIES_ID"] != DBNull.Value)
            {
                Temp.BillCategoriesId = Convert.ToInt32(dr["BILL_CATEGORIES_ID"]);
                Temp.BillCategories = new BillCategories();
                Temp.BillCategories.BillCategoriesId = Convert.ToInt32(dr["BILL_CATEGORIES_ID"]);
                Temp.BillCategories.Description = Convert.ToString(dr["BILL_CATEGORY"]);
            }
            if (dr["PARLIAMENTARY_YEAR_ID"] != DBNull.Value)
            {
                Temp.ParliamentaryYearId = Convert.ToInt32(dr["PARLIAMENTARY_YEAR_ID"]);
                Temp.ParliamentaryYears = new ParliamentaryYears();
                Temp.ParliamentaryYears.ParliamentaryYearsId = Convert.ToInt32(dr["PARLIAMENTARY_YEAR_ID"]);
                Temp.ParliamentaryYears.ParliamentaryYear = Convert.ToString(dr["PARLIAMENTARY_YEAR"]);
            }

            if (dr["STATUS_DATE"] != DBNull.Value)
                Temp.StatusDate = Convert.ToDateTime(dr["STATUS_DATE"]);
            if (dr["BILL_TITLE"] != DBNull.Value)
                Temp.BillTitle = Convert.ToString(dr["BILL_TITLE"]);
            if (dr["SESSION_SITTINGS_ID"] != DBNull.Value)
                Temp.SessionSittingsId = Convert.ToInt32(dr["SESSION_SITTINGS_ID"]);
            if (dr["LEGISLATION_DIARY_NO"] != DBNull.Value)
                Temp.LegislationDiaryNo = Convert.ToString(dr["LEGISLATION_DIARY_NO"]);
            if (dr["LEGISLATION_DIARY_DATE"] != DBNull.Value)
                Temp.LegislationDiaryDate = Convert.ToDateTime(dr["LEGISLATION_DIARY_DATE"]);
            if (dr["SNT_ENTRY_DATE"] != DBNull.Value)
                Temp.SntEntryDate = Convert.ToDateTime(dr["SNT_ENTRY_DATE"]);
            if (dr["IS_ACT"] != DBNull.Value)
                Temp.IsAct = Convert.ToInt32(dr["IS_ACT"]);
            if (dr["SECOND_READING_DATE"] != DBNull.Value)
                Temp.SecondReadindDate = Convert.ToDateTime(dr["SECOND_READING_DATE"]);
            if (dr["OTHER_HOUSE_RECEIPT_DATE"] != DBNull.Value)
                Temp.OtherHouseReceiptDate = Convert.ToDateTime(dr["OTHER_HOUSE_RECEIPT_DATE"]);
            if (dr["OTHER_HOUSE_RETURN_DATE"] != DBNull.Value)
                Temp.OtherHouseReturnDate = Convert.ToDateTime(dr["OTHER_HOUSE_RETURN_DATE"]);
            if (dr["CII_REPORT_DATE"] != DBNull.Value)
                Temp.CllReportDate = Convert.ToDateTime(dr["CII_REPORT_DATE"]);
            if (dr["LEAVE_GRANTED_BY"] != DBNull.Value)
                Temp.LeaveGrantedBy = Convert.ToString(dr["LEAVE_GRANTED_BY"]);
            if (dr["IS_SENT_TO_TRANSLATION"] != DBNull.Value)
                Temp.IsSentToTranslation = Convert.ToInt32(dr["IS_SENT_TO_TRANSLATION"]);
            if (dr["UPDATED_BY"] != DBNull.Value)
                Temp.UpdatedBy = Convert.ToInt32(dr["UPDATED_BY"]);
            if (dr["REVIEWED_BY"] != DBNull.Value)
                Temp.ReviewedBy = Convert.ToString(dr["REVIEWED_BY"]);
            if (dr["LEGISLATION_DIARY_TIME"] != DBNull.Value)
                Temp.LegislationDiaryTime = Convert.ToDateTime(dr["LEGISLATION_DIARY_TIME"]);
            if (dr["F_BILL_PRES_DATE"] != DBNull.Value)
                Temp.FBillPresDate = Convert.ToDateTime(dr["F_BILL_PRES_DATE"]);
            if (dr["SNT_ENTRY_TIME"] != DBNull.Value)
                Temp.SntEntryTime = Convert.ToDateTime(dr["SNT_ENTRY_TIME"]);

            if (dr["IS_WITH_NA"] != DBNull.Value)
                Temp.IsWithNa = Convert.ToInt32(dr["IS_WITH_NA"]);
            if (dr["THIRD_READING_DATE"] != DBNull.Value)
                Temp.ThirdReadingDate = Convert.ToDateTime(dr["THIRD_READING_DATE"]);

            if (dr["BILL_CIRC_DATE"] != DBNull.Value)
                Temp.BillCircDate = Convert.ToDateTime(dr["BILL_CIRC_DATE"]);
            if (dr["ACT_GAZETTE_PUB_DATE"] != DBNull.Value)
                Temp.ActGazettePubDate = Convert.ToDateTime(dr["ACT_GAZETTE_PUB_DATE"]);
            if (dr["BILL_YEAR"] != DBNull.Value)
                Temp.BillYear = Convert.ToInt32(dr["BILL_YEAR"]);
            if (dr["DESIGNATION"] != DBNull.Value)
                Temp.Designation = Convert.ToString(dr["DESIGNATION"]);
            if (dr["URDU_TEXT"] != DBNull.Value)
                Temp.UrduText = Convert.ToString(dr["URDU_TEXT"]);
            if (dr["REMARKS"] != DBNull.Value)
                Temp.Remarks = Convert.ToString(dr["REMARKS"]);
            if (dr["GOVT_BILL_DATE"] != DBNull.Value)
                Temp.GovtBillDate = Convert.ToDateTime(dr["GOVT_BILL_DATE"]);
            if (dr["DISCUSS_DAYS"] != DBNull.Value)
                Temp.DiscussDays = Convert.ToInt32(dr["DISCUSS_DAYS"]);
            if (dr["SNT_REFERENCE"] != DBNull.Value)
                Temp.SntReference = Convert.ToString(dr["SNT_REFERENCE"]);
            if (dr["AND_WHEREAS"] != DBNull.Value)
                Temp.AndWhereas = Convert.ToString(dr["AND_WHEREAS"]);
            if (dr["IS_ENTERED_BY_MEMBER"] != DBNull.Value)
                Temp.IsEnteredByMember = Convert.ToInt32(dr["IS_ENTERED_BY_MEMBER"]);
            if (dr["MINISTER_NOTICE_DATE"] != DBNull.Value)
                Temp.MinisterNoticeDate = Convert.ToDateTime(dr["MINISTER_NOTICE_DATE"]);
            if (dr["PUBLIC_OPINION"] != DBNull.Value)
                Temp.PublicOpinion = Convert.ToString(dr["PUBLIC_OPINION"]);
            if (dr["PRESIDENT_ASSENT_DATE"] != DBNull.Value)
                Temp.PresidentAssentDate = Convert.ToDateTime(dr["PRESIDENT_ASSENT_DATE"]);
            if (dr["LEAVE_GRANTE_DATE"] != DBNull.Value)
                Temp.LeaveGranteDate = Convert.ToDateTime(dr["LEAVE_GRANTE_DATE"]);
            if (dr["AMENDED_CONTENT"] != DBNull.Value)
                Temp.AmendedContent = Convert.ToString(dr["AMENDED_CONTENT"]);
            if (dr["CURRENT_ROLE"] != DBNull.Value)
                Temp.CurrentRole = Convert.ToString(dr["CURRENT_ROLE"]);
            if (dr["IS_ACTIVE"] != DBNull.Value)
                Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
            if (dr["MOTION_DATE"] != DBNull.Value)
                Temp.MotionDate = Convert.ToDateTime(dr["MOTION_DATE"]);
            if (dr["PARTICIPATED_MEMBERS"] != DBNull.Value)
                Temp.ParticipatedMembers = Convert.ToInt32(dr["PARTICIPATED_MEMBERS"]);
            if (dr["SNT_RECOMMENDATION"] != DBNull.Value)
                Temp.SntRecommendation = Convert.ToString(dr["SNT_RECOMMENDATION"]);
            if (dr["BILL_GAZETTED_DATE"] != DBNull.Value)
                Temp.BillGazettedDate = Convert.ToDateTime(dr["BILL_GAZETTED_DATE"]);
            if (dr["NOW_THEREFORE"] != DBNull.Value)
                Temp.NowTherefore = Convert.ToString(dr["NOW_THEREFORE"]);
            if (dr["MED_CMT_REF_DATE"] != DBNull.Value)
                Temp.MedCmtRefDate = Convert.ToDateTime(dr["MED_CMT_REF_DATE"]);
            if (dr["NOTICE_CIRC_DATE"] != DBNull.Value)
                Temp.NoticeCircDate = Convert.ToDateTime(dr["NOTICE_CIRC_DATE"]);
            if (dr["CII_OPINION"] != DBNull.Value)
                Temp.CiiOpinion = Convert.ToString(dr["CII_OPINION"]);
            if (dr["FINANCE_BILL_REFERENCE"] != DBNull.Value)
                Temp.FinanceBillReference = Convert.ToString(dr["FINANCE_BILL_REFERENCE"]);
            if (dr["IS_WITH_MED_COMMITTEE"] != DBNull.Value)
                Temp.IswithSatndingCommitee = Convert.ToInt32(dr["IS_WITH_MED_COMMITTEE"]);
            if (dr["MEM_BILL_SUBJECT"] != DBNull.Value)
                Temp.MemBillSubject = Convert.ToString(dr["MEM_BILL_SUBJECT"]);
            if (dr["NOTICE_DIARY_DATE"] != DBNull.Value)
                Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
            if (dr["BILL_PASSAGE_DATE"] != DBNull.Value)
                Temp.BillPassageDate = Convert.ToDateTime(dr["BILL_PASSAGE_DATE"]);
            if (dr["GOVT_P_MEMBERS"] != DBNull.Value)
                Temp.GovtPMembers = Convert.ToInt32(dr["GOVT_P_MEMBERS"]);
            if (dr["BILL_IDENTIFIER"] != DBNull.Value)
                Temp.BillIdentifier = Convert.ToString(dr["BILL_IDENTIFIER"]);
           
            if (dr["WITHDRAWAL_DATE"] != DBNull.Value)
                Temp.WithdrawalDate = Convert.ToDateTime(dr["WITHDRAWAL_DATE"]);
            if (dr["MED_CMT_PRES_DATE"] != DBNull.Value)
                Temp.MedCmtPresDate = Convert.ToDateTime(dr["MED_CMT_PRES_DATE"]);
            if (dr["LAW_DIV_SENT_DATE"] != DBNull.Value)
                Temp.LawDivSentDate = Convert.ToDateTime(dr["LAW_DIV_SENT_DATE"]);
            if (dr["PUBLIC_OPINION_CIRC_DATE"] != DBNull.Value)
                Temp.PublicOpinionCircDate = Convert.ToDateTime(dr["PUBLIC_OPINION_CIRC_DATE"]);
            if (dr["IS_SENT_TO_SENATE"] != DBNull.Value)
                Temp.IsSentToSenate = Convert.ToInt32(dr["IS_SENT_TO_SENATE"]);
            if (dr["SUBJECT"] != DBNull.Value)
                Temp.Subject = Convert.ToString(dr["SUBJECT"]);
            if (dr["MEM_BILL_CONTENT"] != DBNull.Value)
                Temp.MemBillContent = Convert.ToString(dr["MEM_BILL_CONTENT"]);
            if (dr["PRIORITY"] != DBNull.Value)
                Temp.Priority = Convert.ToInt32(dr["PRIORITY"]);
            if (dr["NOTICE_DIARY_NO"] != DBNull.Value)
                Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
            if (dr["BILL_ASSENT_DATE"] != DBNull.Value)
                Temp.BillAssentDate = Convert.ToDateTime(dr["BILL_ASSENT_DATE"]);
            if (dr["OPP_P_MEMBERS"] != DBNull.Value)
                Temp.OppPMembers = Convert.ToInt32(dr["OPP_P_MEMBERS"]);
            if (dr["FILE_NUMBER"] != DBNull.Value)
                Temp.FileNumber = Convert.ToString(dr["FILE_NUMBER"]);
            if (dr["IS_WITH_PRESIDENT"] != DBNull.Value)
                Temp.IsWithPresident = Convert.ToInt32(dr["IS_WITH_PRESIDENT"]);
            if (dr["FIRST_READING_DATE"] != DBNull.Value)
                Temp.FirstReadingDate = Convert.ToDateTime(dr["FIRST_READING_DATE"]);
            if (dr["AGREED_BILL_CONS_DATE"] != DBNull.Value)
                Temp.AgreedBillConsDate = Convert.ToDateTime(dr["AGREED_BILL_CONS_DATE"]);
            if (dr["LAW_DIV_REC_DATE"] != DBNull.Value)
                Temp.LawDivRecDate = Convert.ToDateTime(dr["LAW_DIV_REC_DATE"]);
            if (dr["PUBLIC_OPINION_DATE"] != DBNull.Value)
                Temp.PublicOpinionDate = Convert.ToDateTime(dr["PUBLIC_OPINION_DATE"]);
            if (dr["IS_SENT_TO_COMMITTEE"] != DBNull.Value)
                Temp.IsSentToCommittee = Convert.ToInt32(dr["IS_SENT_TO_COMMITTEE"]);
            if (dr["REJECT_AMEND_DATE"] != DBNull.Value)
                Temp.RejectAmendDate = Convert.ToDateTime(dr["REJECT_AMEND_DATE"]);
            if (dr["NOTICE_DIARY_TIME"] != DBNull.Value)
                Temp.NoticeDiaryTime = Convert.ToDateTime(dr["NOTICE_DIARY_TIME"]);
            if (dr["IS_WITH_STANDING_COMMITTEE"] != DBNull.Value)
                Temp.IswithSatndingCommitee = Convert.ToInt32(dr["IS_WITH_STANDING_COMMITTEE"]);
            if (dr["SNT_REC_DATE"] != DBNull.Value)
                Temp.SntRecDate = Convert.ToDateTime(dr["SNT_REC_DATE"]);
            if (dr["PASSED_AS_REPT_BY_SC"] != DBNull.Value)
                Temp.PassedAsReptBySc = Convert.ToString(dr["PASSED_AS_REPT_BY_SC"]);
            if (dr["SEND_TO_PRESIDENT_DATE"] != DBNull.Value)
                Temp.SendToPresidentDate = Convert.ToDateTime(dr["SEND_TO_PRESIDENT_DATE"]);
            if (dr["AGREED_BILL_PASS_DATE"] != DBNull.Value)
                Temp.AgreedBillPassDate = Convert.ToDateTime(dr["AGREED_BILL_PASS_DATE"]);
            if (dr["OTHER_HOUSE_INTIMATE_DATE"] != DBNull.Value)
                Temp.OtherHouseIntimateDate = Convert.ToDateTime(dr["OTHER_HOUSE_INTIMATE_DATE"]);
            if (dr["CII_REFER_DATE"] != DBNull.Value)
                Temp.CiiOpinion = Convert.ToString(dr["CII_REFER_DATE"]);
            if (dr["IS_LEAVE_GRANTE"] != DBNull.Value)
                Temp.IsLeaveGranted = Convert.ToInt32(dr["IS_LEAVE_GRANTE"]);
            if (dr["LETTER"] != DBNull.Value)
                Temp.Letter = Convert.ToString(dr["LETTER"]);
            if (dr["BILL_DATE"] != DBNull.Value)
                Temp.BillDate = Convert.ToDateTime(dr["BILL_DATE"]);
            if (dr["LEGISLATION_DIARY_NO"] != DBNull.Value)
                Temp.LegislationDiaryNo = Convert.ToString(dr["LEGISLATION_DIARY_NO"]);
            if (dr["SNT_REC_TIME"] != DBNull.Value)
                Temp.SntRecTime = Convert.ToDateTime(dr["SNT_REC_TIME"]);
            if (dr["PASSED_WO_ST_CMT"] != DBNull.Value)
                Temp.PassedWoStCmt = Convert.ToString(dr["PASSED_WO_ST_CMT"]);
            if (dr["NOTING"] != DBNull.Value)
                Temp.Noting = Convert.ToString(dr["NOTING"]);
            if (dr["BILL_TIME"] != DBNull.Value)
                Temp.BillTime = Convert.ToDateTime(dr["BILL_TIME"]);
            if (dr["BILL_FILE"] != DBNull.Value)
                Temp.BillFile = Convert.ToString(dr["BILL_FILE"]);
            if (dr["NOTICE_FILE"] != DBNull.Value)
                Temp.NoticeFile = Convert.ToString(dr["NOTICE_FILE"]);
            if (dr["BILL_INTRODUCE_DATE"] != DBNull.Value)
                Temp.IntroducedInHouseOn = Convert.ToDateTime(dr["BILL_INTRODUCE_DATE"]);
            if (dr["COMMITTEE_ID"] != DBNull.Value)
                Temp.CommitteeId = Convert.ToInt32(dr["COMMITTEE_ID"]);
            if (dr["COMMITTEE_DAYS_LIMIT"] != DBNull.Value)
                Temp.CommitteeTimeLimit = Convert.ToInt32(dr["COMMITTEE_DAYS_LIMIT"]);
            if (dr["COMMITTEE_RECOMMENDATION_ID"] != DBNull.Value)
                Temp.CommitteeTimeLimit = Convert.ToInt32(dr["COMMITTEE_RECOMMENDATION_ID"]);
            if (dr["COMMITTEE_NAME"] != DBNull.Value)
                Temp.CommitteeName = Convert.ToString(dr["COMMITTEE_NAME"]);
            if (dr["COMMITTEE_REF_DATE"] != DBNull.Value)
                Temp.CommitteeRefDate = Convert.ToDateTime(dr["COMMITTEE_REF_DATE"]);
            if (dr["COMMITTEE_REMARKS"] != DBNull.Value)
                Temp.CommitteeRemarks = Convert.ToString(dr["COMMITTEE_REMARKS"]);
            if (dr["COMMITTEE_REPORT_FILE"] != DBNull.Value)
                Temp.CommitteeReportFile = Convert.ToString(dr["COMMITTEE_REPORT_FILE"]);
            if (dr["COMMITTEE_REPORT_DATE"] != DBNull.Value)
                Temp.CommitteeReportDate = Convert.ToDateTime(dr["COMMITTEE_REPORT_DATE"]);
            if (dr["MEMBERS"] != DBNull.Value)
                Temp.MembersCSV = Convert.ToString(dr["MEMBERS"]);
            if (dr["MINISTERS"] != DBNull.Value)
                Temp.MinistersCSV = Convert.ToString(dr["MINISTERS"]);
            if (dr["DIVISIONS"] != DBNull.Value)
                Temp.DivisionsCSV = Convert.ToString(dr["DIVISIONS"]);

            Temp.BillMovers = new List<BillMovers>();
            Temp.BillMovers = GetBillMovers(Temp.BillsId);
            Temp.MoverNames = GetBillMoverNames(Temp.BillMovers);
            Temp.BillMinisters = new List<BillMinisters>();
            Temp.BillMinisters = GetBillMinisters(Temp.BillsId);
            Temp.MinisterNames = GetBillMinisterNames(Temp.BillMinisters);
            Temp.BillDivisions = new List<BillDivisions>();
            Temp.BillDivisions = GetBillDivisions(Temp.BillsId);
            return Temp;
        }
        protected Bills BindFields(SqlDataReader dr)
        {
            Bills Temp = new Bills();
            Temp.BillsId = Convert.ToInt32(dr["BILLS_ID"]);
            if (dr["BILL_STATUS_ID"] != DBNull.Value)
            {
                Temp.BillStatusId = Convert.ToInt32(dr["BILL_STATUS_ID"]);
                Temp.BillStatuses = new BillStatuses();
                Temp.BillStatuses.BillStatusesId = Convert.ToInt32(dr["BILL_STATUS_ID"]);
                Temp.BillStatuses.Description = Convert.ToString(dr["BILL_STATUS"]);
            }
            if (dr["Bill_TYPE_ID"] != DBNull.Value)
            {
                Temp.BillTypeId = Convert.ToInt32(dr["Bill_TYPE_ID"]);
                Temp.BillTypes = new BillTypes();
                Temp.BillTypes.BillTypesId = Convert.ToInt32(dr["BILL_TYPE_ID"]);
                Temp.BillTypes.Description = Convert.ToString(dr["BILL_TYPE"]);
            }
            if (dr["BILL_STAGES_ID"] != DBNull.Value)
            {
                Temp.BillStagesId = Convert.ToInt32(dr["BILL_STAGES_ID"]);
                Temp.BillStages = new BillStages();
                Temp.BillStages.BillStagesId = Convert.ToInt32(dr["BILL_STAGES_ID"]);
                Temp.BillStages.Description = Convert.ToString(dr["BILL_STAGE"]);
            }
            if (dr["ASSEMBLY_SESSIONS_ID"] != DBNull.Value)
            {
                Temp.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);
                Temp.AssemblySessions = new AssemblySessions();
                Temp.AssemblySessions.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);
                Temp.AssemblySessions.SessionNumber = Convert.ToInt32(dr["SESSION_NUMBER_DESC"]);
            }
            if (dr["HOUSE_TYPES_ID"] != DBNull.Value)
            {
                Temp.HouseTypesId = Convert.ToInt32(dr["HOUSE_TYPES_ID"]);
                Temp.HouseTypes = new HouseTypes();
                Temp.HouseTypes.HouseTypesId = Convert.ToInt32(dr["HOUSE_TYPES_ID"]);
                Temp.HouseTypes.Description = Convert.ToString(dr["HOUSE_TYPE"]);
            }

            if (dr["BILL_CATEGORIES_ID"] != DBNull.Value)
            {
                Temp.BillCategoriesId = Convert.ToInt32(dr["BILL_CATEGORIES_ID"]);
                Temp.BillCategories = new BillCategories();
                Temp.BillCategories.BillCategoriesId = Convert.ToInt32(dr["BILL_CATEGORIES_ID"]);
                Temp.BillCategories.Description = Convert.ToString(dr["BILL_CATEGORY"]);
            }
            if (dr["PARLIAMENTARY_YEAR_ID"] != DBNull.Value)
            {
                Temp.ParliamentaryYearId = Convert.ToInt32(dr["PARLIAMENTARY_YEAR_ID"]);
                Temp.ParliamentaryYears = new ParliamentaryYears();
                Temp.ParliamentaryYears.ParliamentaryYearsId = Convert.ToInt32(dr["PARLIAMENTARY_YEAR_ID"]);
                Temp.ParliamentaryYears.ParliamentaryYear = Convert.ToString(dr["PARLIAMENTARY_YEAR"]);
            }

            if (dr["STATUS_DATE"] != DBNull.Value)
                Temp.StatusDate = Convert.ToDateTime(dr["STATUS_DATE"]);
            if (dr["BILL_TITLE"] != DBNull.Value)
                Temp.BillTitle = Convert.ToString(dr["BILL_TITLE"]);
            if (dr["SESSION_SITTINGS_ID"] != DBNull.Value)
                Temp.SessionSittingsId = Convert.ToInt32(dr["SESSION_SITTINGS_ID"]);
            if (dr["LEGISLATION_DIARY_NO"] != DBNull.Value)
                Temp.LegislationDiaryNo = Convert.ToString(dr["LEGISLATION_DIARY_NO"]);
            if (dr["LEGISLATION_DIARY_DATE"] != DBNull.Value)
                Temp.LegislationDiaryDate = Convert.ToDateTime(dr["LEGISLATION_DIARY_DATE"]);
            if (dr["SNT_ENTRY_DATE"] != DBNull.Value)
                Temp.SntEntryDate = Convert.ToDateTime(dr["SNT_ENTRY_DATE"]);
            if (dr["IS_ACT"] != DBNull.Value)
                Temp.IsAct = Convert.ToInt32(dr["IS_ACT"]);
            if (dr["SECOND_READING_DATE"] != DBNull.Value)
                Temp.SecondReadindDate = Convert.ToDateTime(dr["SECOND_READING_DATE"]);
            if (dr["OTHER_HOUSE_RECEIPT_DATE"] != DBNull.Value)
                Temp.OtherHouseReceiptDate = Convert.ToDateTime(dr["OTHER_HOUSE_RECEIPT_DATE"]);
            if (dr["OTHER_HOUSE_RETURN_DATE"] != DBNull.Value)
                Temp.OtherHouseReturnDate = Convert.ToDateTime(dr["OTHER_HOUSE_RETURN_DATE"]);
            if (dr["CII_REPORT_DATE"] != DBNull.Value)
                Temp.CllReportDate = Convert.ToDateTime(dr["CII_REPORT_DATE"]);
            if (dr["LEAVE_GRANTED_BY"] != DBNull.Value)
                Temp.LeaveGrantedBy = Convert.ToString(dr["LEAVE_GRANTED_BY"]);
            if (dr["IS_SENT_TO_TRANSLATION"] != DBNull.Value)
                Temp.IsSentToTranslation = Convert.ToInt32(dr["IS_SENT_TO_TRANSLATION"]);
         
            if (dr["REVIEWED_BY"] != DBNull.Value)
                Temp.ReviewedBy = Convert.ToString(dr["REVIEWED_BY"]);
            if (dr["LEGISLATION_DIARY_TIME"] != DBNull.Value)
                Temp.LegislationDiaryTime = Convert.ToDateTime(dr["LEGISLATION_DIARY_TIME"]);
            if (dr["F_BILL_PRES_DATE"] != DBNull.Value)
                Temp.FBillPresDate = Convert.ToDateTime(dr["F_BILL_PRES_DATE"]);
            if (dr["SNT_ENTRY_TIME"] != DBNull.Value)
                Temp.SntEntryTime = Convert.ToDateTime(dr["SNT_ENTRY_TIME"]);

            if (dr["IS_WITH_NA"] != DBNull.Value)
                Temp.IsWithNa = Convert.ToInt32(dr["IS_WITH_NA"]);
            if (dr["THIRD_READING_DATE"] != DBNull.Value)
                Temp.ThirdReadingDate = Convert.ToDateTime(dr["THIRD_READING_DATE"]); 
               
            if (dr["BILL_CIRC_DATE"] != DBNull.Value)
                Temp.BillCircDate = Convert.ToDateTime(dr["BILL_CIRC_DATE"]);
            if (dr["ACT_GAZETTE_PUB_DATE"] != DBNull.Value)
                Temp.ActGazettePubDate = Convert.ToDateTime(dr["ACT_GAZETTE_PUB_DATE"]);
            if (dr["BILL_YEAR"] != DBNull.Value)
                Temp.BillYear = Convert.ToInt32(dr["BILL_YEAR"]);
            if (dr["DESIGNATION"] != DBNull.Value)
                Temp.Designation = Convert.ToString(dr["DESIGNATION"]);
            if (dr["URDU_TEXT"] != DBNull.Value)
                Temp.UrduText = Convert.ToString(dr["URDU_TEXT"]);
            if (dr["REMARKS"] != DBNull.Value)
                Temp.Remarks = Convert.ToString(dr["REMARKS"]);
            if (dr["GOVT_BILL_DATE"] != DBNull.Value)
                Temp.GovtBillDate = Convert.ToDateTime(dr["GOVT_BILL_DATE"]);
            if (dr["DISCUSS_DAYS"] != DBNull.Value)
                Temp.DiscussDays = Convert.ToInt32(dr["DISCUSS_DAYS"]);
            if (dr["SNT_REFERENCE"] != DBNull.Value)
                Temp.SntReference = Convert.ToString(dr["SNT_REFERENCE"]);
            if (dr["AND_WHEREAS"] != DBNull.Value)
                Temp.AndWhereas = Convert.ToString(dr["AND_WHEREAS"]);
            if (dr["IS_ENTERED_BY_MEMBER"] != DBNull.Value)
                Temp.IsEnteredByMember = Convert.ToInt32(dr["IS_ENTERED_BY_MEMBER"]);
            if (dr["MINISTER_NOTICE_DATE"] != DBNull.Value)
                Temp.MinisterNoticeDate = Convert.ToDateTime(dr["MINISTER_NOTICE_DATE"]);
            if (dr["PUBLIC_OPINION"] != DBNull.Value)
                Temp.PublicOpinion = Convert.ToString(dr["PUBLIC_OPINION"]);
            if (dr["PRESIDENT_ASSENT_DATE"] != DBNull.Value)
                Temp.PresidentAssentDate = Convert.ToDateTime(dr["PRESIDENT_ASSENT_DATE"]);
            if (dr["LEAVE_GRANTE_DATE"] != DBNull.Value)
                Temp.LeaveGranteDate = Convert.ToDateTime(dr["LEAVE_GRANTE_DATE"]);
            if (dr["AMENDED_CONTENT"] != DBNull.Value)
                Temp.AmendedContent = Convert.ToString(dr["AMENDED_CONTENT"]);
            if (dr["CURRENT_ROLE"] != DBNull.Value)
                Temp.CurrentRole = Convert.ToString(dr["CURRENT_ROLE"]);
            if (dr["IS_ACTIVE"] != DBNull.Value)
                Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
            if (dr["MOTION_DATE"] != DBNull.Value)
                Temp.MotionDate = Convert.ToDateTime(dr["MOTION_DATE"]);
            if (dr["PARTICIPATED_MEMBERS"] != DBNull.Value)
                Temp.ParticipatedMembers = Convert.ToInt32(dr["PARTICIPATED_MEMBERS"]);
            if (dr["SNT_RECOMMENDATION"] != DBNull.Value)
                Temp.SntRecommendation = Convert.ToString(dr["SNT_RECOMMENDATION"]);
            if (dr["BILL_GAZETTED_DATE"] != DBNull.Value)
                Temp.BillGazettedDate = Convert.ToDateTime(dr["BILL_GAZETTED_DATE"]);
            if (dr["NOW_THEREFORE"] != DBNull.Value)
                Temp.NowTherefore = Convert.ToString(dr["NOW_THEREFORE"]);
            if (dr["MED_CMT_REF_DATE"] != DBNull.Value)
                Temp.MedCmtRefDate = Convert.ToDateTime(dr["MED_CMT_REF_DATE"]);
            if (dr["NOTICE_CIRC_DATE"] != DBNull.Value)
                Temp.NoticeCircDate = Convert.ToDateTime(dr["NOTICE_CIRC_DATE"]);
            if (dr["CII_OPINION"] != DBNull.Value)
                Temp.CiiOpinion = Convert.ToString(dr["CII_OPINION"]);
            if (dr["FINANCE_BILL_REFERENCE"] != DBNull.Value)
                Temp.FinanceBillReference = Convert.ToString(dr["FINANCE_BILL_REFERENCE"]);
            if (dr["IS_WITH_MED_COMMITTEE"] != DBNull.Value)
                Temp.IswithSatndingCommitee = Convert.ToInt32(dr["IS_WITH_MED_COMMITTEE"]);
            if (dr["MEM_BILL_SUBJECT"] != DBNull.Value)
                Temp.MemBillSubject = Convert.ToString(dr["MEM_BILL_SUBJECT"]);
            if (dr["NOTICE_DIARY_DATE"] != DBNull.Value)
                Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
            if (dr["BILL_PASSAGE_DATE"] != DBNull.Value)
                Temp.BillPassageDate = Convert.ToDateTime(dr["BILL_PASSAGE_DATE"]);
            if (dr["GOVT_P_MEMBERS"] != DBNull.Value)
                Temp.GovtPMembers = Convert.ToInt32(dr["GOVT_P_MEMBERS"]);
            if (dr["BILL_IDENTIFIER"] != DBNull.Value)
                Temp.BillIdentifier = Convert.ToString(dr["BILL_IDENTIFIER"]);
            if (dr["SEND_TO_NA_DATE"] != DBNull.Value)
                Temp.SentToNaDate = Convert.ToDateTime(dr["SEND_TO_NA_DATE"]);
            if (dr["RECEIVED_FROM_NA_DATE"] != DBNull.Value)
                Temp.ReceivedFromNADate = Convert.ToDateTime(dr["RECEIVED_FROM_NA_DATE"]);

            if (dr["PASSED_BY_NA_DATE"] != DBNull.Value)
                Temp.PassedByNADate = Convert.ToDateTime(dr["PASSED_BY_NA_DATE"]);

            if (dr["NA_REMARKS"] != DBNull.Value)
                Temp.NARemarks = Convert.ToString(dr["NA_REMARKS"]);
            if (dr["WITHDRAWAL_DATE"] != DBNull.Value)
                Temp.WithdrawalDate = Convert.ToDateTime(dr["WITHDRAWAL_DATE"]);
            if (dr["MED_CMT_PRES_DATE"] != DBNull.Value)
                Temp.MedCmtPresDate = Convert.ToDateTime(dr["MED_CMT_PRES_DATE"]);
            if (dr["LAW_DIV_SENT_DATE"] != DBNull.Value)
                Temp.LawDivSentDate = Convert.ToDateTime(dr["LAW_DIV_SENT_DATE"]);
            if (dr["PUBLIC_OPINION_CIRC_DATE"] != DBNull.Value)
                Temp.PublicOpinionCircDate = Convert.ToDateTime(dr["PUBLIC_OPINION_CIRC_DATE"]);
            if (dr["IS_SENT_TO_SENATE"] != DBNull.Value)
                Temp.IsSentToSenate = Convert.ToInt32(dr["IS_SENT_TO_SENATE"]);
            if (dr["SUBJECT"] != DBNull.Value)
                Temp.Subject = Convert.ToString(dr["SUBJECT"]);
            if (dr["MEM_BILL_CONTENT"] != DBNull.Value)
                Temp.MemBillContent = Convert.ToString(dr["MEM_BILL_CONTENT"]);
            if (dr["PRIORITY"] != DBNull.Value)
                Temp.Priority = Convert.ToInt32(dr["PRIORITY"]);
            if (dr["NOTICE_DIARY_NO"] != DBNull.Value)
                Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
            if (dr["BILL_ASSENT_DATE"] != DBNull.Value)
                Temp.BillAssentDate = Convert.ToDateTime(dr["BILL_ASSENT_DATE"]);
            if (dr["OPP_P_MEMBERS"] != DBNull.Value)
                Temp.OppPMembers = Convert.ToInt32(dr["OPP_P_MEMBERS"]);
            if (dr["FILE_NUMBER"] != DBNull.Value)
                Temp.FileNumber = Convert.ToString(dr["FILE_NUMBER"]);
            if (dr["IS_WITH_PRESIDENT"] != DBNull.Value)
                Temp.IsWithPresident = Convert.ToInt32(dr["IS_WITH_PRESIDENT"]);
            if (dr["FIRST_READING_DATE"] != DBNull.Value)
                Temp.FirstReadingDate = Convert.ToDateTime(dr["FIRST_READING_DATE"]);
            if (dr["AGREED_BILL_CONS_DATE"] != DBNull.Value)
                Temp.AgreedBillConsDate = Convert.ToDateTime(dr["AGREED_BILL_CONS_DATE"]);
            if (dr["LAW_DIV_REC_DATE"] != DBNull.Value)
                Temp.LawDivRecDate = Convert.ToDateTime(dr["LAW_DIV_REC_DATE"]);
            if (dr["PUBLIC_OPINION_DATE"] != DBNull.Value)
                Temp.PublicOpinionDate = Convert.ToDateTime(dr["PUBLIC_OPINION_DATE"]);
            if (dr["IS_SENT_TO_COMMITTEE"] != DBNull.Value)
                Temp.IsSentToCommittee = Convert.ToInt32(dr["IS_SENT_TO_COMMITTEE"]);
            if (dr["REJECT_AMEND_DATE"] != DBNull.Value)
                Temp.RejectAmendDate = Convert.ToDateTime(dr["REJECT_AMEND_DATE"]);
            if (dr["NOTICE_DIARY_TIME"] != DBNull.Value)
                Temp.NoticeDiaryTime = Convert.ToDateTime(dr["NOTICE_DIARY_TIME"]);
            if (dr["IS_WITH_STANDING_COMMITTEE"] != DBNull.Value)
                Temp.IswithSatndingCommitee = Convert.ToInt32(dr["IS_WITH_STANDING_COMMITTEE"]);
            if (dr["SNT_REC_DATE"] != DBNull.Value)
                Temp.SntRecDate = Convert.ToDateTime(dr["SNT_REC_DATE"]);
            if (dr["PASSED_AS_REPT_BY_SC"] != DBNull.Value)
                Temp.PassedAsReptBySc = Convert.ToString(dr["PASSED_AS_REPT_BY_SC"]);
            if (dr["SEND_TO_PRESIDENT_DATE"] != DBNull.Value)
                Temp.SendToPresidentDate = Convert.ToDateTime(dr["SEND_TO_PRESIDENT_DATE"]);
            if (dr["AGREED_BILL_PASS_DATE"] != DBNull.Value)
                Temp.AgreedBillPassDate = Convert.ToDateTime(dr["AGREED_BILL_PASS_DATE"]);
            if (dr["OTHER_HOUSE_INTIMATE_DATE"] != DBNull.Value)
                Temp.OtherHouseIntimateDate = Convert.ToDateTime(dr["OTHER_HOUSE_INTIMATE_DATE"]);
            if (dr["CII_REFER_DATE"] != DBNull.Value)
                Temp.CiiOpinion = Convert.ToString(dr["CII_REFER_DATE"]);
            if (dr["IS_LEAVE_GRANTE"] != DBNull.Value)
                Temp.IsLeaveGranted = Convert.ToInt32(dr["IS_LEAVE_GRANTE"]);
            if (dr["LETTER"] != DBNull.Value)
                Temp.Letter = Convert.ToString(dr["LETTER"]);
            if (dr["BILL_DATE"] != DBNull.Value)
                Temp.BillDate = Convert.ToDateTime(dr["BILL_DATE"]);
            if (dr["LEGISLATION_DIARY_NO"] != DBNull.Value)
                Temp.LegislationDiaryNo = Convert.ToString(dr["LEGISLATION_DIARY_NO"]);
            if (dr["SNT_REC_TIME"] != DBNull.Value)
                Temp.SntRecTime = Convert.ToDateTime(dr["SNT_REC_TIME"]);
            if (dr["PASSED_WO_ST_CMT"] != DBNull.Value)
                Temp.PassedWoStCmt = Convert.ToString(dr["PASSED_WO_ST_CMT"]);
            if (dr["NOTING"] != DBNull.Value)
                Temp.Noting = Convert.ToString(dr["NOTING"]);
            if (dr["BILL_TIME"] != DBNull.Value)
                Temp.BillTime = Convert.ToDateTime(dr["BILL_TIME"]);
            if (dr["BILL_FILE"] != DBNull.Value)
                Temp.BillFile = Convert.ToString(dr["BILL_FILE"]);
            if (dr["NOTICE_FILE"] != DBNull.Value)
                Temp.NoticeFile = Convert.ToString(dr["NOTICE_FILE"]);
            if (dr["BILL_INTRODUCE_DATE"] != DBNull.Value)
                Temp.IntroducedInHouseOn = Convert.ToDateTime(dr["BILL_INTRODUCE_DATE"]);
            if (dr["COMMITTEE_ID"] != DBNull.Value)
                Temp.CommitteeId = Convert.ToInt32(dr["COMMITTEE_ID"]);
            if (dr["COMMITTEE_DAYS_LIMIT"] != DBNull.Value)
                Temp.CommitteeTimeLimit = Convert.ToInt32(dr["COMMITTEE_DAYS_LIMIT"]); 
                  if (dr["COMMITTEE_RECOMMENDATION_ID"] != DBNull.Value)
                Temp.CommitteeRecommendationId = Convert.ToInt32(dr["COMMITTEE_RECOMMENDATION_ID"]);
            if (dr["COMMITTEE_NAME"] != DBNull.Value)
                Temp.CommitteeName = Convert.ToString(dr["COMMITTEE_NAME"]);
            if (dr["COMMITTEE_REF_DATE"] != DBNull.Value)
                Temp.CommitteeRefDate = Convert.ToDateTime(dr["COMMITTEE_REF_DATE"]);
            if (dr["COMMITTEE_REMARKS"] != DBNull.Value)
                Temp.CommitteeRemarks = Convert.ToString(dr["COMMITTEE_REMARKS"]);
            if (dr["COMMITTEE_REPORT_FILE"] != DBNull.Value)
                Temp.CommitteeReportFile = Convert.ToString(dr["COMMITTEE_REPORT_FILE"]);
            if (dr["COMMITTEE_REPORT_DATE"] != DBNull.Value)
                Temp.CommitteeReportDate = Convert.ToDateTime(dr["COMMITTEE_REPORT_DATE"]);
            if (dr["MEMBERS"] != DBNull.Value)
                Temp.MembersCSV = Convert.ToString(dr["MEMBERS"]);
            if (dr["MINISTERS"] != DBNull.Value)
                Temp.MinistersCSV = Convert.ToString(dr["MINISTERS"]);
            if (dr["DIVISIONS"] != DBNull.Value)
                Temp.DivisionsCSV = Convert.ToString(dr["DIVISIONS"]);

            if (dr["MEMBER_WITHDRAWAL_STATUS_ID"] != DBNull.Value)
                Temp.MemberWithdrawStatusId = Convert.ToInt32(dr["MEMBER_WITHDRAWAL_STATUS_ID"]);
            if (dr["CONSIDERATION_SESSION_ID"] != DBNull.Value)
                Temp.ConsiderationSessionId = Convert.ToInt32(dr["CONSIDERATION_SESSION_ID"]);

            if (dr["MEMBER_WITHDRAWAL_STATUS_DATE"] != DBNull.Value)
                Temp.MemberWithdrawStatusDate = Convert.ToDateTime(dr["MEMBER_WITHDRAWAL_STATUS_DATE"]);
            if (dr["HOUSE_FOR_CONSIDERATION_DATE"] != DBNull.Value)
                Temp.HouseForConsiderationDate = Convert.ToDateTime(dr["HOUSE_FOR_CONSIDERATION_DATE"]);
            if (dr["MEMBER_REMARKS"] != DBNull.Value)
                Temp.MemberRemarks = Convert.ToString(dr["MEMBER_REMARKS"]);


            if (dr["UPDATED_BY"] != DBNull.Value)
                Temp.UpdatedBy = Convert.ToInt32(dr["UPDATED_BY"]);
            if (dr["UPDATED_ON"] != DBNull.Value)
                Temp.UpdatedOn = Convert.ToDateTime(dr["UPDATED_ON"]);
            if (dr["INSERTED_BY"] != DBNull.Value)
                Temp.InsertedBy = Convert.ToInt32(dr["INSERTED_BY"]);
            if (dr["INSERTED_ON"] != DBNull.Value)
                Temp.InsertedOn = Convert.ToDateTime(dr["INSERTED_ON"]);
            if (dr["DELETED_BY"] != DBNull.Value)
                Temp.DeletedBy = Convert.ToInt32(dr["DELETED_BY"]);
            if (dr["DELETED_ON"] != DBNull.Value)
                Temp.DeletedOn = Convert.ToDateTime(dr["DELETED_ON"]);
            if (dr["RECOVERED_BY"] != DBNull.Value)
                Temp.RecoveredBy = Convert.ToInt32(dr["RECOVERED_BY"]);
            if (dr["RECOVERED_ON"] != DBNull.Value)
                Temp.RecoveredOn = Convert.ToDateTime(dr["RECOVERED_ON"]);
            Temp.BillMovers = new List<BillMovers>();
            Temp.BillMovers = GetBillMovers(Temp.BillsId);
            Temp.MoverNames = GetBillMoverNames(Temp.BillMovers);
            Temp.BillMinisters = new List<BillMinisters>();
            Temp.BillMinisters = GetBillMinisters(Temp.BillsId);
            Temp.MinisterNames = GetBillMinisterNames(Temp.BillMinisters);
            Temp.BillDivisions = new List<BillDivisions>();
            Temp.BillDivisions = GetBillDivisions(Temp.BillsId);
            Temp.DivisionNames = GetBillDivisionNames(Temp.BillDivisions);
            return Temp;
        }
        protected string GetBillMoverNames(List<BillMovers> billMovers)
        {
            string movers = "";
            if (billMovers != null)
            {
                foreach (BillMovers mover in billMovers)
                {
                    movers += mover.Mover + ", ";
                }

            }
            return movers;
        }
        protected string GetBillMinisterNames(List<BillMinisters> billMinisters)
        {
            string movers = "";
            if (billMinisters != null)
            {
                foreach (BillMinisters mover in billMinisters)
                {
                    movers += mover.MinisterName + ", ";
                }

            }
            return movers;
        }
        protected string GetBillDivisionNames(List<BillDivisions> billDivisions)
        {
            string movers = "";
            if (billDivisions != null)
            {
                foreach (BillDivisions mover in billDivisions)
                {
                    movers += mover.Division + ", ";
                }

            }
            return movers;
        }

        public string GetMemberNameById(int MemberId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBER_NAME_BY_ID";
                cmd.Parameters.Add("@MemberId", SqlDbType.Int).Value = MemberId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                string MemberName = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    MemberName = Convert.ToString(dr["SENATOR_NAME"]);

                }
                return MemberName;
            }
            finally
            {
                con.Close();

            }
        }
        public string GetMinistryNameById(int MinistryId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_DIVISION_BY_ID";
                cmd.Parameters.Add("@DivisionsId", SqlDbType.Int).Value = MinistryId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                string MinistryName = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    MinistryName = Convert.ToString(dr["DESCRIPTION"]);

                }
                return MinistryName;
            }
            finally
            {
                con.Close();

            }
        }

        #region BILLS
        public Bills GetBill(int BillsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            using (con)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILL";
                    cmd.Parameters.Add("@BillsId", SqlDbType.VarChar).Value = BillsId;
                    cmd.CommandType = CommandType.StoredProcedure;
                    Bills Temp = new Bills();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {

                        dr.Read();
                        Temp = BindFields(dr);
                    }
                    return Temp;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
           
        }
        public Bills GetNoticeBill(int BillsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            using (con)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_NOTICE_BILL";
                    cmd.Parameters.Add("@BillsId", SqlDbType.VarChar).Value = BillsId;
                    cmd.CommandType = CommandType.StoredProcedure;
                    Bills Temp = new Bills();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {

                        dr.Read();
                        Temp = BindFields(dr);
                    }
                    return Temp;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }

        }

        public List<Bills> GetBills(int parliamentaryYearsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            using (con)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILLS";
                    cmd.Parameters.Add("@ParliamentaryYearsId", SqlDbType.VarChar).Value = parliamentaryYearsId;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Bills> Bills = null;
                    if (dr.HasRows)
                    {
                        Bills = new List<Bills>();
                        while (dr.Read())
                        {
                            Bills Temp = BindFields(dr);
                            Bills.Add(Temp);
                        }

                    }
                    return Bills;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

            }
        }
        public List<Bills> GetBillsByStatus(int StatusId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            using (con)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILLS_BY_STATUS";
                    cmd.Parameters.Add("@BillStatusId", SqlDbType.Int).Value =StatusId;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Bills> Bills = null;
                    if (dr.HasRows)
                    {
                        Bills = new List<Bills>();
                        while (dr.Read())
                        {
                            Bills Temp = BindFields(dr);
                            Bills.Add(Temp);
                        }

                    }
                    return Bills;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

            }
        }
        
        public List<Bills> GetBillsByHouse(int ParliamentaryYearsId,int HouseTypesId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            using (con)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILLS_BY_HOUSE";
                    cmd.Parameters.Add("@ParliamentaryYearsId", SqlDbType.VarChar).Value = ParliamentaryYearsId;
                    cmd.Parameters.Add("@HouseTypesId", SqlDbType.VarChar).Value = HouseTypesId;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Bills> Bills = null;
                    if (dr.HasRows)
                    {
                        Bills = new List<Bills>();
                        while (dr.Read())
                        {
                            Bills Temp = BindFields(dr);
                            Bills.Add(Temp);
                        }

                    }
                    return Bills;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

            }
        }

        public List<Bills> SearchBills(string query)
        {
           
                SqlConnection con = new DalHelper().GetConnection();
                try
                {
                    List<Bills> bills = null;
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    using (con)
                    {
                        if (dr.HasRows)
                        {
                            bills = new List<Bills>();
                            while (dr.Read())
                            {
                                Bills Temp = BindFields(dr);
                                bills.Add(Temp);
                            }
                        }

                    }
                    return bills;
                }
                finally
                {
                    con.Close();
                }
            
        }

        #region Senate Bills
 public void InsertBill(Bills bill)
        {
            SqlConnection con = new DalHelper().GetConnection();
            int BillId = new DalHelper().GetPk("BILLS", "BILLS_ID");
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_BILL";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = BillId;
                cmd.Parameters.Add("@BillTypeId", SqlDbType.Int).Value = bill.BillTypeId;
                cmd.Parameters.Add("@BillStatusId", SqlDbType.Int).Value = bill.BillStatusId;
                cmd.Parameters.Add("@StatusDate", SqlDbType.DateTime).Value = bill.StatusDate;
                cmd.Parameters.Add("@BillCategoriesId", SqlDbType.Int).Value = bill.BillCategoryId;
                cmd.Parameters.Add("@BillStagesId", SqlDbType.Int).Value = bill.BillStagesId;
                cmd.Parameters.Add("@HouseTypesId", SqlDbType.Int).Value = bill.HouseTypesId;
                cmd.Parameters.Add("@Subject", SqlDbType.VarChar).Value = bill.Subject;
                cmd.Parameters.Add("@BillTitle", SqlDbType.VarChar).Value = bill.BillTitle;
                cmd.Parameters.Add("@ParliamentaryYearsId", SqlDbType.Int).Value = bill.ParliamentaryYearId;
                //cmd.Parameters.Add("@BillDate", SqlDbType.DateTime).Value = bill.BillDate;
                // cmd.Parameters.Add("@BillTime", SqlDbType.DateTime).Value = bill.BillTime;
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = bill.AssemblySessionsId;
                //cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.VarChar).Value = bill.NoticeDiaryNo;
                cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.DateTime).Value = bill.NoticeDiaryDate;
               // cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = bill.NoticeDiaryTime;
                //cmd.Parameters.Add("@LegislationDiaryNo", SqlDbType.VarChar).Value = bill.LegislationDiaryNo;
                cmd.Parameters.Add("@LegislationDiaryDate", SqlDbType.DateTime).Value = DateTime.Now;
                //cmd.Parameters.Add("@LegislationDiaryTime", SqlDbType.DateTime).Value = bill.LegislationDiaryTime;
                //cmd.Parameters.Add("@ParticipatedMembers", SqlDbType.Int).Value = bill.ParticipatedMembers;
               // cmd.Parameters.Add("@BillIdentifier", SqlDbType.VarChar).Value = bill.BillIdentifier;
                cmd.Parameters.Add("@FileNumber", SqlDbType.VarChar).Value = bill.FileNumber;
                //cmd.Parameters.Add("@BillGazettedDate", SqlDbType.DateTime).Value = bill.BillGazettedDate;
                cmd.Parameters.Add("@BillYear", SqlDbType.Int).Value = bill.BillYear;
                cmd.Parameters.Add("@BillFile", SqlDbType.Int).Value = bill.BillFile;
                cmd.Parameters.Add("@NoticeFile", SqlDbType.Int).Value = bill.NoticeFile;
                // cmd.Parameters.Add("@BillGazettedDate", SqlDbType.DateTime).Value = bill.BillGazettedDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = bill.IsActive;
                cmd.Parameters.Add("@MembersCSV", SqlDbType.VarChar).Value = bill.MembersCSV;
                cmd.Parameters.Add("@MinistersCSV", SqlDbType.VarChar).Value = bill.MinistersCSV;
                cmd.Parameters.Add("@DivisionsSCV", SqlDbType.VarChar).Value = bill.DivisionsCSV;
                cmd.Parameters.Add("@InsertedBy", SqlDbType.Int).Value = bill.InsertedBy;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                InsertBillMovers(bill.BillMovers, BillId);
                InsertBillMinisters(bill.BillMinisters, BillId);
                InsertBillDivisions(bill.Divisions, BillId);
                //return BillId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public void UpdateBill(Bills bill)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {
               
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_BILL";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = bill.BillsId;
                cmd.Parameters.Add("@BillTypeId", SqlDbType.Int).Value = bill.BillTypeId;
                cmd.Parameters.Add("@BillStatusId", SqlDbType.Int).Value = bill.BillStatusId;
                cmd.Parameters.Add("@StatusDate", SqlDbType.DateTime).Value = bill.StatusDate;
                cmd.Parameters.Add("@BillCategoriesId", SqlDbType.Int).Value = bill.BillCategoryId;
                //cmd.Parameters.Add("@BillStagesId", SqlDbType.Int).Value = bill.BillStagesId;
                cmd.Parameters.Add("@HouseTypesId", SqlDbType.Int).Value = bill.HouseTypesId;
                cmd.Parameters.Add("@Subject", SqlDbType.VarChar).Value = bill.Subject;
                cmd.Parameters.Add("@BillTitle", SqlDbType.VarChar).Value = bill.BillTitle;
                cmd.Parameters.Add("@ParliamentaryYearsId", SqlDbType.Int).Value = bill.ParliamentaryYearId;
                //cmd.Parameters.Add("@BillDate", SqlDbType.DateTime).Value = bill.BillDate;
                // cmd.Parameters.Add("@BillTime", SqlDbType.DateTime).Value = bill.BillTime;
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = bill.AssemblySessionsId;
                //cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.VarChar).Value = bill.NoticeDiaryNo;
                cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.DateTime).Value = bill.NoticeDiaryDate;
                // cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = bill.NoticeDiaryTime;
                //cmd.Parameters.Add("@LegislationDiaryNo", SqlDbType.VarChar).Value = bill.LegislationDiaryNo;
                //cmd.Parameters.Add("@LegislationDiaryDate", SqlDbType.DateTime).Value = bill.LegislationDiaryDate;
                //cmd.Parameters.Add("@LegislationDiaryTime", SqlDbType.DateTime).Value = bill.LegislationDiaryTime;
                //cmd.Parameters.Add("@ParticipatedMembers", SqlDbType.Int).Value = bill.ParticipatedMembers;
                // cmd.Parameters.Add("@BillIdentifier", SqlDbType.VarChar).Value = bill.BillIdentifier;
                 cmd.Parameters.Add("@FileNumber", SqlDbType.VarChar).Value = bill.FileNumber;
                //cmd.Parameters.Add("@BillGazettedDate", SqlDbType.DateTime).Value = bill.BillGazettedDate;
                cmd.Parameters.Add("@BillYear", SqlDbType.Int).Value = bill.BillYear;
                // cmd.Parameters.Add("@BillGazettedDate", SqlDbType.DateTime).Value = bill.BillGazettedDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = bill.IsActive;
                cmd.Parameters.Add("@MembersCSV", SqlDbType.VarChar).Value = bill.MembersCSV;
                cmd.Parameters.Add("@MinistersCSV", SqlDbType.VarChar).Value = bill.MinistersCSV;
                cmd.Parameters.Add("@DivisionsSCV", SqlDbType.VarChar).Value = bill.DivisionsCSV;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = bill.Remarks;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = bill.UpdatedBy;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                InsertBillMovers(bill.BillMovers, bill.BillsId);
                InsertBillMinisters(bill.BillMinisters, bill.BillsId);
                InsertBillDivisions(bill.Divisions, bill.BillsId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public int InsertNoticeBill(Bills bill,int NoticeId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            int BillId = new DalHelper().GetPk("BILLS", "BILLS_ID");
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_BILL";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = BillId;
                cmd.Parameters.Add("@BillTypeId", SqlDbType.Int).Value = bill.BillTypeId;
                cmd.Parameters.Add("@BillStatusId", SqlDbType.Int).Value = bill.BillStatusId;
                cmd.Parameters.Add("@StatusDate", SqlDbType.DateTime).Value = bill.StatusDate;
                cmd.Parameters.Add("@BillCategoriesId", SqlDbType.Int).Value = bill.BillCategoryId;
                cmd.Parameters.Add("@BillStagesId", SqlDbType.Int).Value = bill.BillStagesId;
                cmd.Parameters.Add("@HouseTypesId", SqlDbType.Int).Value = bill.HouseTypesId;
                cmd.Parameters.Add("@Subject", SqlDbType.VarChar).Value = bill.Subject;
                cmd.Parameters.Add("@BillTitle", SqlDbType.VarChar).Value = bill.BillTitle;
                cmd.Parameters.Add("@ParliamentaryYearsId", SqlDbType.Int).Value = bill.ParliamentaryYearId;
                //cmd.Parameters.Add("@BillDate", SqlDbType.DateTime).Value = bill.BillDate;
                // cmd.Parameters.Add("@BillTime", SqlDbType.DateTime).Value = bill.BillTime;
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = bill.AssemblySessionsId;
                //cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.VarChar).Value = bill.NoticeDiaryNo;
                cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.DateTime).Value = bill.NoticeDiaryDate;
                // cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = bill.NoticeDiaryTime;
                //cmd.Parameters.Add("@LegislationDiaryNo", SqlDbType.VarChar).Value = bill.LegislationDiaryNo;
                cmd.Parameters.Add("@LegislationDiaryDate", SqlDbType.DateTime).Value = DateTime.Now;
                //cmd.Parameters.Add("@LegislationDiaryTime", SqlDbType.DateTime).Value = bill.LegislationDiaryTime;
                //cmd.Parameters.Add("@ParticipatedMembers", SqlDbType.Int).Value = bill.ParticipatedMembers;
                // cmd.Parameters.Add("@BillIdentifier", SqlDbType.VarChar).Value = bill.BillIdentifier;
                cmd.Parameters.Add("@FileNumber", SqlDbType.VarChar).Value = bill.FileNumber;
                //cmd.Parameters.Add("@BillGazettedDate", SqlDbType.DateTime).Value = bill.BillGazettedDate;
                cmd.Parameters.Add("@BillYear", SqlDbType.Int).Value = bill.BillYear;
                cmd.Parameters.Add("@BillFile", SqlDbType.Int).Value = bill.BillFile;
                cmd.Parameters.Add("@NoticeFile", SqlDbType.Int).Value = bill.NoticeFile;
                // cmd.Parameters.Add("@BillGazettedDate", SqlDbType.DateTime).Value = bill.BillGazettedDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = bill.IsActive;
                cmd.Parameters.Add("@MembersCSV", SqlDbType.VarChar).Value = bill.MembersCSV;
                cmd.Parameters.Add("@MinistersCSV", SqlDbType.VarChar).Value = bill.MinistersCSV;
                cmd.Parameters.Add("@DivisionsSCV", SqlDbType.VarChar).Value = bill.DivisionsCSV;
                cmd.Parameters.Add("@InsertedBy", SqlDbType.Int).Value = bill.InsertedBy;
                if (!string.IsNullOrEmpty(bill.NoticeFile))
                {
                    BillDocumentsEnt billDocumentsEnt = new BillDocumentsEnt();
                    billDocumentsEnt.BillId = BillId;
                    billDocumentsEnt.AttachmentDate = bill.NoticeDiaryDate;
                    billDocumentsEnt.DocumentTypeId = 3;
                    billDocumentsEnt.DocumentDescription = "Notice";
                    billDocumentsEnt.Url = bill.NoticeFile;
                    InsertBillDocument(billDocumentsEnt);
                }
                if (!string.IsNullOrEmpty(bill.BillFile))
                {
                    BillDocumentsEnt billDocumentsEnt = new BillDocumentsEnt();
                    billDocumentsEnt.BillId = BillId;
                    billDocumentsEnt.AttachmentDate = bill.NoticeDiaryDate;
                    billDocumentsEnt.DocumentTypeId = 2;
                    billDocumentsEnt.DocumentDescription = "Bill";
                    billDocumentsEnt.Url = bill.BillFile;
                    InsertBillDocument(billDocumentsEnt);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                InsertBillMovers(bill.MembersCSV, BillId);
                ProcessNoticeBill(NoticeId);
                //InsertBillMinisters(bill.BillMinisters, BillId);
                //InsertBillDivisions(bill.Divisions, BillId);
                return BillId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public void InsertBillMovers(string Movers,int BillId)
        {
            List<int> ids = Movers.Trim(',')?
                .Split(',')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => int.Parse(x.Trim()))
                .ToList() ?? new List<int>();
            List<BillMovers> billMovers = new List<BillMovers>();
            foreach(int var in ids)
            {
                BillMovers mover = new BillMovers();
                mover.SystemUsersId = var;
                billMovers.Add(mover);
            }
            InsertBillMovers(billMovers, BillId);
        }
        public void ProcessNoticeBill(int NoticeId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "PROCESS_NOTICE_BILL";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = NoticeId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateNABill(Bills bill)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_NA_BILL";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = bill.BillsId;
                cmd.Parameters.Add("@BillTypeId", SqlDbType.Int).Value = bill.BillTypeId;
                cmd.Parameters.Add("@BillStatusId", SqlDbType.Int).Value = bill.BillStatusId;
                cmd.Parameters.Add("@StatusDate", SqlDbType.DateTime).Value = bill.StatusDate;
                cmd.Parameters.Add("@BillCategoriesId", SqlDbType.Int).Value = bill.BillCategoryId;
                //cmd.Parameters.Add("@BillStagesId", SqlDbType.Int).Value = bill.BillStagesId;
                cmd.Parameters.Add("@HouseTypesId", SqlDbType.Int).Value = bill.HouseTypesId;
                cmd.Parameters.Add("@Subject", SqlDbType.VarChar).Value = bill.Subject;
                cmd.Parameters.Add("@BillTitle", SqlDbType.VarChar).Value = bill.BillTitle;
                cmd.Parameters.Add("@ParliamentaryYearsId", SqlDbType.Int).Value = bill.ParliamentaryYearId;
                //cmd.Parameters.Add("@BillDate", SqlDbType.DateTime).Value = bill.BillDate;
                // cmd.Parameters.Add("@BillTime", SqlDbType.DateTime).Value = bill.BillTime;
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = bill.AssemblySessionsId;
                //cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.VarChar).Value = bill.NoticeDiaryNo;
                if(bill.NoticeDiaryDate>Convert.ToDateTime("01/01/1900"))
                cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.DateTime).Value = bill.NoticeDiaryDate;
                else
                    cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.DateTime).Value = DBNull.Value;

                cmd.Parameters.Add("@PassedByNADate", SqlDbType.DateTime).Value = bill.PassedByNADate;
                cmd.Parameters.Add("@ReceivedFromNADate", SqlDbType.DateTime).Value = bill.ReceivedFromNADate;
                cmd.Parameters.Add("@BillCirculationDate", SqlDbType.DateTime).Value = bill.BillCircDate;
                if (bill.NoticeCircDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@NoticeCircDate", SqlDbType.DateTime).Value = bill.NoticeCircDate;
                else
                    cmd.Parameters.Add("@NoticeCircDate", SqlDbType.DateTime).Value = DBNull.Value;

                // cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = bill.NoticeDiaryTime;
                //cmd.Parameters.Add("@LegislationDiaryNo", SqlDbType.VarChar).Value = bill.LegislationDiaryNo;
                //cmd.Parameters.Add("@LegislationDiaryDate", SqlDbType.DateTime).Value = bill.LegislationDiaryDate;
                //cmd.Parameters.Add("@LegislationDiaryTime", SqlDbType.DateTime).Value = bill.LegislationDiaryTime;
                //cmd.Parameters.Add("@ParticipatedMembers", SqlDbType.Int).Value = bill.ParticipatedMembers;
                // cmd.Parameters.Add("@BillIdentifier", SqlDbType.VarChar).Value = bill.BillIdentifier;
                cmd.Parameters.Add("@FileNumber", SqlDbType.VarChar).Value = bill.FileNumber;
                //cmd.Parameters.Add("@BillGazettedDate", SqlDbType.DateTime).Value = bill.BillGazettedDate;
                cmd.Parameters.Add("@BillYear", SqlDbType.Int).Value = bill.BillYear;
                // cmd.Parameters.Add("@BillGazettedDate", SqlDbType.DateTime).Value = bill.BillGazettedDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = bill.IsActive;
                cmd.Parameters.Add("@MembersCSV", SqlDbType.VarChar).Value = bill.MembersCSV;
                cmd.Parameters.Add("@MinistersCSV", SqlDbType.VarChar).Value = bill.MinistersCSV;
                cmd.Parameters.Add("@DivisionsSCV", SqlDbType.VarChar).Value = bill.DivisionsCSV;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = bill.Remarks;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = bill.UpdatedBy;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                InsertBillMovers(bill.BillMovers, bill.BillsId);
                InsertBillMinisters(bill.BillMinisters, bill.BillsId);
                InsertBillDivisions(bill.Divisions, bill.BillsId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public void UpdateCommitteeDetails(Bills bill)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_COMMITTEE_DETAILS";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = bill.BillsId;
                if (bill.IntroducedInHouseOn > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@BillIntroduceDate", SqlDbType.DateTime).Value = bill.IntroducedInHouseOn;
                else
                    cmd.Parameters.Add("@BillIntroduceDate", SqlDbType.DateTime).Value = DBNull.Value;
                if (bill.CommitteeRefDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@CommitteeRefferdDate", SqlDbType.DateTime).Value = bill.CommitteeRefDate; 
                else
                    cmd.Parameters.Add("@CommitteeRefferdDate", SqlDbType.DateTime).Value = DBNull.Value;

                if (bill.CommitteeReportDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@CommitteeReportDate", SqlDbType.DateTime).Value = bill.CommitteeReportDate;
                else
                    cmd.Parameters.Add("@CommitteeReportDate", SqlDbType.DateTime).Value = DBNull.Value;
                cmd.Parameters.Add("@CommitteesId", SqlDbType.Int).Value = bill.CommitteeId;
                cmd.Parameters.Add("@CommitteeDaysLimit", SqlDbType.Int).Value = bill.CommitteeTimeLimit;
                //cmd.Parameters.Add("@CommitteeRefferdDate", SqlDbType.DateTime).Value = bill.StatusDate;
                cmd.Parameters.Add("@CommitteeRecommendationId", SqlDbType.Int).Value = bill.CommitteeRecommendationId;
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = bill.AssemblySessionsId;
                cmd.Parameters.Add("@IsSentToCommittee", SqlDbType.Int).Value = bill.IsSentToCommittee;

                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = bill.CommitteeRemarks;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = bill.UpdatedBy;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateNADetails(Bills bill)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_NA_DETAILS";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = bill.BillsId;
                if (bill.BillPassageDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@BillPassageDate", SqlDbType.DateTime).Value = bill.BillPassageDate;
                if (bill.SentToNaDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@SentToNADate", SqlDbType.DateTime).Value = bill.SentToNaDate;
                if (bill.ReceivedFromNADate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@ReceivedFromNADate", SqlDbType.DateTime).Value = bill.ReceivedFromNADate;
                if (bill.PassedByNADate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@PassedByNADate", SqlDbType.DateTime).Value = bill.PassedByNADate;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = bill.NARemarks;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = bill.UpdatedBy;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public void UpdateNABillNADetails(Bills bill)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_NA_BILL_NA_DETAILS";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = bill.BillsId;
                if (bill.BillPassageDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@BillPassageDate", SqlDbType.DateTime).Value = bill.BillPassageDate;
                if (bill.SentToNaDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@SentToNADate", SqlDbType.DateTime).Value = bill.SentToNaDate;
                if (bill.PresidentAssentDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@PresidentAssentDate", SqlDbType.DateTime).Value = bill.PresidentAssentDate;
                if (bill.ActGazettePubDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@ActGazettePubDate", SqlDbType.DateTime).Value = bill.ActGazettePubDate;
                //cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = bill.NARemarks;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = bill.UpdatedBy;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateBillMemberDetails(Bills bill)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_BILL_MEMBER_DETAILS";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = bill.BillsId;
                cmd.Parameters.Add("@MemberWithdrawStatusId", SqlDbType.Int).Value = bill.MemberWithdrawStatusId;
                if (bill.MemberWithdrawStatusDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@MemberWithdrawStatusDate", SqlDbType.DateTime).Value = bill.MemberWithdrawStatusDate;
                if (bill.HouseForConsiderationDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@HouseForConsiderationDate", SqlDbType.DateTime).Value = bill.HouseForConsiderationDate;
                cmd.Parameters.Add("@ConsiderationSessionId", SqlDbType.Int).Value = bill.ConsiderationSessionId;
                cmd.Parameters.Add("@MemberRemarks", SqlDbType.VarChar).Value = bill.MemberRemarks;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = bill.UpdatedBy;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Senate Bills
        public void InsertNABill(Bills bill)
        {
            SqlConnection con = new DalHelper().GetConnection();
            int BillId = new DalHelper().GetPk("BILLS", "BILLS_ID");

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_NA_BILL";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = BillId;
                cmd.Parameters.Add("@BillTypeId", SqlDbType.Int).Value = bill.BillTypeId;
                cmd.Parameters.Add("@BillStatusId", SqlDbType.Int).Value = bill.BillStatusId;
                cmd.Parameters.Add("@StatusDate", SqlDbType.DateTime).Value = bill.StatusDate;
                cmd.Parameters.Add("@BillCategoriesId", SqlDbType.Int).Value = bill.BillCategoryId;
                cmd.Parameters.Add("@BillStagesId", SqlDbType.Int).Value = bill.BillStagesId;
                cmd.Parameters.Add("@HouseTypesId", SqlDbType.Int).Value = bill.HouseTypesId;
                cmd.Parameters.Add("@Subject", SqlDbType.VarChar).Value = bill.Subject;
                cmd.Parameters.Add("@BillTitle", SqlDbType.VarChar).Value = bill.BillTitle;
                cmd.Parameters.Add("@ParliamentaryYearsId", SqlDbType.Int).Value = bill.ParliamentaryYearId;
                //cmd.Parameters.Add("@BillDate", SqlDbType.DateTime).Value = bill.BillDate;
                // cmd.Parameters.Add("@BillTime", SqlDbType.DateTime).Value = bill.BillTime;
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = bill.AssemblySessionsId;
                //cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.VarChar).Value = bill.NoticeDiaryNo;
                cmd.Parameters.Add("@PassedByNADate", SqlDbType.DateTime).Value = bill.PassedByNADate;
                cmd.Parameters.Add("@ReceivedFromNADate", SqlDbType.DateTime).Value = bill.ReceivedFromNADate;
                // cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = bill.NoticeDiaryTime;
                //cmd.Parameters.Add("@LegislationDiaryNo", SqlDbType.VarChar).Value = bill.LegislationDiaryNo;
                // cmd.Parameters.Add("@LegislationDiaryDate", SqlDbType.DateTime).Value = DateTime.Now;
                //cmd.Parameters.Add("@LegislationDiaryTime", SqlDbType.DateTime).Value = bill.LegislationDiaryTime;
                //cmd.Parameters.Add("@ParticipatedMembers", SqlDbType.Int).Value = bill.ParticipatedMembers;
                // cmd.Parameters.Add("@BillIdentifier", SqlDbType.VarChar).Value = bill.BillIdentifier;
                cmd.Parameters.Add("@FileNumber", SqlDbType.VarChar).Value = bill.FileNumber;
                //cmd.Parameters.Add("@BillGazettedDate", SqlDbType.DateTime).Value = bill.BillGazettedDate;
                cmd.Parameters.Add("@BillYear", SqlDbType.Int).Value = bill.BillYear;
               // cmd.Parameters.Add("@BillFile", SqlDbType.Int).Value = bill.BillFile;
               // cmd.Parameters.Add("@NoticeFile", SqlDbType.Int).Value = bill.NoticeFile;
                // cmd.Parameters.Add("@BillGazettedDate", SqlDbType.DateTime).Value = bill.BillGazettedDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = bill.IsActive;
                cmd.Parameters.Add("@MembersCSV", SqlDbType.VarChar).Value = bill.MembersCSV;
                cmd.Parameters.Add("@MinistersCSV", SqlDbType.VarChar).Value = bill.MinistersCSV;
                cmd.Parameters.Add("@DivisionsSCV", SqlDbType.VarChar).Value = bill.DivisionsCSV;
                cmd.Parameters.Add("@InsertedBy", SqlDbType.Int).Value = bill.InsertedBy;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                InsertBillMovers(bill.BillMovers, BillId);
                InsertBillMinisters(bill.BillMinisters, BillId);
                InsertBillDivisions(bill.Divisions, BillId);
                //return BillId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        //public void UpdateNABill(Bills bill)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();

        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_BILL";
        //        cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = bill.BillsId;
        //        cmd.Parameters.Add("@BillTypeId", SqlDbType.Int).Value = bill.BillTypeId;
        //        cmd.Parameters.Add("@BillStatusId", SqlDbType.Int).Value = bill.BillStatusId;
        //        cmd.Parameters.Add("@StatusDate", SqlDbType.DateTime).Value = bill.StatusDate;
        //        cmd.Parameters.Add("@BillCategoriesId", SqlDbType.Int).Value = bill.BillCategoryId;
        //        cmd.Parameters.Add("@BillStagesId", SqlDbType.Int).Value = bill.BillStagesId;
        //        cmd.Parameters.Add("@HouseTypesId", SqlDbType.Int).Value = bill.HouseTypesId;
        //        cmd.Parameters.Add("@Subject", SqlDbType.VarChar).Value = bill.Subject;
        //        cmd.Parameters.Add("@BillTitle", SqlDbType.VarChar).Value = bill.BillTitle;
        //        cmd.Parameters.Add("@ParliamentaryYearId", SqlDbType.Int).Value = bill.ParliamentaryYearId;
        //        //cmd.Parameters.Add("@BillDate", SqlDbType.DateTime).Value = bill.BillDate;
        //        // cmd.Parameters.Add("@BillTime", SqlDbType.DateTime).Value = bill.BillTime;
        //        cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = bill.AssemblySessionsId;
        //        //cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.VarChar).Value = bill.NoticeDiaryNo;
        //        cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.DateTime).Value = bill.NoticeDiaryDate;
        //        // cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = bill.NoticeDiaryTime;
        //        //cmd.Parameters.Add("@LegislationDiaryNo", SqlDbType.VarChar).Value = bill.LegislationDiaryNo;
        //        //cmd.Parameters.Add("@LegislationDiaryDate", SqlDbType.DateTime).Value = bill.LegislationDiaryDate;
        //        //cmd.Parameters.Add("@LegislationDiaryTime", SqlDbType.DateTime).Value = bill.LegislationDiaryTime;
        //        //cmd.Parameters.Add("@ParticipatedMembers", SqlDbType.Int).Value = bill.ParticipatedMembers;
        //        // cmd.Parameters.Add("@BillIdentifier", SqlDbType.VarChar).Value = bill.BillIdentifier;
        //        cmd.Parameters.Add("@FileNumber", SqlDbType.VarChar).Value = bill.FileNumber;
        //        //cmd.Parameters.Add("@BillGazettedDate", SqlDbType.DateTime).Value = bill.BillGazettedDate;
        //        cmd.Parameters.Add("@BillYear", SqlDbType.Int).Value = bill.BillYear;
        //        // cmd.Parameters.Add("@BillGazettedDate", SqlDbType.DateTime).Value = bill.BillGazettedDate;
        //        cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = bill.IsActive;
        //        cmd.Parameters.Add("@MembersCSV", SqlDbType.VarChar).Value = bill.MembersCSV;
        //        cmd.Parameters.Add("@MinistersCSV", SqlDbType.VarChar).Value = bill.MinistersCSV;
        //        cmd.Parameters.Add("@DivisionsSCV", SqlDbType.VarChar).Value = bill.DivisionsCSV;
        //        cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = bill.Remarks;
        //        cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = bill.UpdatedBy;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        InsertBillMovers(bill.BillMovers, bill.BillsId);
        //        InsertBillMinisters(bill.BillMinisters, bill.BillsId);
        //        InsertBillDivisions(bill.Divisions, bill.BillsId);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}


        public void UpdateNACommitteeDetails(Bills bill)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_COMMITTEE_DETAILS";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = bill.BillsId;
                if (bill.IntroducedInHouseOn > Convert.ToDateTime("01/01/1900"))
                {
                    cmd.Parameters.Add("@BillIntroduceDate", SqlDbType.DateTime).Value = bill.IntroducedInHouseOn;
                    cmd.Parameters.Add("@CommitteeRefferdDate", SqlDbType.DateTime).Value = bill.IntroducedInHouseOn; //As Both Dates are same
                }
                if (bill.CommitteeReportDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@CommitteeReportDate", SqlDbType.DateTime).Value = bill.CommitteeReportDate;
                cmd.Parameters.Add("@CommitteesId", SqlDbType.Int).Value = bill.CommitteeId;
                cmd.Parameters.Add("@CommitteeDaysLimit", SqlDbType.Int).Value = bill.CommitteeTimeLimit;
                //cmd.Parameters.Add("@CommitteeRefferdDate", SqlDbType.DateTime).Value = bill.StatusDate;
                cmd.Parameters.Add("@CommitteeRecommendationId", SqlDbType.Int).Value = bill.CommitteeRecommendationId;
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = bill.AssemblySessionsId;
                cmd.Parameters.Add("@IsSentToCommittee", SqlDbType.Int).Value = bill.IsSentToCommittee;

                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = bill.CommitteeRemarks;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = bill.UpdatedBy;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateNABillMemberDetails(Bills bill)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_BILL_MEMBER_DETAILS";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = bill.BillsId;
                cmd.Parameters.Add("@MemberWithdrawStatusId", SqlDbType.Int).Value = bill.MemberWithdrawStatusId;
                if (bill.MemberWithdrawStatusDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@MemberWithdrawStatusDate", SqlDbType.DateTime).Value = bill.MemberWithdrawStatusDate;
                if (bill.HouseForConsiderationDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@HouseForConsiderationDate", SqlDbType.DateTime).Value = bill.HouseForConsiderationDate;
                cmd.Parameters.Add("@ConsiderationSessionId", SqlDbType.Int).Value = bill.ConsiderationSessionId;
                cmd.Parameters.Add("@MemberRemarks", SqlDbType.VarChar).Value = bill.MemberRemarks;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = bill.UpdatedBy;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        protected void DeleteBillMovers(int BillId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_BILL_MOVERS";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = BillId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }
        protected List<BillMovers> GetBillMovers(int BillId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILL_MOVERS";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = BillId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                List<BillMovers> billMovers = null;

                if (dr.HasRows)
                {
                    billMovers = new List<BillMovers>();
                    while (dr.Read())
                    {
                        BillMovers Temp = new BillMovers();
                        Temp.BillMoversId = Convert.ToInt32(dr["BILL_MOVERS_ID"]);
                        Temp.BillsId= Convert.ToInt32(dr["BILLS_ID"]);
                        Temp.SystemUsersId= Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        Temp.Mover = Convert.ToString(dr["MOVER_NAME"]);
                        billMovers.Add(Temp);
                    }
                }
                return billMovers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }
       
        protected List<BillDivisions> GetBillDivisions(int BillId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILL_DIVISIONS";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = BillId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                List<BillDivisions> BillDivisions = null;

                if (dr.HasRows)
                {
                    BillDivisions = new List<BillDivisions>();
                    while (dr.Read())
                    {
                        BillDivisions Temp = new BillDivisions();
                        Temp.BillDivisionsId = Convert.ToInt32(dr["BILL_DIVISIONS_ID"]);
                        Temp.BillsId = Convert.ToInt32(dr["BILLS_ID"]);
                        Temp.DivisionsId = Convert.ToInt32(dr["DIVISION_ID"]);
                        Temp.Division = Convert.ToString(dr["DIVISION"]);
                        BillDivisions.Add(Temp);
                    }
                }
                return BillDivisions;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        protected void InsertBillMovers(List<BillMovers> billMovers, int BillId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            string query = "";
            try {
                using (con)
                {
                    if (billMovers != null)
                    {
                        if (billMovers.Count > 0)
                        {
                            DeleteBillMovers(BillId);
                            foreach (BillMovers billmovers in billMovers)
                            {
                                query += "INSERT INTO BILL_MOVERS (BILLS_ID,SYSTEM_USERS_ID) VALUES(" + BillId + "," + billmovers.SystemUsersId + ");";

                            }
                            SqlCommand cmd = new SqlCommand(query, con);
                            SqlDataReader dr = cmd.ExecuteReader();
                        }
                    }
                    }
                  
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
       
        protected void DeleteBillDivisions(int BillId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_BILL_DIVISIONS";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = BillId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
      
        protected void InsertBillDivisions(List<Divisions> divisions, int BillId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            string query = "";
            try
            {
                using (con)
                {
                    if (divisions != null)
                    {
                        if (divisions.Count > 0)
                        {
                            DeleteBillDivisions(BillId);
                            foreach (Divisions billdivisions in divisions)
                            {
                                query += "INSERT INTO BILL_DIVISIONS (BILLS_ID,DIVISION_ID) VALUES(" + BillId + "," + billdivisions.DivisionsId + ");";

                            }
                            SqlCommand cmd = new SqlCommand(query, con);
                            SqlDataReader dr = cmd.ExecuteReader();
                        }
                    }
                  
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        #region Bill Ministers
        public List<BillMinisters> GetBillMinisters(int BillId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILL_MINISTERS";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = BillId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                List<BillMinisters> billMovers = null;

                if (dr.HasRows)
                {
                    billMovers = new List<BillMinisters>();
                    while (dr.Read())
                    {
                        BillMinisters Temp = new BillMinisters();
                        Temp.BillMinistersId = Convert.ToInt32(dr["BILL_MINISTER_ID"]);
                        Temp.BillsId = Convert.ToInt32(dr["BILL_ID"]);
                        Temp.MinisterId = Convert.ToInt32(dr["MINISTERS_ID"]);
                        Temp.MinisterName = Convert.ToString(dr["MINISTER_NAME"]);
                        billMovers.Add(Temp);
                    }
                }
                return billMovers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public void InsertBillMinisters(List<BillMinisters> billMovers, int BillId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            string query = "";
            try
            {
                using (con)
                {
                    if (billMovers != null)
                    {
                        if (billMovers.Count > 0)
                        {
                            DeleteBillMinisters(BillId);
                            foreach (BillMinisters billmovers in billMovers)
                            {
                                query += "INSERT INTO BILL_MINISTERS (BILL_ID,MINISTERS_ID) VALUES(" + BillId + "," + billmovers.MinisterId + ");";

                            }
                            SqlCommand cmd = new SqlCommand(query, con);
                            SqlDataReader dr = cmd.ExecuteReader();
                        }
                    }
                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        protected void DeleteBillMinisters(int BillId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_BILL_MINISTERS";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = BillId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        //public void UpdateBill(Bills bill)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_BILL";

        //        cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = bill.BillsId;
        //        cmd.Parameters.Add("@BillTypeId", SqlDbType.Int).Value = bill.BillTypeId;
        //        cmd.Parameters.Add("@BillStatusId", SqlDbType.Int).Value = 2; //Under Process
        //        cmd.Parameters.Add("@BillCategoriesId", SqlDbType.VarChar).Value = bill.BillCategoriesId;
        //        cmd.Parameters.Add("@BillStagesId", SqlDbType.VarChar).Value = bill.BillStagesId;
        //        cmd.Parameters.Add("@HouseTypesId", SqlDbType.VarChar).Value = bill.HouseTypesId;
        //        cmd.Parameters.Add("@ParliamentaryYear", SqlDbType.Int).Value = bill.ParliamentaryYear;
        //        cmd.Parameters.Add("@BillDate", SqlDbType.DateTime).Value = bill.BillDate;
        //        cmd.Parameters.Add("@BillTime", SqlDbType.DateTime).Value = bill.BillTime;
        //        cmd.Parameters.Add("@SessionNumber", SqlDbType.Int).Value = bill.AssemblySessionsId;
        //        cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.VarChar).Value = bill.NoticeDiaryNo;
        //        cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.DateTime).Value = bill.NoticeDiaryDate;
        //        cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = bill.NoticeDiaryTime;
        //        cmd.Parameters.Add("@LegislationDiaryNo", SqlDbType.VarChar).Value = bill.LegislationDiaryNo;
        //        cmd.Parameters.Add("@LegislationDiaryDate", SqlDbType.DateTime).Value = bill.LegislationDiaryDate;
        //        cmd.Parameters.Add("@LegislationDiaryTime", SqlDbType.DateTime).Value = bill.LegislationDiaryTime;
        //        cmd.Parameters.Add("@ParticipatedMembers", SqlDbType.Int).Value = bill.ParticipatedMembers;
        //        cmd.Parameters.Add("@BillIdentifier", SqlDbType.VarChar).Value = bill.BillIdentifier;
        //        cmd.Parameters.Add("@FileNumber", SqlDbType.Int).Value = bill.FileNumber;
        //        cmd.Parameters.Add("@BillGazettedDate", SqlDbType.DateTime).Value = bill.BillGazettedDate;
        //        cmd.Parameters.Add("@BillYear", SqlDbType.Int).Value = bill.BillYear;
        //        cmd.Parameters.Add("@BillGazettedDate", SqlDbType.DateTime).Value = bill.BillGazettedDate;
        //        cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = 1;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataReader dr = cmd.ExecuteReader();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public void DeleteBill(int BillId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_BILL";

                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = BillId;

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion BILLS

        //------------------------------------END-------------------------------------//

        #region BILL_STATUSES
        public List<BillStatuses> GetBillStatuses()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILL_STATUSES";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                List<BillStatuses> billStatuses = null;

                if (dr.HasRows)
                {
                    billStatuses = new List<BillStatuses>();
                    while (dr.Read())
                    {
                        BillStatuses Temp = new BillStatuses();
                        Temp.BillStatusesId = Convert.ToInt32(dr["BILL_STATUSES_ID"]);

                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        Temp.Description = Convert.ToString(dr["DESCRIPTION"]);


                        billStatuses.Add(Temp);
                    }
                }
                return billStatuses;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public List<BillStatuses> GetActiveBillStatuses()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_BILL_STATUSES";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                List<BillStatuses> billStatuses = null;

                if (dr.HasRows)
                {
                    billStatuses = new List<BillStatuses>();
                    while (dr.Read())
                    {
                        BillStatuses Temp = new BillStatuses();
                        Temp.BillStatusesId = Convert.ToInt32(dr["BILL_STATUSES_ID"]);

                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        Temp.Description = Convert.ToString(dr["DESCRIPTION"]);


                        billStatuses.Add(Temp);
                    }
                }
                return billStatuses;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateBillStatuses(BillStatuses billStatuses)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_BILL_STATUS";
                cmd.Parameters.Add("@BillStatusesId", SqlDbType.Int).Value = billStatuses.BillStatusesId;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = billStatuses.Description;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = billStatuses.IsActive;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public void InsertBillStatuses(BillStatuses billStatuses)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_BILL_STATUS";

                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = billStatuses.Description;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = billStatuses.IsActive;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion BILL_STATUSES

        //------------------------------------END-------------------------------------//

        //#region Bill_STATUS_HIST
        //public List<BillStatusHistory> GetBillStatusHistory(int BillId)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {

        //        SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILL_STATUS_HISTORY";
        //        cmd.Parameters.Add("@BillId", SqlDbType.Int).Value = BillId;
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        SqlDataReader dr = cmd.ExecuteReader();
        //        List<BillStatusHistory> billStatusHistories = null;

        //        if (dr.HasRows)
        //        {
        //            BillStatusHistory Temp = new BillStatusHistory();
        //            billStatusHistories = new List<BillStatusHistory>();
        //            while (dr.Read())
        //            {
        //                Temp.BillsId = Convert.ToInt32(dr["BILLS_ID"]);
        //                Temp.BillStatusHistId = Convert.ToInt32(dr["BILL_STATUS_HIST_ID"]);

        //                Temp.BillStatusesId = Convert.ToInt32(dr["BILL_STATUS_ID"]);
        //                Temp.billStatuses = new BillStatuses();
        //                Temp.billStatuses.BillStatusesId = Convert.ToInt32(dr["BILL_STATUS_ID"]);
        //                Temp.billStatuses.Description = Convert.ToString(dr["DESCRIPTION"]);

        //                Temp.BillIdentifier = Convert.ToInt32(dr["BILL_IDENTIFIER"]);
        //                if (dr["STATUS_DATE"] != DBNull.Value)
        //                {
        //                    Temp.StatusDate = Convert.ToDateTime(dr["STATUS_DATE"]);
        //                }
        //                Temp.UpdatedBy = Convert.ToString(dr["UPDATED_BY"]);
        //                billStatusHistories.Add(Temp);
        //            }
        //        }
        //        return billStatusHistories;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}
        //#endregion Bill_STATUS_HIST

        //------------------------------------END-------------------------------------//

        #region BILL_TYPES
        public List<BillTypes> GetBillTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILL_TYPES";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                List<BillTypes> BillTypes = null;

                if (dr.HasRows)
                {

                    BillTypes = new List<BillTypes>();
                    while (dr.Read())
                    {
                        BillTypes Temp = new BillTypes();
                        Temp.BillTypesId = Convert.ToInt32(dr["BILL_TYPES_ID"]);

                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        Temp.Description = Convert.ToString(dr["DESCRIPTION"]);


                        BillTypes.Add(Temp);
                    }
                }
                return BillTypes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion BILL_TYPES

        //------------------------------------END-------------------------------------//

        #region BILL_CATEGORIES
        public List<BillCategories> GetBillCategories()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILL_CATEGORIES";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                List<BillCategories> BillCategories = null;

                if (dr.HasRows)
                {
                    BillCategories = new List<BillCategories>();
                    while (dr.Read())
                    {
                        BillCategories Temp = new BillCategories();
                        Temp.BillCategoriesId = Convert.ToInt32(dr["BILL_CATEGORIES_ID"]);

                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        Temp.Description = Convert.ToString(dr["DESCRIPTION"]);


                        BillCategories.Add(Temp);
                    }
                }
                return BillCategories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public List<BillCategories> GetAllBillCategories()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ALL_BILL_CATEGORIES";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                List<BillCategories> BillCategories = null;

                if (dr.HasRows)
                {
                    BillCategories = new List<BillCategories>();
                    while (dr.Read())
                    {
                        BillCategories Temp = new BillCategories();
                        Temp.BillCategoriesId = Convert.ToInt32(dr["BILL_CATEGORIES_ID"]);

                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        Temp.Description = Convert.ToString(dr["DESCRIPTION"]);


                        BillCategories.Add(Temp);
                    }
                }
                return BillCategories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateBillCategory(BillCategories billCategory)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_BILL_CATEGORY";
                cmd.Parameters.Add("@BillCategoriesId", SqlDbType.Int).Value = billCategory.BillCategoriesId;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = billCategory.Description;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = billCategory.IsActive;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public void InsertBillCategory(BillCategories billCategory)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_BILL_CATEGORY";

                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = billCategory.Description;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = billCategory.IsActive;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion BILL_CATEGORIES

        //------------------------------------END-------------------------------------//

        #region ASSEMBLY_SESSIONS
        public AssemblySessions GetCurrentAssemblySessionDetails()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[QUESTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CURRENT_SESSION_DETAILS";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AssemblySessions Temp = new AssemblySessions();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp.AssemblySessionsId = Convert.ToInt32(dr["Assembly_Sessions_Id"]);
                    Temp.CalledBy = Convert.ToString(dr["Called_By"]);
                    // Temp.IsJointSession = Convert.ToInt32(dr["Is_Joint_Session"]);
                    Temp.SessionNumber = Convert.ToInt32(dr["Session_Number"]);
                    if (dr["Start_Date"] != DBNull.Value)
                        Temp.StartDate = Convert.ToDateTime(dr["Start_Date"]);
                    if (dr["End_Date"] != DBNull.Value)
                        Temp.EndDate = Convert.ToDateTime(dr["End_Date"]);
                    //Temp.SittingTypeId = Convert.ToInt32(dr["Sitting_Type_Id"]);
                    Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                    if (dr["Assemblies_Id"] != DBNull.Value)
                        Temp.AssembliesId = Convert.ToInt32(dr["Assemblies_Id"]);
                    if (dr["Business_Sessions"] != DBNull.Value)
                        Temp.BusinessSessions = Convert.ToString(dr["Business_Sessions"]);
                    if (dr["Business_Status"] != DBNull.Value)
                        Temp.BusinessStatus = Convert.ToInt32(dr["Business_Status"]);
                    //Temp.SummonedBy = Convert.ToInt32(dr["Summoned_By"]);
                    //Temp.ProroguedBy = Convert.ToInt32(dr["Prorogued_By"]);
                    //Temp.LegislationDiaryNo = Convert.ToInt32(dr["Legislation_Diary_No"]);
                    //Temp.LegislationDiaryDate = Convert.ToDateTime(dr["Legislation_Diary_Date"]);
                    //Temp.SessStatusesId = Convert.ToInt32(dr["Sess_Statuses_Id"]);
                    //Temp.IsQuorumAdjourned = Convert.ToInt32(dr["IS_QUORUM_ADJOURNED"]);
                    // Temp.ParliamentaryYearsId = Convert.ToInt32(dr["Parliamentary_Years_Id"]);
                    // Temp.LegislationDiaryTime = Convert.ToDateTime(dr["Legislation_Diary_Time"]);
                    //Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                    //Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                    //Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);
                    //Temp.FileNo = Convert.ToString(dr["File_No"]);
                    //Temp.RequisitionDate = Convert.ToDateTime(dr["Requisition_Date"]);
                    //Temp.RequisitionTime = Convert.ToDateTime(dr["Requisition_Time"]);
                    //Temp.TotalWorkingDays = Convert.ToInt32(dr["Total_Working_Days"]);
                    //Temp.ActualSittingDays = Convert.ToInt32(dr["Actual_Sitting_Days"]);
                    //Temp.SummonNoticeDate = Convert.ToDateTime(dr["Summon_Notice_Date"]);
                    //Temp.SummonNoticeTime = Convert.ToDateTime(dr["Summon_Notice_Time"]);
                }

                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public List<AssemblySessions> GetAssemblySessions()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ASSEMBLY_SESSIONS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<AssemblySessions> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<AssemblySessions>();
                    while (dr.Read())
                    {
                        AssemblySessions Temp = new AssemblySessions();
                        Temp.AssemblySessionsId = Convert.ToInt32(dr["Assembly_Sessions_Id"]);
                        Temp.CalledBy = Convert.ToString(dr["Called_By"]);
                        if(dr["Is_Joint_Session"]!=DBNull.Value)
                        Temp.IsJointSession = Convert.ToInt32(dr["Is_Joint_Session"]);
                        Temp.SessionNumber = Convert.ToInt32(dr["Session_Number"]);
                        Temp.StartDate = Convert.ToDateTime(dr["Start_Date"]);
                        if(dr["End_Date"]!=DBNull.Value)
                        Temp.EndDate = Convert.ToDateTime(dr["End_Date"]);
                        //if (dr["Sitting_Type_Id"] != DBNull.Value)
                        //Temp.SittingTypeId = Convert.ToInt32(dr["Sitting_Type_Id"]);
                        //Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        //if(dr["Assemblies_Id"]!=DBNull.Value)
                        //Temp.AssembliesId = Convert.ToInt32(dr["Assemblies_Id"]);
                        //if(dr["Summoned_By"]!=DBNull.Value)
                        //Temp.SummonedBy = Convert.ToInt32(dr["Summoned_By"]);
                        //if (dr["Prorogued_By"] != DBNull.Value)
                        //Temp.ProroguedBy = Convert.ToInt32(dr["Prorogued_By"]);
                        //if (dr["Legislation_Diary_No"] != DBNull.Value)
                        //Temp.LegislationDiaryNo = Convert.ToInt32(dr["Legislation_Diary_No"]);
                        //if (dr["Legislation_Diary_Date"] != DBNull.Value)
                        //Temp.LegislationDiaryDate = Convert.ToDateTime(dr["Legislation_Diary_Date"]);
                        //if (dr["Sess_Statuses_Id"] != DBNull.Value)
                        //Temp.SessStatusesId = Convert.ToInt32(dr["Sess_Statuses_Id"]);
                        //if (dr["IS_QUORUM_ADJOURNED"] != DBNull.Value)
                        //Temp.IsQuorumAdjourned = Convert.ToInt32(dr["IS_QUORUM_ADJOURNED"]);
                        if (dr["PARLIAMENTARY_YEARS_ID"] != DBNull.Value)
                        {
                            Temp.ParliamentaryYearsId = Convert.ToInt32(dr["PARLIAMENTARY_YEARS_ID"]);
                            Temp.ParliamentaryYear = Convert.ToString(dr["PARLIAMENTARY_YEAR"]);
                        }
                        //if (dr["Legislation_Diary_Time"] != DBNull.Value)
                        //Temp.LegislationDiaryTime = Convert.ToDateTime(dr["Legislation_Diary_Time"]);
                        //if (dr["Notice_Diary_No"] != DBNull.Value)
                        //Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                        //if (dr["Notice_Diary_Date"] != DBNull.Value)
                        //Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                        //if (dr["Notice_Diary_Time"] != DBNull.Value)
                        //Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);
                        //if (dr["File_No"] != DBNull.Value)
                        //Temp.FileNo = Convert.ToString(dr["File_No"]);
                        //if (dr["Requisition_Date"] != DBNull.Value)
                        //Temp.RequisitionDate = Convert.ToDateTime(dr["Requisition_Date"]);
                        //if (dr["Requisition_Time"] != DBNull.Value)
                        //Temp.RequisitionTime = Convert.ToDateTime(dr["Requisition_Time"]);
                        //if (dr["Total_Working_Days"] != DBNull.Value)
                        //Temp.TotalWorkingDays = Convert.ToInt32(dr["Total_Working_Days"]);
                        //if (dr["Actual_Sitting_Days"] != DBNull.Value)
                        //Temp.ActualSittingDays = Convert.ToInt32(dr["Actual_Sitting_Days"]);
                        //if (dr["Summon_Notice_Date"] != DBNull.Value)
                        //Temp.SummonNoticeDate = Convert.ToDateTime(dr["Summon_Notice_Date"]);
                        //if (dr["Summon_Notice_Time"] != DBNull.Value)
                        //Temp.SummonNoticeTime = Convert.ToDateTime(dr["Summon_Notice_Time"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public int GetCurrentAssemblySessions()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CURRENT_SESSION";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                int AssemblySessionsId = 0;
                if (dr.HasRows)
                {
                    dr.Read();
                    AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);

                }
                return AssemblySessionsId;
            }
            finally
            {
                con.Close();

            }
        }
        public void UpdateAssemblySessions(AssemblySessions Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_ASSEMBLY_SESSION";
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = Temp.AssemblySessionsId;
              //  cmd.Parameters.Add("@CalledBy", SqlDbType.VarChar).Value = Temp.CalledBy;
               // cmd.Parameters.Add("@BusinessSessions", SqlDbType.VarChar).Value = Temp.BusinessSessions;
              //  cmd.Parameters.Add("@SessionNumber", SqlDbType.Int).Value = Temp.SessionNumber;
                cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = Temp.StartDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = Temp.EndDate;
                //cmd.Parameters.Add("@Sitting_Type_Id", SqlDbType.Int).Value = Temp.SittingTypeId;
                //cmd.Parameters.Add("@Is_Active", SqlDbType.Int).Value = Temp.IsActive;
                //cmd.Parameters.Add("@Assemblies_Id", SqlDbType.Int).Value = Temp.AssembliesId;
                //cmd.Parameters.Add("@Summoned_By", SqlDbType.Int).Value = Temp.SummonedBy;
                //cmd.Parameters.Add("@Prorogued_By", SqlDbType.Int).Value = Temp.ProroguedBy;
                //cmd.Parameters.Add("@Legislation_Diary_No", SqlDbType.Int).Value = Temp.LegislationDiaryNo;
                //cmd.Parameters.Add("@Legislation_Diary_Date", SqlDbType.Date).Value = Temp.LegislationDiaryDate;
                //cmd.Parameters.Add("@Sess_Statuses_Id", SqlDbType.Int).Value = Temp.SessStatusesId;
                //cmd.Parameters.Add("@Is_Quorum_Adjourned", SqlDbType.Int).Value = Temp.IsQuorumAdjourned;
                cmd.Parameters.Add("@ParliamentaryYearsId", SqlDbType.Int).Value = Temp.ParliamentaryYearsId;
                //cmd.Parameters.Add("@Legislation_Diary_Time", SqlDbType.Date).Value = Temp.LegislationDiaryTime;
                //cmd.Parameters.Add("@Notice_Diary_No", SqlDbType.Int).Value = Temp.NoticeDiaryNo;
                //cmd.Parameters.Add("@Notice_Diary_Date", SqlDbType.Date).Value = Temp.NoticeDiaryDate;
                //cmd.Parameters.Add("@Notice_Diary_Time", SqlDbType.Date).Value = Temp.NoticeDiaryTime;
                //cmd.Parameters.Add("@File_No", SqlDbType.VarChar).Value = Temp.FileNo;
                //cmd.Parameters.Add("@Requisition_Date", SqlDbType.Date).Value = Temp.RequisitionDate;
                //cmd.Parameters.Add("@Requisition_Time", SqlDbType.Date).Value = Temp.RequisitionTime;
                //cmd.Parameters.Add("@Total_Working_Days", SqlDbType.Int).Value = Temp.TotalWorkingDays;
                //cmd.Parameters.Add("@Actual_Sitting_Days", SqlDbType.Int).Value = Temp.ActualSittingDays;
                //cmd.Parameters.Add("@Summon_Notice_Date", SqlDbType.Date).Value = Temp.SummonNoticeDate;
                //cmd.Parameters.Add("@Summon_Notice_Time", SqlDbType.Date).Value = Temp.SummonNoticeTime;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public int InsertAssemblySessions(AssemblySessions Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_ASSEMBLY_SESSION";
                cmd.Parameters.Add("@CalledBy", SqlDbType.VarChar).Value = Temp.CalledBy;
                //  cmd.Parameters.Add("@Is_Joint_Session", SqlDbType.Int).Value = Temp.IsJointSession;
                cmd.Parameters.Add("@SessionNumber", SqlDbType.Int).Value = Temp.SessionNumber;
                cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = Temp.StartDate;
                // cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = Temp.EndDate;
                // cmd.Parameters.Add("@Sitting_Type_Id", SqlDbType.Int).Value = Temp.SittingTypeId;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = 1;
                // cmd.Parameters.Add("@Assemblies_Id", SqlDbType.Int).Value = Temp.AssembliesId;
                // cmd.Parameters.Add("@Summoned_By", SqlDbType.Int).Value = Temp.SummonedBy;
                // cmd.Parameters.Add("@Prorogued_By", SqlDbType.Int).Value = Temp.ProroguedBy;
                // cmd.Parameters.Add("@Legislation_Diary_No", SqlDbType.Int).Value = Temp.LegislationDiaryNo;
                // cmd.Parameters.Add("@Legislation_Diary_Date", SqlDbType.Date).Value = Temp.LegislationDiaryDate;
                //  cmd.Parameters.Add("@Sess_Statuses_Id", SqlDbType.Int).Value = Temp.SessStatusesId;
                // cmd.Parameters.Add("@Is_Quorum_Adjourned", SqlDbType.Int).Value = Temp.IsQuorumAdjourned;
                cmd.Parameters.Add("@ParliamentaryYearsId", SqlDbType.Int).Value = Temp.ParliamentaryYearsId;
                cmd.Parameters.Add("@BusinessSessions", SqlDbType.VarChar).Value = Temp.BusinessSessions;
                // cmd.Parameters.Add("@Legislation_Diary_Time", SqlDbType.Date).Value = Temp.LegislationDiaryTime;
                // cmd.Parameters.Add("@Notice_Diary_No", SqlDbType.Int).Value = Temp.NoticeDiaryNo;
                // cmd.Parameters.Add("@Notice_Diary_Date", SqlDbType.Date).Value = Temp.NoticeDiaryDate;
                // cmd.Parameters.Add("@Notice_Diary_Time", SqlDbType.Date).Value = Temp.NoticeDiaryTime;
                // cmd.Parameters.Add("@File_No", SqlDbType.VarChar).Value = Temp.FileNo;
                // cmd.Parameters.Add("@Requisition_Date", SqlDbType.Date).Value = Temp.RequisitionDate;
                // cmd.Parameters.Add("@Requisition_Time", SqlDbType.Date).Value = Temp.RequisitionTime;
                // cmd.Parameters.Add("@Total_Working_Days", SqlDbType.Int).Value = Temp.TotalWorkingDays;
                // cmd.Parameters.Add("@Actual_Sitting_Days", SqlDbType.Int).Value = Temp.ActualSittingDays;
                // cmd.Parameters.Add("@Summon_Notice_Date", SqlDbType.Date).Value = Temp.SummonNoticeDate;
                // cmd.Parameters.Add("@Summon_Notice_Time", SqlDbType.Date).Value = Temp.SummonNoticeTime;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteScalar();
                int id = Convert.ToInt32(cmd.Parameters["@ID"].Value.ToString());

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }

        #endregion ASSEMBLY_SESSIONS

        //------------------------------------END-------------------------------------//

        #region  ParliamentaryTenures

        public List<ParliamentaryTenures> GetParliamentaryTenures()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PARLIAMENTARY_TENURES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<ParliamentaryTenures> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ParliamentaryTenures>();
                    while (dr.Read())
                    {
                        ParliamentaryTenures Temp = new ParliamentaryTenures();
                        Temp.ParliamentaryTenuresId = Convert.ToInt32(dr["Parliamentary_Tenures_Id"]);
                        Temp.Description = Convert.ToString(dr["Description"]);
                        Temp.FromDate = Convert.ToDateTime(dr["From_Date"]);
                        Temp.ToDate = Convert.ToDateTime(dr["To_Date"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public void UpdateParliamentaryTenures(ParliamentaryTenures Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_PARLIAMENTARY_TENURE";
                cmd.Parameters.Add("@ParliamentaryTenuresId", SqlDbType.Int).Value = Temp.ParliamentaryTenuresId;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = Temp.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = Temp.ToDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertParliamentaryTenures(ParliamentaryTenures Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_PARLIAMENTARY_TENURES";
                cmd.Parameters.Add("@Descriptation", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = Temp.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = Temp.ToDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }

        #endregion ParliamentaryTemnures

        //------------------------------------END-------------------------------------//

        #region  ParliamentaryTerms

        public List<ParliamentaryTerms> GetParliamentaryTerms()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PARLIAMENTARY_TERMS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<ParliamentaryTerms> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ParliamentaryTerms>();
                    while (dr.Read())
                    {
                        ParliamentaryTerms Temp = new ParliamentaryTerms();
                        Temp.ParliamentaryTermsId = Convert.ToInt32(dr["Parliamentary_Terms_Id"]);
                        Temp.Description = Convert.ToString(dr["Description"]);
                        Temp.FromDate = Convert.ToDateTime(dr["From_Date"]);
                        Temp.ToDate = Convert.ToDateTime(dr["To_Date"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        Temp.ParliamentaryTenureId= Convert.ToInt32(dr["PARLIAMENTARY_TENURE_ID"]);
                        Temp.ParliamentaryTenure     = Convert.ToString(dr["PARLIAMENTARY_TENURE"]);

                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }

        public ParliamentaryTerms GetCurrentParliamentaryTerm()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CURRENT_PARLIAMENTARY_TERM";
                cmd.CommandType = CommandType.StoredProcedure;
                ParliamentaryTerms Temp = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                        Temp = new ParliamentaryTerms();
                        dr.Read();
                        Temp.ParliamentaryTermsId = Convert.ToInt32(dr["Parliamentary_Terms_Id"]);
                        Temp.Description = Convert.ToString(dr["Description"]);
                        Temp.FromDate = Convert.ToDateTime(dr["From_Date"]);
                        Temp.ToDate = Convert.ToDateTime(dr["To_Date"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        Temp.ParliamentaryTenureId = Convert.ToInt32(dr["PARLIAMENTARY_TENURE_ID"]);
                        Temp.ParliamentaryTenure = Convert.ToString(dr["PARLIAMENTARY_TENURE"]);
                }

                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public ParliamentaryTerms GetParliamentaryTerm(int TermId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PARLIAMENTARY_TERM";
                cmd.Parameters.Add("@ParliamentaryTermsId", SqlDbType.Int).Value = TermId;
                cmd.CommandType = CommandType.StoredProcedure;
                ParliamentaryTerms Temp = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                       Temp = new ParliamentaryTerms();
                        Temp.ParliamentaryTermsId = Convert.ToInt32(dr["Parliamentary_Terms_Id"]);
                        Temp.Description = Convert.ToString(dr["Description"]);
                        Temp.FromDate = Convert.ToDateTime(dr["From_Date"]);
                        Temp.ToDate = Convert.ToDateTime(dr["To_Date"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        Temp.ParliamentaryTenureId = Convert.ToInt32(dr["PARLIAMENTARY_TENURES_ID"]);
                        Temp.ParliamentaryTenure = Convert.ToString(dr["PARLIAMENTARY_TENURE"]);

                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public void UpdateParliamentaryTerm(ParliamentaryTerms Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_PARLIAMENTARY_TERM";
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@ParliamentaryTermsId", SqlDbType.Int).Value = Temp.ParliamentaryTermsId;
                cmd.Parameters.Add("@ParliamentaryTenuresId", SqlDbType.Int).Value = Temp.ParliamentaryTenureId;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = Temp.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = Temp.ToDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertParliamentaryTerm(ParliamentaryTerms Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_PARLIAMENTARY_TERM";
                cmd.Parameters.Add("@ParliamentaryTenuresId", SqlDbType.Int).Value = Temp.ParliamentaryTenureId;
                cmd.Parameters.Add("@Descriptation", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = Temp.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = Temp.ToDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }

        #endregion ParliamentaryTerms
        #region Parliamentary_Years

        public List<ParliamentaryYears> GetParliamentaryYears()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PARLIAMENTARY_YEARS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<ParliamentaryYears> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ParliamentaryYears>();
                    while (dr.Read())
                    {
                        ParliamentaryYears Temp = new ParliamentaryYears();

                        Temp.ParliamentaryYearsId = Convert.ToInt32(dr["Parliamentary_Years_Id"]);
                        Temp.ParliamentaryYear = Convert.ToString(dr["Parliamentary_Year"]);
                        Temp.FromDate = Convert.ToDateTime(dr["From_Date"]);
                        Temp.ToDate = Convert.ToDateTime(dr["To_Date"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        Temp.ParliamentaryTenuresId = Convert.ToInt32(dr["PARLIAMENTARY_TENURES_ID"]);
                        Temp.ParliamentaryTenure = Convert.ToString(dr["PARLIAMENTARY_TENURE_DESC"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }

        public ParliamentaryYears GetCurrentParliamentaryYear()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CURRENT_PARLIAMENTARY_YEAR";
                cmd.CommandType = CommandType.StoredProcedure;
                ParliamentaryYears Temp = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Temp = new ParliamentaryYears();
                    dr.Read();
                    Temp.ParliamentaryYearsId = Convert.ToInt32(dr["Parliamentary_Years_id"]);
                    Temp.ParliamentaryYear = Convert.ToString(dr["Parliamentary_Year"]);
                    Temp.FromDate = Convert.ToDateTime(dr["From_Date"]);
                    Temp.ToDate = Convert.ToDateTime(dr["To_Date"]);
                    Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                    Temp.ParliamentaryTenuresId = Convert.ToInt32(dr["PARLIAMENTARY_TENURES_ID"]);
                    //Temp.ParliamentaryTenure = Convert.ToString(dr["PARLIAMENTARY_TENURE_DESC"]);

                }

                return Temp;
            }
            finally
            {
                con.Close();

            }
        }

        public void UpdateParliamentaryYears(ParliamentaryYears Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_PARLIAMENTARY_YEAR";
                cmd.Parameters.Add("@ParliamentaryYearsId", SqlDbType.Int).Value = Temp.ParliamentaryYearsId;
                cmd.Parameters.Add("@ParliamentaryYear", SqlDbType.VarChar).Value = Temp.ParliamentaryYear;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = Temp.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = Temp.ToDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.Parameters.Add("@ParliamentaryTenuresId", SqlDbType.Int).Value = Temp.ParliamentaryTenuresId;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertParliamentaryYears(ParliamentaryYears Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_PARLIAMENTARY_YEAR";
                cmd.Parameters.Add("@ParliamentaryTenuresId", SqlDbType.Int).Value = Temp.ParliamentaryTenuresId;
                cmd.Parameters.Add("@ParliamentaryYear", SqlDbType.VarChar).Value = Temp.ParliamentaryYear;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = Temp.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = Temp.ToDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }

        #endregion Parliamentary_Years
        //------------------------------------END-------------------------------------//

        #region Assemblies
        public List<Assemblies> GetAssemblies()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ASSEMBLIES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Assemblies> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Assemblies>();
                    while (dr.Read())
                    {
                        Assemblies Temp = new Assemblies();
                        Temp.AssembliesId = Convert.ToInt32(dr["Assemblies_Id"]);
                        Temp.Term = Convert.ToString(dr["Term"]);
                        Temp.FromDate = Convert.ToDateTime(dr["From_Date"]);
                        Temp.ToDate = Convert.ToDateTime(dr["To_Date"]);
                        Temp.NoOfSeats = Convert.ToInt32(dr["No_Of_Seats"]);
                        Temp.ElectionYear = Convert.ToInt32(dr["Election_Year"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        Temp.MaxStarredAllowed = Convert.ToInt32(dr["Max_Starred_Allwd"]);
                        Temp.MaxUnStarredAllowed = Convert.ToInt32(dr["MAX_UNSTAR_ALLWD"]);
                        Temp.MaxSNoticeAllowed = Convert.ToInt32(dr["MAX_S_NOTICE_ALWD"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public void UpdateAssemblies(Assemblies Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_ASSEMBLY";
                cmd.Parameters.Add("@Term", SqlDbType.VarChar).Value = Temp.Term;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = Temp.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = Temp.ToDate;
                cmd.Parameters.Add("@NoOfSeats", SqlDbType.Date).Value = Temp.NoOfSeats;
                cmd.Parameters.Add("@ElectionYear", SqlDbType.Date).Value = Temp.ElectionYear;
                cmd.Parameters.Add("@MaxStarredAllowed", SqlDbType.Int).Value = Temp.MaxStarredAllowed;
                cmd.Parameters.Add("@MaxUnStarredAllowed", SqlDbType.Int).Value = Temp.MaxUnStarredAllowed;
                cmd.Parameters.Add("@MaxSNoticeAllowed", SqlDbType.Int).Value = Temp.MaxSNoticeAllowed;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertAssemblies(Assemblies Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_ASSEMBLY";
                cmd.Parameters.Add("@Term", SqlDbType.VarChar).Value = Temp.Term;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = Temp.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = Temp.ToDate;
                cmd.Parameters.Add("@NoOfSeats", SqlDbType.Date).Value = Temp.NoOfSeats;
                cmd.Parameters.Add("@ElectionYear", SqlDbType.Date).Value = Temp.ElectionYear;
                cmd.Parameters.Add("@MaxStarredAllowed", SqlDbType.Int).Value = Temp.MaxStarredAllowed;
                cmd.Parameters.Add("@MaxUnStarredAllowed", SqlDbType.Int).Value = Temp.MaxUnStarredAllowed;
                cmd.Parameters.Add("@MaxSNoticeAllowed", SqlDbType.Int).Value = Temp.MaxSNoticeAllowed;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }

        #endregion Assemblies

        //------------------------------------END-------------------------------------//

        #region SittingTypes

        public List<SittingTypes> GetSittingTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SITTING_TYPES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<SittingTypes> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<SittingTypes>();
                    while (dr.Read())
                    {
                        SittingTypes Temp = new SittingTypes();
                        Temp.SittingTypesId = Convert.ToInt32(dr["Sitting_Types_Id"]);
                        Temp.Description = Convert.ToString(dr["Descriptation"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public void UpdateSittingTypes(SittingTypes Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_SITTING_TYPE";
                cmd.Parameters.Add("@Descriptation", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@IsActive", SqlDbType.Date).Value = Temp.IsActive;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertSittingTypes(SittingTypes Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_SITTING_TYPE";
                cmd.Parameters.Add("@Descriptation", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@IsActive", SqlDbType.Date).Value = Temp.IsActive;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }

        #endregion SittingTypes

        //------------------------------------END-------------------------------------//

        #region SessionSittings

        public List<SessionSittings> GetSessionSitting()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SESSION_SITTINGS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<SessionSittings> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<SessionSittings>();
                    while (dr.Read())
                    {
                        SessionSittings Temp = new SessionSittings();
                        Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
                        Temp.AssembliesSessionId = Convert.ToInt32(dr["Assembly_Sessions_Id"]);
                        Temp.AssemblySession = Convert.ToString(dr["Session_Number"]);
                        Temp.Sessiondate = Convert.ToDateTime(dr["Session_Date"]);
                        Temp.IsMorningSitting = Convert.ToInt32(dr["Is_Morning_Sittings"]);
                        Temp.StartTime = Convert.ToDateTime(dr["Start_Time"]);
                        Temp.EndTime = Convert.ToDateTime(dr["End_Time"]);
                        Temp.TotalTimeConsumed = Convert.ToDouble(dr["Total_Time_Consumed"]);
                        Temp.Remarks = Convert.ToString(dr["Session_Date"]);
                        Temp.SittingGernal = Convert.ToString(dr["Sitting_Gernal"]);
                        Temp.EvenStartTime = Convert.ToDateTime(dr["Even_Start_Time"]);
                        Temp.EvenEndTime = Convert.ToDateTime(dr["Even_End_Time"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public void UpdateSessionSittings(SessionSittings Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_SESSION_SITTING";
                cmd.Parameters.Add("@Session_Sittings_Id", SqlDbType.VarChar).Value = Temp.SessionSittingsId;
                cmd.Parameters.Add("@Assembly_Sessions_Id", SqlDbType.VarChar).Value = Temp.AssembliesSessionId;
                cmd.Parameters.Add("@Is_Morning_Sittings", SqlDbType.VarChar).Value = Temp.IsMorningSitting;
                cmd.Parameters.Add("@Session_Date", SqlDbType.Date).Value = Temp.Sessiondate;
                cmd.Parameters.Add("@Is_Morning_Sittings", SqlDbType.VarChar).Value = Temp.IsMorningSitting;
                cmd.Parameters.Add("@Start_Time", SqlDbType.DateTime).Value = Temp.StartTime;
                cmd.Parameters.Add("@End_Time", SqlDbType.Date).Value = Temp.EndTime;
                cmd.Parameters.Add("@Total_Time_Consumed", SqlDbType.VarChar).Value = Temp.TotalTimeConsumed;
                cmd.Parameters.Add("@Session_Date", SqlDbType.DateTime).Value = Temp.Sessiondate;
                cmd.Parameters.Add("@Sitting_Gernal", SqlDbType.VarChar).Value = Temp.SittingGernal;
                cmd.Parameters.Add("@Even_Start_Time", SqlDbType.Date).Value = Temp.EvenStartTime;
                cmd.Parameters.Add("@Even_End_Time", SqlDbType.Date).Value = Temp.EvenEndTime;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertSessionSittings(SessionSittings Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_SESSION_SITTING";
                cmd.Parameters.Add("@Assembly_Sessions_Id", SqlDbType.Int).Value = Temp.AssembliesSessionId;
                cmd.Parameters.Add("@Is_Morning_Sittings", SqlDbType.VarChar).Value = Temp.IsMorningSitting;
                cmd.Parameters.Add("@Session_Date", SqlDbType.Date).Value = Temp.Sessiondate;
                cmd.Parameters.Add("@Is_Morning_Sittings", SqlDbType.VarChar).Value = Temp.IsMorningSitting;
                cmd.Parameters.Add("@Start_Time", SqlDbType.DateTime).Value = Temp.StartTime;
                cmd.Parameters.Add("@End_Time", SqlDbType.Date).Value = Temp.EndTime;
                cmd.Parameters.Add("@Total_Time_Consumed", SqlDbType.VarChar).Value = Temp.TotalTimeConsumed;
                cmd.Parameters.Add("@Session_Date", SqlDbType.DateTime).Value = Temp.Sessiondate;
                cmd.Parameters.Add("@Sitting_Gernal", SqlDbType.VarChar).Value = Temp.SittingGernal;
                cmd.Parameters.Add("@Even_Start_Time", SqlDbType.Date).Value = Temp.EvenStartTime;
                cmd.Parameters.Add("@Even_End_Time", SqlDbType.Date).Value = Temp.EvenEndTime;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }

        #endregion SessionSitting

        //------------------------------------END-------------------------------------//

        //#region Parliamentary Year
        //public ParliamentaryYears GetCurrentParliamentaryYear()
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CURRENT_PARLIAMENTARY_YEAR";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        ParliamentaryYears Temp = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            Temp = new ParliamentaryYears();
        //            dr.Read();
        //            Temp.ParliamentaryYearsId = Convert.ToInt32(dr["Parliamentary_Years_id"]);
        //            Temp.ParliamentaryYear = Convert.ToString(dr["Parliamentary_Year"]);
        //            Temp.FromDate = Convert.ToDateTime(dr["From_Date"]);
        //            Temp.ToDate = Convert.ToDateTime(dr["To_Date"]);
        //            Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
        //            Temp.ParliamentaryTenuresId = Convert.ToInt32(dr["PARLIAMENTARY_TENURES_ID"]);
        //            //Temp.ParliamentaryTenure = Convert.ToString(dr["PARLIAMENTARY_TENURE_DESC"]);

        //        }

        //        return Temp;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}
        //#endregion

        //------------------------------------END-------------------------------------//

        #region Session Groups
        public List<Groups> GetSessionGroups(int AssemplySessionsId, int CategoryId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                if (CategoryId == 1 || CategoryId == 3)
                    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SESSION_GROUPS";
                else if (CategoryId == 2)
                    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_UNSTARRED_GROUPS";
                else
                    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "";


                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = AssemplySessionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Groups> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Groups>();
                    while (dr.Read())
                    {
                        Groups Temp = new Groups();

                        Temp.GroupsId = Convert.ToInt32(dr["Groups_Id"]);
                        Temp.Description = Convert.ToString(dr["Description"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        Temp.AssembliesSessionId = Convert.ToInt32(dr["Assembly_Sessions_Id"]);
                        //Temp.AssembliesSession = Convert.ToString(dr["Session_Number"]);
                        Temp.CorrespondingGroup = Convert.ToInt32(dr["Corresponding_Group"]);
                        Temp.GroupSequence = Convert.ToInt32(dr["Group_Sequence"]);
                        Temp.UnstarDesc = Convert.ToString(dr["Unstar_Desc"]);

                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public void CopySessionGroups(int CurrentSession, int PreviousSession)
        {
            List<Groups> PreviousGroups = GetSessionGroups(PreviousSession, 1);
            foreach (Groups obj in PreviousGroups)
            {
                obj.AssembliesSessionId = CurrentSession;
                InsertGroups(obj);
            }

            //List<Groups> CurrentGroups = GetSessionGroups(CurrentSession, 1);
            //List<GroupDivisions> gds = GetGroupDivisions(PreviousSession);
            //for (int i = 1; i <= 5; i++)
            //{
            //    List<Groups> CurrCorrGps = GetSessionCorrespondingGroups(CurrentSession, i);
            //    List<GroupDivisions> GDivs = GetDivisionsBySessionGroup(PreviousSession, i);
            //    foreach (GroupDivisions temp in GDivs)
            //    {
            //        foreach (Groups gps in CurrCorrGps)
            //        {
            //            GroupDivisions gd = new GroupDivisions();
            //            gd.DivisionsId = temp.DivisionsId;
            //            gd.GroupsId = gps.GroupsId;
            //            InsertGroupDivisions(gd);
            //        }
            //    }

            //}


        }
        #endregion

        //------------------------------------END-------------------------------------//

        #region Groups
        public void InsertGroups(Groups Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_GROUPS";
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = Temp.AssembliesSessionId;
                cmd.Parameters.Add("@CorrespondingGroup", SqlDbType.Int).Value = Temp.CorrespondingGroup;
                cmd.Parameters.Add("@GroupSequenc", SqlDbType.Int).Value = Temp.GroupSequence;
                cmd.Parameters.Add("@UnstarDesc", SqlDbType.VarChar).Value = Temp.UnstarDesc;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion

        //------------------------------------END-------------------------------------//
        #region Committees
        //public List<ParliamentaryTenures> GetParliamentaryTerms()
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PARLIAMENTARY_TENURES";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<ParliamentaryTenures> MyList = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            MyList = new List<ParliamentaryTenures>();
        //            while (dr.Read())
        //            {
        //                ParliamentaryTenures Temp = new ParliamentaryTenures();
        //                Temp.ParliamentaryTenuresId = Convert.ToInt32(dr["Parliamentary_Tenures_Id"]);
        //                Temp.Description = Convert.ToString(dr["Description"]);
        //                Temp.FromDate = Convert.ToDateTime(dr["From_Date"]);
        //                Temp.ToDate = Convert.ToDateTime(dr["To_Date"]);
        //                Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
        //                MyList.Add(Temp);
        //            }
        //        }

        //        if (MyList != null) MyList.TrimExcess();
        //        return MyList;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}
        #endregion
        #region Bill Documents
        public void InsertBillDocument(BillDocumentsEnt billDocumentsEnt)
        {
                //int id = new DalHelper().GetPk("BILL_DOCUMENTS", "BILL_DOCUMENTS_ID");
                SqlConnection con = new DalHelper().GetConnection();
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_BILL_DOCUMENT";
                    cmd.Parameters.Add("@BillDocumentId", SqlDbType.Int).Value = billDocumentsEnt.DocumentId;
                    cmd.Parameters.Add("@DocumentTypeId", SqlDbType.Int).Value = billDocumentsEnt.DocumentTypeId;
                    cmd.Parameters.Add("@BillId", SqlDbType.Int).Value = billDocumentsEnt.BillId;
                    cmd.Parameters.Add("@DocumentDate", SqlDbType.DateTime).Value = billDocumentsEnt.AttachmentDate;
                    cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = billDocumentsEnt.DocumentDescription;
                    cmd.Parameters.Add("@Url", SqlDbType.VarChar).Value = billDocumentsEnt.Url;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();

                }
        }
        public void UpdateBillDocument(BillDocumentsEnt billDocumentsEnt)
        {
            //int id = new DalHelper().GetPk("BILL_DOCUMENTS", "BILL_DOCUMENTS_ID");
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_BILL_DOCUMENT";
                cmd.Parameters.Add("@BillDocumentId", SqlDbType.Int).Value = billDocumentsEnt.DocumentId;
                cmd.Parameters.Add("@DocumentTypeId", SqlDbType.Int).Value = billDocumentsEnt.DocumentTypeId;
                cmd.Parameters.Add("@BillId", SqlDbType.Int).Value = billDocumentsEnt.BillId;
                cmd.Parameters.Add("@DocumentDate", SqlDbType.DateTime).Value = billDocumentsEnt.AttachmentDate;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = billDocumentsEnt.DocumentDescription;
                cmd.Parameters.Add("@Url", SqlDbType.VarChar).Value = billDocumentsEnt.Url;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public List<BillDocumentsEnt> GetBillDocuments(int BillId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILL_DOCUMENTS";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = BillId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<BillDocumentsEnt> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<BillDocumentsEnt>();
                    while (dr.Read())
                    {
                        BillDocumentsEnt Temp = new BillDocumentsEnt();
                        Temp.DocumentId = Convert.ToInt32(dr["BILL_DOCUMENTS_ID"]);
                        Temp.BillId= Convert.ToInt32(dr["BILL_ID"]); 
                        Temp.DocumentDescription = Convert.ToString(dr["DESCRIPTION"]);
                        Temp.AttachmentDate = Convert.ToDateTime(dr["ATTACHEMENT_DATE"]);
                        Temp.DocumentTypeId = Convert.ToInt32(dr["BILL_DOCUMENT_TYPE_ID"]);
                        Temp.DocumentType = Convert.ToString(dr["DOCUMENT_TYPE"]);
                        Temp.Url = Convert.ToString(dr["DOCUMENT_URL"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }

        
        #endregion
        #region Bill Document Types
        public List<DocumentTypes> GetDocumentTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_DOCUMENT_TYPES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<DocumentTypes> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<DocumentTypes>();
                    while (dr.Read())
                    {
                        DocumentTypes Temp = new DocumentTypes();
                        Temp.DocumentTypeId = Convert.ToInt32(dr["BILL_DOCUMENT_TYPE_ID"]);
                        Temp.DocumentType = Convert.ToString(dr["DOCUMENT_TYPE"]);
                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion
        #region  Ministers



        public List<Ministers> GetMinistersByName(string MinisterName)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MINISTERS_BY_NAME";
                cmd.Parameters.Add("@MinisterName", SqlDbType.VarChar).Value = MinisterName;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Ministers> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Ministers>();
                    while (dr.Read())
                    {
                        Ministers Temp = new Ministers();
                        Temp.MinisterId = Convert.ToInt32(dr["MINISTER_ID"]);
                        Temp.MinisterName = Convert.ToString(dr["MINISTER_NAME"]);
                        //Temp.PoliticalPartyId = Convert.ToInt32(dr["POLITICAL_PARTY_ID"]);
                        //Temp.PoliticalParty = Convert.ToString(dr["PARTY_NAME"]);
                        //Temp.GenderId = Convert.ToInt32(dr["GENDERS_ID"]);
                        //Temp.Gender = Convert.ToString(dr["GENDER"]);
                        //Temp.PoliticalPartyId = Convert.ToInt32(dr["POLITICAL_PARTY_ID"]);
                        //Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<Ministers> GetActiveMinisters()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_MINISTERS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Ministers> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Ministers>();
                    while (dr.Read())
                    {
                        Ministers Temp = new Ministers();
                        Temp.MinisterId = Convert.ToInt32(dr["MINISTER_ID"]);
                        Temp.MinisterName = Convert.ToString(dr["MINISTER_NAME"]);
                        Temp.PoliticalPartyId = Convert.ToInt32(dr["POLITICAL_PARTY_ID"]);
                        Temp.PoliticalParty = Convert.ToString(dr["PARTY_NAME"]);
                        Temp.GenderId = Convert.ToInt32(dr["GENDERS_ID"]);
                        Temp.Gender = Convert.ToString(dr["GENDER"]);
                        Temp.PoliticalPartyId = Convert.ToInt32(dr["POLITICAL_PARTY_ID"]);
                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<Ministers> GetAllMinisters()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ALL_MINISTERS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Ministers> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Ministers>();
                    while (dr.Read())
                    {
                        Ministers Temp = new Ministers();
                        Temp.MinisterId = Convert.ToInt32(dr["MINISTER_ID"]);
                        Temp.MinisterName = Convert.ToString(dr["MINISTER_NAME"]);
                        Temp.PoliticalPartyId = Convert.ToInt32(dr["POLITICAL_PARTY_ID"]);
                        Temp.PoliticalParty = Convert.ToString(dr["PARTY_NAME"]);
                        Temp.GenderId = Convert.ToInt32(dr["GENDERS_ID"]);
                        Temp.Gender = Convert.ToString(dr["GENDER"]);
                        Temp.PoliticalPartyId = Convert.ToInt32(dr["POLITICAL_PARTY_ID"]);
                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public void UpdateMinister(Ministers Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MINISTER";
                cmd.Parameters.Add("@MinisterId", SqlDbType.Int).Value = Temp.MinisterId;
                cmd.Parameters.Add("@MinisterName", SqlDbType.VarChar).Value = Temp.MinisterName;
                cmd.Parameters.Add("@PoliticalPartyId", SqlDbType.Int).Value = Temp.PoliticalPartyId;
                cmd.Parameters.Add("@GenderId", SqlDbType.Int).Value = Temp.GenderId;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertMinister(Ministers Temp)
        {
            int Id = new DalHelper().GetPk("MINISTERS", "MINISTER_ID");
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MINISTER";
                cmd.Parameters.Add("@MinisterId", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@MinisterName", SqlDbType.VarChar).Value = Temp.MinisterName;
                cmd.Parameters.Add("@PoliticalPartyId", SqlDbType.Int).Value = Temp.PoliticalPartyId;
                cmd.Parameters.Add("@GenderId", SqlDbType.Int).Value = Temp.GenderId;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }

        #endregion
        #region  Political Parties

        public List<PoliticalParty> GetPoliticalParties()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_POLITICAL_PARTIES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<PoliticalParty> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<PoliticalParty>();
                    while (dr.Read())
                    {
                        PoliticalParty Temp = new PoliticalParty();
                        Temp.PartyId = Convert.ToInt32(dr["POLITICAL_PARTIES_ID"]);
                        Temp.PartyName = Convert.ToString(dr["DESCRIPTION"]);
                        Temp.IsActive= Convert.ToInt32(dr["IS_ACTIVE"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }

        #endregion

        #region Bill Status History
        public void InsertBillStatusHistory(BillStatusHistory Temp)
        {
           
             SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_BILL_STATUS_HISTORY";
               
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = Temp.BillsId;
                cmd.Parameters.Add("@BillStatusesID", SqlDbType.Int).Value = Temp.BillStatusesId;
                cmd.Parameters.Add("@StatusDate", SqlDbType.DateTime).Value = Temp.StatusDate;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = Temp.UpdatedById;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public List<BillStatusHistory> GetBillStatusHistory(int BillsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILL_STATUS_HISTORY";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = BillsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<BillStatusHistory> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                   
                    MyList = new List<BillStatusHistory>();
                    while (dr.Read())
                    {
                        BillStatusHistory Temp = new BillStatusHistory();
                        Temp.BillsId = Convert.ToInt32(dr["BILLS_ID"]);
                        Temp.BillStatusesId = Convert.ToInt32(dr["BILL_STATUSES_ID"]);
                        Temp.BillStatus = Convert.ToString(dr["DESCRIPTION"]);
                        Temp.StatusDate = Convert.ToDateTime(dr["STATUS_DATE"]);
                        Temp.UpdatedBy= Convert.ToString(dr["UPDATED_BY_NAME"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion

        #region Ordinance
        public void InsertOrdinance(Ordinances ordinances)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_ORDINANCE";
                cmd.Parameters.Add("@ParliamentaryYearsId", SqlDbType.Int).Value = ordinances.ParliamentaryYearsId;
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = ordinances.AssemblySessionsId;
                cmd.Parameters.Add("@OrdinanceId", SqlDbType.Int).Value = ordinances.OrdinanceId;
                cmd.Parameters.Add("@PromulgateDate", SqlDbType.DateTime).Value = ordinances.DateOfPromulgation;
                cmd.Parameters.Add("@Subject", SqlDbType.VarChar).Value = ordinances.Title;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void UpdateOrdinance(Ordinances ordinances)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_ORDINANCE";
                cmd.Parameters.Add("@OrdinanceId", SqlDbType.Int).Value = ordinances.OrdinanceId;
                cmd.Parameters.Add("@ParliamentaryYearsId", SqlDbType.Int).Value = ordinances.ParliamentaryYearsId;
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = ordinances.AssemblySessionsId;
                cmd.Parameters.Add("@OrdinanceStatusId", SqlDbType.Int).Value = ordinances.OrdinanceStatusId;
                if (ordinances.StatusDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@StatusDate", SqlDbType.DateTime).Value = ordinances.StatusDate;
                if (ordinances.DateOfPromulgation>Convert.ToDateTime("01/01/1900"))
                cmd.Parameters.Add("@PromulgateDate", SqlDbType.DateTime).Value = ordinances.DateOfPromulgation;
                cmd.Parameters.Add("@Subject", SqlDbType.VarChar).Value = ordinances.Title;
                if (ordinances.DateOfLaying > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@LayingDate", SqlDbType.DateTime).Value = ordinances.DateOfLaying;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = ordinances.Remarks;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        protected Ordinances BindOrdinaceFields(SqlDataReader dr)
        {
            Ordinances Temp = new Ordinances();
            Temp.OrdinanceId = Convert.ToInt32(dr["ORDINANCES_ID"]);
            Temp.Title = Convert.ToString(dr["SUBJECT"]);
            if (dr["PROMULGATE_DATE"] != DBNull.Value)
                Temp.DateOfPromulgation = Convert.ToDateTime(dr["PROMULGATE_DATE"]);
            if (dr["LAYING_DATE"] != DBNull.Value)
                Temp.DateOfLaying = Convert.ToDateTime(dr["LAYING_DATE"]);
            if (dr["STATUS_DATE"] != DBNull.Value)
                Temp.StatusDate = Convert.ToDateTime(dr["STATUS_DATE"]);
            if (dr["PARLIAMENTARY_YEARS_ID"] != DBNull.Value)
            {
                Temp.ParliamentaryYearsId = Convert.ToInt32(dr["PARLIAMENTARY_YEARS_ID"]);
                Temp.ParliamentaryYears = new ParliamentaryYears();
                Temp.ParliamentaryYears.ParliamentaryYearsId = Convert.ToInt32(dr["PARLIAMENTARY_YEARS_ID"]);
                Temp.ParliamentaryYears.ParliamentaryYear = Convert.ToString(dr["PARLIAMENTARY_YEAR"]);
            }
            if (dr["ASSEMBLY_SESSIONS_ID"] != DBNull.Value)
            {
                Temp.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);
                Temp.AssemblySessions = new AssemblySessions();
                Temp.AssemblySessions.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);
                Temp.AssemblySessions.SessionNumber = Convert.ToInt32(dr["SESSION_NUMBER"]);
            }
            if (dr["ORDINANCE_STATUS_ID"] != DBNull.Value)
            {
                Temp.OrdinanceStatusId = Convert.ToInt32(dr["ORDINANCE_STATUS_ID"]);
                Temp.OrdinanceStatuses = new OrdinanceStatuses();
                Temp.OrdinanceStatuses.OrdinanceStatusId = Convert.ToInt32(dr["ORDINANCE_STATUS_ID"]);
                Temp.OrdinanceStatuses.OrdinanceStatus = Convert.ToString(dr["ORDINANCE_STATUS"]);
            }
            Temp.Remarks = Convert.ToString(dr["REMARKS"]);
            return Temp;
        }
        public List<Ordinances> GetOrdinances(int ParliamentaryYearsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ORDINANCES";
                cmd.Parameters.Add("@ParliamentaryYearsId", SqlDbType.Int).Value = ParliamentaryYearsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Ordinances> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {

                    MyList = new List<Ordinances>();
                    while (dr.Read())
                    {
                        MyList.Add(BindOrdinaceFields(dr));
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public Ordinances GetOrdinance(int OrdinanceId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ORDINANCE";
                cmd.Parameters.Add("@OrdinanceId", SqlDbType.Int).Value = OrdinanceId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                Ordinances Temp = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = BindOrdinaceFields(dr);
                }
                return Temp;
            }
            finally
            {
                con.Close();

            }

        }
        public List<Ordinances> SearchOrdinance(string query)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                List<Ordinances> ordinances = null;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                using (con)
                {
                    if (dr.HasRows)
                    {
                        ordinances = new List<Ordinances>();
                        while (dr.Read())
                        {
                            Ordinances Temp = BindOrdinaceFields(dr);
                            ordinances.Add(Temp);
                        }
                    }

                }
                return ordinances;
            }
            finally
            {
                con.Close();
            }

        }
        #endregion


        #region Ordinance Documents
        public void InsertOrdinanceDocument(OrdinanceDocuments OrdinanceDocuments)
        {
            //int id = new DalHelper().GetPk("BILL_DOCUMENTS", "BILL_DOCUMENTS_ID");
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_ORDINANCE_DOCUMENT";
                cmd.Parameters.Add("@OrdinanceDocumentId", SqlDbType.Int).Value = OrdinanceDocuments.OrdinanceDocumentsId;
                cmd.Parameters.Add("@OrdinanceId", SqlDbType.Int).Value = OrdinanceDocuments.OrdinancesId;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = OrdinanceDocuments.Description;
                cmd.Parameters.Add("@Url", SqlDbType.VarChar).Value = OrdinanceDocuments.DocumentUrl;
                cmd.Parameters.Add("@DocumentDate", SqlDbType.DateTime).Value = OrdinanceDocuments.AttachmentDate;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }

        public void UpdateOrdinanceDocument(OrdinanceDocuments OrdinanceDocuments)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_ORDINANCE_DOCUMENTS";
                cmd.Parameters.Add("@OrdinanceDocumentId", SqlDbType.Int).Value = OrdinanceDocuments.OrdinanceDocumentsId;
                cmd.Parameters.Add("@OrdinanceId", SqlDbType.Int).Value = OrdinanceDocuments.OrdinancesId;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = OrdinanceDocuments.Description;
                cmd.Parameters.Add("@Url", SqlDbType.VarChar).Value = OrdinanceDocuments.DocumentUrl;
                cmd.Parameters.Add("@DocumentDate", SqlDbType.VarChar).Value = OrdinanceDocuments.AttachmentDate;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void DeleteOrdinanceDocument(int OrdinanceDocumentsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_ORDINANCE_DOCUMENT";
                cmd.Parameters.Add("@OrdinanceDocumentId", SqlDbType.Int).Value = OrdinanceDocumentsId;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }

        public List<OrdinanceDocuments> GetOrdinanceDocuments(int OrdinanceId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ORDINANCE_DOCUMENTS";
                cmd.Parameters.Add("@OrdinanceId", SqlDbType.Int).Value = OrdinanceId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<OrdinanceDocuments> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<OrdinanceDocuments>();
                    while (dr.Read())
                    {
                        OrdinanceDocuments Temp = new OrdinanceDocuments();
                        Temp.OrdinanceDocumentsId = Convert.ToInt32(dr["ORDINANCE_DOCUMENTS_ID"]);
                        //Temp.DocumentTypeId = Convert.ToInt32(dr["DOCUMENT_TYPE_ID"]);
                        Temp.OrdinancesId = Convert.ToInt32(dr["ORDINANCES_ID"]);
                        Temp.Description = Convert.ToString(dr["DESCRIPTION"]);
                        Temp.DocumentUrl = Convert.ToString(dr["DOCUMENT_URL"]);
                        Temp.AttachmentDate = Convert.ToDateTime(dr["ATTACHEMENT_DATE"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public OrdinanceDocuments GetOrdinanceDocument(int DocumentId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ORDINANCE_DOCUMENT";
                cmd.Parameters.Add("@OrdinanceDocumentId", SqlDbType.Int).Value = DocumentId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                OrdinanceDocuments Temp = null;
                if (dr.HasRows)
                {
                    dr.Read();
                        Temp = new OrdinanceDocuments();
                        Temp.OrdinanceDocumentsId = Convert.ToInt32(dr["ORDINANCE_DOCUMENTS_ID"]);
                        //Temp.DocumentTypeId = Convert.ToInt32(dr["DOCUMENT_TYPE_ID"]);
                        Temp.OrdinancesId = Convert.ToInt32(dr["ORDINANCES_ID"]);
                        Temp.Description = Convert.ToString(dr["DESCRIPTION"]);
                        Temp.DocumentUrl = Convert.ToString(dr["DOCUMENT_URL"]);
                        Temp.AttachmentDate = Convert.ToDateTime(dr["ATTACHEMENT_DATE"]);
                }

                return Temp;
            }
            finally
            {
                con.Close();

            }
        }


        #endregion
        #region Ordinance Statuses
        public List<OrdinanceStatuses> GetOrdinanceStatuses()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ORDINANCE_STATUSES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<OrdinanceStatuses> ordinanceStatuses = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        ordinanceStatuses = new List<OrdinanceStatuses>();
                        while (dr.Read())
                        {
                            OrdinanceStatuses ad = new OrdinanceStatuses();
                            ad.OrdinanceStatusId = Convert.ToInt32(dr["ORDINANCE_STATUS_ID"]);
                            ad.OrdinanceStatus = Convert.ToString(dr["ORDINANCE_STATUS"]);
                            ad.IsActive = Convert.ToInt32(dr["IS_ACTVE"]);
                            ordinanceStatuses.Add(ad);
                        }
                    }
                }
                if (ordinanceStatuses != null) ordinanceStatuses.TrimExcess();
                return ordinanceStatuses;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion

        #region Status History
        public void InsertOrdinanceStatusHistory(OrdinanceStatusHistory history)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try 
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_ORDINANCE_STATUS_HISTORY";
                cmd.Parameters.Add("@StatusHistoryId", SqlDbType.Int).Value = history.OrdinanceStatusHistId;
                cmd.Parameters.Add("@OrdinanceId", SqlDbType.Int).Value = history.OrdinanceId;
                cmd.Parameters.Add("@OrdinanceStatusId", SqlDbType.Int).Value = history.OrdinanceStatusesId;
                cmd.Parameters.Add("@StatusDate", SqlDbType.DateTime).Value = history.StatusDate;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public List<OrdinanceStatusHistory> GetOrdinanceStatusHistory(int OrdinanceId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ORDINANCE_STATUS_HISTORY";
                cmd.Parameters.Add("@OrdinanceId", SqlDbType.Int).Value = OrdinanceId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<OrdinanceStatusHistory> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<OrdinanceStatusHistory>();
                    while (dr.Read())
                    {
                        OrdinanceStatusHistory Temp = new OrdinanceStatusHistory();
                        Temp.OrdinanceStatusHistId = Convert.ToInt32(dr["ORD_STATUS_HISTORY_ID"]);
                        Temp.OrdinanceId = Convert.ToInt32(dr["ORDINANCE_ID"]);
                        Temp.OrdinanceStatusesId = Convert.ToInt32(dr["STATUS_ID"]);
                        Temp.OrdinanceStatus = Convert.ToString(dr["ORDINANCE_STATUS"]);
                        Temp.StatusDate = Convert.ToDateTime(dr["STATUS_DATE"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion


        #region OD
        #region OD SITTINGS
        public List<SessionSittings> GetSittingsFortOrdersOfDay(int assemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);

                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SITTINGS_FOR_OD";
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value =
                    assemblySessionsId;

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                List<SessionSittings> sessionSittings = null;

                if (dr.HasRows)
                {
                    sessionSittings = new List<SessionSittings>();

                    while (dr.Read())
                    {
                        SessionSittings temp = new SessionSittings();

                        temp.SessionSittingsId =
                            Convert.ToInt32(dr["SESSION_SITTINGS_ID"]);

                      

                        temp.Description =
                            Convert.ToString(dr["SITTING"]);


                        sessionSittings.Add(temp);
                    }
                }

                return sessionSittings;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion OD SITTINGS
  
        #region ORDER OF THE DAY TYPES

        public List<OrderOfDayType> GetOrderOfDayTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);

                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value =
                    "GET_ALL_OD_TYPES";

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                List<OrderOfDayType> orderOfDayTypes = new List<OrderOfDayType>();

                while (dr.Read())
                {
                    OrderOfDayType temp = new OrderOfDayType();

                    temp.OrderOfDayTypesId =
                        Convert.ToInt32(dr["ORDER_OF_DAY_TYPES_ID"]);

                    temp.Description =
                        Convert.ToString(dr["DESCRIPTION"]);

                    temp.IsActive =
                        Convert.ToInt32(dr["IS_ACTIVE"]) == 1;

                    orderOfDayTypes.Add(temp);
                }

                return orderOfDayTypes;
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }


        public OrderOfDayType GetOrderOfDayTypeById(int odTypeId)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);

                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value =
                    "GET_OD_TYPE_BY_ID";

                cmd.Parameters.Add("@OdTypeId", SqlDbType.Int).Value =
                    odTypeId;

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                OrderOfDayType orderOfDayType = null;

                if (dr.Read())
                {
                    orderOfDayType = new OrderOfDayType();

                    orderOfDayType.OrderOfDayTypesId =
                        Convert.ToInt32(dr["ORDER_OF_DAY_TYPES_ID"]);

                    orderOfDayType.Description =
                        Convert.ToString(dr["DESCRIPTION"]);

                    orderOfDayType.IsActive =
                        Convert.ToInt32(dr["IS_ACTIVE"]) == 1;
                }

                return orderOfDayType;
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }


        public int GetMaxOrderOfDayTypeId()
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);

                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value =
                    "GET_MAX_OD_TYPE_ID";

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                int maxId = 0;

                if (dr.Read() && dr["MAX_ID"] != DBNull.Value)
                {
                    maxId = Convert.ToInt32(dr["MAX_ID"]);
                }

                return maxId;
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }


        public void InsertOrderOfDayType(OrderOfDayType orderOfDayType)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);

                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value =
                    "INSERT_OD_TYPE";

                cmd.Parameters.Add("@OdTypeId", SqlDbType.Int).Value =
                    orderOfDayType.OrderOfDayTypesId;

                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value =
                    orderOfDayType.Description;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }


        public void UpdateOrderOfDayType(OrderOfDayType orderOfDayType)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);

                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value =
                    "UPDATE_OD_TYPE";

                cmd.Parameters.Add("@OdTypeId", SqlDbType.Int).Value =
                    orderOfDayType.OrderOfDayTypesId;

                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value =
                    orderOfDayType.Description;

                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value =
                    orderOfDayType.IsActive ? 1 : 0;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion ORDER OF THE DAY TYPES

        #region ORDERS OF THE DAY

        public List<OrderOfDay> GetOrdersOfDayBySession(int assemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);

                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_OD_BY_SESSION";
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value =
                    assemblySessionsId;

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                List<OrderOfDay> ordersOfDay = null;

                if (dr.HasRows)
                {
                    ordersOfDay = new List<OrderOfDay>();

                    while (dr.Read())
                    {
                        OrderOfDay temp = new OrderOfDay();

                        temp.OrderOfDaysId =
                            Convert.ToInt32(dr["ORDER_OF_DAYS_ID"]);
                        temp.SittingDayDescription=
                             Convert.ToString(dr["SITTING_DESCRIPTION"]);

                        temp.SessionSittingsId =
                            Convert.ToInt32(dr["SESSION_SITTINGS_ID"]);

                        temp.OrderOfDayTypesId =
                            Convert.ToInt32(dr["ORDER_OF_DAY_TYPES_ID"]);
                        if (dr["MAIN_ORDER_DESCRIPTION"] != DBNull.Value)
                            temp.MainOrderDescription =
                            Convert.ToString(dr["MAIN_ORDER_DESCRIPTION"]);
                        if (dr["SUPPLEMENTARY_ORDER_DESC"] != DBNull.Value)
                            temp.SupplementaryOrderDesc =
                            Convert.ToString(dr["SUPPLEMENTARY_ORDER_DESC"]);

                        temp.IsActive =
                            Convert.ToInt32(dr["IS_ACTIVE"]);

                        if (dr["SITTING_DATE"] != DBNull.Value)
                        {
                            temp.SittingDate =
                                Convert.ToDateTime(dr["SITTING_DATE"]);
                        }

                        temp.AssemblySessionsId =
                            Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);

                        ordersOfDay.Add(temp);
                    }
                }

                return ordersOfDay;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public OrderOfDay GetActiveOrdersOfDayByCurrentSession()
        {
            AssemblySessions assemblySessions = new LegislationDal().GetCurrentAssemblySessionDetails();
            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);

                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_OD_OF_CURRENT_SESSION";
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = 10010;
                   // assemblySessions.AssemblySessionsId;

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                OrderOfDay temp = new OrderOfDay();

                if (dr.HasRows)
                {
                    dr.Read();
                        temp.OrderOfDaysId =
                            Convert.ToInt32(dr["ORDER_OF_DAYS_ID"]);
                        temp.SittingDayDescription =
                             Convert.ToString(dr["SITTING_DESCRIPTION"]);

                        temp.SessionSittingsId =
                            Convert.ToInt32(dr["SESSION_SITTINGS_ID"]);

                        temp.OrderOfDayTypesId =
                            Convert.ToInt32(dr["ORDER_OF_DAY_TYPES_ID"]);
                        if (dr["MAIN_ORDER_DESCRIPTION"] != DBNull.Value)
                            temp.MainOrderDescription =
                            Convert.ToString(dr["MAIN_ORDER_DESCRIPTION"]);
                        if (dr["SUPPLEMENTARY_ORDER_DESC"] != DBNull.Value)
                            temp.SupplementaryOrderDesc =
                            Convert.ToString(dr["SUPPLEMENTARY_ORDER_DESC"]);

                        temp.IsActive =
                            Convert.ToInt32(dr["IS_ACTIVE"]);

                        if (dr["SITTING_DATE"] != DBNull.Value)
                        {
                            temp.SittingDate =
                                Convert.ToDateTime(dr["SITTING_DATE"]);
                        }

                        temp.AssemblySessionsId =
                            Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);

                       
                }

                return temp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public OrderOfDay GetOrderOfDayById(int odId)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);

                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_OD_BY_OD_ID";
                cmd.Parameters.Add("@OdId", SqlDbType.Int).Value = odId;

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                OrderOfDay orderOfDay = null;

                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        orderOfDay = new OrderOfDay();

                        orderOfDay.OrderOfDaysId =
                            Convert.ToInt32(dr["ORDER_OF_DAYS_ID"]);

                        orderOfDay.SessionSittingsId =
                            Convert.ToInt32(dr["SESSION_SITTINGS_ID"]);

                        orderOfDay.OrderOfDayTypesId =
                            Convert.ToInt32(dr["ORDER_OF_DAY_TYPES_ID"]);

                        orderOfDay.MainOrderDescription =
                            Convert.ToString(dr["MAIN_ORDER_DESCRIPTION"]);

                        orderOfDay.SupplementaryOrderDesc =
                            Convert.ToString(dr["SUPPLEMENTARY_ORDER_DESC"]);

                        orderOfDay.IsActive =
                            Convert.ToInt32(dr["IS_ACTIVE"]);

                        if (dr["SITTING_DATE"] != DBNull.Value)
                        {
                            orderOfDay.SittingDate =
                                Convert.ToDateTime(dr["SITTING_DATE"]);
                        }

                        orderOfDay.AssemblySessionsId =
                            Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);
                    }
                }

                return orderOfDay;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public int GetMaxOrderOfDayId()
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);

                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MAX_OD_ID";

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                int maxId = 0;

                if (dr.HasRows)
                {
                    if (dr.Read() && dr["MAX_ID"] != DBNull.Value)
                    {
                        maxId = Convert.ToInt32(dr["MAX_ID"]);
                    }
                }

                return maxId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public void InsertOrderOfDay(OrderOfDay orderOfDay)
        {
            SqlConnection con = new DalHelper().GetConnection();
            int Id = new DalHelper().GetPk("ORDER_OF_DAYS", "ORDER_OF_DAYS_ID");

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);

                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_OD";

                cmd.Parameters.Add("@OdId", SqlDbType.Int).Value = Id;

                cmd.Parameters.Add("@SittingNumber", SqlDbType.Int).Value =
                    orderOfDay.SessionSittingsId;

                cmd.Parameters.Add("@OdTypeId", SqlDbType.Int).Value =
                    orderOfDay.OrderOfDayTypesId;

                cmd.Parameters.Add("@OdMainDescription", SqlDbType.VarChar).Value =
                    orderOfDay.MainOrderDescription;

                cmd.Parameters.Add("@OdSupplementaryDescription", SqlDbType.VarChar).Value =
                    orderOfDay.SupplementaryOrderDesc;

                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value =
                    orderOfDay.IsActive;

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public void UpdateOrderOfDay(OrderOfDay orderOfDay)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);

                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_OD";

                cmd.Parameters.Add("@OdId", SqlDbType.Int).Value =
                    orderOfDay.OrderOfDaysId;

                cmd.Parameters.Add("@SittingNumber", SqlDbType.Int).Value =
                    orderOfDay.SessionSittingsId;

                cmd.Parameters.Add("@OdTypeId", SqlDbType.Int).Value =
                    orderOfDay.OrderOfDayTypesId;

                cmd.Parameters.Add("@OdMainDescription", SqlDbType.VarChar).Value =
                    orderOfDay.MainOrderDescription;

                cmd.Parameters.Add("@OdSupplementaryDescription", SqlDbType.VarChar).Value =
                    orderOfDay.SupplementaryOrderDesc;

                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value =
                    orderOfDay.IsActive;

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion ORDERS OF THE DAY
        #region BUSINESS TYPE 
        public List<BusinessType> GetBusinessTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);

                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value ="GET_BUSINESS_TYPES";

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                List<BusinessType> businesses = null;

                if (dr.HasRows)
                {
                    businesses = new List<BusinessType>();

                    while (dr.Read())
                    {
                        BusinessType temp =
                            new BusinessType();

                        temp.BusinessTypeId =
                            Convert.ToInt32(dr["BUSINESS_TYPES_ID"]);

                        temp.Description =
                            Convert.ToString(dr["DESCRIPTION"]);

                        temp.Rule =
                           Convert.ToString(dr["BUSINESS_RULE"]);
                        temp.IsActive =
                          Convert.ToInt32(dr["IS_ACTIVE"]);


                        temp.SortOrder =
                            Convert.ToInt32(dr["SORT_ORDER"]);

                        businesses.Add(temp);
                    }
                }

                return businesses;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region ORDERS OF THE DAY BUSINESS

        public List<OrderOfTheDayBusiness> GetOrderOfTheDayBusiness(int odId)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);

                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value =
                    "GET_OD_BUSINESS";

                cmd.Parameters.Add("@OdId", SqlDbType.Int).Value = odId;

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                List<OrderOfTheDayBusiness> businesses = null;

                if (dr.HasRows)
                {
                    businesses = new List<OrderOfTheDayBusiness>();

                    while (dr.Read())
                    {
                        OrderOfTheDayBusiness temp =
                            new OrderOfTheDayBusiness();

                        temp.OrderOfDayBusinessId =
                            Convert.ToInt32(dr["ORDER_OF_DAY_BUSINESS_ID"]);

                        temp.OrderOfDayId =
                            Convert.ToInt32(dr["ORDER_OF_DAY_ID"]);

                        temp.BusinessTypesId =
                            Convert.ToInt32(dr["BUSINESS_TYPES_ID"]);

                        temp.Description =
                            Convert.ToString(dr["DESCRIPTION"]);

                        temp.SortOrder =
                            Convert.ToInt32(dr["SORT_ORDER"]);

                        temp.BusinessTypesDescription =
                            Convert.ToString(dr["BUSINESS_TYPES_DESCRIPTION"]);

                        temp.BusinessRule =
                            Convert.ToString(dr["BUSINESS_RULE"]);

                        temp.TypeSortOrder =
                            Convert.ToInt32(dr["TYPE_SORT_ORDER"]);
                        temp.Attachemnts = new List<OrderOfDayBusinessAttachment>();
                        temp.Attachemnts = GetOrderOfDayBusinessAttachments(temp.OrderOfDayBusinessId);
                        businesses.Add(temp);
                    }
                }

                return businesses;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public OrderOfTheDayBusiness GetOrderOfTheDayBusinessById(
            int odBusinessId)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);

                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value =
                    "GET_OD_BUSINESS_BY_ID";

                cmd.Parameters.Add("@OdBusinessId", SqlDbType.Int).Value =
                    odBusinessId;

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                OrderOfTheDayBusiness business = null;

                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        business = new OrderOfTheDayBusiness();

                        business.OrderOfDayBusinessId =
                            Convert.ToInt32(dr["ORDER_OF_DAY_BUSINESS_ID"]);

                        business.OrderOfDayId =
                            Convert.ToInt32(dr["ORDER_OF_DAY_ID"]);

                        business.BusinessTypesId =
                            Convert.ToInt32(dr["BUSINESS_TYPES_ID"]);

                        business.Description =
                            Convert.ToString(dr["DESCRIPTION"]);

                        business.SortOrder =
                            Convert.ToInt32(dr["SORT_ORDER"]);

                        business.BusinessTypesDescription =
                            Convert.ToString(dr["BUSINESS_TYPES_DESCRIPTION"]);

                        business.BusinessRule =
                            Convert.ToString(dr["BUSINESS_RULE"]);

                        business.TypeSortOrder =
                            Convert.ToInt32(dr["TYPE_SORT_ORDER"]);
                    }
                }

                return business;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public int GetMaxOrderOfTheDayBusinessId()
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);

                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value =
                    "GET_MAX_OD_BUSINESS_ID";

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                int maxId = 0;

                if (dr.HasRows)
                {
                    if (dr.Read() && dr["MAX_ID"] != DBNull.Value)
                    {
                        maxId = Convert.ToInt32(dr["MAX_ID"]);
                    }
                }

                return maxId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public int InsertOrderOfTheDayBusiness(
            OrderOfTheDayBusiness business)
        {
            SqlConnection con = new DalHelper().GetConnection();
            int Id = new DalHelper().GetPk("ORDER_OF_THE_DAY_BUSINESS", "ORDER_OF_DAY_BUSINESS_ID");
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);

                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value =
                    "INSERT_OD_BUSINESS";

                cmd.Parameters.Add("@OdBusinessId", SqlDbType.Int).Value = Id;

                cmd.Parameters.Add("@OdId", SqlDbType.Int).Value =
                    business.OrderOfDayId;

                cmd.Parameters.Add("@BusinessTypeId", SqlDbType.Int).Value =
                    business.BusinessTypesId;

                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value =
                    business.Description;

                cmd.Parameters.Add("@SortOrder", SqlDbType.Int).Value =
                    business.SortOrder;

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                return Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public void UpdateOrderOfTheDayBusiness(
            OrderOfTheDayBusiness business)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);

                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value =
                    "UPDATE_OD_BUSINESS";

                cmd.Parameters.Add("@OdBusinessId", SqlDbType.Int).Value =
                    business.OrderOfDayBusinessId;

                cmd.Parameters.Add("@BusinessTypeId", SqlDbType.Int).Value =
                    business.BusinessTypesId;

                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value =
                    business.Description;

                cmd.Parameters.Add("@SortOrder", SqlDbType.Int).Value =
                    business.SortOrder;

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public void DeleteOrderOfTheDayBusiness(int odBusinessId)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);

                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value =
                    "DELETE_OD_BUSINESS";

                cmd.Parameters.Add("@OdBusinessId", SqlDbType.Int).Value =
                    odBusinessId;

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion ORDERS OF THE DAY BUSINESS
        #region ORDERS OF THE DAY BUSINESS ATTACHMENTS

        public List<OrderOfDayBusinessAttachment> GetOrderOfDayBusinessAttachments(
            int odBusinessId)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);

                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value =
                    "GET_OD_BUSINESS_ATTACHMENTS";

                cmd.Parameters.Add("@OdBusinessId", SqlDbType.Int).Value =
                    odBusinessId;

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                List<OrderOfDayBusinessAttachment> attachments = null;

                if (dr.HasRows)
                {
                    attachments =
                        new List<OrderOfDayBusinessAttachment>();

                    while (dr.Read())
                    {
                        OrderOfDayBusinessAttachment temp =
                            new OrderOfDayBusinessAttachment();

                        temp.OrderOfDayAttachmentsId =
                            Convert.ToInt32(dr["ORDER_OF_DAY_ATTACHMENTS_ID"]);

                        temp.OrderOfDayBusinessId =
                            Convert.ToInt32(dr["ORDER_OF_DAY_BUSINESS_ID"]);

                        temp.Attachment =
                            Convert.ToString(dr["ATTACHMENT"]);

                        attachments.Add(temp);
                    }
                }

                return attachments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public int GetMaxOrderOfDayBusinessAttachmentId()
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);

                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value =
                    "GET_MAX_OD_BUSINESS_ATTACHMENT_ID";

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                int maxId = 0;

                if (dr.HasRows)
                {
                    if (dr.Read() && dr["MAX_ID"] != DBNull.Value)
                    {
                        maxId = Convert.ToInt32(dr["MAX_ID"]);
                    }
                }

                return maxId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public void InsertOrderOfDayBusinessAttachment(
            OrderOfDayBusinessAttachment attachment)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);

                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value =
                    "INSERT_OD_BUSINESS_ATTACHMENT";

                cmd.Parameters.Add("@OdAttachmentId", SqlDbType.Int).Value =
                    attachment.OrderOfDayAttachmentsId;

                cmd.Parameters.Add("@OdBusinessId", SqlDbType.Int).Value =
                    attachment.OrderOfDayBusinessId;

                cmd.Parameters.Add("@Attachment", SqlDbType.VarChar).Value =
                    attachment.Attachment;

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public void UpdateOrderOfDayBusinessAttachment(
            OrderOfDayBusinessAttachment attachment)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);

                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value =
                    "UPDATE_OD_BUSINESS_ATTACHMENT";

                cmd.Parameters.Add("@OdAttachmentId", SqlDbType.Int).Value =
                    attachment.OrderOfDayAttachmentsId;

                cmd.Parameters.Add("@OdBusinessId", SqlDbType.Int).Value =
                    attachment.OrderOfDayBusinessId;

                cmd.Parameters.Add("@Attachment", SqlDbType.VarChar).Value =
                    attachment.Attachment;

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public void DeleteOrderOfDayBusinessAttachments(
            int OdBusinessId)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);

                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value =
                    "DELETE_OD_BUSINESS_ATTACHMENTS";

                cmd.Parameters.Add("@OdBusinessId", SqlDbType.Int).Value =
                    OdBusinessId;

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public void DeleteOrderOfDayBusinessAttachmentById(
          int odAttachmentId)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);

                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value =
                    "DELETE_OD_BUSINESS_ATTACHMENT_BY_ID";

                cmd.Parameters.Add("@OdAttachmentId", SqlDbType.Int).Value =
                    odAttachmentId;

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion ORDERS OF THE DAY BUSINESS ATTACHMENTS




        #endregion OD


    }
}