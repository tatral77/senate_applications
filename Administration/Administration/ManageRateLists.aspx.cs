using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using BIZ;

namespace Administration
{
    public partial class ManageRateLists : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindListView1();
            }

        }
        protected void bindListView1()
        {
            int vendorid = Convert.ToInt32(Request.QueryString["Id"]);
            List<RateList> RateList = new AdminBIZ().GetRateListByVendor(vendorid);
            ListView1.DataSource = RateList;
            ListView1.DataBind();
        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {

            ListView1.SelectedIndex = -1;
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.FirstItem;
            bindListView1();

        }
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            ListView1.InsertItemPosition = InsertItemPosition.None;
            ListView1.SelectedIndex = -1;
            ListView1.EditIndex = e.NewEditIndex;
            bindListView1();
            e.Cancel = true;


        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (ListView1.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                //DropDownList VendorDDL = e.Item.FindControl("VendorDDL") as DropDownList;
                //HiddenField HidVendor = (e.Item.FindControl("HidVendorId") as HiddenField);
                //VendorDDL.SelectedValue = HidVendor.Value.ToString();

                DropDownList IsActive = e.Item.FindControl("IsActiveDDL") as DropDownList;
                HiddenField HidIsActive = (e.Item.FindControl("HidIsActive") as HiddenField);
                IsActive.SelectedValue = HidIsActive.Value.ToString();
            }
        }
        protected string GetStatus(int id)
        {
            if (id == 0)
                return "No";
            else
                return "Yes";
        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList VendorDDL = new DropDownList();
            VendorDDL = (e.Item.FindControl("VendorsDDL") as DropDownList);
            if (VendorDDL != null)
            {
                List<AdminVendor> ps = new AdminBIZ().GetAdminVendor();
                if (ps != null)
                {
                    foreach (AdminVendor row in ps)
                    {
                        ListItem li = new ListItem();
                        li.Value = row.VendorId.ToString();
                        li.Text = row.Vendor.ToString();
                        VendorDDL.Items.Add(li);
                    }
                }

            }

        }

        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            ListView1.SelectedIndex = -1;
            bindListView1();
            e.Cancel = true;
        }


        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int vendorid = Convert.ToInt32(Request.QueryString["Id"]);
            TextBox ListDescription = (TextBox)ListView1.InsertItem.FindControl("DescriptionTxt");
            TextBox RateListDate = (TextBox)ListView1.InsertItem.FindControl("ListDateTxt");
            DropDownList IsActive = (DropDownList)ListView1.InsertItem.FindControl("IsActiveDDL");
            TextBox RemarksTxt = (TextBox)ListView1.InsertItem.FindControl("RemarksTxt");
            RateList ep = new RateList();
            ep.RateListDes = ListDescription.Text;
            ep.VendorId = vendorid;
            ep.RateListDate = Convert.ToDateTime(RateListDate.Text);
            ep.Remarks = Convert.ToString(RemarksTxt.Text);
            ep.IsActive = Convert.ToInt32(IsActive.SelectedValue);
            new AdminBIZ().InsertRateList(ep);
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            e.Cancel = true;
            Response.Redirect("ManageRateLists.aspx?="+ vendorid);
        }

        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField HidRateListId = ListView1.EditItem.FindControl("HidRateListId") as HiddenField;
            int vendorid = Convert.ToInt32(Request.QueryString["Id"]);
            TextBox ListDescription = (TextBox)ListView1.EditItem.FindControl("DescriptionTxt");
            TextBox RateListDate = (TextBox)ListView1.EditItem.FindControl("ListDateTxt");
            TextBox RemarksTxt = (TextBox)ListView1.EditItem.FindControl("RemarksTxt");
            DropDownList IsActive = (DropDownList)ListView1.EditItem.FindControl("IsActiveDDL");
            RateList ep = new RateList();
            ep.RateListId = Convert.ToInt32(HidRateListId.Value);
            ep.RateListDes = ListDescription.Text;
            ep.VendorId = vendorid;
            ep.RateListDate = Convert.ToDateTime(RateListDate.Text);
            ep.Remarks = Convert.ToString(RemarksTxt.Text);
            ep.IsActive = Convert.ToInt32(IsActive.SelectedValue);
            new AdminBIZ().UpdateRateList(ep);
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            e.Cancel = true;
        }
    }
}