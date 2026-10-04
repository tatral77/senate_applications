using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisEntities
{
    public class Divisions
    {
        public int DivisionsId { get; set; }
        public string Description { get; set; }
        public int MinistriesId { get; set; }
        public string Ministry { get; set; }
        public Ministries Ministries { get; set; }
        public int IsActive { get; set; }
        public ICollection<Bills> Bills {get;set;}
    }
}
