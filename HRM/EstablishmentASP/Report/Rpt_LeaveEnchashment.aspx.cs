using EstablishmentBIZ;
using EstablishmentENT;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace EstablishmentASP.Reports
{
    public partial class Rpt_LeaveEnchashment : System.Web.UI.Page
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
            List<EmpSearchList> EmpList = new EmployeeHandler().SearchEmployee(query);
            BindLeaveDetails(EmpList);
        }
        protected void ClearSearch_Click(object sender, EventArgs e)
        {
            bindListView();
        }
        public void BindLeaveDetails(List<EmpSearchList> EmpList)
        {
            int SystemUsersId = 0;
            int thisyearcredit = 0;
            if (EmpList != null)
            {
                //Iterate through Search Record and Get All Leaves of Employee
                foreach (EmpSearchList SearchList in EmpList)
                {
                    int YearlyTotalBalance = SearchList.PreviousLeaveCredit;    //Get Leave Creadit from previous Employment If any.
                    SystemUsersId = SearchList.EmpId;
                    // Getting all leaves of Employee
                    List<EmployeeLeave> EmployeeAllLeaves = new EmployeeHandler().GetAllLeaves(SystemUsersId);
                    // List to store Yearly Leave Details like Earned Leave, Creadit of Year, Leave Deducted, Balance Till Now etc
                    List<EmpLeaveDetails> YearlyLeaveDetails = null;
                    List<EmpLeaveDetails> CalculatedYearlyLeaves = null;
                    if (EmployeeAllLeaves != null)
                    {
                        //SeparLeaves availed /// 2016 5 Leaves, 2016 5 Leaves, 2017 7 Leaves etc
                        YearlyLeaveDetails = GetYearlyLeaveDetails(EmployeeAllLeaves);
                        //Combined Year, Availed Leave/// 2016 10 Leaves, 2017 12 Leaves etc
                        CalculatedYearlyLeaves = GetCalculatedLeave(YearlyLeaveDetails); 
                    }
                    // Leave credit calculation from Govt Service Date or Senate Service Date
                    DateTime CreditStartDate;
                    if (Convert.ToInt32(ServiceDDL.SelectedItem.Value) == 0)
                        CreditStartDate = SearchList.GovtServiceStartDate;
                    else
                        CreditStartDate = SearchList.HouseServiceStartDate;
                    //////////////////////////////////////////////////////////////////////////////
                    // Get Earned Leave, Year Credit, Availed Leave, Leave Deducted, Leave Balance
                    List<EmpLeaveDetails> EmpLeaveList = DisplaySummery(CalculatedYearlyLeaves, CreditStartDate, SearchList.EmpId, SearchList.PreviousLeaveCredit);
                    if ((EmpLeaveList.Count) - 1 > 0)
                    {
                        SearchList.CurrentYearCredit = Convert.ToInt32(EmpLeaveList[EmpLeaveList.Count - 1].LeaveBalance);                     
                    }
                    if (EmpLeaveList != null)
                    {
                        foreach (EmpLeaveDetails temp in EmpLeaveList)
                        {
                            SearchList.TotalLeaveCredit += temp.LeaveBalance;

                        }
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
            if (EmpList != null)
            {
                foreach (EmpSearchList a in EmpList)
                {
                    if (a.CurrentYearCredit >= 1)
                    {
                        if (a.TotalLeaveCredit <= 365)
                            a.CreditAvailableForEncashment = 0;
                        else
                        {
                            int leaveAvailable = a.TotalLeaveCredit - 365;
                            if (leaveAvailable < a.CurrentYearCredit)
                                a.CreditAvailableForEncashment = leaveAvailable;
                            else
                                a.CreditAvailableForEncashment = a.CurrentYearCredit;
                        }
                    }
                }
            }
            EmpListView.DataSource = EmpList;
            EmpListView.DataBind();
        }
        public List<EmpLeaveDetails> DisplaySummery(List<EmpLeaveDetails> CalculatedYearlyLeaves, DateTime ServiceStartDate, int EmpId, int LeaveOnCredit)
        {
            //string dateto = DateToTxt.Text;
            DateTime DateTo = Convert.ToDateTime("31/12/2018");
            int SenServiceYear = ServiceStartDate.Year;
            int CurrentYear = DateTo.Year;
            int CurrentMonth = DateTo.Month;
            List<EmpLeaveDetails> YearEarnedLeaves = new List<EmpLeaveDetails>();
            for (int i = SenServiceYear; i <= CurrentYear; i++)
            {
                EmpLeaveDetails YearEarnedLeave = new EmpLeaveDetails();
                YearEarnedLeave.ServiceYear = i;
                ///////////////////////////////////   EARNED LEAVE IN THE YEAR ////////////////////////////////
                if (SenServiceYear != CurrentYear)
                {
                    if (i == SenServiceYear)
                        YearEarnedLeave.EarnedLeave = new DateTimeUtils().CalculateMonthsEarnedLFP(ServiceStartDate, Convert.ToDateTime("31/12/" + i));
                    else if (i == CurrentYear)
                    {
                        YearEarnedLeave.EarnedLeave = new DateTimeUtils().CalculateCurrentMonthsEarnedLFP(Convert.ToDateTime("1/1/" + i), DateTo);
                    }
                    else
                        YearEarnedLeave.EarnedLeave = 48;
                }
                else
                    YearEarnedLeave.EarnedLeave = new DateTimeUtils().CalculateMonthsEarnedLFP(ServiceStartDate, DateTo);
                    YearEarnedLeaves.Add(YearEarnedLeave);
            }
            int yearbalane = LeaveOnCredit;
            //Deduct Availed Calculated Leave from CalculatedYearlyLeaves
            List<EmpLeaveDetails> FinalBalance = new List<EmpLeaveDetails>();
            if (YearEarnedLeaves != null)
            {
                foreach (EmpLeaveDetails yearEarnedLeaves in YearEarnedLeaves)
                {
                    if (CalculatedYearlyLeaves != null)
                    {
                        foreach (EmpLeaveDetails calculatedYearlyLeaves in CalculatedYearlyLeaves)
                        {
                            if (yearEarnedLeaves.ServiceYear == calculatedYearlyLeaves.ServiceYear)
                            {
                                yearEarnedLeaves.EOL = calculatedYearlyLeaves.EOL;
                                yearEarnedLeaves.LeaveDeducted = calculatedYearlyLeaves.LeaveDeducted;
                                yearEarnedLeaves.AvailedLeave = calculatedYearlyLeaves.AvailedLeave;
                                yearEarnedLeaves.CreditOfYear = (yearEarnedLeaves.EarnedLeave - (yearEarnedLeaves.AvailedLeave + yearEarnedLeaves.LeaveDeducted));
                            }
                        }
                    }
                    yearEarnedLeaves.CreditOfYear = (yearEarnedLeaves.EarnedLeave - (yearEarnedLeaves.AvailedLeave + yearEarnedLeaves.LeaveDeducted));
                    yearbalane += yearEarnedLeaves.CreditOfYear;
                    yearEarnedLeaves.BalanceTillNow = yearbalane;
                    FinalBalance.Add(yearEarnedLeaves);
                }
            }
            List<EmpLeaveDetails> SuspensionList = CalculateSuspensionPeriod(EmpId);
            int FinalYearBalance = 0;
            foreach (EmpLeaveDetails finalBalance in FinalBalance)
            {

                foreach (EmpLeaveDetails susp in SuspensionList)
                {
                    if (susp.ServiceYear == finalBalance.ServiceYear)
                    {
                        finalBalance.LeaveDeducted = finalBalance.LeaveDeducted+ susp.LeaveDeducted;
                        finalBalance.Remarks = susp.Remarks;
                    }
                }
                finalBalance.LeaveBalance = finalBalance.EarnedLeave - (finalBalance.AvailedLeave + finalBalance.LeaveDeducted);
                FinalYearBalance += finalBalance.LeaveBalance;
                finalBalance.BalanceTillNow = FinalYearBalance;
            }
            return FinalBalance;
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

        public EmpLeaveDetails GetCreditInSameYear(DateTime StartDate, DateTime EndDate, int LeaveType, int LeaveSubType)
        {
            EmpLeaveDetails lc = new EmpLeaveDetails();
            int StartMonth = StartDate.Month;
            int StartYear = StartDate.Year;
            int StartDay = StartDate.Day;
            int EndYear = EndDate.Year;
            int EndMonth = EndDate.Month;
            int EndDay = EndDate.Day;
            int DaysInMonth = 0;
            int HalfOfMonth = 0;
            lc.ServiceYear = StartYear;
            for (int j = StartMonth; j <= EndMonth; j++)
            {
                DaysInMonth = 0;
                HalfOfMonth = 0;
                if (j == StartMonth && j == EndMonth)
                {
                    DaysInMonth = DateTime.DaysInMonth(StartYear, j);
                    HalfOfMonth = (DaysInMonth / 2) + 1;
                    int Leaves = ((EndDay - StartDay) + 1);
                    if (LeaveSubType == 1 || LeaveSubType == 2)
                        lc.AvailedLeave += Leaves;
                    else if (LeaveSubType == 3)
                        lc.EOL += Leaves;
                    if (Leaves > HalfOfMonth)
                    {
                        lc.LeaveDeducted += 4;
                    }
                }
                else if (j == StartMonth)
                {
                    DaysInMonth = DateTime.DaysInMonth(StartYear, j);
                    HalfOfMonth = (DaysInMonth / 2) + 1;
                    int Leaves = ((DaysInMonth - StartDay) + 1);
                    if (LeaveSubType == 1 || LeaveSubType == 2)
                        lc.AvailedLeave += Leaves;
                    else if (LeaveSubType == 3)
                        lc.EOL += Leaves;
                    if (Leaves > HalfOfMonth)
                    {
                        lc.LeaveDeducted += 4;
                    }
                }
                else if (j == EndMonth)
                {
                    DaysInMonth = DateTime.DaysInMonth(StartYear, j);
                    HalfOfMonth = (DaysInMonth / 2) + 1;
                    int Leaves = EndDay;
                    if (LeaveSubType == 1 || LeaveSubType == 2)
                        lc.AvailedLeave += Leaves;
                    else if (LeaveSubType == 3)
                        lc.EOL += Leaves;
                    if (Leaves > HalfOfMonth)
                    {
                        lc.LeaveDeducted += 4;
                    }
                }
                else
                {
                    if (LeaveSubType == 1 || LeaveSubType == 2)
                        lc.AvailedLeave += DateTime.DaysInMonth(StartYear, j);
                    else if (LeaveSubType == 3)
                        lc.EOL += DateTime.DaysInMonth(StartYear, j);
                    lc.LeaveDeducted += 4;
                }
            }
            if (LeaveSubType == 2)
                lc.AvailedLeave = lc.AvailedLeave / 2;
            if (LeaveType == 7)
                lc.AvailedLeave = lc.AvailedLeave - 5;
            return lc;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public List<EmpLeaveDetails> GetCreditInDifferentYears(DateTime StartDate, DateTime EndDate, int LeaveType, int LeaveSubType)
        {
            List<EmpLeaveDetails> lcs = new List<EmpLeaveDetails>();
            int StartMonth = StartDate.Month;
            int StartYear = StartDate.Year;
            int StartDay = StartDate.Day;
            int EndYear = EndDate.Year;
            int EndMonth = EndDate.Month;
            int EndDay = EndDate.Day;
            int DaysInMonth = 0;
            int HalfOfMonth = 0;
            int startmonth = 0;
            int endmonth = 0;

            for (int i = StartYear; i <= EndYear; i++)
            {
                startmonth = 1;
                endmonth = 12;
                EmpLeaveDetails lc = new EmpLeaveDetails();
                lc.ServiceYear = i;
                if (i == StartYear)
                {
                    startmonth = StartMonth;
                    endmonth = 12;
                }
                if (i == EndYear)
                {
                    startmonth = 1;
                    endmonth = EndMonth;
                }

                for (int j = startmonth; j <= endmonth; j++)
                {
                    DaysInMonth = DateTime.DaysInMonth(i, j);
                    HalfOfMonth = (DaysInMonth / 2);
                    if (j == StartMonth && i == StartYear)
                    {
                        if (LeaveSubType == 1)
                            lc.AvailedLeave += ((DaysInMonth - StartDay) + 1);
                        else if (LeaveSubType == 3)
                            lc.EOL += ((DaysInMonth - StartDay) + 1);
                        if (lc.AvailedLeave > HalfOfMonth || lc.EOL > HalfOfMonth)
                        {
                            lc.LeaveDeducted += 4;
                        }
                    }
                    else if (j == EndMonth && i == EndYear)
                    {
                        if (LeaveSubType == 1)
                            lc.AvailedLeave += EndDay;
                        else if (LeaveSubType == 3)
                            lc.EOL += EndDay;
                        if (lc.AvailedLeave > HalfOfMonth || lc.EOL > HalfOfMonth)
                        {
                            lc.LeaveDeducted += 4;
                        }
                    }
                    else
                    {
                        if (LeaveSubType == 1)
                            lc.AvailedLeave += DateTime.DaysInMonth(i, j);
                        else if (LeaveSubType == 3)
                            lc.EOL += DateTime.DaysInMonth(i, j);

                        lc.LeaveDeducted += 4;
                    }

                }
                if (LeaveSubType == 2)
                    lc.AvailedLeave = lc.AvailedLeave / 2;
                if (LeaveType == 7)
                    lc.AvailedLeave = lc.AvailedLeave - 5;
                lcs.Add(lc);
            }
            lcs.TrimExcess();
            return lcs;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        public List<EmpLeaveDetails> CalculateSuspensionPeriod(int EmpId)
        {
            List<DisciplinaryAction> da = new EmploymentBIZ().GetEmpSuspensions(EmpId);
            List<EmpLeaveDetails> YearlyLeaveDetails = new List<EmpLeaveDetails>();
            if (da != null)
            {
                foreach (DisciplinaryAction row in da)
                {
                    DateTime StartDate = row.FromDate;
                    DateTime EndDate = row.ToDate;
                    int LeaveType = 3;
                    int StartMonth = StartDate.Month;
                    int StartYear = StartDate.Year;
                    int StartDay = StartDate.Day;
                    int EndYear = EndDate.Year;
                    int EndMonth = EndDate.Month;
                    int EndDay = EndDate.Day;
                    string Remarks = "Suspended from " + StartDate.ToShortDateString() + " to " + EndDate.ToShortDateString();
                    if (StartMonth == EndMonth)
                    {
                        EmpLeaveDetails lc = GetCreditInSameYear(StartDate, EndDate, LeaveType, 3);
                        lc.Remarks = Remarks;
                        YearlyLeaveDetails.Add(lc);

                    }
                    else if (StartMonth != EndMonth && StartYear == EndYear)
                    {
                        EmpLeaveDetails lc = GetCreditInSameYear(StartDate, EndDate, LeaveType, 3);
                        lc.Remarks = Remarks;
                        YearlyLeaveDetails.Add(lc);
                    }
                    else if (StartYear != EndYear)
                    {
                        List<EmpLeaveDetails> ld = GetCreditInDifferentYears(StartDate, EndDate, LeaveType, 3);
                        foreach (EmpLeaveDetails lc in ld)
                        {
                            lc.Remarks = Remarks;
                            YearlyLeaveDetails.Add(lc);
                        }
                    }
                }
            }
            return YearlyLeaveDetails;
        }

        protected List<EmpLeaveDetails> GetYearlyLeaveDetails(List<EmployeeLeave>  EmpLeave)
        {
            List<EmpLeaveDetails> YearlyLeaveDetails = new List<EmpLeaveDetails>();
            foreach (EmployeeLeave row in EmpLeave)
            {
                DateTime StartDate = Convert.ToDateTime(row.StartDate);
                DateTime EndDate = Convert.ToDateTime(row.EndDate);
                int LeaveType = row.LeaveTypeId;
                int LeaveSubType = row.LeaveSubTypeId;
                int StartMonth = StartDate.Month;
                int StartYear = StartDate.Year;
                int StartDay = StartDate.Day;
                int EndYear = EndDate.Year;
                int EndMonth = EndDate.Month;
                int EndDay = EndDate.Day;
                if (StartMonth == EndMonth && StartYear == EndYear)
                {
                    EmpLeaveDetails lc = GetCreditInSameYear(StartDate, EndDate, LeaveType, LeaveSubType);
                    YearlyLeaveDetails.Add(lc);
                }
                else if (StartMonth != EndMonth && StartYear == EndYear)
                {
                    EmpLeaveDetails lc = GetCreditInSameYear(StartDate, EndDate, LeaveType, LeaveSubType);
                    YearlyLeaveDetails.Add(lc);
                }
                else if (StartYear != EndYear)
                {
                    List<EmpLeaveDetails> ld = GetCreditInDifferentYears(StartDate, EndDate, LeaveType, LeaveSubType);
                    foreach (EmpLeaveDetails lc in ld)
                    {
                        YearlyLeaveDetails.Add(lc);
                    }
                }
            }
            return YearlyLeaveDetails;
        }

        protected List<EmpLeaveDetails>  GetCalculatedLeave(List<EmpLeaveDetails> YearlyLeaveDetails)
        {
            int startyear = 0;
            List<EmpLeaveDetails>  Calculated = new List<EmpLeaveDetails>();
            foreach (EmpLeaveDetails row in YearlyLeaveDetails)
            {
                if (startyear != row.ServiceYear)
                {
                    EmpLeaveDetails ed = new EmpLeaveDetails();
                    startyear = row.ServiceYear;
                    ed.ServiceYear = row.ServiceYear;
                    ed.AvailedLeave = YearlyLeaveDetails.Where(item => item.ServiceYear == startyear).Sum(item => item.AvailedLeave);
                    ed.LeaveDeducted = YearlyLeaveDetails.Where(item => item.ServiceYear == startyear).Sum(item => item.LeaveDeducted);
                    ed.Remarks = row.Remarks;
                    //ed.EarnedLeave = YearlyLeaveDetails.Where(item => item.ServiceYear == startyear).Sum(item => item.EarnedLeave);
                    ed.EOL = YearlyLeaveDetails.Where(item => item.ServiceYear == startyear).Sum(item => item.EOL);
                    Calculated.Add(ed);
                }
            }
            return Calculated;
        }

    }
}