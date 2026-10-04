using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class ManagementDal
    {
        #region Application
        public List<ApplicationEnt> GetApplications()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_APPLICATIONS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<ApplicationEnt> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ApplicationEnt>();
                    while (dr.Read())
                    {
                        ApplicationEnt Temp = new ApplicationEnt();

                        Temp.ApplicationId = Convert.ToInt32(dr["APPLICATION_ID"]);
                        Temp.ApplicationName = Convert.ToString(dr["APPLICATION"]);
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

        public ApplicationEnt GetApplication(int ApplicationId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_APPLICATION";
                cmd.Parameters.Add("@ApplicationId", SqlDbType.Int).Value = ApplicationId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                ApplicationEnt Temp = null;
                if (dr.HasRows)
                {
                    Temp = new ApplicationEnt();
                    dr.Read();
                    Temp.ApplicationId = Convert.ToInt32(dr["APPLICATION_ID"]);
                    Temp.ApplicationName = Convert.ToString(dr["APPLICATION"]);
                }


                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertApplication(ApplicationEnt Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                int ID = new DalHelper().GetPk("MAN_APPLICATIONS", "APPLICATION_ID");
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_APPLICATION";
                cmd.Parameters.Add("@ApplicationId", SqlDbType.Int).Value = ID;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.ApplicationName;
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

        #endregion APPLICATION
        #region MENU
        public List<MenuesEnt> GetMenus(int ApplicationId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MENUS";
                cmd.Parameters.Add("@ApplicationId", SqlDbType.Int).Value = ApplicationId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<MenuesEnt> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MenuesEnt>();
                    while (dr.Read())
                    {
                        MenuesEnt Temp = new MenuesEnt();

                        Temp.MenuId = Convert.ToInt32(dr["MENUS_ID"]);
                        Temp.Menu = Convert.ToString(dr["MENU"]);
                        Temp.Description = Convert.ToString(dr["DESCRIPTION"]);
                        Temp.MenuPositionId= Convert.ToInt32(dr["MENU_POSTITION_ID"]);
                        Temp.SortOrder = Convert.ToInt32(dr["SORT_ORDER"]);
                        Temp.MenuPosition = Convert.ToString(dr["MENU_POSITION"]);
                        Temp.InnerCss = Convert.ToString(dr["INNER_FUNCTION"]);
                        Temp.ApplicationId = Convert.ToInt32(dr["APPLICATION_ID"]);
                        Temp.Application = Convert.ToString(dr["APPLICATION"]);
                        Temp.Url = Convert.ToString(dr["URL"]);
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

        public MenuesEnt GetMenu(int MenuId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MENU";
                cmd.Parameters.Add("@MenuId", SqlDbType.Int).Value = MenuId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                MenuesEnt Temp = null;
                if (dr.HasRows)
                {
                    Temp = new MenuesEnt();
                    dr.Read();
                    Temp.MenuId = Convert.ToInt32(dr["MENUS_ID"]);
                    Temp.Menu = Convert.ToString(dr["MENU"]);
                    Temp.Description = Convert.ToString(dr["DESCRIPTION"]);
                    Temp.MenuPositionId = Convert.ToInt32(dr["MENU_POSTITION_ID"]);
                    Temp.SortOrder = Convert.ToInt32(dr["SORT_ORDER"]);
                    Temp.InnerFunction = Convert.ToString(dr["INNER_FUNCTION"]);
                    Temp.InnerCss = Convert.ToString(dr["INNER_CSS"]);
                    Temp.MenuPosition = Convert.ToString(dr["MENU_POSITION"]);
                    Temp.ApplicationId = Convert.ToInt32(dr["APPLICATION_ID"]);
                    Temp.Application = Convert.ToString(dr["APPLICATION"]);
                    Temp.Url = Convert.ToString(dr["URL"]);
                    Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public List<MenuesEnt> GetUnAssignedRoleMenus(int RoleId,int ApplicationId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_UN_ASSIGNED_ROLE_MENUES";
                cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = RoleId;
                cmd.Parameters.Add("@ApplicationId", SqlDbType.Int).Value = ApplicationId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                List<MenuesEnt> MyList = null;
                if (dr.HasRows)
                {
                    MyList = new List<MenuesEnt>();
                    while (dr.Read())
                    {
                        MenuesEnt Temp = new MenuesEnt();

                        Temp.MenuId = Convert.ToInt32(dr["MENUS_ID"]);
                        Temp.Menu = Convert.ToString(dr["MENU"]);
                        Temp.Description = Convert.ToString(dr["DESCRIPTION"]);
                        Temp.MenuPositionId = Convert.ToInt32(dr["MENU_POSTITION_ID"]);
                        Temp.SortOrder = Convert.ToInt32(dr["SORT_ORDER"]);
                        Temp.ApplicationId = Convert.ToInt32(dr["APPLICATION_ID"]);
                        Temp.Url = Convert.ToString(dr["URL"]);
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
        public void InsertMenu(MenuesEnt Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                int ID = new DalHelper().GetPk("MAN_MENUS", "MENUS_ID");
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MENU";
                cmd.Parameters.Add("@MenuId", SqlDbType.Int).Value = ID;
                cmd.Parameters.Add("@Menu", SqlDbType.VarChar).Value = Temp.Menu;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@Url", SqlDbType.VarChar).Value = Temp.Url;
                cmd.Parameters.Add("@MenuPositionId", SqlDbType.Int).Value = Temp.MenuPositionId;
                cmd.Parameters.Add("@ApplicationId", SqlDbType.Int).Value = Temp.ApplicationId;
                cmd.Parameters.Add("@InnerFunction", SqlDbType.VarChar).Value = Temp.InnerFunction;
                cmd.Parameters.Add("@InnerCss", SqlDbType.VarChar).Value = Temp.InnerCss;
                cmd.Parameters.Add("@SortOrder", SqlDbType.Int).Value = Temp.SortOrder;
                cmd.Parameters.Add("@IsActive", SqlDbType.VarChar).Value = Temp.IsActive;
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

        public void UpdateMenu(MenuesEnt Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_MENU";
                cmd.Parameters.Add("@MenuId", SqlDbType.Int).Value = Temp.MenuId;
                cmd.Parameters.Add("@Menu", SqlDbType.VarChar).Value = Temp.Menu;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@Url", SqlDbType.VarChar).Value = Temp.Url;
                cmd.Parameters.Add("@MenuPositionId", SqlDbType.Int).Value = Temp.MenuPositionId;
                cmd.Parameters.Add("@SortOrder", SqlDbType.Int).Value = Temp.SortOrder;
                cmd.Parameters.Add("@InnerFunction", SqlDbType.VarChar).Value = Temp.InnerFunction;
                cmd.Parameters.Add("@InnerCss", SqlDbType.VarChar).Value = Temp.InnerCss;
                cmd.Parameters.Add("@IsActive", SqlDbType.VarChar).Value = Temp.IsActive;
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
        #endregion MENU
        #region SUB_MENU
        public List<SubMenus> GetSubMenus()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SUB_MENUS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<SubMenus> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<SubMenus>();
                    while (dr.Read())
                    {
                        SubMenus Temp = new SubMenus();

                        Temp.SubMenuId = Convert.ToInt32(dr["SUB_MENU_ID"]);
                        Temp.SubMenu = Convert.ToString(dr["SUB_MENU"]);
                        Temp.MenuId = Convert.ToInt32(dr["MENUS_ID"]);
                        Temp.SortOrder = Convert.ToInt32(dr["SORT_ORDER"]);
                        Temp.Url = Convert.ToString(dr["URL"]);
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
        public List<SubMenus> GetMenuSubMenus(int MenuId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MENU_SUB_MENUS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<SubMenus> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<SubMenus>();
                    while (dr.Read())
                    {
                        SubMenus Temp = new SubMenus();

                        Temp.SubMenuId = Convert.ToInt32(dr["SUB_MENU_ID"]);
                        Temp.SubMenu = Convert.ToString(dr["SUB_MENU"]);
                        Temp.MenuId = Convert.ToInt32(dr["MENUS_ID"]);
                        Temp.SortOrder = Convert.ToInt32(dr["SORT_ORDER"]);
                        Temp.Url = Convert.ToString(dr["URL"]);
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
        public List<SubMenus> GetMenuActiveSubMenus(int MenuId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MENU_ACTIVE_SUB_MENUS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<SubMenus> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<SubMenus>();
                    while (dr.Read())
                    {
                        SubMenus Temp = new SubMenus();

                        Temp.SubMenuId = Convert.ToInt32(dr["SUB_MENU_ID"]);
                        Temp.SubMenu = Convert.ToString(dr["SUB_MENU"]);
                        Temp.MenuId = Convert.ToInt32(dr["MENUS_ID"]);
                        Temp.SortOrder = Convert.ToInt32(dr["SORT_ORDER"]);
                        Temp.Url = Convert.ToString(dr["URL"]);
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

        public SubMenus GetSubMenu(int SubMenuId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SUB_MENU";
                cmd.Parameters.Add("@SubMenuId", SqlDbType.Int).Value = SubMenuId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                SubMenus Temp = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp.SubMenuId = Convert.ToInt32(dr["SUB_MENU_ID"]);
                    Temp.SubMenu = Convert.ToString(dr["SUB_MENU"]);
                    Temp.MenuId = Convert.ToInt32(dr["MENUS_ID"]);
                    Temp.SortOrder = Convert.ToInt32(dr["SORT_ORDER"]);
                    Temp.Url = Convert.ToString(dr["URL"]);
                    Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertSubMenu(SubMenus Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                int ID = new DalHelper().GetPk("MAN_SUB_MENUS", "SUB_MENUS_ID");
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_SUB_MENU";
                cmd.Parameters.Add("@SubMenuId", SqlDbType.Int).Value = ID;
                cmd.Parameters.Add("@SubMenu", SqlDbType.VarChar).Value = Temp.SubMenu;
                cmd.Parameters.Add("@MenuId", SqlDbType.Int).Value = Temp.MenuId;
                cmd.Parameters.Add("@Url", SqlDbType.VarChar).Value = Temp.Url;
                cmd.Parameters.Add("@SortOrder", SqlDbType.Int).Value = Temp.SortOrder;
                cmd.Parameters.Add("@IsActive", SqlDbType.VarChar).Value = Temp.IsActive;
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

        public void UpdateSubMenu(SubMenus Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_SUB_MENU";
                cmd.Parameters.Add("@SubMenuId", SqlDbType.Int).Value = Temp.SubMenuId;
                cmd.Parameters.Add("@SubMenu", SqlDbType.VarChar).Value = Temp.SubMenu;
                cmd.Parameters.Add("@MenuId", SqlDbType.Int).Value = Temp.MenuId;
                cmd.Parameters.Add("@Url", SqlDbType.VarChar).Value = Temp.Url;
                cmd.Parameters.Add("@SortOrder", SqlDbType.Int).Value = Temp.SortOrder;
                cmd.Parameters.Add("@IsActive", SqlDbType.VarChar).Value = Temp.IsActive;
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
        #endregion SUB_MENU

        #region ROLE
        public List<Role> GetApplicationRoles(int ApplicationId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_APPLICATION_ROLES";
                cmd.Parameters.Add("@ApplicationId", SqlDbType.Int).Value = ApplicationId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Role> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Role>();
                    while (dr.Read())
                    {
                        Role Temp = new Role();

                        Temp.RoleId = Convert.ToInt32(dr["ROLES_ID"]);
                        Temp.RoleName = Convert.ToString(dr["ROLE"]);
                        Temp.ApplicationId = Convert.ToInt32(dr["APPLICATION_ID"]);
                        Temp.Application = Convert.ToString(dr["APPLICATION"]);
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

        public Role GetRole(int RoleId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ROLE";
                cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = RoleId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                Role Temp = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = new Role();
                    Temp.RoleId = Convert.ToInt32(dr["ROLES_ID"]);
                    Temp.RoleName = Convert.ToString(dr["ROLE"]);
                    Temp.ApplicationId = Convert.ToInt32(dr["APPLICATION_ID"]);
                    Temp.Application = Convert.ToString(dr["APPLICATION"]);
                    Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertRole(Role Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                int ID = new DalHelper().GetPk("MAN_ROLES", "ROLES_ID");
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_ROLE";
                cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = ID;
                cmd.Parameters.Add("@RoleName", SqlDbType.VarChar).Value = Temp.RoleName;
                cmd.Parameters.Add("@ApplicationId", SqlDbType.Int).Value = Temp.ApplicationId;
                cmd.Parameters.Add("@IsActive", SqlDbType.VarChar).Value = Temp.IsActive;
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

        public void UpdateRole(Role Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_ROLE";
                cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = Temp.RoleId;
                cmd.Parameters.Add("@RoleName", SqlDbType.VarChar).Value = Temp.RoleName;
                cmd.Parameters.Add("@ApplicationId", SqlDbType.Int).Value = Temp.ApplicationId;
                cmd.Parameters.Add("@IsActive", SqlDbType.VarChar).Value = Temp.IsActive;
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
        #endregion ROLE

        #region ROLE_MENU
        public List<RoleMenus> GetRoleMenus(int RoleId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ROLE_MENUES";
                cmd.Parameters.Add("@RoleId", SqlDbType.VarChar).Value = RoleId;

                cmd.CommandType = CommandType.StoredProcedure;
                List<RoleMenus> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<RoleMenus>();
                    while (dr.Read())
                    {
                        RoleMenus Temp = new RoleMenus();

                        Temp.RoleId = Convert.ToInt32(dr["ROLES_ID"]);
                        Temp.Role = Convert.ToString(dr["ROLE"]);
                        Temp.MenuId = Convert.ToInt32(dr["MENU_ID"]);
                        Temp.Menu = Convert.ToString(dr["MENU"]);
                        Temp.Description = Convert.ToString(dr["DESCRIPTION"]);
                        Temp.Url = Convert.ToString(dr["URL"]);
                        Temp.Submenus = GetMenuSubMenus(Temp.MenuId);
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
        public List<RoleMenus> GetRoleActiveMenus(int RoleId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ROLE_ACTIVE_MENUES";
                cmd.Parameters.Add("@RoleId", SqlDbType.VarChar).Value = RoleId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<RoleMenus> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<RoleMenus>();
                    while (dr.Read())
                    {
                        RoleMenus Temp = new RoleMenus();

                        Temp.RoleId = Convert.ToInt32(dr["ROLES_ID"]);
                        Temp.Role = Convert.ToString(dr["ROLE"]);
                        Temp.MenuId = Convert.ToInt32(dr["MENU_ID"]);
                        Temp.Menu = Convert.ToString(dr["MENU"]);
                        Temp.Url = Convert.ToString(dr["URL"]);
                        Temp.Submenus = GetMenuActiveSubMenus(Temp.MenuId);
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
        

        public void InsertRoleMenu(RoleMenus Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                int ID = new DalHelper().GetPk("MAN_ROLE_MENUS", "ROLE_MENUS_ID");
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_ROLE_MENU";
                cmd.Parameters.Add("@RoleMenuId", SqlDbType.Int).Value = ID;
                cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = Temp.RoleId;
                cmd.Parameters.Add("@MenuId", SqlDbType.VarChar).Value = Temp.MenuId;
                cmd.Parameters.Add("@IsActive", SqlDbType.VarChar).Value = Temp.IsActive;
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

        public void UpdateRoleMenu(RoleMenus Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_ROLE_MENU";
                cmd.Parameters.Add("@RoleMenuId", SqlDbType.Int).Value = Temp.RoleMenuId;
                cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = Temp.RoleId;
                cmd.Parameters.Add("@MenuId", SqlDbType.VarChar).Value = Temp.MenuId;
                cmd.Parameters.Add("@IsActive", SqlDbType.VarChar).Value = Temp.IsActive;
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
        public void DeleteRoleMenu(int RoleId, int MenuId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_ROLE_MENU";
                cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = RoleId;
                cmd.Parameters.Add("@MenuId", SqlDbType.Int).Value = MenuId;
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
        #endregion ROLE_MENU

        #region USER_TYPE
        public List<UserTypes> GetUserTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_USER_TYPES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<UserTypes> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<UserTypes>();
                    while (dr.Read())
                    {
                        UserTypes Temp = new UserTypes();

                        Temp.UserTypeId = Convert.ToInt32(dr["USER_TYPES_ID"]);
                        Temp.UserType = Convert.ToString(dr["USER_TYPE"]);
                        Temp.CanAdd = Convert.ToInt32(dr["CAN_ADD"]);
                        Temp.CanDelete = Convert.ToInt32(dr["CAN_DELETE"]);
                        Temp.CanEdit = Convert.ToInt32(dr["CAN_EDIT"]);
                      
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

        public UserTypes GetUserType(int UserTypeId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_USER_TYPE";
                cmd.Parameters.Add("@UserTypeId", SqlDbType.Int).Value = UserTypeId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                UserTypes Temp = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp.UserTypeId = Convert.ToInt32(dr["USER_TYPES_ID"]);
                    Temp.UserType = Convert.ToString(dr["USER_TYPE"]);
                    Temp.CanAdd = Convert.ToInt32(dr["CAN_ADD"]);
                    Temp.CanDelete = Convert.ToInt32(dr["CAN_DELETE"]);
                    Temp.CanEdit = Convert.ToInt32(dr["CAN_EDIT"]);
                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertUserType(UserTypes Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                int ID = new DalHelper().GetPk("MAN_USER_TYPES", "USER_TYPES_ID");
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_USER_TYPE";
                cmd.Parameters.Add("@UserTypeId", SqlDbType.Int).Value = ID;
                cmd.Parameters.Add("@UserType", SqlDbType.Int).Value = Temp.UserType;
                cmd.Parameters.Add("@CanAdd", SqlDbType.VarChar).Value = Temp.CanAdd;
                cmd.Parameters.Add("@CanEdit", SqlDbType.VarChar).Value = Temp.CanEdit;
                cmd.Parameters.Add("@CanDelete", SqlDbType.VarChar).Value = Temp.CanDelete;
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

        public void UpdateUserType(UserTypes Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_USER_TYPE";
                cmd.Parameters.Add("@UserTypeId", SqlDbType.Int).Value = Temp.UserTypeId;
                cmd.Parameters.Add("@UserType", SqlDbType.Int).Value = Temp.UserType;
                cmd.Parameters.Add("@CanAdd", SqlDbType.VarChar).Value = Temp.CanAdd;
                cmd.Parameters.Add("@CanEdit", SqlDbType.VarChar).Value = Temp.CanEdit;
                cmd.Parameters.Add("@CanDelete", SqlDbType.VarChar).Value = Temp.CanDelete;
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
        #endregion USER TYPES

        #region USER
        public List<Users> GetUsers(int ApplicationId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_USERS";
                cmd.Parameters.Add("@ApplicationId", SqlDbType.Int).Value = ApplicationId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Users> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Users>();
                    while (dr.Read())
                    {
                        Users Temp = new Users();

                        Temp.UserId = Convert.ToInt32(dr["USERS_ID"]);
                        Temp.UserName = Convert.ToString(dr["USER_NAME"]);
                        Temp.Password = Convert.ToString(dr["PASSWORD"]);
                        Temp.FullName = Convert.ToString(dr["FULL_NAME"]);
                        Temp.ApplicationId = Convert.ToInt32(dr["APPLICATION_ID"]);
                        Temp.Application = Convert.ToString(dr["APPLICATION"]);
                        Temp.RoleId = Convert.ToInt32(dr["ROLE_ID"]);
                        Temp.Role = Convert.ToString(dr["ROLE"]);
                        Temp.UserTypeId = Convert.ToInt32(dr["USER_TYPES_ID"]);
                        Temp.UserType = Convert.ToString(dr["USER_TYPE"]);
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

        public Users GetUser(int UserId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_USER";
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                Users Temp = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp.UserId = Convert.ToInt32(dr["USERS_ID"]);
                    Temp.UserName = Convert.ToString(dr["USER_NAME"]);
                    Temp.Password = Convert.ToString(dr["PASSWORD"]);
                    Temp.FullName = Convert.ToString(dr["FULL_NAME"]);
                    Temp.ApplicationId = Convert.ToInt32(dr["APPLICATION_ID"]);
                    Temp.Application = Convert.ToString(dr["APPLICATION"]);
                    Temp.RoleId = Convert.ToInt32(dr["ROLE_ID"]);
                    Temp.Role = Convert.ToString(dr["ROLE"]);
                    Temp.UserTypeId = Convert.ToInt32(dr["USER_TYPES_ID"]);
                    Temp.UserType = Convert.ToString(dr["USER_TYPE"]);
                    Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public Users GetUser(string UserName,string Password)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "VALIDATE_USER";
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = UserName;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = UserName;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                Users Temp = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp.UserId = Convert.ToInt32(dr["USERS_ID"]);
                    Temp.UserName = Convert.ToString(dr["USER_NAME"]);
                    Temp.Password = Convert.ToString(dr["PASSWORD"]);
                    Temp.Password = Convert.ToString(dr["FULL_NAME"]);
                    Temp.ApplicationId = Convert.ToInt32(dr["APPLICATION_ID"]);
                    Temp.Password = Convert.ToString(dr["APPLICATION"]);
                    Temp.RoleId = Convert.ToInt32(dr["ROLE_ID"]);
                    Temp.Password = Convert.ToString(dr["ROLE"]);
                    Temp.UserTypeId = Convert.ToInt32(dr["USER_TYPES_ID"]);
                    Temp.Password = Convert.ToString(dr["USER_TYPE"]);
                    Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertUser(Users Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
               
                int ID = new DalHelper().GetPk("MAN_USERS", "USERS_ID");
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_USER";
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = ID;
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = Temp.UserName;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Temp.Password;
                cmd.Parameters.Add("@FullName", SqlDbType.VarChar).Value = Temp.FullName;
                cmd.Parameters.Add("@ApplicationId", SqlDbType.Int).Value = Temp.ApplicationId;
                cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = Temp.RoleId;
                cmd.Parameters.Add("@UserTypeId", SqlDbType.Int).Value = Temp.UserTypeId;
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

        public void UpdateUser(Users Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_USER";
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = Temp.UserId;
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = Temp.UserName;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Temp.Password;
                cmd.Parameters.Add("@FullName", SqlDbType.VarChar).Value = Temp.FullName;
                cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = Temp.RoleId;
                cmd.Parameters.Add("@UserTypeId", SqlDbType.Int).Value = Temp.UserTypeId;
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
        #endregion USER TYPES

        #region MENU POSITION
        public List<MenuPositionEnt> GetMenuPositions()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MENU_POSITIONS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<MenuPositionEnt> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MenuPositionEnt>();
                    while (dr.Read())
                    {
                        MenuPositionEnt Temp = new MenuPositionEnt();

                        Temp.MenuPositionId = Convert.ToInt32(dr["MENU_POSITION_ID"]);
                        Temp.MenuPosition = Convert.ToString(dr["MENU_POSITION"]);
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

        public MenuPositionEnt GetMenuPosition(int MenuPositionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MENU_POSITION";
                cmd.Parameters.Add("@MenuPositionId", SqlDbType.Int).Value = MenuPositionId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                MenuPositionEnt Temp = null;
                if (dr.HasRows)
                {
                    dr.Read();

                    Temp.MenuPositionId = Convert.ToInt32(dr["MENU_POSITION_ID"]);
                    Temp.MenuPosition = Convert.ToString(dr["MENU_POSITION"]);
                }


                return Temp;
            }
            finally
            {
                con.Close();

            }
        }


        #endregion MENU POSITION

        #region PAGES
        public List<ApplicationPages> GetPages(int ApplicationId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PAGES";
                cmd.Parameters.Add("@ApplicationId", SqlDbType.Int).Value = ApplicationId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ApplicationPages> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ApplicationPages>();
                    while (dr.Read())
                    {
                        ApplicationPages Temp = new ApplicationPages();

                        Temp.PageId = Convert.ToInt32(dr["PAGE_ID"]);
                        Temp.PageTitle = Convert.ToString(dr["PAGE_TITLE"]);
                        Temp.Url = Convert.ToString(dr["URL"]);
                        Temp.InnerFunction = Convert.ToString(dr["INNER_FUNCTION"]);
                        Temp.InnerCss = Convert.ToString(dr["INNER_CSS"]);
                        Temp.ApplicationId = Convert.ToInt32(dr["APPLICATION_ID"]);
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

        public ApplicationPages GetPage(int PageId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PAGE";
                cmd.Parameters.Add("@PageId", SqlDbType.Int).Value = PageId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                ApplicationPages Temp = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp.PageId = Convert.ToInt32(dr["PAGE_ID"]);
                    Temp.PageTitle = Convert.ToString(dr["PAGE_TITLE"]);
                    Temp.Url = Convert.ToString(dr["URL"]);
                    Temp.InnerFunction = Convert.ToString(dr["INNER_FUNCTION"]);
                    Temp.InnerCss = Convert.ToString(dr["INNER_CSS"]);
                    Temp.ApplicationId = Convert.ToInt32(dr["APPLICATION_ID"]);
                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertPage(ApplicationPages Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                int ID = new DalHelper().GetPk("MAN_PAGES", "PAGE_ID");
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_PAGE";
                cmd.Parameters.Add("@PageId", SqlDbType.Int).Value = ID;
                cmd.Parameters.Add("@PageTitle", SqlDbType.VarChar).Value = Temp.PageTitle;
                cmd.Parameters.Add("@Url", SqlDbType.VarChar).Value = Temp.Url;
                cmd.Parameters.Add("@InnerFunction", SqlDbType.VarChar).Value = Temp.InnerFunction;
                cmd.Parameters.Add("@InnerCss", SqlDbType.VarChar).Value = Temp.InnerCss;
                cmd.Parameters.Add("@ApplicationId", SqlDbType.Int).Value = Temp.ApplicationId;
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

        public void UpdatePage(ApplicationPages Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_PAGE";
                cmd.Parameters.Add("@PageId", SqlDbType.Int).Value = Temp.PageId;
                cmd.Parameters.Add("@PageTitle", SqlDbType.VarChar).Value = Temp.PageTitle;
                cmd.Parameters.Add("@Url", SqlDbType.VarChar).Value = Temp.Url;
                cmd.Parameters.Add("@InnerFunction", SqlDbType.VarChar).Value = Temp.InnerFunction;
                cmd.Parameters.Add("@InnerCss", SqlDbType.VarChar).Value = Temp.InnerCss;
                cmd.Parameters.Add("@ApplicationId", SqlDbType.Int).Value = Temp.ApplicationId;
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

        #endregion PAGES
        #region MENU_PAGES
        public List<MenuPages> GetUnAssignedPages(int MenuId,int ApplicationId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_UN_ASSIGNED_PAGES";
                cmd.Parameters.Add("@MenuId", SqlDbType.Int).Value = MenuId;
                cmd.Parameters.Add("@ApplicationId", SqlDbType.Int).Value = ApplicationId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                List<MenuPages> mp = null;
                if (dr.HasRows)
                {
                    mp = new List<MenuPages>();
                    while (dr.Read())
                    {
                        MenuPages Temp = new MenuPages();
                        Temp.PageId = Convert.ToInt32(dr["PAGE_ID"]);
                        Temp.PageTitle = Convert.ToString(dr["PAGE_TITLE"]);
                        mp.Add(Temp);
                    }
                }

                if (mp != null) mp.TrimExcess();
                return mp;
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
                cmd.Parameters.Add("@MenuId", SqlDbType.Int).Value = MenuId;
              
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                List<MenuPages> mp = null;
                if (dr.HasRows)
                {
                    mp = new List<MenuPages>();
                    while (dr.Read())
                    {
                        MenuPages Temp = new MenuPages();
                        Temp.PageId = Convert.ToInt32(dr["PAGE_ID"]);
                        Temp.PageTitle = Convert.ToString(dr["PAGE_TITLE"]);
                        mp.Add(Temp);
                    }
                }

                if (mp != null) mp.TrimExcess();
                return mp;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertMenuPage(int PageId,int MenuId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                int ID = new DalHelper().GetPk("MAN_MENU_PAGES", "MENU_PAGE_ID");
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_MENU_PAGE";
                cmd.Parameters.Add("@MenuPageId", SqlDbType.Int).Value = ID;
                cmd.Parameters.Add("@PageId", SqlDbType.Int).Value = PageId;
                cmd.Parameters.Add("@MenuId", SqlDbType.Int).Value = MenuId;
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

        public void DeleteMenuPage(int PageId,int MenuId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[USERMANAGEMENT_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_MENU_PAGE";
                cmd.Parameters.Add("@PageId", SqlDbType.Int).Value = PageId;
                cmd.Parameters.Add("@MenuId", SqlDbType.Int).Value = MenuId;
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

        #endregion MENU_PAGES






    }
}

   