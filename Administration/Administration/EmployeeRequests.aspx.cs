using BIZ;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administration
{
    public partial class EmployeeRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                HidSystemUserId.Value = Id.ToString();
                HidPostId.Value= Request.QueryString["pid"];
                EmployeeNameTxt.Text = Request.QueryString["ename"];
                BindLV(Id);
            }
        }
      
        protected void BindLV(int EmployeeId)
        {
            List<Requisitions> requisition = new AdminBIZ().GetEmployeeRequisitions(EmployeeId);
            RequisitionItemsLV.DataSource = requisition;
            RequisitionItemsLV.DataBind();
        }

        protected void newLinkButton_Click(object sender, EventArgs e)
        {
            
        }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            RequisitionItemsLV.EditIndex = -1;
            RequisitionItemsLV.InsertItemPosition = InsertItemPosition.None;
            RequisitionItemsLV.SelectedIndex = -1;
            BindLV(Convert.ToInt32(HidSystemUserId.Value));
            e.Cancel = true;
        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {

        }
        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            Requisitions item = new Requisitions();
            int EmployeeId = Convert.ToInt32(HidSystemUserId.Value);
            TextBox ReqDate = RequisitionItemsLV.InsertItem.FindControl("RequisitionDateTxt") as TextBox;
            item.SystemUsersId = EmployeeId;
            item.PostId = Convert.ToInt32(HidPostId.Value);
            item.RequisitionDate = Convert.ToDateTime(ReqDate.Text);
            item.RequisitionBy = 1;
            new AdminBIZ().InsertRequisition(item);
            RequisitionItemsLV.EditIndex = -1;
            RequisitionItemsLV.InsertItemPosition = InsertItemPosition.None;
            RequisitionItemsLV.SelectedIndex = -1;
            BindLV(EmployeeId);
            e.Cancel = true;


        }
        public string GetDate(DateTime d)
        {
            return (Convert.ToString(d) == "01/01/0001 00:00:00") ? string.Empty : d.ToShortDateString();
        }
        public string GetLongDate(DateTime d)
        {
            return (Convert.ToString(d) == "01/01/0001 00:00:00") ? string.Empty : d.ToLongDateString();
        }
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {

            RequisitionItemsLV.InsertItemPosition = InsertItemPosition.None;
            RequisitionItemsLV.SelectedIndex = -1;
            RequisitionItemsLV.EditIndex = e.NewEditIndex;
            BindLV(Convert.ToInt32(HidSystemUserId.Value));
            e.Cancel = true;

        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            Requisitions item = new Requisitions();
            HiddenField HidReqId = RequisitionItemsLV.EditItem.FindControl("HidRequisitionId") as HiddenField;
            int EmployeeId = Convert.ToInt32(HidSystemUserId.Value);
            TextBox ReqDate = RequisitionItemsLV.EditItem.FindControl("RequisitionDateTxt") as TextBox;
            item.RequisitionId = Convert.ToInt32(HidReqId.Value);
            item.SystemUsersId = EmployeeId;
            item.PostId = Convert.ToInt32(HidPostId.Value);
            item.RequisitionDate = Convert.ToDateTime(ReqDate.Text);
            item.RequisitionBy = 1;
            new AdminBIZ().UpdateRequisition(item);
            RequisitionItemsLV.EditIndex = -1;
            RequisitionItemsLV.InsertItemPosition = InsertItemPosition.None;
            RequisitionItemsLV.SelectedIndex = -1;
            Response.Redirect("~/EmployeeRequests.aspx?Id=" + EmployeeId + "&ename=" + EmployeeNameTxt.Text + "&pid=" + HidPostId.Value);
            BindLV(EmployeeId);
            e.Cancel = true;

        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            //HiddenField SystemUsersId = (HiddenField)RequisitionItemsLV.Items[e.ItemIndex].FindControl("HidSystemUserId");
            //int ResId = Convert.ToInt32(SystemUsersId.Value);
            //new AdminBIZ().DeleteRequisition(ResId);
            //BindLV(Convert.ToInt32(SystemUsersId.Value));
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            RequisitionItemsLV.SelectedIndex = -1;
            RequisitionItemsLV.EditIndex = -1;
            RequisitionItemsLV.InsertItemPosition = InsertItemPosition.FirstItem;
            int EmployeeId = Convert.ToInt32(HidSystemUserId.Value);
            BindLV(EmployeeId);
        }

        protected void CheckReq_Click(object sender, EventArgs e)
        {
            int EmployeeId = Convert.ToInt32(HidSystemUserId.Value);
            BindLV(EmployeeId);
        }
    }
}