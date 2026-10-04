using EstablishmentENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EstablishmentDAL
{
    public class EmploymentDAL
    {
        public List<EmpHistory> GetRegEmployment(int SystemUserId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_REG_EMPLOYMENT";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = SystemUserId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<EmpHistory> RegEmpl = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    RegEmpl = new List<EmpHistory>();
                    while (dr.Read())
                    {
                        EmpHistory re = new EmpHistory();
                        if (dr["EMP_EMPLOYMENT_HIST_ID"] != DBNull.Value)
                            re.EmploymentHistoryId = Convert.ToInt32(dr["EMP_EMPLOYMENT_HIST_ID"]);
                        if (dr["SYSTEM_USERS_ID"] != DBNull.Value)
                            re.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        if (dr["POST_ID"] != DBNull.Value)
                        {
                            re.PostId = Convert.ToInt32(dr["POST_ID"]);
                            re.Post = Convert.ToString(dr["POST"]);
                        }
                        if (dr["BPS_ID"] != DBNull.Value)
                        {
                            re.BpsId = Convert.ToInt32(dr["BPS_ID"]);
                            re.BPS = Convert.ToString(dr["BPS"]);
                        }
                        if (dr["POST_STATUS_ID"] != DBNull.Value)
                        {
                            re.PostStatusId = Convert.ToInt32(dr["POST_STATUS_ID"]);
                            re.PostStatus = Convert.ToString(dr["POST_STATUS"]);
                        }
                        if (dr["IS_GAZETTED"] != DBNull.Value)
                            re.IsGazetted = Convert.ToInt32(dr["IS_GAZETTED"]);
                        if (dr["IS_CURRENT"] != DBNull.Value)
                            re.IsCurrent = Convert.ToInt32(dr["IS_CURRENT"]);
                        if (dr["EMPL_STATUS_ID"] != DBNull.Value)
                        {
                            re.EmploymentStatusId = Convert.ToInt32(dr["EMPL_STATUS_ID"]);
                            re.EmploymentStatus = Convert.ToString(dr["EMPL_STATUS"]);

                        }

                        if (dr["STATUS_DATE"] != DBNull.Value)
                            re.EmploymentStatusDate = Convert.ToDateTime(dr["STATUS_DATE"]);
                        if (dr["CURRENT_STATUS_ID"] != DBNull.Value)
                        {
                            re.CurrentStatusId = Convert.ToInt32(dr["CURRENT_STATUS_ID"]);
                            re.CurrentStatus = Convert.ToString(dr["CURRENT_STATUS"]);
                        }
                        if (dr["CURRENT_STATUS_DATE"] != DBNull.Value)
                            re.CurrentStatusDate = Convert.ToDateTime(dr["CURRENT_STATUS_DATE"]);
                        if (dr["REMARKS"] != DBNull.Value)
                            re.Remarks = Convert.ToString(dr["REMARKS"]);

                        RegEmpl.Add(re);
                    }
                }

                if (RegEmpl != null) RegEmpl.TrimExcess();
                return RegEmpl;
            }
            finally
            {
                con.Close();

            }

        }
        public int GetServingStatus(int SystemUserId, int EmpHistoryId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SERVING_STATUS";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = SystemUserId;
                cmd.Parameters.Add("@EmploymentHistoryId", SqlDbType.Int).Value = EmpHistoryId;
                cmd.CommandType = CommandType.StoredProcedure;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                        return 1;
                    else
                        return 0;
                }
            }
            finally
            {
                con.Close();

            }

        }

        public void InsertRegularEmployment(RegularEmployee eh)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_EMPL_HISTORY";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = eh.SystemUsersId;
                cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = eh.PostId;
                cmd.Parameters.Add("@Bps", SqlDbType.Int).Value = eh.BpsId;
                cmd.Parameters.Add("@PostStatus", SqlDbType.Int).Value = eh.PostStatusId;
                cmd.Parameters.Add("@IsGazetted", SqlDbType.Int).Value = eh.IsGazetted;
                cmd.Parameters.Add("@IsCurrent", SqlDbType.Int).Value = eh.IsCurrent;
                cmd.Parameters.Add("@EmploymentStatusId", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@CurrentStatusId", SqlDbType.Int).Value = eh.CurrentStatusId;
                cmd.Parameters.Add("@EmploymentStatusDate", SqlDbType.DateTime).Value = eh.EmploymentStatusDate;
                cmd.Parameters.Add("@CurrentStatusDate", SqlDbType.DateTime).Value = eh.CurrentStatusDate;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = eh.Remarks;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.Connection = con;
                cmd.ExecuteScalar();
                AuditLogger.LogCommand(cmd);
                string id = cmd.Parameters["@ID"].Value.ToString();
                eh.EmploymentHistoryId = Convert.ToInt32(id);
                InsertEmploymentProbation(eh);
                if (eh.IsCurrent == 1)
                {

                    UpdateRegEmployment(eh);
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
        public void UpdateMainEmployment(int SystemUsersId)
        {


        }
        public void UpdateEmpEmployment(RegularEmployee eh)
        {

            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_EMPL_HISTORY";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmploymentHistoryId", SqlDbType.Int).Value = eh.EmploymentHistoryId;
            cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = eh.PostId;
            cmd.Parameters.Add("@Bps", SqlDbType.Int).Value = eh.BpsId;
            cmd.Parameters.Add("@PostStatus", SqlDbType.Int).Value = eh.PostStatusId;
            cmd.Parameters.Add("@IsGazetted", SqlDbType.Int).Value = eh.IsGazetted;
            cmd.Parameters.Add("@IsCurrent", SqlDbType.Int).Value = eh.IsCurrent;
            cmd.Parameters.Add("@EmploymentStatusId", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@CurrentStatusId", SqlDbType.Int).Value = eh.CurrentStatusId;
            cmd.Parameters.Add("@EmploymentStatusDate", SqlDbType.Date).Value = eh.EmploymentStatusDate;
            cmd.Parameters.Add("@CurrentStatusDate", SqlDbType.Date).Value = eh.CurrentStatusDate;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = eh.Remarks;

            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
                if (eh.IsCurrent == 1)
                {
                    UpdateRegEmployment(eh);
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

        public void InsertEmploymentProbation(RegularEmployee prob)
        {
            Probation pr = new Probation();
            pr.SystemUserId = prob.SystemUsersId;
            pr.ProbationFrom = prob.ProbationFrom;
            pr.ProbationTo = prob.ProbationTo;

            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_REGULAR_PROBATION";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = prob.SystemUsersId;
            cmd.Parameters.Add("@EmploymentHistoryId", SqlDbType.Int).Value = prob.EmploymentHistoryId;
            cmd.Parameters.Add("@Probation_From", SqlDbType.Date).Value = prob.ProbationFrom;
            cmd.Parameters.Add("@Probation_To", SqlDbType.Date).Value = prob.ProbationTo;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteScalar();
                AuditLogger.LogCommand(cmd);
                string id = cmd.Parameters["@ID"].Value.ToString();
                pr.ProbationId = Convert.ToInt32(id);
                UpdateMainProbation(pr);

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

        public void DeleteRegularEmployment(int EmploymentHistId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_REG_EMPLOYMENT";
            cmd.Parameters.Add("@EmploymentHistoryId", SqlDbType.Int).Value = EmploymentHistId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            AuditLogger.LogCommand(cmd);
            con.Close();

        }
        #region PROBATION
        public List<Probation> GetEmployeeProbations(int Empid)
        {
            List<Probation> ea = null;
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMPLOYEE_PROBATIONS";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = Empid;
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
        public List<Probation> GetPromotionProbations(int Empid)
        {
            List<Probation> ea = null;
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PROMOTION_PROBATIONS";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = Empid;
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
        public void InsertProbation(Probation prob)
        {

            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_PROBATION";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = prob.SystemUserId;
            cmd.Parameters.Add("@EmploymentHistoryId", SqlDbType.Int).Value = prob.EmploymentHistId;
            cmd.Parameters.Add("@ProbationTypeId", SqlDbType.Int).Value = prob.ProbationTypeId;
            cmd.Parameters.Add("@Probation_From", SqlDbType.Date).Value = prob.ProbationFrom;
            cmd.Parameters.Add("@Probation_To", SqlDbType.Date).Value = prob.ProbationTo;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = prob.Remarks;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteScalar();
                AuditLogger.LogCommand(cmd);
                string id = cmd.Parameters["@ID"].Value.ToString();
                prob.ProbationId = Convert.ToInt32(id);
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
        public void UpdateProbation(Probation prob)
        {

            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_PROBATION";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = prob.SystemUserId;
            cmd.Parameters.Add("@Probation_Id", SqlDbType.Int).Value = prob.ProbationId;
            cmd.Parameters.Add("@EmploymentHistoryId", SqlDbType.Int).Value = prob.EmploymentHistId;
            cmd.Parameters.Add("@ProbationTypeId", SqlDbType.Int).Value = prob.ProbationTypeId;
            cmd.Parameters.Add("@Probation_From", SqlDbType.Date).Value = prob.ProbationFrom;
            cmd.Parameters.Add("@Probation_To", SqlDbType.Date).Value = prob.ProbationTo;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = prob.Remarks;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
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
        public void UpdatePromProbation(Probation prob)
        {

            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_PROM_PROBATION";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = prob.SystemUserId;
            cmd.Parameters.Add("@Probation_Id", SqlDbType.Int).Value = prob.ProbationId;
            cmd.Parameters.Add("@EmpPromotionId", SqlDbType.Int).Value = prob.PromotionId;
            cmd.Parameters.Add("@ProbationTypeId", SqlDbType.Int).Value = prob.ProbationTypeId;
            cmd.Parameters.Add("@Probation_From", SqlDbType.Date).Value = prob.ProbationFrom;
            cmd.Parameters.Add("@Probation_To", SqlDbType.Date).Value = prob.ProbationTo;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = prob.Remarks;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
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
        public void InsertPromProbation(Probation prob)
        {

            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_PROM_PROBATION";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = prob.SystemUserId;
            cmd.Parameters.Add("@EmpPromotionId", SqlDbType.Int).Value = prob.PromotionId;
            cmd.Parameters.Add("@ProbationTypeId", SqlDbType.Int).Value = prob.ProbationTypeId;
            cmd.Parameters.Add("@Probation_From", SqlDbType.Date).Value = prob.ProbationFrom;
            cmd.Parameters.Add("@Probation_To", SqlDbType.Date).Value = prob.ProbationTo;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = prob.Remarks;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteScalar();
                AuditLogger.LogCommand(cmd);
                string id = cmd.Parameters["@ID"].Value.ToString();
                prob.ProbationId = Convert.ToInt32(id);
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
        public void DeleteProbation(int ProbationId, int EmpId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_PROBATION";
            cmd.Parameters.Add("@Probation_Id", SqlDbType.Int).Value = ProbationId;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
                int MaxProbId = GetMaxProbationId(EmpId);
                if (MaxProbId != 0)
                {
                    DeleteMainProbation(GetProbation(MaxProbId));
                }
                else
                {
                    Probation prob = new Probation();
                    prob.SystemUserId = EmpId;
                    prob.ProbationId = null;
                    prob.ProbationFrom = null;
                    prob.ProbationTo = null;
                    DeleteMainProbation(prob);
                }


            }
            finally
            {
                con.Close();
            }

        }
        public int GetMaxProbationId(int SystemUsersId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PROBATION_MAX_ID";
            cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = SystemUsersId;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                    return Convert.ToInt32(dr["PROBATION_ID"]);
                else
                    return 0;
            }
            finally
            {
                con.Close();
            }
        }
        public Probation GetProbation(int ProbationId)
        {
            Probation prob = new Probation();
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PROBATION";
                cmd.Parameters.Add("@Probation_Id", SqlDbType.Int).Value = ProbationId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    {
                        prob.ProbationId = Convert.ToInt32(dr["Probation_Id"]);
                        prob.SystemUserId = Convert.ToInt32(dr["System_Users_Id"]);
                        if (dr["Probation_From"] != DBNull.Value)
                            prob.ProbationFrom = Convert.ToDateTime(dr["Probation_From"]);
                        if (dr["Probation_To"] != DBNull.Value)
                            prob.ProbationTo = Convert.ToDateTime(dr["Probation_To"]);


                    }
                }
                return prob;
            }
            finally
            {
                con.Close();

            }



        }
        public int GetProbationId(int SystemUsersId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PROBATION_ID";
            cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = SystemUsersId;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                    if (dr["PROBATION_ID"] != DBNull.Value)
                        return Convert.ToInt32(dr["PROBATION_ID"]);
                    else
                        return 0;
                else
                    return 0;
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateMainProbation(Probation prob)
        {

            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MAIN_PROBATION";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = prob.SystemUserId;
            cmd.Parameters.Add("@Probation_Id", SqlDbType.Int).Value = prob.ProbationId;
            cmd.Parameters.Add("@Probation_From", SqlDbType.Date).Value = prob.ProbationFrom;
            cmd.Parameters.Add("@Probation_To", SqlDbType.Date).Value = prob.ProbationTo;
            cmd.Connection = con;
            try
            {
                int probationId = GetMaxProbationId(prob.SystemUserId);
                Probation ExistProb = GetProbation(probationId);

                if (ExistProb.ProbationTo <= prob.ProbationTo)
                {
                    cmd.ExecuteReader();
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
        public void DeleteMainProbation(Probation prob)
        {

            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MAIN_PROBATION";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = prob.SystemUserId;
            cmd.Parameters.Add("@Probation_Id", SqlDbType.Int).Value = prob.ProbationId;
            cmd.Parameters.Add("@Probation_From", SqlDbType.Date).Value = prob.ProbationFrom;
            cmd.Parameters.Add("@Probation_To", SqlDbType.Date).Value = prob.ProbationTo;
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
        }
        #endregion PROBATION

        #region EMPLOYMENT
        public void UpdateRegEmployment(RegularEmployee eh)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            List<PromotionHistory> ph = new List<PromotionHistory>();
            ph = new EmployeeDAL().GetPromotionHistory(eh.SystemUsersId);
            var result = new PromotionHistory();
            if (ph != null)
                result = ph.OrderByDescending(t => t.PromotionDate).First();
            if (ph == null || (eh.CurrentStatusDate > result.PromotionDate && eh.BpsId>result.Bps))
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_REG_EMPLOYMENT";
            else
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_REG_EMPLOYMENT_STATUS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = eh.SystemUsersId;
                cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = eh.PostId;
                cmd.Parameters.Add("@Bps", SqlDbType.Int).Value = eh.BpsId;
                cmd.Parameters.Add("@PostStatus", SqlDbType.Int).Value = eh.PostStatusId;
                cmd.Parameters.Add("@IsGazetted", SqlDbType.Int).Value = eh.IsGazetted;
                cmd.Parameters.Add("@EmploymentStatusId", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@CurrentStatusId", SqlDbType.Int).Value = eh.CurrentStatusId;
                cmd.Parameters.Add("@CurrentStatusDate", SqlDbType.Date).Value = eh.CurrentStatusDate;
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

        }
        public void UpdateOtherEmploymentDetails(EmpHistory eh)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            List<PromotionHistory> ph = new List<PromotionHistory>();
            ph = new EmployeeDAL().GetPromotionHistory(eh.SystemUsersId);
            var result = new PromotionHistory();
            if (ph != null)
                result = ph.OrderByDescending(t => t.PromotionDate).First();
            if (ph == null || eh.CurrentStatusDate > result.PromotionDate)
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_REG_EMPLOYMENT";
            else
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_REG_EMPLOYMENT_STATUS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = eh.SystemUsersId;
            cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = eh.PostId;
            cmd.Parameters.Add("@Bps", SqlDbType.Int).Value = eh.BpsId;
            cmd.Parameters.Add("@PostStatus", SqlDbType.Int).Value = eh.PostStatusId;
            cmd.Parameters.Add("@IsGazetted", SqlDbType.Int).Value = eh.IsGazetted;
            cmd.Parameters.Add("@EmploymentStatusId", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@CurrentStatusId", SqlDbType.Int).Value = eh.CurrentStatusId;
            cmd.Parameters.Add("@CurrentStatusDate", SqlDbType.Date).Value = eh.CurrentStatusDate;
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

        }



        public void UpdatePromEmployment(PromotionHistory eh)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_PROM_EMPLOYMENT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = eh.EmpId;
            cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = eh.PostId;
            cmd.Parameters.Add("@Bps", SqlDbType.Int).Value = eh.Bps;
            cmd.Parameters.Add("@IsGazetted", SqlDbType.Int).Value = eh.IsGazetted;

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

        }

        public void UpdatePostingEmployment(int EmpId, int BranchId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_EMPLOYMENT_BRANCH";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
            cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = BranchId;

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

        }

        #endregion EMPLOYMENT
        #region OTHER-EMPLOYMENTS

        public List<EmpHistory> GetEmpHistory(int SystemUserId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_OTHER_EMPL";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = SystemUserId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<EmpHistory> OtherEmpl = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    OtherEmpl = new List<EmpHistory>();
                    while (dr.Read())
                    {
                        EmpHistory re = new EmpHistory();
                        if (dr["EMP_EMPLOYMENT_HIST_ID"] != DBNull.Value)
                            re.EmploymentHistoryId = Convert.ToInt32(dr["EMP_EMPLOYMENT_HIST_ID"]);
                        if (dr["SYSTEM_USERS_ID"] != DBNull.Value)
                            re.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        if (dr["POST_ID"] != DBNull.Value)
                        {
                            re.PostId = Convert.ToInt32(dr["POST_ID"]);
                            re.Post = Convert.ToString(dr["POST"]);
                        }
                        if (dr["BPS_ID"] != DBNull.Value)
                        {
                            re.BpsId = Convert.ToInt32(dr["BPS_ID"]);
                            re.BPS = Convert.ToString(dr["BPS"]);
                        }
                        if (dr["POST_STATUS_ID"] != DBNull.Value)
                        {
                            re.PostStatusId = Convert.ToInt32(dr["POST_STATUS_ID"]);
                            re.PostStatus = Convert.ToString(dr["POST_STATUS"]);
                        }
                        if (dr["IS_GAZETTED"] != DBNull.Value)
                            re.IsGazetted = Convert.ToInt32(dr["IS_GAZETTED"]);
                        if (dr["EMPL_STATUS_ID"] != DBNull.Value)
                        {
                            re.EmploymentStatusId = Convert.ToInt32(dr["EMPL_STATUS_ID"]);
                            re.EmploymentStatus = Convert.ToString(dr["EMPL_STATUS"]);
                        }
                        if (dr["STATUS_DATE"] != DBNull.Value)
                            re.EmploymentStatusDate = Convert.ToDateTime(dr["STATUS_DATE"]);
                        if (dr["OTHER_EMPL_QUOTA_ID"] != DBNull.Value)
                        {
                            re.QuotaId = Convert.ToInt32(dr["OTHER_EMPL_QUOTA_ID"]);
                            re.Quota = Convert.ToString(dr["OTHER_EMPL_QUOTA"]);
                        }

                        if (dr["TO_DATE"] != DBNull.Value)
                            re.ToDate = Convert.ToDateTime(dr["TO_DATE"]);
                        if (dr["DETAILS"] != DBNull.Value)
                            re.Details = Convert.ToString(dr["DETAILS"]);
                        if (dr["CURRENT_STATUS_ID"] != DBNull.Value)
                        {
                            re.CurrentStatusId = Convert.ToInt32(dr["CURRENT_STATUS_ID"]);
                            re.CurrentStatus = Convert.ToString(dr["CURRENT_STATUS"]);
                        }
                        if (dr["CURRENT_STATUS_DATE"] != DBNull.Value)
                            re.CurrentStatusDate = Convert.ToDateTime(dr["CURRENT_STATUS_DATE"]);
                        if (dr["REMARKS"] != DBNull.Value)
                            re.Remarks = Convert.ToString(dr["REMARKS"]);
                        OtherEmpl.Add(re);
                    }
                }
                if (OtherEmpl != null) OtherEmpl.TrimExcess();
                return OtherEmpl;
            }
            finally
            {
                con.Close();

            }

        }


        public void InsertOtherEmployment(EmpHistory eh)
        {

            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_EMPL_HISTORY";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = eh.SystemUsersId;
            cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = eh.PostId;
            cmd.Parameters.Add("@Bps", SqlDbType.Int).Value = eh.BpsId;
            cmd.Parameters.Add("@PostStatus", SqlDbType.Int).Value = eh.PostStatusId;
            cmd.Parameters.Add("@IsGazetted", SqlDbType.Int).Value = eh.IsGazetted;
            cmd.Parameters.Add("@EmploymentStatusId", SqlDbType.Int).Value = eh.EmploymentStatusId;
            cmd.Parameters.Add("@EmploymentStatusDate", SqlDbType.Date).Value = eh.EmploymentStatusDate;
            cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = eh.ToDate;
            cmd.Parameters.Add("@QuotaId", SqlDbType.Int).Value = eh.QuotaId;
            cmd.Parameters.Add("@Details", SqlDbType.VarChar).Value = eh.Details;
            cmd.Parameters.Add("@CurrentStatusId", SqlDbType.Int).Value = eh.CurrentStatusId;
            cmd.Parameters.Add("@CurrentStatusDate", SqlDbType.Date).Value = eh.CurrentStatusDate;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = eh.Remarks;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteScalar();
                AuditLogger.LogCommand(cmd);
                if (eh.IsCurrent == 1)
                {
                    UpdateOtherEmploymentDetails(eh);
                }

                //string id = cmd.Parameters["@ID"].Value.ToString();
                //eh.EmploymentHistoryId = Convert.ToInt32(id);
                //eh.EmplOutTypeId = 1;
                //InsertDetails(eh);
                //if (eh.CurrentStatusId == 9)
                //{
                //  UpdateOtherEmploymentDetails(eh);
                // }

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
        public void UpdateOtherEmployment(EmpHistory eh)
        {

            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_EMPL_HISTORY";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmploymentHistoryId", SqlDbType.Int).Value = eh.EmploymentHistoryId;
            cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = eh.SystemUsersId;
            cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = eh.PostId;
            cmd.Parameters.Add("@Bps", SqlDbType.Int).Value = eh.BpsId;
            cmd.Parameters.Add("@PostStatus", SqlDbType.Int).Value = eh.PostStatusId;
            cmd.Parameters.Add("@IsGazetted", SqlDbType.Int).Value = eh.IsGazetted;
            cmd.Parameters.Add("@EmploymentStatusId", SqlDbType.Int).Value = eh.EmploymentStatusId;
            cmd.Parameters.Add("@EmploymentStatusDate", SqlDbType.Date).Value = eh.EmploymentStatusDate;
            cmd.Parameters.Add("@QuotaId", SqlDbType.Int).Value = eh.QuotaId;
            cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = eh.ToDate;
            cmd.Parameters.Add("@Details", SqlDbType.VarChar).Value = eh.Details;
            cmd.Parameters.Add("@CurrentStatusId", SqlDbType.Int).Value = eh.CurrentStatusId;
            cmd.Parameters.Add("@CurrentStatusDate", SqlDbType.Date).Value = eh.CurrentStatusDate;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = eh.Remarks;

            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
                if (eh.CurrentStatusId == 9)
                {
                    UpdateOtherEmploymentDetails(eh);
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
        //public void UpdateOtherEmploymentDetails(EmpHistory eh)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
        //    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_OTHER_EMPLOYMENT";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = eh.SystemUsersId;
        //    cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = eh.PostId;
        //    cmd.Parameters.Add("@Bps", SqlDbType.Int).Value = eh.BpsId;
        //    cmd.Parameters.Add("@PostStatus", SqlDbType.Int).Value = eh.PostStatusId;
        //    cmd.Parameters.Add("@IsGazetted", SqlDbType.Int).Value = eh.IsGazetted;
        //    cmd.Parameters.Add("@EmploymentStatusId", SqlDbType.Int).Value = eh.EmploymentStatusId;
        //    cmd.Parameters.Add("@QuotaId", SqlDbType.Int).Value = eh.QuotaId;
        //    cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = eh.EmploymentStatusDate;
        //    cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = eh.ToDate;
        //    cmd.Parameters.Add("@CurrentStatusId", SqlDbType.Int).Value = eh.CurrentStatusId;
        //    cmd.Parameters.Add("@CurrentStatusDate", SqlDbType.Date).Value = eh.CurrentStatusDate;
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
        public void DeleteOtherEmployment(int Id)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_OTHER_EMPLOYMENT";
                cmd.Parameters.Add("@EmploymentHistoryId", SqlDbType.Int).Value = Id;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }

        }
        //public void InsertDetails(EmpHistory otherEmpl)
        //{

        //    SqlConnection con = new DalHelper().GetConnection();
        //    SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
        //    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_EmplOut";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = otherEmpl.SystemUsersId;
        //    cmd.Parameters.Add("@EmploymentHistoryId", SqlDbType.Int).Value = otherEmpl.EmploymentHistoryId;
        //    cmd.Parameters.Add("@EmplOutFrom", SqlDbType.Date).Value = otherEmpl.EmplOutFrom;
        //    cmd.Parameters.Add("@EmplOutTo", SqlDbType.Date).Value = EmplOut.EmplOutTo;
        //    cmd.Parameters.Add("@EmplOutTypeId", SqlDbType.Int).Value = EmplOut.EmplOutTypeId;
        //    cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = EmplOut.Remarks;
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
        //        con.Dispose();
        //    }

        //}

        #endregion OTHER-EMPLOYMENTS
        #region EMPLOYMENT_OUT
        public void InsertEmploymentOut(EmploymentOut EmplOut)
        {

            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_EMPL_OUT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmplOut.SystemUsersId;
            cmd.Parameters.Add("@EmploymentHistoryId", SqlDbType.Int).Value = EmplOut.EmploymentHistoryId;
            cmd.Parameters.Add("@EmplOutTypeId", SqlDbType.Int).Value = EmplOut.EmploymentOutTypeId;
            cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = EmplOut.FromDate;
            cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = EmplOut.ToDate;
            cmd.Parameters.Add("@OutBps", SqlDbType.Int).Value = EmplOut.OutBps;
            cmd.Parameters.Add("@OutPost", SqlDbType.Int).Value = EmplOut.OutPost;
            cmd.Parameters.Add("@InBps", SqlDbType.Int).Value = EmplOut.InBps;
            cmd.Parameters.Add("@InPost", SqlDbType.Int).Value = EmplOut.InPost;
            cmd.Parameters.Add("@Is_Extended", SqlDbType.Int).Value = EmplOut.IsExtended;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = EmplOut.IsActive;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = EmplOut.Remarks;
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

        }
        public void UpdateEmploymentOut(EmploymentOut EmplOut)
        {

            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_EMPL_OUT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmplOutId", SqlDbType.Int).Value = EmplOut.EmploymentOutId;
            cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmplOut.SystemUsersId;
            cmd.Parameters.Add("@EmploymentHistoryId", SqlDbType.Int).Value = EmplOut.EmploymentHistoryId;
            cmd.Parameters.Add("@EmplOutTypeId", SqlDbType.Int).Value = EmplOut.EmploymentOutTypeId;
            cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = EmplOut.FromDate;
            cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = EmplOut.ToDate;
            cmd.Parameters.Add("@OutBps", SqlDbType.Int).Value = EmplOut.OutBps;
            cmd.Parameters.Add("@OutPost", SqlDbType.Int).Value = EmplOut.OutPost;
            cmd.Parameters.Add("@InBps", SqlDbType.Int).Value = EmplOut.InBps;
            cmd.Parameters.Add("@InPost", SqlDbType.Int).Value = EmplOut.InPost;
            cmd.Parameters.Add("@Is_Extended", SqlDbType.Int).Value = EmplOut.IsExtended;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = EmplOut.IsActive;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = EmplOut.Remarks;
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

        }

        public List<EmploymentOut> GetEmploymentOut(int SystemUserId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMPL_OUT";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = SystemUserId;
                cmd.CommandType = CommandType.StoredProcedure;

                List<EmploymentOut> EmplOutEmp = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    EmplOutEmp = new List<EmploymentOut>();
                    while (dr.Read())
                    {
                        EmploymentOut re = new EmploymentOut();
                        if (dr["EMPL_OUT_ID"] != DBNull.Value)
                            re.EmploymentOutId = Convert.ToInt32(dr["EMPL_OUT_ID"]);

                        if (dr["SYSTEM_USER_ID"] != DBNull.Value)
                            re.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USER_ID"]);

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

                        if (dr["IS_ACTIVE"] != DBNull.Value)
                            re.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
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
        public void DeleteEmploymentOut(int EmplOutId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_EMPL_OUT";
                cmd.Parameters.Add("@EmplOutId", SqlDbType.Int).Value = EmplOutId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }

        }


        #endregion EMPLOYMENT_OUT

        #region EXTENSION DETAILS
        public void InsertExtensionDetails(ExtensionDetails EmplOut)
        {

            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_EMPL_EXT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmplOut.SystemUsersId;
            cmd.Parameters.Add("@EmploymentHistoryId", SqlDbType.Int).Value = EmplOut.EmploymentHistoryId;
            cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = EmplOut.ExtendedTo;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = EmplOut.Remarks;
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

        }
        public void UpdateExtensionDetails(ExtensionDetails EmplOut)
        {

            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_EMPL_EXT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExtensionId", SqlDbType.Int).Value = EmplOut.ExtensionId;
            cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmplOut.SystemUsersId;
            cmd.Parameters.Add("@EmploymentHistoryId", SqlDbType.Int).Value = EmplOut.EmploymentHistoryId;
            cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = EmplOut.ExtendedTo;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = EmplOut.Remarks;
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

        }

        public List<ExtensionDetails> GetExtensionDetails(int SystemUserId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMPL_EXT";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = SystemUserId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ExtensionDetails> EmplOutEmp = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    EmplOutEmp = new List<ExtensionDetails>();
                    while (dr.Read())
                    {
                        ExtensionDetails re = new ExtensionDetails();
                        if (dr["EXTENSION_ID"] != DBNull.Value)
                            re.ExtensionId = Convert.ToInt32(dr["EXTENSION_ID"]);

                        if (dr["SYSTEM_USER_ID"] != DBNull.Value)
                            re.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USER_ID"]);

                        if (dr["EMPL_HISTORY_ID"] != DBNull.Value)

                            re.EmploymentHistoryId = Convert.ToInt32(dr["EMPL_HISTORY_ID"]);


                        if (dr["EXTENDED_TO"] != DBNull.Value)
                            re.ExtendedTo = Convert.ToDateTime(dr["EXTENDED_TO"]);

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
        public void DeleteExtensionDetails(int ExtensionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_EMPL_EXT";
                cmd.Parameters.Add("@ExtensionId", SqlDbType.Int).Value = ExtensionId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }

        }
        #endregion EXTENSION DETAILS
        #region PREVIOUS EMPLOYMENT
        public void InsertPrevEmployments(PrevEmployments EmplOut)
        {

            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_PREV_EMPL";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmplOut.SystemUsersId;
            cmd.Parameters.Add("@Bps", SqlDbType.Int).Value = EmplOut.BPSID;
            cmd.Parameters.Add("@Organization", SqlDbType.VarChar).Value = EmplOut.Organization;
            cmd.Parameters.Add("@Department", SqlDbType.VarChar).Value = EmplOut.Department;
            cmd.Parameters.Add("@Post", SqlDbType.VarChar).Value = EmplOut.Post;
            cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = EmplOut.FromDate;
            cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = EmplOut.ToDate;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = EmplOut.Remarks;
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

        }
        public void UpdatePrevEmployments(PrevEmployments EmplOut)
        {

            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_PREV_EMPL";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PreviousEmplId", SqlDbType.Int).Value = EmplOut.EmpPrevEmplId;
            cmd.Parameters.Add("@Bps", SqlDbType.Int).Value = EmplOut.BPSID;
            cmd.Parameters.Add("@Organization", SqlDbType.VarChar).Value = EmplOut.Organization;
            cmd.Parameters.Add("@Department", SqlDbType.VarChar).Value = EmplOut.Department;
            cmd.Parameters.Add("@Post", SqlDbType.VarChar).Value = EmplOut.Post;
            cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = EmplOut.FromDate;
            cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = EmplOut.ToDate;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = EmplOut.Remarks;
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

        }

        public List<PrevEmployments> GetPrevEmployments(int SystemUserId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PREV_EMPL";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = SystemUserId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<PrevEmployments> PrevEmp = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    PrevEmp = new List<PrevEmployments>();
                    while (dr.Read())
                    {
                        PrevEmployments re = new PrevEmployments();
                        if (dr["PREVIOUS_EMPL_ID"] != DBNull.Value)
                            re.EmpPrevEmplId = Convert.ToInt32(dr["PREVIOUS_EMPL_ID"]);

                        if (dr["SYSTEM_USERS_ID"] != DBNull.Value)
                            re.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);

                        if (dr["ORGANIZATION"] != DBNull.Value)
                            re.Organization = Convert.ToString(dr["ORGANIZATION"]);

                        if (dr["DEPARTMENT"] != DBNull.Value)
                            re.Department = Convert.ToString(dr["DEPARTMENT"]);

                        if (dr["POST"] != DBNull.Value)
                            re.Post = Convert.ToString(dr["POST"]);

                        if (dr["BPSID"] != DBNull.Value)
                        {
                            re.BPSID = Convert.ToInt32(dr["BPSID"]);
                            re.BPS = Convert.ToString(dr["BPS"]);
                        }
                        if (dr["FROM_DATE"] != DBNull.Value)
                            re.FromDate = Convert.ToDateTime(dr["FROM_DATE"]);

                        if (dr["TO_DATE"] != DBNull.Value)
                            re.ToDate = Convert.ToDateTime(dr["TO_DATE"]);

                        re.Remarks = Convert.ToString(dr["REMARKS"]);


                        PrevEmp.Add(re);
                    }
                }
                if (PrevEmp != null) PrevEmp.TrimExcess();
                return PrevEmp;
            }
            finally
            {
                con.Close();

            }

        }
        public void DeletePrevEmployments(int EmplOutId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_PREV_EMPL";
                cmd.Parameters.Add("@PreviousEmplId", SqlDbType.Int).Value = EmplOutId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }

        }
        #endregion PREVIOUS EMPLOYMENT
        #region EMPLOYEE OTHER CHARGES
        public List<OtherCharges> GetOtherCharges(int EmpId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_OTHER_CHARGES";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<OtherCharges> EmpPosting = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    EmpPosting = new List<OtherCharges>();
                    while (dr.Read())
                    {
                        OtherCharges Eh = new OtherCharges();
                        Eh.SystemUserId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        Eh.OtherChargeId = Convert.ToInt32(dr["EMP_OTHER_CHARGE_ID"]);
                        if (dr["OTHER_CHARGE_TYPE_ID"] != DBNull.Value)
                        {
                            Eh.OtherChargeTypeId = Convert.ToInt32(dr["OTHER_CHARGE_TYPE_ID"]);
                            Eh.OtherChargeType = Convert.ToString(dr["EMP_OTHER_CHARGE_TYPE"]);
                        }
                        Eh.BPSID = Convert.ToInt32(dr["BPS_ID"]);
                        Eh.BPS = Convert.ToString(dr["BPS"]);
                        Eh.PostId = Convert.ToInt32(dr["Posts_ID"]);
                        Eh.Post = Convert.ToString(dr["Post"]);
                        if (dr["Branch_Id"] != DBNull.Value)
                        {
                            Eh.BranchId = Convert.ToInt32(dr["Branch_Id"]);
                            Eh.Branch = Convert.ToString(dr["Branch"]);
                        }
                        if (dr["FROM_DATE"] != DBNull.Value)
                            Eh.FromDate = Convert.ToDateTime(dr["FROM_DATE"]);
                        if (dr["TO_DATE"] != DBNull.Value)
                            Eh.ToDate = Convert.ToDateTime(dr["TO_DATE"]);

                        Eh.Remarks = Convert.ToString(dr["Remarks"]);
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



        public void UpdateOtherCharges(OtherCharges EmpCharge)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_EMP_OTHER_CHARGE";
                cmd.Parameters.Add("@EmpOtherChargeId", SqlDbType.Int).Value = EmpCharge.OtherChargeId;
                cmd.Parameters.Add("@EmpOtherChargeTypeId", SqlDbType.Int).Value = EmpCharge.OtherChargeTypeId;
                cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = EmpCharge.PostId;
                cmd.Parameters.Add("@Bps", SqlDbType.Int).Value = EmpCharge.BPSID;
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = EmpCharge.BranchId;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = EmpCharge.FromDate;
                if (Convert.ToString(EmpCharge.ToDate) != "01/01/0001 00:00:00")
                    cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = EmpCharge.ToDate;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = EmpCharge.Remarks;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }

        }
        public void InsertOtherCharges(OtherCharges EmpCharge)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_EMP_OTHER_CHARGE";
                cmd.Parameters.Add("@EmpOtherChargeTypeId", SqlDbType.Int).Value = EmpCharge.OtherChargeTypeId;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpCharge.SystemUserId;
                cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = EmpCharge.PostId;
                cmd.Parameters.Add("@Bps", SqlDbType.Int).Value = EmpCharge.BPSID;
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = EmpCharge.BranchId;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = EmpCharge.FromDate;
                if (Convert.ToString(EmpCharge.ToDate) != "01/01/0001 00:00:00")
                    cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = EmpCharge.ToDate;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = EmpCharge.Remarks;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }


        }
        public void DeleteOtherCharges(int PostingId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_EMP_OTHER_CHARGE";
                cmd.Parameters.Add("@EmpOtherChargeId", SqlDbType.Int).Value = PostingId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }

        }
        #endregion EMPLOYEE OTHER CHARGES
        #region SECURITY CLEARANCE
        public List<SecurityClearance> GetSecurityClearance(int EmpId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_SECURITY_CLEARANCE";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<SecurityClearance> SecClearance = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    SecClearance = new List<SecurityClearance>();
                    while (dr.Read())
                    {
                        SecurityClearance Eh = new SecurityClearance();
                        Eh.SystemUserId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        Eh.SecurityClearanceId = Convert.ToInt32(dr["EMP_SEC_CLEARANCE_ID"]);
                        if (dr["SEC_CLEARANCE_TYPE_ID"] != DBNull.Value)
                        {
                            Eh.SecClearanceTypeId = Convert.ToInt32(dr["SEC_CLEARANCE_TYPE_ID"]);
                            Eh.SecClearanceType = Convert.ToString(dr["SEC_CLEARANCE_TYPE"]);
                        }
                        Eh.BPSID = Convert.ToInt32(dr["BPS_ID"]);
                        Eh.BPS = Convert.ToString(dr["BPS"]);
                        Eh.PostId = Convert.ToInt32(dr["Post_ID"]);
                        Eh.Post = Convert.ToString(dr["Post"]);

                        if (dr["DATE_SUBMITTED"] != DBNull.Value)
                            Eh.OnDate = Convert.ToDateTime(dr["DATE_SUBMITTED"]);

                        Eh.Remarks = Convert.ToString(dr["Remarks"]);
                        SecClearance.Add(Eh);
                    }
                }
                if (SecClearance != null) SecClearance.TrimExcess();
                return SecClearance;
            }
            finally
            {
                con.Close();

            }

        }



        public void UpdateSecurityClearance(SecurityClearance EmpSecClearance)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_EMP_SECURITY_CLEARANCE";
                cmd.Parameters.Add("@EmpSecClearanceId", SqlDbType.Int).Value = EmpSecClearance.SecurityClearanceId;
                cmd.Parameters.Add("@SecClearanceTypeId", SqlDbType.Int).Value = EmpSecClearance.SecClearanceTypeId;
                cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = EmpSecClearance.PostId;
                cmd.Parameters.Add("@Bps", SqlDbType.Int).Value = EmpSecClearance.BPSID;
                cmd.Parameters.Add("@OnDate", SqlDbType.Date).Value = EmpSecClearance.OnDate;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = EmpSecClearance.Remarks;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }

        }
        public void InsertSecurityClearance(SecurityClearance EmpSecClearance)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_EMP_SECURITY_CLEARANCE";
                cmd.Parameters.Add("@SecClearanceTypeId", SqlDbType.Int).Value = EmpSecClearance.SecClearanceTypeId;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpSecClearance.SystemUserId;
                cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = EmpSecClearance.PostId;
                cmd.Parameters.Add("@Bps", SqlDbType.Int).Value = EmpSecClearance.BPSID;
                cmd.Parameters.Add("@OnDate", SqlDbType.Date).Value = EmpSecClearance.OnDate;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = EmpSecClearance.Remarks;

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }


        }
        public void DeleteSecurityClearance(int SecClearanceId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_EMP_SECURITY_CLEARANCE";
                cmd.Parameters.Add("@EmpSecClearanceId", SqlDbType.Int).Value = SecClearanceId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }

        }
        #endregion SECURITY CLEARANCE

        #region DISCIPLINARY ACTIONS
        public List<DisciplinaryAction> GetDisciplinaryAction(int EmpId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_DISCIP_ACTION";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<DisciplinaryAction> DisActions = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    DisActions = new List<DisciplinaryAction>();
                    while (dr.Read())
                    {
                        DisciplinaryAction Eh = new DisciplinaryAction();
                        Eh.SystemUserId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        Eh.DisciplinaryActionId = Convert.ToInt32(dr["EMP_DISCIP_ID"]);

                        if (dr["DISCIPLINARY_ACTION_TYPE_ID"] != DBNull.Value)
                        {
                            Eh.DisciplinaryActionTypeId = Convert.ToInt32(dr["DISCIPLINARY_ACTION_TYPE_ID"]);
                            Eh.DisciplinaryActionType = Convert.ToString(dr["DISCIPLINARY_ACTION_TYPE"]);
                        }
                        if (dr["DATE_OF_ISSUE"] != DBNull.Value)
                            Eh.ActionDate = Convert.ToDateTime(dr["DATE_OF_ISSUE"]);
                        Eh.BPSID = Convert.ToInt32(dr["BPS_ID"]);
                        Eh.BPS = Convert.ToString(dr["BPS"]);
                        Eh.PostId = Convert.ToInt32(dr["POSTS_ID"]);
                        Eh.Post = Convert.ToString(dr["Post"]);
                        //if (dr["FROM_DATE"] != DBNull.Value)
                        //    Eh.FromDate = Convert.ToDateTime(dr["FROM_DATE"]);
                        //if (dr["TO_DATE"] != DBNull.Value)
                        //    Eh.ToDate = Convert.ToDateTime(dr["TO_DATE"]);
                        if (dr["FINAL_DISCIP_ACTION_ID"] != DBNull.Value)
                        {
                            Eh.FinalActionTypeId = Convert.ToInt32(dr["FINAL_DISCIP_ACTION_ID"]);
                            Eh.FinalActionType = Convert.ToString(dr["FINAL_DISCIP_ACTION_TYPE"]);
                        }
                        if (dr["FINAL_DISCIP_ACTION_DATE"] != DBNull.Value)
                            Eh.FinalActionDate = Convert.ToDateTime(dr["FINAL_DISCIP_ACTION_DATE"]);

                        Eh.Details = Convert.ToString(dr["Remarks"]);
                        DisActions.Add(Eh);
                    }
                }
                if (DisActions != null) DisActions.TrimExcess();
                return DisActions;
            }
            finally
            {
                con.Close();

            }

        }



        public void UpdateDisciplinaryAction(DisciplinaryAction EmpDiscipAction)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_EMP_DISCIP_ACTION";
                cmd.Parameters.Add("@Idd", SqlDbType.Int).Value = EmpDiscipAction.DisciplinaryActionId;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpDiscipAction.SystemUserId;
                cmd.Parameters.Add("@TypeId", SqlDbType.Int).Value = EmpDiscipAction.DisciplinaryActionTypeId;
                cmd.Parameters.Add("@OnDate", SqlDbType.Date).Value = EmpDiscipAction.ActionDate;
                cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = EmpDiscipAction.PostId;
                cmd.Parameters.Add("@Bps", SqlDbType.Int).Value = EmpDiscipAction.BPSID;
                //cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = EmpDiscipAction.FromDate;
                //cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = EmpDiscipAction.ToDate;
                cmd.Parameters.Add("@FinalActionId", SqlDbType.Int).Value = EmpDiscipAction.FinalActionTypeId;
                if (Convert.ToString(EmpDiscipAction.FinalActionDate) != "01/01/0001 00:00:00")
                    cmd.Parameters.Add("@FinalActionDate", SqlDbType.Date).Value = EmpDiscipAction.FinalActionDate;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = EmpDiscipAction.Details;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertDisciplinaryAction(DisciplinaryAction EmpDiscipAction)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_EMP_DISCIP_ACTION";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpDiscipAction.SystemUserId;
                cmd.Parameters.Add("@TypeId", SqlDbType.Int).Value = EmpDiscipAction.DisciplinaryActionTypeId;
                cmd.Parameters.Add("@OnDate", SqlDbType.Date).Value = EmpDiscipAction.ActionDate;
                cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = EmpDiscipAction.PostId;
                cmd.Parameters.Add("@Bps", SqlDbType.Int).Value = EmpDiscipAction.BPSID;
                //cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = EmpDiscipAction.FromDate;
                //cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = EmpDiscipAction.ToDate;
                cmd.Parameters.Add("@FinalActionId", SqlDbType.Int).Value = EmpDiscipAction.FinalActionTypeId;
                if (Convert.ToString(EmpDiscipAction.FinalActionDate) != "01/01/0001 00:00:00")
                    cmd.Parameters.Add("@FinalActionDate", SqlDbType.Date).Value = EmpDiscipAction.FinalActionDate;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = EmpDiscipAction.Details;

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }


        }
        public void DeleteDisciplinaryAction(int DiscipActionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_EMP_DISCIP_ACTION";
                cmd.Parameters.Add("@Idd", SqlDbType.Int).Value = DiscipActionId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }

        }
        #endregion DISCIPLINARY ACTIONS
        #region PENALTIES
        public List<EmpPenalty> GetEmpPenalties(int EmpId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_PENALTIES";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<EmpPenalty> DisActions = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    DisActions = new List<EmpPenalty>();
                    while (dr.Read())
                    {
                        EmpPenalty Eh = new EmpPenalty();
                        Eh.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        Eh.PenaltyId = Convert.ToInt32(dr["EMP_PENALTIES_ID"]);
                        Eh.DisciplinaryActionId = Convert.ToInt32(dr["EMP_DISCIP_ACTION_ID"]);
                        if (dr["PENALTY_TYPE_ID"] != DBNull.Value)
                        {
                            Eh.PenaltyTypeId = Convert.ToInt32(dr["PENALTY_TYPE_ID"]);
                            Eh.PenaltyType = Convert.ToString(dr["PENALTY_TYPE"]);
                        }
                        if (dr["PENALTY_DATE"] != DBNull.Value)
                            Eh.PenaltyDate = Convert.ToDateTime(dr["PENALTY_DATE"]);
                        Eh.IsMajor = Convert.ToInt32(dr["IS_MAJOR"]);
                        Eh.Remarks = Convert.ToString(dr["Remarks"]);
                        DisActions.Add(Eh);
                    }
                }
                if (DisActions != null) DisActions.TrimExcess();
                return DisActions;
            }
            finally
            {
                con.Close();

            }

        }
        public void UpdateEmpPenalties(EmpPenalty EmpDiscipAction)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_EMP_PENALTIES";
                cmd.Parameters.Add("@PenaltyId", SqlDbType.Int).Value = EmpDiscipAction.PenaltyId;
                cmd.Parameters.Add("@DisciplinaryActionId", SqlDbType.Int).Value = EmpDiscipAction.DisciplinaryActionId;
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = EmpDiscipAction.SystemUsersId;
                cmd.Parameters.Add("@PenaltyTypeId", SqlDbType.Int).Value = EmpDiscipAction.PenaltyTypeId;
                cmd.Parameters.Add("@PenaltyDate", SqlDbType.Date).Value = EmpDiscipAction.PenaltyDate;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = EmpDiscipAction.Remarks;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertEmpPenalties(EmpPenalty EmpDiscipAction)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_EMP_PENALTIES";
                cmd.Parameters.Add("@DisciplinaryActionId", SqlDbType.Int).Value = EmpDiscipAction.DisciplinaryActionId;
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = EmpDiscipAction.SystemUsersId;
                cmd.Parameters.Add("@PenaltyTypeId", SqlDbType.Int).Value = EmpDiscipAction.PenaltyTypeId;
                cmd.Parameters.Add("@PenaltyDate", SqlDbType.Date).Value = EmpDiscipAction.PenaltyDate;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = EmpDiscipAction.Remarks;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }


        }
        public void DeleteEmpPenalties(int EmpPenaltyId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_EMP_PENALTIES";
                cmd.Parameters.Add("@PenaltyId", SqlDbType.Int).Value = EmpPenaltyId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }

        }
        #endregion PENALTIES
        #region RETIREMENT
        public List<EmpRetirement> GetRetirements()
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RETIREMENTS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<EmpRetirement> ERetirements = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    ERetirements = new List<EmpRetirement>();
                    while (dr.Read())
                    {
                        EmpRetirement Eh = new EmpRetirement();
                        Eh.SystemUserId = Convert.ToInt32(dr["SYSTEM_USER_ID"]);
                        Eh.EmpRetirementId = Convert.ToInt32(dr["EMP_RETIREMENT_ID"]);

                        if (dr["RETIREMENT_TYPE_ID"] != DBNull.Value)
                        {
                            Eh.RetirementTypeId = Convert.ToInt32(dr["RETIREMENT_TYPE_ID"]);
                            Eh.RetirementType = Convert.ToString(dr["RETIREMENT_TYPE"]);
                        }
                        if (dr["RETIREMENT_DATE"] != DBNull.Value)
                            Eh.RetirementDate = Convert.ToDateTime(dr["RETIREMENT_DATE"]);


                        if (dr["RETIREMENT_MODE_ID"] != DBNull.Value)
                        {
                            Eh.RetirementModeId = Convert.ToInt32(dr["RETIREMENT_MODE_ID"]);
                            Eh.RetirementMode = Convert.ToString(dr["RETIREMENT_MODE"]);
                        }
                        Eh.Remarks = Convert.ToString(dr["Remarks"]);
                        ERetirements.Add(Eh);
                    }
                }
                if (ERetirements != null) ERetirements.TrimExcess();
                return ERetirements;
            }
            finally
            {
                con.Close();

            }

        }
        public void UpdateRetirementInEmployment(int SystemUserId,DateTime RetirementDate)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_RETIREMENT_IN_EMPLOYMENT";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = SystemUserId;
                cmd.Parameters.Add("@CurrentStatusDate", SqlDbType.Date).Value = RetirementDate;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                // not logged one by one: ProcessDataDAL.ProcessRetirement runs for every employee at every login and logs a single summary entry
            }
            finally
            {
                con.Close();

            }
        }
        public List<EmpRetirement> GetEmpRetirement(int EmpId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_RETIREMENT";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<EmpRetirement> ERetirements = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    ERetirements = new List<EmpRetirement>();
                    while (dr.Read())
                    {
                        EmpRetirement Eh = new EmpRetirement();
                        Eh.SystemUserId = Convert.ToInt32(dr["SYSTEM_USER_ID"]);
                        Eh.EmpRetirementId = Convert.ToInt32(dr["EMP_RETIREMENT_ID"]);

                        if (dr["RETIREMENT_TYPE_ID"] != DBNull.Value)
                        {
                            Eh.RetirementTypeId = Convert.ToInt32(dr["RETIREMENT_TYPE_ID"]);
                            Eh.RetirementType = Convert.ToString(dr["RETIREMENT_TYPE"]);
                        }
                        if (dr["RETIREMENT_DATE"] != DBNull.Value)
                            Eh.RetirementDate = Convert.ToDateTime(dr["RETIREMENT_DATE"]);


                        if (dr["RETIREMENT_MODE_ID"] != DBNull.Value)
                        {
                            Eh.RetirementModeId = Convert.ToInt32(dr["RETIREMENT_MODE_ID"]);
                            Eh.RetirementMode = Convert.ToString(dr["RETIREMENT_MODE"]);
                        }
                        Eh.Remarks = Convert.ToString(dr["Remarks"]);
                        ERetirements.Add(Eh);
                    }
                }
                if (ERetirements != null) ERetirements.TrimExcess();
                return ERetirements;
            }
            finally
            {
                con.Close();

            }

        }
        public void UpdateEmpRetirement(EmpRetirement ERetirement)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_EMP_RETIREMENT";
                cmd.Parameters.Add("@Idd", SqlDbType.Int).Value = ERetirement.EmpRetirementId;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = ERetirement.SystemUserId;
                cmd.Parameters.Add("@RetirementTypeId", SqlDbType.Int).Value = ERetirement.RetirementTypeId;
                cmd.Parameters.Add("@OnDate", SqlDbType.Date).Value = ERetirement.RetirementDate;
                cmd.Parameters.Add("@RetirementModeId", SqlDbType.Int).Value = ERetirement.RetirementModeId;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = ERetirement.Remarks;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertEmpRetirement(EmpRetirement ERetirement)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_EMP_RETIREMENT";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = ERetirement.SystemUserId;
                cmd.Parameters.Add("@RetirementTypeId", SqlDbType.Int).Value = ERetirement.RetirementTypeId;
                cmd.Parameters.Add("@OnDate", SqlDbType.Date).Value = ERetirement.RetirementDate;
                cmd.Parameters.Add("@RetirementModeId", SqlDbType.Int).Value = ERetirement.RetirementModeId;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = ERetirement.Remarks;

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }


        }
        public void DeleteEmpRetirement(int RetirementId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_EMP_RETIREMENT";
                cmd.Parameters.Add("@Idd", SqlDbType.Int).Value = RetirementId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }

        }
        #endregion RETIREMENT
        #region EMPLOYEE SUSPENSION
        public List<DisciplinaryAction> GetEmpSuspension(int EmpId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_SUSPENSION";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<DisciplinaryAction> DisActions = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    DisActions = new List<DisciplinaryAction>();
                    while (dr.Read())
                    {
                        DisciplinaryAction Eh = new DisciplinaryAction();
                        Eh.SystemUserId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        Eh.DisciplinaryActionId = Convert.ToInt32(dr["EMP_DISCIP_ID"]);

                        if (dr["IS_LFP_CALCULATED"] != DBNull.Value)
                            Eh.IsLfpCalculated = Convert.ToInt32(dr["IS_LFP_CALCULATED"]);

                        if (dr["IS_SERVICE_CALCULATED"] != DBNull.Value)
                            Eh.IsServiceCalculated = Convert.ToInt32(dr["IS_SERVICE_CALCULATED"]);
                        //if (dr["DATE_OF_ISSUE"] != DBNull.Value)
                        //    Eh.ActionDate = Convert.ToDateTime(dr["DATE_OF_ISSUE"]);
                        Eh.BPSID = Convert.ToInt32(dr["BPS_ID"]);
                        Eh.BPS = Convert.ToString(dr["BPS"]);
                        Eh.PostId = Convert.ToInt32(dr["POSTS_ID"]);
                        Eh.Post = Convert.ToString(dr["Post"]);
                        if (dr["FROM_DATE"] != DBNull.Value)
                            Eh.FromDate = Convert.ToDateTime(dr["FROM_DATE"]);
                        if (dr["TO_DATE"] != DBNull.Value)
                            Eh.ToDate = Convert.ToDateTime(dr["TO_DATE"]);
                        if (dr["FINAL_DISCIP_ACTION_ID"] != DBNull.Value)
                        {
                            Eh.FinalActionTypeId = Convert.ToInt32(dr["FINAL_DISCIP_ACTION_ID"]);
                            Eh.FinalActionType = Convert.ToString(dr["FINAL_DISCIP_ACTION_TYPE"]);
                        }
                        if (dr["FINAL_DISCIP_ACTION_DATE"] != DBNull.Value)
                            Eh.FinalActionDate = Convert.ToDateTime(dr["FINAL_DISCIP_ACTION_DATE"]);

                        Eh.Details = Convert.ToString(dr["Remarks"]);
                        DisActions.Add(Eh);
                    }
                }
                if (DisActions != null) DisActions.TrimExcess();
                return DisActions;
            }
            finally
            {
                con.Close();

            }

        }

        public List<DisciplinaryAction> GetSuspensionDetails(int EmpId, DateTime FromDate, DateTime ToDate)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SUSPENSION_DETAILS";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = ToDate;
                cmd.CommandType = CommandType.StoredProcedure;
                List<DisciplinaryAction> DisActions = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    DisActions = new List<DisciplinaryAction>();
                    while (dr.Read())
                    {
                        DisciplinaryAction Eh = new DisciplinaryAction();
                        Eh.SystemUserId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        Eh.DisciplinaryActionId = Convert.ToInt32(dr["EMP_DISCIP_ID"]);

                        if (dr["IS_LFP_CALCULATED"] != DBNull.Value)
                            Eh.IsLfpCalculated = Convert.ToInt32(dr["IS_LFP_CALCULATED"]);

                        if (dr["IS_SERVICE_CALCULATED"] != DBNull.Value)
                            Eh.IsServiceCalculated = Convert.ToInt32(dr["IS_SERVICE_CALCULATED"]);
                        //if (dr["DATE_OF_ISSUE"] != DBNull.Value)
                        //    Eh.ActionDate = Convert.ToDateTime(dr["DATE_OF_ISSUE"]);
                        Eh.BPSID = Convert.ToInt32(dr["BPS_ID"]);
                        //Eh.BPS = Convert.ToString(dr["BPS"]);
                        Eh.PostId = Convert.ToInt32(dr["POSTS_ID"]);
                        // Eh.Post = Convert.ToString(dr["Post"]);
                        if (dr["FROM_DATE"] != DBNull.Value)
                            Eh.FromDate = Convert.ToDateTime(dr["FROM_DATE"]);
                        if (dr["TO_DATE"] != DBNull.Value)
                            Eh.ToDate = Convert.ToDateTime(dr["TO_DATE"]);
                        if (dr["FINAL_DISCIP_ACTION_ID"] != DBNull.Value)
                        {
                            Eh.FinalActionTypeId = Convert.ToInt32(dr["FINAL_DISCIP_ACTION_ID"]);
                            //  Eh.FinalActionType = Convert.ToString(dr["FINAL_DISCIP_ACTION_TYPE"]);
                        }
                        if (dr["FINAL_DISCIP_ACTION_DATE"] != DBNull.Value)
                            Eh.FinalActionDate = Convert.ToDateTime(dr["FINAL_DISCIP_ACTION_DATE"]);

                        Eh.Details = Convert.ToString(dr["Remarks"]);
                        DisActions.Add(Eh);
                    }
                }
                if (DisActions != null) DisActions.TrimExcess();
                return DisActions;
            }
            finally
            {
                con.Close();

            }

        }
        public List<DisciplinaryAction> GetEmpSuspensions(int EmpId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMP_SUSPENSIONS";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<DisciplinaryAction> DisActions = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    DisActions = new List<DisciplinaryAction>();
                    while (dr.Read())
                    {
                        DisciplinaryAction Eh = new DisciplinaryAction();
                        Eh.SystemUserId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        Eh.DisciplinaryActionId = Convert.ToInt32(dr["EMP_DISCIP_ID"]);

                        if (dr["IS_LFP_CALCULATED"] != DBNull.Value)
                            Eh.IsLfpCalculated = Convert.ToInt32(dr["IS_LFP_CALCULATED"]);

                        if (dr["IS_SERVICE_CALCULATED"] != DBNull.Value)
                            Eh.IsServiceCalculated = Convert.ToInt32(dr["IS_SERVICE_CALCULATED"]);
                        //if (dr["DATE_OF_ISSUE"] != DBNull.Value)
                        //    Eh.ActionDate = Convert.ToDateTime(dr["DATE_OF_ISSUE"]);
                        Eh.BPSID = Convert.ToInt32(dr["BPS_ID"]);
                        //Eh.BPS = Convert.ToString(dr["BPS"]);
                        Eh.PostId = Convert.ToInt32(dr["POSTS_ID"]);
                        // Eh.Post = Convert.ToString(dr["Post"]);
                        if (dr["FROM_DATE"] != DBNull.Value)
                            Eh.FromDate = Convert.ToDateTime(dr["FROM_DATE"]);
                        if (dr["TO_DATE"] != DBNull.Value)
                            Eh.ToDate = Convert.ToDateTime(dr["TO_DATE"]);
                        if (dr["FINAL_DISCIP_ACTION_ID"] != DBNull.Value)
                        {
                            Eh.FinalActionTypeId = Convert.ToInt32(dr["FINAL_DISCIP_ACTION_ID"]);
                            //  Eh.FinalActionType = Convert.ToString(dr["FINAL_DISCIP_ACTION_TYPE"]);
                        }
                        if (dr["FINAL_DISCIP_ACTION_DATE"] != DBNull.Value)
                            Eh.FinalActionDate = Convert.ToDateTime(dr["FINAL_DISCIP_ACTION_DATE"]);

                        Eh.Details = Convert.ToString(dr["Remarks"]);
                        DisActions.Add(Eh);
                    }
                }
                if (DisActions != null) DisActions.TrimExcess();
                return DisActions;
            }
            finally
            {
                con.Close();

            }

        }


        public void UpdateEmpSuspension(DisciplinaryAction EmpDiscipAction)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_EMP_SUSPENSION";
                cmd.Parameters.Add("@Idd", SqlDbType.Int).Value = EmpDiscipAction.DisciplinaryActionId;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpDiscipAction.SystemUserId;
                cmd.Parameters.Add("@IsLfpCalculated", SqlDbType.Int).Value = EmpDiscipAction.IsLfpCalculated;
                cmd.Parameters.Add("@IsServiceCalculated", SqlDbType.Int).Value = EmpDiscipAction.IsServiceCalculated;
                cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = EmpDiscipAction.PostId;
                cmd.Parameters.Add("@Bps", SqlDbType.Int).Value = EmpDiscipAction.BPSID;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = EmpDiscipAction.FromDate;
                if (EmpDiscipAction.ToDate>Convert.ToDateTime("01/01/1950"))
                    cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = EmpDiscipAction.ToDate;
                cmd.Parameters.Add("@FinalActionId", SqlDbType.Int).Value = EmpDiscipAction.FinalActionTypeId;
                cmd.Parameters.Add("@FinalActionDate", SqlDbType.Date).Value = EmpDiscipAction.FinalActionDate;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = EmpDiscipAction.Details;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertEmpSuspension(DisciplinaryAction EmpDiscipAction)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_EMP_SUSPENSION";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpDiscipAction.SystemUserId;
                cmd.Parameters.Add("@IsLfpCalculated", SqlDbType.Int).Value = EmpDiscipAction.IsLfpCalculated;
                cmd.Parameters.Add("@IsServiceCalculated", SqlDbType.Int).Value = EmpDiscipAction.IsServiceCalculated;
                //  cmd.Parameters.Add("@OnDate", SqlDbType.Date).Value = EmpDiscipAction.ActionDate;
                cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = EmpDiscipAction.PostId;
                cmd.Parameters.Add("@Bps", SqlDbType.Int).Value = EmpDiscipAction.BPSID;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = EmpDiscipAction.FromDate;
                if (EmpDiscipAction.ToDate > Convert.ToDateTime("01/01/1950"))
                    cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = EmpDiscipAction.ToDate;
                cmd.Parameters.Add("@FinalActionId", SqlDbType.Int).Value = EmpDiscipAction.FinalActionTypeId;
                cmd.Parameters.Add("@FinalActionDate", SqlDbType.Date).Value = EmpDiscipAction.FinalActionDate;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = EmpDiscipAction.Details;

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }
        }
        public void DeleteEmpSuspension(int DiscipActionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_EMP_SUSPENSION";
                cmd.Parameters.Add("@Idd", SqlDbType.Int).Value = DiscipActionId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }

        }
        #endregion EMPLOYEE SUSPENSION
        #region LEAVE CREDIT
        public LeaveCredit GetLeaveCredit(int SystemUserId)
        {
            LeaveCredit lc = new LeaveCredit();

            return lc;
        }
        public int GetLFPCredit(int SystemUserId)
        {
            int LFPCredit = 0;
            List<EmployeeLeave> el = new EmployeeDAL().GetEmployeeLeaves(SystemUserId);
            foreach (EmployeeLeave row in el)
            {

            }
            return LFPCredit;
        }

        #endregion

        public void InsertPersonalNumber(int EmpId, double personalnumber)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_PERSONAL_NUMBER";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmpId;
                cmd.Parameters.Add("@PersonalNumber", SqlDbType.BigInt).Value = personalnumber;

                cmd.CommandType = CommandType.StoredProcedure;
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

        public void UpdateEmploymentStatus(int EmployeeId)
        {



            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MAIN_EMPLOYMENT";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = EmployeeId;
                cmd.CommandType = CommandType.StoredProcedure;
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
        public DateTime GetServiceEndDate(int EmpId)
        {
            DateTime ServiceEndDate = DateTime.Now;
            EmpHistory emphistory = GetCurrentEmployment(EmpId);
            if (emphistory != null)
            {
               
                if (emphistory.CurrentStatusId == 1 ||
                    emphistory.CurrentStatusId == 3 ||
                    emphistory.CurrentStatusId == 6 ||
                    emphistory.CurrentStatusId == 8 ||
                    emphistory.CurrentStatusId == 2 ||
                    emphistory.CurrentStatusId == 13 ||
                    emphistory.CurrentStatusId == 10)
                    ServiceEndDate = emphistory.CurrentStatusDate;
            }
            return ServiceEndDate;
        }

        public EmpHistory GetCurrentEmployment(int SystemUserId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CURRENT_EMPL_STATUS";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = SystemUserId;
                cmd.CommandType = CommandType.StoredProcedure;
                EmpHistory re = null;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {                   
                        re = new EmpHistory();
                        if (dr["EMP_EMPLOYMENT_HIST_ID"] != DBNull.Value)
                            re.EmploymentHistoryId = Convert.ToInt32(dr["EMP_EMPLOYMENT_HIST_ID"]);
                        if (dr["SYSTEM_USERS_ID"] != DBNull.Value)
                            re.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        if (dr["POST_ID"] != DBNull.Value)
                        {
                            re.PostId = Convert.ToInt32(dr["POST_ID"]);
                            re.Post = Convert.ToString(dr["POST"]);
                    }
                        if (dr["BPS_ID"] != DBNull.Value)
                        {
                            re.BpsId = Convert.ToInt32(dr["BPS_ID"]);
                            re.BPS = Convert.ToString(dr["BPS"]);
                    }
                        if (dr["POST_STATUS_ID"] != DBNull.Value)
                        {
                            re.PostStatusId = Convert.ToInt32(dr["POST_STATUS_ID"]);
                        }
                        if (dr["IS_GAZETTED"] != DBNull.Value)
                            re.IsGazetted = Convert.ToInt32(dr["IS_GAZETTED"]);
                        if (dr["IS_CURRENT"] != DBNull.Value)
                            re.IsCurrent = Convert.ToInt32(dr["IS_CURRENT"]);
                        if (dr["EMPL_STATUS_ID"] != DBNull.Value)
                        {
                            re.EmploymentStatusId = Convert.ToInt32(dr["EMPL_STATUS_ID"]);
                        }
                        if (dr["STATUS_DATE"] != DBNull.Value)
                            re.EmploymentStatusDate = Convert.ToDateTime(dr["STATUS_DATE"]);
                        if (dr["CURRENT_STATUS_ID"] != DBNull.Value)
                        {
                            re.CurrentStatusId = Convert.ToInt32(dr["CURRENT_STATUS_ID"]);
                            re.CurrentStatus = Convert.ToString(dr["CURRENT_STATUS"]);
                        }
                        if (dr["CURRENT_STATUS_DATE"] != DBNull.Value)
                            re.CurrentStatusDate = Convert.ToDateTime(dr["CURRENT_STATUS_DATE"]);
              
               }
            
                return re;
            }
            finally
            {
                con.Close();

            }

        }
        //public void updateall()
        //{
        //    List<int> employees = new List<int>();
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Employees_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ALL_EMPLOYEES";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            while (dr.Read())
        //            {
        //                if(dr["System_users_id"]!=DBNull.Value)
        //                UpdateEmploymentStatus(Convert.ToInt32(dr["System_users_id"]));

        //            }
        //        }
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
    }
}
