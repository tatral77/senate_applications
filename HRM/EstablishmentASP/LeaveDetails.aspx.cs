using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using EstablishmentBIZ;
using EstablishmentENT;
using Utilities;

namespace EstablishmentASP
{
    public partial class LeaveDetails : System.Web.UI.Page
    {
        private List<LeaveYear2> exportYears;
        private List<KeyValuePair<string, string>> exportDetails;
        private List<LeaveTypeSummary2> exportSummary;
        private string exportSection;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }

        protected void ServiceDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind();
        }

        protected void ExportPdfBtn_Click(object sender, EventArgs e)
        {
            Bind();
            if (exportYears == null)
                return;
            byte[] pdf = LeavePdf2.LeaveAccount(FName.Text, Dated.Text, exportDetails, exportSection, exportYears, exportSummary);
            LeavePdf2.Send(Response, pdf, "Leave Account - " + FName.Text.Split(new[] { " --- " }, StringSplitOptions.None)[0]);
        }

        protected void Bind()
        {
            try
            {
                int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
                DateTime floor = Convert.ToDateTime("01/01/1900");
                EmpHistory eh = new EmploymentBIZ().GetCurrentEmployment(empval);
                EmpProfile ep = new EmployeeHandler().GetOnePage(empval);
                LeaveContext2 ctx = LeaveRules2.LoadContext(empval);

                FName.Text = ep.FName + " --- " + ep.CurrentDesignation + " (" + ep.CurrentBPS + ")";
                if (ep.Dob > floor)
                    DOB.Text = Convert.ToString(ep.Dob.ToShortDateString());
                CurrentDesignation.Text = ep.CurrentDesignation;
                bps.Text = ep.CurrentBPS;
                CurrentBranch.Text = ep.CurrentBranch;
                EmployeeStatus.Text = ep.EmployeeStatus;
                DateTime serviceEndDate = ctx.ServiceEnd;
                if (ep.GovtServiceStartDate > floor)
                {
                    GovtServiceStartDate.Text = Convert.ToString(ep.GovtServiceStartDate.ToShortDateString());
                    Duration govtDuration = new DateTimeUtils().GetDuration(ep.GovtServiceStartDate, serviceEndDate);
                    GovtService.Text = Convert.ToString(govtDuration.Years + " Years " + govtDuration.Months + " Months");
                }
                if (ep.SenateServiceStartDate > floor)
                {
                    SenateServiceStartDate.Text = Convert.ToString(ep.SenateServiceStartDate.ToShortDateString());
                    Duration senateDuration = new DateTimeUtils().GetDuration(ep.SenateServiceStartDate, serviceEndDate);
                    HouseService.Text = Convert.ToString(senateDuration.Years + " Years " + senateDuration.Months + " Months");
                }
                if (ep.Dob > floor)
                    SuperantuationDate.Text = Convert.ToString(ep.SuperanuationDate.ToShortDateString());
                if (ep.Age < 100)
                    Age.Text = Convert.ToString(ep.Age);
                CurrentStatusLbl.Text = eh.CurrentStatus + " (" + eh.CurrentStatusDate.ToShortDateString() + ")";
                PreviousLeaveCredit.Text = Convert.ToString(ep.LeaveOnCredit);
                Dated.Text = DateTime.Now.ToShortDateString();

                bool fromSenate = ServiceDDL.SelectedValue == "1";
                GovtServiceDiv.Visible = !fromSenate;
                SenServiceDiv.Visible = fromSenate;

                LeaveAccount2 account = LeaveRules2.BuildAccount(ctx, fromSenate);
                if (account.Years.Count == 0)
                {
                    NoticeLbl.Text = fromSenate ? "Senate service start date is not recorded." : "Government service start date is not recorded.";
                    CurrentLeaveCreditLbl.Text = "";
                }
                else
                {
                    NoticeLbl.Text = "";
                    CurrentLeaveCreditLbl.Text = Convert.ToString(account.ClosingBalance);
                }
                EmpLeaveLv.DataSource = account.Years;
                EmpLeaveLv.DataBind();

                TypeSummaryLit.Text = BuildTypeSummary(ctx.Leaves);

                exportYears = account.Years;
                exportSummary = LeaveRules2.SummariseByType(ctx.Leaves);
                exportSection = fromSenate ? "LEAVE DETAILS FROM START OF SENATE SERVICE" : "LEAVE DETAILS FROM START OF GOVERNMENT SERVICE";
                exportDetails = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Date of Birth:", DOB.Text),
                    new KeyValuePair<string, string>("Age:", Age.Text),
                    new KeyValuePair<string, string>("Current Designation:", CurrentDesignation.Text),
                    new KeyValuePair<string, string>("Current BPS:", bps.Text),
                    new KeyValuePair<string, string>("Employee Branch:", CurrentBranch.Text),
                    new KeyValuePair<string, string>("Employee Status:", EmployeeStatus.Text),
                    new KeyValuePair<string, string>("Govt Service Start Date:", GovtServiceStartDate.Text),
                    new KeyValuePair<string, string>("Senate Service Start Date:", SenateServiceStartDate.Text),
                    new KeyValuePair<string, string>("Current Status:", CurrentStatusLbl.Text),
                    new KeyValuePair<string, string>("Total Govt Service:", GovtService.Text),
                    new KeyValuePair<string, string>("Total Service in Senate:", HouseService.Text),
                    new KeyValuePair<string, string>("Superannuation Date:", SuperantuationDate.Text),
                    new KeyValuePair<string, string>("Leave Credit from Previous Department:", PreviousLeaveCredit.Text),
                    new KeyValuePair<string, string>("Current Leave Credit:", CurrentLeaveCreditLbl.Text)
                };
            }
            catch
            {
                FName.Text = "Incomplete Data. Please complete employment details for this report.";
            }
        }

        private string BuildTypeSummary(List<EmployeeLeave> leaves)
        {
            List<LeaveTypeSummary2> summary = LeaveRules2.SummariseByType(leaves);
            if (summary.Count == 0)
                return "";
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='summary-block'><h5 style='text-align:center'><b><u>LEAVE AVAILED BY TYPE</u></b></h5>");
            sb.Append("<table class='table table-striped table-condensed table-data type-summary'><thead><tr>");
            sb.Append("<th>Leave Type</th><th style='text-align:center'>No. of Entries</th><th style='text-align:center'>Days of Leave</th><th style='text-align:center'>Debited to LFP</th>");
            sb.Append("</tr></thead><tbody>");
            foreach (LeaveTypeSummary2 row in summary)
            {
                sb.Append("<tr><td>").Append(Server.HtmlEncode(row.Description)).Append("</td>");
                sb.Append("<td style='text-align:center'>").Append(row.Spells.ToString(CultureInfo.InvariantCulture)).Append("</td>");
                sb.Append("<td style='text-align:center'>").Append(row.Days.ToString(CultureInfo.InvariantCulture)).Append("</td>");
                sb.Append("<td style='text-align:center'>").Append(row.Debited.ToString(CultureInfo.InvariantCulture)).Append("</td></tr>");
            }
            sb.Append("</tbody></table></div>");
            return sb.ToString();
        }
    }
}
