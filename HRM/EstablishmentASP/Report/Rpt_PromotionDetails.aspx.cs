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
    public partial class Rpt_PromotionDetails : System.Web.UI.Page
    {
        string lastrec = "";
        int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpCookie userinfo = Request.Cookies["loginstatus"];
            //if (userinfo != null)
            //{
            //    string role = userinfo.Value;
            //    if (role.Equals("entry") == false)
            //        Response.Redirect("~/Login.aspx");
            //}
            //else
            //{
            //    Response.Redirect("~/Login.aspx");
            //}

            if (!IsPostBack)
            {
                bindListView();
                bindFields();

            }
        }
        private void bindListView()
        {
            List<EmpSearchList> EmpList = null;
            string query = "SELECT SYSTEM_USERS.SYSTEM_USERS_ID, DATEDIFF(yy, SYSTEM_USERS.DOB, GETDATE()) AS age, SYSTEM_USERS.F_NAME, SYSTEM_USERS.M_NAME, SYSTEM_USERS.L_NAME, POSTS_1.DESCRIPTION AS post, ";
            query += " BASIC_PAY_SCALES_1.DESCRIPTION AS bps, EMP_STATUS.DESCRIPTION AS empl_status, EMP_EMPLOYMENTS.FILE_NO, EMP_EMPLOYMENTS.PREVIOUS_LEAVE_CREDIT,  ";
            query += " EMP_EMPLOYMENTS.FILE_NO,EMP_EMPLOYMENTS.GOVT_SERVICE_START_DATE, EMP_EMPLOYMENTS.HOUSE_SERVICE_START_DATE, EMP_EMPLOYMENTS.PERSONAL_NO, BASIC_PAY_SCALES_1.BASIC_PAY_SCALES_ID,  ";
            query += " EMP_PROMOTION_HIST.PROMOTION_TYPE_ID, PROMOTION_TYPES.PROMOTION_TYPE, EMP_PROMOTION_HIST.DATED, EMP_PROMOTION_HIST.REMARKS, ";
            query += " (SELECT        DESCRIPTION ";
            query += " FROM            POSTS ";
            query += " WHERE(POSTS_ID = EMP_PROMOTION_HIST.POST)) AS PROMOTION_POST, EMP_PROMOTION_HIST.BRANCH, ";
            query += " (SELECT        DESCRIPTION ";
            query += " FROM            BASIC_PAY_SCALES ";
            query += " WHERE(BASIC_PAY_SCALES_ID = EMP_PROMOTION_HIST.BASIC_PAY_SCALES_ID)) AS PROMOTION_BPS, EMP_PROMOTION_HIST.IS_GAZETTED, ";
            query += " (SELECT        DESCRIPTION ";
            query += "  FROM            PROMOTION_MODES ";
            query += " WHERE(PROMOTION_MODES_ID = EMP_PROMOTION_HIST.PROMOTION_MODES_ID)) AS PROMOTION_MODE, PROMOTION_MODES_1.DESCRIPTION AS PROMOTION_MODE ";
            query += " FROM            EMP_EMPLOYMENTS INNER JOIN ";
            query += " SYSTEM_USERS ON EMP_EMPLOYMENTS.SYSTEM_USERS_ID = SYSTEM_USERS.SYSTEM_USERS_ID INNER JOIN ";
            query += " POSTS AS POSTS_1 ON EMP_EMPLOYMENTS.POST_HELD = POSTS_1.POSTS_ID INNER JOIN ";
            query += " EMP_STATUS ON EMP_EMPLOYMENTS.EMP_STATUS_ID = EMP_STATUS.EMP_STATUS_ID INNER JOIN ";
            query += " BASIC_PAY_SCALES AS BASIC_PAY_SCALES_1 ON EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID = BASIC_PAY_SCALES_1.BASIC_PAY_SCALES_ID INNER JOIN ";
            query += " EMP_PROMOTION_HIST ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_PROMOTION_HIST.SYSTEM_USERS_ID INNER JOIN ";
            query += " PROMOTION_TYPES ON EMP_PROMOTION_HIST.PROMOTION_TYPE_ID = PROMOTION_TYPES.PROMOTION_TYPE_ID INNER JOIN ";
            query += " PROMOTION_MODES AS PROMOTION_MODES_1 ON EMP_PROMOTION_HIST.PROMOTION_MODES_ID = PROMOTION_MODES_1.PROMOTION_MODES_ID ";
            EmpList = new ReportsBIZ().PromotionReport(query);
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
         
               List<TempEntity> pmode = new AdministrationBIZ().GetPromotionModes();
            PromotionModeDDL.Items.Add(new ListItem("Select", "0"));
            foreach (TempEntity row in pmode)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.Id.ToString();
                    cy.Text = row.Description.ToString();
                    PromotionModeDDL.Items.Add(cy);
                }
           

                PromotionTypeDDL.Items.Add(new ListItem("Select", "0"));
                List<TempEntity> ptype = new AdministrationBIZ().GetPromotionTypes();
                foreach (TempEntity row in ptype)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.Id.ToString();
                    PromotionTypeDDL.Items.Add(li);
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
            if (NotEmpInSen.Checked == true)
            {
                if (query != "")
                    query += " AND ";
                query += " emp_employments.GOVT_SERVICE_START_DATE<>emp_employments.HOUSE_SERVICE_START_DATE";
            }

            if (!(String.IsNullOrEmpty(AgeTo.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " DATEDIFF(yy,system_users.dob,GetDate())<=" + AgeTo.Text;
            }
            if (!(String.IsNullOrEmpty(GExpFrom.Text)))
            {
                query += " AND DATEDIFF(yy,emp_employments.GOVT_SERVICE_START_DATE,GetDate())>=" + GExpFrom.Text;
                CriteriaLbl.Text += ", <b>Govt. Job Experience From:</b>" + GExpFrom.Text + " Years ";
            }
            if (!(String.IsNullOrEmpty(GExpTo.Text)))
            {
                query += " AND DATEDIFF(yy,emp_employments.GOVT_SERVICE_START_DATE,GetDate())<=" + GExpTo.Text;
                CriteriaLbl.Text += ", <b>Govt. Job Experience To:</b>" + GExpTo.Text + " Years ";
            }


            if (!(String.IsNullOrEmpty(SExpFrom.Text)))
            {
                query += " AND DATEDIFF(yy,emp_employments.HOUSE_SERVICE_START_DATE,GetDate())>=" + SExpFrom.Text;
                CriteriaLbl.Text += ", <b>Senate Job Experience From:</b>" + SExpFrom.Text + " Years ";
            }
            if (!(String.IsNullOrEmpty(SExpTo.Text)))
            {
                query += " AND DATEDIFF(yy,emp_employments.HOUSE_SERVICE_START_DATE,GetDate())<=" + SExpTo.Text;
                CriteriaLbl.Text += ", <b>Senate Job Experience To:</b>" + SExpTo.Text + " Years ";
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
                query += " emp_employments.EMP_STATUS_ID=" + EmpStatusDDL.SelectedItem.Value;

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
                query += " emp_employments.current_status_id=" + CurrentStatusDDL.SelectedItem.Value;

            }
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
                //query = "SELECT system_users.system_users_id,DATEDIFF(yy,system_users.dob,GetDate()) as age,system_users.f_name,system_users.m_name,system_users.l_name,system_users.imageUrl,system_users.perm_address,system_users.local_address,system_users.email,posts.description as post, basic_pay_scales.description as bps, emp_status.description as empl_status, emp_employments.file_no ";
                //query += " ,emp_employments.PREVIOUS_LEAVE_CREDIT, emp_employments.Govt_Service_Start_Date ,emp_employments.House_Service_Start_Date,emp_employments.Personal_No,EnteredBy,EnteredOn,RecheckedBy ";
                //query += " FROM emp_employments, posts, system_users,basic_pay_scales, emp_status, emp_empl_history";
                //query += " WHERE ( (system_users.system_users_id = emp_employments.system_users_id)";
                //query += " AND (posts.posts_id = emp_employments.post_held)";
                //query += " AND (system_users.system_users_id = emp_empl_history.system_users_id)";
                //query += " AND (emp_status.emp_status_id =emp_employments.emp_status_id)";
                query = "SELECT SYSTEM_USERS.SYSTEM_USERS_ID, DATEDIFF(yy, SYSTEM_USERS.DOB, GETDATE()) AS age, SYSTEM_USERS.F_NAME, SYSTEM_USERS.M_NAME, SYSTEM_USERS.L_NAME, POSTS_1.DESCRIPTION AS post, ";
                query += " BASIC_PAY_SCALES_1.DESCRIPTION AS bps, EMP_STATUS.DESCRIPTION AS empl_status, EMP_EMPLOYMENTS.FILE_NO, EMP_EMPLOYMENTS.PREVIOUS_LEAVE_CREDIT,  ";
                query += " EMP_EMPLOYMENTS.GOVT_SERVICE_START_DATE, EMP_EMPLOYMENTS.HOUSE_SERVICE_START_DATE, EMP_EMPLOYMENTS.PERSONAL_NO, BASIC_PAY_SCALES_1.BASIC_PAY_SCALES_ID,  ";
                query += " EMP_EMPLOYMENTS.FILE_NO,EMP_PROMOTION_HIST.PROMOTION_TYPE_ID, PROMOTION_TYPES.PROMOTION_TYPE, EMP_PROMOTION_HIST.DATED, EMP_PROMOTION_HIST.REMARKS, ";
                query += " (SELECT        DESCRIPTION ";
                query += " FROM            POSTS ";
                query += " WHERE(POSTS_ID = EMP_PROMOTION_HIST.POST)) AS PROMOTION_POST, EMP_PROMOTION_HIST.BRANCH, ";
                query += " (SELECT        DESCRIPTION ";
                query += " FROM            BASIC_PAY_SCALES ";
                query += " WHERE(BASIC_PAY_SCALES_ID = EMP_PROMOTION_HIST.BASIC_PAY_SCALES_ID)) AS PROMOTION_BPS, EMP_PROMOTION_HIST.IS_GAZETTED, ";
                query += " (SELECT        DESCRIPTION ";
                query += "  FROM            PROMOTION_MODES ";
                query += " WHERE(PROMOTION_MODES_ID = EMP_PROMOTION_HIST.PROMOTION_MODES_ID)) AS PROMOTION_MODE, PROMOTION_MODES_1.DESCRIPTION AS PROMOTION_MODE ";
                query += " FROM            EMP_EMPLOYMENTS INNER JOIN ";
                query += " SYSTEM_USERS ON EMP_EMPLOYMENTS.SYSTEM_USERS_ID = SYSTEM_USERS.SYSTEM_USERS_ID INNER JOIN ";
                query += " POSTS AS POSTS_1 ON EMP_EMPLOYMENTS.POST_HELD = POSTS_1.POSTS_ID INNER JOIN ";
                query += " EMP_STATUS ON EMP_EMPLOYMENTS.EMP_STATUS_ID = EMP_STATUS.EMP_STATUS_ID INNER JOIN ";
                query += " BASIC_PAY_SCALES AS BASIC_PAY_SCALES_1 ON EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID = BASIC_PAY_SCALES_1.BASIC_PAY_SCALES_ID INNER JOIN ";
                query += " EMP_PROMOTION_HIST ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_PROMOTION_HIST.SYSTEM_USERS_ID INNER JOIN ";
                query += " PROMOTION_TYPES ON EMP_PROMOTION_HIST.PROMOTION_TYPE_ID = PROMOTION_TYPES.PROMOTION_TYPE_ID INNER JOIN ";
                query += " PROMOTION_MODES AS PROMOTION_MODES_1 ON EMP_PROMOTION_HIST.PROMOTION_MODES_ID = PROMOTION_MODES_1.PROMOTION_MODES_ID ";



                //query = "SELECT SYSTEM_USERS.SYSTEM_USERS_ID, DATEDIFF(yy, SYSTEM_USERS.DOB, GETDATE()) AS age, SYSTEM_USERS.F_NAME, SYSTEM_USERS.M_NAME, SYSTEM_USERS.L_NAME, SYSTEM_USERS.ImageUrl, ";
                //query += " SYSTEM_USERS.PERM_ADDRESS, SYSTEM_USERS.LOCAL_ADDRESS, SYSTEM_USERS.EMAIL, POSTS.DESCRIPTION AS post, BASIC_PAY_SCALES.DESCRIPTION AS bps, EMP_STATUS.DESCRIPTION AS empl_status, ";
                //query += " EMP_EMPLOYMENTS.FILE_NO, EMP_EMPLOYMENTS.PREVIOUS_LEAVE_CREDIT, EMP_EMPLOYMENTS.GOVT_SERVICE_START_DATE, EMP_EMPLOYMENTS.HOUSE_SERVICE_START_DATE,  ";
                //query += " EMP_EMPLOYMENTS.PERSONAL_NO, SYSTEM_USERS.ENTEREDBY, SYSTEM_USERS.ENTEREDON, SYSTEM_USERS.RECHECKEDBY, BASIC_PAY_SCALES.BASIC_PAY_SCALES_ID ";
                //query += " FROM            EMP_EMPLOYMENTS INNER JOIN ";
                //query += " SYSTEM_USERS ON EMP_EMPLOYMENTS.SYSTEM_USERS_ID = SYSTEM_USERS.SYSTEM_USERS_ID INNER JOIN ";
                //query += " POSTS ON EMP_EMPLOYMENTS.POST_HELD = POSTS.POSTS_ID INNER JOIN ";
                //if (EmpStatusDDL.SelectedItem.Value != "0" || CurrentStatusDDL.SelectedItem.Value != "0")
                //    query += " EMP_EMPL_HISTORY ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_EMPL_HISTORY.SYSTEM_USERS_ID INNER JOIN ";
                //query += " EMP_STATUS ON EMP_EMPLOYMENTS.EMP_STATUS_ID = EMP_STATUS.EMP_STATUS_ID INNER JOIN ";
                //query += " BASIC_PAY_SCALES ON EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID = BASIC_PAY_SCALES.BASIC_PAY_SCALES_ID ";



                if (!(String.IsNullOrEmpty(FileNoTxt.Text)))
                {
                    query += " AND emp_employments.file_no like '" + FileNoTxt.Text + "%'";
                    CriteriaLbl.Text += ", <b>File Number:</b>" + FileNoTxt.Text;


                }
                if (!(String.IsNullOrEmpty(PeronalNoTxt.Text)))
                {

                    query += " AND emp_employments.Personal_No Like '" + PeronalNoTxt.Text + "'";
                    CriteriaLbl.Text += ", <b>Personal No::</b>" + PeronalNoTxt.Text;

                }
                if (AppointmentModeDDL.SelectedItem.Value != "0")
                {
                    if (query != "")
                        query += " AND ";
                    query += " emp_employments.APPOINTMENT_MODE_ID=" + AppointmentModeDDL.SelectedItem.Value;
                    CriteriaLbl.Text += ", <b>Appointment Mode:</b>" + AppointmentModeDDL.SelectedItem.Text;

                }
                if (!(String.IsNullOrEmpty(EmpName.Text)))
                {
                    query += " AND system_users.f_name like '%" + EmpName.Text + "%'";
                    CriteriaLbl.Text += ", <b>Name:</b>" + EmpName.Text;

                }
                if (IsActiveCB.SelectedItem.Value != "select")
                {
                    query += " AND system_users.is_active=" + IsActiveCB.SelectedItem.Value;
                    CriteriaLbl.Text += ", <b>Active:</b>" + IsActiveCB.SelectedItem.Text;

                }
                if (!(String.IsNullOrEmpty(AgeFrom.Text)))
                {
                    query += " AND DATEDIFF(yy,system_users.dob,GetDate())>=" + AgeFrom.Text;
                    CriteriaLbl.Text += ", <b>Age From:</b>" + AgeFrom.Text;
                }
                if (!(String.IsNullOrEmpty(AgeTo.Text)))
                {
                    query += " AND DATEDIFF(yy,system_users.dob,GetDate())<=" + AgeTo.Text;
                    CriteriaLbl.Text += ", <b>Age To:</b>" + AgeTo.Text;
                }

                if (!(String.IsNullOrEmpty(GExpFrom.Text)))
                {
                    query += " AND DATEDIFF(yy,emp_employments.GOVT_SERVICE_START_DATE,GetDate())>=" + GExpFrom.Text;
                    CriteriaLbl.Text += ", <b>Govt. Job Experience From:</b>" + GExpFrom.Text + " Years ";
                }
                if (!(String.IsNullOrEmpty(GExpTo.Text)))
                {
                    query += " AND DATEDIFF(yy,emp_employments.GOVT_SERVICE_START_DATE,GetDate())<=" + GExpTo.Text;
                    CriteriaLbl.Text += ", <b>Govt. Job Experience To:</b>" + GExpTo.Text + " Years ";
                }


                if (!(String.IsNullOrEmpty(SExpFrom.Text)))
                {
                    query += " AND DATEDIFF(yy,emp_employments.HOUSE_SERVICE_START_DATE,GetDate())>=" + SExpFrom.Text;
                    CriteriaLbl.Text += ", <b>Senate Job Experience From:</b>" + SExpFrom.Text + " Years ";
                }
                if (!(String.IsNullOrEmpty(SExpTo.Text)))
                {
                    query += " AND DATEDIFF(yy,emp_employments.HOUSE_SERVICE_START_DATE,GetDate())<=" + SExpTo.Text;
                    CriteriaLbl.Text += ", <b>Senate Job Experience To:</b>" + SExpTo.Text + " Years ";
                }


                if (Gender.SelectedItem.Value != "0")
                {
                    query += " AND system_users.gender=" + Gender.SelectedItem.Value;
                    CriteriaLbl.Text += ", <b>Gender:</b>" + Gender.SelectedItem.Text;

                }
                if (BPSFrom.SelectedItem.Value != "0")
                {
                    query += " AND emp_employments.BASIC_PAY_SCALES_ID>=" + BPSFrom.SelectedItem.Value;
                    CriteriaLbl.Text += ", <b>BPS From:</b>" + BPSFrom.SelectedItem.Text;

                }
                if (BPSTo.SelectedItem.Value != "0")
                {
                    query += " AND emp_employments.BASIC_PAY_SCALES_ID<=" + BPSTo.SelectedItem.Value;
                    CriteriaLbl.Text += ", <b>BPS To:</b>" + BPSTo.SelectedItem.Text;
                }
                if (EmpStatusDDL.SelectedItem.Value != "0")
                {
                    query += " AND emp_empl_history.empl_status_id=" + EmpStatusDDL.SelectedItem.Value;
                    CriteriaLbl.Text += ", <b>Employment Status:</b>" + EmpStatusDDL.SelectedItem.Text;
                }
                if (CurrentStatusDDL.SelectedItem.Value != "0")
                {
                    query += " AND emp_empl_history.current_status_id=" + CurrentStatusDDL.SelectedItem.Value;
                    CriteriaLbl.Text += ", <b>Current Status:</b>" + CurrentStatusDDL.SelectedItem.Text;
                }
                if (Province.SelectedItem.Value != "0")
                {
                    query += " AND system_users.perm_province=" + Province.SelectedItem.Value;
                    CriteriaLbl.Text += ", <b>Province:</b>" + Province.SelectedItem.Text;

                }
                if (Designation.SelectedItem.Value != "0")
                {
                    query += " AND emp_employments.post_held=" + Designation.SelectedItem.Value;
                    CriteriaLbl.Text += ", <b>Post:</b>" + Designation.SelectedItem.Text;
                }
                if (Branch.SelectedItem.Value != "0")
                {
                    query += " AND emp_employments.branch=" + Branch.SelectedItem.Value;
                    CriteriaLbl.Text += ", <b>Branch:</b>" + Branch.SelectedItem.Text;
                }
                if (EmpPoolDDL.SelectedItem.Value != "0")
                {
                    query += " AND emp_employments.employee_pools_id=" + EmpPoolDDL.SelectedItem.Value;
                    CriteriaLbl.Text += ", <b>Pool:</b>" + EmpPoolDDL.SelectedItem.Text;
                }

                if (NotEmpInSen.Checked == true)
                {
                    if (query != "")
                        query += " AND ";
                    query += " emp_employments.GOVT_SERVICE_START_DATE<>emp_employments.HOUSE_SERVICE_START_DATE";
                }
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
                    query += " emp_employments.HOUSE_SERVICE_START_DATE>=CONVERT(DATE,'" + DateFromTxt.Text + "',103)";
                    CriteriaLbl.Text += ", <b>Appoinment Date From:</b>" + DateFromTxt.Text;
                }
                if (!(String.IsNullOrEmpty(DateToTxt.Text)))
                {
                    if (query != "")
                        query += " AND ";
                    query += " emp_employments.HOUSE_SERVICE_START_DATE<=CONVERT(DATE,'" + DateToTxt.Text + "',103)";
                    CriteriaLbl.Text += ", <b>Appoinment Date To:</b>" + DateToTxt.Text;
                }
                //query += " AND (basic_pay_scales.basic_pay_scales_id=emp_employments.basic_pay_scales_id)) order by basic_pay_scales.basic_pay_scales_id DESC,system_users.dob ";
                EmpList = new ReportsBIZ().PromotionReport(query);
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
        protected string AddGroupingRow()
        {
            string currentSemesterValue = Convert.ToString(Eval("EmployeeName"));
            string row;
            if (currentSemesterValue != lastrec)
            {
                row = "<tr><td>'";
                row += "<asp:Label ID = 'Label3' class='table - data' runat='server' Text=' <%#Container.DataItemIndex + 1%> ' />";
                row += "</td><td>";
                row += "<asp:Label ID = 'Label6' class='table-data' runat='server' Text='<%#Eval('PersonalNumber')%>' />";
                row += "</td><td>";
                row += "<asp:Label ID = 'Label4' class='table-data' runat='server' Text='<%#Eval('Filenumber')%>' />";
                row += "</td><td>";
                row += "<asp:Label ID = 'Label9' class='table-data' runat='server' Text='<%#Eval('EmpName')%>' />";
                row += "</td><td>";
                row += "<asp:Label ID = 'Label5' class='table-data' runat='server' Text='<%#Eval('Age')%>' />";
                row += "</td><td>";
                row += "<asp:Label ID = 'rankLabel' class='table-data' runat='server' Text='<%#Eval('EmpDesignation')%>'></asp:Label>";
                row += "</td><td>";
                row += "<asp:Label ID = 'descriptionLabel' class='table-data' runat='server' Text='<%#Eval('BPS')%>' />";
                row += "</td><td>";
                row += "<asp:Label ID = 'Label2' runat='server' class='table-data' Text='<%#Eval('Empstatus')%>' />";
                row += "</td><td>";
                row += "<asp:Label ID = 'Label1' runat='server' class='table-data' Text='<%#Convert.ToDateTime(Eval('HouseServiceStartDate')).ToShortDateString()%>' />";
                row += "</td><td>";
                row += "<asp:Label ID = 'Label7' runat='server' class='table-data' Text='<%#Eval('AppointmentPost') + ' (' + Eval('AppointmentBps') + ')'%>' />";
                row += "</td><td>";
                row += "<asp:Label ID = 'Label8' runat='server' class='table-data' Text='<%#Eval('AppointmentEmplStatus')%>' />";
                row += "</td></tr>";
                lastrec = currentSemesterValue;
                i++;
                return String.Format(row);

            }
            else return String.Empty;
        }
    }
}