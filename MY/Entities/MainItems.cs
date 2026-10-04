using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MainItems
    {
        public int MainItemId { get; set; }
        public string MainItem { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int IsActive { get; set; }

    }
}
