using BIZ;
using Entities;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Notice
{
    public partial class MembersAttendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList AttendanceDDL = new DropDownList();

            AttendanceDDL = (e.Item.FindControl("AttendanceDDL") as DropDownList);

            if (AttendanceDDL != null)
            {
                List<AttendanceStatuses> ps = new AdministrationBiz().GetAttendanceStatuses();

                foreach (AttendanceStatuses row in ps)
                {
                    ListItem li = new ListItem();
                    li.Value = row.AttendanceStatusId.ToString();
                    li.Text = row.AttendanceStatus.ToString();
                    AttendanceDDL.Items.Add(li);
                }

            }
        }
        protected void Bind()
        {
            SessionSittings sessionSittings = new SessionSittings();
           
            int SessionSittingId = Convert.ToInt32(Request.QueryString["Id"]);
            sessionSittings = new AdministrationBiz().GetSessionSittingById(SessionSittingId);
            heading.InnerText = "MEMBERS ATTENDANCE ( SESSION " + sessionSittings.AssemblySession + " - " + sessionSittings.SittingDate.ToShortDateString() + " )"; 
            List<MemberAttendance> memberAttendances = new NoticeBiz().GetActiveMembersAttendance(SessionSittingId);
            ListView1.DataSource = memberAttendances;
            ListView1.DataBind();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {

            int SessionSittingId = Convert.ToInt32(Request.QueryString["Id"]);
            List<MemberAttendance> memberAttendances = new List<MemberAttendance>();
            foreach (ListViewItem li in ListView1.Items)
            {
                DropDownList attendanceStatus = (DropDownList)li.FindControl("AttendanceDDL" +
                    "");
                HiddenField MemberId = (HiddenField)li.FindControl("HidMemberId");
                if (attendanceStatus != null && MemberId != null)
                {
                    int AttendaceStatusId = Convert.ToInt32(attendanceStatus.SelectedValue);
                    int memberId = Convert.ToInt32(MemberId.Value);
                    MemberAttendance ma = new MemberAttendance();
                    ma.MemberId = memberId;
                    ma.AttendanceStatusId = AttendaceStatusId;
                    ma.SessionSittingId = SessionSittingId;
                    memberAttendances.Add(ma);
                }
            }
            new NoticeBiz().AddMembersAttendances(memberAttendances, SessionSittingId);
        }

        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            DropDownList AttendanceDDL = new DropDownList();
            AttendanceDDL = (e.Item.FindControl("AttendanceDDL") as DropDownList);
            HiddenField AttendaceStatusId = new HiddenField();
            AttendaceStatusId = (e.Item.FindControl("HidAttendanceStatusId") as HiddenField);
            AttendanceDDL.SelectedValue = AttendaceStatusId.Value;
        }
    }
}