using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IPRBIZ;
using IPRENTITIES;

namespace IPR
{
    public partial class OutgoingVisits : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack == true)
            {
                int visitid = Convert.ToInt32(Request.QueryString["Id"]);
                OutgoingVisit ov = new IPRBiz().GetOutgoingVisit(visitid);
                visitlbl.Text = ov.VisitTitle;
                countrylbl.Text = ov.CountryName.ToString();
                fromlbl.Text = ov.FromDate.ToLongDateString();
                tolbl.Text = ov.ToDate.ToLongDateString();
                CompositionHL.NavigateUrl = "~/ManageComposition.aspx?Id=" + visitid;
                TravelScheduleHL.NavigateUrl = "~/ManageTravelSchedule.aspx?Id=" + visitid;
                DACalculationHL.NavigateUrl = "~/ManageOutgoingVisitDA.aspx?Id=" + visitid;
                VisitDetails.NavigateUrl = "~/OutgoingVisitDetails.aspx?Id=" + visitid;
                Documents.NavigateUrl= "~/OutgoingVisitDocuments.aspx?Id=" + visitid;


            }

        }
    }
}