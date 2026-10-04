using BUDENTITIES;
using IPRDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUDDAL
{
    public class BudgetDal
    {
        #region GET FUND CENTER
        public List<FundCenters> GetFundCenters()
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_POOLS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<FundCenters> fundcenter = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    fundcenter = new List<FundCenters>();
                    while (dr.Read())
                    {
                        FundCenters cy = new FundCenters();
                        cy.FundCenterId = Convert.ToInt32(dr["EMPLOYEE_POOLS_ID"]);
                        cy.FundCenter = Convert.ToString(dr["Description"]);
                        fundcenter.Add(cy);
                    }
                }

                if (fundcenter != null) fundcenter.TrimExcess();
                return fundcenter;
            }
            finally
            {
                con.Close();

            }
        }
        public List<FundCenters> GetFundCentersList()
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_POOLS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<FundCenters> fundcenter = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    fundcenter = new List<FundCenters>();
                    while (dr.Read())
                    {
                        FundCenters cy = new FundCenters();
                        cy.FundCenterId = Convert.ToInt32(dr["EMPLOYEE_POOLS_ID"]);
                        cy.FundCenter = Convert.ToString(dr["Description"]);
                        cy.majorObjects = GetActiveMajorObjectsByPool(cy.FundCenterId);
                        fundcenter.Add(cy);
                    }
                }

                if (fundcenter != null) fundcenter.TrimExcess();
                return fundcenter;
            }
            finally
            {
                con.Close();

            }
        }
        public FundCenters GetFundCenter(int FundCenterId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_POOL";
                cmd.Parameters.Add("@FundCenterId", SqlDbType.Int).Value = FundCenterId;
                cmd.CommandType = CommandType.StoredProcedure;
                FundCenters cy = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    cy = new FundCenters();
                    cy.FundCenterId = Convert.ToInt32(dr["EMPLOYEE_POOLS_ID"]);
                    cy.FundCenter = Convert.ToString(dr["Description"]);
                }


                return cy;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion GET FUND CENTER
        #region FINANCIAL YEAR

        public List<FinancialYears> GetFinancialYears()
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_FINANCIAL_YEARS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<FinancialYears> TempList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    TempList = new List<FinancialYears>();
                    while (dr.Read())
                    {
                        FinancialYears obj = new FinancialYears();
                        obj.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                        obj.FinancialYear = Convert.ToString(dr["FINANCIAL_YEAR"]);
                        obj.FromDate = Convert.ToDateTime(dr["From_Date"]);
                        obj.ToDate = Convert.ToDateTime(dr["To_Date"]);
                        obj.DemandNumber = Convert.ToString(dr["DEMAND_NUMBER"]);

                        TempList.Add(obj);
                    }
                }

                if (TempList != null) TempList.TrimExcess();
                return TempList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<FinancialYears> GetActiveFinancialYears()
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_FINANCIAL_YEARS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<FinancialYears> TempList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    TempList = new List<FinancialYears>();
                    while (dr.Read())
                    {
                        FinancialYears obj = new FinancialYears();
                        obj.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                        obj.FinancialYear = Convert.ToString(dr["FINANCIAL_YEAR"]);
                        obj.FromDate = Convert.ToDateTime(dr["From_Date"]);
                        obj.ToDate = Convert.ToDateTime(dr["To_Date"]);
                        obj.DemandNumber = Convert.ToString(dr["DEMAND_NUMBER"]);
                        TempList.Add(obj);
                    }
                }

                if (TempList != null) TempList.TrimExcess();
                return TempList;
            }
            finally
            {
                con.Close();

            }
        }
        public FinancialYears GetFinancialYear(int FinancialYearId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_FINANCIAL_YEAR";
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                FinancialYears obj = new FinancialYears();
                obj.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                obj.FinancialYear = Convert.ToString(dr["FINANCIAL_YEAR"]);
                obj.FromDate = Convert.ToDateTime(dr["From_Date"]);
                obj.ToDate = Convert.ToDateTime(dr["To_Date"]);
                obj.DemandNumber = Convert.ToString(dr["DEMAND_NUMBER"]);
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public FinancialYears GetCurrentFinancialYear()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CURRENT_FINANCIAL_YEAR";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                FinancialYears obj = new FinancialYears();
                obj.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                obj.FinancialYear = Convert.ToString(dr["FINANCIAL_YEAR"]);
                obj.FromDate = Convert.ToDateTime(dr["From_Date"]);
                obj.ToDate = Convert.ToDateTime(dr["To_Date"]);
                obj.DemandNumber = Convert.ToString(dr["DEMAND_NUMBER"]);
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public void InsertFinancialYear(FinancialYears financialyear)
        {
            int Id = new DalHelper().GetPk("BUD_FINANCIAL_YEAR", "FINANCIAL_YEAR_ID");
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_FINANCIAL_YEAR";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@FinancialYear", SqlDbType.VarChar).Value = financialyear.FinancialYear;
            cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = financialyear.FromDate;
            cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = financialyear.ToDate;
            cmd.Parameters.Add("@DemandNumber", SqlDbType.VarChar).Value = financialyear.DemandNumber;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
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
        public void UpdateFinancialYear(FinancialYears financialyear)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_FINANCIAL_YEAR";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = financialyear.FinancialYearId;
            cmd.Parameters.Add("@FinancialYear", SqlDbType.VarChar).Value = financialyear.FinancialYear;
            cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = financialyear.FromDate;
            cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = financialyear.ToDate;
            cmd.Parameters.Add("@DemandNumber", SqlDbType.VarChar).Value = financialyear.DemandNumber;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
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
        #endregion FINANCIAL YEAR
        #region MAJOR OBJECT
        public List<MajorObjects> GetMajorObjects()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MAJOR_OBJECTS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<MajorObjects> TempList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    TempList = new List<MajorObjects>();
                    while (dr.Read())
                    {
                        MajorObjects obj = new MajorObjects();
                        obj.MajorObjectId = Convert.ToInt32(dr["MAJOR_OBJECT_ID"]);
                        obj.MajorObject = Convert.ToString(dr["MAJOR_OBJECT"]);
                        obj.FundCenterId = Convert.ToInt32(dr["POOL_ID"]);
                        obj.minorObjects = GetActiveMinorObjectsByMajorObject(obj.MajorObjectId);
                        TempList.Add(obj);
                    }
                }

                if (TempList != null) TempList.TrimExcess();
                return TempList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<MajorObjects> GetActiveMajorObjects()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_MAJOR_OBJECTS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<MajorObjects> TempList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    TempList = new List<MajorObjects>();
                    while (dr.Read())
                    {
                        MajorObjects obj = new MajorObjects();
                        obj.MajorObjectId = Convert.ToInt32(dr["MAJOR_OBJECT_ID"]);
                        obj.MajorObject = Convert.ToString(dr["MAJOR_OBJECT"]);
                        obj.FundCenterId = Convert.ToInt32(dr["POOL_ID"]);
                        TempList.Add(obj);
                    }
                }

                if (TempList != null) TempList.TrimExcess();
                return TempList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<MajorObjects> GetActiveMajorObjectsByPool(int FundCenterId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_MAJOR_OBJECTS_BY_POOL";
                cmd.Parameters.Add("@FundCenterId", SqlDbType.Int).Value = FundCenterId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<MajorObjects> TempList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    TempList = new List<MajorObjects>();
                    while (dr.Read())
                    {
                        MajorObjects obj = new MajorObjects();
                        obj.MajorObjectId = Convert.ToInt32(dr["MAJOR_OBJECT_ID"]);
                        obj.MajorObject = Convert.ToString(dr["MAJOR_OBJECT"]);
                        obj.FundCenterId = Convert.ToInt32(dr["POOL_ID"]);
                        obj.minorObjects = GetActiveMinorObjectsByMajorObject(obj.MajorObjectId);
                        TempList.Add(obj);
                    }
                }

                if (TempList != null) TempList.TrimExcess();
                return TempList;
            }
            finally
            {
                con.Close();

            }
        }
        public MajorObjects GetMajorObject(int MajorObjectId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MAJOR_OBJECT";
                cmd.Parameters.Add("@MajorObjectId", SqlDbType.Int).Value = MajorObjectId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                MajorObjects obj = new MajorObjects();
                obj.MajorObjectId = Convert.ToInt32(dr["MAJOR_OBJECT_ID"]);
                obj.MajorObject = Convert.ToString(dr["MAJOR_OBJECT"]);
                obj.FundCenterId = Convert.ToInt32(dr["POOL_ID"]);
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public void InsertMajorObject(MajorObjects majorobject)
        {
            int Id = new DalHelper().GetPk("BUD_MAJOR_OBJECTS", "MAJOR_OBJECT_ID");
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MAJOR_OBJECT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MajorObjectId", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@MajorObject", SqlDbType.VarChar).Value = majorobject.MajorObject;
            cmd.Parameters.Add("@FundCenterId", SqlDbType.Int).Value = majorobject.FundCenterId;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = 1;

            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
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
        public void UpdateMajorObject(MajorObjects majorobject)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MAJOR_OBJECT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MajorObjectId", SqlDbType.Int).Value = majorobject.MajorObjectId;
            cmd.Parameters.Add("@MajorObject", SqlDbType.VarChar).Value = majorobject.MajorObject;
            cmd.Parameters.Add("@FundCenterId", SqlDbType.Int).Value = majorobject.FundCenterId;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = 1;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
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
        #endregion MAJOR OBJECT
        #region MINOR OBJECT
        public List<MinorObjects> GetMinorObjects()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_Minor_OBJECTS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<MinorObjects> TempList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    TempList = new List<MinorObjects>();
                    while (dr.Read())
                    {
                        MinorObjects obj = new MinorObjects();
                        obj.MinorObjectId = Convert.ToInt32(dr["Minor_OBJECT_ID"]);
                        obj.MinorObject = Convert.ToString(dr["Minor_OBJECT"]);
                        obj.MajorObjectId = Convert.ToInt32(dr["MAJOR_OBJECT_ID"]);
                        obj.headOfAccounts = GetHeadOfAccounts(obj.MinorObjectId);
                        TempList.Add(obj);
                    }
                }

                if (TempList != null) TempList.TrimExcess();
                return TempList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<MinorObjects> GetActiveMinorObjects()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_MINOR_OBJECTS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<MinorObjects> TempList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    TempList = new List<MinorObjects>();
                    while (dr.Read())
                    {
                        MinorObjects obj = new MinorObjects();
                        obj.MinorObjectId = Convert.ToInt32(dr["Minor_OBJECT_ID"]);
                        obj.MinorObject = Convert.ToString(dr["Minor_OBJECT"]);
                        obj.MajorObjectId = Convert.ToInt32(dr["MAJOR_OBJECT_ID"]);
                        TempList.Add(obj);
                    }
                }

                if (TempList != null) TempList.TrimExcess();
                return TempList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<MinorObjects> GetActiveMinorObjectsByMajorObject(int MajorObjectId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_MINOR_OBJECTS_BY_MAJOR";
                cmd.Parameters.Add("@MajorObjectId", SqlDbType.Int).Value = MajorObjectId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<MinorObjects> TempList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    TempList = new List<MinorObjects>();
                    while (dr.Read())
                    {
                        MinorObjects obj = new MinorObjects();
                        obj.MinorObjectId = Convert.ToInt32(dr["Minor_OBJECT_ID"]);
                        obj.MinorObject = Convert.ToString(dr["Minor_OBJECT"]);
                        obj.MajorObjectId = Convert.ToInt32(dr["MAJOR_OBJECT_ID"]);
                        obj.headOfAccounts = GetHeadOfAccounts(obj.MinorObjectId);
                        TempList.Add(obj);
                    }
                }

                if (TempList != null) TempList.TrimExcess();
                return TempList;
            }
            finally
            {
                con.Close();

            }
        }
        public MinorObjects GetMinorObject(int MinorObjectId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MINOR_OBJECT";
                cmd.Parameters.Add("@MinorObjectId", SqlDbType.Int).Value = MinorObjectId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                MinorObjects obj = new MinorObjects();
                obj.MinorObjectId = Convert.ToInt32(dr["Minor_OBJECT_ID"]);
                obj.MinorObject = Convert.ToString(dr["Minor_OBJECT"]);
                obj.MajorObjectId = Convert.ToInt32(dr["MAJOR_OBJECT_ID"]);
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public void InsertMinorObject(MinorObjects Minorobject)
        {
            int Id = new DalHelper().GetPk("BUD_MINOR_OBJECTS", "MINOR_OBJECT_ID");
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MINOR_OBJECT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MinorObjectId", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@MinorObject", SqlDbType.VarChar).Value = Minorobject.MinorObject;
            cmd.Parameters.Add("@MajorObjectId", SqlDbType.Int).Value = Minorobject.MajorObjectId;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = 1;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
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
        public void UpdateMinorObject(MinorObjects Minorobject)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MINOR_OBJECT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MinorObjectId", SqlDbType.Int).Value = Minorobject.MinorObjectId;
            cmd.Parameters.Add("@MinorObject", SqlDbType.VarChar).Value = Minorobject.MinorObject;
            cmd.Parameters.Add("@MajorObjectId", SqlDbType.Int).Value = Minorobject.MajorObjectId;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = 1;
            try
            {
                cmd.ExecuteReader();
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
        #endregion MINOR OBJECT
        #region HEAD OF ACCOUNT
        public List<HeadOfAccounts> GetHeadOfAccounts(int MinorObjectId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_HEAD_OF_ACCOUNTS";
                cmd.Parameters.Add("@MinorObjectId", SqlDbType.Int).Value = MinorObjectId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<HeadOfAccounts> TempList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    TempList = new List<HeadOfAccounts>();
                    while (dr.Read())
                    {
                        HeadOfAccounts obj = new HeadOfAccounts();
                        obj.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                        obj.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                        obj.MinorObjectId = Convert.ToInt32(dr["MINOR_OBJECT_ID"]);
                        TempList.Add(obj);
                    }
                }

                if (TempList != null) TempList.TrimExcess();
                return TempList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<HeadOfAccounts> GetActiveHeadOfAccounts()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_HEAD_OF_ACCOUNTS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<HeadOfAccounts> TempList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    TempList = new List<HeadOfAccounts>();
                    while (dr.Read())
                    {
                        HeadOfAccounts obj = new HeadOfAccounts();
                        obj.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                        obj.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                        obj.MinorObjectId = Convert.ToInt32(dr["MINOR_OBJECT_ID"]);
                        TempList.Add(obj);
                    }
                }

                if (TempList != null) TempList.TrimExcess();
                return TempList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<HeadOfAccounts> GetHeadOfAccountsByName(string HeadOfAccount)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_HEAD_OF_ACCOUNT_BY_NAME";
                cmd.Parameters.Add("@HeadOfAccount", SqlDbType.VarChar).Value = HeadOfAccount;
                cmd.CommandType = CommandType.StoredProcedure;
                List<HeadOfAccounts> TempList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    TempList = new List<HeadOfAccounts>();
                    while (dr.Read())
                    {
                        HeadOfAccounts obj = new HeadOfAccounts();
                        obj.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                        obj.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                        TempList.Add(obj);
                    }
                }

                if (TempList != null) TempList.TrimExcess();
                return TempList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<HeadOfAccounts> GetFromHeadOfAccountsWithBudget(string HeadOfAccount, int fy)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_FROM_HEAD_OF_ACCOUNT_WITH_BUDGET";
                cmd.Parameters.Add("@HeadOfAccount", SqlDbType.VarChar).Value = HeadOfAccount;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = fy;
                cmd.CommandType = CommandType.StoredProcedure;
                List<HeadOfAccounts> TempList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    TempList = new List<HeadOfAccounts>();
                    while (dr.Read())
                    {
                        HeadOfAccounts obj = new HeadOfAccounts();
                        obj.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                        obj.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                        obj.RemainingAmount = Convert.ToDouble(dr["CURRENT_AMOUNT"]);
                        TempList.Add(obj);
                    }
                }

                if (TempList != null) TempList.TrimExcess();
                return TempList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<HeadOfAccounts> GetToHeadOfAccountsWithBudget(string HeadOfAccount, int fy)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_TO_HEAD_OF_ACCOUNT_WITH_BUDGET";
                cmd.Parameters.Add("@HeadOfAccount", SqlDbType.VarChar).Value = HeadOfAccount;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = fy;
                cmd.CommandType = CommandType.StoredProcedure;
                List<HeadOfAccounts> TempList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    TempList = new List<HeadOfAccounts>();
                    while (dr.Read())
                    {
                        HeadOfAccounts obj = new HeadOfAccounts();
                        obj.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                        obj.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                        obj.RemainingAmount = Convert.ToDouble(dr["CURRENT_AMOUNT"]);
                        TempList.Add(obj);
                    }
                }

                if (TempList != null) TempList.TrimExcess();
                return TempList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<HeadOfAccounts> GetBranchHeadOfAccountsWithBudget(string HeadOfAccount, int fy, int BranchId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BRANCH_HOA_BY_NAME";
                cmd.Parameters.Add("@HeadOfAccount", SqlDbType.VarChar).Value = HeadOfAccount;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = fy;
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = BranchId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<HeadOfAccounts> TempList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    TempList = new List<HeadOfAccounts>();
                    while (dr.Read())
                    {
                        HeadOfAccounts obj = new HeadOfAccounts();
                        obj.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                        obj.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]) + " (" + FormatAmount(Convert.ToDouble(dr["CURRENT_AMOUNT"])) + ")";
                        obj.RemainingAmount = Convert.ToDouble(dr["CURRENT_AMOUNT"]);
                        TempList.Add(obj);
                    }
                }

                if (TempList != null) TempList.TrimExcess();
                return TempList;
            }
            finally
            {
                con.Close();

            }
        }
        protected string FormatAmount(double Amount)
        {
            return String.Format("{0:#,##0}", Convert.ToDecimal(Amount));
        }
        public List<HeadOfAccounts> GetActiveHeadOfAccountsByMinorObject(int MinorObjectId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_HEAD_OF_ACCOUNTS_BY_MINOR";
                cmd.Parameters.Add("@MinorObjectId", SqlDbType.Int).Value = MinorObjectId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<HeadOfAccounts> TempList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    TempList = new List<HeadOfAccounts>();
                    while (dr.Read())
                    {
                        HeadOfAccounts obj = new HeadOfAccounts();
                        obj.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                        obj.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                        obj.MinorObjectId = Convert.ToInt32(dr["MINOR_OBJECT_ID"]);
                        TempList.Add(obj);
                    }
                }

                if (TempList != null) TempList.TrimExcess();
                return TempList;
            }
            finally
            {
                con.Close();

            }
        }
        public HeadOfAccounts GetHeadOfAccount(int HeadOfAccountId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MINOR_OBJECT";
                cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = HeadOfAccountId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                HeadOfAccounts obj = new HeadOfAccounts();
                obj.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                obj.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                obj.MinorObjectId = Convert.ToInt32(dr["MINOR_OBJECT_ID"]);
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public void InsertHeadOfAccount(HeadOfAccounts HeadOfAccount)
        {
            int Id = new DalHelper().GetPk("BUD_HEAD_OF_ACCOUNTS", "HEAD_OF_ACCOUNT_ID");
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_HEAD_OF_ACCOUNTS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@HeadOfAccount", SqlDbType.VarChar).Value = HeadOfAccount.HeadOfAccount;
            cmd.Parameters.Add("@MinorObjectId", SqlDbType.Int).Value = HeadOfAccount.MinorObjectId;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = HeadOfAccount.IsActive;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
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
        public void UpdateHeadOfAccount(HeadOfAccounts HeadOfAccount)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_HEAD_OF_ACCOUNTS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = HeadOfAccount.HeadOfAccountId;
            cmd.Parameters.Add("@HeadOfAccount", SqlDbType.VarChar).Value = HeadOfAccount.HeadOfAccount;
            cmd.Parameters.Add("@MinorObjectId", SqlDbType.Int).Value = HeadOfAccount.MinorObjectId;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = HeadOfAccount.IsActive;
            try
            {
                cmd.ExecuteReader();
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
        #endregion HEAD OF ACCOUNT
        #region BUDGET

        public HeadOfAccountBudget GetHeadOfAccountBudget(int HeadOfAccountId, int FinancialYearId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_HOA_FY_BUDGET";
                cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = HeadOfAccountId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                HeadOfAccountBudget obj = new HeadOfAccountBudget();
                if (dr.HasRows)
                {
                    dr.Read();
                    obj.HeadOfAccountBudgetId = Convert.ToInt32(dr["HOA_FY_BUDGET_ID"]);
                    obj.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                    obj.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                    obj.Amount = Convert.ToDouble(dr["AMOUNT_ALLOCATED"]);
                    obj.RemainingBalance = Convert.ToDouble(dr["CURRENT_AMOUNT"]);
                }
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
        public HeadOfAccountBudget GetBranchBudget(int HeadOfAccountId, int FinancialYearId, int BranchId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BRANCH_BUDGET";
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = BranchId;
                cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = HeadOfAccountId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                HeadOfAccountBudget obj = new HeadOfAccountBudget();
                if (dr.HasRows)
                {
                    dr.Read();
                    obj.HeadOfAccountBudgetId = Convert.ToInt32(dr["BRANCH_HEAD_ID"]);
                    obj.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                    obj.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEARS_ID"]);
                    obj.Amount = Convert.ToDouble(dr["BUDGET_LIMIT"]);
                    obj.RemainingBalance = Convert.ToDouble(dr["REMAINING_BUDGET"]);
                }
                return obj;
            }
            finally
            {
                con.Close();
            }
        }

        public void InsertHeadOfAccountBudget(HeadOfAccountBudget headOfAccountBudget)
        {

            int Id = new DalHelper().GetPk("BUD_HOA_FY_BUDGET", "HOA_FY_BUDGET_ID");
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_HOA_FY_BUDGET";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@HoaFyBudgetId", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = headOfAccountBudget.HeadOfAccountId;
            cmd.Parameters.Add("@FinancialYearId", SqlDbType.VarChar).Value = headOfAccountBudget.FinancialYearId;
            cmd.Parameters.Add("@AmountAllocated", SqlDbType.Decimal).Value = headOfAccountBudget.Amount;
            cmd.Connection = con;
            try
            {
                HeadOfAccountBudget hoab = GetHeadOfAccountBudget(headOfAccountBudget.HeadOfAccountId, headOfAccountBudget.FinancialYearId);
                if (hoab.HeadOfAccountBudgetId == 0)
                {
                    cmd.ExecuteReader();
                }
                else
                    UpdateHeadOfAccountBudget(headOfAccountBudget);
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
        public void UpdateHeadOfAccountBudget(HeadOfAccountBudget headOfAccountBudget)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_HOA_FY_BUDGET";
            cmd.CommandType = CommandType.StoredProcedure;
            // cmd.Parameters.Add("@HoaFyBudgetId", SqlDbType.Int).Value = headOfAccountBudget.HeadOfAccountBudgetId;
            cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = headOfAccountBudget.HeadOfAccountId;
            cmd.Parameters.Add("@FinancialYearId", SqlDbType.VarChar).Value = headOfAccountBudget.FinancialYearId;
            cmd.Parameters.Add("@AmountAllocated", SqlDbType.Decimal).Value = headOfAccountBudget.Amount;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
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
        #endregion BUDGET
        #region HEAD_OF_ACCOUNT_BILLS
        public Bills GetBill(int BillId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILL_BY_ID";
                cmd.Parameters.Add("@BillId", SqlDbType.Int).Value = BillId;
                cmd.CommandType = CommandType.StoredProcedure;
                Bills cy = new Bills();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    cy.BillId = Convert.ToInt32(dr["BILL_ID"]);
                    cy.BranchId = Convert.ToInt32(dr["BRANCH_ID"]);
                    cy.VendorId = Convert.ToInt32(dr["VENDOR_ID"]);
                    cy.BillTypeId = Convert.ToInt32(dr["BILL_TYPE_ID"]);
                    cy.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                    cy.BillDescription = Convert.ToString(dr["BILL_SUBJECT"]);
                    cy.BillNumber = Convert.ToString(dr["BILL_NUMBER"]);
                    if (dr["BILL_DATE"] != DBNull.Value)
                        cy.BillDate = Convert.ToDateTime(dr["BILL_DATE"]);
                    cy.VendorNumber = Convert.ToString(dr["VENDOR_NUMBER"]);
                    cy.TotalAmount = Convert.ToDouble(dr["TOTAL_AMOUNT"]);
                    cy.IncomeTax = Convert.ToDouble(dr["INCOME_TAX"]);
                    cy.Gst = Convert.ToDouble(dr["GST"]);
                    cy.NetAmount = Convert.ToDouble(dr["NET_AMOUNT"]);
                    cy.ChequeNumber = Convert.ToString(dr["CHEQUE_NUMBER"]);
                    if (dr["CHEQUE_DATE"] != DBNull.Value)
                        cy.ChequeDate = Convert.ToDateTime(dr["CHEQUE_DATE"]);
                    cy.BillStatusId = Convert.ToInt32(dr["BILL_STATUS_ID"]);
                    cy.BillStatusDesc = Convert.ToString(dr["BILL_STATUS"]);
                    cy.TokenNumber = Convert.ToString(dr["TOKEN_NUMBER"]);
                    cy.VendorName = Convert.ToString(dr["VENDOR"]);
                    cy.BranchName = Convert.ToString(dr["DESCRIPTION"]);
                    cy.BillType = Convert.ToString(dr["BILL_TYPE"]);
                    cy.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                    cy.GeneratedBy = Convert.ToInt32(dr["GENERATED_BY"]);
                    cy.Remarks = Convert.ToString(dr["REMARKS"]);
                }

                return cy;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Bills> GetBranchFinancialYearsBills(int FinancialYearId, int HeadOfAccountId, int BranchId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_HOA_FY_BILLS_BY_BRANCH_ID";
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = HeadOfAccountId;
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = BranchId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Bills> bill = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    bill = new List<Bills>();
                    while (dr.Read())
                    {
                        Bills cy = new Bills();
                        cy.BillId = Convert.ToInt32(dr["BILL_ID"]);
                        cy.BranchId = Convert.ToInt32(dr["BRANCH_ID"]);
                        cy.VendorId = Convert.ToInt32(dr["VENDOR_ID"]);
                        cy.BillTypeId = Convert.ToInt32(dr["BILL_TYPE_ID"]);
                        cy.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                        cy.BillDescription = Convert.ToString(dr["BILL_SUBJECT"]);
                        cy.BillNumber = Convert.ToString(dr["BILL_NUMBER"]);
                        cy.BillDate = Convert.ToDateTime(dr["BILL_DATE"]);
                        cy.VendorNumber = Convert.ToString(dr["VENDOR_NUMBER"]);
                        cy.TotalAmount = Convert.ToDouble(dr["TOTAL_AMOUNT"]);
                        cy.IncomeTax = Convert.ToDouble(dr["INCOME_TAX"]);
                        cy.Gst = Convert.ToDouble(dr["GST"]);
                        cy.NetAmount = Convert.ToDouble(dr["NET_AMOUNT"]);
                        cy.ChequeNumber = Convert.ToString(dr["CHEQUE_NUMBER"]);
                        cy.ChequeDate = Convert.ToDateTime(dr["CHEQUE_DATE"]);
                        cy.TokenNumber = Convert.ToString(dr["TOKEN_NUMBER"]);
                        cy.VendorName = Convert.ToString(dr["VENDOR"]);
                        cy.BranchName = Convert.ToString(dr["DESCRIPTION"]);
                        cy.BillType = Convert.ToString(dr["BILL_TYPE"]);
                        cy.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                        cy.BillStatusId = Convert.ToInt32(dr["BILL_STATUS_ID"]);
                        cy.BillStatusDesc = Convert.ToString(dr["BILL_STATUS"]);
                        cy.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                        cy.GeneratedBy = Convert.ToInt32(dr["GENERATED_BY"]);
                        cy.Remarks = Convert.ToString(dr["REMARKS"]);
                        bill.Add(cy);
                    }
                }

                if (bill != null) bill.TrimExcess();
                return bill;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Bills> GetBranchFinancialYearsBills(string query)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand(query, con);
                List<Bills> bill = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        bill = new List<Bills>();
                        while (dr.Read())
                        {
                            Bills cy = new Bills();
                            cy.BillId = Convert.ToInt32(dr["BILL_ID"]);
                            cy.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                            cy.BranchId = Convert.ToInt32(dr["BRANCH_ID"]);
                            cy.VendorId = Convert.ToInt32(dr["VENDOR_ID"]);
                            cy.BillTypeId = Convert.ToInt32(dr["BILL_TYPE_ID"]);
                            cy.BillStatusId = Convert.ToInt32(dr["BILL_STATUS_ID"]);
                            cy.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                            cy.BillDescription = Convert.ToString(dr["BILL_SUBJECT"]);
                            cy.BillNumber = Convert.ToString(dr["BILL_NUMBER"]);
                            cy.BillDate = Convert.ToDateTime(dr["BILL_DATE"]);
                            cy.SanctionFileNumber = Convert.ToString(dr["SANCTION_FILE_NO"]);
                            if (dr["SANCTION_DATE"] != DBNull.Value)
                                cy.SanctionFileDate = Convert.ToDateTime(dr["SANCTION_DATE"]);
                            cy.VendorNumber = Convert.ToString(dr["VENDOR_NUMBER"]);
                            cy.TotalAmount = Convert.ToDouble(dr["TOTAL_AMOUNT"]);
                            cy.IncomeTax = Convert.ToDouble(dr["INCOME_TAX"]);
                            cy.Gst = Convert.ToDouble(dr["GST"]);
                            cy.NetAmount = Convert.ToDouble(dr["NET_AMOUNT"]);
                            cy.StockRegisterDetails = Convert.ToString(dr["STOCK_REGISTER_DETAILS"]);
                            cy.ChequeNumber = Convert.ToString(dr["CHEQUE_NUMBER"]);
                            if (dr["CHEQUE_DATE"] != DBNull.Value)
                                cy.ChequeDate = Convert.ToDateTime(dr["CHEQUE_DATE"]);
                            cy.TokenNumber = Convert.ToString(dr["TOKEN_NUMBER"]);
                            cy.VendorName = Convert.ToString(dr["VENDOR"]);
                            cy.BranchName = Convert.ToString(dr["DESCRIPTION"]);
                            cy.BillType = Convert.ToString(dr["BILL_TYPE"]);
                            if (dr["SHORT"] != DBNull.Value)
                                cy.ID = Convert.ToString(dr["SHORT"]);
                            cy.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                            cy.BillStatusId = Convert.ToInt32(dr["BILL_STATUS_ID"]);
                            cy.BillStatusDesc = Convert.ToString(dr["BILL_STATUS"]);
                            cy.GeneratedBy = Convert.ToInt32(dr["GENERATED_BY"]);
                            cy.Remarks = Convert.ToString(dr["REMARKS"]);
                            bill.Add(cy);
                        }
                    }

                    if (bill != null) bill.TrimExcess();
                    return bill;
                }
            }
            finally
            {
                con.Close();
            }
        }
        public List<Bills> GetVendorFinancialYearsBills(int FinancialYearId, int HeadOfAccountId, int VendorId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_FY_BILLS_BY_VENDOR_ID";
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = HeadOfAccountId;
                cmd.Parameters.Add("@VendorId", SqlDbType.Int).Value = VendorId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Bills> bill = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    bill = new List<Bills>();
                    while (dr.Read())
                    {
                        Bills cy = new Bills();
                        cy.BillId = Convert.ToInt32(dr["BILL_ID"]);
                        cy.BranchId = Convert.ToInt32(dr["BRANCH_ID"]);
                        cy.VendorId = Convert.ToInt32(dr["VENDOR_ID"]);
                        cy.BillTypeId = Convert.ToInt32(dr["BILL_TYPE_ID"]);
                        cy.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                        cy.BillDescription = Convert.ToString(dr["BILL_SUBJECT"]);
                        cy.BillNumber = Convert.ToString(dr["BILL_NUMBER"]);
                        cy.BillDate = Convert.ToDateTime(dr["BILL_DATE"]);
                        cy.VendorNumber = Convert.ToString(dr["VENDOR_NUMBER"]);
                        cy.TotalAmount = Convert.ToDouble(dr["TOTAL_AMOUNT"]);
                        cy.IncomeTax = Convert.ToDouble(dr["INCOME_TAX"]);
                        cy.Gst = Convert.ToDouble(dr["GST"]);
                        cy.NetAmount = Convert.ToDouble(dr["NET_AMOUNT"]);
                        cy.ChequeNumber = Convert.ToString(dr["CHEQUE_NUMBER"]);
                        cy.ChequeDate = Convert.ToDateTime(dr["CHEQUE_DATE"]);
                        cy.TokenNumber = Convert.ToString(dr["TOKEN_NUMBER"]);
                        cy.VendorName = Convert.ToString(dr["VENDOR"]);
                        cy.BranchName = Convert.ToString(dr["DESCRIPTION"]);
                        cy.BillType = Convert.ToString(dr["BILL_TYPE"]);
                        cy.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                        cy.BillStatusId = Convert.ToInt32(dr["BILL_STATUS_ID"]);
                        cy.BillStatusDesc = Convert.ToString(dr["BILL_STATUS"]);
                        cy.GeneratedBy = Convert.ToInt32(dr["GENERATED_BY"]);
                        cy.Remarks = Convert.ToString(dr["REMARKS"]);
                        bill.Add(cy);
                    }
                }

                if (bill != null) bill.TrimExcess();
                return bill;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Bills> GetEmployeeFinancialYearsBills(int FinancialYearId, int HeadOfAccountId, int EmployeeId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_FY_BILLS_BY_VENDOR_ID";
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = HeadOfAccountId;
                cmd.Parameters.Add("@SystemUserId", SqlDbType.Int).Value = EmployeeId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Bills> bill = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    bill = new List<Bills>();
                    while (dr.Read())
                    {
                        Bills cy = new Bills();
                        cy.BillId = Convert.ToInt32(dr["BILL_ID"]);
                        cy.SystemUserId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        cy.BillTypeId = Convert.ToInt32(dr["BILL_TYPE_ID"]);
                        cy.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                        cy.BillDescription = Convert.ToString(dr["BILL_SUBJECT"]);
                        cy.BillNumber = Convert.ToString(dr["BILL_NUMBER"]);
                        cy.BillDate = Convert.ToDateTime(dr["BILL_DATE"]);
                        cy.VendorNumber = Convert.ToString(dr["VENDOR_NUMBER"]);
                        cy.TotalAmount = Convert.ToDouble(dr["TOTAL_AMOUNT"]);
                        cy.IncomeTax = Convert.ToDouble(dr["INCOME_TAX"]);
                        cy.Gst = Convert.ToDouble(dr["GST"]);
                        cy.NetAmount = Convert.ToDouble(dr["NET_AMOUNT"]);
                        cy.ChequeNumber = Convert.ToString(dr["CHEQUE_NUMBER"]);
                        cy.ChequeDate = Convert.ToDateTime(dr["CHEQUE_DATE"]);
                        cy.TokenNumber = Convert.ToString(dr["TOKEN_NUMBER"]);
                        cy.VendorName = Convert.ToString(dr["VENDOR"]);
                        cy.BranchName = Convert.ToString(dr["DESCRIPTION"]);
                        cy.BillType = Convert.ToString(dr["BILL_TYPE"]);
                        cy.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                        cy.BillStatusId = Convert.ToInt32(dr["BILL_STATUS_ID"]);
                        cy.BillStatusDesc = Convert.ToString(dr["BILL_STATUS"]);
                        cy.GeneratedBy = Convert.ToInt32(dr["GENERATED_BY"]);
                        cy.Remarks = Convert.ToString(dr["REMARKS"]);
                        bill.Add(cy);
                    }
                }

                if (bill != null) bill.TrimExcess();
                return bill;
            }
            finally
            {
                con.Close();
            }
        }
        public int InsertBill(Bills bill)
        {

            int Id = new DalHelper().GetPk("BUD_BILL", "BILL_ID");
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_BILL";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BillId", SqlDbType.Int).Value = Id;
            if (bill.BranchId != 0)
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = bill.BranchId;
            if (bill.SystemUserId != 0)
                cmd.Parameters.Add("@SystemUserId", SqlDbType.Int).Value = bill.SystemUserId;
            cmd.Parameters.Add("@VendorId", SqlDbType.Int).Value = bill.VendorId;
            cmd.Parameters.Add("@BillTypeId", SqlDbType.Int).Value = bill.BillTypeId;
            cmd.Parameters.Add("@BillCategoryId", SqlDbType.Int).Value = bill.BillCategoryId;
            cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = bill.HeadOfAccountId;
            cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = bill.FinancialYearId;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = bill.TotalAmount;
            cmd.Parameters.Add("@IncomeTax", SqlDbType.Decimal).Value = bill.IncomeTax;
            cmd.Parameters.Add("@SanctionFileNumber", SqlDbType.VarChar).Value = bill.SanctionFileNumber;
            cmd.Parameters.Add("@SanctionDate", SqlDbType.Date).Value = bill.SanctionFileDate;
            cmd.Parameters.Add("@GST", SqlDbType.Decimal).Value = bill.Gst;
            cmd.Parameters.Add("@NetAmount", SqlDbType.Decimal).Value = bill.TotalAmount - bill.IncomeTax - bill.Gst;
            cmd.Parameters.Add("@BillNumber", SqlDbType.VarChar).Value = bill.BillNumber;
            cmd.Parameters.Add("@BillDate", SqlDbType.Date).Value = bill.BillDate;
            cmd.Parameters.Add("@BillStatusId", SqlDbType.Int).Value = bill.BillStatusId;
            cmd.Parameters.Add("@BillSubject", SqlDbType.VarChar).Value = bill.BillDescription;
            cmd.Parameters.Add("@VendorNumber", SqlDbType.VarChar).Value = bill.VendorNumber;
            cmd.Parameters.Add("@ChequeNumber", SqlDbType.VarChar).Value = bill.ChequeNumber;
            cmd.Parameters.Add("@ChequeDate", SqlDbType.Date).Value = bill.ChequeDate;
            cmd.Parameters.Add("@TokenNumber", SqlDbType.VarChar).Value = bill.TokenNumber;
            cmd.Parameters.Add("@GeneratedBy", SqlDbType.Int).Value = bill.GeneratedBy;
            cmd.Parameters.Add("@GeneratedOn", SqlDbType.Date).Value = bill.GeneratedOn;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = bill.Remarks;
            cmd.Connection = con;
            try
            {

                cmd.ExecuteReader();
                return Id;

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
        public void UpdateBill(Bills bill)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_BILL";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BillId", SqlDbType.Int).Value = bill.BillId;
            if (bill.BranchId != 0)
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = bill.BranchId;
            if (bill.SystemUserId != 0)
                cmd.Parameters.Add("@SystemUserId", SqlDbType.Int).Value = bill.SystemUserId;
            cmd.Parameters.Add("@VendorId", SqlDbType.Int).Value = bill.VendorId;
            cmd.Parameters.Add("@BillTypeId", SqlDbType.Int).Value = bill.BillTypeId;
            cmd.Parameters.Add("@BillStatusId", SqlDbType.Int).Value = bill.BillStatusId;
            cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = bill.HeadOfAccountId;
            cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = bill.FinancialYearId;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = bill.TotalAmount;
            cmd.Parameters.Add("@IncomeTax", SqlDbType.Decimal).Value = bill.IncomeTax;
            cmd.Parameters.Add("@GST", SqlDbType.Decimal).Value = bill.Gst;
            cmd.Parameters.Add("@StockRegisterDetails", SqlDbType.VarChar).Value = bill.StockRegisterDetails;
            cmd.Parameters.Add("@NetAmount", SqlDbType.Decimal).Value = bill.TotalAmount - bill.IncomeTax - bill.Gst;
            cmd.Parameters.Add("@SanctionFileNumber", SqlDbType.VarChar).Value = bill.SanctionFileNumber;
            cmd.Parameters.Add("@SanctionDate", SqlDbType.Date).Value = bill.SanctionFileDate;
            cmd.Parameters.Add("@BillNumber", SqlDbType.VarChar).Value = bill.BillNumber;
            cmd.Parameters.Add("@BillDate", SqlDbType.Date).Value = bill.BillDate;
            cmd.Parameters.Add("@BillSubject", SqlDbType.VarChar).Value = bill.BillDescription;
            cmd.Parameters.Add("@VendorNumber", SqlDbType.VarChar).Value = bill.VendorNumber;
            cmd.Parameters.Add("@ChequeNumber", SqlDbType.VarChar).Value = bill.ChequeNumber;
            cmd.Parameters.Add("@ChequeDate", SqlDbType.Date).Value = bill.ChequeDate;
            cmd.Parameters.Add("@TokenNumber", SqlDbType.VarChar).Value = bill.TokenNumber;
            cmd.Parameters.Add("@GeneratedOn", SqlDbType.Date).Value = bill.GeneratedOn;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = bill.Remarks;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
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
        public void UpdateBillSanction(Bills bill)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_BILL_SANCTION";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BillId", SqlDbType.Int).Value = bill.BillId;
            cmd.Parameters.Add("@BillStatusId", SqlDbType.Int).Value = bill.BillStatusId;
            cmd.Parameters.Add("@SanctionFileNumber", SqlDbType.VarChar).Value = bill.SanctionFileNumber;
            cmd.Parameters.Add("@SanctionDate", SqlDbType.Date).Value = bill.SanctionFileDate;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
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
        public void DeleteBill(int BillId, int hoaId, int fyid, int BranchId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_BILL";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BillId", SqlDbType.Int).Value = BillId;
            cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = hoaId;
            cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = fyid;
            cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = BranchId;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
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
        #endregion HEAD_OF_ACCOUNT_BILLS
        #region BRANCH
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
                        ad.Branchid = Convert.ToInt32(dr["Branches_ID"]);
                        ad.Description = Convert.ToString(dr["Description"]);
                        ad.Is_active = Convert.ToInt32(dr["Is_Active"]);
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
        public List<Branch> GetBudgetBranches()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BRANCHES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Branch> branches = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    branches = new List<Branch>();
                    while (dr.Read())
                    {
                        Branch ad = new Branch();
                        ad.Branchid = Convert.ToInt32(dr["Branch_ID"]);
                        ad.Description = Convert.ToString(dr["Description"]);
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
        public Branch GetBranch(int BranchId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BRANCH_BY_ID";
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = BranchId;
                cmd.CommandType = CommandType.StoredProcedure;
                Branch branch = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    branch = new Branch();
                    dr.Read();
                    branch.Branchid = Convert.ToInt32(dr["Branches_ID"]);
                    branch.Description = Convert.ToString(dr["Description"]);
                    branch.Is_active = Convert.ToInt32(dr["Is_Active"]);
                }


                return branch;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion BRANCH
        #region VENDOR
        public List<ITVendors> GetVendorByName(string vendorname)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_VENDOR_BY_NAME";
                cmd.Parameters.Add("@VName", SqlDbType.VarChar).Value = vendorname;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ITVendors> vendor = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    vendor = new List<ITVendors>();
                    while (dr.Read())
                    {
                        ITVendors cy = new ITVendors();
                        cy.VendorId = Convert.ToInt32(dr["VENDOR_ID"]);
                        cy.VendorNumber = Convert.ToString(dr["VENDOR_NUMBER"]);
                        cy.NTN = Convert.ToString(dr["NTN"]);
                        cy.Address = Convert.ToString(dr["VEN_ADDRESS"]);
                        cy.Contacts = Convert.ToString(dr["CONTACTS"]);
                        cy.Emails = Convert.ToString(dr["EMAILS"]);
                        cy.Details = Convert.ToString(dr["DETAILS"]);
                        cy.BranchId = Convert.ToInt32(dr["BRANCH_ID"]);
                        cy.Vendor = Convert.ToString(dr["VENDOR"]);
                        vendor.Add(cy);
                    }
                }

                if (vendor != null) vendor.TrimExcess();
                return vendor;
            }
            finally
            {
                con.Close();
            }
        }
        public List<ITVendors> GetVendorByBranch(int BranchId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_VENDOR_BY_BRANCH";
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = BranchId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ITVendors> vendor = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    vendor = new List<ITVendors>();
                    while (dr.Read())
                    {
                        ITVendors cy = new ITVendors();
                        cy.VendorId = Convert.ToInt32(dr["VENDOR_ID"]);
                        cy.Vendor = Convert.ToString(dr["VENDOR"]);
                        cy.VendorNumber = Convert.ToString(dr["VENDOR_NUMBER"]);
                        cy.NTN = Convert.ToString(dr["NTN"]);
                        cy.Address = Convert.ToString(dr["VEN_ADDRESS"]);
                        cy.Contacts = Convert.ToString(dr["CONTACTS"]);
                        cy.Emails = Convert.ToString(dr["EMAILS"]);
                        cy.Details = Convert.ToString(dr["DETAILS"]);
                        cy.BranchId = Convert.ToInt32(dr["BRANCH_ID"]);
                        vendor.Add(cy);
                    }
                }

                if (vendor != null) vendor.TrimExcess();
                return vendor;
            }
            finally
            {
                con.Close();
            }
        }
        public List<ITVendors> GetBranchVendorByName(int BranchId, string vendorname)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BRANCH_VENDOR_BY_NAME";
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = BranchId;
                cmd.Parameters.Add("@VName", SqlDbType.VarChar).Value = vendorname;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ITVendors> vendor = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    vendor = new List<ITVendors>();
                    while (dr.Read())
                    {
                        ITVendors cy = new ITVendors();
                        cy.VendorId = Convert.ToInt32(dr["VENDOR_ID"]);
                        cy.Vendor = Convert.ToString(dr["VENDOR"]);
                        cy.VendorNumber = Convert.ToString(dr["VENDOR_NUMBER"]);
                        cy.NTN = Convert.ToString(dr["NTN"]);
                        cy.Address = Convert.ToString(dr["VEN_ADDRESS"]);
                        cy.Contacts = Convert.ToString(dr["CONTACTS"]);
                        cy.Emails = Convert.ToString(dr["EMAILS"]);
                        cy.Details = Convert.ToString(dr["DETAILS"]);
                        cy.BranchId = Convert.ToInt32(dr["BRANCH_ID"]);
                        vendor.Add(cy);
                    }
                }

                if (vendor != null) vendor.TrimExcess();
                return vendor;
            }
            finally
            {
                con.Close();
            }
        }
        public List<ITVendors> GetVendorById(int vendorId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_VENDOR_BY_ID";
                cmd.Parameters.Add("@VendorId", SqlDbType.Int).Value = vendorId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ITVendors> vendor = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    vendor = new List<ITVendors>();
                    while (dr.Read())
                    {
                        ITVendors cy = new ITVendors();
                        cy.VendorId = Convert.ToInt32(dr["VENDOR_ID"]);
                        cy.Vendor = Convert.ToString(dr["VENDOR"]);
                        cy.VendorNumber = Convert.ToString(dr["VENDOR_NUMBER"]);
                        cy.NTN = Convert.ToString(dr["NTN"]);
                        cy.Address = Convert.ToString(dr["VEN_ADDRESS"]);
                        cy.Contacts = Convert.ToString(dr["CONTACTS"]);
                        cy.Emails = Convert.ToString(dr["EMAILS"]);
                        cy.Details = Convert.ToString(dr["DETAILS"]);
                        cy.BranchId = Convert.ToInt32(dr["BRANCH_ID"]);
                        vendor.Add(cy);
                    }
                }

                if (vendor != null) vendor.TrimExcess();
                return vendor;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion VENDOR
        #region BRANCH HEADS
        public List<BranchHead> GetBranchHeads(int BranchId, int FinancialYearsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BRANCH_HEADS";
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = BranchId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<BranchHead> branchhead = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    branchhead = new List<BranchHead>();
                    while (dr.Read())
                    {
                        BranchHead cy = new BranchHead();
                        cy.BranchHeadId = Convert.ToInt32(dr["BRANCH_HEAD_ID"]);
                        cy.BranchId = Convert.ToInt32(dr["BRANCH_ID"]);
                        cy.Branch = Convert.ToString(dr["BRANCH"]);
                        cy.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                        cy.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]) + " - " + Convert.ToString(dr["REMAINING_BUDGET"]);
                        branchhead.Add(cy);
                    }
                }

                if (branchhead != null) branchhead.TrimExcess();
                return branchhead;
            }
            finally
            {
                con.Close();
            }
        }
        public void InsertBranchHead(BranchHead bh)
        {

            int Id = new DalHelper().GetPk("BUD_BRANCH_HEADS", "BRANCH_HEAD_ID");
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_BRANCH_HEAD";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BranchHeadId", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = bh.BranchId;
            cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = bh.HeadOfAccountId;
            cmd.Connection = con;
            try
            {

                cmd.ExecuteReader();

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
        public void UpdateBranchHead(BranchHead bh)
        {

            // int Id = new DalHelper().GetPk("BUD_BRANCH_HEADS", "BRANCH_HEAD_ID");
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_BRANCH_HEAD";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BranchHeadId", SqlDbType.Int).Value = bh.BranchHeadId;
            cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = bh.BranchId;
            cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = bh.HeadOfAccountId;
            cmd.Connection = con;
            try
            {

                cmd.ExecuteReader();

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
        public void DeleteBranchHead(int BranchHeadId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_BRANCH_HEAD";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BranchHeadId", SqlDbType.Int).Value = BranchHeadId;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
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
        #endregion BRANCH HEADS
        #region RE APPROPRIATION
        public void InsertReAppropriation(ReApproprationEnt bh)
        {

            int Id = new DalHelper().GetPk("BUD_RE_APPROPRIATION", "RE_APPROP_ID");
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_RE_APPROPRIATION";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReApprpriationId", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = bh.FinancialYearId;
            cmd.Parameters.Add("@ReAppropFrom", SqlDbType.Int).Value = bh.FromHeadOfAccountId;
            cmd.Parameters.Add("@ReAppropTo", SqlDbType.Int).Value = bh.ToHeadOfAccountId;
            cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = bh.Amount;
            cmd.Parameters.Add("@ReAppropDate", SqlDbType.DateTime).Value = bh.ReApprpriationDate;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = bh.Remarks;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
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

        public List<ReApproprationEnt> GetHOAReAppropriation(int FY, int HOA)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_HOA_RE_APPROPRIATIONS";
                cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = HOA;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FY;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ReApproprationEnt> reapp = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    reapp = new List<ReApproprationEnt>();
                    while (dr.Read())
                    {
                        ReApproprationEnt cy = new ReApproprationEnt();
                        cy.ReAppropriationId = Convert.ToInt32(dr["RE_APPROP_ID"]);
                        cy.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                        cy.FromHeadOfAccountId = Convert.ToInt32(dr["FROM_HEAD_OF_ACCOUNT_ID"]);
                        cy.FromHeadOfAccount = Convert.ToString(dr["FROM_HEAD_OF_ACCOUNT"]);
                        cy.ToHeadOfAccountId = Convert.ToInt32(dr["TO_HEAD_OF_ACCOUNT_ID"]);
                        cy.ToHeadOfAccount = Convert.ToString(dr["TO_HEAD_OF_ACCOUNT"]);
                        cy.Amount = Convert.ToDouble(dr["AMOUNT"]);
                        cy.ReApprpriationDate = Convert.ToDateTime(dr["RE_APPROP_DATE"]);
                        cy.Remarks = Convert.ToString(dr["REMARKS"]);
                        reapp.Add(cy);
                    }
                }

                if (reapp != null) reapp.TrimExcess();
                return reapp;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion RE APPROPRIATION
        #region BCR
        public List<Bcr> GetBCR(int FinncialYearId, int HeadOfAccountId)
        {
            List<Bcr> bills = new List<Bcr>();
            bills = GetBCRBills(FinncialYearId, HeadOfAccountId);
            List<Bcr> ReApp = GetBCRReAppropriations(FinncialYearId, HeadOfAccountId);
            if (bills == null)
                bills = new List<Bcr>();
            if (ReApp != null)
            {
                foreach (Bcr b in ReApp)
                {
                    bills.Add(b);
                }
            }
            return bills;
        }
        public List<Bcr> GetBCRBills(int FinncialYearId, int HeadOfAccountId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BCR_BILL";
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinncialYearId;
                cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = HeadOfAccountId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Bcr> bill = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    bill = new List<Bcr>();
                    while (dr.Read())
                    {
                        Bcr cy = new Bcr();
                        cy.BillId = Convert.ToInt32(dr["BILL_ID"]);
                        cy.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                        cy.BranchId = Convert.ToInt32(dr["BRANCH_ID"]);
                        cy.VendorId = Convert.ToInt32(dr["VENDOR_ID"]);
                        cy.BillTypeId = Convert.ToInt32(dr["BILL_TYPE_ID"]);
                        cy.BillStatusId = Convert.ToInt32(dr["BILL_STATUS_ID"]);
                        cy.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                        cy.BillDescription = Convert.ToString(dr["BILL_SUBJECT"]);
                        cy.BillNumber = Convert.ToString(dr["BILL_NUMBER"]);
                        cy.BillDate = Convert.ToDateTime(dr["BILL_DATE"]);
                        cy.SanctionFileNumber = Convert.ToString(dr["SANCTION_FILE_NO"]);
                        if (dr["SANCTION_DATE"] != DBNull.Value)
                            cy.SanctionFileDate = Convert.ToDateTime(dr["SANCTION_DATE"]);
                        cy.VendorNumber = Convert.ToString(dr["VENDOR_NUMBER"]);
                        cy.TotalAmount = Convert.ToDouble(dr["TOTAL_AMOUNT"]);
                        cy.IncomeTax = Convert.ToDouble(dr["INCOME_TAX"]);
                        cy.Gst = Convert.ToDouble(dr["GST"]);
                        cy.NetAmount = Convert.ToDouble(dr["NET_AMOUNT"]);
                        cy.StockRegisterDetails = Convert.ToString(dr["STOCK_REGISTER_DETAILS"]);
                        cy.ChequeNumber = Convert.ToString(dr["CHEQUE_NUMBER"]);
                        if (dr["CHEQUE_DATE"] != DBNull.Value)
                            cy.ChequeDate = Convert.ToDateTime(dr["CHEQUE_DATE"]);
                        cy.TokenNumber = Convert.ToString(dr["TOKEN_NUMBER"]);
                        cy.VendorName = Convert.ToString(dr["VENDOR"]);
                        cy.BranchName = Convert.ToString(dr["DESCRIPTION"]);
                        cy.BillType = Convert.ToString(dr["BILL_TYPE"]);
                        cy.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                        cy.GeneratedBy = Convert.ToInt32(dr["GENERATED_BY"]);
                        cy.Remarks = Convert.ToString(dr["REMARKS"]);
                        if (dr["ENTRY_DATE"] != DBNull.Value)
                            cy.EntryDate = Convert.ToDateTime(dr["ENTRY_DATE"]);
                        bill.Add(cy);
                    }
                }

                if (bill != null) bill.TrimExcess();
                return bill;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Bcr> GetBCRReAppropriations(int FinancialYearId, int HeadOfAccountId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_HOA_RE_APPROPRIATIONS";
                cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = HeadOfAccountId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Bcr> reapp = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    reapp = new List<Bcr>();
                    while (dr.Read())
                    {
                        Bcr cy = new Bcr();
                        cy.ReAppropriationId = Convert.ToInt32(dr["RE_APPROP_ID"]);
                        cy.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                        cy.FromHeadOfAccountId = Convert.ToInt32(dr["FROM_HEAD_OF_ACCOUNT_ID"]);
                        cy.ToHeadOfAccountId = Convert.ToInt32(dr["TO_HEAD_OF_ACCOUNT_ID"]);
                        cy.ReAppAmount = Convert.ToDouble(dr["AMOUNT"]);
                        cy.ReApprpriationDate = Convert.ToDateTime(dr["RE_APPROP_DATE"]);
                        cy.EntryDate = Convert.ToDateTime(dr["RE_APPROP_DATE"]);
                        reapp.Add(cy);
                    }
                }

                if (reapp != null) reapp.TrimExcess();
                return reapp;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion BCR
        #region BRANCH_BCR
        public List<Bcr> GetBranchBCR(int FinncialYearId, int HeadOfAccountId)
        {
            List<Bcr> bills = new List<Bcr>();
            bills = GetBranchBCRBills(FinncialYearId, HeadOfAccountId);
            List<Bcr> ReApp = GetBranchBCRReAppropriations(FinncialYearId, HeadOfAccountId);
            if (bills == null)
                bills = new List<Bcr>();
            if (ReApp != null)
            {
                foreach (Bcr b in ReApp)
                {
                    bills.Add(b);
                }
            }
            return bills;
        }
        public List<Bcr> GetBranchBCRBills(int FinncialYearId, int HeadOfAccountId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BCR_BILL";
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinncialYearId;
                cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = HeadOfAccountId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Bcr> bill = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    bill = new List<Bcr>();
                    while (dr.Read())
                    {
                        Bcr cy = new Bcr();
                        cy.BillId = Convert.ToInt32(dr["BILL_ID"]);
                        cy.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                        cy.BranchId = Convert.ToInt32(dr["BRANCH_ID"]);
                        cy.VendorId = Convert.ToInt32(dr["VENDOR_ID"]);
                        cy.BillTypeId = Convert.ToInt32(dr["BILL_TYPE_ID"]);
                        cy.BillStatusId = Convert.ToInt32(dr["BILL_STATUS_ID"]);
                        cy.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                        cy.BillDescription = Convert.ToString(dr["BILL_SUBJECT"]);
                        cy.BillNumber = Convert.ToString(dr["BILL_NUMBER"]);
                        cy.BillDate = Convert.ToDateTime(dr["BILL_DATE"]);
                        cy.SanctionFileNumber = Convert.ToString(dr["SANCTION_FILE_NO"]);
                        if (dr["SANCTION_DATE"] != DBNull.Value)
                            cy.SanctionFileDate = Convert.ToDateTime(dr["SANCTION_DATE"]);
                        cy.VendorNumber = Convert.ToString(dr["VENDOR_NUMBER"]);
                        cy.TotalAmount = Convert.ToDouble(dr["TOTAL_AMOUNT"]);
                        cy.IncomeTax = Convert.ToDouble(dr["INCOME_TAX"]);
                        cy.Gst = Convert.ToDouble(dr["GST"]);
                        cy.NetAmount = Convert.ToDouble(dr["NET_AMOUNT"]);
                        cy.StockRegisterDetails = Convert.ToString(dr["STOCK_REGISTER_DETAILS"]);
                        cy.ChequeNumber = Convert.ToString(dr["CHEQUE_NUMBER"]);
                        if (dr["CHEQUE_DATE"] != DBNull.Value)
                            cy.ChequeDate = Convert.ToDateTime(dr["CHEQUE_DATE"]);
                        cy.TokenNumber = Convert.ToString(dr["TOKEN_NUMBER"]);
                        cy.VendorName = Convert.ToString(dr["VENDOR"]);
                        cy.BranchName = Convert.ToString(dr["DESCRIPTION"]);
                        cy.BillType = Convert.ToString(dr["BILL_TYPE"]);
                        cy.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                        cy.GeneratedBy = Convert.ToInt32(dr["GENERATED_BY"]);
                        cy.Remarks = Convert.ToString(dr["REMARKS"]);
                        if (dr["ENTRY_DATE"] != DBNull.Value)
                            cy.EntryDate = Convert.ToDateTime(dr["ENTRY_DATE"]);
                        bill.Add(cy);
                    }
                }

                if (bill != null) bill.TrimExcess();
                return bill;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Bcr> GetBranchBCRReAppropriations(int FinancialYearId, int HeadOfAccountId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_HOA_RE_APPROPRIATIONS";
                cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = HeadOfAccountId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Bcr> reapp = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    reapp = new List<Bcr>();
                    while (dr.Read())
                    {
                        Bcr cy = new Bcr();
                        cy.ReAppropriationId = Convert.ToInt32(dr["RE_APPROP_ID"]);
                        cy.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                        cy.FromHeadOfAccountId = Convert.ToInt32(dr["FROM_HEAD_OF_ACCOUNT_ID"]);
                        cy.ToHeadOfAccountId = Convert.ToInt32(dr["TO_HEAD_OF_ACCOUNT_ID"]);
                        cy.ReAppAmount = Convert.ToDouble(dr["AMOUNT"]);
                        cy.ReApprpriationDate = Convert.ToDateTime(dr["RE_APPROP_DATE"]);
                        cy.EntryDate = Convert.ToDateTime(dr["RE_APPROP_DATE"]);
                        reapp.Add(cy);
                    }
                }

                if (reapp != null) reapp.TrimExcess();
                return reapp;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion BCR
        #region SAVINGS
        public void InsertBranchHeadSavings(SavingSurrenderEnt bh)
        {

            //int Id = new DalHelper().GetPk("BUD_BRANCH_HEADS", "BRANCH_HEAD_ID");
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_BRANCH_HOA_SAVING";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = bh.FinancialYearId;
            cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = bh.BranchId;
            cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = bh.HeadOfAccountId;
            cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = bh.Amount;
            cmd.Parameters.Add("@SavingDate", SqlDbType.Date).Value = bh.SavingDate;
            cmd.Connection = con;
            try
            {

                cmd.ExecuteReader();

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
        public List<SavingSurrenderEnt> GetBranchHeadSavings(int FinancialYearId, int HeadOfAccountId, int BranchId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BRANCH_HOA_SAVINGS";
                cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = HeadOfAccountId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = BranchId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<SavingSurrenderEnt> reapp = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    reapp = new List<SavingSurrenderEnt>();
                    while (dr.Read())
                    {
                        SavingSurrenderEnt cy = new SavingSurrenderEnt();
                        cy.BranchId = Convert.ToInt32(dr["BRANCH_ID"]);
                        cy.BranchName = Convert.ToString(dr["BRANCH"]);
                        cy.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                        cy.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                        cy.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                        cy.FinancialYear = Convert.ToString(dr["FINANCIAL_YEAR"]);
                        cy.Amount = Convert.ToDouble(dr["AMOUNT"]);
                        cy.SavingDate = Convert.ToDateTime(dr["SAVING_DATE"]);
                        reapp.Add(cy);
                    }
                }

                if (reapp != null) reapp.TrimExcess();
                return reapp;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion SAVINGS
        #region SURRENDER AMOUNT
        public void InsertBranchHeadSurrender(SavingSurrenderEnt bh)
        {

            //int Id = new DalHelper().GetPk("BUD_BRANCH_HEADS", "BRANCH_HEAD_ID");
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_BRANCH_HOA_SURRENDER";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = bh.FinancialYearId;
            cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = bh.BranchId;
            cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = bh.HeadOfAccountId;
            cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = bh.Amount;
            cmd.Parameters.Add("@SavingDate", SqlDbType.Date).Value = bh.SavingDate;
            cmd.Connection = con;
            try
            {

                cmd.ExecuteReader();

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
        #region Bill_Documents
        public List<BillDocumentsEnt> GetBillDocuments(int BillId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILL_DOCUMENTS";
                cmd.Parameters.Add("@BillId", SqlDbType.Int).Value = BillId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                List<BillDocumentsEnt> drivers = null;
                if (dr.HasRows)
                {
                    drivers = new List<BillDocumentsEnt>();
                    while (dr.Read())
                    {
                        BillDocumentsEnt Temp = new BillDocumentsEnt();
                        Temp.DocumentId = Convert.ToInt32(dr["BILL_DOC_ID"]);
                        Temp.DocumentDescription = Convert.ToString(dr["DOC_DESCRIPTION"]);
                        Temp.BillId = Convert.ToInt32(dr["BILL_ID"]);
                        Temp.Url = Convert.ToString(dr["DOC_URL"]);
                        drivers.Add(Temp);
                    }

                }


                if (drivers != null) drivers.TrimExcess();
                return drivers;
            }
            finally
            {
                con.Close();

            }
        }
        public BillDocumentsEnt GetBillDocument(int DocumentId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILL_DOCUMENT";
                cmd.Parameters.Add("@DocumentId", SqlDbType.Int).Value = DocumentId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                BillDocumentsEnt Temp = new BillDocumentsEnt();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp.DocumentId = Convert.ToInt32(dr["BILL_DOC_ID"]);
                    Temp.DocumentDescription = Convert.ToString(dr["DOC_DESCRIPTION"]);
                    Temp.BillId = Convert.ToInt32(dr["BILL_ID"]);
                    Temp.Url = Convert.ToString(dr["DOC_URL"]);
                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertBillDocument(BillDocumentsEnt Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_BILL_DOCUMENT";
                cmd.Parameters.Add("@DocDescription", SqlDbType.VarChar).Value = Temp.DocumentDescription;
                cmd.Parameters.Add("@BillId", SqlDbType.Int).Value = Temp.BillId;
                cmd.Parameters.Add("@DocUrl", SqlDbType.VarChar).Value = Temp.Url;
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
        public void DeleteBillDocument(int DocumentId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_BILL_DOCUMENT";
                cmd.Parameters.Add("@DocumentId", SqlDbType.Int).Value = DocumentId;
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
        #region Bill_Status
        public List<BillStatus> GetBillStatuses()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILL_STATUSES";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                List<BillStatus> drivers = null;
                if (dr.HasRows)
                {
                    drivers = new List<BillStatus>();
                    while (dr.Read())
                    {
                        BillStatus Temp = new BillStatus();
                        Temp.BillStatusId = Convert.ToInt32(dr["BILL_STATUS_ID"]);
                        Temp.BillStatusDesc = Convert.ToString(dr["BILL_STATUS"]);
                        drivers.Add(Temp);
                    }

                }


                if (drivers != null) drivers.TrimExcess();
                return drivers;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion Bill Status
    }
}
