using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
   public class EmpHeaderInfo
    {
        public string EmpName { get; set; }
        public string EmpStatus { get; set; }
        public string POST { get; set; }
        public string BPS { get; set; }
        public List<AdditionalBranchesEnt> AdditionalBranches { get; set; }
        public string BRANCH { get; set; }
        public string EmploymentStatus { get; set; }
        public string CurrentStatus { get; set; }
    }
}
