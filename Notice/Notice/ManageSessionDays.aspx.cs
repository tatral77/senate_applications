using BIZ;
using Entities;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Notice
{
    public partial class ManageSessionDays : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                AssemblySessions ASession = new AdministrationBiz().GetCurrentAssemblySessionDetails();
                // SessionMovementDDL.Items.Add(new ListItem("Select", "0"));
                List<AssemblySessions> ASessions = new AdministrationBiz().GetAssemblySessions();
                SessionDDL.Items.Add(new ListItem("Select", "0"));

                foreach (AssemblySessions row in ASessions)
                {
                    ListItem li = new ListItem();
                    li.Text = row.SessionNumber.ToString();
                    li.Value = row.AssemblySessionsId.ToString();
                    SessionDDL.Items.Add(li);
                }

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

                DropDownList AssemblySessionDDL = e.Item.FindControl("SessionDDL") as DropDownList;
                HiddenField HidAssembliesSessionId = (e.Item.FindControl("HidAssembliesSessionId") as HiddenField);
                AssemblySessionDDL.SelectedValue = HidAssembliesSessionId.Value.ToString();

                CheckBox IsAdjournedCB = e.Item.FindControl("IsAdjournedCB") as CheckBox;
                HiddenField HidIsAdjourned = (e.Item.FindControl("HidIsAdjourned") as HiddenField);
                IsAdjournedCB.Checked = (Convert.ToInt32(HidIsAdjourned.Value) == 1) ? true : false;

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
            DropDownList LvSessionDDL = new DropDownList();
            LvSessionDDL = (e.Item.FindControl("SessionDDL") as DropDownList);
            if (LvSessionDDL != null)
            {
                List<AssemblySessions> ps = new AdministrationBiz().GetAssemblySessions();

                foreach (AssemblySessions row in ps)
                {
                    ListItem li = new ListItem();
                    li.Value = row.AssemblySessionsId.ToString();
                    li.Text = row.SessionNumber.ToString();
                    LvSessionDDL.Items.Add(li);
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
            HiddenField SessionSittingsId = ListView1.InsertItem.FindControl("HidSessionSittingsId") as HiddenField;
            DropDownList LvSessionDDL = (DropDownList)ListView1.InsertItem.FindControl("SessionDDL");
            TextBox SittingDateTxt = (TextBox)ListView1.InsertItem.FindControl("SittingDateTxt");
            TextBox StartTime = (TextBox)ListView1.InsertItem.FindControl("StartTimeTxt");
            TextBox EndTime = (TextBox)ListView1.InsertItem.FindControl("EndTimeTxt");
            CheckBox IsAdjournedCB = (CheckBox)ListView1.InsertItem.FindControl("IsAdjournedCB");
            SessionSittings ep = new SessionSittings();
            ep.AssembliesSessionId = Convert.ToInt32(LvSessionDDL.SelectedItem.Value);
            ep.SittingDate = Convert.ToDateTime(SittingDateTxt.Text);
            ep.StartTime = JoindDateTime(ep.SittingDate, Convert.ToDateTime(StartTime.Text));
            ep.EndTime = JoindDateTime(ep.SittingDate, Convert.ToDateTime(EndTime.Text));
            ep.IsAdjourned = (IsAdjournedCB.Checked) ? 1 : 0;
            new AdministrationBiz().InsertSessionSittings(ep);
            ListView1.EditIndex = -1;

            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            e.Cancel = true;

            Response.Redirect("ManageSessionDays.aspx");

        }

        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            HiddenField SessionSittingsId = ListView1.EditItem.FindControl("HidSessionSittingsId") as HiddenField;
            DropDownList LvSessionDDL = (DropDownList)ListView1.EditItem.FindControl("SessionDDL");
            TextBox SittingDateTxt = (TextBox)ListView1.EditItem.FindControl("SittingDateTxt");
            TextBox StartTime = (TextBox)ListView1.EditItem.FindControl("StartTimeTxt");
            TextBox EndTime = (TextBox)ListView1.EditItem.FindControl("EndTimeTxt");
            CheckBox IsAdjournedCB = (CheckBox)ListView1.EditItem.FindControl("IsAdjournedCB");
            SessionSittings ep = new SessionSittings();
            ep.SessionSittingsId = Convert.ToInt32(SessionSittingsId.Value);
            ep.AssembliesSessionId = Convert.ToInt32(LvSessionDDL.SelectedItem.Value);
            ep.SittingDate = Convert.ToDateTime(SittingDateTxt.Text);
            ep.StartTime = JoindDateTime(ep.SittingDate, Convert.ToDateTime(StartTime.Text));
            ep.EndTime = JoindDateTime(ep.SittingDate, Convert.ToDateTime(EndTime.Text));
            ep.IsAdjourned = (IsAdjournedCB.Checked) ? 1 : 0;
            new AdministrationBiz().UpdateSessionSittings(ep);
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            e.Cancel = true;
        }
        protected DateTime JoindDateTime(DateTime dtDate, DateTime dtTime)
        {
            //DateTime dtDate =
            //DateTime.ParseExact(date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            //var dtTime = DateTime.ParseExact(time, "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime dtComplete = new DateTime(dtDate.Year, dtDate.Month, dtDate.Day, dtTime.Hour, dtTime.Minute, dtTime.Second);
            return dtComplete;

        }

        protected void MarkAttendanceBtn_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            string Id = linkButton.CommandArgument;
            Response.Redirect("MembersAttendance.aspx?Id=" + Id);

        }

        protected void SessionDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SessionId = Convert.ToInt32(SessionDDL.SelectedValue);
            List<SessionSittings> SessionSittings = new AdministrationBiz().GetSessionSittingBySession(SessionId);
            ListView1.DataSource = SessionSittings;
            ListView1.DataBind();
        }
    }
}