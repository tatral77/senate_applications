using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionDAL
{
    public class AdministrationDAL
    {
        #region  Divisions
        public List<Divisions> GetDivisions()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_DIVISIONS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Divisions> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Divisions>();
                    while (dr.Read())
                    {
                        Divisions Temp = new Divisions();

                        Temp.DivisionsId = Convert.ToInt32(dr["Divisions_Id"]);
                        Temp.Description = Convert.ToString(dr["Division"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        Temp.MinistriesId = Convert.ToInt32(dr["Ministries_Id"]);
                        Temp.Ministry = Convert.ToString(dr["Ministry"]);

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
        public List<Divisions> GetDivisions(int GroupId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_DIVISIONS_BY_GROUP";
                cmd.Parameters.Add("@GroupsId", SqlDbType.Int).Value = GroupId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Divisions> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Divisions>();
                    while (dr.Read())
                    {
                        Divisions Temp = new Divisions();

                        Temp.DivisionsId = Convert.ToInt32(dr["Divisions_Id"]);
                        Temp.Description = Convert.ToString(dr["Description"]);
                       // Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                       // Temp.MinistriesId = Convert.ToInt32(dr["Ministries_Id"]);
                       // Temp.Ministry = Convert.ToString(dr["Ministry"]);

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
        public void UpdateDivision(Divisions Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_DIVIDION";
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.Parameters.Add("@MinistriesId", SqlDbType.Int).Value = Temp.MinistriesId;
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
        public void InsertDivisions(Divisions Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_DIVISIONS";
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.Parameters.Add("@MinistriesId", SqlDbType.Int).Value = Temp.MinistriesId;
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
        public List<Divisions> GetUnAssignedDivisions(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_UN_ASSIGNED_DIVISIONS";
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.VarChar).Value = AssemblySessionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Divisions> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Divisions>();
                    while (dr.Read())
                    {
                        Divisions Temp = new Divisions();

                        Temp.DivisionsId = Convert.ToInt32(dr["Divisions_Id"]);
                        Temp.Description = Convert.ToString(dr["Description"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                       // Temp.MinistriesId = Convert.ToInt32(dr["Ministries_Id"]);
                      //  Temp.Ministry = Convert.ToString(dr["Ministry"]);

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
        #endregion Divisions

        //------------------------------------END-----------------------//.

        #region Question_Status

        public List<QuestionStatuses> GetQuestionStatus()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_QUESTION_STATUSES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<QuestionStatuses> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<QuestionStatuses>();
                    while (dr.Read())
                    {
                        QuestionStatuses Temp = new QuestionStatuses();
                        Temp.QuestionStatusesId = Convert.ToInt32(dr["Question_Statuses_Id"]);
                        Temp.Description = Convert.ToString(dr["Description"]);
                        Temp.ActionName = Convert.ToString(dr["Action_Name"]);
                        Temp.StatusLevel = Convert.ToString(dr["Status_Level"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        //Temp.DisplaySequence = Convert.ToInt32(dr["Display_Sequence"]); DISPLAY_SEQUENCE
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

        public void UpdateQuestionStatuses(QuestionStatuses Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_QUESTION_STATUS";
                cmd.Parameters.Add("@Descriptation", SqlDbType.Int).Value = Temp.Description;
                cmd.Parameters.Add("@Action_Name", SqlDbType.VarChar).Value = Temp.ActionName;
                cmd.Parameters.Add("@Status_Level", SqlDbType.VarChar).Value = Temp.StatusLevel;
                cmd.Parameters.Add("@Is_Active", SqlDbType.Int).Value = Temp.IsActive;
                cmd.Parameters.Add("@Display_Sequence", SqlDbType.Int).Value = Temp.DisplaySequence;
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
        public void InsertQuestionStatuses(QuestionStatuses Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_QUESTION_STATUS";
                cmd.Parameters.Add("@Descriptation", SqlDbType.Int).Value = Temp.Description;
                cmd.Parameters.Add("@Action_Name", SqlDbType.VarChar).Value = Temp.ActionName;
                cmd.Parameters.Add("@Status_Level", SqlDbType.VarChar).Value = Temp.StatusLevel;
                cmd.Parameters.Add("@Is_Active", SqlDbType.Int).Value = Temp.IsActive;
                cmd.Parameters.Add("@Display_Sequence", SqlDbType.Int).Value = Temp.DisplaySequence;
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



        #endregion Question_Status

        //------------------------------------END-----------------------//.

        #region Parliamentary_Years

        public List<ParliamentaryYears> GetParliamentaryYears()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_QUESTION_STATUS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<ParliamentaryYears> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ParliamentaryYears>();
                    while (dr.Read())
                    {
                        ParliamentaryYears Temp = new ParliamentaryYears();

                        Temp.ParliamentaryYearsId = Convert.ToInt32(dr["Parliamentary_Years"]);
                        Temp.ParliamentaryYear = Convert.ToString(dr["Parliamentary_Year"]);
                        Temp.FromDate = Convert.ToDateTime(dr["From_Date"]);
                        Temp.ToDate = Convert.ToDateTime(dr["To_Date"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        Temp.ParliamentaryPeriodsId = Convert.ToInt32(dr["Parliamentary_Periods_Id"]);
                        Temp.ParliamentaryPeriod = Convert.ToString(dr["Parliamentary_Period"]);
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

        public void UpdateParliamentaryYears(ParliamentaryYears Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_PARLIAMENTARY_YEAR";
                cmd.Parameters.Add("@ParliamentaryYearsId", SqlDbType.Int).Value = Temp.ParliamentaryYearsId;
                cmd.Parameters.Add("@ParliamentaryYear", SqlDbType.VarChar).Value = Temp.ParliamentaryYear;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = Temp.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = Temp.ToDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.Parameters.Add("@ParliamentaryPeriodsId", SqlDbType.Int).Value = Temp.ParliamentaryPeriodsId;
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
        public void InsertParliamentaryYears(ParliamentaryYears Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_PARLIAMENTARY_YEAR";
                cmd.Parameters.Add("@ParliamentaryYear", SqlDbType.VarChar).Value = Temp.ParliamentaryYear;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = Temp.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = Temp.ToDate;
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

        #endregion Parliamentary_Years
        #region  Ministries
        public List<Ministries> GetMinistries()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MINISTRIES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Ministries> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Ministries>();
                    while (dr.Read())
                    {
                        Ministries Temp = new Ministries();

                        Temp.MinistriesId = Convert.ToInt32(dr["Ministries_Id"]);
                        Temp.Description = Convert.ToString(dr["Description"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        Temp.IsFedMin = Convert.ToInt32(dr["Is_Fed_Min"]);
                        Temp.IsStatMin = Convert.ToInt32(dr["Is_Stat_Min"]);
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
        public void UpdateMinistries(Ministries Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MINISTRY";
                cmd.Parameters.Add("@MinistriesId", SqlDbType.Int).Value = Temp.MinistriesId;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.Parameters.Add("@IsFedMin", SqlDbType.Int).Value = Temp.IsFedMin;
                cmd.Parameters.Add("@IsStatMin", SqlDbType.Int).Value = Temp.IsStatMin;
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
        public void InsertMinistries(Ministries Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MINISTRY";
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.Parameters.Add("@IsFedMin", SqlDbType.Int).Value = Temp.IsFedMin;
                cmd.Parameters.Add("@IsStatMin", SqlDbType.Int).Value = Temp.IsStatMin;
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

        #endregion Ministries

    }
}
