using EstablishmentENT;
using EstablishmentENT.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Utilities;

namespace EstablishmentDAL
{
    public class ReportsDAL
    {
        public List<EmpSearchList> GetEmployeesList()
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "SELECT_ACTIVE_EMPLOYEES";
            cmd.CommandType = CommandType.StoredProcedure;
            return EmpList(cmd);

        }
        public List<EmpSearchList> EmployeeContact(string query)
        {
            SqlCommand cmd = new SqlCommand(query, new DalHelper().GetConnection());
            return EmpList(cmd);

        }
        public List<EmpSearchList> EmpList(SqlCommand cmd)
        {

            SqlConnection con = cmd.Connection;

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
                        ad.EmpDesignation = Convert.ToString(dr["postsdescription"]);
                        ad.Bps = Convert.ToString(dr["bpsdescription"]);
                        ad.LocalAddress = Convert.ToString(dr["Local_Address"]);
                        ad.EmailAddress = Convert.ToString(dr["Email"]);
                        //ad.Age = Convert.ToString(dr["age"]);
                        emp.Add(ad);
                    }
                }
                dr.Close();
                cmd.Dispose();
                // }
                if (emp != null) emp.TrimExcess();
                return emp;
            }
        }
         public List<ReportEntity> Get_Superanuation(string query)
        {
            SqlCommand cmd = new SqlCommand(query, new DalHelper().GetConnection());
            SqlConnection con = cmd.Connection;

            List<ReportEntity> emp = null;
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    emp = new List<ReportEntity>();
                    while (dr.Read())
                    {
                        ReportEntity ad = new ReportEntity();
                        ad.SystemUsersId= Convert.ToInt32(dr["system_users_id"]);
                        ad.EmployeeName = Convert.ToString(dr["f_name"]);
                        ad.Post = Convert.ToString(dr["Post"]);
                        ad.Bps = Convert.ToString(dr["Bps"]);
                        //if (dr["HOUSE_SERVICE_START_DATE"] != DBNull.Value)
                        //    ad.SenServiceDate= Convert.ToDateTime(dr["HOUSE_SERVICE_START_DATE"]);
                        //if (dr["GOVT_SERVICE_START_DATE"] != DBNull.Value)
                        //    ad.GovtServiceDate = Convert.ToDateTime(dr["GOVT_SERVICE_START_DATE"]);
                        ad.permanentaddress = Convert.ToString(dr["PERM_ADDRESS"]); 
                            ad.localaddress= Convert.ToString(dr["LOCAL_ADDRESS"]);
                        ad.ContactNumbers = GetPhoneNumbers(ad.SystemUsersId);
                        ad.EmpStatus = Convert.ToString(dr["Employee_Status"]);
                        ad.Branch = Convert.ToString(dr["Branch"]);
                        if (dr["DOB"] != DBNull.Value)
                        {
                            ad.Dob = Convert.ToDateTime(dr["DOB"]);
                            if (ad.Dob.Year < 1900)
                                ad.Age = "";
                            else
                            {
                                Duration age = new DateTimeUtils().GetDuration(ad.Dob, DateTime.Now);
                                ad.Age = Convert.ToString(age.Years + " Years " + age.Months + " Months");
                            }
                        }
                        //if (dr["Age"] != DBNull.Value)
                        //    ad.Age = Convert.ToString(dr["Age"]);
                        //else
                        //    ad.Age = "Not Mentioned";
                        if (dr["SuperannuationDate"]!=DBNull.Value)
                        ad.SuperanuationDate = Convert.ToDateTime(dr["SuperannuationDate"]);
                        emp.Add(ad);
                    }
                }
                dr.Close();
                cmd.Dispose();
                // }
                if (emp != null) emp.TrimExcess();
                return emp;
            }
        }
        public string GetPhoneNumbers(int SystemUsersId)
        {
            string contactnumbers = null;
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_USER_PHONES";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = SystemUsersId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    contactnumbers = null;
                    while (dr.Read())
                    {
                        contactnumbers=contactnumbers + Convert.ToString(dr["PHONE_NUMBER"]) + ", "; 
                    }
                }

                return contactnumbers;
            }
            finally
            {
                con.Close();

            }
        }
        public List<ReportEntity> Get_17_Deputation(string query)
        {
            SqlCommand cmd = new SqlCommand(query, new DalHelper().GetConnection());
            SqlConnection con = cmd.Connection;

            List<ReportEntity> emp = null;
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    emp = new List<ReportEntity>();
                    while (dr.Read())
                    {
                        ReportEntity ad = new ReportEntity();
                        ad.SystemUsersId=Convert.ToInt32(dr["System_users_id"]);
                        ad.EmployeeName = Convert.ToString(dr["f_name"]);
                        ad.Post = Convert.ToString(dr["Post"]);
                        ad.Bps = Convert.ToString(dr["Bps"]);
                        ad.EmpStatus = Convert.ToString(dr["Empl_Status"]);
                        ad.Branch = Convert.ToString(dr["Emp_Branch"]);
                        ad.ParantDepartment = Convert.ToString(dr["Remarks"]);
                      //  ad.Quota = Convert.ToString(dr["Other_Empl_Quota"]);
                        ad.CurrentStatus = Convert.ToString(dr["Current_Status"]);
                        if (dr["current_status_date"] != DBNull.Value)
                            ad.CurrentStatusDate = Convert.ToDateTime(dr["current_status_date"]);
                        if (dr["status_date"] != DBNull.Value)
                            ad.StartDate = Convert.ToDateTime(dr["status_date"]);
                        if (dr["To_Date"] != DBNull.Value)
                            ad.EndDate = Convert.ToDateTime(dr["To_Date"]);
                        if (dr["Extended_To"] != DBNull.Value)
                            ad.ExtendedTo = Convert.ToDateTime(dr["Extended_To"]);
                        ad.Extensions = new EmploymentDAL().GetExtensionDetails(ad.SystemUsersId);
                        emp.Add(ad);
                    }
                }
                dr.Close();
                cmd.Dispose();
                // }
                if (emp != null) emp.TrimExcess();
                return emp;
            }
        }
        public List<ReportEntity> Get_03_Probation(string query)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                List<ReportEntity> emp = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        emp = new List<ReportEntity>();
                        while (dr.Read())
                        {
                            ReportEntity ad = new ReportEntity();
                            ad.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                            ad.EmployeeName = Convert.ToString(dr["f_name"]);
                            ad.Post = Convert.ToString(dr["Post"]);
                            ad.Bps = Convert.ToString(dr["Bps"]);
                            ad.Branch = Convert.ToString(dr["Branch"]);
                            if (dr["Probation_To"] != DBNull.Value)
                                ad.ToDate = Convert.ToDateTime(dr["Probation_To"]);
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
        public List<Probation> Get_All_Probations(int EmpId)       
        {
            List<Probation> ea = null;
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ALL_PROBATIONS";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    ea = new List<Probation>();
                    while (dr.Read())
                    {
                        Probation Eh = new Probation();

                        Eh.ProbationId = Convert.ToInt32(dr["Probation_Id"]);

                        if (dr["Emp_Empl_Hist_Id"] != DBNull.Value)
                            Eh.EmploymentHistId = Convert.ToInt32(dr["Emp_Empl_Hist_Id"]);

                        if (dr["Emp_Promotion_Hist_Id"] != DBNull.Value)
                            Eh.PromotionId = Convert.ToInt32(dr["Emp_Promotion_Hist_Id"]);

                        if (dr["Probation_From"] != DBNull.Value)
                            Eh.ProbationFrom = Convert.ToDateTime(dr["Probation_From"]);

                        if (dr["Probation_To"] != DBNull.Value)
                            Eh.ProbationTo = Convert.ToDateTime(dr["Probation_To"]);

                        if (dr["Probation_Type_Id"] != DBNull.Value)
                            Eh.ProbationTypeId = Convert.ToInt32(dr["Probation_Type_Id"]);

                        if (dr["Probation_Type"] != DBNull.Value)
                            Eh.ProbationType = Convert.ToString(dr["Probation_Type"]);

                        if (dr["Remarks"] != DBNull.Value)
                            Eh.Remarks = Convert.ToString(dr["Remarks"]);

                        ea.Add(Eh);
                    }
                }

                return ea;
            }
            finally
            {
                con.Close();

            }
     
    }
        public List<ReportEntity> Get_08_Extension(string query)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                List<ReportEntity> emp = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        emp = new List<ReportEntity>();
                        while (dr.Read())
                        {
                            ReportEntity ad = new ReportEntity();
                            ad.SystemUsersId= Convert.ToInt32(dr["System_users_Id"]);
                            ad.EmployeeName = Convert.ToString(dr["f_name"]);
                            ad.Post = Convert.ToString(dr["Post"]);
                            ad.Bps = Convert.ToString(dr["Bps"]);
                            ad.Branch = Convert.ToString(dr["Branch"]);
                            ad.EmpStatus = Convert.ToString(dr["Empl_Status"]);
                            ad.Remarks = Convert.ToString(dr["Remarks"]);
                            if (dr["From_Date"] != DBNull.Value)
                                ad.FromDAte = Convert.ToDateTime(dr["From_Date"]);
                            if (dr["Extended_To"] != DBNull.Value)
                                ad.ToDate = Convert.ToDateTime(dr["Extended_To"]);
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

        public DateTime GetNextHigherDate(int EmpId, DateTime date)
        {
            SqlConnection con = new DalHelper().GetConnection();
            DateTime NextDate = DateTime.Now; ;
            string query = "Select dated from EMP_PROMOTION_HIST WHERE SYSTEM_USERS_ID=" + EmpId + " AND DATED >CONVERT(datetime, '" + date + "', 103) ";
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    if (dr["Dated"] != DBNull.Value)
                {
                   NextDate = Convert.ToDateTime(dr["Dated"]);
                }
                   
            }
                return NextDate.AddDays(-1);
            }
            finally

            {
                con.Close();

            }

        }
            public List<ReportEntity> Get_05_Designation(string query)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                List<ReportEntity> emp = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        emp = new List<ReportEntity>();
                        while (dr.Read())
                        {
                            ReportEntity ad = new ReportEntity();
                            ad.SystemUsersId= Convert.ToInt32(dr["System_users_id"]);
                            ad.EmployeeName = Convert.ToString(dr["f_name"]);
                            ad.Post = Convert.ToString(dr["Post"]);
                            ad.Bps = Convert.ToString(dr["Bps"]);
                            //ad.Branch = Convert.ToString(dr["Branch"]);
                            if (dr["Dated"] != DBNull.Value)
                            {
                                ad.ToDate = Convert.ToDateTime(dr["Dated"]);
                                ad.EndDate = GetNextHigherDate(ad.SystemUsersId, ad.ToDate);
                                double days = 0;
                                days = (ad.EndDate - ad.ToDate).TotalDays;
                                ad.years = Math.Floor(days / 365);
                                ad.months = Math.Floor((days % 365) / 30);
                            }
                            
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
        public List<RptEmployeesOnLeave> GetEmployeesOnLeave(string query)
        {

            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                List<RptEmployeesOnLeave> emp = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        emp = new List<RptEmployeesOnLeave>();
                        while (dr.Read())
                        {
                            RptEmployeesOnLeave ad = new RptEmployeesOnLeave();
                            ad.EmpId = Convert.ToInt32(dr["System_users_id"]);
                            ad.EmployeeName = Convert.ToString(dr["f_name"]);
                            ad.Post = Convert.ToString(dr["Post"]);
                            ad.BPS = Convert.ToString(dr["Bps"]);
                            ad.LeaveType= Convert.ToString(dr["Leave_Type"]);
                            ad.LeaveSubType = Convert.ToString(dr["EMP_LEAVE_SUBTYPE"]);
                            ad.StartDate = Convert.ToDateTime(dr["Start_Date"]);
                            ad.EndDate = Convert.ToDateTime(dr["End_Date"]);
                            ad.DaysAvailed = new DateTimeUtils().CalculateNumberofDays(ad.StartDate, ad.EndDate);
                            ad.Remarks= Convert.ToString(dr["Remarks"]);
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

        public List<RptEmployeesTraining> GetEmployeesTraining(string query)
        {

            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                List<RptEmployeesTraining> emp = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        emp = new List<RptEmployeesTraining>();
                        while (dr.Read())
                        {
                            RptEmployeesTraining ad = new RptEmployeesTraining();
                            ad.EmpId = Convert.ToInt32(dr["System_users_id"]);
                            ad.EmployeeName = Convert.ToString(dr["f_name"]);
                            ad.Post = Convert.ToString(dr["Post"]);
                            ad.BPS = Convert.ToString(dr["Bps"]);
                            ad.TrainingsAttended = Convert.ToString(dr["Course_Name"]);
                            ad.TrainingInstitute = Convert.ToString(dr["Institution"]);
                            ad.TrainingField = Convert.ToString(dr["Mandatory"]);
                            ad.TrainingStation = Convert.ToString(dr["Cities_Id"]);
                            if(dr["From_Date"]!=DBNull.Value)
                            ad.FromDate = Convert.ToDateTime(dr["From_Date"]);
                            if (dr["To_Date"] != DBNull.Value)
                                ad.ToDate = Convert.ToDateTime(dr["To_Date"]);
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
        public List<RptEmployeeEducation> GetEmployeesEducation(string query)
        {

            SqlConnection con = new DalHelper().GetConnection();

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                List<RptEmployeeEducation> emp = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        emp = new List<RptEmployeeEducation>();
                        while (dr.Read())
                        {
                            RptEmployeeEducation ad = new RptEmployeeEducation();
                          //  ad.EmpId = Convert.ToInt32(dr["System_users_id"]);
                            ad.EmployeeName = Convert.ToString(dr["f_name"]);
                            ad.Post = Convert.ToString(dr["Post"]);
                            ad.BPS = Convert.ToString(dr["Bps"]);
                            ad.DegreeLevel = Convert.ToString(dr["Education_Level"]);
                            ad.Institution = Convert.ToString(dr["Institution_Name"]);
                            ad.Discipline = Convert.ToString(dr["Degree_Obtained"]);
                            ad.Subjects = Convert.ToString(dr["Subjects"]);
                            ad.CompletionYear = Convert.ToString(dr["Completion_Year"]);
                            ad.Country = Convert.ToString(dr["country"]);
                            if (dr["Grade"] != DBNull.Value)
                                ad.Grade = Convert.ToString(dr["Grade"]);
                             ad.Cgpa = Convert.ToString(dr["cgpa"]);
                            ad.Percentage = Convert.ToString(dr["Percentage"]);
                            ad.Division = Convert.ToString(dr["division"]);
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
        public List<Rpt_Lien> RptGetEmploymentOut(string query)
        {
            SqlCommand cmd = new SqlCommand(query, new DalHelper().GetConnection());
            SqlConnection con = cmd.Connection;

            try
            {
                //SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                //cm//d.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMPLOYEES_ON_LIEN";
                //cmd.Parameters.Add("@EmplOutTypeId", SqlDbType.Int).Value = EmplOutTypeId;
                //cmd.CommandType = CommandType.StoredProcedure;

                List<Rpt_Lien> EmplOutEmp = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    EmplOutEmp = new List<Rpt_Lien>();
                    while (dr.Read())
                    {
                        Rpt_Lien re = new Rpt_Lien();
                        if (dr["EMPL_OUT_ID"] != DBNull.Value)
                            re.EmploymentOutId = Convert.ToInt32(dr["EMPL_OUT_ID"]);

                        if (dr["SYSTEM_USER_ID"] != DBNull.Value)
                        {
                            re.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USER_ID"]);
                            re.EmpName = Convert.ToString(dr["EMP_NAME"]);
                            re.Post = Convert.ToString(dr["POST"]);
                            re.Bps = Convert.ToString(dr["BPS"]);
                            re.Branch = Convert.ToString(dr["BRANCH_NAME"]);
                        }

                        if (dr["EMPL_OUT_TYPE_ID"] != DBNull.Value)
                        {
                            re.EmploymentOutTypeId = Convert.ToInt32(dr["EMPL_OUT_TYPE_ID"]);
                            re.EmploymentOutType = Convert.ToString(dr["EMPL_OUT_TYPE"]);
                        }
                        if (dr["FROM_DATE"] != DBNull.Value)
                            re.FromDate = Convert.ToDateTime(dr["FROM_DATE"]);

                        if (dr["TO_DATE"] != DBNull.Value)
                            re.ToDate = Convert.ToDateTime(dr["TO_DATE"]);

                        if (dr["EMPL_OUT_BPS"] != DBNull.Value && Convert.ToInt32(dr["EMPL_OUT_BPS"]) != 0)
                        {
                            re.OutBps = Convert.ToInt32(dr["EMPL_OUT_BPS"]);
                            BPS bps = new AdministrationDAL().GetBPS(re.OutBps);
                            re.OutBpsDesc = bps.Description;
                        }
                        if (dr["EMPL_OUT_POST"] != DBNull.Value && Convert.ToInt32(dr["EMPL_OUT_POST"]) != 0)
                        {
                            re.OutPost = Convert.ToInt32(dr["EMPL_OUT_POST"]);
                            Post post = new AdministrationDAL().GetPost(re.OutPost);
                            re.OutPostDesc = post.Description;
                        }
                        if (dr["EMPL_IN_BPS"] != DBNull.Value && Convert.ToInt32(dr["EMPL_IN_BPS"]) != 0)
                        {
                            re.InBps = Convert.ToInt32(dr["EMPL_IN_BPS"]);
                            BPS bps = new AdministrationDAL().GetBPS(re.InBps);
                            re.InBpsDesc = bps.Description;
                        }

                        if (dr["EMPL_IN_POST"] != DBNull.Value && Convert.ToInt32(dr["EMPL_IN_POST"]) != 0)
                        {
                            re.InPost = Convert.ToInt32(dr["EMPL_IN_POST"]);
                            Post post = new AdministrationDAL().GetPost(re.InPost);
                            re.InPostDesc = post.Description;
                        }


                        if (dr["IS_EXTENDED"] != DBNull.Value)
                            re.IsExtended = Convert.ToInt32(dr["IS_EXTENDED"]);
                        re.Remarks = Convert.ToString(dr["REMARKS"]);


                        EmplOutEmp.Add(re);
                    }
                }

                if (EmplOutEmp != null) EmplOutEmp.TrimExcess();
                return EmplOutEmp;
            }
            finally
            {
                con.Close();

            }

        }
        public List<Rpt_OtherDuties> RptGetOtherDuties(string query)
        {
            SqlCommand cmd = new SqlCommand(query, new DalHelper().GetConnection());
            SqlConnection con = cmd.Connection;

            try
            {
                List<Rpt_OtherDuties> OtherDuty = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    OtherDuty = new List<Rpt_OtherDuties>();
                    while (dr.Read())
                    {
                        Rpt_OtherDuties re = new Rpt_OtherDuties();
                        if (dr["SYSTEM_USERS_ID"] != DBNull.Value)
                        {
                            re.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                            re.EmpName = Convert.ToString(dr["EMP_NAME"]);
                            re.Post = Convert.ToString(dr["POST"]);
                            re.Bps = Convert.ToString(dr["BPS"]);
                            re.Branch = Convert.ToString(dr["BRANCH_NAME"]);
                        }

                        if (dr["OTHER_DUTY_TYPE_ID"] != DBNull.Value)
                        {                            
                            re.OtherDutyType = Convert.ToString(dr["OTHER_DUTY_TYPE"]);
                        }                       


                        if (dr["DUTY_YEAR"] != DBNull.Value)
                            re.DutyYear = Convert.ToString(dr["DUTY_YEAR"]);
                        re.Remarks = Convert.ToString(dr["DETAILS"]);


                        OtherDuty.Add(re);
                    }
                }

                if (OtherDuty != null) OtherDuty.TrimExcess();
                return OtherDuty;
            }
            finally
            {
                con.Close();

            }

        }
        public List<RptOtherCharges> RptGetOtherCharges(string query)
        {
            SqlCommand cmd = new SqlCommand(query, new DalHelper().GetConnection());
            SqlConnection con = cmd.Connection;

            try
            {
                List<RptOtherCharges> OtherDuty = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    OtherDuty = new List<RptOtherCharges>();
                    while (dr.Read())
                    {
                        RptOtherCharges re = new RptOtherCharges();
                        if (dr["SYSTEM_USERS_ID"] != DBNull.Value)
                        {
                            re.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                            re.EmpName = Convert.ToString(dr["F_NAME"]);
                            re.Post = Convert.ToString(dr["POST"]);
                            re.Bps = Convert.ToString(dr["BPS"]);
                            re.Branch = Convert.ToString(dr["BRANCH"]);
                        }

                        if (dr["OTHER_CHARGE_TYPE_ID"] != DBNull.Value)
                        {
                            re.OtherChargeType = Convert.ToString(dr["EMP_OTHER_CHARGE_TYPE"]);
                        }


                        if (dr["FROM_DATE"] != DBNull.Value)
                            re.FromDate = Convert.ToDateTime(dr["FROM_DATE"]);
                        if (dr["TO_DATE"] != DBNull.Value)
                            re.ToDate = Convert.ToDateTime(dr["TO_DATE"]);
                        re.Remarks = Convert.ToString(dr["REMARKS"]);
                        OtherDuty.Add(re);
                    }
                }

                if (OtherDuty != null) OtherDuty.TrimExcess();
                return OtherDuty;
            }
            finally
            {
                con.Close();

            }

        }

        public List<Rpt_Promotion> GetPromotionHistory(string query)//GET_EMP_PROMOTION_HISTORY
        {
            SqlCommand cmd = new SqlCommand(query, new DalHelper().GetConnection());
            SqlConnection con = cmd.Connection;
            try
            {
               List<Rpt_Promotion> PromHist = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    PromHist = new List<Rpt_Promotion>();
                    while (dr.Read())
                    {
                        Rpt_Promotion Eh = new Rpt_Promotion();
                        Eh.EmpId = Convert.ToInt32(dr["System_Users_id"]);
                        Eh.EmployeeName= Convert.ToString(dr["F_Name"]); 
                        //Eh.EmpPromotionId = Convert.ToInt32(dr["Emp_Promotion_Hist_Id"]);

                        if (dr["Post"] != DBNull.Value)
                        {
                            Eh.Post = Convert.ToString(dr["Post_Desc"]);
                        }

                        if (dr["Dated"] != DBNull.Value)
                            Eh.PromotionDate = Convert.ToDateTime(dr["Dated"]);
                        if (dr["Remarks"] != DBNull.Value)
                            Eh.Remarks = Convert.ToString(dr["Remarks"]);
                        if (dr["Basic_Pay_Scales_Id"] != DBNull.Value)
                        {
                            Eh.BpsDesc = Convert.ToString(dr["BPS_Desc"]);
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
                        //if (dr["Is_Current"] != DBNull.Value)
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
        public List<Rpt_NOC> RptGetNOC(string query)
        {
            SqlCommand cmd = new SqlCommand(query, new DalHelper().GetConnection());
            SqlConnection con = cmd.Connection;

            try
            {
                List<Rpt_NOC> EmpNoc = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    EmpNoc = new List<Rpt_NOC>();
                    while (dr.Read())
                    {
                        Rpt_NOC re = new Rpt_NOC();
                        if (dr["SYSTEM_USERS_ID"] != DBNull.Value)
                        {
                            re.System_Users_Id = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                            re.EmpName = Convert.ToString(dr["F_NAME"]);
                            re.Noc_Type = Convert.ToString(dr["Description"]);
                            re.NocDate = Convert.ToDateTime(dr["NOC_DATE"]);
                            re.Remarks = Convert.ToString(dr["REMARKS"]);
                            re.Bps = Convert.ToString(dr["BPS"]);
                            re.Post = Convert.ToString(dr["Post"]);
                        }

                        EmpNoc.Add(re);
                    }
                }

                if (EmpNoc != null) EmpNoc.TrimExcess();
                return EmpNoc;
            }
            finally
            {
                con.Close();

            }

        }
        public string GetEmpHighestQualification(int SystemUsersId)
        {

           // List<Probation> ea = null;
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[HRM_REPORTS]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_HIGHEST_QUALIFICATION";
                cmd.Parameters.Add("@EmpId", SqlDbType.Int).Value = SystemUsersId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();                 
                        

                        return  Convert.ToString(dr["DEGREE_OBTAINED"]);

                      
                  
                }

                return "Qualification not available" ;
            }
            finally
            {
                con.Close();

            }
        }

        public List<RptCurrentPosting> GetCurrentPostings(string query)
        {
            SqlCommand cmd = new SqlCommand(query, new DalHelper().GetConnection());
            SqlConnection con = cmd.Connection;

            List<RptCurrentPosting> emp = null;
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    emp = new List<RptCurrentPosting>();
                    while (dr.Read())
                    {
                        RptCurrentPosting ad = new RptCurrentPosting();
                        ad.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        ad.EmployeeName = Convert.ToString(dr["f_name"]);
                        ad.Post = Convert.ToString(dr["Post"]);
                        ad.Bps = Convert.ToString(dr["Bps"]);
                        ad.EmployeeStatus = Convert.ToString(dr["Employee_Status"]);
                        ad.Branch = Convert.ToString(dr["Branch"]);
                        if (dr["DATE_FROM"] != DBNull.Value)
                            ad.FromDate = Convert.ToDateTime(dr["DATE_FROM"]);
                        ad.Remarks = Convert.ToString(dr["REMARKS"]);
                        emp.Add(ad);
                    }
                }
                dr.Close();
                cmd.Dispose();
                // }
                if (emp != null) emp.TrimExcess();
                return emp;
            }
        }
        public List<EmpSearchList> EmployyesBranch(string query)
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
                            ad.Branch= Convert.ToString(dr["Branch"]);
                            ad.PreviousLeaveCredit = Convert.ToInt32(dr["PREVIOUS_LEAVE_CREDIT"]);
                            if (dr["GOVT_SERVICE_START_DATE"] != DBNull.Value)
                                ad.GovtServiceStartDate = Convert.ToDateTime(dr["GOVT_SERVICE_START_DATE"]);
                            if (dr["House_Service_Start_Date"] != DBNull.Value)
                                ad.HouseServiceStartDate = Convert.ToDateTime(dr["House_Service_Start_Date"]);
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
        public List<PopSuperannuation> GetPopSuperannuation()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_14_MONTHS_SUPERANNUATION";
                cmd.CommandType = CommandType.StoredProcedure;
                List<PopSuperannuation> popsupernnuations = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    {
                        popsupernnuations = new List<PopSuperannuation>();
                        while (dr.Read())
                        {
                            PopSuperannuation ad = new PopSuperannuation();
                            ad.SystemUsersId = Convert.ToInt32(dr["system_users_id"]);
                            ad.EmployeeName = Convert.ToString(dr["f_name"]);
                            ad.Post = Convert.ToString(dr["post"]);
                            ad.Bps = Convert.ToString(dr["bps"]);
                            ad.EmployeeStatus = Convert.ToString(dr["EMP_STATUS"]);
                            ad.SuperannuationDate= Convert.ToDateTime(dr["SUPDATE"]);
                        popsupernnuations.Add(ad);
                        }
                    }

                    if (popsupernnuations != null) popsupernnuations.TrimExcess();
                    return popsupernnuations;
                }
            finally
            {
                con.Close();
            }
        }
        public List<PopProbation> GetPopProbation()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SIX_MONTHS_PROBATIONS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<PopProbation> popprobation = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    popprobation = new List<PopProbation>();
                    while (dr.Read())
                    {
                        PopProbation ad = new PopProbation();
                        ad.SystemUsersId = Convert.ToInt32(dr["system_users_id"]);
                        ad.EmployeeName = Convert.ToString(dr["f_name"]);
                        ad.Post = Convert.ToString(dr["post"]);
                        ad.Bps = Convert.ToString(dr["bps"]);
                        ad.EmployeeStatus = Convert.ToString(dr["EMPL_STATUS"]);
                        ad.ProbationType= Convert.ToString(dr["PROBATION_TYPE"]);
                        ad.ProbationEndDate = Convert.ToDateTime(dr["PROBATION_TO"]);
                        ad.Remarks = Convert.ToString(dr["REMARKS"]);
                        popprobation.Add(ad);
                    }
                }

                if (popprobation != null) popprobation.TrimExcess();
                return popprobation;
            }
            finally
            {
                con.Close();
            }
        }
       
        public List<PopEmployment> GetPopEmployment()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SIX_MONTHS_EMPLOYMENT";
                cmd.CommandType = CommandType.StoredProcedure;
                List<PopEmployment> popemployment = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    popemployment = new List<PopEmployment>();
                    while (dr.Read())
                    {
                        PopEmployment ad = new PopEmployment();
                        ad.SystemUsersId = Convert.ToInt32(dr["system_users_id"]);
                        ad.EmployeeName = Convert.ToString(dr["f_name"]);
                        ad.Post = Convert.ToString(dr["post"]);
                        ad.Bps = Convert.ToString(dr["bps"]);
                        ad.EmployeeStatus = Convert.ToString(dr["EMPL_STATUS"]);
                        ad.EndDate = Convert.ToDateTime(dr["TO_DATE"]);
                        ad.Remarks = Convert.ToString(dr["REMARKS"]);
                        popemployment.Add(ad);
                    }
                }

                if (popemployment != null) popemployment.TrimExcess();
                return popemployment;
            }
            finally
            {
                con.Close();
            }
        }

        public List<EmpSearchList> SearchEmploymentsMade(string query)
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
                            ad.PreviousLeaveCredit = Convert.ToInt32(dr["PREVIOUS_LEAVE_CREDIT"]);
                            if (dr["GOVT_SERVICE_START_DATE"] != DBNull.Value)
                                ad.GovtServiceStartDate = Convert.ToDateTime(dr["GOVT_SERVICE_START_DATE"]);
                            if (dr["House_Service_Start_Date"] != DBNull.Value)
                                ad.HouseServiceStartDate = Convert.ToDateTime(dr["House_Service_Start_Date"]);
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
                            ad.ImageUrl = Convert.ToString(dr["ImageUrl"]);
                            if (dr["OTHER_EMPL_QUOTA"] != DBNull.Value)
                                ad.OtherEmploymentQuota= Convert.ToString(dr["OTHER_EMPL_QUOTA"]);
                            ad =GetAppoinmentDetails(ad);
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
        public EmpSearchList GetAppoinmentDetails(EmpSearchList EmpDetails)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[HRM_REPORTS]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMPLOYEE_APPOINTMENT_DETAILS";
                cmd.Parameters.Add("@EmpId", SqlDbType.Int).Value = EmpDetails.EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    {
                      EmpDetails.AppointmentPost= Convert.ToString(dr["POST"]);
                        EmpDetails.AppointmentBps = Convert.ToString(dr["BPS"]);
                        EmpDetails.AppointmentEmplStatus = Convert.ToString(dr["EMPL_STATUS"]);
                        EmpDetails.AppointmentDate = Convert.ToDateTime(dr["CURRENT_STATUS_DATE"]);
                        EmpDetails.AppointmentBpsId = Convert.ToInt32(dr["BPS_ID"]);

                    }
                }


                return EmpDetails;
            }
            finally
            {
                con.Close();
            }
        }
        public List<EmpSearchList> PromotionReport(string query)
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
                           // ad.EmpAddress = Convert.ToString(dr["perm_address"]);
                            ad.EmpDesignation = Convert.ToString(dr["post"]);
                            ad.Bps = Convert.ToString(dr["bps"]);
                           // ad.Empstatus = Convert.ToString(dr["empl_status"]);
                           // ad.PreviousLeaveCredit = Convert.ToInt32(dr["PREVIOUS_LEAVE_CREDIT"]);
                            //if (dr["GOVT_SERVICE_START_DATE"] != DBNull.Value)
                            //    ad.GovtServiceStartDate = Convert.ToDateTime(dr["GOVT_SERVICE_START_DATE"]);
                            //if (dr["House_Service_Start_Date"] != DBNull.Value)
                            //    ad.HouseServiceStartDate = Convert.ToDateTime(dr["House_Service_Start_Date"]);
                           // ad.Filenumber = Convert.ToString(dr["file_no"]);
                          //  if (dr["Personal_No"] != DBNull.Value)
                           //     ad.PersonalNumber = Convert.ToDouble(dr["Personal_No"]);
                          //  ad.Age = Convert.ToString(dr["age"]);
                          //  ad.LocalAddress = Convert.ToString(dr["Local_address"]);
                           // ad.EmailAddress = Convert.ToString(dr["Email"]);
                           // if (dr["EnteredBy"] != DBNull.Value)
                           //     ad.EnteredBy = Convert.ToString(dr["EnteredBy"]);
                           // if (dr["EnteredOn"] != DBNull.Value)
                            //    ad.EnteredOn = Convert.ToDateTime(dr["EnteredOn"]);
                           // if (dr["RecheckedBy"] != DBNull.Value)
                           //     ad.RecheckedBy = Convert.ToString(dr["RecheckedBy"]);
                           // ad.ImageUrl = Convert.ToString(dr["ImageUrl"]);
                            ad.promotion.PromotionType= Convert.ToString(dr["Promotion_Type"]);
                            ad.promotion.PromotionMode = Convert.ToString(dr["Promotion_Mode"]);
                            ad.promotion.Post= Convert.ToString(dr["Promotion_Post"]);
                            ad.promotion.Remarks = Convert.ToString(dr["Remarks"]);
                            ad.promotion.PromotionDate = Convert.ToDateTime(dr["Dated"]);
                            ad.promotion.BpsDesc = Convert.ToString(dr["Promotion_Bps"]);
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
        public int Get2017Leaves(int SystemUsersId)
        {
            int EmpLeaves = 0;
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[HRM_REPORTS]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMPLOYEE_2017_LEAVES";
                cmd.Parameters.Add("@EmpId", SqlDbType.Int).Value = SystemUsersId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    {
                        EmpLeaves = Convert.ToInt32(dr["LeaveDays"]);

                    }
                }


                return EmpLeaves;
            }
            finally
            {
                con.Close();
            }
        }

    }


    }

