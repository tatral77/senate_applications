using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportEntities
{
    public class Relations
    {
        public int RelationsId { get; set; }
        public string RelationName { get; set; }
        public string Gender { get; set; }
        public int SortOrder { get; set; }
    }
}
