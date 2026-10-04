using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class EmpRetirement
    {
        public int EmpRetirementId { get; set; }
        public int SystemUserId { get; set; }
        public int RetirementTypeId { get; set; }
        public string RetirementType { get; set; }
        public int RetirementModeId { get; set; }
        public string RetirementMode { get; set; }
        public DateTime RetirementDate { get; set; }
        public string Remarks { get; set; }
        public int UpdatedBy { get; set; }
        public int InsertedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime InsertedOn { get; set; }
    }
}
