using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class PopProbation
    {
        public int SystemUsersId { get; set; }
        public string EmployeeName { get; set; }
        public string Post { get; set; }
        public string Bps { get; set; }
        public string EmployeeStatus { get; set; }
        public string ProbationType { get; set; }
        public DateTime ProbationEndDate { get; set; }
        public string Remarks { get; set; }
        public int UpdatedBy { get; set; }
        public int InsertedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime InsertedOn { get; set; }
    }
}
