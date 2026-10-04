using BIZ;
using Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Notice
{
    public partial class ManageSittingPlan : System.Web.UI.Page
    {
        [WebMethod]
        public static int SaveSeat(int SourceSeat,int TargetSeat, int SourceMember,int TargetMember,string SourceMemberColor, string TargetMemberColor, string Action)
        {
            try
            {
               
                List<MemberSeat> memberSeats = new List<MemberSeat>();
                ManageSeatingPlan manageSeatingPlan = new ManageSeatingPlan();
                if (Action.Equals("Swap"))
                {

                    MemberSeat sourceMember = new MemberSeat();
                    sourceMember.SeatNumber = SourceSeat;
                    sourceMember.SystemUsersId = TargetMember;
                    sourceMember.SeatColour = TargetMemberColor;
                    sourceMember.UpdatedBy= GetUserFullName();
                    sourceMember.IsActive = 1;

                    MemberSeat targetMember = new MemberSeat();
                    targetMember.SeatNumber = TargetSeat;
                    targetMember.SystemUsersId = SourceMember;
                    targetMember.SeatColour = SourceMemberColor;
                    sourceMember.UpdatedBy = GetUserFullName(); 
                    targetMember.IsActive = 1;
                    memberSeats.Add(sourceMember);
                    memberSeats.Add(targetMember);
                    new AdministrationBiz().UpdateMemberSeats(memberSeats);
                    //new AdministrationBiz().UpdateMemberSeat(targetMember);
                }
                else if (Action.Equals("Move"))
                {
                    MemberSeat sourceMember = new MemberSeat();
                    sourceMember.SeatNumber = SourceSeat;
                    sourceMember.SystemUsersId = 0;
                    sourceMember.SeatColour = "ffffff";
                    sourceMember.UpdatedBy = GetUserFullName();
                    sourceMember.IsActive = 1;

                    MemberSeat targetMember = new MemberSeat();
                    targetMember.SeatNumber = TargetSeat;
                    targetMember.SystemUsersId = SourceMember;
                    targetMember.SeatColour = SourceMemberColor;
                    targetMember.UpdatedBy = GetUserFullName();
                    targetMember.IsActive = 1;
                    memberSeats.Add(sourceMember);
                    memberSeats.Add(targetMember);
                    new AdministrationBiz().UpdateMemberSeats(memberSeats);
                }
            }
            catch 
            {
                return 0;
            }
            return 1;
            
        }
        [WebMethod]
        public static string GetMemberSeats()
        {
            List<MemberSeat> MemberSeats = new AdministrationBiz().GetMemberSeats();
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(MemberSeats);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string did = "";
                for(int i=2;i<=109;i++)
                {
                    did = 'L' + Convert.ToString(i);
                    Label lbl = Page.FindControl(did) as Label;
                    if(lbl!=null)
                    lbl.Text = "-";
                }
                List<MemberSeat> MemberSeats = new AdministrationBiz().GetMemberSeats();
                MemberSeat LasteUpdatedRecord = MemberSeats.OrderByDescending(x => x.UpdatedOn).FirstOrDefault();
                string UpdatedOn = LasteUpdatedRecord.UpdatedOn.ToString();
                string UpdatedBy = LasteUpdatedRecord.UpdatedBy;
                updatedon.Text = "Update On: " + UpdatedOn + " by " + UpdatedBy;
                //  List<HtmlElement> lst = new List<HtmlElement>();
                if (MemberSeats != null)
                {
                    foreach (MemberSeat ms in MemberSeats)
                    {
                        if (ms.IsActive != 0)
                        {
                            string id = 'L' + Convert.ToString(ms.SeatNumber);
                            string divid = 'S' + Convert.ToString(ms.SeatNumber);
                            string hid = 'H' + Convert.ToString(ms.SeatNumber);
                            Label lbl = Page.FindControl(id) as Label;
                            HtmlControl ctrl = (HtmlControl)this.FindControl(divid);
                            HiddenField hidf = Page.FindControl(hid) as HiddenField;

                            if (lbl != null || hidf != null)
                            {
                                hidf.Value = ms.SystemUsersId.ToString() + "-" + ms.SeatColour;
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
        protected static string GetUserFullName()
        {
            string FullName = "";
            HttpCookie userInfo = HttpContext.Current.Request.Cookies["userInfo"];
            if (userInfo != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                FullName = Convert.ToString(userInfo["FullName"]);
            }
            return FullName;
        }
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
           
            if (!String.IsNullOrEmpty(HidMemberId.Value))
            {
                
                MemberSeat seat = new MemberSeat();
                seat.SeatNumber = Convert.ToInt32(HidSeatNumber.Value);
                seat.SystemUsersId = Convert.ToInt32(HidMemberId.Value);
                seat.UpdatedBy = GetUserFullName();
                if (String.IsNullOrEmpty(SeatColour.SelectedItem.Text))
                    seat.SeatColour = "white";
                else
                    seat.SeatColour = SeatColour.SelectedValue;
                new AdministrationBiz().UpdateMemberSeat(seat);
                Response.Redirect("ManageSittingPlan.aspx");
            }
        }

        protected void UnAssignBtn_Click(object sender, EventArgs e)
        {
            MemberSeat seat = new MemberSeat();
            seat.SeatNumber = Convert.ToInt32(HidSeatNumber.Value);
            seat.SystemUsersId = 0;
            seat.SeatColour = "ffffff";
            new AdministrationBiz().UpdateMemberSeat(seat);
            Response.Redirect("ManageSittingPlan.aspx");

        }
       

        protected void ClearColoursBtn_Click(object sender, EventArgs e)
        {
            string FullName = "";       
            if (Request.Cookies["userInfo"] != null)
            {
                HttpCookie userInfo = Request.Cookies["userInfo"];
                FullName = Convert.ToString(userInfo["FullName"]);
            }
            new AdministrationBiz().UnAssignAllColours(FullName);
            Response.Redirect("ManageSittingPlan.aspx");

        }

        protected void UnAssignAllSeatsBtn_Click(object sender, EventArgs e)
        {
            string FullName = "";
            if (Request.Cookies["userInfo"] != null)
            {
                HttpCookie userInfo = Request.Cookies["userInfo"];
                FullName = Convert.ToString(userInfo["FullName"]);
            }
            new AdministrationBiz().UnAssignAllSeats(FullName);
            Response.Redirect("ManageSittingPlan.aspx");
        }
    }
}