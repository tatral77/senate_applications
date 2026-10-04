using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    public class ManagementBiz
    {
        #region Application
        public List<ApplicationEnt> GetApplications()
        {
            return new ManagementDal().GetApplications();
        }

        public ApplicationEnt GetApplication(int ApplicationId)
        {
            return new ManagementDal().GetApplication(ApplicationId);
        }
        public void InsertApplication(ApplicationEnt Temp)
        {
            new ManagementDal().InsertApplication(Temp);
        }
        #endregion APPLICATION
            #region MENU
        public List<MenuesEnt> GetMenus(int ApplicationId)
        {
            return new ManagementDal().GetMenus(ApplicationId);
        }

        public MenuesEnt GetMenu(int MenuId)
        {
            return new ManagementDal().GetMenu(MenuId);
        }
        public List<MenuesEnt> GetUnAssignedRoleMenus(int RoleId, int ApplicationId)
        {
            return new ManagementDal().GetUnAssignedRoleMenus(RoleId, ApplicationId);
        }
        public void InsertMenu(MenuesEnt Temp)
        {
            new ManagementDal().InsertMenu(Temp);
        }

        public void UpdateMenu(MenuesEnt Temp)
        {
            new ManagementDal().UpdateMenu(Temp);
        }
        #endregion MENU

        #region SUB_MENU
        public List<SubMenus> GetSubMenus()
        {
            return new ManagementDal().GetSubMenus();
        }
        public List<SubMenus> GetMenuSubMenus(int MenuId)
        {
            return new ManagementDal().GetMenuSubMenus(MenuId);
        }
        public List<SubMenus> GetMenuActiveSubMenus(int MenuId)
        {
            return new ManagementDal().GetMenuActiveSubMenus(MenuId);
        }

        public SubMenus GetSubMenu(int SubMenuId)
        {
            return new ManagementDal().GetSubMenu(SubMenuId);
        }
        public void InsertSubMenu(SubMenus Temp)
        {
            new ManagementDal().InsertSubMenu(Temp);
        }

        public void UpdateSubMenu(SubMenus Temp)
        {
            new ManagementDal().UpdateSubMenu(Temp);
        }
        #endregion SUB_MENU

        #region ROLE
        public List<Role> GetApplicationRoles(int ApplicationId)
        {
            return new ManagementDal().GetApplicationRoles(ApplicationId);
        }

        public Role GetRole(int RoleId)
        {
            return new ManagementDal().GetRole(RoleId);
        }
        public void InsertRole(Role Temp)
        {
            new ManagementDal().InsertRole(Temp);
        }

        public void UpdateRole(Role Temp)
        {
            new ManagementDal().UpdateRole(Temp);
        }
        #endregion ROLE

        #region ROLE_MENU
        public List<RoleMenus> GetRoleMenus(int RoleId)
        {
            return new ManagementDal().GetRoleMenus(RoleId);
        }
        public List<RoleMenus> GetRoleActiveMenus(int RoleId)
        {
            return new ManagementDal().GetRoleActiveMenus(RoleId);
        }

        public void InsertRoleMenu(RoleMenus Temp)
        {
            new ManagementDal().InsertRoleMenu(Temp);
        }

        public void UpdateRoleMenu(RoleMenus Temp)
        {
            new ManagementDal().UpdateRoleMenu(Temp);
        }
        public void DeleteRoleMenu(int RoleId, int MenuId)
        {
            new ManagementDal().DeleteRoleMenu(RoleId,MenuId);
        }
        #endregion ROLE_MENU

            #region USER_TYPE
        public List<UserTypes> GetUserTypes()
        {
            return new ManagementDal().GetUserTypes();
        }

        public UserTypes GetUserType(int UserTypeId)
        {
            return new ManagementDal().GetUserType(UserTypeId);
        }
        public void InsertUserType(UserTypes Temp)
        {
            new ManagementDal().InsertUserType(Temp);
        }

        public void UpdateUserType(UserTypes Temp)
        {
            new ManagementDal().UpdateUserType(Temp);
        }
        #endregion USER TYPES

        #region USER
        public List<Users> GetUsers(int ApplicationId)
        {
            return new ManagementDal().GetUsers(ApplicationId);
        }

        public Users GetUser(int UserId)
        {
            return new ManagementDal().GetUser(UserId);
        }
        public Users GetUser(string UserName, string Password)
        {
            return new ManagementDal().GetUser(UserName, Password);
        }
        public void InsertUser(Users Temp)
        {
            new ManagementDal().InsertUser(Temp);
        }

        public void UpdateUser(Users Temp)
        {
            new ManagementDal().UpdateUser(Temp);
        }
        #endregion USER TYPES
        #region MENU POSITIONS
        public List<MenuPositionEnt> GetMenuPositions()
        {
            return new ManagementDal().GetMenuPositions();
        }

        public MenuPositionEnt GetMenuPosition(int MenuPositionId)
        {
            return new ManagementDal().GetMenuPosition(MenuPositionId);
        }
        #endregion MENU POSITIONS
        #region PAGES
        public List<ApplicationPages> GetPages(int ApplicationId)
        {
            return new ManagementDal().GetPages(ApplicationId);
        }

        public ApplicationPages GetPage(int PageId)
        {
            return new ManagementDal().GetPage(PageId);
        }
        public void InsertPage(ApplicationPages Temp)
        {
            new ManagementDal().InsertPage(Temp);
        }

        public void UpdatePage(ApplicationPages Temp)
        {
            new ManagementDal().UpdatePage(Temp);
        }

        #endregion PAGES.
        #region MENU_PAGES
        public List<MenuPages> GetUnAssignedPages(int MenuId,int ApplicationId)
        {
            return new ManagementDal().GetUnAssignedPages(MenuId,ApplicationId);
        }
        public List<MenuPages> GetMenuPages(int MenuId)
        {
            return new ManagementDal().GetMenuPages(MenuId);
        }
        public void InsertMenuPage(int PageId, int MenuId)
        {
           new ManagementDal().InsertMenuPage(PageId, MenuId);
        }

        public void DeleteMenuPage(int PageId, int MenuId)
        {
            new ManagementDal().DeleteMenuPage(PageId, MenuId);
        }

        #endregion MENU_PAGES

    }
}
