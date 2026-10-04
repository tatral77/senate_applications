using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class ManageParliamentaryPeriods : System.Web.UI.Page
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
            List<ParliamentaryTenures> ParliamentaryPeriods = new AdministrationBiz().GetParliamentaryTenuress();
            ListView1.DataSource = ParliamentaryPeriods;
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
                DropDownList ParliamentaryTenuresDDL = e.Item.FindControl("ParliamentaryTenuressDDL") as DropDownList;
                HiddenField HidParliamentaryTenures = (e.Item.FindControl("HidParliamentaryTenuresId") as HiddenField);
                //  ParliamentaryTenuresDDL.SelectedValue = HidParliamentaryTenures.Value.ToString();

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
            DropDownList ParliamentaryTenuresDDL = new DropDownList();
            ParliamentaryTenuresDDL = (e.Item.FindControl("ParliamentaryTenuresDDL") as DropDownList);
            if (ParliamentaryTenuresDDL != null)
            {
                List<ParliamentaryTenures> ps = new AdministrationBiz().GetParliamentaryTenuress();

                foreach (ParliamentaryTenures row in ps)
                {
                    ListItem li = new ListItem();
                    li.Value = row.Description.ToString();
                    li.Text = row.Description.ToString();
                    ParliamentaryTenuresDDL.Items.Add(li);
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
            HiddenField ParliamentaryTenuresId = ListView1.InsertItem.FindControl("HidParliamentaryTenuresId") as HiddenField;
            TextBox Description = (TextBox)ListView1.InsertItem.FindControl("ParliamentaryTenuresTxt");
            DropDownList IsActive = (DropDownList)ListView1.InsertItem.FindControl("IsActiveDDL");
            TextBox FromDate = (TextBox)ListView1.InsertItem.FindControl("FromDateTxt");
            TextBox ToDate = (TextBox)ListView1.InsertItem.FindControl("ToDateTxt");
            ParliamentaryTenures ep = new ParliamentaryTenures();
            ep.Description = Convert.ToString(Description.Text);
            ep.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);
            ep.FromDate = Convert.ToDateTime(FromDate.Text);
            ep.ToDate = Convert.ToDateTime(ToDate.Text);
            new AdministrationBiz().InsertParliamentaryTenure(ep);
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            e.Cancel = true;

            Response.Redirect("ManageParliamentaryPeriods.aspx");

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            HiddenField ParliamentaryTenuresId = ListView1.EditItem.FindControl("HidParliamentaryTenuresId") as HiddenField;
            TextBox Description = (TextBox)ListView1.EditItem.FindControl("ParliamentaryTenuresTxt");
            DropDownList IsActive = (DropDownList)ListView1.EditItem.FindControl("IsActiveDDL");
            TextBox FromDate = (TextBox)ListView1.EditItem.FindControl("FromDateTxt");
            TextBox ToDate = (TextBox)ListView1.EditItem.FindControl("ToDateTxt");
            ParliamentaryTenures ep = new ParliamentaryTenures();
            ep.ParliamentaryTenuresId = Convert.ToInt16(ParliamentaryTenuresId.Value);
            ep.Description = Convert.ToString(Description.Text);
            ep.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);
            ep.FromDate = Convert.ToDateTime(FromDate.Text);
            ep.ToDate = Convert.ToDateTime(ToDate.Text);
            new AdministrationBiz().UpdateParliamentaryPeriods(ep);
            ListView1.EditIndex = -1;

            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            //  }
            e.Cancel = true;
        }
    }
}