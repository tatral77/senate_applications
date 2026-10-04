using LegisEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisDAL
{
    public class MiscDal
    {
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
        #endregion Member
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
        public string GetPassword()
        {
            return "X#Bv7_4qT!Ma";
        }
    }
}
