using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEntities;
using MyDAL;
using EstablishmentDAL;

namespace MyBIZ
{
    public class vmsBiz
    {
        public int GetPK(string TableName, string FieldName)
        {
            return new vmsDal().GetPK(TableName, FieldName);
        }
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
        public void InsertVisitorPass(VisitorPasses visitorPasses)
        {
            new vmsDal().InsertVisitorPass(visitorPasses);
        }
        public void UpdateVisitorPass(VisitorPasses visitorPasses)
        {
            new vmsDal().UpdateVisitorPass(visitorPasses);
        }
        public List<VisitorPasses> GetVisitorPasses(int Id)
        {
            return new vmsDal().GetVisitorPasses(Id);
        }
        public void VerifyPass(int PassId)
        {
            new vmsDal().VerifyPass(PassId);
        }
        public void UnVerifyPass(int PassId)
        {
            new vmsDal().UnVerifyPass(PassId);
        }
        public List<VisitorPasses> SearchVisitorPasses(string query)
        {
            return new vmsDal().SearchVisitorPasses(query);
        }
        public List<VisitorPasses> GetValidVisitorPass(int PassTypeId)
        {
            return new vmsDal().GetValidVisitorPasses();
        }
        public List<VisitorPasses> GetActiveVisitorPasses(int PassTypeId)
        {
            return new vmsDal().GetActiveVisitorPasses();
        }

        public VisitorPasses GetVisitorPass(string PassId)
        {
            return new vmsDal().GetVisitorPass(PassId);
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
        public void VerifyPassVisitor(int PassVisitorId)
        {
            new vmsDal().VerifyPassVisitor(PassVisitorId);
        }
        public void UnVerifyPassVisitor(int PassVisitorId)
        {
            new vmsDal().UnVerifyPassVisitor(PassVisitorId);
        }
        public void DeleteVisitor(int VisitorId)
        {
            new vmsDal().DeleteVisitor(VisitorId);
        }
        #endregion

        #endregion
        #region Temp Visitors
        public List<Visitors> GetTempVisitors(string PassId)
        {
            return new vmsDal().GetTempVisitors(PassId);
        }


        public void InsertTempVisitor(Visitors Temp)
        {
            new vmsDal().InsertTempVisitor(Temp);
        }

        public void UpdateTempVisitor(Visitors Temp)
        {
            new vmsDal().UpdateTempVisitor(Temp);
        }

        public void DeleteTempVisitor(int VisitorId)
        {
            new vmsDal().DeleteTempVisitor(VisitorId);
        }
        public void DeleteTempVisitors(int PassId)
        {
            new vmsDal().DeleteTempVisitors(PassId);
        }
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

        public List<Visitors> GetVisitorByName(string name)
        {
            return new vmsDal().GetVisitorByName(name);
        }
        public List<Visitors> GetVisitorByCNIC(string cnic)
        {
            return new vmsDal().GetVisitorByCNIC(cnic);
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
        #region Vehicle types
        public List<VehicleTypes> GetVehicleTypes()
        {
            return new vmsDal().GetVehicleTypes();
        }
        #endregion

    }
}
