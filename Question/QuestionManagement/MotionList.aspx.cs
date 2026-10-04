using Entities;
using MotionBIZ;
using MotionEntities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class MotionList : System.Web.UI.Page
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
        }
        protected void SessionDDL_SelectedIndexChanged1(object sender, EventArgs e)
        {
            int AssemblySessionId = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            BindListView();
            MotionLV.DataSource = null;
            MotionLV.DataBind();
        }
        public void BindListView()
        {
            int AssemblySessionId = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            List<ListEntity> ql = new MotionBiz().GetMotionList(AssemblySessionId);
            ListView1.DataSource = ql;
            ListView1.DataBind();
        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField ListId = (HiddenField)ListView1.Items[e.ItemIndex].FindControl("HidMotionListNo");
            int listid = Convert.ToInt32(ListId.Value);
            ListEntity ql = new ListEntity();
            ql = new MotionBiz().GetMotionListById(listid);

            if (!String.IsNullOrEmpty(ql.ListMotions))
            {
                List<int> listmotions = ql.ListMotions.Split(',').Select(s => Convert.ToInt32(s)).ToList();
                foreach (var a in listmotions)
                {
                    new MotionBiz().UpdateMotionListNo(a, 0, Convert.ToDateTime("01/01/1900"));
                }
            }

            new MotionBiz().DeleteMotionList(listid);
            BindListView();
        }
        public string GetSessionName(int AssemblySessionId)
        {
            AssemblySessions asession = new AdministrationBiz().GetAssemblySession(AssemblySessionId);
            if (asession != null)
                return asession.SessionNumber.ToString();
            else
                return "Not Mentioned";

        }
        public string GetPrintLink(string MotionListId)
        {
            return "~/PrintMotionList.aspx?MotionListId=" + MotionListId;
        }
        //protected int CalculateDays(DateTime NoticeDate)
        //{

        //    DateTime HouseLayDate = Convert.ToDateTime(ListDateTxt.Text);
        //    int NumberOfDays = Convert.ToInt32((((HouseLayDate - NoticeDate).TotalDays) - 1));
        //    if (NumberOfDays >= 7)
        //        return 1;
        //    else
        //        return 0;

        //}
        protected string GetMembers(int MotionId)
        {
            string moverslist = "";
            List<MotionMoversEnt> movers = new MotionBiz().GetMotionMovers(MotionId);
            int count = movers.Count();
            int chk = 0;
            if (movers != null)
            {
                foreach (MotionMoversEnt temp in movers)
                {
                    moverslist += "Senator " + temp.MoverName;
                    if (chk != count)
                        moverslist += "<br>";
                    chk++;

                }
            }
            return moverslist;
        }
        protected void GenerateBtn_Click(object sender, EventArgs e)
        {
            int SessionNumber = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            AssemblySessions assession = new AdministrationBiz().GetAssemblySession(SessionNumber);
            List<MotionEnt> ListMotions = new List<MotionEnt>();
            List<MotionEnt> CarryForwardedMotions = new List<MotionEnt>();
            if (assession.BusinessSessions != null)
            {
                List<int> BSessions = assession.BusinessSessions.Split(',').Select(s => Convert.ToInt32(s)).ToList();
                foreach (int a in BSessions)
                {
                    CarryForwardedMotions = new MotionBiz().GetAdmittedMotions(a);
                    if (CarryForwardedMotions != null)
                    {
                        foreach (MotionEnt cf2 in CarryForwardedMotions)
                        {
                            ListMotions.Add(cf2);
                        }
                    }
                }

            }

            List<MotionEnt> CurrentSessionMotions = new MotionBiz().GetAdmittedMotions(SessionNumber);
            if (CurrentSessionMotions != null)
            {
                foreach (MotionEnt me in CurrentSessionMotions)
                {
                    ListMotions.Add(me);
                }
            }

            if (ListMotions != null)
            {
                ListMotions.TrimExcess();
                var sortbydiary = from p in ListMotions
                                  orderby p.MotionDiaryNo
                                  select p;
                MotionLV.DataSource = sortbydiary.ToList();
                MotionLV.DataBind();
            }



        }

        //public string GetNoticeDateTime(DateTime DiaryDate, DateTime DiaryTime, int qid)
        //{
        //    return "( Notice Received on " + DiaryDate.ToShortDateString() + " at " + DiaryTime.ToShortTimeString() + ") QID: " + qid;
        //}

        protected void SaveList_Click(object sender, EventArgs e)
        {
            ListEntity motionlist = new ListEntity();
            motionlist.AssemblySessionsId = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            motionlist.ListName = Convert.ToString(ListName.Text);
            motionlist.ListDate = Convert.ToDateTime(ListDateTxt.Text);
            string ListMotions = null;
            List<int> motions = new List<int>();
            foreach (ListViewDataItem item in MotionLV.Items)
            {
                HiddenField motionId = item.FindControl("HidMotionsId") as HiddenField;
                motions.Add(Convert.ToInt32(motionId.Value));
                if (ListMotions != null)
                    ListMotions = ListMotions + ",";
                ListMotions = ListMotions + motionId.Value;

            }
            motionlist.ListMotions = ListMotions;

            if (motionlist != null)
            {
                new MotionBiz().InsertMotionList(motionlist);
            }

            foreach (int mots in motions)
            {
                new MotionBiz().UpdateMotionListNo(mots, 1, motionlist.ListDate);
            }
            Response.Redirect("~/MotionList.aspx");
        }
    }
}