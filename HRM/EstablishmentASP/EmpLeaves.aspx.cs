using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using EstablishmentBIZ;
using EstablishmentENT;

namespace EstablishmentASP
{
    public partial class EmpLeaves : System.Web.UI.Page
    {
        private static readonly string[] DateFormats = { "dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy", "d-M-yyyy", "yyyy-MM-dd" };

        private int EmpId
        {
            get
            {
                int id;
                int.TryParse(Request.QueryString["EmpId"], out id);
                return id;
            }
        }

        private int EditLeaveId
        {
            get
            {
                object o = ViewState["EditLeaveId"];
                return o == null ? 0 : (int)o;
            }
            set { ViewState["EditLeaveId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            if (EmpId == 0)
            {
                MsgLbl.Text = "<div class='alert alert-danger'>Employee is not specified.</div>";
                AddNewBtn.Visible = false;
                return;
            }
            LeaveDetailsLink.NavigateUrl = "~/LeaveDetails.aspx?empid=" + EmpId;
            BindTypes();
            BindLeaves();
        }

        #region Binding

        private void BindLeaves()
        {
            int empId = EmpId;
            List<EmployeeLeave> leaves = new EmployeeHandler().GetEmployeeLeaves(empId);

            LeaveHeader.Text = Server.HtmlEncode(BuildHeaderText(empId));

            EmpLeavesLv.DataSource = leaves;
            EmpLeavesLv.DataBind();

            BindPosition();
        }

        private string BuildHeaderText(int empId)
        {
            EmpHeaderInfo info = new EmployeeHandler().GetEmpName(empId);
            EmpHeaderInfo desig = new EmployeeHandler().GetEmpDesignation(empId);
            StringBuilder header = new StringBuilder();
            header.Append(info.EmpName).Append(" -- ");
            if (!String.IsNullOrEmpty(desig.POST))
                header.Append(desig.POST).Append("(").Append(desig.BPS).Append(") -- ");
            else
                header.Append(" Post and BPS not mentioned--");
            info = new EmployeeHandler().GetEmpBranch(empId);
            if (!String.IsNullOrEmpty(info.BRANCH))
                header.Append(info.BRANCH).Append(" -- ");
            else
                header.Append(" Branch not mentioned -- ");
            info = new EmployeeHandler().GetEmpEmplStatus(empId);
            if (!String.IsNullOrEmpty(info.EmploymentStatus))
                header.Append(info.EmploymentStatus).Append(" -- ").Append(info.CurrentStatus);
            else
                header.Append("Employment Status not mentioned");
            return header.ToString();
        }

        protected void ExportPdfBtn_Click(object sender, EventArgs e)
        {
            int empId = EmpId;
            if (empId == 0)
                return;
            List<EmployeeLeave> leaves = new EmployeeHandler().GetEmployeeLeaves(empId);
            byte[] pdf = LeavePdf2.EmployeeLeaves(BuildHeaderText(empId), leaves);
            LeavePdf2.Send(Response, pdf, "Leave Details - " + new EmployeeHandler().GetEmpName(empId).EmpName);
        }

        private void BindPosition()
        {
            PositionLit.Text = "";
            try
            {
                LeaveContext2 ctx = LeaveRules2.LoadContext(EmpId);
                StringBuilder sb = new StringBuilder();
                sb.Append("<div class='panel panel-default'><div class='panel-heading'><b>Leave position under the Revised Leave Rules, 1980</b></div>");
                sb.Append("<table class='table table-condensed table-data'>");
                if (ctx.ServiceStart.HasValue)
                {
                    LeaveAccount2 account = LeaveRules2.BuildAccount(ctx, false);
                    sb.Append("<tr><td>Leave credit (LFP) as on ").Append(DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)).Append("</td><td><b>")
                      .Append(account.ClosingBalance).Append(" days</b></td></tr>");
                }
                foreach (KeyValuePair<string, string> kv in LeaveRules2.Position(ctx, DateTime.Today))
                    sb.Append("<tr><td>").Append(Server.HtmlEncode(kv.Key)).Append("</td><td>").Append(Server.HtmlEncode(kv.Value)).Append("</td></tr>");
                sb.Append("</table></div>");
                PositionLit.Text = sb.ToString();
            }
            catch
            {
                PositionLit.Text = "";
            }
        }

        private void BindTypes()
        {
            LeaveTypeDDL.Items.Clear();
            LeaveTypeDDL.Items.Add(new ListItem("-- Select --", "0"));
            List<LeaveType> types = new AdministrationBIZ().GetLeaveTypes();
            if (types != null)
            {
                foreach (LeaveType row in types)
                    LeaveTypeDDL.Items.Add(new ListItem(row.Description, row.LeaveTypeId.ToString()));
            }
            BindSubTypes(0, 0);
        }

        private void BindSubTypes(int typeId, int selectedSubTypeId)
        {
            LeaveSubTypeDDL.Items.Clear();
            RuleHintLbl.Text = "";
            McRow.Visible = false;
            if (typeId == 0)
            {
                LeaveSubTypeDDL.Items.Add(new ListItem("-- Select --", "0"));
                return;
            }

            Dictionary<int, string> names = new Dictionary<int, string>();
            List<TempEntity> subTypes = new AdministrationBIZ().GetLeaveSubTypes();
            if (subTypes != null)
            {
                foreach (TempEntity t in subTypes)
                    names[t.Id] = t.Description;
            }

            int[] allowed = LeaveRules2.AllowedSubTypes(typeId);
            if (allowed.Length > 1)
                LeaveSubTypeDDL.Items.Add(new ListItem("-- Select --", "0"));
            foreach (int id in allowed)
            {
                string text;
                if (!names.TryGetValue(id, out text))
                    text = LeaveRules2.SubTypeName(id);
                LeaveSubTypeDDL.Items.Add(new ListItem(text, id.ToString()));
            }
            ListItem chosen = LeaveSubTypeDDL.Items.FindByValue(selectedSubTypeId.ToString());
            if (chosen != null)
                chosen.Selected = true;
            else if (allowed.Length == 1)
                LeaveSubTypeDDL.SelectedIndex = 0;

            RuleHintLbl.Text = Server.HtmlEncode(LeaveRules2.RuleHint(typeId));
            McRow.Visible = typeId == LeaveTypeIds2.LFP || typeId == LeaveTypeIds2.LHP || typeId == LeaveTypeIds2.NotDue;
        }

        #endregion

        #region Form

        private void ClearForm()
        {
            EditLeaveId = 0;
            FormMsgLbl.Text = "";
            LeaveTypeDDL.SelectedIndex = 0;
            BindSubTypes(0, 0);
            StartDateTxt.Text = "";
            NoOfDaysTxt.Text = "";
            ExPakistanCB.Checked = false;
            IsExtensionCB.Checked = false;
            MedicalCB.Checked = false;
            RemarksTxt.Text = "";
        }

        private void LoadForm(EmployeeLeave rec)
        {
            ClearForm();
            EditLeaveId = rec.EmpLeaveId;
            ListItem type = LeaveTypeDDL.Items.FindByValue(rec.LeaveTypeId.ToString());
            if (type != null)
            {
                LeaveTypeDDL.ClearSelection();
                type.Selected = true;
            }
            BindSubTypes(rec.LeaveTypeId, rec.LeaveSubTypeId);
            if (LeaveSubTypeDDL.SelectedValue != rec.LeaveSubTypeId.ToString() && rec.LeaveSubTypeId != 0)
                FormMsgLbl.Text = "This record was saved under sub type '" + Server.HtmlEncode(rec.LeaveSubType) + "', which is not valid for " + Server.HtmlEncode(LeaveRules2.TypeName(rec.LeaveTypeId)) + ". Select the correct sub type.";

            int days = rec.NumberOfDays;
            if (rec.LeaveTypeId == LeaveTypeIds2.Recreation && LeaveRules2.CalendarDays(rec) == 15)
                days = 10;
            StartDateTxt.Text = rec.StartDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            NoOfDaysTxt.Text = days.ToString();
            ExPakistanCB.Checked = rec.ExPakistan == 1;
            IsExtensionCB.Checked = rec.IsExtension == 1;
            MedicalCB.Checked = LeaveRules2.HasMedicalCertificate(rec.Remarks);
            RemarksTxt.Text = LeaveRules2.StripMedicalTag(rec.Remarks);
            pnlForm.Visible = true;
        }

        private static bool TryParseDate(string text, out DateTime date)
        {
            return DateTime.TryParseExact((text ?? "").Trim(), DateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }

        private static int ToInt(string s)
        {
            int v;
            int.TryParse(s, out v);
            return v;
        }

        private static string Bullets(IEnumerable<string> lines, Func<string, string> encode)
        {
            return string.Join("<br />", lines.Select(l => encode(l)));
        }

        protected void AddNewBtn_Click(object sender, EventArgs e)
        {
            ClearForm();
            pnlForm.Visible = true;
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            ClearForm();
            pnlForm.Visible = false;
        }

        protected void LeaveTypeDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormMsgLbl.Text = "";
            int typeId = ToInt(LeaveTypeDDL.SelectedValue);
            BindSubTypes(typeId, 0);
            if (typeId == LeaveTypeIds2.Recreation && string.IsNullOrWhiteSpace(NoOfDaysTxt.Text))
                NoOfDaysTxt.Text = "10";
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            Page.Validate("Group1");
            if (!Page.IsValid)
                return;

            int empId = EmpId;
            DateTime start;
            if (!TryParseDate(StartDateTxt.Text, out start))
            {
                FormMsgLbl.Text = "Enter the start date as DD/MM/YYYY.";
                return;
            }
            int days;
            if (!int.TryParse(NoOfDaysTxt.Text.Trim(), out days) || days < 1)
            {
                FormMsgLbl.Text = "Number of days must be a whole number of at least 1.";
                return;
            }

            EmployeeLeave leave = new EmployeeLeave();
            leave.EmpLeaveId = EditLeaveId;
            leave.EmpId = empId;
            leave.LeaveTypeId = ToInt(LeaveTypeDDL.SelectedValue);
            leave.LeaveSubTypeId = ToInt(LeaveSubTypeDDL.SelectedValue);
            leave.ExPakistan = ExPakistanCB.Checked ? 1 : 0;
            leave.IsExtension = IsExtensionCB.Checked ? 1 : 0;
            leave.StartDate = start;
            leave.NumberOfDays = days;
            leave.Remarks = LeaveRules2.ComposeRemarks(RemarksTxt.Text, MedicalCB.Checked && McRow.Visible);

            LeaveContext2 ctx;
            try
            {
                ctx = LeaveRules2.LoadContext(empId);
            }
            catch (Exception ex)
            {
                FormMsgLbl.Text = "The employee's service details could not be read: " + Server.HtmlEncode(ex.Message);
                return;
            }

            if (leave.EmpLeaveId != 0)
            {
                List<EmployeeLeave> mine = new EmployeeHandler().GetEmployeeLeaves(empId);
                if (mine == null || !mine.Any(x => x.EmpLeaveId == leave.EmpLeaveId))
                {
                    FormMsgLbl.Text = "The leave record being edited no longer exists.";
                    return;
                }
            }

            LeaveValidation2 result = LeaveRules2.Validate(leave, ctx);
            if (!result.IsValid)
            {
                FormMsgLbl.Text = Bullets(result.Errors, Server.HtmlEncode);
                return;
            }

            if (leave.EmpLeaveId == 0)
                new EmployeeHandler().InsertEmployeeLeave(leave);
            else
                new EmployeeHandler().SaveEmpLeave(leave);

            ClearForm();
            pnlForm.Visible = false;
            BindLeaves();

            StringBuilder msg = new StringBuilder("<div class='alert alert-success'>Leave saved.</div>");
            if (result.Warnings.Count > 0)
                msg.Append("<div class='alert alert-warning'><b>Please note:</b><br />").Append(Bullets(result.Warnings, Server.HtmlEncode)).Append("</div>");
            MsgLbl.Text = msg.ToString();
        }

        protected void EmpLeavesLv_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName != "EditLeave" && e.CommandName != "DeleteLeave")
                return;
            int id;
            if (!int.TryParse(Convert.ToString(e.CommandArgument), out id))
                return;

            List<EmployeeLeave> mine = new EmployeeHandler().GetEmployeeLeaves(EmpId);
            EmployeeLeave rec = mine == null ? null : mine.FirstOrDefault(x => x.EmpLeaveId == id);
            if (rec == null)
                return;

            if (e.CommandName == "EditLeave")
            {
                LoadForm(rec);
            }
            else
            {
                new EmployeeHandler().DeleteEmployeeLeave(id);
                if (EditLeaveId == id)
                {
                    ClearForm();
                    pnlForm.Visible = false;
                }
                BindLeaves();
                MsgLbl.Text = "<div class='alert alert-success'>Leave deleted.</div>";
            }
        }

        #endregion

        #region Template helpers

        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }

        public string GetDebit(object typeId, object subTypeId, object start, object end)
        {
            if (typeId == null || subTypeId == null || start == null || end == null)
                return "";
            int calendarDays = LeaveRules2.CalendarDays(Convert.ToDateTime(start), Convert.ToDateTime(end));
            int debit = LeaveRules2.DebitDays(Convert.ToInt32(typeId), Convert.ToInt32(subTypeId), calendarDays);
            return debit == 0 ? "-" : debit + " Days";
        }

        public string GetDetails(object remarks)
        {
            string text = Convert.ToString(remarks);
            if (LeaveRules2.HasMedicalCertificate(text))
                return (LeaveRules2.StripMedicalTag(text) + " (Medical Certificate)").Trim();
            return text;
        }

        #endregion
    }
}
