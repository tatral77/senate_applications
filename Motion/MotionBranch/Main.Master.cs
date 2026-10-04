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
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //body.Attributes.Add("scroll", "no");
            if (Request.Cookies["loginstatus"] == null)
                Response.Redirect("~/Login.aspx");
            //HttpCookie cookie = Request.Cookies["loginstatus"];
            //if (cookie != null)
            //{
            //    string roll = cookie.Value;
            //    if (roll == "1")
            //    {
            //        Response.Redirect("SearchEmployee.aspx");
            //    }
            //    else
            //        Response.Redirect("Login.aspx");
            //}

        }
        protected string GetMotions()
        {
            AssemblySessions ASession = new MotionBiz().GetCurrentAssemblySessionDetails();
            List<MotionEnt> motions = new MotionBiz().GetSentMotions(ASession.AssemblySessionsId);
            if (motions==null)
                return "";
            return Convert.ToString(motions.Count);
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["loginstatus"] != null)
            {
                HttpCookie myCookie = new HttpCookie("loginstatus");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
                Response.Redirect("~/Login.aspx");
            }
            // Response.Redirect("Login.aspx");
            //}
        }
        protected string GetTranslations()
        {
            AssemblySessions ASession = new AdministrationBiz().GetCurrentAssemblySessionDetails();
            List<MotionEnt> TranslatedQuestions = new MotionBiz().GetTranslatedMotions(ASession.AssemblySessionsId);
            if (TranslatedQuestions == null)
                return "";
            return Convert.ToString(TranslatedQuestions.Count);
        }
    }
}