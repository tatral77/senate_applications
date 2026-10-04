using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class SessionsRotaList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindListView1();
                //day.Text = Convert.ToString((int)DateTime.Now.DayOfWeek;
            }

        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList SessionsDDL = new DropDownList();
            SessionsDDL = (e.Item.FindControl("SessionDDL") as DropDownList);
            if (SessionsDDL != null)
            {
                List<AssemblySessions> ps = new AdministrationBiz().GetAssemblySessions();

                foreach (AssemblySessions row in ps)
                {
                    ListItem li = new ListItem();
                    li.Value = row.AssemblySessionsId.ToString();
                    li.Text = row.SessionNumber.ToString();
                    SessionsDDL.Items.Add(li);
                }

            }

            DropDownList RotaWeekDaysDDL = new DropDownList();
            RotaWeekDaysDDL = (e.Item.FindControl("RotaWeekDaysDDL") as DropDownList);
            if (RotaWeekDaysDDL != null)
            {
                List<RotaWeekDays> ps = new QuestionBiz().GetRotaWeekDays();

                foreach (RotaWeekDays row in ps)
                {
                    ListItem li = new ListItem();
                    li.Value = row.RotaWeekDayId.ToString();
                    li.Text = row.RotaWeekDay.ToString();
                    RotaWeekDaysDDL.Items.Add(li);
                }
            }
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
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (ListView1.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList SessionDDL = e.Item.FindControl("SessionDDL") as DropDownList;
                HiddenField HidAssemblySessionId = (e.Item.FindControl("HidAssemblySessionId") as HiddenField);
                SessionDDL.SelectedValue = HidAssemblySessionId.Value.ToString();

                DropDownList ListTypeDDL = e.Item.FindControl("ListTypeDDL") as DropDownList;
                HiddenField HidListType = (e.Item.FindControl("HidListType") as HiddenField);
                ListTypeDDL.SelectedValue = HidListType.Value.ToString();

                DropDownList RotaWeekDaysDDL = e.Item.FindControl("RotaWeekDaysDDL") as DropDownList;
                HiddenField HidRotaWeekDayId = (e.Item.FindControl("HidRotaWeekDayId") as HiddenField);
                RotaWeekDaysDDL.SelectedValue = HidRotaWeekDayId.Value.ToString();

                DropDownList StartGroupDDL = e.Item.FindControl("StartGroupDDL") as DropDownList;
                HiddenField HidStartGroup = (e.Item.FindControl("HidStartGroup") as HiddenField);
                StartGroupDDL.SelectedValue = HidStartGroup.Value.ToString();

                ListBox SkipedGroupsLB = e.Item.FindControl("SkipedGroupsLB") as ListBox;
                HiddenField HidRotaListId = (e.Item.FindControl("HidRotaListId") as HiddenField);
                if(SkipedGroupsLB!=null && HidRotaListId!=null)
                {
                    int RotaId = Convert.ToInt32(HidRotaListId.Value);
                    List<SkipRotaGroups> skipRotaGroups = new AdministrationBiz().GetRotaSkipDates(RotaId);
                    if(skipRotaGroups!=null)
                    {
                        foreach (SkipRotaGroups sg in skipRotaGroups)
                        {
                            ListItem li = new ListItem();
                            li.Value = sg.SkipDate.ToShortDateString() + "," + sg.SkipGroup;
                            li.Text= sg.SkipDate.ToShortDateString() + "(" + sg.SkipGroupDesc + ")";
                            SkipedGroupsLB.Items.Add(li);
                        }

                    }

                }
                ListBox AllowedDaysLB = e.Item.FindControl("AllowedDaysLB") as ListBox;
                HiddenField HidAllowedDates = (e.Item.FindControl("HidAllowedDates") as HiddenField);
                if (AllowedDaysLB != null && HidAllowedDates != null)
                {
                    if (!String.IsNullOrEmpty(HidAllowedDates.Value))
                    {
                        string allowedDates = HidAllowedDates.Value.Trim(',');
                        List<DateTime> AllowedDates = allowedDates.Split(',').Select(s => Convert.ToDateTime(s)).ToList();
                        foreach (DateTime sg in AllowedDates)
                        {
                            ListItem li = new ListItem();
                            li.Value = sg.ToShortDateString();
                            li.Text = sg.ToShortDateString();
                            AllowedDaysLB.Items.Add(li);
                        }

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
            DropDownList SessionDDL = (DropDownList)ListView1.InsertItem.FindControl("SessionDDL");
            DropDownList ListTypeDDL = (DropDownList)ListView1.InsertItem.FindControl("ListTypeDDL");
            TextBox StartListNoTxt = (TextBox)ListView1.InsertItem.FindControl("StartListNoTxt");
            TextBox FromDateTxt = (TextBox)ListView1.InsertItem.FindControl("FromDateTxt");
            TextBox ToDate = (TextBox)ListView1.InsertItem.FindControl("ToDateTxt");
            DropDownList StartGroupDDL = (DropDownList)ListView1.InsertItem.FindControl("StartGroupDDL");
            DropDownList RotaWeekDaysDDL = (DropDownList)ListView1.InsertItem.FindControl("RotaWeekDaysDDL");
           // TextBox SkipDays = (TextBox)ListView1.InsertItem.FindControl("SkipDaystxt");
            ListBox SkipDaysList = (ListBox)ListView1.InsertItem.FindControl("SkipedGroupsLB");
            ListBox AllowedDaysLB = (ListBox)ListView1.InsertItem.FindControl("AllowedDaysLB");
            QuestionsRota ep = new QuestionsRota();

            ep.SkipRotaGroups = new List<SkipRotaGroups>();
            foreach (ListItem li in SkipDaysList.Items)
            {
                SkipRotaGroups skipgroup = new SkipRotaGroups();
                skipgroup.SkipDate = Convert.ToDateTime(li.Value.Split(',')[0]);
                skipgroup.SkipGroup = Convert.ToInt32(li.Value.Split(',')[1]);
                if(skipgroup.SkipGroup==0)
                    skipgroup.SkipGroupDesc = "All Groups";
                else
                skipgroup.SkipGroupDesc = "Group-" + skipgroup.SkipGroup;
                ep.SkipRotaGroups.Add(skipgroup);
            }
            foreach (ListItem li in AllowedDaysLB.Items)
            {
                ep.AllowedDates += li.Text + ",";
            }
            if(!String.IsNullOrEmpty(ep.AllowedDates))
            ep.AllowedDates = ep.AllowedDates.Trim(',');
            ep.AssemblySessionsId = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            ep.StartListNo = Convert.ToInt32(StartListNoTxt.Text);
            ep.ListType = Convert.ToString(ListTypeDDL.SelectedItem.Value);
            ep.StartDate = Convert.ToDateTime(FromDateTxt.Text);
            ep.EndDate = Convert.ToDateTime(ToDate.Text);
            ep.StartGroup = Convert.ToInt32(StartGroupDDL.SelectedItem.Value);
            
                ep.RotaWeekDayId= Convert.ToInt32(RotaWeekDaysDDL.SelectedItem.Value);
            new AdministrationBiz().InsertQuestionRota(ep);
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            e.Cancel = true;

            Response.Redirect("SessionsRotaList.aspx");

        }
        public string GetDate(DateTime d)
        {
            return (Convert.ToString(d) == "01/01/0001 00:00:00") ? string.Empty : d.ToShortDateString();
        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            HiddenField HidRotaListId = ListView1.EditItem.FindControl("HidRotaListId") as HiddenField;
            DropDownList SessionDDL = (DropDownList)ListView1.EditItem.FindControl("SessionDDL");
            DropDownList ListTypeDDL = (DropDownList)ListView1.EditItem.FindControl("ListTypeDDL");
            TextBox StartListNoTxt = (TextBox)ListView1.EditItem.FindControl("StartListNoTxt");
            TextBox FromDateTxt = (TextBox)ListView1.EditItem.FindControl("FromDateTxt");
            TextBox ToDate = (TextBox)ListView1.EditItem.FindControl("ToDateTxt");
            DropDownList StartGroupDDL = (DropDownList)ListView1.EditItem.FindControl("StartGroupDDL");
            ListBox SkipDaysList = (ListBox)ListView1.EditItem.FindControl("SkipedGroupsLB");
            DropDownList RotaWeekDaysDDL = (DropDownList)ListView1.EditItem.FindControl("RotaWeekDaysDDL");
            ListBox AllowedDaysLB = (ListBox)ListView1.EditItem.FindControl("AllowedDaysLB");
            QuestionsRota ep = new QuestionsRota();
            if (SkipDaysList.Items.Count > 0)
            {
                ep.SkipRotaGroups = new List<SkipRotaGroups>();
                foreach (ListItem li in SkipDaysList.Items)
                {
                    SkipRotaGroups skipgroup = new SkipRotaGroups();
                    skipgroup.RotaId= Convert.ToInt32(HidRotaListId.Value);
                    skipgroup.SkipDate = Convert.ToDateTime(li.Value.Split(',')[0]);
                    skipgroup.SkipGroup = Convert.ToInt32(li.Value.Split(',')[1]);
                     if (skipgroup.SkipGroup == 0)
                        skipgroup.SkipGroupDesc = "All Groups";
                    else
                    skipgroup.SkipGroupDesc = "Group-" + skipgroup.SkipGroup;
                    ep.SkipRotaGroups.Add(skipgroup);
                }
            }
            foreach (ListItem li in AllowedDaysLB.Items)
            {
                ep.AllowedDates += li.Text + ",";
            }
            if(!String.IsNullOrEmpty(ep.AllowedDates))
            ep.AllowedDates = ep.AllowedDates.Trim(',');
            ep.RotaListId = Convert.ToInt32(HidRotaListId.Value);
            ep.AssemblySessionsId = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            ep.StartListNo = Convert.ToInt32(StartListNoTxt.Text);
            ep.ListType = Convert.ToString(ListTypeDDL.SelectedItem.Value);
            ep.StartDate = Convert.ToDateTime(FromDateTxt.Text);
            ep.EndDate = Convert.ToDateTime(ToDate.Text);
            ep.StartGroup = Convert.ToInt32(StartGroupDDL.SelectedItem.Value);
            ep.RotaWeekDayId = Convert.ToInt32(RotaWeekDaysDDL.SelectedItem.Value);
            new AdministrationBiz().UpdateQuestionRota(ep);
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            bindListView1();
            e.Cancel = true;
            Response.Redirect("SessionsRotaList.aspx");
        }
        protected void bindListView1()
        {
            List<QuestionsRota> QuestionTotaList = new AdministrationBiz().GetQuestionRotas();
            ListView1.DataSource = QuestionTotaList;
            ListView1.DataBind();

        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField HidRotaListId = (HiddenField)ListView1.Items[e.ItemIndex].FindControl("HidRotaListId");
            int EmpCourId = Convert.ToInt32(HidRotaListId.Value);
            new AdministrationBiz().DeleteQuestionRota(EmpCourId);
            bindListView1();
        }
        protected void AddGroupBtn_Click(object sender, EventArgs e)
        {
            ListBox SkipDaysList = null;
            TextBox SkipDateTxt = null;
            DropDownList SkipGroupDDL = null;
            bool matched = false;
            if (ListView1.EditIndex > -1)
            {
                SkipDaysList = (ListBox)ListView1.EditItem.FindControl("SkipedGroupsLB");
                SkipDateTxt = (TextBox)ListView1.EditItem.FindControl("SkipDateTxt");
                SkipGroupDDL = (DropDownList)ListView1.EditItem.FindControl("SkipGroupsDDL");
            }
            else
            {
                SkipDaysList = (ListBox)ListView1.InsertItem.FindControl("SkipedGroupsLB");
                SkipDateTxt = (TextBox)ListView1.InsertItem.FindControl("SkipDateTxt");
                SkipGroupDDL = (DropDownList)ListView1.InsertItem.FindControl("SkipGroupsDDL");
            }

            ListItem li = new ListItem();
            if (!string.IsNullOrEmpty(SkipDateTxt.Text))
            {
                li.Text = Convert.ToDateTime(SkipDateTxt.Text).ToShortDateString();
                li.Value= Convert.ToDateTime(SkipDateTxt.Text).ToShortDateString();
               
                    li.Text+="(" + SkipGroupDDL.SelectedItem.Text + ")";
                    li.Value += "," + SkipGroupDDL.SelectedItem.Value;
                
                string GroupDate = li.Value.Split(',')[0];
                if (SkipDaysList.Items.Count != 0)
                {

                    foreach (ListItem list in SkipDaysList.Items)
                    {
                        string ListDate = list.Value.Split(',')[0];
                        if (DateTime.Compare(Convert.ToDateTime(ListDate), Convert.ToDateTime(GroupDate)) == 0)
                        {
                            //if (list.Text.Equals(li.Text))
                            //{
                                matched = true;
                            //}
                        }
                    }
                }
                if (matched == false)
                {
                    if (!String.IsNullOrEmpty(li.Text))
                        SkipDaysList.Items.Add(li);
                    SkipDateTxt.Text = "";
                    SkipGroupDDL.SelectedValue = "0";

                }
            }
        }

        protected void RemoveGroupBtn_Click(object sender, EventArgs e)
        {
            ListBox SkipGroupsList = null;
            // TextBox SkipDaysTxt = null;

            if (ListView1.EditIndex > -1)
            {
                SkipGroupsList = (ListBox)ListView1.EditItem.FindControl("SkipedGroupsLB");
                //SkipDaysTxt = (TextBox)ListView1.EditItem.FindControl("SkipDaysTxt");
            }
            else
            {
                SkipGroupsList = (ListBox)ListView1.InsertItem.FindControl("SkipedGroupsLB");
                //SkipDaysTxt = (TextBox)ListView1.InsertItem.FindControl("SkipDaysTxt");
            }
            List<ListItem> dates = new List<ListItem>();
            foreach (ListItem list in SkipGroupsList.Items)
            {
                if (list.Selected == false)
                    dates.Add(list);
            }
            SkipGroupsList.Items.Clear();
            foreach (ListItem li2 in dates)
                SkipGroupsList.Items.Add(li2);
        }

        protected void AddDayBtn_Click(object sender, EventArgs e)
        {
            ListBox AllowedDaysLB = null;
            TextBox AddDaysTxt = null;
            bool matched = false;
            if (ListView1.EditIndex > -1)
            {
                AllowedDaysLB = (ListBox)ListView1.EditItem.FindControl("AllowedDaysLB");
                AddDaysTxt = (TextBox)ListView1.EditItem.FindControl("AddDaysTxt");
            }
            else
            {
                AllowedDaysLB = (ListBox)ListView1.InsertItem.FindControl("AllowedDaysLB");
                AddDaysTxt = (TextBox)ListView1.InsertItem.FindControl("AddDaysTxt");
            }

            ListItem li = new ListItem();
            if (!string.IsNullOrEmpty(AddDaysTxt.Text))
            {
                li.Text = Convert.ToDateTime(AddDaysTxt.Text).ToShortDateString();
                li.Value = Convert.ToDateTime(AddDaysTxt.Text).ToShortDateString();
                string GroupDate = li.Value.Split(',')[0];
                if (AllowedDaysLB.Items.Count != 0)
                {

                    foreach (ListItem list in AllowedDaysLB.Items)
                    {
                        string ListDate = list.Value.Split(',')[0];
                        if (DateTime.Compare(Convert.ToDateTime(ListDate), Convert.ToDateTime(GroupDate)) == 0)
                        {
                            //if (list.Text.Equals(li.Text))
                            //{
                            matched = true;
                            //}
                        }
                    }
                }
                if (matched == false)
                {
                    if (!String.IsNullOrEmpty(li.Text))
                        AllowedDaysLB.Items.Add(li);
                        AddDaysTxt.Text = "";

                }
            }
        }

        protected void RemoveDayBtn_Click(object sender, EventArgs e)
        {
            ListBox AllowedDaysLB = null;
            // TextBox SkipDaysTxt = null;

            if (ListView1.EditIndex > -1)
            {
                AllowedDaysLB = (ListBox)ListView1.EditItem.FindControl("AllowedDaysLB");
                //SkipDaysTxt = (TextBox)ListView1.EditItem.FindControl("SkipDaysTxt");
            }
            else
            {
                AllowedDaysLB = (ListBox)ListView1.InsertItem.FindControl("AllowedDaysLB");
                //SkipDaysTxt = (TextBox)ListView1.InsertItem.FindControl("SkipDaysTxt");
            }
            List<ListItem> dates = new List<ListItem>();
            foreach (ListItem list in AllowedDaysLB.Items)
            {
                if (list.Selected == false)
                    dates.Add(list);
            }
            AllowedDaysLB.Items.Clear();
            foreach (ListItem li2 in dates)
                AllowedDaysLB.Items.Add(li2);
        }
    }
}