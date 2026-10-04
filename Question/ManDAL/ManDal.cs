using ManEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ManDAL
{
    public class ManDal
    {
        public User ValidateUser(string UserName, string Password, int ApplicationId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "VALIDATE_USER";
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = UserName;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;
                cmd.Parameters.Add("@ApplicationId", SqlDbType.Int).Value = ApplicationId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                User Temp = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = new User();
                    Temp.UserId = Convert.ToInt32(dr["USERS_ID"]);
                    Temp.FullName = Convert.ToString(dr["FULL_NAME"]);
                    Temp.ApplicationId = Convert.ToInt32(dr["APPLICATION_ID"]);
                    Temp.RoleId = Convert.ToInt32(dr["ROLE_ID"]);
                    Temp.Role = Convert.ToString(dr["ROLE"]);
                    Temp.UserTypeId = Convert.ToInt32(dr["USER_TYPES_ID"]);
                    Temp.UserType = Convert.ToString(dr["USER_TYPE"]);
                    // Temp.UserMenus = GetRoleActiveMenus(Temp.RoleId);
                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public User GetUser(int UserId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_USER";
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                User Temp = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = new User();
                    Temp.UserId = Convert.ToInt32(dr["USERS_ID"]);
                    Temp.FullName = Convert.ToString(dr["FULL_NAME"]);
                    Temp.ApplicationId = Convert.ToInt32(dr["APPLICATION_ID"]);
                    Temp.RoleId = Convert.ToInt32(dr["ROLE_ID"]);
                    Temp.UserCss = Convert.ToString(dr["USER_CSS"]);
                    Temp.UserTypeId = Convert.ToInt32(dr["USER_TYPES_ID"]);

                    Temp.UserMenus = GetRoleActiveMenus(Temp.RoleId);
                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public List<Menus> GetRoleActiveMenus(int RoleId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ROLE_ACTIVE_MENUES";
                cmd.Parameters.Add("@RoleId", SqlDbType.VarChar).Value = RoleId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Menus> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Menus>();
                    while (dr.Read())
                    {
                        Menus Temp = new Menus();
                        Temp.MenuId = Convert.ToInt32(dr["MENU_ID"]);
                        Temp.Menu = Convert.ToString(dr["MENU"]);
                        Temp.Url = Convert.ToString(dr["URL"]);
                        Temp.menuPages = GetMenuPages(Temp.MenuId);
                        if (dr["INNER_FUNCTION"] != DBNull.Value)
                            Temp.InnerFunction = Convert.ToString(dr["INNER_FUNCTION"]);
                        if (dr["INNER_CSS"] != DBNull.Value)
                            Temp.InnerCss = Convert.ToString(dr["INNER_CSS"]);
                        if (dr["SORT_ORDER"] != DBNull.Value)
                            Temp.SortOrder = Convert.ToInt32(dr["SORT_ORDER"]);
                        if (dr["MENU_POSTITION_ID"] != DBNull.Value)
                            Temp.MenuPosition = Convert.ToInt32(dr["MENU_POSTITION_ID"]);
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


        public List<MenuPages> GetMenuPages(int MenuId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MENU_PAGES";
                cmd.Parameters.Add("@MenuId", SqlDbType.VarChar).Value = MenuId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<MenuPages> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MenuPages>();
                    while (dr.Read())
                    {
                        MenuPages Temp = new MenuPages();
                        Temp.PageId = Convert.ToInt32(dr["PAGE_ID"]);
                        Temp.PageTitle = Convert.ToString(dr["PAGE_TITLE"]);
                        Temp.Url = Convert.ToString(dr["URL"]);
                        if (dr["INNER_FUNCTION"] != DBNull.Value)
                            Temp.InnerFunction = Convert.ToString(dr["INNER_FUNCTION"]);
                        if (dr["INNER_CSS"] != DBNull.Value)
                            Temp.InnerCss = Convert.ToString(dr["INNER_CSS"]);
                        if (dr["SORT_ORDER"] != DBNull.Value)
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
    }
}
