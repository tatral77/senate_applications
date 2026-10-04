using Entities;
using EstablishmentENT;
using LegisDAL;
using LegisEntities;

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
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
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
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_DIVIDION";
                cmd.Parameters.Add("@DivisionId", SqlDbType.Int).Value = Temp.DivisionsId;
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
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_DIVISION";
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
      
        #endregion Divisions

        //------------------------------------END-----------------------//.

        //#region Question_Status

        //public List<QuestionStatuses> GetQuestionStatuses()
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_QUESTION_STATUSES";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<QuestionStatuses> MyList = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            MyList = new List<QuestionStatuses>();
        //            while (dr.Read())
        //            {
        //                QuestionStatuses Temp = new QuestionStatuses();
        //                Temp.QuestionStatusesId = Convert.ToInt32(dr["Question_Statuses_Id"]);
        //                Temp.Description = Convert.ToString(dr["Description"]);
        //                Temp.ActionName = Convert.ToString(dr["Action_Name"]);
        //                Temp.StatusLevel = Convert.ToString(dr["Status_Level"]);
        //                Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
        //                //Temp.DisplaySequence = Convert.ToInt32(dr["Display_Sequence"]); DISPLAY_SEQUENCE
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
        //public List<QuestionStatuses> GetQuestionActiveStatus()
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_QUESTION_STATUSES";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<QuestionStatuses> MyList = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            MyList = new List<QuestionStatuses>();
        //            while (dr.Read())
        //            {
        //                QuestionStatuses Temp = new QuestionStatuses();
        //                Temp.QuestionStatusesId = Convert.ToInt32(dr["Question_Statuses_Id"]);
        //                Temp.Description = Convert.ToString(dr["Description"]);
        //                Temp.ActionName = Convert.ToString(dr["Action_Name"]);
        //                Temp.StatusLevel = Convert.ToString(dr["Status_Level"]);
        //                Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
        //                //Temp.DisplaySequence = Convert.ToInt32(dr["Display_Sequence"]); DISPLAY_SEQUENCE
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

        //public void UpdateQuestionStatuses(QuestionStatuses Temp)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_QUESTION_STATUS";
        //        cmd.Parameters.Add("@Descriptation", SqlDbType.Int).Value = Temp.Description;
        //        cmd.Parameters.Add("@Action_Name", SqlDbType.VarChar).Value = Temp.ActionName;
        //        cmd.Parameters.Add("@Status_Level", SqlDbType.VarChar).Value = Temp.StatusLevel;
        //        cmd.Parameters.Add("@Is_Active", SqlDbType.Int).Value = Temp.IsActive;
        //        cmd.Parameters.Add("@Display_Sequence", SqlDbType.Int).Value = Temp.DisplaySequence;
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
        //public void InsertQuestionStatuses(QuestionStatuses Temp)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_QUESTION_STATUS";
        //        cmd.Parameters.Add("@Descriptation", SqlDbType.Int).Value = Temp.Description;
        //        cmd.Parameters.Add("@Action_Name", SqlDbType.VarChar).Value = Temp.ActionName;
        //        cmd.Parameters.Add("@Status_Level", SqlDbType.VarChar).Value = Temp.StatusLevel;
        //        cmd.Parameters.Add("@Is_Active", SqlDbType.Int).Value = Temp.IsActive;
        //        cmd.Parameters.Add("@Display_Sequence", SqlDbType.Int).Value = Temp.DisplaySequence;
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



        //#endregion Question_Status


        //#region  QUESTION_CATEGORY

        //public List<QuestionCategories> GetQuestionCategories()
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_QUESTION_CATOGORIES";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<QuestionCategories> MyList = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            MyList = new List<QuestionCategories>();
        //            while (dr.Read())
        //            {
        //                QuestionCategories Temp = new QuestionCategories();

        //                Temp.QuestionCategoriesId = Convert.ToInt32(dr["QUESTION_CATEGORIES_ID"]);
        //                Temp.Description = Convert.ToString(dr["Description"]);
        //                Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
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
        //public void UpdateQuestionCategory(QuestionCategories Temp)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_QUESTION_CATOGORY";
        //        cmd.Parameters.Add("@QuestionCategoriesId", SqlDbType.Int).Value = Temp.QuestionCategoriesId;
        //        cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
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
        //public void InsertQuestionCategory(QuestionCategories Temp)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_QUESTION_CATOGORY";
        //        cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
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
        //#endregion QUESTION_CATEGORY

        //------------------------------------END-----------------------//.

        #region Parliamentary_Years

        public List<ParliamentaryYears> GetParliamentaryYears()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PARLIAMENTARY_YEARS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<ParliamentaryYears> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ParliamentaryYears>();
                    while (dr.Read())
                    {
                        ParliamentaryYears Temp = new ParliamentaryYears();

                        Temp.ParliamentaryYearsId = Convert.ToInt32(dr["Parliamentary_Years_Id"]);
                        Temp.ParliamentaryYear = Convert.ToString(dr["Parliamentary_Year"]);
                        Temp.FromDate = Convert.ToDateTime(dr["From_Date"]);
                        Temp.ToDate = Convert.ToDateTime(dr["To_Date"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        Temp.ParliamentaryTenuresId = Convert.ToInt32(dr["PARLIAMENTARY_TENURES_ID"]);
                        Temp.ParliamentaryTenure = Convert.ToString(dr["PARLIAMENTARY_TENURE_DESC"]);
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

        public ParliamentaryYears GetCurrentParliamentaryYear()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CURRENT_PARLIAMENTARY_YEAR";
                cmd.CommandType = CommandType.StoredProcedure;
                ParliamentaryYears Temp= null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Temp = new ParliamentaryYears();
                    dr.Read();
                        Temp.ParliamentaryYearsId = Convert.ToInt32(dr["Parliamentary_Years_id"]);
                        Temp.ParliamentaryYear = Convert.ToString(dr["Parliamentary_Year"]);
                        Temp.FromDate = Convert.ToDateTime(dr["From_Date"]);
                        Temp.ToDate = Convert.ToDateTime(dr["To_Date"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        Temp.ParliamentaryTenuresId = Convert.ToInt32(dr["PARLIAMENTARY_TENURES_ID"]);
                        //Temp.ParliamentaryTenure = Convert.ToString(dr["PARLIAMENTARY_TENURE_DESC"]);
                    
                }

                return Temp;
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
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_PARLIAMENTARY_YEAR";
                cmd.Parameters.Add("@ParliamentaryYearsId", SqlDbType.Int).Value = Temp.ParliamentaryYearsId;
                cmd.Parameters.Add("@ParliamentaryYear", SqlDbType.VarChar).Value = Temp.ParliamentaryYear;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = Temp.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = Temp.ToDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.Parameters.Add("@ParliamentaryTenuresId", SqlDbType.Int).Value = Temp.ParliamentaryTenuresId;
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
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_PARLIAMENTARY_YEAR"; 
                 cmd.Parameters.Add("@ParliamentaryTenuresId", SqlDbType.Int).Value = Temp.ParliamentaryTenuresId;
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
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
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
                        if(dr["Is_Stat_Min"]!=DBNull.Value)
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
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
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
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
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
      
        public List<Divisions> GetDivisionsByName(string DivisionName)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_DIVISION_BY_NAME";
                cmd.Parameters.Add("@Division", SqlDbType.VarChar).Value = DivisionName;
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
                        //Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        //Temp.MinistriesId = Convert.ToInt32(dr["Ministries_Id"]);
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
        public List<Divisions> GetCurrentDivisionsByName(string DivisionName)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CURRENT_DIVISION_BY_NAME";
                cmd.Parameters.Add("@Division", SqlDbType.VarChar).Value = DivisionName;
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
                        //Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        //Temp.MinistriesId = Convert.ToInt32(dr["Ministries_Id"]);
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

        //public List<DivisionGroups> GetDivisionGroups(int AssemblySessionId, int DivisionId)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_DIVISION_GROUPS";
        //        cmd.Parameters.Add("@DivisionId", SqlDbType.Int).Value = DivisionId;
        //        cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = AssemblySessionId;
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
        //        SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
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
        //            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
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
        //        SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_ROTA";
        //        cmd.Parameters.Add("@RotaId", SqlDbType.Int).Value = Temp.RotaListId;
        //        cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = Temp.AssemblySessionsId;
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
        //        SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_ROTA";
        //        cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = Temp.AssemblySessionsId;
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
        //        SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
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
   




        #region MEMBER STATUS
        public List<MemberStatus> GetMemberStatuses()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBER_STATUSES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<MemberStatus> Temp = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        Temp = new List<MemberStatus>();
                        while (dr.Read())
                        {
                            MemberStatus ad = new MemberStatus();
                            ad.MemberStatusId = Convert.ToInt32(dr["MEMBER_STATUSES_ID"]);
                            ad.MemStatus = Convert.ToString(dr["DESCRIPTION"]);
                            Temp.Add(ad);
                        }
                    }
                }
                if (Temp != null) Temp.TrimExcess();
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion MEMBER STATUS

        #region POLITICAL_PARTY
        public List<PoliticalParty> GetPoliticalParties()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_POLITICAL_PARTIES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<PoliticalParty> Temp = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        Temp = new List<PoliticalParty>();
                        while (dr.Read())
                        {
                            PoliticalParty ad = new PoliticalParty();
                            ad.PartyId = Convert.ToInt32(dr["POLITICAL_PARTIES_ID"]);
                            ad.PartyName = Convert.ToString(dr["DESCRIPTION"]);
                            Temp.Add(ad);
                        }
                    }
                }
                if (Temp != null) Temp.TrimExcess();
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion POLITICAL_PARTY

        #region ELECTION TYPES
        public List<ElectionTypes> GetElectionTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ELECTION_TYPES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<ElectionTypes> Temp = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        Temp = new List<ElectionTypes>();
                        while (dr.Read())
                        {
                            ElectionTypes ad = new ElectionTypes();
                            ad.ElectionTypesId = Convert.ToInt32(dr["ELECTION_TYPES_ID"]);
                            ad.Description = Convert.ToString(dr["DESCRIPTION"]);
                            Temp.Add(ad);
                        }
                    }
                }
                if (Temp != null) Temp.TrimExcess();
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion ELECTION_TYPES
        public List<Gender> GetGenders()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_GENDERS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Gender> gender = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        gender = new List<Gender>();
                        while (dr.Read())
                        {
                            Gender ad = new Gender();
                            ad.GenderId = Convert.ToInt32(dr["Genders_id"]);
                            ad.Description = Convert.ToString(dr["Description"]);
                            ad.IsActive = Convert.ToInt32(dr["Is_Active"]);
                            gender.Add(ad);
                        }
                    }
                }
                if (gender != null) gender.TrimExcess();
                return gender;
            }
            finally
            {
                con.Close();

            }
        }


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

        #region  ParliamentaryTenures

        public List<ParliamentaryTenures> GetParliamentaryTenures()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PARLIAMENTARY_TENURES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<ParliamentaryTenures> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ParliamentaryTenures>();
                    while (dr.Read())
                    {
                        ParliamentaryTenures Temp = new ParliamentaryTenures();
                        Temp.ParliamentaryTenuresId = Convert.ToInt32(dr["Parliamentary_Tenures_Id"]);
                        Temp.Description = Convert.ToString(dr["Description"]);
                        Temp.FromDate = Convert.ToDateTime(dr["From_Date"]);
                        Temp.ToDate = Convert.ToDateTime(dr["To_Date"]);
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
        public void UpdateParliamentaryTenures(ParliamentaryTenures Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_PARLIAMENTARY_TENURE";
                cmd.Parameters.Add("@ParliamentaryTenuresId", SqlDbType.Int).Value = Temp.ParliamentaryTenuresId;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
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
        public void InsertParliamentaryTenures(ParliamentaryTenures Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_PARLIAMENTARY_TENURES";
                cmd.Parameters.Add("@Descriptation", SqlDbType.VarChar).Value = Temp.Description;
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

        #endregion ParliamentaryTemnures

        #region  ParliamentaryTerms

        public List<ParliamentaryTerms> GetParliamentaryTerms()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PARLIAMENTARY_TERMS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<ParliamentaryTerms> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ParliamentaryTerms>();
                    while (dr.Read())
                    {
                        ParliamentaryTerms Temp = new ParliamentaryTerms();
                        Temp.ParliamentaryTermsId = Convert.ToInt32(dr["Parliamentary_Terms_Id"]);
                        Temp.Description = Convert.ToString(dr["Description"]);
                        Temp.FromDate = Convert.ToDateTime(dr["From_Date"]);
                        Temp.ToDate = Convert.ToDateTime(dr["To_Date"]);
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
        public void UpdateParliamentaryTerm(ParliamentaryTerms Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_PARLIAMENTARY_TERM";
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@ParliamentaryTermsId", SqlDbType.Int).Value = Temp.ParliamentaryTermsId;
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
        public void InsertParliamentaryTerm(ParliamentaryTerms Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_PARLIAMENTARY_TERM";
                cmd.Parameters.Add("@Descriptation", SqlDbType.VarChar).Value = Temp.Description;
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

        #endregion ParliamentaryTerms

        //------------------------------------END-------------------------------------//

        #region Assemblies
        public List<Assemblies> GetAssemblies()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ASSEMBLIES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Assemblies> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Assemblies>();
                    while (dr.Read())
                    {
                        Assemblies Temp = new Assemblies();
                        Temp.AssembliesId = Convert.ToInt32(dr["Assemblies_Id"]);
                        Temp.Term = Convert.ToString(dr["Term"]);
                        Temp.FromDate = Convert.ToDateTime(dr["From_Date"]);
                        Temp.ToDate = Convert.ToDateTime(dr["To_Date"]);
                        Temp.NoOfSeats = Convert.ToInt32(dr["No_Of_Seats"]);
                        Temp.ElectionYear = Convert.ToInt32(dr["Election_Year"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        Temp.MaxStarredAllowed = Convert.ToInt32(dr["Max_Starred_Allwd"]);
                        Temp.MaxUnStarredAllowed = Convert.ToInt32(dr["MAX_UNSTAR_ALLWD"]);
                        Temp.MaxSNoticeAllowed = Convert.ToInt32(dr["MAX_S_NOTICE_ALWD"]);
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
        public void UpdateAssemblies(Assemblies Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_ASSEMBLY";
                cmd.Parameters.Add("@Term", SqlDbType.VarChar).Value = Temp.Term;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = Temp.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = Temp.ToDate;
                cmd.Parameters.Add("@NoOfSeats", SqlDbType.Date).Value = Temp.NoOfSeats;
                cmd.Parameters.Add("@ElectionYear", SqlDbType.Date).Value = Temp.ElectionYear;
                cmd.Parameters.Add("@MaxStarredAllowed", SqlDbType.Int).Value = Temp.MaxStarredAllowed;
                cmd.Parameters.Add("@MaxUnStarredAllowed", SqlDbType.Int).Value = Temp.MaxUnStarredAllowed;
                cmd.Parameters.Add("@MaxSNoticeAllowed", SqlDbType.Int).Value = Temp.MaxSNoticeAllowed;
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
        public void InsertAssemblies(Assemblies Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_ASSEMBLY";
                cmd.Parameters.Add("@Term", SqlDbType.VarChar).Value = Temp.Term;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = Temp.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = Temp.ToDate;
                cmd.Parameters.Add("@NoOfSeats", SqlDbType.Date).Value = Temp.NoOfSeats;
                cmd.Parameters.Add("@ElectionYear", SqlDbType.Date).Value = Temp.ElectionYear;
                cmd.Parameters.Add("@MaxStarredAllowed", SqlDbType.Int).Value = Temp.MaxStarredAllowed;
                cmd.Parameters.Add("@MaxUnStarredAllowed", SqlDbType.Int).Value = Temp.MaxUnStarredAllowed;
                cmd.Parameters.Add("@MaxSNoticeAllowed", SqlDbType.Int).Value = Temp.MaxSNoticeAllowed;
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

        #endregion Assemblies

        //------------------------------------END-------------------------------------//

        #region SittingTypes

        public List<SittingTypes> GetSittingTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SITTING_TYPES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<SittingTypes> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<SittingTypes>();
                    while (dr.Read())
                    {
                        SittingTypes Temp = new SittingTypes();
                        Temp.SittingTypesId = Convert.ToInt32(dr["Sitting_Types_Id"]);
                        Temp.Description = Convert.ToString(dr["Descriptation"]);
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
        public void UpdateSittingTypes(SittingTypes Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_SITTING_TYPE";
                cmd.Parameters.Add("@Descriptation", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@IsActive", SqlDbType.Date).Value = Temp.IsActive;
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
        public void InsertSittingTypes(SittingTypes Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_SITTING_TYPE";
                cmd.Parameters.Add("@Descriptation", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@IsActive", SqlDbType.Date).Value = Temp.IsActive;
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

        #endregion SittingTypes
        #region SessionSittings

        public List<SessionSittings> GetSessionSitting()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SESSION_SITTINGS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<SessionSittings> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<SessionSittings>();
                    while (dr.Read())
                    {
                        SessionSittings Temp = new SessionSittings();
                        Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
                        Temp.AssembliesSessionId = Convert.ToInt32(dr["Assembly_Sessions_Id"]);
                        Temp.AssemblySession = Convert.ToString(dr["Session_Number"]);
                        Temp.IsAdjourned = Convert.ToInt32(dr["Is_Adjourned"]);
                        Temp.SittingDate = Convert.ToDateTime(dr["SITTING_DATE"]);
                        Temp.StartTime = Convert.ToDateTime(dr["Start_Time"]);
                        Temp.EndTime = Convert.ToDateTime(dr["End_Time"]);
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
        public List<SessionSittings> GetSessionSittingBySession(int AssebmblySessionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SESSION_SITTINGS_BY_SESSION";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = AssebmblySessionId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<SessionSittings> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<SessionSittings>();
                    while (dr.Read())
                    {
                        SessionSittings Temp = new SessionSittings();
                        Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
                        Temp.AssembliesSessionId = Convert.ToInt32(dr["Assembly_Sessions_Id"]);
                        Temp.AssemblySession = Convert.ToString(dr["Session_Number"]);
                        Temp.IsAdjourned = Convert.ToInt32(dr["Is_Adjourned"]);
                        Temp.SittingDate = Convert.ToDateTime(dr["SITTING_DATE"]);
                        Temp.StartTime = Convert.ToDateTime(dr["Start_Time"]);
                        Temp.EndTime = Convert.ToDateTime(dr["End_Time"]);
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

        public SessionSittings GetSessionSittingById(int SittingId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SESSION_SITTING_BY_ID";
                cmd.Parameters.Add("@SessionSittingId", SqlDbType.Int).Value = SittingId;
                cmd.CommandType = CommandType.StoredProcedure;
                SessionSittings Temp = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Temp = new SessionSittings();
                    dr.Read();
                    Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
                    Temp.AssembliesSessionId = Convert.ToInt32(dr["Assembly_Sessions_Id"]);
                    Temp.AssemblySession = Convert.ToString(dr["Session_Number"]);
                    Temp.IsAdjourned = Convert.ToInt32(dr["Is_Adjourned"]);
                    Temp.SittingDate = Convert.ToDateTime(dr["SITTING_DATE"]);
                    Temp.StartTime = Convert.ToDateTime(dr["Start_Time"]);
                    Temp.EndTime = Convert.ToDateTime(dr["End_Time"]);

                }
                return Temp;
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateSessionSittings(SessionSittings Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_SESSION_SITTING";
                cmd.Parameters.Add("@SessionSittingId", SqlDbType.VarChar).Value = Temp.SessionSittingsId;
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.VarChar).Value = Temp.AssembliesSessionId;
                cmd.Parameters.Add("@IsAdjourned", SqlDbType.VarChar).Value = Temp.IsAdjourned;
                cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = Temp.StartTime;
                cmd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = Temp.EndTime;
                cmd.Parameters.Add("@SittingDate", SqlDbType.DateTime).Value = Temp.SittingDate;
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
        public void InsertSessionSittings(SessionSittings Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_SESSION_SITTING";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = Temp.AssembliesSessionId;
                cmd.Parameters.Add("@IsAdjourned", SqlDbType.VarChar).Value = Temp.IsAdjourned;
                cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = Temp.StartTime;
                cmd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = Temp.EndTime;
                cmd.Parameters.Add("@SittingDate", SqlDbType.DateTime).Value = Temp.SittingDate;
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

        #endregion SessionSitting
        #region AssemblySessions
        public AssemblySessions GetAssemblySession( int AssemblySessionId)
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
					if(dr["End_Date"]!=DBNull.Value)
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
					if(dr["Start_Date"]!=DBNull.Value)
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
				int AssemblySessionsId=0;
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
				string MemberName=null;
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
				cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = Temp.EndDate ;
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
        #region  ParliamentaryTenures

        public List<ParliamentaryTenures> GetParliamentaryTenuress()
        {
            return new LegislationDal().GetParliamentaryTenures();
        }
        public void UpdateParliamentaryTerms(ParliamentaryTenures Temp)
        {
            new LegislationDal().UpdateParliamentaryTenures(Temp);
        }
        public void InsertParliamentaryTenure(ParliamentaryTenures Temp)
        {
            new LegislationDal().InsertParliamentaryTenures(Temp);
        }

        #endregion ParliamentaryTerms

        //#region  MOTION_TYPES

        //public List<MotionTypeEnt> GetMotionTypes()
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MOTION_TYPES";
        //        cmd.Parameters.Add("@IsForMotion", SqlDbType.VarChar).Value = 1;

        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<MotionTypeEnt> MyList = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            MyList = new List<MotionTypeEnt>();
        //            while (dr.Read())
        //            {
        //                MotionTypeEnt Temp = new MotionTypeEnt();

        //                Temp.MotionTypeId = Convert.ToInt32(dr["MOTION_TYPES_ID"]);
        //                Temp.Description = Convert.ToString(dr["DESCRIPTION"]);
        //                Temp.IsForMotions = Convert.ToInt32(dr["IS_FOR_MOTIONS"]);
        //                Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
        //                //Temp.SortOrder = Convert.ToInt32(dr["SORT_ORDER"]);
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
        //public void UpdateMotionType(MotionTypeEnt Temp)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MOTION_TYPE";
        //        cmd.Parameters.Add("@@MotionTypesId", SqlDbType.Int).Value = Temp.MotionTypeId;
        //        cmd.Parameters.Add("@Description", SqlDbType.Int).Value = Temp.Description;
        //        cmd.Parameters.Add("@IsForMotions", SqlDbType.Int).Value = Temp.IsForMotions;
        //        cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
        //        cmd.Parameters.Add("@SortOrder", SqlDbType.Int).Value = Temp.SortOrder;
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
        //public void InsertMotionType(MotionTypeEnt Temp)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MOTION_TYPE";
        //        cmd.Parameters.Add("@Description", SqlDbType.Int).Value = Temp.Description;
        //        cmd.Parameters.Add("@IsForMotions", SqlDbType.Int).Value = Temp.IsForMotions;
        //        cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
        //        cmd.Parameters.Add("@SortOrder", SqlDbType.Int).Value = Temp.SortOrder;
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
        //#endregion MOTION_TYPES

        //#region  MOTION_STATUSES

        //public List<MotionStatusEnt> GetMotionStatuses()
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MOTION_STATUSES";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<MotionStatusEnt> MyList = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            MyList = new List<MotionStatusEnt>();
        //            while (dr.Read())
        //            {
        //                MotionStatusEnt Temp = new MotionStatusEnt();

        //                Temp.MotionStatusId = Convert.ToInt32(dr["MOTION_STATUSES_ID"]);
        //                Temp.Description = Convert.ToString(dr["DESCRIPTION"]);
        //                Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
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
        //public void UpdateMotionStatus(MotionStatusEnt Temp)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MOTION_STATUS";
        //        cmd.Parameters.Add("@@MotionStatusesId", SqlDbType.Int).Value = Temp.MotionStatusId;
        //        cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
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
        //public void InsertMotionStatus(MotionStatusEnt Temp)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MOTION_STATUS";
        //        cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
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
        //#endregion MOTION_STATUSES
        //#region  RESOLUTION_TYPES

        //public List<ResolutionTypesEnt> GetResolutionTypes()
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RESOLUTION_TYPES";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<ResolutionTypesEnt> MyList = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            MyList = new List<ResolutionTypesEnt>();
        //            while (dr.Read())
        //            {
        //                ResolutionTypesEnt Temp = new ResolutionTypesEnt();

        //                Temp.ResTypesId = Convert.ToInt32(dr["RES_TYPES_ID"]);
        //                Temp.Description = Convert.ToString(dr["DESCRIPTION"]);
        //                Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
        //               // Temp.BranchesId = Convert.ToInt32(dr["BRANCHES_ID"]);
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

        //public ResolutionTypesEnt GetResolutionType(int ResolutionTypeId)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RESOLUTION_TYPE";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        ResolutionTypesEnt Temp = null;
        //        if (dr.HasRows)
        //        {
        //            dr.Read();

        //            Temp.ResTypesId = Convert.ToInt32(dr["RES_TYPES_ID"]);
        //            Temp.Description = Convert.ToString(dr["DESCRIPTION"]);
        //            Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
        //            Temp.BranchesId = Convert.ToInt32(dr["BRANCHES_ID"]);
        //        }


        //        return Temp;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}

        //public void UpdateResolutionTypes(ResolutionTypesEnt Temp)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_RESOLUTION_TYPES";
        //        cmd.Parameters.Add("@ResTypesId", SqlDbType.Int).Value = Temp.ResTypesId;
        //        cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
        //        cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
        //        cmd.Parameters.Add("@BranchesId", SqlDbType.Int).Value = Temp.BranchesId;
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
        //public void InsertResolutionTypes(ResolutionTypesEnt Temp)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_RESOLUTION_TYPES";
        //        cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
        //        cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
        //        cmd.Parameters.Add("@BranchesId", SqlDbType.Int).Value = Temp.BranchesId;
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
        //#endregion RESOLUTION_TYPES

        //#region  RESOLUTION_STATUSES
        //public List<ResolutionStatusesEnt> GetResolutionStatuses()
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RESOLUTION_STATUSES";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<ResolutionStatusesEnt> MyList = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            MyList = new List<ResolutionStatusesEnt>();
        //            while (dr.Read())
        //            {
        //                ResolutionStatusesEnt Temp = new ResolutionStatusesEnt();

        //                Temp.ResolutionStatusesId = Convert.ToInt32(dr["RESOLUTION_STATUSES_ID"]);
        //                Temp.Description = Convert.ToString(dr["DESCRIPTION"]);
        //                Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
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

        //public ResolutionStatusesEnt GetResolutionStatus(int ResolutionStatusesId)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RESOLUTION_STATUS";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        ResolutionStatusesEnt Temp = null;
        //        if (dr.HasRows)
        //        {
        //            dr.Read();
        //            Temp.ResolutionStatusesId = Convert.ToInt32(dr["RES_TYPES_ID"]);
        //            Temp.Description = Convert.ToString(dr["DESCRIPTION"]);
        //            Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
        //        }


        //        return Temp;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}

        //public void UpdateResolutionStatus(ResolutionStatusesEnt Temp)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_RESOLUTION_STATUS";
        //        cmd.Parameters.Add("@ResolutionStatusesId", SqlDbType.Int).Value = Temp.ResolutionStatusesId;
        //        cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
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
        //public void InsertResolutionStatus(ResolutionStatusesEnt Temp)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_RESOLUTION_STATUS";
        //        cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
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
        //#endregion RESOLUTION_STATUSES



    }
}
