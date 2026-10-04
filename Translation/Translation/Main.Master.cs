using BIZ;
using Entities;
using ManBIZ;
using ManEntities;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

namespace Translation
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // GetQuestions();GetMotions();
            if (Request.Cookies["userInfo"] == null)
                Response.Redirect("~/Login.aspx");


            else if (!IsPostBack)
            {

            }

            string navbar = "";
            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                int userid = Convert.ToInt32(userInfo["userid"]);
                int roleid = Convert.ToInt32(userInfo["roleid"]);

                User user = new ManBiz().GetUser(userid);
                if (user.Role.Equals("Manager"))
                {
                    ManagerMenuDiv.Visible = true;
                }
                if (user.Role.Equals("Translator"))
                {
                    UserMenuDiv.Visible = true;
                }
                int UserTypeId = user.UserTypeId;
                string css = "@" + "<style type = 'text/css' > " + user.UserCss + "</style>";
                Page.Header.Controls.Add(
                new LiteralControl(css));
                if (user.UserMenus != null)
                {
                    foreach (Menus temp in user.UserMenus)
                    {
                        if (temp.MenuPosition == 1)
                        {
                            navbar += "<ul class='nav navbar-nav'>";

                            if (temp.menuPages != null)
                                navbar += "<li class='dropdown'><a data-toggle='dropdown' href='" + temp.Url + "'>" + temp.Menu + "<span class='caret'></span></a>";
                            else
                                navbar += "<li class='dropdown'><a href='" + temp.Url + "'>" + temp.Menu + "<span class='caret'></span></a>";

                            if (temp.menuPages != null)
                            {
                                navbar += "<ul class='dropdown-menu'> ";
                                foreach (MenuPages pages in temp.menuPages)
                                {
                                    navbar += "<li>" + pages.Url + "</li>";
                                }
                                navbar += "</ul>";
                            }
                            navbar += "</li></ul>";
                        }
                    }


                    foreach (Menus temp in user.UserMenus)
                    {
                        if (temp.MenuPosition == 2)
                        {
                            navbar += "<ul class='nav navbar-nav navbar-right'>";

                            if (temp.menuPages != null)
                                navbar += "<li class='dropdown'>" + temp.Url;
                            else
                                navbar += "<li class='dropdown'>" + temp.Url;

                            if (temp.menuPages != null)
                            {
                                navbar += "<ul class='dropdown-menu'> ";
                                foreach (MenuPages pages in temp.menuPages)
                                {
                                    navbar += "<li>" + pages.Url + "</li>";
                                }
                                navbar += "</ul>";
                            }
                            navbar += "</li></ul>";
                        }
                    }



                }
                //navbar += "<ul class='nav navbar-nav navbar-right '>";
                //navbar += "<li>";
                //navbar += "<asp:LinkButton ID='LinkButton1' runat='server' OnClick='Logout_Click'><span class='glyphicon glyphicon-log-out'></span>Logout</asp:LinkButton></li> </ul></div> </nav>";


            }
            MenusDiv.InnerHtml = navbar;


        }

        //protected string GetMotions()
        //{
        //    AssemblySessions ASession = new AdministrationBiz().GetCurrentAssemblySessionDetails();
        //    List<MotionEnt> motions = new MotionBiz().GetSentMotions(ASession.AssemblySessionsId);
        //    if (motions == null)
        //        return "";
        //    return Convert.ToString(motions.Count);
        //}
        protected string GetQuestionTranslations()
        {
            List<Questions> questions = null;
            if (Request.Cookies["userInfo"] != null)
            {
                HttpCookie userInfo = Request.Cookies["userInfo"];
                int userid = Convert.ToInt32(userInfo["userid"]);
                User user = new ManBiz().GetUser(userid);
                AssemblySessions ASession = new TranslationBiz().GetCurrentAssemblySessionDetails();
                if (user.Role.Equals("Manager"))
                {
                    questions = new TranslationBiz().GetTranslationQuestions();
                }
                if (user.Role.Equals("Translator"))
                {
                     questions = new TranslationBiz().GetTranslationQuestionsByUser(userid);
                }
                if (questions == null)
                    return "";
                return Convert.ToString(questions.Count);
            }
            return "";


        }
        protected string GetTranslatedQuestions()
        {
            List<Questions> TranslatedQuestions = new TranslationBiz().GetTranslatedQuestionsByUsers();
            if (TranslatedQuestions != null)
                return Convert.ToString(TranslatedQuestions.Count);
            else
                return "";
        }
        protected string GetMotionTranslations()
        {
            List<Motion> motions = null;
            if (Request.Cookies["userInfo"] != null)
            {
                HttpCookie userInfo = Request.Cookies["userInfo"];
                int userid = Convert.ToInt32(userInfo["userid"]);
                User user = new ManBiz().GetUser(userid);
                AssemblySessions ASession = new TranslationBiz().GetCurrentAssemblySessionDetails();
                if (user.Role.Equals("Manager"))
                {
                    motions = new TranslationBiz().GetTranslationMotions(ASession.AssemblySessionsId);
                }
                if (user.Role.Equals("Translator"))
                {
                   // motions = new TranslationBiz().GetTranslationMotionsByUser(ASession.AssemblySessionsId, userid);
                }
                if (motions == null)
                    return "";
                return Convert.ToString(motions.Count);
            }
            return "";



            //AssemblySessions ASession = new TranslationBiz().GetCurrentAssemblySessionDetails();
            //List<Motion> motions = new TranslationBiz().GetTranslationMotions(ASession.AssemblySessionsId);
            //if (motions == null)
            //    return "";
            //return Convert.ToString(motions.Count);
        }
        protected string GetResolutionTranslations()
        {
            List<Resolution> resolutions = null;
            if (Request.Cookies["userInfo"] != null)
            {
                HttpCookie userInfo = Request.Cookies["userInfo"];
                int userid = Convert.ToInt32(userInfo["userid"]);
                User user = new ManBiz().GetUser(userid);
                AssemblySessions ASession = new TranslationBiz().GetCurrentAssemblySessionDetails();
                if (user.Role.Equals("Manager"))
                {
                    resolutions = new TranslationBiz().GetTranslationResolutions(ASession.AssemblySessionsId);
                }
                if (user.Role.Equals("Translator"))
                {
                    // motions = new TranslationBiz().GetTranslationMotionsByUser(ASession.AssemblySessionsId, userid);
                }
                if (resolutions == null)
                    return "";
                return Convert.ToString(resolutions.Count);
            }
            return "";



            //AssemblySessions ASession = new TranslationBiz().GetCurrentAssemblySessionDetails();
            //List<Resolution> motions = new TranslationBiz().GetTranslationResolutions(ASession.AssemblySessionsId);
            //if (motions == null)
            //    return "";
            //return Convert.ToString(motions.Count);
        }
       
        //protected string GetMBMotions()
        //{
        //    AssemblySessions ASession = new AdministrationBiz().GetCurrentAssemblySessionDetails();
        //    List<MBMotion> mbmotions = new MBMotionBiz().GetSentMotions(ASession.AssemblySessionsId);
        //    if (mbmotions == null)
        //        return "";
        //    return Convert.ToString(mbmotions.Count);
        //}

        protected void Logout_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["userInfo"] != null)
            {
                HttpCookie myCookie = new HttpCookie("userInfo");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
                Response.Redirect("~/Login.aspx");
            }
            // Response.Redirect("Login.aspx");
            //}
        }
    }
}