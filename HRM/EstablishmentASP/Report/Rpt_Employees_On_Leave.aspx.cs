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
    public partial class Rpt_Employees_On_Leave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindListView();
                bindFields();

            }
        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }
        private void bindListView()
        {
            string query = null;
            string CurrentDate = DateTime.Now.ToShortDateString();
            query = "SELECT DISTINCT EMP_LEAVES.EMP_LEAVE_ID, EMP_LEAVES.SYSTEM_USERS_ID, EMP_LEAVES.EMP_LEAVE_TYPES_ID, EMP_LEAVES.EMP_LEAVE_SUBTYPE_ID, EMP_LEAVES.EX_PAKISTAN, EMP_LEAVES.START_DATE, ";
            query += " EMP_LEAVES.IS_EXTENSION, EMP_LEAVES.END_DATE, EMP_LEAVES.NO_OF_DAYS, EMP_LEAVES.JOINING_DATE, EMP_LEAVES.REMARKS, EMP_LEAVE_TYPES.DESCRIPTION AS LEAVE_TYPE, ";
            query += " EMP_LEAVE_SUBTYPE.EMP_LEAVE_SUBTYPE, SYSTEM_USERS.F_NAME, POSTS.DESCRIPTION AS POST, BASIC_PAY_SCALES.DESCRIPTION AS BPS, EMP_LEAVE_TYPES.EMP_LEAVES_TYPE_ID";
            query += " FROM SYSTEM_USERS INNER JOIN ";
            query += " EMP_EMPLOYMENTS ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_EMPLOYMENTS.SYSTEM_USERS_ID INNER JOIN";
            query += " EMP_LEAVES ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_LEAVES.SYSTEM_USERS_ID INNER JOIN";
            query += " EMP_LEAVE_SUBTYPE ON EMP_LEAVES.EMP_LEAVE_SUBTYPE_ID = EMP_LEAVE_SUBTYPE.EMP_LEAVE_SUBTYPE_ID INNER JOIN";
            query += " POSTS ON EMP_EMPLOYMENTS.POST_HELD = POSTS.POSTS_ID INNER JOIN ";
            query += " BASIC_PAY_SCALES ON EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID = BASIC_PAY_SCALES.BASIC_PAY_SCALES_ID INNER JOIN ";
            query += " EMP_LEAVE_TYPES ON EMP_LEAVES.EMP_LEAVE_TYPES_ID = EMP_LEAVE_TYPES.EMP_LEAVES_TYPE_ID ";
            query += " WHERE (EMP_LEAVES.END_DATE >= CONVERT(DATETIME, '" + CurrentDate + "', 104))";
            query += " ORDER BY EMP_LEAVES.END_DATE";
            List<RptEmployeesOnLeave> EmpList = new ReportsBIZ().GetEmployeesOnLeave(query);
            EmpListView.DataSource = EmpList;
            EmpListView.DataBind();

        }
        private void bindFields()
        {
            DateToTxt.Text = DateTime.Now.ToShortDateString();
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
            List<Post> posts = new AdministrationBIZ().GetActivePosts();
            foreach (Post row in posts)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.PostID.ToString();
                Designation.Items.Add(li);
            }
            List<EmpStatus> ps = new AdministrationBIZ().GetEmpStatusList();
            foreach (EmpStatus row in ps)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.EmpStatusId.ToString();
                EmpStatusDDL.Items.Add(li);
            }
          //  EmpStatusDDL.SelectedValue = "1";
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
          
         
                List<LeaveType> LeaveTypes = new AdministrationBIZ().GetLeaveTypes();
            LeaveTypeDDL.Items.Add(new ListItem("Select", "0"));
            foreach (LeaveType row in LeaveTypes)
                {
                    ListItem ty = new ListItem();
                    ty.Value = row.LeaveTypeId.ToString();
                    ty.Text = row.Description.ToString();
                    LeaveTypeDDL.Items.Add(ty);
                }

            
          
            List<TempEntity> LeaveSubTypes = new AdministrationBIZ().GetLeaveSubTypes();
            LeaveSubTypeDDL.Items.Add(new ListItem("Select", "0"));
            foreach (TempEntity row in LeaveSubTypes)
                {
                    ListItem ty = new ListItem();
                    ty.Value = row.Id.ToString();
                    ty.Text = row.Description.ToString();
                    LeaveSubTypeDDL.Items.Add(ty);
                }

            

        }
        protected string GetCriteria()
        {
            string query = "";
            if (!(String.IsNullOrEmpty(FileNoTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " emp_employments.file_no like '" + FileNoTxt.Text + "%'";
                CriteriaLbl.Text += ", <b>File Number:</b>" + FileNoTxt.Text;


            }
            if (!(String.IsNullOrEmpty(EmpName.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " system_users.f_name like '%" + EmpName.Text + "%'";
                CriteriaLbl.Text += ", <b>Name Contains:</b>" + EmpName.Text;

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
                CriteriaLbl.Text += ", <b>Age From:</b>" + AgeFrom.Text;
            }
            if (!(String.IsNullOrEmpty(AgeTo.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " DATEDIFF(yy,system_users.dob,GetDate())<=" + AgeTo.Text;
                CriteriaLbl.Text += ", <b>Age To:</b>" + AgeTo.Text;
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
                CriteriaLbl.Text += ",<b> BPS from:</b>" + BPSTo.SelectedItem.Text;

            }
            if (EmpStatusDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " emp_empl_history.empl_status_id=" + EmpStatusDDL.SelectedItem.Value;
                CriteriaLbl.Text += ", <b>Employee Status:</b>" + EmpStatusDDL.SelectedItem.Text;

            }
            if (Province.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " system_users.perm_province=" + Province.SelectedItem.Value;
                CriteriaLbl.Text += ",<b> Province:</b>" + Province.SelectedItem.Text;

            }
            if (Designation.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += "emp_employments.post_held=" + Designation.SelectedItem.Value;
                CriteriaLbl.Text += ", <b>Post Held:</b>" + Designation.SelectedItem.Text;

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
            if (CurrentStatusDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " emp_empl_history.current_status_id=" + CurrentStatusDDL.SelectedItem.Value;
                CriteriaLbl.Text += ", <b>Current Status:</b>" + CurrentStatusDDL.SelectedItem.Text;

            }


            ////////////////////////////////////////////////////////////////////////////////////
            if (LeaveTypeDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " EMP_LEAVES.EMP_LEAVE_TYPES_ID=" + LeaveTypeDDL.SelectedItem.Value;
                CriteriaLbl.Text += ", <b>Leave Type:</b>" + LeaveTypeDDL.SelectedItem.Text;

            }
            if (LeaveSubTypeDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " EMP_LEAVES.EMP_LEAVE_SUBTYPE_ID=" + LeaveSubTypeDDL.SelectedItem.Value;
                CriteriaLbl.Text += ", <b>Leave Sub Type:</b>" + LeaveSubTypeDDL.SelectedItem.Text;

            }
            if (!(String.IsNullOrEmpty(DateFromTxt.Text)) && !(String.IsNullOrEmpty(DateFromTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += "(EMP_LEAVES.START_DATE >= CONVERT(DATETIME, '" + DateFromTxt.Text + "', 104))";
                CriteriaLbl.Text += ", <b>Date From:</b>" + DateFromTxt.Text;
            }
            if (!(String.IsNullOrEmpty(DateToTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += "(EMP_LEAVES.END_DATE >= CONVERT(DATETIME, '" + DateToTxt.Text + "', 104))";
                CriteriaLbl.Text += ", <b>On Date:</b>" + DateToTxt.Text;

            }
            if (isExPakistan.Checked==true)
            {
                if (query != "")
                    query += " AND ";
                query += "(EMP_LEAVES.EX_PAKISTAN=1)";
                CriteriaLbl.Text += ", <b>Ex-Pakistan:</b>";

            }

            //if (!(String.IsNullOrEmpty(DateToTxt.Text)))
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += "(EMP_LEAVES.START_DATE <= CONVERT(DATETIME, '" + DateToTxt.Text + "', 104)) AND (EMP_LEAVES.END_DATE >= CONVERT(DATETIME, '" + DateToTxt.Text + "', 104))";
            //    CriteriaLbl.Text += ", <b>On Date:</b>" + DateToTxt.Text;

            //}
            query += " AND (SYSTEM_USERS.IS_EMPLOYEE = 1)";

            return query;

        }
      
        protected void Search_Click(object sender, EventArgs e)
        {
            CriteriaLbl.Text = "";
            string query = null;
            query = "SELECT DISTINCT EMP_LEAVES.EMP_LEAVE_ID, EMP_LEAVES.SYSTEM_USERS_ID, EMP_LEAVES.EMP_LEAVE_TYPES_ID, EMP_LEAVES.EMP_LEAVE_SUBTYPE_ID, EMP_LEAVES.EX_PAKISTAN, EMP_LEAVES.START_DATE, ";
            query += " EMP_LEAVES.IS_EXTENSION, EMP_LEAVES.END_DATE, EMP_LEAVES.NO_OF_DAYS, EMP_LEAVES.JOINING_DATE, EMP_LEAVES.REMARKS, EMP_LEAVE_TYPES.DESCRIPTION AS LEAVE_TYPE, ";
            query += " EMP_LEAVE_SUBTYPE.EMP_LEAVE_SUBTYPE, SYSTEM_USERS.F_NAME, POSTS.DESCRIPTION AS POST, BASIC_PAY_SCALES.DESCRIPTION AS BPS, EMP_LEAVE_TYPES.EMP_LEAVES_TYPE_ID";
            query += " FROM SYSTEM_USERS INNER JOIN ";
            query += " EMP_EMPLOYMENTS ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_EMPLOYMENTS.SYSTEM_USERS_ID INNER JOIN";
            query += " EMP_LEAVES ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_LEAVES.SYSTEM_USERS_ID INNER JOIN";
            query += " EMP_LEAVE_SUBTYPE ON EMP_LEAVES.EMP_LEAVE_SUBTYPE_ID = EMP_LEAVE_SUBTYPE.EMP_LEAVE_SUBTYPE_ID INNER JOIN";
            query += " POSTS ON EMP_EMPLOYMENTS.POST_HELD = POSTS.POSTS_ID INNER JOIN ";
            query += " BASIC_PAY_SCALES ON EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID = BASIC_PAY_SCALES.BASIC_PAY_SCALES_ID INNER JOIN ";
            query += " EMP_LEAVE_TYPES ON EMP_LEAVES.EMP_LEAVE_TYPES_ID = EMP_LEAVE_TYPES.EMP_LEAVES_TYPE_ID ";
            string Criteria = GetCriteria();
            if (!(String.IsNullOrEmpty(Criteria)))
                query += " WHERE "+ Criteria;
             query+= " ORDER BY EMP_LEAVES.START_DATE";
            List<RptEmployeesOnLeave> EmpList = new ReportsBIZ().GetEmployeesOnLeave(query);
            EmpListView.DataSource = EmpList;
            EmpListView.DataBind();
        }
        protected void ClearSearch_Click(object sender, EventArgs e)
        {
            bindListView();
        }
    }
}