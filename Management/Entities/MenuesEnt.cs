using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MenuesEnt
    {
        public int MenuId { get; set; }
        public string Menu { get; set; }
        public string Description { get; set; }
        public int ApplicationId { get; set; }
        public int MenuPositionId { get; set; }
        public string MenuPosition { get; set; }
        public string  Application { get; set; }
        public string InnerFunction { get; set; }
        public string InnerCss { get; set; }
        public int SortOrder { get; set; }
        public string Url { get; set; }
        public int IsActive { get; set; }
    }
}
