using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class ManageParliamentaryTerms : System.Web.UI.Page
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
            List<ParliamentaryTerms> ParliamentaryPeriods = new AdministrationBiz().GetParliamentaryTerms();
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
                DropDownList ParliamentaryPeriodsDDL = e.Item.FindControl("ParliamentaryPeriodsDDL") as DropDownList;
                HiddenField HidParliamentaryPeriods = (e.Item.FindControl("HidParliamentaryPeriodsId") as HiddenField);
                //ParliamentaryPeriodsDDL.SelectedValue = HidParliamentaryPeriodsId.Value.ToString();

                DropDownList IsActive = e.Item.FindControl("IsActiveDDL") as DropDownList;
                HiddenField HidIsActive = (e.Item.FindControl("HidIsActive") as HiddenField);
                //IsActive.SelectedValue = HidIsActive.Value.ToString();



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
            DropDownList ParliamentaryPeriodsDDL = new DropDownList();
            ParliamentaryPeriodsDDL = (e.Item.FindControl("ParliamentaryPeriodsDDL") as DropDownList);
            if (ParliamentaryPeriodsDDL != null)
            {
                List<ParliamentaryTerms> ps = new AdministrationBiz().GetParliamentaryTerms();

                foreach (ParliamentaryTerms row in ps)
                {
                    ListItem li = new ListItem();
                    li.Value = row.Description.ToString();
                    li.Text = row.Description.ToString();
                    ParliamentaryPeriodsDDL.Items.Add(li);
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
            HiddenField ParliamentaryPeriodsId = ListView1.InsertItem.FindControl("HidParliamentaryTermsId") as HiddenField;
            TextBox Description = (TextBox)ListView1.InsertItem.FindControl("ParliamentaryTermTxt");
            DropDownList IsActive = (DropDownList)ListView1.InsertItem.FindControl("IsActiveDDL");
            TextBox FromDate = (TextBox)ListView1.InsertItem.FindControl("FromDateTxt");
            TextBox ToDate = (TextBox)ListView1.InsertItem.FindControl("ToDateTxt");
            ParliamentaryTerms ep = new ParliamentaryTerms();
            ep.Description = Convert.ToString(Description.Text);
            ep.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);
            ep.FromDate = Convert.ToDateTime(FromDate.Text);
            ep.ToDate = Convert.ToDateTime(ToDate.Text);
            new AdministrationBiz().InsertParliamentaryTerm(ep);
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            e.Cancel = true;

            Response.Redirect("ManageParliamentaryTerms.aspx");

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            HiddenField ParliamentaryPeriodsId = ListView1.EditItem.FindControl("HidParliamentaryPeriodsId") as HiddenField;
            TextBox Description = (TextBox)ListView1.EditItem.FindControl("ParliamentaryPeriodsTxt");
            DropDownList IsActive = (DropDownList)ListView1.EditItem.FindControl("IsActiveDDL");
            TextBox FromDate = (TextBox)ListView1.EditItem.FindControl("FromDateTxt");
            TextBox ToDate = (TextBox)ListView1.EditItem.FindControl("ToDateTxt");
            ParliamentaryTerms ep = new ParliamentaryTerms();
            ep.ParliamentaryTermsId = Convert.ToInt16(ParliamentaryPeriodsId.Value);
            ep.Description = Convert.ToString(Description.Text);
            ep.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);
            ep.FromDate = Convert.ToDateTime(FromDate.Text);
            ep.ToDate = Convert.ToDateTime(ToDate.Text);
            new AdministrationBiz().UpdateParliamentaryTerm(ep);
            ListView1.EditIndex = -1;

            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            //  }
            e.Cancel = true;
        }
    }
}