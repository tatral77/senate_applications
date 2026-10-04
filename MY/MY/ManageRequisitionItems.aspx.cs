using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MY
{
    public partial class ManageRequisitionItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack == true)
            {
                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                Requisitions requisition = new AdminBIZ().GetRequisition(Id);
                if (requisition.RequisitionBy == 1)
                    heading.Text = "Requisition Id :-" + Id;  //requisition.EmployeeName + " ( " + requisition.Post + " ) on " + requisition.RequisitionDate.ToLongDateString();
                else if (requisition.RequisitionBy == 2)
                    heading.Text = "Requisition Id " + Id;// requisition.Branch + " on " + requisition.RequisitionDate.ToLongDateString();
                RequisitionIDLbl.Text = "  Dated : " + requisition.RequisitionDate.ToLongDateString(); //"Requisition Id ( " + Id + " )";
                BindLV();
            }
        }
        protected void BindLV()
        {
            int Id = Convert.ToInt32(Request.QueryString["Id"]);
            List<RequisitionItems> requisitionitems = new AdminBIZ().GetRequistionItems(Id);
            RequisitionItemsLV.DataSource = requisitionitems;
            RequisitionItemsLV.DataBind();
        }

        protected void newLinkButton_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(Request.QueryString["Id"]);
            RequisitionItems item = new RequisitionItems();
            item.RequistionId = Id;
            item.ItemId = Convert.ToInt32(HidItemId.Value);
            item.QuantityDemanded = Convert.ToInt32(QuantityRequestedTxt.Text);
            item.QuantityIssued = 0;

            Items i = new AdminBIZ().GetItem(item.ItemId);
            if (i.CurrentBalance < item.QuantityIssued)
                InsertError.Text = "Do not have sufficient items for this request.";
            else if (item.QuantityDemanded < item.QuantityIssued)
            {
                InsertError.Text = "Can not issue more items than requested.";
            }
            else
            {
                InsertError.Text = "";
                new AdminBIZ().InsertRequisitionItem(item);
                ItemTxt.Text = "";
                HidItemId.Value = "";
                QuantityRequestedTxt.Text = "";
               // QuantityIssuedTxt.Text = "";
                Response.Redirect("~/ManageRequisitionItems.aspx?Id=" + Id);
            }
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


        }
        public string GetDate(DateTime d)
        {
            return (Convert.ToString(d) == "01/01/0001 00:00:00") ? string.Empty : d.ToShortDateString();
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

            RequisitionItems ReqItem = new RequisitionItems();
            int Id = Convert.ToInt32(Request.QueryString["Id"]);
            HiddenField HidRequisitionItemId = RequisitionItemsLV.EditItem.FindControl("HidRequisitionItemId") as HiddenField;
            TextBox requested = RequisitionItemsLV.EditItem.FindControl("QuantityDemanded") as TextBox;
            TextBox issued = RequisitionItemsLV.EditItem.FindControl("QuantityIssued") as TextBox;
            Label error = RequisitionItemsLV.EditItem.FindControl("EditError") as Label;
            ReqItem.RequisitionItemId = Convert.ToInt32(HidRequisitionItemId.Value);
            ReqItem.QuantityDemanded = Convert.ToInt32(requested.Text);
            //ReqItem.QuantityIssued = 0;
            RequisitionItems requisitionitem = new AdminBIZ().GetRequisitionItem(ReqItem.RequisitionItemId);
            Items item = new AdminBIZ().GetItem(requisitionitem.ItemId);
            RequisitionItems req = new AdminBIZ().GetRequisitionItem(Id);
            if ((item.CurrentBalance + requisitionitem.QuantityIssued) < ReqItem.QuantityIssued)
                error.Text = "Do not have sufficient items for this request.";
            else if (ReqItem.QuantityDemanded < ReqItem.QuantityIssued)
            {
                error.Text = "Can not issue more items than requested.";
            }
            else
            {
                error.Text = "";
                new AdminBIZ().UpdateRequisitionItem(ReqItem);
                RequisitionItemsLV.EditIndex = -1;
                RequisitionItemsLV.InsertItemPosition = InsertItemPosition.None;
                RequisitionItemsLV.SelectedIndex = -1;
                Response.Redirect("~/ManageRequisitionItems.aspx?Id=" + Id);
                e.Cancel = true;
            }

        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField HidRequisitionItemId = (HiddenField)RequisitionItemsLV.Items[e.ItemIndex].FindControl("HidRequisitionItemId");
            int ResId = Convert.ToInt32(HidRequisitionItemId.Value);
            new AdminBIZ().DeleteRequisitionItem(ResId);
            BindLV();
        }

    }
}