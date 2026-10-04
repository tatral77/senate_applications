using Entities;
using MotionEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QuestionDAL
{
    public class AdministrationDAL
    {
        //#region  Divisions
        //public List<Divisions> GetDivisions()
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_DIVISIONS";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<Divisions> MyList = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            MyList = new List<Divisions>();
        //            while (dr.Read())
        //            {
        //                Divisions Temp = new Divisions();

        //                Temp.DivisionsId = Convert.ToInt32(dr["Divisions_Id"]);
        //                Temp.Description = Convert.ToString(dr["Division"]);
        //                Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
        //                Temp.MinistriesId = Convert.ToInt32(dr["Ministries_Id"]);
        //                Temp.Ministry = Convert.ToString(dr["Ministry"]);

        //                MyList.Add(Temp);
        //            }
        //        }

        //        if (MyList != null) MyList.TrimExcess();
        //        return MyList;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}
        //public List<Divisions> GetDivisions(int GroupId)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_DIVISIONS_BY_GROUP";
        //        cmd.Parameters.Add("@GroupsId", SqlDbType.Int).Value = GroupId;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<Divisions> MyList = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            MyList = new List<Divisions>();
        //            while (dr.Read())
        //            {
        //                Divisions Temp = new Divisions();

        //                Temp.DivisionsId = Convert.ToInt32(dr["Divisions_Id"]);
        //                Temp.Description = Convert.ToString(dr["Description"]);
        //               // Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
        //               // Temp.MinistriesId = Convert.ToInt32(dr["Ministries_Id"]);
        //               // Temp.Ministry = Convert.ToString(dr["Ministry"]);

        //                MyList.Add(Temp);
        //            }
        //        }

        //        if (MyList != null) MyList.TrimExcess();
        //        return MyList;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}
        //public void UpdateDivision(Divisions Temp)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_DIVIDION";
        //        cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
        //        cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
        //        cmd.Parameters.Add("@MinistriesId", SqlDbType.Int).Value = Temp.MinistriesId;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.ExecuteNonQuery();
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
        //public void InsertDivisions(Divisions Temp)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_DIVISIONS";
        //        cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
        //        cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
        //        cmd.Parameters.Add("@MinistriesId", SqlDbType.Int).Value = Temp.MinistriesId;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.ExecuteNonQuery();
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
        //public List<Divisions> GetUnAssignedDivisions(int AssemblySessionsId)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_UN_ASSIGNED_DIVISIONS";
        //        cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.VarChar).Value = AssemblySessionsId;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<Divisions> MyList = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            MyList = new List<Divisions>();
        //            while (dr.Read())
        //            {
        //                Divisions Temp = new Divisions();

        //                Temp.DivisionsId = Convert.ToInt32(dr["Divisions_Id"]);
        //                Temp.Description = Convert.ToString(dr["Description"]);
        //                Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
        //               // Temp.MinistriesId = Convert.ToInt32(dr["Ministries_Id"]);
        //              //  Temp.Ministry = Convert.ToString(dr["Ministry"]);

        //                MyList.Add(Temp);
        //            }
        //        }

        //        if (MyList != null) MyList.TrimExcess();
        //        return MyList;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}
        //#endregion Divisions

        //------------------------------------END-----------------------//.

        #region Question_Status

        public List<QuestionStatuses> GetQuestionStatuses()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
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
        public List<QuestionStatuses> GetQuestionActiveStatus()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_QUESTION_STATUSES";
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
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
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
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
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

        //#region Parliamentary_Years

        //public List<ParliamentaryYears> GetParliamentaryYears()
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PARLIAMENTARY_YEARS";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<ParliamentaryYears> MyList = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            MyList = new List<ParliamentaryYears>();
        //            while (dr.Read())
        //            {
        //                ParliamentaryYears Temp = new ParliamentaryYears();

        //                Temp.ParliamentaryYearsId = Convert.ToInt32(dr["Parliamentary_Years"]);
        //                Temp.ParliamentaryYear = Convert.ToString(dr["Parliamentary_Year"]);
        //                Temp.FromDate = Convert.ToDateTime(dr["From_Date"]);
        //                Temp.ToDate = Convert.ToDateTime(dr["To_Date"]);
        //                Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
        //                Temp.ParliamentaryPeriodsId = Convert.ToInt32(dr["Parliamentary_Periods_Id"]);
        //                Temp.ParliamentaryPeriod = Convert.ToString(dr["Parliamentary_Period"]);
        //                MyList.Add(Temp);
        //            }
        //        }

        //        if (MyList != null) MyList.TrimExcess();
        //        return MyList;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}

        //public ParliamentaryYears GetCurrentParliamentaryYear()
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CURRENT_PARLIAMENTARY_YEAR";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        ParliamentaryYears Temp= null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            Temp = new ParliamentaryYears();
        //            dr.Read();
        //                Temp.ParliamentaryYearsId = Convert.ToInt32(dr["Parliamentary_Years_id"]);
        //                Temp.ParliamentaryYear = Convert.ToString(dr["Parliamentary_Year"]);
        //                Temp.FromDate = Convert.ToDateTime(dr["From_Date"]);
        //                Temp.ToDate = Convert.ToDateTime(dr["To_Date"]);
        //                Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
        //                Temp.ParliamentaryPeriodsId = Convert.ToInt32(dr["Parliamentary_Periods_Id"]);
        //                //Temp.ParliamentaryPeriod = Convert.ToString(dr["Parliamentary_Period"]);

        //        }

        //        return Temp;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}

        //public void UpdateParliamentaryYears(ParliamentaryYears Temp)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_PARLIAMENTARY_YEAR";
        //        cmd.Parameters.Add("@ParliamentaryYearsId", SqlDbType.Int).Value = Temp.ParliamentaryYearsId;
        //        cmd.Parameters.Add("@ParliamentaryYear", SqlDbType.VarChar).Value = Temp.ParliamentaryYear;
        //        cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = Temp.FromDate;
        //        cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = Temp.ToDate;
        //        cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
        //        cmd.Parameters.Add("@ParliamentaryPeriodsId", SqlDbType.Int).Value = Temp.ParliamentaryPeriodsId;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.ExecuteNonQuery();
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
        //public void InsertParliamentaryYears(ParliamentaryYears Temp)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_PARLIAMENTARY_YEAR";
        //        cmd.Parameters.Add("@ParliamentaryYear", SqlDbType.VarChar).Value = Temp.ParliamentaryYear;
        //        cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = Temp.FromDate;
        //        cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = Temp.ToDate;
        //        cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.ExecuteNonQuery();
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

        //#endregion Parliamentary_Years
        //#region  Ministries
        //public List<Ministries> GetMinistries()
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MINISTRIES";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<Ministries> MyList = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            MyList = new List<Ministries>();
        //            while (dr.Read())
        //            {
        //                Ministries Temp = new Ministries();

        //                Temp.MinistriesId = Convert.ToInt32(dr["Ministries_Id"]);
        //                Temp.Description = Convert.ToString(dr["Description"]);
        //                Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
        //                Temp.IsFedMin = Convert.ToInt32(dr["Is_Fed_Min"]);
        //                if(dr["Is_Stat_Min"]!=DBNull.Value)
        //                Temp.IsStatMin = Convert.ToInt32(dr["Is_Stat_Min"]);
        //                MyList.Add(Temp);
        //            }
        //        }

        //        if (MyList != null) MyList.TrimExcess();
        //        return MyList;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}

        //public void UpdateMinistries(Ministries Temp)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MINISTRY";
        //        cmd.Parameters.Add("@MinistriesId", SqlDbType.Int).Value = Temp.MinistriesId;
        //        cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
        //        cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
        //        cmd.Parameters.Add("@IsFedMin", SqlDbType.Int).Value = Temp.IsFedMin;
        //        cmd.Parameters.Add("@IsStatMin", SqlDbType.Int).Value = Temp.IsStatMin;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.ExecuteNonQuery();
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
        //public void InsertMinistries(Ministries Temp)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MINISTRY";
        //        cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
        //        cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
        //        cmd.Parameters.Add("@IsFedMin", SqlDbType.Int).Value = Temp.IsFedMin;
        //        cmd.Parameters.Add("@IsStatMin", SqlDbType.Int).Value = Temp.IsStatMin;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.ExecuteNonQuery();
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

        //#endregion Ministries
        //#region Member
        ////public List<MemberStatuses> GetMemberStatuses()
        ////{
        ////    SqlConnection con = new DalHelper().GetConnection();
        ////    try
        ////    {
        ////        SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
        ////        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBER_STATUSES";
        ////        cmd.CommandType = CommandType.StoredProcedure;
        ////        List<MemberStatuses> MyList = null;
        ////        SqlDataReader dr = cmd.ExecuteReader();
        ////        if (dr.HasRows)
        ////        {
        ////            MyList = new List<MemberStatuses>();
        ////            while (dr.Read())
        ////            {
        ////                MemberStatuses Temp = new MemberStatuses();

        ////                Temp.MemberStatusId = Convert.ToInt32(dr["Member_Statuses_Id"]);
        ////                Temp.MemberStatus = Convert.ToString(dr["Description"]);
        ////                Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
        ////                MyList.Add(Temp);
        ////            }
        ////        }

        ////        if (MyList != null) MyList.TrimExcess();
        ////        return MyList;
        ////    }
        ////    finally
        ////    {
        ////        con.Close();

        ////    }
        ////}

        public List<Member> GetMemberByName(string MemberName)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
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
                        Temp.MemberName = Convert.ToString(dr["Senator_Name"]);
                        Temp.IsActive = Convert.ToInt32(dr["MEMBER_STATUS"]);
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
        //public List<Member> GetMembersByStatus(int StatusId)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBERS_BY_STATUS";
        //        cmd.Parameters.Add("@MemberStatusId", SqlDbType.Int).Value = StatusId;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<Member> MyList = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            MyList = new List<Member>();
        //            while (dr.Read())
        //            {
        //                Member Temp = new Member();
        //                string membername = "";
        //                if (dr["F_Name"] != DBNull.Value)
        //                    membername = Convert.ToString(dr["F_Name"]);
        //                if (dr["M_Name"] != DBNull.Value)
        //                    membername += " " + Convert.ToString(dr["M_Name"]);
        //                if (dr["L_Name"] != DBNull.Value)
        //                    membername += " " + Convert.ToString(dr["L_Name"]);
        //                Temp.MemberId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
        //                Temp.MemberName = membername;
        //                Temp.IsActive = Convert.ToInt32(dr["MEMBER_STATUS"]);
        //                MyList.Add(Temp);
        //            }
        //        }

        //        if (MyList != null) MyList.TrimExcess();
        //        return MyList;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}
        //#endregion Member

        //public List<Divisions> GetDivisionsByName(string DivisionName)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_DIVISION_BY_NAME";
        //        cmd.Parameters.Add("@Division", SqlDbType.VarChar).Value = DivisionName;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<Divisions> MyList = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            MyList = new List<Divisions>();
        //            while (dr.Read())
        //            {
        //                Divisions Temp = new Divisions();

        //                Temp.DivisionsId = Convert.ToInt32(dr["Divisions_Id"]);
        //                Temp.Description = Convert.ToString(dr["Description"]);
        //                //Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
        //                //Temp.MinistriesId = Convert.ToInt32(dr["Ministries_Id"]);
        //                MyList.Add(Temp);
        //            }
        //        }

        //        if (MyList != null) MyList.TrimExcess();
        //        return MyList;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}
        //public List<Divisions> GetCurrentDivisionsByName(string DivisionName)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CURRENT_DIVISION_BY_NAME";
        //        cmd.Parameters.Add("@Division", SqlDbType.VarChar).Value = DivisionName;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<Divisions> MyList = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            MyList = new List<Divisions>();
        //            while (dr.Read())
        //            {
        //                Divisions Temp = new Divisions();

        //                Temp.DivisionsId = Convert.ToInt32(dr["Divisions_Id"]);
        //                Temp.Description = Convert.ToString(dr["Description"]);
        //                //Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
        //                //Temp.MinistriesId = Convert.ToInt32(dr["Ministries_Id"]);
        //                MyList.Add(Temp);
        //            }
        //        }

        //        if (MyList != null) MyList.TrimExcess();
        //        return MyList;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}


        //public List<DivisionGroups> GetDivisionGroups(int AssemblySessionId, int DivisionId)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_DIVISION_GROUPS";
        //        cmd.Parameters.Add("@DivisionId", SqlDbType.Int).Value = DivisionId;
        //        cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = AssemblySessionId;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<DivisionGroups> MyList = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            MyList = new List<DivisionGroups>();
        //            while (dr.Read())
        //            {
        //                DivisionGroups Temp = new DivisionGroups();

        //                Temp.DivisionId = Convert.ToInt32(dr["Divisions_Id"]);
        //                Temp.AssemblySessionId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);
        //                Temp.GroupSequence = Convert.ToInt32(dr["GROUP_SEQUENCE"]);
        //                Temp.GroupId = Convert.ToInt32(dr["GROUPS_ID"]);
        //                MyList.Add(Temp);
        //            }
        //        }

        //        if (MyList != null) MyList.TrimExcess();
        //        return MyList;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}

        //#region Rota

        //public List<QuestionsRota> GetQuestionRotas()
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ROTAS";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<QuestionsRota> MyList = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            MyList = new List<QuestionsRota>();
        //            while (dr.Read())
        //            {
        //                QuestionsRota Temp = new QuestionsRota();
        //                Temp.RotaListId = Convert.ToInt32(dr["QUEST_ROTA_ID"]);
        //                Temp.AssemblySessionsId = Convert.ToInt32(dr["Assembly_Session_Id"]);
        //                Temp.SessionNumber = Convert.ToInt32(dr["Session_Number"]);
        //                Temp.StartDate = Convert.ToDateTime(dr["Start_Date"]);
        //                Temp.EndDate = Convert.ToDateTime(dr["End_Date"]);
        //                Temp.StartGroup = Convert.ToInt32(dr["STARTING_GROUP"]);
        //                Temp.SkipDays = Convert.ToString(dr["Skip_Days"]);
        //                MyList.Add(Temp);
        //            }
        //        }

        //        if (MyList != null) MyList.TrimExcess();
        //        return MyList;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}


        //public QuestionsRota GetQuestionRota(int RotaId)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        QuestionsRota Temp = null;
        //            SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
        //            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ROTA";
        //            cmd.Parameters.Add("@RotaId", SqlDbType.Int).Value = RotaId;
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            using (con)
        //            {
        //                SqlDataReader dr = cmd.ExecuteReader();
        //                dr.Read();
        //            Temp = new QuestionsRota();
        //            Temp.RotaListId = Convert.ToInt32(dr["QUEST_ROTA_ID"]);
        //            Temp.SessionNumber = Convert.ToInt32(dr["Session_Number"]);
        //            Temp.AssemblySessionsId = Convert.ToInt32(dr["Assembly_Session_Id"]);
        //            Temp.StartDate = Convert.ToDateTime(dr["Start_Date"]);
        //            Temp.EndDate = Convert.ToDateTime(dr["End_Date"]);
        //            Temp.StartGroup = Convert.ToInt32(dr["STARTING_GROUP"]);
        //            Temp.SkipDays = Convert.ToString(dr["Skip_Days"]);
        //        }

        //        return Temp;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}

        //public void UpdateQuestionRota(QuestionsRota Temp)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_ROTA";
        //        cmd.Parameters.Add("@RotaId", SqlDbType.Int).Value = Temp.RotaListId;
        //        cmd.Parameters.Add("@AssembliesSessionId", SqlDbType.Int).Value = Temp.AssemblySessionsId;
        //        cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = Temp.StartDate;
        //        cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = Temp.EndDate;
        //        cmd.Parameters.Add("@StartGroup", SqlDbType.Int).Value = Temp.StartGroup;
        //        cmd.Parameters.Add("@SkipDays", SqlDbType.VarChar).Value = Temp.SkipDays;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.ExecuteNonQuery();
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
        //public void InsertQuestionRota(QuestionsRota Temp)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_ROTA";
        //        cmd.Parameters.Add("@AssembliesSessionId", SqlDbType.Int).Value = Temp.AssemblySessionsId;
        //        cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = Temp.StartDate;
        //        cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = Temp.EndDate;
        //        cmd.Parameters.Add("@StartGroup", SqlDbType.Int).Value = Temp.StartGroup;
        //        cmd.Parameters.Add("@SkipDays", SqlDbType.VarChar).Value = Temp.SkipDays;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.ExecuteNonQuery();
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
        //public void DeleteQuestionRota(int RotaId)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_ROTA";
        //        cmd.Parameters.Add("@RotaId", SqlDbType.Int).Value = RotaId;               
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.ExecuteNonQuery();
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



        //#endregion Rota
        //#region Members
        //public int INSERT_NEW_MEMBER(NewMemberInfo Md)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();

        //    SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_SYSTEM_USERS";
        //    //cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = Md.Title;
        //    cmd.Parameters.Add("@FName", SqlDbType.VarChar).Value = Md.MemberName;
        //   // cmd.Parameters.Add("@NICNumber", SqlDbType.VarChar).Value = Md.NICNumber;
        //   // cmd.Parameters.Add("@FatherHusbandName", SqlDbType.VarChar).Value = Md.HusbandFatherName;
        //   // cmd.Parameters.Add("@DOB", SqlDbType.Date).Value = Md.DOB;
        //    cmd.Parameters.Add("@Gender", SqlDbType.Int).Value = Md.GenderId;
        //   // cmd.Parameters.Add("@ReligionsId", SqlDbType.Int).Value = Md.ReligionId;
        //  //  cmd.Parameters.Add("@MaritalStatus", SqlDbType.Int).Value = Md.MaritalStatus;
        //    cmd.Parameters.Add("@IsEmployee", SqlDbType.Int).Value = 0;
        //    cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = 1;
        //    cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
        //    cmd.Connection = con;
        //    try
        //    {
        //        cmd.ExecuteScalar();
        //        string id = cmd.Parameters["@ID"].Value.ToString();
        //        return Convert.ToInt32(id);

        //    }


        //    finally
        //    {
        //        con.Close();
        //    }

        //}

        //     public void UpdateMemberBasicInfo(NewMemberInfo bi)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
        //    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MEMBERS_BASIC_INFO";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = bi.MemberId;
        //    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = bi.MemberName;
        //    cmd.Parameters.Add("@TermId", SqlDbType.Int).Value = bi.MemberTenureId;
        //    cmd.Parameters.Add("@MemberStatusId", SqlDbType.Int).Value = bi.MemberStatusId;
        //    cmd.Parameters.Add("@PoliticalPartyId", SqlDbType.Int).Value = bi.PartyId;
        //    cmd.Parameters.Add("@ElectionTypeId", SqlDbType.Int).Value = bi.ElectionTypeId;

        //    cmd.Connection = con;
        //    try
        //    {
        //        cmd.ExecuteReader();
        //    }

        //    finally
        //    {
        //        con.Close();

        //    }

        //}
        //public void InsertMemberId(NewMemberInfo bi)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
        //    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_NEW_MEMBER";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = bi.MemberId;
        //    cmd.Parameters.Add("@TermId", SqlDbType.Int).Value = bi.MemberTenureId;
        //    cmd.Parameters.Add("@MemberStatusId", SqlDbType.Int).Value = bi.MemberStatusId;
        //    cmd.Parameters.Add("@PoliticalPartyId", SqlDbType.Int).Value = bi.PartyId;
        //    cmd.Parameters.Add("@ElectionTypeId", SqlDbType.Int).Value = bi.ElectionTypeId;

        //    cmd.Connection = con;
        //    try
        //    {
        //        cmd.ExecuteReader();
        //    }

        //    finally
        //    {
        //        con.Close();

        //    }

        //}

        //    public List<NewMemberInfo> GetMemberBasicInfo()
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBERS_BASIC_INFO";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<NewMemberInfo> Temp = null;
        //        using (con)
        //        {
        //            SqlDataReader dr = cmd.ExecuteReader();
        //            if (dr.HasRows)
        //            {
        //                Temp = new List<NewMemberInfo>();
        //                while (dr.Read())
        //                {
        //                    NewMemberInfo ad = new NewMemberInfo();
        //                    ad.MemberId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
        //                    ad.MemberName = Convert.ToString(dr["F_NAME"]);
        //                    ad.MemberTenureId= Convert.ToInt32(dr["ASSEMBLIES_ID"]);
        //                    ad.MemberTenure = Convert.ToString(dr["TERM"]);
        //                    ad.PartyId = Convert.ToInt32(dr["POLITICAL_PARTY"]);
        //                    ad.Party = Convert.ToString(dr["PARTY"]);
        //                    ad.MemberStatusId= Convert.ToInt32(dr["MEMBER_STATUS_ID"]);
        //                    ad.MemberStatus = Convert.ToString(dr["MEMBER_STATUS"]);
        //                    ad.NoOfQuestions = Convert.ToInt32(dr["NOOFQUESTIONS"]);
        //                    Temp.Add(ad);
        //                }
        //            }
        //        }
        //        if (Temp != null) Temp.TrimExcess();
        //        return Temp;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}
        //#endregion

        //#region ASSEMBLIES
        //public List<Assemblies> GetAssemblies()
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ASSEBLIES";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<Assemblies> Temp = null;
        //        using (con)
        //        {
        //            SqlDataReader dr = cmd.ExecuteReader();
        //            if (dr.HasRows)
        //            {
        //                Temp = new List<Assemblies>();
        //                while (dr.Read())
        //                {
        //                    Assemblies ad = new Assemblies();
        //                    ad.AssembliesId = Convert.ToInt32(dr["ASSEMBLIES_ID"]);
        //                    ad.Term = Convert.ToString(dr["TERM"]);
        //                    Temp.Add(ad);
        //                }
        //            }
        //        }
        //        if (Temp != null) Temp.TrimExcess();
        //        return Temp;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}
        //#endregion ASSEMBLIES

        //#region MEMBER STATUS
        //public List<MemberStatus> GetMemberStatuses()
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBER_STATUSES";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<MemberStatus> Temp = null;
        //        using (con)
        //        {
        //            SqlDataReader dr = cmd.ExecuteReader();
        //            if (dr.HasRows)
        //            {
        //                Temp = new List<MemberStatus>();
        //                while (dr.Read())
        //                {
        //                    MemberStatus ad = new MemberStatus();
        //                    ad.MemberStatusId = Convert.ToInt32(dr["MEMBER_STATUSES_ID"]);
        //                    ad.MemStatus = Convert.ToString(dr["DESCRIPTION"]);
        //                    Temp.Add(ad);
        //                }
        //            }
        //        }
        //        if (Temp != null) Temp.TrimExcess();
        //        return Temp;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}
        //#endregion MEMBER STATUS

        //#region POLITICAL_PARTY
        //public List<PoliticalParty> GetPoliticalParties()
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_POLITICAL_PARTIES";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<PoliticalParty> Temp = null;
        //        using (con)
        //        {
        //            SqlDataReader dr = cmd.ExecuteReader();
        //            if (dr.HasRows)
        //            {
        //                Temp = new List<PoliticalParty>();
        //                while (dr.Read())
        //                {
        //                    PoliticalParty ad = new PoliticalParty();
        //                    ad.PartyId = Convert.ToInt32(dr["POLITICAL_PARTIES_ID"]);
        //                    ad.PartyName = Convert.ToString(dr["DESCRIPTION"]);
        //                    Temp.Add(ad);
        //                }
        //            }
        //        }
        //        if (Temp != null) Temp.TrimExcess();
        //        return Temp;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}
        //#endregion POLITICAL_PARTY

        //#region ELECTION TYPES
        //public List<ElectionTypes> GetElectionTypes()
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ELECTION_TYPES";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<ElectionTypes> Temp = null;
        //        using (con)
        //        {
        //            SqlDataReader dr = cmd.ExecuteReader();
        //            if (dr.HasRows)
        //            {
        //                Temp = new List<ElectionTypes>();
        //                while (dr.Read())
        //                {
        //                    ElectionTypes ad = new ElectionTypes();
        //                    ad.ElectionTypesId = Convert.ToInt32(dr["ELECTION_TYPES_ID"]);
        //                    ad.Description = Convert.ToString(dr["DESCRIPTION"]);
        //                    Temp.Add(ad);
        //                }
        //            }
        //        }
        //        if (Temp != null) Temp.TrimExcess();
        //        return Temp;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}
        //#endregion ELECTION_TYPES
        //public List<Gender> GetGenders()
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_GENDERS";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<Gender> gender = null;
        //        using (con)
        //        {
        //            SqlDataReader dr = cmd.ExecuteReader();
        //            if (dr.HasRows)
        //            {
        //                gender = new List<Gender>();
        //                while (dr.Read())
        //                {
        //                    Gender ad = new Gender();
        //                    ad.GenderId = Convert.ToInt32(dr["Genders_id"]);
        //                    ad.Description = Convert.ToString(dr["Description"]);
        //                    ad.IsActive = Convert.ToInt32(dr["Is_Active"]);
        //                    gender.Add(ad);
        //                }
        //            }
        //        }
        //        if (gender != null) gender.TrimExcess();
        //        return gender;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}


        //public List<Religion> GetReligions()
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_RELIGIONS";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<Religion> Rlgn = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            Rlgn = new List<Religion>();
        //            while (dr.Read())
        //            {
        //                Religion ad = new Religion();
        //                ad.ReligionId = Convert.ToInt32(dr["religions_id"]);
        //                ad.Description = Convert.ToString(dr["Description"]);
        //                ad.IsActive = Convert.ToInt32(dr["Is_Active"]);
        //                Rlgn.Add(ad);
        //            }
        //        }

        //        if (Rlgn != null) Rlgn.TrimExcess();
        //        return Rlgn;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}
        //public List<MaritalStatus> GetMaritalStatuses()
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MARITAL_STATUSES";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<MaritalStatus> Mstatus = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            Mstatus = new List<MaritalStatus>();
        //            while (dr.Read())
        //            {
        //                MaritalStatus ad = new MaritalStatus();
        //                ad.MaritalStatusId = Convert.ToInt32(dr["MARITAL_STATUSES_ID"]);
        //                ad.Description = Convert.ToString(dr["Description"]);
        //                ad.IsActive = Convert.ToInt32(dr["Is_Active"]);
        //                Mstatus.Add(ad);
        //            }
        //        }

        //        if (Mstatus != null) Mstatus.TrimExcess();
        //        return Mstatus;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}
        #region AssemblySessions
        public AssemblySessions GetAssemblySession(int AssemblySessionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ASSEMBLY_SESSION";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.VarChar).Value = AssemblySessionId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AssemblySessions Temp = new AssemblySessions();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp.AssemblySessionsId = Convert.ToInt32(dr["Assembly_Sessions_Id"]);
                    //Temp.CalledBy = Convert.ToString(dr["Called_By"]);
                    // Temp.IsJointSession = Convert.ToInt32(dr["Is_Joint_Session"]);
                    Temp.SessionNumber = Convert.ToInt32(dr["Session_Number"]);
                    Temp.StartDate = Convert.ToDateTime(dr["Start_Date"]);
                    if (dr["End_Date"] != DBNull.Value)
                        Temp.EndDate = Convert.ToDateTime(dr["End_Date"]);
                    if (dr["Business_Sessions"] != DBNull.Value)
                        Temp.BusinessSessions = Convert.ToString(dr["Business_Sessions"]);

                    //Temp.SittingTypeId = Convert.ToInt32(dr["Sitting_Type_Id"]);
                    //Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                    //Temp.AssembliesId = Convert.ToInt32(dr["Assemblies_Id"]);
                    //Temp.SummonedBy = Convert.ToInt32(dr["Summoned_By"]);
                    //Temp.ProroguedBy = Convert.ToInt32(dr["Prorogued_By"]);
                    //Temp.LegislationDiaryNo = Convert.ToInt32(dr["Legislation_Diary_No"]);
                    //Temp.LegislationDiaryDate = Convert.ToDateTime(dr["Legislation_Diary_Date"]);
                    //Temp.SessStatusesId = Convert.ToInt32(dr["Sess_Statuses_Id"]);
                    //Temp.IsQuorumAdjourned = Convert.ToInt32(dr["IS_QUORUM_ADJOURNED"]);
                    // Temp.ParliamentaryYearsId = Convert.ToInt32(dr["Parliamentary_Years_Id"]);
                    // Temp.LegislationDiaryTime = Convert.ToDateTime(dr["Legislation_Diary_Time"]);
                    //Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                    //Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                    //Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);
                    //Temp.FileNo = Convert.ToString(dr["File_No"]);
                    //Temp.RequisitionDate = Convert.ToDateTime(dr["Requisition_Date"]);
                    //Temp.RequisitionTime = Convert.ToDateTime(dr["Requisition_Time"]);
                    //Temp.TotalWorkingDays = Convert.ToInt32(dr["Total_Working_Days"]);
                    //Temp.ActualSittingDays = Convert.ToInt32(dr["Actual_Sitting_Days"]);
                    //Temp.SummonNoticeDate = Convert.ToDateTime(dr["Summon_Notice_Date"]);
                    //Temp.SummonNoticeTime = Convert.ToDateTime(dr["Summon_Notice_Time"]);


                }

                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public AssemblySessions GetCurrentAssemblySessionDetails()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CURRENT_SESSION_DETAILS";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AssemblySessions Temp = new AssemblySessions();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp.AssemblySessionsId = Convert.ToInt32(dr["Assembly_Sessions_Id"]);
                    Temp.CalledBy = Convert.ToString(dr["Called_By"]);
                    // Temp.IsJointSession = Convert.ToInt32(dr["Is_Joint_Session"]);
                    Temp.SessionNumber = Convert.ToInt32(dr["Session_Number"]);
                    if (dr["Start_Date"] != DBNull.Value)
                        Temp.StartDate = Convert.ToDateTime(dr["Start_Date"]);
                    if (dr["End_Date"] != DBNull.Value)
                        Temp.EndDate = Convert.ToDateTime(dr["End_Date"]);
                    //Temp.SittingTypeId = Convert.ToInt32(dr["Sitting_Type_Id"]);
                    Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                    if (dr["Assemblies_Id"] != DBNull.Value)
                        Temp.AssembliesId = Convert.ToInt32(dr["Assemblies_Id"]);
                    if (dr["Business_Sessions"] != DBNull.Value)
                        Temp.BusinessSessions = Convert.ToString(dr["Business_Sessions"]);
                    if (dr["Business_Status"] != DBNull.Value)
                        Temp.BusinessStatus = Convert.ToInt32(dr["Business_Status"]);
                    //Temp.SummonedBy = Convert.ToInt32(dr["Summoned_By"]);
                    //Temp.ProroguedBy = Convert.ToInt32(dr["Prorogued_By"]);
                    //Temp.LegislationDiaryNo = Convert.ToInt32(dr["Legislation_Diary_No"]);
                    //Temp.LegislationDiaryDate = Convert.ToDateTime(dr["Legislation_Diary_Date"]);
                    //Temp.SessStatusesId = Convert.ToInt32(dr["Sess_Statuses_Id"]);
                    //Temp.IsQuorumAdjourned = Convert.ToInt32(dr["IS_QUORUM_ADJOURNED"]);
                    // Temp.ParliamentaryYearsId = Convert.ToInt32(dr["Parliamentary_Years_Id"]);
                    // Temp.LegislationDiaryTime = Convert.ToDateTime(dr["Legislation_Diary_Time"]);
                    //Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                    //Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                    //Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);
                    //Temp.FileNo = Convert.ToString(dr["File_No"]);
                    //Temp.RequisitionDate = Convert.ToDateTime(dr["Requisition_Date"]);
                    //Temp.RequisitionTime = Convert.ToDateTime(dr["Requisition_Time"]);
                    //Temp.TotalWorkingDays = Convert.ToInt32(dr["Total_Working_Days"]);
                    //Temp.ActualSittingDays = Convert.ToInt32(dr["Actual_Sitting_Days"]);
                    //Temp.SummonNoticeDate = Convert.ToDateTime(dr["Summon_Notice_Date"]);
                    //Temp.SummonNoticeTime = Convert.ToDateTime(dr["Summon_Notice_Time"]);


                }

                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public List<AssemblySessions> GetAssemblySessions()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ASSEMBLY_SESSIONS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<AssemblySessions> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<AssemblySessions>();
                    while (dr.Read())
                    {
                        AssemblySessions Temp = new AssemblySessions();
                        Temp.AssemblySessionsId = Convert.ToInt32(dr["Assembly_Sessions_Id"]);
                        // Temp.CalledBy = Convert.ToInt32(dr["Called_By"]);
                        // Temp.IsJointSession = Convert.ToInt32(dr["Is_Joint_Session"]);
                        Temp.SessionNumber = Convert.ToInt32(dr["Session_Number"]);
                        //Temp.StartDate = Convert.ToDateTime(dr["Start_Date"]);
                        //Temp.EndDate = Convert.ToDateTime(dr["End_Date"]);
                        //Temp.SittingTypeId = Convert.ToInt32(dr["Sitting_Type_Id"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        //Temp.AssembliesId = Convert.ToInt32(dr["Assemblies_Id"]);
                        //Temp.SummonedBy = Convert.ToInt32(dr["Summoned_By"]);
                        //Temp.ProroguedBy = Convert.ToInt32(dr["Prorogued_By"]);
                        //Temp.LegislationDiaryNo = Convert.ToInt32(dr["Legislation_Diary_No"]);
                        //Temp.LegislationDiaryDate = Convert.ToDateTime(dr["Legislation_Diary_Date"]);
                        //Temp.SessStatusesId = Convert.ToInt32(dr["Sess_Statuses_Id"]);
                        //Temp.IsQuorumAdjourned = Convert.ToInt32(dr["IS_QUORUM_ADJOURNED"]);
                        // Temp.ParliamentaryYearsId = Convert.ToInt32(dr["Parliamentary_Years_Id"]);
                        // Temp.LegislationDiaryTime = Convert.ToDateTime(dr["Legislation_Diary_Time"]);
                        //Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                        //Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                        //Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);
                        //Temp.FileNo = Convert.ToString(dr["File_No"]);
                        //Temp.RequisitionDate = Convert.ToDateTime(dr["Requisition_Date"]);
                        //Temp.RequisitionTime = Convert.ToDateTime(dr["Requisition_Time"]);
                        //Temp.TotalWorkingDays = Convert.ToInt32(dr["Total_Working_Days"]);
                        //Temp.ActualSittingDays = Convert.ToInt32(dr["Actual_Sitting_Days"]);
                        //Temp.SummonNoticeDate = Convert.ToDateTime(dr["Summon_Notice_Date"]);
                        //Temp.SummonNoticeTime = Convert.ToDateTime(dr["Summon_Notice_Time"]);
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
        public int GetCurrentAssemblySessions()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CURRENT_SESSION";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                int AssemblySessionsId = 0;
                if (dr.HasRows)
                {
                    dr.Read();
                    AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);

                }
                return AssemblySessionsId;
            }
            finally
            {
                con.Close();

            }
        }


        public string GetMemberNameById(int MemberId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBER_NAME_BY_ID";
                cmd.Parameters.Add("@MemberId", SqlDbType.Int).Value = MemberId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                string MemberName = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    MemberName = Convert.ToString(dr["SENATOR_NAME"]);

                }
                return MemberName;
            }
            finally
            {
                con.Close();

            }
        }


        public void UpdateAssemblySessions(AssemblySessions Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_ASSEMBLY_SESSION";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = Temp.AssemblySessionsId;
                cmd.Parameters.Add("@CalledBy", SqlDbType.VarChar).Value = Temp.CalledBy;
                cmd.Parameters.Add("@BusinessSessions", SqlDbType.VarChar).Value = Temp.BusinessSessions;
                cmd.Parameters.Add("@SessionNumber", SqlDbType.Int).Value = Temp.SessionNumber;
                cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = Temp.StartDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = Temp.EndDate;
                //cmd.Parameters.Add("@Sitting_Type_Id", SqlDbType.Int).Value = Temp.SittingTypeId;
                //cmd.Parameters.Add("@Is_Active", SqlDbType.Int).Value = Temp.IsActive;
                //cmd.Parameters.Add("@Assemblies_Id", SqlDbType.Int).Value = Temp.AssembliesId;
                //cmd.Parameters.Add("@Summoned_By", SqlDbType.Int).Value = Temp.SummonedBy;
                //cmd.Parameters.Add("@Prorogued_By", SqlDbType.Int).Value = Temp.ProroguedBy;
                //cmd.Parameters.Add("@Legislation_Diary_No", SqlDbType.Int).Value = Temp.LegislationDiaryNo;
                //cmd.Parameters.Add("@Legislation_Diary_Date", SqlDbType.Date).Value = Temp.LegislationDiaryDate;
                //cmd.Parameters.Add("@Sess_Statuses_Id", SqlDbType.Int).Value = Temp.SessStatusesId;
                //cmd.Parameters.Add("@Is_Quorum_Adjourned", SqlDbType.Int).Value = Temp.IsQuorumAdjourned;
                cmd.Parameters.Add("@ParliamentaryYearsId", SqlDbType.Int).Value = Temp.ParliamentaryYearsId;
                //cmd.Parameters.Add("@Legislation_Diary_Time", SqlDbType.Date).Value = Temp.LegislationDiaryTime;
                //cmd.Parameters.Add("@Notice_Diary_No", SqlDbType.Int).Value = Temp.NoticeDiaryNo;
                //cmd.Parameters.Add("@Notice_Diary_Date", SqlDbType.Date).Value = Temp.NoticeDiaryDate;
                //cmd.Parameters.Add("@Notice_Diary_Time", SqlDbType.Date).Value = Temp.NoticeDiaryTime;
                //cmd.Parameters.Add("@File_No", SqlDbType.VarChar).Value = Temp.FileNo;
                //cmd.Parameters.Add("@Requisition_Date", SqlDbType.Date).Value = Temp.RequisitionDate;
                //cmd.Parameters.Add("@Requisition_Time", SqlDbType.Date).Value = Temp.RequisitionTime;
                //cmd.Parameters.Add("@Total_Working_Days", SqlDbType.Int).Value = Temp.TotalWorkingDays;
                //cmd.Parameters.Add("@Actual_Sitting_Days", SqlDbType.Int).Value = Temp.ActualSittingDays;
                //cmd.Parameters.Add("@Summon_Notice_Date", SqlDbType.Date).Value = Temp.SummonNoticeDate;
                //cmd.Parameters.Add("@Summon_Notice_Time", SqlDbType.Date).Value = Temp.SummonNoticeTime;
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
        public int InsertAssemblySessions(AssemblySessions Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_ASSEMBLY_SESSION";
                cmd.Parameters.Add("@CalledBy", SqlDbType.VarChar).Value = Temp.CalledBy;
                //  cmd.Parameters.Add("@Is_Joint_Session", SqlDbType.Int).Value = Temp.IsJointSession;
                cmd.Parameters.Add("@SessionNumber", SqlDbType.Int).Value = Temp.SessionNumber;
                cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = Temp.StartDate;
                // cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = Temp.EndDate;
                // cmd.Parameters.Add("@Sitting_Type_Id", SqlDbType.Int).Value = Temp.SittingTypeId;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = 1;
                // cmd.Parameters.Add("@Assemblies_Id", SqlDbType.Int).Value = Temp.AssembliesId;
                // cmd.Parameters.Add("@Summoned_By", SqlDbType.Int).Value = Temp.SummonedBy;
                // cmd.Parameters.Add("@Prorogued_By", SqlDbType.Int).Value = Temp.ProroguedBy;
                // cmd.Parameters.Add("@Legislation_Diary_No", SqlDbType.Int).Value = Temp.LegislationDiaryNo;
                // cmd.Parameters.Add("@Legislation_Diary_Date", SqlDbType.Date).Value = Temp.LegislationDiaryDate;
                //  cmd.Parameters.Add("@Sess_Statuses_Id", SqlDbType.Int).Value = Temp.SessStatusesId;
                // cmd.Parameters.Add("@Is_Quorum_Adjourned", SqlDbType.Int).Value = Temp.IsQuorumAdjourned;
                cmd.Parameters.Add("@ParliamentaryYearsId", SqlDbType.Int).Value = Temp.ParliamentaryYearsId;
                cmd.Parameters.Add("@BusinessSessions", SqlDbType.VarChar).Value = Temp.BusinessSessions;
                // cmd.Parameters.Add("@Legislation_Diary_Time", SqlDbType.Date).Value = Temp.LegislationDiaryTime;
                // cmd.Parameters.Add("@Notice_Diary_No", SqlDbType.Int).Value = Temp.NoticeDiaryNo;
                // cmd.Parameters.Add("@Notice_Diary_Date", SqlDbType.Date).Value = Temp.NoticeDiaryDate;
                // cmd.Parameters.Add("@Notice_Diary_Time", SqlDbType.Date).Value = Temp.NoticeDiaryTime;
                // cmd.Parameters.Add("@File_No", SqlDbType.VarChar).Value = Temp.FileNo;
                // cmd.Parameters.Add("@Requisition_Date", SqlDbType.Date).Value = Temp.RequisitionDate;
                // cmd.Parameters.Add("@Requisition_Time", SqlDbType.Date).Value = Temp.RequisitionTime;
                // cmd.Parameters.Add("@Total_Working_Days", SqlDbType.Int).Value = Temp.TotalWorkingDays;
                // cmd.Parameters.Add("@Actual_Sitting_Days", SqlDbType.Int).Value = Temp.ActualSittingDays;
                // cmd.Parameters.Add("@Summon_Notice_Date", SqlDbType.Date).Value = Temp.SummonNoticeDate;
                // cmd.Parameters.Add("@Summon_Notice_Time", SqlDbType.Date).Value = Temp.SummonNoticeTime;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteScalar();
                int id = Convert.ToInt32(cmd.Parameters["@ID"].Value.ToString());

                return id;
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

        #endregion AssemblySessions



        #region  QUESTION_CATEGORY

        public List<QuestionCategories> GetQuestionCategories()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_QUESTION_CATOGORIES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<QuestionCategories> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<QuestionCategories>();
                    while (dr.Read())
                    {
                        QuestionCategories Temp = new QuestionCategories();

                        Temp.QuestionCategoriesId = Convert.ToInt32(dr["QUESTION_CATEGORIES_ID"]);
                        Temp.Description = Convert.ToString(dr["Description"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
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
        public void UpdateQuestionCategory(QuestionCategories Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_QUESTION_CATOGORY";
                cmd.Parameters.Add("@QuestionCategoriesId", SqlDbType.Int).Value = Temp.QuestionCategoriesId;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
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
        public void InsertQuestionCategory(QuestionCategories Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_QUESTION_CATOGORY";
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
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
        #endregion QUESTION_CATEGORY

        public List<ResolutionStatusesEnt> GetResolutionStatuses()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RESOLUTION_STATUSES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<ResolutionStatusesEnt> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ResolutionStatusesEnt>();
                    while (dr.Read())
                    {
                        ResolutionStatusesEnt Temp = new ResolutionStatusesEnt();

                        Temp.ResolutionStatusesId = Convert.ToInt32(dr["RESOLUTION_STATUSES_ID"]);
                        Temp.Description = Convert.ToString(dr["DESCRIPTION"]);
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
        public List<ResolutionTypeEnt> GetResolutionTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RESOLUTION_TYPES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<ResolutionTypeEnt> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ResolutionTypeEnt>();
                    while (dr.Read())
                    {
                        ResolutionTypeEnt Temp = new ResolutionTypeEnt();

                        Temp.ResTypesId = Convert.ToInt32(dr["RES_TYPES_ID"]);
                        Temp.Description = Convert.ToString(dr["DESCRIPTION"]);
                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        // Temp.BranchesId = Convert.ToInt32(dr["BRANCHES_ID"]);
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
    }
}
