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
    public partial class NewRequest1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack==true)
            {
                List<Branch> br = new AdminBIZ().GetBranches();
                //BranchDDL.Items.Add(new ListItem("Select", "0"));
                foreach (Branch row in br)
                {
                    ListItem li = new ListItem();
                    li.Text = row.BranchName;
                    li.Value = row.BranchId.ToString();
                    BranchDDL.Items.Add(li);
                }
            }
        }
        protected void BindLV(int RequisitionId)
        {
            List<RequisitionItems> requisitionitems = new AdminBIZ().GetRequistionItems(RequisitionId);
            RequisitionItemsLV.DataSource = requisitionitems;
            RequisitionItemsLV.DataBind();
        }

        protected void newLinkButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(HidRequisitionId.Value))
            {
                Requisitions requisition = new Requisitions();
                if (BranchDDL.SelectedValue != "0")
                {
                    requisition.BranchId = Convert.ToInt32(BranchDDL.SelectedValue);
                    requisition.RequisitionBy = 2;
                }
                else if (!String.IsNullOrEmpty(HidSystemUserId.Value))
                {
                    requisition.SystemUsersId = Convert.ToInt32(HidSystemUserId.Value);
                    requisition.PostId = Convert.ToInt32(HidPostId.Value);
                    requisition.RequisitionBy = 1;
                }
                requisition.RequisitionDate = Convert.ToDateTime(RequestDateTxt.Text);
                int RequisitionId = new AdminBIZ().InsertRequisition(requisition);
                RequisitionIDLbl.Text = "Requisition Id ( " + RequisitionId + " )";
                HidRequisitionId.Value = RequisitionId.ToString();
            }
                RequisitionItems item = new RequisitionItems();
                item.RequistionId = Convert.ToInt32(HidRequisitionId.Value);
                item.ItemId = Convert.ToInt32(HidItemId.Value);
                item.QuantityDemanded = Convert.ToInt32(QuantityRequestedTxt.Text);
                item.QuantityIssued = Convert.ToInt32(QuantityIssuedTxt.Text);
                new AdminBIZ().InsertRequisitionItem(item);
                BindLV(Convert.ToInt32(HidRequisitionId.Value));
                ItemTxt.Text = "";
                HidItemId.Value = "";
                QuantityRequestedTxt.Text = "";
                QuantityIssuedTxt.Text = "";
            }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            RequisitionItemsLV.EditIndex = -1;
            RequisitionItemsLV.InsertItemPosition = InsertItemPosition.None;
            RequisitionItemsLV.SelectedIndex = -1;
            BindLV(Convert.ToInt32(HidRequisitionId.Value));
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
            BindLV(Convert.ToInt32(HidRequisitionId.Value));
            e.Cancel = true;

        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            
        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

             RequisitionItems item = new RequisitionItems();
             int RequisitionId=Convert.ToInt32(HidRequisitionId.Value);
            HiddenField HidRequisitionItemId = RequisitionItemsLV.EditItem.FindControl("HidRequisitionItemId") as HiddenField;
            TextBox requested = RequisitionItemsLV.EditItem.FindControl("QuantityDemanded") as TextBox;
            TextBox issued = RequisitionItemsLV.EditItem.FindControl("QuantityIssued") as TextBox;
            item.RequisitionItemId = Convert.ToInt32(HidRequisitionItemId.Value);
            item.QuantityDemanded = Convert.ToInt32(requested.Text);
            item.QuantityIssued = Convert.ToInt32(issued.Text);
            new AdminBIZ().UpdateRequisitionItem(item);
            RequisitionItemsLV.EditIndex = -1;
            RequisitionItemsLV.InsertItemPosition = InsertItemPosition.None;
            RequisitionItemsLV.SelectedIndex = -1;
            BindLV(Convert.ToInt32(HidRequisitionId.Value));
            e.Cancel = true;

        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField HidRequisitionItemId = (HiddenField)RequisitionItemsLV.Items[e.ItemIndex].FindControl("HidRequisitionItemId");
            int ResId = Convert.ToInt32(HidRequisitionItemId.Value);
            new AdminBIZ().DeleteRequisitionItem(ResId);
            BindLV(Convert.ToInt32(HidRequisitionId.Value));
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NewRequest.aspx");
        }
    }
    }
