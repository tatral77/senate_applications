using DAL;
using Entities;
using System.Collections.Generic;

namespace BIZ
{
    public class MBMotionBiz
    {
        #region  MOTION_MOVERS

        public List<MotionMoversEnt> GetMotionMovers(int MotionId)
        {
            return new MBMotionDal().GetMotionMovers(MotionId);
        }
        public void UpdateMotionMover(MotionMoversEnt Temp)
        {
            new MBMotionDal().UpdateMotionMover(Temp);
        }
        public void InsertMotionMover(MotionMoversEnt Temp)
        {
            new MBMotionDal().InsertMotionMover(Temp);
        }
        public void DeleteMotionMover(int MotionId, int MoverId)
        {
            new MBMotionDal().DeleteMotionMover(MotionId, MoverId);
        }
        #endregion MOTION_MOVERS

        #region  MOTION_TYPES
        public List<MotionTypeEnt> GetMotionTypes()
        {
            return new MBMotionDal().GetMotionTypes();
        }
        public void UpdateMotionType(MotionTypeEnt Temp)
        {
            new MBMotionDal().UpdateMotionType(Temp);
        }
        public void InsertMotionType(MotionTypeEnt Temp)
        {
            new MBMotionDal().InsertMotionType(Temp);
        }
        #endregion MOTION_MOVERS

        #region  MOTION_STATUSES
        public List<MotionStatusEnt> GetMotionStatuses()
        {
            return new MBMotionDal().GetMotionStatuses();
        }
        public void UpdateMotionStatus(MotionStatusEnt Temp)
        {
            new MBMotionDal().UpdateMotionStatus(Temp);
        }
        public void InsertMotionStatus(MotionStatusEnt Temp)
        {
            new MBMotionDal().InsertMotionStatus(Temp);
        }
        #endregion MOTION_STATUSES

        #region  MOTION_MINISTRIES
        //public List<MotionMinistriesEnt> GetMotionMinistries()
        //{
        //    return new MBMotionDal().GetMotionMinistries();
        //}
        //public void UpdateMotionMinistry(MotionMinistriesEnt Temp)
        //{
        //    new MBMotionDal().UpdateMotionMinistry(Temp);
        //}
        //public void InsertMotionMinistry(MotionMinistriesEnt Temp)
        //{
        //    new MBMotionDal().InsertMotionMinistry(Temp);
        //}
        #endregion MOTION_MINISTRIES

        #region  MOTION
        public List<MBMotion> GetMotions(int AssemblySessionId)
        {
            return new MBMotionDal().GetMotions(AssemblySessionId);
        }
        public List<MBMotion> GetSentMotions(int AssemblySessionId)
        {
            return new MBMotionDal().GetSentMotions(AssemblySessionId);
        }

        public MBMotion GetMotion(int MotionId)
        {
            return new MBMotionDal().GetMotion(MotionId);
        }
        public List<MBMotion> SearchMotion(string query)
        {
            return new MBMotionDal().SearchMotion(query);
        }
        public void UpdateMotion(MBMotion Temp)
        {
            new MBMotionDal().UpdateMotion(Temp);
        }
        public int InsertMotion(MBMotion Temp, List<MotionMoversEnt> motionmovers)
        {
            return new MBMotionDal().InsertMotion(Temp, motionmovers);
        }
        public void InsertMotionFile(string file, int QuestionId)
        {
            new MBMotionDal().InsertMotionFile(file, QuestionId);
        }

        #endregion MOTION
        #region AssemblySessions
        //public AssemblySessions GetAssemblySession(int AssemblySessionId)
        //{
        //    return new MBMotionDal().GetAssemblySession(AssemblySessionId);
        //}
        //public AssemblySessions GetCurrentAssemblySessionDetails()
        //{
        //    return new MBMotionDal().GetCurrentAssemblySessionDetails();
        //}
        //public List<AssemblySessions> GetAssemblySessions()
        //{
        //    return new MBMotionDal().GetAssemblySessions();
        //}
        public int GetCurrentAssemblySessions()
        {
            return new MBMotionDal().GetCurrentAssemblySessions();
        }
        #endregion AssemblySessions

        public string GetMemberNameById(int MemberId)
        {
            return new MBMotionDal().GetMemberNameById(MemberId);
        }
        //public Groups GetGroupById(int GroupId)
        //{
        //    return new MBMotionDal().GetGroupById(GroupId);
        //}
        //public List<Divisions> GetDivisionsByName(string DivisionName)
        //{
        //    return new MBMotionDal().GetDivisionsByName(DivisionName);
        //}
        //public List<Divisions> GetCurrentDivisionsByName(string DivisionName)
        //{
        //    return new MBMotionDal().GetCurrentDivisionsByName(DivisionName);
        //}

        //public List<MotionWeek> GetMotionWeeks()
        //{
        //    return new MBMotionDal().GetMotionWeeks();  
        //}
        //public MotionWeek GetMotionWeek(int weekid)
        //{
        //    return new MBMotionDal().GetMotionWeek(weekid);
        //}
    }
}
