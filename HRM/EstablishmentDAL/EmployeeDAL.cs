using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EstablishmentENT;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using Utilities;

namespace EstablishmentDAL
{
    public class EmployeeDAL
    {
        public List<EmpSearchList> GetEmployeesList()
        {
           // GetAllEmployees();
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "SELECT_ACTIVE_EMPLOYEES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<EmpSearchList> emp = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        emp = new List<EmpSearchList>();
                        while (dr.Read())
                        {
                            EmpSearchList ad = new EmpSearchList();
                            ad.EmpId = Convert.ToInt32(dr["system_users_id"]);
                            ad.EmpName = Convert.ToString(dr["f_name"] + " " + dr["m_name"] + " " + dr["l_name"]);
                            ad.EmpAddress = Convert.ToString(dr["perm_address"]);
                            ad.EmpDesignation = Convert.ToString(dr["post"]);
                            ad.Bps = Convert.ToString(dr["bps"]);
                            ad.Empstatus = Convert.ToString(dr["EMPL_STATUS"]);
                            if(dr["GOVT_SERVICE_START_DATE"]!=DBNull.Value)
                            ad.GovtServiceStartDate = Convert.ToDateTime(dr["GOVT_SERVICE_START_DATE"]);
                            if (dr["House_SERVICE_START_DATE"] != DBNull.Value)
                                ad.HouseServiceStartDate= Convert.ToDateTime(dr["House_Service_Start_Date"]);
                            ad.PreviousLeaveCredit= Convert.ToInt32(dr["PREVIOUS_LEAVE_CREDIT"]);
                            ad.Filenumber = Convert.ToString(dr["file_no"]);
                            if (dr["Personal_No"] != DBNull.Value)
                                ad.PersonalNumber = Convert.ToDouble(dr["Personal_No"]);
                            ad.Age = Convert.ToString(dr["age"]);
                            ad.LocalAddress = Convert.ToString(dr["Local_address"]);
                            ad.EmailAddress = Convert.ToString(dr["Email"]);
                            if (dr["EnteredBy"] != DBNull.Value)
                                ad.EnteredBy = Convert.ToString(dr["EnteredBy"]);
                            if (dr["EnteredOn"] != DBNull.Value)
                                ad.EnteredOn = Convert.ToDateTime(dr["EnteredOn"]);
                            if (dr["RecheckedBy"] != DBNull.Value)
                                ad.RecheckedBy = Convert.ToString(dr["RecheckedBy"]);
                            ad.ImageUrl= Convert.ToString(dr["ImageUrl"]);
                            emp.Add(ad);
                        }
                    }

                    if (emp != null) emp.TrimExcess();
                    return emp;
                }
            }
            finally
            {
                con.Close();
            }



        }
        public List<EmpSearchList> GetAllEmployeesList()
        {
            // GetAllEmployees();
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "SELECT_ALL_ACTIVE_EMPLOYEES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<EmpSearchList> emp = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        emp = new List<EmpSearchList>();
                        while (dr.Read())
                        {
                            EmpSearchList ad = new EmpSearchList();
                            ad.EmpId = Convert.ToInt32(dr["system_users_id"]);
                            ad.EmpName = Convert.ToString(dr["f_name"]);
                            ad.EmpAddress = Convert.ToString(dr["perm_address"]);
                            if (dr["GOVT_SERVICE_START_DATE"] != DBNull.Value)
                                ad.GovtServiceStartDate = Convert.ToDateTime(dr["GOVT_SERVICE_START_DATE"]);
                            if (dr["House_SERVICE_START_DATE"] != DBNull.Value)
                                ad.HouseServiceStartDate = Convert.ToDateTime(dr["House_Service_Start_Date"]);
                            ad.PreviousLeaveCredit = Convert.ToInt32(dr["PREVIOUS_LEAVE_CREDIT"]);
                            ad.Filenumber = Convert.ToString(dr["file_no"]);
                            if (dr["Personal_No"] != DBNull.Value)
                                ad.PersonalNumber = Convert.ToDouble(dr["Personal_No"]);
                            ad.Age = Convert.ToString(dr["age"]);
                            ad.LocalAddress = Convert.ToString(dr["Local_address"]);
                            ad.EmailAddress = Convert.ToString(dr["Email"]);
                            if (dr["EnteredBy"] != DBNull.Value)
                                ad.EnteredBy = Convert.ToString(dr["EnteredBy"]);
                            if (dr["EnteredOn"] != DBNull.Value)
                                ad.EnteredOn = Convert.ToDateTime(dr["EnteredOn"]);
                            if (dr["RecheckedBy"] != DBNull.Value)
                                ad.RecheckedBy = Convert.ToString(dr["RecheckedBy"]);
                            emp.Add(ad);
                        }
                    }

                    if (emp != null) emp.TrimExcess();
                    return emp;
                }
            }
            finally
            {
                con.Close();
            }
        }
        public void GetAllEmployees()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ALL_EMPLOYEES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<EmpSearchList> emp = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        emp = new List<EmpSearchList>();
                        while (dr.Read())
                        {
                            EmpSearchList ad = new EmpSearchList();
                            ad.EmpId = Convert.ToInt32(dr["system_users_id"]);
                            ad.EmpName = Convert.ToString(dr["f_name"] + " " + dr["m_name"] + " " + dr["l_name"]);
                            ad.EmpAddress = Convert.ToString(dr["perm_address"]);
                            //ad.EmpDesignation = Convert.ToString(dr["post"]);
                            //ad.Bps = Convert.ToString(dr["bps"]);
                            //ad.Empstatus = Convert.ToString(dr["EMPL_STATUS"]);
                            //if (dr["GOVT_SERVICE_START_DATE"] != DBNull.Value)
                            //    ad.GovtServiceStartDate = Convert.ToDateTime(dr["GOVT_SERVICE_START_DATE"]);
                            //if (dr["House_SERVICE_START_DATE"] != DBNull.Value)
                            //    ad.HouseServiceStartDate = Convert.ToDateTime(dr["House_Service_Start_Date"]);
                            //ad.PreviousLeaveCredit = Convert.ToInt32(dr["PREVIOUS_LEAVE_CREDIT"]);
                            //ad.Filenumber = Convert.ToString(dr["file_no"]);
                            //if (dr["Personal_No"] != DBNull.Value)
                            //    ad.PersonalNumber = Convert.ToDouble(dr["Personal_No"]);
                            //ad.Age = Convert.ToString(dr["age"]);
                            //ad.LocalAddress = Convert.ToString(dr["Local_address"]);
                            //ad.EmailAddress = Convert.ToString(dr["Email"]);
                            //if (dr["EnteredBy"] != DBNull.Value)
                            //    ad.EnteredBy = Convert.ToString(dr["EnteredBy"]);
                            //if (dr["EnteredOn"] != DBNull.Value)
                            //    ad.EnteredOn = Convert.ToDateTime(dr["EnteredOn"]);
                            //if (dr["RecheckedBy"] != DBNull.Value)
                            //    ad.RecheckedBy = Convert.ToString(dr["RecheckedBy"]);
                            emp.Add(ad);
                        }
                    }

                    foreach (EmpSearchList sl in emp)
                    {
                        UpdateEmployment(sl.EmpId);
                    }
                }
            }
            finally
            {
                con.Close();
            }



        }
        public void UpdateEmployment(int EmpId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_EMPLOYMENT";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    AuditLogger.LogCommand(cmd);
                }
            }
            finally
            {
                con.Close();
            }



        }
        public List<EmpSearchList> SearchEmployee(string query)
        {
            SqlCommand cmd = new SqlCommand(query, new DalHelper().GetConnection());
            return EmpList(query);

        }
        public EmpHeaderInfo GetEmpName(int EmpId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_NAME";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                using (con)
                {
                    EmpHeaderInfo pd = new EmpHeaderInfo();
                    //cmd.ExecuteReader();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    pd.EmpName = Convert.ToString(dr["f_name"]);
                    // pd.EmpStatus= Convert.ToString(dr["EMPL_STATUS"]);
                    //pd.POST = Convert.ToString(dr["POST"]);
                    // pd.BPS = Convert.ToString(dr["BPS"]);
                    return pd;
                }
            }
            finally
            {
                con.Close();
            }

        }
        public EmpHeaderInfo GetEmpDesignation(int EmpId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_DESIGNATION";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                using (con)
                {

                    EmpHeaderInfo pd = new EmpHeaderInfo();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        ;
                        pd.POST = Convert.ToString(dr["POST"]);
                        pd.BPS = Convert.ToString(dr["BPS"]);
                    }

                    return pd;
                }
            }
            finally
            {
                con.Close();
            }

        }
        public EmpHeaderInfo GetEmpEmplStatus(int EmpId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_EMPL_STATUS";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                using (con)
                {

                    EmpHeaderInfo pd = new EmpHeaderInfo();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        
                        pd.EmploymentStatus = Convert.ToString(dr["EMP_STATUS"]);
                        pd.CurrentStatus= Convert.ToString(dr["CURRENT_STATUS"]);
                    }

                    return pd;
                }
            }
            finally
            {
                con.Close();
            }

        }
        public EmpHeaderInfo GetEmpBranch(int EmpId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_BRANCH";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                using (con)
                {

                    EmpHeaderInfo pd = new EmpHeaderInfo();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        pd.BRANCH = Convert.ToString(dr["BRANCH_NAME"]);
                        pd.AdditionalBranches = GetEmployeeCurrentAdditionalBranches(EmpId);
                    }

                    return pd;
                }
            }
            finally
            {
                con.Close();
            }

        }
        public List<AdditionalBranchesEnt> GetEmployeeCurrentAdditionalBranches(int SystemUsersId)
        {
            // GetAllEmployees();
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMPLOYEE_CURRENT_ADDITIONAL_BRANCHES";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = SystemUsersId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<AdditionalBranchesEnt> emp = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        emp = new List<AdditionalBranchesEnt>();
                        while (dr.Read())
                        {
                            AdditionalBranchesEnt ad = new AdditionalBranchesEnt();
                            ad.PostingId= Convert.ToInt32(dr["EMP_POSTING_ID"]);
                            ad.AdditionalBranchesId= Convert.ToInt32(dr["BRANCH_ID"]);
                            ad.AdditionalBranch= Convert.ToString(dr["BRANCH_NAME"]);
                            ad.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                            emp.Add(ad);
                        }
                    }

                    if (emp != null) emp.TrimExcess();
                    return emp;
                }
            }
            finally
            {
                con.Close();
            }
        }



        public PersonalDetail GetPersonalDetails(int empId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_DETAILS";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = empId;
                cmd.CommandType = CommandType.StoredProcedure;
                using (con)
                {
                    PersonalDetail pd = new PersonalDetail();

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr["system_users_id"] != DBNull.Value)
                        pd.Userid = Convert.ToInt32(dr["system_users_id"]);
                    if (dr["is_active"] != DBNull.Value)
                        pd.IsActive = Convert.ToInt32(dr["is_active"]);
                    if (dr["title"] != DBNull.Value)
                        pd.Title = Convert.ToString(dr["title"]);
                    if (dr["previous_Name"] != DBNull.Value)
                        pd.PreviousName = Convert.ToString(dr["previous_Name"]);
                    if (dr["name_change_date"] != DBNull.Value)
                        pd.NameChangeDate = Convert.ToDateTime(dr["name_change_date"]);
                    if (dr["Name_Change_Date"] != DBNull.Value)
                        pd.NameChangeDate = Convert.ToDateTime(dr["Name_Change_Date"]);
                    if (dr["f_Name"] != DBNull.Value)
                        pd.FName = Convert.ToString(dr["f_name"]);
                    if (dr["l_Name"] != DBNull.Value)
                        pd.LName = Convert.ToString(dr["l_name"]);
                    if (dr["m_name"] != DBNull.Value)
                        pd.MName = Convert.ToString(dr["m_name"]);
                    if (dr["father_husband_name"] != DBNull.Value)
                        pd.FatherNanme = Convert.ToString(dr["father_husband_name"]);
                    if (dr["email"] != DBNull.Value)
                        pd.EMail = Convert.ToString(dr["email"]);
                    if (dr["nic_number"] != DBNull.Value)
                        pd.Cnic = Convert.ToString(dr["nic_number"]);
                    if (dr["nic_date"] != DBNull.Value)
                        pd.CnicDate = Convert.ToDateTime(dr["nic_date"]);
                    if (dr["nic_exp_date"] != DBNull.Value)
                        pd.cnicExpDate = Convert.ToDateTime(dr["nic_exp_date"]);
                    if (dr["old_nic_no"] != DBNull.Value)
                        pd.OldCnic = Convert.ToString(dr["old_nic_no"]);
                    if (dr["place_of_birth"] != DBNull.Value)
                        pd.BirthPlace = Convert.ToInt32(dr["place_of_birth"]);
                    if (dr["dob"] != DBNull.Value)
                        pd.Dob = Convert.ToDateTime(dr["DOB"]);
                    if (dr["domicile_district"] != DBNull.Value)
                        pd.DomDistrict = Convert.ToInt32(dr["Domicile_District"]);
                    if (dr["gender"] != DBNull.Value)
                        pd.Gender = Convert.ToInt32(dr["Gender"]);
                    if (dr["nic_place"] != DBNull.Value)
                        pd.IssuePlace = Convert.ToInt32(dr["nic_place"]);
                    if (dr["local_address"] != DBNull.Value)
                        pd.LocalAddress = Convert.ToString(dr["local_address"]);
                    if (dr["perm_address"] != DBNull.Value)
                        pd.PermAddress = Convert.ToString(dr["perm_address"]);
                    if (dr["perm_city"] != DBNull.Value)
                        pd.PermCity = Convert.ToInt32(dr["perm_city"]);
                    if (dr["local_city"] != DBNull.Value)
                        pd.LocalCity = Convert.ToInt32(dr["local_city"]);
                    if (dr["marital_status"] != DBNull.Value)
                        pd.MaritalStatus = Convert.ToInt32(dr["marital_status"]);
                    if (dr["ntn"] != DBNull.Value)
                        pd.Ntn = Convert.ToString(dr["ntn"]);
                    if (dr["religions_id"] != DBNull.Value)
                        pd.Religion = Convert.ToInt32(dr["religions_id"]);
                    if (dr["perm_province"] != DBNull.Value)
                        pd.PermProvince = Convert.ToInt32(dr["perm_province"]);

                    return pd;
                }
            }
            finally
            {
                con.Close();
            }

        }
        public int InsertNewEmployee(BasicInfo newEmp)
        {
            int Id = new DalHelper().GetPk("SYSTEM_USERS", "SYSTEM_USERS_ID");
            newEmp.EmpId = Id;
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_EMPLOYEE";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = Id; 
            cmd.Parameters.Add("@FName", SqlDbType.VarChar).Value = newEmp.EmpName;
            cmd.Parameters.Add("@Gender", SqlDbType.Int).Value = newEmp.Gender;
            cmd.Parameters.Add("@IsEmployee", SqlDbType.Int).Value = 1;
           // cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
                return InsertEmpEmployment(newEmp);

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



        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="newEmp"></param>
        /// <param name="EmpId"></param>
        /// <returns></returns>
        public int InsertEmpEmployment(BasicInfo newEmp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_EMP_EMPLOYMENTS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = newEmp.EmpId;
            cmd.Parameters.Add("@FileNumber", SqlDbType.VarChar).Value = newEmp.FileNumber;
            cmd.Parameters.Add("@EmployeePoolId", SqlDbType.Int).Value = newEmp.MainHead;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
            return newEmp.EmpId;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////   
        public List<EmpSearchList> EmpList(string query)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                List<EmpSearchList> emp = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        emp = new List<EmpSearchList>();
                        while (dr.Read())
                        {
                            EmpSearchList ad = new EmpSearchList();
                            ad.EmpId = Convert.ToInt32(dr["system_users_id"]);
                            ad.EmpName = Convert.ToString(dr["f_name"] + " " + dr["m_name"] + " " + dr["l_name"]);
                            ad.EmpAddress = Convert.ToString(dr["perm_address"]);
                            ad.EmpDesignation = Convert.ToString(dr["post"]);
                            ad.Bps = Convert.ToString(dr["bps"]);
                            ad.Empstatus = Convert.ToString(dr["empl_status"]);
                            ad.PreviousLeaveCredit= Convert.ToInt32(dr["PREVIOUS_LEAVE_CREDIT"]);
                            if (dr["GOVT_SERVICE_START_DATE"] != DBNull.Value)
                                ad.GovtServiceStartDate = Convert.ToDateTime(dr["GOVT_SERVICE_START_DATE"]);
                            if (dr["House_Service_Start_Date"] != DBNull.Value)
                                ad.HouseServiceStartDate = Convert.ToDateTime(dr["House_Service_Start_Date"]);
                            ad.Filenumber = Convert.ToString(dr["file_no"]);
                            if (dr["Personal_No"] != DBNull.Value || !String.IsNullOrEmpty(dr["Personal_No"].ToString()))
                                ad.PersonalNumber = Convert.ToDouble(dr["Personal_No"]);
                            ad.Age = Convert.ToString(dr["age"]);
                            ad.LocalAddress = Convert.ToString(dr["Local_address"]);
                            ad.EmailAddress = Convert.ToString(dr["Email"]);
                            if (dr["EnteredBy"] != DBNull.Value)
                                ad.EnteredBy = Convert.ToString(dr["EnteredBy"]);
                            if (dr["EnteredOn"] != DBNull.Value)
                                ad.EnteredOn = Convert.ToDateTime(dr["EnteredOn"]);
                            if (dr["RecheckedBy"] != DBNull.Value)
                                ad.RecheckedBy = Convert.ToString(dr["RecheckedBy"]);
                            ad.ImageUrl = Convert.ToString(dr["ImageUrl"]);
                            emp.Add(ad);
                        }
                    }

                    if (emp != null) emp.TrimExcess();
                    return emp;
                }
            }
            finally
            {
                con.Close();
            }
        }
        

        public List<EmpSearchList> ForceSearchEmployee(string query)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                List<EmpSearchList> emp = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        emp = new List<EmpSearchList>();
                        while (dr.Read())
                        {
                            EmpSearchList ad = new EmpSearchList();
                            ad.EmpId = Convert.ToInt32(dr["system_users_id"]);
                            ad.EmpName = Convert.ToString(dr["f_name"] + " " + dr["m_name"] + " " + dr["l_name"]);
                            ad.EmpAddress = Convert.ToString(dr["perm_address"]);
                            //ad.EmpDesignation = Convert.ToString(dr["post"]);
                            //ad.Bps = Convert.ToString(dr["bps"]);
                            //ad.Empstatus = Convert.ToString(dr["empl_status"]);
                            //ad.PreviousLeaveCredit = Convert.ToInt32(dr["PREVIOUS_LEAVE_CREDIT"]);
                            if (dr["GOVT_SERVICE_START_DATE"] != DBNull.Value)
                                ad.GovtServiceStartDate = Convert.ToDateTime(dr["GOVT_SERVICE_START_DATE"]);
                            if (dr["House_Service_Start_Date"] != DBNull.Value)
                                ad.HouseServiceStartDate = Convert.ToDateTime(dr["House_Service_Start_Date"]);
                            // ad.Filenumber = Convert.ToString(dr["file_no"]);
                            //if (dr["Personal_No"] != DBNull.Value)
                            //   ad.PersonalNumber = Convert.ToDouble(dr["Personal_No"]);
                            ad.Age = Convert.ToString(dr["age"]);
                            ad.LocalAddress = Convert.ToString(dr["Local_address"]);
                            //ad.EmailAddress = Convert.ToString(dr["Email"]);
                            //if (dr["EnteredBy"] != DBNull.Value)
                            //    ad.EnteredBy = Convert.ToString(dr["EnteredBy"]);
                            //if (dr["EnteredOn"] != DBNull.Value)
                            //    ad.EnteredOn = Convert.ToDateTime(dr["EnteredOn"]);
                            //if (dr["RecheckedBy"] != DBNull.Value)
                            //    ad.RecheckedBy = Convert.ToString(dr["RecheckedBy"]);
                            emp.Add(ad);
                        }
                    }

                    if (emp != null) emp.TrimExcess();
                    return emp;
                }
            }
            finally
            {
                con.Close();
            }
        }

        //Save Employee Personal Info
        public void SavePersonalInfo(PersonalDetail pd)
        {
            string query = "Update system_users ";
            query += "set previous_name='"+ pd.PreviousName +"', f_name='" + pd.FName + "',m_name='',l_name=''";
            if (pd.NameChangeDate > Convert.ToDateTime("1/1/1900"))
                query += ",name_change_date=CONVERT(Date,'" + pd.NameChangeDate + "',105)";
            else
                query += ",name_change_date=NULL";
            if (!String.IsNullOrEmpty(pd.Title))
                query += ",title='" + pd.Title + "'";
            query += ",father_husband_name='" + pd.FatherNanme + "'";
            if (!String.IsNullOrEmpty(pd.EMail))
                query += ",email='" + pd.EMail + "'";
            query += ",nic_number='" + pd.Cnic + "'";
            //query += "nic_date=CONVERT(Date,'" +  pd.CnicDate + "','MM/DD/YYYY'),";
            query += ",nic_date=CONVERT(Date,'" + pd.CnicDate + "',105)";
            if(pd.cnicExpDate>Convert.ToDateTime("1/1/1900"))
            query += ",nic_exp_date=CONVERT(Date,'" + pd.cnicExpDate + "',105)";
            if (!String.IsNullOrEmpty(pd.OldCnic))
                query += ",old_nic_no='" + pd.OldCnic + "'";
            query += ",place_of_birth=" + pd.BirthPlace;
            //query += "dob=CONVERT(Date,'" +  pd.Dob + "','MM/DD/YYYY'),";
            query += ",dob=CONVERT(Date,'" + pd.Dob + "',105)";
            // query += "domicile_district=" + pd.DomDistrict + ",";
            query += ",gender=" + pd.Gender;
            query += ",is_active=" + pd.IsActive;
            if (pd.IssuePlace != 0)
                query += ",nic_place=" + pd.IssuePlace;

            if (!String.IsNullOrEmpty(pd.LocalAddress))
                query += ",local_address='" + pd.LocalAddress + "'";
            if (!String.IsNullOrEmpty(pd.PermAddress))
                query += ",perm_address='" + pd.PermAddress + "'";
            if (pd.LocalCity != 0)
                query += ",local_city=" + pd.LocalCity;
            if (pd.PermCity != 0)
                query += ",perm_city=" + pd.PermCity;
            if (pd.MaritalStatus != 0)
                query += ",marital_status=" + pd.MaritalStatus;
            if (!String.IsNullOrEmpty(pd.Ntn))
                query += ",ntn='" + pd.Ntn + "'";
            if (pd.Religion != 0)
                query += ",religions_id=" + pd.Religion;
            if (pd.PermProvince != 0)
                query += ",perm_province=" + pd.PermProvince;
            else
                query += ",perm_province=" + 0;
            if (pd.DomDistrict != 0)
                query += ",domicile_district=" + pd.DomDistrict;
            query += ",Is_Employee=1";
            query += " where system_users_id=" + pd.Userid;
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                UpdateSupperannuationDate(pd.Userid, pd.Dob);
            }
            finally
            {
                con.Close();
            }


        }
        public void UpdateSupperannuationDate(int Userid, DateTime Dob)
        {

        }
        /// <summary>
        /// ///////////////////////////////////////////  EMPLOYEE PHONE ////////////////////////////////////////////////////
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public List<EmployeePhones> GetEmployeePhones(int empId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_USER_PHONES";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = empId;
                cmd.Connection = con;
                List<EmployeePhones> phones = null;

                using (con)
                {

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        phones = new List<EmployeePhones>();
                        while (dr.Read())
                        {
                            EmployeePhones cy = new EmployeePhones();
                            cy.EmpId = Convert.ToInt32(dr["system_users_id"]);
                            cy.PhoneType = Convert.ToString(dr["description"]);
                            cy.EmpPhoneId = Convert.ToInt32(dr["user_phones_id"]);
                            cy.PhoneTypeId = Convert.ToInt32(dr["Phone_Type"]);
                            cy.PhoneNumber = Convert.ToString(dr["Phone_Number"]);
                            phones.Add(cy);
                        }
                    }
                }
                if (phones != null) phones.TrimExcess();
                return phones;
            }
            finally
            {
                con.Close();
            }

        }
        public int DeleteEmployee(int EmpId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_EMPLOYEE";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
                return 1;

            }
            catch 
            {
                return 0; 
            }
            finally
            {                
                con.Close();
                
            }
            


        }
        public void SaveEmployeePhones(EmployeePhones ef)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_USER_PHONE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = ef.PhoneNumber;
                cmd.Parameters.Add("@PhoneTypeId", SqlDbType.Int).Value = ef.PhoneTypeId;
                cmd.Parameters.Add("@User_Phone_Id", SqlDbType.Int).Value = ef.EmpPhoneId;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }


        }
        public void DeleteEmployeePhones(int ef)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_USER_PHONE";
                cmd.Parameters.Add("@User_Phone_Id", SqlDbType.Int).Value = ef;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }
        }
        public void InsertEmployeePhones(EmployeePhones ef)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_USER_PHONES";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = ef.EmpId;
                cmd.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = ef.PhoneNumber;
                cmd.Parameters.Add("@PhoneTypeId", SqlDbType.Int).Value = ef.PhoneTypeId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }

        }
        public void DelInactivePhones()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DEL_INACTIVE_PHONES";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
            }
            finally
            {
                con.Close();
            }

        }
        /// <summary>
        /// ////////////////////////////////////////////   EMPLOYEE PASSPORT    //////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="ef"></param>

        public List<EmpPassports> GetPassports(int EmpId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_USER_PASSPORT";
                cmd.Parameters.Add("@USER_ID", SqlDbType.VarChar).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<EmpPassports> EmpPass = null;
                using (con)
                {

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        EmpPass = new List<EmpPassports>();
                        while (dr.Read())
                        {
                            EmpPassports Ep = new EmpPassports();
                            Ep.EmpId = Convert.ToInt32(dr["system_users_id"]);
                            Ep.EmpPassportId = Convert.ToInt32(dr["user_passports_id"]);
                            if (dr["Passport_Number"] != DBNull.Value)
                                Ep.PassportNumber = Convert.ToString(dr["Passport_Number"]);
                            if (dr["Passport_Date"] != DBNull.Value)
                                Ep.IssueDate = Convert.ToDateTime(dr["Passport_Date"]);
                            if (dr["Passport_exp_Date"] != DBNull.Value)
                                Ep.ValidUpto = Convert.ToDateTime(dr["Passport_exp_Date"]);
                            if (dr["Passport_Types_Id"] != DBNull.Value)
                                Ep.PassportTypeId = Convert.ToInt32(dr["Passport_Types_Id"]);
                            if (dr["Description"] != DBNull.Value)
                                Ep.PassportType = Convert.ToString(dr["Description"]);
                            if (dr["Countries_id"] != DBNull.Value)
                                Ep.CountryId = Convert.ToInt32(dr["Countries_id"]);
                           
                            EmpPass.Add(Ep);
                        }
                    }
                    con.Close();
                }
                if (EmpPass != null) EmpPass.TrimExcess();
                return EmpPass;
            }
            finally
            {
                con.Close();
            }


        }


        public void DeleteEmployeePassport(int ef)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_USER_PASSORT";
                cmd.Parameters.Add("@user_passports_id", SqlDbType.VarChar).Value = ef;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }

        }

        public void InsertEmployeePassport(EmpPassports ef)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_USER_PASSPORT";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = ef.EmpId;
                cmd.Parameters.Add("@PassportNumber", SqlDbType.VarChar).Value = ef.PassportNumber;
                cmd.Parameters.Add("@IssueDate", SqlDbType.Date).Value = ef.IssueDate;
                cmd.Parameters.Add("@ValidUpto", SqlDbType.Date).Value = ef.ValidUpto;
                cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = ef.CountryId;
                cmd.Parameters.Add("@PassportTypeId", SqlDbType.Int).Value = ef.PassportTypeId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }

        }
        public void SaveEmployeePassport(EmpPassports ef)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_USER_PASSPORT";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.VarChar).Value = ef.EmpId;
                cmd.Parameters.Add("@PassportNumber", SqlDbType.VarChar).Value = ef.PassportNumber;
                cmd.Parameters.Add("@IssueDate", SqlDbType.Date).Value = ef.IssueDate;
                cmd.Parameters.Add("@ValidUpto", SqlDbType.Date).Value = ef.ValidUpto;
                cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = ef.CountryId;
                cmd.Parameters.Add("@PassportTypeId", SqlDbType.Int).Value = ef.PassportTypeId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }

        }
        //=======================================================================================================================================

        public EmpEmployment GetEmpEmployment(int EmpId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_EMPOYMENTS";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                EmpEmployment EEmp = new EmpEmployment();
                using (con)
                {
                    PersonalDetail pd = new PersonalDetail();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    EEmp.EmpEmplid = Convert.ToInt32(dr["emp_employments_id"]);
                    EEmp.EmpId = Convert.ToInt32(dr["system_users_id"]);
                    if (dr["post_held"] != DBNull.Value)
                        EEmp.Postheld = Convert.ToInt32(dr["post_held"]);
                    if (dr["branch"] != DBNull.Value)
                        EEmp.Branch = Convert.ToInt32(dr["branch"]);
                    if (dr["post_status"] != DBNull.Value)
                        EEmp.PostStatus = Convert.ToInt32(dr["post_status"]);
                    if (dr["probation_from"] != DBNull.Value)
                        EEmp.ProbFrom = Convert.ToDateTime(dr["probation_from"]);
                    if (dr["probation_to"] != DBNull.Value)
                        EEmp.ProbTo = Convert.ToDateTime(dr["probation_to"]);
                    if (dr["is_probation_extended"] != DBNull.Value)
                        EEmp.IsProbExt = Convert.ToInt32(dr["is_probation_extended"]);
                    if (dr["prob_Extended_to"] != DBNull.Value)
                        EEmp.ProbExtTo = Convert.ToDateTime(dr["prob_extended_to"]);
                    if (dr["prob_ext_reason"] != DBNull.Value)
                        EEmp.ProbExtReason = Convert.ToString(dr["prob_ext_reason"]);
                    if (dr["employee_pools_id"] != DBNull.Value)
                        EEmp.EmpPoolId = Convert.ToInt32(dr["employee_pools_id"]);
                    if (dr["EMPL_QUOTA_ID"] != DBNull.Value)
                        EEmp.QuotaId = Convert.ToInt32(dr["EMPL_QUOTA_ID"]);
                    if (dr["APPOINTMENT_MODE_ID"] != DBNull.Value)
                        EEmp.AppointmentModeId = Convert.ToInt32(dr["APPOINTMENT_MODE_ID"]);
                    if (dr["govt_service_start_date"] != DBNull.Value)
                        EEmp.GovtServStDate = Convert.ToDateTime(dr["govt_service_start_date"]);
                    if (dr["house_service_start_date"] != DBNull.Value)
                        EEmp.SenServStDate = Convert.ToDateTime(dr["house_service_start_date"]);
                    if (dr["previous_department"] != DBNull.Value)
                        EEmp.PrevDept = Convert.ToInt32(dr["previous_department"]);
                    if (dr["previous_post"] != DBNull.Value)
                        EEmp.PrevPost = Convert.ToInt32(dr["previous_post"]);
                    if (dr["PREVIOUS_LEAVE_CREDIT"] != DBNull.Value)
                        EEmp.PreviousLeaveCredit = Convert.ToInt32(dr["PREVIOUS_LEAVE_CREDIT"]);
                    if (dr["is_gazetted"] != DBNull.Value)
                        EEmp.Is_gazetted = Convert.ToInt32(dr["is_gazetted"]);
                    if (dr["non_gazetted_from"] != DBNull.Value)
                        EEmp.NonGazFrom = Convert.ToDateTime(dr["non_gazetted_from"]);
                    if (dr["non_gazetted_to"] != DBNull.Value)
                        EEmp.NonGazTo = Convert.ToDateTime(dr["non_gazetted_to"]);
                    if (dr["gazetted_from"] != DBNull.Value)
                        EEmp.GazFrom = Convert.ToDateTime(dr["gazetted_from"]);
                    if (dr["gazetted_to"] != DBNull.Value)
                        EEmp.GazTo = Convert.ToDateTime(dr["gazetted_to"]);
                    if (dr["superannuation_date"] != DBNull.Value)
                        EEmp.SuperDate = Convert.ToDateTime(dr["superannuation_date"]);
                    if (dr["basic_pay_scales_id"] != DBNull.Value)
                        EEmp.BpsId = Convert.ToInt32(dr["basic_pay_scales_id"]);
                    if (dr["employee_pools_id"] != DBNull.Value)
                        EEmp.EmpPoolId = Convert.ToInt32(dr["employee_pools_id"]);
                    if (dr["accommodation_date"] != DBNull.Value)
                        EEmp.AccommodDate = Convert.ToDateTime(dr["accommodation_date"]);
                    if (dr["emp_accommodation_types_id"] != DBNull.Value)
                        EEmp.AccommodTypeId = Convert.ToInt32(dr["emp_accommodation_types_id"]);
                    if (dr["remarks"] != DBNull.Value)
                        EEmp.Remarks = Convert.ToString(dr["remarks"]);
                    if (dr["file_no"] != DBNull.Value)
                        EEmp.File_no = Convert.ToString(dr["file_no"]);
                    if (dr["Personal_No"] != DBNull.Value)
                    EEmp.PersonalNo=Convert.ToString(dr["Personal_No"]);
                    if (dr["other_information"] != DBNull.Value)
                        EEmp.OtherInfo = Convert.ToString(dr["other_information"]);
                    if (dr["emp_status_id"] != DBNull.Value)
                        EEmp.EmpStatusId = Convert.ToInt32(dr["emp_status_id"]);
                    if (dr["re_empl_from"] != DBNull.Value)
                        EEmp.ReEmpFrom = Convert.ToDateTime(dr["re_empl_from"]);
                    if (dr["re_empl_to"] != DBNull.Value)
                        EEmp.ReEmpTo = Convert.ToDateTime(dr["re_empl_to"]);
                    if (dr["re_empl_period"] != DBNull.Value)
                        EEmp.ReEmpPeriod = Convert.ToString(dr["re_empl_period"]);
                    if (dr["seniority_num"] != DBNull.Value)
                        EEmp.SenNo = Convert.ToInt32(dr["seniority_num"]);

                    return EEmp;

                }
            }
            finally
            {
                con.Close();
            }


        }

        public void UpdateEmpEmployment(EmpEmployment El)
        {
            string query = "update Emp_Employments set ";
            query += "Personal_No='" + El.PersonalNo + "'";
            query += ",File_No='" + El.File_no + "'";
           
            if (El.AppointmentModeId != 0)
                query += ",Appointment_Mode_Id=" + El.AppointmentModeId;
            if (El.QuotaId != 0)
                query += ",empl_quota_id=" + El.QuotaId;
            if (El.SenNo != 0)
            query += ",SENIORITY_NUM = " + El.SenNo;
          //  if (El.PreviousLeaveCredit != 0)
                query += ",PREVIOUS_LEAVE_CREDIT = " + El.PreviousLeaveCredit;
            if (El.EmpPoolId != 0)
                query += ",employee_pools_id=" + El.EmpPoolId;
            query += ",govt_service_start_date=CONVERT(Date,'" + El.GovtServStDate.ToString("dd/MM/yyyy") + "',105)";

            query += ",house_service_start_date=CONVERT(Date,'" + El.SenServStDate.ToString("dd/MM/yyyy") + "',105)";
            query += " where system_users_id=" + El.EmpId;
            //string query = "update Emp_Employments set Post_held=15 where system_users_id=428";
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
            }

            finally
            {
                con.Close();
            }

        }

        /// <summary>
        /// /////////////////////////////////////////// EMPLOYEE PROMOTION   ////////////////////////////////
        /// </summary>
        /// <param name="EmpId"></param>
        /// <returns></returns>

        ///////////////////////////////////////////// EMPLOYEE LEAVE///////////////////////////////////////
        
        public List<EmployeeLeave> GetLeaveInSameYear(int EmpId,DateTime StartDate,DateTime EndDate)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_LEAVE_IN_SAME_YEAR";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = StartDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = EndDate;
                cmd.CommandType = CommandType.StoredProcedure;
                List<EmployeeLeave> EmpLeaves = null;

                using (con)
                {

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        EmpLeaves = new List<EmployeeLeave>();
                        while (dr.Read())
                        {
                            EmployeeLeave Eh = new EmployeeLeave();
                            Eh.EmpId = Convert.ToInt32(dr["system_users_id"]);
                            Eh.EmpLeaveId = Convert.ToInt32(dr["Emp_Leave_Id"]);
                            Eh.LeaveTypeId = Convert.ToInt32(dr["Emp_Leave_Types_Id"]);
                            //Eh.LeaveType = Convert.ToString(dr["Emp_Leave_Type"]);
                            Eh.LeaveSubTypeId = Convert.ToInt32(dr["Emp_Leave_SubType_Id"]);
                           // Eh.LeaveSubType = Convert.ToString(dr["Emp_Leave_SubType"]);
                            Eh.ExPakistan = Convert.ToInt32(dr["Ex_Pakistan"]);
                            Eh.ExPakistan = Convert.ToInt32(dr["IS_EXTENSION"]);
                            Eh.StartDate = Convert.ToDateTime(dr["Start_Date"]);
                            Eh.EndDate = Convert.ToDateTime(dr["End_Date"]);
                            if (dr["NO_OF_DAYS"] != DBNull.Value)
                                Eh.NumberOfDays = Convert.ToInt32(dr["NO_OF_DAYS"]);
                            else
                                Eh.NumberOfDays = new DateTimeUtils().CalculateNumberofDays(Eh.StartDate, Eh.EndDate);
                            Eh.ExpectedJoiningDate = new DateTimeUtils().GetJoiningDate(Eh.EndDate,Eh.NumberOfDays,Eh.LeaveTypeId);
                            if (dr["JOINING_DATE"] != DBNull.Value)
                                Eh.JoiningDate = Convert.ToDateTime(dr["JOINING_DATE"]);
                            Eh.Remarks = Convert.ToString(dr["Remarks"]);

                            EmpLeaves.Add(Eh);
                        }
                    }
                }
                if (EmpLeaves != null) EmpLeaves.TrimExcess();
                return EmpLeaves;
            }
            finally
            {
                con.Close();
            }
        }
        public List<EmployeeLeave>  GetLeavesStatusBetweenDates(int EmpId, DateTime StartDate, DateTime EndDate)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "CHECK_LFP_BETWEEN_DATES";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = StartDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = EndDate;
                cmd.CommandType = CommandType.StoredProcedure;
                List<EmployeeLeave> EmpLeaves = null;

                using (con)
                {

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        EmpLeaves = new List<EmployeeLeave>();
                        while (dr.Read())
                        {
                            EmployeeLeave Eh = new EmployeeLeave();
                            Eh.EmpId = Convert.ToInt32(dr["system_users_id"]);
                            Eh.EmpLeaveId = Convert.ToInt32(dr["Emp_Leave_Id"]);
                            Eh.LeaveTypeId = Convert.ToInt32(dr["Emp_Leave_Types_Id"]);
                            //Eh.LeaveType = Convert.ToString(dr["Emp_Leave_Type"]);
                            Eh.LeaveSubTypeId = Convert.ToInt32(dr["Emp_Leave_SubType_Id"]);
                            // Eh.LeaveSubType = Convert.ToString(dr["Emp_Leave_SubType"]);
                            Eh.ExPakistan = Convert.ToInt32(dr["Ex_Pakistan"]);
                            Eh.ExPakistan = Convert.ToInt32(dr["IS_EXTENSION"]);
                            Eh.StartDate = Convert.ToDateTime(dr["Start_Date"]);
                            Eh.EndDate = Convert.ToDateTime(dr["End_Date"]);
                          //  if (Eh.LeaveTypeId == 7)
                           //     Eh.EndDate = Eh.EndDate.AddDays(-5);
;                            if (dr["NO_OF_DAYS"] != DBNull.Value)
                                Eh.NumberOfDays = Convert.ToInt32(dr["NO_OF_DAYS"]);
                            else
                                Eh.NumberOfDays = new DateTimeUtils().CalculateNumberofDays(Eh.StartDate, Eh.EndDate);
                            Eh.ExpectedJoiningDate = new DateTimeUtils().GetJoiningDate(Eh.EndDate, Eh.NumberOfDays, Eh.LeaveTypeId);
                            if (dr["JOINING_DATE"] != DBNull.Value)
                                Eh.JoiningDate = Convert.ToDateTime(dr["JOINING_DATE"]);
                            Eh.Remarks = Convert.ToString(dr["Remarks"]);

                            EmpLeaves.Add(Eh);
                        }
                    }
                }
                if (EmpLeaves != null) EmpLeaves.TrimExcess();
                return EmpLeaves;
            }
            finally
            {
                con.Close();
            }

        }
        public List<EmployeeLeave> GetAllLeaves(int EmpId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ALL_LEAVES";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<EmployeeLeave> EmpLeaves = null;

                using (con)
                {

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        EmpLeaves = new List<EmployeeLeave>();
                        while (dr.Read())
                        {
                            EmployeeLeave Eh = new EmployeeLeave();
                            Eh.EmpId = Convert.ToInt32(dr["system_users_id"]);
                            Eh.EmpLeaveId = Convert.ToInt32(dr["Emp_Leave_Id"]);
                            Eh.LeaveTypeId = Convert.ToInt32(dr["Emp_Leave_Types_Id"]);
                            //Eh.LeaveType = Convert.ToString(dr["Emp_Leave_Type"]);
                            Eh.LeaveSubTypeId = Convert.ToInt32(dr["Emp_Leave_SubType_Id"]);
                            // Eh.LeaveSubType = Convert.ToString(dr["Emp_Leave_SubType"]);
                            Eh.ExPakistan = Convert.ToInt32(dr["Ex_Pakistan"]);
                            Eh.ExPakistan = Convert.ToInt32(dr["IS_EXTENSION"]);
                            Eh.StartDate = Convert.ToDateTime(dr["Start_Date"]);
                            Eh.EndDate = Convert.ToDateTime(dr["End_Date"]);
                            if (dr["NO_OF_DAYS"] != DBNull.Value)
                                Eh.NumberOfDays = Convert.ToInt32(dr["NO_OF_DAYS"]);
                            else
                                Eh.NumberOfDays = new DateTimeUtils().CalculateNumberofDays(Eh.StartDate, Eh.EndDate);
                            Eh.ExpectedJoiningDate = new DateTimeUtils().GetJoiningDate(Eh.EndDate,Eh.NumberOfDays,Eh.LeaveTypeId);
                            if (dr["JOINING_DATE"] != DBNull.Value)
                                Eh.JoiningDate = Convert.ToDateTime(dr["JOINING_DATE"]);
                            Eh.Remarks = Convert.ToString(dr["Remarks"]);

                            EmpLeaves.Add(Eh);
                        }
                    }
                }
                if (EmpLeaves != null) EmpLeaves.TrimExcess();
                return EmpLeaves;
            }
            finally
            {
                con.Close();
            }
        }
        public List<EmployeeLeave> GetLeavesTillDate(int EmpId,DateTime EndDate)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ALL_LEAVES";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                cmd.CommandType = CommandType.StoredProcedure;
                List<EmployeeLeave> EmpLeaves = null;

                using (con)
                {

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        EmpLeaves = new List<EmployeeLeave>();
                        while (dr.Read())
                        {
                            EmployeeLeave Eh = new EmployeeLeave();
                            Eh.EmpId = Convert.ToInt32(dr["system_users_id"]);
                            Eh.EmpLeaveId = Convert.ToInt32(dr["Emp_Leave_Id"]);
                            Eh.LeaveTypeId = Convert.ToInt32(dr["Emp_Leave_Types_Id"]);
                            //Eh.LeaveType = Convert.ToString(dr["Emp_Leave_Type"]);
                            Eh.LeaveSubTypeId = Convert.ToInt32(dr["Emp_Leave_SubType_Id"]);
                            // Eh.LeaveSubType = Convert.ToString(dr["Emp_Leave_SubType"]);
                            Eh.ExPakistan = Convert.ToInt32(dr["Ex_Pakistan"]);
                            Eh.ExPakistan = Convert.ToInt32(dr["IS_EXTENSION"]);
                            Eh.StartDate = Convert.ToDateTime(dr["Start_Date"]);
                            Eh.EndDate = Convert.ToDateTime(dr["End_Date"]);
                            if (dr["NO_OF_DAYS"] != DBNull.Value)
                                Eh.NumberOfDays = Convert.ToInt32(dr["NO_OF_DAYS"]);
                            else
                                Eh.NumberOfDays = new DateTimeUtils().CalculateNumberofDays(Eh.StartDate, Eh.EndDate);
                            Eh.ExpectedJoiningDate = new DateTimeUtils().GetJoiningDate(Eh.EndDate, Eh.NumberOfDays, Eh.LeaveTypeId);
                            if (dr["JOINING_DATE"] != DBNull.Value)
                                Eh.JoiningDate = Convert.ToDateTime(dr["JOINING_DATE"]);
                            Eh.Remarks = Convert.ToString(dr["Remarks"]);

                            EmpLeaves.Add(Eh);
                        }
                    }
                }
                if (EmpLeaves != null) EmpLeaves.TrimExcess();
                return EmpLeaves;
            }
            finally
            {
                con.Close();
            }
        }
        public List<EmployeeLeave> GetLeavesBetweenDates(DateTime StartDate,DateTime EndDate,int EmpId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_LEAVES_BETWEEN_DATES";
                cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = StartDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = EndDate;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<EmployeeLeave> EmpLeaves = null;

                using (con)
                {

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        EmpLeaves = new List<EmployeeLeave>();
                        while (dr.Read())
                        {
                            EmployeeLeave Eh = new EmployeeLeave();
                            Eh.EmpId = Convert.ToInt32(dr["system_users_id"]);
                            Eh.EmpLeaveId = Convert.ToInt32(dr["Emp_Leave_Id"]);
                            Eh.LeaveTypeId = Convert.ToInt32(dr["Emp_Leave_Types_Id"]);
                            //Eh.LeaveType = Convert.ToString(dr["Emp_Leave_Type"]);
                            Eh.LeaveSubTypeId = Convert.ToInt32(dr["Emp_Leave_SubType_Id"]);
                            // Eh.LeaveSubType = Convert.ToString(dr["Emp_Leave_SubType"]);
                            Eh.ExPakistan = Convert.ToInt32(dr["Ex_Pakistan"]);
                            Eh.ExPakistan = Convert.ToInt32(dr["IS_EXTENSION"]);
                            Eh.StartDate = Convert.ToDateTime(dr["Start_Date"]);
                            Eh.EndDate = Convert.ToDateTime(dr["End_Date"]);
                            if (dr["NO_OF_DAYS"] != DBNull.Value)
                                Eh.NumberOfDays = Convert.ToInt32(dr["NO_OF_DAYS"]);
                            else
                                Eh.NumberOfDays = new DateTimeUtils().CalculateNumberofDays(Eh.StartDate, Eh.EndDate);
                            Eh.ExpectedJoiningDate = new DateTimeUtils().GetJoiningDate(Eh.EndDate, Eh.NumberOfDays, Eh.LeaveTypeId);
                            if (dr["JOINING_DATE"] != DBNull.Value)
                                Eh.JoiningDate = Convert.ToDateTime(dr["JOINING_DATE"]);
                            Eh.Remarks = Convert.ToString(dr["Remarks"]);

                            EmpLeaves.Add(Eh);
                        }
                    }
                }
                if (EmpLeaves != null) EmpLeaves.TrimExcess();
                return EmpLeaves;
            }
            finally
            {
                con.Close();
            }
        }
        public List<EmployeeLeave> GetLeaveInDifferentYear(int EmpId, DateTime StartDate, DateTime EndDate)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_LEAVE_IN_DIFF_YEAR";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = StartDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = EndDate;
                cmd.CommandType = CommandType.StoredProcedure;
                List<EmployeeLeave> EmpLeaves = null;

                using (con)
                {

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        EmpLeaves = new List<EmployeeLeave>();
                        while (dr.Read())
                        {
                            EmployeeLeave Eh = new EmployeeLeave();
                            Eh.EmpId = Convert.ToInt32(dr["system_users_id"]);
                            Eh.EmpLeaveId = Convert.ToInt32(dr["Emp_Leave_Id"]);
                            Eh.LeaveTypeId = Convert.ToInt32(dr["Emp_Leave_Types_Id"]);
                            //Eh.LeaveType = Convert.ToString(dr["Emp_Leave_Type"]);
                            Eh.LeaveSubTypeId = Convert.ToInt32(dr["Emp_Leave_SubType_Id"]);
                            // Eh.LeaveSubType = Convert.ToString(dr["Emp_Leave_SubType"]);
                            Eh.ExPakistan = Convert.ToInt32(dr["Ex_Pakistan"]);
                            Eh.ExPakistan = Convert.ToInt32(dr["IS_EXTENSION"]);
                            Eh.StartDate = Convert.ToDateTime(dr["Start_Date"]);
                            Eh.EndDate = Convert.ToDateTime(dr["End_Date"]);
                            if (dr["NO_OF_DAYS"] != DBNull.Value)
                                Eh.NumberOfDays = Convert.ToInt32(dr["NO_OF_DAYS"]);
                            else
                                Eh.NumberOfDays = new DateTimeUtils().CalculateNumberofDays(Eh.StartDate, Eh.EndDate);
                            Eh.ExpectedJoiningDate = new DateTimeUtils().GetJoiningDate(Eh.EndDate, Eh.NumberOfDays, Eh.LeaveTypeId);
                            if (dr["JOINING_DATE"] != DBNull.Value)
                                Eh.JoiningDate = Convert.ToDateTime(dr["JOINING_DATE"]);
                            Eh.Remarks = Convert.ToString(dr["Remarks"]);

                            EmpLeaves.Add(Eh);
                        }
                    }
                }
                if (EmpLeaves != null) EmpLeaves.TrimExcess();
                return EmpLeaves;
            }
            finally
            {
                con.Close();
            }
        }
        public List<EmployeeLeave> GetEmployeeLeaves(int EmpId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_LEAVES";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<EmployeeLeave> EmpLeaves = null;

                using (con)
                {

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        EmpLeaves = new List<EmployeeLeave>();
                        while (dr.Read())
                        {
                            EmployeeLeave Eh = new EmployeeLeave();
                            Eh.EmpId = Convert.ToInt32(dr["system_users_id"]);
                            Eh.EmpLeaveId = Convert.ToInt32(dr["Emp_Leave_Id"]);
                            Eh.LeaveTypeId = Convert.ToInt32(dr["Emp_Leave_Types_Id"]);
                            Eh.LeaveType = Convert.ToString(dr["Emp_Leave_Type"]);
                            Eh.LeaveSubTypeId= Convert.ToInt32(dr["Emp_Leave_SubType_Id"]);
                            Eh.LeaveSubType=Convert.ToString(dr["Emp_Leave_SubType"]);
                            Eh.ExPakistan = Convert.ToInt32(dr["Ex_Pakistan"]);
                            Eh.IsExtension = Convert.ToInt32(dr["IS_EXTENSION"]);
                            Eh.StartDate = Convert.ToDateTime(dr["Start_Date"]);
                            Eh.EndDate= Convert.ToDateTime(dr["End_Date"]);
                            if (dr["NO_OF_DAYS"]!=DBNull.Value)                                
                            Eh.NumberOfDays = Convert.ToInt32(dr["NO_OF_DAYS"]);
                            else
                                Eh.NumberOfDays=  new DateTimeUtils().CalculateNumberofDays(Eh.StartDate, Eh.EndDate);
                            Eh.ExpectedJoiningDate = new DateTimeUtils().GetJoiningDate(Eh.EndDate,Eh.NumberOfDays,Eh.LeaveTypeId);
                            if (dr["JOINING_DATE"] != DBNull.Value)
                                Eh.JoiningDate = Convert.ToDateTime(dr["JOINING_DATE"]);
                            Eh.Remarks= Convert.ToString(dr["Remarks"]);

                            EmpLeaves.Add(Eh);
                        }
                    }
                }
                if (EmpLeaves != null) EmpLeaves.TrimExcess();
                return EmpLeaves;
            }
            finally
            {
                con.Close();
            }
        }
        public List<T_LEAVES> GetLeavesFromT()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_LEAVES_FROM_T";
                cmd.CommandType = CommandType.StoredProcedure;
                List<T_LEAVES> emp = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        emp = new List<T_LEAVES>();
                        while (dr.Read())
                        {
                            T_LEAVES ad = new T_LEAVES();
                            ad.EmpId = Convert.ToInt32(dr["EmpId"]);                          
                            ad.NoOfLeaves = Convert.ToInt32(dr["LeaveDays"]);                           
                            emp.Add(ad);
                        }
                    }

                    if (emp != null) emp.TrimExcess();
                    return emp;
                }
            }
            finally
            {
                con.Close();
            }



        }

        /// <summary>
        /// /////                           LEAVE TYPES
        /// </summary>
        /// <returns></returns>
        /// 

      

        public void SaveEmpLeave(EmployeeLeave El)
        {
            if (El.NumberOfDays != 0)
                El.EndDate = new DateTimeUtils().GetEndDate(El.StartDate, El.NumberOfDays,El.LeaveTypeId);
            else
            {
                El.NumberOfDays = new DateTimeUtils().CalculateNumberofDays(El.StartDate, El.EndDate);
                El.EndDate = new DateTimeUtils().GetEndDate(El.StartDate, El.NumberOfDays, El.LeaveTypeId);
            }
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_EMP_LEAVE";
                cmd.Parameters.Add("@EmpLeaveId", SqlDbType.Int).Value = El.EmpLeaveId;
                cmd.Parameters.Add("@LeaveTypeId", SqlDbType.Int).Value = El.LeaveTypeId;
                cmd.Parameters.Add("@LeaveSubTypeId", SqlDbType.Int).Value = El.LeaveSubTypeId;
                cmd.Parameters.Add("@ExPakistan", SqlDbType.Int).Value = El.ExPakistan;
                cmd.Parameters.Add("@IsExtended", SqlDbType.Int).Value = El.IsExtension;
                cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = El.StartDate;
                cmd.Parameters.Add("@NoOfDays", SqlDbType.Int).Value = El.NumberOfDays;
                cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = El.EndDate;
                cmd.Parameters.Add("@JoiningDate", SqlDbType.Date).Value = El.JoiningDate;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = El.Remarks;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }
        }
        public void InsertEmployeeLeave(EmployeeLeave el)
        {
            if (el.NumberOfDays != 0)
                el.EndDate = new DateTimeUtils().GetEndDate(el.StartDate, el.NumberOfDays, el.LeaveTypeId);
            else
            {
                el.NumberOfDays = new DateTimeUtils().CalculateNumberofDays(el.StartDate, el.EndDate);
                el.EndDate = new DateTimeUtils().GetEndDate(el.StartDate, el.NumberOfDays, el.LeaveTypeId);
            }
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_EMP_LEAVE";
                cmd.Parameters.Add("@EmpLeaveId", SqlDbType.Int).Value = el.EmpLeaveId;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = el.EmpId;
                cmd.Parameters.Add("@LeaveTypeId", SqlDbType.Int).Value = el.LeaveTypeId;
                cmd.Parameters.Add("@LeaveSubTypeId", SqlDbType.Int).Value = el.LeaveSubTypeId;
                cmd.Parameters.Add("@ExPakistan", SqlDbType.Int).Value = el.ExPakistan;
                cmd.Parameters.Add("@IsExtended", SqlDbType.Int).Value = el.IsExtension;
                cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = el.StartDate;
                cmd.Parameters.Add("@NoOfDays", SqlDbType.Int).Value = el.NumberOfDays;
                cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = el.EndDate;
                cmd.Parameters.Add("@JoiningDate", SqlDbType.Date).Value = el.JoiningDate;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = el.Remarks;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }

        }
        public void DeleteEmployeeLeave(int el)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_EMP_LEAVE";
                cmd.Parameters.Add("@EmpLeaveId", SqlDbType.Int).Value = el;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }

        }

        /////////////////////////////////////////////// EMPLOYEE COURSES ////////////////////////////////
        public List<EmpCourses> GetEmployeeCourses(int EmpId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_COURSES";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;

                List<EmpCourses> EmpCourse = null;

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    EmpCourse = new List<EmpCourses>();
                    while (dr.Read())
                    {
                        EmpCourses Eh = new EmpCourses();
                        Eh.SystemUsersId = Convert.ToInt32(dr["system_users_id"]);
                        Eh.EmpCourseId = Convert.ToInt32(dr["Emp_Courses_Id"]);
                        if (dr["Course_Types_Id"] != DBNull.Value)
                            Eh.CourseTypeId = Convert.ToInt32(dr["Course_Types_Id"]);
                        Eh.CourseName = Convert.ToString(dr["Course_Name"]);
                        Eh.InstitutionName = Convert.ToString(dr["Institution"]);
                        if (dr["Countries_Id"] != DBNull.Value)
                            Eh.CountryId = Convert.ToInt32(dr["Countries_Id"]);
                        if (dr["Mandatory"] != DBNull.Value)
                            Eh.Mandatory = Convert.ToInt32(dr["Mandatory"]);

                        Eh.DegDipCert = Convert.ToString(dr["Degree_Diploma_cert"]);
                        if (dr["From_Date"] != DBNull.Value)
                            Eh.FromDate = Convert.ToDateTime(dr["From_Date"]);
                        if (dr["To_Date"] != DBNull.Value)
                            Eh.ToDate = Convert.ToDateTime(dr["To_Date"]);
                        Eh.SponsoredBy = Convert.ToString(dr["Sponsored_By"]);
                        Eh.Remarks = Convert.ToString(dr["Remarks"]);



                        EmpCourse.Add(Eh);
                    }
                }

                if (EmpCourse != null) EmpCourse.TrimExcess();
                return EmpCourse;
            }
            finally
            {
                con.Close();
            }
        }
        public void SaveEmpCourses(EmpCourses Ec)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_EMP_COURSE";
                cmd.Parameters.Add("@EmpCourseId", SqlDbType.Int).Value = Ec.EmpCourseId;
                cmd.Parameters.Add("@CourseName", SqlDbType.VarChar).Value = Ec.CourseName;
                cmd.Parameters.Add("@InstitutionName", SqlDbType.VarChar).Value = Ec.InstitutionName;
                cmd.Parameters.Add("@Mandatory", SqlDbType.Int).Value = Ec.Mandatory;

                cmd.Parameters.Add("@CourseTypeId", SqlDbType.Int).Value = Ec.CourseTypeId;
                cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = Ec.CountryId;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = Ec.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = Ec.ToDate;
                cmd.Parameters.Add("@SponsoredBy", SqlDbType.VarChar).Value = Ec.SponsoredBy;
                cmd.Parameters.Add("@DegDipCert", SqlDbType.VarChar).Value = Ec.DegDipCert;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Ec.Remarks;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }
        }
        public void InsertEmployeeCourse(EmpCourses Ec)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_EMP_COURSE";
                cmd.Parameters.Add("@EmpCourseId", SqlDbType.Int).Value = Ec.EmpCourseId;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = Ec.SystemUsersId;
                cmd.Parameters.Add("@CourseName", SqlDbType.VarChar).Value = Ec.CourseName;
                cmd.Parameters.Add("@InstitutionName", SqlDbType.VarChar).Value = Ec.InstitutionName;
                cmd.Parameters.Add("@Mandatory", SqlDbType.Int).Value = Ec.Mandatory;
                cmd.Parameters.Add("@CourseTypeId", SqlDbType.Int).Value = Ec.CourseTypeId;
                cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = Ec.CountryId;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = Ec.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = Ec.ToDate;
                cmd.Parameters.Add("@SponsoredBy", SqlDbType.VarChar).Value = Ec.SponsoredBy;
                cmd.Parameters.Add("@DegDipCert", SqlDbType.VarChar).Value = Ec.DegDipCert;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Ec.Remarks;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }

        }
        public void DeleteEmployeeCourse(int ec)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_EMP_COURSE";
                cmd.Parameters.Add("@EmpCourseId", SqlDbType.Int).Value = ec;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }

        }
        /////////////////////////////////////////   EMPLOYEE EDUCATION     //////////////////////////////////////

        public List<EmpQualification> GetEmployeeQualifications(int EmpId)//GET_EMP_QUALIFICATIONS
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_QUALIFICATIONS";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<EmpQualification> empqualification = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    empqualification = new List<EmpQualification>();
                    while (dr.Read())
                    {
                        EmpQualification Eq = new EmpQualification();
                        Eq.System_Users_Id = Convert.ToInt32(dr["system_users_id"]);
                        Eq.Emp_Qualification_Id = Convert.ToInt32(dr["Emp_Qualification_Id"]);
                        Eq.Degree_Level_Id = Convert.ToInt32(dr["Degree_Level_Id"]);
                        Eq.Degree_Obtained = Convert.ToString(dr["Degree_Obtained"]);
                        Eq.Completion_Year = Convert.ToString(dr["Completion_Year"]);
                        Eq.Subjects = Convert.ToString(dr["Subjects"]);
                        if (dr["Grade"] != DBNull.Value)
                        {
                            Eq.Grade = Convert.ToString(dr["Grade"]);
                        }
                        if (dr["CGPA"] != DBNull.Value)
                        {
                            Eq.Cgpa = Convert.ToDouble(dr["CGPA"]);
                        }
                        if (dr["Percentage"] != DBNull.Value)
                        {
                            Eq.Percentage = Convert.ToDouble(dr["Percentage"]);
                        }
                        if (dr["Division"] != DBNull.Value)
                        {
                            Eq.Division = Convert.ToString(dr["Division"]);
                        }
                        Eq.Institution_Name = Convert.ToString(dr["Institution_Name"]);
                        Eq.Country_Id = Convert.ToInt32(dr["Country_Id"]);

                        empqualification.Add(Eq);
                    }
                }

                if (empqualification != null) empqualification.TrimExcess();
                return empqualification;
            }
            finally
            {
                con.Close();
            }
        }
        public void InsertEmployeeQualification(EmpQualification Eq)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_EMP_QUALIFICATION";

                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = Eq.System_Users_Id;
                cmd.Parameters.Add("@Degree_Level_Id", SqlDbType.Int).Value = Eq.Degree_Level_Id;
                cmd.Parameters.Add("@Degree_Obtained", SqlDbType.VarChar).Value = Eq.Degree_Obtained;
                cmd.Parameters.Add("@InstitutionName", SqlDbType.VarChar).Value = Eq.Institution_Name;
                cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = Eq.Country_Id;
                cmd.Parameters.Add("@Completion_Year", SqlDbType.VarChar).Value = Eq.Completion_Year;
                cmd.Parameters.Add("@Grade", SqlDbType.VarChar).Value = Eq.Grade;
                cmd.Parameters.Add("@Cgpa", SqlDbType.Float).Value = Eq.Cgpa;
                cmd.Parameters.Add("@Percentage", SqlDbType.Float).Value = Eq.Percentage;
                cmd.Parameters.Add("@Division", SqlDbType.VarChar).Value = Eq.Division;
                cmd.Parameters.Add("@Subjects", SqlDbType.VarChar).Value = Eq.Subjects;

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }

        }

        public void UpdateEmployeeQualification(EmpQualification Eq)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_EMP_QUALIFICATION";
                cmd.Parameters.Add("@EmpQualificationId", SqlDbType.Int).Value = Eq.Emp_Qualification_Id;
                cmd.Parameters.Add("@Degree_Level_Id", SqlDbType.Int).Value = Eq.Degree_Level_Id;
                cmd.Parameters.Add("@Degree_Obtained", SqlDbType.VarChar).Value = Eq.Degree_Obtained;
                cmd.Parameters.Add("@InstitutionName", SqlDbType.VarChar).Value = Eq.Institution_Name;
                cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = Eq.Country_Id;
                cmd.Parameters.Add("@Completion_Year", SqlDbType.VarChar).Value = Eq.Completion_Year;
                cmd.Parameters.Add("@Grade", SqlDbType.VarChar).Value = Eq.Grade;
                cmd.Parameters.Add("@Cgpa", SqlDbType.Float).Value = Eq.Cgpa;
                cmd.Parameters.Add("@Percentage", SqlDbType.Float).Value = Eq.Percentage;
                cmd.Parameters.Add("@Division", SqlDbType.VarChar).Value = Eq.Division;
                cmd.Parameters.Add("@Subjects", SqlDbType.VarChar).Value = Eq.Subjects;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }


        }
        public void DeleteEmployeeQualification(int ec)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_EMP_QUALIFICATION";
                cmd.Parameters.Add("@EmpQualificationId", SqlDbType.Int).Value = ec;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }

        }
        //*******************************************************************************************************

        public void InsertEmployeeHistory(EmploymentHistory eh)//INSERT_EMPLOYMENT_HISTORY
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_EMPLOYMENT_HISTORY";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = eh.EmpId;
                cmd.Parameters.Add("@EmpHistoryId", SqlDbType.Int).Value = eh.HistoryId;
                cmd.Parameters.Add("@DesigId", SqlDbType.Int).Value = eh.DesigId;
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = eh.BranchId;
                cmd.Parameters.Add("@Posting_From", SqlDbType.Date).Value = eh.StayFrom;
                cmd.Parameters.Add("@Posting_To", SqlDbType.Date).Value = eh.StayTo;
                cmd.Parameters.Add("@Rems", SqlDbType.VarChar).Value = eh.Rems;

                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }
        }
        public void InsertEmployeePromotion(PromotionHistory eh)
        {

            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_EMP_PROMOTION";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = eh.EmpId;
            cmd.Parameters.Add("@EmpPromotionId", SqlDbType.Int).Value = eh.EmpPromotionId;
            cmd.Parameters.Add("@TypeId", SqlDbType.Int).Value = eh.PromotionTypeId;
            cmd.Parameters.Add("@PromotionModeId", SqlDbType.Int).Value = eh.PromotionModeId;
            cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = eh.PostId;
            cmd.Parameters.Add("@Bps", SqlDbType.Int).Value = eh.Bps;
            cmd.Parameters.Add("@PromotionDate", SqlDbType.Date).Value = eh.PromotionDate;
            cmd.Parameters.Add("@IsCurrent", SqlDbType.Int).Value = eh.IsCurrent;
            cmd.Parameters.Add("@IsGazetted", SqlDbType.Int).Value = eh.IsGazetted;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = eh.Remarks;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteScalar();
                AuditLogger.LogCommand(cmd);
                string id = cmd.Parameters["@ID"].Value.ToString();
                eh.EmpPromotionId = Convert.ToInt32(id);
                if (eh.ProbationFrom != null)
                    InsertPromotionProbation(eh);
                if (eh.IsCurrent == 1)
                    new EmploymentDAL().UpdatePromEmployment(eh);


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
        public void InsertPromotionProbation(PromotionHistory prob)
        {

            SqlConnection con = new DalHelper().GetConnection();

            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_PROMOTION_PROBATION";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = prob.EmpId;
            cmd.Parameters.Add("@EmpPromotionId", SqlDbType.Int).Value = prob.EmpPromotionId;
            cmd.Parameters.Add("@Probation_From", SqlDbType.Date).Value = prob.ProbationFrom;
            cmd.Parameters.Add("@Probation_To", SqlDbType.Date).Value = prob.ProbationTo;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
           
            cmd.Connection = con;
            try
            {
                cmd.ExecuteScalar();
                AuditLogger.LogCommand(cmd);
                string id = cmd.Parameters["@ID"].Value.ToString();
                Probation temp = new Probation();
                temp.ProbationId= Convert.ToInt32(id);
                temp.SystemUserId = prob.EmpId;
                temp.ProbationFrom = Convert.ToDateTime(prob.ProbationFrom);
                temp.ProbationTo = Convert.ToDateTime(prob.ProbationTo); 
             //   UpdateMainProbation(temp);

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

        public List<PromotionHistory> GetPromotionHistory(int EmpId)//GET_EMP_PROMOTION_HISTORY
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_PROMOTION_HISTORY";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<PromotionHistory> PromHist = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    PromHist = new List<PromotionHistory>();
                    while (dr.Read())
                    {
                        PromotionHistory Eh = new PromotionHistory();
                        Eh.EmpId = EmpId;
                        Eh.EmpPromotionId = Convert.ToInt32(dr["Emp_Promotion_Hist_Id"]);

                        if (dr["Post"] != DBNull.Value)
                        {
                            Eh.PostId = Convert.ToInt32(dr["Post"]);
                            Eh.Post = Convert.ToString(dr["Post_Desc"]);
                        }

                        if (dr["Dated"] != DBNull.Value)
                            Eh.PromotionDate = Convert.ToDateTime(dr["Dated"]);
                        if (dr["Remarks"] != DBNull.Value)
                            Eh.Remarks = Convert.ToString(dr["Remarks"]);
                        if (dr["Basic_Pay_Scales_Id"] != DBNull.Value)
                        {
                            Eh.Bps = Convert.ToInt32(dr["Basic_Pay_Scales_Id"]);
                            Eh.BpsDesc = Convert.ToString(dr["BPS"]);
                        }
                        if (dr["PROMOTION_TYPE_ID"] != DBNull.Value)
                        {
                            Eh.PromotionTypeId = Convert.ToInt32(dr["PROMOTION_TYPE_ID"]);
                            Eh.PromotionType = Convert.ToString(dr["PROMOTION_TYPE"]);
                        }
                        if (dr["PROMOTION_MODES_ID"] != DBNull.Value)
                        {
                            Eh.PromotionModeId = Convert.ToInt32(dr["PROMOTION_MODES_ID"]);
                            Eh.PromotionMode = Convert.ToString(dr["PROMOTION_MODE"]);
                        }
                        if (dr["Is_Current"] != DBNull.Value)
                            Eh.IsCurrent = Convert.ToInt32(dr["Is_Current"]);
                        if (dr["Is_Gazetted"] != DBNull.Value)
                            Eh.IsGazetted = Convert.ToInt32(dr["Is_Gazetted"]);

                        PromHist.Add(Eh);
                    }
                }
                if (PromHist != null) PromHist.TrimExcess();
                return PromHist;
            }
            finally
            {
                con.Close();
            }
        }
        public Probation GetEmployeeProbationStatus(int EmpId)
        {
            Probation probation = null; ;
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PROBATION_STATUS";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    probation = new Probation();
                    dr.Read();
                   probation.ProbationId= Convert.ToInt32(dr["PROBATION_ID"]);
                   probation.ProbationTypeId= Convert.ToInt32(dr["PROBATION_TYPE_ID"]);
                   probation.SystemUserId= Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                   probation.ProbationFrom = Convert.ToDateTime(dr["PROBATION_FROM"]);
                   probation.ProbationTo = Convert.ToDateTime(dr["PROBATION_TO"]);
                   probation.Remarks= Convert.ToString(dr["REMARKS"]);

                }

                return probation;
            }
            finally
            {
                con.Close();

            }

        }
        public List<PromotionHistory> GetPromotionBasedOnBPS(int EmpId, int FromBPS, int ToBPS)//GET_EMP_PROMOTION_HISTORY
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PROMOTION_BASED_ON_BPS";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.Parameters.Add("@FromBPS", SqlDbType.Int).Value = FromBPS;
                cmd.Parameters.Add("@ToBPS", SqlDbType.Int).Value = ToBPS;
                cmd.CommandType = CommandType.StoredProcedure;
                List<PromotionHistory> PromHist = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    PromHist = new List<PromotionHistory>();
                    while (dr.Read())
                    {
                       PromotionHistory Eh = new PromotionHistory();
                       Eh = new PromotionHistory();
                        Eh.EmpId = EmpId;
                        Eh.EmpPromotionId = Convert.ToInt32(dr["Emp_Promotion_Hist_Id"]);

                        if (dr["Post"] != DBNull.Value)
                        {
                            Eh.PostId = Convert.ToInt32(dr["Post_Id"]);
                            Eh.Post= Convert.ToString(dr["Post"]);
                    }

                        if (dr["Dated"] != DBNull.Value)
                            Eh.PromotionDate = Convert.ToDateTime(dr["Dated"]);
                        if (dr["Remarks"] != DBNull.Value)
                            Eh.Remarks = Convert.ToString(dr["Remarks"]);
                        if (dr["Basic_Pay_Scales_Id"] != DBNull.Value)
                        {
                            Eh.Bps = Convert.ToInt32(dr["Basic_Pay_Scales_Id"]);
                            Eh.BpsDesc = Convert.ToString(dr["BPS"]);
                    }
                        if (dr["PROMOTION_TYPE_ID"] != DBNull.Value)
                        {
                            Eh.PromotionTypeId = Convert.ToInt32(dr["PROMOTION_TYPE_ID"]);
                        }
                        if (dr["PROMOTION_MODES_ID"] != DBNull.Value)
                        {
                            Eh.PromotionModeId = Convert.ToInt32(dr["PROMOTION_MODES_ID"]);
                          }
                        if (dr["Is_Current"] != DBNull.Value)
                            Eh.IsCurrent = Convert.ToInt32(dr["Is_Current"]);
                        if (dr["Is_Gazetted"] != DBNull.Value)
                            Eh.IsGazetted = Convert.ToInt32(dr["Is_Gazetted"]);

                        PromHist.Add(Eh);
                    }
                }
                if (PromHist != null) PromHist.TrimExcess();
                return PromHist;
            }

            finally
            {
                con.Close();
            }
        }
        public PromotionHistory GetCurrentPromotion(int EmpId)//GET_EMP_PROMOTION_HISTORY
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CURRENT_PROMOTION";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                PromotionHistory Eh = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Eh = new PromotionHistory();
                    Eh.EmpId = EmpId;
                    Eh.EmpPromotionId = Convert.ToInt32(dr["Emp_Promotion_Hist_Id"]);

                    if (dr["Post"] != DBNull.Value)
                    {
                        Eh.PostId = Convert.ToInt32(dr["Post"]);
                    }

                    if (dr["Dated"] != DBNull.Value)
                        Eh.PromotionDate = Convert.ToDateTime(dr["Dated"]);
                    if (dr["Remarks"] != DBNull.Value)
                        Eh.Remarks = Convert.ToString(dr["Remarks"]);
                    if (dr["Basic_Pay_Scales_Id"] != DBNull.Value)
                    {
                        Eh.Bps = Convert.ToInt32(dr["Basic_Pay_Scales_Id"]);
                    }
                    if (dr["PROMOTION_TYPE_ID"] != DBNull.Value)
                    {
                        Eh.PromotionTypeId = Convert.ToInt32(dr["PROMOTION_TYPE_ID"]);
                    }
                    if (dr["PROMOTION_MODES_ID"] != DBNull.Value)
                    {
                        Eh.PromotionModeId = Convert.ToInt32(dr["PROMOTION_MODES_ID"]);
                    }
                    if (dr["Is_Current"] != DBNull.Value)
                        Eh.IsCurrent = Convert.ToInt32(dr["Is_Current"]);
                    if (dr["Is_Gazetted"] != DBNull.Value)
                        Eh.IsGazetted = Convert.ToInt32(dr["Is_Gazetted"]);


                }

                return Eh;
            }
            finally
            {
                con.Close();
            }
        }
        public List<PromotionHistory> GetAppointmentBasedOnBPS(int EmpId,int FromBPS,int ToBPS)//GET_EMP_PROMOTION_HISTORY
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMPLOYMENT_BASED_ON_BPS";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.Parameters.Add("@FromBPS", SqlDbType.Int).Value = FromBPS;
                cmd.Parameters.Add("@ToBPS", SqlDbType.Int).Value = ToBPS;
                cmd.CommandType = CommandType.StoredProcedure;
                List<PromotionHistory> PromHist = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    PromHist = new List<PromotionHistory>();
                    while (dr.Read())
                    {
                    PromotionHistory Eh = new PromotionHistory();
                    Eh.EmpId = EmpId;
                 //   Eh.EmpPromotionId = Convert.ToInt32(dr["Emp_Promotion_Hist_Id"]);
                    if (dr["POST_ID"] != DBNull.Value)
                    {
                        Eh.PostId = Convert.ToInt32(dr["POST_ID"]);
                        Eh.Post = Convert.ToString(dr["POST"]);
                    }

                    if (dr["STATUS_DATE"] != DBNull.Value)
                        Eh.PromotionDate = Convert.ToDateTime(dr["STATUS_DATE"]);
                    //if (dr["Remarks"] != DBNull.Value)
                    //    Eh.Remarks = Convert.ToString(dr["Remarks"]);
                    if (dr["BPS_ID"] != DBNull.Value)
                    {
                        Eh.Bps = Convert.ToInt32(dr["BPS_ID"]);
                        Eh.BpsDesc= Convert.ToString(dr["POST"]);
                    }
                        //if (dr["PROMOTION_TYPE_ID"] != DBNull.Value)
                        //{
                        //    Eh.PromotionTypeId = Convert.ToInt32(dr["PROMOTION_TYPE_ID"]);
                        //}
                        //if (dr["PROMOTION_MODES_ID"] != DBNull.Value)
                        //{
                        //    Eh.PromotionModeId = Convert.ToInt32(dr["PROMOTION_MODES_ID"]);
                        //}
                        //if (dr["Is_Current"] != DBNull.Value)
                        //    Eh.IsCurrent = Convert.ToInt32(dr["Is_Current"]);
                        //if (dr["Is_Gazetted"] != DBNull.Value)
                        //    Eh.IsGazetted = Convert.ToInt32(dr["Is_Gazetted"]);

                        PromHist.Add(Eh);
                    }
                }
                if (PromHist != null) PromHist.TrimExcess();
                return PromHist;
            }
            finally
            {
                con.Close();
            }
        }
        public PromotionHistory GetCurrentEmployment(int EmpId)//GET_EMP_PROMOTION_HISTORY
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CURRENT_EMPLOYMENT";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                PromotionHistory Eh = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Eh = new PromotionHistory();
                    Eh.EmpId = EmpId;
                    //   Eh.EmpPromotionId = Convert.ToInt32(dr["Emp_Promotion_Hist_Id"]);
                    if (dr["POST_ID"] != DBNull.Value)
                    {
                        Eh.PostId = Convert.ToInt32(dr["POST_ID"]);
                    }

                    if (dr["STATUS_DATE"] != DBNull.Value)
                        Eh.PromotionDate = Convert.ToDateTime(dr["STATUS_DATE"]);
                    //if (dr["Remarks"] != DBNull.Value)
                    //    Eh.Remarks = Convert.ToString(dr["Remarks"]);
                    if (dr["BPS_ID"] != DBNull.Value)
                    {
                        Eh.Bps = Convert.ToInt32(dr["BPS_ID"]);
                    }
                    //if (dr["PROMOTION_TYPE_ID"] != DBNull.Value)
                    //{
                    //    Eh.PromotionTypeId = Convert.ToInt32(dr["PROMOTION_TYPE_ID"]);
                    //}
                    //if (dr["PROMOTION_MODES_ID"] != DBNull.Value)
                    //{
                    //    Eh.PromotionModeId = Convert.ToInt32(dr["PROMOTION_MODES_ID"]);
                    //}
                    //if (dr["Is_Current"] != DBNull.Value)
                    //    Eh.IsCurrent = Convert.ToInt32(dr["Is_Current"]);
                    //if (dr["Is_Gazetted"] != DBNull.Value)
                    //    Eh.IsGazetted = Convert.ToInt32(dr["Is_Gazetted"]);


                }

                return Eh;
            }
            finally
            {
                con.Close();
            }
        }
        public void DeletePromotionHistory(int EmpHistId)//DELETE_EMP_PROMOTION_HISTORY
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_EMP_PROMOTION_HISTORY";
                cmd.Parameters.Add("@Emp_Promotion_Hist_Id", SqlDbType.Int).Value = EmpHistId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }
        }
        public void DeleteOtherEmployment(int Id)//DELETE_EMP_PROMOTION_HISTORY
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_OTHER_EMPLOYMENT";
                cmd.Parameters.Add("@Idd", SqlDbType.Int).Value = Id;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateEmployeePromotion(PromotionHistory eh)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_EMP_PROMOTION_HISTORY";
                cmd.Parameters.Add("@EmpPromotionId", SqlDbType.Int).Value = eh.EmpPromotionId;
                cmd.Parameters.Add("@TypeId", SqlDbType.Int).Value = eh.PromotionTypeId;
                cmd.Parameters.Add("@PromotionModeId", SqlDbType.Int).Value = eh.PromotionModeId;
                cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = eh.PostId;
                cmd.Parameters.Add("@Bps", SqlDbType.Int).Value = eh.Bps;
                cmd.Parameters.Add("@PromotionDate", SqlDbType.Date).Value = eh.PromotionDate;
                cmd.Parameters.Add("@IsCurrent", SqlDbType.Int).Value = eh.IsCurrent;
                cmd.Parameters.Add("@IsGazetted", SqlDbType.Int).Value = eh.IsGazetted;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = eh.Remarks;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
                if (eh.IsCurrent == 1)
                    new EmploymentDAL().UpdatePromEmployment(eh);
            }
            finally
            {
                con.Close();
            }


        }

        public List<EmploymentHistory> GetEmploymentHist(int EmpId)//GET_EMP_EMPLOYMENT_HISTORY
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_EMPLOYMENT_HISTORY";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<EmploymentHistory> EmpHist = null;
                //using (con)
                //{

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    EmpHist = new List<EmploymentHistory>();
                    while (dr.Read())
                    {
                        EmploymentHistory Eh = new EmploymentHistory();
                        Eh.EmpId = Convert.ToInt32(dr["system_users_id"]);
                        Eh.HistoryId = Convert.ToInt32(dr["Emp_Employment_Hist_Id"]);
                        if (dr["Posting"] != DBNull.Value)
                        {
                            Eh.DesigId = Convert.ToInt32(dr["Posting"]);
                            Eh.Designation = Convert.ToString(dr["Post_Desc"]);
                        }
                        if (dr["Branch"] != DBNull.Value)
                        {
                            Eh.BranchId = Convert.ToInt32(dr["Branch"]);
                            Eh.Branch = Convert.ToString(dr["Branch_Desc"]);
                        }
                        if (dr["Posting_From"] != DBNull.Value)
                            Eh.StayFrom = Convert.ToDateTime(dr["Posting_From"]);

                        if (dr["Posting_To"] != DBNull.Value)
                            Eh.StayTo = Convert.ToDateTime(dr["Posting_To"]);
                        if (dr["Remarks"] != DBNull.Value)

                            Eh.Rems = Convert.ToString(dr["Remarks"]);
                        if (dr["Basic_Pay_Scales_ID"] != DBNull.Value)
                        {
                            Eh.BpsId = Convert.ToInt32(dr["Basic_Pay_Scales_ID"]);
                            Eh.Bps = Convert.ToString(dr["BPS"]);
                        }
                        //if (dr["Is_Promotion"] != DBNull.Value)
                        //    Eh.IsPromotion = Convert.ToInt32(dr["Is_Promotion"]);

                        //if (dr["Is_Gazetted"] != DBNull.Value)
                        //    Eh.IsGazetted = Convert.ToInt32(dr["is_Gazetted"]);
                        EmpHist.Add(Eh);
                    }
                    //}
                }
                if (EmpHist != null) EmpHist.TrimExcess();
                return EmpHist;
            }
            finally
            {
                con.Close();
            }

        }
        public void SaveEmployeeHistory(EmploymentHistory eh)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_EMP_EMPLOYMENT_HISTORY";
                cmd.Parameters.Add("@HistoryId", SqlDbType.Int).Value = eh.HistoryId;
                cmd.Parameters.Add("@DesigId", SqlDbType.Int).Value = eh.DesigId;
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = eh.BranchId;
                cmd.Parameters.Add("@Posting_From", SqlDbType.Date).Value = eh.StayFrom;
                cmd.Parameters.Add("@Posting_To", SqlDbType.Date).Value = eh.StayTo;
                cmd.Parameters.Add("@Rems", SqlDbType.VarChar).Value = eh.Rems;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }

        }

        public void DeleteEmployementHistory(int EmpHistId)//DELETE_EMP_EMPLOYMENT_HISTORY
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_EMP_EMPLOYMENT_HISTORY";
                cmd.Parameters.Add("@EmpHistoryId", SqlDbType.Int).Value = EmpHistId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }
        }



        //************************************IMAGE***********************************************

        public void SaveImage(string ImgUrl, int EmpId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "SAVE_IMAGE";
                cmd.Parameters.Add("@ImageUrl", SqlDbType.VarChar).Value = ImgUrl;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }

        }
        public string GetImage(int EmpId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "Get_IMAGE";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    return Convert.ToString(dr["ImageUrl"]);
                }
                return "missing.jpg";
            }
            finally
            {
                con.Close();
            }
        }
        public void DeleteEmployeeDependent(int el)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_EMP_DEPENDANT";
                cmd.Parameters.Add("@Emp_Dependant_Id", SqlDbType.Int).Value = el;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }

        }


        public List<EmployeeDependant> GetEmployeeDependants(int EmpId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_DEPENDANTS";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<EmployeeDependant> ps = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    ps = new List<EmployeeDependant>();
                    while (dr.Read())
                    {
                        EmployeeDependant ad = new EmployeeDependant();
                        ad.EmpDependantId = Convert.ToInt32(dr["Emp_Dependant_Id"]);
                        ad.DependantName = Convert.ToString(dr["DependantName"]);
                        ad.RelationshipId = Convert.ToInt32(dr["Relation_Id"]);
                        ad.RelationshipName = Convert.ToString(dr["RelationName"]);
                        ad.Gender = Convert.ToString(dr["Gender"]);
                        if(dr["DOB"]!=DBNull.Value)
                        ad.DOB = Convert.ToDateTime(dr["DOB"]);
                        Duration duration = new DateTimeUtils().GetDuration(ad.DOB, DateTime.Now);
                        ad.AgeYears = duration.Years;
                        ad.AgeMonths = duration.Months;
                        ad.IsDependant = Convert.ToInt32(dr["IsDependant"]);
                        ps.Add(ad);
                    }
                }
                if (ps != null) ps.TrimExcess();
                return ps;
            }
            finally
            {
                con.Close();
            }
        }
      
        public void InsertEmployeeDependants(EmployeeDependant Edep)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_EMP_DEPENDANTS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = Edep.SystemUersId;
                cmd.Parameters.Add("@DependantName", SqlDbType.VarChar).Value = Edep.DependantName;
                cmd.Parameters.Add("@RelationId", SqlDbType.Int).Value = Edep.RelationshipId;
                cmd.Parameters.Add("@DOB", SqlDbType.Date).Value = Edep.DOB;
                cmd.Parameters.Add("@AgeYears", SqlDbType.Int).Value = Edep.AgeYears;
                cmd.Parameters.Add("@AgeMonths", SqlDbType.Int).Value = Edep.AgeMonths;
                cmd.Parameters.Add("@IsDependant", SqlDbType.Int).Value = Edep.IsDependant;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                AuditLogger.LogCommand(cmd);
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
        public void UpdateEmployeeDependants(EmployeeDependant EDep)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_EMP_DEPENDANTS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Emp_Dependant_Id", SqlDbType.Int).Value = EDep.EmpDependantId;
            cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EDep.SystemUersId;
            cmd.Parameters.Add("@DependantName", SqlDbType.VarChar).Value = EDep.DependantName;
            cmd.Parameters.Add("@RelationId", SqlDbType.Int).Value = EDep.RelationshipId;
            cmd.Parameters.Add("@DOB", SqlDbType.Date).Value = EDep.DOB;
            cmd.Parameters.Add("@AgeYears", SqlDbType.Int).Value = EDep.AgeYears;
            cmd.Parameters.Add("@AgeMonths", SqlDbType.Int).Value = EDep.AgeMonths;
            cmd.Parameters.Add("@IsDependant", SqlDbType.Int).Value = EDep.IsDependant;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteNonQuery();
                AuditLogger.LogCommand(cmd);
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
        ////////////////////////////////////EMPLOYEE POSTINGS///////////////////////////////////////////
        public List<EmployeePosting> GetEmployeePostings(int EmpId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_POSTINGS";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<EmployeePosting> EmpPosting = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    EmpPosting = new List<EmployeePosting>();
                    while (dr.Read())
                    {
                        EmployeePosting Eh = new EmployeePosting();
                        Eh.System_Users_Id = Convert.ToInt32(dr["system_users_id"]);
                        Eh.Emp_Posting_id = Convert.ToInt32(dr["Emp_Posting_Id"]);
                        Eh.BPS = Convert.ToInt32(dr["BPS_Id"]);
                        Eh.BPSDesc = Convert.ToString(dr["BPSDesc"]);
                        Eh.PostId = Convert.ToInt32(dr["Post_Id"]);
                        Eh.Post = Convert.ToString(dr["PostDesc"]);

                        if (dr["Branch_Id"] != DBNull.Value)
                        {
                            Eh.BranchId = Convert.ToInt32(dr["Branch_Id"]);
                            Eh.Branch = Convert.ToString(dr["Branch"]);
                        }
                        if (dr["Additional_Branches"] != DBNull.Value)
                        {
                            string additionalbranches = Convert.ToString(dr["Additional_Branches"]);
                            Eh.Branch = Convert.ToString(dr["Branch"]);
                        }
                        if (dr["Date_From"] != DBNull.Value)
                            Eh.Date_From = Convert.ToDateTime(dr["Date_From"]);
                        if (dr["Date_To"] != DBNull.Value)
                            Eh.Date_To = Convert.ToDateTime(dr["Date_To"]);
                        if (dr["Working"] != DBNull.Value)
                            Eh.Working = Convert.ToInt32(dr["Working"]);
                        Eh.Remarks = Convert.ToString(dr["Remarks"]);
                        Eh.AdditionalBranches = GetAdditionalBranches(Eh.Emp_Posting_id);
                        if (Eh.AdditionalBranches != null)
                        {
                            foreach(AdditionalBranchesEnt eb in Eh.AdditionalBranches)
                            {
                                Eh.AddtionalBranchesNames = Eh.AddtionalBranchesNames + eb.AdditionalBranch + ",";
                            }
                        }
                        EmpPosting.Add(Eh);
                    }
                }
                if (EmpPosting != null) EmpPosting.TrimExcess();
                return EmpPosting;
            }
            finally
            {
                con.Close();
            }

        }

        public double GetWorkingStatus(int SystemUserId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_WORKING_STATUS";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = SystemUserId;
                cmd.CommandType = CommandType.StoredProcedure;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        return Convert.ToDouble(dr["Emp_Posting_Id"]);
                    }
                }
                return 0;
            }
            finally
            {
                con.Close();
            }
        }
        public double GetCurrentStatus(int SystemUserId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CURRENT_STATUS";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = SystemUserId;

                cmd.CommandType = CommandType.StoredProcedure;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        return Convert.ToDouble(dr["EMP_PROMOTION_HIST_ID"]);

                    }
                }
                return 0;
            }
            finally
            {
                con.Close();
            }

        }
        public void UpdateEmployeePosting(EmployeePosting EPosting)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_EMP_POSTING";
                cmd.Parameters.Add("@Emp_Posting_Id", SqlDbType.Int).Value = EPosting.Emp_Posting_id;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EPosting.System_Users_Id;
                cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = EPosting.PostId;
                cmd.Parameters.Add("@Bps", SqlDbType.Int).Value = EPosting.BPS;
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = EPosting.BranchId;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = EPosting.Date_From;
                if (Convert.ToString(EPosting.Date_To) != "01/01/0001 00:00:00")
                    cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = EPosting.Date_To;
                cmd.Parameters.Add("@CurrentStatusId", SqlDbType.Int).Value = EPosting.Working;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = EPosting.Remarks;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
                if (EPosting.Working == 1)
                    new EmploymentDAL().UpdatePostingEmployment(EPosting.System_Users_Id, EPosting.BranchId);
            }
            finally
            {
                con.Close();
            }
        }
        public int InsertEmployeePosting(EmployeePosting EPosting)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_EMP_POSTING";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EPosting.System_Users_Id;
                cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = EPosting.PostId;
                cmd.Parameters.Add("@Bps", SqlDbType.Int).Value = EPosting.BPS;
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = EPosting.BranchId;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = EPosting.Date_From;
                if (Convert.ToString(EPosting.Date_To) != "01/01/0001 00:00:00")
                    cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = EPosting.Date_To;
                cmd.Parameters.Add("@CurrentStatusId", SqlDbType.Int).Value = EPosting.Working;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = EPosting.Remarks;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteScalar();
                AuditLogger.LogCommand(cmd);
                int id = Convert.ToInt32(cmd.Parameters["@ID"].Value);
                if (EPosting.Working == 1)
                    new EmploymentDAL().UpdatePostingEmployment(EPosting.System_Users_Id, EPosting.BranchId);
                return id;
            }
            finally
            {
                con.Close();
            }

        }
        public void DeleteEmployeePosting(int PostingId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_EMP_POSTING";
                cmd.Parameters.Add("@Emp_Posting_Id", SqlDbType.Int).Value = PostingId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }

        }
        ////////////////////////////////////////////////////    PROBATION   ////////////////////////////////////////////////////////////////////////
        public int InsertProbation(Probation prob)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_PROBATION";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Probation_From", SqlDbType.Date).Value = prob.ProbationFrom;
                cmd.Parameters.Add("@Probation_To", SqlDbType.Date).Value = prob.ProbationTo;
                cmd.Parameters.Add("@Is_Extended", SqlDbType.Int).Value = prob.IsExtended;
                if (Convert.ToString(prob.ExtendedTo) != "01/01/0001 00:00:00")
                    cmd.Parameters.Add("@Extended_To", SqlDbType.DateTime).Value = prob.ExtendedTo;
                cmd.Parameters.Add("@Extension_Reason", SqlDbType.VarChar).Value = prob.Remarks;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection = con;
                cmd.ExecuteScalar();
                AuditLogger.LogCommand(cmd);
                UpdateMainProbation(prob);
                string id = cmd.Parameters["@ID"].Value.ToString();
                return Convert.ToInt32(id);

                //return InsertEmpEmployment(newEmp, Convert.ToInt32(id));
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
        public void UpdateMainProbation(Probation prob)
        {
            SqlConnection con = new DalHelper().GetConnection();
            DateTime CurrentProbationDate = GetProbationToDate(prob.SystemUserId);
           
            try
            {
                if (CurrentProbationDate < prob.ProbationFrom)
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MAIN_PROBATION";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Probation_From", SqlDbType.Date).Value = prob.ProbationFrom;
                    cmd.Parameters.Add("@Probation_To", SqlDbType.Date).Value = prob.ProbationTo;
                    cmd.Parameters.Add("@Is_Extended", SqlDbType.Int).Value = prob.IsExtended;
                    if (Convert.ToString(prob.ExtendedTo) != "01/01/0001 00:00:00")
                        cmd.Parameters.Add("@Extended_To", SqlDbType.Date).Value = prob.ExtendedTo;
                    cmd.Parameters.Add("@Extension_Reason", SqlDbType.VarChar).Value = prob.Remarks;
                    cmd.Connection = con;
                    SqlDataReader dr = cmd.ExecuteReader();
                    AuditLogger.LogCommand(cmd);
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
        public DateTime GetProbationToDate(int SystemUsersId)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PROBATION_TO_DATE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Date).Value = SystemUsersId;
                cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                if (dr["PROB_EXTENDED_TO"] == DBNull.Value)
                    return Convert.ToDateTime(dr["PROBATION_TO"]);
                else
                    return Convert.ToDateTime(dr["PROB_EXTENDED_TO"]);
               

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
        public void UpdateProbation(Probation prob)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_PROBATION";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Probation_Id", SqlDbType.Int).Value = prob.ProbationId;
                cmd.Parameters.Add("@Probation_From", SqlDbType.Date).Value = prob.ProbationFrom;
                cmd.Parameters.Add("@Probation_To", SqlDbType.Date).Value = prob.ProbationTo;
                cmd.Parameters.Add("@Is_Extended", SqlDbType.Int).Value = prob.IsExtended;
                if (Convert.ToString(prob.ExtendedTo) != "01/01/0001 00:00:00")
                    cmd.Parameters.Add("@Extended_To", SqlDbType.Date).Value = prob.ExtendedTo;
                cmd.Parameters.Add("@Extension_Reason", SqlDbType.VarChar).Value = prob.Remarks;
                cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
                UpdateMainProbation(prob);

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
        public Probation GetProbation(int ProbationId)
        {
            Probation Eh = new Probation();
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PROBATION";
                cmd.Parameters.Add("@Probation_Id", SqlDbType.Int).Value = ProbationId;
                cmd.CommandType = CommandType.StoredProcedure;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        if (dr["Probation_From"] != DBNull.Value)

                            Eh.ProbationFrom = Convert.ToDateTime(dr["Probation_From"]);
                        if (dr["Probation_To"] != DBNull.Value)

                            Eh.ProbationTo = Convert.ToDateTime(dr["Probation_To"]);

                    }


                }
                return Eh;
            }
            finally
            {
                con.Close();
            }

        }
        ////////////////////////////////////////////////////    VISITS   ////////////////////////////////////////////////////////////////////////
        public void InsertEmployeeVisits(EmployeeVisits EmpVisit)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_VISIT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpVisit.System_User_Id;
                cmd.Parameters.Add("@VisitTypeId", SqlDbType.Int).Value = EmpVisit.VisitTypeId;
                cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = EmpVisit.CountryId;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = EmpVisit.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = EmpVisit.ToDate;
                cmd.Parameters.Add("@NOCDate", SqlDbType.Date).Value = EmpVisit.NocDate;
                cmd.Parameters.Add("@Purpose", SqlDbType.VarChar).Value = EmpVisit.Purpose;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                AuditLogger.LogCommand(cmd);
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
        public void UpdateEmployeeVisits(EmployeeVisits EmpVisit)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_VISIT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserVisitId", SqlDbType.Int).Value = EmpVisit.ForeignVisitId;
                cmd.Parameters.Add("@VisitTypeId", SqlDbType.Int).Value = EmpVisit.VisitTypeId;
                cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = EmpVisit.CountryId;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = EmpVisit.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = EmpVisit.ToDate;
                cmd.Parameters.Add("@NOCDate", SqlDbType.Date).Value = EmpVisit.NocDate;
                cmd.Parameters.Add("@Purpose", SqlDbType.VarChar).Value = EmpVisit.Purpose;
                cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
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
        public List<EmployeeVisits> GetEmployeeVisits(int EmpId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_VISITS";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<EmployeeVisits> EmpVisits = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    EmpVisits = new List<EmployeeVisits>();
                    while (dr.Read())
                    {
                        EmployeeVisits Eh = new EmployeeVisits();
                        Eh.ForeignVisitId = Convert.ToInt32(dr["User_Visits_Id"]);
                        Eh.System_User_Id = Convert.ToInt32(dr["System_Users_Id"]);
                        Eh.VisitTypeId = Convert.ToInt32(dr["Visit_Type_Id"]);
                        Eh.CountryId = Convert.ToInt32(dr["Countries_Id"]);
                        Eh.Country = Convert.ToString(dr["Country"]);
                        Eh.VisitType = Convert.ToString(dr["Visit_Type"]);
                        Eh.FromDate = Convert.ToDateTime(dr["From_Date"]);
                        Eh.ToDate = Convert.ToDateTime(dr["To_Date"]);
                        if(dr["NOC_Date"]!=DBNull.Value)
                        Eh.NocDate= Convert.ToDateTime(dr["NOC_Date"]);
                        Eh.Purpose = Convert.ToString(dr["Purpose"]);
                        EmpVisits.Add(Eh);
                    }
                }
                if (EmpVisits != null) EmpVisits.TrimExcess();
                return EmpVisits;
            }
            finally
            {
                con.Close();
            }

        }
        public void DeleteEmployeeVisit(int VisitId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_VISIT";
                cmd.Parameters.Add("@UserVisitId", SqlDbType.Int).Value = VisitId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }

        }
        /////////////////////////////////////////////////////////////////////////////////////////////////
        public void InsertEmployeeNOC(NOC noc)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_NOC";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = noc.SystemUserId;
                cmd.Parameters.Add("@NocNumber", SqlDbType.VarChar).Value = noc.NocNumber;
                cmd.Parameters.Add("@NocTypeId", SqlDbType.Int).Value = noc.NocTypeId;
                cmd.Parameters.Add("@NocDate", SqlDbType.Date).Value = noc.IssueDate;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = noc.Remarks;
                cmd.Connection = con;

                cmd.ExecuteNonQuery();
                AuditLogger.LogCommand(cmd);
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
        public void UpdateEmployeeNOC(NOC noc)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_NOC";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NOCId", SqlDbType.Int).Value = noc.NocId;
               // cmd.Parameters.Add("@NocNumber", SqlDbType.VarChar).Value = noc.NocNumber;
                cmd.Parameters.Add("@NocTypeId", SqlDbType.Int).Value = noc.NocTypeId;
                cmd.Parameters.Add("@NocDate", SqlDbType.Date).Value = noc.IssueDate;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = noc.Remarks;
                cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
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
        public List<NOC> GetEmployeeNOCs(int EmpId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_NOCS";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<NOC> NOCs = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    NOCs = new List<NOC>();
                    while (dr.Read())
                    {
                        NOC Eh = new NOC();
                        Eh.NocId = Convert.ToInt32(dr["Emp_Noc_Id"]);
                        Eh.SystemUserId = Convert.ToInt32(dr["System_Users_Id"]);
                      //  Eh.NocNumber = Convert.ToString(dr["Noc_Number"]);
                        Eh.NocTypeId = Convert.ToInt32(dr["Emp_Noc_Types_Id"]); ;
                        Eh.NocType = Convert.ToString(dr["Description"]);
                        Eh.IssueDate = Convert.ToDateTime(dr["Noc_Date"]); ;
                        Eh.Remarks = Convert.ToString(dr["Remarks"]); ;
                        NOCs.Add(Eh);
                    }
                }

                if (NOCs != null) NOCs.TrimExcess();
                return NOCs;
            }
            finally
            {
                con.Close();
            }
        }
        public void DeleteEmployeeNOC(int NocId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_NOC";
                cmd.Parameters.Add("@NOCId", SqlDbType.Int).Value = NocId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }

        }

        public EmpProfile GetOnePage(int empId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ONE_PAGE";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = empId;
                cmd.CommandType = CommandType.StoredProcedure;
                EmpProfile op = new EmpProfile();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();

                    if (dr["f_Name"] != DBNull.Value)
                        op.FName = Convert.ToString(dr["f_name"]);
                    if (dr["dob"] != DBNull.Value)
                    {
                        op.Dob = Convert.ToDateTime(dr["dob"]);
                        op.SuperanuationDate = op.Dob.AddYears(60);
                    }
                    if (dr["PREVIOUS_LEAVE_CREDIT"] != DBNull.Value)
                        op.LeaveOnCredit = Convert.ToInt32(dr["PREVIOUS_LEAVE_CREDIT"]);
                    else
                        op.LeaveOnCredit = 0;
                    if (dr["Age"] != DBNull.Value)
                        op.Age = Convert.ToInt32(dr["Age"]);
                    if (dr["Govt_Service"] != DBNull.Value)
                        op.GovtService = Convert.ToInt32(dr["Govt_Service"]);
                    if (dr["House_Service"] != DBNull.Value)
                        op.HouseService = Convert.ToInt32(dr["House_Service"]);
                    if (dr["Govt_Service_Months"] != DBNull.Value)
                        op.GovtServiceMonths = Convert.ToInt32(dr["Govt_Service_Months"]);
                    if (dr["House_Service_Months"] != DBNull.Value)
                        op.HouseServiceMonths = Convert.ToInt32(dr["House_Service_Months"]);
                    if (dr["Post"] != DBNull.Value)
                        op.CurrentDesignation = Convert.ToString(dr["Post"]);
                    if (dr["bps"] != DBNull.Value)
                        op.CurrentBPS = Convert.ToString(dr["bps"]);
                    if (dr["Branch"] != DBNull.Value)
                        op.CurrentBranch = Convert.ToString(dr["BranchDesc"]);
                    if (dr["emp_status"] != DBNull.Value)
                        op.EmployeeStatus = Convert.ToString(dr["emp_status"]);
                    if (dr["Govt_service_start_date"] != DBNull.Value)
                        op.GovtServiceStartDate = Convert.ToDateTime(dr["Govt_service_start_date"]);
                    if (dr["House_service_start_date"] != DBNull.Value)
                        op.SenateServiceStartDate = Convert.ToDateTime(dr["House_service_start_date"]);
                }
                return op;

            }
            finally
            {
                con.Close();
            }
        }

        //   ------------------------------------------------ ACR--------------------------------------------

        public List<AnnualConfRep> GetAcrs(int EmpId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACRS";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<AnnualConfRep> Acrs = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Acrs = new List<AnnualConfRep>();
                    while (dr.Read())
                    {
                        AnnualConfRep ea = new AnnualConfRep();
                        if (dr["Emp_Acr_Id"] != DBNull.Value)
                            ea.AnConfRepId = Convert.ToInt32(dr["Emp_Acr_Id"]);
                        if (dr["BPS_Id"] != DBNull.Value)
                            ea.BPSID = Convert.ToInt32(dr["BPS_Id"]);
                        if (dr["Posts_Id"] != DBNull.Value)
                            ea.PostId = Convert.ToInt32(dr["Posts_Id"]);
                        if (dr["Acr_year"] != DBNull.Value)
                            ea.RepYear = Convert.ToInt32(dr["Acr_year"]);
                        if (dr["Post"] != DBNull.Value)
                            ea.Post = Convert.ToString(dr["Post"]);
                        if (dr["BPS"] != DBNull.Value)
                            ea.BPS = Convert.ToString(dr["BPS"]);
                        if (dr["Reporting_Officer"] != DBNull.Value)
                            ea.ReportingOfficerId = Convert.ToInt32(dr["Reporting_Officer"]);
                        if (dr["REPOFFICER_NAME"] != DBNull.Value)
                            ea.ReportingOfficer = Convert.ToString(dr["REPOFFICER_NAME"]);
                        if (dr["REP_OFFICER_IN_DATE"] != DBNull.Value)
                            ea.ROInDate = Convert.ToDateTime(dr["REP_OFFICER_IN_DATE"]);
                        if (dr["REP_OFFICER_OUT_DATE"] != DBNull.Value)
                            ea.ROOutDate = Convert.ToDateTime(dr["REP_OFFICER_OUT_DATE"]);
                        if (dr["COUNTERSIGNING_OFFICER"] != DBNull.Value)
                            ea.CounterSignOffId = Convert.ToInt32(dr["COUNTERSIGNING_OFFICER"]);
                        if (dr["CSOFFICER_NAME"] != DBNull.Value)
                            ea.CounterSignOff = Convert.ToString(dr["CSOFFICER_NAME"]);
                        if (dr["CS_OFFICER_IN_DATE"] != DBNull.Value)
                            ea.CSInDate = Convert.ToDateTime(dr["CS_OFFICER_IN_DATE"]);
                        if (dr["CS_OFFICER_OUT_DATE"] != DBNull.Value)
                            ea.CSOutDate = Convert.ToDateTime(dr["CS_OFFICER_OUT_DATE"]);
                        if (dr["ACR_STATUS_ID"] != DBNull.Value)
                        {
                            ea.StatusId = Convert.ToInt32(dr["ACR_STATUS_ID"]);
                            ea.AcrStatus = Convert.ToString(dr["ACR_Status"]);
                        }

                        if (dr["ACR_GRADE_ID"] != DBNull.Value)
                        {
                            ea.GradeId = Convert.ToInt32(dr["ACR_GRADE_ID"]);
                            ea.AcrGrade = Convert.ToString(dr["ACR_Grade"]);
                        }
                        ea.Remarks = Convert.ToString(dr["Remarks"]);

                        Acrs.Add(ea);
                    }
                }
                if (Acrs != null) Acrs.TrimExcess();
                return Acrs;
            }
            finally
            {
                con.Close();
            }
        }
        public List<ReportingOfficers> GetReportingOfficers()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACR_REPORTING_OFF";
                cmd.CommandType = CommandType.StoredProcedure;
                List<ReportingOfficers> Acrs = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Acrs = new List<ReportingOfficers>();
                    while (dr.Read())
                    {
                        ReportingOfficers ea = new ReportingOfficers();
                        if (dr["System_Users_Id"] != DBNull.Value)
                            ea.OfficerId = Convert.ToInt32(dr["System_Users_Id"]);
                        if (dr["Emp_Name"] != DBNull.Value)
                            ea.OfficerName = Convert.ToString(dr["Emp_Name"]);
                        if (dr["Post"] != DBNull.Value)
                            ea.OfficerPost = Convert.ToString(dr["Post"]);

                        Acrs.Add(ea);
                    }
                }
                if (Acrs != null) Acrs.TrimExcess();
                return Acrs;
            }
            finally
            {
                con.Close();
            }
        }
        public void InsertAnnualConfRep(AnnualConfRep ea)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_ACR";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = ea.SystemUserId;
                // cmd.Parameters.Add("@EmpAcrId", SqlDbType.Int).Value = ea.EmpAcrId;
                cmd.Parameters.Add("@AcrYear", SqlDbType.Int).Value = ea.RepYear;
                cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = ea.PostId;
                cmd.Parameters.Add("@BPS", SqlDbType.Int).Value = ea.BPSID;
                cmd.Parameters.Add("@RepoptingOfficer", SqlDbType.Int).Value = ea.ReportingOfficerId;
                cmd.Parameters.Add("@RepOfficerName", SqlDbType.VarChar).Value = ea.ReportingOfficer;
                if (Convert.ToString(ea.CSInDate) != "01/01/0001 00:00:00")
                    cmd.Parameters.Add("@CSInDate", SqlDbType.Date).Value = ea.CSInDate;
                if (Convert.ToString(ea.CSOutDate) != "01/01/0001 00:00:00")
                    cmd.Parameters.Add("@CSOutDate", SqlDbType.Date).Value = ea.CSOutDate;
                cmd.Parameters.Add("@CounterSigningOfficer", SqlDbType.Int).Value = ea.CounterSignOffId;
                cmd.Parameters.Add("@CsOfficerName", SqlDbType.VarChar).Value = ea.CounterSignOff;
                if (Convert.ToString(ea.ROInDate) != "01/01/0001 00:00:00")
                    cmd.Parameters.Add("@RepInDate", SqlDbType.Date).Value = ea.ROInDate;
                if (Convert.ToString(ea.ROOutDate) != "01/01/0001 00:00:00")
                    cmd.Parameters.Add("@RepOutDate", SqlDbType.Date).Value = ea.ROOutDate;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = ea.StatusId;
                cmd.Parameters.Add("@Grade", SqlDbType.Int).Value = ea.GradeId;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = ea.Remarks;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                AuditLogger.LogCommand(cmd);
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
        public void UpdateAnnualConfRep(AnnualConfRep ea)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_ACR";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@EmpAcrId", SqlDbType.Int).Value = ea.AnConfRepId;
                cmd.Parameters.Add("@AcrYear", SqlDbType.Int).Value = ea.RepYear;
                cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = ea.PostId;
                cmd.Parameters.Add("@BPS", SqlDbType.Int).Value = ea.BPSID;
                cmd.Parameters.Add("@RepoptingOfficer", SqlDbType.Int).Value = ea.ReportingOfficerId;
                cmd.Parameters.Add("@RepOfficerName", SqlDbType.VarChar).Value = ea.ReportingOfficer;
                if (Convert.ToString(ea.ROInDate) != "01/01/0001 00:00:00")
                    cmd.Parameters.Add("@RepInDate", SqlDbType.Date).Value = ea.ROInDate;
                if (Convert.ToString(ea.ROOutDate) != "01/01/0001 00:00:00")
                    cmd.Parameters.Add("@RepOutDate", SqlDbType.Date).Value = ea.ROOutDate;
                cmd.Parameters.Add("@CounterSigningOfficer", SqlDbType.Int).Value = ea.CounterSignOffId;
                cmd.Parameters.Add("@CsOfficerName", SqlDbType.VarChar).Value = ea.CounterSignOff;
                if (Convert.ToString(ea.CSInDate) != "01/01/0001 00:00:00")
                    cmd.Parameters.Add("@CSInDate", SqlDbType.Date).Value = ea.CSInDate;
                if (Convert.ToString(ea.CSOutDate) != "01/01/0001 00:00:00")
                    cmd.Parameters.Add("@CSOutDate", SqlDbType.Date).Value = ea.CSOutDate;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = ea.StatusId;
                cmd.Parameters.Add("@Grade", SqlDbType.Int).Value = ea.GradeId;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = ea.Remarks;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                AuditLogger.LogCommand(cmd);
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
        public void DeleteEmployeeACR(int EmpAcrId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_ACR";
                cmd.Parameters.Add("@EmpAcrId", SqlDbType.Int).Value = EmpAcrId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }

        }
        public List<PostingSummary> GetPostingSummary(int empId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_POSTING_DURATION";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = empId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<PostingSummary> ps = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    ps = new List<PostingSummary>();
                    while (dr.Read())
                    {
                        PostingSummary ea = new PostingSummary();
                        if (dr["Branch_Id"] != DBNull.Value)
                            ea.BranchId = Convert.ToInt32(dr["Branch_Id"]);
                        if (dr["Description"] != DBNull.Value)
                            ea.BranchName = Convert.ToString(dr["Description"]);
                        if (dr["YEARS"] != DBNull.Value)
                            ea.TotalYears = Convert.ToInt32(dr["YEARS"]);
                        if (dr["MONTHS"] != DBNull.Value)
                            ea.TotalMonths = Convert.ToInt32(dr["MONTHS"]);

                        ps.Add(ea);
                    }
                }

                List<PostingSummary> temp = new List<PostingSummary>();
                if (ps != null)
                {
                    List<PostingSummary> orderedlist = ps.OrderBy(o => o.BranchId).ToList();
                    List<PostingSummary> newlist = orderedlist.GroupBy(test => test.BranchId)
                           .Select(grp => grp.First())
                           .ToList();

                    for (int i = 0; i < newlist.Count; i++)
                    {
                        PostingSummary tempps = new PostingSummary();
                        tempps.BranchId = newlist[i].BranchId;
                        tempps.BranchName = newlist[i].BranchName;
                        int id = newlist[i].BranchId;
                        int totalmonths = 0;
                        foreach (PostingSummary row in orderedlist)
                        {
                            if (row.BranchId == id)
                            {
                                totalmonths += row.TotalMonths;
                            }
                        }
                        if (totalmonths > 0)
                        { 
                            tempps.TotalYears = totalmonths / 12;
                            tempps.TotalMonths = totalmonths % 12;
                            tempps.TotalPeriod = Convert.ToDouble(tempps.TotalYears + "." + tempps.TotalMonths);
                            temp.Add(tempps);
                        }
                    }

                    if (temp != null) temp.TrimExcess();
                    return temp.OrderByDescending(o => o.TotalPeriod).ToList();
                }
                return temp;
            }
            finally
            {
                con.Close();
            }
        }

        #region RESOURSE PERSON
        public List<ResoursePerson> GetResourse(int EmpId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RESOURCE_PERSON";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ResoursePerson> Acrs = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Acrs = new List<ResoursePerson>();
                    while (dr.Read())
                    {
                        ResoursePerson ea = new ResoursePerson();
                        if (dr["EMP_RESOURSE_ID"] != DBNull.Value)
                            ea.ResoursePersonId = Convert.ToInt32(dr["EMP_RESOURSE_ID"]);
                        if (dr["SYSTEM_USERS_ID"] != DBNull.Value)
                            ea.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        if (dr["BPS_Id"] != DBNull.Value)
                            ea.BPSID = Convert.ToInt32(dr["BPS_Id"]);
                        if (dr["Posts_Id"] != DBNull.Value)
                            ea.PostId = Convert.ToInt32(dr["Posts_Id"]);
                        if (dr["Post"] != DBNull.Value)
                            ea.Post = Convert.ToString(dr["Post"]);
                        if (dr["BPS"] != DBNull.Value)
                            ea.BPS = Convert.ToString(dr["BPS"]);
                        if (dr["DETAILS"] != DBNull.Value)
                            ea.Details = Convert.ToString(dr["DETAILS"]);
                        if (dr["STATION"] != DBNull.Value)
                            ea.Station = Convert.ToString(dr["STATION"]);
                        if (dr["PRESENTED_AS"] != DBNull.Value)
                            ea.PresAs = Convert.ToString(dr["PRESENTED_AS"]);
                        if (dr["ON_DATE"] != DBNull.Value)
                            ea.PresDate = Convert.ToDateTime(dr["ON_DATE"]);

                        Acrs.Add(ea);
                    }
                }

                if (Acrs != null) Acrs.TrimExcess();
                return Acrs;
            }
            finally
            {
                con.Close();
            }
        }

        public void InsertEmployeeRes(ResoursePerson ea)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_RESOURCE_PERSON";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = ea.SystemUsersId;
                cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = ea.PostId;
                cmd.Parameters.Add("@BPS", SqlDbType.Int).Value = ea.BPSID;
                cmd.Parameters.Add("@OnDate", SqlDbType.DateTime).Value = ea.PresDate;
                cmd.Parameters.Add("@Details", SqlDbType.VarChar).Value = ea.Details;
                cmd.Parameters.Add("@Station", SqlDbType.VarChar).Value = ea.Station;
                cmd.Parameters.Add("@PresentedAs", SqlDbType.VarChar).Value = ea.PresAs;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                AuditLogger.LogCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Close();
            }

        }
        public void UpdateEmployeeRes(ResoursePerson ea)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_RESOURCE_PERSON";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@EmpResourceId", SqlDbType.Int).Value = ea.ResoursePersonId;
                cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = ea.PostId;
                cmd.Parameters.Add("@BPS", SqlDbType.Int).Value = ea.BPSID;
                cmd.Parameters.Add("@OnDate", SqlDbType.DateTime).Value = ea.PresDate;
                cmd.Parameters.Add("@Details", SqlDbType.VarChar).Value = ea.Details;
                cmd.Parameters.Add("@Station", SqlDbType.VarChar).Value = ea.Station;
                cmd.Parameters.Add("@PresentedAs", SqlDbType.VarChar).Value = ea.PresAs;
                cmd.Connection = con;

                cmd.ExecuteNonQuery();
                AuditLogger.LogCommand(cmd);
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
        public void DeleteResourse(int ResId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_RESOURCE_PERSON";
                cmd.Parameters.Add("@EmpResourceId", SqlDbType.Int).Value = ResId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }
        }
        #endregion
        #region MEDICAL
        public List<EmpMedical> GetEmpMedical(int EmpId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_MEDICAL";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<EmpMedical> EmpMedical = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    EmpMedical = new List<EmpMedical>();
                    while (dr.Read())
                    {
                        EmpMedical ea = new EmpMedical();
                        if (dr["EMP_MEDICAL_ID"] != DBNull.Value)
                            ea.EmpMedicalId = Convert.ToInt32(dr["EMP_MEDICAL_ID"]);
                        if (dr["SYSTEM_USERS_ID"] != DBNull.Value)
                            ea.SystemUserId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);

                        if (dr["CHECKUP_DATE"] != DBNull.Value)
                            ea.OnDate = Convert.ToDateTime(dr["CHECKUP_DATE"]);
                        if (dr["MEDICAL_TYPE_ID"] != DBNull.Value)
                        {
                            ea.MedicalTypeId = Convert.ToInt32(dr["MEDICAL_TYPE_ID"]);
                            ea.MedicalType = Convert.ToString(dr["MEDICAL_TYPE"]);

                        }
                        if (dr["POST_ID"] != DBNull.Value)
                        {
                            ea.PostId = Convert.ToInt32(dr["POST_ID"]);
                            ea.Post = Convert.ToString(dr["POST"]);
                        }
                        if (dr["BPS_ID"] != DBNull.Value)
                        {
                            ea.BPSID = Convert.ToInt32(dr["BPS_ID"]);
                            ea.BPS = Convert.ToString(dr["BPS"]);
                        }
                        if (dr["MEDICAL_YEAR"] != DBNull.Value)
                            ea.MedYear = Convert.ToInt32(dr["MEDICAL_YEAR"]);
                        ea.IsSubmitted = Convert.ToInt32(dr["IS_SUBMITTED"]);
                        if (dr["REMARKS"] != DBNull.Value)
                            ea.Remarks = Convert.ToString(dr["REMARKS"]);


                        EmpMedical.Add(ea);
                    }
                }
                if (EmpMedical != null) EmpMedical.TrimExcess();
                return EmpMedical;
            }
            finally
            {
                con.Close();

            }
        }

        public void InsertEmpMedical(EmpMedical ea)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_EMP_MEDICAL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = ea.SystemUserId;
                cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = ea.PostId;
                cmd.Parameters.Add("@Bps", SqlDbType.Int).Value = ea.BPSID;
                cmd.Parameters.Add("@year", SqlDbType.Int).Value = ea.MedYear;
                cmd.Parameters.Add("@TypeId", SqlDbType.Int).Value = ea.MedicalTypeId;
                cmd.Parameters.Add("@OnDate", SqlDbType.DateTime).Value = ea.OnDate;
                cmd.Parameters.Add("@IsSubmitted", SqlDbType.VarChar).Value = ea.IsSubmitted;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = ea.Remarks;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                AuditLogger.LogCommand(cmd);
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
        public void UpdateEmpMedical(EmpMedical ea)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_EMP_MEDICAL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = ea.SystemUserId;
                cmd.Parameters.Add("@Idd", SqlDbType.Int).Value = ea.EmpMedicalId;
                cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = ea.PostId;
                cmd.Parameters.Add("@Bps", SqlDbType.Int).Value = ea.BPSID;
                cmd.Parameters.Add("@year", SqlDbType.Int).Value = ea.MedYear;
                cmd.Parameters.Add("@TypeId", SqlDbType.Int).Value = ea.MedicalTypeId;
                cmd.Parameters.Add("@OnDate", SqlDbType.DateTime).Value = ea.OnDate;
                cmd.Parameters.Add("@IsSubmitted", SqlDbType.VarChar).Value = ea.IsSubmitted;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = ea.Remarks;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                AuditLogger.LogCommand(cmd);
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
        public void DeleteEmpMedical(int EmpMedicalId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_EMP_MEDICAL";
                cmd.Parameters.Add("@Idd", SqlDbType.Int).Value = EmpMedicalId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }
        }
        #endregion MEDICAL

        #region ASSET
        public List<EmpAssets> GetEmpAsset(int EmpId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_ASSET";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<EmpAssets> EmpAsset = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    EmpAsset = new List<EmpAssets>();
                    while (dr.Read())
                    {
                        EmpAssets ea = new EmpAssets();
                        if (dr["EMP_ASSET_ID"] != DBNull.Value)
                            ea.EmpAssetId = Convert.ToInt32(dr["EMP_ASSET_ID"]);
                        if (dr["SYSTEM_USERS_ID"] != DBNull.Value)
                            ea.SystemUserId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);


                        if (dr["POST_ID"] != DBNull.Value)
                        {
                            ea.PostId = Convert.ToInt32(dr["POST_ID"]);
                            ea.Post = Convert.ToString(dr["POST"]);
                        }
                        if (dr["BPS_ID"] != DBNull.Value)
                        {
                            ea.BPSID = Convert.ToInt32(dr["BPS_ID"]);
                            ea.BPS = Convert.ToString(dr["BPS"]);
                        }
                        if (dr["ASSET_YEAR"] != DBNull.Value)
                            ea.AssetYear = Convert.ToInt32(dr["ASSET_YEAR"]);
                        ea.IsSubmitted = Convert.ToInt32(dr["IS_SUBMITTED"]);


                        EmpAsset.Add(ea);
                    }
                }
                if (EmpAsset != null) EmpAsset.TrimExcess();
                return EmpAsset;
            }
            finally
            {
                con.Close();
            }
        }

        public void InsertEmpAsset(EmpAssets ea)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_EMP_ASSET";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = ea.SystemUserId;
                cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = ea.PostId;
                cmd.Parameters.Add("@Bps", SqlDbType.Int).Value = ea.BPSID;
                cmd.Parameters.Add("@year", SqlDbType.Int).Value = ea.AssetYear;
                cmd.Parameters.Add("@IsSubmitted", SqlDbType.VarChar).Value = ea.IsSubmitted;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                AuditLogger.LogCommand(cmd);
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
        public void UpdateEmpAsset(EmpAssets ea)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_EMP_ASSET";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Idd", SqlDbType.Int).Value = ea.EmpAssetId;
                cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = ea.PostId;
                cmd.Parameters.Add("@Bps", SqlDbType.Int).Value = ea.BPSID;
                cmd.Parameters.Add("@year", SqlDbType.Int).Value = ea.AssetYear;
                cmd.Parameters.Add("@IsSubmitted", SqlDbType.VarChar).Value = ea.IsSubmitted;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                AuditLogger.LogCommand(cmd);
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
        public void DeleteEmpAsset(int EmpAssetId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_EMP_ASSET";
                cmd.Parameters.Add("@Idd", SqlDbType.Int).Value = EmpAssetId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }
         

        }
        #endregion ASSET
        #region OTHER DUTIES

        public List<EmpOtherDuty> GetEmpOtherDuties(int EmpId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_OTHER_DUTIES";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<EmpOtherDuty> EmpOtherDuty = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    EmpOtherDuty = new List<EmpOtherDuty>();
                    while (dr.Read())
                    {
                        EmpOtherDuty ea = new EmpOtherDuty();
                        if (dr["EMP_OTHER_DUTY_ID"] != DBNull.Value)
                            ea.EmpOtherDutyId = Convert.ToInt32(dr["EMP_OTHER_DUTY_ID"]);
                        if (dr["SYSTEM_USERS_ID"] != DBNull.Value)
                            ea.SystemUserId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);

                        if (dr["OTHER_DUTY_TYPE_ID"] != DBNull.Value)
                        {
                            ea.DutyTypeId = Convert.ToInt32(dr["OTHER_DUTY_TYPE_ID"]);
                            ea.DutyType = Convert.ToString(dr["OTHER_DUTY_TYPE"]);

                        }
                        if (dr["POST_ID"] != DBNull.Value)
                        {
                            ea.PostId = Convert.ToInt32(dr["POST_ID"]);
                            ea.Post = Convert.ToString(dr["POST"]);
                        }
                        if (dr["BPS_ID"] != DBNull.Value)
                        {
                            ea.BPSID = Convert.ToInt32(dr["BPS_ID"]);
                            ea.BPS = Convert.ToString(dr["BPS"]);
                        }
                        if (dr["DUTY_YEAR"] != DBNull.Value)
                            ea.DutyYear = Convert.ToInt32(dr["DUTY_YEAR"]);
                        if (dr["FROM_DATE"] != DBNull.Value)
                            ea.FromDate = Convert.ToDateTime(dr["FROM_DATE"]);
                        if (dr["TO_DATE"] != DBNull.Value)
                            ea.ToDate = Convert.ToDateTime(dr["TO_DATE"]);
                        ea.Details = Convert.ToString(dr["DETAILS"]);


                        EmpOtherDuty.Add(ea);
                    }
                }
                if (EmpOtherDuty != null) EmpOtherDuty.TrimExcess();
                return EmpOtherDuty;
            }
            finally
            {
                con.Close();

            }
        }

        public void InsertEmpOtherDuty(EmpOtherDuty ea)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_EMP_OTHER_DUTY";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = ea.SystemUserId;
                cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = ea.PostId;
                cmd.Parameters.Add("@Bps", SqlDbType.Int).Value = ea.BPSID;
                cmd.Parameters.Add("@year", SqlDbType.Int).Value = ea.DutyYear;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = ea.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = ea.ToDate;
                cmd.Parameters.Add("@TypeId", SqlDbType.Int).Value = ea.DutyTypeId;
                cmd.Parameters.Add("@Details", SqlDbType.VarChar).Value = ea.Details;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                AuditLogger.LogCommand(cmd);
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
        public void UpdateEmpOtherDuty(EmpOtherDuty ea)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_EMP_OTHER_DUTY";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = ea.SystemUserId;
                cmd.Parameters.Add("@Idd", SqlDbType.Int).Value = ea.EmpOtherDutyId;
                cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = ea.PostId;
                cmd.Parameters.Add("@Bps", SqlDbType.Int).Value = ea.BPSID;
                cmd.Parameters.Add("@year", SqlDbType.Int).Value = ea.DutyYear;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = ea.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = ea.ToDate;
                cmd.Parameters.Add("@TypeId", SqlDbType.Int).Value = ea.DutyTypeId;
                cmd.Parameters.Add("@Details", SqlDbType.VarChar).Value = ea.Details;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                AuditLogger.LogCommand(cmd);
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
        public void DeleteEmpOtherDuty(int EmpOtherDutyId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_EMP_OTHER_DUTY";
                cmd.Parameters.Add("@Idd", SqlDbType.Int).Value = EmpOtherDutyId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }
        }
        #endregion OTHER DUTIES

        public List<BasicInfo> GetEmployeeByName()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMPLOYEES_FOR_PN";
                cmd.CommandType = CommandType.StoredProcedure;
                List<BasicInfo> EmployeesByName = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    EmployeesByName = new List<BasicInfo>();
                    while (dr.Read())
                    {
                        BasicInfo ea = new BasicInfo();
                            ea.EmpId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);

                            ea.EmpName = Convert.ToString(dr["F_Name"]);

                        EmployeesByName.Add(ea);
                    }
                }
                if (EmployeesByName != null) EmployeesByName.TrimExcess();
                return EmployeesByName;
            }
            finally
            {
                con.Close();

            }
        }
        public BasicInfo GetEmployeeByName(string EmpName)
        {
            BasicInfo bis = null; ;
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_BY_NAME";
                cmd.Parameters.Add("@FName", SqlDbType.VarChar).Value = EmpName;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    bis = new BasicInfo();
                    dr.Read();
                   
                        bis.EmpName = Convert.ToString(dr["EMPNAME"]);
                        bis.PersonalNumber = Convert.ToDouble(dr["PesonalNumber"]);
                   
                }
             
                return bis;
            }
            finally
            {
                con.Close();

            }

        }
        #region PERSONAL NUMBERS
        public List<PersonalNumbers> GetPersonalNumbers(string query)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
               List<PersonalNumbers> emp = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        emp = new List<PersonalNumbers>();
                        while (dr.Read())
                        {
                            PersonalNumbers ad = new PersonalNumbers();
                            ad.SystemUsersId = Convert.ToInt32(dr["system_users_id"]);
                            ad.EmpName = Convert.ToString(dr["f_name"] + " " + dr["m_name"] + " " + dr["l_name"]);
                            if (dr["Personal_No"] != DBNull.Value)
                                ad.PersonalNumber=Convert.ToString(dr["Personal_No"]);
                            if (dr["EMPLOYEE_POOLS_ID"] != DBNull.Value)
                                ad.EmployeePoolsId = Convert.ToInt32(dr["EMPLOYEE_POOLS_ID"]);
                            else
                                ad.EmployeePoolsId = 0;
                            if (dr["Vendor_Number"] != DBNull.Value)
                                ad.VendorNumber = Convert.ToString(dr["Vendor_Number"]);
                            ad.Post = Convert.ToString(dr["post"]);
                            ad.BPS = Convert.ToString(dr["bps"]);
                            ad.imageurl= Convert.ToString(dr["ImageUrl"]);
                            ad.CNIC = Convert.ToString(dr["NIC_NUMBER"]);

                            emp.Add(ad);
                        }
                    }

                    if (emp != null) emp.TrimExcess();
                    return emp;
                }
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdatePersonalNumbers(PersonalNumbers personalnumber)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_PERSONAL_NUMBERS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = personalnumber.SystemUsersId;
                cmd.Parameters.Add("@PersonalNumber", SqlDbType.VarChar).Value = personalnumber.PersonalNumber;
                cmd.Parameters.Add("@VendorNumber", SqlDbType.VarChar).Value = personalnumber.VendorNumber;
                cmd.Parameters.Add("@EmployeePoolId", SqlDbType.VarChar).Value = personalnumber.EmployeePoolsId;
                cmd.Parameters.Add("@CnicNumber", SqlDbType.VarChar).Value = personalnumber.CNIC;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                AuditLogger.LogCommand(cmd);
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
        #endregion PERSONAL NUMBERS

        #region EMAILS
       
        public List<UserEmails> GetEmployeeEmails(int empId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_USER_EMAILS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = empId;
                cmd.Connection = con;
                List<UserEmails> emails = null;

                using (con)
                {

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        emails = new List<UserEmails>();
                        while (dr.Read())
                        {
                            UserEmails cy = new UserEmails();
                            cy.SystemUsersId = Convert.ToInt32(dr["system_users_id"]);
                            cy.Email = Convert.ToString(dr["Email"]);
                            cy.UserEmailId = Convert.ToInt32(dr["user_emails_id"]);
                            cy.IsOfficial = Convert.ToInt32(dr["Is_Official"]);
                            cy.IsActive = Convert.ToInt32(dr["Is_Active"]);
                            emails.Add(cy);
                        }
                    }
                }
                if (emails != null) emails.TrimExcess();
                return emails;
            }
            finally
            {
                con.Close();
            }

        }
        public void UpdateEmployeeEmail(UserEmails ef)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_USER_EMAIL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Idd", SqlDbType.Int).Value = ef.UserEmailId;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = ef.Email;
                cmd.Parameters.Add("@IsOfficial", SqlDbType.Int).Value = ef.IsOfficial;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = ef.IsActive;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }


        }
        public void DeleteEmployeeEmail(int ef)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_USER_EMAIL";
                cmd.Parameters.Add("@Idd", SqlDbType.Int).Value = ef;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }
        }
        public void InsertEmployeeEmail(UserEmails ef)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_USER_EMAIL";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = ef.SystemUsersId;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = ef.Email;
                cmd.Parameters.Add("@IsOfficial", SqlDbType.Int).Value = ef.IsOfficial;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = ef.IsActive;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }

        }
        #endregion EMAILS
        public DateTime GetDOB(int EmpId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_DOB";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                return Convert.ToDateTime(dr["DOB"]);
            }
            finally
            {
                con.Close();
            }
        }
        public DateTime GetSuperannuationDate(int EmpId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                return  GetDOB(EmpId).AddYears(60);
            }
            finally
            {
                con.Close();
            }
        }
        #region Leave Enchashment Opt
        public LeaveEnchashmentOptEnt GetLeaveEncashmentOpted(int year,int systemusersid)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ENCASHMENT_OPTION";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Year", SqlDbType.Int).Value = year;
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = systemusersid;
                cmd.Connection = con;
                LeaveEnchashmentOptEnt cy = new LeaveEnchashmentOptEnt();
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        
                            
                            cy.StystemUsersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                            cy.Year = Convert.ToInt32(dr["YEAR"]);
                            cy.LeaveEncashmentOptId = Convert.ToInt32(dr["LEAVE_ENC_OPT_ID"]);
                            cy.Days= Convert.ToInt32(dr["NO_OF_DAYS"]);
                        
                    }
                }
                return cy;
            }
            finally
            {
                con.Close();
            }

        }
        public void DeleteLeaveEncashmentOpt(int year,int SystemUserId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_ENCASHMENT_OPTION";
                cmd.Parameters.Add("@Year", SqlDbType.Int).Value = year;
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = SystemUserId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }
        }
        public void InsertLeaveEncashmentOpt(int year,int systemuserid,int noofdays)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                DeleteLeaveEncashmentOpt(year, systemuserid);
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_ENCASHMENT_OPTION";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value =systemuserid;
                cmd.Parameters.Add("@Year", SqlDbType.Int).Value = year;
                cmd.Parameters.Add("@NoOfDays", SqlDbType.Int).Value = noofdays;

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();
            }

        }
        #endregion Leave Encashment Opt
        #region ADDITIONAL_BRANCHES
        public List<AdditionalBranchesEnt> GetAdditionalBranches(int PostingId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ADDITIONAL_BRANCHES";
                cmd.Parameters.Add("@Emp_Posting_Id", SqlDbType.VarChar).Value = PostingId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<AdditionalBranchesEnt> additionalBranches = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    additionalBranches = new List<AdditionalBranchesEnt>();
                    while (dr.Read())
                    {
                        AdditionalBranchesEnt ea = new AdditionalBranchesEnt();
                        ea.PostingId = Convert.ToInt32(dr["POSTING_ID"]);
                        ea.AdditionalBranchesId = Convert.ToInt32(dr["BRANCH_ID"]);
                        ea.AdditionalBranch= Convert.ToString(dr["BRANCH"]);
                        additionalBranches.Add(ea);
                    }
                }
                if (additionalBranches != null) additionalBranches.TrimExcess();
                return additionalBranches;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertAdditionalBranch(AdditionalBranchesEnt ea)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_ADDITIONAL_BRANCH";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Emp_Posting_Id", SqlDbType.Int).Value = ea.PostingId;
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = ea.AdditionalBranchesId;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                AuditLogger.LogCommand(cmd);
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
        public void UpdateBranchesInMainEmployment(string AdditionalBranches,int SystemUsersId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                string branches = null;
                if (!String.IsNullOrEmpty(AdditionalBranches))
                {
                    List<int> AdditionalBranchesId = AdditionalBranches.Split(',').Select(s => Convert.ToInt32(s)).ToList();
                    branches = "-";
                    foreach (int i in AdditionalBranchesId)
                    {
                        branches = branches + i + "-";
                    }
                }
                    SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_ADDITIONAL_BRANCH_IN_MAIN_EMP";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@AdditionalBranches", SqlDbType.VarChar).Value = branches;
                    cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = SystemUsersId;
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    AuditLogger.LogCommand(cmd);
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
        public void DeleteAdditionalBranches(int EmpPostingId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_ADDITIONAL_BRANCH";
                cmd.Parameters.Add("@Emp_Posting_Id", SqlDbType.Int).Value = EmpPostingId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }


        }
        #endregion ADDITIONAL_BRANCHES

        #region CorrectionS
        public List<Correction> GetEmployeeCorrections(int SystemUsersId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_CORRECTIONS";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = SystemUsersId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Correction> Correction = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Correction = new List<Correction>();
                    while (dr.Read())
                    {
                        Correction ea = new Correction();
                        ea.CorrectionId = Convert.ToInt32(dr["Correction_ID"]);
                        ea.CorrectionTxt = Convert.ToString(dr["Correction"]);
                        ea.EmployeeName = Convert.ToString(dr["F_NAME"]);
                        ea.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        ea.CorrectionDate = Convert.ToDateTime(dr["Correction_DATE"]);
                        ea.Solved = Convert.ToInt32(dr["Solved"]);
                        Correction.Add(ea);
                    }
                }
                if (Correction != null) Correction.TrimExcess();
                return Correction;
            }
            finally
            {
                con.Close();

            }
        }
        public List<Correction> GetEmployeeSolvedCorrections(int SystemUsersId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_SOLVED_CORRECTIONS";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = SystemUsersId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Correction> Correction = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Correction = new List<Correction>();
                    while (dr.Read())
                    {
                        Correction ea = new Correction();
                        ea.CorrectionId = Convert.ToInt32(dr["Correction_ID"]);
                        ea.CorrectionTxt = Convert.ToString(dr["Correction"]);
                        ea.EmployeeName = Convert.ToString(dr["F_NAME"]);
                        ea.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        ea.CorrectionDate = Convert.ToDateTime(dr["Correction_DATE"]);
                        ea.Solved = Convert.ToInt32(dr["SOLVED"]);
                        Correction.Add(ea);
                    }
                }
                if (Correction != null) Correction.TrimExcess();
                return Correction;
            }
            finally
            {
                con.Close();

            }
        }
        public List<Correction> GetEmployeeUnSolvedCorrections(int SystemUsersId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_UNSOLVED_CORRECTIONS";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = SystemUsersId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Correction> Correction = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Correction = new List<Correction>();
                    while (dr.Read())
                    {
                        Correction ea = new Correction();
                        ea.CorrectionId = Convert.ToInt32(dr["Correction_ID"]);
                        ea.CorrectionTxt = Convert.ToString(dr["Correction"]);
                        ea.EmployeeName = Convert.ToString(dr["F_NAME"]);
                        ea.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        ea.CorrectionDate = Convert.ToDateTime(dr["Correction_DATE"]);
                        ea.Solved = Convert.ToInt32(dr["SOLVED"]);
                        Correction.Add(ea);
                    }
                }
                if (Correction != null) Correction.TrimExcess();
                return Correction;
            }
            finally
            {
                con.Close();

            }
        }
        public List<Correction> GetSolvedCorrections()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SOLVED_CORRECTIONS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Correction> Correction = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Correction = new List<Correction>();
                    while (dr.Read())
                    {
                        Correction ea = new Correction();
                        ea.CorrectionId = Convert.ToInt32(dr["Correction_ID"]);
                        ea.CorrectionTxt = Convert.ToString(dr["Correction"]);
                        ea.EmployeeName = Convert.ToString(dr["F_NAME"]);
                        ea.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        ea.CorrectionDate = Convert.ToDateTime(dr["Correction_DATE"]);
                        ea.Solved = Convert.ToInt32(dr["SOLVED"]);
                        Correction.Add(ea);
                    }
                }
                if (Correction != null) Correction.TrimExcess();
                return Correction;
            }
            finally
            {
                con.Close();

            }
        }
        public List<Correction> GetUnSolvedCorrections()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_UNSOLVED_CORRECTIONS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Correction> Correction = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Correction = new List<Correction>();
                    while (dr.Read())
                    {
                        Correction ea = new Correction();
                        ea.CorrectionId = Convert.ToInt32(dr["Correction_ID"]);
                        ea.CorrectionTxt = Convert.ToString(dr["Correction"]);
                        ea.EmployeeName = Convert.ToString(dr["F_NAME"]);
                        ea.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        ea.CorrectionDate = Convert.ToDateTime(dr["Correction_DATE"]);
                        ea.Solved = Convert.ToInt32(dr["SOLVED"]);
                        Correction.Add(ea);
                    }
                }
                if (Correction != null) Correction.TrimExcess();
                return Correction;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertCorrection(Correction Correction)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_CORRECTION";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = Correction.SystemUsersId;
                cmd.Parameters.Add("@Correction", SqlDbType.VarChar).Value = Correction.CorrectionTxt;
                cmd.Parameters.Add("@CorrectionDate", SqlDbType.Date).Value = Correction.CorrectionDate;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                AuditLogger.LogCommand(cmd);
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
        public void UpdateCorrection(Correction Correction)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_CORRECTION";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CorrectionId", SqlDbType.Int).Value = Correction.CorrectionId;
                cmd.Parameters.Add("@Correction", SqlDbType.VarChar).Value = Correction.CorrectionTxt;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                AuditLogger.LogCommand(cmd);
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
        public void DeleteCorrection(int CorrectionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_CORRECTION";
                cmd.Parameters.Add("@CorrectionId", SqlDbType.Int).Value = CorrectionId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }


        }
        public void SolveCorrection(int CorrectionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "SOLVE_CORRECTION";
                cmd.Parameters.Add("@CorrectionId", SqlDbType.Int).Value = CorrectionId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
            }
            finally
            {
                con.Close();

            }


        }
        #endregion ADDITIONAL_BRANCHES

        #region BENEVOLENT FUND
        public List<EmpBenevolentFunds> GetEmpBenevolentFunds(int EmployeeId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_BEN_FUNDS";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmployeeId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<EmpBenevolentFunds> empBenevolentFunds = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    empBenevolentFunds = new List<EmpBenevolentFunds>();
                    while (dr.Read())
                    {
                        EmpBenevolentFunds ea = new EmpBenevolentFunds();
                        ea.EmpBenevolentFundId = Convert.ToInt32(dr["EMP_BEN_FUND_ID"]);
                        ea.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USER_ID"]);
                        ea.BenevolentFundTypeId = Convert.ToInt32(dr["BEN_FUND_TYPE_ID"]);
                        ea.BenevolentFundType= Convert.ToString(dr["BEN_FUND_TYPE"]);
                        ea.Amount = Convert.ToInt32(dr["AMOUNT"]);
                        ea.FundDate = Convert.ToDateTime(dr["FUND_DATE"]);
                        ea.Details= Convert.ToString(dr["DETAILS"]);
                        empBenevolentFunds.Add(ea);
                    }
                }
                if (empBenevolentFunds != null) empBenevolentFunds.TrimExcess();
                return empBenevolentFunds;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertEmpBenevolentFund(EmpBenevolentFunds ea)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_EMP_BEN_FUND";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = ea.SystemUsersId;
                cmd.Parameters.Add("@BenevolentFundTypeId", SqlDbType.Int).Value = ea.BenevolentFundTypeId;
                cmd.Parameters.Add("@Amount", SqlDbType.Int).Value = ea.Amount;
                cmd.Parameters.Add("@Date", SqlDbType.Date).Value = ea.FundDate;
                cmd.Parameters.Add("@Details", SqlDbType.VarChar).Value = ea.Details;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                AuditLogger.LogCommand(cmd);
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
        public void UpdateEmpBenevolentFund(EmpBenevolentFunds ea)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_EMP_BEN_FUND";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@EmpBenevolentFundId", SqlDbType.Int).Value = ea.EmpBenevolentFundId;
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = ea.SystemUsersId;
                cmd.Parameters.Add("@BenevolentFundTypeId", SqlDbType.Int).Value = ea.BenevolentFundTypeId;
                cmd.Parameters.Add("@Amount", SqlDbType.Int).Value = ea.Amount;
                cmd.Parameters.Add("@Date", SqlDbType.Date).Value = ea.FundDate;
                cmd.Parameters.Add("@Details", SqlDbType.VarChar).Value = ea.Details;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                AuditLogger.LogCommand(cmd);
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
        public void DeleteEmpBenevolentFund(int Id)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_EMP_BEN_FUND";
                cmd.Parameters.Add("@EmpBenevolentFundId", SqlDbType.Int).Value = Id;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }


        }
        #endregion ADDITIONAL_BRANCHES




    }
}





