using DAL;
using Entities;
using System.Collections.Generic;

namespace BIZ
{
    public class ResolutionBiz
    {
        //#region  RESOLUTION_STATUS_HISTORY

        //public List<ResolutionStatusHistoryEnt> GetResolutionStatusHistories()
        //{
        //    return new ResolutionDal().GetResolutionStatusHistories();
        //}
        //public ResolutionStatusHistoryEnt GetResolutionStatusHistory(int ResolutionStatusHistoryId)
        //{
        //    return new ResolutionDal().GetResolutionStatusHistory(ResolutionStatusHistoryId);
        //}
        //public void UpdateResolutionStatusHistory(ResolutionStatusHistoryEnt Temp)
        //{
        //    new ResolutionDal().UpdateResolutionStatusHistory(Temp);
        //}
        //public void InsertResolutionStatusHistory(ResolutionStatusHistoryEnt Temp)
        //{
        //    new ResolutionDal().InsertResolutionStatusHistory(Temp);
        //}
        //#endregion RESOLUTION_STATUS_HISTORY


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
        public int GetPk(string Table, string Field)
        {
            return new ResolutionDal().GetPk(Table, Field);
        }
            public List<ResolutionEnt> GetResolutions(int AssemblySession)
        {
            return new ResolutionDal().GetResolutions(AssemblySession);
        }
        public void DeleteSentResolution(int SentResolutionId)
        {
            new ResolutionDal().DeleteSentResolution(SentResolutionId);
        }
        public ResolutionEnt GetResolution(int ResolutionId)
        {
            return new ResolutionDal().GetResolution(ResolutionId);
        }
        public void UpdateResolution(ResolutionEnt Temp)
        {
            new ResolutionDal().UpdateResolution(Temp);
        }
        public int InsertResolution(ResolutionEnt Temp)
        {
            return new ResolutionDal().InsertResolution(Temp);
        }
        public void InsertResolutionFile(string url, int id)
        {
            new ResolutionDal().InsertResolutionFile(url, id);
        }
        public List<ResolutionEnt> GetSentResolutions(int AssemblySessionId)
        {
            return new ResolutionDal().GetSentResolutions(AssemblySessionId);
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
    }
}
