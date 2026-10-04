using BIZ;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Notice
{
    public partial class MemberLeaveRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindLeaves();
            }

        }
        protected void BindLeaves()
        {
            int asseblysession = new AdministrationBiz().GetCurrentAssemblySessions();
            List<MemberLeaveApplication> memberLeaveRequests = new NoticeBiz().GetSessionLeaveRequests(asseblysession);
            LeavesLV.DataSource = memberLeaveRequests;
            LeavesLV.DataBind();

        }
        public string GetTime(DateTime time)
        {
            return time.ToShortTimeString();
        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();

        }

        protected void LeavesLV_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            LeavesLV.InsertItemPosition = InsertItemPosition.None;
            LeavesLV.SelectedIndex = -1;
            LeavesLV.EditIndex = e.NewEditIndex;
            BindLeaves();
            e.Cancel = true;
        }



        protected void LeavesLV_ItemCreated(object sender, ListViewItemEventArgs e)
        {

        }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            LeavesLV.EditIndex = -1;
            LeavesLV.InsertItemPosition = InsertItemPosition.None;
            LeavesLV.SelectedIndex = -1;
            int empval;
            BindLeaves();
            e.Cancel = true;
        }
        protected void LeavesLV_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            CheckBox IsSessionCB = e.Item.FindControl("IsSessionCB") as CheckBox;
            if (IsSessionCB != null)
            {
                HiddenField HidIsSessionLeave = (e.Item.FindControl("HidIsSessionLeave") as HiddenField);
                if (Convert.ToInt32(HidIsSessionLeave.Value) == 1)
                    IsSessionCB.Checked = true;
                else
                    IsSessionCB.Checked = false;
            }
        }

        protected void LeavesLV_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {


            HiddenField HidLeaveApplicationId = LeavesLV.EditItem.FindControl("HidLeaveApplicationId") as HiddenField;
            TextBox NoticeCommentsTxt = LeavesLV.EditItem.FindControl("NoticeCommentsTxt") as TextBox;
            TextBox ApprovalDateTxt = LeavesLV.EditItem.FindControl("ApprovalDateTxt") as TextBox;

            int LeaverequestId = Convert.ToInt32(HidLeaveApplicationId.Value);
            string NoticeComments = Convert.ToString(NoticeCommentsTxt.Text);
            DateTime ApprovalDate = Convert.ToDateTime(ApprovalDateTxt.Text);

            new NoticeBiz().UpdateLeaverequest(LeaverequestId, ApprovalDate, NoticeComments);
            LeavesLV.EditIndex = -1;
            BindLeaves();
            LeavesLV.InsertItemPosition = InsertItemPosition.None;
            LeavesLV.SelectedIndex = -1;
            e.Cancel = true;

        }
    }
}