using System.Collections.Generic;
namespace ManEntities
{
    public class Menus
    {
        public int MenuId { get; set; }
        public string Menu { get; set; }
        public string Url { get; set; }
        public string InnerFunction { get; set; }
        public string InnerCss { get; set; }
        public List<MenuPages> menuPages { get; set; }
        public int MenuPosition { get; set; }
        public int SortOrder { get; set; }
    }
}
