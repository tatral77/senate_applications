using EstablishmentBIZ;
using EstablishmentENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstablishmentASP.Reports
{
    public partial class Rpt_EmployeesBranch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              //  bindListView();
                bindFields();

            }
        }
        private void bindListView()
        {
            List<EmpSearchList> EmpList = new EmployeeHandler().GetEmployeesList();
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
            List<TempEntity> AppModes = new AdministrationBIZ().GetAppointmenModes();
            AppointmentModeDDL.Items.Add(new ListItem("Select", "0"));
            foreach (TempEntity row in AppModes)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.Id.ToString();
                AppointmentModeDDL.Items.Add(li);
            }
          
            List<Post> designations = new AdministrationBIZ().GetActivePosts();
            foreach (Post des in designations)
            {
                ListItem li = new ListItem();
                li.Text = des.Description;
                li.Value = des.PostID.ToString();
                DesignationLb.Items.Add(li);
            }
            List<EmpStatus> ps = new AdministrationBIZ().GetEmpStatusList();
            foreach (EmpStatus row in ps)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.EmpStatusId.ToString();
                EmpStatusDDL.Items.Add(li);
            }
            // EmpStatusDDL.SelectedValue = "1";
            List<CurrentStatuses> pt = new AdministrationBIZ().GetCurrentStatuses();

            foreach (CurrentStatuses row in pt)
            {
                ListItem cy = new ListItem();
                cy.Value = row.CurrentStatusId.ToString();
                cy.Text = row.CurrentStatus.ToString();
                CurrentStatusDDL.Items.Add(cy);
            }
            // CurrentStatusDDL.SelectedValue = "9";
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
        protected string GetCriteria()
        {
            CriteriaLbl.Text = "";
            string query = "";
            if (!(String.IsNullOrEmpty(FileNoTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " emp_employments.file_no like '" + FileNoTxt.Text + "%'";
                CriteriaLbl.Text += ",<b> File No Contains:</b>" + FileNoTxt.Text;


            }
            if (!(String.IsNullOrEmpty(EmpName.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " system_users.f_name like '%" + EmpName.Text + "%'";
                CriteriaLbl.Text += ",<b>Employee Name contains:</b>" + EmpName.Text;

            }
            if (IsActiveCB.SelectedItem.Value != "select")
            {
                if (query != "")
                    query += " AND ";
                query += " system_users.is_active=" + IsActiveCB.SelectedItem.Value;
                CriteriaLbl.Text += ",<b> Active:</b>" + IsActiveCB.SelectedItem.Text;

            }
            if (!(String.IsNullOrEmpty(AgeFrom.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " DATEDIFF(yy,system_users.dob,GetDate())>=" + AgeFrom.Text;
                CriteriaLbl.Text += ",<b> Age from:</b>" + AgeFrom.Text;
            }
            if (!(String.IsNullOrEmpty(AgeTo.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " DATEDIFF(yy,system_users.dob,GetDate())<=" + AgeTo.Text;
                CriteriaLbl.Text += ",<b> Age to:</b>" + AgeTo.Text;
            }
            if (!(String.IsNullOrEmpty(GExpFrom.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " DATEDIFF(yy,emp_employments.GOVT_SERVICE_START_DATE,GetDate())>=" + GExpFrom.Text;
                CriteriaLbl.Text += ", <b>Govt. Job Experience From:</b>" + GExpFrom.Text + " Years ";
            }
            if (!(String.IsNullOrEmpty(GExpTo.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " DATEDIFF(yy,emp_employments.GOVT_SERVICE_START_DATE,GetDate())<=" + GExpTo.Text;
                CriteriaLbl.Text += ", <b>Govt. Job Experience To:</b>" + GExpTo.Text + " Years ";
            }


            if (!(String.IsNullOrEmpty(SExpFrom.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " DATEDIFF(yy,emp_employments.HOUSE_SERVICE_START_DATE,GetDate())>=" + SExpFrom.Text;
                CriteriaLbl.Text += ", <b>Senate Job Experience From:</b>" + SExpFrom.Text + " Years ";
            }
            if (!(String.IsNullOrEmpty(SExpTo.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " DATEDIFF(yy,emp_employments.HOUSE_SERVICE_START_DATE,GetDate())<=" + SExpTo.Text;
                CriteriaLbl.Text += ", <b>Senate Job Experience To:</b>" + SExpTo.Text + " Years ";
            }
            if (Gender.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " system_users.gender=" + Gender.SelectedItem.Value;
                CriteriaLbl.Text += ",<b> Gender:</b>" + Gender.SelectedItem.Text;

            }

            if (AppointmentModeDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " emp_employments.APPOINTMENT_MODE_ID>=" + AppointmentModeDDL.SelectedItem.Value;
                //   CriteriaLbl.Text += ",<b> Appointment Mode:</b>" + AppointmentModeDDL.SelectedItem.Text;

            }
            if (BPSFrom.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " emp_employments.BASIC_PAY_SCALES_ID>=" + BPSFrom.SelectedItem.Value;
                CriteriaLbl.Text += ",<b> BPS from:</b>" + BPSFrom.SelectedItem.Text;

            }
            if (BPSTo.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " emp_employments.BASIC_PAY_SCALES_ID<=" + BPSTo.SelectedItem.Value;
                CriteriaLbl.Text += ",<b> BPS to:</b>" + BPSTo.SelectedItem.Text;

            }
            if (EmpStatusDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " emp_employments.emp_status_id=" + EmpStatusDDL.SelectedItem.Value;
                CriteriaLbl.Text += ", <b>Employee Status:</b>" + EmpStatusDDL.SelectedItem.Text;

            }
            if (Province.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " system_users.perm_province=" + Province.SelectedItem.Value;
                CriteriaLbl.Text += ",<b> Province:</b>" + Province.SelectedItem.Text;
            }
            string posts = GetSelectedDesignations();
            if (!String.IsNullOrEmpty(posts))
            {
                if (query != "")
                    query += " AND ";
                query += "emp_employments.post_held In (" + posts + ")";
              //  CriteriaLbl.Text += ", <b>Post Held:</b>" + Designation.SelectedItem.Text;

            }
            if (Branch.SelectedItem.Value != "0")
            {
                int BranchId = Convert.ToInt32(Branch.SelectedItem.Value);
                if (query != "")
                    query += " AND ";
                query += "(emp_employments.branch=" + Branch.SelectedItem.Value + " OR ";
                query += " emp_employments.additional_branches like '%-" + BranchId + "-%')";
                CriteriaLbl.Text += ",<b> Branch:</b>" + Branch.SelectedItem.Text;

            }
            if (EmpPoolDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " emp_employments.employee_pools_id=" + EmpPoolDDL.SelectedItem.Value;
                CriteriaLbl.Text += ", <b>Employee Pool:</b>" + EmpPoolDDL.SelectedItem.Text;

            }
            if (NotEmpInSen.Checked == true)
            {
                if (query != "")
                    query += " AND ";
                query += " emp_employments.GOVT_SERVICE_START_DATE<>emp_employments.HOUSE_SERVICE_START_DATE ";
            }
            if (CurrentStatusDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " emp_employments.current_status=" + CurrentStatusDDL.SelectedItem.Value;
                CriteriaLbl.Text += ", <b>Current Status:</b>" + CurrentStatusDDL.SelectedItem.Text;

            }
            return query;

        }
        //protected void Search_Click(object sender, EventArgs e)
        //{
        //    string query = null;
        //    string criteria = null;
        //    query += " SELECT SYSTEM_USERS.SYSTEM_USERS_ID, SYSTEM_USERS.F_NAME, EMP_EMPLOYMENTS.File_No, SYSTEM_USERS.M_NAME, SYSTEM_USERS.L_NAME, SYSTEM_USERS.DOB, DATEDIFF(yy,system_users.dob,GetDate()) as age, SYSTEM_USERS.PERM_ADDRESS, SYSTEM_USERS.LOCAL_ADDRESS,SYSTEM_USERS.EMAIL, ";
        //    query += " EMP_EMPLOYMENTS.POST_HELD, EMP_EMPLOYMENTS.BRANCH, EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID, EMP_EMPL_HISTORY.EMPL_STATUS_ID, EMP_EMPL_HISTORY.CURRENT_STATUS_ID, ";
        //    query += "  EMP_EMPL_STATUS.EMPL_STATUS, POSTS.DESCRIPTION AS POST, BASIC_PAY_SCALES.DESCRIPTION AS BPS ";
        //    query += " FROM SYSTEM_USERS INNER JOIN ";
        //    query += "  EMP_EMPLOYMENTS ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_EMPLOYMENTS.SYSTEM_USERS_ID INNER JOIN ";
        //    query += "  EMP_EMPL_HISTORY ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_EMPL_HISTORY.SYSTEM_USERS_ID INNER JOIN ";
        //    query += "  EMP_EMPL_STATUS ON EMP_EMPL_HISTORY.EMPL_STATUS_ID = EMP_EMPL_STATUS.EMPL_STATUS_ID INNER JOIN ";
        //    query += "  BASIC_PAY_SCALES ON EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID = BASIC_PAY_SCALES.BASIC_PAY_SCALES_ID INNER JOIN ";
        //    query += "  POSTS ON EMP_EMPLOYMENTS.POST_HELD = POSTS.POSTS_ID ";
        //    criteria = GetCriteria();
        //    if (criteria != null)
        //    {
        //        query += " WHERE SYSTEM_USERS.IS_ACTIVE=1 AND ";
        //        query += criteria;
        //    }
        //    query += " ORDER BY SYSTEM_USERS.DOB";
        //    List<EmpSearchList> EmpList = new EmployeeHandler().SearchEmployee(query);
        //    EmpListView.DataSource = EmpList;
        //    EmpListView.DataBind();
        //}
        protected void Search_Click(object sender, EventArgs e)
        {
            List<EmpSearchList> EmpList = null;
            if (ForceCB.Checked == false)
            {
                CriteriaLbl.Text = "";
                string query = null;
                query = "SELECT SYSTEM_USERS.SYSTEM_USERS_ID, DATEDIFF(yy, SYSTEM_USERS.DOB, GETDATE()) AS age, SYSTEM_USERS.F_NAME, SYSTEM_USERS.M_NAME, SYSTEM_USERS.L_NAME, SYSTEM_USERS.PERM_ADDRESS, ";
                query += " SYSTEM_USERS.LOCAL_ADDRESS, SYSTEM_USERS.EMAIL, POSTS.DESCRIPTION AS post, BASIC_PAY_SCALES.DESCRIPTION AS bps, EMP_STATUS.DESCRIPTION AS empl_status, EMP_EMPLOYMENTS.FILE_NO, ";
                query += " EMP_EMPLOYMENTS.PREVIOUS_LEAVE_CREDIT, EMP_EMPLOYMENTS.GOVT_SERVICE_START_DATE, EMP_EMPLOYMENTS.HOUSE_SERVICE_START_DATE, EMP_EMPLOYMENTS.PERSONAL_NO, ";
                query += " SYSTEM_USERS.ENTEREDBY, SYSTEM_USERS.ENTEREDON, SYSTEM_USERS.RECHECKEDBY, BRANCHES.DESCRIPTION AS BRANCH ";
                query += " FROM            EMP_EMPLOYMENTS INNER JOIN ";
                query += " SYSTEM_USERS ON EMP_EMPLOYMENTS.SYSTEM_USERS_ID = SYSTEM_USERS.SYSTEM_USERS_ID INNER JOIN ";
                query += " POSTS ON EMP_EMPLOYMENTS.POST_HELD = POSTS.POSTS_ID INNER JOIN ";
                query += " EMP_STATUS ON EMP_EMPLOYMENTS.EMP_STATUS_ID = EMP_STATUS.EMP_STATUS_ID INNER JOIN ";
                query += " BRANCHES ON EMP_EMPLOYMENTS.BRANCH = BRANCHES.BRANCHES_ID AND EMP_EMPLOYMENTS.BRANCH = BRANCHES.BRANCHES_ID AND EMP_EMPLOYMENTS.BRANCH = BRANCHES.BRANCHES_ID INNER JOIN ";
                query += " BASIC_PAY_SCALES ON EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID = BASIC_PAY_SCALES.BASIC_PAY_SCALES_ID WHERE ";

                query += GetCriteria();

                query += " order by EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID DESC ,EMP_EMPLOYMENTS.POST_HELD ";
                EmpList = new ReportsBIZ().EmployyesBranch(query);
                EmpListView.DataSource = EmpList;
                EmpListView.DataBind();
            }
            else
            {
                if (!String.IsNullOrEmpty(EmpName.Text))
                {
                    string forcequery = "SELECT system_users.system_users_id,DATEDIFF(yy,system_users.dob,GetDate()) as age,system_users.f_name,system_users.m_name,system_users.l_name,system_users.perm_address,system_users.local_address from SYSTEM_USERS where (F_NAME like '%" + EmpName.Text + "%' OR M_NAME LIKE '%" + EmpName.Text + "%' OR L_NAME LIKE '%" + EmpName.Text + "%') AND IS_EMPLOYEE = 1";
                    EmpList = new EmployeeHandler().ForceSearchEmployee(forcequery);
                    EmpListView.DataSource = EmpList;
                    EmpListView.DataBind();
                }
                else
                {
                    EmpListView.DataSource = null;
                    EmpListView.DataBind();
                }
            }

        }
        protected void ClearSearch_Click(object sender, EventArgs e)
        {
            bindListView();
        }
        protected string GetSelectedDesignations()
        {
            string values=String.Empty;
            foreach (ListItem listItem in DesignationLb.Items)
            {
                if (listItem.Selected == true)
                {
                    values += listItem.Value.ToString();
                    values += ",";
                }
            }
            values = values.TrimEnd(',');
            return values;
        }
    }
}