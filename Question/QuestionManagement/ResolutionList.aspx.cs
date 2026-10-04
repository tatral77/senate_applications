using Entities;
using QuestionBIZ;
using ResolutionBIZ;
using ResolutionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class ResolutionList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCombos();
                try
                {
                    string current = new AdministrationBiz().GetCurrentAssemblySessions().ToString();
                    if (SessionDDL.Items.FindByValue(current) != null)
                    {
                        SessionDDL.SelectedValue = current;
                        BindListView();
                    }
                }
                catch { /* the page still works without a preselected session */ }
            }
        }

        // The preview decides what the page shows: Save only makes sense once a list has been generated.
        protected void Page_PreRender(object sender, EventArgs e)
        {
            int count = ResolutionLV.Items.Count;
            SaveList.Enabled = count > 0;
            HintPnl.Visible = count == 0;
            pnlContents.Visible = count > 0;    // no empty table while there is nothing to preview
            CountLit.Text = count > 0 ? "<span class='rl-count'>" + count + (count == 1 ? " resolution" : " resolutions") + "</span>" : "";
            if (count == 0)
                HintLit.Text = ViewState["generated"] != null
                    ? "No admitted resolutions were found for this session."
                    : "Choose a session and click <b>Generate</b> to preview the admitted resolutions.";
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
            ResolutionLV.DataSource = null;
            ResolutionLV.DataBind();
            ViewState["generated"] = null;
            ErrorLbl.Visible = false;
        }
        public void BindListView()
        {
            int AssemblySessionId = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            List<ResolutionListEnt> ql = new ResolutionBiz().GetResolutionList(AssemblySessionId) ?? new List<ResolutionListEnt>();
            ListView1.DataSource = ql;
            ListView1.DataBind();
        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField ListId = (HiddenField)ListView1.Items[e.ItemIndex].FindControl("HidResolutionListNo");
            int listid = Convert.ToInt32(ListId.Value);
            ResolutionListEnt ql = new ResolutionListEnt();
            ql = new ResolutionBiz().GetResolutionListById(listid);

            if (!String.IsNullOrEmpty(ql.Resolutions))
            {
                List<int> listResolutions = ql.Resolutions.Split(',').Select(s => Convert.ToInt32(s)).ToList();
                foreach (var a in listResolutions)
                {
                    new ResolutionBiz().UpdateResolutionListNo(a, 0, Convert.ToDateTime("01/01/1900"));
                }
            }

            new ResolutionBiz().DeleteResolutionList(listid);
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
        public string GetPrintLink(string ResolutionListId)
        {
            return "~/PrintResolutionList.aspx?ResolutionListId=" + ResolutionListId;
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
        protected string GetMembers(int ResolutionId)
        {
            string moverslist = "";
            List<ResolutionSubmittersEnt> movers = new ResolutionBiz().GetResolutionSubmitters(ResolutionId);
            if (movers != null)
            {
                int count = movers.Count();
                int chk = 0;
                if (movers != null)
                {
                    foreach (ResolutionSubmittersEnt temp in movers)
                    {
                        moverslist += "Senator " + temp.MoverName;
                        if (chk != count)
                            moverslist += "<br>";
                        chk++;

                    }
                }
            }
            return moverslist;
        }
        protected void GenerateBtn_Click(object sender, EventArgs e)
        {
            int SessionNumber = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            AssemblySessions assession = new AdministrationBiz().GetAssemblySession(SessionNumber);
            List<ResolutionEnt> ListResolutions = new List<ResolutionEnt>();
            List<ResolutionEnt> CarryForwardedResolutions = new List<ResolutionEnt>();
            if (assession.BusinessSessions != null)
            {
                List<int> BSessions = assession.BusinessSessions.Split(',').Select(s => Convert.ToInt32(s)).ToList();
                foreach (int a in BSessions)
                {
                    CarryForwardedResolutions = new ResolutionBiz().GetAdmittedResolutions(a);
                    if (CarryForwardedResolutions != null)
                    {
                        foreach (ResolutionEnt cf2 in CarryForwardedResolutions)
                        {
                            ListResolutions.Add(cf2);
                        }
                    }
                }

            }

            List<ResolutionEnt> CurrentSessionResolutions = new ResolutionBiz().GetAdmittedResolutions(SessionNumber);
            if (CurrentSessionResolutions != null)
            {
                foreach (ResolutionEnt me in CurrentSessionResolutions)
                {
                    ListResolutions.Add(me);
                }
            }

            if (ListResolutions != null)
            {
                ListResolutions.TrimExcess();

            }
            var resolutions = from p in ListResolutions
                              orderby p.ResolutionDiaryNo
                              select p;
            ResolutionLV.DataSource = resolutions;
            ResolutionLV.DataBind();
            ViewState["generated"] = true;
            ErrorLbl.Visible = false;
        }

        //public string GetNoticeDateTime(DateTime DiaryDate, DateTime DiaryTime, int qid)
        //{
        //    return "( Notice Received on " + DiaryDate.ToShortDateString() + " at " + DiaryTime.ToShortTimeString() + ") QID: " + qid;
        //}

        protected void SaveList_Click(object sender, EventArgs e)
        {
            DateTime listDate;
            if (ResolutionLV.Items.Count == 0)
            {
                ErrorLbl.Text = "Generate the list first - there are no resolutions to save.";
                ErrorLbl.Visible = true;
                return;
            }
            if (string.IsNullOrWhiteSpace(ListName.Text) || !DateTime.TryParse(ListDateTxt.Text, out listDate))
            {
                ErrorLbl.Text = "Enter a list name and a valid list date.";
                ErrorLbl.Visible = true;
                return;
            }
            ResolutionListEnt Resolutionlist = new ResolutionListEnt();
            Resolutionlist.AssemblySessionsId = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            Resolutionlist.ListName = Convert.ToString(ListName.Text);
            Resolutionlist.ListDate = listDate;
            string ListResolutions = null;
            List<int> Resolutions = new List<int>();
            foreach (ListViewDataItem item in ResolutionLV.Items)
            {
                HiddenField ResolutionId = item.FindControl("HidResolutionsId") as HiddenField;
                Resolutions.Add(Convert.ToInt32(ResolutionId.Value));
                if (ListResolutions != null)
                    ListResolutions = ListResolutions + ",";
                ListResolutions = ListResolutions + ResolutionId.Value;

            }
            Resolutionlist.Resolutions = ListResolutions;

            if (Resolutionlist != null)
            {
                new ResolutionBiz().InsertResolutionList(Resolutionlist);
            }

            foreach (int mots in Resolutions)
            {
                new ResolutionBiz().UpdateResolutionListNo(mots, 1, Resolutionlist.ListDate);
            }
            Response.Redirect("~/ResolutionList.aspx");
        }
    }
}
