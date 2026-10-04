using EstablishmentBIZ;
using EstablishmentENT;
using EstablishmentENT.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstablishmentASP.Reports
{
    public partial class Rpt_17_Deputation : System.Web.UI.Page
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
            //List<EmpSearchList> EmpList = new EmployeeHandler().GetEmployeesList();
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
            List<TempEntity> quota = new AdministrationBIZ().GetOtherEmplQuotas();
            foreach (TempEntity row in quota)
            {
                ListItem cy1 = new ListItem();
                cy1.Value = row.Id.ToString();
                cy1.Text = row.Description.ToString();
                QuotaDDL.Items.Add(cy1);
            }
            List<Post> posts = new AdministrationBIZ().GetActivePosts();
            foreach (Post row in posts)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.PostID.ToString();
                Designation.Items.Add(li);
            }
            List<CurrentStatuses> pt = new AdministrationBIZ().GetCurrentStatuses();

            foreach (CurrentStatuses row in pt)
            {
                ListItem cy = new ListItem();
                cy.Value = row.CurrentStatusId.ToString();
                cy.Text = row.CurrentStatus.ToString();
                CurrentStatusDDL.Items.Add(cy);
            }
          //  CurrentStatusDDL.SelectedValue = "9";
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
                lblHeader.Text = " ( "+EmpStatusDDL.SelectedItem.Text.ToUpper()+" ) ";
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
                query += " emp_empl_history.empl_status_id=" + EmpStatusDDL.SelectedItem.Value;

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
            if (CurrentStatusDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " emp_empl_history.current_status_id=" + CurrentStatusDDL.SelectedItem.Value;

            }
            if (QuotaDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                if(QuotaDDL.SelectedItem.Value =="100")
                    query += " emp_empl_history.other_empl_quota_id in (3,4)";
                else
                query += " emp_empl_history.other_empl_quota_id=" + QuotaDDL.SelectedItem.Value;

            }


            
             if (!(String.IsNullOrEmpty(AppointedAfterDate.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " (EMP_EMPL_HISTORY.STATUS_DATE >= CONVERT(datetime,'" + AppointedAfterDate.Text + "' , 103))";
            }
            if (!(String.IsNullOrEmpty(StartBeforeDate.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " (EMP_EMPL_HISTORY.STATUS_DATE <= CONVERT(datetime,'" + StartBeforeDate.Text + "' , 103))";
            }
            if (!(String.IsNullOrEmpty(EndingBeforeDate.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " (EMP_EMPL_HISTORY.TO_DATE >= CONVERT(datetime,'" + DateTime.Now + "' , 103) AND EMP_EMPL_HISTORY.TO_DATE <=CONVERT(datetime, '" + EndingBeforeDate.Text + "', 103) AND (SYSTEM_USERS.IS_EMPLOYEE = 1))";
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
            query += " SELECT SYSTEM_USERS.SYSTEM_USERS_ID, SYSTEM_USERS.F_NAME, EMP_EMPLOYMENTS.File_No, SYSTEM_USERS.M_NAME, SYSTEM_USERS.L_NAME, SYSTEM_USERS.DOB, DATEDIFF(yy,system_users.dob,GetDate()) as age, SYSTEM_USERS.PERM_ADDRESS, SYSTEM_USERS.LOCAL_ADDRESS,SYSTEM_USERS.EMAIL, ";
            query += " EMP_EMPLOYMENTS.POST_HELD, EMP_EMPLOYMENTS.BRANCH, EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID, EMP_EMPL_HISTORY.EMPL_STATUS_ID,EMP_EMPL_HISTORY.STATUS_DATE,EMP_EMPL_HISTORY.TO_DATE, EMP_EMPL_HISTORY.CURRENT_STATUS_ID, ";
            query += "  EMP_EMPL_STATUS.EMPL_STATUS,EMP_EMPL_HISTORY.REMARKS, BRANCHES.DESCRIPTION AS EMP_BRANCH,POSTS.DESCRIPTION AS POST, BASIC_PAY_SCALES.DESCRIPTION AS BPS, (SELECT MAX(EMP_EMPL_EXTENSIONS.EXTENDED_TO) FROM EMP_EMPL_EXTENSIONS WHERE EMPL_HISTORY_ID=EMP_EMPL_HISTORY.EMP_EMPLOYMENT_HIST_ID) AS EXTENDED_TO";
            query += ", EMP_CURRENT_STATUS.CURRENT_STATUS, EMP_EMPLOYMENTS.CURRENT_STATUS AS EMPL_CURRENT_STATUS_ID, EMP_EMPL_HISTORY.CURRENT_STATUS_DATE";
            query += " FROM SYSTEM_USERS INNER JOIN ";
            query += "  EMP_EMPLOYMENTS ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_EMPLOYMENTS.SYSTEM_USERS_ID INNER JOIN ";
            query += "  BRANCHES ON EMP_EMPLOYMENTS.BRANCH=BRANCHES.BRANCHES_ID INNER JOIN ";
            query += "  EMP_EMPL_HISTORY ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_EMPL_HISTORY.SYSTEM_USERS_ID INNER JOIN ";
            query += "  EMP_EMPL_STATUS ON EMP_EMPL_HISTORY.EMPL_STATUS_ID = EMP_EMPL_STATUS.EMPL_STATUS_ID INNER JOIN ";
            query += "  BASIC_PAY_SCALES ON EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID = BASIC_PAY_SCALES.BASIC_PAY_SCALES_ID INNER JOIN ";
            query += "  POSTS ON EMP_EMPLOYMENTS.POST_HELD = POSTS.POSTS_ID INNER JOIN ";
           // query += "  OTHER_EMPL_QUOTAS ON EMP_EMPL_HISTORY.OTHER_EMPL_QUOTA_ID = OTHER_EMPL_QUOTAS.OTHER_EMPL_QUOTA_ID INNER JOIN ";
            query += "  EMP_CURRENT_STATUS ON EMP_EMPL_HISTORY.CURRENT_STATUS_ID = EMP_CURRENT_STATUS.CURRENT_STATUS_ID AND EMP_EMPL_HISTORY.CURRENT_STATUS_ID = EMP_CURRENT_STATUS.CURRENT_STATUS_ID "; 
            criteria = GetCriteria();
            if (criteria != null)
            {
                //query += " WHERE SYSTEM_USERS.IS_ACTIVE=1 AND ";
                query += " WHERE " + criteria  ;
            }
            query += " ORDER BY EMP_EMPL_HISTORY.STATUS_DATE";
            List<ReportEntity> EmpList = new ReportsBIZ().Get_17_Deputation(query);
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