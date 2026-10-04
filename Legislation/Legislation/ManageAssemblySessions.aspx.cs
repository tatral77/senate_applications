using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LegisBIZ;
using LegisEntities;

namespace QuestionManagement
{
    public partial class ManageAssemblySessions : System.Web.UI.Page
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
            List<AssemblySessions> assemblySessions = new LegislationBiz().GetAssemblySessions();
            ListView1.DataSource = assemblySessions;
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
                DropDownList ParliamentaryYearDDL = e.Item.FindControl("ParliamentaryYearDDL") as DropDownList;
                HiddenField HidParliamentaryYearsId = (e.Item.FindControl("HidParliamentaryYearsId") as HiddenField);
                ParliamentaryYearDDL.SelectedValue = HidParliamentaryYearsId.Value.ToString();

               
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
            DropDownList ParliamentaryYearDDL = new DropDownList();
            ParliamentaryYearDDL = (e.Item.FindControl("ParliamentaryYearDDL") as DropDownList);
            if (ParliamentaryYearDDL != null)
            {
                List<ParliamentaryYears> ps = new LegislationBiz().GetParliamentaryYears();

                foreach (ParliamentaryYears row in ps)
                {
                    ListItem li = new ListItem();
                    li.Value = row.ParliamentaryYearsId.ToString();
                    li.Text = row.ParliamentaryYear.ToString();
                    ParliamentaryYearDDL.Items.Add(li);
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
            TextBox Description = (TextBox)ListView1.InsertItem.FindControl("AssemblySessionsTxt");
            DropDownList ParliamentaryTenureDDL = (DropDownList)ListView1.InsertItem.FindControl("ParliamentaryTenureDDL");
            DropDownList IsActive = (DropDownList)ListView1.InsertItem.FindControl("IsActiveDDL");
            TextBox FromDate = (TextBox)ListView1.InsertItem.FindControl("FromDateTxt");
            TextBox ToDate = (TextBox)ListView1.InsertItem.FindControl("ToDateTxt");
            AssemblySessions ep = new AssemblySessions();
            //ep.Description = Convert.ToString(Description.Text);
            //ep.ParliamentaryTenureId = Convert.ToInt32(ParliamentaryTenureDDL.SelectedItem.Value);
            //ep.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);
            //ep.FromDate = Convert.ToDateTime(FromDate.Text);
            //ep.ToDate = Convert.ToDateTime(ToDate.Text);
            //new LegislationBiz().InsertAssemblySession(ep);
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            e.Cancel = true;

            Response.Redirect("ManageAssemblySessions.aspx");

        }
        public string GetDate(DateTime date)
        {
            if (date < Convert.ToDateTime("01/01/1900"))
                return "";
            else
                return date.ToShortDateString();

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            HiddenField HidAssemblySessionsId = ListView1.EditItem.FindControl("HidAssemblySessionsId") as HiddenField;
            TextBox Description = (TextBox)ListView1.EditItem.FindControl("AssemblySessionsTxt");
            DropDownList ParliamentaryYearDDL = (DropDownList)ListView1.EditItem.FindControl("ParliamentaryYearDDL");
            TextBox StartDateTxt = (TextBox)ListView1.EditItem.FindControl("StartDateTxt");
            TextBox EndDateTxt = (TextBox)ListView1.EditItem.FindControl("EndDateTxt");
            AssemblySessions ep = new AssemblySessions();
            ep.AssemblySessionsId = Convert.ToInt32(HidAssemblySessionsId.Value);
            ep.ParliamentaryYearsId = Convert.ToInt32(ParliamentaryYearDDL.SelectedItem.Value);
            //ep.Description = Convert.ToString(Description.Text);
            //ep.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);
            if(!string.IsNullOrEmpty(StartDateTxt.Text))
            ep.StartDate = Convert.ToDateTime(StartDateTxt.Text);
            if (!string.IsNullOrEmpty(EndDateTxt.Text))
                ep.EndDate = Convert.ToDateTime(EndDateTxt.Text);
            //ep.ToDate = Convert.ToDateTime(ToDate.Text);
            new LegislationBiz().UpdateAssemblySessions(ep);
            ListView1.EditIndex = -1;

            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            //  }
            e.Cancel = true;
        }
    }
}