using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Requisitions
    {
        public int RequisitionId { get; set; }
        public int SystemUsersId { get; set; }
        public string EmployeeName { get; set; }
        public int PostId { get; set; }
        public string Post { get; set; }
        public int BranchId { get; set; }
        public string Branch { get; set; }
        public int RequisitionBy { get; set; }
        public int Items { get; set; }
        public DateTime RequisitionDate { get; set; }
        public int ReqMonth { get; set; }
        public int ReqYear { get; set; }

    }
}
