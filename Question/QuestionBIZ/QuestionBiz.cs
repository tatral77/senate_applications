using Entities;
using QuestionDAL;
using System;
using System.Collections.Generic;

namespace QuestionBIZ
{
    public class QuestionBiz
    {

        #region  GroupDivisions

        public List<GroupDivisions> GetGroupDivisions(int AssemblySessionId)
        {
            return new QuestionDal().GetGroupDivisions(AssemblySessionId);
        }
        public List<GroupDivisions> GetSingleGroupDivisions(int AssemblySessionId, int GroupSequenceId)
        {
            return new QuestionDal().GetSingleGroupDivisions(AssemblySessionId, GroupSequenceId);
        }

        //public void UpdateGroupDivision(GroupDivisions Temp)
        //{
        //    new QuestionDal().UpdateGroupDivision(Temp);
        //}
        public void InsertGroupDivisions(GroupDivisions Temp)
        {
            new QuestionDal().InsertGroupDivisions(Temp);
        }
        public void DeleteGroupDivisions(int GroupsId, int DivisionsId)
        {
            new QuestionDal().DeleteGroupDivisions(GroupsId, DivisionsId);
        }
        public List<Divisions> GetUnAssignedDivisions(int AssemblySessionsId)
        {
            return new QuestionDal().GetUnAssignedDivisions(AssemblySessionsId);
        }
        #endregion Divisions



        //------------------------------------END-------------------------------------//

        #region  Groups

        public List<Groups> GetSessionGroups(int AssemblySessionsId, int CategoryId)
        {
            return new QuestionDal().GetSessionGroups(AssemblySessionsId, CategoryId);
        }
        public void UpdateGroups(Groups Temp)
        {
            new QuestionDal().UpdateGroups(Temp);
        }
        public void InsertGroups(Groups Temp)
        {
            new QuestionDal().InsertGroups(Temp);
        }
        public List<Groups> GetSessionCorrespondingGroup(int AssemplySessionsId, int CorrespondingGroupId)
        {
            return new QuestionDal().GetSessionCorrespondingGroups(AssemplySessionsId, CorrespondingGroupId);
        }
        public Groups GetGroupById(int GroupId)
        {
            return new QuestionDal().GetGroupById(GroupId);
        }

        #endregion Groups

        //------------------------------------END-------------------------------------//


        //------------------------------------END-------------------------------------//

        #region Questions

        public List<Questions> GetQuestions(int AssemblySessionsId)
        {
            return new QuestionDal().GetQuestions(AssemblySessionsId);


        }
        public List<Questions> GetDeletedQuestions()
        {
            return new QuestionDal().GetDeletedQuestions();


        }
        public List<Questions> GetNoticeQuestions(int AssemblySessionsId)
        {
            return new QuestionDal().GetNoticeQuestions(AssemblySessionsId);
        }
        public List<Questions> GetRevivedQuestions(int AssemblySessionsId)
        {
            return new QuestionDal().GetRevivedQuestions(AssemblySessionsId);
        }
        public List<Questions> GetDuplicateQuestions(int AssemblySessionsId)
        {
            return new QuestionDal().GetDuplicateQuestions(AssemblySessionsId);
        }
        public List<Questions> GetTranslationQuestions(int AssemblySessionsId)
        {
            return new QuestionDal().GetTranslationQuestions(AssemblySessionsId);
        }
        public List<Questions> GetTranslatedQuestions(int AssemblySessionsId)
        {
            return new QuestionDal().GetTranslatedQuestions(AssemblySessionsId);
        }
        public void SendForTranslation(int QuestionId, int UserId)
        {
            new QuestionDal().SendForTranslation(QuestionId, UserId);
        }
        public void SetNoticeQuestionRevived(int QuestionId, int ReviveQuestionId)
        {
            new QuestionDal().SetNoticeQuestionRevived(QuestionId, ReviveQuestionId);
        }
        public void SetNoticeQuestionCheckedStatus(int QuestionId, int Status)
        {
            new QuestionDal().SetNoticeQuestionCheckedStatus(QuestionId, Status);
        }
        public void ApproveTranslation(int QuestionId, int UserId)
        {
            new QuestionDal().ApproveTranslation(QuestionId, UserId);
        }
        public List<Questions> GetQuestionsByStatus(int AssemblySessionsId, int StatusId)
        {
            return new QuestionDal().GetQuestionsByStatus(AssemblySessionsId, StatusId);
        }
        public Questions GetQuestionById(int QuestionId)
        {
            return new QuestionDal().GetQuestionById(QuestionId);
        }
        public Questions GetQuestionByIdMin(int QuestionId)
        {
            return new QuestionDal().GetQuestionByIdMin(QuestionId);
        }
        public Questions GetNoticeQuestionByIdMin(int QuestionId)
        {
            return new QuestionDal().GetNoticeQuestionByIdMin(QuestionId);
        }

        public void UpdateQuestions(Questions Temp)
        {
            new QuestionDal().UpdateQuestions(Temp);
        }

        public void UpdateSORemarks(Questions Temp)
        {
            new QuestionDal().UpdateSORemarks(Temp);
        }

        public int InsertQuestions(Questions Temp)
        {
            return new QuestionDal().InsertQuestions(Temp);
        }
        public int InsertNoticeQuestions(Questions Temp)
        {
            return new QuestionDal().InsertNoticeQuestions(Temp);
        }
        public int CopyQuestion(Questions Temp)
        {
            return new QuestionDal().CopyQuestion(Temp);
        }
        public List<Questions> SearchQuestion(string query)
        {
            return new QuestionDal().SearchQuestion(query);
        }
        public void MoveQuestion(int CurrentSession, Questions Temp)
        {
            new QuestionDal().MoveQuestion(CurrentSession, Temp);
        }


        #endregion Questions
        public int GetMemberGroupQuestionsByStatus(int MemberId, int GroupId, int QuestionCategoryId, int StatusId)
        {
            return new QuestionDal().GetMemberGroupQuestionsByStatus(MemberId, GroupId, QuestionCategoryId, StatusId);
        }
        public void DeleteQuestion(int QuestionId, int DeletedBy)
        {
            new QuestionDal().DeleteQuestion(QuestionId, DeletedBy);
        }
        public void RecoverQuestion(int QuestionId, int RecoveredBy)
        {
            new QuestionDal().RecoverQuestion(QuestionId, RecoveredBy);
        }
        public void RecoverDuplicateQuestion(int QuestionId, int RecoveredBy)
        {
            new QuestionDal().RecoverDuplicateQuestion(QuestionId, RecoveredBy);
        }

        public void UpdateQuestionStatusHistory(QuestionStatusHistory Temp)
        {
            new QuestionDal().UpdateQuestionStatusHistory(Temp);
        }

        public List<QuestionStatusHistory> GetQuestionStatusHistory(int QuestionIdentifier)
        {
            return new QuestionDal().GetQuestionStatusHistory(QuestionIdentifier);

        }
        public void InsertQuestionStatusHistory(QuestionStatusHistory Temp)
        {
            new QuestionDal().InsertQuestionStatusHistory(Temp);
        }
        public void InsertQuestionMovementHistory(QuestionMovementHistory Temp)
        {
            new QuestionDal().InsertQuestionMovementHistory(Temp);
        }
        public void UpdateQuestionMovementHistory(QuestionMovementHistory Temp)
        {
            new QuestionDal().UpdateQuestionMovementHistory(Temp);
        }

        public List<QuestionMovementHistory> GetQuestionMovementHistory(int QuestionIdentifier)
        {
            return new QuestionDal().GetQuestionMovementHistory(QuestionIdentifier);
        }
        public string GetMemberNameById(int MemberId)
        {
            return new AdministrationDAL().GetMemberNameById(MemberId);
        }

        #region ROTA
       
        public List<RotaWeekDays> GetRotaWeekDays()
        {
            return new QuestionDal().GetRotaWeekDays();
        }

        public RotaWeekDays GetRotaWeekDay(int Id)
        {
            return new QuestionDal().GetRotaWeekDay(Id);
        }
        public QuestionsRota GetRota(int AssemblySessionsId)
        {
            return new QuestionDal().GetRota(AssemblySessionsId);
        }
        public void InsertRota(QuestionsRota rota)
        {
            new QuestionDal().InsertRota(rota);
        }
        public void UpdateRota(QuestionsRota rota)
        {
            new QuestionDal().UpdateRota(rota);
        }
       
            #endregion ROTA

            public void CopySessionGroups(int CurrentSession, int PreviousSession)
        {
            new QuestionDal().CopySessionGroups(CurrentSession, PreviousSession);
        }
        public void LapseQuestion(int AssemblySessionsId)
        {
            new QuestionDal().LapseQuestion(AssemblySessionsId);
        }
        public void LapseMotion(int AssemblySessionsId)
        {
            new QuestionDal().LapseMotion(AssemblySessionsId);
        }

        public void LapseResolution(int AssemblySessionsId)
        {
            new QuestionDal().LapseResolution(AssemblySessionsId);
        }
        public void DeferQuestions(DeferQuestion df)
        {
            new QuestionDal().DeferQuestions(df);
        }
        public List<ListQuestion> GetAllDeferedQuestions(int AssemblySessionId)
        {
            return new QuestionDal().GetAllDeferedQuestions(AssemblySessionId);
        }
        public List<DeferQuestion> GetQuestionDeferment(int QuestionIdentifier)
        {
            return new QuestionDal().GetQuestionDeferment(QuestionIdentifier);
        }
        public int CheckQuestionDeferment(int QuestionId, int AssemblySessionId)
        {
            return new QuestionDal().CheckQuestionDeferment(QuestionId, AssemblySessionId);
        }
        public void DeleteDeferedQuestion(int DeferId)
        {
            new QuestionDal().DeleteDeferedQuestion(DeferId);
        }

        #region QUESTION LIST
        public List<ListQuestion> GetDeferedQuestions(int AssemblySessionId, int GroupId, int CategoryId)
        {
            return new QuestionDal().GetDeferedQuestions(AssemblySessionId, GroupId, CategoryId);
        }
        public List<ListQuestion> GetListQuestions(int AssemblySessionId, int GroupId, int CategoryId)
        {
            return new QuestionDal().GetListQuestions(AssemblySessionId, GroupId, CategoryId);
        }
        public List<ListQuestion> GetPriorityQuestions(int AssemblySessionId, int GroupId, int CategoryId)
        {
            return new QuestionDal().GetPriorityQuestions(AssemblySessionId, GroupId, CategoryId);
        }
        #endregion QUESTION LIST
        #region QUESTION DIARY
        public List<GroupDiary> GetGroupDiary(int GroupId, int CategoryId)
        {
            return new QuestionDal().GetGroupDiary(GroupId, CategoryId);
        }
        #endregion QUESTION DIARY

        #region CARRY FORWARD
        public List<ListQuestion> GetCarryForwardQuestions(int AssemblySessionId, int GroupId, int CategoryId)
        {
            return new QuestionDal().GetCarryForwardQuestions(AssemblySessionId, GroupId, CategoryId);
        }
        public void CaryFwdQuestion(CarryForward df)
        {
            new QuestionDal().CaryFwdQuestion(df);
        }
        #endregion CARRY FOIRWARD

        public void SwapQuestion(int firstgroup, int firstquestion, int secondgroup, int secondquestion)
        {
            new QuestionDal().SwapQuestion(firstgroup, firstquestion, secondgroup, secondquestion);
        }
        public void UpdateListNo(int QuestionId, int ListId, string SupNo, DateTime ListDate)
        {
            new QuestionDal().UpdateListNo(QuestionId, ListId, SupNo, ListDate);
        }

        #region QUESTIONS LIST
        public void InsertQuestionsList(QuestList df)
        {
            new QuestionDal().InsertQuestionsList(df);
        }
        public List<QuestList> GetQuestionsList(int AssemblySessionId)
        {
            return new QuestionDal().GetQuestionsList(AssemblySessionId);
        }
        public QuestList GetQuestionList(int QuestionsListId)
        {
            return new QuestionDal().GetQuestionList(QuestionsListId);

        }
        public int GetQuestionListLastNumber(int AssemblySessionId,int CategoryId)
        {
            return new QuestionDal().GetQuestionListLastNumber(AssemblySessionId, CategoryId);

        }
        public void DeleteQuestionsList(int QuestionsListId)
        {
            new QuestionDal().DeleteQuestionsList(QuestionsListId);

        }
        public ListQuestion GetListQuestion(int QuestionId)
        {
            return new QuestionDal().GetListQuestion(QuestionId);
        }
        public void UpdateDeferStatus(int AssemblySessionsId, int QuestionId, int DefStatus)
        {
            new QuestionDal().UpdateDeferStatus(AssemblySessionsId, QuestionId, DefStatus);
        }

        #endregion QUESTIONS LIST
        public void ChangeGroups(int first, int second, int third)
        {
            new QuestionDal().ChangeGroups(first, second, third);
        }
        public List<QuestionSummary> GetStatusNoOfQuestions(int FromSession, int ToSession)
        {
            return new QuestionDal().GetStatusNoOfQuestions(FromSession, ToSession);
        }
        public List<QuestionSummary> GetCoalitionNoOfQuestions(int FromSession, int ToSession)
        {
            return new QuestionDal().GetCoalitionNoOfQuestions(FromSession, ToSession);
        }

            public List<GroupDiary> GetUnderProcessPending(int GroupId, int CategoryId)
        {
            return new QuestionDal().GetUnderProcessPending(GroupId, CategoryId);
        }
        public void RemoveListNumbers(string query)
        {
            new QuestionDal().RemoveListNumbers(query);
        }
        #region Member
        //public List<MemberStatuses> GetMemberStatuses()
        //{
        //    return new AdministrationDAL().GetMemberStatuses();
        //}
        public List<Member> GetMembersByStatus(int StatusId)
        {
            return new QuestionDal().GetMembersByStatus(StatusId);
        }
        public List<Member> GetMembersByName(string MemberName)
        {
            return new QuestionDal().GetMemberByName(MemberName);
        }
        public List<Member> GetMemberMinisterByName(string MemberName)
        {
            return new QuestionDal().GetMemberMinisterByName(MemberName);
        }

        public List<Member> GetAllMemberByName(string MemberName)
        {
            return new QuestionDal().GetAllMemberByName(MemberName);
        }
        public List<NewMemberInfo> GetMemberBasicInfo()
        {
            return new QuestionDal().GetMemberBasicInfo();
        }
        public List<NewMemberInfo> GetMemberBasicInfo(string query)
        {
            return new QuestionDal().GetMemberBasicInfo(query);
        }
        public int INSERT_NEW_MEMBER(NewMemberInfo EmpId)
        {
            return new QuestionDal().INSERT_NEW_MEMBER(EmpId);
        }
        public void InsertMemberId(NewMemberInfo bi)
        {
            new QuestionDal().InsertMemberId(bi);
        }
        public void UpdateMemberBasicInfo(NewMemberInfo bi)
        {
            new QuestionDal().UpdateMemberBasicInfo(bi);
        }
        public void InsertUrduName(int SystemUsersId, string UrduName)
        {
            new QuestionDal().InsertUrduName(SystemUsersId, UrduName);
        }

        #endregion Member
        #region SUPLEMENTARY_LIST
        public void InsertSupQuestionsList(SuplementaryListEnt df)
        {
            new QuestionDal().InsertSupQuestionsList(df);
        }
        public List<SuplementaryListEnt> GetQuestionsSupLists(int QuestionListId)
        {
            return new QuestionDal().GetQuestionsSupLists(QuestionListId);

        }
        public SuplementaryListEnt GetQuestionSupList(int SupQuestionsListId)
        {
            return new QuestionDal().GetQuestionSupList(SupQuestionsListId);

        }
        public void DeleteQuestionsSupList(int QuestionsListId)
        {
            new QuestionDal().DeleteQuestionsSupList(QuestionsListId);
        }

        #endregion SUPLEMENTARY_LIST
        public void UpdateQuestionStatus(QuestionStatusHistory questionStatusHistory)
        {
            new QuestionDal().UpdateQuestionStatus(questionStatusHistory);
        }
        public void InsertQuestionRevivalHistory(RevivalHistory revivalHistory)
        {
            new QuestionDal().InsertQuestionRevivalHistory(revivalHistory);
        }

        public List<RevivalHistory> GetQuestionRevivalHistory(int QuestionsId)
        {
            return new QuestionDal().GetQuestionRevivalHistory(QuestionsId);
        }

        public void SetNoticeQuestionDuplicate(int BranchQuestionId, int NoticeQuestionId, int Status, int UserId)
        {
            new QuestionDal().SetNoticeQuestionDuplicate(BranchQuestionId, NoticeQuestionId, Status, UserId);
        }

        #region Notice Summary
        public List<NoticeSummaryEnt> GetQuestionNoticeSummary(DateTime FromDate, DateTime ToDate)
        {
            return new QuestionDal().GetQuestionNoticeSummary(FromDate, ToDate);
        }
        public List<NoticeSummaryEnt> GetMotionNoticeSummary(DateTime FromDate, DateTime ToDate)
        {
            return new QuestionDal().GetMotionNoticeSummary(FromDate, ToDate);
        }
        public List<NoticeSummaryEnt> GetResolutionNoticeSummary(DateTime FromDate, DateTime ToDate)
        {
            return new QuestionDal().GetResolutionNoticeSummary(FromDate, ToDate);
        }
        #endregion

        #region File Status History
        public void InsertFileStatusHistory(FileStatusHiostory fileStatusHiostory)
        {
            new QuestionDal().InsertFileStatusHistory(fileStatusHiostory);
        }
        public List<FileStatusHiostory> GetFileStatusHistory(int QuestionsId)
        {
            return new QuestionDal().GetFileStatusHistory(QuestionsId);
        }
        #endregion

        #region Group Summary
        public List<GroupSummaryReport> GetQuestionGroupSummary(int SessionNumber, int ToSession)
        {
            return new QuestionDal().GetQuestionGroupSummary(SessionNumber, ToSession);
        }
        public List<GroupMinistryMembersQuestions> GetGroupMinistryMembersQuestions(int SessionNumber, int ToSession)
        {
            return new QuestionDal().GetGroupMinistryMembersQuestions(SessionNumber, ToSession);
        }
        #endregion
        public List<Rpt_QuestionsResolutionsSummary> GetQuestionsStatusWiseSummary(int StartSession, int EndSession, int CategoryId)
        {
            return new QuestionDal().GetQuestionsStatusWiseSummary(StartSession, EndSession, CategoryId);
        }
        public void CarryForwardQuestions(int SessionNumber)
        {
            new QuestionDal().CarryForwardQuestions(SessionNumber);
        }

        #region Question Documents
        public List<BusinessDocuments> GetBusinessDocuments(int BusinessId)
        {
            return new QuestionDal().GetBusinessDocuments(BusinessId);
        }
        public void UpdateBusinessDocument(BusinessDocuments Temp)
        {
            new QuestionDal().UpdateBusinessDocument(Temp);  
        }
        public void InsertBusinessDocument(BusinessDocuments Temp)
        {
            new QuestionDal().InsertBusinessDocument(Temp);
        }
        #endregion
    }
}
