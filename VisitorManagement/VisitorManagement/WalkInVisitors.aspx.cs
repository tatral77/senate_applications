using BIZ;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VisitorManagement
{
    public partial class WalkInVisitors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
              
                    List<WalkInVisitor> walkInVisitors = new Biz().GetWalkInVisitors();
                    LV.DataSource = walkInVisitors;
                    LV.DataBind();

                
            }
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}