using EstablishmentBIZ;
using EstablishmentENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace EstablishmentASP.Reports
{
    public partial class Rpt_25_Promotion : System.Web.UI.Page
    {
        string lastrec = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindListView();
                bindFields();

            }

        }
        private void bindListView()
        {
            string query = null;
            query += " SELECT EMP_PROMOTION_HIST.SYSTEM_USERS_ID, EMP_PROMOTION_HIST.DATED, EMP_PROMOTION_HIST.REMARKS, EMP_PROMOTION_HIST.POST, EMP_PROMOTION_HIST.BRANCH, ";
                         query += " EMP_PROMOTION_HIST.BASIC_PAY_SCALES_ID, EMP_PROMOTION_HIST.IS_GAZETTED, EMP_PROMOTION_HIST.PROMOTION_TYPE_ID, EMP_PROMOTION_HIST.PROMOTION_MODES_ID,  ";
            query += " PROMOTION_MODES.DESCRIPTION AS PROMOTION_MODE, PROMOTION_TYPES.PROMOTION_TYPE, BASIC_PAY_SCALES.DESCRIPTION AS BPS_DESC, SYSTEM_USERS.F_NAME, POSTS.DESCRIPTION AS POST_DESC  ";
            query += " FROM            EMP_PROMOTION_HIST INNER JOIN  ";
            query += " PROMOTION_MODES ON EMP_PROMOTION_HIST.PROMOTION_MODES_ID = PROMOTION_MODES.PROMOTION_MODES_ID INNER JOIN  ";
            query += " PROMOTION_TYPES ON EMP_PROMOTION_HIST.PROMOTION_TYPE_ID = PROMOTION_TYPES.PROMOTION_TYPE_ID INNER JOIN  ";
            query += " SYSTEM_USERS ON EMP_PROMOTION_HIST.SYSTEM_USERS_ID = SYSTEM_USERS.SYSTEM_USERS_ID INNER JOIN  ";
            query += " BASIC_PAY_SCALES ON EMP_PROMOTION_HIST.BASIC_PAY_SCALES_ID = BASIC_PAY_SCALES.BASIC_PAY_SCALES_ID INNER JOIN  ";
            query += " POSTS ON EMP_PROMOTION_HIST.POST = POSTS.POSTS_ID INNER JOIN  ";
            query += " EMP_EMPLOYMENTS ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_EMPLOYMENTS.SYSTEM_USERS_ID  ";
            //List<Rpt_Promotion> EmpList = new ReportsBIZ().GetPromotionHistory(query);
            //EmpListView.DataSource = EmpList;
            //EmpListView.DataBind();

        }
       
        private void bindFields()
        {

            List<BPS> bps = new AdministrationBIZ().GetAllBPS();
            foreach (BPS row in bps)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.BpsId.ToString();
                BPSFrom.Items.Add(li);
                BPSTo.Items.Add(li);
            }

            PromotionTypeDDL.Items.Add(new ListItem("Select", "0"));
            List<TempEntity> pt = new AdministrationBIZ().GetPromotionTypes();

            foreach (TempEntity row in pt)
            {
                ListItem cy = new ListItem();
                cy.Value = row.Id.ToString();
                cy.Text = row.Description.ToString();
                PromotionTypeDDL.Items.Add(cy);
            }
            PromotionModeDDL.Items.Add(new ListItem("Select", "0"));
            List<TempEntity> pt1 = new AdministrationBIZ().GetPromotionModes();

            foreach (TempEntity row in pt1)
            {
                ListItem cy = new ListItem();
                cy.Value = row.Id.ToString();
                cy.Text = row.Description.ToString();
                PromotionModeDDL.Items.Add(cy);
            }
            List<Post> posts = new AdministrationBIZ().GetActivePosts();
            foreach (Post row in posts)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.PostID.ToString();
                Designation.Items.Add(li);
            }
            List<CurrentStatuses> pt2 = new AdministrationBIZ().GetCurrentStatuses();

            foreach (CurrentStatuses row in pt2)
            {
                ListItem cy = new ListItem();
                cy.Value = row.CurrentStatusId.ToString();
                cy.Text = row.CurrentStatus.ToString();
                CurrentStatusDDL.Items.Add(cy);
            }
            //CurrentStatusDDL.SelectedValue = "9";
            List<EmpStatus> ps = new AdministrationBIZ().GetEmpStatusList();
            foreach (EmpStatus row in ps)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.EmpStatusId.ToString();
                EmpStatusDDL.Items.Add(li);
            }
            //EmpStatusDDL.SelectedValue = "1";
            List<Branch> br = new AdministrationBIZ().GetBranches();
            foreach (Branch row in br)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.Branchid.ToString();
                Branch.Items.Add(li);
            }
            List<Province> pr = new AdministrationBIZ().GetProvinces();
            foreach (Province row in pr)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.ProvincesID.ToString();
                Province.Items.Add(li);
            }
            List<EmployeePools> EmpPools = new AdministrationBIZ().GetEmpPools();
            foreach (EmployeePools row in EmpPools)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.EmpPoolsId.ToString();
                EmpPoolDDL.Items.Add(li);
            }
        }
        protected void GetHeader()
        {
            if (PromotionTypeDDL.SelectedItem.Value != "0")
            {
                lblHeader.Text = " ( " + PromotionTypeDDL.SelectedItem.Text.ToUpper() + " ) ";
            }
            else
                lblHeader.Text = " ( All Promotion Types ) ";
        }
        protected string GetHeading()
        {
            if (EmpStatusDDL.SelectedItem.Text == "Contract")
            {
                return "<th>Contract Type</th>";
            }
            else
                return null;
        }
        //protected Control GetFields()
        //{
        //    Label lbl = new Label();
        //    lbl.ID = "abc";
        //    lbl.Text = "<%#Eval(\"Quota\")%>";
        //    lbl.Attributes.Add("class", "table-data");
        //    TableRow ts = new TableRow();
        //    ts.Controls.Add(lbl);
        //    if (EmpStatusDDL.SelectedItem.Text == "Contract")
        //    {
        //        return ts;
        //    }
        //    else
        //        return null;
        //}



        protected string GetCriteria()
        {
            string query = "";
            if (!(String.IsNullOrEmpty(FileNoTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " emp_employments.file_no like '" + FileNoTxt.Text + "%'";

            }
            if (!(String.IsNullOrEmpty(EmpName.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " system_users.f_name like '%" + EmpName.Text + "%'";

            }
            if (IsActiveCB.SelectedItem.Value != "select")
            {
                if (query != "")
                    query += " AND ";
                query += " system_users.is_active=" + IsActiveCB.SelectedItem.Value;

            }
            if (!(String.IsNullOrEmpty(AgeFrom.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " DATEDIFF(yy,system_users.dob,GetDate())>=" + AgeFrom.Text;
            }
            if (!(String.IsNullOrEmpty(AgeTo.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " DATEDIFF(yy,system_users.dob,GetDate())<=" + AgeTo.Text;
            }
            if (!(String.IsNullOrEmpty(ExpFrom.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " DATEDIFF(yy,emp_employments.GOVT_SERVICE_START_DATE,GetDate())>=" + ExpFrom.Text;
            }
            if (!(String.IsNullOrEmpty(ExpTo.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " DATEDIFF(yy,emp_employments.GOVT_SERVICE_START_DATE,GetDate())<=" + ExpTo.Text;
            }
            if (Gender.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " system_users.gender=" + Gender.SelectedItem.Value;

            }
            if (BPSFrom.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " emp_employments.BASIC_PAY_SCALES_ID>=" + BPSFrom.SelectedItem.Value;

            }
            if (BPSTo.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " emp_employments.BASIC_PAY_SCALES_ID<=" + BPSTo.SelectedItem.Value;

            }
            if (EmpStatusDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " emp_employments.emp_status_id=" + EmpStatusDDL.SelectedItem.Value;

            }
            if (Province.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " system_users.perm_province=" + Province.SelectedItem.Value;

            }
            if (Designation.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += "emp_employments.post_held=" + Designation.SelectedItem.Value;

            }
            if (Branch.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " emp_employments.branch=" + Branch.SelectedItem.Value;

            }
            if (EmpPoolDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " emp_employments.employee_pools_id=" + EmpPoolDDL.SelectedItem.Value;

            }
            //if (CurrentStatusDDL.SelectedItem.Value != "0")
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " emp_empl_history.current_status_id=" + CurrentStatusDDL.SelectedItem.Value;

            //}
            if (PromotionModeDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " EMP_PROMOTION_HIST.PROMOTION_MODES_ID=" + PromotionModeDDL.SelectedItem.Value;

            }
            if (PromotionTypeDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " EMP_PROMOTION_HIST.PROMOTION_TYPE_ID=" + PromotionTypeDDL.SelectedItem.Value;

            }
            if (!(String.IsNullOrEmpty(DateFromTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " FROM_DATE>= " + DateFromTxt.Text;
            }
            if (!(String.IsNullOrEmpty(DateToTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " FROM_DATE<= " + DateToTxt.Text;
            }
            if (CurrentStatusDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " emp_employments.current_status=" + CurrentStatusDDL.SelectedItem.Value;
                //CriteriaLbl.Text += ", <b>Current Status:</b>" + CurrentStatusDDL.SelectedItem.Text;

            }
            return query;

        }
        protected string AddGroupingRow()
        {
            string currentSemesterValue = Convert.ToString(Eval("EmployeeName"));
            if (currentSemesterValue != lastrec)
            {
                lastrec = currentSemesterValue;
                return String.Format("<tr class=group><td colspan=9><b>" + Eval("EmployeeName") + "</b></td></tr>");

            }
            else return String.Empty;
        }
        protected void Search_Click(object sender, EventArgs e)
        {

            string query = null;
            string criteria = null;
            query += " SELECT EMP_PROMOTION_HIST.SYSTEM_USERS_ID, EMP_PROMOTION_HIST.DATED, EMP_PROMOTION_HIST.REMARKS, EMP_PROMOTION_HIST.POST, EMP_PROMOTION_HIST.BRANCH, ";
            query += " EMP_PROMOTION_HIST.BASIC_PAY_SCALES_ID,EMP_PROMOTION_HIST.IS_CURRENT, EMP_PROMOTION_HIST.IS_GAZETTED, EMP_PROMOTION_HIST.PROMOTION_TYPE_ID, EMP_PROMOTION_HIST.PROMOTION_MODES_ID,  ";
            query += " PROMOTION_MODES.DESCRIPTION AS PROMOTION_MODE, PROMOTION_TYPES.PROMOTION_TYPE, BASIC_PAY_SCALES.DESCRIPTION AS BPS_DESC, SYSTEM_USERS.F_NAME, POSTS.DESCRIPTION AS POST_DESC  ";
            query += " FROM            EMP_PROMOTION_HIST INNER JOIN  ";
            query += " PROMOTION_MODES ON EMP_PROMOTION_HIST.PROMOTION_MODES_ID = PROMOTION_MODES.PROMOTION_MODES_ID INNER JOIN  ";
            query += " PROMOTION_TYPES ON EMP_PROMOTION_HIST.PROMOTION_TYPE_ID = PROMOTION_TYPES.PROMOTION_TYPE_ID INNER JOIN  ";
            query += " SYSTEM_USERS ON EMP_PROMOTION_HIST.SYSTEM_USERS_ID = SYSTEM_USERS.SYSTEM_USERS_ID INNER JOIN  ";
            query += " BASIC_PAY_SCALES ON EMP_PROMOTION_HIST.BASIC_PAY_SCALES_ID = BASIC_PAY_SCALES.BASIC_PAY_SCALES_ID INNER JOIN  ";
            query += " POSTS ON EMP_PROMOTION_HIST.POST = POSTS.POSTS_ID INNER JOIN  ";
            query += " EMP_EMPLOYMENTS ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_EMPLOYMENTS.SYSTEM_USERS_ID  ";
            criteria = GetCriteria();
            if (criteria != null)
            {
                query += " WHERE SYSTEM_USERS.IS_ACTIVE=1 AND ";
                query += criteria;
            }
            query += " ORDER BY EMP_PROMOTION_HIST.BASIC_PAY_SCALES_ID DESC,EMP_PROMOTION_HIST.DATED DESC";
            List<Rpt_Promotion> EmpList = new ReportsBIZ().GetPromotionHistory(query);
            EmpListView.DataSource = EmpList;
            EmpListView.DataBind();
            GetHeader();

        }

        protected void ClearSearch_Click(object sender, EventArgs e)
        {
            bindListView();
        }
        public string GetDate(DateTime date)
        {
            return (date < Convert.ToDateTime("01/01/1900")) ? string.Empty : date.ToShortDateString();
        }
        public string GetDuration(DateTime FromDate, DateTime ToDate)
        {
            string duration = "";
            if (ToDate < Convert.ToDateTime("01/01/1900"))
                return "";
            else
            {
                int days = new DateTimeUtils().CalculateNumberofDays(FromDate, ToDate);
                if (days < 30)
                    return days + " Day(s)";
                int years = days / 365;
                int months = (days % 365) / 30;
                if (years != 0)
                    duration = years + " Year(s) ";
                if (months != 0)
                    duration = months + " Month(s) ";


                return duration;

            }
        }
    }
}