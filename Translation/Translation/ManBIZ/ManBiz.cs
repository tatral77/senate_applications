using ManDAL;
using ManEntities;

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
