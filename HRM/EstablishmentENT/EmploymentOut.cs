using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class EmploymentOut
    {
        public int EmploymentOutId { get; set; }
        public int EmploymentHistoryId { get; set; }
        public int SystemUsersId { get; set; }
        public int EmploymentOutTypeId { get; set; }
        public string EmploymentOutType { get; set; }
        public DateTime FromDate { get; set; }
        public int OutBps { get; set; }
        public string OutBpsDesc { get; set; }
        public int OutPost { get; set; }
        public string OutPostDesc { get; set; }
        public int InBps { get; set; }
        public string InBpsDesc { get; set; }
        public int InPost { get; set; }
        public string InPostDesc { get; set; }
        public DateTime ToDate { get; set; }
        public int IsExtended { get; set; }
        public int IsActive { get; set; }
        public string Remarks { get; set; }
        public int UpdatedBy { get; set; }
        public int InsertedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime InsertedOn { get; set; }

    }
}
