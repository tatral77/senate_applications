
using ManDAL;
using ManEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManBIZ
{
    public class ManBiz
    {
        public User ValidateUser(string UserName, string Password, int ApplicationId)
        {
            return new ManDal().ValidateUser(UserName, Password, ApplicationId);
        }
        public User GetUser(int UserId)
        {
            return new ManDal().GetUser(UserId);
        }


            //public List<Menus> GetRoleActiveMenus(int RoleId)
            //{

            //}

            //public List<MenuPages> GetMenuPages(int MenuId)
            //{

            //}
        }
}
