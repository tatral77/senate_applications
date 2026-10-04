using EstablishmentBIZ;
using EstablishmentENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace EstablishmentASP.Test
{

    public partial class LeaveEncashmentTest : System.Web.UI.Page
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
            //int year= (YearsDDL.SelectedValue == "0") ? DateTime.Now.Year : Convert.ToInt32(YearsDDL.SelectedValue);
            //CriteriaLbl.Text = "<b>Till Year:</b> " + year;
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
            
            string query = null;
            List<EmpSearchList> EmpList = null;
            if (ForceCB.Checked == false)
            {
                CriteriaLbl.Text = "";
               
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

            }
            else
            {
                if (!String.IsNullOrEmpty(EmpName.Text))
                {
                    query = "SELECT SYSTEM_USERS.SYSTEM_USERS_ID, DATEDIFF(yy, SYSTEM_USERS.DOB, GETDATE()) AS age, SYSTEM_USERS.F_NAME, SYSTEM_USERS.M_NAME, SYSTEM_USERS.L_NAME, SYSTEM_USERS.PERM_ADDRESS, ";
                    query += "SYSTEM_USERS.LOCAL_ADDRESS, EMP_EMPLOYMENTS.GOVT_SERVICE_START_DATE, EMP_EMPLOYMENTS.HOUSE_SERVICE_START_DATE ";
                    query += "FROM SYSTEM_USERS INNER JOIN ";
                    query += "EMP_EMPLOYMENTS ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_EMPLOYMENTS.SYSTEM_USERS_ID ";
                    query += "where (F_NAME like '%" + EmpName.Text + "%' OR M_NAME LIKE '%" + EmpName.Text + "%' OR L_NAME LIKE '%" + EmpName.Text + "%') AND IS_EMPLOYEE = 1";
                    EmpList = new EmployeeHandler().ForceSearchEmployee(query);
               //     EmpListView.DataSource = EmpList;
                   // EmpListView.DataBind();
                }
                else
                {
                    EmpListView.DataSource = null;
                    EmpListView.DataBind();
                }
            }
           BindLeaveDetails(EmpList);

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
            if (leopt.Year!=0)
                return true;
            else
                return false;
        }
      
        public void BindLeaveDetails(List<EmpSearchList> EmpList)
        {
            //GET REPORT YEAR
            int ReportYear = (YearsDDL.SelectedValue == "0") ? DateTime.Now.Year : Convert.ToInt32(YearsDDL.SelectedValue);
            CriteriaLbl.Text += ",<b>Till Year:</b> " + ReportYear;
            DateTime DateTo = Convert.ToDateTime("31/12/" + ReportYear);
            ////////////////////////////////////////////////////////////////////
            EmpLeaveDetails leaveDetails = new EmpLeaveDetails();
            List<EmpLeaveDetails> FinalLeaveDetails = new List<EmpLeaveDetails>();
            if (EmpList != null)
            {
                
                foreach (EmpSearchList SearchList in EmpList)
                {
                    //GET EMPLOYEE SERVICE START DATE 
                    DateTime CreditStartDate;
                    if (Convert.ToInt32(ServiceDDL.SelectedItem.Value) == 0)
                        CreditStartDate = SearchList.GovtServiceStartDate;
                    else
                        CreditStartDate = SearchList.HouseServiceStartDate;

                    //PREVIOUS LEAVE CREDIT IF AVAILABLE
                    int YearlyTotalBalance = SearchList.PreviousLeaveCredit;


                    int  EmpId = SearchList.EmpId; 


                    List<EmployeeLeave> EmpLeave = new EmployeeHandler().GetAllLeaves(EmpId);
                    List<EmpLeaveDetails> details = new List<EmpLeaveDetails>();
                    List<EmpLeaveDetails> Calculated = null;
                    List<EmpLeaveDetails> details2017 = new List<EmpLeaveDetails>();
                    List<EmpLeaveDetails> Calculated2017 = null;


                    if (EmpLeave != null)
                    {
                        details = new LeaveUtilites().GetLeaveDetails(EmpLeave);
                        Calculated = new LeaveUtilites().GetCalculatedLeave(details);
                    }


                    List<EmpLeaveDetails> summary = new LeaveUtilites().DisplayProfileSummery(Calculated, CreditStartDate, EmpId, YearlyTotalBalance);
                    if (summary != null)
                    {
                        leaveDetails = (from p in summary where p.ServiceYear == ReportYear select p).FirstOrDefault();
                        if (leaveDetails != null)
                        {
                            SearchList.AvailedLeave = leaveDetails.AvailedLeave;
                            SearchList.CurrentYearCredit = leaveDetails.CreditOfYear;
                            SearchList.TotalLeaveCredit = leaveDetails.BalanceTillNow;
                            if (ReportYear != 2017)
                            {
                                if (leaveDetails.BalanceTillNow < 365 || leaveDetails.CreditOfYear < 0)
                                    SearchList.CreditAvailableForEncashment = 0;
                                else if (leaveDetails.BalanceTillNow - leaveDetails.CreditOfYear < 365)
                                    SearchList.CreditAvailableForEncashment = leaveDetails.BalanceTillNow - 365;
                                else
                                    SearchList.CreditAvailableForEncashment = leaveDetails.CreditOfYear;
                            }
                            else
                            {
                                List<EmployeeLeave> LeaveIn2017 = new EmployeeHandler().GetLeavesStatusBetweenDates(EmpId, Convert.ToDateTime("01/08/2017"), Convert.ToDateTime("31/12/2017"));
                                if (LeaveIn2017 != null)
                                {
                                    DateTime startdate = Convert.ToDateTime("01/08/2017");
                                    DateTime endate = Convert.ToDateTime("31/12/2017");
                                    foreach (EmployeeLeave leavein2017 in LeaveIn2017)
                                    {
                                        if (leavein2017.StartDate <= startdate)
                                            leavein2017.StartDate = startdate;
                                        if (leavein2017.EndDate >= endate)
                                            leavein2017.EndDate = endate;
                                    }
                                    details2017 = new LeaveUtilites().GetLeaveDetails(LeaveIn2017);
                                    Calculated2017 = new LeaveUtilites().GetCalculatedLeave(details2017);
                                    int leaves = 0;
                                    foreach(EmpLeaveDetails clc2017 in Calculated2017)
                                    {
                                        leaves = leaves + (clc2017.AvailedLeave + clc2017.LeaveDeducted);
                                    }
                                    int availableforencashment = 20 - leaves;
                                    if (leaveDetails.BalanceTillNow < 365 || leaveDetails.CreditOfYear < 0)
                                        SearchList.CreditAvailableForEncashment = 0;
                                    else if (leaveDetails.BalanceTillNow - availableforencashment < 365)
                                        SearchList.CreditAvailableForEncashment = leaveDetails.BalanceTillNow - 365;
                                    else if (leaveDetails.CreditOfYear < 20)
                                        SearchList.CreditAvailableForEncashment = leaveDetails.CreditOfYear;
                                    else
                                        SearchList.CreditAvailableForEncashment = 20 - leaves;


                                }
                                else
                                {
                                    if (leaveDetails.BalanceTillNow < 365 || leaveDetails.CreditOfYear < 0)
                                        SearchList.CreditAvailableForEncashment = 0;
                                    else if (leaveDetails.BalanceTillNow - 20 < 365)
                                        SearchList.CreditAvailableForEncashment = leaveDetails.BalanceTillNow - 365;
                                    else if (leaveDetails.CreditOfYear < 20)
                                        SearchList.CreditAvailableForEncashment = leaveDetails.CreditOfYear;
                                    else
                                        SearchList.CreditAvailableForEncashment = 20;
                                }
                                if(SearchList.CreditAvailableForEncashment<0)
                                SearchList.CreditAvailableForEncashment = 0;
                            }
                        }
                        FinalLeaveDetails.Add(leaveDetails);
                        }
                    }

                }
         
            if (Convert.ToInt32(EligibleDDL.SelectedItem.Value) == 2)
            {
                if (EmpList != null)
                    EmpList.RemoveAll(f => (f.TotalLeaveCredit) >= 365);
                CriteriaLbl.Text += ", <b>Eligible:</b> No";
            }
            else if (Convert.ToInt32(EligibleDDL.SelectedItem.Value) == 1)
            {
                if (EmpList != null)
                    EmpList.RemoveAll(f => (f.TotalLeaveCredit) < 365);
                CriteriaLbl.Text += ", <b>Eligible:</b> Yes";
            }
            EmpListView.DataSource = EmpList;
            EmpListView.DataBind();
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

        protected void SaveOptionBtn_Click(object sender, EventArgs e)
        {
            int ReportYear = (YearsDDL.SelectedValue == "0") ? DateTime.Now.Year : Convert.ToInt32(YearsDDL.SelectedValue);
            if (ReportYear == 0)
            {
                string msg = "Please select Year";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + msg + "')", true);
            }
            else
            {
                // new EmployeeHandler().DeleteLeaveEncashmentOpt(ReportYear);
                foreach (ListViewItem li in EmpListView.Items)
                {
                    CheckBox cb = (CheckBox)li.FindControl("OptedCB");
                    if (cb != null)
                    {
                        HiddenField EmpId = (HiddenField)li.FindControl("idHiddenField");
                        Label EncashmentDays = (Label)li.FindControl("CreditAvailableLbl");
                        int days = Convert.ToInt32(EncashmentDays.Text);
                        int SystemUsersId = (Convert.ToInt32(EmpId.Value));
                        if (cb.Checked == true)
                        {

                            new EmployeeHandler().InsertLeaveEncashmentOpt(ReportYear, SystemUsersId, days);
                        }
                        else
                            new EmployeeHandler().DeleteLeaveEncashmentOpt(ReportYear, SystemUsersId);
                    }
                }
            }
        }

        protected void CheckAll_CheckedChanged(object sender, EventArgs e)
        {
                foreach (ListViewItem li in EmpListView.Items)
                {
                    CheckBox cb = (CheckBox)li.FindControl("OptedCB");
                    if (cb != null)
                    {
                    if (CheckAll.Checked == true)
                        cb.Checked = true;
                    else
                        cb.Checked = false;
                    }
                }
            
        }

        //protected int Get2017LeaveEncashment(int EmployeeId)
        //{
        //    List<EmployeeLeave> EmployeeLeaves = new EmployeeHandler().GetLe(EmpId);
        //}
    }
}