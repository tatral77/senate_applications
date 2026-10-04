using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Threading.Tasks;
using DAL;

namespace BIZ
{
    public class Biz
    {
        #region Pass Types
        public List<PassTypes> GetPassTypes()
        {
            return new Dal().GetPassTypes();
        }
        //public PassTypes GetPassType(int PassTypeId)
        //{

        //}


        #endregion

        #region Visitor Passes
        public void InsertVisitorPass(VisitorPasses visitorPasses)
        {
            new Dal().InsertVisitorPass(visitorPasses);
        }
        public void UpdateVisitorPass(VisitorPasses visitorPasses)
        {
            new Dal().UpdateVisitorPass(visitorPasses);
        }
        public List<VisitorPasses> GetVisitorPasses()
        {
            return new Dal().GetVisitorPasses();
        }
        public List<VisitorPasses> SearchVisitorPasses(string query)
        {
            return new Dal().SearchVisitorPasses(query);
        }
        public List<VisitorPasses> GetValidVisitorPass(int PassTypeId)
        {
            return new Dal().GetValidVisitorPasses();
        }
        public List<VisitorPasses> GetActiveVisitorPasses(int PassTypeId)
        {
            return new Dal().GetActiveVisitorPasses();
        }

        public VisitorPasses GetVisitorPass(string PassId)
        {
            return new Dal().GetVisitorPass(PassId);
        }
        #endregion

        #region Branches
        public List<Branch> GetBranches()
        {
            return new Dal().GetBranches();
        }
        #endregion

        #region Visitors
        #region Visitors
        public List<Visitors> GetVisitors(string PassId)
        {
            return new Dal().GetVisitors(PassId);
        }


        public void InsertVisitor(Visitors Temp)
        {
            new Dal().InsertVisitor(Temp);
        }

        public void UpdateVisitor(Visitors Temp)
        {
            new Dal().UpdateVisitor(Temp);
        }
        public void DeleteVisitor(int VisitorId)
        {
            new Dal().DeleteVisitor(VisitorId);
        }
        #endregion

        #endregion
        #region Company
        public List<Companies> GetCompanies(string CompanyName)
        {
            return new Dal().GetCompanies(CompanyName);
        }
        #endregion

        public List<Member> GetEmployeeByName(string MemberName)
        {
            return new Dal().GetEmployeeByName(MemberName);
        }

        public List<Visitors> GetVisitorByName(string MemberName)
        {
            return new Dal().GetVisitorByName(MemberName);
        }

        #region WalkInVisitor
        public void AddWalkInVisitor(WalkInVisitor walkInVisitor)
        {
            new Dal().AddWalkInVisitor(walkInVisitor);
          
        }

        public void UpdateWalkInVisitor(WalkInVisitor walkInVisitor)
        {
            new Dal().UpdateWalkInVisitor(walkInVisitor);
        }
        public void DeleteWalkInVisitor(int visitorid)
        {
            new Dal().DeleteWalkInVisitor(visitorid);
        }


        public List<WalkInVisitor> GetWalkInVisitors()
        {
            return new Dal().GetWalkInVisitors();
        }
        #endregion

    }
}
