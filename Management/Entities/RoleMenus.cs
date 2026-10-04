using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RoleMenus
    {
        public int RoleMenuId { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        public int MenuId { get; set; }
        public string Menu { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public List<SubMenus> Submenus { get; set; }
        public int IsActive { get; set; }
    }
}
