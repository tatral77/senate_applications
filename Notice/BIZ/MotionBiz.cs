using DAL;
using Entities;
using System.Collections.Generic;

namespace BIZ
{
    public class MotionBiz
    {
        public int GetPk()
        {
            return new MotionDal().GetPk();
        }
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
        public void InsertMotionFile(string url, int id)
        {
            new MotionDal().InsertMotionFile(url, id);
        }
        public void DeleteSentMotion(int SentMotionId)
        {
            new MotionDal().DeleteSentMotion(SentMotionId);
        }
        #endregion MOTION
    }
}
