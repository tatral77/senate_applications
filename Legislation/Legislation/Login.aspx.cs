using ManBIZ;
using ManEntities;
using System;
using System.Web;

namespace Legislation
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string userName = UserName.Text;
            string password = Password.Text;
            int ApplicationId = 15;
            User user = new ManBiz().ValidateUser(userName, password, ApplicationId);
            if (user != null)
            {
                HttpCookie userInfo = new HttpCookie("userInfo");
                userInfo["roleid"] = user.RoleId.ToString();
                userInfo["role"] = user.Role.ToString();
                userInfo["userid"] = user.UserId.ToString();

                userInfo["FullName"] = user.FullName.ToString();
                //userInfo.Expires.Add(new TimeSpan(0, 1, 0));
               
                userInfo.Expires = DateTime.Now.AddHours(8);
                Response.Cookies.Add(userInfo);
                Response.Redirect("SearchBill.aspx");
            }
            else
                errorlbl.Text = "Incorrect user name or password";
        }
    }
}