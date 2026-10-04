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
    public partial class ManageRequisitionItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack == true)
            {
                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                Requisitions requisition = new AdminBIZ().GetRequisition(Id);
                if(requisition.RequisitionBy==1)
                heading.Text = "Requisition by " + requisition.EmployeeName + " ( " + requisition.Post + " ) on " + requisition.RequisitionDate.ToLongDateString(); 
                else if (requisition.RequisitionBy == 2)
                    heading.Text = "Requisition by " + requisition.Branch + " on " + requisition.RequisitionDate.ToLongDateString();
                RequisitionIDLbl.Text = "Requisition Id ( " + Id + " )" ;
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
            item.QuantityIssued = Convert.ToInt32(QuantityIssuedTxt.Text);
          
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
                QuantityIssuedTxt.Text = "";
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
            Label error= RequisitionItemsLV.EditItem.FindControl("EditError") as Label;
            ReqItem.RequisitionItemId = Convert.ToInt32(HidRequisitionItemId.Value);
            ReqItem.QuantityDemanded = Convert.ToInt32(requested.Text);
            ReqItem.QuantityIssued = Convert.ToInt32(issued.Text);
            string errors=UpdateRequisitionItem(ReqItem);
            error.Text = errors;
            RequisitionItemsLV.EditIndex = -1;
            RequisitionItemsLV.InsertItemPosition = InsertItemPosition.None;
            RequisitionItemsLV.SelectedIndex = -1;
            Response.Redirect("~/ManageRequisitionItems.aspx?Id=" + Id);
            e.Cancel = true;


        }
        protected string UpdateRequisitionItem(RequisitionItems ReqItem)
        {

            int Id = Convert.ToInt32(Request.QueryString["Id"]);
            RequisitionItems requisitionitem = new AdminBIZ().GetRequisitionItem(ReqItem.RequisitionItemId);
            Items item = new AdminBIZ().GetItem(requisitionitem.ItemId);
            RequisitionItems req = new AdminBIZ().GetRequisitionItem(Id);
            string error = null;
            if ((item.CurrentBalance + requisitionitem.QuantityIssued) < ReqItem.QuantityIssued)
                error=error +  "<p>( " + requisitionitem.Item + " )-Do not have sufficient items for this request.</p>";
            else if (ReqItem.QuantityDemanded < ReqItem.QuantityIssued)
            {
                error = error + "<p>( " + requisitionitem.Item + " )-Can not issue more items than requested.</p>";
            }

            if(String.IsNullOrEmpty(error))
                new AdminBIZ().UpdateRequisitionItem(ReqItem);
            
            return error;
        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField HidRequisitionItemId = (HiddenField)RequisitionItemsLV.Items[e.ItemIndex].FindControl("HidRequisitionItemId");
            int ResId = Convert.ToInt32(HidRequisitionItemId.Value);
            new AdminBIZ().DeleteRequisitionItem(ResId);
            BindLV();
        }

        protected void SaveItems_Click(object sender, EventArgs e)
        {

            int FinancialYearId = Convert.ToInt32(Request.QueryString["FY"]);
            string errors = null;
            foreach (ListViewItem li in RequisitionItemsLV.Items)
            {
                TextBox issued = (TextBox)li.FindControl("IssuedTxt");
                Label requested = (Label)li.FindControl("DemandLbl");
                if (issued != null && requested!=null)
                {
                    HiddenField HidRequisitionItemId = (HiddenField)li.FindControl("HidRequisitionItemId");
                    int RequisitionItemId = (Convert.ToInt32(HidRequisitionItemId.Value));
                    RequisitionItems sh = new RequisitionItems();
                    sh.RequisitionItemId = RequisitionItemId;
                    sh.QuantityIssued = Convert.ToInt32(issued.Text);
                    sh.QuantityDemanded= Convert.ToInt32(requested.Text);
                    errors=errors + UpdateRequisitionItem(sh);
                }
            }
            errordiv.InnerHtml = errors;
        }
        protected string GetFormattedAmount(double Amount)
        {
            return String.Format("{0:#,##0}", Amount);
        }
    }

}
