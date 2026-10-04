using ManBIZ;
using ManEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administration
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    if (UserName.Text == "user" && Password.Text == "123")
        //    {
        //        HttpCookie LoginStatus = new HttpCookie("loginstatus");
        //        LoginStatus.Value = "entry";
        //        LoginStatus.Expires = DateTime.Now.AddHours(3);
        //        Response.Cookies.Add(LoginStatus);
        //        Response.Redirect("SearchItem.aspx");
        //    }
        //    else if (UserName.Text == "admin" && Password.Text == "admin123")
        //    {
        //        HttpCookie userInfo = new HttpCookie("userInfo");
        //        userInfo["role"] = "admin";
        //        // userInfo["UserColor"] = "Black";
        //        userInfo.Expires.Add(new TimeSpan(0, 1, 0));
        //        Response.Cookies.Add(userInfo);
        //        userInfo.Expires = DateTime.Now.AddHours(3);
        //        Response.Cookies.Add(userInfo);
        //        Response.Redirect("Admin/ManageLog.aspx");
        //    }
        //    else
        //        errorlbl.Text = "Incorrect user name or password";

        //}
        protected void Button1_Click(object sender, EventArgs e)
        {
            string userName = UserName.Text;
            string password = Password.Text;
            int ApplicationId = 4;
            User user = new ManBiz().ValidateUser(userName, password, ApplicationId);
            if (user != null)
            {
                HttpCookie userInfo = new HttpCookie("userInfo");
                userInfo["role"] = user.RoleId.ToString();
                userInfo["userid"] = user.UserId.ToString();
                userInfo["roleid"] = user.RoleId.ToString();
                userInfo["FullName"] = user.FullName.ToString();
                //userInfo.Expires.Add(new TimeSpan(0, 1, 0));
                Response.Cookies.Add(userInfo);
                userInfo.Expires = DateTime.Now.AddHours(3);
                Response.Cookies.Add(userInfo);
                Response.Redirect("Home.aspx");
            }
            else
                errorlbl.Text = "Incorrect user name or password";
        }
    }
}