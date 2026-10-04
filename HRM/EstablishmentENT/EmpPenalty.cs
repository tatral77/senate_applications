using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
   public  class EmpPenalty
    {
        public int PenaltyId { get; set; }
        public int DisciplinaryActionId { get; set; }
        public int SystemUsersId { get; set; }
        public int PenaltyTypeId { get; set; }
        public string PenaltyType { get; set; }
        public DateTime PenaltyDate { get; set; }
        public DateTime PenaltyFrom { get; set; }
        public DateTime PenaltyTo { get; set; }
        public int IsMajor { get; set; }
        public string Remarks { get; set; }
        public int UpdatedBy { get; set; }
        public int InsertedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime InsertedOn { get; set; }

    }
}
