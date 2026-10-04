using MyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyBIZ;

namespace MY
{
    public partial class AdminRequisition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie reqCookies = Request.Cookies["userInfo"];
                if (reqCookies != null)
                {
                    //int EmployeeId = Convert.ToInt32(reqCookies["SystemUsersId"]);
                    BindLV();
                }
            }
        }

        protected void BindLV()
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                int EmployeeId = Convert.ToInt32(reqCookies["SystemUsersId"]);
                List<Requisitions> requisition = new AdminBIZ().GetEmployeeRequisitions(EmployeeId);
                RequisitionItemsLV.DataSource = requisition;
                RequisitionItemsLV.DataBind();
            }
        }

        protected void newLinkButton_Click(object sender, EventArgs e)
        {

        }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            RequisitionItemsLV.EditIndex = -1;
            RequisitionItemsLV.InsertItemPosition = InsertItemPosition.None;
            RequisitionItemsLV.SelectedIndex = -1;
            BindLV();
            e.Cancel = true;
        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {

        }
        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                int EmployeeId = Convert.ToInt32(reqCookies["SystemUsersId"]);
                int PostId = Convert.ToInt32(reqCookies["PostId"]);
                Requisitions item = new Requisitions();
               // int EmployeeId = Convert.ToInt32(HidSystemUserId.Value);
                TextBox ReqDate = RequisitionItemsLV.InsertItem.FindControl("RequisitionDateTxt") as TextBox;
                item.SystemUsersId = EmployeeId;
                item.PostId = Convert.ToInt32(PostId);
                item.RequisitionDate = Convert.ToDateTime(ReqDate.Text);
                item.RequisitionBy = 1;
                new AdminBIZ().InsertRequisition(item);
                RequisitionItemsLV.EditIndex = -1;
                RequisitionItemsLV.InsertItemPosition = InsertItemPosition.None;
                RequisitionItemsLV.SelectedIndex = -1;
                BindLV();
                e.Cancel = true;
            }


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
            BindLV();
            e.Cancel = true;

        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                int systemusersid = Convert.ToInt32(reqCookies["SystemUsersId"]);
                int PostId = Convert.ToInt32(reqCookies["PostId"]);
                Requisitions item = new Requisitions();
                HiddenField HidReqId = RequisitionItemsLV.EditItem.FindControl("HidRequisitionId") as HiddenField;
              //  int EmployeeId = Convert.ToInt32(HidSystemUserId.Value);
                TextBox ReqDate = RequisitionItemsLV.EditItem.FindControl("RequisitionDateTxt") as TextBox;
                item.RequisitionId = Convert.ToInt32(HidReqId.Value);
                item.SystemUsersId = systemusersid;
                item.PostId = Convert.ToInt32(PostId);
                item.RequisitionDate = Convert.ToDateTime(ReqDate.Text);
                item.RequisitionBy = 1;
                new AdminBIZ().UpdateRequisition(item);
                RequisitionItemsLV.EditIndex = -1;
                RequisitionItemsLV.InsertItemPosition = InsertItemPosition.None;
                RequisitionItemsLV.SelectedIndex = -1;
                //Response.Redirect("~/EmployeeRequests.aspx?Id=" + systemusersid + "&ename=" + EmployeeNameTxt.Text + "&pid=" + HidPostId.Value);
                BindLV();
                e.Cancel = true;
            }

        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField RequisitionId = (HiddenField)RequisitionItemsLV.Items[e.ItemIndex].FindControl("HidRequisitionId");
            int ResId = Convert.ToInt32(RequisitionId.Value);
            new AdminBIZ().DeleteRequisition(ResId);
            BindLV();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            //RequisitionItemsLV.SelectedIndex = -1;
            //RequisitionItemsLV.EditIndex = -1;
            //RequisitionItemsLV.InsertItemPosition = InsertItemPosition.FirstItem;
            //BindLV();
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                int EmployeeId = Convert.ToInt32(reqCookies["SystemUsersId"]);
                int PostId = Convert.ToInt32(reqCookies["PostId"]);
                Requisitions item = new Requisitions();
                // int EmployeeId = Convert.ToInt32(HidSystemUserId.Value);
              //  TextBox ReqDate = RequisitionItemsLV.InsertItem.FindControl("RequisitionDateTxt") as TextBox;
                item.SystemUsersId = EmployeeId;
                item.PostId = Convert.ToInt32(PostId);
                item.RequisitionDate = DateTime.Now;
                item.RequisitionBy = 1;
                int RequisionId=new AdminBIZ().InsertRequisition(item);
                RequisitionItemsLV.EditIndex = -1;
                RequisitionItemsLV.InsertItemPosition = InsertItemPosition.None;
                RequisitionItemsLV.SelectedIndex = -1;
                Response.Redirect("ManageRequisitionItems.aspx?Id=" + RequisionId);
            }
        }

        protected void AddItemsBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int RequisitionId = Convert.ToInt32(btn.CommandArgument);
            Response.Redirect("ManageRequisitionItems.aspx?Id=" + RequisitionId);
        }
    }
}