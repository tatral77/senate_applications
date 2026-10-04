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
        public List<FundCenters> GetFundCenters(int FinancialYearId)
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
                        cy.FundCenterId = Convert.ToInt32(dr["EMPLOYEE_POOLS_ID"]);
                        cy.FundCenter = Convert.ToString(dr["Description"]);
                        BudgetDetails bd = new BudgetDetails();
                        bd = GetFundCenterTotal(cy.FundCenterId, FinancialYearId);
                        cy.FundCenterAmount = bd.Allocated;
                        cy.Remaining = bd.Balance;
                        cy.Saving = bd.Saving;
                        cy.Surrender = bd.Surrender;
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
        public List<FundCenters> GetFundCentersList(int FinancialYearId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                FinancialYears fy = GetCurrentFinancialYear();
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_POOLS";
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
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
                        BudgetDetails bd = new BudgetDetails();
                        bd = GetFundCenterTotal(cy.FundCenterId,FinancialYearId);
                        cy.FundCenterAmount = bd.Allocated;
                        cy.Remaining = bd.Balance;
                        cy.Saving = bd.Saving;
                        cy.Surrender = bd.Surrender;
                        cy.majorObjects = GetActiveMajorObjectsByPool(cy.FundCenterId,FinancialYearId);
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
        public List<MajorObjects> GetMajorObjects(int FinancialYearId)
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
                        obj.minorObjects = GetActiveMinorObjectsByMajorObject(obj.MajorObjectId, FinancialYearId);
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
        public List<MajorObjects> GetActiveMajorObjectsByPool(int FundCenterId,int FinancialYearId)
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
                        BudgetDetails bd = new BudgetDetails();
                        bd = GetMajorTotal(obj.MajorObjectId, FinancialYearId);
                        obj.MajorObjectAmount = bd.Allocated;
                        obj.MajorObjectRemaining = bd.Balance;
                        obj.MajorObjectSaving = bd.Saving;
                        obj.MajorObjectSurrender = bd.Surrender;
                        obj.minorObjects = GetActiveMinorObjectsByMajorObject(obj.MajorObjectId,FinancialYearId);
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
        public void DeleteMajorObject(int MajorObjectId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_MAJOR_OBJECT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MajorObjectId", SqlDbType.Int).Value = MajorObjectId;
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
        public int GetMajorMinors(int MajorObjectId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MAJOR_OBJECT_MINORS_COUNT";
                cmd.Parameters.Add("@MajorObjectId", SqlDbType.Int).Value = MajorObjectId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                return Convert.ToInt32(dr["RECS"]);
            }
            finally
            {
                con.Close();
            }
        }
        #endregion MAJOR OBJECT
        #region MINOR OBJECT
        public List<MinorObjects> GetMinorObjects(int FinancialYearId)
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
                        obj.headOfAccounts = GetHeadOfAccounts(obj.MinorObjectId, FinancialYearId);
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
        public List<MinorObjects> GetActiveMinorObjectsByMajorObject(int MajorObjectId,int FinancialYearId)
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
                        BudgetDetails bd = new BudgetDetails();
                        bd = GetMinorTotal(obj.MinorObjectId,FinancialYearId);
                        obj.MinorObjectAmount = bd.Allocated;
                        obj.MinorObjectRemaining = bd.Balance;
                        obj.MinorObjectSaving = bd.Saving;
                        obj.MinorObjectSurrender = bd.Surrender;
                        obj.headOfAccounts = GetHeadOfAccounts(obj.MinorObjectId,FinancialYearId);
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
        public void DeleteMinorObject(int MinorobjectId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_MINOR_OBJECT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MinorObjectId", SqlDbType.Int).Value = MinorobjectId;
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
        public int GetMinorHOAs(int MinorObjectId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MINOR_OBJECT_HOAS_COUNT";
                cmd.Parameters.Add("@MinorObjectId", SqlDbType.Int).Value = MinorObjectId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                return Convert.ToInt32(dr["RECS"]);
            }
            finally
            {
                con.Close();
            }
        }
        #endregion MINOR OBJECT
        #region HEAD OF ACCOUNT
        public List<HeadOfAccounts> GetHeadOfAccounts(int MinorObjectId,int FinancialYearId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_HEAD_OF_ACCOUNTS";
                cmd.Parameters.Add("@MinorObjectId", SqlDbType.Int).Value = MinorObjectId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
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
                        BudgetDetails bd = new BudgetDetails();
                        bd = GetHeadOfAccountTotal(obj.HeadOfAccountId, FinancialYearId);
                        obj.AmountAllocated = bd.Allocated;
                        obj.RemainingAmount = bd.Balance;
                        obj.Savings = bd.Saving;
                        obj.Surrendered = bd.Surrender;
                        //obj.AmountAllocated = Convert.ToDouble(dr["AMOUNT_ALLOCATED"]);
                        //obj.RemainingAmount = Convert.ToDouble(dr["CURRENT_AMOUNT"]);
                        //obj.Savings= Convert.ToDouble(dr["SAVINGS"]);
                        //obj.Surrendered= Convert.ToDouble(dr["SURRENDERED"]);
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
                        obj.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]) + " (" + Convert.ToDouble(dr["CURRENT_AMOUNT"]) + ")";
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
        public List<HeadOfAccounts> GetBranchHeadOfAccountsWithBudgetByFundCenter(string HeadOfAccount, int fy, int BranchId,int FundCenterId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BRANCH_HOA_BY_NAME_BY_FUNDCENTER";
                cmd.Parameters.Add("@HeadOfAccount", SqlDbType.VarChar).Value = HeadOfAccount;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = fy;
                cmd.Parameters.Add("@FundCenterId", SqlDbType.Int).Value = FundCenterId;
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
                        obj.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]) + " (" + new BudgetDal().FormatAmount(Convert.ToDouble(dr["CURRENT_AMOUNT"])) + ")";
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
        public List<HeadOfAccounts> GetHeadOfAccountsByName(string HeadOfAccount,int FinancialYearId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_HEAD_OF_ACCOUNT_BY_NAME";
                cmd.Parameters.Add("@HeadOfAccount", SqlDbType.VarChar).Value = HeadOfAccount;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
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
                        obj.RemainingAmount= Convert.ToDouble(dr["CURRENT_AMOUNT"]);
                        obj.Savings = Convert.ToDouble(dr["SAVINGS"]);
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
        public List<HeadOfAccounts> GetBranchHeadOfAccountsByName(string HeadOfAccount, int FinancialYearId,int BranchId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BRANCH_HOA_BY_NAME";
                cmd.Parameters.Add("@HeadOfAccount", SqlDbType.VarChar).Value = HeadOfAccount;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
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
                        obj.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                        obj.RemainingAmount = Convert.ToDouble(dr["CURRENT_AMOUNT"]);
                        obj.Savings = Convert.ToDouble(dr["SAVINGS"]);
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
        public List<HeadOfAccounts> GetEmployeeHeadOfAccountByName(string HeadOfAccount, int FinancialYearId, int EmpId,int BranchId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_HEAD_OF_ACCOUNT_BY_NAME";
                cmd.Parameters.Add("@HeadOfAccount", SqlDbType.VarChar).Value = HeadOfAccount;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
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
                        obj.Savings = Convert.ToDouble(dr["SAVINGS"]);
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
        public List<HeadOfAccounts> GetFromHeadOfAccountsWithBudget(string HeadOfAccount,int fy)
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
                        obj.RemainingAmount= Convert.ToDouble(dr["CURRENT_AMOUNT"]);
                        obj.Savings = Convert.ToDouble(dr["SAVINGS"]);
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
                        obj.Savings = Convert.ToDouble(dr["SAVINGS"]);
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
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_HEAD_OF_ACCOUNT";
                cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = HeadOfAccountId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                HeadOfAccounts obj = null;
                if (dr.HasRows)
                {
                    dr.Read();
                     obj = new HeadOfAccounts();
                    obj.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                    obj.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                    obj.MinorObjectId = Convert.ToInt32(dr["MINOR_OBJECT_ID"]);
                }
                return obj;

            }
            finally
            {
                con.Close();
            }
        }

        public int InsertHeadOfAccount(HeadOfAccounts HeadOfAccount)
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
        public void DeleteHeadOfAccount(int HeadOfAccountId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_HEAD_OF_ACCOUNT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = HeadOfAccountId;
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
        public int GetHOABills(int HeadOfAccountId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_HOA_BILLS_COUNT";
                cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = HeadOfAccountId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                return Convert.ToInt32(dr["RECS"]);
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
            if (hoab.HeadOfAccountBudgetId==0)
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
        //public List<Bills> GetBranchFinancialYearsBills(int FinancialYearId,int HeadOfAccountId,int BranchId)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_HOA_FY_BILLS_BY_BRANCH_ID";
        //        cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
        //        cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = HeadOfAccountId;
        //        cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = BranchId;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<Bills> bill = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            bill = new List<Bills>();
        //            while (dr.Read())
        //            {
        //                Bills cy = new Bills();
        //                cy.BillId = Convert.ToInt32(dr["BILL_ID"]);
        //                cy.BranchId = Convert.ToInt32(dr["BRANCH_ID"]);
        //                cy.VendorId = Convert.ToInt32(dr["VENDOR_ID"]);
        //                cy.BillTypeId = Convert.ToInt32(dr["BILL_TYPE_ID"]);
        //                cy.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
        //                cy.BillDescription = Convert.ToString(dr["BILL_SUBJECT"]);
        //                cy.BillNumber = Convert.ToString(dr["BILL_NUMBER"]);
        //                cy.BillDate = Convert.ToDateTime(dr["BILL_DATE"]);
        //                cy.VendorNumber = Convert.ToString(dr["VENDOR_NUMBER"]);
        //                cy.TotalAmount = Convert.ToDouble(dr["TOTAL_AMOUNT"]);
        //                cy.IncomeTax = Convert.ToDouble(dr["INCOME_TAX"]);
        //                cy.Gst = Convert.ToDouble(dr["GST"]);
        //                cy.NetAmount= Convert.ToDouble(dr["NET_AMOUNT"]);
        //                cy.ChequeNumber = Convert.ToString(dr["CHEQUE_NUMBER"]);
        //                cy.ChequeDate = Convert.ToDateTime(dr["CHEQUE_DATE"]);
        //                cy.TokenNumber = Convert.ToString(dr["TOKEN_NUMBER"]);
        //                cy.VendorName = Convert.ToString(dr["VENDOR"]);
        //                cy.BranchName = Convert.ToString(dr["DESCRIPTION"]);
        //                cy.BillType = Convert.ToString(dr["BILL_TYPE"]);
        //                cy.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
        //                cy.GeneratedBy = Convert.ToInt32(dr["GENERATED_BY"]);
        //                cy.Remarks = Convert.ToString(dr["REMARKS"]);
        //                bill.Add(cy);
        //            }
        //        }

        //        if (bill != null) bill.TrimExcess();
        //        return bill;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}
        //public List<Bills> GetBranchFinancialYearsBills(string query)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
               
        //        SqlCommand cmd = new SqlCommand(query, con);
        //        List<Bills> bill = null;
        //        using (con)
        //        {
        //            SqlDataReader dr = cmd.ExecuteReader();
        //            if (dr.HasRows)
        //            {
        //                bill = new List<Bills>();
        //                while (dr.Read())
        //                {
        //                    Bills cy = new Bills();
        //                    cy.BillId = Convert.ToInt32(dr["BILL_ID"]);
        //                    cy.BranchId = Convert.ToInt32(dr["BRANCH_ID"]);
        //                    cy.VendorId = Convert.ToInt32(dr["VENDOR_ID"]);
        //                    cy.BillTypeId = Convert.ToInt32(dr["BILL_TYPE_ID"]);
        //                    cy.FinancialYearId=Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
        //                    if (dr["BILL_STATUS_ID"] != DBNull.Value)
        //                        cy.BillStatusId = Convert.ToInt32(dr["BILL_STATUS_ID"]);
        //                    cy.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
        //                    cy.BillDescription = Convert.ToString(dr["BILL_SUBJECT"]);
        //                    cy.BillNumber = Convert.ToString(dr["BILL_NUMBER"]);
        //                    cy.BillDate = Convert.ToDateTime(dr["BILL_DATE"]);
        //                    cy.SanctionFileNumber = Convert.ToString(dr["SANCTION_FILE_NO"]);
        //                    if(dr["SANCTION_DATE"]!=DBNull.Value)
        //                    cy.SanctionFileDate = Convert.ToDateTime(dr["SANCTION_DATE"]);
        //                    cy.VendorNumber = Convert.ToString(dr["VENDOR_NUMBER"]);
        //                    cy.TotalAmount = Convert.ToDouble(dr["TOTAL_AMOUNT"]);
        //                    cy.IncomeTax = Convert.ToDouble(dr["INCOME_TAX"]);
        //                    cy.Gst = Convert.ToDouble(dr["GST"]);
        //                    cy.NetAmount = Convert.ToDouble(dr["NET_AMOUNT"]);
        //                    cy.StockRegisterDetails= Convert.ToString(dr["STOCK_REGISTER_DETAILS"]);
        //                    cy.ChequeNumber = Convert.ToString(dr["CHEQUE_NUMBER"]);
        //                    if (dr["CHEQUE_DATE"] != DBNull.Value)
        //                        cy.ChequeDate = Convert.ToDateTime(dr["CHEQUE_DATE"]);
        //                    cy.TokenNumber = Convert.ToString(dr["TOKEN_NUMBER"]);
        //                    cy.VendorName = Convert.ToString(dr["VENDOR"]);
        //                    cy.BranchName = Convert.ToString(dr["DESCRIPTION"]);
        //                    cy.BillType = Convert.ToString(dr["BILL_TYPE"]);
        //                    cy.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
        //                    cy.GeneratedBy = Convert.ToInt32(dr["GENERATED_BY"]);
        //                    cy.Remarks = Convert.ToString(dr["REMARKS"]);
        //                    bill.Add(cy);
        //                }
        //            }

        //            if (bill != null) bill.TrimExcess();
        //            return bill;
        //        }
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}
        //public List<Bills> GetVendorFinancialYearsBills(int FinancialYearId,int HeadOfAccountId, int VendorId)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_FY_BILLS_BY_VENDOR_ID";
        //        cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
        //        cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = HeadOfAccountId;
        //        cmd.Parameters.Add("@VendorId", SqlDbType.Int).Value = VendorId;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<Bills> bill = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            bill = new List<Bills>();
        //            while (dr.Read())
        //            {
        //                Bills cy = new Bills();
        //                cy.BillId = Convert.ToInt32(dr["BILL_ID"]);
        //                cy.BranchId = Convert.ToInt32(dr["BRANCH_ID"]);
        //                cy.VendorId = Convert.ToInt32(dr["VENDOR_ID"]);
        //                cy.BillTypeId = Convert.ToInt32(dr["BILL_TYPE_ID"]);
        //                if (dr["BILL_STATUS_ID"] != DBNull.Value)
        //                    cy.BillStatusId = Convert.ToInt32(dr["BILL_STATUS_ID"]);
        //                cy.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
        //                cy.BillDescription = Convert.ToString(dr["BILL_SUBJECT"]);
        //                cy.BillNumber = Convert.ToString(dr["BILL_NUMBER"]);
        //                cy.BillDate = Convert.ToDateTime(dr["BILL_DATE"]);
        //                cy.VendorNumber = Convert.ToString(dr["VENDOR_NUMBER"]);
        //                cy.TotalAmount = Convert.ToDouble(dr["TOTAL_AMOUNT"]);
        //                cy.IncomeTax = Convert.ToDouble(dr["INCOME_TAX"]);
        //                cy.Gst = Convert.ToDouble(dr["GST"]);
        //                cy.NetAmount = Convert.ToDouble(dr["NET_AMOUNT"]);
        //                cy.ChequeNumber = Convert.ToString(dr["CHEQUE_NUMBER"]);
        //                cy.ChequeDate = Convert.ToDateTime(dr["CHEQUE_DATE"]);
        //                cy.TokenNumber = Convert.ToString(dr["TOKEN_NUMBER"]);
        //                cy.VendorName = Convert.ToString(dr["VENDOR"]);
        //                cy.BranchName = Convert.ToString(dr["DESCRIPTION"]);
        //                cy.BillType = Convert.ToString(dr["BILL_TYPE"]);
        //                cy.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
        //                cy.GeneratedBy = Convert.ToInt32(dr["GENERATED_BY"]);
        //                cy.Remarks = Convert.ToString(dr["REMARKS"]);
        //                bill.Add(cy);
        //            }
        //        }

        //        if (bill != null) bill.TrimExcess();
        //        return bill;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}
        //public List<Bills> GetEmployeeFinancialYearsBills(int FinancialYearId, int HeadOfAccountId, int EmployeeId)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_FY_BILLS_BY_VENDOR_ID";
        //        cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
        //        cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = HeadOfAccountId;
        //        cmd.Parameters.Add("@SystemUserId", SqlDbType.Int).Value = EmployeeId;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<Bills> bill = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            bill = new List<Bills>();
        //            while (dr.Read())
        //            {
        //                Bills cy = new Bills();
        //                cy.BillId = Convert.ToInt32(dr["BILL_ID"]);
        //                cy.SystemUserId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
        //                cy.BillTypeId = Convert.ToInt32(dr["BILL_TYPE_ID"]);
        //                if (dr["BILL_STATUS_ID"] != DBNull.Value)
        //                    cy.BillStatusId = Convert.ToInt32(dr["BILL_STATUS_ID"]);
        //                cy.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
        //                cy.BillDescription = Convert.ToString(dr["BILL_SUBJECT"]);
        //                cy.BillNumber = Convert.ToString(dr["BILL_NUMBER"]);
        //                cy.BillDate = Convert.ToDateTime(dr["BILL_DATE"]);
        //                cy.VendorNumber = Convert.ToString(dr["VENDOR_NUMBER"]);
        //                cy.TotalAmount = Convert.ToDouble(dr["TOTAL_AMOUNT"]);
        //                cy.IncomeTax = Convert.ToDouble(dr["INCOME_TAX"]);
        //                cy.Gst = Convert.ToDouble(dr["GST"]);
        //                cy.NetAmount = Convert.ToDouble(dr["NET_AMOUNT"]);
        //                cy.ChequeNumber = Convert.ToString(dr["CHEQUE_NUMBER"]);
        //                cy.ChequeDate = Convert.ToDateTime(dr["CHEQUE_DATE"]);
        //                cy.TokenNumber = Convert.ToString(dr["TOKEN_NUMBER"]);
        //                cy.VendorName = Convert.ToString(dr["VENDOR"]);
        //                cy.BranchName = Convert.ToString(dr["DESCRIPTION"]);
        //                cy.BillType = Convert.ToString(dr["BILL_TYPE"]);
        //                cy.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
        //                cy.GeneratedBy = Convert.ToInt32(dr["GENERATED_BY"]);
        //                cy.Remarks = Convert.ToString(dr["REMARKS"]);
        //                bill.Add(cy);
        //            }
        //        }

        //        if (bill != null) bill.TrimExcess();
        //        return bill;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}
        //public int InsertBill(Bills bill)
        //{

        //    int Id = new DalHelper().GetPk("BUD_BILL", "BILL_ID");
        //    SqlConnection con = new DalHelper().GetConnection();
        //    SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
        //    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_BILL";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@BillId", SqlDbType.Int).Value = Id;
        //    if(bill.BranchId!=0)
        //    cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = bill.BranchId;
        //    if (bill.SystemUserId != 0)
        //        cmd.Parameters.Add("@SystemUserId", SqlDbType.Int).Value = bill.SystemUserId;
        //    cmd.Parameters.Add("@VendorId", SqlDbType.Int).Value = bill.VendorId;
        //    cmd.Parameters.Add("@BillTypeId", SqlDbType.Int).Value = bill.BillTypeId;
        //    cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = bill.HeadOfAccountId;
        //    cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = bill.FinancialYearId;
        //    cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = bill.TotalAmount;
        //    cmd.Parameters.Add("@IncomeTax", SqlDbType.Decimal).Value = bill.IncomeTax;
        //    cmd.Parameters.Add("@GST", SqlDbType.Decimal).Value = bill.Gst;
        //    cmd.Parameters.Add("@NetAmount", SqlDbType.Decimal).Value = bill.TotalAmount + bill.IncomeTax + bill.Gst;
        //    cmd.Parameters.Add("@BillNumber", SqlDbType.VarChar).Value = bill.BillNumber;
        //    cmd.Parameters.Add("@BillDate", SqlDbType.Date).Value = bill.BillDate;
        //    cmd.Parameters.Add("@BillSubject", SqlDbType.VarChar).Value = bill.BillDescription;
        //    cmd.Parameters.Add("@BillStatusId", SqlDbType.Int).Value = bill.BillStatusId;
        //    cmd.Parameters.Add("@VendorNumber", SqlDbType.VarChar).Value = bill.VendorNumber;
        //    cmd.Parameters.Add("@ChequeNumber", SqlDbType.VarChar).Value = bill.ChequeNumber;
        //    cmd.Parameters.Add("@ChequeDate", SqlDbType.Date).Value = bill.ChequeDate;
        //    cmd.Parameters.Add("@TokenNumber", SqlDbType.VarChar).Value = bill.TokenNumber;
        //    cmd.Parameters.Add("@GeneratedBy", SqlDbType.Int).Value = bill.GeneratedBy;
        //    cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = bill.Remarks;
        //    cmd.Connection = con;
        //    try
        //    {
             
        //            cmd.ExecuteReader();
        //        return Id;
              
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}
        //public void UpdateBill(Bills bill)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
        //    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_BILL";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@BillId", SqlDbType.Int).Value = bill.BillId;
        //   // if (bill.BranchId != 0)
        //   //     cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = bill.BranchId;
        //  //  if (bill.SystemUserId != 0)
        //  //      cmd.Parameters.Add("@SystemUserId", SqlDbType.Int).Value = bill.SystemUserId; ;
        //  //  cmd.Parameters.Add("@VendorId", SqlDbType.Int).Value = bill.VendorId;
        //    cmd.Parameters.Add("@BillTypeId", SqlDbType.Int).Value = bill.BillTypeId;
        //    cmd.Parameters.Add("@BillStatusId", SqlDbType.Int).Value = bill.BillStatusId;
        //    cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = bill.HeadOfAccountId;
        //    cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = bill.FinancialYearId;
        //    cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = bill.TotalAmount;
        //    cmd.Parameters.Add("@IncomeTax", SqlDbType.Decimal).Value = bill.IncomeTax;
        //    cmd.Parameters.Add("@GST", SqlDbType.Decimal).Value = bill.Gst;
        //    cmd.Parameters.Add("@StockRegisterDetails", SqlDbType.VarChar).Value = bill.StockRegisterDetails;
        //    cmd.Parameters.Add("@NetAmount", SqlDbType.Decimal).Value = bill.TotalAmount - bill.IncomeTax - bill.Gst;
        //    cmd.Parameters.Add("@SanctionFileNumber", SqlDbType.VarChar).Value = bill.SanctionFileNumber;
        //    cmd.Parameters.Add("@SanctionDate", SqlDbType.Date).Value = bill.SanctionFileDate;
        //    cmd.Parameters.Add("@BillNumber", SqlDbType.VarChar).Value = bill.BillNumber;
        //    cmd.Parameters.Add("@BillDate", SqlDbType.Date).Value = bill.BillDate;
        //    cmd.Parameters.Add("@BillSubject", SqlDbType.VarChar).Value = bill.BillDescription;
        //  //  cmd.Parameters.Add("@VendorNumber", SqlDbType.VarChar).Value = bill.VendorNumber;
        //    cmd.Parameters.Add("@ChequeNumber", SqlDbType.VarChar).Value = bill.ChequeNumber;
        //    cmd.Parameters.Add("@ChequeDate", SqlDbType.Date).Value = bill.ChequeDate;
        //    cmd.Parameters.Add("@TokenNumber", SqlDbType.VarChar).Value = bill.TokenNumber;
        //    cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = bill.Remarks;
        //    cmd.Connection = con;
        //    try
        //    {
        //        cmd.ExecuteReader();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}
        public void UpdateBillDetails(Bills bill)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_BILL_DETAILS"; 
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BillId", SqlDbType.Int).Value = bill.BillId;
            if (bill.BranchId != 0)
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = bill.BranchId;
            if (bill.SystemUserId != 0)
                cmd.Parameters.Add("@SystemUserId", SqlDbType.Int).Value = bill.SystemUserId; ;
            //cmd.Parameters.Add("@VendorId", SqlDbType.Int).Value = bill.VendorId;
            //cmd.Parameters.Add("@BillTypeId", SqlDbType.Int).Value = bill.BillTypeId;
            //cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = bill.HeadOfAccountId;
            //cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = bill.FinancialYearId;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = bill.TotalAmount;
            cmd.Parameters.Add("@IncomeTax", SqlDbType.Decimal).Value = bill.IncomeTax;
            cmd.Parameters.Add("@GST", SqlDbType.Decimal).Value = bill.Gst;
           // cmd.Parameters.Add("@StockRegisterDetails", SqlDbType.VarChar).Value = bill.StockRegisterDetails;
            cmd.Parameters.Add("@NetAmount", SqlDbType.Decimal).Value = bill.TotalAmount - bill.IncomeTax - bill.Gst;
           // cmd.Parameters.Add("@SanctionFileNumber", SqlDbType.VarChar).Value = bill.SanctionFileNumber;
           // cmd.Parameters.Add("@SanctionDate", SqlDbType.Date).Value = bill.SanctionFileDate;
           // cmd.Parameters.Add("@BillNumber", SqlDbType.VarChar).Value = bill.BillNumber;
           // cmd.Parameters.Add("@BillDate", SqlDbType.Date).Value = bill.BillDate;
           // cmd.Parameters.Add("@BillSubject", SqlDbType.VarChar).Value = bill.BillDescription;
            //cmd.Parameters.Add("@VendorNumber", SqlDbType.VarChar).Value = bill.VendorNumber;
            cmd.Parameters.Add("@ChequeNumber", SqlDbType.VarChar).Value = bill.ChequeNumber;
            cmd.Parameters.Add("@ChequeDate", SqlDbType.Date).Value = bill.ChequeDate;
            cmd.Parameters.Add("@TokenNumber", SqlDbType.VarChar).Value = bill.TokenNumber;
            cmd.Parameters.Add("@BillStatusId", SqlDbType.Int).Value = bill.BillStatusId;
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
        public void DeleteBill(int BillId, int hoaId, int fyid)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_BILL";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BillId", SqlDbType.Int).Value = BillId;
            cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = hoaId;
            cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = fyid;
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
        public void SendToAgpr(int BillId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "SEND_TO_AGPR";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BillId", SqlDbType.Int).Value = BillId;
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
        public Bills GetBillById(int BillId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBER_BILL_FOR_PERFORMA";
                cmd.Parameters.Add("@BillId", SqlDbType.Int).Value = BillId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                Bills cy = new Bills();
                cy.BillId = Convert.ToInt32(dr["BILL_ID"]);
                cy.BranchId = Convert.ToInt32(dr["BRANCH_ID"]);
                cy.SystemUserId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                cy.BillTypeId = Convert.ToInt32(dr["BILL_TYPE_ID"]);
                if (dr["BILL_STATUS_ID"] != DBNull.Value)
                    cy.BillStatusId = Convert.ToInt32(dr["BILL_STATUS_ID"]);
                cy.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                    cy.BillDescription = Convert.ToString(dr["BILL_SUBJECT"]);
                cy.BillNumber = Convert.ToString(dr["BILL_NUMBER"]);
                cy.BillDate = Convert.ToDateTime(dr["BILL_DATE"]);
                cy.SanctionFileNumber = Convert.ToString(dr["SANCTION_FILE_NO"]);
                if (dr["SANCTION_DATE"] != DBNull.Value)
                    cy.SanctionFileDate = Convert.ToDateTime(dr["SANCTION_DATE"]);
               // cy.VendorNumber = Convert.ToString(dr["VENDOR_NUMBER"]);
                cy.TotalAmount = Convert.ToDouble(dr["TOTAL_AMOUNT"]);
                cy.IncomeTax = Convert.ToDouble(dr["INCOME_TAX"]);
                cy.Gst = Convert.ToDouble(dr["GST"]);
                cy.NetAmount = Convert.ToDouble(dr["NET_AMOUNT"]);
                cy.StockRegisterDetails = Convert.ToString(dr["STOCK_REGISTER_DETAILS"]);
                cy.ChequeNumber = Convert.ToString(dr["CHEQUE_NUMBER"]);
                if (dr["CHEQUE_DATE"] != DBNull.Value)
                    cy.ChequeDate = Convert.ToDateTime(dr["CHEQUE_DATE"]);
                cy.TokenNumber = Convert.ToString(dr["TOKEN_NUMBER"]);
                cy.EmployeeName = Convert.ToString(dr["F_NAME"]);
               // cy.BranchName = Convert.ToString(dr["DESCRIPTION"]);
               // cy.BillType = Convert.ToString(dr["BILL_TYPE"]);
                cy.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                cy.Remarks = Convert.ToString(dr["REMARKS"]);
                cy.DemandNumber = Convert.ToString(dr["DEMAND_NUMBER"]);
              //  cy.BankAccountNumber = Convert.ToString(dr["BANK_ACCOUNT"]);
                cy.MinorObject = Convert.ToString(dr["MINOR_OBJECT"]);
                cy.MajorObject = Convert.ToString(dr["MAJOR_OBJECT"]);
              //  cy.BankName = Convert.ToString(dr["BANK"]);
                cy.MainId= Convert.ToString(dr["MAIN_ID"]);
                return cy;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion HEAD_OF_ACCOUNT_BILLS

        #region HEAD_OF_ACCOUNT_BILLS
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
                        cy.BillTypeId = Convert.ToInt32(dr["BILL_CATEGORY_ID"]);
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
                            cy.BranchName = Convert.ToString(dr["BRANCH"]);
                            cy.VendorId = Convert.ToInt32(dr["VENDOR_ID"]);
                            cy.BillTypeId = Convert.ToInt32(dr["BILL_TYPE_ID"]);
                            cy.BillCategoryId = Convert.ToInt32(dr["BILL_CATEGORY_ID"]);
                            cy.BillCategory= Convert.ToString(dr["BILL_CATEGORY"]);
                            cy.BillStatusId = Convert.ToInt32(dr["BILL_STATUS_ID"]);
                            cy.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                            cy.BillDescription = Convert.ToString(dr["BILL_SUBJECT"]);
                            cy.BillNumber = Convert.ToString(dr["BILL_NUMBER"]);
                            cy.BillDate = Convert.ToDateTime(dr["BILL_DATE"]);
                            cy.SanctionFileNumber = Convert.ToString(dr["SANCTION_FILE_NO"]);
                            if (dr["SANCTION_DATE"] != DBNull.Value)
                                cy.SanctionFileDate = Convert.ToDateTime(dr["SANCTION_DATE"]);
                            cy.SystemUserId= Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                            cy.EmployeeName = Convert.ToString(dr["F_NAME"]);
                            cy.TotalAmount = Convert.ToDouble(dr["TOTAL_AMOUNT"]);
                            cy.IncomeTax = Convert.ToDouble(dr["INCOME_TAX"]);
                            cy.Gst = Convert.ToDouble(dr["GST"]);
                            cy.NetAmount = Convert.ToDouble(dr["NET_AMOUNT"]);
                            cy.StockRegisterDetails = Convert.ToString(dr["STOCK_REGISTER_DETAILS"]);
                            cy.ChequeNumber = Convert.ToString(dr["CHEQUE_NUMBER"]);
                            if (dr["CHEQUE_DATE"] != DBNull.Value)
                                cy.ChequeDate = Convert.ToDateTime(dr["CHEQUE_DATE"]);
                            cy.TokenNumber = Convert.ToString(dr["TOKEN_NUMBER"]);
                           // cy.VendorName = Convert.ToString(dr["VENDOR"]);
                            //cy.BranchName = Convert.ToString(dr["DESCRIPTION"]);
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
                        cy.BillTypeId = Convert.ToInt32(dr["BILL_CATEGORY_ID"]);
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
                        cy.BillTypeId = Convert.ToInt32(dr["BILL_CATEGORY_ID"]);
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
            cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = bill.HeadOfAccountId;
            cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = bill.FinancialYearId;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = bill.TotalAmount;
            cmd.Parameters.Add("@IncomeTax", SqlDbType.Decimal).Value = bill.IncomeTax;
            cmd.Parameters.Add("@GST", SqlDbType.Decimal).Value = bill.Gst;
            cmd.Parameters.Add("@NetAmount", SqlDbType.Decimal).Value = bill.TotalAmount - bill.IncomeTax - bill.Gst;
            cmd.Parameters.Add("@BillNumber", SqlDbType.VarChar).Value = bill.BillNumber;
            cmd.Parameters.Add("@BillDate", SqlDbType.Date).Value = bill.BillDate;
            cmd.Parameters.Add("@BillStatusId", SqlDbType.Int).Value = bill.BillStatusId;
            cmd.Parameters.Add("@BillCategoryId", SqlDbType.Int).Value = bill.BillCategoryId;
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
        public List<Vendors> GetVendorByName(string vendorname)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_VENDOR_BY_NAME";
                cmd.Parameters.Add("@VName", SqlDbType.VarChar).Value = vendorname;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Vendors> vendor = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    vendor = new List<Vendors>();
                    while (dr.Read())
                    {
                        Vendors cy = new Vendors();
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
        public List<Vendors> GetVendorByBranch(int BranchId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_VENDOR_BY_BRANCH";
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = BranchId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Vendors> vendor = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    vendor = new List<Vendors>();
                    while (dr.Read())
                    {
                        Vendors cy = new Vendors();
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
        public List<Vendors> GetBranchVendorByName(int BranchId,string vendorname)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BRANCH_VENDOR_BY_NAME";
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = BranchId;
                cmd.Parameters.Add("@VName", SqlDbType.VarChar).Value = vendorname;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Vendors> vendor = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    vendor = new List<Vendors>();
                    while (dr.Read())
                    {
                        Vendors cy = new Vendors();
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
        public List<Vendors> GetVendorById(int vendorId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_VENDOR_BY_ID";
                cmd.Parameters.Add("@VendorId", SqlDbType.Int).Value = vendorId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Vendors> vendor = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    vendor = new List<Vendors>();
                    while (dr.Read())
                    {
                        Vendors cy = new Vendors();
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
                        cy.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]) + " - " + FormatAmount(Convert.ToDouble(dr["REMAINING_BUDGET"]));
                        cy.BudgetLimit = Convert.ToDouble(dr["BUDGET_LIMIT"]);
                        cy.FundCenter = Convert.ToString(dr["FUND_CENTER"]);
                        cy.MajorObject = Convert.ToString(dr["MAJOR_OBJECT"]);
                        cy.MinorObjectId = Convert.ToInt32(dr["MINOR_OBJECT_ID"]);
                        cy.MinorObject = Convert.ToString(dr["MINOR_OBJECT"]);
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
        public List<BranchHead> GetBranchFundCenterHeads(int BranchId, int FinancialYearsId, int FundCenterId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BRANCH_HEADS";
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = BranchId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearsId;
                cmd.Parameters.Add("@FundCenterId", SqlDbType.Int).Value = FundCenterId;
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
                        cy.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]) + " - " + FormatAmount(Convert.ToDouble(dr["REMAINING_BUDGET"]));
                        cy.BudgetLimit = Convert.ToDouble(dr["BUDGET_LIMIT"]);
                        cy.FundCenter = Convert.ToString(dr["FUND_CENTER"]);
                        cy.MajorObject = Convert.ToString(dr["MAJOR_OBJECT"]);
                        cy.MinorObjectId = Convert.ToInt32(dr["MINOR_OBJECT_ID"]);
                        cy.MinorObject = Convert.ToString(dr["MINOR_OBJECT"]);
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
        protected string FormatAmount(double Amount)
        {
            return String.Format("{0:#,##0}", Convert.ToDecimal(Amount));
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
            cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = bh.FinancialYearId;
            cmd.Parameters.Add("@BudgetLimit", SqlDbType.Int).Value = bh.BudgetLimit;
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
            cmd.Parameters.Add("@BudgetLimit", SqlDbType.Int).Value = bh.BudgetLimit;
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
                cy.FromHeadOfAccount= Convert.ToString(dr["FROM_HEAD_OF_ACCOUNT"]);
                cy.ToHeadOfAccountId = Convert.ToInt32(dr["TO_HEAD_OF_ACCOUNT_ID"]);
                cy.ToHeadOfAccount = Convert.ToString(dr["TO_HEAD_OF_ACCOUNT"]);
                cy.Amount = Convert.ToDouble(dr["AMOUNT"]);
                cy.ReApprpriationDate= Convert.ToDateTime(dr["RE_APPROP_DATE"]);
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
                        cy.BillDate = Convert.ToDateTime(dr["RE_APPROP_DATE"]);
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
        #region TOTALS
        public BudgetDetails GetFundCenterTotal(int Id,int fy)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_POOL_TOTAL";
                cmd.Parameters.Add("@FundCenterId", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = fy;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                BudgetDetails bd = new BudgetDetails();
                if (dr.HasRows)
                {

                    dr.Read();
                    {
                        if (dr["TOTAL"] != DBNull.Value)
                        {
                            bd.Allocated = Convert.ToDouble(dr["TOTAL"]);
                            bd.Balance= Convert.ToDouble(dr["CURRENT_AMOUNT"]);
                            bd.Saving = Convert.ToDouble(dr["SAVINGS"]);
                            bd.Surrender = Convert.ToDouble(dr["SURRENDERED"]);

                        }
                    }
                }
              
                return bd;
            }
            finally
            {
                con.Close();
            }
        }
        public BudgetDetails GetMajorTotal(int Id,int fy)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MAJOR_TOTAL";
                cmd.Parameters.Add("@MajorObjectId", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = fy;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                BudgetDetails bd = new BudgetDetails();
                if (dr.HasRows)
                {
                    dr.Read();
                    {
                        if (dr["TOTAL"] != DBNull.Value)
                        {
                            bd.Allocated = Convert.ToDouble(dr["TOTAL"]);
                            bd.Balance = Convert.ToDouble(dr["CURRENT_AMOUNT"]);
                            bd.Saving = Convert.ToDouble(dr["SAVINGS"]);
                            bd.Surrender = Convert.ToDouble(dr["SURRENDERED"]);

                        }
                    }
                }

                return bd;
            }
            finally
            {
                con.Close();
            }
        }
        public BudgetDetails GetMinorTotal(int Id,int fy)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MINOR_TOTAL";
                cmd.Parameters.Add("@MinorObjectId", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = fy;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                BudgetDetails bd = new BudgetDetails();
                if (dr.HasRows)
                {
                    dr.Read();
                    {
                        if (dr["TOTAL"] != DBNull.Value)
                        {
                            bd.Allocated = Convert.ToDouble(dr["TOTAL"]);
                            bd.Balance = Convert.ToDouble(dr["CURRENT_AMOUNT"]);
                            bd.Saving = Convert.ToDouble(dr["SAVINGS"]);
                            bd.Surrender = Convert.ToDouble(dr["SURRENDERED"]);

                        }
                    }
                }

                return bd;
            }
            finally
            {
                con.Close();
            }
        }
        public BudgetDetails GetHeadOfAccountTotal(int Id, int fy)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_HOA_TOTAL";
                cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = fy;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                BudgetDetails bd = new BudgetDetails();
                if (dr.HasRows)
                {
                    dr.Read();
                    {
                        if (dr["TOTAL"] != DBNull.Value)
                        {
                            bd.Allocated = Convert.ToDouble(dr["TOTAL"]);
                            bd.Balance = Convert.ToDouble(dr["CURRENT_AMOUNT"]);
                            bd.Saving = Convert.ToDouble(dr["SAVINGS"]);
                            bd.Surrender = Convert.ToDouble(dr["SURRENDERED"]);

                        }
                    }
                }

                return bd;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion TOTALS
        #region OTHERS
        public List<Employees> GetEmployeeByName(string EmployeeName)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMPLOYEE_BY_NAME";
                cmd.Parameters.Add("@FName", SqlDbType.VarChar).Value = EmployeeName;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Employees> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Employees>();
                    while (dr.Read())
                    {
                        Employees Temp = new Employees();

                        Temp.EmployeeId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        Temp.EmployeeName = Convert.ToString(dr["F_NAME"]) + " (" + Convert.ToString(dr["POST"]) + ")";
                        Temp.Post = Convert.ToString(dr["POST"]);
                        Temp.PostId = Convert.ToInt32(dr["POST_HELD"]);
                        Temp.VendorNumber = Convert.ToString(dr["VENDOR_NUMBER"]);
                        Temp.PersonalNumber = Convert.ToString(dr["PERSONAL_NO"]);
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
        #endregion OTHERS
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
                        Temp.Description = Convert.ToString(dr["BILL_STATUS"]);
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

        #region MONTH
        public List<Months> GetMonths()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_FY_MONTHS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Months> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Months>();
                    while (dr.Read())
                    {
                        Months Temp = new Months();

                        Temp.MonthId = Convert.ToInt32(dr["MONTH_NAMES_ID"]);
                        Temp.MonthName = Convert.ToString(dr["MONTH_NAME"]);
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
        public Months GetMonth(int MonthId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MONTH";
                cmd.Parameters.Add("@MonthId", SqlDbType.Int).Value = MonthId;
                cmd.CommandType = CommandType.StoredProcedure;
                Months Temp = new Months();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp.MonthId = Convert.ToInt32(dr["MONTH_NAMES_ID"]);
                    Temp.MonthName = Convert.ToString(dr["MONTH_NAME"]);
                }

                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion MONTH
        #region BILL_CATEGORY
        public List<BillCategories> GetBillCategories()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILL_CATEGORIES";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                List<BillCategories> drivers = null;
                if (dr.HasRows)
                {
                    drivers = new List<BillCategories>();
                    while (dr.Read())
                    {
                        BillCategories Temp = new BillCategories();
                        Temp.BillCategoryId = Convert.ToInt32(dr["BILL_CATEGORY_ID"]);
                        Temp.BillCategory = Convert.ToString(dr["BILL_CATEGORY"]);
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
        public BillCategories GetBillCategory(int CategoryId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILL_CATEGORY";
                cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = CategoryId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                BillCategories Temp = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = new BillCategories();
                    Temp.BillCategoryId = Convert.ToInt32(dr["BILL_CATEGORIES_ID"]);
                    Temp.BillCategory = Convert.ToString(dr["BILL_CATEGORY"]);
                }


                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion BILL_CATEGORY

        #region  BILL_DETAILS
        public List<BillDetails> GetBillDetailsByBillId(int BillId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILL_DETAILS_BY_BILL";
                cmd.Parameters.Add("@BillId", SqlDbType.Int).Value = BillId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<BillDetails> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<BillDetails>();
                    while (dr.Read())
                    {
                        BillDetails Temp = new BillDetails();
                        Temp.BillDetailId = Convert.ToInt32(dr["BILL_DETAIL_ID"]);
                        Temp.BillId = Convert.ToInt32(dr["BILL_ID"]);
                        Temp.CategoryId = Convert.ToInt32(dr["BILL_CATEGORY_ID"]);
                        Temp.Category = Convert.ToString(dr["BILL_CATEGORY"]);
                        Temp.Amount = Convert.ToDouble(dr["AMOUNT"]);
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
        public BillDetails GetBillDetailsById(int BillDetailId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILL_DETAILS_BY_ID";
                cmd.Parameters.Add("@BillDetailId", SqlDbType.Int).Value = BillDetailId;
                cmd.CommandType = CommandType.StoredProcedure;
                BillDetails Temp = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                        dr.Read();
                        Temp = new BillDetails();
                        Temp.BillDetailId = Convert.ToInt32(dr["BILL_DETAIL_ID"]);
                        Temp.BillId = Convert.ToInt32(dr["BILL_ID"]);
                        Temp.CategoryId = Convert.ToInt32(dr["BILL_CATEGORY_ID"]);
                        Temp.Category = Convert.ToString(dr["BILL_CATEGORY"]);
                        Temp.Amount = Convert.ToDouble(dr["AMOUNT"]);
                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public List<BillDetails> GetBillDetailsByCategory(int CategoryId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILL_DETAILS_BY_CATEGORY";
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = CategoryId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<BillDetails> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<BillDetails>();
                    while (dr.Read())
                    {
                        BillDetails Temp = new BillDetails();
                        Temp.BillDetailId = Convert.ToInt32(dr["BILL_DETAIL_ID"]);
                        Temp.BillId = Convert.ToInt32(dr["BILL_ID"]);
                        Temp.CategoryId = Convert.ToInt32(dr["BILL_CATEGORY_ID"]);
                        Temp.Category = Convert.ToString(dr["BILL_CATEGORY"]);
                        Temp.Amount = Convert.ToDouble(dr["AMOUNT"]);
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
        public void InsertBillDetail(BillDetails Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_BILL_DETAILS";
                cmd.Parameters.Add("@BillCategoryId", SqlDbType.Int).Value = Temp.CategoryId;
                cmd.Parameters.Add("@BillId", SqlDbType.Int).Value = Temp.BillId;
                cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = Temp.Amount;
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
        
        public void DeleteBillDetail(int BillDetailId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_BILL_DETAILS";
                cmd.Parameters.Add("@BillDetailId", SqlDbType.VarChar).Value = BillDetailId;
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

        #endregion BILL_DETAIL

        #region  BILL_DEDUCTION
        public List<BillDeductions> GetBillDeductionsByBillId(int BillId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILL_DEDUCTION_BY_BILL";
                cmd.Parameters.Add("@BillId", SqlDbType.Int).Value = BillId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<BillDeductions> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<BillDeductions>();
                    while (dr.Read())
                    {
                        BillDeductions Temp = new BillDeductions();
                        Temp.BillDeductionId = Convert.ToInt32(dr["BILL_DEDUCTION_ID"]);
                        Temp.BillId = Convert.ToInt32(dr["BILL_ID"]);
                        Temp.DeductionDetail = Convert.ToString(dr["DEDUCTION_DETAIL"]);
                        Temp.Amount = Convert.ToDouble(dr["AMOUNT"]);
                        Temp.Remarks = Convert.ToString(dr["REMARKS"]);
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
        public BillDeductions GetBillDeductionById(int BillDeductionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILL_DEDUCTION_BY_ID";
                cmd.Parameters.Add("@BillDeductionId", SqlDbType.Int).Value = BillDeductionId;
                cmd.CommandType = CommandType.StoredProcedure;
                BillDeductions Temp = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = new BillDeductions();
                    Temp.BillDeductionId = Convert.ToInt32(dr["BILL_DEDUCTION_ID"]);
                    Temp.BillId = Convert.ToInt32(dr["BILL_ID"]);
                    Temp.DeductionDetail = Convert.ToString(dr["DEDUCTION_DETAIL"]);
                    Temp.Amount = Convert.ToDouble(dr["AMOUNT"]);
                    Temp.Remarks = Convert.ToString(dr["REMARKS"]);
                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
     
        public void InsertBillDeduction(BillDeductions Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_BILL_DEDUCTION";
                cmd.Parameters.Add("@BillId", SqlDbType.Int).Value = Temp.BillId;
                cmd.Parameters.Add("@Details", SqlDbType.VarChar).Value = Temp.DeductionDetail;
                cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = Temp.Amount;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Temp.Remarks;
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

        public void DeleteBillDeduction(int BillDeductionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_BILL_DEDUCTION";
                cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = BillDeductionId;
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

        #endregion BILL_DEDUCTION


    }
}
