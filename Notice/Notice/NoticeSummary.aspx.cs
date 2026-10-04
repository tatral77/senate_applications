using BIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;

namespace Notice
{
    public partial class NoticeSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //FromdateTxt.Text = DateTime.Now.ToShortDateString();
                //ToDateTxt.Text = DateTime.Now.ToShortDateString();
            }
           
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            bindListView();
        }


            private void bindListView()
        {
            DateTime fromDate = Convert.ToDateTime(FromdateTxt.Text);
            DateTime toDate = Convert.ToDateTime(ToDateTxt.Text);
            List<NoticeSummaryEnt> noticeQuestionSummaries = new NoticeBiz().GetQuestionNoticeSummary(fromDate, toDate);
            ListView1.DataSource = noticeQuestionSummaries;
            ListView1.DataBind();

            List<NoticeSummaryEnt> noticeMotionSummaries = new NoticeBiz().GetMotionNoticeSummary(fromDate, toDate);
            MotionsLV.DataSource = noticeMotionSummaries;
            MotionsLV.DataBind();

            List<NoticeSummaryEnt> resolutionMotionSummaries = new NoticeBiz().GetResolutionNoticeSummary(fromDate, toDate);
            ResolutionsLV.DataSource = resolutionMotionSummaries;
            ResolutionsLV.DataBind();


        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();

        }
        public string GetStatus(int StatusId)
        {
            if(StatusId==1)
            {
                return "Confirmed";
            }
            else
            {
                return "Not Confirmed";
            }
            

        }
        protected string GetActionTaken(int processed)
        {
            if(processed==1)
            {
                return "Processed";
            }
            else if(processed==2)
            {
                return "Revived";
            }
            else
            {
                return "Pending";
            }
        }
    }
}