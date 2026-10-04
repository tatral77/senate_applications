using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Divisions
    {
        public int DivisionsId { get; set; }
        public string Description { get; set; }
        public int MinistriesId { get; set; }
        public string Ministry { get; set; }
        public int IsActive { get; set; }
    }
}
