using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class NewMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindFields();
                // bindLV();
            }

        }
        public void bindLV()
        {
            List<NewMemberInfo> members = new QuestionBiz().GetMemberBasicInfo();
            MembersLv.DataSource = members;
            MembersLv.DataBind();
        }
        public void bindFields()
        {

            List<Gender> genders = new AdministrationBiz().GetGenders();
            GenderDDL.Items.Add(new ListItem("Select", "0"));
            if (genders != null)
            {
                foreach (Gender row in genders)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.GenderId.ToString();
                    GenderDDL.Items.Add(li);
                }
            }

            List<Assemblies> assemblies = new AdministrationBiz().GetAssemblies();
            AssemblyDDL.Items.Add(new ListItem("Select", "0"));
            SearchTenureDDL.Items.Add(new ListItem("Select", "0"));
            if (assemblies != null)
            {
                foreach (Assemblies row in assemblies)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Term;
                    li.Value = row.AssembliesId.ToString();
                    AssemblyDDL.Items.Add(li);
                    SearchTenureDDL.Items.Add(li);
                }
            }

            List<MemberStatus> memberstatus = new AdministrationBiz().GetMemberStatuses();
            MemberStatusDDL.Items.Add(new ListItem("Select", "0"));
            SearchStatusDDL.Items.Add(new ListItem("Select", "0"));
            if (memberstatus != null)
            {
                foreach (MemberStatus row in memberstatus)
                {
                    ListItem li = new ListItem();
                    li.Text = row.MemStatus;
                    li.Value = row.MemberStatusId.ToString();
                    MemberStatusDDL.Items.Add(li);
                    SearchStatusDDL.Items.Add(li);
                }
            }

            List<PoliticalParty> politicalparty = new AdministrationBiz().GetPoliticalParties();
            PoliticalPartyDDL.Items.Add(new ListItem("Select", "0"));
            SearchPartyDDL.Items.Add(new ListItem("Select", "0"));

            if (politicalparty != null)
            {
                foreach (PoliticalParty row in politicalparty)
                {
                    ListItem li = new ListItem();
                    li.Text = row.PartyName;
                    li.Value = row.PartyId.ToString();
                    PoliticalPartyDDL.Items.Add(li);
                    SearchPartyDDL.Items.Add(li);
                }
            }

            List<ElectionTypes> electiontypes = new AdministrationBiz().GetElectionTypes();
            ElectionTypeDDL.Items.Add(new ListItem("Select", "0"));
            if (electiontypes != null)
            {
                foreach (ElectionTypes row in electiontypes)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.ElectionTypesId.ToString();
                    ElectionTypeDDL.Items.Add(li);
                }
            }
        }
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            MembersLv.InsertItemPosition = InsertItemPosition.None;
            MembersLv.SelectedIndex = -1;
            MembersLv.EditIndex = e.NewEditIndex;
            SearchMembers();
            e.Cancel = true;


        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (MembersLv.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {

                DropDownList TenureDDL = e.Item.FindControl("LVTenureDDL") as DropDownList;
                HiddenField HidMemberTenureId = (e.Item.FindControl("HidMemberTenureId") as HiddenField);
                TenureDDL.SelectedValue = HidMemberTenureId.Value.ToString();



                DropDownList StatusDDL = e.Item.FindControl("LVStatusDDL") as DropDownList;
                HiddenField HidMemberStatusId = (e.Item.FindControl("HidMemberStatusId") as HiddenField);
                StatusDDL.SelectedValue = HidMemberStatusId.Value.ToString();


                DropDownList PartyDDL = e.Item.FindControl("LVPartyDDL") as DropDownList;
                HiddenField HidPartyId = (e.Item.FindControl("HidPartyId") as HiddenField);
                PartyDDL.SelectedValue = HidPartyId.Value.ToString();
            }
        }

        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            MembersLv.EditIndex = -1;
            MembersLv.InsertItemPosition = InsertItemPosition.None;
            MembersLv.SelectedIndex = -1;
            SearchMembers();
            e.Cancel = true;
        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList AssemblyDDL = (e.Item.FindControl("LVTenureDDL") as DropDownList);
            List<Assemblies> assemblies = new AdministrationBiz().GetAssemblies();
            if (AssemblyDDL != null)
            {
                AssemblyDDL.Items.Add(new ListItem("Select", "0"));
                if (assemblies != null)
                {
                    foreach (Assemblies row in assemblies)
                    {
                        ListItem li = new ListItem();
                        li.Text = row.Term;
                        li.Value = row.AssembliesId.ToString();
                        AssemblyDDL.Items.Add(li);
                    }
                }
            }

            DropDownList LVStatusDDL = (e.Item.FindControl("LVStatusDDL") as DropDownList);
            List<MemberStatus> memberstatus = new AdministrationBiz().GetMemberStatuses();

            if (memberstatus != null && LVStatusDDL != null)
            {
                LVStatusDDL.Items.Add(new ListItem("Select", "0"));
                foreach (MemberStatus row in memberstatus)
                {
                    ListItem li = new ListItem();
                    li.Text = row.MemStatus;
                    li.Value = row.MemberStatusId.ToString();
                    LVStatusDDL.Items.Add(li);
                }
            }

            DropDownList LVPoliticalPartyDDL = (e.Item.FindControl("LVPartyDDL") as DropDownList);
            List<PoliticalParty> politicalparty = new AdministrationBiz().GetPoliticalParties();

            if (politicalparty != null && LVPoliticalPartyDDL != null)
            {
                LVPoliticalPartyDDL.Items.Add(new ListItem("Select", "0"));
                foreach (PoliticalParty row in politicalparty)
                {
                    ListItem li = new ListItem();
                    li.Text = row.PartyName;
                    li.Value = row.PartyId.ToString();
                    LVPoliticalPartyDDL.Items.Add(li);
                }
            }

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField HidMemberId = MembersLv.EditItem.FindControl("HidMemberId") as HiddenField;
            TextBox MemberNameTxt = MembersLv.EditItem.FindControl("MemberNameTxt") as TextBox;
            TextBox MemberUrduNameTxt = MembersLv.EditItem.FindControl("MemberUrduNameTxt") as TextBox;
            DropDownList TenureDDL = MembersLv.EditItem.FindControl("LVTenureDDL") as DropDownList;
            DropDownList PartyDDL = (DropDownList)MembersLv.EditItem.FindControl("LVPartyDDL");
            DropDownList MemberStatusDDL = (DropDownList)MembersLv.EditItem.FindControl("LVStatusDDL");
            NewMemberInfo ep = new NewMemberInfo();
            ep.MemberId = Convert.ToInt32(HidMemberId.Value);
            ep.MemberName = Convert.ToString(MemberNameTxt.Text);
            ep.UrduName = Convert.ToString(MemberUrduNameTxt.Text);
            ep.MemberTenureId = Convert.ToInt32(TenureDDL.SelectedItem.Value);
            ep.PartyId = Convert.ToInt32(PartyDDL.SelectedItem.Value);
            ep.MemberStatusId = Convert.ToInt32(MemberStatusDDL.SelectedItem.Value);
            new QuestionBiz().UpdateMemberBasicInfo(ep);
            new QuestionBiz().InsertUrduName(Convert.ToInt32(HidMemberId.Value), Convert.ToString(MemberUrduNameTxt.Text));
            MembersLv.EditIndex = -1;
            MembersLv.InsertItemPosition = InsertItemPosition.None;
            SearchMembers();
            //  }
            e.Cancel = true;
        }
        protected void Save_Click(object sender, EventArgs e)
        {
            NewMemberInfo binfo = new NewMemberInfo();
            binfo.MemberName = EmpName.Text;
            binfo.UrduName = UrduName.Text;
            binfo.GenderId = Convert.ToInt32(GenderDDL.SelectedValue);
            binfo.PartyId = Convert.ToInt32(PoliticalPartyDDL.SelectedValue);
            binfo.MemberTenureId = Convert.ToInt32(AssemblyDDL.SelectedValue);
            binfo.MemberStatusId = Convert.ToInt32(MemberStatusDDL.SelectedValue);
            binfo.ElectionTypeId = Convert.ToInt32(ElectionTypeDDL.SelectedValue);
            binfo.IsMinister = (IsMinisterCB.Checked) ? 1 : 0;
            int EmpId = new QuestionBiz().INSERT_NEW_MEMBER(binfo);
            binfo.MemberId = EmpId;
            new QuestionBiz().InsertMemberId(binfo);
            Response.Redirect("~/NewMember.aspx");

        }
        protected void Search_Click(object sender, EventArgs e)
        {

            SearchMembers();


        }
        protected void Reset_Click(object sender, EventArgs e)
        {
            SearchNameTxt.Text = "";
            SearchStatusDDL.SelectedIndex = 0;
            SearchTenureDDL.SelectedIndex = 0;
            SearchPartyDDL.SelectedIndex = 0;
            MembersLv.EditIndex = -1;
            MembersLv.DataSource = null;
            MembersLv.DataBind();
            ResultCountLbl.Text = "Use the filters above and press Search to list members.";
        }
        protected void SearchMembers()
        {
            string criteria = GetCriteria();
            //if (GetCriteria() == String.Empty)
            //    bindLV();
            //else
            //{
            string query = "SELECT MEMBERS.SYSTEM_USERS_ID, CONCAT(ISNULL(SYSTEM_USERS.F_NAME, ' '), ' ', ISNULL(SYSTEM_USERS.M_NAME, ' '), ' ', ISNULL(SYSTEM_USERS.L_NAME, '')) AS F_NAME,SYSTEM_USERS.URDU_NAME, MEMBERS.ASSEMBLIES_ID, MEMBERS.POLITICAL_PARTY, MEMBERS.MEMBER_STATUS AS MEMBER_STATUS_ID, ";
            query += " ASSEMBLIES.TERM, POLITICAL_PARTIES.DESCRIPTION AS PARTY, MEMBER_STATUSES.DESCRIPTION AS MEMBER_STATUS, ";
            query += " (SELECT COUNT(QUESTIONS_ID) FROM QUESTIONS WHERE MOVER = MEMBERS.SYSTEM_USERS_ID) AS NOOFQUESTIONS ";
            query += " FROM SYSTEM_USERS INNER JOIN ";
            query += " MEMBERS ON SYSTEM_USERS.SYSTEM_USERS_ID = MEMBERS.SYSTEM_USERS_ID INNER JOIN ";
            query += " MEMBER_STATUSES ON MEMBERS.MEMBER_STATUS = MEMBER_STATUSES.MEMBER_STATUSES_ID INNER JOIN ";
            query += " POLITICAL_PARTIES ON MEMBERS.POLITICAL_PARTY = POLITICAL_PARTIES.POLITICAL_PARTIES_ID INNER JOIN ";
            query += " ASSEMBLIES ON MEMBERS.ASSEMBLIES_ID = ASSEMBLIES.ASSEMBLIES_ID";
            if (GetCriteria() != String.Empty)
            {
                query += " WHERE ";
                query += GetCriteria();
            }
            query += " ORDER BY MEMBERS.POLITICAL_PARTY,F_NAME,MEMBERS.MEMBER_STATUS";
            List<NewMemberInfo> members = new QuestionBiz().GetMemberBasicInfo(query);
            MembersLv.DataSource = members;
            MembersLv.DataBind();
            int count = members == null ? 0 : members.Count;
            ResultCountLbl.Text = count == 0 ? "No members match your search." : count + (count == 1 ? " member found" : " members found");
            // }
        }
        // Escapes a search word for use inside LIKE N'%...%'.
        private static string LikeText(string word)
        {
            return word.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]");
        }

        private static bool IsId(string value)
        {
            int id;
            return int.TryParse(value, out id) && id > 0;
        }

        protected string GetCriteria()
        {
            List<string> parts = new List<string>();

            if (IsId(SearchPartyDDL.SelectedItem.Value))
                parts.Add("MEMBERS.POLITICAL_PARTY=" + int.Parse(SearchPartyDDL.SelectedItem.Value));
            if (IsId(SearchStatusDDL.SelectedItem.Value))
                parts.Add("MEMBERS.MEMBER_STATUS=" + int.Parse(SearchStatusDDL.SelectedItem.Value));
            if (IsId(SearchTenureDDL.SelectedItem.Value))
                parts.Add("MEMBERS.ASSEMBLIES_ID=" + int.Parse(SearchTenureDDL.SelectedItem.Value));

            // every word typed must appear in the member's full name or in the Urdu name, so "ali khan" finds "Ali Ahmed Khan"
            foreach (string word in (SearchNameTxt.Text ?? "").Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries))
            {
                string like = LikeText(word);
                parts.Add("(ISNULL(SYSTEM_USERS.F_NAME, '') + ' ' + ISNULL(SYSTEM_USERS.M_NAME, '') + ' ' + ISNULL(SYSTEM_USERS.L_NAME, '') LIKE N'%" + like + "%' OR ISNULL(SYSTEM_USERS.URDU_NAME, '') LIKE N'%" + like + "%')");
            }
            return string.Join(" AND ", parts);
        }
    }
}
