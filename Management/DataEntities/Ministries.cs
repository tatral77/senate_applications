using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities
{
    public class Ministries
    {
        public int MinistriesId { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
        public int IsFedMin { get; set; }
        public int IsStatMin { get; set; }
    }
}
