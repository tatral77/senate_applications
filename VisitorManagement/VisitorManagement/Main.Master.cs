using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ManEntities;
using ManBIZ;


namespace QuestionManagement
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