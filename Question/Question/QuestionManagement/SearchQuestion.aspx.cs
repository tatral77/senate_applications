using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class SearchQuestion : System.Web.UI.Page
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
            List<Questions> Questions = new QuestionBiz().GetQuestions(20);
            ListView1.DataSource = Questions;
            ListView1.DataBind();

        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();

        }
        private void bindFields()
        {

            List<AssemblySessions> ASessions = new QuestionBiz().GetAssemblySessions();
            foreach (AssemblySessions row in ASessions)
            {
                ListItem li = new ListItem();
                li.Text = row.SessionNumber.ToString();
                li.Value = row.AssemblySessionsId.ToString();
                AssemblySessionDDL.Items.Add(li);
            }
            List<QuestionCategories> QCats = new QuestionBiz().GetQuestionCategories();
            foreach (QuestionCategories row in QCats)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.QuestionCategoriesId.ToString();
                CategoryDDL.Items.Add(li);
            }
            //List<Post> posts = new AdministrationBIZ().GetActivePosts();
            //foreach (Post row in posts)
            //{
            //    ListItem li = new ListItem();
            //    li.Text = row.Description;
            //    li.Value = row.PostID.ToString();
            //    Designation.Items.Add(li);
            //}
            //List<EmpStatus> ps = new AdministrationBIZ().GetEmpStatusList();
            //foreach (EmpStatus row in ps)
            //{
            //    ListItem li = new ListItem();
            //    li.Text = row.Description;
            //    li.Value = row.EmpStatusId.ToString();
            //    EmpStatusDDL.Items.Add(li);
            //}
            //EmpStatusDDL.SelectedValue = "1";
            //List<CurrentStatuses> pt = new AdministrationBIZ().GetCurrentStatuses();

            //foreach (CurrentStatuses row in pt)
            //{
            //    ListItem cy = new ListItem();
            //    cy.Value = row.CurrentStatusId.ToString();
            //    cy.Text = row.CurrentStatus.ToString();
            //    CurrentStatusDDL.Items.Add(cy);
            //}
            //CurrentStatusDDL.SelectedValue = "9";
            //List<Branch> br = new AdministrationBIZ().GetBranches();
            //foreach (Branch row in br)
            //{
            //    ListItem li = new ListItem();
            //    li.Text = row.Description;
            //    li.Value = row.Branchid.ToString();
            //    Branch.Items.Add(li);
            //}
            //List<Province> pr = new AdministrationBIZ().GetProvinces();
            //foreach (Province row in pr)
            //{
            //    ListItem li = new ListItem();
            //    li.Text = row.Description;
            //    li.Value = row.ProvincesID.ToString();
            //    Province.Items.Add(li);
            //}
            //List<EmployeePools> EmpPools = new AdministrationBIZ().GetEmpPools();
            //foreach (EmployeePools row in EmpPools)
            //{
            //    ListItem li = new ListItem();
            //    li.Text = row.Description;
            //    li.Value = row.EmpPoolsId.ToString();
            //    EmpPoolDDL.Items.Add(li);
            //}

        }
        protected void SessionDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupsDDL.Items.Clear();
            List<Groups> gps = new QuestionBiz().GetSessionGroups(Convert.ToInt32(AssemblySessionDDL.SelectedItem.Value));
            foreach(Groups obj in gps)
            {
                ListItem li = new ListItem();
                li.Value = obj.GroupsId.ToString();
                li.Text = obj.Description;
                GroupsDDL.Items.Add(li);
            }
            
        }
        protected string GetCriteria()
        {
            string query = "";
            //if (!(String.IsNullOrEmpty(FileNoTxt.Text)))
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " emp_employments.file_no like '" + FileNoTxt.Text + "%'";

            //}
            //if (!(String.IsNullOrEmpty(EmpName.Text)))
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " system_users.f_name like '%" + EmpName.Text + "%'";

            //}
            //if (IsActiveCB.SelectedItem.Value != "select")
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " system_users.is_active=" + IsActiveCB.SelectedItem.Value;

            //}
            //if (!(String.IsNullOrEmpty(AgeFrom.Text)))
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " DATEDIFF(yy,system_users.dob,GetDate())>=" + AgeFrom.Text;
            //}
            //if (!(String.IsNullOrEmpty(AgeTo.Text)))
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " DATEDIFF(yy,system_users.dob,GetDate())<=" + AgeTo.Text;
            //}
            //if (!(String.IsNullOrEmpty(ExpFrom.Text)))
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " DATEDIFF(yy,emp_employments.GOVT_SERVICE_START_DATE,GetDate())>=" + ExpFrom.Text;
            //}
            //if (!(String.IsNullOrEmpty(ExpTo.Text)))
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " DATEDIFF(yy,emp_employments.GOVT_SERVICE_START_DATE,GetDate())<=" + ExpTo.Text;
            //}
            //if (Gender.SelectedItem.Value != "0")
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " system_users.gender=" + Gender.SelectedItem.Value;

            //}

            //if (AppointmentModeDDL.SelectedItem.Value != "0")
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " emp_employments.APPOINTMENT_MODE_ID>=" + AppointmentModeDDL.SelectedItem.Value;

            //}
            //if (BPSFrom.SelectedItem.Value != "0")
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " emp_employments.BASIC_PAY_SCALES_ID>=" + BPSFrom.SelectedItem.Value;

            //}
            //if (BPSTo.SelectedItem.Value != "0")
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " emp_employments.BASIC_PAY_SCALES_ID<=" + BPSTo.SelectedItem.Value;

            //}
            //if (EmpStatusDDL.SelectedItem.Value != "0")
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " emp_empl_history.empl_status_id=" + EmpStatusDDL.SelectedItem.Value;

            //}
            //if (Province.SelectedItem.Value != "0")
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " system_users.perm_province=" + Province.SelectedItem.Value;

            //}
            //if (Designation.SelectedItem.Value != "0")
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += "emp_employments.post_held=" + Designation.SelectedItem.Value;

            //}
            //if (Branch.SelectedItem.Value != "0")
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " emp_employments.branch=" + Branch.SelectedItem.Value;

            //}
            //if (EmpPoolDDL.SelectedItem.Value != "0")
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " emp_employments.employee_pools_id=" + EmpPoolDDL.SelectedItem.Value;

            //}
            //if (CurrentStatusDDL.SelectedItem.Value != "0")
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " emp_empl_history.current_status_id=" + CurrentStatusDDL.SelectedItem.Value;

            //}
            //if (!(String.IsNullOrEmpty(DateFromTxt.Text)) && !(String.IsNullOrEmpty(DateToTxt.Text)))
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " (DATEADD(year, 60, SYSTEM_USERS.DOB) BETWEEN CONVERT(datetime,'" + DateFromTxt.Text + "' , 103) AND CONVERT(datetime, '" + DateToTxt.Text + "', 103) AND (SYSTEM_USERS.IS_EMPLOYEE = 1))";
            //}
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
        //    List<EmpSearchList> EmpList = new QuestionBiz().SearchEmployee(query);
        //    ListView1.DataSource = EmpList;
        //    ListView1.DataBind();
        //}
        protected void Search_Click(object sender, EventArgs e)
        {
            //CriteriaLbl.Text = "";
            //string query = null;
            //query = "SELECT system_users.system_users_id,DATEDIFF(yy,system_users.dob,GetDate()) as age,system_users.f_name,system_users.m_name,system_users.l_name,system_users.perm_address,system_users.local_address,system_users.email,posts.description as post, basic_pay_scales.description as bps, emp_status.description as empl_status, emp_employments.file_no ";
            //query += ",emp_employments.PREVIOUS_LEAVE_CREDIT, emp_employments.House_Service_Start_Date ";
            //query += " FROM emp_employments, posts, system_users,basic_pay_scales, emp_status";
            //query += " WHERE ( (system_users.system_users_id = emp_employments.system_users_id)";
            //query += " AND (posts.posts_id = emp_employments.post_held)";
            //query += " AND (emp_status.emp_status_id =emp_employments.emp_status_id)";
            //if (!(String.IsNullOrEmpty(FileNoTxt.Text)))
            //{
            //    query += " AND emp_employments.file_no like '" + FileNoTxt.Text + "%'";
            //    CriteriaLbl.Text += ", <b>File Number:</b>" + FileNoTxt.Text;


            //}
            //if (!(String.IsNullOrEmpty(PeronalNoTxt.Text)))
            //{

            //    query += " AND emp_employments.Personal_No Like '" + PeronalNoTxt.Text + "'";
            //    CriteriaLbl.Text += ", <b>Personal No::</b>" + PeronalNoTxt.Text;

            //}
            //if (!(String.IsNullOrEmpty(EmpName.Text)))
            //{
            //    query += " AND system_users.f_name like '%" + EmpName.Text + "%'";
            //    CriteriaLbl.Text += ", <b>Name:</b>" + EmpName.Text;

            //}
            //if (IsActiveCB.SelectedItem.Value != "select")
            //{
            //    query += " AND system_users.is_active=" + IsActiveCB.SelectedItem.Value;
            //    CriteriaLbl.Text += ", <b>Active:</b>" + IsActiveCB.SelectedItem.Text;

            //}
            //if (!(String.IsNullOrEmpty(AgeFrom.Text)))
            //{
            //    query += " AND DATEDIFF(yy,system_users.dob,GetDate())>=" + AgeFrom.Text;
            //    CriteriaLbl.Text += ", <b>Age From:</b>" + AgeFrom.Text;
            //}
            //if (!(String.IsNullOrEmpty(AgeTo.Text)))
            //{
            //    query += " AND DATEDIFF(yy,system_users.dob,GetDate())<=" + AgeTo.Text;
            //    CriteriaLbl.Text += ", <b>Age To:</b>" + AgeTo.Text;
            //}
            //if (!(String.IsNullOrEmpty(ExpFrom.Text)))
            //{
            //    query += " AND DATEDIFF(yy,emp_employments.GOVT_SERVICE_START_DATE,GetDate())>=" + ExpFrom.Text;
            //    CriteriaLbl.Text += ", <b>Job Experience From:</b>" + ExpFrom.Text;
            //}
            //if (!(String.IsNullOrEmpty(ExpTo.Text)))
            //{
            //    query += " AND DATEDIFF(yy,emp_employments.GOVT_SERVICE_START_DATE,GetDate())<=" + ExpTo.Text;
            //    CriteriaLbl.Text += ", <b>Job Experience To:</b>" + ExpTo.Text;
            //}
            //if (Gender.SelectedItem.Value != "0")
            //{
            //    query += " AND system_users.gender=" + Gender.SelectedItem.Value;
            //    CriteriaLbl.Text += ", <b>Gender:</b>" + Gender.SelectedItem.Text;

            //}
            //if (BPSFrom.SelectedItem.Value != "0")
            //{
            //    query += " AND emp_employments.BASIC_PAY_SCALES_ID>=" + BPSFrom.SelectedItem.Value;
            //    CriteriaLbl.Text += ", <b>BPS From:</b>" + BPSFrom.SelectedItem.Text;

            //}
            //if (BPSTo.SelectedItem.Value != "0")
            //{
            //    query += " AND emp_employments.BASIC_PAY_SCALES_ID<=" + BPSTo.SelectedItem.Value;
            //    CriteriaLbl.Text += ", <b>BPS To:</b>" + BPSTo.SelectedItem.Text;
            //}
            //if (EmpStatusDDL.SelectedItem.Value != "0")
            //{
            //    query += " AND emp_employments.emp_status_id=" + EmpStatusDDL.SelectedItem.Value;
            //    CriteriaLbl.Text += ", <b>Employment Status:</b>" + EmpStatusDDL.SelectedItem.Text;
            //}
            //if (CurrentStatusDDL.SelectedItem.Value != "0")
            //{
            //    query += " AND emp_employments.current_status=" + CurrentStatusDDL.SelectedItem.Value;
            //    CriteriaLbl.Text += ", <b>Current Status:</b>" + CurrentStatusDDL.SelectedItem.Text;
            //}
            //if (Province.SelectedItem.Value != "0")
            //{
            //    query += " AND system_users.perm_province=" + Province.SelectedItem.Value;
            //    CriteriaLbl.Text += ", <b>Province:</b>" + Province.SelectedItem.Text;

            //}
            //if (Designation.SelectedItem.Value != "0")
            //{
            //    query += " AND emp_employments.post_held=" + Designation.SelectedItem.Value;
            //    CriteriaLbl.Text += ", <b>Post:</b>" + Designation.SelectedItem.Text;
            //}
            //if (Branch.SelectedItem.Value != "0")
            //{
            //    query += " AND emp_employments.branch=" + Branch.SelectedItem.Value;
            //    CriteriaLbl.Text += ", <b>Branch:</b>" + Branch.SelectedItem.Text;
            //}
            //if (EmpPoolDDL.SelectedItem.Value != "0")
            //{
            //    query += " AND emp_employments.employee_pools_id=" + EmpPoolDDL.SelectedItem.Value;
            //    CriteriaLbl.Text += ", <b>Pool:</b>" + EmpPoolDDL.SelectedItem.Text;
            //}
            //query += " AND (basic_pay_scales.basic_pay_scales_id=emp_employments.basic_pay_scales_id)) order by basic_pay_scales.basic_pay_scales_id DESC";
            //List<EmpSearchList> EmpList = new QuestionBiz().SearchEmployee(query);
            //ListView1.DataSource = EmpList;
            //ListView1.DataBind();
        }
        protected void ClearSearch_Click(object sender, EventArgs e)
        {
            bindListView();
        }
    }
}