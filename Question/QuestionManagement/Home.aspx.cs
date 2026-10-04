using QuestionBIZ;
using System;

namespace QuestionManagement
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void LoadData()
        {
            DashboardBiz biz = new DashboardBiz();
            CardsRepeater.DataSource = biz.GetCards();
            CardsRepeater.DataBind();
            SessionLit.Text = Server.HtmlEncode(biz.SessionNumber);
            SessionChip.Visible = !string.IsNullOrEmpty(biz.SessionNumber);
        }
    }
}
