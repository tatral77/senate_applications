using Entities;
using MotionEntities;
using QuestionDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MotionDAL
{
    public class ResolutionDal
    {
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
        public List<ResolutionTypeEnt> GetResolutionTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RESOLUTION_TYPES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<ResolutionTypeEnt> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ResolutionTypeEnt>();
                    while (dr.Read())
                    {
                        ResolutionTypeEnt Temp = new ResolutionTypeEnt();

                        Temp.ResTypesId = Convert.ToInt32(dr["RES_TYPES_ID"]);
                        Temp.Description = Convert.ToString(dr["DESCRIPTION"]);
                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        // Temp.BranchesId = Convert.ToInt32(dr["BRANCHES_ID"]);
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
        public List<ResolutionStatusesEnt> GetResolutionStatuses()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[RESOLUTION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RESOLUTION_STATUSES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<ResolutionStatusesEnt> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ResolutionStatusesEnt>();
                    while (dr.Read())
                    {
                        ResolutionStatusesEnt Temp = new ResolutionStatusesEnt();

                        Temp.ResolutionStatusesId = Convert.ToInt32(dr["RESOLUTION_STATUSES_ID"]);
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
    }
}
