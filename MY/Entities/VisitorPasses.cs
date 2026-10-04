using System;
using System.Collections.Generic;

namespace Entities
{
    public class VisitorPasses
    {
        public int PassId { get; set; }
        public string PassCode { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        //public TimeSpan VisitTime { get; set; }
        public string VisitTime { get; set; }
        public string VisitPurpose { get; set; }
        public int RequestedById { get; set; }
        public string RequestedBy { get; set; }
        public DateTime PassDate { get; set; }
        public string Post { get; set; }
        public string Bps { get; set; }
        public int PassTypeId { get; set; }
        public string Remarks { get; set; }
        public int IsActive { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public Companies Company { get; set; }
        public virtual PassTypes PassTypes { get; set; }
        public int Saturday { get; set; }
        public int Sunday { get; set; }
        public int Verified { get; set; }
        public virtual ICollection<Visitors> Visitors { get; set; }
    }
}
