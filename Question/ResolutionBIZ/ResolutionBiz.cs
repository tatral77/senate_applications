using Entities;
using QuestionDAL;
using ResolutionEntities;
using RsolutionDAL;
using System;
using System.Collections.Generic;

namespace ResolutionBIZ
{
    public class ResolutionBiz
    {
        #region  RESOLUTION_STATUS_HISTORY


        public List<ResolutionStatusHistory> GetResolutionStatusHistory(int ResolutionId)
        {
            return new ResolutionDal().GetResolutionStatusHistory(ResolutionId);
        }

        public void InsertResolutionStatusHistory(ResolutionStatusHistory Temp)
        {
            new ResolutionDal().InsertResolutionStatusHistory(Temp);
        }
        #endregion RESOLUTION_STATUS_HISTORY


        #region  RESOLUTION_TYPES
        public List<ResolutionTypesEnt> GetResolutionTypes()
        {
            return new AdministrationDAL().GetResolutionTypes();
        }
        public ResolutionTypesEnt GetResolutionType(int ResTypesId)
        {
            return new AdministrationDAL().GetResolutionType(ResTypesId);
        }
        public void UpdateResolutionType(ResolutionTypesEnt Temp)
        {
            new AdministrationDAL().UpdateResolutionTypes(Temp);
        }
        public void InsertResolutionType(ResolutionTypesEnt Temp)
        {
            new AdministrationDAL().InsertResolutionTypes(Temp);
        }
        #endregion RESOLUTION_TYPES

        #region  RESOLUTION_STATUSES
        public List<ResolutionStatusesEnt> GetResolutionStatuses()
        {
            return new AdministrationDAL().GetResolutionStatuses();
        }
        public ResolutionStatusesEnt GetResolutionStatus(int ResolutionTypesId)
        {
            return new AdministrationDAL().GetResolutionStatus(ResolutionTypesId);
        }
        public void UpdateResolutionStatus(ResolutionStatusesEnt Temp)
        {
            new AdministrationDAL().UpdateResolutionStatus(Temp);
        }
        public void InsertResolutionStatus(ResolutionStatusesEnt Temp)
        {
            new AdministrationDAL().InsertResolutionStatus(Temp);
        }
        #endregion RESOLUTION_STATUSES

        #region  RESOLUTION
        public List<ResolutionEnt> GetSentResolutions(int AssemblySessionId)
        {
            return new ResolutionDal().GetSentResolutions(AssemblySessionId);
        }
        public List<ResolutionEnt> GetResolutions(int AssemblySession)
        {
            return new ResolutionDal().GetResolutions(AssemblySession);
        }
        public List<ResolutionEnt> GetDeletedResolutions(int AssemblySession)
        {
            return new ResolutionDal().GetDeletedResolutions(AssemblySession);
        }
        public ResolutionEnt GetResolution(int ResolutionId)
        {
            return new ResolutionDal().GetResolution(ResolutionId);
        }
        public ResolutionEnt GetNoticeResolution(int ResolutionId)
        {
            return new ResolutionDal().GetNoticeResolution(ResolutionId);
        }
        public void UpdateResolution(ResolutionEnt Temp)
        {
            new ResolutionDal().UpdateResolution(Temp);
        }
        public void UpdateRevivedResolution(ResolutionEnt Temp)
        {
            new ResolutionDal().UpdateRevivedResolution(Temp);
        }
            public int InsertResolution(ResolutionEnt Temp)
        {
            return new ResolutionDal().InsertResolution(Temp);
        }
        public void MoveResolution(ResolutionEnt Temp)
        {
            new ResolutionDal().MoveResolution(Temp);
        }
        public void DeleteResolution(int ResolutionId, int DeletedBy)
        {
            new ResolutionDal().DeleteResolution(ResolutionId, DeletedBy);

        }
        public void RecoverResolution(int ResolutionId, int UserId)
        {
            new ResolutionDal().RecoverResolution(ResolutionId, UserId);

        }
        public void ChangeNoticeResolutionStatus(int noticeid, int status)
        {
            new ResolutionDal().ChangeNoticeResolutionStatus(noticeid, status);
        }
        #endregion RESOLUTION

        #region  RESOLUTION_SUBMITTERS
        public List<ResolutionSubmittersEnt> GetResolutionSubmitters(int ResolutionsId)
        {
            return new ResolutionDal().GetResolutionSubmitters(ResolutionsId);
        }
        public ResolutionSubmittersEnt GetResolutionSubmitter(int ResolutionSubmitterId)
        {
            return new ResolutionDal().GetResolutionSubmitter(ResolutionSubmitterId);
        }
        public void UpdateResolutionSubmitters(ResolutionSubmittersEnt Temp)
        {
            new ResolutionDal().UpdateResolutionSubmitters(Temp);
        }
        public void InsertResolutionSubmitters(ResolutionSubmittersEnt Temp)
        {
            new ResolutionDal().InsertResolutionSubmitters(Temp);
        }
        public List<ResolutionEnt> SearchResolutions(string query)
        {
            return new ResolutionDal().SearchResolutions(query);
        }
        public void DeleteResolutionMover(int ResolutionId, int MoverId)
        {
            new ResolutionDal().DeleteResolutionMover(ResolutionId, MoverId);
        }
        #endregion RESOLUTION_SUBMITTERS
        public List<ResolutionEnt> GetAdmittedResolutions(int AssemblySessionsId)
        {
            return new ResolutionDal().GetAdmittedResolutions(AssemblySessionsId);
        }
        public List<ResolutionListEnt> GetResolutionList(int AssemblySessionsId)
        {
            return new ResolutionDal().GetResolutionList(AssemblySessionsId);
        }
        public void InsertResolutionList(ResolutionListEnt Temp)
        {
            new ResolutionDal().InsertResolutionList(Temp);
        }
        public void DeleteResolutionList(int ResolutionListId)
        {
            new ResolutionDal().DeleteResolutionList(ResolutionListId);
        }
        public ResolutionListEnt GetResolutionListById(int ResolutionListId)
        {
            return new ResolutionDal().GetResolutionListById(ResolutionListId);
        }
        public void UpdateResolutionListNo(int ResolutionsId, int ListNo, DateTime ListDate)
        {
            new ResolutionDal().UpdateResolutionListNo(ResolutionsId, ListNo, ListDate);
        }
        public List<ResolutionSummaryEnt> GetStatusNoOfResolutions(int FromSession, int ToSession)
        {
            return new ResolutionDal().GetStatusNoOfResolutions(FromSession, ToSession);
        }
        public void UpdateResolutionStatus(ResolutionStatusHistory resolutionStatusHistory)
        {
            new ResolutionDal().UpdateResolutionStatus(resolutionStatusHistory);
        }

        public void SetNoticeResolutionRevived(int ResolutionId, int PreviousResolutionId)
        {
            new ResolutionDal().SetNoticeResolutionRevived(ResolutionId, PreviousResolutionId);
        }
        public void InsertResolutionRevivalHistory(ResolutionRevivalHistory revivalHistory)
        {
            new ResolutionDal().InsertResolutionRevivalHistory(revivalHistory);
        }

        public List<ResolutionRevivalHistory> GetResolutionRevivalHistory(int ResolutionId)
        {
            return new ResolutionDal().GetResolutionRevivalHistory(ResolutionId);
        }

        public void SetNoticeResolutionDuplicate(int BranchResolutionId, int NoticeResolutionId, int Status, int UserId)
        {
            new ResolutionDal().SetNoticeResolutionDuplicate(BranchResolutionId, NoticeResolutionId, Status, UserId);
        }
        #region Resolution Ministries
        public string GetMinistryNameById(int MinistryId)
        {
            return new ResolutionDal().GetMinistryNameById(MinistryId);
        }
        public List<ResolutionMinistries> GetResolutionMinistries(int ResolutionId)
        {
            return new ResolutionDal().GetResolutionMinistries(ResolutionId);
        }
        public void InsertResolutionMinistries(ResolutionMinistries Temp)
        {
            new ResolutionDal().InsertResolutionMinistries(Temp);
        }
        public void DeleteResolutionMinistry(int ResolutionId, int MinistryId)
        {
            new ResolutionDal().DeleteResolutionMinistry(ResolutionId, MinistryId);
        }

        #endregion




        #region Translation
        public List<ResolutionEnt> GetTranslationResolutions(int AssemblySessionsId)
        {
            return new ResolutionDal().GetTranslationResolutions(AssemblySessionsId);
        }
        public List<ResolutionEnt> GetTranslatedResolutions(int AssemblySessionsId)
        {
            return new ResolutionDal().GetTranslatedResolutions(AssemblySessionsId);
        }
        public void SendForTranslation(int ResolutionId, int UserId)
        {
            new ResolutionDal().SendForTranslation(ResolutionId, UserId);
        }
        public void ApproveTranslation(int ResolutionId, int UserId)
        {
            new ResolutionDal().ApproveTranslation(ResolutionId, UserId);
        }
        #endregion
        public List<Rpt_QuestionsResolutionsSummary> GetResolutionStatusWiseSummary(int StartSession, int EndSession)
        {
            return new ResolutionDal().GetResolutionStatusWiseSummary(StartSession, EndSession);
        }
        public void CarryForwardResolutions(int SessionNumber)
        {
            new ResolutionDal().CarryForwardResolutions(SessionNumber);
        }

        }
}
