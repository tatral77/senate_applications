using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstablishmentASP
{
    public partial class Management : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //body.Attributes.Add("scroll", "no");
            if (Request.Cookies["userInfo"] == null)
            {
                HttpCookie userInfo = new HttpCookie("userInfo");
                if (userInfo["role"] != "management")
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
        }
        protected void Logout_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["userInfo"] != null)
            {
                HttpCookie userInfo = new HttpCookie("userInfo");
                userInfo["role"] = "";
                userInfo.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(userInfo);
                Response.Redirect("~/Login.aspx");
            }
            // Response.Redirect("Login.aspx");
            //}
        }
    }
}