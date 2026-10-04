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
    public partial class ManageRateListItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindListView1();
                List<CalcUnit> units = new AdminBIZ().GetUnits();
                if(units!=null)
                {
                    foreach(CalcUnit t in units)
                    {
                        ListItem a = new ListItem();
                        a.Value = t.UnitId.ToString();
                        a.Text = t.Description;
                        UnitDDL.Items.Add(a);
                    }
                }
            }

        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {           
            DropDownList UnitDDL2 = new DropDownList();
            UnitDDL2 = (e.Item.FindControl("UnitDDL") as DropDownList);
            if (UnitDDL2 != null)
            {

                List<CalcUnit> ps = new AdminBIZ().GetUnits();
                if (ps != null)
                {
                    foreach (CalcUnit row in ps)
                    {
                        ListItem li = new ListItem();
                        li.Value = row.UnitId.ToString();
                        li.Text = row.Description.ToString();
                        UnitDDL2.Items.Add(li);
                    }
                }

            }

        }
        protected void bindListView1()
        {
            int RateListId = Convert.ToInt32(Request.QueryString["Id"]);
            List<RateListItem> RateListItem = new AdminBIZ().GetRateListItems(RateListId);
            ListView1.DataSource = RateListItem;
            ListView1.DataBind();
        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {
            int RateListId = Convert.ToInt32(Request.QueryString["Id"]);
            RateListItem ep = new RateListItem();
            ep.RateListId = RateListId;
            ep.ItemId = Convert.ToInt32(HidItemId.Value);
            ep.Price = Convert.ToInt32(PriceTxt.Text);
            ep.UnitId = Convert.ToInt32(UnitDDL.SelectedValue);
            ep.IsActive = 1;
            new AdminBIZ().InsertRateListItem(ep);
            bindListView1();
            Response.Redirect("ManageRateListItems.aspx?Id=" + RateListId);

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
                DropDownList IsActive = e.Item.FindControl("IsActiveDDL") as DropDownList;
                HiddenField HidIsActive = (e.Item.FindControl("HidIsActive") as HiddenField);
                IsActive.SelectedValue = HidIsActive.Value.ToString();

                DropDownList UnitDDL = e.Item.FindControl("UnitDDL") as DropDownList;
                HiddenField HidUnitIt = (e.Item.FindControl("HidUnitId") as HiddenField);
                UnitDDL.SelectedValue = HidUnitIt.Value.ToString();
            }
        }
        protected string GetStatus(int id)
        {
            if (id == 0)
                return "No";
            else
                return "Yes";
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
            int RateListId = Convert.ToInt32(Request.QueryString["Id"]);
            RateListItem ep = new RateListItem();
            ep.RateListId = RateListId;
            ep.ItemId = Convert.ToInt32(HidItemId.Value);
            ep.Price = Convert.ToInt32(PriceTxt.Text);
            ep.UnitId = Convert.ToInt32(UnitDDL.SelectedValue);
            ep.IsActive = 1;
            new AdminBIZ().InsertRateListItem(ep);
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            e.Cancel = true;
            Response.Redirect("ManageRateListItem.aspx?Id=" + RateListId );
        }
    
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField HidRateListItemId = ListView1.EditItem.FindControl("HidRateListItemId") as HiddenField;
            int RateListId = Convert.ToInt32(Request.QueryString["Id"]);
            TextBox Price = (TextBox)ListView1.EditItem.FindControl("PriceTxt");
            DropDownList UnitId = (DropDownList)ListView1.EditItem.FindControl("UnitDDL");
            DropDownList IsActive = (DropDownList)ListView1.EditItem.FindControl("IsActiveDDL");
            RateListItem ep = new RateListItem();
            ep.RateListItemId = Convert.ToInt32(HidRateListItemId.Value);
            ep.Price = Convert.ToInt32(Price.Text); 
            ep.UnitId= Convert.ToInt32(UnitId.SelectedValue);
            ep.IsActive = Convert.ToInt32(IsActive.SelectedValue);
            new AdminBIZ().UpdateRateListItem(ep);
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            e.Cancel = true;
        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField HidRateListItemId = (HiddenField)ListView1.Items[e.ItemIndex].FindControl("HidRateListItemId");
            int itemid = Convert.ToInt32(HidRateListItemId.Value);
            new AdminBIZ().DeleteRateListItem(itemid);
            bindListView1();
        }

    }
}