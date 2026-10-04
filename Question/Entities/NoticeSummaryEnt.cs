using MotionEntities;
using System;
using System.Collections.Generic;

namespace Entities
{
    public class NoticeSummaryEnt
    {
        public int BusinessId { get; set; }
        public int NoticeOfficeDiaryNo { get; set; }
        public DateTime NotiiceOfficeDate { get; set; }
        public DateTime NoticeOfficeTime { get; set; }
        public int BranchAssignedId { get; set; }
        public string AssemblySession { get; set; }
        public string BusinessText { get; set; }
        public string BusinessType { get; set; }
        public string BusinessFile { get; set; }
        public string Mover { get; set; }
        public List<MotionMoversEnt> Movers { get; set; }
        public int Checked { get; set; }
        public int Processed { get; set; }

    }
}
