using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class SuplementaryList : System.Web.UI.Page
    {
        public class MemberQuestions
        {
            public int SystemUsersId { get; set; }
            public int NoOfQuestions { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindListView();
                BindCombos();
            }
        }

        public void BindCombos()
        {


        }


        public void BindListView()
        {
            int QuestionListId = Convert.ToInt32(Request.QueryString["QuestionListId"]);
            QuestList QL = new QuestionBiz().GetQuestionList(QuestionListId);
            int AssemblySessionId = QL.AssemblySessionsId;
            ListName.Text = "Supplementary " + QL.ListName;
            List<SuplementaryListEnt> ql = new QuestionBiz().GetQuestionsSupLists(QuestionListId);
            ListView1.DataSource = ql;
            ListView1.DataBind();

        }
        //public void BindGroupsDDL(int AssemblySessionId)
        //{
        //    List<Groups> gps = null;
        //    int CategoryId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
        //    gps = new QuestionBiz().GetSessionGroups(AssemblySessionId, CategoryId);
        //    GroupDDL.Items.Clear();
        //    GroupDDL.Items.Add(new ListItem("Select", "0"));

        //    if (gps != null)
        //    {

        //        foreach (Groups obj in gps)
        //        {
        //            ListItem li = new ListItem();
        //            li.Value = obj.GroupsId.ToString();
        //            if (CategoryId == 2)
        //                li.Text = obj.UnstarDesc;
        //            else
        //                li.Text = obj.Description;
        //            GroupDDL.Items.Add(li);
        //        }
        //    }

        //}
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            int QuestionListId = Convert.ToInt32(Request.QueryString["QuestionListId"]);
            HiddenField HidQuestionsListId = (HiddenField)ListView1.Items[e.ItemIndex].FindControl("HidQuestionsListNo");
            int QuestionsListId = Convert.ToInt32(HidQuestionsListId.Value);
            SuplementaryListEnt questionlist = new SuplementaryListEnt();
            questionlist = new QuestionBiz().GetQuestionSupList(QuestionsListId);
            if (!String.IsNullOrEmpty(questionlist.Questions))
            {
                List<int> BSessions = questionlist.Questions.Split(',').Select(s => Convert.ToInt32(s)).ToList();
                foreach (var QuestionId in BSessions)
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

            new QuestionBiz().DeleteQuestionsSupList(QuestionsListId);
            Response.Redirect("~/SuplementaryList.aspx?QuestionListId=" + QuestionListId);

        }
        public string GetGroupName(int GroupId)
        {
            Groups gp = new QuestionBiz().GetGroupById(GroupId);
            if (gp != null)
                return gp.Description;
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
            return "~/PrintSuplimentaryList.aspx?QuestionListId=" + QuestionListId;
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
        protected void GenerateBtn_Click(object sender, EventArgs e)
        {

            int QuestionListId = Convert.ToInt32(Request.QueryString["QuestionListId"]);
            QuestList QL = new QuestList();

            // GET QUESTION LIST
            QL = new QuestionBiz().GetQuestionList(QuestionListId);

            int LastListNoAssigned = 0;
            int Group = QL.GroupsId;
            int CategoryId = QL.CategoryId;
            int AssemblySessionId = QL.AssemblySessionsId;
            List<ListQuestion> NewQuestions = new List<ListQuestion>();
            List<ListQuestion> CarryForwardedQuestions = new List<ListQuestion>();
            List<ListQuestion> CurrentQuestions = new List<ListQuestion>();
            List<ListQuestion> JoinedQuestions = new List<ListQuestion>();
            List<ListQuestion> FinalQuestions = new List<ListQuestion>();


            AssemblySessions ListAssemblySession = new AdministrationBiz().GetAssemblySession(AssemblySessionId);

            if (ListAssemblySession.BusinessSessions != null)
            {
                List<int> BSessions = ListAssemblySession.BusinessSessions.Split(',').Select(s => Convert.ToInt32(s)).ToList();
                foreach (int AssSessionId in BSessions)
                {
                    CarryForwardedQuestions = new QuestionBiz().GetCarryForwardQuestions(AssSessionId, Group, CategoryId);
                    if (CarryForwardedQuestions != null)
                    {
                        foreach (ListQuestion carryforwardedquestion in CarryForwardedQuestions)
                        {
                            NewQuestions.Add(carryforwardedquestion);
                            JoinedQuestions.Add(carryforwardedquestion);
                        }
                    }
                }

            }
            CurrentQuestions = new QuestionBiz().GetListQuestions(AssemblySessionId, Group, CategoryId);
            if (CurrentQuestions != null)
            {
                if (NewQuestions != null)
                {
                    foreach (ListQuestion row in CurrentQuestions)
                    {
                        if (CalculateDays(row.NoticeDiaryDate) == 1)
                            NewQuestions.Add(row);
                        JoinedQuestions.Add(row);
                    }
                }
            }
            List<ListQuestion> PreviousQuestions = new List<ListQuestion>();
            if (!String.IsNullOrEmpty(QL.Questions))
            {
                List<int> questions = QL.Questions.Split(',').Select(s => Convert.ToInt32(s)).ToList();
                if (questions != null)
                {
                    foreach (int qs in questions)
                    {
                        ListQuestion listquestion = new QuestionBiz().GetListQuestion(qs);
                        PreviousQuestions.Add(listquestion);
                        LastListNoAssigned = listquestion.ListNo;
                        //JoinedQuestions.Add(listquestion);
                    }
                }
            }

            // Sort previous questions by Member
            var SortByMemberPrevQues = from p in PreviousQuestions
                                       orderby p.SystemUsersId, p.NoticeDiaryDate, p.NoticeDiaryTime, p.NoticeDiaryNo
                                       select p;
            int AllowedQuestions = 0;
            int MemberId = 0;
            if (CategoryId == 1)
                AllowedQuestions = 3;
            if (CategoryId == 2)
                AllowedQuestions = 5;

            //Get Member Id and Previous number of questions
            var MemberNoOfQuestions = (PreviousQuestions.GroupBy(d => d.SystemUsersId).Select(d => new { SystemUsersId = d.Key, NumberOfQuestions = AllowedQuestions - d.Count() })).ToList();
            var SortByNoticeDiary = from p in JoinedQuestions
                                    orderby p.NoticeDiaryDate, p.NoticeDiaryTime, p.NoticeDiaryNo
                                    select p;

            //Store MemberId and No of Questions into a list
            List<MemberQuestions> memberquestionslist = new List<MemberQuestions>();
            foreach (var b in MemberNoOfQuestions)
            {
                MemberQuestions memberquestions = new MemberQuestions();
                memberquestions.SystemUsersId = b.SystemUsersId;
                memberquestions.NoOfQuestions = b.NumberOfQuestions;
                memberquestionslist.Add(memberquestions);

            }
            foreach (ListQuestion listquestions in SortByNoticeDiary)
            {
                if (memberquestionslist != null && listquestions != null)
                {
                    foreach (var a in memberquestionslist)
                    {
                        if (listquestions.SystemUsersId == a.SystemUsersId)
                            MemberId = a.SystemUsersId;

                    }
                    // MemberId = memberquestionslist.Find(x => x.SystemUsersId == listquestions.SystemUsersId).SystemUsersId;
                    if (MemberId != listquestions.SystemUsersId)
                    {
                        MemberQuestions memberquestions = new MemberQuestions();
                        memberquestions.SystemUsersId = listquestions.SystemUsersId;
                        memberquestions.NoOfQuestions = AllowedQuestions;
                        memberquestionslist.Add(memberquestions);
                    }
                }

            }


            char sn = 'A';
            foreach (ListQuestion listquestions in SortByNoticeDiary)
            {
                int NoOfQuestions = 3;
                foreach (var a in memberquestionslist)
                {
                    if (listquestions.SystemUsersId == a.SystemUsersId)
                        NoOfQuestions = a.NoOfQuestions;

                }
                //try {
                //    NoOfQuestions = memberquestionslist.Find(x => x.SystemUsersId == listquestions.SystemUsersId).NoOfQuestions;
                if (NoOfQuestions > 0)
                {

                    listquestions.ListNo = LastListNoAssigned;
                    listquestions.SuplementaryNo = sn++;
                    FinalQuestions.Add(listquestions);
                    memberquestionslist.Find(x => x.SystemUsersId == listquestions.SystemUsersId).NoOfQuestions--;



                }
            }
            //catch { }


            //}

            //if (SortByNoticeDiary != null)
            //{
            //    DeferLV.DataSource = SortByNoticeDiary.ToList();
            //    DeferLV.DataBind();

            //}


            //foreach (ListQuestion joinedquestions in JoinedQuestions)
            //{
            //    if(!ThreeQuestionMembers.Contains(joinedquestions.SystemUsersId))
            //    {
            //        FinalQuestions.Add(joinedquestions);
            //    }
            //}
            if (FinalQuestions != null)
            {
                ListLV.DataSource = FinalQuestions;
                ListLV.DataBind();

            }
            //else
            // ListLV.DataSource = JoinedQuestions;
            // ListLV.DataBind();


        }


        public string GetDefSenatorName(int ListNo, string MoverName)
        {
            return "*(DEF.) QUESTION NO. " + ListNo + " SENATOR " + MoverName.ToUpper() + ":";
        }
        public string GetListSenatorName(int ListNo, char SupNo, string MoverName)
        {
            int QuestionListId = Convert.ToInt32(Request.QueryString["QuestionListId"]);
            QuestList QL = new QuestList();
            QL = new QuestionBiz().GetQuestionList(QuestionListId);
            int CategoryId = QL.CategoryId;
            int cat = Convert.ToInt32(CategoryId);

            if (cat == 1)
                return "*QUESTION NO. " + ListNo + "-" + SupNo + " SENATOR " + MoverName.ToUpper() + ":";
            if (cat == 2)
                return "QUESTION NO. " + ListNo + "-" + SupNo + " SENATOR " + MoverName.ToUpper() + ":";
            else
                return "";
        }
        public string GetNoticeDateTime(DateTime DiaryDate, DateTime DiaryTime, int qid)
        {
            return "( Notice Received on " + DiaryDate.ToShortDateString() + " at " + DiaryTime.ToShortTimeString() + ") QID: " + qid;
        }

        protected void SaveList_Click(object sender, EventArgs e)
        {
            int QuestionListId = Convert.ToInt32(Request.QueryString["QuestionListId"]);
            SuplementaryListEnt ql = new SuplementaryListEnt();
            ql.ListName = Convert.ToString(ListName.Text);
            ql.ListDate = Convert.ToDateTime(ListDateTxt.Text);
            ql.QuestionListId = QuestionListId;
            string questions = null;
            foreach (ListViewDataItem item in ListLV.Items)
            {
                HiddenField qid = item.FindControl("HidQid") as HiddenField;
                HiddenField lid = item.FindControl("HidListNo") as HiddenField;
                HiddenField sid = item.FindControl("HidSupNo") as HiddenField;
                if (questions != null)
                    questions = questions + ",";
                questions = questions + qid.Value;
                if (qid != null && lid != null)
                {
                    new QuestionBiz().UpdateListNo(Convert.ToInt32(qid.Value), Convert.ToInt32(lid.Value), Convert.ToString(sid.Value), Convert.ToDateTime(ListDateTxt.Text));
                }
            }
            ql.Questions = questions;
            new QuestionBiz().InsertSupQuestionsList(ql);
            BindListView();
            Response.Redirect("~/SuplementaryList.aspx?QuestionListId=" + QuestionListId);
        }

        protected void GroupDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListLV.DataSource = null;
            ListLV.DataBind();
        }
    }
}