using Entities;
using MotionBIZ;
using MotionEntities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Services;

namespace QuestionManagement
{
    public partial class NoticeMotions : System.Web.UI.Page
    {
        [WebMethod]
        public static List<string> GetEmployeeName(string empName)
        {
            List<string> empResult = new List<string>();
            List<Member> mems = new QuestionBiz().GetMembersByName(empName);
            foreach (Member a in mems)
            {
                empResult.Add(a.MemberName);
            }
            return empResult;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindListView();

            }
        }

        private void bindListView()
        {
            List<MotionEnt> Motions = new MotionBiz().GetSentMotions(new AdministrationBiz().GetCurrentAssemblySessions());
            ListView1.DataSource = Motions;
            ListView1.DataBind();

        }
        public string GetMinText(string txt)
        {
            string text = Regex.Replace(txt, @"<[^>]+>|&nbsp;", "").Trim(); ;
            if (txt.Length >= 350)
                text = txt.Substring(0, 350).Trim() + ".................";
            else
                text = txt;
            return text;


        }
        protected string GetMembers(int MotionId)
        {
            string moverslist = "";
            List<MotionMoversEnt> movers = new MotionBiz().GetMotionMovers(MotionId);
            if (movers != null)
            {
                foreach (MotionMoversEnt temp in movers)
                {
                    moverslist += temp.MoverName + ", ";
                }
            }
            return moverslist;
        }
        public string SelectText(string Text)
        {
            return GetMinText(Text);
        }
        public string GetTime(DateTime time)
        {
            return time.ToShortTimeString();
        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();

        }

    }
}