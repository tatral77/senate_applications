using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class QuestionsList : System.Web.UI.Page
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
            foreach (QuestionCategories row in QCats)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.QuestionCategoriesId.ToString();
                CategoryDDL.Items.Add(li);
            }

        }
        protected void CategoryDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupDDL.Items.Clear();
            int AssemblySessionId = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            BindGroupsDDL(AssemblySessionId);

        }
        protected void SessionDDL_SelectedIndexChanged1(object sender, EventArgs e)
        {
            int AssemblySessionId = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            BindGroupsDDL(AssemblySessionId);
            BindListView();
            ListLV.DataSource = null;
            ListLV.DataBind();
            DeferLV.DataSource = null;
            DeferLV.DataBind();
        }
        public void BindListView()
        {
            int AssemblySessionId = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            List<QuestList> ql = new QuestionBiz().GetQuestionsList(AssemblySessionId);
            ListView1.DataSource = ql;
            ListView1.DataBind();

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
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {

            HiddenField QListId = (HiddenField)ListView1.Items[e.ItemIndex].FindControl("HidQuestionsListNo");

            int QuestionsListId = Convert.ToInt32(QListId.Value);
            DeleteSuplementaryLists(QuestionsListId);
            QuestList ql = new QuestList();
            ql = new QuestionBiz().GetQuestionList(QuestionsListId);
            if (!String.IsNullOrEmpty(ql.Questions))
            {
                List<int> questions = ql.Questions.Split(',').Select(s => Convert.ToInt32(s)).ToList();
                foreach (var QuestionId in questions)
                {
                    new QuestionBiz().UpdateListNo(QuestionId, 0, "Z", Convert.ToDateTime("01/01/1900"));
                }
            }
            //if (!String.IsNullOrEmpty(ql.DefQuestions))
            //{
            //    List<int> BSessionsDef = ql.DefQuestions.Split(',').Select(s => Convert.ToInt32(s)).ToList();
            //    foreach (var a in BSessionsDef)
            //    {
            //        new QuestionBiz().UpdateDeferStatus(ql.AssemblySessionsId, a, 0);
            //    }
            //}

            new QuestionBiz().DeleteQuestionsList(QuestionsListId);
            BindListView();
        }
        public void DeleteSuplementaryLists(int QuestionListId)
        {
            List<SuplementaryListEnt> SuplementaryLists = new List<SuplementaryListEnt>();
            SuplementaryLists = new QuestionBiz().GetQuestionsSupLists(QuestionListId);
            if (SuplementaryLists != null)
            {
                foreach (SuplementaryListEnt sl in SuplementaryLists)
                {
                    if (!String.IsNullOrEmpty(sl.Questions))
                    {
                        List<int> questions = sl.Questions.Split(',').Select(s => Convert.ToInt32(s)).ToList();
                        foreach (var QuestionId in questions)
                        {
                            new QuestionBiz().UpdateListNo(QuestionId, 0, "Z", Convert.ToDateTime("01/01/1900"));
                        }
                    }
                    new QuestionBiz().DeleteQuestionsSupList(sl.QuestionSupListId);
                }
            }
        }
        public string GetGroupName(int GroupId)
        {
            Groups Group = new QuestionBiz().GetGroupById(GroupId);
            if (Group != null)
                return Group.Description;
            else
                return "Not Mentioned";

        }
        public string GetSessionName(int AssemblySessionId)
        {
            AssemblySessions asession = new AdministrationBiz().GetAssemblySession(AssemblySessionId);
            if (asession != null)
                return asession.SessionNumber.ToString();
            else
                return "Not Mentioned";

        }
        public string GetPrintLink(string QuestionListId)
        {
            return "~/printList.aspx?QuestionListId=" + QuestionListId;
        }
        public string GetSuplementaryLink(string QuestionListId)
        {
            return "~/SuplementaryList.aspx?QuestionListId=" + QuestionListId;
        }
        protected int CalculateDays(DateTime NoticeDate)
        {

            DateTime HouseLayDate = Convert.ToDateTime(ListDateTxt.Text);
            int NumberOfDays = Convert.ToInt32((((HouseLayDate - NoticeDate).TotalDays) - 1));
            if (NumberOfDays >= 13)
                return 1;
            else
                return 0;

        }
        protected string GetListNo(int ListNo, string SupNo)
        {
            {
                if (SupNo == 'Z'.ToString())
                    return ListNo + "";
                else
                    return ListNo + "-" + SupNo;

            }

        }
        protected void GenerateBtn_Click(object sender, EventArgs e)
        {
            int startno = Convert.ToInt32(StartNoTxt.Text);
            int SessionNumber = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            int category = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
            AssemblySessions assession = new AdministrationBiz().GetAssemblySession(SessionNumber);
            int GroupNumber = Convert.ToInt32(GroupDDL.SelectedItem.Value);
            Groups Group = new Groups();
            Group = new QuestionBiz().GetGroupById(GroupNumber);
            DeferLV.DataSource = null;
            DeferLV.DataBind();
            if (AddDefferCB.Checked == true)
            {
                List<ListQuestion> DefferedQuestions = new List<ListQuestion>();
                DefferedQuestions = new QuestionBiz().GetDeferedQuestions(SessionNumber, Group.CorrespondingGroup, category);
                if (DefferedQuestions != null)
                {

                    var defQuestions = from p in DefferedQuestions
                                       orderby p.StatusDate, p.ListNo
                                       select p;
                    DeferLV.DataSource = DefferedQuestions;//defQuestions.ToList();
                    DeferLV.DataBind();
                }
            }

            ////////////////////////////////////////////// CARRY FORWARD LIST/////////////////
            List<ListQuestion> AllQuestions = new List<ListQuestion>();
            List<ListQuestion> CarryForwarededQuestions = new List<ListQuestion>();
            List<ListQuestion> PriorityQuestions = new List<ListQuestion>();
            if (assession.BusinessSessions != null)
            {
                List<int> BSessions = assession.BusinessSessions.Split(',').Select(s => Convert.ToInt32(s)).ToList();
                foreach (int a in BSessions)
                {
                    CarryForwarededQuestions = new QuestionBiz().GetCarryForwardQuestions(a, Group.GroupSequence, category);
                    if (CarryForwarededQuestions != null)
                    {
                        foreach (ListQuestion carryforwardedquestions in CarryForwarededQuestions)
                        {
                            AllQuestions.Add(carryforwardedquestions);
                        }
                    }
                }

            }
            List<ListQuestion> ListQuestions = new List<ListQuestion>();
            ListQuestions = new QuestionBiz().GetListQuestions(SessionNumber, Group.GroupsId, category);
            if (ListQuestions != null)
            {
                if (AllQuestions != null)
                {
                    foreach (ListQuestion row in ListQuestions)
                    {
                        if (CalculateDays(row.NoticeDiaryDate) == 1)
                            AllQuestions.Add(row);
                    }
                }
            }
            PriorityQuestions = new QuestionBiz().GetPriorityQuestions(SessionNumber, Group.GroupsId, category);
            if (PriorityQuestions != null)
            {
                if (AllQuestions != null)
                {
                    foreach (ListQuestion row in PriorityQuestions)
                    {
                        AllQuestions.Add(row);
                    }
                }
            }
            var sortbymember = from p in AllQuestions
                               orderby p.SystemUsersId, p.NoticeDiaryDate, p.NoticeDiaryTime, p.NoticeDiaryNo
                               select p;
            int LastNumber = new QuestionBiz().GetQuestionListLastNumber(SessionNumber, category);
            startno = LastNumber + 1;
            List<ListQuestion> final = new List<ListQuestion>();
            int Member = 0;
            int counter = 0;
            int cat = 0;
            if (category == 1)
                cat = 3;
            if (category == 2)
                cat = 5;

            foreach (ListQuestion cf1 in sortbymember)
            {
                if (Member != cf1.SystemUsersId)
                {
                    Member = cf1.SystemUsersId;
                    counter = 1;
                }
                else
                    counter++;
                if (counter <= cat)
                    final.Add(cf1);


            }
            var persons = from p in final
                          orderby p.NoticeDiaryDate, p.NoticeDiaryTime, p.NoticeDiaryNo
                          select p;
            if (persons != null)
            {
                string listquestions = null;
                foreach (ListQuestion Row in persons)
                {
                    listquestions += Row.QuestionId + "'";
                    Row.ListNo = startno;
                    startno++;
                }
            }

            if (AllQuestions != null)
            {
                ListLV.DataSource = persons.ToList();

            }
            else
            ListLV.DataSource = ListQuestions;
            ListLV.DataBind();


        }


        public string GetDefSenatorName(int ListNo, string supno, string MoverName)
        {

            return "*(DEF.) QUESTION NO. " + GetListNo(ListNo, supno) + " SENATOR " + MoverName.ToUpper() + ":";
        }
        public string GetListSenatorName(int ListNo, string MoverName)
        {
            int cat = Convert.ToInt32(CategoryDDL.SelectedItem.Value);

            if (cat == 1)
                return "*QUESTION NO. " + ListNo + " SENATOR " + MoverName.ToUpper() + ":";
            if (cat == 2)
                return "QUESTION NO. " + ListNo + " SENATOR " + MoverName.ToUpper() + ":";
            else
                return "";
        }
        public string GetNoticeDateTime(DateTime DiaryDate, DateTime DiaryTime, int qid)
        {
            return "( Notice Received on " + DiaryDate.ToShortDateString() + " at " + DiaryTime.ToShortTimeString() + ") QID: " + qid;
        }

        protected void SaveList_Click(object sender, EventArgs e)
        {
            QuestList ql = new QuestList();
            ql.AssemblySessionsId = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            ql.GroupsId = Convert.ToInt32(GroupDDL.SelectedItem.Value);
            ql.StartNo = Convert.ToInt32(StartNoTxt.Text);
            ql.CategoryId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
            ql.ListName = Convert.ToString(ListName.Text);
            string defquestions = null;
            List<int> deferedlist = new List<int>();
            foreach (ListViewDataItem item in DeferLV.Items)
            {

                HiddenField qid = item.FindControl("HidQid") as HiddenField;
                HiddenField lid = item.FindControl("HidListNo") as HiddenField;
                deferedlist.Add(Convert.ToInt32(qid.Value));
                if (defquestions != null)
                    defquestions = defquestions + ",";
                defquestions = defquestions + qid.Value;


            }
            ql.DefQuestions = defquestions;
            if (deferedlist != null)
            {
                foreach (int dl in deferedlist)
                {
                    new QuestionBiz().UpdateDeferStatus(ql.AssemblySessionsId, dl, 1);
                }
            }



            string questions = null;
            int LastNumber = 0;
            foreach (ListViewDataItem item in ListLV.Items)
            {

                HiddenField qid = item.FindControl("HidQid") as HiddenField;
                HiddenField lid = item.FindControl("HidListNo") as HiddenField;
                if (questions != null)
                    questions = questions + ",";
                questions = questions + qid.Value;

                if (qid != null && lid != null)
                {

                    new QuestionBiz().UpdateListNo(Convert.ToInt32(qid.Value), Convert.ToInt32(lid.Value), "Z", Convert.ToDateTime(ListDateTxt.Text));
                    LastNumber = Convert.ToInt32(lid.Value);
                }
            }
            ql.Questions = questions;
            ql.LastNumber = LastNumber;
            ql.ListDate = Convert.ToDateTime(ListDateTxt.Text);

            new QuestionBiz().InsertQuestionsList(ql);
            BindListView();
            Response.Redirect("~/QuestionsList.aspx");
        }

        protected void GroupDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListLV.DataSource = null;
            ListLV.DataBind();
            DeferLV.DataSource = null;
            DeferLV.DataBind();
        }
    }
}