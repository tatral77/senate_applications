using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SubMenus
    {
        public int SubMenuId { get; set; }
        public string SubMenu { get; set; }
        public int MenuId { get; set; }
        public int SortOrder { get; set; }
        public string Url { get; set; }
        public int IsActive { get; set; }

    }
}
