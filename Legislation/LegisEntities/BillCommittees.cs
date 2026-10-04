using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisEntities
{
    class BillCommittees
    {
        public int BillCommitteesId { get; set; }
        public int BillsId { get; set; }
        public int CommitteesId { get; set; }
        public String Report { get; set; }
        public string ReportSubject { get; set; }
        public DateTime CommitteeRefferdDate { get; set; }
        public DateTime TentativeDate { get; set; }
        public DateTime ActualReportBackDate { get; set; }
        public DateTime ReportPresentationDate { get; set; }
        public DateTime PublicationDate { get; set; }
        public String CondonencePeriod { get; set; }
    }
}
