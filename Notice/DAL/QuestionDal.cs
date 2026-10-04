using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace DAL
{
    public class QuestionDal
    {

        #region Questions

        public int GetQuestionPk()
        {
            int Questionsid = 1;
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_QUESTION_PK";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr["Questions_Id"] != DBNull.Value)
                {
                    Questionsid = Convert.ToInt32(dr["Questions_Id"]);
                    Questionsid++;
                }
                return Questionsid;
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
        public Questions GetQuestionById(int QuestionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_QUESTION_BY_ID";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.VarChar).Value = QuestionId;
                cmd.CommandType = CommandType.StoredProcedure;
                Questions Temp = new Questions();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp.QuestionsId = Convert.ToInt32(dr["Questions_Id"]);
                    Temp.ParliamentaryYear = Convert.ToString(dr["Parliamentary_Year"]);
                    Temp.QuestionStatus = Convert.ToString(dr["QUESTION_STATUS_DESC"]);
                    if (dr["Mover"] != DBNull.Value)
                    {
                        Temp.Mover = Convert.ToInt32(dr["Mover"]);
                        Temp.MoverName = Convert.ToString(dr["F_Name"]);
                    }
                    if (dr["QUESTION_CATEGORY"] != DBNull.Value)
                    {
                        Temp.QuestionCategoriesId = Convert.ToInt32(dr["QUESTION_CATEGORY"]);
                        Temp.QuestionCategory = Convert.ToString(dr["Category"]);
                    }
                    Temp.QuestionStatusId = Convert.ToInt32(dr["Question_Status"]);

                    if (dr["Question_Date"] != DBNull.Value)
                        Temp.QuestionDate = Convert.ToDateTime(dr["Question_Date"]);
                    if (dr["Question_Time"] != DBNull.Value)
                        Temp.QuestionTime = Convert.ToString(dr["Question_Time"]);
                    if (dr["Subject"] != DBNull.Value)
                    {
                        Temp.Subject = Convert.ToString(dr["Subject"]);
                    }
                    Temp.QuestionText = Convert.ToString(dr["Question_Text"]);
                    Temp.UrduText = Convert.ToString(dr["Urdu_Text"]);
                    if (dr["Question_File"] != DBNull.Value)
                        Temp.QuestionFile = Convert.ToString(dr["Question_File"]);
                    if (dr["Notice_Diary_No"] != DBNull.Value)

                        Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                    if (dr["Notice_Diary_Date"] != DBNull.Value)
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                    if (dr["Notice_Diary_Time"] != DBNull.Value)
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);

                    Temp.SessionNumberId = Convert.ToInt32(dr["Session_Number"]);
                    Temp.SessionNumber = Convert.ToString(dr["SESSION_NAME"]);
                    if (dr["Checked"] != DBNull.Value)
                        Temp.Checked = Convert.ToInt32(dr["Checked"]);
                    Temp.DeviceId = Convert.ToInt32(dr["DEVICE_ID"]);

                }
                else
                {
                   return GetQuestionByIdFromQuestion(QuestionId);
                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public Questions GetQuestionByIdFromQuestion(int QuestionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_QUESTION_BY_ID_FROM_QUESTION";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.VarChar).Value = QuestionId;
                cmd.CommandType = CommandType.StoredProcedure;
                Questions Temp = new Questions();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Temp.QuestionsId = Convert.ToInt32(dr["Questions_Id"]);
                    Temp.ParliamentaryYear = Convert.ToString(dr["Parliamentary_Year"]);
                    Temp.QuestionStatus = Convert.ToString(dr["QUESTION_STATUS_DESC"]);
                    if (dr["Mover"] != DBNull.Value)
                    {
                        Temp.Mover = Convert.ToInt32(dr["Mover"]);
                        Temp.MoverName = Convert.ToString(dr["F_Name"]);
                    }
                    if (dr["QUESTION_CATEGORY"] != DBNull.Value)
                    {
                        Temp.QuestionCategoriesId = Convert.ToInt32(dr["QUESTION_CATEGORY"]);
                        Temp.QuestionCategory = Convert.ToString(dr["Category"]);
                    }
                    Temp.QuestionStatusId = Convert.ToInt32(dr["Question_Status"]);

                    if (dr["Question_Date"] != DBNull.Value)
                        Temp.QuestionDate = Convert.ToDateTime(dr["Question_Date"]);
                    if (dr["Question_Time"] != DBNull.Value)
                        Temp.QuestionTime = Convert.ToString(dr["Question_Time"]);
                    if (dr["Subject"] != DBNull.Value)
                    {
                        Temp.Subject = Convert.ToString(dr["Subject"]);
                    }
                    Temp.QuestionText = Convert.ToString(dr["Question_Text"]);
                    Temp.UrduText = Convert.ToString(dr["Urdu_Text"]);
                    if (dr["Question_File"] != DBNull.Value)
                        Temp.QuestionFile = Convert.ToString(dr["Question_File"]);
                    if (dr["Notice_Diary_No"] != DBNull.Value)

                        Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                    if (dr["Notice_Diary_Date"] != DBNull.Value)
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                    if (dr["Notice_Diary_Time"] != DBNull.Value)
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);

                    Temp.SessionNumberId = Convert.ToInt32(dr["Session_Number"]);
                    Temp.SessionNumber = Convert.ToString(dr["SESSION_NAME"]);
                    if (dr["Checked"] != DBNull.Value)
                        Temp.Checked = Convert.ToInt32(dr["Checked"]);
                    Temp.DeviceId = Convert.ToInt32(dr["DEVICE_ID"]);

                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public Questions GetQuestionByIdMin(int QuestionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_QUESTION_BY_ID_MIN";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.VarChar).Value = QuestionId;
                cmd.CommandType = CommandType.StoredProcedure;
                Questions Temp = new Questions();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp.QuestionsId = Convert.ToInt32(dr["Questions_Id"]);
                    if (dr["Mover"] != DBNull.Value)
                    {
                        Temp.Mover = Convert.ToInt32(dr["Mover"]);
                        Temp.MoverName = Convert.ToString(dr["F_Name"]);
                    }
                    if (dr["QUESTION_CATEGORY"] != DBNull.Value)
                    {
                        Temp.QuestionCategoriesId = Convert.ToInt32(dr["QUESTION_CATEGORY"]);
                    }
                    Temp.QuestionStatusId = Convert.ToInt32(dr["Question_Status"]);

                    if (dr["Question_Date"] != DBNull.Value)
                        Temp.QuestionDate = Convert.ToDateTime(dr["Question_Date"]);
                    if (dr["Question_Time"] != DBNull.Value)
                        Temp.QuestionTime = Convert.ToString(dr["Question_Time"]);
                    Temp.QuestionText = Convert.ToString(dr["Question_Text"]);
                    if (dr["Urdu_Text"] != DBNull.Value)
                        Temp.UrduText = Convert.ToString(dr["Urdu_Text"]);
                    if (dr["Question_File"] != DBNull.Value)
                        Temp.QuestionFile = Convert.ToString(dr["Question_File"]);
                    if (dr["Notice_Diary_No"] != DBNull.Value)
                        Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                    if (dr["Notice_Diary_Date"] != DBNull.Value)
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                    if (dr["Notice_Diary_Time"] != DBNull.Value)
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);
                    Temp.SessionNumberId = Convert.ToInt32(dr["Session_Number"]);
                    Temp.SessionNumber = Convert.ToString(dr["SESSION_NAME"]);
                    if (dr["Session_Sittings_Id"] != DBNull.Value)
                        Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
                    if (dr["Reply"] != DBNull.Value)
                        Temp.Reply = Convert.ToString(dr["Reply"]);
                    if (dr["Reply_Date"] != DBNull.Value)
                        Temp.ReplyDate = Convert.ToDateTime(dr["Reply_Date"]);
                    if (dr["Checked"] != DBNull.Value)
                        Temp.Checked = Convert.ToInt32(dr["Checked"]);

                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }

        public List<Questions> GetQuestions(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_QUESTIONS";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.VarChar).Value = AssemblySessionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Questions> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Questions>();
                    while (dr.Read())
                    {
                        Questions Temp = new Questions();
                        Temp.QuestionsId = Convert.ToInt32(dr["Questions_Id"]);
                        Temp.ParliamentaryYear = Convert.ToString(dr["Parliamentary_Year"]);
                        if (dr["Mover"] != DBNull.Value)
                        {
                            Temp.Mover = Convert.ToInt32(dr["Mover"]);
                            Temp.MoverName = Convert.ToString(dr["F_Name"]);
                        }
                        if (dr["Question_Date"] != DBNull.Value)
                            Temp.QuestionDate = Convert.ToDateTime(dr["Question_Date"]);
                        Temp.QuestionCategory = Convert.ToString(dr["Category"]);
                        Temp.QuestionStatus = Convert.ToString(dr["QUESTION_STATUS_DESC"]);
                        if (dr["STATUS_DATE"] != DBNull.Value)
                            Temp.QuestionStatusDate = Convert.ToDateTime(dr["STATUS_DATE"]);

                        if (dr["QUESTION_DIARY_DATE"] != DBNull.Value)
                            Temp.QuestionDiaryDate = Convert.ToDateTime(dr["QUESTION_DIARY_DATE"]);
                        if (dr["Question_Time"] != DBNull.Value)
                            Temp.QuestionTime = Convert.ToString(dr["Question_Time"]);
                        if (dr["Subject"] != DBNull.Value)
                        {
                            Temp.Subject = Convert.ToString(dr["Subject"]);
                        }
                        Temp.QuestionText = Convert.ToString(dr["Question_Text"]);
                        if (dr["Urdu_Text"] != DBNull.Value)
                            Temp.UrduText = Convert.ToString(dr["Urdu_Text"]);
                        if (dr["Question_File"] != DBNull.Value)
                            Temp.QuestionFile = Convert.ToString(dr["Question_File"]);

                        Temp.Ministry = Convert.ToString(dr["Ministry"]);
                        Temp.MinistryGroup = Convert.ToString(dr["Ministry_Group"]);
                        Temp.Division = Convert.ToString(dr["Division"]);
                        if (dr["Notice_Diary_No"] != DBNull.Value)
                            Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                        if (dr["Notice_Diary_Time"] != DBNull.Value)
                            Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);
                        if (dr["Notice_Diary_Date"] != DBNull.Value)
                            Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                        if (dr["Question_Diary_No"] != DBNull.Value)
                            Temp.QuestionDiaryNo = Convert.ToInt32(dr["Question_Diary_No"]);
                        Temp.SessionNumberId = Convert.ToInt32(dr["Session_Number"]);
                        Temp.SessionNumber = Convert.ToString(dr["Session_Name"]);
                        //	Temp.IsCarryFwd = Convert.ToInt32(dr["Is_Carry_Fwd"]);
                        if (dr["Session_Sittings_Id"] != DBNull.Value)
                            Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
                        if (dr["Checked"] != DBNull.Value)
                            Temp.Checked = Convert.ToInt32(dr["Checked"]);
                        Temp.DeviceId = Convert.ToInt32(dr["DEVICE_ID"]);

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
        public List<Questions> SearchQuestions(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "SEARCH_QUESTIONS";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = AssemblySessionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Questions> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Questions>();
                    while (dr.Read())
                    {
                        Questions Temp = new Questions();
                        Temp.QuestionsId = Convert.ToInt32(dr["Questions_Id"]);
                        Temp.ParliamentaryYear = Convert.ToString(dr["Parliamentary_Year"]);
                        if (dr["Mover"] != DBNull.Value)
                        {
                            Temp.Mover = Convert.ToInt32(dr["Mover"]);
                            Temp.MoverName = Convert.ToString(dr["F_Name"]);
                        }
                        if (dr["Question_Date"] != DBNull.Value)
                            Temp.QuestionDate = Convert.ToDateTime(dr["Question_Date"]);
                        Temp.QuestionCategory = Convert.ToString(dr["Category"]);
                        Temp.QuestionStatus = Convert.ToString(dr["Question_Status"]);
                        if (dr["STATUS_DATE"] != DBNull.Value)
                            Temp.QuestionStatusDate = Convert.ToDateTime(dr["STATUS_DATE"]);

                        if (dr["QUESTION_DIARY_DATE"] != DBNull.Value)
                            Temp.QuestionDiaryDate = Convert.ToDateTime(dr["QUESTION_DIARY_DATE"]);
                        if (dr["Question_Time"] != DBNull.Value)
                            Temp.QuestionTime = Convert.ToString(dr["Question_Time"]);
                        if (dr["Subject"] != DBNull.Value)
                        {
                            Temp.Subject = Convert.ToString(dr["Subject"]);
                        }
                        Temp.QuestionText = Convert.ToString(dr["Question_Text"]);
                        if (dr["Urdu_Text"] != DBNull.Value)
                            Temp.UrduText = Convert.ToString(dr["Urdu_Text"]);
                        if (dr["Question_File"] != DBNull.Value)
                            Temp.QuestionFile = Convert.ToString(dr["Question_File"]);

                        Temp.Ministry = Convert.ToString(dr["Ministry"]);
                        Temp.MinistryGroup = Convert.ToString(dr["Ministry_Group"]);
                        Temp.Division = Convert.ToString(dr["Division"]);
                        Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                        if (dr["Question_Diary_No"] != DBNull.Value)
                            Temp.QuestionDiaryNo = Convert.ToInt32(dr["Question_Diary_No"]);
                        Temp.SessionNumberId = Convert.ToInt32(dr["Session_Number"]);
                        Temp.SessionNumber = Convert.ToString(dr["Session_Name"]);
                        if (dr["Is_Carry_Fwd"] != DBNull.Value)
                            Temp.IsCarryFwd = Convert.ToInt32(dr["Is_Carry_Fwd"]);
                        if (dr["Session_Sittings_Id"] != DBNull.Value)
                            Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
                        if (dr["Checked"] != DBNull.Value)
                            Temp.Checked = Convert.ToInt32(dr["Checked"]);
                        Temp.DeviceId = Convert.ToInt32(dr["DEVICE_ID"]);
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
        public void DeleteQuestion(int QuestionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_QUESTION";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = QuestionId;
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
        public List<Questions> GetQuestionsByStatus(int AssemblySessionsId, int StatusId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_QUESTIONS_BY_STATUS";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.VarChar).Value = AssemblySessionsId;
                cmd.Parameters.Add("@QuestionStstusId", SqlDbType.VarChar).Value = StatusId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Questions> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Questions>();
                    while (dr.Read())
                    {
                        Questions Temp = new Questions();
                        Temp.QuestionsId = Convert.ToInt32(dr["Questions_Id"]);
                        Temp.ParliamentaryYear = Convert.ToString(dr["Parliamentary_Year"]);
                        if (dr["Mover"] != DBNull.Value)
                        {
                            Temp.Mover = Convert.ToInt32(dr["Mover"]);
                            Temp.MoverName = Convert.ToString(dr["F_Name"]);
                        }
                        if (dr["Question_Date"] != DBNull.Value)
                            Temp.QuestionDate = Convert.ToDateTime(dr["Question_Date"]);
                        Temp.QuestionCategory = Convert.ToString(dr["Category"]);
                        Temp.QuestionStatusId = Convert.ToInt32(dr["Question_Status"]);
                        Temp.QuestionStatus = Convert.ToString(dr["Question_Status_Desc"]);

                        if (dr["QUESTION_DIARY_DATE"] != DBNull.Value)
                            Temp.QuestionDiaryDate = Convert.ToDateTime(dr["QUESTION_DIARY_DATE"]);
                        if (dr["Question_Time"] != DBNull.Value)
                            Temp.QuestionTime = Convert.ToString(dr["Question_Time"]);
                        if (dr["Subject"] != DBNull.Value)
                        {
                            Temp.Subject = Convert.ToString(dr["Subject"]);
                        }
                        Temp.QuestionText = Regex.Replace(Convert.ToString(dr["Question_Text"]), "<.*?>", string.Empty);
                        if (dr["Urdu_Text"] != DBNull.Value)
                            Temp.UrduText = Convert.ToString(dr["Urdu_Text"]);
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                        Temp.SessionNumberId = Convert.ToInt32(dr["Session_Number"]);
                        if (dr["Session_Sittings_Id"] != DBNull.Value)
                            Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
                        if (dr["Checked"] != DBNull.Value)
                            Temp.Checked = Convert.ToInt32(dr["Checked"]);
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
        public void UpdateQuestions(Questions Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_QUESTIONS";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = Temp.QuestionsId;
                cmd.Parameters.Add("@Mover", SqlDbType.Int).Value = Temp.Mover;
                cmd.Parameters.Add("@QuestionCategoryId", SqlDbType.Int).Value = Temp.QuestionCategoriesId;
                cmd.Parameters.Add("@QuestionText", SqlDbType.VarChar).Value = Temp.QuestionText;
                cmd.Parameters.Add("@QuestionStatusesId", SqlDbType.Int).Value = Temp.QuestionStatusId;
                if (Temp.QuestionStatusDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@QuestionStatusDate", SqlDbType.Date).Value = Temp.QuestionStatusDate;
                cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.Int).Value = Temp.NoticeDiaryNo;
                cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.Date).Value = Temp.NoticeDiaryDate;
                cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = Temp.NoticeDiaryTime;
                cmd.Parameters.Add("@QuestionDate", SqlDbType.Date).Value = Temp.QuestionDate;
                cmd.Parameters.Add("@SessionNumber", SqlDbType.Int).Value = Temp.SessionNumberId;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                if (!string.IsNullOrEmpty(Temp.UrduText))
                    InsertUrduText(Temp.UrduText, Temp.QuestionsId);
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
        public int InsertQuestions(Questions Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                //int id = GetQuestionPk();
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_QUESTIONS";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = Temp.QuestionsId;
                cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.Int).Value = Temp.NoticeDiaryNo;
                cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.Date).Value = Temp.NoticeDiaryDate;
                cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = Temp.NoticeDiaryTime;
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = Temp.SessionNumberId;
                cmd.Parameters.Add("@Mover", SqlDbType.Int).Value = Temp.Mover;
                cmd.Parameters.Add("@QuestionCategoriesId", SqlDbType.Int).Value = Temp.QuestionCategoriesId;
                cmd.Parameters.Add("@QuestionStatusesId", SqlDbType.Int).Value = Temp.QuestionStatusId;
                cmd.Parameters.Add("@QuestionStatusDate", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@QuestionText", SqlDbType.VarChar).Value = Temp.QuestionText;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                InsertUrduText(Temp.UrduText, Temp.QuestionsId);
                return Temp.QuestionsId;
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
        public void InsertUrduText(string UrduText, int QuestionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                if (!string.IsNullOrEmpty(UrduText))
                {
                    string query = "Update notice_questions set urdu_text=N'" + UrduText + "' where questions_id=" + QuestionId;
                    SqlCommand cmd = new SqlCommand(query, con);
                    using (con)
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
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
        public void InsertQuestionFile(string file, int QuestionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_QUESTION_FILE";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = QuestionId;
                cmd.Parameters.Add("@QuestionFile", SqlDbType.VarChar).Value = file;
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



        public List<Questions> SearchQuestion(string query)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                List<Questions> emp = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        emp = new List<Questions>();
                        while (dr.Read())
                        {
                            Questions Temp = new Questions();
                            Temp.QuestionsId = Convert.ToInt32(dr["Questions_Id"]);
                            Temp.ParliamentaryYear = Convert.ToString(dr["Parliamentary_Year"]);
                            if (dr["Mover"] != DBNull.Value)
                            {
                                Temp.Mover = Convert.ToInt32(dr["Mover"]);
                                Temp.MoverName = Convert.ToString(dr["F_Name"]);
                            }
                            if (dr["Question_Date"] != DBNull.Value)
                                Temp.QuestionDate = Convert.ToDateTime(dr["Question_Date"]);
                            Temp.QuestionCategory = Convert.ToString(dr["Category"]);
                            Temp.QuestionStatus = Convert.ToString(dr["Question_Status_desc"]);
                            if (dr["Status_Date"] != DBNull.Value)
                                Temp.QuestionStatusDate = Convert.ToDateTime(dr["Status_Date"]);


                            if (dr["QUESTION_DIARY_DATE"] != DBNull.Value)
                                Temp.QuestionDiaryDate = Convert.ToDateTime(dr["QUESTION_DIARY_DATE"]);
                            if (dr["Question_Time"] != DBNull.Value)
                                Temp.QuestionTime = Convert.ToString(dr["Question_Time"]);
                            if (dr["Subject"] != DBNull.Value)
                            {
                                Temp.Subject = Convert.ToString(dr["Subject"]);
                            }
                            Temp.QuestionText = Regex.Replace(Convert.ToString(dr["Question_Text"]), @"<[^>]+>|&nbsp;", "").Trim();

                            Temp.Ministry = Convert.ToString(dr["Ministry"]);
                            if (dr["Ministry_Group"] != DBNull.Value)
                                Temp.MinistryGroup = Convert.ToString(dr["Ministry_Group"]);
                            Temp.Division = Convert.ToString(dr["Division"]);
                            Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                            Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);
                            if (dr["Notice_Diary_Date"] != DBNull.Value)
                                Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                            if (dr["Question_Diary_No"] != DBNull.Value)
                                Temp.QuestionDiaryNo = Convert.ToInt32(dr["Question_Diary_No"]);
                            Temp.SessionNumberId = Convert.ToInt32(dr["Session_Number"]);
                            Temp.SessionNumber = Convert.ToString(dr["Session_Name"]);
                            Temp.IsCarryFwd = Convert.ToInt32(dr["Is_Carry_Fwd"]);
                            if (dr["Session_Sittings_Id"] != DBNull.Value)
                                Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
                            Temp.DeviceId = Convert.ToInt32(dr["Device_Id"]);
                            emp.Add(Temp);

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

        #endregion Questions

        public AssemblySessions GetCurrentSession()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CURRENT_SESSION_DETAILS";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AssemblySessions asseblysessions = new AssemblySessions();
                if (dr.HasRows)
                {
                    dr.Read();
                    asseblysessions.SessionNumber = Convert.ToInt32(dr["SESSION_NUMBER"]);
                    asseblysessions.AssembliesId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);

                }
                return asseblysessions;
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
        public AssemblySessions GetPreviousSession()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PREVIOUS_SESSION";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AssemblySessions asseblysessions = new AssemblySessions();
                if (dr.HasRows)
                {
                    dr.Read();
                    asseblysessions.SessionNumber = Convert.ToInt32(dr["SESSION_NUMBER"]);
                    asseblysessions.AssembliesId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);

                }
                return asseblysessions;
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
        public void LapseQuestion(int AssemblySessionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "LAPSE_QUESTIONS";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = AssemblySessionId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

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

        public void LapseMotion(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "LAPSE_MOTIONS";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = AssemblySessionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

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

        public void LapseResolution(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "LAPSE_RESOLUTIONS";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = AssemblySessionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

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
        public List<QuestionStatusHistory> GetQuestionStatusHistory(int QuestionIdentifier)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_QUESTION_STATUS_HIST";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = QuestionIdentifier;
                cmd.CommandType = CommandType.StoredProcedure;
                List<QuestionStatusHistory> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<QuestionStatusHistory>();
                    while (dr.Read())
                    {
                        QuestionStatusHistory Temp = new QuestionStatusHistory();

                        Temp.QuestionStatusHistoryId = Convert.ToInt32(dr["QUEST_STATUS_HIST_ID"]);
                        Temp.QuestionId = Convert.ToInt32(dr["QUESTION_ID"]);
                        Temp.QuestionStatusId = Convert.ToInt32(dr["QUESTION_STATUSES_ID"]);
                        Temp.QuestionStatus = Convert.ToString(dr["QUESTION_STATUS"]);
                        Temp.AssemblySessionId = Convert.ToInt32(dr["ASSEMBLY_SESSION_ID"]);
                        Temp.AssemblySession = Convert.ToString(dr["SESSION_NUMBER"]);
                        Temp.StatusDate = Convert.ToDateTime(dr["STATUS_DATE"]);
                        Temp.Remarks = Convert.ToString(dr["Remarks"]);
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

        public List<QuestionMovementHistory> GetQuestionMovementHistory(int QuestionIdentifier)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_QUESTION_MOVEMENT";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = QuestionIdentifier;
                cmd.CommandType = CommandType.StoredProcedure;
                List<QuestionMovementHistory> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<QuestionMovementHistory>();
                    while (dr.Read())
                    {
                        QuestionMovementHistory Temp = new QuestionMovementHistory();
                        Temp.QuestionId = Convert.ToInt32(dr["QUESTION_ID"]);
                        Temp.FromAssemblySession = Convert.ToInt32(dr["FROM_SESSION"]);
                        Temp.ToAssemblySession = Convert.ToInt32(dr["TO_SESSION"]);
                        Temp.MovementDate = Convert.ToDateTime(dr["MVMT_DATE"]);
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
        public List<DeferQuestion> GetQuestionDeferment(int QuestionIdentifier)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_QUESTION_DEFERMENT";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = QuestionIdentifier;
                cmd.CommandType = CommandType.StoredProcedure;
                List<DeferQuestion> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<DeferQuestion>();
                    while (dr.Read())
                    {
                        DeferQuestion Temp = new DeferQuestion();
                        Temp.DeferId = Convert.ToInt32(dr["QUEST_DEFER_ID"]);
                        Temp.QuestionId = Convert.ToInt32(dr["QUESTION_ID"]);
                        Temp.AssemblySessionId = Convert.ToInt32(dr["ASSEMBLY_SESSION_ID"]);
                        Temp.DeferDate = Convert.ToDateTime(dr["DEFER_DATE"]);
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
        public List<Member> GetSeatMemberByName(string MemberName)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SEAT_MEMBERS_BY_NAME";
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
        public List<Member> GetMembersByStatus(int StatusId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBERS_BY_STATUS";
                cmd.Parameters.Add("@MemberStatusId", SqlDbType.Int).Value = StatusId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Member> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Member>();
                    while (dr.Read())
                    {
                        Member Temp = new Member();
                        string membername = "";
                        if (dr["F_Name"] != DBNull.Value)
                            membername = Convert.ToString(dr["F_Name"]);
                        if (dr["M_Name"] != DBNull.Value)
                            membername += " " + Convert.ToString(dr["M_Name"]);
                        if (dr["L_Name"] != DBNull.Value)
                            membername += " " + Convert.ToString(dr["L_Name"]);
                        Temp.MemberId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        Temp.MemberName = membername;
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

    }
}

