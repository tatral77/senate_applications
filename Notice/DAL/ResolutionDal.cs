using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using DAL;

namespace DAL
{
    public class ResolutionDal
    {

        public int GetPk(string Table, string Field)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                int pk = 0;
                string query = "SELECT MAX(" + Field + ") AS ID FROM " + Table;
                SqlCommand cmd = new SqlCommand(query, con);
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr["ID"] != DBNull.Value)
                    {

                        pk = Convert.ToInt32(dr["ID"]);
                    }

                }
                return ++pk;
            }
            finally
            {
                con.Close();

            }
        }

        //#region  RESOLUTION_STATUS_HISTORY

        //public List<ResolutionStatusHistoryEnt> GetResolutionStatusHistories()
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RESOLUTION_STATUS_HISTORIES";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<ResolutionStatusHistoryEnt> MyList = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            MyList = new List<ResolutionStatusHistoryEnt>();
        //            while (dr.Read())
        //            {
        //                ResolutionStatusHistoryEnt Temp = new ResolutionStatusHistoryEnt();

        //                Temp.ResolutionStatusHistoryId = Convert.ToInt32(dr["RES_STATUS_HIST_ID"]);
        //                Temp.ResolutionsId = Convert.ToInt32(dr["RESOLUTIONS_ID"]);
        //                Temp.ResolutionsStatusesId = Convert.ToInt32(dr["RESOLUTION_STATUSES_ID"]);
        //                Temp.StatusDate = Convert.ToDateTime(dr["STATUS_DATE"]);
        //                Temp.UpdatedBy = Convert.ToString(dr["UPDATED_BY"]);
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

        //public ResolutionStatusHistoryEnt GetResolutionStatusHistory(int ResolutionStatusHistoryId)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RESOLUTION_STATUS_HISTORY";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        ResolutionStatusHistoryEnt Temp = null;
        //        if (dr.HasRows)
        //        {
        //            dr.Read();

        //            Temp.ResolutionStatusHistoryId = Convert.ToInt32(dr["RES_STATUS_HIST_ID"]);
        //            Temp.ResolutionsId = Convert.ToInt32(dr["RESOLUTIONS_ID"]);
        //            Temp.ResolutionsStatusesId = Convert.ToInt32(dr["RESOLUTION_STATUSES_ID"]);
        //            Temp.StatusDate = Convert.ToDateTime(dr["STATUS_DATE"]);
        //            Temp.UpdatedBy = Convert.ToString(dr["UPDATED_BY"]);
        //        }


        //        return Temp;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}

        //public void UpdateResolutionStatusHistory(ResolutionStatusHistoryEnt Temp)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MOTION_MOVER";
        //        cmd.Parameters.Add("@ResolutionStatusHistoryId", SqlDbType.Int).Value = Temp.ResolutionStatusHistoryId;
        //        cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = Temp.ResolutionsId;
        //        cmd.Parameters.Add("@ResolutionsStatusesId", SqlDbType.Int).Value = Temp.ResolutionsStatusesId;
        //        cmd.Parameters.Add("@StatusDate", SqlDbType.Date).Value = Temp.StatusDate;
        //        cmd.Parameters.Add("@UpdatedBy", SqlDbType.VarChar).Value = Temp.UpdatedBy;
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
        //public void InsertResolutionStatusHistory(ResolutionStatusHistoryEnt Temp)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MOTION_MOVER";
        //        cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = Temp.ResolutionsId;
        //        cmd.Parameters.Add("@ResolutionsStatusesId", SqlDbType.Int).Value = Temp.ResolutionsStatusesId;
        //        cmd.Parameters.Add("@StatusDate", SqlDbType.Date).Value = Temp.StatusDate;
        //        cmd.Parameters.Add("@UpdatedBy", SqlDbType.VarChar).Value = Temp.UpdatedBy;
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
        //#endregion RESOLUTION_STATUS_HISTORY



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
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.VarChar).Value = Temp.ResolutionsId;
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = Temp.SystemUsersId;
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
                SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_RESOLUTION_SUBMITTERS";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = Temp.SystemUsersId;
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
        public List<ResolutionEnt> GetResolutions(int AssemblySessionsId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RESOLUTIONS";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = AssemblySessionsId;
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
                        Temp.ResolutionTypeId = Convert.ToInt32(dr["RES_TYPES_ID"]);
                        Temp.ResolutionType = Convert.ToString(dr["RES_TYPE"]);
                        //  Temp.Description = Regex.Replace(Convert.ToString(dr["DESCRIPTION"]), @"<[^>]+>|&nbsp;", "").Trim();
                        Temp.Description = Convert.ToString(dr["DESCRIPTION"]);
                        if (dr["URDU_TEXT"] != DBNull.Value)
                            Temp.UrduText = Convert.ToString(dr["URDU_TEXT"]);
                        if (dr["RESOLUTION_FILE"] != DBNull.Value)
                            Temp.ResolutionFile = Convert.ToString(dr["RESOLUTION_FILE"]);
                        Temp.Description = WebUtility.UrlDecode(Temp.Description);
                        Temp.ResolutionDiaryNo = Convert.ToInt32(dr["RESOLUTION_DIARY_NO"]);
                        Temp.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);
                        Temp.SessionNumber = Convert.ToString(dr["SESSION_NUMBER"]);
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
                        if (dr["MOVED_DATE"] != DBNull.Value)
                            Temp.MovedDate = Convert.ToDateTime(dr["MOVED_DATE"]);
                        if (dr["PASSED_DATE"] != DBNull.Value)
                            Temp.PassedDate = Convert.ToDateTime(dr["PASSED_DATE"]);
                        if (dr["DISCUSSED_DATE"] != DBNull.Value)
                            Temp.DiscussedDate = Convert.ToDateTime(dr["DISCUSSED_DATE"]);
                        Temp.DeviceId = Convert.ToInt32(dr["DEVICE_ID"]);
                        if (dr["MOVERS"] != DBNull.Value)
                        {
                            Temp.Mover = Convert.ToString(dr["MOVERS"]);
                            Temp.Submitters = new List<ResolutionSubmittersEnt>();
                            Temp.Submitters = GetResolutionSubmitters(Temp.Mover, Temp.ResolutionsId);
                        }
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
                    Temp.ResolutionsId = Convert.ToInt32(dr["RESOLUTIONS_ID"]);
                    Temp.ResolutionTypeId = Convert.ToInt32(dr["RES_TYPES_ID"]);
                    Temp.ResolutionType = Convert.ToString(dr["RES_TYPE"]);
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
                    Temp.DeviceId = Convert.ToInt32(dr["DEVICE_ID"]);
                    //if (dr["PASSED_DATE"] != DBNull.Value)
                    //    Temp.PassedDate = Convert.ToDateTime(dr["PASSED_DATE"]);
                    //if (dr["DISCUSSED_DATE"] != DBNull.Value)
                    //    Temp.DiscussedDate = Convert.ToDateTime(dr["DISCUSSED_DATE"]);
                    if (dr["MOVERS"] != DBNull.Value)
                    {
                        Temp.Mover = Convert.ToString(dr["MOVERS"]);
                        Temp.Submitters = new List<ResolutionSubmittersEnt>();
                        Temp.Submitters = GetResolutionSubmitters(Temp.Mover,ResolutionsId);
                    }
                }


                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public void DeleteSentResolution(int SentResolutionId)
        {
            
                string query = "Delete from notice_resolutions where resolutions_id=" + SentResolutionId;
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
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_RESOLUTION";
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = Temp.ResolutionsId;
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = Temp.AssemblySessionsId;
                cmd.Parameters.Add("@ResTypesId", SqlDbType.Int).Value = Temp.ResolutionTypeId;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@ResolutionStatus", SqlDbType.Int).Value = Temp.ResolutionStatusId;
                cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.Int).Value = Temp.NoticeDiaryNo;
                cmd.Parameters.Add("@ResolutionFile", SqlDbType.VarChar).Value = Temp.ResolutionFile;
                cmd.Parameters.Add("@Movers", SqlDbType.VarChar).Value = Temp.Mover;
                //cmd.Parameters.Add("@ResolutionNumber", SqlDbType.Int).Value = Temp.ResolutionNumber;
                if (Temp.NoticeDiaryDate > Convert.ToDateTime("01/01/1950"))
                    cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.DateTime).Value = Temp.NoticeDiaryDate;
                cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = Temp.NoticeDiaryTime;
                //cmd.Parameters.Add("@ResolutionDiaryNo", SqlDbType.Int).Value = Temp.ResolutionDiaryNo;
                //if (Temp.DiscussedDate > Convert.ToDateTime("01/01/1950"))
                //    cmd.Parameters.Add("@DiscussedDate", SqlDbType.DateTime).Value = Temp.DiscussedDate;
                //if (Temp.MovedDate > Convert.ToDateTime("01/01/1950"))
                //    cmd.Parameters.Add("@MovedDate", SqlDbType.DateTime).Value = Temp.MovedDate;
                //if (Temp.PassedDate > Convert.ToDateTime("01/01/1950"))
                //    cmd.Parameters.Add("@PassedDate", SqlDbType.DateTime).Value = Temp.PassedDate;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                if(!string.IsNullOrEmpty(Temp.UrduText))
                InsertDescription(Temp.ResolutionsId, Temp.UrduText);
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
                //int pk = GetPk("NOTICE_RESOLUTIONS","RESOLUTIONS_ID");
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_RESOLUTION";
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = Temp.ResolutionsId;
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = Temp.AssemblySessionsId;
                cmd.Parameters.Add("@ResTypesId", SqlDbType.Int).Value = Temp.ResolutionTypeId;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@ResolutionStatus", SqlDbType.Int).Value = Temp.ResolutionStatusId;// Temp.ResolutionStatusId;
                cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.Int).Value = Temp.NoticeDiaryNo;
                cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.DateTime).Value = Temp.NoticeDiaryDate;
                cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = Temp.NoticeDiaryTime;
                cmd.Parameters.Add("@ResolutionDiaryNo", SqlDbType.Int).Value = Temp.ResolutionDiaryNo;
                cmd.Parameters.Add("@Processed", SqlDbType.Int).Value = 0;
                cmd.Parameters.Add("@Movers", SqlDbType.VarChar).Value = Temp.Mover;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                //if (Temp.Submitters != null)
                //{
                //    foreach (ResolutionSubmittersEnt temp in Temp.Submitters)
                //    {
                //        temp.ResolutionsId = pk;
                //        InsertResolutionSubmitters(temp);
                //    }
                //}
                if(!string.IsNullOrEmpty(Temp.UrduText))
                InsertDescription(Temp.ResolutionsId, Temp.UrduText);
                return Temp.ResolutionsId;
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
            string query = "update notice_resolutions set urdu_text='" + text + "' where resolutions_id=" + ResId;
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
                            if (dr["SESSION_NUMBER"] != DBNull.Value)
                            {
                                Temp.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);
                                Temp.SessionNumber = Convert.ToString(dr["SESSION_NUMBER"]);
                            }
                            Temp.ResolutionDiaryNo = Convert.ToInt32(dr["RESOLUTION_DIARY_NO"]);
                            Temp.ResolutionsId = Convert.ToInt32(dr["RESOLUTIONS_ID"]);
                            Temp.ResolutionTypeId = Convert.ToInt32(dr["RES_TYPES_ID"]);
                            Temp.ResolutionType = Convert.ToString(dr["RES_TYPE"]);
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
                            Temp.DeviceId = Convert.ToInt32(dr["DEVICE_ID"]);
                            //if (dr["PASSED_DATE"] != DBNull.Value)
                            //    Temp.PassedDate = Convert.ToDateTime(dr["PASSED_DATE"]);
                            //if (dr["DISCUSSED_DATE"] != DBNull.Value)
                            //    Temp.DiscussedDate = Convert.ToDateTime(dr["DISCUSSED_DATE"]);
                            // Temp.Submitters = new List<ResolutionSubmittersEnt>();
                            // Temp.Submitters = GetResolutionSubmitters(ResolutionsId);
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
        public void InsertResolutionFile(string file, int ResolutionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_RESOLUTION_FILE";
                cmd.Parameters.Add("@ResolutionsId", SqlDbType.Int).Value = ResolutionId;
                cmd.Parameters.Add("@ResolutionFile", SqlDbType.VarChar).Value = file;
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
        public List<ResolutionEnt> GetSentResolutions(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SENT_RESOLUTIONS";
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
                            Temp.ResolutionDiaryNo = Convert.ToInt32(dr["RESOLUTION_DIARY_NO"]);
                        Temp.ResolutionsId = Convert.ToInt32(dr["RESOLUTIONS_ID"]);
                        Temp.ResolutionTypeId = Convert.ToInt32(dr["RES_TYPES_ID"]);
                        Temp.ResolutionType = Convert.ToString(dr["RES_TYPE"]);
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
        #endregion RESOLUTION

    }
}
