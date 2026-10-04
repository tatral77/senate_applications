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
    public partial class BranchRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Branch> branch = new AdminBIZ().GetBranches();
                if(branch!=null)
                {
                    foreach(Branch br in branch)
                    {
                        ListItem it = new ListItem();
                        it.Value = br.BranchId.ToString();
                        it.Text = br.BranchName;
                        BranchDDL.Items.Add(it);
                    }
                }

                
            }
            //else
            //{
            //    int Id = Convert.ToInt32(Request.QueryString["Id"]);
                
            //    BranchDDL.SelectedValue = Id.ToString();
            //    BindLV(Id);
            //}
        }

        protected void BindLV(int BranchId)
        {
            List<Requisitions> requisition = new AdminBIZ().GetBranchRequisitions(BranchId);
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
            int BranchId = Convert.ToInt32(BranchDDL.SelectedValue);
            BindLV(BranchId);
            e.Cancel = true;
        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {

        }
        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            Requisitions item = new Requisitions();
            int BranchId = Convert.ToInt32(BranchDDL.SelectedValue);
            TextBox ReqDate = RequisitionItemsLV.InsertItem.FindControl("RequisitionDateTxt") as TextBox;
            item.BranchId = BranchId;
            item.RequisitionDate = Convert.ToDateTime(ReqDate.Text);
            item.RequisitionBy = 2;
            new AdminBIZ().InsertRequisition(item);
            RequisitionItemsLV.EditIndex = -1;
            RequisitionItemsLV.InsertItemPosition = InsertItemPosition.None;
            RequisitionItemsLV.SelectedIndex = -1;
            Response.Redirect("~/BranchRequests.aspx?Id=" + BranchId);
            BindLV(BranchId);
            BindLV(BranchId);
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
            int BranchId = Convert.ToInt32(BranchDDL.SelectedValue);
            BindLV(BranchId);
            e.Cancel = true;

        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            Requisitions item = new Requisitions();
            int BranchId = Convert.ToInt32(BranchDDL.SelectedValue);
            HiddenField HidReqId = RequisitionItemsLV.EditItem.FindControl("HidRequisitionId") as HiddenField;
            TextBox ReqDate = RequisitionItemsLV.EditItem.FindControl("RequisitionDateTxt") as TextBox;
            item.RequisitionId = Convert.ToInt32(HidReqId.Value);
            item.BranchId = BranchId;
            item.RequisitionDate = Convert.ToDateTime(ReqDate.Text);
            item.RequisitionBy = 2;
            new AdminBIZ().UpdateRequisition(item);
            RequisitionItemsLV.EditIndex = -1;
            RequisitionItemsLV.InsertItemPosition = InsertItemPosition.None;
            RequisitionItemsLV.SelectedIndex = -1;
            Response.Redirect("~/BranchRequests.aspx?Id=" + BranchId);
            BindLV(BranchId);
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
            int BranchId = Convert.ToInt32(BranchDDL.SelectedValue);
            BindLV(BranchId);
           
        }

        protected void CheckReq_Click(object sender, EventArgs e)
        {
           
        }

        protected void BranchDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int BranchId = Convert.ToInt32(BranchDDL.SelectedValue);
            BindLV(BranchId);
        }
    }



    
    }
