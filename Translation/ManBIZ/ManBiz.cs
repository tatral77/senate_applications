using ManDAL;
using ManEntities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using Entities;
using DAL;

namespace ManBIZ
{
    public class ManBiz
    {
        public User ValidateUser(string UserName, string Password, int ApplicationId)
        {
            return new ManDal().ValidateUser(UserName, Password, ApplicationId);
        }
        public List<User> GetApplicationUsers(int ApplicationId)
        {
            return new ManDal().GetApplicationUsers(ApplicationId);
        }
        public List<User> GetApplicationUsersByRole(int ApplicationId, string RoleName)
        {
            return new ManDal().GetApplicationUsersByRole(ApplicationId, RoleName);
        }
        public List<UsersWithBusiness> GetApplicationUsersByBusinessAssigned(int ApplicationId, string RoleName)
        {
            return new ManDal().GetApplicationUsersByBusinessAssigned(ApplicationId, RoleName);
        }
        //public List<Menus> GetRoleActiveMenus(int RoleId)
        //{

        //}

        //public List<MenuPages> GetMenuPages(int MenuId)
        //{

        //}
        #region USER
        public List<User> GetUsers(int ApplicationId)
        {
            return new ManDal().GetUsers(ApplicationId);
        }

        public User GetUser(int UserId)
        {
            return new ManDal().GetUser(UserId);
        }
        public User GetUser(string UserName, string Password)
        {
            return new ManDal().GetUser(UserName, Password);
        }
        public void InsertUser(User Temp)
        {
            new ManDal().InsertUser(Temp);
        }

        public void UpdateUser(User Temp)
        {
            new ManDal().UpdateUser(Temp);
        }
        #endregion USER TYPES

    }
}
