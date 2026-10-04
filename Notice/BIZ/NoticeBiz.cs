using DAL;
using Entities;
using System;
using System.Collections.Generic;

namespace BIZ
{
    public class NoticeBiz
    {
        public List<MemberAttendance> GetActiveMembersAttendance(int SessionSittingId)
        {
            return new NoticeDal().GetActiveMembersAttendance(SessionSittingId);
        }
        public void AddMembersAttendances(List<MemberAttendance> memberAttendances, int sessionSittingId)
        {
            new NoticeDal().AddMembersAttendances(memberAttendances, sessionSittingId);
        }
		#region Notice Summary
		public List<NoticeSummaryEnt> GetQuestionNoticeSummary(DateTime FromDate, DateTime ToDate)
		{
			return new NoticeDal().GetQuestionNoticeSummary(FromDate, ToDate);
		}
		public List<NoticeSummaryEnt> GetMotionNoticeSummary(DateTime FromDate, DateTime ToDate)
		{
			return new NoticeDal().GetMotionNoticeSummary(FromDate, ToDate);
		}
		public List<NoticeSummaryEnt> GetResolutionNoticeSummary(DateTime FromDate, DateTime ToDate)
		{
			return new NoticeDal().GetResolutionNoticeSummary(FromDate, ToDate);
		}
        #endregion

        #region Member Leave
        public List<MemberLeaveApplication> GetSessionLeaveRequests(int SessionId)
        {
            return new NoticeDal().GetSessionLeaveRequests(SessionId);
        }
        public void UpdateLeaverequest(int LeaveRequestId, DateTime ApprovalDate, string NoticeComments)
        {
            new NoticeDal().UpdateLeaverequest(LeaveRequestId, ApprovalDate, NoticeComments);

        }
        #endregion
        #region Bills
        public List<Bills> GetNoticeBills()
        {
            return new NoticeDal().GetNoticeBills();
        }
            #endregion

        }
}
