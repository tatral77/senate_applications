using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class ManageGroups : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearListBoxes();
                BindSessionCB();
                BindDivisions();
            }

        }
        // Buttons only work once a session is chosen.
        protected void Page_PreRender(object sender, EventArgs e)
        {
            bool ready = SessionDDL.SelectedValue != "0";
            foreach (LinkButton b in new[] { OneIn, OneOut, TwoIn, TwoOut, ThreeIn, ThreeOut, FourIn, FourOut, FiveIn, FiveOut })
                b.Enabled = ready;
            HintLbl.Text = ready ? "Session " + SessionDDL.SelectedItem.Text : "Choose a session to start.";
        }

        private void Say(string message, bool ok)
        {
            MsgLit.Text = Server.HtmlEncode(message);
            MsgPnl.CssClass = "mg-msg " + (ok ? "ok" : "err");
            MsgPnl.Visible = true;
        }

        private static List<int> SelectedIds(ListBox lb)
        {
            List<int> ids = new List<int>();
            foreach (ListItem li in lb.Items)
                if (li.Selected) ids.Add(Convert.ToInt32(li.Value));
            return ids;
        }

        private ListBox GroupList(int groupNumber)
        {
            switch (groupNumber)
            {
                case 1: return GroupOneLB;
                case 2: return GroupTwoLB;
                case 3: return GroupThreeLB;
                case 4: return GroupFourLB;
                default: return GroupFiveLB;
            }
        }

        public void BindDivisions()
        {
            int AssemblySessionsId = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            List<Divisions> divisions = new QuestionBiz().GetUnAssignedDivisions(AssemblySessionsId);
            foreach (Divisions div in divisions)
            {
                ListItem Temp = new ListItem();
                Temp.Value = Convert.ToString(div.DivisionsId);
                Temp.Text = Convert.ToString(div.Description);
                DivisionsCB.Items.Add(Temp);
            }
        }

        public void BindSessionCB()
        {
            List<AssemblySessions> AssSessions = new AdministrationBiz().GetAssemblySessions();
            foreach (AssemblySessions div in AssSessions)
            {
                ListItem Temp = new ListItem();
                Temp.Value = Convert.ToString(div.AssemblySessionsId);
                Temp.Text = Convert.ToString(div.SessionNumber);
                SessionDDL.Items.Add(Temp);
            }
        }
        public void BindGroupsDivisions()
        {
            int AssemblySessionsId = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            ClearListBoxes();
            BindDivisions();
            List<GroupDivisions> divisions = new QuestionBiz().GetGroupDivisions(AssemblySessionsId);
            if (divisions != null)
            {
                foreach (GroupDivisions div in divisions)
                {
                    ListItem Temp = new ListItem();
                    Temp.Value = Convert.ToString(div.DivisionsId);
                    Temp.Text = Convert.ToString(div.Division);
                    if (div.GroupSequence == 1)
                        GroupOneLB.Items.Add(Temp);
                    if (div.GroupSequence == 2)
                        GroupTwoLB.Items.Add(Temp);
                    if (div.GroupSequence == 3)
                        GroupThreeLB.Items.Add(Temp);
                    if (div.GroupSequence == 4)
                        GroupFourLB.Items.Add(Temp);
                    if (div.GroupSequence == 5)
                        GroupFiveLB.Items.Add(Temp);

                }
            }
        }
        public void ClearListBoxes()
        {
            DivisionsCB.Items.Clear();
            GroupOneLB.Items.Clear();
            GroupTwoLB.Items.Clear();
            GroupThreeLB.Items.Clear();
            GroupFourLB.Items.Clear();
            GroupFiveLB.Items.Clear();

        }
        protected void SessionDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            MsgPnl.Visible = false;
            BindGroupsDivisions();
        }

        protected void OneIn_Click(object sender, EventArgs e)
        {
            InsertGroupDivision(1);
        }
        protected void TwoIn_Click(object sender, EventArgs e)
        {
            InsertGroupDivision(2);
        }
        protected void ThreeIn_Click(object sender, EventArgs e)
        {
            InsertGroupDivision(3);
        }
        protected void FourIn_Click(object sender, EventArgs e)
        {
            InsertGroupDivision(4);
        }
        protected void FiveIn_Click(object sender, EventArgs e)
        {
            InsertGroupDivision(5);
        }

        public void InsertGroupDivision(int GroupNumber)
        {
            int AssemblySessionsId = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            if (AssemblySessionsId == 0) { Say("Choose a session first.", false); return; }
            List<int> divisionIds = SelectedIds(DivisionsCB);
            if (divisionIds.Count == 0) { Say("Select one or more divisions in the Available list first.", false); return; }

            List<Groups> gp = new QuestionBiz().GetSessionCorrespondingGroup(AssemblySessionsId, GroupNumber);
            foreach (int divisionId in divisionIds)
            {
                foreach (Groups obj in gp)
                {
                    GroupDivisions temp = new GroupDivisions();
                    temp.GroupsId = obj.GroupsId;
                    temp.DivisionsId = divisionId;
                    new QuestionBiz().InsertGroupDivisions(temp);
                }
            }
            BindGroupsDivisions();
            Say(divisionIds.Count + " division(s) added to Group " + GroupNumber + ".", true);
        }

        public void DeleteGroupDivision(int GroupNumber, int DivisionId)
        {
            int AssemblySessionsId = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            List<Groups> gp = new QuestionBiz().GetSessionCorrespondingGroup(AssemblySessionsId, GroupNumber);
            foreach (Groups temp in gp)
            {
                new QuestionBiz().DeleteGroupDivisions(temp.GroupsId, DivisionId);
            }
            BindGroupsDivisions();
        }

        // Removes every division selected in the group's list.
        private void RemoveSelected(int GroupNumber)
        {
            if (Convert.ToInt32(SessionDDL.SelectedItem.Value) == 0) { Say("Choose a session first.", false); return; }
            List<int> divisionIds = SelectedIds(GroupList(GroupNumber));
            if (divisionIds.Count == 0) { Say("Select one or more divisions in Group " + GroupNumber + " first.", false); return; }
            foreach (int divisionId in divisionIds)
                DeleteGroupDivision(GroupNumber, divisionId);
            Say(divisionIds.Count + " division(s) removed from Group " + GroupNumber + ".", true);
        }

        protected void OneOut_Click(object sender, EventArgs e) { RemoveSelected(1); }

        protected void TwoOut_Click(object sender, EventArgs e) { RemoveSelected(2); }

        protected void ThreeOut_Click(object sender, EventArgs e) { RemoveSelected(3); }

        protected void FourOut_Click(object sender, EventArgs e) { RemoveSelected(4); }

        protected void FiveOut_Click(object sender, EventArgs e) { RemoveSelected(5); }
    }
}
