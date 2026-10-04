using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using ResolutionBIZ;

namespace QuestionManagement
{
    public partial class Rpt_ReceivedQuestionsResolutions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindSessionCB();
                //bindUnStarredListView();

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
                ToSessionDDL.Items.Add(Temp);
            }
        }

        protected void GenerateBtn_Click(object sender, EventArgs e)
        {
            int StartSession = Convert.ToInt32(SessionDDL.SelectedValue);
            int EndSession = Convert.ToInt32(ToSessionDDL.SelectedValue);
            MessagePnl.Visible = false;
            if (StartSession == 0 || EndSession == 0)
            {
                ToolbarDiv.Visible = false;
                MessageLbl.Text = "Please select the From and To sessions.";
                MessagePnl.Visible = true;
                return;
            }
            if (StartSession > EndSession)
            {
                ToolbarDiv.Visible = false;
                MessageLbl.Text = "The From session cannot be later than the To session.";
                MessagePnl.Visible = true;
                return;
            }
            string StartSessionName = SessionDDL.SelectedItem.Text;
            string EndSessionName = ToSessionDDL.SelectedItem.Text;
            if (StartSession == EndSession)
                ReportHeading.InnerText = "DETAIL OF STARRED/UNSTARRED QUESTIONS AND RESOLUTIONS RECEIVED DURING SESSION " + StartSessionName + " OF THE SENATE";
            else
                ReportHeading.InnerText = "DETAIL OF STARRED/UNSTARRED QUESTIONS AND RESOLUTIONS RECEIVED DURING SESSION " + StartSessionName + " TO SESSION " + EndSessionName + " OF THE SENATE";
            List<Rpt_QuestionsResolutionsSummary> rpt_ReceivedQuestionsResolutions = new QuestionBiz().GetQuestionsStatusWiseSummary(StartSession, EndSession, 1);
            StarredLV.DataSource = rpt_ReceivedQuestionsResolutions;
            StarredLV.DataBind();
            List<Rpt_QuestionsResolutionsSummary> rpt_UnstarredReceivedQuestionsResolutions = new QuestionBiz().GetQuestionsStatusWiseSummary(StartSession, EndSession, 2);
            UnStarredLv.DataSource = rpt_UnstarredReceivedQuestionsResolutions;
            UnStarredLv.DataBind();
            List<Rpt_QuestionsResolutionsSummary> rpt_ResolutionsSummary = new ResolutionBiz().GetResolutionStatusWiseSummary(StartSession, EndSession);
            ResolutionsLv.DataSource = rpt_ResolutionsSummary;
            ResolutionsLv.DataBind();
            ToolbarDiv.Visible = true;
            ReportCard.Visible = true;
        }
    }
}