using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class ManageSessionSittings : System.Web.UI.Page
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
            List<SessionSittings> SessionSittings = new AdministrationBiz().GetSessionSitting();
            ListView1.DataSource = SessionSittings;
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

                DropDownList AssemblySessionDDL = e.Item.FindControl("AssemblySessionDDL") as DropDownList;
                HiddenField HidAssemblySession = (e.Item.FindControl("HidSessionNumberId") as HiddenField);
                //ParliamentaryPeriodsDDL.SelectedValue = HidParliamentaryPeriodsId.Value.ToString();

                CheckBox IsMorningSittingCB = e.Item.FindControl("IsMorningSittingCB") as CheckBox;
                HiddenField IsMorningSitting = (e.Item.FindControl("HidIsMorningSittingCB") as HiddenField);
                IsMorningSittingCB.Checked = (Convert.ToInt32(IsMorningSitting.Value) == 1) ? true : false;

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
            HiddenField SessionSittingsId = ListView1.InsertItem.FindControl("HidSessionSittingsId") as HiddenField;
            TextBox Description = (TextBox)ListView1.InsertItem.FindControl("SessionSittingsIdTxt");
            DropDownList AssemblySession = (DropDownList)ListView1.InsertItem.FindControl("SessionNumberDDL");
            TextBox SessionDate = (TextBox)ListView1.InsertItem.FindControl("SessionDateTxt");
            TextBox StartTime = (TextBox)ListView1.InsertItem.FindControl("StartTimeTxt");
            TextBox EndTime = (TextBox)ListView1.InsertItem.FindControl("EndTimeTxt");
            CheckBox IsMorningSitting = (CheckBox)ListView1.InsertItem.FindControl("IsMorningSittingCB");
            TextBox EveningStartTime = (TextBox)ListView1.InsertItem.FindControl("EveningStartTimeTxt");
            TextBox EveningEndTime = (TextBox)ListView1.InsertItem.FindControl("EveningEndTimeTxt");
            SessionSittings ep = new SessionSittings();
            //ep.Description = Convert.ToString(Description.Text);
            ep.AssemblySession = Convert.ToString(AssemblySession.SelectedItem.Value);
            ep.Sessiondate = Convert.ToDateTime(SessionDate.Text);
            ep.StartTime = Convert.ToDateTime(StartTime.Text);
            ep.EndTime = Convert.ToDateTime(EndTime.Text);
            ep.IsMorningSitting = Convert.ToInt32(IsMorningSitting.Text);
            ep.EvenStartTime = Convert.ToDateTime(EveningStartTime.Text);
            ep.EvenEndTime = Convert.ToDateTime(EveningEndTime.Text);
            new AdministrationBiz().InsertSessionSittings(ep);
            ListView1.EditIndex = -1;

            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            //  }
            e.Cancel = true;

            Response.Redirect("ManageSessionSittings.aspx");

        }

        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            HiddenField SessionSittingsId = ListView1.EditItem.FindControl("HidSessionSittingsId") as HiddenField;
            TextBox Description = (TextBox)ListView1.EditItem.FindControl("SessionSittingsTxt");
            DropDownList AssemblySession = (DropDownList)ListView1.EditItem.FindControl("SessionNumberDDL");
            TextBox SessionDate = (TextBox)ListView1.EditItem.FindControl("SessionDateTxt");
            TextBox StartTime = (TextBox)ListView1.EditItem.FindControl("StartTimeTxt");
            TextBox EndTime = (TextBox)ListView1.EditItem.FindControl("EndTimeTxt");
            CheckBox IsMorningSitting = (CheckBox)ListView1.EditItem.FindControl("IsMorningSittingCB");
            TextBox EveningStartTime = (TextBox)ListView1.EditItem.FindControl("EveningStartTimeTxt");
            TextBox EveningEndTime = (TextBox)ListView1.EditItem.FindControl("EveningEndTimeTxt");
            SessionSittings ep = new SessionSittings();
            ep.AssemblySession = Convert.ToString(AssemblySession.SelectedItem.Value);
            ep.Sessiondate = Convert.ToDateTime(SessionDate.Text);
            ep.StartTime = Convert.ToDateTime(StartTime.Text);
            ep.EndTime = Convert.ToDateTime(EndTime.Text);
            ep.IsMorningSitting = Convert.ToInt32(IsMorningSitting.Text);
            ep.EvenStartTime = Convert.ToDateTime(EveningStartTime.Text);
            ep.EvenEndTime = Convert.ToDateTime(EveningEndTime.Text);
            new AdministrationBiz().UpdateSessionSittings(ep);
            ListView1.EditIndex = -1;

            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            //  }
            e.Cancel = true;
        }

        protected void SessionDDL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}