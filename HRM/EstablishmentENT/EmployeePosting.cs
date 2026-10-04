using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class EmployeePosting
    {
        public int Emp_Posting_id { get; set; }
        public int System_Users_Id { get; set; }
        public int PostId { get; set; }
        public string Post { get; set; }
        public int BPS { get; set; }
        public string BPSDesc { get; set;}
        //public string From_Branch { get; set; }
        //public string To_Branch { get; set; }
        public int BranchId { get; set; }
        public string Branch { get; set; }
        public List<AdditionalBranchesEnt> AdditionalBranches { get; set; }
        public string AddtionalBranchesNames { get; set; }
        public DateTime Date_From { get; set; }
        public DateTime Date_To { get; set; }
        public int Working { get; set; }
        public string Remarks { get; set; }
        public int UpdatedBy { get; set; }
        public int InsertedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime InsertedOn { get; set; }
    }
}
