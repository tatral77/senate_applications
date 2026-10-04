using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionManagement
{
    public partial class Rpt_DefferedQuestions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                bindDefferedLV();
            }
        }
        private void bindDefferedLV()
        {
            List<ListQuestion> DefferedQuestions = new List<ListQuestion>();
            DefferedQuestions = new QuestionBiz().GetAllDeferedQuestions(new AdministrationBiz().GetCurrentAssemblySessions());
            if (DefferedQuestions != null)
            {

                var defQuestions = from p in DefferedQuestions
                                   orderby p.StatusDate, p.ListNo
                                   select p;
                DefferedLV.DataSource = DefferedQuestions;//defQuestions.ToList();
                DefferedLV.DataBind();
            }
        }
        public string GetLink(string QuestionId)
        {
            string link = "~/QuestionDetails.aspx?QuestionsId=" + QuestionId;
            if (Request.Cookies["userInfo"] != null)
            {
                HttpCookie userInfo = Request.Cookies["userInfo"];
                string role = Convert.ToString(userInfo["role"]);
                if (role.Equals("SO"))
                    link = "~/QuestionDetailsRest.aspx?QuestionsId=" + QuestionId;
            }
            return link;

        }

        public string GetTime(DateTime time)
        {
            return time.ToShortTimeString();
        }
        public string GetDate(DateTime date)
        {
            if (date < Convert.ToDateTime("01/01/1900"))
                return "";
            else
                return date.ToShortDateString();

        }
    }
}