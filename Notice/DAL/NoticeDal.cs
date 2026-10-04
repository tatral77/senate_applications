using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class NoticeDal
    {
        public List<Member> GetActiveMembers()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Members_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_MEMBERS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Member> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Member>();
                    while (dr.Read())
                    {
                        Member Temp = new Member();

                        Temp.MemberId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        Temp.MemberName = Convert.ToString(dr["F_NAME"]);
                        Temp.IsActive = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<MemberAttendance> GetActiveMembersAttendance(int SessionSittingId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_MEMBERS_ATTENDANCE";
                cmd.Parameters.Add("@SessionSittingId", SqlDbType.Int).Value = SessionSittingId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<MemberAttendance> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<MemberAttendance>();
                    while (dr.Read())
                    {
                        MemberAttendance Temp = new MemberAttendance();
                        Temp.MemberId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        Temp.MemberName = Convert.ToString(dr["F_NAME"]);
                        if (dr["ATTENDANCE"] != DBNull.Value)
                            Temp.AttendanceStatusId = Convert.ToInt32(dr["ATTENDANCE"]);
                        MyList.Add(Temp);
                    }
                }
                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public void AddMembersAttendances(List<MemberAttendance> memberAttendances, int sessionSittingId)
        {
            DeleteMembersAttendance(sessionSittingId);
            string query = string.Empty;
            foreach (MemberAttendance memberAttendance in memberAttendances)
            {
                query = query + "INSERT INTO MEMBER_ATTENDANCES(SESSION_SITTINGS_ID,ATTENDANCE_STATUSES_ID,SYSTEM_USERS_ID) VALUES";
                query = query + "(" + memberAttendance.SessionSittingId + "," + memberAttendance.AttendanceStatusId + "," + memberAttendance.MemberId + ");";
            }
            if (!String.IsNullOrEmpty(query))
            {
                SqlConnection con = new DalHelper().GetConnection();
                try
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    using (con)
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();
                    }
                }
                catch
                {

                }
            }
        }
        public void DeleteMembersAttendance(int SessionSittingId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_MEMBERS_ATTENDANCES";
                cmd.Parameters.Add("@SessionSittingId", SqlDbType.Int).Value = SessionSittingId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
            }
            finally
            {
                con.Close();

            }
        }
		#region Notice Summary
		public List<NoticeSummaryEnt> GetQuestionNoticeSummary(DateTime FromDate, DateTime ToDate)
		{
			SqlConnection con = new DalHelper().GetConnection();
			try
			{

				SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
				cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_NOTICE_QUESTION_SUMMARY";
				cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = FromDate;
				cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = ToDate;
				cmd.CommandType = CommandType.StoredProcedure;
				List<NoticeSummaryEnt> MyList = null;
				SqlDataReader dr = cmd.ExecuteReader();
				if (dr.HasRows)
				{
					MyList = new List<NoticeSummaryEnt>();
					while (dr.Read())
					{
						NoticeSummaryEnt Temp = new NoticeSummaryEnt();
						Temp.NoticeOfficeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
						Temp.NotiiceOfficeDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
						Temp.NoticeOfficeTime = Convert.ToDateTime(dr["NOTICE_DIARY_TIME"]);
						Temp.AssemblySession = Convert.ToString(dr["SESSION_DESC"]);
						//Temp.BranchAssignedId = Convert.ToInt32(dr["FROM_SESSION"]);
						Temp.BusinessText = Convert.ToString(dr["BUSINESS_TEXT"]);
						Temp.BusinessFile = Convert.ToString(dr["BUSINESS_FILE"]);
						Temp.BusinessType = Convert.ToString(dr["BUSINESS_TYPE"]);
						Temp.Mover = Convert.ToString(dr["MOVER"]);
						Temp.Checked = Convert.ToInt32(dr["CHECKED"]);
						Temp.Processed = Convert.ToInt32(dr["PROCESSED"]);
						MyList.Add(Temp);
					}
				}

				if (MyList != null) MyList.TrimExcess();
				return MyList;
			}
			finally
			{
				con.Close();

			}
		}
		public List<NoticeSummaryEnt> GetMotionNoticeSummary(DateTime FromDate, DateTime ToDate)
		{
			SqlConnection con = new DalHelper().GetConnection();
			try
			{

				SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
				cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_NOTICE_MOTION_SUMMARY";
				cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = FromDate;
				cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = ToDate;
				cmd.CommandType = CommandType.StoredProcedure;
				List<NoticeSummaryEnt> MyList = null;
				SqlDataReader dr = cmd.ExecuteReader();
				if (dr.HasRows)
				{
					MyList = new List<NoticeSummaryEnt>();
					while (dr.Read())
					{
						NoticeSummaryEnt Temp = new NoticeSummaryEnt();
						Temp.BusinessId = Convert.ToInt32(dr["BUSINESS_ID"]);
						Temp.NoticeOfficeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
						Temp.NotiiceOfficeDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
						Temp.NoticeOfficeTime = Convert.ToDateTime(dr["NOTICE_DIARY_TIME"]);
						Temp.AssemblySession = Convert.ToString(dr["SESSION_DESC"]);
						//Temp.BranchAssignedId = Convert.ToInt32(dr["FROM_SESSION"]);
						Temp.BusinessText = Convert.ToString(dr["BUSINESS_TEXT"]);
						Temp.BusinessFile = Convert.ToString(dr["BUSINESS_FILE"]);
						Temp.BusinessType = Convert.ToString(dr["BUSINESS_TYPE"]);
						Temp.Mover = Convert.ToString(dr["MOVERS"]);
						Temp.Checked = Convert.ToInt32(dr["CHECKED"]);
						Temp.Processed = Convert.ToInt32(dr["PROCESSED"]);
						if (!String.IsNullOrEmpty(Temp.Mover))
						{
							Temp.Movers = new List<MotionMoversEnt>();
							Temp.Movers = new MotionDal().GetMotionMovers(Temp.Mover, Temp.BusinessId);
						}
						if(Temp.Movers!=null)
                        {
							Temp.Mover = "";
							foreach (MotionMoversEnt mm in Temp.Movers)
							{
								Temp.Mover = Temp.Mover + mm.MoverName + ",";

							}
						}	
						MyList.Add(Temp);
					}
				}

				if (MyList != null) MyList.TrimExcess();
				return MyList;
			}
			finally
			{
				con.Close();

			}
		}
		public List<NoticeSummaryEnt> GetResolutionNoticeSummary(DateTime FromDate, DateTime ToDate)
		{
			SqlConnection con = new DalHelper().GetConnection();
			try
			{

				SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
				cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_NOTICE_RESOLUTION_SUMMARY";
				cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = FromDate;
				cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = ToDate;
				cmd.CommandType = CommandType.StoredProcedure;
				List<NoticeSummaryEnt> MyList = null;
				SqlDataReader dr = cmd.ExecuteReader();
				if (dr.HasRows)
				{
					MyList = new List<NoticeSummaryEnt>();
					while (dr.Read())
					{
						NoticeSummaryEnt Temp = new NoticeSummaryEnt();
						Temp.BusinessId = Convert.ToInt32(dr["BUSINESS_ID"]);
						Temp.NoticeOfficeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
						Temp.NotiiceOfficeDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
						Temp.NoticeOfficeTime = Convert.ToDateTime(dr["NOTICE_DIARY_TIME"]);
						Temp.AssemblySession = Convert.ToString(dr["SESSION_DESC"]);
						//Temp.BranchAssignedId = Convert.ToInt32(dr["FROM_SESSION"]);
						Temp.BusinessText = Convert.ToString(dr["BUSINESS_TEXT"]);
						Temp.BusinessFile = Convert.ToString(dr["BUSINESS_FILE"]);
						Temp.BusinessType = Convert.ToString(dr["BUSINESS_TYPE"]);
						Temp.Mover = Convert.ToString(dr["MOVERS"]);
						Temp.Checked = Convert.ToInt32(dr["CHECKED"]);
						Temp.Processed = Convert.ToInt32(dr["PROCESSED"]);
						if (!String.IsNullOrEmpty(Temp.Mover))
						{
							Temp.Movers = new List<MotionMoversEnt>();
							Temp.Movers = new MotionDal().GetMotionMovers(Temp.Mover, Temp.BusinessId);
						}
						if (Temp.Movers != null)
						{
							Temp.Mover = "";
							foreach (MotionMoversEnt mm in Temp.Movers)
							{
								Temp.Mover = Temp.Mover + mm.MoverName + ",";

							}
						}
						MyList.Add(Temp);
					}
				}

				if (MyList != null) MyList.TrimExcess();
				return MyList;
			}
			finally
			{
				con.Close();

			}
		}
		#endregion
		#region Member Leaves


		public List<MemberLeaveApplication> GetSessionLeaveRequests(int SessionId)
		{
			SqlConnection con = new DalHelper().GetConnection();
			try
			{

				SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
				cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SESSION_LEAVE_REQUESTS";
				cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = SessionId;
				cmd.CommandType = CommandType.StoredProcedure;
				List<MemberLeaveApplication> MyList = null;
				SqlDataReader dr = cmd.ExecuteReader();
				if (dr.HasRows)
				{
					MyList = new List<MemberLeaveApplication>();
					while (dr.Read())
					{
						MemberLeaveApplication Temp = new MemberLeaveApplication();
						Temp.LeaveApplicationId = Convert.ToInt32(dr["LEAVE_ID"]);
						Temp.MemberId = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
						Temp.LeaveTypeId = Convert.ToInt32(dr["LEAVE_TYPES_ID"]);
						Temp.SessionNumber = Convert.ToString(dr["SESSION_NUMBER"]);
						if (dr["SUBMISSION_DATE"] != DBNull.Value)
							Temp.SubmissionDate = Convert.ToDateTime(dr["SUBMISSION_DATE"]);
						if (dr["APPROVAL_DATE"] != DBNull.Value)
							Temp.ApprovalDate = Convert.ToDateTime(dr["APPROVAL_DATE"]);
						Temp.MemberName = Convert.ToString(dr["F_NAME"]);
						Temp.IsSessionLeave = Convert.ToInt32(dr["IS_SESSION_LEAVE"]);
						Temp.LeaveType = Convert.ToString(dr["LEAVE_TYPE"]);
						//Temp.BranchAssignedId = Convert.ToInt32(dr["FROM_SESSION"]);
						Temp.Purpose = Convert.ToString(dr["PURPOSE"]);
						if (dr["START_DATE"] != DBNull.Value)
							Temp.StartDate = Convert.ToDateTime(dr["START_DATE"]);
						if (dr["END_DATE"] != DBNull.Value)
							Temp.EndDate = Convert.ToString(dr["END_DATE"]);
						Temp.NoticeComments = Convert.ToString(dr["NOTICE_COMMENTS"]);
						MyList.Add(Temp);
					}
				}

				if (MyList != null) MyList.TrimExcess();
				return MyList;
			}
			finally
			{
				con.Close();

			}
		}

		public void UpdateLeaverequest(int LeaveRequestId, DateTime ApprovalDate, string NoticeComments)
		{
			SqlConnection con = new DalHelper().GetConnection();
			try
			{
				SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
				cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_LEAVE_REQUEST";
				cmd.Parameters.Add("@LeaveId", SqlDbType.Int).Value = LeaveRequestId;
				cmd.Parameters.Add("@ApprovalDate", SqlDbType.DateTime).Value = ApprovalDate;
				cmd.Parameters.Add("@NoticeComments", SqlDbType.NVarChar).Value = NoticeComments;
				cmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader dr = cmd.ExecuteReader();
			}
			finally
			{
				con.Close();

			}
		}
        #endregion
        #region BILLS
      public List<Bills> GetNoticeBills()
        {
			SqlConnection con = new DalHelper().GetConnection();
			try
			{

				SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
				cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_NOTICE_BILLS";
				//cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = SessionId;
				cmd.CommandType = CommandType.StoredProcedure;
				List<Bills> MyList = null;
				SqlDataReader dr = cmd.ExecuteReader();
				if (dr.HasRows)
				{
					MyList = new List<Bills>();
					while (dr.Read())
					{
						Bills Temp = new Bills();
						Temp.BillsId = Convert.ToInt32(dr["BILLS_ID"]);
						Temp.HouseTypes = new LegisEntities.HouseTypes();
						Temp.HouseTypesId = Convert.ToInt32(dr["HOUSE_TYPES_ID"]);
						Temp.HouseTypes.Description = Convert.ToString(dr["HOUSE_TYPE"]);
						Temp.BillCategories = new BillCategories();
						Temp.BillCategoriesId = Convert.ToInt32(dr["BILL_CATEGORIES_ID"]);
						Temp.HouseTypes.Description = Convert.ToString(dr["BILL_CATEGORY"]);
						if (dr["NOTICE_DIARY_DATE"] != DBNull.Value)
							Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
						if (dr["BILL_TITLE"] != DBNull.Value)
							Temp.BillTitle = Convert.ToString(dr["BILL_TITLE"]);
						if (dr["SUBJECT"] != DBNull.Value)
							Temp.Subject = Convert.ToString(dr["SUBJECT"]);
						Temp.DeviceId= Convert.ToInt32(dr["DEVICE_ID"]);
						MyList.Add(Temp);
					}
				}

				if (MyList != null) MyList.TrimExcess();
				return MyList;
			}
			finally
			{
				con.Close();

			}
		}
        #endregion

    }

}
