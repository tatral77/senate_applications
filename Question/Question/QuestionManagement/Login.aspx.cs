using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (UserName.Text == "ques" && Password.Text == "1")
            {
                HttpCookie LoginStatus = new HttpCookie("loginstatus");
                LoginStatus.Value = "1";
                LoginStatus.Expires = DateTime.Now.AddHours(3);
                Response.Cookies.Add(LoginStatus);
                Response.Redirect("SearchQuestion.aspx");
            }
            else
                Response.Redirect("Login.aspx");


        }
    }
}
