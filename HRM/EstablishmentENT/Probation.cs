using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class Probation
    {
        public int? ProbationId { get; set; }
        public int EmploymentHistId { get; set; }
        public int SystemUserId { get; set; }
        public int PromotionId { get; set; }
        public DateTime? ProbationFrom { get; set; }
        public DateTime? ProbationTo { get; set; }
        public int ProbationTypeId { get; set; }
        public string ProbationType { get; set; }
        public int IsExtended { get; set; }
        public DateTime ExtendedTo { get; set; }
        public string Remarks { get; set; }
    }
}
