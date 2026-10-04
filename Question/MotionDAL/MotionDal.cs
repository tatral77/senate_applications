using MotionEntities;
using QuestionDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MotionDAL
{
    public class MotionDal
    {
        public int GetPk()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                int pk = 0;
                SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MOTION_PK";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
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
        public void UpdateMotionMover(MotionMoversEnt Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
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
                SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
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
                SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
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
                SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
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
                        Temp.MotionDiaryNo = Convert.ToInt32(dr["MOTION_DIARY_NO"]);
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
                        Temp.Description = Convert.ToString(dr["MOTION_TEXT"]);
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
                        Temp.MotionDiaryNo = Convert.ToInt32(dr["MOTION_DIARY_NO"]);
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
                        Temp.Description = Convert.ToString(dr["MOTION_TEXT"]);
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
                            if (dr["MOTION_DIARY_NO"] != DBNull.Value)
                                Temp.MotionDiaryNo = Convert.ToInt32(dr["MOTION_DIARY_NO"]);
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
                            Temp.Description = Convert.ToString(dr["MOTION_TEXT"]);
                            Temp.Movers = new List<MotionMoversEnt>();
                            Temp.Movers = GetMotionMovers(Temp.MotionsId);
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
                SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
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
                    Temp.MotionDiaryNo = Convert.ToInt32(dr["MOTION_DIARY_NO"]);
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
                    Temp.Description = Convert.ToString(dr["MOTION_TEXT"]);
                    Temp.IsUrdu = Convert.ToInt32(dr["IS_URDU"]);
                    Temp.Movers = new List<MotionMoversEnt>();
                    Temp.Movers = GetMotionMovers(Temp.MotionsId);

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
                SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MOTION";
                cmd.Parameters.Add("@MotionsId", SqlDbType.Int).Value = Temp.MotionsId;
                cmd.Parameters.Add("@MotionDiaryNo", SqlDbType.VarChar).Value = Temp.MotionDiaryNo;
                cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.Int).Value = Temp.NoticeDiaryNo;
                cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.DateTime).Value = Temp.NoticeDiaryDate;
                cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = Temp.NoticeDiaryTime;
                cmd.Parameters.Add("@MotionTypesId", SqlDbType.Int).Value = Temp.MotionTypeId;
                cmd.Parameters.Add("@MotionStatusesId", SqlDbType.Int).Value = Temp.MotionStatusId;
                cmd.Parameters.Add("@SessionNumber", SqlDbType.Int).Value = Temp.SessionNumber;
                cmd.Parameters.Add("@IsUrdu", SqlDbType.Int).Value = Temp.IsUrdu;
                if (Temp.RefferedScDate > Convert.ToDateTime("01/01/1950"))
                    cmd.Parameters.Add("@RefferedSCDate", SqlDbType.DateTime).Value = Temp.RefferedScDate;
                if (Temp.MovingHouseDate > Convert.ToDateTime("01/01/1950"))
                    cmd.Parameters.Add("@MovingHouseDate", SqlDbType.DateTime).Value = Temp.MovingHouseDate;
                if (Temp.DiscussionDate > Convert.ToDateTime("01/01/1950"))
                    cmd.Parameters.Add("@DiscussionDate", SqlDbType.DateTime).Value = Temp.DiscussionDate;
                if (Temp.IsUrdu == 0)
                    cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                if (Temp.IsUrdu == 1)
                    InsertDescription(Temp.MotionsId, Temp.Description);

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
                SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MOTION";
                cmd.Parameters.Add("@MotionsId", SqlDbType.Int).Value = pk;
                cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.Int).Value = Temp.NoticeDiaryNo;
                cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.DateTime).Value = Temp.NoticeDiaryDate;
                cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = Temp.NoticeDiaryTime;
                cmd.Parameters.Add("@SessionNumber", SqlDbType.Int).Value = Temp.SessionNumber;
                cmd.Parameters.Add("@MotionDiaryNo", SqlDbType.Int).Value = Temp.MotionDiaryNo;
                cmd.Parameters.Add("@MotionType", SqlDbType.Int).Value = Temp.MotionTypeId;
                cmd.Parameters.Add("@MotionStatusesId", SqlDbType.Int).Value = Temp.MotionStatusId;
                cmd.Parameters.Add("@IsUrdu", SqlDbType.Int).Value = Temp.IsUrdu;
                if (Temp.IsUrdu == 0)
                    cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                // int id = Convert.ToInt32(cmd.Parameters["@ID"].Value.ToString());
                if (Temp.IsUrdu == 1)
                    InsertDescription(pk, Temp.Description);
                foreach (MotionMoversEnt temp in Temp.Movers)
                {
                    temp.MotionId = pk;
                    InsertMotionMover(temp);

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
        protected void InsertDescription(int MotionId, string text)
        {
            string query = "update motions set description=N'" + text + "' where motions_id=" + MotionId;
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
        public void DeleteMotion(int MotionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_MOTION";
                cmd.Parameters.Add("@MotionsId", SqlDbType.Int).Value = MotionId;
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
        public List<MotionEnt> GetAdmittedMotions(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ADMITTED_MOTIONS";
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
                        Temp.MotionDiaryNo = Convert.ToInt32(dr["MOTION_DIARY_NO"]);
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
                        Temp.Description = Convert.ToString(dr["MOTION_TEXT"]);
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
        public List<ListEntity> GetMotionList(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MOTION_LIST";
                cmd.Parameters.Add("@SessionNumber", SqlDbType.VarChar).Value = AssemblySessionsId;
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
                        Temp.ListName = Convert.ToString(dr["LIST_NAME"]);
                        Temp.ListDate = Convert.ToDateTime(dr["LIST_DATE"]);
                        Temp.ListMotions = Convert.ToString(dr["MOTIONS"]);
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
                cmd.Parameters.Add("@ListDate", SqlDbType.DateTime).Value = Temp.ListDate;
                cmd.Parameters.Add("@Motions", SqlDbType.VarChar).Value = Temp.ListMotions;
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
                    Temp.ListName = Convert.ToString(dr["LIST_NAME"]);
                    Temp.ListDate = Convert.ToDateTime(dr["LIST_DATE"]);
                    Temp.ListMotions = Convert.ToString(dr["MOTIONS"]);
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
        public List<MotionSummary> GetStatusNoOfMotions(int FromSession, int ToSession)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "STATUS_NO_OF_MOTIONS";
                cmd.Parameters.Add("@FromSession", SqlDbType.Int).Value = FromSession;
                cmd.Parameters.Add("@ToSession", SqlDbType.Int).Value = ToSession;
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
                        Temp.StatusId = Convert.ToInt32(dr["MOTION_STATUSES_ID"]);
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
        public void UpdateMotionStatus(int MotionId, int StatusId, int AssemblySessionId, DateTime StatusDate)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
                //if (StatusId == 15 || StatusId == 2)
                //    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_QUESTION_REPLY_STATUS";
                //else if (StatusId == 4)
                //    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_QUESTION_DEFERMENT";
                //else
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "CHANGE_MOTION_STATUS";
                cmd.Parameters.Add("@MotionsId", SqlDbType.Int).Value = MotionId;
                cmd.Parameters.Add("@MotionStatusesId", SqlDbType.Int).Value = StatusId;
                cmd.Parameters.Add("@StatusDate", SqlDbType.Date).Value = StatusDate;
                //  cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = AssemblySessionId;
                // cmd.Parameters.Add("@ReplyDate", SqlDbType.Date).Value = StatusDate;
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
        public void CarryForwardMotions(int SessionNumber)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "CARRY_FORWARD_MOTIONS";
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
