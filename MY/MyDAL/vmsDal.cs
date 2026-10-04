
using EstablishmentDAL;
using MyEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyDAL
{
    public class vmsDal
    {
        #region PASS TYPES
        public List<PassTypes> GetPassTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PASS_TYPES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<PassTypes> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<PassTypes>();
                    while (dr.Read())
                    {
                        PassTypes Temp = new PassTypes();

                        Temp.PassTypeId = Convert.ToInt32(dr["PASS_TYPE_ID"]);
                        Temp.Description = Convert.ToString(dr["PASS_TYPE"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion

        #region PASS

        #region Companies
        #region Branches
        public List<Branch> GetBranches()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_BRANCHES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Branch> branches = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    branches = new List<Branch>();
                    while (dr.Read())
                    {
                        Branch ad = new Branch();
                        ad.BranchId = Convert.ToInt32(dr["Branches_ID"]);
                        ad.BranchName = Convert.ToString(dr["Description"]);
                        branches.Add(ad);
                    }
                }

                if (branches != null) branches.TrimExcess();
                return branches;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion
        public List<Companies> GetCompanies(string prefix)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_COMPANIES";
                cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = prefix;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Companies> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Companies>();
                    while (dr.Read())
                    {
                        Companies Temp = new Companies();

                        Temp.CompanyId = Convert.ToInt32(dr["COMPANY_ID"]);
                        Temp.CompanyName = Convert.ToString(dr["COMPANY_NAME"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion

        public VisitorPasses GetVisitorPass(string PassId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PASS";
                cmd.Parameters.Add("@PassId", SqlDbType.VarChar).Value = PassId;
                cmd.CommandType = CommandType.StoredProcedure;
                VisitorPasses Temp = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = new VisitorPasses();
                    Temp.PassId = Convert.ToString(dr["PASS_ID"]);
                    Temp.PassCode = Convert.ToString(dr["PASS_CODE"]);
                    Temp.RequestedById = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                    Temp.PassDate = Convert.ToDateTime(dr["PASS_DATE"]);
                    Temp.BranchId = Convert.ToInt32(dr["BRANCH_ID"]);
                    Temp.Branch = new Branch();
                    Temp.BranchId = Convert.ToInt32(dr["BRANCH_ID"]);
                    Temp.Branch.BranchName = Convert.ToString(dr["BRANCH"]);
                    if (dr["COMPANY_ID"] != DBNull.Value)
                    {
                        Temp.CompanyId = Convert.ToInt32(dr["COMPANY_ID"]);
                        Temp.Company = new Companies();
                        Temp.Company.CompanyId = Convert.ToInt32(dr["COMPANY_ID"]);
                        Temp.Company.CompanyName = Convert.ToString(dr["COMPANY_NAME"]);
                    }
                    Temp.RequestedBy = Convert.ToString(dr["F_NAME"]);
                    Temp.Post = Convert.ToString(dr["POST"]);
                    Temp.Bps = Convert.ToString(dr["BPS"]);
                    Temp.VisitPurpose = Convert.ToString(dr["VISIT_PURPOSE"]);
                    Temp.FromDate = Convert.ToDateTime(dr["FROM_DATE"]);
                    Temp.ToDate = Convert.ToDateTime(dr["TO_DATE"]);
                    Temp.Remarks = Convert.ToString(dr["REMARKS"]);
                    Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                    Temp.PassTypeId = Convert.ToInt32(dr["PASS_TYPE_ID"]);
                    Temp.PassTypes = new PassTypes();
                    Temp.PassTypes.PassTypeId = Convert.ToInt32(dr["PASS_TYPE_ID"]);
                    Temp.PassTypes.Description = Convert.ToString(dr["PASS_TYPE"]);
                    if (dr["SATURDAY"] != DBNull.Value)
                        Temp.Saturday = Convert.ToInt32(dr["SATURDAY"]);
                    if (dr["SUNDAY"] != DBNull.Value)
                        Temp.Sunday = Convert.ToInt32(dr["SUNDAY"]);
                    Temp.Visitors = GetVisitors(PassId);
                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public List<VisitorPasses> GetVisitorPasses(int Id)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_USER_PASSES";
                cmd.Parameters.Add("@RequestedBy", SqlDbType.Int).Value = Id;
                cmd.CommandType = CommandType.StoredProcedure;
                List<VisitorPasses> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<VisitorPasses>();
                    while (dr.Read())
                    {
                        VisitorPasses Temp = new VisitorPasses();

                        Temp.PassId = Convert.ToString(dr["PASS_ID"]);
                        Temp.PassCode = Convert.ToString(dr["PASS_CODE"]);
                        Temp.RequestedById = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        Temp.PassDate = Convert.ToDateTime(dr["PASS_DATE"]);
                        Temp.BranchId = Convert.ToInt32(dr["BRANCH_ID"]);
                        Temp.Branch = new Branch();
                        Temp.BranchId = Convert.ToInt32(dr["BRANCH_ID"]);
                        Temp.Branch.BranchName = Convert.ToString(dr["BRANCH"]);
                        if (dr["COMPANY_ID"] != DBNull.Value)
                        {
                            Temp.CompanyId = Convert.ToInt32(dr["COMPANY_ID"]);
                            Temp.Company = new Companies();
                            Temp.Company.CompanyId = Convert.ToInt32(dr["COMPANY_ID"]);
                            Temp.Company.CompanyName = Convert.ToString(dr["COMPANY_NAME"]);
                        }
                        Temp.RequestedBy = Convert.ToString(dr["F_NAME"]);
                        Temp.Post = Convert.ToString(dr["POST"]);
                        Temp.Bps = Convert.ToString(dr["BPS"]);
                        Temp.VisitPurpose = Convert.ToString(dr["VISIT_PURPOSE"]);
                        Temp.FromDate = Convert.ToDateTime(dr["FROM_DATE"]);
                        Temp.ToDate = Convert.ToDateTime(dr["TO_DATE"]);
                        Temp.Remarks = Convert.ToString(dr["REMARKS"]);
                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        Temp.PassTypeId = Convert.ToInt32(dr["PASS_TYPE_ID"]);
                        Temp.PassTypes = new PassTypes();
                        Temp.PassTypes.PassTypeId = Convert.ToInt32(dr["PASS_TYPE_ID"]);
                        Temp.PassTypes.Description = Convert.ToString(dr["PASS_TYPE"]);
                        Temp.Verified = Convert.ToInt32(dr["VERIFIED"]);
                        if (dr["SATURDAY"] != DBNull.Value)
                            Temp.Saturday = Convert.ToInt32(dr["SATURDAY"]);
                        if (dr["SUNDAY"] != DBNull.Value)
                            Temp.Sunday = Convert.ToInt32(dr["SUNDAY"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<VisitorPasses> GetValidVisitorPasses()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_VALID_USER_PASSES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<VisitorPasses> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<VisitorPasses>();
                    while (dr.Read())
                    {
                        VisitorPasses Temp = new VisitorPasses();

                        Temp.PassId = Convert.ToString(dr["PASS_ID"]);
                        Temp.PassCode = Convert.ToString(dr["PASS_CODE"]);
                        Temp.RequestedById = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        Temp.PassDate = Convert.ToDateTime(dr["PASS_DATE"]);
                        Temp.BranchId = Convert.ToInt32(dr["BRANCH_ID"]);
                        Temp.Branch = new Branch();
                        Temp.BranchId = Convert.ToInt32(dr["BRANCH_ID"]);
                        Temp.Branch.BranchName = Convert.ToString(dr["BRANCH"]);
                        if (dr["COMPANY_ID"] != DBNull.Value)
                        {
                            Temp.CompanyId = Convert.ToInt32(dr["COMPANY_ID"]);
                            Temp.Company = new Companies();
                            Temp.Company.CompanyId = Convert.ToInt32(dr["COMPANY_ID"]);
                            Temp.Company.CompanyName = Convert.ToString(dr["COMPANY_NAME"]);
                        }
                        Temp.RequestedBy = Convert.ToString(dr["F_NAME"]);
                        Temp.Post = Convert.ToString(dr["POST"]);
                        Temp.Bps = Convert.ToString(dr["BPS"]);
                        Temp.VisitPurpose = Convert.ToString(dr["VISIT_PURPOSE"]);
                        Temp.FromDate = Convert.ToDateTime(dr["FROM_DATE"]);
                        Temp.ToDate = Convert.ToDateTime(dr["TO_DATE"]);
                        Temp.Remarks = Convert.ToString(dr["REMARKS"]);
                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        Temp.PassTypeId = Convert.ToInt32(dr["PASS_TYPE_ID"]);
                        Temp.PassTypes = new PassTypes();
                        Temp.PassTypes.PassTypeId = Convert.ToInt32(dr["PASS_TYPE_ID"]);
                        Temp.PassTypes.Description = Convert.ToString(dr["PASS_TYPE"]);
                        Temp.Verified = Convert.ToInt32(dr["VERIFIED"]);
                        if (dr["SATURDAY"] != DBNull.Value)
                            Temp.Saturday = Convert.ToInt32(dr["SATURDAY"]);
                        if (dr["SUNDAY"] != DBNull.Value)
                            Temp.Sunday = Convert.ToInt32(dr["SUNDAY"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }

        public List<VisitorPasses> GetActiveVisitorPasses()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_USER_PASSES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<VisitorPasses> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<VisitorPasses>();
                    while (dr.Read())
                    {
                        VisitorPasses Temp = new VisitorPasses();

                        Temp.PassId = Convert.ToString(dr["PASS_ID"]);
                        Temp.PassCode = Convert.ToString(dr["PASS_CODE"]);
                        Temp.RequestedById = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        Temp.PassDate = Convert.ToDateTime(dr["PASS_DATE"]);
                        Temp.BranchId = Convert.ToInt32(dr["BRANCH_ID"]);
                        Temp.Branch = new Branch();
                        Temp.BranchId = Convert.ToInt32(dr["BRANCH_ID"]);
                        Temp.Branch.BranchName = Convert.ToString(dr["BRANCH"]);
                        if (dr["COMPANY_ID"] != DBNull.Value)
                        {
                            Temp.CompanyId = Convert.ToInt32(dr["COMPANY_ID"]);
                            Temp.Company = new Companies();
                            Temp.Company.CompanyId = Convert.ToInt32(dr["COMPANY_ID"]);
                            Temp.Company.CompanyName = Convert.ToString(dr["COMPANY_NAME"]);
                        }
                        Temp.RequestedBy = Convert.ToString(dr["F_NAME"]);
                        Temp.Post = Convert.ToString(dr["POST"]);
                        Temp.Bps = Convert.ToString(dr["BPS"]);
                        Temp.VisitPurpose = Convert.ToString(dr["VISIT_PURPOSE"]);
                        Temp.FromDate = Convert.ToDateTime(dr["FROM_DATE"]);
                        Temp.ToDate = Convert.ToDateTime(dr["TO_DATE"]);
                        Temp.Remarks = Convert.ToString(dr["REMARKS"]);
                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        Temp.PassTypeId = Convert.ToInt32(dr["PASS_TYPE_ID"]);
                        Temp.PassTypes = new PassTypes();
                        Temp.PassTypes.PassTypeId = Convert.ToInt32(dr["PASS_TYPE_ID"]);
                        Temp.PassTypes.Description = Convert.ToString(dr["PASS_TYPE"]);
                        Temp.Verified = Convert.ToInt32(dr["VERIFIED"]);
                        if (dr["SATURDAY"] != DBNull.Value)
                            Temp.Saturday = Convert.ToInt32(dr["SATURDAY"]);
                        if (dr["SUNDAY"] != DBNull.Value)
                            Temp.Sunday = Convert.ToInt32(dr["SUNDAY"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }

        public List<VisitorPasses> SearchVisitorPasses(string query)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                List<VisitorPasses> MyList = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        MyList = new List<VisitorPasses>();
                        while (dr.Read())
                        {
                            VisitorPasses Temp = new VisitorPasses();

                            Temp.PassId = Convert.ToString(dr["PASS_ID"]);
                            Temp.PassCode = Convert.ToString(dr["PASS_CODE"]);
                            Temp.RequestedById = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                            Temp.PassDate = Convert.ToDateTime(dr["PASS_DATE"]);
                            Temp.BranchId = Convert.ToInt32(dr["BRANCH_ID"]);
                            Temp.Branch = new Branch();
                            Temp.BranchId = Convert.ToInt32(dr["BRANCH_ID"]);
                            Temp.Branch.BranchName = Convert.ToString(dr["BRANCH"]);
                            if (dr["COMPANY_ID"] != DBNull.Value)
                            {
                                Temp.CompanyId = Convert.ToInt32(dr["COMPANY_ID"]);
                                Temp.Company = new Companies();
                                Temp.Company.CompanyId = Convert.ToInt32(dr["COMPANY_ID"]);
                                Temp.Company.CompanyName = Convert.ToString(dr["COMPANY_NAME"]);
                            }
                            Temp.RequestedBy = Convert.ToString(dr["F_NAME"]);
                            Temp.Post = Convert.ToString(dr["POST"]);
                            Temp.Bps = Convert.ToString(dr["BPS"]);
                            Temp.VisitPurpose = Convert.ToString(dr["VISIT_PURPOSE"]);
                            Temp.FromDate = Convert.ToDateTime(dr["FROM_DATE"]);
                            Temp.ToDate = Convert.ToDateTime(dr["TO_DATE"]);
                            Temp.Remarks = Convert.ToString(dr["REMARKS"]);
                            if (dr["SATURDAY"] != DBNull.Value)
                                Temp.Saturday = Convert.ToInt32(dr["SATURDAY"]);
                            if (dr["SUNDAY"] != DBNull.Value)
                                Temp.Sunday = Convert.ToInt32(dr["SUNDAY"]);
                            Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                            Temp.PassTypeId = Convert.ToInt32(dr["PASS_TYPE_ID"]);
                            Temp.PassTypes = new PassTypes();
                            Temp.PassTypes.PassTypeId = Convert.ToInt32(dr["PASS_TYPE_ID"]);
                            Temp.PassTypes.Description = Convert.ToString(dr["PASS_TYPE"]);
                            if (dr["SATURDAY"] != DBNull.Value)
                                Temp.Saturday = Convert.ToInt32(dr["SATURDAY"]);
                            if (dr["SUNDAY"] != DBNull.Value)
                                Temp.Sunday = Convert.ToInt32(dr["SUNDAY"]);
                            MyList.Add(Temp);
                        }
                    }

                    if (MyList != null) MyList.TrimExcess();
                    return MyList;
                }
            }
            finally
            {
                con.Close();
            }
        }
        public int GetPK(string TableName, string FieldName)
        {
            return new DalHelper().GetPk(TableName, FieldName);
        }
        public void InsertVisitorPass(VisitorPasses Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                // int pk = GetPK("VIS_VISITOR_PASSES", "PASS_ID");
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_PASS";
                cmd.Parameters.Add("@PassId", SqlDbType.VarChar).Value = Temp.PassId;
                DateTime date = DateTime.Now;
                cmd.Parameters.Add("@PassCode", SqlDbType.VarChar).Value = date.Day.ToString() + date.Month.ToString() + date.Year.ToString() + Temp.PassId.Substring(0,3) + Temp.PassId.Substring(6, 1);
                cmd.Parameters.Add("@RequestedBy", SqlDbType.Int).Value = Temp.RequestedById;
                cmd.Parameters.Add("@PassDate", SqlDbType.Date).Value = Temp.PassDate;
                if (Temp.CompanyId == 0 && !string.IsNullOrEmpty(Temp.Company.CompanyName))
                {
                    Temp.CompanyId = InsertCompany(Temp.Company.CompanyName);

                }
                if (Temp.CompanyId != 0)
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = Temp.CompanyId;
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = Temp.BranchId;
                cmd.Parameters.Add("@PassTypeId", SqlDbType.Int).Value = Temp.PassTypeId;
                cmd.Parameters.Add("@Purpose", SqlDbType.VarChar).Value = Temp.VisitPurpose;
                cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = Temp.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = Temp.ToDate;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Temp.Remarks;
                cmd.Parameters.Add("@Saturday", SqlDbType.Int).Value = Temp.Saturday;
                cmd.Parameters.Add("@Sunday", SqlDbType.Int).Value = Temp.Sunday;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                List<Visitors> visitors = GetTempVisitors(Temp.PassId);
                if (visitors != null)
                {
                    foreach (Visitors vis in visitors)
                    {
                        InsertVisitor(vis);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }

        public void UpdateVisitorPass(VisitorPasses Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_PASS";
                cmd.Parameters.Add("@PassId", SqlDbType.VarChar).Value = Temp.PassId;
                cmd.Parameters.Add("@RequestedBy", SqlDbType.Int).Value = Temp.RequestedById;
                cmd.Parameters.Add("@PassDate", SqlDbType.Date).Value = Temp.PassDate;
                if (Temp.CompanyId == 0 && !string.IsNullOrEmpty(Temp.Company.CompanyName))
                {
                    Temp.CompanyId = InsertCompany(Temp.Company.CompanyName);
                }
                if (Temp.CompanyId != 0)
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = Temp.CompanyId;

                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = Temp.BranchId;
                cmd.Parameters.Add("@PassTypeId", SqlDbType.VarChar).Value = Temp.PassTypeId;
                cmd.Parameters.Add("@Purpose", SqlDbType.VarChar).Value = Temp.VisitPurpose;
                cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = Temp.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = Temp.ToDate;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Temp.Remarks;
                cmd.Parameters.Add("@Sunday", SqlDbType.Int).Value = Temp.Sunday;
                cmd.Parameters.Add("@Saturday", SqlDbType.Int).Value = Temp.Saturday;
                cmd.Parameters.Add("@IsActive", SqlDbType.VarChar).Value = Temp.IsActive;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void VerifyPass(int PassId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "VERIFY_PASS";
                cmd.Parameters.Add("@PassId", SqlDbType.Int).Value = PassId;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void UnVerifyPass(int PassId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UN_VERIFY_PASS";
                cmd.Parameters.Add("@PassId", SqlDbType.Int).Value = PassId;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion MENU

        #region Visitors
        public List<Visitors> GetVisitors(string PassId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_VISITORS";
                cmd.Parameters.Add("@PassId", SqlDbType.VarChar).Value = PassId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Visitors> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Visitors>();
                    while (dr.Read())
                    {
                        Visitors Temp = new Visitors();

                        Temp.VisitorId = Convert.ToInt32(dr["PASS_VISITOR_ID"]);
                        Temp.VisitorName = Convert.ToString(dr["VISITOR_NAME"]);
                        Temp.Cnic = Convert.ToString(dr["CNIC"]);
                        Temp.Details = Convert.ToString(dr["DETAILS"]);
                        Temp.Verified = Convert.ToInt32(dr["VERIFIED"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }


        public void InsertVisitor(Visitors Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_VISITOR";

                cmd.Parameters.Add("@VisitorName", SqlDbType.VarChar).Value = Temp.VisitorName;
                cmd.Parameters.Add("@Cnic", SqlDbType.VarChar).Value = Temp.Cnic;
                cmd.Parameters.Add("@Details", SqlDbType.VarChar).Value = Temp.Details;
                cmd.Parameters.Add("@PassId", SqlDbType.VarChar).Value = Temp.PassId;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }

        public void UpdateVisitor(Visitors Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_VISITOR";
                cmd.Parameters.Add("@PassVisitorId", SqlDbType.Int).Value = Temp.VisitorId;
                cmd.Parameters.Add("@VisitorName", SqlDbType.VarChar).Value = Temp.VisitorName;
                cmd.Parameters.Add("@Cnic", SqlDbType.VarChar).Value = Temp.Cnic;
                cmd.Parameters.Add("@Details", SqlDbType.VarChar).Value = Temp.Details;
                cmd.Parameters.Add("@PassId", SqlDbType.VarChar).Value = Temp.PassId;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void VerifyPassVisitor(int PassVisitorId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "VERIFY_VISITOR";
                cmd.Parameters.Add("@PassVisitorId", SqlDbType.Int).Value = PassVisitorId;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void UnVerifyPassVisitor(int PassVisitorId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UN_VERIFY_VISITOR";
                cmd.Parameters.Add("@PassVisitorId", SqlDbType.Int).Value = PassVisitorId;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void DeleteVisitor(int VisitorId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_VISITOR";
                cmd.Parameters.Add("@PassVisitorId", SqlDbType.Int).Value = VisitorId;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        //public List<Visitors> GetVisitorByName(string name)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_VISITOR_BY_NAME";
        //        cmd.Parameters.Add("@Fname", SqlDbType.VarChar).Value = name;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<Visitors> visitors = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            visitors = new List<Visitors>();
        //            while(dr.Read())
        //            {
        //                Visitors Temp = new Visitors();
        //                Temp.VisitorName = Convert.ToString(dr["VISITOR_NAME"]);
        //                Temp.Cnic = Convert.ToString(dr["CNIC"]);
        //                visitors.Add(Temp);
        //            }

        //        }
        //        return visitors;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}
        //public List<Visitors> GetVisitorByCNIC(string cnic)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_VISITOR_BY_CNIC";
        //        cmd.Parameters.Add("@Cnic", SqlDbType.VarChar).Value = cnic;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<Visitors> visitors = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            visitors = new List<Visitors>();
        //            while (dr.Read())
        //            {
        //                Visitors Temp = new Visitors();
        //                Temp.VisitorName = Convert.ToString(dr["VISITOR_NAME"]);
        //                Temp.Cnic = Convert.ToString(dr["CNIC"]);
        //                visitors.Add(Temp);
        //            }

        //        }
        //        return visitors;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}
        #endregion
        #region Temp Visitor
        public List<Visitors> GetTempVisitors(string PassId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_TEMP_VISITORS";
                cmd.Parameters.Add("@PassId", SqlDbType.VarChar).Value = PassId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Visitors> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Visitors>();
                    while (dr.Read())
                    {
                        Visitors Temp = new Visitors();
                        Temp.PassId = Convert.ToString(dr["PASS_ID"]);
                        Temp.VisitorId = Convert.ToInt32(dr["PASS_VISITOR_ID"]);
                        Temp.VisitorName = Convert.ToString(dr["VISITOR_NAME"]);
                        Temp.Cnic = Convert.ToString(dr["CNIC"]);
                        Temp.Details = Convert.ToString(dr["DETAILS"]);
                        Temp.Verified = Convert.ToInt32(dr["VERIFIED"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }


        public void InsertTempVisitor(Visitors Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_TEMP_VISITOR";
                cmd.Parameters.Add("@VisitorName", SqlDbType.VarChar).Value = Temp.VisitorName;
                cmd.Parameters.Add("@Cnic", SqlDbType.VarChar).Value = Temp.Cnic;
                cmd.Parameters.Add("@Details", SqlDbType.VarChar).Value = Temp.Details;
                cmd.Parameters.Add("@PassId", SqlDbType.VarChar).Value = Temp.PassId;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }

        public void UpdateTempVisitor(Visitors Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_TEMP_VISITOR";
                cmd.Parameters.Add("@PassVisitorId", SqlDbType.Int).Value = Temp.VisitorId;
                cmd.Parameters.Add("@VisitorName", SqlDbType.VarChar).Value = Temp.VisitorName;
                cmd.Parameters.Add("@Cnic", SqlDbType.VarChar).Value = Temp.Cnic;
                cmd.Parameters.Add("@Details", SqlDbType.VarChar).Value = Temp.Details;
                cmd.Parameters.Add("@PassId", SqlDbType.VarChar).Value = Temp.PassId;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void DeleteTempVisitor(int VisitorId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_TEMP_VISITOR";
                cmd.Parameters.Add("@PassVisitorId", SqlDbType.Int).Value = VisitorId;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void DeleteTempVisitors(int PassId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_TEMP_VISITORS";
                cmd.Parameters.Add("@PassId", SqlDbType.Int).Value = PassId;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion
        public List<Member> GetEmployeeByName(string MemberName)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMPLOYEE_BY_NAME";
                cmd.Parameters.Add("@FName", SqlDbType.VarChar).Value = MemberName;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Member> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Member>();
                    while (dr.Read())
                    {
                        Member Temp = new Member();

                        Temp.MemberId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        Temp.MemberName = Convert.ToString(dr["F_NAME"]) + " (" + Convert.ToString(dr["POST"]) + ")";
                        Temp.Post = Convert.ToString(dr["POST"]);
                        Temp.PostId = Convert.ToInt32(dr["POST_HELD"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }

        public List<Visitors> GetVisitorByName(string MemberName)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_VISITOR_BY_NAME";
                cmd.Parameters.Add("@FName", SqlDbType.VarChar).Value = MemberName;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Visitors> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Visitors>();
                    while (dr.Read())
                    {
                        Visitors Temp = new Visitors();
                        Temp.Details = Convert.ToString(dr["VISITOR_NAME"]) + " (" + Convert.ToString(dr["CNIC"]) + ")";
                        Temp.VisitorName = Convert.ToString(dr["VISITOR_NAME"]);
                        Temp.Cnic = Convert.ToString(dr["CNIC"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<Visitors> GetVisitorByCNIC(string CNIC)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_VISITOR_BY_CNIC";
                cmd.Parameters.Add("@Cnic", SqlDbType.VarChar).Value = CNIC;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Visitors> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Visitors>();
                    while (dr.Read())
                    {
                        Visitors Temp = new Visitors();
                        Temp.Details = Convert.ToString(dr["VISITOR_NAME"]) + " (" + Convert.ToString(dr["CNIC"]) + ")";
                        Temp.VisitorName = Convert.ToString(dr["VISITOR_NAME"]);
                        Temp.Cnic = Convert.ToString(dr["CNIC"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }

        #region Compny
        public int InsertCompany(string CompanyName)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                int pk = new DalHelper().GetPk("VIS_COMPANIES", "COMPANY_ID");
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_COMPANY";
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = pk;
                cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = CompanyName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                return pk;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion

        #region WalkInVisitor
        public void AddWalkInVisitor(WalkInVisitor walkInVisitor)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_WALK_IN_VISITOR";
                cmd.Parameters.Add("@VisitorName", SqlDbType.VarChar).Value = walkInVisitor.VisitorName;
                cmd.Parameters.Add("@VisitDate", SqlDbType.DateTime).Value = walkInVisitor.VisitDate;
                cmd.Parameters.Add("@Cnic", SqlDbType.VarChar).Value = walkInVisitor.Cnic;
                cmd.Parameters.Add("@PassTypeId", SqlDbType.Int).Value = walkInVisitor.VisitTypeId;
                if (walkInVisitor.PersonToVisitId != 0)
                    cmd.Parameters.Add("@VisitToId", SqlDbType.Int).Value = walkInVisitor.PersonToVisitId;
                cmd.Parameters.Add("@VisitToName", SqlDbType.VarChar).Value = walkInVisitor.PersonToVisitName;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = walkInVisitor.Details;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }

        public void UpdateWalkInVisitor(WalkInVisitor walkInVisitor)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_WALK_IN_VISITOR";
                cmd.Parameters.Add("@VisitorId", SqlDbType.Int).Value = walkInVisitor.VisitorId;
                cmd.Parameters.Add("@VisitorName", SqlDbType.VarChar).Value = walkInVisitor.VisitorName;
                cmd.Parameters.Add("@VisitDate", SqlDbType.DateTime).Value = walkInVisitor.VisitDate;
                cmd.Parameters.Add("@Cnic", SqlDbType.VarChar).Value = walkInVisitor.Cnic;
                cmd.Parameters.Add("@PassTypeId", SqlDbType.Int).Value = walkInVisitor.VisitTypeId;
                cmd.Parameters.Add("@VisitToId", SqlDbType.Int).Value = walkInVisitor.PersonToVisitId;
                cmd.Parameters.Add("@VisitToName", SqlDbType.VarChar).Value = walkInVisitor.PersonToVisitName;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = walkInVisitor.Details;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void DeleteWalkInVisitor(int VisitorId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_WALK_IN_VISITOR";
                cmd.Parameters.Add("@VisitorId", SqlDbType.Int).Value = VisitorId;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }


        public List<WalkInVisitor> GetWalkInVisitors()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_WALK_IN_VISITORS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<WalkInVisitor> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<WalkInVisitor>();
                    while (dr.Read())
                    {
                        WalkInVisitor Temp = new WalkInVisitor();
                        Temp.VisitorId = Convert.ToInt32(dr["VISITOR_ID"]);
                        Temp.VisitorName = Convert.ToString(dr["VISITOR_NAME"]) + " (" + Convert.ToString(dr["CNIC"]) + ")";
                        Temp.Cnic = Convert.ToString(dr["CNIC"]);
                        Temp.VisitDate = Convert.ToDateTime(dr["VISIT_DATE"]);
                        if (dr["VISIT_TO_ID"] != DBNull.Value)
                            Temp.PersonToVisitId = Convert.ToInt32(dr["VISIT_TO_ID"]);
                        Temp.PersonToVisitName = Convert.ToString(dr["VISIT_TO_NAME"]);
                        Temp.Details = Convert.ToString(dr["REMARKS"]);
                        Temp.VisitTypeId = Convert.ToInt32(dr["VISIT_PASS_TYPE_ID"]);
                        Temp.VisitType = Convert.ToString(dr["PASS_TYPE"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion
        #region Vehicle types
        public List<VehicleTypes> GetVehicleTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[VISITOR_MANAGEMENT]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_VEHICLE_TYPES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<VehicleTypes> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<VehicleTypes>();
                    while (dr.Read())
                    {
                        VehicleTypes Temp = new VehicleTypes();
                        Temp.VehicleTypeId = Convert.ToInt32(dr["VEHICLE_TYPE_ID"]);
                        Temp.VehicleType = Convert.ToString(dr["VEHICLE_TYPE"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion
    }
}
