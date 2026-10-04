using BIZ;
using Entities;
using System;
using System.Collections.Generic;

namespace Notice
{
    public partial class ManageSeatingPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            List<MemberSeat> MemberSeats = new AdministrationBiz().GetMemberSeats();
            foreach (MemberSeat ms in MemberSeats)
            {
                //Html
                //if(ms.SeatNumber==)
                //Label lbl = F109.Controls[1] as Label;
                //Response.Write(lbl.Text);
            }


        }

        protected void savebtn_Click(object sender, EventArgs e)
        {

            string txt = HidSeatNumber.Value + "/" + HidMemberId.Value;
            MemberNameTxt.Text = "";
            HidMemberId.Value = "";
            HidSeatNumber.Value = "";
            Response.Write(txt);

        }
    }
}