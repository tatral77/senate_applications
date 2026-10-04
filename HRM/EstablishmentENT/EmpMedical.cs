using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class EmpMedical
    {
        public int EmpMedicalId { get; set; }
        public int SystemUserId { get; set; }
        public int BPSID { get; set; }
        public string BPS { get; set; }
        public int PostId { get; set; }
        public string Post { get; set; }
        public DateTime OnDate { get; set; }
        public int MedicalTypeId { get; set; }
        public string MedicalType { get; set; }
        public int MedYear { get; set; }
        public int IsSubmitted{ get; set; }
        public string Remarks { get; set; }
        public int UpdatedBy { get; set; }
        public int InsertedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime InsertedOn { get; set; }

    }
}
