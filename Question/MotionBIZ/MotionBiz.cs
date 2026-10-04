using MotionDAL;
using MotionEntities;
using System;
using System.Collections.Generic;

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

        #endregion MOTION
        public List<MotionEnt> GetAdmittedMotions(int AssemblySessionsId)
        {
            return new MotionDal().GetAdmittedMotions(AssemblySessionsId);
        }
        public List<ListEntity> GetMotionList(int AssemblySessionsId)
        {
            return new MotionDal().GetMotionList(AssemblySessionsId);
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
        public List<MotionSummary> GetStatusNoOfMotions(int FromSession, int ToSession)
        {
            return new MotionDal().GetStatusNoOfMotions(FromSession, ToSession);
        }
        public void UpdateMotionStatus(int MotionId, int StatusId, int AssemblySessionId, DateTime StatusDate)
        {
            new MotionDal().UpdateMotionStatus(MotionId, StatusId, AssemblySessionId, StatusDate);
        }
        public void CarryForwardMotions(int SessionNumber)
        {
            new MotionDal().CarryForwardMotions(SessionNumber);
        }
    }
}
