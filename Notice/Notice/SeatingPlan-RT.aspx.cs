using BIZ;
using Entities;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Notice
{
    public partial class SeatingPlan_RT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentDate.Text = "Printed on: " + DateTime.Now.ToString();
            List<MemberSeat> MemberSeats = new AdministrationBiz().GetMemberSeats();
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
    }
}