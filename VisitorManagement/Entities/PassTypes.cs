using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class PassTypes
    {
       

        public int PassTypeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<VisitorPasses> VisitorPasses { get; set; }
    }
}
