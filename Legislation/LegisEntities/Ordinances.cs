using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisEntities
{
    public class Ordinances
    {
        public int OrdinanceId { get; set; }
        public string Title { get; set; }
        public DateTime DateOfPromulgation { get; set; }
        public DateTime DateOfLaying { get; set; }
        public string Remarks { get; set; }
        public int ParliamentaryYearsId { get; set; }
        public int AssemblySessionsId { get; set; }
        public int OrdinanceStatusId { get; set; }
        public DateTime StatusDate { get; set; }
        public ParliamentaryYears ParliamentaryYears { get; set; }
        public AssemblySessions AssemblySessions { get; set; }
        public OrdinanceStatuses OrdinanceStatuses { get; set; }
        public List<OrdinanceDocuments> BillDocumentsEnt { get; set; }
        public List<OrdinanceStatusHistory> OrdinanceStatusHistories { get; set; }
    }
}
