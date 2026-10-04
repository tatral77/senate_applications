using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MenuPages
    {
        public int MenuPageId { get; set; }
        public int MenuId { get; set; }
        public string Menu { get; set; }
        public int PageId { get; set; }
        public int SortOrder { get; set; }
        public string PageTitle { get; set; }
    }
}
