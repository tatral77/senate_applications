using Entities;
using MotionDAL;
using MotionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionBIZ
{
    public class MotionBiz
    {
        #region  MOTION_MOVERS

        public List<MotionMoversEnt> GetMotionMovers(int MotionId)
        {
            return new MotionDal().GetMotionMovers(MotionId);
        }
        public void UpdateMotionMover(MotionMoversEnt Temp)
        {
            new MotionDal().UpdateMotionMover(Temp);
        }
        public void InsertMotionMover(MotionMoversEnt Temp)
        {
            new MotionDal().InsertMotionMover(Temp);
        }
        public void DeleteMotionMover(int MotionId, int MoverId)
        {
            new MotionDal().DeleteMotionMover(MotionId, MoverId);
        }
        #endregion MOTION_MOVERS

        #region  MOTION_TYPES
        public List<MotionTypeEnt> GetMotionTypes()
        {
            return new MotionDal().GetMotionTypes();
        }
        public void UpdateMotionType(MotionTypeEnt Temp)
        {
            new MotionDal().UpdateMotionType(Temp);
        }
        public void InsertMotionType(MotionTypeEnt Temp)
        {
            new MotionDal().InsertMotionType(Temp);
        }
        #endregion MOTION_MOVERS

        #region  MOTION_STATUSES
        public List<MotionStatusEnt> GetMotionStatuses()
        {
            return new MotionDal().GetMotionStatuses();
        }
        public void UpdateMotionStatus(MotionStatusEnt Temp)
        {
            new MotionDal().UpdateMotionStatus(Temp);
        }
        public void InsertMotionStatus(MotionStatusEnt Temp)
        {
            new MotionDal().InsertMotionStatus(Temp);
        }
        #endregion MOTION_STATUSES

        #region  MOTION_MINISTRIES
        //public List<MotionMinistriesEnt> GetMotionMinistries()
        //{
        //    return new MotionDal().GetMotionMinistries();
        //}
        //public void UpdateMotionMinistry(MotionMinistriesEnt Temp)
        //{
        //    new MotionDal().UpdateMotionMinistry(Temp);
        //}
        //public void InsertMotionMinistry(MotionMinistriesEnt Temp)
        //{
        //    new MotionDal().InsertMotionMinistry(Temp);
        //}
        #endregion MOTION_MINISTRIES

        #region  MOTION
        public List<MotionEnt> GetMotions(int AssemblySessionId)
        {
            return new MotionDal().GetMotions(AssemblySessionId);
        }
        public List<MotionEnt> GetSentMotions(int AssemblySessionId)
        {
            return new MotionDal().GetSentMotions(AssemblySessionId);
        }
        public MotionEnt GetMotion(int MotionId)
        {
            return new MotionDal().GetMotion(MotionId);
        }
        public MotionEnt GetNoticeMotion(int MotionId)
        {
            return new MotionDal().GetNoticeMotion(MotionId);
        }

        public List<MotionEnt> SearchMotion(string query)
        {
            return new MotionDal().SearchMotion(query);
        }
        public void UpdateMotion(MotionEnt Temp)
        {
            new MotionDal().UpdateMotion(Temp);
        }
        public int InsertMotion(MotionEnt Temp, List<MotionMoversEnt> motionmovers)
        {
            return new MotionDal().InsertMotion(Temp, motionmovers);
        }
        public void DeleteMotion(int MotionId)
        {
            new MotionDal().DeleteMotion(MotionId);
        }
        public void RecoverMotion(int MotionId)
        {
            new MotionDal().RecoverMotion(MotionId);
        }

        #endregion MOTION

        #region Translation
        public List<MotionEnt> GetTranslationMotions(int AssemblySessionsId)
        {
            return new MotionDal().GetTranslationMotions(AssemblySessionsId);
        }
        public List<MotionEnt> GetTranslatedMotions(int AssemblySessionsId)
        {
            return new MotionDal().GetTranslatedMotions(AssemblySessionsId);
        }
        public void SendForTranslation(int MotionId)
        {
            new MotionDal().SendForTranslation(MotionId);
        }
        public void ApproveTranslation(int MotionId)
        {
            new MotionDal().ApproveTranslation(MotionId);
        }
        #endregion
        #region AssemblySessions
        public AssemblySessions GetAssemblySession(int AssemblySessionId)
        {
            return new MotionDal().GetAssemblySession(AssemblySessionId);
        }
        public AssemblySessions GetCurrentAssemblySessionDetails()
        {
            return new MotionDal().GetCurrentAssemblySessionDetails();
        }
        public List<AssemblySessions> GetAssemblySessions()
        {
            return new MotionDal().GetAssemblySessions();
        }
        public int GetCurrentAssemblySessions()
        {
            return new MotionDal().GetCurrentAssemblySessions();
        }
        #endregion AssemblySessions

        public string GetMemberNameById(int MemberId)
        {
            return new MotionDal().GetMemberNameById(MemberId);
        }
        public string GetMinistryNameById(int MinistryId)
        {
            return new MotionDal().GetMinistryNameById(MinistryId);
        }
        public Groups GetGroupById(int GroupId)
        {
            return new MotionDal().GetGroupById(GroupId);
        }
        public List<Divisions> GetDivisionsByName(string DivisionName)
        {
            return new MotionDal().GetDivisionsByName(DivisionName);
        }
        public List<Divisions> GetCurrentDivisionsByName(string DivisionName)
        {
            return new MotionDal().GetCurrentDivisionsByName(DivisionName);
        }

        public List<MotionWeek> GetMotionWeeks()
        {
            return new MotionDal().GetMotionWeeks();
        }
        public MotionWeek GetMotionWeek(int weekid)
        {
            return new MotionDal().GetMotionWeek(weekid);
        }
        public List<MotionMinistriesEnt> GetMotionMinistries(int MotionId)
        {
            return new MotionDal().GetMotionMinistries(MotionId);
        }
        public void InsertMotionMinistries(MotionMinistriesEnt Temp)
        {
            new MotionDal().InsertMotionMinistries(Temp);
        }

        public void DeleteMotionMinistry(int MotionId, int MinistryId)
        {
            new MotionDal().DeleteMotionMinistry(MotionId, MinistryId);
        }

        public List<MotionSummary> GetStatusNoOfMotions(int FromSession, int ToSession,int MotionTypeId)
        {
            return new MotionDal().GetStatusNoOfMotions(FromSession, ToSession, MotionTypeId);
        }

        #region Motion Status History


        public List<MotionStatusHistory> GetMotionStatusHistory(int MotionsId)
        {
            return new MotionDal().GetMotionStatusHistory(MotionsId);
        }

        public void SetNoticeMotionRevived(int MotionId, int ReviveMotionId)
        {
            new MotionDal().SetNoticeMotionRevived(MotionId, ReviveMotionId);
        }
        public void InsertMotionStatusHistory(MotionStatusHistory Temp)
        {
            new MotionDal().InsertMotionStatusHistory(Temp);
        }
        public void InsertMotionRevivalHistory(RevivalHistory revivalHistory)
        {
            new MotionDal().InsertMotionRevivalHistory(revivalHistory);
        }

        public List<RevivalHistory> GetMotionRevivalHistory(int QuestionsId)
        {
            return new MotionDal().GetMotionRevivalHistory(QuestionsId);
        }
        #endregion

        #region Motions List

        public List<MotionEnt> GetAdmittedMotions(int AssemblySessionsId, int MotionTypeId)
        {
            return new MotionDal().GetAdmittedMotions(AssemblySessionsId, MotionTypeId);
        }
        public List<MotionEnt> GetDefferedMotions(int AssemblySessionsId, int MotionTypeId)
        {
            return new MotionDal().GetDefferedMotions(AssemblySessionsId, MotionTypeId);
        }
        public List<ListEntity> GetMotionList(int AssemblySessionsId, int MotionTypeId)
        {
            return new MotionDal().GetMotionList(AssemblySessionsId, MotionTypeId);
        }
        public void InsertMotionList(ListEntity Temp)
        {
            new MotionDal().InsertMotionList(Temp);
        }
        public void DeleteMotionList(int MotionListId)
        {
            new MotionDal().DeleteMotionList(MotionListId);
        }
        public ListEntity GetMotionListById(int MotionListId)
        {
            return new MotionDal().GetMotionListById(MotionListId);
        }
        public void UpdateMotionListNo(int MotionsId, int ListNo, DateTime ListDate)
        {
            new MotionDal().UpdateMotionListNo(MotionsId, ListNo, ListDate);
        }
        #endregion
    }

}
