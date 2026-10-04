using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class SecurityClearance
    {
        public int SecurityClearanceId { get; set; }
        public int SystemUserId { get; set; }
        public int SecClearanceTypeId { get; set; }
        public string SecClearanceType { get; set; }
        public int PostId { get; set; }
        public string Post { get; set; }
        public int BPSID { get; set; }
        public string BPS { get; set; }
        public DateTime OnDate { get; set; }
        public string Remarks { get; set; }
        public int UpdatedBy { get; set; }
        public int InsertedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime InsertedOn { get; set; }
    }
}
