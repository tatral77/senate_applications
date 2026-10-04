using System.Collections.Generic;

namespace ManEntities
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public int ApplicationId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int UserTypeId { get; set; }
        public string UserCss { get; set; }
        public List<Menus> UserMenus { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int IsActive { get; set; }
        public string Application { get; set; }
        public string Role { get; set; }
        public string UserType { get; set; }
    }
}
