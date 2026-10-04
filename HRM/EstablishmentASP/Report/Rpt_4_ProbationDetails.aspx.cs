using EstablishmentBIZ;
using EstablishmentENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstablishmentASP.Reports
{
    public partial class Rpt_4_ProbationDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            EmpProfile ep = new EmpProfile();
            ep = new EmployeeHandler().GetOnePage(empval);
            FName.Text = ep.FName;
            DOB.Text = Convert.ToString(ep.Dob.ToShortDateString());
            CurrentDesignation.Text = ep.CurrentDesignation;
            bps.Text = ep.CurrentBPS;
            CurrentBranch.Text = ep.CurrentBranch;
            EmployeeStatus.Text = ep.EmployeeStatus;
            GovtServiceStartDate.Text = Convert.ToString(ep.GovtServiceStartDate.ToShortDateString());
            SenateServiceStartDate.Text = Convert.ToString(ep.SenateServiceStartDate.ToShortDateString());
            //if (ep.GovtService != 0 && ep.GovtServiceMonths != 0)
            //    GovtService.Text = Convert.ToString(ep.GovtService + " Years " + ep.GovtServiceMonths % 12 + " Months");
            //else if (ep.GovtService != 0 && ep.GovtServiceMonths == 0)
            //    GovtService.Text = Convert.ToString(ep.GovtService + " Years ");
            //else if (ep.GovtServiceMonths != 0)
            //    GovtService.Text = Convert.ToString(ep.GovtServiceMonths + " Months");
            //if (ep.HouseService != 0 && ep.HouseServiceMonths != 0)
            //    HouseService.Text = Convert.ToString(ep.HouseService + " Years " + ep.HouseServiceMonths % 12 + " Months");
            //else if (ep.HouseService != 0 && ep.HouseServiceMonths == 0)
            //    HouseService.Text = Convert.ToString(ep.HouseService + " Years ");
            //else if (ep.HouseServiceMonths != 0)
            //    HouseService.Text = Convert.ToString(ep.HouseServiceMonths + " Months");
           // SuperantuationDate.Text = Convert.ToString(ep.SuperanuationDate.ToShortDateString());
            Age.Text = Convert.ToString(ep.Age);
            List<Probation> re = new List<Probation>();
            re = new ReportsBIZ().Get_All_Probations(empval);
            ProbationLV.DataSource = re;
            ProbationLV.DataBind();


        }

        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }
    }
}