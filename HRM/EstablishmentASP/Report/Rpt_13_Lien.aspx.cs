using EstablishmentBIZ;
using EstablishmentENT;
using EstablishmentENT.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace EstablishmentASP.Reports
{
    public partial class Rpt_13_Lien : System.Web.UI.Page
    {
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
            query += " SELECT EMPL_OUT.EMPL_OUT_ID, EMPL_OUT.SYSTEM_USER_ID,  CONCAT(ISNULL(SYSTEM_USERS.F_NAME, ' '), ' ', ISNULL(SYSTEM_USERS.M_NAME, ' '), ' ', ISNULL(SYSTEM_USERS.L_NAME, ''))  AS EMP_NAME, ";
            query += " EMPL_OUT.EMPL_OUT_TYPE_ID, EMPL_OUT.FROM_DATE, EMPL_OUT.EMPL_OUT_POST, EMPL_OUT.TO_DATE, EMPL_OUT.EMPL_IN_BPS, EMPL_OUT.EMPL_IN_POST, EMPL_OUT.IS_EXTENDED, EMPL_OUT.REMARKS, ";
            query += " EMPL_OUT_TYPES.EMPL_OUT_TYPE, SYSTEM_USERS.F_NAME, SYSTEM_USERS.M_NAME, SYSTEM_USERS.L_NAME, EMP_EMPLOYMENTS.POST_HELD, EMP_EMPLOYMENTS.BRANCH, ";
            query += " EMP_EMPLOYMENTS.POST_STATUS, EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID, POSTS.DESCRIPTION AS POST, BASIC_PAY_SCALES.DESCRIPTION AS BPS, EMPL_OUT.EMPL_OUT_BPS, ";
            query += " BRANCHES.DESCRIPTION AS BRANCH_NAME ";
            query += " FROM POSTS INNER JOIN ";
            query += " EMPL_OUT INNER JOIN ";
            query += " EMPL_OUT_TYPES ON EMPL_OUT.EMPL_OUT_TYPE_ID = EMPL_OUT_TYPES.EMPL_OUT_TYPE_ID INNER JOIN ";
            query += " SYSTEM_USERS ON EMPL_OUT.SYSTEM_USER_ID = SYSTEM_USERS.SYSTEM_USERS_ID INNER JOIN ";
            query += " EMP_EMPLOYMENTS ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_EMPLOYMENTS.SYSTEM_USERS_ID INNER JOIN ";
            query += " BASIC_PAY_SCALES ON EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID = BASIC_PAY_SCALES.BASIC_PAY_SCALES_ID ON POSTS.POSTS_ID = EMP_EMPLOYMENTS.POST_HELD INNER JOIN ";
            query += " BRANCHES ON EMP_EMPLOYMENTS.BRANCH = BRANCHES.BRANCHES_ID AND EMP_EMPLOYMENTS.BRANCH = BRANCHES.BRANCHES_ID AND EMP_EMPLOYMENTS.BRANCH = BRANCHES.BRANCHES_ID WHERE TO_DATE>GetDate()";
            query += " AND SYSTEM_USERS.IS_ACTIVE=1";
            List<Rpt_Lien> EmpList = new ReportsBIZ().RptGetEmploymentOut(query);
            EmpListView.DataSource = EmpList;
            EmpListView.DataBind();

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
           
            EmploymentOutTypeDDL.Items.Add(new ListItem("Select", "0"));
            List<EmploymentOutTypes> pt = new AdministrationBIZ().GetEmploymentOutTypes();

            foreach (EmploymentOutTypes row in pt)
            {
                ListItem cy = new ListItem();
                cy.Value = row.EmploymentOutTypeId.ToString();
                cy.Text = row.EmploymentOuType.ToString();
                EmploymentOutTypeDDL.Items.Add(cy);
            }
            List<Post> posts = new AdministrationBIZ().GetActivePosts();
            foreach (Post row in posts)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.PostID.ToString();
                Designation.Items.Add(li);
            }
            List<CurrentStatuses> pt1 = new AdministrationBIZ().GetCurrentStatuses();

            foreach (CurrentStatuses row in pt1)
            {
                ListItem cy = new ListItem();
                cy.Value = row.CurrentStatusId.ToString();
                cy.Text = row.CurrentStatus.ToString();
                CurrentStatusDDL.Items.Add(cy);
            }
           // CurrentStatusDDL.SelectedValue = "9";
            List<EmpStatus> ps = new AdministrationBIZ().GetEmpStatusList();
            foreach (EmpStatus row in ps)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.EmpStatusId.ToString();
                EmpStatusDDL.Items.Add(li);
            }
           // EmpStatusDDL.SelectedValue = "1";
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
            if (EmpStatusDDL.SelectedItem.Value != "0")
            {
                lblHeader.Text = " ( " + EmploymentOutTypeDDL.SelectedItem.Text.ToUpper() + " ) ";
            }
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
            if (!(String.IsNullOrEmpty(StartDateFromTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " FROM_DATE>CONVERT(datetime,'" + StartDateFromTxt.Text + "' , 103)";
            }
            if (!(String.IsNullOrEmpty(StartDateToTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " FROM_DATE<CONVERT(datetime,'" + StartDateToTxt.Text + "' , 103)";
            }

            if (!(String.IsNullOrEmpty(EndDateFromTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " TO_DATE>CONVERT(datetime,'" + StartDateFromTxt.Text + "' , 103)";
            }
            if (!(String.IsNullOrEmpty(EndDateToTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " TO_DATE<CONVERT(datetime,'" + EndDateToTxt.Text + "' , 103)";
            }
            if (EmploymentOutTypeDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " EMPL_OUT.EMPL_OUT_TYPE_ID=" + EmploymentOutTypeDDL.SelectedItem.Value;

            }
           




            if (query != "")
                    query += " AND ";
            query += " SYSTEM_USERS.IS_ACTIVE=1 ";
           
            return query;

        }
        protected void Search_Click(object sender, EventArgs e)
        {

            string query = null;
            string criteria = null;
            query += " SELECT EMPL_OUT.EMPL_OUT_ID, EMPL_OUT.SYSTEM_USER_ID,  CONCAT(ISNULL(SYSTEM_USERS.F_NAME, ' '), ' ', ISNULL(SYSTEM_USERS.M_NAME, ' '), ' ', ISNULL(SYSTEM_USERS.L_NAME, ''))  AS EMP_NAME, ";
            query += " EMPL_OUT.EMPL_OUT_TYPE_ID, EMPL_OUT.FROM_DATE, EMPL_OUT.EMPL_OUT_POST, EMPL_OUT.TO_DATE, EMPL_OUT.EMPL_IN_BPS, EMPL_OUT.EMPL_IN_POST, EMPL_OUT.IS_EXTENDED, EMPL_OUT.REMARKS, ";
            query += " EMPL_OUT_TYPES.EMPL_OUT_TYPE, SYSTEM_USERS.F_NAME, SYSTEM_USERS.M_NAME, SYSTEM_USERS.L_NAME, EMP_EMPLOYMENTS.POST_HELD, EMP_EMPLOYMENTS.BRANCH, ";
            query += " EMP_EMPLOYMENTS.POST_STATUS, EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID, POSTS.DESCRIPTION AS POST, BASIC_PAY_SCALES.DESCRIPTION AS BPS, EMPL_OUT.EMPL_OUT_BPS, ";
            query += " BRANCHES.DESCRIPTION AS BRANCH_NAME ";
            query += " FROM POSTS INNER JOIN ";
            query += " EMPL_OUT INNER JOIN ";
            query += " EMPL_OUT_TYPES ON EMPL_OUT.EMPL_OUT_TYPE_ID = EMPL_OUT_TYPES.EMPL_OUT_TYPE_ID INNER JOIN ";
            query += " SYSTEM_USERS ON EMPL_OUT.SYSTEM_USER_ID = SYSTEM_USERS.SYSTEM_USERS_ID INNER JOIN ";
            query += " EMP_EMPLOYMENTS ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_EMPLOYMENTS.SYSTEM_USERS_ID INNER JOIN ";
            query += " BASIC_PAY_SCALES ON EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID = BASIC_PAY_SCALES.BASIC_PAY_SCALES_ID ON POSTS.POSTS_ID = EMP_EMPLOYMENTS.POST_HELD INNER JOIN ";
            query += " BRANCHES ON EMP_EMPLOYMENTS.BRANCH = BRANCHES.BRANCHES_ID AND EMP_EMPLOYMENTS.BRANCH = BRANCHES.BRANCHES_ID AND EMP_EMPLOYMENTS.BRANCH = BRANCHES.BRANCHES_ID ";
            criteria = GetCriteria();
            if (criteria != null)
            {
                query += " WHERE SYSTEM_USERS.IS_ACTIVE=1 AND ";
                query += criteria;
            }
            query += " ORDER BY FROM_DATE DESC";
            List<Rpt_Lien> EmpList = new ReportsBIZ().RptGetEmploymentOut(query);
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
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }
        public string GetDuration(DateTime FromDate, DateTime ToDate)
        {
            int days = new DateTimeUtils().CalculateNumberofDays(FromDate, ToDate);
            int years = days / 365;
            return Convert.ToString(years) + " Year(s)";                   
        }

    }
}