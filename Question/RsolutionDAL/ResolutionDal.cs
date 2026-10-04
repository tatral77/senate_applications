using Entities;
using QuestionDAL;
using ResolutionEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;

namespace RsolutionDAL
{
    public class ResolutionDal
    {

        public int GetPk()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                int pk = 0;
                SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RESOLUTION_PK";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    pk = Convert.ToInt32(dr["RESOLUTIONS_ID"]);

                }

                pk++;
                return pk;
            }
            finally
            {
                con.Close();

            }
        }

        #region  RESOLUTION_STATUS_HISTORY

        public List<ResolutionStatusHistory> GetResolutionStatusHistory(int ResolutionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RESOLUTION_STATUS_HISTORY";
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.VarChar).Value = ResolutionId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ResolutionStatusHistory> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ResolutionStatusHistory>();
                    while (dr.Read())
                    {
                        ResolutionStatusHistory Temp = new ResolutionStatusHistory();

                        Temp.ResolutionStatusHistoryId = Convert.ToInt32(dr["RES_STATUS_HIST_ID"]);
                        Temp.ResolutionId = Convert.ToInt32(dr["RESOLUTION_ID"]);
                        Temp.AssemblySession = Convert.ToString(dr["SESSION_NUMBER"]);
                        Temp.ResolutionStatusId = Convert.ToInt32(dr["RESOLUTION_STATUSES_ID"]);
                        Temp.ResolutionStatus = Convert.ToString(dr["RESOLUTION_STATUS"]);
                        Temp.StatusDate = Convert.ToDateTime(dr["STATUS_DATE"]);
                        if (dr["INSERTED_BY"] != DBNull.Value)
                            Temp.InsertedBy = Convert.ToInt32(dr["INSERTED_BY"]);
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



        public void InsertResolutionStatusHistory(ResolutionStatusHistory Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "CHANGE_RESOLUTION_STATUS";
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = Temp.ResolutionId;
                cmd.Parameters.Add("@ResolutionsStatusesId", SqlDbType.Int).Value = Temp.ResolutionStatusId;
                cmd.Parameters.Add("@SessionNumber", SqlDbType.Int).Value = Temp.AssemblySessionId;
                cmd.Parameters.Add("@StatusDate", SqlDbType.Date).Value = DateTime.Now;
                cmd.Parameters.Add("@InsertedBy", SqlDbType.Int).Value = Temp.InsertedBy;
                cmd.Parameters.Add("@InsertedOn", SqlDbType.Date).Value = DateTime.Now;
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
        #endregion RESOLUTION_STATUS_HISTORY



        #region  RESOLUTION_SUBMITTERS
        public List<ResolutionSubmittersEnt> GetResolutionSubmitters(int ResolutionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RESOLUTION_SUBMITTERS";
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = ResolutionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ResolutionSubmittersEnt> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ResolutionSubmittersEnt>();
                    while (dr.Read())
                    {
                        ResolutionSubmittersEnt Temp = new ResolutionSubmittersEnt();

                        Temp.ResolutionsSubmittersId = Convert.ToInt32(dr["RESOLUTION_SUBMITTERS_ID"]);
                        Temp.ResolutionsId = Convert.ToInt16(dr["RESOLUTIONS_ID"]);
                        Temp.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        Temp.MoverName = Convert.ToString(dr["F_NAME"]);
                        if (dr["RELIGIONS_ID"] != DBNull.Value)
                            Temp.ReligionId = Convert.ToInt32(dr["RELIGIONS_ID"]);
                        Temp.GenderId = Convert.ToInt32(dr["GENDER"]);
                        if (dr["SORT_ORDER"] != DBNull.Value)
                            Temp.SortOrder = Convert.ToInt32(dr["SORT_ORDER"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null)
                {
                    // Chosen order first; rows without an order keep their insertion order at the end.
                    MyList = MyList.OrderBy(m => m.SortOrder > 0 ? m.SortOrder : int.MaxValue)
                                   .ThenBy(m => m.ResolutionsSubmittersId).ToList();
                }
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<ResolutionSubmittersEnt> GetResolutionSubmitters(string movers, int Id)
        {
            movers = movers.Trim(',');
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                string query = "SELECT SYSTEM_USERS_ID,SYSTEM_USERS.F_NAME from SYSTEM_USERS WHERE SYSTEM_USERS_ID in (" + movers + ")";
                SqlCommand cmd = new SqlCommand(query, con);
                List<ResolutionSubmittersEnt> MyList = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        MyList = new List<ResolutionSubmittersEnt>();
                        while (dr.Read())
                        {
                            ResolutionSubmittersEnt Temp = new ResolutionSubmittersEnt();

                            // Temp.MotionMoversId = Convert.ToInt32(dr["MOTION_MOVERS_ID"]);
                            Temp.ResolutionsId = Id;
                            Temp.ResolutionsSubmittersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                            Temp.MoverName = Convert.ToString(dr["F_NAME"]);
                            MyList.Add(Temp);
                        }
                    }

                    if (MyList != null) MyList.TrimExcess();
                    return MyList;
                }
            }
            finally
            {
                con.Close();

            }
        }

        public ResolutionSubmittersEnt GetResolutionSubmitter(int ResolutionsSubmittersId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RESOLUTION_SUBMITTER";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                ResolutionSubmittersEnt Temp = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp.ResolutionsSubmittersId = Convert.ToInt32(dr["RESOLUTION_SUBMITTERS_ID"]);
                    Temp.ResolutionsId = Convert.ToInt16(dr["RESOLUTIONS_ID"]);
                    Temp.SystemUsersId = Convert.ToInt32(dr["SYSTEMUSERS_ID"]);
                }


                return Temp;
            }
            finally
            {
                con.Close();

            }
        }

        public void UpdateResolutionSubmitters(ResolutionSubmittersEnt Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_RESOLUTION_SUBMITTERS";
                cmd.Parameters.Add("@ResolutionSubmittersId", SqlDbType.Int).Value = Temp.ResolutionsSubmittersId;
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = Temp.ResolutionsId;
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = Temp.SystemUsersId;
                cmd.Parameters.Add("@SortOrder", SqlDbType.Int).Value = Temp.SortOrder;
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
        public void InsertResolutionSubmitters(ResolutionSubmittersEnt Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                int sortOrder = Temp.SortOrder;
                if (sortOrder <= 0)
                {
                    // no position given: put the new submitter last
                    SqlCommand next = new SqlCommand("SELECT ISNULL(MAX(SORT_ORDER), 0) + 1 FROM RESOLUTION_SUBMITTERS WHERE RESOLUTIONS_ID = @ResolutionsId", con);
                    next.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = Temp.ResolutionsId;
                    sortOrder = Convert.ToInt32(next.ExecuteScalar());
                }
                SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_RESOLUTION_SUBMITTERS";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = Temp.SystemUsersId;
                cmd.Parameters.Add("@SortOrder", SqlDbType.Int).Value = sortOrder;
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = Temp.ResolutionsId;
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
        public void DeleteResolutionMover(int ResolutionId, int MoverId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_RESOLUTION_SUBMITTER";
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = ResolutionId;
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = MoverId;
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
        #endregion RESOLUTION_SUBMITTERS

        #region  RESOLUTION
        public List<ResolutionEnt> GetSentResolutions(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SENT_RESOLUTIONS";
                cmd.Parameters.Add("@SessionNumber", SqlDbType.VarChar).Value = AssemblySessionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ResolutionEnt> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ResolutionEnt>();
                    while (dr.Read())
                    {
                        ResolutionEnt Temp = new ResolutionEnt();
                        Temp.ResolutionsId = Convert.ToInt32(dr["RESOLUTIONS_ID"]);
                        if (dr["SESSION_NUMBER"] != DBNull.Value)
                        {
                            Temp.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);
                            Temp.SessionNumber = Convert.ToString(dr["SESSION_NUMBER"]);
                        }
                        if (dr["RESOLUTION_DIARY_NO"] != DBNull.Value)
                        {
                            Temp.ResolutionDiaryNo = Convert.ToInt32(dr["RESOLUTION_DIARY_NO"]);
                        }
                        Temp.ResolutionsId = Convert.ToInt32(dr["RESOLUTIONS_ID"]);
                        Temp.ResTypesId = Convert.ToInt32(dr["RES_TYPES_ID"]);
                        Temp.ResType = Convert.ToString(dr["RES_TYPE"]);
                        //Temp.Description = Regex.Replace(Convert.ToString(dr["DESCRIPTION"]), @"<[^>]+>|&nbsp;", "").Trim();
                        Temp.Description = Convert.ToString(dr["DESCRIPTION"]);
                        if (dr["URDU_TEXT"] != DBNull.Value)
                            Temp.UrduText = Convert.ToString(dr["URDU_TEXT"]);
                        if (dr["RESOLUTION_FILE"] != DBNull.Value)
                            Temp.ResolutionFile = Convert.ToString(dr["RESOLUTION_FILE"]);
                        Temp.Description = WebUtility.UrlDecode(Temp.Description);
                        Temp.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);
                        Temp.SessionNumber = Convert.ToString(dr["SESSION_NUMBER"]);
                        if (dr["RESOLUTION_NUMBER"] != DBNull.Value)
                            Temp.ResolutionNumber = Convert.ToInt32(dr["RESOLUTION_NUMBER"]);
                        if (dr["RESOLUTION_STATUS"] != DBNull.Value)
                        {
                            Temp.ResolutionStatusId = Convert.ToInt32(dr["RESOLUTION_STATUS"]);
                            Temp.ResolutionStatus = Convert.ToString(dr["RES_STATUS"]);
                        }
                        if (dr["NOTICE_DIARY_NO"] != DBNull.Value)
                            Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                        if (dr["NOTICE_DIARY_DATE"] != DBNull.Value)
                            Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
                        if (dr["NOTICE_DIARY_TIME"] != DBNull.Value)
                            Temp.NoticeDiaryTime = Convert.ToDateTime(dr["NOTICE_DIARY_TIME"]);
                        if (dr["MOVED_DATE"] != DBNull.Value)
                            Temp.MovedDate = Convert.ToDateTime(dr["MOVED_DATE"]);
                        if (dr["IS_DELETED"] != DBNull.Value)
                            Temp.IsDeleted = Convert.ToInt32(dr["IS_DELETED"]);
                        Temp.DeviceId = Convert.ToInt32(dr["DEVICE_ID"]);

                        //if (dr["PASSED_DATE"] != DBNull.Value)
                        //    Temp.PassedDate = Convert.ToDateTime(dr["PASSED_DATE"]);
                        //if (dr["DISCUSSED_DATE"] != DBNull.Value)
                        //    Temp.DiscussedDate = Convert.ToDateTime(dr["DISCUSSED_DATE"]);
                        // Temp.Submitters = new List<ResolutionSubmittersEnt>();
                        // Temp.Submitters = GetResolutionSubmitters(ResolutionsId);
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
        public List<ResolutionEnt> GetResolutions(int AssemblySessionsId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RESOLUTIONS";
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = AssemblySessionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ResolutionEnt> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ResolutionEnt>();
                    while (dr.Read())
                    {
                        ResolutionEnt Temp = new ResolutionEnt();
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
                        if (dr["CLUBED_RESOLUTIONS"] != DBNull.Value)
                            Temp.ClubedResolutions = Convert.ToString(dr["CLUBED_RESOLUTIONS"]);
                        if (dr["CLUBED_WITH"] != DBNull.Value)
                            Temp.ClubedTo = Convert.ToString(dr["CLUBED_WITH"]);
                        if (dr["IS_DELETED"] != DBNull.Value)
                            Temp.IsDeleted = Convert.ToInt32(dr["IS_DELETED"]);
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
                        if (dr["deleted_On"] != DBNull.Value)
                            Temp.DeletedOn = Convert.ToDateTime(dr["deleted_on"]);
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
                        if (dr["ENG_SUBJECT"] != DBNull.Value)
                            Temp.EngSubject = Convert.ToString(dr["ENG_SUBJECT"]);
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
        public List<ResolutionEnt> GetDeletedResolutions
            (int AssemblySessionsId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_DELETED_RESOLUTIONS";
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = AssemblySessionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ResolutionEnt> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ResolutionEnt>();
                    while (dr.Read())
                    {
                        ResolutionEnt Temp = new ResolutionEnt();
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
                        if (dr["CLUBED_RESOLUTIONS"] != DBNull.Value)
                            Temp.ClubedResolutions = Convert.ToString(dr["CLUBED_RESOLUTIONS"]);
                        if (dr["CLUBED_WITH"] != DBNull.Value)
                            Temp.ClubedTo = Convert.ToString(dr["CLUBED_WITH"]);
                        if (dr["IS_DELETED"] != DBNull.Value)
                            Temp.IsDeleted = Convert.ToInt32(dr["IS_DELETED"]);
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
                        if (dr["Deleted_on"] != DBNull.Value)
                            Temp.DeletedOn = Convert.ToDateTime(dr["Deleted_on"]);
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
                        if (dr["ENG_SUBJECT"] != DBNull.Value)
                            Temp.EngSubject = Convert.ToString(dr["ENG_SUBJECT"]);
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
        public ResolutionEnt GetResolution(int ResolutionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RESOLUTION";
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = ResolutionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                ResolutionEnt Temp = null;
                if (dr.HasRows)
                {
                    Temp = new ResolutionEnt();
                    dr.Read();
                    Temp.ResolutionsId = Convert.ToInt32(dr["RESOLUTIONS_ID"]);
                    if (dr["SESSION_NUMBER"] != DBNull.Value)
                    {
                        Temp.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);
                        Temp.SessionNumber = Convert.ToString(dr["SESSION_NUMBER"]);
                    }
                    Temp.ResolutionDiaryNo = Convert.ToInt32(dr["RESOLUTION_DIARY_NO"]);
                    Temp.ResTypesId = Convert.ToInt32(dr["RES_TYPES_ID"]);
                    Temp.ResType = Convert.ToString(dr["RES_TYPE"]);
                    //Temp.Description = Regex.Replace(Convert.ToString(dr["DESCRIPTION"]), @"<[^>]+>|&nbsp;", "").Trim();
                    Temp.Description = Convert.ToString(dr["DESCRIPTION"]);
                    Temp.Description = WebUtility.UrlDecode(Temp.Description);
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
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["NOTICE_DIARY_TIME"]);
                    if (dr["MOVED_DATE"] != DBNull.Value)
                        Temp.MovedDate = Convert.ToDateTime(dr["MOVED_DATE"]);
                    if (dr["PASSED_DATE"] != DBNull.Value)
                        Temp.PassedDate = Convert.ToDateTime(dr["PASSED_DATE"]);
                    if (dr["DISCUSSED_DATE"] != DBNull.Value)
                        Temp.DiscussedDate = Convert.ToDateTime(dr["DISCUSSED_DATE"]);
                    if (dr["URDU_TEXT"] != DBNull.Value)
                        Temp.UrduText = Convert.ToString(dr["URDU_TEXT"]);
                    if (dr["ENG_SUBJECT"] != DBNull.Value)
                        Temp.EngSubject = Convert.ToString(dr["ENG_SUBJECT"]);
                    if (dr["RESOLUTION_FILE"] != DBNull.Value)
                        Temp.ResolutionFile = Convert.ToString(dr["RESOLUTION_FILE"]);
                    if (dr["CLUBED_RESOLUTIONS"] != DBNull.Value)
                        Temp.ClubedResolutions = Convert.ToString(dr["CLUBED_RESOLUTIONS"]);
                    if (dr["CLUBED_WITH"] != DBNull.Value)
                        Temp.ClubedTo = Convert.ToString(dr["CLUBED_WITH"]);
                    if (dr["IS_DELETED"] != DBNull.Value)
                        Temp.IsDeleted = Convert.ToInt32(dr["IS_DELETED"]);
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
                    if (dr["deleted_on"] != DBNull.Value)
                        Temp.DeletedOn = Convert.ToDateTime(dr["deleted_on"]);
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
                    // Temp.Submitters = new List<ResolutionSubmittersEnt>();
                    Temp.Submitters = GetResolutionSubmitters(ResolutionsId);
                    Temp.ResolutionMinistries = GetResolutionMinistries(ResolutionsId);
                    Temp.ResolutionStatusHistories = new List<ResolutionStatusHistory>();
                    Temp.ResolutionStatusHistories = GetResolutionStatusHistory(Temp.ResolutionsId);
                }


                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public ResolutionEnt GetNoticeResolution(int ResolutionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RESOLUTION";
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = ResolutionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                ResolutionEnt Temp = null;
                if (dr.HasRows)
                {
                    Temp = new ResolutionEnt();
                    dr.Read();
                    Temp.ResolutionsId = Convert.ToInt32(dr["RESOLUTIONS_ID"]);
                    if (dr["SESSION_NUMBER"] != DBNull.Value)
                    {
                        Temp.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);
                        Temp.SessionNumber = Convert.ToString(dr["SESSION_NUMBER"]);
                    }
                    Temp.ResolutionDiaryNo = Convert.ToInt32(dr["RESOLUTION_DIARY_NO"]);
                    Temp.ResTypesId = Convert.ToInt32(dr["RES_TYPES_ID"]);
                    Temp.ResType = Convert.ToString(dr["RES_TYPE"]);
                    //Temp.Description = Regex.Replace(Convert.ToString(dr["DESCRIPTION"]), @"<[^>]+>|&nbsp;", "").Trim();
                    Temp.Description = Convert.ToString(dr["DESCRIPTION"]);
                    Temp.Description = WebUtility.UrlDecode(Temp.Description);
                    Temp.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);
                    Temp.SessionNumber = Convert.ToString(dr["SESSION_NUMBER"]);
                    //   Temp.IsUrdu = Convert.ToInt32(dr["IS_URDU"]);
                    if (dr["RESOLUTION_NUMBER"] != DBNull.Value)
                        Temp.ResolutionNumber = Convert.ToInt32(dr["RESOLUTION_NUMBER"]);
                    if (dr["RESOLUTION_STATUS"] != DBNull.Value)
                        Temp.ResolutionStatusId = Convert.ToInt32(dr["RESOLUTION_STATUS"]);
                    Temp.ResolutionStatus = Convert.ToString(dr["RES_STATUS"]);
                    if (dr["NOTICE_DIARY_NO"] != DBNull.Value)
                        Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                    if (dr["NOTICE_DIARY_DATE"] != DBNull.Value)
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
                    if (dr["NOTICE_DIARY_TIME"] != DBNull.Value)
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["NOTICE_DIARY_TIME"]);
                    if (dr["URDU_TEXT"] != DBNull.Value)
                        Temp.UrduText = Convert.ToString(dr["URDU_TEXT"]);
                    if (dr["RESOLUTION_FILE"] != DBNull.Value)
                        Temp.ResolutionFile = Convert.ToString(dr["RESOLUTION_FILE"]);
                    Temp.DeviceId = Convert.ToInt32(dr["DEVICE_ID"]);
                    //if (dr["RESOLUTION_DIARY_TIME"] != DBNull.Value)
                    //    Temp.NoticeDiaryTime = Convert.ToDateTime(dr["RESOLUTION_DIARY_TIME"]);
                    //if (dr["MOVED_DATE"] != DBNull.Value)
                    //    Temp.MovedDate = Convert.ToDateTime(dr["MOVED_DATE"]);
                    //if (dr["PASSED_DATE"] != DBNull.Value)
                    //    Temp.PassedDate = Convert.ToDateTime(dr["PASSED_DATE"]);
                    //if (dr["DISCUSSED_DATE"] != DBNull.Value)
                    //    Temp.DiscussedDate = Convert.ToDateTime(dr["DISCUSSED_DATE"]);
                    // Temp.Submitters = new List<ResolutionSubmittersEnt>();
                    //Temp.Submitters = GetResolutionSubmitters(ResolutionsId);
                    if (dr["MOVERS"] != DBNull.Value)
                    {
                        Temp.Mover = Convert.ToString(dr["MOVERS"]);
                        Temp.Submitters = new List<ResolutionSubmittersEnt>();
                        Temp.Submitters = GetResolutionSubmitters(Temp.Mover, Temp.ResolutionsId);
                    }
                }


                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public List<ResolutionEnt> DecodeResolution(List<ResolutionEnt> res)
        {

            foreach (ResolutionEnt Temp in res)
            {
                Temp.Description = WebUtility.UrlDecode(Temp.Description);
                UpdateResolution(Temp);

            }
            return res;

        }

        public void UpdateResolution(ResolutionEnt Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_RESOLUTION";
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = Temp.AssemblySessionsId;
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = Temp.ResolutionsId;
                cmd.Parameters.Add("@ResTypesId", SqlDbType.Int).Value = Temp.ResTypesId;
                //cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@ResolutionStatus", SqlDbType.Int).Value = Temp.ResolutionStatusId;
                cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.Int).Value = Temp.NoticeDiaryNo;
                cmd.Parameters.Add("@ResolutionNumber", SqlDbType.Int).Value = Temp.ResolutionNumber;
                if (Temp.NoticeDiaryDate > Convert.ToDateTime("01/01/1950"))
                    cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.DateTime).Value = Temp.NoticeDiaryDate;
                cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = Temp.NoticeDiaryTime;
                cmd.Parameters.Add("@ResolutionDiaryNo", SqlDbType.Int).Value = Temp.ResolutionDiaryNo;
                cmd.Parameters.Add("@IsUrdu", SqlDbType.Int).Value = Temp.IsUrdu;
                if (Temp.DiscussedDate > Convert.ToDateTime("01/01/1950"))
                    cmd.Parameters.Add("@DiscussedDate", SqlDbType.DateTime).Value = Temp.DiscussedDate;
                if (Temp.MovedDate > Convert.ToDateTime("01/01/1950"))
                    cmd.Parameters.Add("@MovedDate", SqlDbType.DateTime).Value = Temp.MovedDate;
                if (Temp.PassedDate > Convert.ToDateTime("01/01/1950"))
                    cmd.Parameters.Add("@PassedDate", SqlDbType.DateTime).Value = Temp.PassedDate;
                if (Temp.IsUrdu == 0)
                    cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@OriginalText", SqlDbType.VarChar).Value = Temp.EngSubject;

                cmd.Parameters.Add("@ClubedTo", SqlDbType.VarChar).Value = Temp.ClubedTo;
                cmd.Parameters.Add("@ClubedResolutions", SqlDbType.VarChar).Value = Temp.ClubedResolutions;

                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = Temp.UpdatedBy;
                cmd.Parameters.Add("@UpdatedOn", SqlDbType.DateTime).Value = DateTime.Now;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                if (Temp.IsUrdu == 1)
                    InsertDescription(Temp.ResolutionsId, Temp.Description);
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
        public void UpdateRevivedResolution(ResolutionEnt Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_REVIVED_RESOLUTION";
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = Temp.AssemblySessionsId;
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = Temp.ResolutionsId;
                cmd.Parameters.Add("@ResTypesId", SqlDbType.Int).Value = Temp.ResTypesId;
                //cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@ResolutionStatus", SqlDbType.Int).Value = Temp.ResolutionStatusId;
                cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.Int).Value = Temp.NoticeDiaryNo;
                cmd.Parameters.Add("@ResolutionNumber", SqlDbType.Int).Value = Temp.ResolutionNumber;
                if (Temp.NoticeDiaryDate > Convert.ToDateTime("01/01/1950"))
                    cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.DateTime).Value = Temp.NoticeDiaryDate;
                cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = Temp.NoticeDiaryTime;
                cmd.Parameters.Add("@ResolutionDiaryNo", SqlDbType.Int).Value = Temp.ResolutionDiaryNo;
                cmd.Parameters.Add("@IsUrdu", SqlDbType.Int).Value = Temp.IsUrdu;
                if (Temp.DiscussedDate > Convert.ToDateTime("01/01/1950"))
                    cmd.Parameters.Add("@DiscussedDate", SqlDbType.DateTime).Value = Temp.DiscussedDate;
                if (Temp.MovedDate > Convert.ToDateTime("01/01/1950"))
                    cmd.Parameters.Add("@MovedDate", SqlDbType.DateTime).Value = Temp.MovedDate;
                if (Temp.PassedDate > Convert.ToDateTime("01/01/1950"))
                    cmd.Parameters.Add("@PassedDate", SqlDbType.DateTime).Value = Temp.PassedDate;
                if (Temp.IsUrdu == 0)
                    cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@OriginalText", SqlDbType.VarChar).Value = Temp.EngSubject;

                cmd.Parameters.Add("@ClubedTo", SqlDbType.VarChar).Value = Temp.ClubedTo;
                cmd.Parameters.Add("@ClubedResolutions", SqlDbType.VarChar).Value = Temp.ClubedResolutions;
                cmd.Parameters.Add("@FileUrl", SqlDbType.VarChar).Value = Temp.ResolutionFile;
               
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = Temp.UpdatedBy;
                cmd.Parameters.Add("@UpdatedOn", SqlDbType.DateTime).Value = DateTime.Now;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                if (Temp.IsUrdu == 1)
                    InsertDescription(Temp.ResolutionsId, Temp.Description);
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
        public void MoveResolution(ResolutionEnt Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "MOVE_RESOLUTION";
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = Temp.AssemblySessionsId;
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = Temp.ResolutionsId;
                cmd.Parameters.Add("@ResTypesId", SqlDbType.Int).Value = Temp.ResTypesId;
                //cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@ResolutionStatus", SqlDbType.Int).Value = Temp.ResolutionStatusId;
                cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.Int).Value = Temp.NoticeDiaryNo;
                cmd.Parameters.Add("@ResolutionNumber", SqlDbType.Int).Value = Temp.ResolutionNumber;
                if (Temp.NoticeDiaryDate > Convert.ToDateTime("01/01/1950"))
                    cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.DateTime).Value = Temp.NoticeDiaryDate;
                cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = Temp.NoticeDiaryTime;
                cmd.Parameters.Add("@ResolutionDiaryNo", SqlDbType.Int).Value = Temp.ResolutionDiaryNo;
                if (Temp.DiscussedDate > Convert.ToDateTime("01/01/1950"))
                    cmd.Parameters.Add("@DiscussedDate", SqlDbType.DateTime).Value = Temp.DiscussedDate;
                if (Temp.MovedDate > Convert.ToDateTime("01/01/1950"))
                    cmd.Parameters.Add("@MovedDate", SqlDbType.DateTime).Value = Temp.MovedDate;
                if (Temp.PassedDate > Convert.ToDateTime("01/01/1950"))
                    cmd.Parameters.Add("@PassedDate", SqlDbType.DateTime).Value = Temp.PassedDate;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
                if (Temp.IsUrdu == 1)
                    InsertDescription(Temp.ResolutionsId, Temp.Description);
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
        public int InsertResolution(ResolutionEnt Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                int pk = GetPk();
                SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_RESOLUTION";
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = pk;
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = Temp.AssemblySessionsId;
                cmd.Parameters.Add("@ResTypesId", SqlDbType.Int).Value = Temp.ResTypesId;
                cmd.Parameters.Add("@ResolutionStatus", SqlDbType.Int).Value = Temp.ResolutionStatusId;
                cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.Int).Value = Temp.NoticeDiaryNo;
                cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.DateTime).Value = Temp.NoticeDiaryDate;
                cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = Temp.NoticeDiaryTime;
                cmd.Parameters.Add("@ResolutionDiaryNo", SqlDbType.Int).Value = Temp.ResolutionDiaryNo;
                cmd.Parameters.Add("@StatusDate", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@IsUrdu", SqlDbType.Int).Value = Temp.IsUrdu;
                //cmd.Parameters.Add("@ResolutionText", SqlDbType.VarChar).Value = Temp.Description;
                //  if (Temp.IsUrdu == 0)
                cmd.Parameters.Add("@OriginalText", SqlDbType.VarChar).Value = Temp.Subject;
                cmd.Parameters.Add("@ResolutionFile", SqlDbType.VarChar).Value = Temp.ResolutionFile;
                cmd.Parameters.Add("@InsertedBy", SqlDbType.Int).Value = Temp.InsertedBy;
                cmd.Parameters.Add("@InsertedOn", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@DeviceId", SqlDbType.Int).Value = Temp.DeviceId;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                //if (Temp.IsUrdu == 1)
                InsertDescription(pk, Temp.UrduText);
                if (Temp.Submitters != null)
                {
                    foreach (ResolutionSubmittersEnt temp in Temp.Submitters)
                    {
                        temp.ResolutionsId = pk;
                        InsertResolutionSubmitters(temp);
                    }
                }
                return pk;
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
        protected void InsertDescription(int ResId, string text)
        {
            string query = "update resolutions set urdu_text=" + "N'" + text + "' where resolutions_id=" + ResId;
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


        public List<ResolutionEnt> SearchResolutions(string query)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                List<ResolutionEnt> emp = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        emp = new List<ResolutionEnt>();
                        while (dr.Read())
                        {
                            ResolutionEnt Temp = new ResolutionEnt();
                            Temp.ResolutionsId = Convert.ToInt32(dr["RESOLUTIONS_ID"]);
                            if (dr["ASSEMBLY_SESSIONS_ID"] != DBNull.Value)
                            {
                                Temp.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);

                                Temp.SessionNumber = Convert.ToString(dr["SESSION_NUMBER"]);
                            }
                            Temp.ResTypesId = Convert.ToInt32(dr["RES_TYPES_ID"]);
                            Temp.Description = Convert.ToString(dr["DESCRIPTION"]);
                            Temp.Description = WebUtility.UrlDecode(Temp.Description);
                            Temp.ResolutionStatusId = Convert.ToInt32(dr["RESOLUTION_STATUS_ID"]);
                            Temp.ResolutionStatus = Convert.ToString(dr["RESOLUTION_STATUS"]);
                            Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                            if (dr["NOTICE_DIARY_DATE"] != DBNull.Value)
                                Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
                            Temp.ResolutionDiaryNo = Convert.ToInt32(dr["RESOLUTION_DIARY_NO"]);
                            if (dr["MOVED_DATE"] != DBNull.Value)
                                Temp.MovedDate = Convert.ToDateTime(dr["MOVED_DATE"]);
                            if (dr["PASSED_DATE"] != DBNull.Value)
                                Temp.PassedDate = Convert.ToDateTime(dr["PASSED_DATE"]);
                            if (dr["DISCUSSED_DATE"] != DBNull.Value)
                                Temp.DiscussedDate = Convert.ToDateTime(dr["DISCUSSED_DATE"]);
                            if (dr["CLUBED_RESOLUTIONS"] != DBNull.Value)
                                Temp.ClubedResolutions = Convert.ToString(dr["CLUBED_RESOLUTIONS"]);
                            if (dr["CLUBED_WITH"] != DBNull.Value)
                                Temp.ClubedTo = Convert.ToString(dr["CLUBED_WITH"]);
                            Temp.DeviceId = Convert.ToInt32(dr["DEVICE_ID"]);
                            Temp.Submitters = GetResolutionSubmitters(1);
                            Temp.Submitters = new List<ResolutionSubmittersEnt>();
                            Temp.Submitters = GetResolutionSubmitters(Temp.ResolutionsId);
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
        public void DeleteResolution(int ResolutionId, int DeletedBy)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_RESOLUTION";
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = ResolutionId;
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
        public void RecoverResolution(int ResolutionId, int UserId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "RECOVER_RESOLUTION";
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = ResolutionId;
                cmd.Parameters.Add("@RecoveredBy", SqlDbType.Int).Value = UserId;
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
        public void ChangeNoticeResolutionStatus(int noticeid, int status)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "SET_RESOLUTION_PROCESSED_STATUS";
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = noticeid;
                cmd.Parameters.Add("@ProcessedStatus", SqlDbType.Int).Value = status;
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
        #endregion RESOLUTION
        public List<ResolutionEnt> GetAdmittedResolutions(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Resolution_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ADMITTED_ResolutionS";
                cmd.Parameters.Add("@SessionNumber", SqlDbType.VarChar).Value = AssemblySessionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ResolutionEnt> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ResolutionEnt>();
                    while (dr.Read())
                    {
                        ResolutionEnt Temp = new ResolutionEnt();
                        Temp.ResolutionsId = Convert.ToInt32(dr["ResolutionS_ID"]);
                        Temp.ResolutionDiaryNo = Convert.ToInt32(dr["Resolution_DIARY_NO"]);
                        Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                        if (dr["NOTICE_DIARY_DATE"] != DBNull.Value)
                            Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
                        if (dr["NOTICE_DIARY_TIME"] != DBNull.Value)
                            Temp.NoticeDiaryTime = Convert.ToDateTime(dr["NOTICE_DIARY_TIME"]);
                        Temp.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);
                        Temp.SessionNumber = Convert.ToString(dr["SESSION_DESC"]);
                        Temp.ResolutionStatusId = Convert.ToInt32(dr["Resolution_STATUS_ID"]);
                        Temp.ResolutionStatus = Convert.ToString(dr["Resolution_STATUS"]);
                        Temp.ResTypesId = Convert.ToInt32(dr["Resolution_TYPE_ID"]);
                        Temp.ResType = Convert.ToString(dr["Resolution_TYPE"]);
                        Temp.DeviceId = Convert.ToInt32(dr["Device_Id"]);
                        //Temp.Description = Regex.Replace(Convert.ToString(dr["Resolution_TEXT"]), @"<[^>]+>|&nbsp;", "").Trim();
                        Temp.Description = Convert.ToString(dr["Resolution_TEXT"]);
                        //Temp.Movers = new List<ResolutionSubmittersEnt>();
                        //Temp.Movers = GetResolutionMovers(Temp.ResolutionsId);
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
        public List<ResolutionListEnt> GetResolutionList(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Resolution_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_Resolution_LIST";
                cmd.Parameters.Add("@SessionNumber", SqlDbType.VarChar).Value = AssemblySessionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ResolutionListEnt> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ResolutionListEnt>();
                    while (dr.Read())
                    {
                        ResolutionListEnt Temp = new ResolutionListEnt();

                        Temp.ResolutionsListId = Convert.ToInt32(dr["Resolution_LIST_ID"]);
                        Temp.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);
                        Temp.ListName = Convert.ToString(dr["LIST_NAME"]);
                        Temp.ListDate = Convert.ToDateTime(dr["LIST_DATE"]);
                        Temp.Resolutions = Convert.ToString(dr["ResolutionS"]);
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
        public void InsertResolutionList(ResolutionListEnt Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Resolution_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_RESOLUTION_LIST";
                cmd.Parameters.Add("@ListName", SqlDbType.VarChar).Value = Temp.ListName;
                cmd.Parameters.Add("@SessionNumber", SqlDbType.Int).Value = Temp.AssemblySessionsId;
                cmd.Parameters.Add("@ListDate", SqlDbType.DateTime).Value = Temp.ListDate;
                cmd.Parameters.Add("@Resolutions", SqlDbType.VarChar).Value = Temp.Resolutions;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteReader();
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
        public void DeleteResolutionList(int ResolutionListId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Resolution_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_Resolution_LIST";
                cmd.Parameters.Add("@ResolutionListId", SqlDbType.Int).Value = ResolutionListId;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteReader();
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
        public ResolutionListEnt GetResolutionListById(int ResolutionListId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Resolution_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_Resolution_LIST_BY_ID";
                cmd.Parameters.Add("@ResolutionListId", SqlDbType.VarChar).Value = ResolutionListId;
                cmd.CommandType = CommandType.StoredProcedure;
                ResolutionListEnt Temp = new ResolutionListEnt();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = new ResolutionListEnt();
                    Temp.ResolutionsListId = Convert.ToInt32(dr["Resolution_LIST_ID"]);
                    Temp.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);
                    Temp.ListName = Convert.ToString(dr["LIST_NAME"]);
                    Temp.ListDate = Convert.ToDateTime(dr["LIST_DATE"]);
                    Temp.Resolutions = Convert.ToString(dr["RESOLUTIONS"]);
                }

                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public void UpdateResolutionListNo(int ResolutionsId, int ListNo, DateTime ListDate)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Resolution_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_Resolution_LIST_NO";
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = ResolutionsId;
                cmd.Parameters.Add("@ListNo", SqlDbType.Int).Value = ListNo;
                cmd.Parameters.Add("@ListDate", SqlDbType.Date).Value = ListDate;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteReader();
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
        public List<ResolutionSummaryEnt> GetStatusNoOfResolutions(int FromSession, int ToSession)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[Resolution_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "STATUS_NO_OF_RESOLUTIONS";
                cmd.Parameters.Add("@FromSession", SqlDbType.Int).Value = FromSession;
                cmd.Parameters.Add("@ToSession", SqlDbType.Int).Value = ToSession;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ResolutionSummaryEnt> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ResolutionSummaryEnt>();
                    while (dr.Read())
                    {
                        ResolutionSummaryEnt Temp = new ResolutionSummaryEnt();
                        Temp.AssemblySession = Convert.ToInt32(dr["SESSION_NUMBER"]);
                        Temp.StatusId = Convert.ToInt32(dr["RESOLUTION_STATUSES_ID"]);
                        Temp.Status = Convert.ToString(dr["DESCRIPTION"]);
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
        public void UpdateResolutionStatus(ResolutionStatusHistory resolutionStatusHistory)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Resolution_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "CHANGE_RESOLUTION_STATUS";
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = resolutionStatusHistory.ResolutionId;
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = resolutionStatusHistory.AssemblySessionId;
                cmd.Parameters.Add("@ResolutionsStatusesId", SqlDbType.Int).Value = resolutionStatusHistory.ResolutionStatusId;
                cmd.Parameters.Add("@StatusDate", SqlDbType.Date).Value = resolutionStatusHistory.StatusDate;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = resolutionStatusHistory.InsertedBy;

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

        public void SetNoticeResolutionRevived(int ResolutionId, int PreviousResolutionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "SET_AS_REVIVED_RESOLUTION";
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.VarChar).Value = ResolutionId;
                cmd.Parameters.Add("@PreviousId", SqlDbType.VarChar).Value = PreviousResolutionId;
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

        public void InsertResolutionRevivalHistory(ResolutionRevivalHistory revivalHistory)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Resolution_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_RESOLUTION_REVIVAL_HISTORY";
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = revivalHistory.ResolutionId;
                cmd.Parameters.Add("@FromAssemblySessionsId", SqlDbType.Int).Value = revivalHistory.FromAssemblySessionId;
                cmd.Parameters.Add("@ToAssemblySessionsId", SqlDbType.Int).Value = revivalHistory.ToAssemblySessionId;
                cmd.Parameters.Add("@RevivalDate", SqlDbType.Date).Value = revivalHistory.RevivalDate;
                cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.Int).Value = revivalHistory.NoticeOfficediaryNumber;
                cmd.Parameters.Add("@InsertedBy", SqlDbType.Int).Value = revivalHistory.InsertedBy;
                cmd.Parameters.Add("@InsertedOn", SqlDbType.DateTime).Value = revivalHistory.InsertedOn;
                cmd.Parameters.Add("@FileUrl", SqlDbType.VarChar).Value = revivalHistory.PreviousFile;

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

        public List<ResolutionRevivalHistory> GetResolutionRevivalHistory(int QuestionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_QUESTION_REVIVAL_HISTORY";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = QuestionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ResolutionRevivalHistory> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ResolutionRevivalHistory>();
                    while (dr.Read())
                    {
                        ResolutionRevivalHistory Temp = new ResolutionRevivalHistory();
                        Temp.RevivalHistoryId = Convert.ToInt32(dr["RESOLUTION_REVIVAL_ID"]);
                        Temp.ResolutionId = Convert.ToInt32(dr["RESOLUTIONS_ID"]);
                        //Temp.FromAssemblySessionId = Convert.ToInt32(dr["SESSION_NUMBER"]);
                        //Temp.ToAssemblySessionId = Convert.ToInt32(dr["QUESTION_STATUS"]);
                        Temp.FromAssemblySession = Convert.ToString(dr["FROM_ASSEBLY_SESSONS_ID"]);
                        Temp.ToAssemblySession = Convert.ToString(dr["TO_ASSEMBLE_SESSONS_ID"]);
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
        public void SetNoticeResolutionDuplicate(int BranchResolutionId, int NoticeResolutionId, int Status, int UserId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "SET_AS_DUPLICATE_RESOLUTION";
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = NoticeResolutionId;
                cmd.Parameters.Add("@ProcessedStatus", SqlDbType.Int).Value = Status;
                cmd.Parameters.Add("@PreviousId", SqlDbType.Int).Value = BranchResolutionId;
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

        #region Resolution Ministries
        public string GetMinistryNameById(int MinistryId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_DIVISION_BY_ID";
                cmd.Parameters.Add("@MinistriesId", SqlDbType.Int).Value = MinistryId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                string MinistryName = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    MinistryName = Convert.ToString(dr["DESCRIPTION"]);

                }
                return MinistryName;
            }
            finally
            {
                con.Close();

            }
        }
        public List<ResolutionMinistries> GetResolutionMinistries(int ResolutionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Resolution_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RESOLUTION_MINISTRIES";
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = ResolutionId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ResolutionMinistries> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ResolutionMinistries>();
                    while (dr.Read())
                    {
                        ResolutionMinistries Temp = new ResolutionMinistries();

                        Temp.ResolutionMinistriesId = Convert.ToInt32(dr["RES_MINISTRIES_ID"]);
                        Temp.ResolutionId = Convert.ToInt32(dr["RESOLUTIONS_ID"]);
                        Temp.MinistryId = Convert.ToInt32(dr["MINISTRIES_ID"]);
                        Temp.MinistryName = Convert.ToString(dr["DESCRIPTION"]);
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
        public void InsertResolutionMinistries(ResolutionMinistries Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Resolution_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_RESOLUTION_MINISTRY";
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = Temp.ResolutionId;
                cmd.Parameters.Add("@MinistriesId",  SqlDbType.Int).Value = Temp.MinistryId;
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

        public void DeleteResolutionMinistry(int ResolutionId, int MinistryId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Resolution_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_RESOLUTION_MINISTRY";
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = ResolutionId;
                cmd.Parameters.Add("@MinistriesId", SqlDbType.Int).Value = MinistryId;
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

        #region TRANSLATION
        public void SendForTranslation(int ResolutionId, int UserId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "TRANSLATE_RESOLUTION";
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = ResolutionId;
                cmd.Parameters.Add("@SentForTranslationBy", SqlDbType.Int).Value = UserId;

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

        public void ApproveTranslation(int ResolutionId, int UserId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "APPROVE_RESOLUTION_TRANSLATION";
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = ResolutionId;
                cmd.Parameters.Add("@ApprovedBy", SqlDbType.Int).Value = UserId;
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
        public List<ResolutionEnt> GetTranslationResolutions(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_TRANSLATION_RESOLUTIONS";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.VarChar).Value = AssemblySessionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                List<ResolutionEnt> MyList = null;
                if (dr.HasRows)
                {
                    MyList = new List<ResolutionEnt>();
                    while (dr.Read())
                    {
                        ResolutionEnt Temp = new ResolutionEnt();
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

        public List<ResolutionEnt> GetTranslatedResolutions(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_TRANSLATED_RESOLUTIONS";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.VarChar).Value = AssemblySessionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                List<ResolutionEnt> MyList = null;
                if (dr.HasRows)
                {
                    MyList = new List<ResolutionEnt>();
                    while (dr.Read())
                    {
                        ResolutionEnt Temp = new ResolutionEnt();
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
        public List<Rpt_QuestionsResolutionsSummary> GetResolutionStatusWiseSummary(int StartSession, int EndSession)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[usp_ResolutionStatusSummary]", con);
                cmd.Parameters.Add("@SESSION_ID", SqlDbType.Int).Value = StartSession;
                cmd.Parameters.Add("@TO_SESSION_ID", SqlDbType.Int).Value = EndSession;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Rpt_QuestionsResolutionsSummary> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Rpt_QuestionsResolutionsSummary>();
                    while (dr.Read())
                    {
                        Rpt_QuestionsResolutionsSummary Temp = new Rpt_QuestionsResolutionsSummary();
                        Temp.QuestionStatus = Convert.ToString(dr["RESOLUTION_STATUS"]);
                        Temp.TotalQuestions = Convert.ToInt32(dr["TOTAL_RESOLUTIONS"]);
                        Temp.SortOrder = Convert.ToInt32(dr["SORTORDER"]);
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
        public void CarryForwardResolutions(int SessionNumber)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Resolution_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "CARRY_FORWARD_RESOLUTIONS";
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
    }
}
