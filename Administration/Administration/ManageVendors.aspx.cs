using BIZ;
using BUDENTITIES;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administration
{
    public partial class ManageVendors : System.Web.UI.Page
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
            List<AdminVendor> Vendors = new AdminBIZ().GetAdminVendor();
            ListView1.DataSource = Vendors;
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
        //protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        //{
        //    (ListView1.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        //    this.bindListView1();
        //}
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (ListView1.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                //DropDownList SessionSittingsDDL = e.Item.FindControl("SessionSittingsDDL") as DropDownList;
                //HiddenField HidSessionSittings = (e.Item.FindControl("HidSessionSittingsId") as HiddenField);
                //ParliamentaryPeriodsDDL.SelectedValue = HidParliamentaryPeriodsId.Value.ToString();

                TextBox Description = e.Item.FindControl("Description") as TextBox;
                HiddenField HidVendorId = (e.Item.FindControl("HidVendorId") as HiddenField);
                //ParliamentaryPeriodsDDL.SelectedValue = HidParliamentaryPeriodsId.Value.ToString();

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
            //DropDownList MinistriesDDL = new DropDownList();
            //MinistriesDDL = (e.Item.FindControl("MinistryDDL") as DropDownList);
            //if (MinistriesDDL != null)
            //{
            //    List<Ministries> ps = new AdministrationBiz().GetMinistries();

            //    foreach (Ministries row in ps)
            //    {
            //        ListItem li = new ListItem();
            //        li.Value = row.MinistriesId.ToString();
            //        li.Text = row.Description.ToString();
            //        MinistriesDDL.Items.Add(li);
            //    }

            //}

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

            TextBox Vendor = (TextBox)ListView1.InsertItem.FindControl("Vendor");
            TextBox Address = (TextBox)ListView1.InsertItem.FindControl("AddressTxt");
            TextBox Contacts = (TextBox)ListView1.InsertItem.FindControl("ContactsTxt");
            TextBox Emails = (TextBox)ListView1.InsertItem.FindControl("EmailsTxt");
            TextBox Details = (TextBox)ListView1.InsertItem.FindControl("DetailsTxt");
            TextBox NTN = (TextBox)ListView1.InsertItem.FindControl("NTNTxt");
            TextBox VendorNoTxt = (TextBox)ListView1.InsertItem.FindControl("VendorNumberTxt");
            TextBox BankAccountTxt = (TextBox)ListView1.InsertItem.FindControl("BankAccountTxt");
            TextBox BankNameTxt = (TextBox)ListView1.InsertItem.FindControl("BankNameTxt");
            AdminVendor ep = new AdminVendor();
            ep.Vendor = Convert.ToString(Vendor.Text);
            ep.Address = Convert.ToString(Address.Text);
            ep.Contacts = Convert.ToString(Contacts.Text);
            ep.Emails = Convert.ToString(Emails.Text);
            ep.Details = Convert.ToString(Details.Text);
            ep.NTN = Convert.ToString(NTN.Text);
            ep.VendorNumber = Convert.ToString(VendorNoTxt.Text);
            ep.BankAccount = Convert.ToString(BankAccountTxt.Text);
            ep.BankName = Convert.ToString(BankNameTxt.Text);
            new AdminBIZ().InsertAdminVendor(ep);
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            //  }
            e.Cancel = true;

            Response.Redirect("ManageVendors.aspx");

        }

        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField HidVendorId = ListView1.EditItem.FindControl("HidVendorId") as HiddenField;
            TextBox Vendor = (TextBox)ListView1.EditItem.FindControl("Vendor");
            TextBox Address = (TextBox)ListView1.EditItem.FindControl("AddressTxt");
            TextBox Contacts = (TextBox)ListView1.EditItem.FindControl("ContactsTxt");
            TextBox Emails = (TextBox)ListView1.EditItem.FindControl("EmailsTxt");
            TextBox Details = (TextBox)ListView1.EditItem.FindControl("DetailsTxt");
            TextBox NTN = (TextBox)ListView1.EditItem.FindControl("NTNTxt");
            TextBox VendorNoTxt = (TextBox)ListView1.EditItem.FindControl("VendorNumberTxt");
            TextBox BankAccountTxt = (TextBox)ListView1.EditItem.FindControl("BankAccountTxt");
            TextBox BankNameTxt = (TextBox)ListView1.EditItem.FindControl("BankNameTxt");
            AdminVendor ep = new AdminVendor();
            ep.VendorId = Convert.ToInt32(HidVendorId.Value);
            ep.Vendor = Convert.ToString(Vendor.Text);
            ep.Address = Convert.ToString(Address.Text);
            ep.Contacts = Convert.ToString(Contacts.Text);
            ep.Emails = Convert.ToString(Emails.Text);
            ep.Details = Convert.ToString(Details.Text);
            ep.NTN = Convert.ToString(NTN.Text);
            ep.VendorNumber = Convert.ToString(VendorNoTxt.Text);
            ep.BankAccount = Convert.ToString(BankAccountTxt.Text);
            ep.BankName = Convert.ToString(BankNameTxt.Text);
            new AdminBIZ().UpdateAdminVendor(ep);
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            //  }
            e.Cancel = true;
        }

    }
}