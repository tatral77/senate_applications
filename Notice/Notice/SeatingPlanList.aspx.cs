using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using BIZ;

namespace Notice
{
    public partial class SeatingPlanList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            List<MemberSeat> MemberSeats = new AdministrationBiz().GetMemberSeatsList();
            ListView1.DataSource = MemberSeats;
            ListView1.DataBind();
        }
    }
}