using Entities;
using MotionBIZ;
using MotionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MotionBranch
{
    public partial class MotionsList : System.Web.UI.Page
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
            List<MotionTypeEnt> motiontypes = new MotionBiz().GetMotionTypes();
            MotionTypeDDL.Items.Add(new ListItem("Select", "0"));
            foreach (MotionTypeEnt row in motiontypes)
            {
                ListItem li = new ListItem();
                li.Text = row.Description.ToString();
                li.Value = row.MotionTypeId.ToString();
                MotionTypeDDL.Items.Add(li);
            }
            List<AssemblySessions> ASessions = new AdministrationBiz().GetAssemblySessions();
            SessionDDL.Items.Add(new ListItem("Select", "0"));
            foreach (AssemblySessions row in ASessions)
            {
                ListItem li = new ListItem();
                li.Text = row.SessionNumber.ToString();
                li.Value = row.AssemblySessionsId.ToString();
                SessionDDL.Items.Add(li);
            }

            List<MotionWeek> motionWeeks = new MotionBiz().GetMotionWeeks();
            foreach (MotionWeek row in motionWeeks)
            {
                ListItem li = new ListItem();
                li.Text = row.WeekName.ToString();
                li.Value = row.WeekId.ToString();
                MotionWeekCB.Items.Add(li);
            }
        }

        protected string GetMinistries(int MotionId)
        {
            string moverslist = "";
            List<MotionMinistriesEnt> motionMinistriesEnts = new MotionBiz().GetMotionMinistries(MotionId);
            if (motionMinistriesEnts != null)
            {
                int count = motionMinistriesEnts.Count();
                int chk = 0;
                if (motionMinistriesEnts != null)
                {
                    foreach (MotionMinistriesEnt temp in motionMinistriesEnts)
                    {
                        moverslist += temp.MinistryName;
                        if (chk != count)
                            moverslist += ",<br>";
                        chk++;

                    }
                }
            }
            return moverslist;
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
            int MotionTypeId = Convert.ToInt32(MotionTypeDDL.SelectedValue);
            List<ListEntity> ql = new MotionBiz().GetMotionList(AssemblySessionId, MotionTypeId);
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
            MotionListLbl.Text = MotionTypeDDL.SelectedItem.Text.ToUpper() + " FOR SESSION " + SessionDDL.SelectedItem.Text.ToUpper();
            int SessionNumber = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            AssemblySessions assession = new AdministrationBiz().GetAssemblySession(SessionNumber);
            int MotionTypeId = Convert.ToInt32(MotionTypeDDL.SelectedValue);
            List<MotionEnt> ListMotions = new List<MotionEnt>();
            List<MotionEnt> ListDefMotions = new List<MotionEnt>();
            List<MotionEnt> DefferedMotions = new List<MotionEnt>();
            List<MotionEnt> AdmittedMotions = new List<MotionEnt>();
            if (assession.BusinessSessions != null)
            {
                List<int> BSessions = assession.BusinessSessions.Split(',').Select(s => Convert.ToInt32(s)).ToList();
                foreach (int a in BSessions)
                {
                    DefferedMotions = new MotionBiz().GetDefferedMotions(a, MotionTypeId);
                    if (DefferedMotions != null)
                    {
                        foreach (MotionEnt cf2 in DefferedMotions)
                        {
                            ListDefMotions.Add(cf2);
                        }
                    }
                }

            }
            if (ListDefMotions.Count>0)
            {
                DefferedLabel.Text = MotionTypeDDL.SelectedItem.Text.ToUpper() + " DEFFERED DURING SESSION " + SessionDDL.SelectedItem.Text.ToUpper();
                DefferedLabel.Visible = true;
                DefferedLV.Visible = true;
                ListDefMotions.TrimExcess();
                var sortbydiary = from p in ListDefMotions
                                  orderby p.NoticeDiaryDate, p.NoticeDiaryTime
                                  select p;
                DefferedLV.DataSource = sortbydiary.ToList();
                DefferedLV.DataBind();
            }


            if (assession.BusinessSessions != null)
            {
                List<int> BSessions = assession.BusinessSessions.Split(',').Select(s => Convert.ToInt32(s)).ToList();
                foreach (int a in BSessions)
                {
                    AdmittedMotions = new MotionBiz().GetAdmittedMotions(a, MotionTypeId);
                    if (AdmittedMotions != null)
                    {
                        MotionListLbl.Visible = true;
                        MotionLV.Visible = true;
                        foreach (MotionEnt cf2 in AdmittedMotions)
                        {
                            ListMotions.Add(cf2);
                        }
                    }
                }

            }

            List<MotionEnt> CurrentSessionMotions = new MotionBiz().GetAdmittedMotions(SessionNumber,MotionTypeId);
            if (CurrentSessionMotions != null)
            {
                foreach (MotionEnt me in CurrentSessionMotions)
                {
                    ListMotions.Add(me);
                }
            }

            if (ListMotions.Count>0)
            {
                MotionLV.Visible = true;
                MotionListLbl.Visible = true;
                ListMotions.TrimExcess();
                var sortbydiary = from p in ListMotions
                                  orderby p.NoticeDiaryDate,p.NoticeDiaryTime
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
            motionlist.MotionTypeId= Convert.ToInt32(MotionTypeDDL.SelectedItem.Value);
            motionlist.MotionWeekId= Convert.ToInt32(MotionWeekCB.SelectedItem.Value);
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


            string DefferedList = null;
            List<int> Defmotions = new List<int>();
            foreach (ListViewDataItem item in DefferedLV.Items)
            {
                HiddenField motionId = item.FindControl("HidMotionsId") as HiddenField;
                Defmotions.Add(Convert.ToInt32(motionId.Value));
                if (DefferedList != null)
                    DefferedList = DefferedList + ",";
                DefferedList = DefferedList + motionId.Value;

            }
            motionlist.DefferedMotions = DefferedList;

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

        protected void MotionTypeDDL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}