using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class ManageGroups : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindSessionCB();
                BindDivisions();
            }
        }
        public void BindDivisions()
        {
            int AssemblySessionsId = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            List<Divisions> divisions = new AdministrationBiz().GetUnAssignedDivisions(AssemblySessionsId);
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
            List<AssemblySessions> AssSessions = new QuestionBiz().GetAssemblySessions();
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
            int DivisionId = Convert.ToInt32(DivisionsCB.SelectedItem.Value);
            List<Groups> gp = new List<Groups>();
            gp = new QuestionBiz().GetSessionCorrespondingGroup(AssemblySessionsId, GroupNumber);
            List<GroupDivisions> gd = new List<GroupDivisions>();
            foreach (Groups obj in gp)
            {
                GroupDivisions temp = new GroupDivisions();
                temp.GroupsId = obj.GroupsId;
                temp.DivisionsId = DivisionId;
                gd.Add(temp);
            }
            foreach (GroupDivisions gds in gd)
            {
                new QuestionBiz().InsertGroupDivisions(gds);
            }
            BindDivisions();
            BindGroupsDivisions();
        }

       public void DeleteGroupDivision(int GroupNumber,int DivisionId)
        {
            int AssemblySessionsId = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            List<Groups> gp = new List<Groups>();
            gp = new QuestionBiz().GetSessionCorrespondingGroup(AssemblySessionsId, GroupNumber);
            foreach (Groups temp in gp)
            {
                new QuestionBiz().DeleteGroupDivisions(temp.GroupsId, DivisionId);
            }
            BindDivisions();
            BindGroupsDivisions();
        }

        protected void OneOut_Click(object sender, EventArgs e)
        {
            DeleteGroupDivision(1, Convert.ToInt32(GroupOneLB.SelectedItem.Value));
        }

        protected void TwoOut_Click(object sender, EventArgs e)
        {
            DeleteGroupDivision(2, Convert.ToInt32(GroupTwoLB.SelectedItem.Value));
        }

        protected void ThreeOut_Click(object sender, EventArgs e)
        {
            DeleteGroupDivision(3, Convert.ToInt32(GroupThreeLB.SelectedItem.Value));
        }

        protected void FourOut_Click(object sender, EventArgs e)
        {
            DeleteGroupDivision(4, Convert.ToInt32(GroupFourLB.SelectedItem.Value));
        }

        protected void FiveOut_Click(object sender, EventArgs e)
        {
            DeleteGroupDivision(5, Convert.ToInt32(GroupFiveLB.SelectedItem.Value));
        }

     
    }
}
