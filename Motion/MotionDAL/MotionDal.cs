using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MotionDAL;
using QuestionDAL;
using MotionEntities;
using Entities;

namespace MotionDAL
{
    public class MotionDal
    {
        #region  MOTION_MOVERS

        public List<MotionMoversEnt> GetMotionMovers(int MotionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
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
        public List<MotionMoversEnt> GetMotionMovers(string movers,int MotionId)
        {
            if (!string.IsNullOrEmpty(movers))
            {

                movers = movers.Trim(',');
                SqlConnection con = new DalHelper().GetConnection();
                try
                {
                    string query = "SELECT SYSTEM_USERS_ID,SYSTEM_USERS.F_NAME from SYSTEM_USERS WHERE SYSTEM_USERS_ID in (" + movers + ")";
                    SqlCommand cmd = new SqlCommand(query, con);
                    List<MotionMoversEnt> MyList = null;
                    using (con)
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            MyList = new List<MotionMoversEnt>();
                            while (dr.Read())
                            {
                                MotionMoversEnt Temp = new MotionMoversEnt();

                                // Temp.MotionMoversId = Convert.ToInt32(dr["MOTION_MOVERS_ID"]);
                                Temp.MotionId = MotionId;
                                Temp.MotionMoversId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
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
            else
            {
                return null;
            }
        }
        public MotionMoversEnt GetMotionMover(int MotionId, int MoverId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
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
        public void UpdateMotionMover(MotionMoversEnt Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MOTION_MOVER";
                cmd.Parameters.Add("@@MotionMoversId", SqlDbType.Int).Value = Temp.MotionMoversId;
                cmd.Parameters.Add("@MotionsId", SqlDbType.Int).Value = Temp.MotionId;
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
        public void InsertMotionMover(MotionMoversEnt Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MOTION_MOVER";
                cmd.Parameters.Add("@MotionsId", SqlDbType.Int).Value = Temp.MotionId;
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = Temp.MotionMoversId;
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

        public void DeleteMotionMover(int MotionId, int MoverId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_MOTION_MOVER";
                cmd.Parameters.Add("@MotionsId", SqlDbType.Int).Value = MotionId;
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
        #endregion MOTION_MOVERS

        #region  MOTION_TYPES

        public List<MotionTypeEnt> GetMotionTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MOTION_TYPES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<MotionTypeEnt> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MotionTypeEnt>();
                    while (dr.Read())
                    {
                        MotionTypeEnt Temp = new MotionTypeEnt();

                        Temp.MotionTypeId = Convert.ToInt32(dr["MOTION_TYPES_ID"]);
                        Temp.Description = Convert.ToString(dr["DESCRIPTION"]);
                        Temp.IsForMotions = Convert.ToInt32(dr["IS_FOR_MOTIONS"]);
                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        //Temp.SortOrder = Convert.ToInt32(dr["SORT_ORDER"]);
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
        public void UpdateMotionType(MotionTypeEnt Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MOTION_TYPE";
                cmd.Parameters.Add("@@MotionTypesId", SqlDbType.Int).Value = Temp.MotionTypeId;
                cmd.Parameters.Add("@Description", SqlDbType.Int).Value = Temp.Description;
                cmd.Parameters.Add("@IsForMotions", SqlDbType.Int).Value = Temp.IsForMotions;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
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
        public void InsertMotionType(MotionTypeEnt Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MOTION_TYPE";
                cmd.Parameters.Add("@Description", SqlDbType.Int).Value = Temp.Description;
                cmd.Parameters.Add("@IsForMotions", SqlDbType.Int).Value = Temp.IsForMotions;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
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
        #endregion MOTION_TYPES

        #region  MOTION_STATUSES

        public List<MotionStatusEnt> GetMotionStatuses()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MOTION_STATUSES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<MotionStatusEnt> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MotionStatusEnt>();
                    while (dr.Read())
                    {
                        MotionStatusEnt Temp = new MotionStatusEnt();

                        Temp.MotionStatusId = Convert.ToInt32(dr["MOTION_STATUSES_ID"]);
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
        public void UpdateMotionStatus(MotionStatusEnt Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MOTION_STATUS";
                cmd.Parameters.Add("@@MotionStatusesId", SqlDbType.Int).Value = Temp.MotionStatusId;
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
        public void InsertMotionStatus(MotionStatusEnt Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MOTION_STATUS";
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
        #endregion MOTION_STATUSES

        #region  MOTION_MINISTRIES

        //public List<MotionMinistriesEnt> GetMotionMinistries()
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MOTION_MINISTRIES";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<MotionMinistriesEnt> MyList = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            MyList = new List<MotionMinistriesEnt>();
        //            while (dr.Read())
        //            {
        //                MotionMinistriesEnt Temp = new MotionMinistriesEnt();

        //                Temp.MotionMinistriesId = Convert.ToInt32(dr["MOTION_MINISTRIES_ID"]);
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
        //public void UpdateMotionMinistry(MotionMinistriesEnt Temp)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MOTION_MINISTRIES";
        //        cmd.Parameters.Add("@@MemberMinistriesId", SqlDbType.Int).Value = Temp.MemberMinistriesId;
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
        //public void InsertMotionMinistry(MotionMinistriesEnt Temp)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
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
        #endregion MOTION_MINISTRIES

        #region  MOTION
        public int GetPk()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                int pk = 1;
                SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MOTION_PK";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    if(dr["MOTIONS_ID"]!=DBNull.Value)
                    pk = Convert.ToInt32(dr["MOTIONS_ID"]);
                    

                }

                pk++;
                return pk;
            }
            finally
            {
                con.Close();

            }
        }
        public List<MotionEnt> GetMotions(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MOTIONS";
                cmd.Parameters.Add("@SessionNumber", SqlDbType.VarChar).Value = AssemblySessionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<MotionEnt> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MotionEnt>();
                    while (dr.Read())
                    {
                        MotionEnt Temp = new MotionEnt();
                        Temp.MotionsId = Convert.ToInt32(dr["MOTIONS_ID"]);
                        Temp.FileNo = Convert.ToString(dr["FILE_NO"]);
                        if (dr["REFFERED_SC_DATE"] != DBNull.Value)
                            Temp.WeekId = Convert.ToInt32(dr["MB_WEEK_ID"]);
                        Temp.MotionDiaryNo = Convert.ToString(dr["MOTION_DIARY_NO"]);
                        Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
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
                        if (dr["MOTION_TEXT"] != DBNull.Value)
                            Temp.Description = Convert.ToString(dr["MOTION_TEXT"]);
                        if (dr["SUBJECT"] != DBNull.Value)
                            Temp.NoteDescription = Convert.ToString(dr["SUBJECT"]);
                        if (dr["URDU_TEXT"] != DBNull.Value)
                            Temp.UrduText = Convert.ToString(dr["URDU_TEXT"]);
                        if (dr["MOTION_FILE"] != DBNull.Value)
                            Temp.MotionFile = Convert.ToString(dr["MOTION_FILE"]);
                        Temp.Movers = new List<MotionMoversEnt>();
                        Temp.Movers = GetMotionMovers(Temp.MotionsId);
                        Temp.MotionMinistries = GetMotionMinistries(Temp.MotionsId);
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
        public MotionEnt GetNoticeMotion(int MotionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MOTION";
                cmd.Parameters.Add("@MotionsId", SqlDbType.VarChar).Value = MotionId;
                cmd.CommandType = CommandType.StoredProcedure;
                MotionEnt Temp = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = new MotionEnt();
                    Temp.MotionsId = Convert.ToInt32(dr["MOTIONS_ID"]);
                    Temp.MotionDiaryNo = Convert.ToString(dr["MOTION_DIARY_NO"]);
                    Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                    if (dr["NOTICE_DIARY_DATE"] != DBNull.Value)
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
                    if (dr["NOTICE_DIARY_TIME"] != DBNull.Value)
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
                    if (dr["MOTION_TEXT"] != DBNull.Value)
                        Temp.Description = Convert.ToString(dr["MOTION_TEXT"]);
                    else
                        Temp.Description = "No English Text";
                    if (dr["SUBJECT"] != DBNull.Value)
                        Temp.NoteDescription = Convert.ToString(dr["SUBJECT"]);
                    if (dr["URDU_TEXT"] != DBNull.Value)
                        Temp.UrduText = Convert.ToString(dr["URDU_TEXT"]);
                    else
                        Temp.UrduText = "No Urdu Text";
                    if (dr["MOTION_FILE"] != DBNull.Value)
                        Temp.MotionFile = Convert.ToString(dr["MOTION_FILE"]);
                    if (dr["MOVERS"] != DBNull.Value)
                    {
                        Temp.Mover = Convert.ToString(dr["MOVERS"]);
                        Temp.Movers = new List<MotionMoversEnt>();
                        Temp.Movers = GetMotionMovers(Temp.Mover, Temp.MotionsId);
                        Temp.DeviceId = Convert.ToInt32(dr["DEVICE_ID"]);
                    }

                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public List<MotionEnt> GetSentMotions(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SENT_MOTIONS";
                cmd.Parameters.Add("@SessionNumber", SqlDbType.VarChar).Value = AssemblySessionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<MotionEnt> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MotionEnt>();
                    while (dr.Read())
                    {
                        MotionEnt Temp = new MotionEnt();
                        Temp.MotionsId = Convert.ToInt32(dr["MOTIONS_ID"]);
                        //Temp.FileNo = Convert.ToString(dr["FILE_NO"]);
                        if (dr["REFFERED_SC_DATE"] != DBNull.Value)
                            Temp.WeekId = Convert.ToInt32(dr["MB_WEEK_ID"]);
                        Temp.MotionDiaryNo = Convert.ToString(dr["MOTION_DIARY_NO"]);
                        Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
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
                        if (dr["MOTION_TEXT"] != DBNull.Value)
                            Temp.Description = Convert.ToString(dr["MOTION_TEXT"]);
                        else
                            Temp.Description = "No English Text";
                        //if (dr["SUBJECT"] != DBNull.Value)
                        //    Temp.Description = Convert.ToString(dr["SUBJECT"]);
                        if (dr["URDU_TEXT"] != DBNull.Value)
                            Temp.UrduText = Convert.ToString(dr["URDU_TEXT"]);
                        if (dr["MOTION_FILE"] != DBNull.Value)
                            Temp.MotionFile = Convert.ToString(dr["MOTION_FILE"]);
                        //Temp.NoteDescription = Convert.ToString(dr["SUBJECT"]);
                        Temp.Movers = new List<MotionMoversEnt>();
                        Temp.Movers = GetMotionMovers(Temp.MotionsId);
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
        public List<MotionEnt> SearchMotion(string query)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                List<MotionEnt> emp = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        emp = new List<MotionEnt>();
                        while (dr.Read())
                        {
                            MotionEnt Temp = new MotionEnt();
                            Temp.MotionsId = Convert.ToInt32(dr["MOTIONS_ID"]);
                            Temp.FileNo = Convert.ToString(dr["FILE_NO"]);
                            if (dr["MB_WEEK_ID"] != DBNull.Value)
                                Temp.WeekId = Convert.ToInt32(dr["MB_WEEK_ID"]);
                            Temp.MotionDiaryNo = Convert.ToString(dr["MOTION_DIARY_NO"]);
                            Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                            if (dr["NOTICE_DIARY_DATE"] != DBNull.Value)
                                Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
                            //Temp.NoticeDiaryTime = Convert.ToDateTime(dr["NOTICE_DIARY_TIME"]);
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
                            if (dr["MOTION_TEXT"] != DBNull.Value)
                                Temp.Description = Convert.ToString(dr["MOTION_TEXT"]);
                            else
                                Temp.Description = "No Text Entered";
                            if (dr["SUBJECT"] != DBNull.Value)
                                Temp.NoteDescription = Convert.ToString(dr["SUBJECT"]);
                            if (dr["URDU_TEXT"] != DBNull.Value)
                                Temp.UrduText = Convert.ToString(dr["URDU_TEXT"]);
                            if (dr["MOTION_FILE"] != DBNull.Value)
                                Temp.MotionFile = Convert.ToString(dr["MOTION_FILE"]);
                            Temp.Movers = new List<MotionMoversEnt>();
                            Temp.Movers = GetMotionMovers(Temp.MotionsId);
                            Temp.MotionMinistries = GetMotionMinistries(Temp.MotionsId);
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
        public MotionEnt GetMotion(int MotionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MOTION";
                cmd.Parameters.Add("@MotionsId", SqlDbType.Int).Value = MotionId;
                cmd.CommandType = CommandType.StoredProcedure;
                MotionEnt Temp = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = new MotionEnt();
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
                    if (dr["MOTION_TEXT"] != DBNull.Value)
                        Temp.Description = Convert.ToString(dr["MOTION_TEXT"]);
                    if (dr["SUBJECT"] != DBNull.Value)
                        Temp.NoteDescription = Convert.ToString(dr["SUBJECT"]);
                    if (dr["URDU_TEXT"] != DBNull.Value)
                        Temp.UrduText = Convert.ToString(dr["URDU_TEXT"]);
                    if (dr["MOTION_FILE"] != DBNull.Value)
                        Temp.MotionFile = Convert.ToString(dr["MOTION_FILE"]);
                    Temp.Movers = new List<MotionMoversEnt>();
                    Temp.Movers = GetMotionMovers(Temp.MotionsId);
                    Temp.MotionMinistries = GetMotionMinistries(Temp.MotionsId);

                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public List<MotionMinistriesEnt> GetMotionMinistries(int MotionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MOTION_MINISTRIES";
                cmd.Parameters.Add("@MotionsId", SqlDbType.Int).Value = MotionId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<MotionMinistriesEnt> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MotionMinistriesEnt>();
                    while (dr.Read())
                    {
                        MotionMinistriesEnt Temp = new MotionMinistriesEnt();

                        Temp.MotionMinistriesId = Convert.ToInt32(dr["MOTION_MINISTRIES_ID"]);
                        Temp.MotionId = Convert.ToInt32(dr["MOTIONS_ID"]);
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
        public void DeleteMotion(int MotionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_MOTION";
                cmd.Parameters.Add("@MotionsId", SqlDbType.Int).Value = MotionId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();                
            }
            finally
            {
                con.Close();

            }
        }
        public void RecoverMotion(int MotionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "RECOVER_MOTION";
                cmd.Parameters.Add("@MotionsId", SqlDbType.Int).Value = MotionId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
            }
            finally
            {
                con.Close();

            }
        }
        public void UpdateMotion(MotionEnt Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MOTION";
                cmd.Parameters.Add("@MotionsId", SqlDbType.Int).Value = Temp.MotionsId;
                cmd.Parameters.Add("@FileNo", SqlDbType.VarChar).Value = Temp.FileNo;
                cmd.Parameters.Add("@WeekId", SqlDbType.Int).Value = Temp.WeekId;
                cmd.Parameters.Add("@MotionDiaryNo", SqlDbType.VarChar).Value = Temp.MotionDiaryNo;
                cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.Int).Value = Temp.NoticeDiaryNo;
                cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.DateTime).Value = Temp.NoticeDiaryDate;
                cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = Temp.NoticeDiaryTime;
                cmd.Parameters.Add("@MotionTypesId", SqlDbType.Int).Value = Temp.MotionTypeId;
                cmd.Parameters.Add("@MotionStatusesId", SqlDbType.Int).Value = Temp.MotionStatusId;
                cmd.Parameters.Add("@SessionNumber", SqlDbType.Int).Value = Temp.SessionNumber;
                cmd.Parameters.Add("@Processed", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@Subject", SqlDbType.VarChar).Value = Temp.NoteDescription;
                if (Temp.RefferedScDate > Convert.ToDateTime("01/01/1950"))
                    cmd.Parameters.Add("@RefferedSCDate", SqlDbType.DateTime).Value = Temp.RefferedScDate;
                if (Temp.MovingHouseDate > Convert.ToDateTime("01/01/1950"))
                    cmd.Parameters.Add("@MovingHouseDate", SqlDbType.DateTime).Value = Temp.MovingHouseDate;
                if (Temp.DiscussionDate > Convert.ToDateTime("01/01/1950"))
                    cmd.Parameters.Add("@DiscussionDate", SqlDbType.DateTime).Value = Temp.DiscussionDate;
                if (!string.IsNullOrEmpty(Temp.MotionFile))
                    cmd.Parameters.Add("@MotionFile", SqlDbType.VarChar).Value = Temp.MotionFile;

                //cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                InsertDescription(Temp.MotionsId, Temp.UrduText);
              
               

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
        public int InsertMotion(MotionEnt Temp, List<MotionMoversEnt> motionmovers)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                int pk = GetPk();
                SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MOTION";
                cmd.Parameters.Add("@MotionsId", SqlDbType.Int).Value = pk;
                cmd.Parameters.Add("@WeekId", SqlDbType.Int).Value = Temp.WeekId;
                cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.Int).Value = Temp.NoticeDiaryNo;
                cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.DateTime).Value = Temp.NoticeDiaryDate;
                cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = Temp.NoticeDiaryTime;
                cmd.Parameters.Add("@FileNo", SqlDbType.VarChar).Value = Temp.FileNo + "/" + pk.ToString();
                cmd.Parameters.Add("@SessionNumber", SqlDbType.Int).Value = Temp.SessionNumber;
                cmd.Parameters.Add("@MotionDiaryNo", SqlDbType.Int).Value = Temp.MotionDiaryNo;
                cmd.Parameters.Add("@MotionType", SqlDbType.Int).Value = Temp.MotionTypeId;
                cmd.Parameters.Add("@MotionStatusesId", SqlDbType.Int).Value = Temp.MotionStatusId;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@MotionFile", SqlDbType.VarChar).Value = Temp.MotionFile;
                cmd.Parameters.Add("@Subject", SqlDbType.VarChar).Value = Temp.NoteDescription;
                cmd.Parameters.Add("@Processed", SqlDbType.Int).Value = Temp.Processed;
                // cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                //int id = Convert.ToInt32(cmd.Parameters["@ID"].Value.ToString());
                if (Temp.Movers != null)
                {
                    foreach (MotionMoversEnt temp in Temp.Movers)
                    {
                        temp.MotionId = pk;
                        InsertMotionMover(temp);

                    }
                }
                if (Temp.MotionMinistries != null)
                {
                    foreach (MotionMinistriesEnt temp2 in Temp.MotionMinistries)
                    {
                        temp2.MotionId = pk;
                        InsertMotionMinistries(temp2);

                    }
                }
                if(!string.IsNullOrEmpty(Temp.UrduText))
                InsertDescription(pk, Temp.UrduText);
                UpdateMotionProcessStatus(Temp.MotionsId, 1);
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
        public void UpdateMotionProcessStatus(int MotionId, int Status)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "SET_MOTION_PROCESSED_STATUS";
                cmd.Parameters.Add("@MotionsId", SqlDbType.Int).Value = MotionId;
                cmd.Parameters.Add("@ProcessedStatus", SqlDbType.Int).Value = Status;
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
        public void InsertMotionMinistries(MotionMinistriesEnt Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MOTION_MINISTRY";
                cmd.Parameters.Add("@MotionsId", SqlDbType.Int).Value = Temp.MotionId;
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

        public void DeleteMotionMinistry(int MotionId, int MinistryId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_MOTION_MINISTRY";
                cmd.Parameters.Add("@MotionsId", SqlDbType.Int).Value = MotionId;
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

        protected void InsertDescription(int MotionId, string text)
        {
            string query = "update motions set urdu_text=N'" + text + "' where motions_id=" + MotionId;
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
        #endregion MOTION

        #region TRANSLATION
        public void SendForTranslation(int MotionId)
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
       
        public void ApproveTranslation(int MotionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "APPROVE_MOTION_TRANSLATION";
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
        public List<MotionEnt> GetTranslationMotions(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_TRANSLATION_MOTIONS";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.VarChar).Value = AssemblySessionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                    List<MotionEnt> MyList = null;
                    if (dr.HasRows)
                    {
                        MyList = new List<MotionEnt>();
                        while (dr.Read())
                        {
                            MotionEnt Temp = new MotionEnt();
                            Temp.MotionsId = Convert.ToInt32(dr["MOTIONS_ID"]);
                            Temp.FileNo = Convert.ToString(dr["FILE_NO"]);
                            if (dr["REFFERED_SC_DATE"] != DBNull.Value)
                                Temp.WeekId = Convert.ToInt32(dr["MB_WEEK_ID"]);
                            Temp.MotionDiaryNo = Convert.ToString(dr["MOTION_DIARY_NO"]);
                            Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                            Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
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
                            Temp.Movers = new List<MotionMoversEnt>();
                            Temp.Movers = GetMotionMovers(Temp.MotionsId);
                            Temp.MotionMinistries = GetMotionMinistries(Temp.MotionsId);
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

        public List<MotionEnt> GetTranslatedMotions(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[TRANSLATION]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_TRANSLATED_MOTIONS";
                cmd.Parameters.Add("@AssemblySessionId", SqlDbType.VarChar).Value = AssemblySessionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                List<MotionEnt> MyList = null;
                if (dr.HasRows)
                {
                    MyList = new List<MotionEnt>();
                    while (dr.Read())
                    {
                        MotionEnt Temp = new MotionEnt();
                        Temp.MotionsId = Convert.ToInt32(dr["MOTIONS_ID"]);
                        Temp.FileNo = Convert.ToString(dr["FILE_NO"]);
                        if (dr["REFFERED_SC_DATE"] != DBNull.Value)
                            Temp.WeekId = Convert.ToInt32(dr["MB_WEEK_ID"]);
                        Temp.MotionDiaryNo = Convert.ToString(dr["MOTION_DIARY_NO"]);
                        Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
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
                        Temp.Movers = new List<MotionMoversEnt>();
                        Temp.Movers = GetMotionMovers(Temp.MotionsId);
                        Temp.MotionMinistries = GetMotionMinistries(Temp.MotionsId);
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

        #region AssemblySessions
        public AssemblySessions GetAssemblySession(int AssemblySessionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ASSEMBLY_SESSION";
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.VarChar).Value = AssemblySessionId;
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
        #endregion Assembly sessions
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
        public string GetMemberNameById(int MemberId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
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
        public int GetCurrentAssemblySessions()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
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
        public List<Divisions> GetDivisionsByName(string DivisionName)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
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
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
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

        #region MOTION WEEK
        public List<MotionWeek> GetMotionWeeks()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MOTION_WEEKS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<MotionWeek> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MotionWeek>();
                    while (dr.Read())
                    {
                        MotionWeek Temp = new MotionWeek();

                        Temp.WeekId = Convert.ToInt32(dr["MB_WEEKS_ID"]);
                        Temp.WeekName = Convert.ToString(dr["MB_WEEK"]);
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
        public MotionWeek GetMotionWeek(int weekid)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MOTION_WEEK";
                cmd.Parameters.Add("@WeekId", SqlDbType.VarChar).Value = weekid;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                MotionWeek Temp = null;
                dr.Read();
                if (dr.HasRows)
                {
                        Temp = new MotionWeek();
                        Temp.WeekId = Convert.ToInt32(dr["MB_WEEKS_ID"]);
                        Temp.WeekName = Convert.ToString(dr["MB_WEEK"]);
                       
                }

               
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion MOTION WEEK

        public List<MotionSummary> GetStatusNoOfMotions(int FromSession, int ToSession,int MotionTypeId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "STATUS_NO_OF_MOTIONS";
                cmd.Parameters.Add("@FromSession", SqlDbType.Int).Value = FromSession;
                cmd.Parameters.Add("@ToSession", SqlDbType.Int).Value = ToSession;
                cmd.Parameters.Add("@MotionTypesId", SqlDbType.Int).Value = MotionTypeId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<MotionSummary> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MotionSummary>();
                    while (dr.Read())
                    {
                        MotionSummary Temp = new MotionSummary();
                        Temp.AssemblySession = Convert.ToInt32(dr["SESSION_NUMBER"]);
                        Temp.StatusId = Convert.ToInt32(dr["MOTION_STATUS"]);
                        Temp.Status = Convert.ToString(dr["DESCRIPTION"]);
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
        #region Motion Status History


        public List<MotionStatusHistory> GetMotionStatusHistory(int MotionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MOTION_STATUS_HISTORY";
                cmd.Parameters.Add("@MotionsId", SqlDbType.Int).Value = MotionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<MotionStatusHistory> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MotionStatusHistory>();
                    while (dr.Read())
                    {
                        MotionStatusHistory Temp = new MotionStatusHistory();
                        Temp.MotionStatusHistoryId = Convert.ToInt32(dr["MOT_STATUS_HIST_ID"]);
                        Temp.MotionId = Convert.ToInt32(dr["MOTIONS_ID"]);
                        Temp.MotionStatusId = Convert.ToInt32(dr["MOTION_STATUSES_ID"]);
                        Temp.MotionStatus= Convert.ToString(dr["DESCRIPTION"]);
                        Temp.StatusDate = Convert.ToDateTime(dr["STATUS_DATE"]);
                        Temp.AssemblySessionId= Convert.ToInt32(dr["ASSEMBLY_SESSION_ID"]);
                        Temp.AssemblySession= Convert.ToString(dr["SESSION_NUMBER"]);
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


        public void InsertMotionStatusHistory(MotionStatusHistory Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MOTION_STATUS_HISTORY";
                cmd.Parameters.Add("@MotionsId", SqlDbType.Int).Value = Temp.MotionId;
                cmd.Parameters.Add("@MotionStatusesId", SqlDbType.Int).Value = Temp.MotionStatusId;
                cmd.Parameters.Add("@StatusDate", SqlDbType.DateTime).Value = Temp.StatusDate;
                cmd.Parameters.Add("@SessionNumber", SqlDbType.Int).Value = Temp.AssemblySessionId;

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

        public void SetNoticeMotionRevived(int MotionsId, int ReviveMotionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "SET_AS_REVIVED_MOTION";
                cmd.Parameters.Add("@MotionsId", SqlDbType.VarChar).Value = MotionsId;
                cmd.Parameters.Add("@PreviousId", SqlDbType.VarChar).Value = ReviveMotionId;
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
        public void InsertMotionRevivalHistory(RevivalHistory revivalHistory)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Motion_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MOTION_REVIVAL_HISTORY";
                cmd.Parameters.Add("@MotionsId", SqlDbType.Int).Value = revivalHistory.MotionsId;
                cmd.Parameters.Add("@FromAssemblySessionsId", SqlDbType.Int).Value = revivalHistory.FromAssemblySessionId;
                cmd.Parameters.Add("@ToAssemblySessionsId", SqlDbType.Int).Value = revivalHistory.ToAssemblySessionId;
                cmd.Parameters.Add("@RevivalDate", SqlDbType.Date).Value = revivalHistory.RevivalDate;
                cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.Int).Value = revivalHistory.NoticeOfficediaryNumber;
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

        public List<RevivalHistory> GetMotionRevivalHistory(int MotionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[Motion_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MOTION_REVIVAL_HISTORY";
                cmd.Parameters.Add("@MotionsId", SqlDbType.Int).Value = MotionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<RevivalHistory> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<RevivalHistory>();
                    while (dr.Read())
                    {
                        RevivalHistory Temp = new RevivalHistory();
                        Temp.RevivalHistoryId = Convert.ToInt32(dr["MOTION_REVIVAL_ID"]);
                        Temp.MotionsId = Convert.ToInt32(dr["MOTIONS_ID"]);
                        //Temp.FromAssemblySessionId = Convert.ToInt32(dr["SESSION_NUMBER"]);
                        //Temp.ToAssemblySessionId = Convert.ToInt32(dr["QUESTION_STATUS"]);
                        Temp.FromAssemblySession = Convert.ToString(dr["FROM_SESSION"]);
                        Temp.ToAssemblySession = Convert.ToString(dr["TO_SESSION"]);
                        Temp.RevivalDate = Convert.ToDateTime(dr["REVIVAL_DATE"]);
                        Temp.NoticeOfficediaryNumber = Convert.ToInt32(dr["NOTICE_DIARY_NUMBER"]);
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

        #region Motions List

        public List<MotionEnt> GetAdmittedMotions(int AssemblySessionsId,int MotiontypeId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ADMITTED_MOTIONS";
                cmd.Parameters.Add("@SessionNumber", SqlDbType.Int).Value = AssemblySessionsId;
                cmd.Parameters.Add("@MotionTypesId", SqlDbType.Int).Value = MotiontypeId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<MotionEnt> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MotionEnt>();
                    while (dr.Read())
                    {
                        MotionEnt Temp = new MotionEnt();
                        Temp.MotionsId = Convert.ToInt32(dr["MOTIONS_ID"]);
                        Temp.MotionDiaryNo = Convert.ToString(dr["MOTION_DIARY_NO"]);
                        Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                        if (dr["NOTICE_DIARY_DATE"] != DBNull.Value)
                            Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
                        if (dr["NOTICE_DIARY_TIME"] != DBNull.Value)
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
                        //Temp.Description = Regex.Replace(Convert.ToString(dr["MOTION_TEXT"]), @"<[^>]+>|&nbsp;", "").Trim();
                        if (dr["MOTION_TEXT"] != DBNull.Value)
                            Temp.Description = Convert.ToString(dr["MOTION_TEXT"]);
                        else
                            Temp.Description = "No Text Entered";
                        Temp.Movers = new List<MotionMoversEnt>();
                        Temp.Movers = GetMotionMovers(Temp.MotionsId);
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

        public List<MotionEnt> GetDefferedMotions(int AssemblySessionsId, int MotiontypeId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_DEFFERED_MOTIONS";
                cmd.Parameters.Add("@SessionNumber", SqlDbType.Int).Value = AssemblySessionsId;
                cmd.Parameters.Add("@MotionTypesId", SqlDbType.Int).Value = MotiontypeId;
               
                cmd.CommandType = CommandType.StoredProcedure;
                List<MotionEnt> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MotionEnt>();
                    while (dr.Read())
                    {
                        MotionEnt Temp = new MotionEnt();
                        Temp.MotionsId = Convert.ToInt32(dr["MOTIONS_ID"]);
                        Temp.MotionDiaryNo = Convert.ToString(dr["MOTION_DIARY_NO"]);
                        Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
                        if (dr["NOTICE_DIARY_DATE"] != DBNull.Value)
                            Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
                        if (dr["NOTICE_DIARY_TIME"] != DBNull.Value)
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
                        //Temp.Description = Regex.Replace(Convert.ToString(dr["MOTION_TEXT"]), @"<[^>]+>|&nbsp;", "").Trim();
                        if (dr["MOTION_TEXT"] != DBNull.Value)
                            Temp.Description = Convert.ToString(dr["MOTION_TEXT"]);
                        else
                            Temp.Description = "No Text Entered";
                        Temp.Movers = new List<MotionMoversEnt>();
                        Temp.Movers = GetMotionMovers(Temp.MotionsId);
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
        public List<ListEntity> GetMotionList(int AssemblySessionsId,int MotiontypeId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MOTION_LIST";
                cmd.Parameters.Add("@SessionNumber", SqlDbType.VarChar).Value = AssemblySessionsId;
                cmd.Parameters.Add("@MotionTypesId", SqlDbType.VarChar).Value = MotiontypeId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ListEntity> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ListEntity>();
                    while (dr.Read())
                    {
                        ListEntity Temp = new ListEntity();

                        Temp.MotionListId = Convert.ToInt32(dr["MOTION_LIST_ID"]);
                        Temp.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);
                        Temp.AsseblySession = Convert.ToString(dr["SESSION_NUMBER"]);
                        Temp.MotionTypeId = Convert.ToInt32(dr["MOTION_TYPES_ID"]);
                        Temp.MotionType = Convert.ToString(dr["SESSION_NUMBER"]);
                        Temp.MotionWeekId = Convert.ToInt32(dr["MOTION_WEEK_ID"]);
                        Temp.MotionWeek = Convert.ToString(dr["MB_WEEK"]);
                        Temp.ListName = Convert.ToString(dr["MOTION_TYPE"]);
                        Temp.ListDate = Convert.ToDateTime(dr["LIST_DATE"]);
                        Temp.ListMotions = Convert.ToString(dr["MOTIONS"]);
                        Temp.DefferedMotions = Convert.ToString(dr["DEFFERED_MOTIONS"]);
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
        public void InsertMotionList(ListEntity Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MOTION_LIST";
                cmd.Parameters.Add("@ListName", SqlDbType.VarChar).Value = Temp.ListName;
                cmd.Parameters.Add("@SessionNumber", SqlDbType.Int).Value = Temp.AssemblySessionsId;
                cmd.Parameters.Add("@MotionTypesId", SqlDbType.Int).Value = Temp.MotionTypeId;
                cmd.Parameters.Add("@MotionWeekId", SqlDbType.Int).Value = Temp.MotionWeekId;
                cmd.Parameters.Add("@ListDate", SqlDbType.DateTime).Value = Temp.ListDate;
                cmd.Parameters.Add("@Motions", SqlDbType.VarChar).Value = Temp.ListMotions;
                cmd.Parameters.Add("@DefferedMotions", SqlDbType.VarChar).Value = Temp.DefferedMotions;
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
        public void DeleteMotionList(int MotionListId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_MOTION_LIST";
                cmd.Parameters.Add("@MotionListId", SqlDbType.Int).Value = MotionListId;
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
        public ListEntity GetMotionListById(int MotionListId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MOTION_LIST_BY_ID";
                cmd.Parameters.Add("@MotionListId", SqlDbType.VarChar).Value = MotionListId;
                cmd.CommandType = CommandType.StoredProcedure;
                ListEntity Temp = new ListEntity();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = new ListEntity();
                    Temp.MotionListId = Convert.ToInt32(dr["MOTION_LIST_ID"]);
                    Temp.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);
                    Temp.AsseblySession = Convert.ToString(dr["SESSION_NUMBER"]);
                    Temp.MotionTypeId = Convert.ToInt32(dr["MOTION_TYPES_ID"]);
                    Temp.MotionType = Convert.ToString(dr["MOTION_TYPE"]);
                    Temp.MotionWeekId = Convert.ToInt32(dr["MOTION_WEEK_ID"]);
                    Temp.MotionWeek = Convert.ToString(dr["MB_WEEK"]);
                    Temp.ListName = Convert.ToString(dr["LIST_NAME"]);
                    Temp.ListDate = Convert.ToDateTime(dr["LIST_DATE"]);
                    Temp.ListMotions = Convert.ToString(dr["MOTIONS"]);
                    Temp.DefferedMotions = Convert.ToString(dr["DEFFERED_MOTIONS"]);
                }

                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public void UpdateMotionListNo(int MotionsId, int ListNo, DateTime ListDate)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MOTION_LIST_NO";
                cmd.Parameters.Add("@MotionsId", SqlDbType.Int).Value = MotionsId;
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
        #endregion

    }
}
