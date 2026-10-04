using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class ManageSittingTypes : System.Web.UI.Page
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
            List<SittingTypes> SittingTypes = new AdministrationBiz().GetSittingTypes();
            ListView1.DataSource = SittingTypes;
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
                //DropDownList MinistryDDL = e.Item.FindControl("MinistryDDL") as DropDownList;
                //HiddenField HidMinistriesId = (e.Item.FindControl("HidMinistriesId") as HiddenField);
                //MinistryDDL.SelectedValue = HidMinistriesId.Value.ToString();

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
            // HiddenField DivisionsId = ListView1.InsertItem.FindControl("HidDivisionsId") as HiddenField;
            TextBox Description = (TextBox)ListView1.InsertItem.FindControl("SittingTypesTxt");
            DropDownList IsActive = (DropDownList)ListView1.InsertItem.FindControl("IsActiveDDL");
            SittingTypes ep = new SittingTypes();
            ep.Description = Convert.ToString(Description.Text);
            ep.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);
            new AdministrationBiz().InsertSittingTypes(ep);
            ListView1.EditIndex = -1;

            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            //  }
            e.Cancel = true;

            Response.Redirect("ManageSittingTypes.aspx");

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            HiddenField SittingTypesId = ListView1.EditItem.FindControl("HidSittingTypesId") as HiddenField;
            DropDownList IsActive = (DropDownList)ListView1.EditItem.FindControl("IsActiveDDL");
            TextBox Description = (TextBox)ListView1.EditItem.FindControl("SittingTypesTxt");
            SittingTypes ep = new SittingTypes();
            ep.SittingTypesId = Convert.ToInt32(SittingTypesId.Value);
            ep.Description = Convert.ToString(Description.Text);
            ep.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);
            new AdministrationBiz().UpdateSittingTypes(ep);
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            e.Cancel = true;
        }
    }
}