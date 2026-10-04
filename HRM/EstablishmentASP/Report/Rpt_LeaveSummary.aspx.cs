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
    public partial class Rpt_LeaveSummary : System.Web.UI.Page
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
            EmpStatusDDL.SelectedValue = "1";
            List<CurrentStatuses> pt = new AdministrationBIZ().GetCurrentStatuses();

            foreach (CurrentStatuses row in pt)
            {
                ListItem cy = new ListItem();
                cy.Value = row.CurrentStatusId.ToString();
                cy.Text = row.CurrentStatus.ToString();
                CurrentStatusDDL.Items.Add(cy);
            }
            CurrentStatusDDL.SelectedValue = "9";
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

            if (AppointmentModeDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " emp_employments.APPOINTMENT_MODE_ID>=" + AppointmentModeDDL.SelectedItem.Value;

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
            if (!(String.IsNullOrEmpty(DateFromTxt.Text)) && !(String.IsNullOrEmpty(DateToTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " (DATEADD(year, 60, SYSTEM_USERS.DOB) BETWEEN CONVERT(datetime,'" + DateFromTxt.Text + "' , 103) AND CONVERT(datetime, '" + DateToTxt.Text + "', 103) AND (SYSTEM_USERS.IS_EMPLOYEE = 1))";
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
        //        query += " WHERE ";
        //        query += criteria;
        //    }
        //    query += " ORDER BY SYSTEM_USERS.DOB";
        //    List<EmpSearchList> EmpList = new EmployeeHandler().SearchEmployee(query);
        //    EmpListView.DataSource = EmpList;
        //    EmpListView.DataBind();
        //}
        protected void Search_Click(object sender, EventArgs e)
        {
            string query = null;
            query = "SELECT system_users.system_users_id,DATEDIFF(yy,system_users.dob,GetDate()) as age,system_users.f_name,system_users.m_name,system_users.l_name,system_users.perm_address,system_users.local_address,system_users.email,posts.description as post, basic_pay_scales.description as bps, emp_status.description as empl_status, emp_employments.file_no, ";
            query += " emp_employments.HOUSE_SERVICE_START_DATE,emp_employments.PREVIOUS_LEAVE_CREDIT";
           query += " FROM emp_employments, posts, system_users,basic_pay_scales, emp_status";
            query += " WHERE ( (system_users.system_users_id = emp_employments.system_users_id)";
            query += " AND (posts.posts_id = emp_employments.post_held)";
            query += " AND (emp_status.emp_status_id =emp_employments.emp_status_id)";
            if (!(String.IsNullOrEmpty(FileNoTxt.Text)))
            {
                query += " AND emp_employments.file_no like '" + FileNoTxt.Text + "%'";


            }
            if (!(String.IsNullOrEmpty(PeronalNoTxt.Text)))
            {

                query += " AND emp_employments.Personal_No Like '" + PeronalNoTxt.Text + "'";

            }
            if (!(String.IsNullOrEmpty(EmpName.Text)))
            {
                query += " AND system_users.f_name like '%" + EmpName.Text + "%'";

            }
            if (IsActiveCB.SelectedItem.Value != "select")
            {
                query += " AND system_users.is_active=" + IsActiveCB.SelectedItem.Value;

            }
            if (!(String.IsNullOrEmpty(AgeFrom.Text)))
            {
                query += " AND DATEDIFF(yy,system_users.dob,GetDate())>=" + AgeFrom.Text;
            }
            if (!(String.IsNullOrEmpty(AgeTo.Text)))
            {
                query += " AND DATEDIFF(yy,system_users.dob,GetDate())<=" + AgeTo.Text;
            }
            if (!(String.IsNullOrEmpty(ExpFrom.Text)))
            {
                query += " AND DATEDIFF(yy,emp_employments.GOVT_SERVICE_START_DATE,GetDate())>=" + ExpFrom.Text;
            }
            if (!(String.IsNullOrEmpty(ExpTo.Text)))
            {
                query += " AND DATEDIFF(yy,emp_employments.GOVT_SERVICE_START_DATE,GetDate())<=" + ExpTo.Text;
            }
            if (Gender.SelectedItem.Value != "0")
            {
                query += " AND system_users.gender=" + Gender.SelectedItem.Value;

            }
            if (BPSFrom.SelectedItem.Value != "0")
            {
                query += " AND emp_employments.BASIC_PAY_SCALES_ID>=" + BPSFrom.SelectedItem.Value;

            }
            if (BPSTo.SelectedItem.Value != "0")
            {
                query += " AND emp_employments.BASIC_PAY_SCALES_ID<=" + BPSTo.SelectedItem.Value;

            }
            if (EmpStatusDDL.SelectedItem.Value != "0")
            {
                query += " AND emp_employments.emp_status_id=" + EmpStatusDDL.SelectedItem.Value;

            }
            if (CurrentStatusDDL.SelectedItem.Value != "0")
            {
                query += " AND emp_employments.current_status=" + CurrentStatusDDL.SelectedItem.Value;

            }
            if (Province.SelectedItem.Value != "0")
            {
                query += " AND system_users.perm_province=" + Province.SelectedItem.Value;

            }
            if (Designation.SelectedItem.Value != "0")
            {
                query += " AND emp_employments.post_held=" + Designation.SelectedItem.Value;

            }
            if (Branch.SelectedItem.Value != "0")
            {
                query += " AND emp_employments.branch=" + Branch.SelectedItem.Value;

            }
            if (EmpPoolDDL.SelectedItem.Value != "0")
            {
                query += " AND emp_employments.employee_pools_id=" + EmpPoolDDL.SelectedItem.Value;

            }
            query += " AND (basic_pay_scales.basic_pay_scales_id=emp_employments.basic_pay_scales_id)) order by basic_pay_scales.basic_pay_scales_id DESC";
            List<EmpSearchList> EmpList = new EmployeeHandler().SearchEmployee(query);

            EmpListView.DataSource = EmpList;
            EmpListView.DataBind();
        }
        protected void ClearSearch_Click(object sender, EventArgs e)
        {
            bindListView();
        }
        public void BindLeaveDetails(List<EmpSearchList> EmpList)
        {
            int SystemUsersId = 0;
            if(EmpList!=null)
            {
                foreach(EmpSearchList SList in EmpList)
                {
                    int YearlyTotalBalance = SList.PreviousLeaveCredit;
                    SystemUsersId= SList.EmpId;
                    List<EmployeeLeave> EmpLeave = new EmployeeHandler().GetAllLeaves(SystemUsersId);
                    List<EmpLeaveDetails> details = new List<EmpLeaveDetails>();
                    List<EmpLeaveDetails> Calculated = null;
                    if (EmpLeave != null)
                    {
                        foreach (EmployeeLeave row in EmpLeave)
                        {
                            DateTime StartDate = Convert.ToDateTime(row.StartDate);
                            DateTime EndDate = Convert.ToDateTime(row.EndDate);
                            int LeaveType = row.LeaveSubTypeId;
                            int StartMonth = StartDate.Month;
                            int StartYear = StartDate.Year;
                            int StartDay = StartDate.Day;
                            int EndYear = EndDate.Year;
                            int EndMonth = EndDate.Month;
                            int EndDay = EndDate.Day;

                            if (StartMonth == EndMonth)
                            {
                                EmpLeaveDetails lc = GetCreditInSameYearDifferentMonths(StartDate, EndDate, LeaveType);
                                details.Add(lc);

                            }
                            else if (StartMonth != EndMonth && StartYear == EndYear)
                            {
                                EmpLeaveDetails lc = GetCreditInSameYearDifferentMonths(StartDate, EndDate, LeaveType);
                                details.Add(lc);
                            }
                            else if (StartYear != EndYear)
                            {
                                List<EmpLeaveDetails> ld = GetCreditInDifferentYears(StartDate, EndDate, LeaveType);
                                foreach (EmpLeaveDetails lc in ld)
                                {
                                    details.Add(lc);
                                }
                            }
                        }
                        int startyear = 0;
                        Calculated = new List<EmpLeaveDetails>();
                        foreach (EmpLeaveDetails row in details)
                        {

                            if (startyear != row.ServiceYear)
                            {
                                EmpLeaveDetails ed = new EmpLeaveDetails();
                                startyear = row.ServiceYear;
                                ed.ServiceYear = row.ServiceYear;
                                ed.AvailedLeave = details.Where(item => item.ServiceYear == startyear).Sum(item => item.AvailedLeave);
                                ed.LeaveDeducted = details.Where(item => item.ServiceYear == startyear).Sum(item => item.LeaveDeducted);
                                ed.Remarks = row.Remarks;
                                //ed.EarnedLeave = details.Where(item => item.ServiceYear == startyear).Sum(item => item.EarnedLeave);
                                ed.EOL = details.Where(item => item.ServiceYear == startyear).Sum(item => item.EOL);

                                Calculated.Add(ed);
                            }
                        }
                    }

                    List<EmpLeaveDetails> EmpLeaveList = DisplaySummery(Calculated, SList.HouseServiceStartDate, SList.EmpId, SList.PreviousLeaveCredit);
                    //SList.PreviousLeaveCredit=EmpLeaveList.Max(t=>t.)

                }
            }
        }
        public List<EmpLeaveDetails> DisplaySummery(List<EmpLeaveDetails> cd, DateTime ServiceStartDate, int EmpId, int LeaveOnCredit)
        {
            int SenServiceYear = ServiceStartDate.Year;
            int CurrentYear = DateTime.Now.Year;
            List<EmpLeaveDetails> Lds = new List<EmpLeaveDetails>();
            for (int i = SenServiceYear; i <= CurrentYear; i++)
            {
                EmpLeaveDetails Ld = new EmpLeaveDetails();
                Ld.ServiceYear = i;
                //if (i == SenServiceYear)
                //     Ld.BalanceTillNow = LeaveOnCredit;
                ///////////////////////////////////   EARNED LEAVE IN THE YEAR ////////////////////////////////
                if (SenServiceYear != CurrentYear)
                {
                    if (i == SenServiceYear)
                        Ld.EarnedLeave = new DateTimeUtils().CalculateMonthsEarnedLFP(ServiceStartDate, Convert.ToDateTime("31/12/" + i));
                    else if (i == CurrentYear)
                        Ld.EarnedLeave = new DateTimeUtils().CalculateMonthsEarnedLFP(Convert.ToDateTime("1/1/" + i), DateTime.Now);
                    else
                        Ld.EarnedLeave = 48;

                }
                else
                    Ld.EarnedLeave = new DateTimeUtils().CalculateMonthsEarnedLFP(ServiceStartDate, DateTime.Now);
                Lds.Add(Ld);
            }
            int yearbalane = LeaveOnCredit;
            List<EmpLeaveDetails> FinalBalance = new List<EmpLeaveDetails>();

            foreach (EmpLeaveDetails row in Lds)
            {
                if (cd != null)
                {
                    foreach (EmpLeaveDetails row2 in cd)
                    {
                        if (row.ServiceYear == row2.ServiceYear)
                        {
                            row.EOL = row2.EOL;
                            row.LeaveDeducted = row2.LeaveDeducted;
                            row.AvailedLeave = row2.AvailedLeave;
                            row.CreditOfYear = (row.EarnedLeave - (row.AvailedLeave + row.LeaveDeducted));
                        }

                    }
                }
                row.CreditOfYear = (row.EarnedLeave - (row.AvailedLeave + row.LeaveDeducted));
                yearbalane += row.CreditOfYear;
                row.BalanceTillNow = yearbalane;
                FinalBalance.Add(row);

            }

            //CurrentLeaveCreditLbl.Text = Convert.ToString(yearbalane);
            List<EmpLeaveDetails> SuspensionList = CalculateSuspensionPeriod(EmpId);
            int FinalYearBalance = 0;
            foreach (EmpLeaveDetails obj in FinalBalance)
            {

                foreach (EmpLeaveDetails susp in SuspensionList)
                {
                    if (susp.ServiceYear == obj.ServiceYear)
                    {
                        obj.LeaveDeducted = susp.LeaveDeducted;
                        obj.Remarks = susp.Remarks;
                    }
                }
                obj.LeaveBalance = obj.EarnedLeave - (obj.AvailedLeave + obj.LeaveDeducted);

                FinalYearBalance += obj.LeaveBalance;
                //obj.BalanceTillNow = FinalYearBalance;
            }

            return FinalBalance;


        }



        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>

        //public EmpLeaveDetails GetCreditInSameMonth(DateTime StartDate,DateTime EndDate)
        //{
        //    EmpLeaveDetails lc = new EmpLeaveDetails();
        //    int Month = StartDate.Month;
        //    int Year = StartDate.Year;
        //    int StartDay = StartDate.Day;
        //    int EndDay = EndDate.Day;
        //    int DaysInMonth = DateTime.DaysInMonth(Year, Month);
        //    int HalfOfMonth = (DaysInMonth / 2) ;
        //    lc.ServiceYear = Year;
        //    lc.AvailedLeave = EndDay - StartDay+1;
        //    if (lc.AvailedLeave > HalfOfMonth)
        //        lc.LeaveDeducted = 4;
        //    return lc;

        //}

        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public EmpLeaveDetails GetCreditInSameYearDifferentMonths(DateTime StartDate, DateTime EndDate, int LeaveType)
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
                    if (LeaveType != 3)
                        lc.AvailedLeave += Leaves;
                    else
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
                    if (LeaveType != 3)
                        lc.AvailedLeave += Leaves;
                    else
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
                    if (LeaveType != 3)
                        lc.AvailedLeave += Leaves;
                    else
                        lc.EOL += Leaves;
                    if (Leaves > HalfOfMonth)
                    {
                        lc.LeaveDeducted += 4;
                    }
                }
                else
                {
                    if (LeaveType != 3)
                        lc.AvailedLeave += DateTime.DaysInMonth(StartYear, j);
                    else
                        lc.EOL += DateTime.DaysInMonth(StartYear, j);
                    lc.LeaveDeducted += 4;
                }


            }
            if (LeaveType == 2)
                lc.AvailedLeave = lc.AvailedLeave / 2;
            return lc;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////




        public List<EmpLeaveDetails> GetCreditInDifferentYears(DateTime StartDate, DateTime EndDate, int LeaveType)
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
                        if (LeaveType != 3)
                            lc.AvailedLeave += ((DaysInMonth - StartDay) + 1);
                        else
                            lc.EOL += ((DaysInMonth - StartDay) + 1);
                        if (lc.AvailedLeave > HalfOfMonth || lc.EOL > HalfOfMonth)
                        {
                            lc.LeaveDeducted += 4;
                        }
                    }
                    else if (j == EndMonth && i == EndYear)
                    {
                        if (LeaveType != 3)
                            lc.AvailedLeave += EndDay;
                        else
                            lc.EOL += EndDay;
                        if (lc.AvailedLeave > HalfOfMonth || lc.EOL > HalfOfMonth)
                        {
                            lc.LeaveDeducted += 4;
                        }
                    }
                    else
                    {
                        if (LeaveType != 3)
                            lc.AvailedLeave += DateTime.DaysInMonth(i, j);
                        else
                            lc.EOL += DateTime.DaysInMonth(i, j);

                        lc.LeaveDeducted += 4;
                    }

                }
                if (LeaveType == 2)
                    lc.AvailedLeave = lc.AvailedLeave / 2;
                lcs.Add(lc);
            }
            lcs.TrimExcess();
            return lcs;

        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        public List<EmpLeaveDetails> CalculateSuspensionPeriod(int EmpId)
        {
            List<DisciplinaryAction> da = new EmploymentBIZ().GetEmpSuspensions(EmpId);
            List<EmpLeaveDetails> details = new List<EmpLeaveDetails>();
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
                        EmpLeaveDetails lc = GetCreditInSameYearDifferentMonths(StartDate, EndDate, LeaveType);
                        lc.Remarks = Remarks;
                        details.Add(lc);

                    }
                    else if (StartMonth != EndMonth && StartYear == EndYear)
                    {
                        EmpLeaveDetails lc = GetCreditInSameYearDifferentMonths(StartDate, EndDate, LeaveType);
                        lc.Remarks = Remarks;
                        details.Add(lc);
                    }
                    else if (StartYear != EndYear)
                    {
                        List<EmpLeaveDetails> ld = GetCreditInDifferentYears(StartDate, EndDate, LeaveType);
                        foreach (EmpLeaveDetails lc in ld)
                        {
                            lc.Remarks = Remarks;
                            details.Add(lc);
                        }
                    }
                }
            }
            return details;

        }
    }
}