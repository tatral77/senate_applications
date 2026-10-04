using IPRBIZ;
using IPRENITITIES;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPR
{
    public partial class ManageTravelSchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindTravelScheduleLV();
            }

        }
        protected void bindTravelScheduleLV()
        {
            int VisitId = Convert.ToInt32(Request.QueryString["Id"]);
            List<TravelSchedule> TravelSchedule = new IPRBiz().GetTravelSchedules(VisitId);
            TravelScheduleLV.DataSource = TravelSchedule;
            TravelScheduleLV.DataBind();

        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {
            TravelScheduleLV.SelectedIndex = -1;
            TravelScheduleLV.EditIndex = -1;
            TravelScheduleLV.InsertItemPosition = InsertItemPosition.FirstItem;
            bindTravelScheduleLV();

        }
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            TravelScheduleLV.InsertItemPosition = InsertItemPosition.None;
            TravelScheduleLV.SelectedIndex = -1;
            TravelScheduleLV.EditIndex = e.NewEditIndex;
            bindTravelScheduleLV();
            e.Cancel = true;
        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
           

        }

        protected string GetStatus(int id)
        {
            if (id == 0)
                return "No";
            else
                return "Yes";

        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
        
        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {

            HiddenField TravelScheduleId = (HiddenField)TravelScheduleLV.Items[e.ItemIndex].FindControl("HidTravelScheduleId");
            new IPRBiz().DeleteTravelSchedule(Convert.ToInt32(TravelScheduleId.Value));
            bindTravelScheduleLV();
        }

        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            TravelScheduleLV.EditIndex = -1;
            TravelScheduleLV.InsertItemPosition = InsertItemPosition.None;
            TravelScheduleLV.SelectedIndex = -1;
            bindTravelScheduleLV();
            e.Cancel = true;
        }
        protected string GetDuration(string t1,string t2)
        {
            string h="", m="";
            DateTime dtFrom = DateTime.Parse(t1);
            DateTime dtTo = DateTime.Parse(t2);
            int hours = (dtTo.Subtract(dtFrom).Hours);
            int mins = (dtTo.Subtract(dtFrom).Minutes);
            if (hours!=0)
                h= hours + " Hours ";
            if (mins != 0)
                m = mins + " Minutes";
            return h + m;  
        }


        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int Visit = Convert.ToInt32(Request.QueryString["Id"]);

            HiddenField HidArrCityId = (HiddenField)TravelScheduleLV.InsertItem.FindControl("HidArrCityId");
            HiddenField HidDepCityId = (HiddenField)TravelScheduleLV.InsertItem.FindControl("HidDepCityId");
            TextBox DepDateTxt = (TextBox)TravelScheduleLV.InsertItem.FindControl("DepDateTxt");
            TextBox ArrDateTxt = (TextBox)TravelScheduleLV.InsertItem.FindControl("ArrDateTxt");
            TextBox DepTimeTxt = (TextBox)TravelScheduleLV.InsertItem.FindControl("DepTimeTxt");
            TextBox ArrTimeTxt = (TextBox)TravelScheduleLV.InsertItem.FindControl("ArrTimeTxt");
            TextBox FlighNumberTxt = (TextBox)TravelScheduleLV.InsertItem.FindControl("FlighNumberTxt");
            TravelSchedule ep = new TravelSchedule();
            ep.VisitId = Visit;
            ep.DepCityId = Convert.ToInt32(HidDepCityId.Value);
            ep.DepDate = Convert.ToDateTime(DepDateTxt.Text);
            ep.DepTime = Convert.ToDateTime(DepTimeTxt.Text);
            ep.ArrCityId = Convert.ToInt32(HidArrCityId.Value);
            ep.ArrDate = Convert.ToDateTime(ArrDateTxt.Text);
            ep.ArrTime = Convert.ToDateTime(ArrTimeTxt.Text);
            ep.FlighNumber= Convert.ToString(FlighNumberTxt.Text);
            new IPRBiz().InsertTravelSchedule(ep);
            TravelScheduleLV.EditIndex = -1;
            TravelScheduleLV.InsertItemPosition = InsertItemPosition.None;
            bindTravelScheduleLV();
            e.Cancel = true;
            Response.Redirect("ManageTravelSchedule.aspx?Id=" + Visit);

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            int Visit = Convert.ToInt32(Request.QueryString["Id"]);
            HiddenField HidTravelScheduleId = (HiddenField)TravelScheduleLV.EditItem.FindControl("HidTravelScheduleId");
            HiddenField HidArrCityId = (HiddenField)TravelScheduleLV.EditItem.FindControl("HidArrCityId");
            HiddenField HidDepCityId = (HiddenField)TravelScheduleLV.EditItem.FindControl("HidDepCityId");
            TextBox DepDateTxt = (TextBox)TravelScheduleLV.EditItem.FindControl("DepDateTxt");
            TextBox ArrDateTxt = (TextBox)TravelScheduleLV.EditItem.FindControl("ArrDateTxt");
            TextBox DepTimeTxt = (TextBox)TravelScheduleLV.EditItem.FindControl("DepTimeTxt");
            TextBox ArrTimeTxt = (TextBox)TravelScheduleLV.EditItem.FindControl("ArrTimeTxt");
            TextBox FlighNumberTxt = (TextBox)TravelScheduleLV.EditItem.FindControl("FlighNumberTxt");
            TravelSchedule ep = new TravelSchedule();
            ep.VisitId = Visit;
            ep.TravelScheduleId= Convert.ToInt32(HidTravelScheduleId.Value);
            ep.DepCityId = Convert.ToInt32(HidDepCityId.Value);
            ep.DepDate = Convert.ToDateTime(DepDateTxt.Text);
            ep.DepTime = Convert.ToDateTime(DepTimeTxt.Text);
            ep.ArrCityId = Convert.ToInt32(HidArrCityId.Value);
            ep.ArrDate = Convert.ToDateTime(ArrDateTxt.Text);
            ep.ArrTime = Convert.ToDateTime(ArrTimeTxt.Text);
            ep.FlighNumber = Convert.ToString(FlighNumberTxt.Text);
            new IPRBiz().UpdateTravelSchedule(ep);
            TravelScheduleLV.EditIndex = -1;
            TravelScheduleLV.InsertItemPosition = InsertItemPosition.None;
            bindTravelScheduleLV();
            e.Cancel = true;

        }
        protected string GetTime(DateTime time)
        {
            return DateTime.ParseExact(time.ToString(), "HH:mm:ss", CultureInfo.InvariantCulture).ToString(); ;
            
        }
    }
}