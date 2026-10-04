using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManEntities
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public int ApplicationId { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        public int UserTypeId { get; set; }
        public string UserType { get; set; }
        public string UserCss { get; set; }
        public List<Menus> UserMenus { get; set; }
    }
}
