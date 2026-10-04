using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MemberLeaveApplication
    {
        public int LeaveApplicationId { get; set; }
        public  DateTime    SubmissionDate { get; set; }
        public string NoticeComments { get; set; }
        public int IsSessionLeave { get; set; }
        public int MemberId { get; set; }
        public DateTime LeaveAppliedFrom { get; set; }
        public DateTime LeaveAppliedTo { get; set; }
        public int LeaveTypeId { get; set; }
        public string SessionNumber { get; set; }
        public int SessionSittingId { get; set; }
        public DateTime CalledInHouseOn { get; set; }
        public string Purpose { get; set; }
        public string ApplicationUrl { get; set; }
        public string MemberName { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
