using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using EstablishmentDAL;

namespace EstablishmentASP
{
    /// <summary>
    /// Read-only viewer of dbo.AuditLog. Access is limited to the role ids listed in the AuditLogRoleIds setting of Web.config.
    /// </summary>
    public partial class Logs : System.Web.UI.Page
    {
        private const int PageSize = 50;
        private const int ExportLimit = 50000;

        private int PageIndex
        {
            get { return ViewState["PageIndex"] == null ? 0 : (int)ViewState["PageIndex"]; }
            set { ViewState["PageIndex"] = value; }
        }

        private int TotalRows
        {
            get { return ViewState["TotalRows"] == null ? 0 : (int)ViewState["TotalRows"]; }
            set { ViewState["TotalRows"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HasAccess())
            {
                ContentPnl.Visible = false;
                ExportBtn.Visible = false;
                return;
            }
            if (!IsPostBack)
            {
                ActionDDL.Items.Add(new System.Web.UI.WebControls.ListItem("All actions", ""));
                try
                {
                    foreach (string a in AuditLogReader.Actions())
                        ActionDDL.Items.Add(a);
                }
                catch (Exception ex)
                {
                    ErrorLbl.Text = "The audit table could not be read: " + Server.HtmlEncode(ex.Message);
                }
                Bind();
            }
        }

        /// <summary>The page is only for the roles named in Web.config (AuditLogRoleIds, comma separated).</summary>
        private bool HasAccess()
        {
            HttpCookie cookie = Request.Cookies["userInfo"];
            if (cookie == null)
                return false;
            string role = cookie["roleid"];
            string allowed = ConfigurationManager.AppSettings["AuditLogRoleIds"];
            bool ok = false;
            if (!string.IsNullOrWhiteSpace(allowed) && !string.IsNullOrWhiteSpace(role))
            {
                foreach (string r in allowed.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (string.Equals(r.Trim(), role.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        ok = true;
                        break;
                    }
                }
            }
            if (!ok)
            {
                NoAccessPnl.Visible = true;
                NoAccessLbl.Text = string.IsNullOrWhiteSpace(allowed)
                    ? "The audit log is not enabled. Add the role ids that may view it to the AuditLogRoleIds setting in Web.config (your role id is "
                        + Server.HtmlEncode(role ?? "unknown") + ")."
                    : "You do not have permission to view the audit log.";
            }
            return ok;
        }

        private AuditLogFilter ReadFilter()
        {
            AuditLogFilter f = new AuditLogFilter();
            DateTime d;
            ErrorLbl.Text = "";
            if (!string.IsNullOrWhiteSpace(FromTxt.Text))
            {
                if (DateTime.TryParse(FromTxt.Text.Trim(), CultureInfo.CurrentCulture, DateTimeStyles.None, out d)) f.From = d;
                else ErrorLbl.Text = "From date is not a valid date. ";
            }
            if (!string.IsNullOrWhiteSpace(ToTxt.Text))
            {
                if (DateTime.TryParse(ToTxt.Text.Trim(), CultureInfo.CurrentCulture, DateTimeStyles.None, out d)) f.To = d;
                else ErrorLbl.Text += "To date is not a valid date. ";
            }
            int emp;
            if (!string.IsNullOrWhiteSpace(EmployeeTxt.Text))
            {
                if (int.TryParse(EmployeeTxt.Text.Trim(), out emp)) f.EmployeeId = emp;
                else ErrorLbl.Text += "Employee id must be a number. ";
            }
            f.User = UserTxt.Text;
            f.Action = ActionDDL.SelectedValue;
            f.TableName = TableTxt.Text;
            f.RecordId = RecordTxt.Text;
            f.Kind = KindDDL.SelectedValue;
            if (f.From.HasValue && f.To.HasValue && f.To.Value < f.From.Value)
                ErrorLbl.Text += "To date cannot be earlier than From date. ";
            return f;
        }

        private void Bind()
        {
            AuditLogFilter f = ReadFilter();
            if (ErrorLbl.Text.Length > 0)
            {
                LogsLV.DataSource = null;
                LogsLV.DataBind();
                SummaryLbl.Text = "";
                SetPager(0);
                return;
            }
            try
            {
                int total;
                DataTable t = AuditLogReader.Search(f, PageIndex, PageSize, out total);
                int pages = Math.Max(1, (int)Math.Ceiling(total / (double)PageSize));
                if (PageIndex > pages - 1)
                {
                    PageIndex = pages - 1;
                    t = AuditLogReader.Search(f, PageIndex, PageSize, out total);
                }
                TotalRows = total;
                LogsLV.DataSource = t;
                LogsLV.DataBind();
                int from = total == 0 ? 0 : PageIndex * PageSize + 1;
                int to = Math.Min(total, (PageIndex + 1) * PageSize);
                SummaryLbl.Text = total.ToString("N0") + " entr" + (total == 1 ? "y" : "ies") + " found" + (total == 0 ? "" : ", showing " + from.ToString("N0") + " - " + to.ToString("N0"));
                SetPager(pages);
            }
            catch (Exception ex)
            {
                ErrorLbl.Text = "The audit log could not be read: " + Server.HtmlEncode(ex.Message);
                SetPager(0);
            }
        }

        private void SetPager(int pages)
        {
            PageLbl.Text = pages <= 0 ? "" : "Page " + (PageIndex + 1) + " of " + pages;
            bool hasPrev = pages > 0 && PageIndex > 0;
            bool hasNext = pages > 0 && PageIndex < pages - 1;
            FirstBtn.Enabled = PrevBtn.Enabled = hasPrev;
            NextBtn.Enabled = LastBtn.Enabled = hasNext;
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            PageIndex = 0;
            Bind();
        }

        protected void ClearBtn_Click(object sender, EventArgs e)
        {
            FromTxt.Text = ToTxt.Text = UserTxt.Text = TableTxt.Text = EmployeeTxt.Text = RecordTxt.Text = "";
            KindDDL.SelectedIndex = 0;
            ActionDDL.SelectedIndex = 0;
            PageIndex = 0;
            Bind();
        }

        protected void FirstBtn_Click(object sender, EventArgs e) { PageIndex = 0; Bind(); }
        protected void PrevBtn_Click(object sender, EventArgs e) { PageIndex = Math.Max(0, PageIndex - 1); Bind(); }
        protected void NextBtn_Click(object sender, EventArgs e) { PageIndex++; Bind(); }
        protected void LastBtn_Click(object sender, EventArgs e)
        {
            PageIndex = Math.Max(0, (int)Math.Ceiling(TotalRows / (double)PageSize) - 1);
            Bind();
        }

        /// <summary>The filtered entries as a CSV file (up to 50,000 rows).</summary>
        protected void ExportBtn_Click(object sender, EventArgs e)
        {
            if (!HasAccess())
                return;
            AuditLogFilter f = ReadFilter();
            if (ErrorLbl.Text.Length > 0)
                return;
            DataTable t;
            try
            {
                t = AuditLogReader.Export(f, ExportLimit);
            }
            catch (Exception ex)
            {
                ErrorLbl.Text = "The audit log could not be exported: " + Server.HtmlEncode(ex.Message);
                return;
            }
            StringBuilder sb = new StringBuilder();
            string[] cols = { "AuditId", "ActionOn", "UserId", "UserName", "Action", "TableName", "RecordId", "EmployeeId", "OldValues", "NewValues", "PageUrl", "IpAddress" };
            sb.AppendLine(string.Join(",", cols));
            foreach (DataRow r in t.Rows)
            {
                for (int i = 0; i < cols.Length; i++)
                {
                    object v = r[cols[i]];
                    string s = v == DBNull.Value ? "" : (v is DateTime ? ((DateTime)v).ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) : Convert.ToString(v, CultureInfo.InvariantCulture));
                    // stop spreadsheet programs from running a value as a formula
                    if (s.Length > 0 && (s[0] == '=' || s[0] == '+' || s[0] == '-' || s[0] == '@'))
                        s = "'" + s;
                    sb.Append('"').Append(s.Replace("\"", "\"\"")).Append('"');
                    if (i < cols.Length - 1) sb.Append(',');
                }
                sb.AppendLine();
            }
            Response.Clear();
            Response.ContentType = "text/csv";
            Response.ContentEncoding = new UTF8Encoding(true);
            Response.AddHeader("Content-Disposition", "attachment; filename=AuditLog_" + DateTime.Now.ToString("yyyyMMdd_HHmm", CultureInfo.InvariantCulture) + ".csv");
            Response.BinaryWrite(new UTF8Encoding(true).GetPreamble());
            Response.Write(sb.ToString());
            Response.End();
        }

        protected string BadgeClass(string action)
        {
            if (string.IsNullOrEmpty(action)) return "lg-other";
            if (action.StartsWith("INSERT_", StringComparison.OrdinalIgnoreCase) || action.StartsWith("SAVE_", StringComparison.OrdinalIgnoreCase)) return "lg-insert";
            if (action.StartsWith("UPDATE_", StringComparison.OrdinalIgnoreCase)) return "lg-update";
            if (action.StartsWith("DELETE_", StringComparison.OrdinalIgnoreCase)) return "lg-delete";
            if (action.StartsWith("UI_", StringComparison.OrdinalIgnoreCase)) return "lg-ui";
            return "lg-other";
        }

        /// <summary>A one-line preview of the saved values, shown in the list (the full set is under "View").</summary>
        protected string NewValuesPreview(object dataItem)
        {
            DataRowView row = dataItem as DataRowView;
            if (row == null || row["NewValues"] == DBNull.Value)
                return "";
            string json = Convert.ToString(row["NewValues"]);
            if (json.Trim().Length == 0)
                return "";
            StringBuilder sb = new StringBuilder();
            StringBuilder full = new StringBuilder();
            MatchCollection pairs = JsonPair.Matches(json);
            if (pairs.Count == 0)
            {
                string raw = json.Length > 160 ? json.Substring(0, 160) + "..." : json;
                return "<span title=\"" + HttpUtility.HtmlAttributeEncode(json) + "\">" + HttpUtility.HtmlEncode(raw) + "</span>";
            }
            int shown = 0;
            foreach (Match m in pairs)
            {
                string k = Unescape(m.Groups[1].Value), v = Unescape(m.Groups[2].Value);
                full.Append(k).Append(": ").Append(v).Append('\n');
                if (sb.Length < 160)
                {
                    if (shown > 0) sb.Append("; ");
                    sb.Append("<b>").Append(HttpUtility.HtmlEncode(k)).Append(":</b> ").Append(HttpUtility.HtmlEncode(v.Length > 40 ? v.Substring(0, 40) + "..." : v));
                    shown++;
                }
            }
            if (shown < pairs.Count)
                sb.Append(" ... (+").Append(pairs.Count - shown).Append(" more)");
            return "<span title=\"" + HttpUtility.HtmlAttributeEncode(full.ToString()) + "\">" + sb + "</span>";
        }

        /// <summary>The expandable part of a row: saved values (old and new), the page and the address of the computer.</summary>
        protected string DetailsHtml(object dataItem)
        {
            DataRowView row = dataItem as DataRowView;
            if (row == null)
                return "";
            StringBuilder sb = new StringBuilder();
            AppendValues(sb, "New values", row["NewValues"]);
            AppendValues(sb, "Old values", row["OldValues"]);
            string url = row["PageUrl"] == DBNull.Value ? "" : Convert.ToString(row["PageUrl"]);
            string ip = row["IpAddress"] == DBNull.Value ? "" : Convert.ToString(row["IpAddress"]);
            if (url.Length > 0 || ip.Length > 0)
            {
                sb.Append("<div class='lg-h'>Request</div><table class='lg-kv'>");
                if (url.Length > 0) sb.Append("<tr><td>Page</td><td>").Append(HttpUtility.HtmlEncode(url)).Append("</td></tr>");
                if (ip.Length > 0) sb.Append("<tr><td>Address</td><td>").Append(HttpUtility.HtmlEncode(ip)).Append("</td></tr>");
                sb.Append("</table>");
            }
            sb.Append("<div class='lg-h'>Entry</div><table class='lg-kv'><tr><td>Id</td><td>").Append(row["AuditId"]).Append("</td></tr></table>");
            return sb.ToString();
        }

        private static readonly Regex JsonPair = new Regex("\"((?:\\\\.|[^\"\\\\])*)\"\\s*:\\s*\"((?:\\\\.|[^\"\\\\])*)\"", RegexOptions.Compiled);

        private static void AppendValues(StringBuilder sb, string title, object value)
        {
            if (value == null || value == DBNull.Value)
                return;
            string json = Convert.ToString(value);
            if (json.Trim().Length == 0)
                return;
            sb.Append("<div class='lg-h'>").Append(title).Append("</div>");
            MatchCollection pairs = JsonPair.Matches(json);
            if (pairs.Count == 0)
            {
                sb.Append("<div>").Append(HttpUtility.HtmlEncode(json)).Append("</div>");
                return;
            }
            sb.Append("<table class='lg-kv'>");
            foreach (Match m in pairs)
                sb.Append("<tr><td>").Append(HttpUtility.HtmlEncode(Unescape(m.Groups[1].Value))).Append("</td><td>").Append(HttpUtility.HtmlEncode(Unescape(m.Groups[2].Value))).Append("</td></tr>");
            sb.Append("</table>");
        }

        private static string Unescape(string s)
        {
            return Regex.Replace(s, @"\\(u[0-9a-fA-F]{4}|.)", m =>
            {
                string g = m.Groups[1].Value;
                if (g.Length == 5) return ((char)Convert.ToInt32(g.Substring(1), 16)).ToString();
                switch (g)
                {
                    case "n": return "\n";
                    case "r": return "\r";
                    case "t": return "\t";
                    default: return g;
                }
            });
        }
    }
}
