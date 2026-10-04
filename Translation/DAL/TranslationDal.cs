using Entities;
using QuestionDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace DAL
{
    public class TranslationDal
    {
        #region Assembly Session
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
                }

                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion
        #region Questions
        public int SaveQuestionTranslation(int QuestionId, string TranslatedText)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "SAVE_QUESTION_TRANSLATION";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = QuestionId;
                cmd.Parameters.Add("@TranslatedText", SqlDbType.VarChar).Value = TranslatedText;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                return 1;
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
        public int FinalizeQuestionTranslation(int QuestionId, string TranslatedText)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "FINALIZE_QUESTION_TRANSLATION";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = QuestionId;
                cmd.Parameters.Add("@TranslatedText", SqlDbType.VarChar).Value = TranslatedText;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                return 1;
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
        public int SubmitQuestionTranslationByUser(int QuestionId, string TranslatedText)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "SUBMIT_QUESTION_TRANSLATION_BY_USER";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = QuestionId;
                cmd.Parameters.Add("@TranslatedText", SqlDbType.VarChar).Value = TranslatedText;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                return 1;
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
        public Questions GetQuestionByIdMin(int QuestionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_QUESTION_BY_ID";
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
                    Temp.QuestionStatus = Convert.ToString(dr["Question_Status"]);

                    if (dr["Question_Date"] != DBNull.Value)
                        Temp.QuestionDate = Convert.ToDateTime(dr["Question_Date"]);
                    if (dr["Question_Time"] != DBNull.Value)
                        Temp.QuestionTime = Convert.ToString(dr["Question_Time"]);
                    //if (dr["Subject"] != DBNull.Value)
                    //{
                    //    Temp.Subject = Convert.ToString(dr["Subject"]);
                    //    //if(Temp.Subject.Length>42)
                    //    //Temp.Subject = Temp.Subject.Substring(43);
                    //}
                    if (dr["Question_File"] != DBNull.Value)
                        Temp.QuestionFile = Convert.ToString(dr["Question_File"]);
                    if (dr["Urdu_Text"] != DBNull.Value)
                        Temp.UrduText = Convert.ToString(dr["Urdu_Text"]);
                    Temp.QuestionText = Convert.ToString(dr["Question_Text"]);
                    //Temp.Ministry = Convert.ToString(dr["Ministry"]);
                    if (dr["Division"] != DBNull.Value)
                        Temp.DivisionId = Convert.ToInt32(dr["Division"]);
                    // Temp.DepartmentsId = Convert.ToInt32(dr["Departments_Id"]);
                    // Temp.Department = Convert.ToString(dr["Deptt_Name"]);
                    if (dr["Notice_Diary_No"] != DBNull.Value)
                        Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                    if (dr["Notice_Diary_Date"] != DBNull.Value)
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                    if (dr["Notice_Diary_Time"] != DBNull.Value)
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);
                    //Temp.AdmittedNumber = Convert.ToString(dr["Admitted_Number"]);
                    if (dr["Question_Diary_No"] != DBNull.Value)
                        Temp.QuestionDiaryNo = Convert.ToInt32(dr["Question_Diary_No"]);
                    if (dr["Question_Diary_Date"] != DBNull.Value)
                        Temp.QuestionDiaryDate = Convert.ToDateTime(dr["Question_Diary_Date"]);
                    // Temp.QuestionDiaryTime = Convert.ToDateTime(dr["Question_Diary_Time"]);
                    Temp.SessionNumberId = Convert.ToInt32(dr["Session_Number"]);
                    Temp.SessionNumber = Convert.ToString(dr["SESSION_NAME"]);
                    if (dr["Session_Sittings_Id"] != DBNull.Value)
                        Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
                    if (dr["TRANS_APPROVED_BY"] != DBNull.Value)
                    {
                        Temp.TranslationApprovedBy = Convert.ToInt32(dr["TRANS_APPROVED_BY"]);

                    }
                    if (dr["TRANS_APPROVED_ON"] != DBNull.Value)
                        Temp.TranslationApprovedOn = Convert.ToDateTime(dr["TRANS_APPROVED_ON"]);
                    if (dr["ASSIGNED_FOR_TRANS_TO"] != DBNull.Value)
                    {
                        Temp.AssignedForTranslationTo = Convert.ToInt32(dr["ASSIGNED_FOR_TRANS_TO"]);
                        Temp.AssignedForTranslationToName = Convert.ToString(dr["ASSIGNED_FOR_TRANS_TO_NAME"]);
                    }
                    if (dr["ASSIGNED_FOR_TRANS_ON"] != DBNull.Value)
                        Temp.AssignedForTranslationOn = Convert.ToDateTime(dr["ASSIGNED_FOR_TRANS_ON"]);
                    if (dr["TRANSLATED_BY"] != DBNull.Value)
                    {
                        Temp.TranslatedBy = Convert.ToInt32(dr["TRANSLATED_BY"]);
                        Temp.TranslatedByName = Convert.ToString(dr["TRANSLATED_BY_NAME"]);
                    }
                    if (dr["TRANSLATED_ON"] != DBNull.Value)
                        Temp.TranslatedOn = Convert.ToDateTime(dr["TRANSLATED_ON"]);

                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public void SendQuestionForTranslation(int QuestionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "TRANSLATE_QUESTION";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.VarChar).Value = QuestionId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
        }

        public List<Questions> GetTranslationQuestions()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_TRANSLATION_QUESTIONS";
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
                        if (dr["SENT_FOR_TRANS_ON"] != DBNull.Value)
                            Temp.SentForTranslationOn = Convert.ToDateTime(dr["SENT_FOR_TRANS_ON"]);
                        if (dr["RETURN_FROM_TRANS_ON"] != DBNull.Value)
                            Temp.ReturnedFromTranslationOn = Convert.ToDateTime(dr["RETURN_FROM_TRANS_ON"]);
                        if (dr["Question_File"] != DBNull.Value)
                            Temp.QuestionFile = Convert.ToString(dr["Question_File"]);

                        Temp.Ministry = Convert.ToString(dr["Ministry"]);
                        Temp.MinistryGroup = Convert.ToString(dr["Ministry_Group"]);
                        Temp.Division = Convert.ToString(dr["Division"]);
                        if (dr["Notice_Diary_No"] != DBNull.Value)
                            Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                        if (dr["Question_Diary_No"] != DBNull.Value)
                            Temp.QuestionDiaryNo = Convert.ToInt32(dr["Question_Diary_No"]);
                        Temp.SessionNumberId = Convert.ToInt32(dr["Session_Number"]);
                        Temp.SessionNumber = Convert.ToString(dr["Session_Name"]);
                        Temp.IsCarryFwd = Convert.ToInt32(dr["Is_Carry_Fwd"]);
                        if (dr["Session_Sittings_Id"] != DBNull.Value)
                            Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
                        if (dr["TRANS_APPROVED_BY"] != DBNull.Value)
                        {
                            Temp.TranslationApprovedBy = Convert.ToInt32(dr["TRANS_APPROVED_BY"]);

                        }
                        if (dr["TRANS_APPROVED_ON"] != DBNull.Value)
                            Temp.TranslationApprovedOn = Convert.ToDateTime(dr["TRANS_APPROVED_ON"]);
                        if (dr["ASSIGNED_FOR_TRANS_TO"] != DBNull.Value)
                        {
                            Temp.AssignedForTranslationTo = Convert.ToInt32(dr["ASSIGNED_FOR_TRANS_TO"]);
                            Temp.AssignedForTranslationToName = Convert.ToString(dr["ASSIGNED_FOR_TRANS_TO_NAME"]);
                        }
                        if (dr["ASSIGNED_FOR_TRANS_ON"] != DBNull.Value)
                            Temp.AssignedForTranslationOn = Convert.ToDateTime(dr["ASSIGNED_FOR_TRANS_ON"]);
                        if (dr["TRANSLATED_BY"] != DBNull.Value)
                        {
                            Temp.TranslatedBy = Convert.ToInt32(dr["TRANSLATED_BY"]);
                            Temp.TranslatedByName = Convert.ToString(dr["TRANSLATED_BY_NAME"]);
                        }
                        if (dr["TRANSLATED_ON"] != DBNull.Value)
                            Temp.TranslatedOn = Convert.ToDateTime(dr["TRANSLATED_ON"]);
                     

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
        public List<Questions> GetSentQuestionsToUsers()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_USERS_TRANSLATION_QUESTIONS";
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
                        if (dr["SENT_FOR_TRANS_ON"] != DBNull.Value)
                            Temp.SentForTranslationOn = Convert.ToDateTime(dr["SENT_FOR_TRANS_ON"]);
                        if (dr["RETURN_FROM_TRANS_ON"] != DBNull.Value)
                            Temp.ReturnedFromTranslationOn = Convert.ToDateTime(dr["RETURN_FROM_TRANS_ON"]);
                        if (dr["Question_File"] != DBNull.Value)
                            Temp.QuestionFile = Convert.ToString(dr["Question_File"]);

                        Temp.Ministry = Convert.ToString(dr["Ministry"]);
                        Temp.MinistryGroup = Convert.ToString(dr["Ministry_Group"]);
                        Temp.Division = Convert.ToString(dr["Division"]);
                        if (dr["Notice_Diary_No"] != DBNull.Value)
                            Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                        if (dr["Question_Diary_No"] != DBNull.Value)
                            Temp.QuestionDiaryNo = Convert.ToInt32(dr["Question_Diary_No"]);
                        Temp.SessionNumberId = Convert.ToInt32(dr["Session_Number"]);
                        Temp.SessionNumber = Convert.ToString(dr["Session_Name"]);
                        Temp.IsCarryFwd = Convert.ToInt32(dr["Is_Carry_Fwd"]);
                        if (dr["Session_Sittings_Id"] != DBNull.Value)
                            Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
                        if (dr["TRANS_APPROVED_BY"] != DBNull.Value)
                        {
                            Temp.TranslationApprovedBy = Convert.ToInt32(dr["TRANS_APPROVED_BY"]);

                        }
                        if (dr["TRANS_APPROVED_ON"] != DBNull.Value)
                            Temp.TranslationApprovedOn = Convert.ToDateTime(dr["TRANS_APPROVED_ON"]);
                        if (dr["ASSIGNED_FOR_TRANS_TO"] != DBNull.Value)
                        {
                            Temp.AssignedForTranslationTo = Convert.ToInt32(dr["ASSIGNED_FOR_TRANS_TO"]);
                            Temp.AssignedForTranslationToName = Convert.ToString(dr["ASSIGNED_FOR_TRANS_TO_NAME"]);
                        }
                        if (dr["ASSIGNED_FOR_TRANS_ON"] != DBNull.Value)
                            Temp.AssignedForTranslationOn = Convert.ToDateTime(dr["ASSIGNED_FOR_TRANS_ON"]);
                        if (dr["TRANSLATED_BY"] != DBNull.Value)
                        {
                            Temp.TranslatedBy = Convert.ToInt32(dr["TRANSLATED_BY"]);
                            Temp.TranslatedByName = Convert.ToString(dr["TRANSLATED_BY_NAME"]);
                        }
                        if (dr["TRANSLATED_ON"] != DBNull.Value)
                            Temp.TranslatedOn = Convert.ToDateTime(dr["TRANSLATED_ON"]);
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
        public List<Questions> GetSentQuestionsToUser(int UserId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_USER_TRANSLATION_QUESTIONS";
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
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
                        if (dr["SENT_FOR_TRANS_ON"] != DBNull.Value)
                            Temp.SentForTranslationOn = Convert.ToDateTime(dr["SENT_FOR_TRANS_ON"]);
                        if (dr["RETURN_FROM_TRANS_ON"] != DBNull.Value)
                            Temp.ReturnedFromTranslationOn = Convert.ToDateTime(dr["RETURN_FROM_TRANS_ON"]);
                        if (dr["Question_File"] != DBNull.Value)
                            Temp.QuestionFile = Convert.ToString(dr["Question_File"]);

                        Temp.Ministry = Convert.ToString(dr["Ministry"]);
                        Temp.MinistryGroup = Convert.ToString(dr["Ministry_Group"]);
                        Temp.Division = Convert.ToString(dr["Division"]);
                        if (dr["Notice_Diary_No"] != DBNull.Value)
                            Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                        if (dr["Question_Diary_No"] != DBNull.Value)
                            Temp.QuestionDiaryNo = Convert.ToInt32(dr["Question_Diary_No"]);
                        Temp.SessionNumberId = Convert.ToInt32(dr["Session_Number"]);
                        Temp.SessionNumber = Convert.ToString(dr["Session_Name"]);
                        Temp.IsCarryFwd = Convert.ToInt32(dr["Is_Carry_Fwd"]);
                        if (dr["Session_Sittings_Id"] != DBNull.Value)
                            Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
                        if (dr["TRANS_APPROVED_BY"] != DBNull.Value)
                        {
                            Temp.TranslationApprovedBy = Convert.ToInt32(dr["TRANS_APPROVED_BY"]);

                        }
                        if (dr["TRANS_APPROVED_ON"] != DBNull.Value)
                            Temp.TranslationApprovedOn = Convert.ToDateTime(dr["TRANS_APPROVED_ON"]);
                        if (dr["ASSIGNED_FOR_TRANS_TO"] != DBNull.Value)
                        {
                            Temp.AssignedForTranslationTo = Convert.ToInt32(dr["ASSIGNED_FOR_TRANS_TO"]);
                            Temp.AssignedForTranslationToName = Convert.ToString(dr["ASSIGNED_FOR_TRANS_TO_NAME"]);
                        }
                        if (dr["ASSIGNED_FOR_TRANS_ON"] != DBNull.Value)
                            Temp.AssignedForTranslationOn = Convert.ToDateTime(dr["ASSIGNED_FOR_TRANS_ON"]);
                        if (dr["TRANSLATED_BY"] != DBNull.Value)
                        {
                            Temp.TranslatedBy = Convert.ToInt32(dr["TRANSLATED_BY"]);
                            Temp.TranslatedByName = Convert.ToString(dr["TRANSLATED_BY_NAME"]);
                        }
                        if (dr["TRANSLATED_ON"] != DBNull.Value)
                            Temp.TranslatedOn = Convert.ToDateTime(dr["TRANSLATED_ON"]);
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
        public List<Questions> GetTranslatedQuestionsByUsers()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ALL_USER_TRANSLATED_QUESTIONS";
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
                        if (dr["SENT_FOR_TRANS_ON"] != DBNull.Value)
                            Temp.SentForTranslationOn = Convert.ToDateTime(dr["SENT_FOR_TRANS_ON"]);
                        if (dr["RETURN_FROM_TRANS_ON"] != DBNull.Value)
                            Temp.ReturnedFromTranslationOn = Convert.ToDateTime(dr["RETURN_FROM_TRANS_ON"]);
                        if (dr["Question_File"] != DBNull.Value)
                            Temp.QuestionFile = Convert.ToString(dr["Question_File"]);

                        Temp.Ministry = Convert.ToString(dr["Ministry"]);
                        Temp.MinistryGroup = Convert.ToString(dr["Ministry_Group"]);
                        Temp.Division = Convert.ToString(dr["Division"]);
                        if (dr["Notice_Diary_No"] != DBNull.Value)
                            Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                        if (dr["Question_Diary_No"] != DBNull.Value)
                            Temp.QuestionDiaryNo = Convert.ToInt32(dr["Question_Diary_No"]);
                        Temp.SessionNumberId = Convert.ToInt32(dr["Session_Number"]);
                        Temp.SessionNumber = Convert.ToString(dr["Session_Name"]);
                        Temp.IsCarryFwd = Convert.ToInt32(dr["Is_Carry_Fwd"]);
                        if (dr["Session_Sittings_Id"] != DBNull.Value)
                            Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
                        if (dr["TRANS_APPROVED_BY"] != DBNull.Value)
                        {
                            Temp.TranslationApprovedBy = Convert.ToInt32(dr["TRANS_APPROVED_BY"]);

                        }
                        if (dr["TRANS_APPROVED_ON"] != DBNull.Value)
                            Temp.TranslationApprovedOn = Convert.ToDateTime(dr["TRANS_APPROVED_ON"]);
                        if (dr["ASSIGNED_FOR_TRANS_TO"] != DBNull.Value)
                        {
                            Temp.AssignedForTranslationTo = Convert.ToInt32(dr["ASSIGNED_FOR_TRANS_TO"]);
                            Temp.AssignedForTranslationToName = Convert.ToString(dr["ASSIGNED_FOR_TRANS_TO_NAME"]);
                        }
                        if (dr["ASSIGNED_FOR_TRANS_ON"] != DBNull.Value)
                            Temp.AssignedForTranslationOn = Convert.ToDateTime(dr["ASSIGNED_FOR_TRANS_ON"]);
                        if (dr["TRANSLATED_BY"] != DBNull.Value)
                        {
                            Temp.TranslatedBy = Convert.ToInt32(dr["TRANSLATED_BY"]);
                            Temp.TranslatedByName = Convert.ToString(dr["TRANSLATED_BY_NAME"]);
                        }
                        if (dr["TRANSLATED_ON"] != DBNull.Value)
                            Temp.TranslatedOn = Convert.ToDateTime(dr["TRANSLATED_ON"]);
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
        public List<Questions> GetUserTranslatedQuestions(int UserId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_USER_TRANSLATION_QUESTIONS";
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
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
                        if (dr["SENT_FOR_TRANS_ON"] != DBNull.Value)
                            Temp.SentForTranslationOn = Convert.ToDateTime(dr["SENT_FOR_TRANS_ON"]);
                        if (dr["RETURN_FROM_TRANS_ON"] != DBNull.Value)
                            Temp.ReturnedFromTranslationOn = Convert.ToDateTime(dr["RETURN_FROM_TRANS_ON"]);
                        if (dr["Question_File"] != DBNull.Value)
                            Temp.QuestionFile = Convert.ToString(dr["Question_File"]);

                        Temp.Ministry = Convert.ToString(dr["Ministry"]);
                        Temp.MinistryGroup = Convert.ToString(dr["Ministry_Group"]);
                        Temp.Division = Convert.ToString(dr["Division"]);
                        if (dr["Notice_Diary_No"] != DBNull.Value)
                            Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                        if (dr["Question_Diary_No"] != DBNull.Value)
                            Temp.QuestionDiaryNo = Convert.ToInt32(dr["Question_Diary_No"]);
                        Temp.SessionNumberId = Convert.ToInt32(dr["Session_Number"]);
                        Temp.SessionNumber = Convert.ToString(dr["Session_Name"]);
                        Temp.IsCarryFwd = Convert.ToInt32(dr["Is_Carry_Fwd"]);
                        if (dr["Session_Sittings_Id"] != DBNull.Value)
                            Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
                        if (dr["TRANS_APPROVED_BY"] != DBNull.Value)
                        {
                            Temp.TranslationApprovedBy = Convert.ToInt32(dr["TRANS_APPROVED_BY"]);

                        }
                        if (dr["TRANS_APPROVED_ON"] != DBNull.Value)
                            Temp.TranslationApprovedOn = Convert.ToDateTime(dr["TRANS_APPROVED_ON"]);
                        if (dr["ASSIGNED_FOR_TRANS_TO"] != DBNull.Value)
                        {
                            Temp.AssignedForTranslationTo = Convert.ToInt32(dr["ASSIGNED_FOR_TRANS_TO"]);
                            Temp.AssignedForTranslationToName = Convert.ToString(dr["ASSIGNED_FOR_TRANS_TO_NAME"]);
                        }
                        if (dr["ASSIGNED_FOR_TRANS_ON"] != DBNull.Value)
                            Temp.AssignedForTranslationOn = Convert.ToDateTime(dr["ASSIGNED_FOR_TRANS_ON"]);
                        if (dr["TRANSLATED_BY"] != DBNull.Value)
                        {
                            Temp.TranslatedBy = Convert.ToInt32(dr["TRANSLATED_BY"]);
                            Temp.TranslatedByName = Convert.ToString(dr["TRANSLATED_BY_NAME"]);
                        }
                        if (dr["TRANSLATED_ON"] != DBNull.Value)
                            Temp.TranslatedOn = Convert.ToDateTime(dr["TRANSLATED_ON"]);
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
        public List<Questions> GetTranslatedQuestions(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_TRANSLATED_QUESTIONS";
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
                        if (dr["SENT_FOR_TRANS_ON"] != DBNull.Value)
                            Temp.SentForTranslationOn = Convert.ToDateTime(dr["SENT_FOR_TRANS_ON"]);
                        if (dr["RETURN_FROM_TRANS_ON"] != DBNull.Value)
                            Temp.ReturnedFromTranslationOn = Convert.ToDateTime(dr["RETURN_FROM_TRANS_ON"]);
                        if (dr["Question_File"] != DBNull.Value)
                            Temp.QuestionFile = Convert.ToString(dr["Question_File"]);
                        Temp.Ministry = Convert.ToString(dr["Ministry"]);
                        Temp.MinistryGroup = Convert.ToString(dr["Ministry_Group"]);
                        Temp.Division = Convert.ToString(dr["Division"]);
                        if (dr["Notice_Diary_No"] != DBNull.Value)
                            Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                        if (dr["Question_Diary_No"] != DBNull.Value)
                            Temp.QuestionDiaryNo = Convert.ToInt32(dr["Question_Diary_No"]);
                        Temp.SessionNumberId = Convert.ToInt32(dr["Session_Number"]);
                        Temp.SessionNumber = Convert.ToString(dr["Session_Name"]);
                        Temp.IsCarryFwd = Convert.ToInt32(dr["Is_Carry_Fwd"]);
                        if (dr["Session_Sittings_Id"] != DBNull.Value)
                            Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
                        if (dr["TRANS_APPROVED_BY"] != DBNull.Value)
                        {
                            Temp.TranslationApprovedBy = Convert.ToInt32(dr["TRANS_APPROVED_BY"]);

                        }
                        if (dr["TRANS_APPROVED_ON"] != DBNull.Value)
                            Temp.TranslationApprovedOn = Convert.ToDateTime(dr["TRANS_APPROVED_ON"]);
                        if (dr["ASSIGNED_FOR_TRANS_TO"] != DBNull.Value)
                        {
                            Temp.AssignedForTranslationTo = Convert.ToInt32(dr["ASSIGNED_FOR_TRANS_TO"]);
                            Temp.AssignedForTranslationToName = Convert.ToString(dr["ASSIGNED_FOR_TRANS_TO_NAME"]);
                        }
                        if (dr["ASSIGNED_FOR_TRANS_ON"] != DBNull.Value)
                            Temp.AssignedForTranslationOn = Convert.ToDateTime(dr["ASSIGNED_FOR_TRANS_ON"]);
                        if (dr["TRANSLATED_BY"] != DBNull.Value)
                        {
                            Temp.TranslatedBy = Convert.ToInt32(dr["TRANSLATED_BY"]);
                            Temp.TranslatedByName = Convert.ToString(dr["TRANSLATED_BY_NAME"]);
                        }
                        if (dr["TRANSLATED_ON"] != DBNull.Value)
                            Temp.TranslatedOn = Convert.ToDateTime(dr["TRANSLATED_ON"]);
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
        #endregion

        #region Motion
        public Motion GetMotion(int MotionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MOTION";
                cmd.Parameters.Add("@MotionsId", SqlDbType.Int).Value = MotionId;
                cmd.CommandType = CommandType.StoredProcedure;
                Motion Temp = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = new Motion();
                    Temp.MotionsId = Convert.ToInt32(dr["MOTIONS_ID"]);
                    Temp.FileNo = Convert.ToString(dr["FILE_NO"]);
                    if (dr["MB_WEEK_ID"] != DBNull.Value)
                    {
                        Temp.WeekId = Convert.ToInt32(dr["MB_WEEK_ID"]);
                        Temp.WeekName = Convert.ToString(dr["MB_WEEK"]);
                    }
                    Temp.MotionDiaryNo = Convert.ToString(dr["MOTION_DIARY_NO"]);
                    Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                    Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
                    Temp.NoticeDiaryTime = Convert.ToDateTime(dr["NOTICE_DIARY_TIME"]);
                    Temp.SessionNumber = Convert.ToInt32(dr["SESSION_NUMBER"]);
                    Temp.SessionDesc = Convert.ToString(dr["SESSION_DESC"]);
                    Temp.MotionStatusId = Convert.ToInt32(dr["MOTION_STATUS_ID"]);
                    Temp.MotionStatus = Convert.ToString(dr["MOTION_STATUS"]);
                    Temp.MotionTypeId = Convert.ToInt32(dr["MOTION_TYPE_ID"]);
                    Temp.MotionType = Convert.ToString(dr["MOTION_TYPE"]);
                    if (dr["REFFERED_SC_DATE"] != DBNull.Value)
                        Temp.RefferedScDate = Convert.ToDateTime(dr["REFFERED_SC_DATE"]);
                    if (dr["MOVING_HOUSE_DATE"] != DBNull.Value)
                        Temp.MovingHouseDate = Convert.ToDateTime(dr["MOVING_HOUSE_DATE"]);
                    if (dr["DISCUSSION_DATE"] != DBNull.Value)
                        Temp.DiscussionDate = Convert.ToDateTime(dr["DISCUSSION_DATE"]);
                    Temp.Description = Convert.ToString(dr["MOTION_TEXT"]);
                    Temp.NoteDescription = Convert.ToString(dr["SUBJECT"]);
                    if (dr["URDU_TEXT"] != DBNull.Value)
                        Temp.UrduText = Convert.ToString(dr["URDU_TEXT"]);
                    if (dr["MOTION_FILE"] != DBNull.Value)
                        Temp.MotionFile = Convert.ToString(dr["MOTION_FILE"]);

                    //Temp.Movers = new List<MotionMoversEnt>();
                    //Temp.Movers = GetMotionMovers(Temp.MotionsId);
                    //Temp.MotionMinistries = GetMotionMinistries(Temp.MotionsId);

                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public int SaveMotionTranslation(int MotionId, string TranslatedText)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "SAVE_MOTION_TRANSLATION";
                cmd.Parameters.Add("@MotionsId", SqlDbType.Int).Value = MotionId;
                cmd.Parameters.Add("@TranslatedText", SqlDbType.VarChar).Value = TranslatedText;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                return 1;
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
        public int FinalizeMotionTranslation(int MotionId, string TranslatedText)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "FINALIZE_MOTION_TRANSLATION";
                cmd.Parameters.Add("@MotionsId", SqlDbType.Int).Value = MotionId;
                cmd.Parameters.Add("@TranslatedText", SqlDbType.VarChar).Value = TranslatedText;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                return 1;
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
        public void SendMotionForTranslation(int MotionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "TRANSLATE_MOTION";
                cmd.Parameters.Add("@MotionsId", SqlDbType.VarChar).Value = MotionId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
        }
        public List<Motion> GetTranslationMotions(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_TRANSLATION_MOTIONS";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.VarChar).Value = AssemblySessionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Motion> MyList = null;
                Motion Temp = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Motion>();
                    while (dr.Read())
                    {
                        Temp = new Motion();
                        Temp.MotionsId = Convert.ToInt32(dr["MOTIONS_ID"]);
                        Temp.FileNo = Convert.ToString(dr["FILE_NO"]);
                        if (dr["MB_WEEK_ID"] != DBNull.Value)
                        {
                            Temp.WeekId = Convert.ToInt32(dr["MB_WEEK_ID"]);
                            Temp.WeekName = Convert.ToString(dr["MB_WEEK"]);
                        }
                        Temp.MotionDiaryNo = Convert.ToString(dr["MOTION_DIARY_NO"]);
                        Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["NOTICE_DIARY_TIME"]);
                        Temp.SessionNumber = Convert.ToInt32(dr["SESSION_NUMBER"]);
                        Temp.SessionDesc = Convert.ToString(dr["SESSION_DESC"]);
                        Temp.MotionStatusId = Convert.ToInt32(dr["MOTION_STATUS_ID"]);
                        Temp.MotionStatus = Convert.ToString(dr["MOTION_STATUS"]);
                        Temp.MotionTypeId = Convert.ToInt32(dr["MOTION_TYPE_ID"]);
                        Temp.MotionType = Convert.ToString(dr["MOTION_TYPE"]);
                        if (dr["REFFERED_SC_DATE"] != DBNull.Value)
                            Temp.RefferedScDate = Convert.ToDateTime(dr["REFFERED_SC_DATE"]);
                        if (dr["MOVING_HOUSE_DATE"] != DBNull.Value)
                            Temp.MovingHouseDate = Convert.ToDateTime(dr["MOVING_HOUSE_DATE"]);
                        if (dr["DISCUSSION_DATE"] != DBNull.Value)
                            Temp.DiscussionDate = Convert.ToDateTime(dr["DISCUSSION_DATE"]);
                        if (dr["SENT_FOR_TRANS_ON"] != DBNull.Value)
                            Temp.SentForTranslationOn = Convert.ToDateTime(dr["SENT_FOR_TRANS_ON"]);
                        if (dr["RETURN_FROM_TRANS_ON"] != DBNull.Value)
                            Temp.ReturnedFromTranslationOn = Convert.ToDateTime(dr["RETURN_FROM_TRANS_ON"]);

                        Temp.Description = Convert.ToString(dr["MOTION_TEXT"]);
                        Temp.NoteDescription = Convert.ToString(dr["SUBJECT"]);
                        //Temp.Movers = new List<MotionMoversEnt>();
                        //Temp.Movers = GetMotionMovers(Temp.MotionsId);
                        //Temp.MotionMinistries = GetMotionMinistries(Temp.MotionsId);
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
        public List<Motion> GetTranslatedMotions(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_TRANSLATED_MOTIONS";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.VarChar).Value = AssemblySessionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Motion> MyList = null;
                Motion Temp = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Motion>();
                    while (dr.Read())
                    {

                        Temp = new Motion();
                        Temp.MotionsId = Convert.ToInt32(dr["MOTIONS_ID"]);
                        Temp.FileNo = Convert.ToString(dr["FILE_NO"]);
                        if (dr["MB_WEEK_ID"] != DBNull.Value)
                        {
                            Temp.WeekId = Convert.ToInt32(dr["MB_WEEK_ID"]);
                            Temp.WeekName = Convert.ToString(dr["MB_WEEK"]);
                        }
                        Temp.MotionDiaryNo = Convert.ToString(dr["MOTION_DIARY_NO"]);
                        Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["NOTICE_DIARY_TIME"]);
                        Temp.SessionNumber = Convert.ToInt32(dr["SESSION_NUMBER"]);
                        Temp.SessionDesc = Convert.ToString(dr["SESSION_DESC"]);
                        Temp.MotionStatusId = Convert.ToInt32(dr["MOTION_STATUS_ID"]);
                        Temp.MotionStatus = Convert.ToString(dr["MOTION_STATUS"]);
                        Temp.MotionTypeId = Convert.ToInt32(dr["MOTION_TYPE_ID"]);
                        Temp.MotionType = Convert.ToString(dr["MOTION_TYPE"]);
                        if (dr["REFFERED_SC_DATE"] != DBNull.Value)
                            Temp.RefferedScDate = Convert.ToDateTime(dr["REFFERED_SC_DATE"]);
                        if (dr["MOVING_HOUSE_DATE"] != DBNull.Value)
                            Temp.MovingHouseDate = Convert.ToDateTime(dr["MOVING_HOUSE_DATE"]);
                        if (dr["DISCUSSION_DATE"] != DBNull.Value)
                            Temp.DiscussionDate = Convert.ToDateTime(dr["DISCUSSION_DATE"]);
                        if (dr["SENT_FOR_TRANS_ON"] != DBNull.Value)
                            Temp.SentForTranslationOn = Convert.ToDateTime(dr["SENT_FOR_TRANS_ON"]);
                        if (dr["RETURN_FROM_TRANS_ON"] != DBNull.Value)
                            Temp.ReturnedFromTranslationOn = Convert.ToDateTime(dr["RETURN_FROM_TRANS_ON"]);
                        Temp.Description = Convert.ToString(dr["MOTION_TEXT"]);
                        Temp.NoteDescription = Convert.ToString(dr["SUBJECT"]);
                        //Temp.Movers = new List<MotionMoversEnt>();
                        //Temp.Movers = GetMotionMovers(Temp.MotionsId);
                        //Temp.MotionMinistries = GetMotionMinistries(Temp.MotionsId);
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
        #endregion

        #region Resolution
        public Resolution GetResolution(int ResolutionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RESOLUTION";
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = ResolutionId;
                cmd.CommandType = CommandType.StoredProcedure;
                Resolution Temp = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = new Resolution();
                    Temp.ResolutionsId = Convert.ToInt32(dr["RESOLUTIONS_ID"]);
                    Temp.ResTypesId = Convert.ToInt32(dr["RES_TYPES_ID"]);
                    Temp.ResType = Convert.ToString(dr["RES_TYPE"]);
                    //  Temp.Description = Regex.Replace(Convert.ToString(dr["DESCRIPTION"]), @"<[^>]+>|&nbsp;", "").Trim();
                    Temp.Description = Convert.ToString(dr["DESCRIPTION"]);
                    Temp.Description = WebUtility.UrlDecode(Temp.Description);
                    Temp.ResolutionDiaryNo = Convert.ToInt32(dr["RESOLUTION_DIARY_NO"]);
                    Temp.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);
                    Temp.SessionNumber = Convert.ToString(dr["SESSION_NUMBER"]);
                    Temp.IsUrdu = Convert.ToInt32(dr["IS_URDU"]);
                    if (dr["RESOLUTION_NUMBER"] != DBNull.Value)
                        Temp.ResolutionNumber = Convert.ToInt32(dr["RESOLUTION_NUMBER"]);
                    if (dr["RESOLUTION_STATUS"] != DBNull.Value)
                        Temp.ResolutionStatusId = Convert.ToInt32(dr["RESOLUTION_STATUS"]);
                    Temp.ResolutionStatus = Convert.ToString(dr["RES_STATUS"]);
                    if (dr["NOTICE_DIARY_NO"] != DBNull.Value)
                        Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                    if (dr["NOTICE_DIARY_DATE"] != DBNull.Value)
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
                    if (dr["RESOLUTION_DIARY_TIME"] != DBNull.Value)
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["RESOLUTION_DIARY_TIME"]);
                    if (dr["MOVED_DATE"] != DBNull.Value)
                        Temp.MovedDate = Convert.ToDateTime(dr["MOVED_DATE"]);
                    if (dr["PASSED_DATE"] != DBNull.Value)
                        Temp.PassedDate = Convert.ToDateTime(dr["PASSED_DATE"]);
                    if (dr["DISCUSSED_DATE"] != DBNull.Value)
                        Temp.DiscussedDate = Convert.ToDateTime(dr["DISCUSSED_DATE"]);
                    if (dr["URDU_TEXT"] != DBNull.Value)
                        Temp.UrduText = Convert.ToString(dr["URDU_TEXT"]);
                    if (dr["RESOLUTION_FILE"] != DBNull.Value)
                        Temp.ResolutionFile = Convert.ToString(dr["RESOLUTION_FILE"]);
                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public int SaveResolutionTranslation(int ResolutionId, string TranslatedText)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "SAVE_RESOLUTION_TRANSLATION";
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = ResolutionId;
                cmd.Parameters.Add("@TranslatedText", SqlDbType.VarChar).Value = TranslatedText;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                return 1;
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
        public int FinalizeResolutionTranslation(int ResolutionId, string TranslatedText)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "FINALIZE_RESOLUTION_TRANSLATION";
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = ResolutionId;
                cmd.Parameters.Add("@TranslatedText", SqlDbType.VarChar).Value = TranslatedText;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                return 1;
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
        public void SendResolutionForTranslation(int ResolutionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "TRANSLATE_RESOLUTION";
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.VarChar).Value = ResolutionId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
        }
        public List<Resolution> GetTranslationResolutions(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_TRANSLATION_RESOLUTIONS";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.VarChar).Value = AssemblySessionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Resolution> MyList = null;
                Resolution Temp = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Resolution>();
                    while (dr.Read())
                    {
                        Temp = new Resolution();
                        Temp.ResolutionsId = Convert.ToInt32(dr["RESOLUTIONS_ID"]);
                        Temp.ResTypesId = Convert.ToInt32(dr["RES_TYPES_ID"]);
                        Temp.ResType = Convert.ToString(dr["RES_TYPE"]);
                        //  Temp.Description = Regex.Replace(Convert.ToString(dr["DESCRIPTION"]), @"<[^>]+>|&nbsp;", "").Trim();
                        Temp.Description = Convert.ToString(dr["DESCRIPTION"]);
                        Temp.Description = WebUtility.UrlDecode(Temp.Description);
                        Temp.ResolutionDiaryNo = Convert.ToInt32(dr["RESOLUTION_DIARY_NO"]);
                        Temp.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);
                        Temp.SessionNumber = Convert.ToString(dr["SESSION_NUMBER"]);
                        Temp.IsUrdu = Convert.ToInt32(dr["IS_URDU"]);
                        if (dr["RESOLUTION_NUMBER"] != DBNull.Value)
                            Temp.ResolutionNumber = Convert.ToInt32(dr["RESOLUTION_NUMBER"]);
                        if (dr["RESOLUTION_STATUS"] != DBNull.Value)
                            Temp.ResolutionStatusId = Convert.ToInt32(dr["RESOLUTION_STATUS"]);
                        Temp.ResolutionStatus = Convert.ToString(dr["RES_STATUS"]);
                        if (dr["NOTICE_DIARY_NO"] != DBNull.Value)
                            Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                        if (dr["NOTICE_DIARY_DATE"] != DBNull.Value)
                            Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
                        if (dr["RESOLUTION_DIARY_TIME"] != DBNull.Value)
                            Temp.NoticeDiaryTime = Convert.ToDateTime(dr["RESOLUTION_DIARY_TIME"]);
                        if (dr["MOVED_DATE"] != DBNull.Value)
                            Temp.MovedDate = Convert.ToDateTime(dr["MOVED_DATE"]);
                        if (dr["PASSED_DATE"] != DBNull.Value)
                            Temp.PassedDate = Convert.ToDateTime(dr["PASSED_DATE"]);
                        if (dr["DISCUSSED_DATE"] != DBNull.Value)
                            Temp.DiscussedDate = Convert.ToDateTime(dr["DISCUSSED_DATE"]);
                        if (dr["SENT_FOR_TRANS_ON"] != DBNull.Value)
                            Temp.SentForTranslationOn = Convert.ToDateTime(dr["SENT_FOR_TRANS_ON"]);
                        if (dr["RETURN_FROM_TRANS_ON"] != DBNull.Value)
                            Temp.ReturnedFromTranslationOn = Convert.ToDateTime(dr["RETURN_FROM_TRANS_ON"]);
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
        public List<Resolution> GetTranslatedResolutions(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_TRANSLATED_RESOLUTIONS";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.VarChar).Value = AssemblySessionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Resolution> MyList = null;
                Resolution Temp = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Resolution>();
                    while (dr.Read())
                    {

                        Temp = new Resolution();
                        Temp.ResolutionsId = Convert.ToInt32(dr["RESOLUTIONS_ID"]);
                        Temp.ResTypesId = Convert.ToInt32(dr["RES_TYPES_ID"]);
                        Temp.ResType = Convert.ToString(dr["RES_TYPE"]);
                        //  Temp.Description = Regex.Replace(Convert.ToString(dr["DESCRIPTION"]), @"<[^>]+>|&nbsp;", "").Trim();
                        Temp.Description = Convert.ToString(dr["DESCRIPTION"]);
                        Temp.Description = WebUtility.UrlDecode(Temp.Description);
                        Temp.ResolutionDiaryNo = Convert.ToInt32(dr["RESOLUTION_DIARY_NO"]);
                        Temp.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);
                        Temp.SessionNumber = Convert.ToString(dr["SESSION_NUMBER"]);
                        Temp.IsUrdu = Convert.ToInt32(dr["IS_URDU"]);
                        if (dr["RESOLUTION_NUMBER"] != DBNull.Value)
                            Temp.ResolutionNumber = Convert.ToInt32(dr["RESOLUTION_NUMBER"]);
                        if (dr["RESOLUTION_STATUS"] != DBNull.Value)
                            Temp.ResolutionStatusId = Convert.ToInt32(dr["RESOLUTION_STATUS"]);
                        Temp.ResolutionStatus = Convert.ToString(dr["RES_STATUS"]);
                        if (dr["NOTICE_DIARY_NO"] != DBNull.Value)
                            Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                        if (dr["NOTICE_DIARY_DATE"] != DBNull.Value)
                            Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
                        if (dr["RESOLUTION_DIARY_TIME"] != DBNull.Value)
                            Temp.NoticeDiaryTime = Convert.ToDateTime(dr["RESOLUTION_DIARY_TIME"]);
                        if (dr["MOVED_DATE"] != DBNull.Value)
                            Temp.MovedDate = Convert.ToDateTime(dr["MOVED_DATE"]);
                        if (dr["PASSED_DATE"] != DBNull.Value)
                            Temp.PassedDate = Convert.ToDateTime(dr["PASSED_DATE"]);
                        if (dr["DISCUSSED_DATE"] != DBNull.Value)
                            Temp.DiscussedDate = Convert.ToDateTime(dr["DISCUSSED_DATE"]);
                        if (dr["SENT_FOR_TRANS_ON"] != DBNull.Value)
                            Temp.SentForTranslationOn = Convert.ToDateTime(dr["SENT_FOR_TRANS_ON"]);
                        if (dr["RETURN_FROM_TRANS_ON"] != DBNull.Value)
                            Temp.ReturnedFromTranslationOn = Convert.ToDateTime(dr["RETURN_FROM_TRANS_ON"]);
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
        #endregion

        #region User Questions

        public void AssignQuestionForTranslation(int UserId,List<string> Questions)
        {
            if (Questions != null)
            {
                string csv = string.Join(",", Questions);
                SqlConnection con = new DalHelper().GetConnection();
                try
                {
                    string query = "update QUESTIONS Set ASSIGNED_FOR_TRANS_TO = " + UserId + ",ASSIGNED_FOR_TRANS_ON ='" + DateTime.Now + "',TRANSLATION_STATUS=2 Where QUESTIONS_ID IN(" + csv + ")";
                    SqlCommand cmd = new SqlCommand(query, con);
                    using (con)
                    {
                        SqlDataReader dr = cmd.ExecuteReader();

                    }
                }
                finally
                {
                    con.Close();

                }
            }
        }
        public List<Questions> GetTranslationQuestionsByUser(int userid)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_USER_TRANSLATION_QUESTIONS";
                //cmd.Parameters.Add("@AssemblySessionId", SqlDbType.VarChar).Value = AssemblySessionsId;
                cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = userid;
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
                        if (dr["SENT_FOR_TRANS_ON"] != DBNull.Value)
                            Temp.SentForTranslationOn = Convert.ToDateTime(dr["SENT_FOR_TRANS_ON"]);
                        if (dr["RETURN_FROM_TRANS_ON"] != DBNull.Value)
                            Temp.ReturnedFromTranslationOn = Convert.ToDateTime(dr["RETURN_FROM_TRANS_ON"]);
                        if (dr["Question_File"] != DBNull.Value)
                            Temp.QuestionFile = Convert.ToString(dr["Question_File"]);

                        Temp.Ministry = Convert.ToString(dr["Ministry"]);
                        Temp.MinistryGroup = Convert.ToString(dr["Ministry_Group"]);
                        Temp.Division = Convert.ToString(dr["Division"]);
                        if (dr["Notice_Diary_No"] != DBNull.Value)
                            Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                        if (dr["Question_Diary_No"] != DBNull.Value)
                            Temp.QuestionDiaryNo = Convert.ToInt32(dr["Question_Diary_No"]);
                        Temp.SessionNumberId = Convert.ToInt32(dr["Session_Number"]);
                        Temp.SessionNumber = Convert.ToString(dr["Session_Name"]);
                        Temp.IsCarryFwd = Convert.ToInt32(dr["Is_Carry_Fwd"]);
                        if (dr["Session_Sittings_Id"] != DBNull.Value)
                            Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
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
        public List<Questions> GetTranslatedQuestionsByUser(int userid)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_USER_TRANSLATED_QUESTIONS";
                //cmd.Parameters.Add("@AssemblySessionId", SqlDbType.VarChar).Value = AssemblySessionsId;
                cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = userid;
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
                        if (dr["SENT_FOR_TRANS_ON"] != DBNull.Value)
                            Temp.SentForTranslationOn = Convert.ToDateTime(dr["SENT_FOR_TRANS_ON"]);
                        if (dr["RETURN_FROM_TRANS_ON"] != DBNull.Value)
                            Temp.ReturnedFromTranslationOn = Convert.ToDateTime(dr["RETURN_FROM_TRANS_ON"]);
                        if (dr["Question_File"] != DBNull.Value)
                            Temp.QuestionFile = Convert.ToString(dr["Question_File"]);

                        Temp.Ministry = Convert.ToString(dr["Ministry"]);
                        Temp.MinistryGroup = Convert.ToString(dr["Ministry_Group"]);
                        Temp.Division = Convert.ToString(dr["Division"]);
                        if (dr["Notice_Diary_No"] != DBNull.Value)
                            Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                        if (dr["Question_Diary_No"] != DBNull.Value)
                            Temp.QuestionDiaryNo = Convert.ToInt32(dr["Question_Diary_No"]);
                        Temp.SessionNumberId = Convert.ToInt32(dr["Session_Number"]);
                        Temp.SessionNumber = Convert.ToString(dr["Session_Name"]);
                        Temp.IsCarryFwd = Convert.ToInt32(dr["Is_Carry_Fwd"]);
                        if (dr["Session_Sittings_Id"] != DBNull.Value)
                            Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
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
        
        #endregion
    }
}
