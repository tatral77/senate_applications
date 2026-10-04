using CommitteesEntities;
using LegisBIZ;
using LegisEntities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Legislation
{
    public partial class SearchOrdinances : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindControls();
                bindListView();
            }
        }
        private void bindListView()
        {
            int parliamentaryYearsId = new AdministrationBiz().GetCurrentParliamentaryYear().ParliamentaryYearsId;
            List<Ordinances> ordinances = new LegislationBiz().GetOrdinances(parliamentaryYearsId);
            ListView1.DataSource = ordinances;
            ListView1.DataBind();


        }
        protected void BindControls()
        {
            List<OrdinanceStatuses> ordinanceStatuses = new LegislationBiz().GetOrdinanceStatuses();

            if (ordinanceStatuses != null)
            {
                foreach (OrdinanceStatuses row in ordinanceStatuses)
                {
                    ListItem li = new ListItem();
                    li.Text = row.OrdinanceStatus.ToString();
                    li.Value = row.OrdinanceStatusId.ToString();
                    StatusDDL.Items.Add(li);
                }
            }
            List<ParliamentaryYears> parliamentaryYears = new LegislationBiz().GetParliamentaryYears();
            if (parliamentaryYears != null)
            {
                List<ParliamentaryYears> sorted = parliamentaryYears.OrderByDescending(o => o.FromDate).ToList();
                foreach (ParliamentaryYears row in sorted)
                {
                    ListItem li = new ListItem();
                    li.Text = row.ParliamentaryYear;
                    li.Value = row.ParliamentaryYearsId.ToString();
                    ParliamentaryYearsDDL.Items.Add(li);
                }
            }
            List<AssemblySessions> assemblySessions = new LegislationBiz().GetAssemblySessions();
            if (assemblySessions != null)
            {
                ListItem listitem = new ListItem
                {
                    Value = "0",
                    Text = "Select"
                };
                FromAssemblySessionDDL.Items.Add(listitem);
                ToAssemblySessionDDL.Items.Add(listitem);
                foreach (AssemblySessions row in assemblySessions)
                {
                    ListItem li = new ListItem();
                    li.Text = row.SessionNumber.ToString();
                    li.Value = row.AssemblySessionsId.ToString();
                    FromAssemblySessionDDL.Items.Add(li);
                    ToAssemblySessionDDL.Items.Add(li);
                }
            }
        }
        public string GetLink(string Id)
        {
           return "~/OrdinanceDetails.aspx?Id=" + Id;

        }
        public string GetMinText(string txt)
        {
            string text = Regex.Replace(txt, @"<[^>]+>|&nbsp;", "").Trim();
            //if (txt.Length >= 350 && FullTextCB.Checked == false)
            //    text = txt.Substring(0, 350).Trim() + ".................";
            //else
            //    text = txt;
            return text;

        }
        public string SelectText(string Text)
        {
            string keywords = KeywordsTxt.Text;
            if (Text != string.Empty && keywords != string.Empty)
            {
                string[] sKeywords = keywords.Split(' ');
                foreach (string sKeyword in sKeywords)
                {
                    try
                    {
                        Text = Regex.Replace(Text, sKeyword, string.Format("<strong><span class=\"hit\">{0}</span></strong>", "$0"), RegexOptions.IgnoreCase);
                        // Text = Regex.Replace(Text, sKeyword, string.Format("<strong>{0}</strong>", "$0"), RegexOptions.IgnoreCase);
                    }
                    catch
                    {
                        //
                    }
                }

                return Text;
            }
            else
                return GetMinText(Text);
        }
        public string GetTime(DateTime time)
        {
            return time.ToShortTimeString();
        }
        public string GetDate(DateTime date)
        {
            if (date < Convert.ToDateTime("01/01/1900"))
                return "";
            else
                return date.ToShortDateString();

        }

        protected string GetCriteria()
        {
            string query = "";
            int ordinanceId;
            if (int.TryParse(OrdinanceIdTxt.Text.Trim(), out ordinanceId))
            {
                if (query != "")
                    query += " AND ";
                query += " ORDINANCES.ORDINANCES_ID=" + ordinanceId;
            }
            if (!string.IsNullOrEmpty(KeywordsTxt.Text))
            {
                if (query != "")
                    query += " AND ";
                query += " (ORDINANCES.REMARKS LIKE '%" + KeywordsTxt.Text.Replace("'", "''") + "%' OR ORDINANCES.SUBJECT LIKE '%" + KeywordsTxt.Text.Replace("'", "''") + "%')";
            }

            if (FromAssemblySessionDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " ORDINANCES.ASSEMBLY_SESSIONS_ID>=" + FromAssemblySessionDDL.SelectedItem.Value;

            }
            if (ToAssemblySessionDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " ORDINANCES.ASSEMBLY_SESSIONS_ID<=" + ToAssemblySessionDDL.SelectedItem.Value;

            }
            if (ParliamentaryYearsDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " ORDINANCES.PARLIAMENTARY_YEARS_ID=" + ParliamentaryYearsDDL.SelectedItem.Value;

            }
            if (StatusDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " ORDINANCES.ORDINANCE_STATUS_ID=" + StatusDDL.SelectedItem.Value;

            }
            //if (query != "")
            //    query += " AND ";
            //query += " IS_DELETED=0 ";
            return query;

        }
        protected void search()
        {
            string criteria = GetCriteria();
            if (criteria == String.Empty)
                bindListView();
            else
            {
                string query = "SELECT ORDINANCES.ORDINANCES_ID, ORDINANCES.SUBJECT, ORDINANCES.ORD_NUMBER, ORDINANCES.PROMULGATE_DATE, ORDINANCES.GAZETTE_DATE, ORDINANCES.LAYING_DATE, ORDINANCES.NOTICE_DISAPP_DATE, ";
                         query += " ORDINANCES.DISAPPROVE_DATE,ORDINANCES.REMARKS, ORDINANCES.PARLIAMENTARY_YEARS_ID, ORDINANCES.ASSEMBLY_SESSIONS_ID, ORDINANCES.PRE_ORDINANCES_ID, ORDINANCES.ORDINANCE_STATUS_ID, ";
                         query += " PARLIAMENTARY_YEARS.PARLIAMENTARY_YEAR, ASSEMBLY_SESSIONS.SESSION_NUMBER, ORDINANCE_STATUSES.ORDINANCE_STATUS,ORDINANCES.STATUS_DATE ";
                        query += " FROM            ORDINANCES INNER JOIN ";
                        query += " PARLIAMENTARY_YEARS ON ORDINANCES.PARLIAMENTARY_YEARS_ID = PARLIAMENTARY_YEARS.PARLIAMENTARY_YEARS_ID INNER JOIN ";
                        query += " ASSEMBLY_SESSIONS ON ORDINANCES.ASSEMBLY_SESSIONS_ID = ASSEMBLY_SESSIONS.ASSEMBLY_SESSIONS_ID ";
                        query += " INNER JOIN ORDINANCE_STATUSES ON ORDINANCES.ORDINANCE_STATUS_ID = ORDINANCE_STATUSES.ORDINANCE_STATUS_ID";
                if (GetCriteria() != String.Empty)
                {
                    query += " WHERE ";
                    query += criteria;
                }
                // query += " ORDER BY QUESTIONS.REPLY_DATE  ";
                query += " ORDER BY ORDINANCES.PROMULGATE_DATE DESC";
                List<Ordinances> ordinances = new LegislationBiz().SearchOrdinance(query);
                ListView1.DataSource = ordinances;
                ListView1.DataBind();
            }
        }
        protected void Search_Click(object sender, EventArgs e)
        {
            search();
        }
        protected void ClearSearch_Click(object sender, EventArgs e)
        {
            bindListView();

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            FromAssemblySessionDDL.SelectedItem.Value = "0";
            ToAssemblySessionDDL.SelectedItem.Value = "0";
            ParliamentaryYearsDDL.SelectedItem.Value = "0";
            KeywordsTxt.Text = "";

        }
    }
}