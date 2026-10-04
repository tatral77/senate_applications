using BUDDAL;
using BUDENTITIES;
using FinEntities;
using IPRDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinDal
{
    public class FinDAL
    {
        #region MEMBER
        public List<Member> GetMemberByName(string MemberName)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBERS_BY_NAME";
                cmd.Parameters.Add("@MemberName", SqlDbType.VarChar).Value = MemberName;
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
                        Temp.MemberName = Convert.ToString(dr["SENATOR_NAME"]);
                        Temp.MemberSalCategoryId= Convert.ToInt32(dr["SAL_CATEGORY_ID"]);
                        Temp.MemberSalCategory= Convert.ToString(dr["SAL_CATEGORY"]);
                        Temp.IsActive = Convert.ToInt32(dr["MEMBER_STATUS"]);
                        Temp.SalaryStatus= Convert.ToInt32(dr["SALARY_ACTIVE"]);
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
        public List<Member> GetMemberWithoutBankAccount()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBERS_WITHOUT_BANK_ACCOUNT";
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
                        Temp.MemberName = Convert.ToString(dr["SENATOR_NAME"]);
                        Temp.MemberSalCategoryId = Convert.ToInt32(dr["SAL_CATEGORY_ID"]);
                        Temp.MemberSalCategory = Convert.ToString(dr["SAL_CATEGORY"]);
                        Temp.IsActive = Convert.ToInt32(dr["MEMBER_STATUS"]);
                        Temp.SalaryStatus = Convert.ToInt32(dr["SALARY_ACTIVE"]);
                        Temp.HaveBankAccount = 0;
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
        public List<Member> GetCatMemberWithoutBankAccount(int SalCategoryId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CAT_MEMBERS_WITHOUT_BANK_ACCOUNT";
                cmd.Parameters.Add("@SalaryCategoryId", SqlDbType.Int).Value = SalCategoryId;
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
                        Temp.MemberName = Convert.ToString(dr["SENATOR_NAME"]);
                        Temp.MemberSalCategoryId = Convert.ToInt32(dr["SAL_CATEGORY_ID"]);
                        Temp.MemberSalCategory = Convert.ToString(dr["SAL_CATEGORY"]);
                        Temp.IsActive = Convert.ToInt32(dr["MEMBER_STATUS"]);
                        Temp.SalaryStatus = Convert.ToInt32(dr["SALARY_ACTIVE"]);
                        Temp.HaveBankAccount = 0;
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
        public List<Member> GetCatMemberWithBankAccount(int SalCategoryId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CAT_MEMBERS_WITH_BANK_ACCOUNT";
                cmd.Parameters.Add("@SalaryCategoryId", SqlDbType.Int).Value = SalCategoryId;
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
                        Temp.MemberName = Convert.ToString(dr["SENATOR_NAME"]);
                        Temp.MemberSalCategoryId = Convert.ToInt32(dr["SAL_CATEGORY_ID"]);
                        Temp.MemberSalCategory = Convert.ToString(dr["SAL_CATEGORY"]);
                        Temp.IsActive = Convert.ToInt32(dr["MEMBER_STATUS"]);
                        Temp.SalaryStatus = Convert.ToInt32(dr["SALARY_ACTIVE"]);
                        Temp.HaveBankAccount = 1;
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
        public Member GetMemberById(int Id)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBER_BY_ID";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = Id;
                cmd.CommandType = CommandType.StoredProcedure;
                Member Temp = new Member();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                        Temp.MemberId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        Temp.MemberName = Convert.ToString(dr["SENATOR_NAME"]);
                        Temp.MemberSalCategoryId = Convert.ToInt32(dr["SAL_CATEGORY_ID"]);
                        Temp.MemberSalCategory = Convert.ToString(dr["SAL_CATEGORY"]);
                        Temp.IsActive = Convert.ToInt32(dr["MEMBER_STATUS"]);
                        Temp.SalaryStatus = Convert.ToInt32(dr["SALARY_ACTIVE"]);
                }

                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public List<Member> GetActiveMembers()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_MEMBERS";
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
                        Temp.MemberName = Convert.ToString(dr["SENATOR_NAME"]);
                        Temp.IsActive = Convert.ToInt32(dr["MEMBER_STATUS"]);
                        Temp.MemberSalCategoryId = Convert.ToInt32(dr["SAL_CATEGORY_ID"]);
                        Temp.MemberSalCategory = Convert.ToString(dr["SAL_CATEGORY"]);
                        Temp.SalaryStatus = Convert.ToInt32(dr["SALARY_ACTIVE"]);
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
        public List<Member> GetMembersByCategory(int SalCategoryId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBERS_BY_CATEGORY";
                cmd.Parameters.Add("@SalaryCategoryId", SqlDbType.Int).Value = SalCategoryId;
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
                        Temp.MemberName = Convert.ToString(dr["SENATOR_NAME"]);
                        Temp.IsActive = Convert.ToInt32(dr["MEMBER_STATUS"]);
                        Temp.MemberSalCategoryId = Convert.ToInt32(dr["SAL_CATEGORY_ID"]);
                        Temp.MemberSalCategory = Convert.ToString(dr["SAL_CATEGORY"]);
                        Temp.SalaryStatus = Convert.ToInt32(dr["SALARY_ACTIVE"]);
                        MemberBankAccounts ba = GetMemberSalaryAccount(Temp.MemberId);
                        if(ba!=null)
                        {
                            Temp.BankName = ba.BankName;
                            Temp.BankAccount = ba.AccountNumber;
                        }
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
        public void UpdateMemberSalaryStatus(int SystemUserId, int SalCategoryId, int SalaryStatus)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_SALARY_STATUS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = SystemUserId;
            cmd.Parameters.Add("@SalaryCategoryId", SqlDbType.Int).Value = SalCategoryId;
            cmd.Parameters.Add("@SalaryStatus", SqlDbType.VarChar).Value = SalaryStatus;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
            }

            finally
            {
                con.Close();

            }

        }
        public List<MemberSalCategories> GetMemberSalCategories()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEM_SAL_CATEGORIES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<MemberSalCategories> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MemberSalCategories>();
                    while (dr.Read())
                    {
                        MemberSalCategories Temp = new MemberSalCategories();
                        Temp.MemberSalCategoryId = Convert.ToInt32(dr["MEM_SAL_CATEGORIES_ID"]);
                        Temp.MemberSalCategory = Convert.ToString(dr["DESCRIPTION"]);
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
        public List<MemberSalCategories> GetMemberActiveSalCategories()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEM_ACTIVE_SAL_CATEGORIES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<MemberSalCategories> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MemberSalCategories>();
                    while (dr.Read())
                    {
                        MemberSalCategories Temp = new MemberSalCategories();
                        Temp.MemberSalCategoryId = Convert.ToInt32(dr["MEM_SAL_CATEGORIES_ID"]);
                        Temp.MemberSalCategory = Convert.ToString(dr["DESCRIPTION"]);
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
        #endregion MEMBER
        #region SALARY_STRUCTURE
        public List<SalaryStructure> GetSalaryStructures()
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SALARY_STRUCTURES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<SalaryStructure> salarystructure = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    salarystructure = new List<SalaryStructure>();
                    while (dr.Read())
                    {
                        SalaryStructure cy = new SalaryStructure();
                        cy.SalaryStructureId = Convert.ToInt32(dr["STRUCTURE_ID"]);
                        cy.Description = Convert.ToString(dr["SAL_STRUCTURE"]);
                        cy.FinancialYear = Convert.ToString(dr["FINANCIAL_YEAR"]);
                        cy.MemberSalCategoryId = Convert.ToInt32(dr["SAL_CATEGORY_ID"]);
                        cy.MemberSalCategory = Convert.ToString(dr["SAL_CATEGORY"]);
                        cy.IsCurrent = Convert.ToInt32(dr["IS_CURRENT"]);
                        salarystructure.Add(cy);
                    }
                }

                if (salarystructure != null) salarystructure.TrimExcess();
                return salarystructure;
            }
            finally
            {
                con.Close();

            }
        }
        public SalaryStructure GetSalaryStructure(int SalaryStructureId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SALARY_STRUCTURE";
                cmd.Parameters.Add("@SalaryStructureId", SqlDbType.Int).Value = SalaryStructureId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                SalaryStructure cy = new SalaryStructure();
                if (dr.HasRows)
                {
                    dr.Read();
                    cy.SalaryStructureId = Convert.ToInt32(dr["STRUCTURE_ID"]);
                    cy.Description = Convert.ToString(dr["SAL_STRUCTURE"]);
                    cy.FinancialYear = Convert.ToString(dr["FINANCIAL_YEAR"]);
                    cy.MemberSalCategoryId= Convert.ToInt32(dr["SAL_CATEGORY_ID"]);
                    cy.MemberSalCategory = Convert.ToString(dr["SAL_CATEGORY"]);
                    cy.FundCenterId = Convert.ToInt32(dr["ID"]);
                    cy.IsCurrent = Convert.ToInt32(dr["IS_CURRENT"]);
                   
                }

                return cy;
            }
            finally
            {
                con.Close();

            }
        }
        public SalaryStructure GetSalaryStructureByCategory(int CategoryId)
        {
            FinancialYears fy = new BudgetDal().GetCurrentFinancialYear();
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SALARY_STRUCTURE_BY_CATEGORY";
                cmd.Parameters.Add("@SalaryCategoryId", SqlDbType.Int).Value = CategoryId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = fy.FinancialYearId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                SalaryStructure cy = new SalaryStructure();
                if (dr.HasRows)
                {
                    dr.Read();
                    cy.SalaryStructureId = Convert.ToInt32(dr["STRUCTURE_ID"]);
                    cy.Description = Convert.ToString(dr["SAL_STRUCTURE"]);
                    cy.FinancialYear = Convert.ToString(dr["FINANCIAL_YEAR"]);
                    cy.MemberSalCategoryId = Convert.ToInt32(dr["SAL_CATEGORY_ID"]);
                    cy.MemberSalCategory = Convert.ToString(dr["SAL_CATEGORY"]);
                    cy.FundCenterId= Convert.ToInt32(dr["ID"]);
                    cy.IsCurrent = Convert.ToInt32(dr["IS_CURRENT"]);

                }

                return cy;
            }
            finally
            {
                con.Close();

            }
        }
        public SalaryStructure GetCurrentSalaryStructure()
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CURRENT_SALARY_STRUCTURE";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                SalaryStructure cy = new SalaryStructure();
                if (dr.HasRows)
                {
                    dr.Read();
                    cy.SalaryStructureId = Convert.ToInt32(dr["STRUCTURE_ID"]);
                    cy.Description = Convert.ToString(dr["SAL_STRUCTURE"]);
                    cy.FinancialYear = Convert.ToString(dr["FINANCIAL_YEAR"]);
                    cy.MemberSalCategoryId = Convert.ToInt32(dr["SAL_CATEGORY_ID"]);
                    cy.MemberSalCategory = Convert.ToString(dr["SAL_CATEGORY"]);
                    cy.IsCurrent = Convert.ToInt32(dr["IS_CURRENT"]);

                }

                return cy;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertSalaryStructure(SalaryStructure Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_SALARY_STRUCTURE"; 
                cmd.Parameters.Add("@SalaryStructure", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@SalaryCategoryId", SqlDbType.VarChar).Value = Temp.MemberSalCategoryId;
                cmd.Parameters.Add("@IsCurrent", SqlDbType.Int).Value = Temp.IsCurrent;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = Temp.FinancialYearId;
                cmd.Parameters.Add("@FundCenterId", SqlDbType.Int).Value = Temp.FundCenterId;
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
        public void UpdateSalaryStructure(SalaryStructure Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_SALARY_STRUCTURE";
                cmd.Parameters.Add("@SalaryStructureId", SqlDbType.Int).Value = Temp.SalaryStructureId;
                cmd.Parameters.Add("@SalaryStructure", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@SalaryCategoryId", SqlDbType.VarChar).Value = Temp.MemberSalCategoryId;
                cmd.Parameters.Add("@IsCurrent", SqlDbType.Int).Value = Temp.IsCurrent;
                cmd.Parameters.Add("@FundCenterId", SqlDbType.Int).Value = Temp.FundCenterId;
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
        public FundCenters GetIdByCategory(int CategoryId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ID_BY_CATEGORY";
                cmd.Parameters.Add("@SalaryCategoryId", SqlDbType.Int).Value = CategoryId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                FundCenters Temp = new FundCenters();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp.FundCenterId = Convert.ToInt32(dr["ID"]);
                    Temp.FundCenter = Convert.ToString(dr["DESCRIPTION"]);
                }

                return Temp;
            }
            finally
            {
                con.Close();

            }
        }

        #endregion SALARY_STRUCTURE
        #region  STRUCTURE_ALLOWANCES
        public List<StructureAllowance> GetStructureAllownaces(int StructureId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_STRUCTURE_ALLOWANCES";
                cmd.Parameters.Add("@SalaryStructureId", SqlDbType.Int).Value = StructureId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<StructureAllowance> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<StructureAllowance>();
                    while (dr.Read())
                    {
                        StructureAllowance Temp = new StructureAllowance();
                        Temp.StructureId = Convert.ToInt32(dr["SAL_STRUCTURE_ID"]);
                        Temp.AllowanceId = Convert.ToInt32(dr["ALLOWANCE_ID"]);
                        Temp.AllowanceDesc = Convert.ToString(dr["ALLOWANCE"]);
                        Temp.Amount = Convert.ToDouble(dr["AMOUNT"]);
                        Temp.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                        Temp.Id= Convert.ToString(dr["ID"]);
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
        public StructureAllowance GetStructureAllownace(int StructureId, int AllownaceId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_STRUCTURE_ALLOWANCE";
                cmd.Parameters.Add("@SalaryStructureId", SqlDbType.Int).Value = StructureId;
                cmd.Parameters.Add("@AllowanceId", SqlDbType.Int).Value = AllownaceId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                StructureAllowance Temp = new StructureAllowance();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp.StructureId = Convert.ToInt32(dr["SAL_STRUCTURE_ID"]);
                    Temp.AllowanceId = Convert.ToInt32(dr["ALLOWANCE_ID"]);
                    Temp.AllowanceDesc = Convert.ToString(dr["ALLOWANCE"]);
                    Temp.Amount = Convert.ToDouble(dr["AMOUNT"]);
                    Temp.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                    Temp.Id = Convert.ToString(dr["ID"]);

                }

                return Temp;
            }
            finally
            {
                con.Close();

            }
        }

        public void InsertStructureAllownace(StructureAllowance Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_STRUCTURE_ALLOWANCE";
                cmd.Parameters.Add("@SalaryStructureId", SqlDbType.Int).Value = Temp.StructureId;
                cmd.Parameters.Add("@AllowanceId", SqlDbType.Int).Value = Temp.AllowanceId;
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
        public void UpdateStructureAllownace(StructureAllowance Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_STRUCTURE_ALLOWANCE";
                cmd.Parameters.Add("@SalaryStructureId", SqlDbType.Int).Value = Temp.StructureId;
                cmd.Parameters.Add("@AllowanceId", SqlDbType.Int).Value = Temp.AllowanceId;
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
        public void DeleteStructureAllownace(int StructureId, int AllownaceId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_STRUCTURE_ALLOWANCE";
                cmd.Parameters.Add("@SalaryStructureId", SqlDbType.VarChar).Value = StructureId;
                cmd.Parameters.Add("@AllowanceId", SqlDbType.Int).Value = AllownaceId;
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
        #endregion STRUCTURE ALLOWANCE
        #region  STRUCTURE_DEDUCTIONS
        public List<StructureDeduction> GetStructureDeductions(int StructureId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_STRUCTURE_DEDUCTIONS";
                cmd.Parameters.Add("@SalaryStructureId", SqlDbType.Int).Value = StructureId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<StructureDeduction> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<StructureDeduction>();
                    while (dr.Read())
                    {
                        StructureDeduction Temp = new StructureDeduction();
                        Temp.StructureId = Convert.ToInt32(dr["SAL_STRUCTURE_ID"]);
                        Temp.DeductionId = Convert.ToInt32(dr["DEDUCTION_ID"]);
                        Temp.DeductionDesc = Convert.ToString(dr["DEDUCTION"]);
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
        public StructureDeduction GetStructureDeduction(int StructureId, int DeductionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_STRUCTURE_DEDUCTION";
                cmd.Parameters.Add("@SalaryStructureId", SqlDbType.Int).Value = StructureId;
                cmd.Parameters.Add("@DeductionId", SqlDbType.Int).Value = DeductionId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                StructureDeduction Temp = new StructureDeduction();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp.StructureId = Convert.ToInt32(dr["SAL_STRUCTURE_ID"]);
                    Temp.DeductionId = Convert.ToInt32(dr["DEDUCTION_ID"]);
                    Temp.DeductionDesc = Convert.ToString(dr["DEDUCTION"]);
                    Temp.Amount = Convert.ToDouble(dr["AMOUNT"]);

                }

                return Temp;
            }
            finally
            {
                con.Close();

            }
        }

        public void InsertStructureDeduction(StructureDeduction Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_STRUCTURE_DEDUCTION";
                cmd.Parameters.Add("@SalaryStructureId", SqlDbType.Int).Value = Temp.StructureId;
                cmd.Parameters.Add("@DeductionId", SqlDbType.Int).Value = Temp.DeductionId;
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
        public void UpdateStructureDeduction(StructureDeduction Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_STRUCTURE_DEDUCTION";
                cmd.Parameters.Add("@SalaryStructureId", SqlDbType.Int).Value = Temp.StructureId;
                cmd.Parameters.Add("@DeductionId", SqlDbType.VarChar).Value = Temp.DeductionId;
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
        public void DeleteStructureDeduction(int StructureId, int DeductionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_STRUCTURE_DEDUCTION";
                cmd.Parameters.Add("@SalaryStructureId", SqlDbType.VarChar).Value = StructureId;
                cmd.Parameters.Add("@DeductionId", SqlDbType.VarChar).Value = DeductionId;
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
        #endregion STRUCTURE DEDUCTION
        #region ALLOWANCES
        public List<Allowances> GetAllowances()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ALLOWANCES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Allowances> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Allowances>();
                    while (dr.Read())
                    {
                        Allowances Temp = new Allowances();

                        Temp.AllowanceId = Convert.ToInt32(dr["ALLOWANCE_ID"]);
                        Temp.AllowanceDesc = Convert.ToString(dr["ALLOWANCE"]);
                        Temp.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                        Temp.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                        Temp.Id= Convert.ToString(dr["ID"]);
                        Temp.IsActive= Convert.ToInt32(dr["IS_ACTIVE"]);
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
        public Allowances GetAllowance(int AllowanceId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ALLOWANCE";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                Allowances Temp = new Allowances();
                if (dr.HasRows)
                { 
                    dr.Read();
                        Temp.AllowanceId = Convert.ToInt32(dr["ALLOWANCE_ID"]);
                        Temp.AllowanceDesc = Convert.ToString(dr["ALLOWANCE"]);
                        Temp.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                        Temp.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                        Temp.Id = Convert.ToString(dr["ID"]);
                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                }

                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
       
        public void InsertAllowance(Allowances Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_ALLOWANCE";
                cmd.Parameters.Add("@Allowance", SqlDbType.VarChar).Value = Temp.AllowanceDesc;
                cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = Temp.HeadOfAccountId;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                    
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
        public void UpdateAllowance(Allowances Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_ALLOWANCE";
                cmd.Parameters.Add("@AllowanceId", SqlDbType.VarChar).Value = Temp.AllowanceId;
                cmd.Parameters.Add("@Allowance", SqlDbType.VarChar).Value = Temp.AllowanceDesc;
                cmd.Parameters.Add("@HeadOfAccountId", SqlDbType.Int).Value = Temp.HeadOfAccountId;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
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

        #endregion ALLOWANCE
        #region DEDUCTIONS
        public List<Deductions> GetDeductions()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_DEDUCTIONS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Deductions> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Deductions>();
                    while (dr.Read())
                    {
                        Deductions Temp = new Deductions();

                        Temp.DeductionId = Convert.ToInt32(dr["DEDUCTION_ID"]);
                        Temp.DeductionDesc = Convert.ToString(dr["DEDUCTION"]);
                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
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
        public Deductions GetDeduction(int DeductionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_DEDUCTION";
                SqlDataReader dr = cmd.ExecuteReader();
                Deductions Temp = new Deductions();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp.DeductionId = Convert.ToInt32(dr["DEDUCTION_ID"]);
                    Temp.DeductionDesc = Convert.ToString(dr["DEDUCTION"]);
                    Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                }

                return Temp;
            }
            finally
            {
                con.Close();

            }
        }

        public void InsertDeduction(Deductions Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_DEDUCTION";
                cmd.Parameters.Add("@Deduction", SqlDbType.VarChar).Value = Temp.DeductionDesc;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;

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
        public void UpdateDeduction(Deductions Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_DEDUCTION";
                cmd.Parameters.Add("@DeductionId", SqlDbType.VarChar).Value = Temp.DeductionId;
                cmd.Parameters.Add("@Deduction", SqlDbType.VarChar).Value = Temp.DeductionDesc;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
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
        #endregion DEDUCTION
        #region  CURRENT_DEDUCTIONS
        public List<CurrentDeduction> GetCurrentDeductions()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CURRENT_DEDUCTIONS";
                List<CurrentDeduction> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<CurrentDeduction>();
                    while (dr.Read())
                    {
                        CurrentDeduction Temp = new CurrentDeduction();
                        Temp.CurrentDeductionId = Convert.ToInt32(dr["CURRENT_DEDUCTION_ID"]);
                        Temp.DeductionId = Convert.ToInt32(dr["DEDUCTION_ID"]);
                        Temp.DeductionDesc = Convert.ToString(dr["DEDUCTION"]);
                        Temp.MemberId = Convert.ToInt32(dr["MEMBER_ID"]);
                        Temp.Amount= Convert.ToDouble(dr["AMOUNT"]);
                        Temp.IsStructured = Convert.ToInt32(dr["IS_STRUCTURED"]);
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
        public CurrentDeduction GetCurrentDeduction(int CurrentDeductionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CURRENT_DEDUCTION";
                SqlDataReader dr = cmd.ExecuteReader();
                CurrentDeduction Temp = new CurrentDeduction();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp.CurrentDeductionId = Convert.ToInt32(dr["CURRENT_DEDUCTION_ID"]);
                    Temp.DeductionId = Convert.ToInt32(dr["DEDUCTION_ID"]);
                    Temp.DeductionDesc = Convert.ToString(dr["DEDUCTION"]);
                    Temp.MemberId = Convert.ToInt32(dr["MEMBER_ID"]);
                    Temp.Amount = Convert.ToDouble(dr["AMOUNT"]);
                    Temp.IsStructured = Convert.ToInt32(dr["IS_STRUCTURED"]);

                }

                return Temp;
            }
            finally
            {
                con.Close();

            }
        }

        public void InsertCurrentDeduction(CurrentDeduction Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_CURRENT_DEDUCTION";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = Temp.MemberId;
                cmd.Parameters.Add("@DeductionId", SqlDbType.Int).Value = Temp.DeductionId;
                cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = Temp.Amount;
                cmd.Parameters.Add("@IsStructured", SqlDbType.Float).Value = Temp.IsStructured;
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
        public void UpdateCurrentDeduction(CurrentDeduction Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_CURRENT_DEDUCTION";
                cmd.Parameters.Add("@CurrentDeductionId", SqlDbType.VarChar).Value = Temp.CurrentDeductionId;
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
        public void DeleteCurrentDeduction(int CurrentDeductionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_CURRENT_DEDUCTION";
                cmd.Parameters.Add("@CurrentDeductionId", SqlDbType.VarChar).Value = CurrentDeductionId;
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
        #endregion CURRENT DEDUCTION
        #region  CURRENT_ALLOWANCES
        public List<CurrentAllowance> GetCurrentAllowances(int MemberId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CURRENT_ALLOWANCES";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = MemberId;
                List<CurrentAllowance> MyList = null;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<CurrentAllowance>();
                    while (dr.Read())
                    {
                        CurrentAllowance Temp = new CurrentAllowance();
                        Temp.CurrentAllowanceId = Convert.ToInt32(dr["CURRENT_ALLOWANCE_ID"]);
                        Temp.AllowanceId = Convert.ToInt32(dr["ALLOWANCE_ID"]);
                        Temp.AllowanceDesc = Convert.ToString(dr["ALLOWANCE"]);
                        Temp.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                        Temp.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                        Temp.MemberId = Convert.ToInt32(dr["MEMBER_ID"]);
                        Temp.Amount = Convert.ToDouble(dr["AMOUNT"]);
                        Temp.IsStructured = Convert.ToInt32(dr["IS_STRUCTURED"]);
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
        public CurrentAllowance GetCurrentAllowance(int CurrentAllowanceId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CURRENT_ALLOWANCE";
                SqlDataReader dr = cmd.ExecuteReader();
                CurrentAllowance Temp = new CurrentAllowance();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp.CurrentAllowanceId = Convert.ToInt32(dr["CURRENT_ALLOWANCE_ID"]);
                    Temp.AllowanceId = Convert.ToInt32(dr["ALLOWANCE_ID"]);
                    Temp.AllowanceDesc = Convert.ToString(dr["ALLOWANCE"]);
                    Temp.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                    Temp.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                    Temp.MemberId = Convert.ToInt32(dr["MEMBER_ID"]);
                    Temp.Amount = Convert.ToDouble(dr["AMOUNT"]);
                    Temp.IsStructured= Convert.ToInt32(dr["IS_STRUCTURED"]); 
                }

                return Temp;
            }
            finally
            {
                con.Close();

            }
        }

        public void InsertCurrentAllowance(CurrentAllowance Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_CURRENT_ALLOWANCE";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = Temp.MemberId;
                cmd.Parameters.Add("@AllowanceId", SqlDbType.Int).Value = Temp.AllowanceId;
                cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = Temp.Amount;
                cmd.Parameters.Add("@IsStructured", SqlDbType.Float).Value = Temp.IsStructured;
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
        public void UpdateCurrentAllowance(CurrentAllowance Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_CURRENT_ALLOWANCE";
                cmd.Parameters.Add("@CurrentAllowanceId", SqlDbType.VarChar).Value = Temp.CurrentAllowanceId;
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
        public void DeleteCurrentAllowance(int CurrentAllowanceId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_CURRENT_ALLOWANCE";
                cmd.Parameters.Add("@CurrentAllowanceId", SqlDbType.VarChar).Value = CurrentAllowanceId;
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
        #endregion CURRENT ALLOWANCE      
        #region  MONTHLY_ALLOWANCES
        public List<MonthlyAllowance> GetMonthlyAllowances(int MemberId ,int FinancialYearId, int MonthId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MONTHLY_ALLOWANCES";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = MemberId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value =FinancialYearId;
                cmd.Parameters.Add("@Month", SqlDbType.Int).Value = MonthId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<MonthlyAllowance> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MonthlyAllowance>();
                    while (dr.Read())
                    {
                        MonthlyAllowance Temp = new MonthlyAllowance();
                        Temp.AllowanceId = Convert.ToInt32(dr["SAL_ALLOWANCE_ID"]);
                        Temp.AllowanceDesc = Convert.ToString(dr["ALLOWANCE"]);
                        Temp.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                        Temp.FinancialYear = Convert.ToString(dr["FINANCIAL_YEAR"]);
                        Temp.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                        Temp.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                        Temp.MemberId = Convert.ToInt32(dr["SAL_MEMBER_ID"]);
                        Temp.Amount = Convert.ToDouble(dr["AMOUNT"]);
                        Temp.MonthlyRate= Convert.ToDouble(dr["MONTHLY_RATE"]);
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
        public MonthlyAllowance GetMonthlyAllowance(int MemberId,int MonthId,int FinancialYearId,int AllowanceId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MONTHLY_ALLOWANCE";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = MemberId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.Parameters.Add("@Month", SqlDbType.Int).Value = MonthId;
                cmd.Parameters.Add("@AllowanceId", SqlDbType.Int).Value = AllowanceId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                MonthlyAllowance Temp = new MonthlyAllowance();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp.AllowanceId = Convert.ToInt32(dr["SAL_ALLOWANCE_ID"]);
                    Temp.AllowanceDesc = Convert.ToString(dr["ALLOWANCE"]);
                    Temp.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                    Temp.FinancialYear = Convert.ToString(dr["FINANCIAL_YEAR"]);
                    Temp.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                    Temp.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                    Temp.MemberId = Convert.ToInt32(dr["SAL_MEMBER_ID"]);
                    Temp.Amount = Convert.ToDouble(dr["AMOUNT"]);
                    Temp.MonthlyRate = Convert.ToDouble(dr["MONTHLY_RATE"]);
                }

                return Temp;
            }
            finally
            {
                con.Close();

            }
        }

        public int InsertMonthlyAllowance(MonthlyAllowance Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                Allowances allow = GetAllowance(Temp.AllowanceId);
               // HeadOfAccountBudget hoa = new BudgetDal().GetBranchBudget(allow.HeadOfAccountId,Temp.FinancialYearId,10);
                //if (hoa.RemainingBalance >= Temp.Amount)
                //{
                    SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MONTHLY_ALLOWANCE";
                    cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = Temp.MemberId;
                    cmd.Parameters.Add("@AllowanceId", SqlDbType.Int).Value = Temp.AllowanceId;
                    cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = Temp.FinancialYearId;
                    cmd.Parameters.Add("@Month", SqlDbType.Int).Value = Temp.MonthId;
                    cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = Temp.Amount;
                    cmd.Parameters.Add("@MonthlyRate", SqlDbType.Float).Value = Temp.MonthlyRate;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    return 1;
                //}
                
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
        public int FinalizeMonthlyAllowance(MonthlyAllowance Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                Allowances allow = GetAllowance(Temp.AllowanceId);
                // HeadOfAccountBudget hoa = new BudgetDal().GetBranchBudget(allow.HeadOfAccountId,Temp.FinancialYearId,10);
                //if (hoa.RemainingBalance >= Temp.Amount)
                //{
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "FINALIZE_MONTHLY_ALLOWANCE";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = Temp.MemberId;
                cmd.Parameters.Add("@AllowanceId", SqlDbType.Int).Value = Temp.AllowanceId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = Temp.FinancialYearId;
                cmd.Parameters.Add("@Month", SqlDbType.Int).Value = Temp.MonthId;
                cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = Temp.Amount;
                cmd.Parameters.Add("@MonthlyRate", SqlDbType.Float).Value = Temp.MonthlyRate;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                return 1;
                //}

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
        public void UpdateMonthlyAllowance(MonthlyAllowance Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MONTHLY_ALLOWANCE";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = Temp.MemberId;
                cmd.Parameters.Add("@AllowanceId", SqlDbType.Int).Value = Temp.AllowanceId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = Temp.FinancialYearId;
                cmd.Parameters.Add("@Month", SqlDbType.Int).Value = Temp.MonthId;
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
        public void DeleteMonthlyAllowance(int MonthlyAllowanceId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_MONTHLY_ALLOWANCE";
                cmd.Parameters.Add("@MonthlyAllowanceId", SqlDbType.VarChar).Value = MonthlyAllowanceId;
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
        public List<MonthlyAllowance> GetDistinctMonthlyAllownacesList(int CategoryId, int FinancialYearId, int Month)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_DISTINCT_MONTHLY_ALLOWANCES_LIST";
                cmd.Parameters.Add("@SalaryCategoryId", SqlDbType.Int).Value = CategoryId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                cmd.CommandType = CommandType.StoredProcedure;
                List<MonthlyAllowance> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MonthlyAllowance>();
                    while (dr.Read())
                    {
                        MonthlyAllowance Temp = new MonthlyAllowance();
                        // Temp.StructureId = Convert.ToInt32(dr["SAL_STRUCTURE_ID"]);
                        //Temp.AllowanceId = Convert.ToInt32(dr["SAL_ALLOWANCE_ID"]);
                        Temp.AllowanceDesc = Convert.ToString(dr["ALLOWANCE"]);
                        //Temp.HeadOfAccountId = Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
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
        public List<MonthlyAllowance> GetMonthlyAllownacesList(int CategoryId,int FinancialYearId,int Month)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MONTHLY_ALLOWANCES_LIST";
                cmd.Parameters.Add("@SalaryCategoryId", SqlDbType.Int).Value = CategoryId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                cmd.CommandType = CommandType.StoredProcedure;
                List<MonthlyAllowance> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MonthlyAllowance>();
                    while (dr.Read())
                    {
                        MonthlyAllowance Temp = new MonthlyAllowance();
                       // Temp.StructureId = Convert.ToInt32(dr["SAL_STRUCTURE_ID"]);
                        Temp.AllowanceId = Convert.ToInt32(dr["SAL_ALLOWANCE_ID"]);
                        Temp.AllowanceDesc = Convert.ToString(dr["ALLOWANCE_NAME"]);
                        Temp.HeadOfAccountId= Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
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
        public List<MonthlyAllowance> GetMemberFinYearAllownacesList(int MemberId, int FinancialYearId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBER_FY_ALLOW_LIST";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = MemberId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<MonthlyAllowance> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MonthlyAllowance>();
                    while (dr.Read())
                    {
                        MonthlyAllowance Temp = new MonthlyAllowance();
                        Temp.AllowanceId = Convert.ToInt32(dr["SAL_ALLOWANCE_ID"]);
                        Temp.AllowanceDesc = Convert.ToString(dr["ALLOWANCE"]);
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
        #endregion MONTHLY ALLOWANCE
        #region  MONTHLY_DEDUCTIONS
        public List<MonthlyDeduction> GetMonthlyDeductions(int MemberId,int FinancialYearId,int MonthId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MONTHLY_DEDUCTIONS";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = MemberId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.Parameters.Add("@Month", SqlDbType.Int).Value = MonthId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<MonthlyDeduction> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MonthlyDeduction>();
                    while (dr.Read())
                    {
                        MonthlyDeduction Temp = new MonthlyDeduction();
                        Temp.DeductionId = Convert.ToInt32(dr["SAL_DEDUCTION_ID"]);
                        Temp.DeductionDesc = Convert.ToString(dr["DEDUCTION"]);
                        Temp.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                        Temp.FinancialYear = Convert.ToString(dr["FINANCIAL_YEAR"]);
                        Temp.MemberId = Convert.ToInt32(dr["SAL_MEMBER_ID"]);
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
        public MonthlyDeduction GetMonthlyDeduction(int MemberId, int MonthId, int FinancialYearId, int DeductionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MONTHLY_DEDUCTION";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = MemberId;
                cmd.Parameters.Add("@DeductionId", SqlDbType.Int).Value = DeductionId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.Parameters.Add("@Month", SqlDbType.Int).Value = MonthId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                MonthlyDeduction Temp = new MonthlyDeduction();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp.DeductionId = Convert.ToInt32(dr["SAL_DEDUCTION_ID"]);
                    Temp.DeductionDesc = Convert.ToString(dr["DEDUCTION"]);
                    Temp.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                    Temp.FinancialYear = Convert.ToString(dr["FINANCIAL_YEAR"]);
                    Temp.MemberId = Convert.ToInt32(dr["SAL_MEMBER_ID"]);
                    Temp.Description= Convert.ToString(dr["DESCRIPTION"]);
                    Temp.ShowInDetail = Convert.ToInt32(dr["SHOW_IN_DETAIL"]);
                    Temp.Amount = Convert.ToDouble(dr["AMOUNT"]);
                }

                return Temp;
            }
            finally
            {
                con.Close();

            }
        }

        public void InsertMonthlyDeduction(MonthlyDeduction Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MONTHLY_DEDUCTION";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = Temp.MemberId;
                cmd.Parameters.Add("@DeductionId", SqlDbType.Int).Value = Temp.DeductionId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = Temp.FinancialYearId;
                cmd.Parameters.Add("@Month", SqlDbType.Int).Value = Temp.MonthId;
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
        public void UpdateMonthlyDeduction(MonthlyDeduction Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MONTHLY_DEDUCTION";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = Temp.MemberId;
                cmd.Parameters.Add("@DeductionId", SqlDbType.Int).Value = Temp.DeductionId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = Temp.FinancialYearId;
                cmd.Parameters.Add("@Month", SqlDbType.Int).Value = Temp.MonthId;
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
        public void DeleteMonthlyDeduction(int MonthlyDeductionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_MONTHLY_DEDUCTION";
                cmd.Parameters.Add("@MonthlyDeductionId", SqlDbType.VarChar).Value = MonthlyDeductionId;
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
        public List<MonthlyDeduction> GetMonthlyDeductionsList(int CategoryId, int FinancialYearId, int Month)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MONTHLY_DEDUCTION_LIST";
                cmd.Parameters.Add("@SalaryCategoryId", SqlDbType.Int).Value = CategoryId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
                cmd.CommandType = CommandType.StoredProcedure;
                List<MonthlyDeduction> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MonthlyDeduction>();
                    while (dr.Read())
                    {
                        MonthlyDeduction Temp = new MonthlyDeduction();
                        // Temp.StructureId = Convert.ToInt32(dr["SAL_STRUCTURE_ID"]);
                        Temp.DeductionId = Convert.ToInt32(dr["SAL_DEDUCTION_ID"]);
                        Temp.DeductionDesc = Convert.ToString(dr["DEDUCTION"]);
                        Temp.Description= Convert.ToString(dr["DESCRIPTION"]);
                        Temp.ShowInDetail= Convert.ToInt32(dr["SHOW_IN_DETAIL"]);

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
        public List<MonthlyDeduction> GetMemberFinYearDeductionsList(int MemberId, int FinancialYearId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBER_FY_DED_LIST";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = MemberId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<MonthlyDeduction> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MonthlyDeduction>();
                    while (dr.Read())
                    {
                        MonthlyDeduction Temp = new MonthlyDeduction();
                        Temp.DeductionId = Convert.ToInt32(dr["SAL_DEDUCTION_ID"]);
                        Temp.DeductionDesc = Convert.ToString(dr["DEDUCTION"]);
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
        #endregion MONTHLY DEDUCTION

        #region Utilities
        public void AssignStructureToMembers(int SalaryStructureId)
        {
            SalaryStructure structure = GetSalaryStructure(SalaryStructureId);
            List<Member> StructureMembers = GetMembersByCategory(structure.MemberSalCategoryId);
            foreach (Member member in StructureMembers)
            {
                DeleteMemberCurrentStructure(member.MemberId);
                List<StructureAllowance> structAllowances = GetStructureAllownaces(SalaryStructureId);
                if (structAllowances != null)
                {
                    foreach (StructureAllowance structureallowance in structAllowances)
                    {
                        CurrentAllowance memberallowance = new CurrentAllowance();
                        memberallowance.MemberId = member.MemberId;
                        memberallowance.AllowanceId = structureallowance.AllowanceId;
                        memberallowance.Amount = structureallowance.Amount;
                        memberallowance.IsStructured = 1;
                        InsertMemberCurrentAllowance(memberallowance);
                    }
                }
                List<StructureDeduction> structDeductions = GetStructureDeductions(SalaryStructureId);
                if (structDeductions != null)
                {
                    foreach (StructureDeduction structuredeductions in structDeductions)
                    {
                        CurrentDeduction memberdeduction = new CurrentDeduction();
                        memberdeduction.MemberId = member.MemberId;
                        memberdeduction.DeductionId = structuredeductions.DeductionId;
                        memberdeduction.Amount = structuredeductions.Amount;
                        memberdeduction.IsStructured = 1;
                        InsertMemberCurrentDeduction(memberdeduction);
                    }
                }
            }
        }
        protected void DeleteMemberCurrentStructure(int SystemUsersId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_MEMBER_CURRENT_STRUCTURE";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = SystemUsersId;
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
        #endregion Utilities

        #region MEMBER_CURRENT_ALLOWANCES
        public List<CurrentAllowance> GetMemberCurrentAllowances(int MemberId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBER_CURRENT_ALLOWANCES";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = MemberId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<CurrentAllowance> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<CurrentAllowance>();
                    while (dr.Read())
                    {
                        CurrentAllowance Temp = new CurrentAllowance();
                        Temp.CurrentAllowanceId= Convert.ToInt32(dr["CURRENT_ALLOWANCE_ID"]);
                        Temp.AllowanceId = Convert.ToInt32(dr["ALLOWANCE_ID"]);
                        Temp.AllowanceDesc = Convert.ToString(dr["ALLOWANCE"]);
                        Temp.HeadOfAccountId= Convert.ToInt32(dr["HEAD_OF_ACCOUNT_ID"]);
                        Temp.MemberId = Convert.ToInt32(dr["MEMBER_ID"]);
                        Temp.Amount = Convert.ToDouble(dr["AMOUNT"]);
                        Temp.IsStructured = Convert.ToInt32(dr["IS_STRUCTURED"]);
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
        public void InsertMemberCurrentAllowance(CurrentAllowance Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MEMBER_CURRENT_ALLOWANCE";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = Temp.MemberId;
                cmd.Parameters.Add("@AllowanceId", SqlDbType.Int).Value = Temp.AllowanceId;
                cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = Temp.Amount;
                cmd.Parameters.Add("@IsStructured", SqlDbType.Int).Value = Temp.IsStructured;
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
        public void UpdateMemberCurrentAllowance(CurrentAllowance Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MEMBER_CURRENT_ALLOWANCE";
                cmd.Parameters.Add("@CurrentAllowanceId", SqlDbType.Int).Value = Temp.CurrentAllowanceId;
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = Temp.MemberId;
                cmd.Parameters.Add("@AllowanceId", SqlDbType.Int).Value = Temp.AllowanceId;
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



        #endregion  MEMBER_CURRENT_ALLOWANCES
        #region MEMBER_CURRENT_DEDUCTIONS
        public List<CurrentDeduction> GetMemberCurrentDeductions(int MemberId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBER_CURRENT_DEDUCTIONS";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = MemberId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<CurrentDeduction> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<CurrentDeduction>();
                    while (dr.Read())
                    {
                        CurrentDeduction Temp = new CurrentDeduction();
                        Temp.CurrentDeductionId = Convert.ToInt32(dr["CURRENT_DEDUCTION_ID"]);
                        Temp.DeductionId = Convert.ToInt32(dr["DEDUCTION_ID"]);
                        Temp.DeductionDesc = Convert.ToString(dr["DEDUCTION"]);
                        Temp.MemberId = Convert.ToInt32(dr["MEMBER_ID"]);
                        Temp.Amount = Convert.ToDouble(dr["AMOUNT"]);
                        Temp.IsStructured = Convert.ToInt32(dr["IS_STRUCTURED"]);
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
        public void InsertMemberCurrentDeduction(CurrentDeduction Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MEMBER_CURRENT_DEDUCTION";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = Temp.MemberId;
                cmd.Parameters.Add("@DeductionId", SqlDbType.Int).Value = Temp.DeductionId;
                cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = Temp.Amount;
                cmd.Parameters.Add("@IsStructured", SqlDbType.Int).Value = Temp.IsStructured;
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
        public void UpdateMemberCurrentDeduction(CurrentDeduction Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MEMBER_CURRENT_DEDUCTION";
                cmd.Parameters.Add("@CurrentDeductionId", SqlDbType.Int).Value = Temp.CurrentDeductionId;
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = Temp.MemberId;
                cmd.Parameters.Add("@DeductionId", SqlDbType.Int).Value = Temp.DeductionId;
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
        #endregion  MEMBER_CURRENT_DEDUCTIONS

        public double GetMembersTotalAllowanceAmount(int AllowanceId)
        {
            double Amount = 0;
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ALLOWANCE_SUM";
                cmd.Parameters.Add("@AllowanceId", SqlDbType.Int).Value = AllowanceId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Amount = Convert.ToDouble(dr["Amount"]);
                }

                return Amount;
            }
            finally
            {
                con.Close();

            }
        }
        #region MEMBER_BANK_ACCOUNTS
        public List<MemberBankAccounts> GetMemberBankAccounts(int MemberId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBER_BANK_ACCOUNTS";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = MemberId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<MemberBankAccounts> salarystructure = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    salarystructure = new List<MemberBankAccounts>();
                    while (dr.Read())
                    {
                        MemberBankAccounts cy = new MemberBankAccounts();
                        cy.MemberId = Convert.ToInt32(dr["MEMBER_ID"]);
                        cy.MemberBankAccountId = Convert.ToInt32(dr["MEMBER_BANK_ID"]);
                        cy.BankName = Convert.ToString(dr["BANK_NAME"]);
                        cy.AccountNumber = Convert.ToString(dr["ACCOUNT_NUMBER"]);
                        cy.IsSalaried = Convert.ToInt32(dr["IS_SALARIED"]);
                        salarystructure.Add(cy);
                    }
                }

                if (salarystructure != null) salarystructure.TrimExcess();
                return salarystructure;
            }
            finally
            {
                con.Close();

            }
        }
        public MemberBankAccounts GetMemberBankAccount(int BankAccountsId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBER_BANK_ACCOUNT";
                cmd.Parameters.Add("@BankAccountId", SqlDbType.Int).Value = BankAccountsId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                MemberBankAccounts cy = new MemberBankAccounts();
                if (dr.HasRows)
                {
                    dr.Read();
                    cy.MemberId = Convert.ToInt32(dr["MEMBER_ID"]);
                    cy.MemberBankAccountId = Convert.ToInt32(dr["MEMBER_BANK_ID"]);
                    cy.BankName = Convert.ToString(dr["BANK_NAME"]);
                    cy.AccountNumber = Convert.ToString(dr["ACCOUNT_NUMBER"]);
                    cy.IsSalaried = Convert.ToInt32(dr["IS_SALARIED"]);

                }

                return cy;
            }
            finally
            {
                con.Close();

            }
        }
        public MemberBankAccounts GetMemberSalaryAccount(int MemberId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBER_SALARY_ACCOUNTS";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = MemberId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                MemberBankAccounts cy = new MemberBankAccounts();
                if (dr.HasRows)
                {
                    dr.Read();
                    cy.MemberId = Convert.ToInt32(dr["MEMBER_ID"]);
                    cy.MemberBankAccountId = Convert.ToInt32(dr["MEMBER_BANK_ID"]);
                    cy.BankName = Convert.ToString(dr["BANK_NAME"]);
                    cy.AccountNumber = Convert.ToString(dr["ACCOUNT_NUMBER"]);
                    cy.IsSalaried = Convert.ToInt32(dr["IS_SALARIED"]);

                }

                return cy;
            }
            finally
            {
                con.Close();

            }
        }

        public void InsertMemberBankAccount(MemberBankAccounts Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MEMBER_BANK_ACCOUNT";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = Temp.MemberId;
                cmd.Parameters.Add("@BankName", SqlDbType.VarChar).Value = Temp.BankName;
                cmd.Parameters.Add("@AccountNumber", SqlDbType.VarChar).Value = Temp.AccountNumber;
                cmd.Parameters.Add("@IsSalaried", SqlDbType.Int).Value = Temp.IsSalaried;
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
        public void UpdateMemberBankAccount(MemberBankAccounts Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MEMBER_BANK_ACCOUNT";
                cmd.Parameters.Add("@BankAccountId", SqlDbType.Int).Value = Temp.MemberBankAccountId;
                cmd.Parameters.Add("@BankName", SqlDbType.VarChar).Value = Temp.BankName;
                cmd.Parameters.Add("@AccountNumber", SqlDbType.VarChar).Value = Temp.AccountNumber;
                cmd.Parameters.Add("@IsSalaried", SqlDbType.Int).Value = Temp.IsSalaried;
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
        public void DeleteMemberBankAccount(int BankAccountsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_MEMBER_BANK_ACCOUNT";
                cmd.Parameters.Add("@BankAccountId", SqlDbType.Int).Value = BankAccountsId;
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

        #endregion MEMBER_BANK_ACCOUNTS

        #region MEMBER_SALARY_DETAILS
        public List<MemberSalaryDetails> GetMemberSalaryDetails(int MemberId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBER_SALARY_DETAILS";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = MemberId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<MemberSalaryDetails> salarystructure = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    salarystructure = new List<MemberSalaryDetails>();
                    while (dr.Read())
                    {
                        MemberSalaryDetails cy = new MemberSalaryDetails();
                        cy.MemberId = Convert.ToInt32(dr["MEMBER_ID"]);
                        cy.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                        cy.MonthId = Convert.ToInt32(dr["MONTH_ID"]);
                        cy.BankName = Convert.ToString(dr["BANK_NAME"]);
                        cy.BankAccount = Convert.ToString(dr["ACCOUNT_NUMBER"]);
                        cy.TotalAllowances = Convert.ToDouble(dr["TOTAL_ALLOWANCES"]);
                        cy.TotalDeductions = Convert.ToDouble(dr["TOTAL_DEDUCTIONS"]);
                        salarystructure.Add(cy);
                    }
                }

                if (salarystructure != null) salarystructure.TrimExcess();
                return salarystructure;
            }
            finally
            {
                con.Close();

            }
        }
       
        public MemberSalaryDetails GetMemberSalaryDetail(int MemberId,int FinancialYearId,int MonthId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBER_SALARY_DETAIL";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = MemberId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.Parameters.Add("@Month", SqlDbType.Int).Value = MonthId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                MemberSalaryDetails cy = new MemberSalaryDetails();
                if (dr.HasRows)
                {
                    dr.Read();
                    cy.MemberId = Convert.ToInt32(dr["MEMBER_ID"]);
                    cy.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                    cy.MonthId = Convert.ToInt32(dr["MONTH_ID"]);
                    cy.BankName = Convert.ToString(dr["BANK_NAME"]);
                    cy.BankAccount = Convert.ToString(dr["ACCOUNT_NUMBER"]);
                    cy.TotalAllowances = Convert.ToDouble(dr["TOTAL_ALLOWANCES"]);
                    cy.TotalDeductions = Convert.ToDouble(dr["TOTAL_DEDUCTIONS"]);
                    cy.ChequeNumber = Convert.ToString(dr["CHEQUE_NUMBER"]);
                    //cy.ChequeDate = Convert.ToDateTime(dr["CHEQUE_DATE"]);
                }

                return cy;
            }
            finally
            {
                con.Close();

            }
        }

        public void InsertMemberSalaryDetail(MemberSalaryDetails Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MEMBER_SALARY_DETAIL";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = Temp.MemberId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = Temp.FinancialYearId;
                cmd.Parameters.Add("@Month", SqlDbType.Int).Value = Temp.MonthId;
                cmd.Parameters.Add("@BankName", SqlDbType.VarChar).Value = Temp.BankName;
                cmd.Parameters.Add("@AccountNumber", SqlDbType.VarChar).Value = Temp.BankAccount;
                cmd.Parameters.Add("@TotalAllowances", SqlDbType.Float).Value = Temp.TotalAllowances;
                cmd.Parameters.Add("@TotalDeductions", SqlDbType.Float).Value = Temp.TotalDeductions;
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
        public void UpdateMemberChequeDetail(MemberSalaryDetails Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MEMBER_SALARY_CHEQUE";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = Temp.MemberId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = Temp.FinancialYearId;
                cmd.Parameters.Add("@Month", SqlDbType.Int).Value = Temp.MonthId;
                cmd.Parameters.Add("@ChequeNumber", SqlDbType.VarChar).Value = Temp.ChequeNumber;
                cmd.Parameters.Add("@ChequeDate", SqlDbType.VarChar).Value = Temp.ChequeDate;
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
        #endregion MEMBER_SALARY_DETAIL
        #region  MONTHLY_CHANGE
        public List<MonthlyChange> GetMonthlyChanges(int MemberId, int FinancialYearId, int MonthId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBER_MONTHLY_CHANGES";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = MemberId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.Parameters.Add("@Month", SqlDbType.Int).Value = MonthId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<MonthlyChange> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MonthlyChange>();
                    while (dr.Read())
                    {
                        MonthlyChange Temp = new MonthlyChange();
                        Temp.MonthlyChangeId= Convert.ToInt32(dr["MONTHLY_CHANGE_ID"]);
                        Temp.Id = Convert.ToInt32(dr["ALLOWANCE_ID"]);
                        Temp.Description = Convert.ToString(dr["ALLOWANCE"]);
                        Temp.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                        Temp.MonthId = Convert.ToInt32(dr["MONTH_ID"]);
                        Temp.MemberId = Convert.ToInt32(dr["MEMBER_ID"]);
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
        public MonthlyChange GetMonthlyChange(int MemberId, int FinancialYearId, int MonthId, int AllowanceId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBER_MONTHLY_CHANGE";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = MemberId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.Parameters.Add("@Month", SqlDbType.Int).Value = MonthId;
                cmd.Parameters.Add("@AllowanceId", SqlDbType.Int).Value = AllowanceId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                MonthlyChange Temp = new MonthlyChange();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp.MonthlyChangeId = Convert.ToInt32(dr["MONTHLY_CHANGE_ID"]);
                    Temp.Id = Convert.ToInt32(dr["ALLOWANCE_ID"]);
                    Temp.Description = Convert.ToString(dr["ALLOWANCE"]);
                    Temp.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                    Temp.MonthId = Convert.ToInt32(dr["MONTH_ID"]);
                    Temp.MemberId = Convert.ToInt32(dr["MEMBER_ID"]);
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

        public void InsertMonthlyChange(MonthlyChange Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MEMBER_MONTHLY_CHANGE";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = Temp.MemberId;
                cmd.Parameters.Add("@AllowanceId", SqlDbType.Int).Value = Temp.Id;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = Temp.FinancialYearId;
                cmd.Parameters.Add("@Month", SqlDbType.Int).Value = Temp.MonthId;
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
        public void DeleteMonthlyChange(int MonthlyChangeId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_MEMBER_MONTHLY_CHANGE";
                cmd.Parameters.Add("@ChangeId", SqlDbType.Int).Value = MonthlyChangeId;
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
        public List<MonthlyChange> GetMonthlyChanges(int FinancialYearId, int MonthId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MONTHLY_ALLOWANCE_CHANGES";
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.Parameters.Add("@Month", SqlDbType.Int).Value = MonthId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<MonthlyChange> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MonthlyChange>();
                    while (dr.Read())
                    {
                        MonthlyChange Temp = new MonthlyChange();
                        Temp.MonthlyChangeId = Convert.ToInt32(dr["MONTHLY_CHANGE_ID"]);
                        Temp.Id = Convert.ToInt32(dr["ALLOWANCE_ID"]);
                        Temp.Description = Convert.ToString(dr["ALLOWANCE"]);
                        Temp.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                        Temp.MonthId = Convert.ToInt32(dr["MONTH_ID"]);
                        Temp.MemberName = Convert.ToString(dr["F_NAME"]);
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
        #endregion MONTHLY ALLOWANCE
        #region  MONTHLY_DEDUCTION_CHANGE
        public List<MonthlyChange> GetMonthlyDeductionChanges(int MemberId, int FinancialYearId, int MonthId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBER_MONTHLY_DED_CHANGES";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = MemberId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.Parameters.Add("@Month", SqlDbType.Int).Value = MonthId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<MonthlyChange> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MonthlyChange>();
                    while (dr.Read())
                    {
                        MonthlyChange Temp = new MonthlyChange();
                        Temp.MonthlyChangeId = Convert.ToInt32(dr["MONTHLY_CHANGE_ID"]);
                        Temp.Id = Convert.ToInt32(dr["DEDUCTION_ID"]);
                        Temp.Description = Convert.ToString(dr["DEDUCTION"]);
                        Temp.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                        Temp.MonthId = Convert.ToInt32(dr["MONTH_ID"]);
                        Temp.MemberId = Convert.ToInt32(dr["MEMBER_ID"]);
                        Temp.Amount = Convert.ToDouble(dr["AMOUNT"]);
                        Temp.Limit= Convert.ToDouble(dr["LIMIT"]);
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
        public MonthlyChange GetMonthlyDeductionChange(int MemberId, int FinancialYearId, int MonthId, int DeductionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBER_MONTHLY_DED_CHANGE";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = MemberId;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.Parameters.Add("@Month", SqlDbType.Int).Value = MonthId;
                cmd.Parameters.Add("@DeductionId", SqlDbType.Int).Value = DeductionId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                MonthlyChange Temp = new MonthlyChange();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp.MonthlyChangeId = Convert.ToInt32(dr["MONTHLY_CHANGE_ID"]);
                    Temp.Id = Convert.ToInt32(dr["DEDUCTION_ID"]);
                    Temp.Description = Convert.ToString(dr["DEDUCTION"]);
                    Temp.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                    Temp.MonthId = Convert.ToInt32(dr["MONTH_ID"]);
                    Temp.MemberId = Convert.ToInt32(dr["MEMBER_ID"]);
                    Temp.Amount = Convert.ToDouble(dr["AMOUNT"]);
                    Temp.Limit = Convert.ToDouble(dr["LIMIT"]);
                    Temp.Remarks = Convert.ToString(dr["REMARKS"]);
                }

                return Temp;
            }
            finally
            {
                con.Close();

            }
        }

        public void InsertMonthlyDeductionChange(MonthlyChange Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MEMBER_MONTHLY_DED_CHANGE";
                cmd.Parameters.Add("@ReferenceId", SqlDbType.Int).Value = Temp.ReferenceId;
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = Temp.MemberId;
                cmd.Parameters.Add("@DeductionId", SqlDbType.Int).Value = Temp.Id;
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = Temp.FinancialYearId;
                cmd.Parameters.Add("@Month", SqlDbType.Int).Value = Temp.MonthId;
                cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = Temp.Amount;
                cmd.Parameters.Add("@Limit", SqlDbType.Float).Value = Temp.Limit;
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
        public void DeleteMonthlyDeductionChange(int MonthlyChangeId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_MEMBER_MONTHLY_DED_CHANGE";
                cmd.Parameters.Add("@ChangeId", SqlDbType.Int).Value = MonthlyChangeId;
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
        public List<MonthlyChange> GetMonthlyDeductionChanges(int FinancialYearId, int MonthId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MONTHLY_DEDUCTION_CHANGES";
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.Parameters.Add("@Month", SqlDbType.Int).Value = MonthId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<MonthlyChange> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MonthlyChange>();
                    while (dr.Read())
                    {
                        MonthlyChange Temp = new MonthlyChange();
                        Temp.MonthlyChangeId = Convert.ToInt32(dr["MONTHLY_CHANGE_ID"]);
                        Temp.Description = Convert.ToString(dr["DEDUCTION"]);
                        Temp.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                        Temp.MonthId = Convert.ToInt32(dr["MONTH_ID"]);
                        Temp.MemberName = Convert.ToString(dr["F_NAME"]);
                        Temp.Amount = Convert.ToDouble(dr["AMOUNT"]);
                        Temp.Limit = Convert.ToDouble(dr["LIMIT"]);
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
        #endregion MONTHLY_DEDUCTION_CHANGE

        #region FINANCIAL_YEAR_SAL_DETAILS
        public void ResetAllowancesDeductions(int FinancialYearsId,int Month)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "RESET_ALLOWANCES_DEDUCTIONS";
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearsId;
                cmd.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
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
        public FinancialYearSalaryDetail GetFinancialYearSalaryDetails(int MonthId, int FinancialYearId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_FY_SALARY_DETAIL";
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.Parameters.Add("@Month", SqlDbType.Int).Value = MonthId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                FinancialYearSalaryDetail Temp = new FinancialYearSalaryDetail();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                    Temp.MonthId = Convert.ToInt32(dr["MONTH_ID"]);
                    Temp.Processed = Convert.ToInt32(dr["PROCESSED"]);
                    Temp.Finalized = Convert.ToInt32(dr["FINALIZED"]);
                }

                return Temp;
            }
            finally
            {
                con.Close();

            }
        }

        public void InsertFinancialYearSalaryDetails(FinancialYearSalaryDetail Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                FinancialYearSalaryDetail fyd = GetFinancialYearSalaryDetails(Temp.MonthId,Temp.FinancialYearId);
                if (fyd.MonthId == 0)
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_FY_SALARY_DETAIL";
                    cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = Temp.FinancialYearId;
                    cmd.Parameters.Add("@Month", SqlDbType.Int).Value = Temp.MonthId;
                    cmd.Parameters.Add("@Processed", SqlDbType.Int).Value = Temp.Processed;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
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
        public void UpdateFinalizeDetail(FinancialYearSalaryDetail Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SALARY_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_FINALIZE_DETAIL";
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = Temp.FinancialYearId;
                cmd.Parameters.Add("@Month", SqlDbType.Int).Value = Temp.MonthId;
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
    }
}
