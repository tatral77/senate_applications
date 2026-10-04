using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Management
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
     if (UserName.Text == "manage" && Password.Text == "123")
            {
                HttpCookie LoginStatus = new HttpCookie("loginstatus");
                LoginStatus.Value = "management";
                // userInfo["UserColor"] = "Black";
                LoginStatus.Expires.Add(new TimeSpan(0, 1, 0));
                Response.Cookies.Add(LoginStatus);
                LoginStatus.Expires = DateTime.Now.AddHours(3);
                Response.Cookies.Add(LoginStatus);
                Response.Redirect("Applications.aspx");
            }
            else
                errorlbl.Text = "Incorrect user name or password";


        }
    }
}