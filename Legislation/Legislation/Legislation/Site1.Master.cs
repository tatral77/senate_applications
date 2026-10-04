
using ManBIZ;
using ManEntities;
using System;
using System.Web;
using System.Web.UI;

namespace Legislation
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["userInfo"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else if (!IsPostBack)
            {

            }
            string navbar = "";
            if (Request.Cookies["userInfo"] != null)
            {
                HttpCookie userInfo = Request.Cookies["userInfo"];
                if (userInfo.Expires < DateTime.Now)
                {
                    int userid = Convert.ToInt32(userInfo["userid"]);
                    int roleid = Convert.ToInt32(userInfo["roleid"]);

                    User user = new ManBiz().GetUser(userid);
                    if (user != null)
                    {
                        int UserTypeId = user.UserTypeId;
                        string css = "<style type = 'text/css' > " + user.UserCss + "</style>";
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
                                        navbar += "<li class='dropdown'><a data-toggle='dropdown' href='" + temp.Url + "'>" + temp.Menu + "<span class='caret'></span></a>";
                                    else
                                        navbar += "<li class='dropdown'><a href='" + temp.Url + "'>" + temp.Menu + "<span class='caret'></span></a>";


                                }
                                navbar += "</li></ul>";

                            }



                        }
                        //navbar += "<ul class='nav navbar-nav navbar-right '>";
                        //navbar += "<li>";
                        //navbar += "<asp:LinkButton ID='LinkButton1' runat='server' OnClick='Logout_Click'><span class='glyphicon glyphicon-log-out'></span>Logout</asp:LinkButton></li> </ul></div> </nav>";
                    }
                }

            }
            MenusDiv.InnerHtml = navbar;


        }
        protected void Logout_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["userInfo"] != null)
            {
                HttpCookie myCookie = new HttpCookie("userInfo");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
                Response.Redirect("~/Login.aspx");
            }
           Response.Redirect("~/Login.aspx");
           
        }
    }
}