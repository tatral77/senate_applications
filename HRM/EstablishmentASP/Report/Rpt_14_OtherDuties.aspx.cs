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
    public partial class Rpt_14_OtherDuties : System.Web.UI.Page
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
            query += " SELECT EMP_OTHER_DUTIES.EMP_OTHER_DUTY_ID, EMP_OTHER_DUTIES.SYSTEM_USERS_ID,CONCAT(ISNULL(SYSTEM_USERS.F_NAME, ' '), ' ', ISNULL(SYSTEM_USERS.M_NAME, ' '), ' ', ISNULL(SYSTEM_USERS.L_NAME, ''))  AS EMP_NAME,  EMP_OTHER_DUTIES.POST_ID, EMP_OTHER_DUTIES.BPS_ID, EMP_OTHER_DUTIES.OTHER_DUTY_TYPE_ID, ";
                         query += "EMP_OTHER_DUTIES.DUTY_YEAR, EMP_OTHER_DUTIES.DETAILS, OTHER_DUTY_TYPES.OTHER_DUTY_TYPE, SYSTEM_USERS.F_NAME, SYSTEM_USERS.M_NAME, SYSTEM_USERS.L_NAME, ";
            query += "EMP_EMPLOYMENTS.POST_HELD, EMP_EMPLOYMENTS.BRANCH, EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID, BASIC_PAY_SCALES.DESCRIPTION AS BPS, POSTS.DESCRIPTION AS POST, ";
            query += "BRANCHES.DESCRIPTION AS BRANCH_NAME ";
            query += "FROM            OTHER_DUTY_TYPES INNER JOIN  ";
            query += "EMP_OTHER_DUTIES ON OTHER_DUTY_TYPES.OTHER_DUTY_TYPE_ID = EMP_OTHER_DUTIES.OTHER_DUTY_TYPE_ID INNER JOIN  ";
            query += "SYSTEM_USERS ON EMP_OTHER_DUTIES.SYSTEM_USERS_ID = SYSTEM_USERS.SYSTEM_USERS_ID INNER JOIN ";
            query += "EMP_EMPLOYMENTS ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_EMPLOYMENTS.SYSTEM_USERS_ID INNER JOIN ";
            query += "BASIC_PAY_SCALES ON EMP_OTHER_DUTIES.BPS_ID = BASIC_PAY_SCALES.BASIC_PAY_SCALES_ID INNER JOIN ";
            query += "BRANCHES ON EMP_EMPLOYMENTS.BRANCH = BRANCHES.BRANCHES_ID AND EMP_EMPLOYMENTS.BRANCH = BRANCHES.BRANCHES_ID AND EMP_EMPLOYMENTS.BRANCH = BRANCHES.BRANCHES_ID INNER JOIN ";
            query += "POSTS ON EMP_EMPLOYMENTS.POST_HELD = POSTS.POSTS_ID ";
            query += " ORDER BY DUTY_YEAR DESC";
            List<Rpt_OtherDuties> EmpList = new ReportsBIZ().RptGetOtherDuties(query);
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

            DutyTypeDDL.Items.Add(new ListItem("Select", "0"));
            List<TempEntity> pt = new AdministrationBIZ().GetDutyTypes();

            foreach (TempEntity row in pt)
            {
                ListItem cy = new ListItem();
                cy.Value = row.Id.ToString();
                cy.Text = row.Description.ToString();
                DutyTypeDDL.Items.Add(cy);
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
            if (DutyTypeDDL.SelectedItem.Value != "0")
            {
                lblHeader.Text = " ( " + DutyTypeDDL.SelectedItem.Text.ToUpper() + " ) ";
            }
            else
                lblHeader.Text = " ( All Types of Duties ) ";
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
            if (DutyTypeDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " EMP_OTHER_DUTIES.other_duty_type_id=" + DutyTypeDDL.SelectedItem.Value;

            }
            if (!(String.IsNullOrEmpty(DutyYearFromTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " DUTY_YEAR>= " + DutyYearFromTxt.Text ;
            }
            if (!(String.IsNullOrEmpty(DutyYearToTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " DUTY_YEAR<= " + DutyYearToTxt.Text;
            }
            return query;

        }
        protected void Search_Click(object sender, EventArgs e)
        {

            string query = null;
            string criteria = null;
            query += " SELECT EMP_OTHER_DUTIES.EMP_OTHER_DUTY_ID, EMP_OTHER_DUTIES.SYSTEM_USERS_ID,CONCAT(ISNULL(SYSTEM_USERS.F_NAME, ' '), ' ', ISNULL(SYSTEM_USERS.M_NAME, ' '), ' ', ISNULL(SYSTEM_USERS.L_NAME, ''))  AS EMP_NAME,  EMP_OTHER_DUTIES.POST_ID, EMP_OTHER_DUTIES.BPS_ID, EMP_OTHER_DUTIES.OTHER_DUTY_TYPE_ID, ";
            query += "EMP_OTHER_DUTIES.DUTY_YEAR, EMP_OTHER_DUTIES.DETAILS, OTHER_DUTY_TYPES.OTHER_DUTY_TYPE, SYSTEM_USERS.F_NAME, SYSTEM_USERS.M_NAME, SYSTEM_USERS.L_NAME, ";
            query += "EMP_EMPLOYMENTS.POST_HELD, EMP_EMPLOYMENTS.BRANCH, EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID, BASIC_PAY_SCALES.DESCRIPTION AS BPS, POSTS.DESCRIPTION AS POST, ";
            query += "BRANCHES.DESCRIPTION AS BRANCH_NAME ";
            query += "FROM            OTHER_DUTY_TYPES INNER JOIN  ";
            query += "EMP_OTHER_DUTIES ON OTHER_DUTY_TYPES.OTHER_DUTY_TYPE_ID = EMP_OTHER_DUTIES.OTHER_DUTY_TYPE_ID INNER JOIN  ";
            query += "SYSTEM_USERS ON EMP_OTHER_DUTIES.SYSTEM_USERS_ID = SYSTEM_USERS.SYSTEM_USERS_ID INNER JOIN ";
            query += "EMP_EMPLOYMENTS ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_EMPLOYMENTS.SYSTEM_USERS_ID INNER JOIN ";
            query += "BASIC_PAY_SCALES ON EMP_OTHER_DUTIES.BPS_ID = BASIC_PAY_SCALES.BASIC_PAY_SCALES_ID INNER JOIN ";
            query += "BRANCHES ON EMP_EMPLOYMENTS.BRANCH = BRANCHES.BRANCHES_ID AND EMP_EMPLOYMENTS.BRANCH = BRANCHES.BRANCHES_ID AND EMP_EMPLOYMENTS.BRANCH = BRANCHES.BRANCHES_ID INNER JOIN ";
            query += "POSTS ON EMP_EMPLOYMENTS.POST_HELD = POSTS.POSTS_ID ";

            criteria = GetCriteria();
            if (criteria != null)
            {
                query += " WHERE SYSTEM_USERS.IS_ACTIVE=1 AND ";
                query += criteria;
            }
            query += " ORDER BY DUTY_YEAR DESC";
            List<Rpt_OtherDuties> EmpList = new ReportsBIZ().RptGetOtherDuties(query);
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
       
    }
}