using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EstablishmentBIZ;
using EstablishmentENT;
namespace EstablishmentASP
{
    public partial class LeaveEncashmentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                // bindListView();
                bindFields();
                if (!Page.IsPostBack)
                {
                    int currentyear = DateTime.Now.Year;
                    for (int i = 2017; i <= currentyear; i++)
                    {
                        ListItem li = new ListItem(i.ToString(), i.ToString());
                        YearsDDL.Items.Add(li);

                    }
                }
            }
        }
        private void bindListView()
        {
            List<EmpSearchList> EmpList = new EmployeeHandler().GetEmployeesList();
            BindLeaveDetails(EmpList);
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
                EmpStatusLb.Items.Add(li);

            }
            // EmpStatusDDL.SelectedValue = "1";
            List<CurrentStatuses> pt = new AdministrationBIZ().GetCurrentStatuses();
            foreach (CurrentStatuses row in pt)
            {
                ListItem cy = new ListItem();
                cy.Value = row.CurrentStatusId.ToString();
                cy.Text = row.CurrentStatus.ToString();
                CurrentStatusLb.Items.Add(cy);
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
            int year = (YearsDDL.SelectedValue == "0") ? DateTime.Now.Year : Convert.ToInt32(YearsDDL.SelectedValue);
            CriteriaLbl.Text = "<b>Till Year:</b> " + year;
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
            string statuses = GetSelectedStatuses();
            if (!String.IsNullOrEmpty(statuses))
            {
                if (query != "")
                    query += " AND ";
                query += "emp_employments.emp_status_id In (" + statuses + ")";
                //CriteriaLbl.Text += ", <b>Employee Status:</b>" + EmpStatusDDL.SelectedItem.Text;
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
            string currentstatuses = GetSelectedCurrentStatuses();
            if (!String.IsNullOrEmpty(currentstatuses))
            {
                if (query != "")
                    query += " AND ";
                query += "emp_employments.current_status In (" + currentstatuses + ")";
                //  CriteriaLbl.Text += ", <b>Post Held:</b>" + Designation.SelectedItem.Text;

            }
            if (Branch.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " emp_employments.branch=" + Branch.SelectedItem.Value;
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

        protected void Search_Click(object sender, EventArgs e)
        {
            List<EmpSearchList> EmpList = null;
            if (ForceCB.Checked == false)
            {
                CriteriaLbl.Text = "";
                string query = null;
                query = "SELECT system_users.system_users_id,DATEDIFF(yy,system_users.dob,GetDate()) as age,system_users.f_name,system_users.m_name,system_users.l_name,system_users.perm_address,system_users.local_address,system_users.email,posts.description as post, basic_pay_scales.description as bps, emp_status.description as empl_status, emp_employments.file_no,emp_employments.Personal_no, ";
                query += " emp_employments.GOVT_SERVICE_START_DATE,emp_employments.HOUSE_SERVICE_START_DATE,emp_employments.PREVIOUS_LEAVE_CREDIT,system_users.EnteredBy,system_users.EnteredOn,system_users.RecheckedBy,system_users.ImageUrl";
                query += " FROM emp_employments, posts, system_users,basic_pay_scales, emp_status";
                query += " WHERE (system_users.system_users_id = emp_employments.system_users_id)";
                query += " AND (posts.posts_id = emp_employments.post_held)";
                query += " AND (basic_pay_scales.BASIC_PAY_SCALES_ID = emp_employments.BASIC_PAY_SCALES_ID)";
                query += " AND (emp_status.emp_status_id =emp_employments.emp_status_id)";
                string criteria = GetCriteria();
                if (!String.IsNullOrEmpty(criteria))
                {
                    query += " AND ";
                    query += criteria;
                }
                query += " order by basic_pay_scales.basic_pay_scales_id DESC,system_users.f_name";
                //List of Employees by Search Criteria
                EmpList = new EmployeeHandler().SearchEmployee(query);
                BindLeaveDetails(EmpList);
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
        protected bool GetEncashmentStatus(int EmpId)
        {
            int year = Convert.ToInt32(YearsDDL.SelectedValue);
            LeaveEnchashmentOptEnt leopt = new EmployeeHandler().GetLeaveEncashmentOpted(year, EmpId);
            int i = leopt.Year;
            if (leopt.Year != 0)
                return true;
            else
                return false;
        }
        protected string GetSelectedDesignations()
        {
            string values = String.Empty;
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
        protected string GetSelectedStatuses()
        {
            string values = String.Empty;
            foreach (ListItem listItem in EmpStatusLb.Items)
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
        protected string GetSelectedCurrentStatuses()
        {
            string values = String.Empty;
            foreach (ListItem listItem in CurrentStatusLb.Items)
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

        public void BindLeaveDetails(List<EmpSearchList> EmpList)
        {
          
            if (EmpList != null)
            {
                int SystemUsersId = 0;

                int ReportYear = (YearsDDL.SelectedValue == "0") ? DateTime.Now.Year : Convert.ToInt32(YearsDDL.SelectedValue);
                DateTime DateTo = Convert.ToDateTime("31/12/" + ReportYear);
                //Iterate through Search Record and Get All Leaves of Employee
                foreach (EmpSearchList SearchList in EmpList)
                {
                    //Get Leave Creadit from previous Employment If any.
                    int YearlyTotalBalance = SearchList.PreviousLeaveCredit;
                    SystemUsersId = SearchList.EmpId;
                    // Getting all leaves of Employee
                    List<EmployeeLeave> EmployeeAllLeaves = new EmployeeHandler().GetLeavesTillDate(SystemUsersId, DateTo);


                }   
            }

        }
     }
}