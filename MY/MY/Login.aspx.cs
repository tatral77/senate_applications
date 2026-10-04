using ManEntities;
using MyBIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MY
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string userName = UserName.Text;
            string password = Password.Text;
            //  int ApplicationId = 9;
            User user = new MyBiz().GetEmployeeUser(Convert.ToDouble(userName), password);
            if (!String.IsNullOrEmpty(user.FullName))
            {
                HttpCookie userInfo = new HttpCookie("userInfo");
                userInfo["role"] = user.RoleId.ToString();
                userInfo["userid"] = user.UserId.ToString();
                userInfo["SystemUsersId"] = user.SystemUsersId.ToString();
                userInfo["FullName"] = user.FullName.ToString();
                userInfo["PostId"] = user.PostId.ToString();
                userInfo["BranchId"] = user.BranchId.ToString();
                //userInfo.Expires.Add(new TimeSpan(0, 1, 0));
                Response.Cookies.Add(userInfo);
                userInfo.Expires = DateTime.Now.AddHours(3);
                Response.Cookies.Add(userInfo);
                Response.Redirect("Profile.aspx");
            }
            else
                errorlbl.Text = "Incorrect user name or password";


        }
    }
}