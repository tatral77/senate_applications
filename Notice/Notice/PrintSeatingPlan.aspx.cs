using BIZ;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Notice
{
    public partial class PrintSeatingPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string did = "";
            for (int i = 2; i <= 109; i++)
            {
                did = 'L' + Convert.ToString(i);
                Label lbl = Page.FindControl(did) as Label;
                if (lbl != null)
                    lbl.Text = "-";
            }
            List<MemberSeat> MemberSeats = new AdministrationBiz().GetMemberSeats();
            string UpdatedOn = MemberSeats.Max(i => i.UpdatedOn).ToString();
            updatedon.Text = "Update On: " + UpdatedOn;
            //  List<HtmlElement> lst = new List<HtmlElement>();
            if (MemberSeats != null)
            {
                foreach (MemberSeat ms in MemberSeats)
                {
                    string id = 'L' + Convert.ToString(ms.SeatNumber);
                    string divid = 'S' + Convert.ToString(ms.SeatNumber);
                    
                    string hid = 'H' + Convert.ToString(ms.SeatNumber);
                    Label lbl = Page.FindControl(id) as Label;
                    HtmlControl ctrl = (HtmlControl)this.FindControl(divid);
                    HiddenField hidf = Page.FindControl(hid) as HiddenField;

                    if (lbl != null || hidf != null)
                    {
                        hidf.Value = ms.SystemUsersId.ToString();
                        lbl.Text = ms.MemberUrduName;
                        // lbl.BackColor = System.Drawing.ColorTranslator.FromHtml(ms.SeatColour);
                        if (!String.IsNullOrEmpty(ms.SeatColour))
                        {
                            ms.SeatColour = ms.SeatColour + "!important";
                            ctrl.Attributes.CssStyle.Add("background-color", ms.SeatColour);
                            //if(!ms.SeatColour.Equals("white!important"))
                            //{
                            //    ctrl.Attributes.CssStyle.Add("color", "#FFFFFF!important");
                            //}
                            //else
                            //{
                            //    ctrl.Attributes.CssStyle.Add("color", "#000000!important");
                            //}
                            // ctrl.Attributes.CssStyle.Add("color" , "#FFFFFF!important");
                            // ctrl.Attributes["style"] = "color:#fff";
                        }
                    }
                }
            }

        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(HidMemberId.Value))
            {
                MemberSeat seat = new MemberSeat
                {
                    SeatNumber = Convert.ToInt32(HidSeatNumber.Value),
                    SystemUsersId = Convert.ToInt32(HidMemberId.Value)
                };
                new AdministrationBiz().UpdateMemberSeat(seat);
                Response.Redirect("ManageSittingPlan.aspx");
            }
        }

        protected void UnAssignBtn_Click(object sender, EventArgs e)
        {
           
            MemberSeat seat = new MemberSeat
            {
                SeatNumber = Convert.ToInt32(HidSeatNumber.Value),
                SystemUsersId = 0
            };
          
            new AdministrationBiz().UpdateMemberSeat(seat);
            Response.Redirect("ManageSittingPlan.aspx");

        }
    }
}