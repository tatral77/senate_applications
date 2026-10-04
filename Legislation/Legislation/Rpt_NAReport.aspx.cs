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
    public partial class Rpt_NAReport  : System.Web.UI.Page
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
            List<Bills> Bills = new LegislationBiz().GetBillsByHouse(parliamentaryYearsId,2);  //2 = National Assembly
            ListView1.DataSource = Bills;
            ListView1.DataBind();
        }
        protected void BindControls()
        {
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
            List<BillCategories> QCats = new LegislationBiz().GetBillCategories();
            if (QCats != null)
            {
                foreach (BillCategories row in QCats)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.BillCategoriesId.ToString();
                    BillCategoryDDL.Items.Add(li);
                }
            }
            List<BillStatuses> billStatuses = new LegislationBiz().GetActiveBillStatuses();
            if (QCats != null)
            {
                foreach (BillStatuses row in billStatuses)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.BillStatusesId.ToString();
                    BillStatusDDL.Items.Add(li);
                }
            }
            List<BillTypes> billTypes = new LegislationBiz().GetBillTypes();
            if (billTypes != null)
            {
                foreach (BillTypes row in billTypes)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.BillTypesId.ToString();
                    BillTypeDDL.Items.Add(li);
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
            ParliamentaryTerms parliamentaryTerms = new LegislationBiz().GetCurrentParliamentaryTerms();
            if (parliamentaryTerms != null)
            {
                List<Committees> committees = new CommitteesBiz().GetCommitteesByParliamentaryTerm(parliamentaryTerms.ParliamentaryTermsId);
                ;
                if (committees != null)
                {
                    foreach (Committees row in committees)
                    {
                        ListItem li = new ListItem();
                        li.Text = row.CommitteeName;
                        li.Value = row.CommitteesId.ToString();
                        CommitteeDDL.Items.Add(li);
                    }
                }
            }
        }
        public string GetLink(string BillId)
        {
            string link = "~/BillDetail.aspx?Id=" + BillId;
            if (Request.Cookies["userInfo"] != null)
            {
                HttpCookie userInfo = Request.Cookies["userInfo"];
                string role = Convert.ToString(userInfo["role"]);
                if (role.Equals("SO"))
                    link = "~/QuestionDetailsRest.aspx?QuestionsId=" + BillId;
            }
            return link;

        }
        public string GetMinText(string txt)
        {
            string text = Regex.Replace(txt, @"<[^>]+>|&nbsp;", "").Trim();
            if (txt.Length >= 350 && FullTextCB.Checked == false)
                text = txt.Substring(0, 350).Trim() + ".................";
            else
                text = txt;
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

            if (FromAssemblySessionDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " BILLS.ASSEMBLY_SESSIONS_ID>=" + FromAssemblySessionDDL.SelectedItem.Value;

            }
            if (ToAssemblySessionDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " BILLS.ASSEMBLY_SESSIONS_ID<=" + ToAssemblySessionDDL.SelectedItem.Value;

            }
            if (ParliamentaryYearsDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " BILLS.PARLIAMENTARY_YEAR_ID=" + ParliamentaryYearsDDL.SelectedItem.Value;

            }
            //if (GenderDDL.SelectedItem.Value != "0")
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " SYSTEM_USERS.GENDER=" + GenderDDL.SelectedItem.Value;

            //}
            //if (ReligionDDL.SelectedItem.Value != "0")
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " SYSTEM_USERS.RELIGIONS_ID=" + ReligionDDL.SelectedItem.Value;

            //}
            //if (NotReligionDDL.SelectedItem.Value != "0")
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " SYSTEM_USERS.RELIGIONS_ID<>" + NotReligionDDL.SelectedItem.Value;

            //}


            if (!(String.IsNullOrEmpty(BillIdTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " BILLS.BILLS_ID IN (" + BillIdTxt.Text + ")";

            }
            if (!(String.IsNullOrEmpty(FileNumberTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " BILLS.FILE_NUMBER LIKE '%" + FileNumberTxt.Text + "%'";

            }

            if (BillStatusDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " BILLS.BILL_STATUS_ID=" + BillStatusDDL.SelectedItem.Value;

            }

            if (BillCategoryDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " BILLS.BILL_CATEGORIES_ID=" + BillCategoryDDL.SelectedItem.Value;

            }
            if (CommitteeDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " BILLS.COMMITTEE_ID=" + CommitteeDDL.SelectedItem.Value;

            }
            string memberFilter = MultiPick.LikeAny("MEMBERS", HidMemberId.Value);
            if (memberFilter != "")
            {
                if (query != "")
                    query += " AND ";
                query += memberFilter;
            }
            string ministerFilter = MultiPick.LikeAny("MINISTERS", HidMinisterId.Value);
            if (ministerFilter != "")
            {
                if (query != "")
                    query += " AND ";
                query += ministerFilter;
            }
            string divisionFilter = MultiPick.LikeAny("DIVISIONS", HidDivisionId.Value);
            if (divisionFilter != "")
            {
                if (query != "")
                    query += " AND ";
                query += divisionFilter;
            }
            //if (!(String.IsNullOrEmpty(KeywordsTxt.Text)))
            //{
            //    if (query != "")
            //        query += " AND ";
            //    if (ExactMatchCB.Checked == true)
            //        query += " QUESTION_TEXT LIKE '%" + KeywordsTxt.Text + "%' COLLATE SQL_Latin1_General_CP1_CS_AS ";
            //    else
            //        query += " QUESTION_TEXT LIKE '%" + KeywordsTxt.Text + "%'";

            //}
            //if (!(String.IsNullOrEmpty(NoticeDiaryNo.Text)))
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " QUESTIONS.NOTICE_DIARY_NO  IN (" + NoticeDiaryNo.Text + ") ";

            //}
            if (!(String.IsNullOrEmpty(NoticeDateFromTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " BILL.NOTICE_DIARY_DATE>=CONVERT(DATETIME, '" + NoticeDateFromTxt.Text + "', 104)";

            }
            if (!(String.IsNullOrEmpty(NoticeDateToTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += "BILL.NOTICE_DIARY_DATE<=CONVERT(DATETIME, '" + NoticeDateToTxt.Text + "', 104)";

            }

            if (query != "")
                query += " AND ";
            query += " BILLS.HOUSE_TYPES_ID=2 "; //2=National Assembly
            return query;

        }
        protected void search()
        {
            string criteria = GetCriteria();
            if (criteria == String.Empty)
                bindListView();
            else
            {
                string query = "SELECT        BILLS.BILLS_ID, BILLS.UPDATED_BY, BILLS.PARLIAMENTARY_YEAR_ID, BILLS.CURRENT_ROLE, BILLS.BILL_TYPE_ID, BILLS.PRIORITY, BILLS.BILL_STATUS_ID, BILLS.STATUS_DATE, BILLS.BILL_DATE, BILLS.BILL_TIME, ";
                query += " BILLS.ASSEMBLY_SESSIONS_ID, BILLS.SESSION_SITTINGS_ID, BILLS.REVIEWED_BY, BILLS.REMARKS, BILLS.IS_ACTIVE, BILLS.NOTICE_DIARY_DATE, BILLS.NOTICE_DIARY_NO, BILLS.NOTICE_DIARY_TIME,  ";
                query += " BILLS.LEGISLATION_DIARY_NO, BILLS.LEGISLATION_DIARY_DATE, BILLS.LEGISLATION_DIARY_TIME, BILLS.GOVT_BILL_DATE, BILLS.MOTION_DATE, BILLS.BILL_PASSAGE_DATE, BILLS.BILL_ASSENT_DATE,  ";
                query += " BILLS.IS_WITH_STANDING_COMMITTEE, BILLS.BUDGET_PRES_DATE, BILLS.F_BILL_PRES_DATE, BILLS.DISCUSS_DAYS, BILLS.PARTICIPATED_MEMBERS, BILLS.GOVT_P_MEMBERS, BILLS.OPP_P_MEMBERS,  ";
                query += " BILLS.SNT_REC_DATE, BILLS.SNT_REC_TIME, BILLS.SNT_ENTRY_DATE, BILLS.SNT_ENTRY_TIME, BILLS.SNT_REFERENCE, BILLS.SNT_RECOMMENDATION, BILLS.BILL_IDENTIFIER, BILLS.FILE_NUMBER,  ";
                query += " BILLS.PASSED_AS_REPT_BY_SC, BILLS.PASSED_WO_ST_CMT, BILLS.IS_ACT, BILLS.BILL_CATEGORIES_ID, BILLS.BILL_STAGES_ID, BILLS.BILL_GAZETTED_DATE, BILLS.SEND_TO_NA_DATE, BILLS.IS_WITH_PRESIDENT,  ";
                query += " BILLS.SEND_TO_PRESIDENT_DATE, BILLS.HOUSE_TYPES_ID, ASSEMBLY_SESSIONS.SESSION_NUMBER AS SESSION_NUMBER_DESC, BILLS.IS_WITH_NA, BILLS.AND_WHEREAS, BILLS.NOW_THEREFORE,  ";
                query += " BILLS.WITHDRAWAL_DATE, BILLS.FIRST_READING_DATE, BILLS.SECOND_READING_DATE, BILLS.THIRD_READING_DATE, BILLS.IS_ENTERED_BY_MEMBER, BILLS.MED_CMT_REF_DATE, BILLS.MED_CMT_PRES_DATE,  ";
                query += " BILLS.AGREED_BILL_CONS_DATE, BILLS.AGREED_BILL_PASS_DATE, BILLS.OTHER_HOUSE_RECEIPT_DATE, BILLS.BILL_CIRC_DATE, BILLS.MINISTER_NOTICE_DATE, BILLS.NOTICE_CIRC_DATE,  ";
                query += " BILLS.LAW_DIV_SENT_DATE, BILLS.LAW_DIV_REC_DATE, BILLS.OTHER_HOUSE_INTIMATE_DATE, BILLS.OTHER_HOUSE_RETURN_DATE, BILLS.ACT_GAZETTE_PUB_DATE, BILLS.PUBLIC_OPINION, BILLS.CII_OPINION,  ";
                query += " BILLS.PUBLIC_OPINION_CIRC_DATE, BILLS.PUBLIC_OPINION_DATE, BILLS.CII_REFER_DATE, BILLS.CII_REPORT_DATE, BILLS.BILL_YEAR, BILLS.PRESIDENT_ASSENT_DATE, BILLS.FINANCE_BILL_REFERENCE,  ";
                query += " BILLS.IS_SENT_TO_SENATE, BILLS.IS_SENT_TO_COMMITTEE, BILLS.IS_LEAVE_GRANTE, BILLS.LEAVE_GRANTED_BY, BILLS.DESIGNATION, BILLS.LEAVE_GRANTE_DATE, BILLS.IS_WITH_MED_COMMITTEE,  ";
                query += " BILLS.SUBJECT, BILLS.REJECT_AMEND_DATE, BILLS.LETTER, BILLS.NOTING, BILLS.DIVISIONS_ID, BILLS.IS_SENT_TO_TRANSLATION, BILLS.URDU_TEXT, BILLS.AMENDED_CONTENT, BILLS.MEM_BILL_SUBJECT,  ";
                query += " BILLS.MEM_BILL_CONTENT, HOUSE_TYPES.DESCRIPTION AS HOUSE_TYPE, BILL_CATEGORIES.DESCRIPTION AS BILL_CATEGORY, BILL_STATUSES.DESCRIPTION AS BILL_STATUS,  ";
                query += " BILL_TYPES.DESCRIPTION AS BILL_TYPE, BILLS.BILL_FILE, BILLS.BILL_TITLE, BILLS.DEVICE_ID, BILLS.NOTICE_FILE, BILLS.COMMITTEE_REMARKS,BILLS.RECEIVED_FROM_NA_DATE, BILLS.COMMITTEE_REPORT_FILE, BILLS.COMMITTEE_ID,  ";
                query += " BILLS.COMMITTEE_REF_DATE, BILLS.PASSED_BY_NA_DATE,BILLS.NA_REMARKS,BILLS.MEMBER_WITHDRAWAL_STATUS_ID,BILLS.CONSIDERATION_SESSION_ID,BILLS.MEMBER_WITHDRAWAL_STATUS_DATE,BILLS.HOUSE_FOR_CONSIDERATION_DATE,BILLS.MEMBER_REMARKS, ";
                query += " BILLS.UPDATED_ON,BILLS.IS_DELETED, BILLS.INSERTED_BY,BILLS.DELETED_BY, BILLS.RECOVERED_BY, BILLS.INSERTED_ON, BILLS.DELETED_ON, BILLS.RECOVERED_ON, BILLS.UPDATED_ON, ";
                query += " (SELECT        COMMITTEE_NAME ";
                query += " FROM            COMMITTEES ";
                query += " WHERE(COMMITTEES_ID = BILLS.COMMITTEE_ID)) AS COMMITTEE_NAME, PARLIAMENTARY_YEARS.PARLIAMENTARY_YEAR, BILLS.MEMBERS, BILLS.MINISTERS, BILLS.DIVISIONS, BILLS.BILL_INTRODUCE_DATE,  ";
                query += " BILLS.COMMITTEE_DAYS_LIMIT, BILLS.COMMITTEE_RECOMMENDATION_ID, BILLS.COMMITTEE_REPORT_DATE ";
                query += " FROM            BILLS INNER JOIN ";
                query += " ASSEMBLY_SESSIONS ON BILLS.ASSEMBLY_SESSIONS_ID = ASSEMBLY_SESSIONS.ASSEMBLY_SESSIONS_ID INNER JOIN ";
                query += " BILL_TYPES ON BILLS.BILL_TYPE_ID = BILL_TYPES.BILL_TYPES_ID INNER JOIN ";
                query += " BILL_STATUSES ON BILLS.BILL_STATUS_ID = BILL_STATUSES.BILL_STATUSES_ID INNER JOIN ";
                query += " BILL_CATEGORIES ON BILLS.BILL_CATEGORIES_ID = BILL_CATEGORIES.BILL_CATEGORIES_ID INNER JOIN ";
                query += " HOUSE_TYPES ON BILLS.HOUSE_TYPES_ID = HOUSE_TYPES.HOUSE_TYPES_ID INNER JOIN ";
                query += " PARLIAMENTARY_YEARS ON BILLS.PARLIAMENTARY_YEAR_ID = PARLIAMENTARY_YEARS.PARLIAMENTARY_YEARS_ID ";
                if (GetCriteria() != String.Empty)
                {
                    query += " WHERE ";
                    query += criteria;
                }
                // query += " ORDER BY QUESTIONS.REPLY_DATE  ";
                query += " ORDER BY BILLS.NOTICE_DIARY_DATE DESC";
                List<Bills> bills = new LegislationBiz().SearchBills(query);
                ListView1.DataSource = bills;
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
            BillCategoryDDL.SelectedItem.Value = "0";
            ParliamentaryYearsDDL.SelectedItem.Value = "0";
            BillStatusDDL.SelectedItem.Value = "0";
            NoticeDateFromTxt.Text = "";
            NoticeDateToTxt.Text = "";
            KeywordsTxt.Text = "";
            MemberNameTxt.Text = "";
            HidMemberId.Value = "";
            BillIdTxt.Text = "";

        }
        protected void FromAssemblySessionDDL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ToAssemblySessionDDL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CategoryDDL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CategoryDDL_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
        //protected void CheckAll_CheckedChanged(object sender, EventArgs e)
        //{
        //    foreach (ListViewItem li in ListView1.Items)
        //    {
        //        CheckBox cb = (CheckBox)li.FindControl("SelectCB");
        //        if (cb != null)
        //        {
        //            if (CheckAll.Checked == true)
        //                cb.Checked = true;
        //            else
        //                cb.Checked = false;
        //        }
        //    }

        //}
        public string GetBillMovers(List<BillMovers> billMovers)
        {
            string movers = "";
            if(billMovers!=null)
            {
                foreach(BillMovers mover in billMovers)
                {
                    movers = mover.Mover + ", ";
                }
                
            }
            return movers;
        }
        public string GetBillMinisters(List<BillMinisters> billMinisters)
        {
            string movers = "";
            if (billMinisters != null)
            {
                foreach (BillMinisters mover in billMinisters)
                {
                    movers = mover.MinisterName + ", ";
                }

            }
            return movers;
        }

    }
}
