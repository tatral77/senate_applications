using Entities;
using MotionEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace QuestionDAL
{
    public class QuestionDal
    {



        //------------------------------------END----------------------------------------//

        //------------------------------------END-------------------------------------//

        #region  GroupDivisions

        public List<GroupDivisions> GetGroupDivisions(int AssemblySessionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_GROUPS_DIVISIONS";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = AssemblySessionId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<GroupDivisions> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<GroupDivisions>();
                    while (dr.Read())
                    {
                        GroupDivisions Temp = new GroupDivisions();

                        Temp.GroupDivisionsId = Convert.ToInt32(dr["Group_Divisions_Id"]);
                        Temp.GroupSequence = Convert.ToInt32(dr["GROUP_SEQUENCE"]);
                        Temp.Group = Convert.ToString(dr["GROUPDESC"]);
                        Temp.GroupsId = Convert.ToInt32(dr["Groups_Id"]);
                        Temp.DivisionsId = Convert.ToInt32(dr["Divisions_Id"]);
                        Temp.Division = Convert.ToString(dr["Division"]);
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
        public void CopyNewDivisions(int CurrentSessionId, int NewSessionId)
        {
            for (int i = 1; i <= 5; i++)
            {
                List<Groups> CurrentCorrespondingGroups = GetSessionCorrespondingGroups(CurrentSessionId, i);
                List<Groups> NewCorrespondingGroups = GetSessionCorrespondingGroups(NewSessionId, i);
                List<GroupDivisions> CurrentGroupDivisions = GetDivisionsBySessionGroup(CurrentSessionId, CurrentCorrespondingGroups[0].GroupsId);
                foreach (Groups newgroups in NewCorrespondingGroups)
                {
                    foreach (GroupDivisions groupdivisions in CurrentGroupDivisions)
                    {
                        groupdivisions.GroupsId = newgroups.GroupsId;
                        InsertGroupDivisions(groupdivisions);
                    }
                }
            }



        }
        public List<GroupDivisions> GetSingleGroupDivisions(int AssemblySessionId, int GroupSequenceId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                //SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                //cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_GROUP_DIVS";
                //cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = AssemblySessionId;
                //cmd.Parameters.Add("@GroupSequenc", SqlDbType.Int).Value = GroupSequenceId;
                //cmd.CommandType = CommandType.StoredProcedure;
                //List<GroupDivisions> MyList = null;
                //SqlDataReader dr = cmd.ExecuteReader();
                string query = "SELECT DIVISIONS.DESCRIPTION AS DIVISION, GROUP_DIVISIONS.GROUP_DIVISIONS_ID, GROUPS.GROUP_SEQUENCE, GROUPS.DESCRIPTION AS GROUPDESC, GROUP_DIVISIONS.GROUPS_ID, GROUP_DIVISIONS.DIVISIONS_ID";
                query += " FROM            GROUPS INNER JOIN ";
                query += "          GROUP_DIVISIONS ON GROUPS.GROUPS_ID = GROUP_DIVISIONS.GROUPS_ID INNER JOIN ";
                query += "     DIVISIONS ON GROUP_DIVISIONS.DIVISIONS_ID = DIVISIONS.DIVISIONS_ID ";

                query += "  WHERE(GROUPS.ASSEMBLY_SESSIONS_ID =" + AssemblySessionId + ") AND(GROUPS.GROUP_SEQUENCE =" + GroupSequenceId + ")";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                List<GroupDivisions> MyList = null;
                if (dr.HasRows)
                {
                    MyList = new List<GroupDivisions>();
                    while (dr.Read())
                    {
                        GroupDivisions Temp = new GroupDivisions();

                        Temp.GroupDivisionsId = Convert.ToInt32(dr["Group_Divisions_Id"]);
                        Temp.GroupSequence = Convert.ToInt32(dr["GROUP_SEQUENCE"]);
                        Temp.Group = Convert.ToString(dr["GROUPDESC"]);
                        Temp.GroupsId = Convert.ToInt32(dr["Groups_Id"]);
                        Temp.DivisionsId = Convert.ToInt32(dr["Divisions_Id"]);
                        Temp.Division = Convert.ToString(dr["Division"]);
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
        public List<Divisions> GetUnAssignedDivisions(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_UN_ASSIGNED_DIVISIONS";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.VarChar).Value = AssemblySessionsId;
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
        //public void UpdateGroupDivision(GroupDivisions Temp)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_GROUP_DIVISION";
        //        cmd.Parameters.Add("@GroupsId", SqlDbType.Int).Value = Temp.GroupsId;
        //        cmd.Parameters.Add("@DivisionsId", SqlDbType.Int).Value = Temp.DivisionsId;
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
        public void InsertGroupDivisions(GroupDivisions Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_GROUP_DIVISION";
                cmd.Parameters.Add("@GroupsId", SqlDbType.VarChar).Value = Temp.GroupsId;
                cmd.Parameters.Add("@DivisionId", SqlDbType.VarChar).Value = Temp.DivisionsId;
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

        public void DeleteGroupDivisions(int GroupsId, int DivisionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_GROUP_DIVISION";
                cmd.Parameters.Add("@GroupsId", SqlDbType.Int).Value = GroupsId;
                cmd.Parameters.Add("@DivisionsId", SqlDbType.Int).Value = DivisionId;
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

        //------------------------------------END-------------------------------------//

        #region  Groups

        public Groups GetGroupById(int GroupId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_GROUP";
                cmd.Parameters.Add("@GroupsId", SqlDbType.Int).Value = GroupId;
                cmd.CommandType = CommandType.StoredProcedure;
                Groups Temp = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = new Groups();
                    Temp.GroupsId = Convert.ToInt32(dr["Groups_Id"]);
                    Temp.Description = Convert.ToString(dr["Group_Name"]);
                    Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                    Temp.AssembliesSessionId = Convert.ToInt32(dr["Assembly_Sessions_Id"]);
                    //Temp.AssembliesSession = Convert.ToString(dr["Session_Number"]);
                    Temp.CorrespondingGroup = Convert.ToInt32(dr["Corresponding_Group"]);
                    Temp.GroupSequence = Convert.ToInt32(dr["Group_Sequence"]);
                    Temp.UnstarDesc = Convert.ToString(dr["Unstar_Desc"]);


                }

                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public List<Groups> GetSessionGroups(int AssemplySessionsId, int CategoryId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                if (CategoryId == 1 || CategoryId == 3)
                    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SESSION_GROUPS";
                else if (CategoryId == 2)
                    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_UNSTARRED_GROUPS";
                else
                    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "";


                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = AssemplySessionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Groups> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Groups>();
                    while (dr.Read())
                    {
                        Groups Temp = new Groups();

                        Temp.GroupsId = Convert.ToInt32(dr["Groups_Id"]);
                        Temp.Description = Convert.ToString(dr["Description"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        Temp.AssembliesSessionId = Convert.ToInt32(dr["Assembly_Sessions_Id"]);
                        //Temp.AssembliesSession = Convert.ToString(dr["Session_Number"]);
                        Temp.CorrespondingGroup = Convert.ToInt32(dr["Corresponding_Group"]);
                        Temp.GroupSequence = Convert.ToInt32(dr["Group_Sequence"]);
                        Temp.UnstarDesc = Convert.ToString(dr["Unstar_Desc"]);

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
        public List<Groups> GetSessionCorrespondingGroups(int AssemplySessionsId, int CorrespondingGroupId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);

                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SESSION_CORRESPONDING_GROUPS";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = AssemplySessionsId;
                cmd.Parameters.Add("@CorrespondingGroupId", SqlDbType.Int).Value = CorrespondingGroupId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Groups> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Groups>();
                    while (dr.Read())
                    {
                        Groups Temp = new Groups();

                        Temp.GroupsId = Convert.ToInt32(dr["Groups_Id"]);
                        Temp.Description = Convert.ToString(dr["DESCRIPTION"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        Temp.AssembliesSessionId = Convert.ToInt32(dr["Assembly_Sessions_Id"]);
                        //Temp.AssembliesSession = Convert.ToString(dr["Session_Number"]);
                        Temp.CorrespondingGroup = Convert.ToInt32(dr["Corresponding_Group"]);
                        Temp.GroupSequence = Convert.ToInt32(dr["Group_Sequence"]);
                        Temp.UnstarDesc = Convert.ToString(dr["Unstar_Desc"]);
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
        public void CopyNewSessionGroups(int NewSessionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            int CurrentSessionId = new AdministrationDAL().GetCurrentAssemblySessions();
            List<Groups> CurrentGroups = GetSessionGroups(CurrentSessionId, 1);
            try
            {
                if (CurrentGroups != null)
                {
                    foreach (Groups currentgroup in CurrentGroups)
                    {
                        Groups newgroup = new Groups();
                        newgroup.AssembliesSessionId = NewSessionId;
                        newgroup.IsActive = currentgroup.IsActive;
                        newgroup.Description = currentgroup.Description;
                        newgroup.CorrespondingGroupId = currentgroup.CorrespondingGroupId;
                        newgroup.GroupSequence = currentgroup.GroupSequence;
                        newgroup.UnstarDesc = currentgroup.UnstarDesc;
                        InsertGroups(newgroup);
                    }
                }
            }

            finally
            {
                con.Close();

            }
        }

        public void UpdateGroups(Groups Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_GROUPS";
                cmd.Parameters.Add("@Descriptation", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = Temp.AssembliesSessionId;
                cmd.Parameters.Add("@CorrespondingGroup", SqlDbType.Int).Value = Temp.CorrespondingGroup;
                cmd.Parameters.Add("@GroupSequence", SqlDbType.Int).Value = Temp.GroupSequence;
                cmd.Parameters.Add("@UnstarDesc", SqlDbType.VarChar).Value = Temp.UnstarDesc;
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
        public void InsertGroups(Groups Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_GROUPS";
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = Temp.AssembliesSessionId;
                cmd.Parameters.Add("@CorrespondingGroup", SqlDbType.Int).Value = Temp.CorrespondingGroup;
                cmd.Parameters.Add("@GroupSequenc", SqlDbType.Int).Value = Temp.GroupSequence;
                cmd.Parameters.Add("@UnstarDesc", SqlDbType.VarChar).Value = Temp.UnstarDesc;
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

        #endregion Groups

        //------------------------------------END-------------------------------------//


        //------------------------------------END-------------------------------------//


        //------------------------------------END-------------------------------------//

        //------------------------------------END-------------------------------------//

        #region Questions

        public int GetQuestionPk()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_QUESTION_PK";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                int Questionsid = Convert.ToInt32(dr["Questions_Id"]);
                Questionsid++;
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
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
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
                    Temp.QuestionStatus = Convert.ToString(dr["Question_Status_desc"]);
                    Temp.ListId = Convert.ToInt32(dr["LIST_NO"]);
                    Temp.SupNo = Convert.ToString(dr["SUP_NO"]);
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
                    if (dr["FILE_STATUS_ID"] != DBNull.Value)
                    {
                        Temp.FileStatusId = Convert.ToInt32(dr["FILE_STATUS_ID"]);
                    }

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
                    Temp.QuestionText = Convert.ToString(dr["Question_Text"]);
                    if (dr["Urdu_Text"] != DBNull.Value)
                        Temp.UrduText = Convert.ToString(dr["Urdu_Text"]);
                    if (dr["Subject"] != DBNull.Value)
                        Temp.Subject = Convert.ToString(dr["Subject"]);
                    if (dr["SO_REMARKS"] != DBNull.Value)
                        Temp.SORemarks = Convert.ToString(dr["SO_REMARKS"]);
                    //Temp.Ministry = Convert.ToString(dr["Ministry"]);
                    if (dr["MINISTRY_GROUP"] != DBNull.Value)
                    {
                        Temp.MinistryGroupId = Convert.ToInt32(dr["MINISTRY_GROUP"]);
                        Temp.MinistryGroup = Convert.ToString(dr["GROUPDESC"]);
                        Temp.UnstarDesc = Convert.ToString(dr["UNSTAR_DESC"]);
                        Temp.GroupSequence = Convert.ToInt32(dr["GROUP_SEQUENCE"]);
                    }

                    Temp.DivisionId = Convert.ToInt32(dr["Division"]);
                    Temp.Division = Convert.ToString(dr["Division_Name"]);
                    Temp.Priority = Convert.ToInt32(dr["Priority"]);
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
                    Temp.SessionNumber = Convert.ToString(dr["SessionNumber"]);
                    if (dr["Session_Sittings_Id"] != DBNull.Value)
                        Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
                    if (dr["Reply"] != DBNull.Value)
                        Temp.Reply = Convert.ToString(dr["Reply"]);
                    if (dr["Reply_Date"] != DBNull.Value)
                        Temp.ReplyDate = Convert.ToDateTime(dr["Reply_Date"]);
                    Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                    if (dr["QUESTION_FILE"] != DBNull.Value)
                        Temp.QuestionFile = Convert.ToString(dr["QUESTION_FILE"]);
                    if (dr["Updated_By"] != DBNull.Value)
                        Temp.UpdatedBy = Convert.ToInt32(dr["Updated_By"]);
                    if (dr["Updated_on"] != DBNull.Value)
                        Temp.UpdatedOn = Convert.ToDateTime(dr["Updated_on"]);
                    if (dr["Inserted_By"] != DBNull.Value)
                        Temp.InsertedBy = Convert.ToInt32(dr["Inserted_By"]);
                    if (dr["Inserted_on"] != DBNull.Value)
                        Temp.InsertedOn = Convert.ToDateTime(dr["Inserted_on"]);
                    if (dr["Deleted_By"] != DBNull.Value)
                        Temp.DeletedBy = Convert.ToInt32(dr["Deleted_By"]);
                    if (dr["deletion_date"] != DBNull.Value)
                        Temp.DeletedOn = Convert.ToDateTime(dr["deletion_date"]);
                    if (dr["Recovered_By"] != DBNull.Value)
                        Temp.RecoveredBy = Convert.ToInt32(dr["Recovered_By"]);
                    if (dr["Recovered_On"] != DBNull.Value)
                        Temp.RecoveredOn = Convert.ToDateTime(dr["Recovered_On"]);
                    if (dr["SENT_FOR_TRANSLATION_BY"] != DBNull.Value)
                        Temp.SentForTranslationBy = Convert.ToInt32(dr["SENT_FOR_TRANSLATION_BY"]);
                    if (dr["SENT_FOR_TRANS_ON"] != DBNull.Value)
                        Temp.SentForTranslationOn = Convert.ToDateTime(dr["SENT_FOR_TRANS_ON"]);
                    if (dr["TRANS_APPROVED_BY"] != DBNull.Value)
                        Temp.TranslationApprovedBy = Convert.ToInt32(dr["TRANS_APPROVED_BY"]);
                    if (dr["TRANS_APPROVED_ON"] != DBNull.Value)
                        Temp.TranslationApprovedOn = Convert.ToDateTime(dr["TRANS_APPROVED_ON"]);
                    Temp.DeviceId = Convert.ToInt32(dr["DEVICE_ID"]);

                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }

        public Questions GetNoticeQuestionByIdMin(int QuestionId)
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
                    if (dr["PREV_QUESTIONS_ID"] != DBNull.Value)
                        Temp.PreviousQuestionsId = Convert.ToInt32(dr["PREV_QUESTIONS_ID"]);
                    if (dr["QBR_QUESTIONS_ID"] != DBNull.Value)
                        Temp.QuestionBranchId = Convert.ToInt32(dr["QBR_QUESTIONS_ID"]);
                    if (dr["Mover"] != DBNull.Value)
                    {
                        Temp.Mover = Convert.ToInt32(dr["Mover"]);
                        Temp.MoverName = Convert.ToString(dr["F_Name"]);
                    }
                    if (dr["QUESTION_CATEGORY"] != DBNull.Value)
                    {
                        Temp.QuestionCategoriesId = Convert.ToInt32(dr["QUESTION_CATEGORY"]);
                    }
                    //if (dr["FILE_STATUS_ID"] != DBNull.Value)
                    //{
                    //    Temp.FileStatusId = Convert.ToInt32(dr["FILE_STATUS_ID"]);
                    //}
                    Temp.QuestionStatusId = Convert.ToInt32(dr["Question_Status"]);

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
                    if (dr["QUESTION_FILE"] != DBNull.Value)
                        Temp.QuestionFile = Convert.ToString(dr["QUESTION_FILE"]);
                    if (dr["Urdu_Text"] != DBNull.Value)
                        Temp.UrduText = Convert.ToString(dr["Urdu_Text"]);

                    Temp.QuestionText = Convert.ToString(dr["Question_Text"]);
                    //Temp.Ministry = Convert.ToString(dr["Ministry"]);
                    if (dr["MINISTRY_GROUP"] != DBNull.Value)
                    {
                        Temp.MinistryGroupId = Convert.ToInt32(dr["MINISTRY_GROUP"]);
                    }
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
                    //if (dr["Priority"] != DBNull.Value)
                    //	Temp.Priority = Convert.ToInt32(dr["Priority"]);
                    // Temp.QuestionDiaryTime = Convert.ToDateTime(dr["Question_Diary_Time"]);
                    Temp.SessionNumberId = Convert.ToInt32(dr["Session_Number"]);
                    Temp.SessionNumber = Convert.ToString(dr["SESSION_NAME"]);
                    if (dr["Session_Sittings_Id"] != DBNull.Value)
                        Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
                    if (dr["Reply"] != DBNull.Value)
                        Temp.Reply = Convert.ToString(dr["Reply"]);
                    if (dr["Reply_Date"] != DBNull.Value)
                        Temp.ReplyDate = Convert.ToDateTime(dr["Reply_Date"]);
                    if (dr["CHECKED"] != DBNull.Value)
                        Temp.Checked = Convert.ToInt32(dr["CHECKED"]);
                    //if (dr["Updated_By"] != DBNull.Value)
                    //    Temp.UpdatedBy = Convert.ToInt32(dr["Updated_By"]);
                    //if (dr["Updated_on"] != DBNull.Value)
                    //    Temp.UpdatedOn = Convert.ToDateTime(dr["Updated_on"]);
                    //if (dr["Inserted_By"] != DBNull.Value)
                    //    Temp.InsertedBy = Convert.ToInt32(dr["Inserted_By"]);
                    //if (dr["Inserted_on"] != DBNull.Value)
                    //    Temp.InsertedOn = Convert.ToDateTime(dr["Inserted_on"]);
                    //if (dr["Deleted_By"] != DBNull.Value)
                    //    Temp.DeletedBy = Convert.ToInt32(dr["Deleted_By"]);
                    //if (dr["deletion_date"] != DBNull.Value)
                    //    Temp.DeletedOn = Convert.ToDateTime(dr["deletion_date"]);
                    //if (dr["Recovered_By"] != DBNull.Value)
                    //    Temp.RecoveredBy = Convert.ToInt32(dr["Recovered_By"]);
                    //if (dr["Recovered_On"] != DBNull.Value)
                    //    Temp.RecoveredOn = Convert.ToDateTime(dr["Recovered_On"]);
                    //if (dr["SENT_FOR_TRANSLATION_BY"] != DBNull.Value)
                    //    Temp.SentForTranslationBy = Convert.ToInt32(dr["SENT_FOR_TRANSLATION_BY"]);
                    //if (dr["SENT_FOR_TRANS_ON"] != DBNull.Value)
                    //    Temp.SentForTranslationOn = Convert.ToDateTime(dr["SENT_FOR_TRANS_ON"]);
                    //if (dr["TRANS_APPROVED_BY"] != DBNull.Value)
                    //    Temp.TranslationApprovedBy = Convert.ToInt32(dr["TRANS_APPROVED_BY"]);
                    //if (dr["TRANS_APPROVED_ON"] != DBNull.Value)
                    //    Temp.TranslationApprovedOn = Convert.ToDateTime(dr["TRANS_APPROVED_ON"]);

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
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
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
                    //if (dr["Subject"] != DBNull.Value)
                    //{
                    //    Temp.Subject = Convert.ToString(dr["Subject"]);
                    //    //if(Temp.Subject.Length>42)
                    //    //Temp.Subject = Temp.Subject.Substring(43);
                    //}
                    if (dr["FILE_STATUS_ID"] != DBNull.Value)
                    {
                        Temp.FileStatusId = Convert.ToInt32(dr["FILE_STATUS_ID"]);
                    }
                    if (dr["QUESTION_FILE"] != DBNull.Value)
                        Temp.QuestionFile = Convert.ToString(dr["QUESTION_FILE"]);
                    if (dr["Subject"] != DBNull.Value)
                    {
                        Temp.Subject = Convert.ToString(dr["Subject"]);
                        //if(Temp.Subject.Length>42)
                        //Temp.Subject = Temp.Subject.Substring(43);
                    }
                    if (dr["Urdu_Text"] != DBNull.Value)
                        Temp.UrduText = Convert.ToString(dr["Urdu_Text"]);
                    if (dr["SO_REMARKS"] != DBNull.Value)
                        Temp.SORemarks = Convert.ToString(dr["SO_REMARKS"]);
                    Temp.QuestionText = Convert.ToString(dr["Question_Text"]);
                    //Temp.Ministry = Convert.ToString(dr["Ministry"]);
                    if (dr["MINISTRY_GROUP"] != DBNull.Value)
                    {
                        Temp.MinistryGroupId = Convert.ToInt32(dr["MINISTRY_GROUP"]);
                    }
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
                    if (dr["Priority"] != DBNull.Value)
                        Temp.Priority = Convert.ToInt32(dr["Priority"]);
                    // Temp.QuestionDiaryTime = Convert.ToDateTime(dr["Question_Diary_Time"]);
                    Temp.SessionNumberId = Convert.ToInt32(dr["Session_Number"]);
                    Temp.SessionNumber = Convert.ToString(dr["SessionNumber"]);
                    if (dr["Session_Sittings_Id"] != DBNull.Value)
                        Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
                    if (dr["Reply"] != DBNull.Value)
                        Temp.Reply = Convert.ToString(dr["Reply"]);
                    if (dr["Reply_Date"] != DBNull.Value)
                        Temp.ReplyDate = Convert.ToDateTime(dr["Reply_Date"]);
                    if (dr["Updated_By"] != DBNull.Value)
                        Temp.UpdatedBy = Convert.ToInt32(dr["Updated_By"]);
                    if (dr["Updated_on"] != DBNull.Value)
                        Temp.UpdatedOn = Convert.ToDateTime(dr["Updated_on"]);
                    if (dr["Inserted_By"] != DBNull.Value)
                        Temp.InsertedBy = Convert.ToInt32(dr["Inserted_By"]);
                    if (dr["Inserted_on"] != DBNull.Value)
                        Temp.InsertedOn = Convert.ToDateTime(dr["Inserted_on"]);
                    if (dr["Deleted_By"] != DBNull.Value)
                        Temp.DeletedBy = Convert.ToInt32(dr["Deleted_By"]);
                    if (dr["deletion_date"] != DBNull.Value)
                        Temp.DeletedOn = Convert.ToDateTime(dr["deletion_date"]);
                    if (dr["Recovered_By"] != DBNull.Value)
                        Temp.RecoveredBy = Convert.ToInt32(dr["Recovered_By"]);
                    if (dr["Recovered_On"] != DBNull.Value)
                        Temp.RecoveredOn = Convert.ToDateTime(dr["Recovered_On"]);
                    if (dr["SENT_FOR_TRANSLATION_BY"] != DBNull.Value)
                        Temp.SentForTranslationBy = Convert.ToInt32(dr["SENT_FOR_TRANSLATION_BY"]);
                    if (dr["SENT_FOR_TRANS_ON"] != DBNull.Value)
                        Temp.SentForTranslationOn = Convert.ToDateTime(dr["SENT_FOR_TRANS_ON"]);
                    if (dr["TRANS_APPROVED_BY"] != DBNull.Value)
                        Temp.TranslationApprovedBy = Convert.ToInt32(dr["TRANS_APPROVED_BY"]);
                    if (dr["TRANS_APPROVED_ON"] != DBNull.Value)
                        Temp.TranslationApprovedOn = Convert.ToDateTime(dr["TRANS_APPROVED_ON"]);
                    Temp.DeviceId = Convert.ToInt32(dr["DEVICE_ID"]);





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

                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
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
                        Temp.ListId = Convert.ToInt32(dr["List_No"]);
                        if (dr["SUP_NO"] != DBNull.Value)
                            Temp.SupNo = Convert.ToString(dr["SUP_NO"]);
                        if (dr["Question_Date"] != DBNull.Value)
                            Temp.QuestionDate = Convert.ToDateTime(dr["Question_Date"]);
                        Temp.QuestionCategory = Convert.ToString(dr["Category"]);
                        Temp.QuestionStatus = Convert.ToString(dr["Question_Status"]);
                        if (dr["STATUS_DATE"] != DBNull.Value)
                            Temp.QuestionStatusDate = Convert.ToDateTime(dr["STATUS_DATE"]);
                        if (dr["REPLY_DATE"] != DBNull.Value)
                            Temp.QuestionStatusDate = Convert.ToDateTime(dr["REPLY_DATE"]);

                        if (dr["QUESTION_DIARY_DATE"] != DBNull.Value)
                            Temp.QuestionDiaryDate = Convert.ToDateTime(dr["QUESTION_DIARY_DATE"]);
                        if (dr["Question_Time"] != DBNull.Value)
                            Temp.QuestionTime = Convert.ToString(dr["Question_Time"]);
                        if (dr["Subject"] != DBNull.Value)
                        {
                            Temp.Subject = Convert.ToString(dr["Subject"]);
                            //if(Temp.Subject.Length>42)
                            //Temp.Subject = Temp.Subject.Substring(43);
                        }
                        if (dr["FILE_STATUS_ID"] != DBNull.Value)
                        {
                            Temp.FileStatusId = Convert.ToInt32(dr["FILE_STATUS_ID"]);
                        }
                        Temp.QuestionText = Convert.ToString(dr["Question_Text"]);
                        if (dr["Urdu_Text"] != DBNull.Value)
                            Temp.UrduText = Convert.ToString(dr["Urdu_Text"]);
                        if (dr["Question_File"] != DBNull.Value)
                            Temp.QuestionFile = Convert.ToString(dr["Question_File"]);

                        Temp.Ministry = Convert.ToString(dr["Ministry"]);
                        Temp.MinistryGroup = Convert.ToString(dr["Ministry_Group"]);
                        Temp.DivisionId = Convert.ToInt32(dr["Division"]);
                        Temp.Division = Convert.ToString(dr["DIVISION_NAME"]);
                        // Temp.DepartmentsId = Convert.ToInt32(dr["Departments_Id"]);
                        // Temp.Department = Convert.ToString(dr["Deptt_Name"]);
                        //Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                        //Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                        if (dr["Notice_Diary_No"] != DBNull.Value)
                            Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                        //Temp.AdmittedNumber = Convert.ToString(dr["Admitted_Number"]);
                        if (dr["Question_Diary_No"] != DBNull.Value)
                            Temp.QuestionDiaryNo = Convert.ToInt32(dr["Question_Diary_No"]);
                        //Temp.QuestionDiaryDate = Convert.ToDateTime(dr["Question_Diary_Date"]);

                        // Temp.QuestionDiaryTime = Convert.ToDateTime(dr["Question_Diary_Time"]);
                        Temp.SessionNumberId = Convert.ToInt32(dr["Session_Number"]);
                        Temp.SessionNumber = Convert.ToString(dr["Session_Name"]);
                        Temp.IsCarryFwd = Convert.ToInt32(dr["Is_Carry_Fwd"]);
                        if (dr["Session_Sittings_Id"] != DBNull.Value)
                            Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
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
        public List<Questions> GetDeletedQuestions()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_DELETED_QUESTIONS";
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
                        Temp.ListId = Convert.ToInt32(dr["List_No"]);
                        if (dr["Question_Date"] != DBNull.Value)
                            Temp.QuestionDate = Convert.ToDateTime(dr["Question_Date"]);
                        Temp.QuestionCategory = Convert.ToString(dr["Category"]);
                        Temp.QuestionStatus = Convert.ToString(dr["Question_Status"]);
                        if (dr["STATUS_DATE"] != DBNull.Value)
                            Temp.QuestionStatusDate = Convert.ToDateTime(dr["STATUS_DATE"]);
                        if (dr["REPLY_DATE"] != DBNull.Value)
                            Temp.QuestionStatusDate = Convert.ToDateTime(dr["REPLY_DATE"]);

                        if (dr["QUESTION_DIARY_DATE"] != DBNull.Value)
                            Temp.QuestionDiaryDate = Convert.ToDateTime(dr["QUESTION_DIARY_DATE"]);
                        if (dr["Question_Time"] != DBNull.Value)
                            Temp.QuestionTime = Convert.ToString(dr["Question_Time"]);
                        if (dr["Subject"] != DBNull.Value)
                        {
                            Temp.Subject = Convert.ToString(dr["Subject"]);
                            //if(Temp.Subject.Length>42)
                            //Temp.Subject = Temp.Subject.Substring(43);
                        }
                        if (dr["FILE_STATUS_ID"] != DBNull.Value)
                        {
                            Temp.FileStatusId = Convert.ToInt32(dr["FILE_STATUS_ID"]);
                        }
                        Temp.QuestionText = Convert.ToString(dr["Question_Text"]);
                        if (dr["Urdu_Text"] != DBNull.Value)
                            Temp.UrduText = Convert.ToString(dr["Urdu_Text"]);
                        if (dr["Question_File"] != DBNull.Value)
                            Temp.QuestionFile = Convert.ToString(dr["Question_File"]);

                        Temp.Ministry = Convert.ToString(dr["Ministry"]);
                        Temp.MinistryGroup = Convert.ToString(dr["Ministry_Group"]);
                        Temp.DivisionId = Convert.ToInt32(dr["Division"]);
                        Temp.Division = Convert.ToString(dr["DIVISION_NAME"]);
                        // Temp.DepartmentsId = Convert.ToInt32(dr["Departments_Id"]);
                        // Temp.Department = Convert.ToString(dr["Deptt_Name"]);
                        //Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                        //Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                        if (dr["Notice_Diary_No"] != DBNull.Value)
                            Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                        //Temp.AdmittedNumber = Convert.ToString(dr["Admitted_Number"]);
                        if (dr["Question_Diary_No"] != DBNull.Value)
                            Temp.QuestionDiaryNo = Convert.ToInt32(dr["Question_Diary_No"]);
                        //Temp.QuestionDiaryDate = Convert.ToDateTime(dr["Question_Diary_Date"]);

                        // Temp.QuestionDiaryTime = Convert.ToDateTime(dr["Question_Diary_Time"]);
                        Temp.SessionNumberId = Convert.ToInt32(dr["Session_Number"]);
                        Temp.SessionNumber = Convert.ToString(dr["Session_Name"]);
                        Temp.IsCarryFwd = Convert.ToInt32(dr["Is_Carry_Fwd"]);
                        if (dr["Session_Sittings_Id"] != DBNull.Value)
                            Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
                        if (dr["Updated_By"] != DBNull.Value)
                            Temp.UpdatedBy = Convert.ToInt32(dr["Updated_By"]);
                        if (dr["Updated_on"] != DBNull.Value)
                            Temp.UpdatedOn = Convert.ToDateTime(dr["Updated_on"]);
                        Temp.InsertedBy = Convert.ToInt32(dr["Inserted_By"]);
                        if (dr["Inserted_on"] != DBNull.Value)
                            Temp.InsertedOn = Convert.ToDateTime(dr["Inserted_on"]);
                        if (dr["Deleted_By"] != DBNull.Value)
                            Temp.DeletedBy = Convert.ToInt32(dr["Deleted_By"]);
                        if (dr["deletion_date"] != DBNull.Value)
                            Temp.DeletedOn = Convert.ToDateTime(dr["deletion_date"]);
                        if (dr["Recovered_By"] != DBNull.Value)
                            Temp.RecoveredBy = Convert.ToInt32(dr["Recovered_By"]);
                        if (dr["Recovered_On"] != DBNull.Value)
                            Temp.RecoveredOn = Convert.ToDateTime(dr["Recovered_On"]);
                        if (dr["SENT_FOR_TRANSLATION_BY"] != DBNull.Value)
                            Temp.SentForTranslationBy = Convert.ToInt32(dr["SENT_FOR_TRANSLATION_BY"]);
                        if (dr["SENT_FOR_TRANS_ON"] != DBNull.Value)
                            Temp.SentForTranslationOn = Convert.ToDateTime(dr["SENT_FOR_TRANS_ON"]);
                        if (dr["TRANS_APPROVED_BY"] != DBNull.Value)
                            Temp.TranslationApprovedBy = Convert.ToInt32(dr["TRANS_APPROVED_BY"]);
                        if (dr["TRANS_APPROVED_ON"] != DBNull.Value)
                            Temp.TranslationApprovedOn = Convert.ToDateTime(dr["TRANS_APPROVED_ON"]);
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
        public void SendForTranslation(int QuestionId, int UserId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "TRANSLATE_QUESTION";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.VarChar).Value = QuestionId;
                cmd.Parameters.Add("@SentForTranslationBy", SqlDbType.VarChar).Value = UserId;
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
        public void SetNoticeQuestionRevived(int QuestionId, int ReviveQuestionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "SET_AS_REVIVED_QUESTION";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.VarChar).Value = QuestionId;
                cmd.Parameters.Add("@PreviousId", SqlDbType.VarChar).Value = ReviveQuestionId;
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
        public void SetNoticeQuestionCheckedStatus(int QuestionId, int Status)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_QUESTION_CHECKED_STATUS";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.VarChar).Value = QuestionId;
                cmd.Parameters.Add("@CheckedStatus", SqlDbType.VarChar).Value = Status;
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
        public void ApproveTranslation(int QuestionId, int UserId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "APPROVE_QUESTION_TRANSLATION";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.VarChar).Value = QuestionId;
                cmd.Parameters.Add("@ApprovedBy", SqlDbType.VarChar).Value = UserId;
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
        public List<Questions> GetTranslationQuestions(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_TRANSLATION_QUESTIONS";
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
                        if (dr["FILE_STATUS_ID"] != DBNull.Value)
                        {
                            Temp.FileStatusId = Convert.ToInt32(dr["FILE_STATUS_ID"]);
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

                        if (dr["SENT_FOR_TRANSLATION_BY"] != DBNull.Value)
                            Temp.SentForTranslationBy = Convert.ToInt32(dr["SENT_FOR_TRANSLATION_BY"]);
                        if (dr["SENT_FOR_TRANS_ON"] != DBNull.Value)
                            Temp.SentForTranslationOn = Convert.ToDateTime(dr["SENT_FOR_TRANS_ON"]);
                        if (dr["TRANS_APPROVED_BY"] != DBNull.Value)
                            Temp.TranslationApprovedBy = Convert.ToInt32(dr["TRANS_APPROVED_BY"]);
                        if (dr["TRANS_APPROVED_ON"] != DBNull.Value)
                            Temp.TranslationApprovedOn = Convert.ToDateTime(dr["TRANS_APPROVED_ON"]);
                            Temp.DeviceId= Convert.ToInt32(dr["DEVICE_ID"]);
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
                        if (dr["FILE_STATUS_ID"] != DBNull.Value)
                        {
                            Temp.FileStatusId = Convert.ToInt32(dr["FILE_STATUS_ID"]);
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
                        if (dr["Notice_Diary_Time"] != DBNull.Value)
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
                        if (dr["SENT_FOR_TRANSLATION_BY"] != DBNull.Value)
                            Temp.SentForTranslationBy = Convert.ToInt32(dr["SENT_FOR_TRANSLATION_BY"]);
                        if (dr["SENT_FOR_TRANS_ON"] != DBNull.Value)
                            Temp.SentForTranslationOn = Convert.ToDateTime(dr["SENT_FOR_TRANS_ON"]);
                        if (dr["TRANS_APPROVED_BY"] != DBNull.Value)
                            Temp.TranslationApprovedBy = Convert.ToInt32(dr["TRANS_APPROVED_BY"]);
                        if (dr["TRANS_APPROVED_ON"] != DBNull.Value)
                            Temp.TranslationApprovedOn = Convert.ToDateTime(dr["TRANS_APPROVED_ON"]);
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
        public List<Questions> GetNoticeQuestions(int AssemblySessionsId)
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
                        if (!string.IsNullOrEmpty(Temp.UrduText))
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
                        if (dr["Session_Sittings_Id"] != DBNull.Value)
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
        public List<Questions> GetRevivedQuestions(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_REVIVED_QUESTIONS";
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
                        if (dr["QBR_QUESTIONS_ID"] != DBNull.Value)
                            Temp.QuestionBranchId = Convert.ToInt32(dr["QBR_QUESTIONS_ID"]);
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
                        if (!string.IsNullOrEmpty(Temp.UrduText))
                            Temp.UrduText = Convert.ToString(dr["Urdu_Text"]);
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
                        if (dr["Session_Sittings_Id"] != DBNull.Value)
                            Temp.IsCarryFwd = Convert.ToInt32(dr["Is_Carry_Fwd"]);
                        if (dr["Session_Sittings_Id"] != DBNull.Value)
                            Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
                        if (dr["PREV_QUESTIONS_ID"] != DBNull.Value)
                            Temp.PreviousQuestionsId = Convert.ToInt32(dr["PREV_QUESTIONS_ID"]);
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

        public List<Questions> GetDuplicateQuestions(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_DUPLICATE_QUESTIONS";
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
                        if (dr["QBR_QUESTIONS_ID"] != DBNull.Value)
                            Temp.QuestionBranchId = Convert.ToInt32(dr["QBR_QUESTIONS_ID"]);
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
                        if (!string.IsNullOrEmpty(Temp.UrduText))
                            Temp.UrduText = Convert.ToString(dr["Urdu_Text"]);
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
                        if (dr["Session_Sittings_Id"] != DBNull.Value)
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

        public void DeleteQuestion(int QuestionId, int DeletedBy)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                //Questions question = GetQuestionById(QuestionId);
                //InsertDeletedQuestions(question);
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_QUESTION";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = QuestionId;
                cmd.Parameters.Add("@DeletedBy", SqlDbType.Int).Value = DeletedBy;
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
        public void RecoverQuestion(int QuestionId, int RecoveredBy)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                //Questions question = GetQuestionById(QuestionId);
                //InsertDeletedQuestions(question);
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "RECOVER_QUESTION";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = QuestionId;
                cmd.Parameters.Add("@RecoveredBy", SqlDbType.Int).Value = RecoveredBy;
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
        public void RecoverDuplicateQuestion(int QuestionId, int RecoveredBy)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                //Questions question = GetQuestionById(QuestionId);
                //InsertDeletedQuestions(question);
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "RECOVER_DUPLICATE_QUESTION";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = QuestionId;
                cmd.Parameters.Add("@RecoveredBy", SqlDbType.Int).Value = RecoveredBy;
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

                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
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
                            //if(Temp.Subject.Length>42)
                            //Temp.Subject = Temp.Subject.Substring(43);
                        }
                        Temp.QuestionText = Regex.Replace(Convert.ToString(dr["Question_Text"]), "<.*?>", string.Empty);
                        if (dr["Urdu_Text"] != DBNull.Value)
                            Temp.UrduText = Convert.ToString(dr["Urdu_Text"]);
                        Temp.Ministry = Convert.ToString(dr["Ministry"]);
                        Temp.MinistryGroup = Convert.ToString(dr["Ministry_Group"]);
                        Temp.Division = Convert.ToString(dr["Division"]);
                        // Temp.DepartmentsId = Convert.ToInt32(dr["Departments_Id"]);
                        // Temp.Department = Convert.ToString(dr["Deptt_Name"]);
                        //Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                        //Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                        if (dr["Notice_Diary_No"] != DBNull.Value)
                            Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                        //Temp.AdmittedNumber = Convert.ToString(dr["Admitted_Number"]);
                        if (dr["Question_Diary_No"] != DBNull.Value)
                            Temp.QuestionDiaryNo = Convert.ToInt32(dr["Question_Diary_No"]);
                        //Temp.QuestionDiaryDate = Convert.ToDateTime(dr["Question_Diary_Date"]);

                        // Temp.QuestionDiaryTime = Convert.ToDateTime(dr["Question_Diary_Time"]);
                        Temp.SessionNumberId = Convert.ToInt32(dr["Session_Number"]);
                        if (dr["Session_Sittings_Id"] != DBNull.Value)
                            Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
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
        public void UpdateQuestions(Questions Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_QUESTIONS";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = Temp.QuestionsId;
                cmd.Parameters.Add("@QuestionDiaryNo", SqlDbType.Int).Value = Temp.QuestionDiaryNo;
                cmd.Parameters.Add("@Mover", SqlDbType.Int).Value = Temp.Mover;
                cmd.Parameters.Add("@QuestionCategoryId", SqlDbType.Int).Value = Temp.QuestionCategoriesId;
                cmd.Parameters.Add("@QuestionText", SqlDbType.VarChar).Value = Temp.QuestionText;
                cmd.Parameters.Add("@Subject", SqlDbType.VarChar).Value = Temp.Subject;
                cmd.Parameters.Add("@DivisionId", SqlDbType.Int).Value = Temp.DivisionId;
                cmd.Parameters.Add("@QuestionStatusesId", SqlDbType.Int).Value = Temp.QuestionStatusId;
                if (Temp.QuestionStatusDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@QuestionStatusDate", SqlDbType.Date).Value = Temp.QuestionStatusDate;
                cmd.Parameters.Add("@FileStatusId", SqlDbType.Int).Value = Temp.FileStatusId;
                cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = Temp.Priority;
                cmd.Parameters.Add("@GroupsId", SqlDbType.Int).Value = Temp.MinistryGroupId;
                cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.Int).Value = Temp.NoticeDiaryNo;
                cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.Date).Value = Temp.NoticeDiaryDate;
                cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = Temp.NoticeDiaryTime;
                cmd.Parameters.Add("@QuestionDate", SqlDbType.Date).Value = Temp.QuestionDate;
                cmd.Parameters.Add("@SessionNumber", SqlDbType.Int).Value = Temp.SessionNumberId;
                cmd.Parameters.Add("@Reply", SqlDbType.VarChar).Value = Temp.Reply;
                if (Temp.ReplyDate > Convert.ToDateTime("1/1/1900"))
                    cmd.Parameters.Add("@ReplyDate", SqlDbType.DateTime).Value = Temp.ReplyDate;
                if (!string.IsNullOrEmpty(Temp.QuestionFile))
                    cmd.Parameters.Add("@QuestionFile", SqlDbType.VarChar).Value = Temp.QuestionFile;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = Temp.UpdatedBy;
                cmd.Parameters.Add("@UpdatedOn", SqlDbType.DateTime).Value = Temp.UpdatedOn;

                cmd.CommandType = CommandType.StoredProcedure;
                //InsertUrduText(Temp.UrduText, Temp.QuestionsId);
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

        public void UpdateSORemarks(Questions Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_SO_REMARKS";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = Temp.QuestionsId;
                cmd.Parameters.Add("@SORemarks", SqlDbType.VarChar).Value = Temp.SORemarks;
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
        public int InsertQuestions(Questions Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                int id = GetQuestionPk();
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_QUESTIONS";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = Temp.QuestionsId;
                cmd.Parameters.Add("@QuestionDiaryNo", SqlDbType.Int).Value = Temp.QuestionDiaryNo;
                cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.Int).Value = Temp.NoticeDiaryNo;
                cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.Date).Value = Temp.NoticeDiaryDate;
                cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = Temp.NoticeDiaryTime;
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = Temp.SessionNumberId;
                cmd.Parameters.Add("@QuestionDate", SqlDbType.Date).Value = Temp.QuestionDate;
                cmd.Parameters.Add("@FileStatusId", SqlDbType.Int).Value = Temp.FileStatusId;
                cmd.Parameters.Add("@Mover", SqlDbType.Int).Value = Temp.Mover;
                cmd.Parameters.Add("@QuestionCategoriesId", SqlDbType.Int).Value = Temp.QuestionCategoriesId;
                cmd.Parameters.Add("@QuestionStatusesId", SqlDbType.Int).Value = Temp.QuestionStatusId;
                cmd.Parameters.Add("@QuestionStatusDate", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@MinistryGroupId", SqlDbType.Int).Value = Temp.MinistryGroupId;
                cmd.Parameters.Add("@DivisionId", SqlDbType.Int).Value = Temp.DivisionId;
                cmd.Parameters.Add("@QuestionText", SqlDbType.VarChar).Value = Temp.QuestionText;
                cmd.Parameters.Add("@QuestionFile", SqlDbType.VarChar).Value = Temp.QuestionFile;
                cmd.Parameters.Add("@InsertedBy", SqlDbType.Int).Value = Temp.InsertedBy;
                cmd.Parameters.Add("@InsertedOn", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                UpdateQuestionProcessStatus(Temp.QuestionsId, 1, id);
                InsertUrduText(Temp.UrduText, id);
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
        public int InsertNoticeQuestions(Questions Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                int id = GetQuestionPk();
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_QUESTIONS";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@QuestionDiaryNo", SqlDbType.Int).Value = Temp.QuestionDiaryNo;
                cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.Int).Value = Temp.NoticeDiaryNo;
                cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.Date).Value = Temp.NoticeDiaryDate;
                cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = Temp.NoticeDiaryTime;
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = Temp.SessionNumberId;
                cmd.Parameters.Add("@QuestionDate", SqlDbType.Date).Value = Temp.QuestionDate;
                cmd.Parameters.Add("@Mover", SqlDbType.Int).Value = Temp.Mover;
                cmd.Parameters.Add("@QuestionCategoriesId", SqlDbType.Int).Value = Temp.QuestionCategoriesId;
                cmd.Parameters.Add("@QuestionStatusesId", SqlDbType.Int).Value = Temp.QuestionStatusId;
                cmd.Parameters.Add("@QuestionStatusDate", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@FileStatusId", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@MinistryGroupId", SqlDbType.Int).Value = Temp.MinistryGroupId;
                cmd.Parameters.Add("@DivisionId", SqlDbType.Int).Value = Temp.DivisionId;
                cmd.Parameters.Add("@QuestionText", SqlDbType.VarChar).Value = Temp.QuestionText;
                cmd.Parameters.Add("@QuestionFile", SqlDbType.VarChar).Value = Temp.QuestionFile;
                cmd.Parameters.Add("@InsertedBy", SqlDbType.Int).Value = Temp.InsertedBy;
                cmd.Parameters.Add("@InsertedOn", SqlDbType.DateTime).Value = Temp.InsertedOn;
                cmd.Parameters.Add("@DeviceId", SqlDbType.Int).Value = Temp.InsertedBy;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                UpdateQuestionProcessStatus(Temp.NoticeDiaryNo, 1, id);
                InsertUrduText(Temp.UrduText, id);
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
        public void UpdateQuestionProcessStatus(int QuestionId, int Status, int QuestionBranchId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "SET_PROCESSED_STATUS";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = QuestionId;
                cmd.Parameters.Add("@ProcessedStatus", SqlDbType.Int).Value = Status;
                cmd.Parameters.Add("@BranchAssignedId", SqlDbType.Int).Value = QuestionBranchId;
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
        public void InsertUrduText(string UrduText, int QuestionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                if (!string.IsNullOrEmpty(UrduText))
                {
                    string query = "Update questions set urdu_text=N'" + UrduText + "' where questions_id=" + QuestionId;
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
        public void InsertDeletedQuestions(Questions Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                // int id = GetQuestionPk();
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_DELETED_QUESTIONS";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = Temp.QuestionsId;
                //            cmd.Parameters.Add("@QuestionDiaryNo", SqlDbType.Int).Value = Temp.QuestionDiaryNo;
                //            cmd.Parameters.Add("@ListNo", SqlDbType.Int).Value = Temp.ListId;
                //            cmd.Parameters.Add("@SupNo", SqlDbType.VarChar).Value = Temp.SupNo;
                //            cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.Int).Value = Temp.NoticeDiaryNo;
                //            cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.Date).Value = Temp.NoticeDiaryDate;
                //            cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = Temp.NoticeDiaryTime;
                //            cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = Temp.SessionNumberId;
                //            cmd.Parameters.Add("@QuestionDate", SqlDbType.Date).Value = Temp.QuestionDate;
                //            cmd.Parameters.Add("@Mover", SqlDbType.Int).Value = Temp.Mover;
                //            cmd.Parameters.Add("@QuestionCategoriesId", SqlDbType.Int).Value = Temp.QuestionCategoriesId;
                //            cmd.Parameters.Add("@QuestionStatusesId", SqlDbType.Int).Value = Temp.QuestionStatusId;
                //            cmd.Parameters.Add("@QuestionStatusDate", SqlDbType.DateTime).Value = DateTime.Now;
                //            cmd.Parameters.Add("@MinistryGroupId", SqlDbType.Int).Value = Temp.MinistryGroupId;
                //            cmd.Parameters.Add("@DivisionId", SqlDbType.Int).Value = Temp.DivisionId;
                //            cmd.Parameters.Add("@QuestionText", SqlDbType.VarChar).Value = Temp.QuestionText;
                //if(Temp.SentForTranslationOn>Convert.ToDateTime("1/1/1900"))
                //            cmd.Parameters.Add("@SentForTranslationOn", SqlDbType.DateTime).Value = Temp.SentForTranslationOn;
                //            cmd.Parameters.Add("@TranslatedBy", SqlDbType.Int).Value = Temp.TranslatedBy;
                //            if (Temp.ReturnedFromTranslationOn > Convert.ToDateTime("1/1/1900"))
                //                cmd.Parameters.Add("@ReturnedFromTranslationOn", SqlDbType.DateTime).Value = Temp.ReturnedFromTranslationOn;
                //            cmd.Parameters.Add("@TranslationStatus", SqlDbType.Int).Value = Temp.TranslationStatus;
                //            cmd.Parameters.Add("@IsSentToTranslation", SqlDbType.Int).Value = Temp.IsSentToTranslation;
                //            cmd.Parameters.Add("@QuestionFile", SqlDbType.Int).Value = Temp.QuestionFile;

                //            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
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
        public int CopyQuestion(Questions Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                int id = GetQuestionPk();
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "COPY_QUESTION";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@PrevQuestionId", SqlDbType.Int).Value = Temp.PreviousQuestionsId;
                cmd.Parameters.Add("@QuestionDiaryNo", SqlDbType.Int).Value = Temp.QuestionDiaryNo;
                cmd.Parameters.Add("@FromSession", SqlDbType.Int).Value = Temp.PreviousSessionNumber;
                cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.Int).Value = Temp.NoticeDiaryNo;
                cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.Date).Value = Temp.NoticeDiaryDate;
                cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = Temp.NoticeDiaryTime;
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = Temp.SessionNumberId;
                cmd.Parameters.Add("@QuestionDate", SqlDbType.Date).Value = DateTime.Now;
                cmd.Parameters.Add("@Mover", SqlDbType.Int).Value = Temp.Mover;
                cmd.Parameters.Add("@QuestionCategoriesId", SqlDbType.Int).Value = Temp.QuestionCategoriesId;
                cmd.Parameters.Add("@QuestionStatusesId", SqlDbType.Int).Value = Temp.QuestionStatusId;
                cmd.Parameters.Add("@QuestionStatusDate", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@MinistryGroupId", SqlDbType.Int).Value = Temp.MinistryGroupId;
                cmd.Parameters.Add("@DivisionId", SqlDbType.Int).Value = Temp.DivisionId;
                cmd.Parameters.Add("@QuestionText", SqlDbType.VarChar).Value = Temp.QuestionText;
                cmd.CommandType = CommandType.StoredProcedure;
                InsertUrduText(Temp.UrduText, id);
                cmd.ExecuteNonQuery();
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
                            Temp.ListId = Convert.ToInt32(dr["List_No"]);
                            if (dr["Mover"] != DBNull.Value)
                            {
                                Temp.Mover = Convert.ToInt32(dr["Mover"]);
                                Temp.MoverName = Convert.ToString(dr["F_Name"]);
                            }
                            if (dr["Question_Date"] != DBNull.Value)
                                Temp.QuestionDate = Convert.ToDateTime(dr["Question_Date"]);
                            Temp.QuestionCategory = Convert.ToString(dr["Category"]);
                            Temp.QuestionStatus = Convert.ToString(dr["Question_Status"]);
                            if (dr["Status_Date"] != DBNull.Value)
                                Temp.QuestionStatusDate = Convert.ToDateTime(dr["Status_Date"]);
                            if (dr["Reply_Date"] != DBNull.Value)
                                Temp.QuestionStatusDate = Convert.ToDateTime(dr["Reply_Date"]);
                            if (dr["QUESTION_DIARY_DATE"] != DBNull.Value)
                                Temp.QuestionDiaryDate = Convert.ToDateTime(dr["QUESTION_DIARY_DATE"]);
                            if (dr["Question_Time"] != DBNull.Value)
                                Temp.QuestionTime = Convert.ToString(dr["Question_Time"]);
                            if (dr["Subject"] != DBNull.Value)
                            {
                                Temp.Subject = Convert.ToString(dr["Subject"]);
                                //if(Temp.Subject.Length>42)
                                //Temp.Subject = Temp.Subject.Substring(43);
                            }
                            Temp.QuestionText = Regex.Replace(Convert.ToString(dr["Question_Text"]), @"<[^>]+>|&nbsp;", "").Trim();
                            Temp.QuestionHtmlText = Convert.ToString(dr["Question_Text"]).Replace("<p><br></p>","").Trim();
                            if (!string.IsNullOrEmpty(Temp.UrduText))
                                Temp.UrduText = Convert.ToString(dr["Urdu_Text"]);
                            Temp.Ministry = Convert.ToString(dr["Ministry"]);
                            if (dr["Ministry_Group"] != DBNull.Value)
                                Temp.MinistryGroup = Convert.ToString(dr["Ministry_Group"]);
                            Temp.DivisionId = Convert.ToInt32(dr["Division"]);
                            Temp.Division = Convert.ToString(dr["Division_Name"]);
                            // Temp.DivisionId=
                            // Temp.DepartmentsId = Convert.ToInt32(dr["Departments_Id"]);
                            // Temp.Department = Convert.ToString(dr["Deptt_Name"]);
                            if (dr["Notice_Diary_No"] != DBNull.Value)
                                Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                            //Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                            Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);
                            if (dr["Notice_Diary_Date"] != DBNull.Value)
                                Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                            //Temp.AdmittedNumber = Convert.ToString(dr["Admitted_Number"]);
                            if (dr["Question_Diary_No"] != DBNull.Value)
                                Temp.QuestionDiaryNo = Convert.ToInt32(dr["Question_Diary_No"]);
                            //Temp.QuestionDiaryDate = Convert.ToDateTime(dr["Question_Diary_Date"]);
                            // Temp.QuestionDiaryTime = Convert.ToDateTime(dr["Question_Diary_Time"]);
                            Temp.SessionNumberId = Convert.ToInt32(dr["Session_Number"]);
                            Temp.SessionNumber = Convert.ToString(dr["Session_Name"]);
                            Temp.IsCarryFwd = Convert.ToInt32(dr["Is_Carry_Fwd"]);
                            if (dr["Session_Sittings_Id"] != DBNull.Value)
                                Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
                            if (dr["Deleted_By"] != DBNull.Value)
                                Temp.DeletedBy = Convert.ToInt32(dr["Deleted_By"]);
                            if (dr["Deletion_Date"] != DBNull.Value)
                                Temp.DeletedOn = Convert.ToDateTime(dr["Deletion_Date"]);
                            Temp.DeviceId = Convert.ToInt32(dr["DEVICE_ID"]);

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

        #region Utilities
        public AssemblySessions GetCurrentSession()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
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
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
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
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
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
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
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
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
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


        public void CopySessionGroups(int CurrentSession, int PreviousSession)
        {
            List<Groups> PreviousGroups = GetSessionGroups(PreviousSession, 1);
            foreach (Groups obj in PreviousGroups)
            {
                obj.AssembliesSessionId = CurrentSession;
                InsertGroups(obj);
            }

            List<Groups> CurrentGroups = GetSessionGroups(CurrentSession, 1);
            List<GroupDivisions> gds = GetGroupDivisions(PreviousSession);
            for (int i = 1; i <= 5; i++)
            {
                List<Groups> CurrCorrGps = GetSessionCorrespondingGroups(CurrentSession, i);
                List<GroupDivisions> GDivs = GetDivisionsBySessionGroup(PreviousSession, i);
                foreach (GroupDivisions temp in GDivs)
                {
                    foreach (Groups gps in CurrCorrGps)
                    {
                        GroupDivisions gd = new GroupDivisions();
                        gd.DivisionsId = temp.DivisionsId;
                        gd.GroupsId = gps.GroupsId;
                        InsertGroupDivisions(gd);
                    }
                }

            }


        }
        public List<GroupDivisions> GetDivisionsBySessionGroup(int AssemblySessionId, int CorrespondingGroupId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_DIVISIONS_BY_GROUP_SEQUENCE";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = AssemblySessionId;
                cmd.Parameters.Add("@GroupSequenc", SqlDbType.Int).Value = CorrespondingGroupId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<GroupDivisions> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<GroupDivisions>();
                    while (dr.Read())
                    {
                        GroupDivisions Temp = new GroupDivisions();

                        Temp.GroupDivisionsId = Convert.ToInt32(dr["Group_Divisions_Id"]);
                        Temp.GroupSequence = Convert.ToInt32(dr["GROUP_SEQUENCE"]);
                        Temp.Group = Convert.ToString(dr["GROUPDESC"]);
                        Temp.GroupsId = Convert.ToInt32(dr["Groups_Id"]);
                        Temp.DivisionsId = Convert.ToInt32(dr["Divisions_Id"]);
                        Temp.Division = Convert.ToString(dr["Division"]);
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
        public int GetMemberGroupQuestionsByStatus(int MemberId, int GroupId, int QuestionCategoryId, int StatusId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMB_GROUP_QUESTIONS";
                cmd.Parameters.Add("@Mover", SqlDbType.Int).Value = MemberId;
                cmd.Parameters.Add("@QuestionCategoriesId", SqlDbType.Int).Value = QuestionCategoryId;
                cmd.Parameters.Add("@GroupsId", SqlDbType.Int).Value = GroupId;
                cmd.Parameters.Add("@QuestionStatusesId", SqlDbType.Int).Value = StatusId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                int NoOfQuestions = 0;

                if (dr.HasRows)
                {
                    dr.Read();
                    NoOfQuestions = Convert.ToInt32(dr["MEMBER_QUESTIONS"]);
                }
                return NoOfQuestions;
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
        #region Question_Status_History

        public void InsertQuestionStatusHistory(QuestionStatusHistory Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_QUESTION_STATUS_HIST";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = Temp.QuestionId;
                cmd.Parameters.Add("@QuestionStatusesId", SqlDbType.Int).Value = Temp.QuestionStatusId;
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = Temp.AssemblySessionId;
                cmd.Parameters.Add("@StatusDate", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Temp.Remarks;
                cmd.Parameters.Add("InsertedBy", SqlDbType.Int).Value = Temp.InsertedBy;
                cmd.Parameters.Add("@InsertedOn", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Connection = con;
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
        public void UpdateQuestionStatusHistory(QuestionStatusHistory Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_QUESTION_STATUS_HIST";
                cmd.Parameters.Add("@StatusHistoryId", SqlDbType.Int).Value = Temp.QuestionStatusHistoryId;
                cmd.Parameters.Add("@QuestionStatusesId", SqlDbType.Int).Value = Temp.QuestionStatusId;
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Date).Value = Temp.AssemblySessionId;
                cmd.Parameters.Add("@StatusDate", SqlDbType.DateTime).Value = Temp.StatusDate;
                cmd.Parameters.Add("@Remarks", SqlDbType.Int).Value = Temp.Remarks;
                cmd.Connection = con;
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

        public List<QuestionStatusHistory> GetQuestionStatusHistory(int QuestionIdentifier)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
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
                        Temp.InsertedBy = Convert.ToInt32(dr["INSERTED_BY"]);
                        if (dr["INSERTED_ON"] != DBNull.Value)
                            Temp.InsertedOn = Convert.ToDateTime(dr["INSERTED_ON"]);

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

        #endregion Question_Status_History

        #region Question_Movement_History

        public void InsertQuestionMovementHistory(QuestionMovementHistory Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_QUESTION_MOVEMENT";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = Temp.QuestionId;
                cmd.Parameters.Add("@FromSession", SqlDbType.Int).Value = Temp.FromAssemblySession;
                cmd.Parameters.Add("@ToSession", SqlDbType.Int).Value = Temp.ToAssemblySession;
                cmd.Parameters.Add("@MovementDate", SqlDbType.DateTime).Value = Temp.MovementDate;
                cmd.Parameters.Add("@Remarks", SqlDbType.Int).Value = Temp.Remarks;
                cmd.Connection = con;
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
        public void UpdateQuestionMovementHistory(QuestionMovementHistory Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_QUESTION_STATUS_HIST";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = Temp.QuestionId;
                cmd.Parameters.Add("@FromSession", SqlDbType.Int).Value = Temp.FromAssemblySession;
                cmd.Parameters.Add("@ToSession", SqlDbType.Int).Value = Temp.ToAssemblySession;
                cmd.Parameters.Add("@MovementDate", SqlDbType.DateTime).Value = Temp.MovementDate;
                cmd.Parameters.Add("@Remarks", SqlDbType.Int).Value = Temp.Remarks;
                cmd.Connection = con;
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

        public List<QuestionMovementHistory> GetQuestionMovementHistory(int QuestionIdentifier)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
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
                        if (dr["PREV_QUESTION_ID"] != DBNull.Value)
                            Temp.PreviousQuestionId = Convert.ToInt32(dr["PREV_QUESTION_ID"]);
                        else
                            Temp.PreviousQuestionId = 0;
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


        #endregion Question_Movement_History


        #region ROTA
        public QuestionsRota GetRota(int AssemblySessionsId)
        {


            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ROTA";
                cmd.Parameters.Add("@AsseblySessionId", SqlDbType.Int).Value = AssemblySessionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                QuestionsRota rota = new QuestionsRota();
                if (dr.HasRows)
                {
                    dr.Read();
                    rota.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);
                    rota.StartDate = Convert.ToDateTime(dr["START_DATE"]);
                    rota.EndDate = Convert.ToDateTime(dr["END_DATE"]);
                    rota.StartGroup = Convert.ToInt32(dr["START_GROUP"]);
                    rota.StartGroup = Convert.ToInt32(dr["START_GROUP"]);
                    rota.SkipDays = Convert.ToString(dr["SKIP_DAYS"]);
                    rota.RotaWeekDayId= Convert.ToInt32(dr["ROTA_WEEK_DAY_ID"]);
                    rota.RotaWeekDay= Convert.ToString(dr["ROTA_WEEK_DAY"]);
                    rota.Days = Convert.ToString(dr["DAYS"]);



                }
                return rota;
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
        public void InsertRota(QuestionsRota rota)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_ROTA";
                cmd.Parameters.Add("@AsseblySessionId", SqlDbType.Int).Value = rota.AssemblySessionsId;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = rota.StartDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = rota.EndDate;
                cmd.Parameters.Add("@GroupsId", SqlDbType.Int).Value = rota.StartGroup;
                cmd.Parameters.Add("@SkipDays", SqlDbType.VarChar).Value = rota.SkipDays;
                cmd.Parameters.Add("@RotaWeekDayId", SqlDbType.Int).Value = rota.RotaWeekDayId;


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
        public void UpdateRota(QuestionsRota rota)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_ROTA";
                cmd.Parameters.Add("@QuestionsRotaId", SqlDbType.Int).Value = rota.RotaListId;
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = rota.AssemblySessionsId;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = rota.StartDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = rota.EndDate;
                cmd.Parameters.Add("@GroupsId", SqlDbType.Int).Value = rota.StartGroup;
                cmd.Parameters.Add("@SkipDays", SqlDbType.VarChar).Value = rota.SkipDays;
                cmd.Parameters.Add("@RotaWeekDayId", SqlDbType.Int).Value = rota.RotaWeekDayId;
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
        public RotaWeekDays GetRotaWeekDay(int Id)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ROTA_WEEK_DAYS";
                cmd.Parameters.Add("@RotaWeekDayId", SqlDbType.Int).Value =Id;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                RotaWeekDays rwd = null;
                if (dr.HasRows)
                {
                        rwd = new RotaWeekDays();
                        rwd.RotaWeekDayId = Convert.ToInt32(dr["ROTA_WEEK_DAYS_ID"]);
                        rwd.RotaWeekDay = Convert.ToString(dr["ROTA_WEEK_DAY"]);
                        rwd.Days = Convert.ToString(dr["DAYS"]);
                        rwd.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                }
                return rwd;
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
        public List<RotaWeekDays> GetRotaWeekDays()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ROTA_WEEK_DAYS";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                List<RotaWeekDays> rotaWeekDays = null;
                if (dr.HasRows)
                {
                    rotaWeekDays = new List<RotaWeekDays>();
                    while (dr.Read())
                    {
                        RotaWeekDays rwd = new RotaWeekDays();
                        rwd.RotaWeekDayId = Convert.ToInt32(dr["ROTA_WEEK_DAYS_ID"]);
                        rwd.RotaWeekDay = Convert.ToString(dr["ROTA_WEEK_DAY"]);
                        rwd.Days = Convert.ToString(dr["DAYS"]);
                        rwd.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        rotaWeekDays.Add(rwd);
                    }

                }
                if (rotaWeekDays != null) rotaWeekDays.TrimExcess();
                return rotaWeekDays;
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


        #endregion ROTA

        //public void MoveQuestion(int CurrentSession,Questions Temp)
        //{
        //	SqlConnection con = new DalHelper().GetConnection();
        //	try
        //	{
        //		SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
        //		cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "MOVE_QUESTION";
        //		cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = Temp.QuestionsId;
        //		cmd.Parameters.Add("@Mover", SqlDbType.Int).Value = Temp.Mover;
        //		cmd.Parameters.Add("@QuestionCategoryId", SqlDbType.Int).Value = Temp.QuestionCategoriesId;
        //		cmd.Parameters.Add("@QuestionText", SqlDbType.VarChar).Value = Temp.QuestionText;
        //		cmd.Parameters.Add("@DivisionId", SqlDbType.Int).Value = Temp.DivisionId;
        //		cmd.Parameters.Add("@QuestionStatusesId", SqlDbType.Int).Value = Temp.QuestionStatusId;
        //		cmd.Parameters.Add("@GroupsId", SqlDbType.Int).Value = Temp.MinistryGroupId;
        //		cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.VarChar).Value = Convert.ToString(Temp.NoticeDiaryNo);
        //		if (Temp.NoticeDiaryDate > Convert.ToDateTime("01/01/1900"))
        //			cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.Date).Value = Temp.NoticeDiaryDate;
        //		cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = Temp.NoticeDiaryTime;
        //		cmd.Parameters.Add("@QuestionDiaryNo", SqlDbType.Int).Value = Temp.QuestionDiaryNo;
        //		if (Temp.QuestionStatusDate > Convert.ToDateTime("01/01/1900"))
        //			cmd.Parameters.Add("@QuestionStatusDate", SqlDbType.Date).Value = Temp.QuestionStatusDate;
        //		cmd.Parameters.Add("@SessionNumber", SqlDbType.Int).Value = Temp.SessionNumberId;
        //		cmd.Parameters.Add("@FromSession", SqlDbType.Int).Value = CurrentSession;
        //		cmd.Parameters.Add("@Reply", SqlDbType.VarChar).Value = Temp.Reply;
        //		if (Temp.ReplyDate > Convert.ToDateTime("1/1/1900")) 
        //		cmd.Parameters.Add("@ReplyDate", SqlDbType.DateTime).Value = Temp.ReplyDate;
        //		cmd.CommandType = CommandType.StoredProcedure;
        //		cmd.ExecuteNonQuery();
        //	}
        //	catch (Exception ex)
        //	{
        //		throw ex;
        //	}
        //	finally
        //	{
        //		con.Close();

        //	}
        //}
        public void MoveQuestion(int CurrentSession, Questions Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "MOVE_QUESTION";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = Temp.QuestionsId;
                cmd.Parameters.Add("@Mover", SqlDbType.Int).Value = Temp.Mover;
                cmd.Parameters.Add("@QuestionCategoryId", SqlDbType.Int).Value = Temp.QuestionCategoriesId;
                cmd.Parameters.Add("@QuestionText", SqlDbType.VarChar).Value = Temp.QuestionText;
                cmd.Parameters.Add("@DivisionId", SqlDbType.Int).Value = Temp.DivisionId;
                cmd.Parameters.Add("@QuestionStatusesId", SqlDbType.Int).Value = Temp.QuestionStatusId;
                cmd.Parameters.Add("@GroupsId", SqlDbType.Int).Value = Temp.MinistryGroupId;
                cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.VarChar).Value = Convert.ToString(Temp.NoticeDiaryNo);
                if (Temp.NoticeDiaryDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.Date).Value = Temp.NoticeDiaryDate;
                cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = Temp.NoticeDiaryTime;
                cmd.Parameters.Add("@QuestionDiaryNo", SqlDbType.Int).Value = Temp.QuestionDiaryNo;
                if (Temp.QuestionStatusDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@QuestionStatusDate", SqlDbType.Date).Value = Temp.QuestionStatusDate;
                cmd.Parameters.Add("@SessionNumber", SqlDbType.Int).Value = Temp.SessionNumberId;
                cmd.Parameters.Add("@FromSession", SqlDbType.Int).Value = CurrentSession;
                cmd.Parameters.Add("@Reply", SqlDbType.VarChar).Value = Temp.Reply;
                if (Temp.ReplyDate > Convert.ToDateTime("1/1/1900"))
                    cmd.Parameters.Add("@ReplyDate", SqlDbType.DateTime).Value = Temp.ReplyDate;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = Temp.UpdatedBy;
                if (Temp.UpdatedOn > Convert.ToDateTime("1/1/1900"))
                    cmd.Parameters.Add("@UpdatedOn", SqlDbType.DateTime).Value = Temp.UpdatedOn;
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
        #region DEFER_QUESTION
        public void DeferQuestions(DeferQuestion df)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DEFER_QUESTION";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = df.AssemblySessionId;
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = df.QuestionId;
                cmd.Parameters.Add("@MovementDate", SqlDbType.Date).Value = df.DeferDate;
                cmd.Parameters.Add("@InsertedBy", SqlDbType.Int).Value = df.InsertedBy;
                if (df.InsertedOn > Convert.ToDateTime("1/1/1900"))
                    cmd.Parameters.Add("@InsertedOn", SqlDbType.DateTime).Value = df.InsertedOn;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = df.Remarks;
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
        public List<DeferQuestion> GetQuestionDeferment(int QuestionIdentifier)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
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
                        Temp.InsertedBy = Convert.ToInt32(dr["INSERTED_BY"]);
                        if (dr["INSERTED_ON"] != DBNull.Value)
                            Temp.InsertedOn = Convert.ToDateTime(dr["INSERTED_ON"]);
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
        public int CheckQuestionDeferment(int QuestionId, int AssemblySessionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "CHECK_QUESTION_DEFERMENT";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = QuestionId;
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = AssemblySessionId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    return 1;

                }


                return 0;
            }
            finally
            {
                con.Close();

            }

        }
        public List<ListQuestion> GetDeferedQuestions(int AssemblySessionId, int GroupId, int CategoryId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_DEFERED_QUESTIONS";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = AssemblySessionId;
                cmd.Parameters.Add("@QuestionCategoriesId", SqlDbType.Int).Value = CategoryId;
                cmd.Parameters.Add("@GroupsId", SqlDbType.Int).Value = GroupId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ListQuestion> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ListQuestion>();
                    while (dr.Read())
                    {
                        ListQuestion Temp = new ListQuestion();
                        Temp.QuestionId = Convert.ToInt32(dr["QUESTIONS_ID"]);
                        //Temp.SessionId = Convert.ToInt32(dr["ASSEMBLY_SESSION_ID"]);
                        //Temp.DeferDate = Convert.ToDateTime(dr["DEFER_DATE"]);
                        Temp.SystemUsersId = Convert.ToInt32(dr["MOVER"]);
                        //Temp.CategoryId = Convert.ToInt32(dr["QUESTION_CATEGORY"]);
                        if (dr["LIST_NO"] != DBNull.Value)
                            Temp.ListNo = Convert.ToInt32(dr["LIST_NO"]);
                        Temp.SuplementaryNo = Convert.ToChar(dr["SUP_NO"]);
                        Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["NOTICE_DIARY_TIME"]);
                        Temp.MoverName = Convert.ToString(dr["F_NAME"]);
                        if (dr["Status_Date"] != DBNull.Value)
                            Temp.StatusDate = Convert.ToDateTime(dr["Status_Date"]);
                        //Temp.SessionNumber = Convert.ToInt32(dr["SESSION_NUMBER"]);
                        //Temp.StatusId = Convert.ToInt32(dr["QUESTION_STATUS"]);
                        Temp.QuestionText = Convert.ToString(dr["QUESTION_TEXT"]);
                        //Temp.GroupId = Convert.ToInt32(dr["MINISTRY_GROUP"]);
                        //Temp.DivisionId = Convert.ToInt32(dr["DIVISION"]);
                        //Temp.Category = Convert.ToString(dr["CATEGORY"]);
                        //Temp.Status = Convert.ToString(dr["QUESTIONSTATUS"]);
                        //Temp.CorrespondingGroup = Convert.ToInt32(dr["CORRESPONDING_GROUP"]);
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

        public List<ListQuestion> GetAllDeferedQuestions(int AssemblySessionId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ALL_DEFERED_QUESTIONS";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = AssemblySessionId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ListQuestion> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ListQuestion>();
                    while (dr.Read())
                    {
                        ListQuestion Temp = new ListQuestion();
                        Temp.QuestionId = Convert.ToInt32(dr["QUESTIONS_ID"]);
                        Temp.SessionId = Convert.ToInt32(dr["SESSION_NUMBER"]);
                        Temp.QuestionDiaryNo = Convert.ToInt32(dr["QUESTION_DIARY_NO"]);
                        //Temp.DeferDate = Convert.ToDateTime(dr["DEFER_DATE"]);
                        Temp.SystemUsersId = Convert.ToInt32(dr["MOVER"]);
                        if (dr["LIST_NO"] != DBNull.Value)
                            Temp.ListNo = Convert.ToInt32(dr["LIST_NO"]);
                        Temp.SuplementaryNo = Convert.ToChar(dr["SUP_NO"]);
                        Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["NOTICE_DIARY_TIME"]);
                        Temp.MoverName = Convert.ToString(dr["F_NAME"]);
                        if (dr["Status_Date"] != DBNull.Value)
                            Temp.StatusDate = Convert.ToDateTime(dr["Status_Date"]);
                        Temp.SessionName = Convert.ToString(dr["ASSEMBLY_SESSION"]);
                        Temp.StatusId = Convert.ToInt32(dr["QUESTION_STATUS"]);
                        Temp.QuestionText = Convert.ToString(dr["QUESTION_TEXT"]);
                        Temp.GroupId = Convert.ToInt32(dr["MINISTRY_GROUP"]);
                        Temp.DivisionId = Convert.ToInt32(dr["DIVISION"]);
                        Temp.Division = Convert.ToString(dr["DIVISION_NAME"]);
                        Temp.Category = Convert.ToString(dr["QUESTION_CATEGORY_DESC"]);
                        Temp.Status = Convert.ToString(dr["STATUS"]);
                        Temp.Group = Convert.ToString(dr["GROUP_NAME"]);
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

        public void DeleteDeferedQuestion(int DeferId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_DEFERED_QUEST";
                cmd.Parameters.Add("@DeferId", SqlDbType.Int).Value = DeferId;
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
        public List<ListQuestion> GetListQuestions(int AssemblySessionId, int GroupId, int CategoryId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_LIST_QUESTIONS";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = AssemblySessionId;
                cmd.Parameters.Add("@QuestionCategoriesId", SqlDbType.Int).Value = CategoryId;
                cmd.Parameters.Add("@GroupsId", SqlDbType.Int).Value = GroupId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ListQuestion> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ListQuestion>();
                    while (dr.Read())
                    {

                        ListQuestion Temp = new ListQuestion();
                        Temp.QuestionId = Convert.ToInt32(dr["QUESTIONS_ID"]);
                        // Temp.SessionId = Convert.ToInt32(dr["ASSEMBLY_SESSION_ID"]);
                        Temp.SystemUsersId = Convert.ToInt32(dr["MOVER"]);
                        Temp.CategoryId = Convert.ToInt32(dr["QUESTION_CATEGORY"]);
                        if (dr["LIST_NO"] != DBNull.Value)
                            Temp.ListNo = Convert.ToInt32(dr["LIST_NO"]);
                        Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["NOTICE_DIARY_TIME"]);
                        Temp.MoverName = Convert.ToString(dr["F_NAME"]);
                        Temp.SessionNumber = Convert.ToInt32(dr["SESSION_NUMBER"]);
                        Temp.StatusId = Convert.ToInt32(dr["QUESTION_STATUS"]);
                        Temp.QuestionText = Convert.ToString(dr["QUESTION_TEXT"]);
                        Temp.GroupId = Convert.ToInt32(dr["MINISTRY_GROUP"]);
                        // Temp.DivisionId = Convert.ToInt32(dr["DIVISION"]);
                        Temp.Category = Convert.ToString(dr["CATEGORY"]);
                        Temp.Status = Convert.ToString(dr["QUESTIONSTATUS"]);
                        Temp.SessionName = Convert.ToString(dr["SESSIONNAME"]);
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
        public List<ListQuestion> GetPriorityQuestions(int AssemblySessionId, int GroupId, int CategoryId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PRIORITY_QUESTIONS";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = AssemblySessionId;
                cmd.Parameters.Add("@QuestionCategoriesId", SqlDbType.Int).Value = CategoryId;
                cmd.Parameters.Add("@GroupsId", SqlDbType.Int).Value = GroupId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ListQuestion> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ListQuestion>();
                    while (dr.Read())
                    {

                        ListQuestion Temp = new ListQuestion();
                        Temp.QuestionId = Convert.ToInt32(dr["QUESTIONS_ID"]);
                        // Temp.SessionId = Convert.ToInt32(dr["ASSEMBLY_SESSION_ID"]);
                        Temp.SystemUsersId = Convert.ToInt32(dr["MOVER"]);
                        Temp.CategoryId = Convert.ToInt32(dr["QUESTION_CATEGORY"]);
                        if (dr["LIST_NO"] != DBNull.Value)
                            Temp.ListNo = Convert.ToInt32(dr["LIST_NO"]);
                        Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["NOTICE_DIARY_TIME"]);
                        Temp.MoverName = Convert.ToString(dr["F_NAME"]);
                        Temp.SessionNumber = Convert.ToInt32(dr["SESSION_NUMBER"]);
                        Temp.StatusId = Convert.ToInt32(dr["QUESTION_STATUS"]);
                        Temp.QuestionText = Convert.ToString(dr["QUESTION_TEXT"]);
                        Temp.GroupId = Convert.ToInt32(dr["MINISTRY_GROUP"]);
                        // Temp.DivisionId = Convert.ToInt32(dr["DIVISION"]);
                        Temp.Category = Convert.ToString(dr["CATEGORY"]);
                        Temp.Status = Convert.ToString(dr["QUESTIONSTATUS"]);
                        Temp.SessionName = Convert.ToString(dr["SESSIONNAME"]);
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
        public ListQuestion GetListQuestion(int QuestionId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_LIST_QUESTION";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = QuestionId;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                ListQuestion Temp = null;
                if (dr.HasRows)
                {
                    Temp = new ListQuestion();
                    dr.Read();


                    Temp.QuestionId = Convert.ToInt32(dr["QUESTIONS_ID"]);
                    // Temp.SessionId = Convert.ToInt32(dr["ASSEMBLY_SESSION_ID"]);
                    Temp.SystemUsersId = Convert.ToInt32(dr["MOVER"]);
                    Temp.CategoryId = Convert.ToInt32(dr["QUESTION_CATEGORY"]);
                    if (dr["LIST_NO"] != DBNull.Value)
                        Temp.ListNo = Convert.ToInt32(dr["LIST_NO"]);
                    if (dr["SUP_NO"] != DBNull.Value)
                        Temp.SuplementaryNo = Convert.ToChar(dr["SUP_NO"]);
                    Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                    Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
                    Temp.NoticeDiaryTime = Convert.ToDateTime(dr["NOTICE_DIARY_TIME"]);
                    Temp.MoverName = Convert.ToString(dr["F_NAME"]);
                    Temp.SessionNumber = Convert.ToInt32(dr["SESSION_NUMBER"]);
                    Temp.StatusId = Convert.ToInt32(dr["QUESTION_STATUS"]);
                    Temp.QuestionText = Convert.ToString(dr["QUESTION_TEXT"]);
                    Temp.GroupId = Convert.ToInt32(dr["MINISTRY_GROUP"]);
                    Temp.DivisionId = Convert.ToInt32(dr["DIVISION"]);
                    Temp.Division = Convert.ToString(dr["DIVISION_NAME"]);
                    Temp.Category = Convert.ToString(dr["CATEGORY"]);
                    Temp.Status = Convert.ToString(dr["QUESTIONSTATUS"]);
                    Temp.SessionName = Convert.ToString(dr["SESSIONNAME"]);
                    Temp.DeviceId = Convert.ToInt32(dr["DEVICE_ID"]);


                }

                return Temp;
            }
            finally
            {
                con.Close();

            }

        }
        public void UpdateDeferStatus(int AssemblySessionsId, int QuestionId, int DefStatus)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "SET_DEFERED_STATUS";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = AssemblySessionsId;
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = QuestionId;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = DefStatus;
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

        #endregion QUESTION_DEFER

        #region GROUP_DIARY
        public List<GroupDiary> GetGroupDiary(int GroupId, int CategoryId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_GROUP_DIARY";
                cmd.Parameters.Add("@GroupsId", SqlDbType.Int).Value = GroupId;
                cmd.Parameters.Add("@QuestionCategoriesId", SqlDbType.Int).Value = CategoryId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<GroupDiary> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<GroupDiary>();
                    while (dr.Read())
                    {
                        GroupDiary Temp = new GroupDiary();

                        Temp.QuestionId = Convert.ToInt32(dr["QUESTIONS_ID"]);
                        if (dr["QUESTION_DIARY_NO"] != DBNull.Value)
                            Temp.QuestionDiaryNo = Convert.ToInt32(dr["QUESTION_DIARY_NO"]);
                        Temp.ListNo = Convert.ToInt32(dr["LIST_NO"]);
                        if (dr["SUP_NO"] != DBNull.Value)
                            Temp.SupListNo = Convert.ToString(dr["SUP_NO"]);
                        if (dr["LIST_DATE"] != DBNull.Value)
                            Temp.ListDate = Convert.ToDateTime(dr["LIST_DATE"]);
                        Temp.Mover = Convert.ToString(dr["F_NAME"]);
                        Temp.QuestionStatusId = Convert.ToInt32(dr["QUESTION_STATUS"]);
                        Temp.QuestionStatus = Convert.ToString(dr["QStatus"]);
                        if (dr["STATUS_DATE"] != DBNull.Value)
                            Temp.StatusDate = Convert.ToDateTime(dr["STATUS_DATE"]);
                        Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["NOTICE_DIARY_TIME"]);
                        Temp.DivisionName = Convert.ToString(dr["DIVISIONNAME"]);
                        Temp.QuestionText = Regex.Replace(Convert.ToString(dr["Question_Text"]), "<.*?>", string.Empty);
                        if (dr["REPLY_DATE"] != DBNull.Value)
                            Temp.ReplyDate = Convert.ToDateTime(dr["REPLY_DATE"]);
                        Temp.Remarks = Convert.ToString(dr["REMARKS"]);
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
        #endregion GROUP_DIARY
        #region CARRY FORWARD
        public List<ListQuestion> GetCarryForwardQuestions(int AssemblySessionId, int GroupId, int CategoryId)
        {
            Groups group = GetGroupById(GroupId);
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SESSION_CARRY_FWD_QUESTION";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = AssemblySessionId;
                cmd.Parameters.Add("@QuestionCategoriesId", SqlDbType.Int).Value = CategoryId;
                cmd.Parameters.Add("@GroupSequenc", SqlDbType.Int).Value = group.CorrespondingGroup;

                cmd.CommandType = CommandType.StoredProcedure;
                List<ListQuestion> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ListQuestion>();
                    while (dr.Read())
                    {
                        ListQuestion Temp = new ListQuestion();
                        Temp.QuestionId = Convert.ToInt32(dr["QUESTIONS_ID"]);
                        if (dr["QUESTION_DIARY_NO"] != DBNull.Value)
                            Temp.QuestionDiaryNo = Convert.ToInt32(dr["QUESTION_DIARY_NO"]);
                        //Temp.SessionId = Convert.ToInt32(dr["ASSEMBLY_SESSION_ID"]);
                        //Temp.DeferDate = Convert.ToDateTime(dr["DEFER_DATE"]);
                        Temp.SystemUsersId = Convert.ToInt32(dr["MOVER"]);
                        Temp.CategoryId = Convert.ToInt32(dr["QUESTION_CATEGORY"]);
                        if (dr["LIST_NO"] != DBNull.Value)
                            Temp.ListNo = Convert.ToInt32(dr["LIST_NO"]);
                        Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["NOTICE_DIARY_TIME"]);
                        Temp.MoverName = Convert.ToString(dr["F_NAME"]);
                        Temp.SessionNumber = Convert.ToInt32(dr["SESSION_NUMBER"]);
                        Temp.StatusId = Convert.ToInt32(dr["QUESTION_STATUS"]);
                        Temp.QuestionText = Convert.ToString(dr["QUESTION_TEXT"]);
                        Temp.GroupId = Convert.ToInt32(dr["MINISTRY_GROUP"]);
                        Temp.DivisionId = Convert.ToInt32(dr["DIVISION"]);
                        Temp.Category = Convert.ToString(dr["CATEGORY"]);
                        Temp.Status = Convert.ToString(dr["QUESTIONSTATUS"]);
                        Temp.CorrespondingGroup = Convert.ToInt32(dr["CORRESPONDING_GROUP"]);
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
        public void CaryFwdQuestion(CarryForward df)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                if (GetCarryForwardList(df.QuestionId, df.ToSession) == 0)
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_CARRY_FWD_QUESTION";
                    cmd.Parameters.Add("@FromSession", SqlDbType.Int).Value = df.FromSession;
                    cmd.Parameters.Add("@ToSession", SqlDbType.Int).Value = df.ToSession;
                    cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = df.QuestionId;
                    cmd.Parameters.Add("@MovementDate", SqlDbType.Date).Value = df.CarryFwdDate;
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

        public int GetCarryForwardList(int QuestionId, int ToSession)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CARRY_FWD_LIST";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = QuestionId;
                cmd.Parameters.Add("@SessionNumberId", SqlDbType.Int).Value = ToSession;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ListQuestion> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    return 1;
                }
                else
                    return 0;

            }
            finally
            {
                con.Close();

            }

        }
        #endregion CARRY FORWARD
        #region SWAP QUESTION
        public void SwapQuestion(int firstgroup, int firstquestion, int secondgroup, int secondquestion)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "SWAP_QUESTION";
                cmd.Parameters.Add("@FirstGroup", SqlDbType.Int).Value = firstgroup;
                cmd.Parameters.Add("@FirstQuestion", SqlDbType.Int).Value = firstquestion;
                cmd.Parameters.Add("@SecondGroup", SqlDbType.Int).Value = secondgroup;
                cmd.Parameters.Add("@SecondQuestion", SqlDbType.Int).Value = secondquestion;
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
        #endregion SWAP QUESTION
        public void UpdateListNo(int QuestionId, int ListId, string SupNo, DateTime ListDate)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_LIST";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = QuestionId;
                cmd.Parameters.Add("@ListNo", SqlDbType.Int).Value = ListId;
                cmd.Parameters.Add("@SupNo", SqlDbType.Char).Value = SupNo;
                cmd.Parameters.Add("@ListDate", SqlDbType.Date).Value = ListDate;
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

        #region QUESTIONS LIST
        public void InsertQuestionsList(QuestList df)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_QUESTIONS_LIST";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = df.AssemblySessionsId;
                cmd.Parameters.Add("@QuestionCategoriesId", SqlDbType.Int).Value = df.CategoryId;
                cmd.Parameters.Add("@GroupsId", SqlDbType.Int).Value = df.GroupsId;
                cmd.Parameters.Add("@StartNo", SqlDbType.Int).Value = df.StartNo;
                cmd.Parameters.Add("@LastNumber", SqlDbType.Int).Value = df.LastNumber;
                cmd.Parameters.Add("@ListName", SqlDbType.VarChar).Value = df.ListName;
                cmd.Parameters.Add("@ListDate", SqlDbType.Date).Value = df.ListDate;
                cmd.Parameters.Add("@DefQuestions", SqlDbType.VarChar).Value = df.DefQuestions;
                cmd.Parameters.Add("@Questions", SqlDbType.VarChar).Value = df.Questions;
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
        public List<QuestList> GetQuestionsList(int AssemblySessionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_QUESTIONS_LISTS";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = AssemblySessionId;

                cmd.CommandType = CommandType.StoredProcedure;
                List<QuestList> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<QuestList>();
                    while (dr.Read())
                    {
                        QuestList Temp = new QuestList();
                        Temp.QuestionsListId = Convert.ToInt32(dr["QUESTION_LIST_ID"]);
                        Temp.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSION_ID"]);
                        Temp.GroupsId = Convert.ToInt32(dr["GROUPS_ID"]);
                        Temp.CategoryId = Convert.ToInt32(dr["CATEGORY_ID"]);
                        Temp.Category = Convert.ToString(dr["CATEGORY"]);
                        Temp.StartNo = Convert.ToInt32(dr["START_NUMBER"]);
                        if (dr["LIST_DATE"] != DBNull.Value)
                            Temp.ListDate = Convert.ToDateTime(dr["LIST_DATE"]);
                        if (dr["LAST_NUMBER"] != DBNull.Value)
                            Temp.LastNumber = Convert.ToInt32(dr["LAST_NUMBER"]);
                        Temp.ListName = Convert.ToString(dr["LIST_NAME"]);
                        if (dr["DEF_QUESTIONS"] != DBNull.Value)
                            Temp.DefQuestions = Convert.ToString(dr["DEF_QUESTIONS"]);
                        else
                            Temp.DefQuestions = "0";
                        if (dr["QUESTIONS"] != DBNull.Value)
                            Temp.Questions = Convert.ToString(dr["QUESTIONS"]);
                        else
                            Temp.Questions = "0";
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

        public QuestList GetQuestionList(int QuestionsListId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_QUESTION_LISTS";
                cmd.Parameters.Add("@QuestionsListId", SqlDbType.Int).Value = QuestionsListId;
                QuestList Temp = new QuestList();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp.QuestionsListId = Convert.ToInt32(dr["QUESTION_LIST_ID"]);
                    Temp.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSION_ID"]);
                    Temp.GroupsId = Convert.ToInt32(dr["GROUPS_ID"]);
                    Temp.CategoryId = Convert.ToInt32(dr["CATEGORY_ID"]);
                    Temp.Category = Convert.ToString(dr["CATEGORY"]);
                    Temp.StartNo = Convert.ToInt32(dr["START_NUMBER"]);
                    if (dr["LAST_NUMBER"] != DBNull.Value)
                        Temp.LastNumber = Convert.ToInt32(dr["LAST_NUMBER"]);
                    if (dr["LIST_DATE"] != DBNull.Value)
                        Temp.ListDate = Convert.ToDateTime(dr["LIST_DATE"]);
                    Temp.ListName = Convert.ToString(dr["LIST_NAME"]);
                    Temp.DefQuestions = Convert.ToString(dr["DEF_QUESTIONS"]);
                    Temp.Questions = Convert.ToString(dr["QUESTIONS"]);
                }

                return Temp;
            }
            finally
            {
                con.Close();

            }

        }
        public int GetQuestionListLastNumber(int AssemblySessionId, int CategoryId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_QUESTION_LIST_LAST_NUMBER";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = AssemblySessionId;
                cmd.Parameters.Add("@QuestionCategoriesId", SqlDbType.Int).Value = CategoryId;
                QuestList Temp = new QuestList();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                int LastNumber = 0;
                if (dr.HasRows)
                {
                    dr.Read();
                    if(dr["LAST_NUMBER"]!=DBNull.Value)
                    LastNumber = Convert.ToInt32(dr["LAST_NUMBER"]);
                    
                }

                return LastNumber;
            }
            finally
            {
                con.Close();

            }

        }
        public void DeleteQuestionsList(int QuestionsListId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_QUESTIONS_LIST";
                cmd.Parameters.Add("@QuestionsListId", SqlDbType.Int).Value = QuestionsListId;
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



        #endregion QUESTIONS LIST
        public void ChangeGroups(int first, int second, int third)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "CHANGE_GROUPS";
                cmd.Parameters.Add("@FirstGroup", SqlDbType.Int).Value = first;
                cmd.Parameters.Add("@SecondGroup", SqlDbType.Int).Value = second;
                cmd.Parameters.Add("@ThirdGroup", SqlDbType.Int).Value = third;
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


        public List<QuestionSummary> GetStatusNoOfQuestions(int FromSession, int ToSession)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "STATUS_NO_OF_QUESTIONS";
                cmd.Parameters.Add("@FromSession", SqlDbType.Int).Value = FromSession;
                cmd.Parameters.Add("@ToSession", SqlDbType.Int).Value = ToSession;
                cmd.CommandType = CommandType.StoredProcedure;
                List<QuestionSummary> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<QuestionSummary>();
                    while (dr.Read())
                    {
                        QuestionSummary Temp = new QuestionSummary();
                        //Temp.AssemblySession = Convert.ToInt32(dr["SESSION_NUMBER"]);
                        //Temp.StatusId = Convert.ToInt32(dr["QUESTION_STATUS"]);
                        Temp.Status = Convert.ToString(dr["DESCRIPTION"]);
                        Temp.Questions = Convert.ToInt32(dr["QUESTION_STATUSES_ID"]);
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
        public List<QuestionSummary> GetCoalitionNoOfQuestions(int FromSession, int ToSession)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "COALLITION_NO_OF_QUESTIONS";
                cmd.Parameters.Add("@FromSession", SqlDbType.Int).Value = FromSession;
                cmd.Parameters.Add("@ToSession", SqlDbType.Int).Value = ToSession;
                cmd.CommandType = CommandType.StoredProcedure;
                List<QuestionSummary> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<QuestionSummary>();
                    while (dr.Read())
                    {
                        
                           QuestionSummary Temp = new QuestionSummary();
                        Temp.PoliticalPartyId = Convert.ToInt32(dr["POLITICAL_PARTIES_ID"]);
                        Temp.PoliticalParty = Convert.ToString(dr["POLITICAL_PARTY_DESC"]);
                        Temp.CoalitionId = Convert.ToInt32(dr["COALITIONS_ID"]);
                        Temp.Coalition = Convert.ToString(dr["COALITION_DESC"]);
                        Temp.PoliticalParty = Convert.ToString(dr["POLITICAL_PARTY_DESC"]);
                        Temp.SenateSessionId = Convert.ToInt32(dr["SESSION_NUMBER"]);
                        Temp.SenateSession = Convert.ToInt32(dr["SENATE_SESSION"]);
                        Temp.Status = Convert.ToString(dr["DESCRIPTION"]);
                        Temp.StatusId = Convert.ToInt32(dr["QUESTION_STATUSES_ID"]);
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

        #region UNDER_PROCESS_PENDING
        public List<GroupDiary> GetUnderProcessPending(int GroupId, int CategoryId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_UNDER_PROCESS_PENDING";
                cmd.Parameters.Add("@GroupsId", SqlDbType.Int).Value = GroupId;
                cmd.Parameters.Add("@QuestionCategoriesId", SqlDbType.Int).Value = CategoryId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<GroupDiary> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<GroupDiary>();
                    while (dr.Read())
                    {
                        GroupDiary Temp = new GroupDiary();

                        Temp.QuestionId = Convert.ToInt32(dr["QUESTIONS_ID"]);
                        if (dr["QUESTION_DIARY_NO"] != DBNull.Value)
                            Temp.QuestionDiaryNo = Convert.ToInt32(dr["QUESTION_DIARY_NO"]);
                        Temp.ListNo = Convert.ToInt32(dr["LIST_NO"]);
                        if (dr["LIST_DATE"] != DBNull.Value)
                            Temp.ListDate = Convert.ToDateTime(dr["LIST_DATE"]);
                        Temp.Mover = Convert.ToString(dr["F_NAME"]);
                        Temp.QuestionStatusId = Convert.ToInt32(dr["QUESTION_STATUS"]);
                        Temp.QuestionStatus = Convert.ToString(dr["QStatus"]);
                        Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["NOTICE_DIARY_TIME"]);
                        Temp.DivisionName = Convert.ToString(dr["DIVISIONNAME"]);
                        Temp.QuestionText = Regex.Replace(Convert.ToString(dr["Question_Text"]), "<.*?>", string.Empty);
                        if (dr["REPLY_DATE"] != DBNull.Value)
                            Temp.ReplyDate = Convert.ToDateTime(dr["REPLY_DATE"]);
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
        #endregion UNDER_PROCESS_PENDING
        public void RemoveListNumbers(string query)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
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
        #region Member
        //public List<MemberStatuses> GetMemberStatuses()
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBER_STATUSES";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<MemberStatuses> MyList = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            MyList = new List<MemberStatuses>();
        //            while (dr.Read())
        //            {
        //                MemberStatuses Temp = new MemberStatuses();

        //                Temp.MemberStatusId = Convert.ToInt32(dr["Member_Statuses_Id"]);
        //                Temp.MemberStatus = Convert.ToString(dr["Description"]);
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

        public List<Member> GetMemberMinisterByName(string MemberName)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBERS_MINISTER_BY_NAME";
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



        public List<Member> GetAllMemberByName(string MemberName)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ALL_MEMBERS_BY_NAME";
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
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
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
        public List<NewMemberInfo> GetMemberBasicInfo(string query)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                List<NewMemberInfo> Temp = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        Temp = new List<NewMemberInfo>();
                        while (dr.Read())
                        {
                            NewMemberInfo ad = new NewMemberInfo();
                            ad.MemberId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                            ad.MemberName = Convert.ToString(dr["F_NAME"]);
                            ad.UrduName = Convert.ToString(dr["URDU_NAME"]);
                            ad.MemberTenureId = Convert.ToInt32(dr["ASSEMBLIES_ID"]);
                            ad.MemberTenure = Convert.ToString(dr["TERM"]);
                            ad.PartyId = Convert.ToInt32(dr["POLITICAL_PARTY"]);
                            ad.Party = Convert.ToString(dr["PARTY"]);
                            ad.MemberStatusId = Convert.ToInt32(dr["MEMBER_STATUS_ID"]);
                            ad.MemberStatus = Convert.ToString(dr["MEMBER_STATUS"]);
                            ad.NoOfQuestions = Convert.ToInt32(dr["NOOFQUESTIONS"]);
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
        public List<NewMemberInfo> GetMemberBasicInfo()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBERS_BASIC_INFO";
                cmd.CommandType = CommandType.StoredProcedure;
                List<NewMemberInfo> Temp = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        Temp = new List<NewMemberInfo>();
                        while (dr.Read())
                        {
                            NewMemberInfo ad = new NewMemberInfo();
                            ad.MemberId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                            ad.MemberName = Convert.ToString(dr["F_NAME"]);
                            ad.MemberTenureId = Convert.ToInt32(dr["ASSEMBLIES_ID"]);
                            ad.MemberTenure = Convert.ToString(dr["TERM"]);
                            ad.PartyId = Convert.ToInt32(dr["POLITICAL_PARTY"]);
                            ad.Party = Convert.ToString(dr["PARTY"]);
                            ad.MemberStatusId = Convert.ToInt32(dr["MEMBER_STATUS_ID"]);
                            ad.MemberStatus = Convert.ToString(dr["MEMBER_STATUS"]);
                            ad.NoOfQuestions = Convert.ToInt32(dr["NOOFQUESTIONS"]);
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
        public int INSERT_NEW_MEMBER(NewMemberInfo Md)
        {
            int pk = new DalHelper().GetPk("SYSTEM_USERS", "SYSTEM_USERS_ID");
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_SYSTEM_USERS";
            cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = pk;
            cmd.Parameters.Add("@FName", SqlDbType.VarChar).Value = Md.MemberName;
            cmd.Parameters.Add("@UrduName", SqlDbType.VarChar).Value = Md.UrduName;
            cmd.Parameters.Add("@AssembliesId", SqlDbType.VarChar).Value = Md.MemberTenureId;

            // cmd.Parameters.Add("@NICNumber", SqlDbType.VarChar).Value = Md.NICNumber;
            // cmd.Parameters.Add("@FatherHusbandName", SqlDbType.VarChar).Value = Md.HusbandFatherName;
            // cmd.Parameters.Add("@DOB", SqlDbType.Date).Value = Md.DOB;
            cmd.Parameters.Add("@Gender", SqlDbType.Int).Value = Md.GenderId;
            // cmd.Parameters.Add("@ReligionsId", SqlDbType.Int).Value = Md.ReligionId;
            //  cmd.Parameters.Add("@MaritalStatus", SqlDbType.Int).Value = Md.MaritalStatus;
            cmd.Parameters.Add("@IsEmployee", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Md.MemberStatusId;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteNonQuery();
                InsertUrduName(pk, Md.UrduName);

                return pk;

            }


            finally
            {
                con.Close();
            }

        }

        public void UpdateMemberBasicInfo(NewMemberInfo bi)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MEMBERS_BASIC_INFO";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = bi.MemberId;
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = bi.MemberName;
            cmd.Parameters.Add("@TermId", SqlDbType.Int).Value = bi.MemberTenureId;
            cmd.Parameters.Add("@MemberStatusId", SqlDbType.Int).Value = bi.MemberStatusId;
            cmd.Parameters.Add("@PoliticalPartyId", SqlDbType.Int).Value = bi.PartyId;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = bi.MemberStatusId;
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
        public void InsertUrduName(int SystemUsersId, string UrduName)
        {
            string query = "update System_Users  set URDU_NAME=N'" + UrduName + "' where System_Users_Id=" + SystemUsersId;
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
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
        public void InsertMemberId(NewMemberInfo bi)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_NEW_MEMBER";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = bi.MemberId;
            cmd.Parameters.Add("@TermId", SqlDbType.Int).Value = bi.MemberTenureId;
            cmd.Parameters.Add("@MemberStatusId", SqlDbType.Int).Value = bi.MemberStatusId;
            cmd.Parameters.Add("@PoliticalPartyId", SqlDbType.Int).Value = bi.PartyId;
            cmd.Parameters.Add("@ElectionTypesId", SqlDbType.Int).Value = bi.ElectionTypeId;
            cmd.Parameters.Add("@IsMinister", SqlDbType.Int).Value = bi.IsMinister;
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

        #endregion Member

        #region SUPLEMENTARY_LIST
        public void InsertSupQuestionsList(SuplementaryListEnt df)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_QUESTIONS_SUP_LIST";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = df.AssemblySessionsId;
                cmd.Parameters.Add("@QuestionsListId", SqlDbType.Int).Value = df.QuestionListId;
                cmd.Parameters.Add("@ListName", SqlDbType.VarChar).Value = df.ListName;
                cmd.Parameters.Add("@ListDate", SqlDbType.Date).Value = df.ListDate;
                cmd.Parameters.Add("@Questions", SqlDbType.VarChar).Value = df.Questions;
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
        public List<SuplementaryListEnt> GetQuestionsSupLists(int QuestionListId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SUPLIMENTARY_LISTS";
                cmd.Parameters.Add("@ListNo", SqlDbType.Int).Value = QuestionListId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<SuplementaryListEnt> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<SuplementaryListEnt>();
                    while (dr.Read())
                    {
                        SuplementaryListEnt Temp = new SuplementaryListEnt();
                        Temp.QuestionSupListId = Convert.ToInt32(dr["QUESTION_SUP_LIST_ID"]);
                        Temp.QuestionListId = Convert.ToInt32(dr["QUESTION_LIST_ID"]);
                        // Temp.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSION_ID"]);
                        //  Temp.GroupsId = Convert.ToInt32(dr["GROUPS_ID"]);
                        if (dr["LIST_DATE"] != DBNull.Value)
                            Temp.ListDate = Convert.ToDateTime(dr["LIST_DATE"]);
                        Temp.ListName = Convert.ToString(dr["LIST_NAME"]);
                        if (dr["QUESTIONS"] != DBNull.Value)
                            Temp.Questions = Convert.ToString(dr["QUESTIONS"]);
                        else
                            Temp.Questions = "0";
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
        public SuplementaryListEnt GetQuestionSupList(int SuplQuestionsListId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SUPLIMENTARY_LIST";
                cmd.Parameters.Add("@ListNo", SqlDbType.Int).Value = SuplQuestionsListId;
                SuplementaryListEnt Temp = new SuplementaryListEnt();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp.QuestionSupListId = Convert.ToInt32(dr["QUESTION_SUP_LIST_ID"]);
                    Temp.QuestionListId = Convert.ToInt32(dr["QUESTION_LIST_ID"]);
                    // Temp.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSION_ID"]);
                    //Temp.GroupsId = Convert.ToInt32(dr["GROUPS_ID"]);
                    if (dr["LIST_DATE"] != DBNull.Value)
                        Temp.ListDate = Convert.ToDateTime(dr["LIST_DATE"]);
                    Temp.ListName = Convert.ToString(dr["LIST_NAME"]);
                    if (dr["QUESTIONS"] != DBNull.Value)
                        Temp.Questions = Convert.ToString(dr["QUESTIONS"]);
                    else
                        Temp.Questions = "0";
                }

                return Temp;
            }
            finally
            {
                con.Close();

            }

        }
        public void DeleteQuestionsSupList(int QuestionsListId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_SUPLEMENTARY_LIST";
                cmd.Parameters.Add("@ListNo", SqlDbType.Int).Value = QuestionsListId;
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

        #endregion SUPLEMENTARY_LIST
        public void UpdateQuestionStatus(QuestionStatusHistory questionStatusHistory)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                if (questionStatusHistory.QuestionStatusId == 15 || questionStatusHistory.QuestionStatusId == 2)
                    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_QUESTION_REPLY_STATUS";
                else if (questionStatusHistory.QuestionStatusId == 4)
                    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_QUESTION_DEFERMENT";
                else
                    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_QUESTION_STATUS";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = questionStatusHistory.QuestionId;
                cmd.Parameters.Add("@QuestionStatusesId", SqlDbType.Int).Value = questionStatusHistory.QuestionStatusId;
                cmd.Parameters.Add("@StatusDate", SqlDbType.Date).Value = questionStatusHistory.StatusDate;
                //cmd.Parameters.Add("@FromAssemblySessionId", SqlDbType.Date).Value = FromAssemblySessionId;
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = questionStatusHistory.AssemblySessionId;
                cmd.Parameters.Add("@ReplyDate", SqlDbType.Date).Value = questionStatusHistory.StatusDate;
                cmd.Parameters.Add("@InsertedBy", SqlDbType.Int).Value = questionStatusHistory.InsertedBy;
                cmd.Parameters.Add("@InsertedOn", SqlDbType.DateTime).Value = questionStatusHistory.InsertedOn;
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
        public void InsertQuestionRevivalHistory(RevivalHistory revivalHistory)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_QUESTION_REVIVAL_HISTORY";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = revivalHistory.QuestionsId;
                cmd.Parameters.Add("@FromAssemblySessionsId", SqlDbType.Int).Value = revivalHistory.FromAssemblySessionId;
                cmd.Parameters.Add("@ToAssemblySessionsId", SqlDbType.Int).Value = revivalHistory.ToAssemblySessionId;
                cmd.Parameters.Add("@RevivalDate", SqlDbType.Date).Value = revivalHistory.RevivalDate;
                cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.Int).Value = revivalHistory.NoticeOfficediaryNumber;
                cmd.Parameters.Add("@InsertedBy", SqlDbType.Int).Value = revivalHistory.InsertedBy;
                cmd.Parameters.Add("@InsertedOn", SqlDbType.DateTime).Value = revivalHistory.InsertedOn;

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

        public List<RevivalHistory> GetQuestionRevivalHistory(int QuestionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_QUESTION_REVIVAL_HISTORY";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = QuestionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<RevivalHistory> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<RevivalHistory>();
                    while (dr.Read())
                    {
                        RevivalHistory Temp = new RevivalHistory();
                        Temp.RevivalHistoryId = Convert.ToInt32(dr["QUESTION_REVIVAL_ID"]);
                        Temp.QuestionsId = Convert.ToInt32(dr["QUESTIONS_ID"]);
                        //Temp.FromAssemblySessionId = Convert.ToInt32(dr["SESSION_NUMBER"]);
                        //Temp.ToAssemblySessionId = Convert.ToInt32(dr["QUESTION_STATUS"]);
                        Temp.FromAssemblySession = Convert.ToString(dr["FROM_SESSION"]);
                        Temp.ToAssemblySession = Convert.ToString(dr["TO_SESSION"]);
                        Temp.RevivalDate = Convert.ToDateTime(dr["REVIVAL_DATE"]);
                        Temp.NoticeOfficediaryNumber = Convert.ToInt32(dr["NOTICE_DIARY_NUMBER"]);
                        if (dr["INSERTED_BY"] != DBNull.Value)
                            Temp.InsertedBy = Convert.ToInt32(dr["INSERTED_BY"]);
                        if (dr["INSERTED_ON"] != DBNull.Value)
                            Temp.InsertedOn = Convert.ToDateTime(dr["INSERTED_ON"]);

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

        #region Notice Summary
        public List<NoticeSummaryEnt> GetQuestionNoticeSummary(DateTime FromDate, DateTime ToDate)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_NOTICE_QUESTION_SUMMARY";
                cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = ToDate;
                cmd.CommandType = CommandType.StoredProcedure;
                List<NoticeSummaryEnt> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<NoticeSummaryEnt>();
                    while (dr.Read())
                    {
                        NoticeSummaryEnt Temp = new NoticeSummaryEnt();
                        Temp.NoticeOfficeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                        Temp.NotiiceOfficeDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
                        Temp.NoticeOfficeTime = Convert.ToDateTime(dr["NOTICE_DIARY_TIME"]);
                        Temp.AssemblySession = Convert.ToString(dr["SESSION_DESC"]);
                        //Temp.BranchAssignedId = Convert.ToInt32(dr["FROM_SESSION"]);
                        Temp.BusinessText = Convert.ToString(dr["BUSINESS_TEXT"]);
                        Temp.BusinessFile = Convert.ToString(dr["BUSINESS_FILE"]);
                        Temp.BusinessType = Convert.ToString(dr["BUSINESS_TYPE"]);
                        Temp.Mover = Convert.ToString(dr["MOVER"]);
                        Temp.Checked = Convert.ToInt32(dr["CHECKED"]);
                        Temp.Processed = Convert.ToInt32(dr["PROCESSED"]);
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
        public List<NoticeSummaryEnt> GetMotionNoticeSummary(DateTime FromDate, DateTime ToDate)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_NOTICE_MOTION_SUMMARY";
                cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = ToDate;
                cmd.CommandType = CommandType.StoredProcedure;
                List<NoticeSummaryEnt> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<NoticeSummaryEnt>();
                    while (dr.Read())
                    {
                        NoticeSummaryEnt Temp = new NoticeSummaryEnt();
                        Temp.NoticeOfficeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                        Temp.NotiiceOfficeDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
                        Temp.NoticeOfficeTime = Convert.ToDateTime(dr["NOTICE_DIARY_TIME"]);
                        Temp.AssemblySession = Convert.ToString(dr["SESSION_DESC"]);
                        //Temp.BranchAssignedId = Convert.ToInt32(dr["FROM_SESSION"]);
                        Temp.BusinessText = Convert.ToString(dr["BUSINESS_TEXT"]);
                        Temp.BusinessFile = Convert.ToString(dr["BUSINESS_FILE"]);
                        Temp.BusinessType = Convert.ToString(dr["BUSINESS_TYPE"]);
                        Temp.Mover = Convert.ToString(dr["MOVERS"]);
                        Temp.Checked = Convert.ToInt32(dr["CHECKED"]);
                        Temp.Processed = Convert.ToInt32(dr["PROCESSED"]);
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
        public List<NoticeSummaryEnt> GetResolutionNoticeSummary(DateTime FromDate, DateTime ToDate)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_NOTICE_RESOLUTION_SUMMARY";
                cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = ToDate;
                cmd.CommandType = CommandType.StoredProcedure;
                List<NoticeSummaryEnt> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<NoticeSummaryEnt>();
                    while (dr.Read())
                    {
                        NoticeSummaryEnt Temp = new NoticeSummaryEnt();
                        Temp.NoticeOfficeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                        Temp.NotiiceOfficeDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
                        Temp.NoticeOfficeTime = Convert.ToDateTime(dr["NOTICE_DIARY_TIME"]);
                        Temp.AssemblySession = Convert.ToString(dr["SESSION_DESC"]);
                        //Temp.BranchAssignedId = Convert.ToInt32(dr["FROM_SESSION"]);
                        Temp.BusinessText = Convert.ToString(dr["BUSINESS_TEXT"]);
                        Temp.BusinessFile = Convert.ToString(dr["BUSINESS_FILE"]);
                        Temp.BusinessType = Convert.ToString(dr["BUSINESS_TYPE"]);
                        Temp.Mover = Convert.ToString(dr["MOVERS"]);
                        Temp.Checked = Convert.ToInt32(dr["CHECKED"]);
                        Temp.Processed = Convert.ToInt32(dr["PROCESSED"]);

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
        #region  MOTION_MOVERS

        public List<MotionMoversEnt> GetMotionMovers(int MotionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MOTION_MOVERS";
                cmd.Parameters.Add("@MotionsId", SqlDbType.VarChar).Value = MotionId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<MotionMoversEnt> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MotionMoversEnt>();
                    while (dr.Read())
                    {
                        MotionMoversEnt Temp = new MotionMoversEnt();

                        Temp.MotionMoversId = Convert.ToInt32(dr["MOTION_MOVERS_ID"]);
                        Temp.MotionId = Convert.ToInt32(dr["MOTIONS_ID"]);
                        Temp.MotionMoversId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        Temp.MoverName = Convert.ToString(dr["F_NAME"]);
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
        public MotionMoversEnt GetMotionMover(int MotionId, int MoverId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MOTION_MOVER";
                cmd.Parameters.Add("@MotionsId", SqlDbType.VarChar).Value = MotionId;
                cmd.Parameters.Add("@MotionMoversId", SqlDbType.VarChar).Value = MoverId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                MotionMoversEnt Temp = null;
                if (dr.HasRows)
                {
                    Temp = new MotionMoversEnt();
                    dr.Read();
                    Temp.MotionMoversId = Convert.ToInt32(dr["MOTION_MOVERS_ID"]);
                    Temp.MotionId = Convert.ToInt32(dr["MOTIONS_ID"]);
                    Temp.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                    Temp.MoverName = Convert.ToString(dr["F_NAME"]);
                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion
        public void SetNoticeQuestionDuplicate(int BranchQuestionId, int NoticeQuestionId, int Status, int UserId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "SET_AS_DUPLICATE_QUESTION";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = NoticeQuestionId;
                cmd.Parameters.Add("@ProcessedStatus", SqlDbType.Int).Value = Status;
                cmd.Parameters.Add("@PreviousId", SqlDbType.Int).Value = BranchQuestionId;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = UserId;
                cmd.Parameters.Add("@UpdatedOn", SqlDbType.DateTime).Value = DateTime.Now;

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
        #region File Status History
        public void InsertFileStatusHistory(FileStatusHiostory fileStatusHiostory)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[QUESTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_QUESTION_FILE_STATUS_HISTORY";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = fileStatusHiostory.QuestionsId;
                cmd.Parameters.Add("@FileStatusId", SqlDbType.Int).Value = fileStatusHiostory.FileStatusId;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = fileStatusHiostory.UserId;
                cmd.Parameters.Add("@FileStatusDate", SqlDbType.DateTime).Value = DateTime.Now;
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
        public List<FileStatusHiostory> GetFileStatusHistory(int QuestionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_QUESTION_FILE_STATUS_HISTORY";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.VarChar).Value = QuestionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<FileStatusHiostory> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<FileStatusHiostory>();
                    while (dr.Read())
                    {
                        FileStatusHiostory Temp = new FileStatusHiostory();
                        Temp.QuestionsId = Convert.ToInt32(dr["QUESTIONS_ID"]);
                        Temp.FileStatusHistoryId = Convert.ToInt32(dr["FILE_STATUS_HIST_ID"]);
                        Temp.FileStatusId = Convert.ToInt32(dr["FILE_STATUS_ID"]);
                        Temp.FileStatus = Convert.ToString(dr["FILE_STATUS"]);
                        if (dr["STATUS_DATE"] != DBNull.Value)
                            Temp.StatusHistoryDate = Convert.ToDateTime(dr["STATUS_DATE"]);
                        Temp.UserId = Convert.ToInt32(dr["USER_ID"]);
                        Temp.UserName = Convert.ToString(dr["USER_NAME"]);
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

        #region Group Summary
        public List<GroupSummaryReport> GetQuestionGroupSummary(int SessionNumber, int ToSession)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "QUESTIONS_SUMMARY_REPORT";
                cmd.Parameters.Add("@FromSession", SqlDbType.Int).Value = SessionNumber;
                cmd.Parameters.Add("@ToSession", SqlDbType.Int).Value = ToSession;
                cmd.CommandType = CommandType.StoredProcedure;
                List<GroupSummaryReport> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<GroupSummaryReport>();
                    while (dr.Read())
                    {
                        GroupSummaryReport Temp = new GroupSummaryReport();
                        //	Temp.GroupId = Convert.ToInt32(dr["GROUPS_ID"]);
                        Temp.Group = Convert.ToString(dr["GROUP_NAME"]);
                        Temp.DivisionId = Convert.ToInt32(dr["DIVISIONS_ID"]);
                        Temp.Division = Convert.ToString(dr["DIVISION"]);
                        Temp.Starred = Convert.ToInt32(dr["STARRED"]);
                        Temp.UnStarred = Convert.ToInt32(dr["UNSTARRED"]);
                        Temp.Deferred = Convert.ToInt32(dr["DEFERRED_STARRED"]);
                        Temp.DeferredUnstarred = Convert.ToInt32(dr["DEFERRED_UNSTARRED"]);
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
        public List<GroupMinistryMembersQuestions> GetGroupMinistryMembersQuestions(int SessionNumber, int ToSession)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GROUP_MINISTRY_MEMBER_QUESTIONS";
                cmd.Parameters.Add("@FromSession", SqlDbType.Int).Value = SessionNumber;
                cmd.Parameters.Add("@ToSession", SqlDbType.Int).Value = ToSession;
                cmd.CommandType = CommandType.StoredProcedure;
                List<GroupMinistryMembersQuestions> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<GroupMinistryMembersQuestions>();
                    while (dr.Read())
                    {
                        GroupMinistryMembersQuestions Temp = new GroupMinistryMembersQuestions();
                        //	Temp.GroupId = Convert.ToInt32(dr["GROUPS_ID"]);
                        Temp.Group = Convert.ToString(dr["GROUP_NAME"]);
                        Temp.Ministry = Convert.ToString(dr["DIVISION_NAME"]);
                        Temp.MoverName = Convert.ToString(dr["F_NAME"]);
                        Temp.QuestionId = Convert.ToInt32(dr["QUESTIONS_ID"]);
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

        #region Questions Resolutions Summary
        public List<Rpt_QuestionsResolutionsSummary> GetQuestionsStatusWiseSummary(int StartSession, int EndSession,int CategoryId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[usp_Questions_Status_Report]", con);
                cmd.Parameters.Add("@SESSION_ID", SqlDbType.Int).Value = StartSession;
                cmd.Parameters.Add("@TO_SESSION_ID", SqlDbType.Int).Value = EndSession;
                cmd.Parameters.Add("@CATEGORY_ID", SqlDbType.Int).Value = CategoryId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Rpt_QuestionsResolutionsSummary> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Rpt_QuestionsResolutionsSummary>();
                    while (dr.Read())
                    {
                        Rpt_QuestionsResolutionsSummary Temp = new Rpt_QuestionsResolutionsSummary();
                        Temp.QuestionStatus = Convert.ToString(dr["QUESTIONS_STATUS"]);
                        Temp.TotalQuestions = Convert.ToInt32(dr["TOTAL_QUESTIONS"]);
                        Temp.SortOrder = Convert.ToInt32(dr["SORT_ORDER"]);
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
        public void CarryForwardQuestions(int SessionNumber)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "CARRY_FORWARD_QUESTIONS";
                cmd.Parameters.Add("@SessionNumber", SqlDbType.Int).Value = SessionNumber;
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
        #region Question Documents
        public List<BusinessDocuments> GetBusinessDocuments(int BusinessId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_QUESTION_DOCUMENTS";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = BusinessId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<BusinessDocuments> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<BusinessDocuments>();
                    while (dr.Read())
                    {
                        BusinessDocuments Temp = new BusinessDocuments();
                        Temp.DocumentId = Convert.ToInt32(dr["DOCUMENT_ID"]);
                        Temp.BusinessId = Convert.ToInt32(dr["QUESTION_ID"]);
                        Temp.Description = Convert.ToString(dr["DESCRIPTION"]);
                        Temp.DocumentUrl = Convert.ToString(dr["URL"]);
                        Temp.InsertedById = Convert.ToInt32(dr["INSERTED_BY"]);
                        Temp.InsertedOn = Convert.ToDateTime(dr["INSERTED_ON"]);
                        if (dr["UPDATED_BY"] != DBNull.Value)
                            Temp.UpdatedById = Convert.ToInt32(dr["UPDATED_BY"]);
                        if (dr["UPDATED_ON"] != DBNull.Value)
                            Temp.UpdatedOn = Convert.ToDateTime(dr["UPDATED_ON"]);
                        Temp.IsListed = Convert.ToInt32(dr["IS_LISTED"]);
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
        public void UpdateBusinessDocument(BusinessDocuments Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_QUESTION_DOCUMENT";
                cmd.Parameters.Add("@DocumentId", SqlDbType.Int).Value = Temp.DocumentId;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@Url", SqlDbType.VarChar).Value = Temp.DocumentUrl;
                cmd.Parameters.Add("@IsListed", SqlDbType.Int).Value = Temp.IsListed;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = Temp.UpdatedById;
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
        public void InsertBusinessDocument(BusinessDocuments Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_QUESTION_DOCUMENT";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = Temp.BusinessId;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@Url", SqlDbType.VarChar).Value = Temp.DocumentUrl;
                cmd.Parameters.Add("@IsListed", SqlDbType.Int).Value = Temp.IsListed;
                cmd.Parameters.Add("@InsertedBy", SqlDbType.Int).Value = Temp.InsertedById;
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

