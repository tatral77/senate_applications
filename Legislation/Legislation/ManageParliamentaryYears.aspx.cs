using LegisEntities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Legislation
{
    public partial class ManageParliamentaryYears : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindListView1();
            }

        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date).Substring(0, 9) == "1/01/0001") ? string.Empty : date.ToShortDateString();

        }
        protected void bindListView1()
        {
            List<ParliamentaryYears> ParliamentaryYears = new AdministrationBiz().GetParliamentaryYears();
            ListView1.DataSource = ParliamentaryYears;
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
                //DropDownList ParliamentaryYearsDDL = e.Item.FindControl("ParliamentaryYearsDDL") as DropDownList;
                //HiddenField HidParliamentaryYears = (e.Item.FindControl("HidParliamentaryYearsId") as HiddenField);
                //ParliamentaryTenuresDDL.SelectedValue = HidParliamentaryTenuresId.Value.ToString();

                DropDownList ParliamentaryTenuresDDL = e.Item.FindControl("ParliamentaryTenureDDL") as DropDownList;
                HiddenField HidParliamentaryTenures = (e.Item.FindControl("HidParliamentaryTenuresId") as HiddenField);
                ParliamentaryTenuresDDL.SelectedValue = HidParliamentaryTenures.Value.ToString();

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
            ParliamentaryTenuresDDL = (e.Item.FindControl("ParliamentaryTenureDDL") as DropDownList);
            if (ParliamentaryTenuresDDL != null)
            {
                List<ParliamentaryTenures> ps = new AdministrationBiz().GetParliamentaryTenuress();

                foreach (ParliamentaryTenures row in ps)
                {
                    ListItem li = new ListItem();
                    li.Value = row.ParliamentaryTenuresId.ToString();
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
            HiddenField ParliamentaryYearsId = ListView1.InsertItem.FindControl("HidParliamentaryYearsId") as HiddenField;
            DropDownList ParliamentaryTenuresId = (DropDownList)ListView1.InsertItem.FindControl("ParliamentaryTenureDDL");
            TextBox ParliamentaryYearTxt = (TextBox)ListView1.InsertItem.FindControl("ParliamentaryYearTxt");
            DropDownList IsActive = (DropDownList)ListView1.InsertItem.FindControl("IsActiveDDL");
            TextBox FromDate = (TextBox)ListView1.InsertItem.FindControl("FromDateTxt");
            TextBox ToDate = (TextBox)ListView1.InsertItem.FindControl("ToDateTxt");

            ParliamentaryYears ep = new ParliamentaryYears();
            ep.ParliamentaryTenuresId = Convert.ToInt32(ParliamentaryTenuresId.SelectedItem.Value);
            ep.ParliamentaryYear = Convert.ToString(ParliamentaryYearTxt.Text);
            ep.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);
            ep.FromDate = Convert.ToDateTime(FromDate.Text);
            ep.ToDate = Convert.ToDateTime(ToDate.Text);

            new AdministrationBiz().InsertParliamentaryYears(ep);
            ListView1.EditIndex = -1;

            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            //  }
            e.Cancel = true;

            Response.Redirect("ManageParliamentaryYears.aspx");

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            HiddenField ParliamentaryYearsId = ListView1.EditItem.FindControl("HidParliamentaryYearsId") as HiddenField;
            DropDownList ParliamentaryTenuresId = (DropDownList)ListView1.EditItem.FindControl("ParliamentaryTenureDDL");
            TextBox ParliamentaryYearTxt = (TextBox)ListView1.EditItem.FindControl("ParliamentaryYearTxt");
            DropDownList IsActive = (DropDownList)ListView1.EditItem.FindControl("IsActiveDDL");
            TextBox FromDate = (TextBox)ListView1.EditItem.FindControl("FromDateTxt");
            TextBox ToDate = (TextBox)ListView1.EditItem.FindControl("ToDateTxt");
            ParliamentaryYears ep = new ParliamentaryYears();
            ep.ParliamentaryYearsId = Convert.ToInt32(ParliamentaryYearsId.Value);
            ep.ParliamentaryYear = Convert.ToString(ParliamentaryYearTxt.Text);
            ep.ParliamentaryTenuresId = Convert.ToInt32(ParliamentaryTenuresId.SelectedItem.Value);
            ep.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);
            ep.FromDate = Convert.ToDateTime(FromDate.Text);
            ep.ToDate = Convert.ToDateTime(ToDate.Text);

            new AdministrationBiz().UpdateParliamentaryYears(ep);
            ListView1.EditIndex = -1;

            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            //  }
            e.Cancel = true;
        }
    }
}