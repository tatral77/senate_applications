using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class MotionDal
    {
        public int GetPk()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                int pk = 0;
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MOTION_PK";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    if (dr["MOTIONS_ID"] != DBNull.Value)
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
        #region  MOTION_MOVERS

        public List<MotionMoversEnt> GetMotionMovers(int MotionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
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
        public List<MotionMoversEnt> GetMotionMovers(string movers,int motionId)
        {
                movers = movers.Trim(',');
                SqlConnection con = new DalHelper().GetConnection();
                try
                {
                    string query= "SELECT SYSTEM_USERS_ID,SYSTEM_USERS.F_NAME from SYSTEM_USERS WHERE SYSTEM_USERS_ID in (" + movers +")";
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
                                Temp.MotionId = motionId;
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
        public MotionMoversEnt GetMotionMover(int MotionId, int MoverId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
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
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
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
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
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
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
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



        #region  MOTION

        public List<MotionEnt> GetMotions(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
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
                        if (dr["MOVERS"] != DBNull.Value)
                            Temp.Mover = Convert.ToString(dr["MOVERS"]);
                        if (dr["MOVERS"] != DBNull.Value)
                            Temp.Mover = Convert.ToString(dr["MOVERS"]);
                        if (dr["MOVERS"] != DBNull.Value)
                            Temp.Mover = Convert.ToString(dr["MOVERS"]);
                        //Temp.Description = Regex.Replace(Convert.ToString(dr["MOTION_TEXT"]), @"<[^>]+>|&nbsp;", "").Trim();
                        Temp.Description = Convert.ToString(dr["MOTION_TEXT"]);
                        if (!String.IsNullOrEmpty(Temp.Mover))
                        {
                            Temp.Movers = new List<MotionMoversEnt>();
                            Temp.Movers = GetMotionMovers(Temp.Mover,Temp.MotionsId);
                        }
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
        public List<MotionEnt> GetSentMotions(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SENT_MOTIONS";
                cmd.Parameters.Add("@SessionNumber", SqlDbType.Int).Value = AssemblySessionsId;
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
                        if (dr["MOVERS"] != DBNull.Value)
                            Temp.Mover = Convert.ToString(dr["MOVERS"]);
                        //Temp.Description = Regex.Replace(Convert.ToString(dr["MOTION_TEXT"]), @"<[^>]+>|&nbsp;", "").Trim();
                        Temp.Description = Convert.ToString(dr["MOTION_TEXT"]);
                        if (!String.IsNullOrEmpty(Temp.Mover))
                        {
                            Temp.Movers = new List<MotionMoversEnt>();
                            Temp.Movers = GetMotionMovers(Temp.Mover, Temp.MotionsId);
                        }
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
                            if (dr["MOVERS"] != DBNull.Value)
                                Temp.Mover = Convert.ToString(dr["MOVERS"]);
                            //Temp.Description = Regex.Replace(Convert.ToString(dr["MOTION_TEXT"]), @"<[^>]+>|&nbsp;", "").Trim();
                            Temp.Description = Convert.ToString(dr["MOTION_TEXT"]);
                            if (!String.IsNullOrEmpty(Temp.Mover))
                            {
                                Temp.Movers = new List<MotionMoversEnt>();
                                Temp.Movers = GetMotionMovers(Temp.Mover, Temp.MotionsId);
                            }
                            emp.Add(Temp);
                            Temp.DeviceId = Convert.ToInt32(dr["DEVICE_ID"]);

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
                    if (dr["MOVERS"] != DBNull.Value)
                        Temp.Mover = Convert.ToString(dr["MOVERS"]);
                    Temp.Description = Convert.ToString(dr["MOTION_TEXT"]);
                    Temp.UrduText = Convert.ToString(dr["URDU_TEXT"]);
                    Temp.MotionFile = Convert.ToString(dr["MOTION_FILE"]);
                    if (!String.IsNullOrEmpty(Temp.Mover))
                    {
                        Temp.Movers = new List<MotionMoversEnt>();
                        Temp.Movers = GetMotionMovers(Temp.Mover, Temp.MotionsId);
                    }
                    Temp.DeviceId = Convert.ToInt32(dr["DEVICE_ID"]);

                }
                return Temp;
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
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MOTION";
                cmd.Parameters.Add("@MotionsId", SqlDbType.Int).Value = Temp.MotionsId;
                //cmd.Parameters.Add("@MotionDiaryNo", SqlDbType.VarChar).Value = Temp.MotionDiaryNo;
                cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.Int).Value = Temp.NoticeDiaryNo;
                cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.DateTime).Value = Temp.NoticeDiaryDate;
                cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = Temp.NoticeDiaryTime;
                cmd.Parameters.Add("@MotionTypesId", SqlDbType.Int).Value = Temp.MotionTypeId;
                //cmd.Parameters.Add("@MotionStatusesId", SqlDbType.Int).Value = Temp.MotionStatusId;
                cmd.Parameters.Add("@SessionNumber", SqlDbType.Int).Value = Temp.SessionNumber;
                //if (Temp.RefferedScDate > Convert.ToDateTime("01/01/1950"))
                //    cmd.Parameters.Add("@RefferedSCDate", SqlDbType.DateTime).Value = Temp.RefferedScDate;
                //if (Temp.MovingHouseDate > Convert.ToDateTime("01/01/1950"))
                //    cmd.Parameters.Add("@MovingHouseDate", SqlDbType.DateTime).Value = Temp.MovingHouseDate;
                //if (Temp.DiscussionDate > Convert.ToDateTime("01/01/1950"))
                //    cmd.Parameters.Add("@DiscussionDate", SqlDbType.DateTime).Value = Temp.DiscussionDate;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@MotionFile", SqlDbType.VarChar).Value = Temp.MotionFile;
                cmd.Parameters.Add("@Movers", SqlDbType.VarChar).Value = Temp.Mover;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                if (!string.IsNullOrEmpty(Temp.UrduText))
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
               // int pk = GetPk();
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MOTION";
                cmd.Parameters.Add("@MotionsId", SqlDbType.Int).Value = Temp.MotionsId;
                cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.Int).Value = Temp.MotionsId;
                cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.DateTime).Value = Temp.NoticeDiaryDate;
                cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = Temp.NoticeDiaryTime;
                cmd.Parameters.Add("@SessionNumber", SqlDbType.Int).Value = Temp.SessionNumber;
                cmd.Parameters.Add("@MotionDiaryNo", SqlDbType.Int).Value = Temp.MotionDiaryNo;
                cmd.Parameters.Add("@MotionType", SqlDbType.Int).Value = Temp.MotionTypeId;
                cmd.Parameters.Add("@MotionStatusesId", SqlDbType.Int).Value = Temp.MotionStatusId;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@Movers", SqlDbType.VarChar).Value = Temp.Mover;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                //int id = Convert.ToInt32(cmd.Parameters["@ID"].Value.ToString());
                //foreach (MotionMoversEnt temp in Temp.Movers)
                //{
                //    temp.MotionId = pk;
                //    InsertMotionMover(temp);

                //}
                if (!string.IsNullOrEmpty(Temp.MotionFile))
                    InsertMotionFile(Temp.MotionFile, Temp.MotionsId);
                if (!string.IsNullOrEmpty(Temp.UrduText))
                    InsertDescription(Temp.MotionsId, Temp.UrduText);
                return Temp.MotionsId;

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
        public void DeleteSentMotion(int SentMotionId)
        {
            string query = "Delete from notice_motions where motions_id=" + SentMotionId;
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
        protected void InsertDescription(int MotionId, string text)
        {
            string query = "update notice_motions set Urdu_Text=N'" + text + "' where motions_id=" + MotionId;
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
        public void InsertUrduText(string UrduText, int MotionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                if (!string.IsNullOrEmpty(UrduText))
                {
                    string query = "Update notice_motions set urdu_text=N'" + UrduText + "' where motionss_id=" + MotionId;
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
        public void InsertMotionFile(string file, int MotionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MOTION_FILE";
                cmd.Parameters.Add("@MotionsId", SqlDbType.Int).Value = MotionId;
                cmd.Parameters.Add("@MotionFile", SqlDbType.VarChar).Value = file;
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
        #endregion MOTION
    }
}
