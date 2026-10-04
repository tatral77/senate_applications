using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class ManageAssemblies : System.Web.UI.Page
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
            List<Assemblies> Assemblies = new AdministrationBiz().GetAssemblies();
            ListView1.DataSource = Assemblies;
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
                TextBox TermTxt = e.Item.FindControl("TermTxt") as TextBox;
                HiddenField HidTermId = (e.Item.FindControl("HidTermId") as HiddenField);
                //TermTxt.SelectedValue = HidMinistriesId.Value.ToString();

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
            TextBox Term = (TextBox)ListView1.InsertItem.FindControl("TermTxt");
            TextBox FromDate = (TextBox)ListView1.InsertItem.FindControl("FromDateTxt");
            TextBox ToDate = (TextBox)ListView1.InsertItem.FindControl("ToDateTxt");
            TextBox NoOfSeats = (TextBox)ListView1.InsertItem.FindControl("NoOfSeatsTxt");
            TextBox ElectionYear = (TextBox)ListView1.InsertItem.FindControl("ElectionYearTxt");
            TextBox MaxStarredAllowed = (TextBox)ListView1.InsertItem.FindControl("MaxStarredTxt");
            TextBox MaxUnStarredAllowed = (TextBox)ListView1.InsertItem.FindControl("MaxUnStarredTxt");
            TextBox MaxSNoticeAllowed = (TextBox)ListView1.InsertItem.FindControl("MaxSNoticeTxt");
            DropDownList IsActive = (DropDownList)ListView1.InsertItem.FindControl("IsActiveDDL");

            Assemblies ep = new Assemblies();
            // if (fuControl != null && PhoneNum != null)
            // {
            ep.Term = Convert.ToString(Term.Text);
            ep.FromDate = Convert.ToDateTime(FromDate.Text);
            ep.ToDate = Convert.ToDateTime(ToDate.Text);
            ep.NoOfSeats = Convert.ToInt32(NoOfSeats.Text);
            ep.ElectionYear = Convert.ToInt32(ElectionYear.Text);
            ep.MaxStarredAllowed = Convert.ToInt32(MaxStarredAllowed.Text);
            ep.MaxUnStarredAllowed = Convert.ToInt32(MaxUnStarredAllowed.Text);
            ep.MaxSNoticeAllowed = Convert.ToInt32(MaxSNoticeAllowed.Text);
            ep.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);
            new AdministrationBiz().InsertAssemblies(ep);
            ListView1.EditIndex = -1;

            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            //  }
            e.Cancel = true;

            Response.Redirect("ManageAssemblies.aspx");

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            TextBox Term = (TextBox)ListView1.EditItem.FindControl("TermTxt");
            TextBox FromDate = (TextBox)ListView1.EditItem.FindControl("FromDateTxt");
            TextBox ToDate = (TextBox)ListView1.EditItem.FindControl("ToDateTxt");
            TextBox NoOfSeats = (TextBox)ListView1.EditItem.FindControl("NoOfSeatsTxt");
            TextBox ElectionYear = (TextBox)ListView1.EditItem.FindControl("ElectionYearTxt");
            TextBox MaxStarredAllowed = (TextBox)ListView1.EditItem.FindControl("MaxStarredTxt");
            TextBox MaxUnStarredAllowed = (TextBox)ListView1.EditItem.FindControl("MaxUnStarredTxt");
            TextBox MaxSNoticeAllowed = (TextBox)ListView1.EditItem.FindControl("MaxSNoticeTxt");
            DropDownList IsActive = (DropDownList)ListView1.EditItem.FindControl("IsActiveDDL");
            Assemblies ep = new Assemblies();
            // if (fuControl != null && PhoneNum != null)
            // {
            ep.Term = Convert.ToString(Term.Text);
            ep.FromDate = Convert.ToDateTime(FromDate.Text);
            ep.ToDate = Convert.ToDateTime(ToDate.Text);
            ep.NoOfSeats = Convert.ToInt32(NoOfSeats.Text);
            ep.ElectionYear = Convert.ToInt32(ElectionYear.Text);
            ep.MaxStarredAllowed = Convert.ToInt32(MaxStarredAllowed.Text);
            ep.MaxUnStarredAllowed = Convert.ToInt32(MaxUnStarredAllowed.Text);
            ep.MaxSNoticeAllowed = Convert.ToInt32(MaxSNoticeAllowed.Text);
            ep.IsActive = Convert.ToInt32(IsActive.SelectedItem.Value);
            new AdministrationBiz().UpdateAssemblies(ep);
            ListView1.EditIndex = -1;

            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            //  }
            e.Cancel = true;
        }
    }
}