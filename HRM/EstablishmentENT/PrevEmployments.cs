using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class PrevEmployments
    {
        public int EmpPrevEmplId { get; set; }
        public int SystemUsersId { get; set; }
        public string Organization { get; set; }
        public string Department { get; set; }
        public string Post { get; set; }
        public int BPSID { get; set; }
        public string BPS { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Remarks { get; set; }
        public int UpdatedBy { get; set; }
        public int InsertedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime InsertedOn { get; set; }
    }
}
