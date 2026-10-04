using System;
using System.Collections.Generic;
using System.Text;

namespace VmsEntities
{
    public class PassTypes
    {
       

        public int PassTypeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<VisitorPasses> VisitorPasses { get; set; }
    }
}
