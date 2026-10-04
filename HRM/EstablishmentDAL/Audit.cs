using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace EstablishmentDAL
{
    /// <summary>
    /// Writes audit entries to dbo.AuditLog through dbo.AuditLog_Insert.
    /// Logging never throws: a problem with the audit table must not stop a user's save.
    /// </summary>
    public static class AuditLogger
    {
        private static readonly Regex WriteAction = new Regex(@"^(INSERT|UPDATE|DELETE|SAVE)_", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex SecretName = new Regex(@"pass|pwd|secret|token", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        // parameters that point at other records, not at the record being changed
        private static readonly Regex NotThePrimaryKey = new Regex(@"^@(user_?id|system_?users?_?id|emp_?id|employee_?id|post_?id|bps_?id?|bps|branch_?id|action)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex EmployeeParam = new Regex(@"^@(user_?id|system_?users?_?id|emp_?id|employee_?id)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private const int MaxValueLength = 500;
        private const int MaxJsonLength = 3800;

        /// <summary>Call right after a stored procedure command has been executed. Only INSERT_/UPDATE_/DELETE_/SAVE_ actions are logged.</summary>
        public static void LogCommand(SqlCommand cmd)
        {
            try
            {
                if (cmd == null || cmd.Parameters == null || !cmd.Parameters.Contains("@Action"))
                    return;
                string action = Convert.ToString(cmd.Parameters["@Action"].Value);
                if (string.IsNullOrEmpty(action) || !WriteAction.IsMatch(action))
                    return;

                int underscore = action.IndexOf('_');
                string kind = action.Substring(0, underscore).ToUpperInvariant();
                string entity = action.Substring(underscore + 1).ToUpperInvariant();

                string recordId = null;
                int? employeeId = null;
                string bestKeyName = null;
                Dictionary<string, string> values = new Dictionary<string, string>();

                foreach (SqlParameter p in cmd.Parameters)
                {
                    string name = p.ParameterName;
                    if (name.Equals("@Action", StringComparison.OrdinalIgnoreCase))
                        continue;
                    object v = p.Value;
                    if (v == null || v == DBNull.Value)
                        continue;
                    if (v is byte[] || SecretName.IsMatch(name))
                    {
                        values[name.TrimStart('@')] = "(not logged)";
                        continue;
                    }

                    string text = Convert.ToString(v, CultureInfo.InvariantCulture);
                    if (v is DateTime)
                        text = ((DateTime)v).ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    if (text.Length > MaxValueLength)
                        text = text.Substring(0, MaxValueLength) + "...";
                    values[name.TrimStart('@')] = text;

                    if (employeeId == null && EmployeeParam.IsMatch(name))
                    {
                        int emp;
                        if (int.TryParse(text, out emp))
                            employeeId = emp;
                    }
                    // the most specific *Id parameter that is not a link to another table is the record's own key
                    if (name.EndsWith("id", StringComparison.OrdinalIgnoreCase) && !NotThePrimaryKey.IsMatch(name)
                        && (bestKeyName == null || name.Length > bestKeyName.Length))
                    {
                        bestKeyName = name;
                        recordId = text;
                    }
                }

                // for inserts the new key comes back in an output parameter
                if (cmd.Parameters.Contains("@ID") && cmd.Parameters["@ID"].Value != null && cmd.Parameters["@ID"].Value != DBNull.Value
                    && (cmd.Parameters["@ID"].Direction == ParameterDirection.Output || cmd.Parameters["@ID"].Direction == ParameterDirection.InputOutput))
                {
                    recordId = Convert.ToString(cmd.Parameters["@ID"].Value, CultureInfo.InvariantCulture);
                }

                string json = ToJson(values);
                Write(kind + "_" + entity, entity, recordId, employeeId, null, json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError("AuditLogger.LogCommand failed: " + ex.Message);
            }
        }

        /// <summary>Free-form entry, for code that changes data outside the stored procedures (or for page level events).</summary>
        public static void Log(string action, string tableName, string recordId, int? employeeId, string oldValues, string newValues)
        {
            try
            {
                Write(action, tableName, recordId, employeeId, oldValues, newValues);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError("AuditLogger.Log failed: " + ex.Message);
            }
        }

        private static void Write(string action, string tableName, string recordId, int? employeeId, string oldValues, string newValues)
        {
            int? userId;
            string userName;
            CurrentUser(out userId, out userName);

            string url = null, ip = null;
            HttpContext ctx = HttpContext.Current;
            if (ctx != null && ctx.Request != null)
            {
                try
                {
                    url = ctx.Request.Url.AbsolutePath + (string.IsNullOrEmpty(ctx.Request.Url.Query) ? "" : ctx.Request.Url.Query);
                    ip = ctx.Request.UserHostAddress;
                }
                catch (Exception) { }
            }

            // its own connection, so the audit row is written even if the caller's connection is closing
            using (SqlConnection con = new DalHelper().GetConnection())
            using (SqlCommand cmd = new SqlCommand("[dbo].[AuditLog_Insert]", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 15;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId.HasValue ? (object)userId.Value : DBNull.Value;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 150).Value = (object)Trim(userName, 150) ?? DBNull.Value;
                cmd.Parameters.Add("@Action", SqlDbType.VarChar, 100).Value = Trim(action, 100);
                cmd.Parameters.Add("@TableName", SqlDbType.VarChar, 128).Value = (object)Trim(tableName, 128) ?? DBNull.Value;
                cmd.Parameters.Add("@RecordId", SqlDbType.VarChar, 100).Value = (object)Trim(recordId, 100) ?? DBNull.Value;
                cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employeeId.HasValue ? (object)employeeId.Value : DBNull.Value;
                cmd.Parameters.Add("@OldValues", SqlDbType.NVarChar, -1).Value = (object)oldValues ?? DBNull.Value;
                cmd.Parameters.Add("@NewValues", SqlDbType.NVarChar, -1).Value = (object)newValues ?? DBNull.Value;
                cmd.Parameters.Add("@PageUrl", SqlDbType.NVarChar, 400).Value = (object)Trim(url, 400) ?? DBNull.Value;
                cmd.Parameters.Add("@IpAddress", SqlDbType.VarChar, 45).Value = (object)Trim(ip, 45) ?? DBNull.Value;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>The signed-in user, from the same "userInfo" cookie the application already uses.</summary>
        public static void CurrentUser(out int? userId, out string userName)
        {
            userId = null;
            userName = null;
            HttpContext ctx = HttpContext.Current;
            if (ctx == null)
                return;
            try
            {
                HttpCookie cookie = ctx.Request.Cookies["userInfo"];
                // on the login request the cookie is only in the response
                if ((cookie == null || cookie.Values["userid"] == null) && ctx.Response != null && Array.IndexOf(ctx.Response.Cookies.AllKeys, "userInfo") >= 0)
                    cookie = ctx.Response.Cookies["userInfo"];
                if (cookie == null || cookie.Values == null)
                    return;
                int id;
                if (int.TryParse(cookie.Values["userid"], out id))
                    userId = id;
                userName = cookie.Values["FullName"];
            }
            catch (Exception) { }
        }

        private static string Trim(string s, int max)
        {
            if (s == null)
                return null;
            return s.Length > max ? s.Substring(0, max) : s;
        }

        private static string ToJson(Dictionary<string, string> values)
        {
            StringBuilder sb = new StringBuilder("{");
            bool first = true;
            foreach (KeyValuePair<string, string> kv in values)
            {
                if (sb.Length > MaxJsonLength)
                {
                    sb.Append(first ? "" : ",").Append("\"...\":\"truncated\"");
                    break;
                }
                if (!first) sb.Append(',');
                first = false;
                sb.Append('"').Append(Escape(kv.Key)).Append("\":\"").Append(Escape(kv.Value)).Append('"');
            }
            return sb.Append('}').ToString();
        }

        private static string Escape(string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                switch (c)
                {
                    case '"': sb.Append("\\\""); break;
                    case '\\': sb.Append("\\\\"); break;
                    case '\n': sb.Append("\\n"); break;
                    case '\r': sb.Append("\\r"); break;
                    case '\t': sb.Append("\\t"); break;
                    default:
                        if (c < 32) sb.Append("\\u").Append(((int)c).ToString("x4"));
                        else sb.Append(c);
                        break;
                }
            }
            return sb.ToString();
        }
    }

    /// <summary>Search options of the log viewer. Every field is optional.</summary>
    public class AuditLogFilter
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }          // inclusive: the whole day is included
        public string User { get; set; }           // part of the name, or the exact user id
        public string Action { get; set; }
        public string TableName { get; set; }
        public string RecordId { get; set; }
        public int? EmployeeId { get; set; }
        public string Kind { get; set; }           // "DATA" data changes only, "UI" page actions only, empty = both
    }

    /// <summary>Read side of dbo.AuditLog (used by Logs.aspx). All values go in as parameters.</summary>
    public static class AuditLogReader
    {
        private static string Like(string s)
        {
            return "%" + s.Trim().Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]") + "%";
        }

        private static string Where(AuditLogFilter f, SqlCommand cmd)
        {
            List<string> w = new List<string>();
            if (f == null)
                return "";
            if (f.From.HasValue)
            {
                w.Add("ActionOn >= @From");
                cmd.Parameters.Add("@From", SqlDbType.DateTime2).Value = f.From.Value.Date;
            }
            if (f.To.HasValue)
            {
                w.Add("ActionOn < @ToNext");
                cmd.Parameters.Add("@ToNext", SqlDbType.DateTime2).Value = f.To.Value.Date.AddDays(1);
            }
            if (!string.IsNullOrWhiteSpace(f.User))
            {
                int uid;
                if (int.TryParse(f.User.Trim(), out uid))
                {
                    w.Add("(UserId = @UserId OR UserName LIKE @UserName)");
                    cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = uid;
                }
                else
                {
                    w.Add("UserName LIKE @UserName");
                }
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 200).Value = Like(f.User);
            }
            if (!string.IsNullOrWhiteSpace(f.Action))
            {
                w.Add("Action LIKE @Action");
                cmd.Parameters.Add("@Action", SqlDbType.VarChar, 200).Value = Like(f.Action);
            }
            if (!string.IsNullOrWhiteSpace(f.TableName))
            {
                w.Add("TableName LIKE @TableName");
                cmd.Parameters.Add("@TableName", SqlDbType.VarChar, 200).Value = Like(f.TableName);
            }
            if (!string.IsNullOrWhiteSpace(f.RecordId))
            {
                w.Add("RecordId = @RecordId");
                cmd.Parameters.Add("@RecordId", SqlDbType.VarChar, 100).Value = f.RecordId.Trim();
            }
            if (f.EmployeeId.HasValue)
            {
                w.Add("EmployeeId = @EmployeeId");
                cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = f.EmployeeId.Value;
            }
            if (string.Equals(f.Kind, "UI", StringComparison.OrdinalIgnoreCase))
                w.Add("Action LIKE 'UI[_]%'");
            else if (string.Equals(f.Kind, "DATA", StringComparison.OrdinalIgnoreCase))
                w.Add("Action NOT LIKE 'UI[_]%'");
            return w.Count == 0 ? "" : " WHERE " + string.Join(" AND ", w.ToArray());
        }

        private const string Columns = "AuditId, ActionOn, UserId, UserName, Action, TableName, RecordId, EmployeeId, OldValues, NewValues, PageUrl, IpAddress";

        /// <summary>One page of entries, newest first, and the total number of matching entries.</summary>
        public static DataTable Search(AuditLogFilter filter, int pageIndex, int pageSize, out int total)
        {
            if (pageSize < 1) pageSize = 50;
            if (pageSize > 200) pageSize = 200;
            if (pageIndex < 0) pageIndex = 0;
            DataTable table = new DataTable();
            using (SqlConnection con = new DalHelper().GetConnection())
            {
                using (SqlCommand count = new SqlCommand())
                {
                    count.Connection = con;
                    count.CommandTimeout = 60;
                    count.CommandText = "SELECT COUNT_BIG(*) FROM dbo.AuditLog" + Where(filter, count);
                    total = (int)Math.Min(int.MaxValue, Convert.ToInt64(count.ExecuteScalar()));
                }
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 60;
                    cmd.CommandText = "SELECT " + Columns + " FROM dbo.AuditLog" + Where(filter, cmd)
                        + " ORDER BY ActionOn DESC, AuditId DESC OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY";
                    cmd.Parameters.Add("@Skip", SqlDbType.Int).Value = pageIndex * pageSize;
                    cmd.Parameters.Add("@Take", SqlDbType.Int).Value = pageSize;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(table);
                }
            }
            return table;
        }

        /// <summary>Up to maxRows matching entries for a file export, newest first.</summary>
        public static DataTable Export(AuditLogFilter filter, int maxRows)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new DalHelper().GetConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandTimeout = 120;
                cmd.CommandText = "SELECT TOP (@Max) " + Columns + " FROM dbo.AuditLog" + Where(filter, cmd) + " ORDER BY ActionOn DESC, AuditId DESC";
                cmd.Parameters.Add("@Max", SqlDbType.Int).Value = maxRows;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(table);
            }
            return table;
        }

        /// <summary>The distinct action names present in the log, for the filter list.</summary>
        public static List<string> Actions()
        {
            List<string> list = new List<string>();
            using (SqlConnection con = new DalHelper().GetConnection())
            using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT TOP 500 Action FROM dbo.AuditLog ORDER BY Action", con))
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                    list.Add(Convert.ToString(dr[0]));
            }
            return list;
        }
    }

    /// <summary>
    /// HTTP module: logs the user's save / delete / login style page actions (which button was pressed, on which page, for which employee).
    /// It never records what was typed into the form. Data changes are logged separately by AuditLogger.LogCommand in the data layer.
    /// </summary>
    public class AuditModule : IHttpModule
    {
        // button / link names that mean "the user changed something or did something worth recording"
        private static readonly Regex Interesting = new Regex(@"(save|insert|update|delete|remove|submit|login|logout|signin|export|print|assign|approve|reject|process|upload|reset|password)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex Ignored = new Regex(@"(cancel|edit|new|search|clear|select|page|sort)", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public void Init(HttpApplication app)
        {
            app.EndRequest += OnEndRequest;
        }

        public void Dispose() { }

        private static void OnEndRequest(object sender, EventArgs e)
        {
            try
            {
                HttpApplication app = (HttpApplication)sender;
                HttpContext ctx = app.Context;
                HttpRequest req = ctx.Request;
                if (!string.Equals(req.HttpMethod, "POST", StringComparison.OrdinalIgnoreCase))
                    return;
                string path = req.Url.AbsolutePath;
                if (!path.EndsWith(".aspx", StringComparison.OrdinalIgnoreCase) && !path.EndsWith(".ashx", StringComparison.OrdinalIgnoreCase))
                    return;
                if (ctx.Error != null || ctx.Response.StatusCode >= 400)
                    return;

                string target = ClickedControl(req);
                if (string.IsNullOrEmpty(target))
                    return;
                string shortName = target;
                int cut = Math.Max(shortName.LastIndexOf('$'), shortName.LastIndexOf(':'));
                if (cut >= 0)
                    shortName = shortName.Substring(cut + 1);
                if (!Interesting.IsMatch(shortName) || Ignored.IsMatch(shortName) && !Regex.IsMatch(shortName, "(save|insert|update|delete|login)", RegexOptions.IgnoreCase))
                    return;

                int? employeeId = null;
                int emp;
                if (int.TryParse(req.QueryString["EmpId"] ?? req.QueryString["empid"], out emp))
                    employeeId = emp;

                string page = path.Substring(path.LastIndexOf('/') + 1);
                AuditLogger.Log("UI_" + shortName.ToUpperInvariant(), page, null, employeeId, null, null);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError("AuditModule failed: " + ex.Message);
            }
        }

        /// <summary>The control that caused the post back: link buttons use __EVENTTARGET, ordinary buttons post their own name.</summary>
        private static string ClickedControl(HttpRequest req)
        {
            string t = req.Form["__EVENTTARGET"];
            if (!string.IsNullOrEmpty(t))
                return t;
            foreach (string key in req.Form.AllKeys)
            {
                if (key == null || key.StartsWith("__"))
                    continue;
                string last = key.Substring(Math.Max(key.LastIndexOf('$'), key.LastIndexOf(':')) + 1);
                // a submit button appears in the form data under its own name; text boxes and lists also do, so only accept button-like names
                if (Regex.IsMatch(last, "(btn|button)$", RegexOptions.IgnoreCase) || Interesting.IsMatch(last) && req.Form[key] != null && req.Form[key].Length < 40 && !Regex.IsMatch(last, "(txt|ddl|hid|cb|lb)", RegexOptions.IgnoreCase))
                    return key;
            }
            return null;
        }
    }
}
