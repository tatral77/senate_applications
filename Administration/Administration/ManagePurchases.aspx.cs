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
    public partial class ManagePurchases : System.Web.UI.Page
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
            List<Purchases> Purchases = new AdminBIZ().GetPurchases();
            ListView1.DataSource = Purchases;
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
                DropDownList AdminVendorDDL = e.Item.FindControl("AdminVendorDDL") as DropDownList;
                HiddenField HidAdminVendor = (e.Item.FindControl("HidAdminVendorId") as HiddenField);
                AdminVendorDDL.SelectedValue = HidAdminVendor.Value.ToString();

                //TextBox Description = e.Item.FindControl("Description") as TextBox;
                //HiddenField HidVendorId = (e.Item.FindControl("HidVendorId") as HiddenField);
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
            DropDownList AdminVendorDDL = new DropDownList();
            AdminVendorDDL = (e.Item.FindControl("VendorsDDL") as DropDownList);
            if (AdminVendorDDL != null)
            {
                List<AdminVendor> ps = new AdminBIZ().GetAdminVendor();
                if (ps != null)
                {
                    foreach (AdminVendor row in ps)
                    {
                        ListItem li = new ListItem();
                        li.Value = row.VendorId.ToString();
                        li.Text = row.Vendor.ToString();
                        AdminVendorDDL.Items.Add(li);
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
            HiddenField HidPurchaseId = ListView1.InsertItem.FindControl("HidPurchaseId") as HiddenField;
            HiddenField HidVendorId = ListView1.InsertItem.FindControl("HidVendorId") as HiddenField;
            TextBox Purchase = (TextBox)ListView1.InsertItem.FindControl("PurchaseDescription");
            DropDownList Vendor = (DropDownList)ListView1.InsertItem.FindControl("VendorsDDL");
            TextBox InvoiceNumber = (TextBox)ListView1.InsertItem.FindControl("InvoiceNumberTxt");
            TextBox InvoiceDate = (TextBox)ListView1.InsertItem.FindControl("InvoiceDateTxt");
            TextBox OfficeFileNo = (TextBox)ListView1.InsertItem.FindControl("OfficeFileNoTxt");
            TextBox OfficeFileDate = (TextBox)ListView1.InsertItem.FindControl("OfficeFileDateTxt");
            Purchases ep = new Purchases();
            ep.VendorId = Convert.ToInt32(Vendor.SelectedItem.Value);
            ep.InvoiceNumber = Convert.ToString(InvoiceNumber.Text);
            ep.InvoiceDate = Convert.ToDateTime(InvoiceDate.Text);
            ep.OfficeFileNo = Convert.ToString(OfficeFileNo.Text);
            ep.OfficeFileDate = Convert.ToDateTime(OfficeFileDate.Text);
            new AdminBIZ().InsertPurchases(ep);
            ListView1.EditIndex = -1;

            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            //  }
            e.Cancel = true;

            Response.Redirect("ManagePurchases.aspx");

        }

        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField HidVendorId = ListView1.EditItem.FindControl("HidVendorId") as HiddenField;
            HiddenField HidPurchaseId = ListView1.EditItem.FindControl("HidPurchaseId") as HiddenField;
            TextBox Purchase = (TextBox)ListView1.EditItem.FindControl("PurchaseDescription");
            DropDownList Vendor = (DropDownList)ListView1.EditItem.FindControl("AdminVendorDDL");
            TextBox InvoiceNumber = (TextBox)ListView1.EditItem.FindControl("InvoiceNumberTxt");
            TextBox InvoiceDate = (TextBox)ListView1.EditItem.FindControl("InvoiceDateTxt");
            TextBox OfficeFileNo = (TextBox)ListView1.EditItem.FindControl("OfficeFileNoTxt");
            TextBox OfficeFileDate = (TextBox)ListView1.EditItem.FindControl("OfficeFileDateTxt");
            Purchases ep = new Purchases();
            ep.VendorId = Convert.ToInt32(Vendor.SelectedItem.Value);
            ep.PurchaseId = Convert.ToInt32(HidPurchaseId.Value);
            ep.InvoiceNumber = Convert.ToString(InvoiceNumber.Text);
            ep.InvoiceDate = Convert.ToDateTime(InvoiceDate.Text);
            ep.OfficeFileNo = Convert.ToString(OfficeFileNo.Text);
            ep.OfficeFileDate = Convert.ToDateTime(OfficeFileDate.Text);
            new AdminBIZ().UpdatePurchase(ep);
            ListView1.EditIndex = -1;

            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            //  }
            e.Cancel = true;
        }
    }
}