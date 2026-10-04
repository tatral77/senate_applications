using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisEntities
{
    class BillDetails
    {
        public int BillDetailsId { get; set; }
        public int ParentId { get; set; }
        public String DetailHeading { get; set; }
        public int BillDetailTypesId { get; set; }
        public int IsAccepted { get; set; }
        public int YesVotes { get; set; }
        public int NoVotes { get; set; }
        public int NotVoted { get; set; }
        public int NoticeDiaryNo { get; set; }
        public DateTime NoticeDiaryDate { get; set; }
        public int LegislationDiaryNo { get; set; }
        public DateTime LegislationDiaryDate { get; set; }
        public string ProvisoNote { get; set; }
        public string Explanation { get; set; }
        public String Schedule { get; set; }
        public string BillDetailCategories { get; set; }
        public DateTime VotingDate { get; set; }
        public string Definition { get; set; }
        public int Absents { get; set; }
        public int ClauseNo { get; set; }
        public int BillContentsId { get; set; }
        public int IsLatestVersion { get; set; }
        public int RolesId { get; set; }
        public int BillVersionTypesId { get; set; }
        public string Dtext { get; set; }
        public string DetailText { get; set; }
    }
}
