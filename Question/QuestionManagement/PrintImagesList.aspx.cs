using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class PrintImagesList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string qry = Request.QueryString["List"];
            string html = "<table>";
            if (!string.IsNullOrEmpty(qry))
            {
                string decoded = Server.UrlDecode(qry);
                List<string> questions = decoded.Split(',').ToList();
                string path = "/contents/";
                foreach (string q in questions)
                {
                    html += $"<tr><td><img src='{path}{q}.jpg'/></td></tr>";
                }
                html += "</table>";
                maindiv.InnerHtml = html;
                // Now you can use the 'fruits' list
            }
        }
    }
}