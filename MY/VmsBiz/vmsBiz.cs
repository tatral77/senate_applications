using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmsEntities;
using System.Threading.Tasks;
using VmsDal;

namespace VmsBiz
{
    public class vmsBiz
    {
        #region Pass Types
        public List<PassTypes> GetPassTypes()
        {
            return new vmsDal().GetPassTypes();
        }
        //public PassTypes GetPassType(int PassTypeId)
        //{

        //}


        #endregion

        #region Visitor Passes
        public void InsertVisitorPasses(VisitorPasses visitorPasses)
        {
            new vmsDal().InsertVisitorPasses(visitorPasses);
        }
        public void UpdateVisitorPasses(VisitorPasses visitorPasses)
        {
            new vmsDal().UpdateVisitorPasses(visitorPasses);
        }
        public List<VisitorPasses> GetVisitorPasses()
        {
            return new vmsDal().GetVisitorPasses();
        }
        public List<VisitorPasses> SearchVisitorPasses(string query)
        {
            return new vmsDal().SearchVisitorPasses(query);
        }
        public List<VisitorPasses> GetValidVisitorPasses(int PassTypeId)
        {
            return new vmsDal().GetValidVisitorPasses();
        }
        public List<VisitorPasses> GetActiveVisitorPasses(int PassTypeId)
        {
            return new vmsDal().GetActiveVisitorPasses();
        }

        public VisitorPasses GetVisitorPasses(string PassId)
        {
            return new vmsDal().GetVisitorPasses(PassId);
        }
        #endregion

        #region Branches
        public List<Branch> GetBranches()
        {
            return new vmsDal().GetBranches();
        }
        #endregion

        #region Visitors
        #region Visitors
        public List<Visitors> GetVisitors(string PassId)
        {
            return new vmsDal().GetVisitors(PassId);
        }


        public void InsertVisitor(Visitors Temp)
        {
            new vmsDal().InsertVisitor(Temp);
        }

        public void UpdateVisitor(Visitors Temp)
        {
            new vmsDal().UpdateVisitor(Temp);
        }
        public void DeleteVisitor(int VisitorId)
        {
            new vmsDal().DeleteVisitor(VisitorId);
        }
        #endregion

        #endregion
        #region Company
        public List<Companies> GetCompanies(string CompanyName)
        {
            return new vmsDal().GetCompanies(CompanyName);
        }
        #endregion

        public List<Member> GetEmployeeByName(string MemberName)
        {
            return new vmsDal().GetEmployeeByName(MemberName);
        }

        public List<Visitors> GetVisitorByName(string MemberName)
        {
            return new vmsDal().GetVisitorByName(MemberName);
        }

        #region WalkInVisitor
        public void AddWalkInVisitor(WalkInVisitor walkInVisitor)
        {
            new vmsDal().AddWalkInVisitor(walkInVisitor);
          
        }

        public void UpdateWalkInVisitor(WalkInVisitor walkInVisitor)
        {
            new vmsDal().UpdateWalkInVisitor(walkInVisitor);
        }
        public void DeleteWalkInVisitor(int visitorid)
        {
            new vmsDal().DeleteWalkInVisitor(visitorid);
        }


        public List<WalkInVisitor> GetWalkInVisitors()
        {
            return new vmsDal().GetWalkInVisitors();
        }
        #endregion

    }
}
