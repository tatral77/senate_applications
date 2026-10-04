using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisEntities
{
    class BillAmendments
    {
        public int BillAmendmenstsId { get; set; }
        public int BillDetailsId { get; set; }
        public int SystemUsersId { get; set; }
        public DateTime AmendmentDate { get; set; }
        public int AmendmentStatusesId { get; set; }
        public string Amendment { get; set; }
        public int NoticeDiaryNo { get; set; }
        public DateTime NoticeDiaryDate { get; set; }
        public int LegislationDairyNo { get; set; }
        public DateTime LegislationDiaryDate { get; set; }
        public DateTime NoticeDiaryTime { get; set; }
        public DateTime LegislationDiaryTime { get; set; }
        public int AmendmentStagesId { get; set; }
        public String CurrentRole { get; set; }
        public int IsAccepted { get; set; }
        public int YesVotes { get; set; }
        public int NoVotes { get; set; }
        public int NotVoted { get; set; }
        public DateTime VotingDate { get; set; }
        public int Absents { get; set; }

    }
}
