using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class MBMotionDal
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
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MB_MOTION_MINISTRIES";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<MotionMinistriesEnt> MyList = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            MyList = new List<MotionMinistriesEnt>();
        //            while (dr.Read())
        //            {
        //                MotionMinistriesEnt Temp = new MotionMinistriesEnt();

        //                Temp.MemberMinistriesId = Convert.ToInt32(dr["MOTION_MINISTRIES_ID"]);
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
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MB_MOTION_MINISTRIES";
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
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MB_MOTION_STATUS";
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
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MB_MOTION_PK";
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
        public List<MBMotion> GetMotions(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[MB_MOTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MB_MOTIONS";
                cmd.Parameters.Add("@SessionNumber", SqlDbType.VarChar).Value = AssemblySessionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<MBMotion> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MBMotion>();
                    while (dr.Read())
                    {
                        MBMotion Temp = new MBMotion();
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
        public List<MBMotion> GetSentMotions(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MB_SENT_MOTIONS";
                cmd.Parameters.Add("@SessionNumber", SqlDbType.VarChar).Value = AssemblySessionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<MBMotion> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MBMotion>();
                    while (dr.Read())
                    {
                        MBMotion Temp = new MBMotion();
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
        public List<MBMotion> SearchMotion(string query)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                List<MBMotion> emp = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        emp = new List<MBMotion>();
                        while (dr.Read())
                        {
                            MBMotion Temp = new MBMotion();
                            Temp.MotionsId = Convert.ToInt32(dr["MOTIONS_ID"]);
                            Temp.FileNo = Convert.ToString(dr["FILE_NO"]);
                            Temp.WeekId = Convert.ToInt32(dr["MB_WEEK_ID"]);
                            Temp.MotionDiaryNo = Convert.ToString(dr["MOTION_DIARY_NO"]);
                            Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
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
        public MBMotion GetMotion(int MotionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MB_MOTION";
                cmd.Parameters.Add("@MotionsId", SqlDbType.VarChar).Value = MotionId;
                cmd.CommandType = CommandType.StoredProcedure;
                MBMotion Temp = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = new MBMotion();
                    Temp.MotionsId = Convert.ToInt32(dr["MOTIONS_ID"]);
                    Temp.FileNo = Convert.ToString(dr["FILE_NO"]);
                    if (dr["REFFERED_SC_DATE"] != DBNull.Value)
                        Temp.WeekId = Convert.ToInt32(dr["MB_WEEK_ID"]);
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
                    //if (dr["REFFERED_SC_DATE"] != DBNull.Value)
                    //    Temp.RefferedScDate = Convert.ToDateTime(dr["REFFERED_SC_DATE"]);
                    //if (dr["MOVING_HOUSE_DATE"] != DBNull.Value)
                    //    Temp.MovingHouseDate = Convert.ToDateTime(dr["MOVING_HOUSE_DATE"]);
                    //if (dr["DISCUSSION_DATE"] != DBNull.Value)
                    //    Temp.DiscussionDate = Convert.ToDateTime(dr["DISCUSSION_DATE"]);
                    Temp.Description = Convert.ToString(dr["MOTION_TEXT"]);
                    Temp.UrduText = Convert.ToString(dr["URDU_TEXT"]);
                    Temp.MotionFile = Convert.ToString(dr["MOTION_TEXT"]);
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
        public void UpdateMotion(MBMotion Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MB_MOTION";
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
                //if (Temp.RefferedScDate > Convert.ToDateTime("01/01/1950"))
                //    cmd.Parameters.Add("@RefferedSCDate", SqlDbType.DateTime).Value = Temp.RefferedScDate;
                //if (Temp.MovingHouseDate > Convert.ToDateTime("01/01/1950"))
                //    cmd.Parameters.Add("@MovingHouseDate", SqlDbType.DateTime).Value = Temp.MovingHouseDate;
                //if (Temp.DiscussionDate > Convert.ToDateTime("01/01/1950"))
                cmd.Parameters.Add("@DiscussionDate", SqlDbType.DateTime).Value = Temp.DiscussionDate;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                InsertUrduText(Temp.MotionsId, Temp.UrduText);
                //InsertDescription(Temp.MotionsId, Temp.Description);

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
        public int InsertMotion(MBMotion Temp, List<MotionMoversEnt> motionmovers)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                int pk = GetPk();
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MB_MOTION";
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
                // cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                //int id = Convert.ToInt32(cmd.Parameters["@ID"].Value.ToString());
                foreach (MotionMoversEnt temp in Temp.Movers)
                {
                    temp.MotionId = pk;
                    InsertMotionMover(temp);

                }
                InsertUrduText(pk, Temp.UrduText);
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
        protected void InsertUrduText(int MotionId, string text)
        {
            string query = "update mb_motions set Urdu_Text=N'" + text + "' where motions_id=" + MotionId;
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
        public void InsertMotionFile(string file, int MotionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MB_MOTION_FILE";
                cmd.Parameters.Add("@MotionId", SqlDbType.Int).Value = MotionId;
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

        #region AssemblySessions
        public AssemblySessions GetAssemblySession(int AssemblySessionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
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
        //public Groups GetGroupById(int GroupId)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_GROUP";
        //        cmd.Parameters.Add("@GroupsId", SqlDbType.Int).Value = GroupId;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        Groups Temp = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            dr.Read();
        //            Temp = new Groups();
        //            Temp.GroupsId = Convert.ToInt32(dr["Groups_Id"]);
        //            Temp.Description = Convert.ToString(dr["Group_Name"]);
        //            Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
        //            Temp.AssembliesSessionId = Convert.ToInt32(dr["Assembly_Sessions_Id"]);
        //            //Temp.AssembliesSession = Convert.ToString(dr["Session_Number"]);
        //            Temp.CorrespondingGroup = Convert.ToInt32(dr["Corresponding_Group"]);
        //            Temp.GroupSequence = Convert.ToInt32(dr["Group_Sequence"]);
        //            Temp.UnstarDesc = Convert.ToString(dr["Unstar_Desc"]);


        //        }

        //        return Temp;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}
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
    }
}
