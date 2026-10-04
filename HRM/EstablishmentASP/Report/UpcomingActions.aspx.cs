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
    public partial class UpcomingActions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSuperannuationLV();
                BindProbationLV();
                BindEmploymentLV();
            }

        }

        protected void BindSuperannuationLV()
        {

            List<PopSuperannuation> Eq = new ReportsBIZ().GetPopSuperannuation();
            SuperannuationLV.DataSource = Eq;
            SuperannuationLV.DataBind();
        }
        protected void BindProbationLV()
        {

            List<PopProbation> Eq = new ReportsBIZ().GetPopProbation();
            ProbationLV.DataSource = Eq;
            ProbationLV.DataBind();
        }
        protected void BindEmploymentLV()
        {

            List<PopEmployment> Eq = new ReportsBIZ().GetPopEmployment();
            EmploymentLV.DataSource = Eq;
            EmploymentLV.DataBind();
        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }
    }
}