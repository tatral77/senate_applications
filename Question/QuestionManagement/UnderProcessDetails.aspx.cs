using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class UnderProcessDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCombos();
            }

        }
        public void BindCombos()
        {
            List<AssemblySessions> ASessions = new AdministrationBiz().GetAssemblySessions();
            SessionDDL.Items.Add(new ListItem("Select", "0"));
            foreach (AssemblySessions row in ASessions)
            {
                ListItem li = new ListItem();
                li.Text = row.SessionNumber.ToString();
                li.Value = row.AssemblySessionsId.ToString();
                SessionDDL.Items.Add(li);
            }
            List<QuestionCategories> QCats = new AdministrationBiz().GetQuestionCategories();
            CategoryDDL.Items.Add(new ListItem("Select", "0"));
            foreach (QuestionCategories row in QCats)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.QuestionCategoriesId.ToString();
                CategoryDDL.Items.Add(li);
            }
        }

        protected void SessionDDL_SelectedIndexChanged1(object sender, EventArgs e)
        {
            CategoryDDL.SelectedItem.Value = "0";
            GroupDDL.Items.Clear();
            GroupDDL.Items.Add(new ListItem("Select", "0"));
        }
        public void BindGroupsDDL(int AssemblySessionId)
        {
            List<Groups> gps = null;
            int CategoryId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
            gps = new QuestionBiz().GetSessionGroups(AssemblySessionId, CategoryId);
            GroupDDL.Items.Clear();
            GroupDDL.Items.Add(new ListItem("Select", "0"));

            if (gps != null)
            {

                foreach (Groups obj in gps)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.GroupsId.ToString();
                    if (CategoryId == 2)
                        li.Text = obj.UnstarDesc;
                    else
                        li.Text = obj.Description;
                    GroupDDL.Items.Add(li);
                }
            }

        }
        public string GetMinText(string value)
        {
            string a = "pleased to state";
            int posA = value.LastIndexOf(a);
            if (posA == -1)
            {
                return value;
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= value.Length)
            {
                return value;
            }
            return value.Substring(adjustedPosA);
            //if (txt.Length >= 350)
            //    return txt.Substring(0, 300).Trim() + ".....";
            //else
            //    return txt;

        }

        protected void GenerateBtn_Click(object sender, EventArgs e)
        {
            int GroupNumber = Convert.ToInt32(GroupDDL.SelectedItem.Value);
            int category = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
            List<GroupDiary> LQ = new List<GroupDiary>();
            LQ = new QuestionBiz().GetUnderProcessPending(GroupNumber, category);
            LVStatus.DataSource = LQ;
            LVStatus.DataBind();
            Headerlbl.Text = "SESSION NO: " + SessionDDL.SelectedItem.Text + "<br>" + GroupDDL.SelectedItem.Text;

            //if (LQ != null)
            //{
            //    // TotalLabelLbl.Visible = true;
            //    // TotalQuestionsLbl.Text = Convert.ToString(QSummary.Count());
            //    var MemberCount =
            //   from p in LQ
            //   group p by p.Mover into g
            //   select new { Category = g.Key, MemberCount = g.Count() };
            //    MembersCountLv.DataSource = MemberCount;
            //    MembersCountLv.DataBind();

            //    var categoryCounts =
            //    from p in LQ
            //    group p by p.QuestionStatus into g
            //    select new { Category = g.Key, ProductCount = g.Count() };

            //    int count = (from row in LQ
            //                 where row.ListNo != 0
            //                 select row).Count();
            //    listquestions.Text = count.ToString();
            //    totalquestions.Text = LQ.Count().ToString();
            LVStatus.DataSource = LQ;
            LVStatus.DataBind();
            //}


        }
        public string GetNoticeInfo(int NoticeDiaryNo, DateTime NoticeDiaryDate, DateTime NoticeDiaryTime)
        {

            return "No: " + NoticeDiaryNo + "<br>" + NoticeDiaryDate.ToShortDateString() + "<br>" + NoticeDiaryTime.ToShortTimeString();
        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date).Substring(0, 9) == "1/01/0001") ? string.Empty : date.ToShortDateString();

        }
        public string GetListNo(int ListNo, DateTime ListDate)
        {
            if (ListNo == 0)
                return "Not Assigned";
            else
                return "List No: " + ListNo + "<br>" + ListDate.ToShortDateString();
        }

        protected void CategoryDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int AssemblySessionId = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            BindGroupsDDL(AssemblySessionId);
        }
        protected string GetColour(string status, int ListNo)
        {
            if (ListNo != 0)
                return "color:#996600;font-weight:bold";
            if (status == "Admitted")
                return "color:Green;font-weight:bold";
            else if (status == "Under Process")
                return "color:#000";
            else if (status == "Disallowed")
                return "text-decoration:line-through";
            else if (status == "Replied")
                return "font-style:italic;;font-weight:bold;color:Blue";
            else if (status == "File not Available")
                return "font-style:italic;;font-weight:bold;color:Brown";
            else if (status == "Not Assigned")
                return "font-weight:bold;color:#006600";


            else return "color:Black"; ;
        }
    }
}