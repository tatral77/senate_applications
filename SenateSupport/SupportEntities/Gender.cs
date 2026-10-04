using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportEntities
{
    public class Gender
    {
        public int GenderId { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
        public static object SelectedValue { get; set; }
    }
}
