using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class RegularEmployee:EmpHistory
    {
        public DateTime ProbationTo { get; set; }
        public DateTime ProbationFrom { get; set; }

    }
}
