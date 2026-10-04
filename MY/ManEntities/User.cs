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
        public int SystemUsersId { get; set; }
        public string PersonalNumber { get; set; }
        public int BranchId { get; set; }
        public int PostId { get; set; }
        public string FullName { get; set; }
        public int ApplicationId { get; set; }
        public int RoleId { get; set; }
        public int UserTypeId { get; set; }
        public string UserCss { get; set; }
        public List<Menus> UserMenus { get; set; }
    }
}
