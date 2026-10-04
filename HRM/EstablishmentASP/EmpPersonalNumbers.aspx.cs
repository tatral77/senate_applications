using EstablishmentBIZ;
using EstablishmentENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstablishmentASP
{
    public partial class EmpPersonalNumbers : System.Web.UI.Page
    {

        protected void BindLv()
        {
            string query = null;
            query = "SELECT SYSTEM_USERS.SYSTEM_USERS_ID, SYSTEM_USERS.F_NAME, SYSTEM_USERS.M_NAME, SYSTEM_USERS.L_NAME,SYSTEM_USERS.NIC_NUMBER,SYSTEM_USERS.IMAGEURL, EMP_EMPLOYMENTS.POST_HELD,EMP_EMPLOYMENTS.PERSONAL_NO, EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID, EMP_EMPLOYMENTS.EMPLOYEE_POOLS_ID,EMP_EMPLOYMENTS.VENDOR_NUMBER, ";
            query += " BASIC_PAY_SCALES.DESCRIPTION AS BPS, POSTS.DESCRIPTION AS POST ";
            query += "FROM            SYSTEM_USERS INNER JOIN ";
            query += "EMP_EMPLOYMENTS ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_EMPLOYMENTS.SYSTEM_USERS_ID INNER JOIN ";
            query += "POSTS ON EMP_EMPLOYMENTS.POST_HELD = POSTS.POSTS_ID INNER JOIN ";
            query += " BASIC_PAY_SCALES ON EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID = BASIC_PAY_SCALES.BASIC_PAY_SCALES_ID ";
            query += " WHERE emp_employments.current_status=9 AND emp_employments.emp_status_id=1  ";
            query += " ORDER BY SYSTEM_USERS.F_NAME";
            List<PersonalNumbers> BranchesList = new EmployeeHandler().GetPersonalNumbers(query);
            EmpListView.DataSource = BranchesList;
            EmpListView.DataBind();

        }

        protected void Save_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < EmpListView.Items.Count(); i++)
            {
                PersonalNumbers personalnumber = new PersonalNumbers();
                HiddenField SystemUsersId = (HiddenField)EmpListView.Items[i].FindControl("SystemUsersId");
                TextBox PersonalNumber = (TextBox)EmpListView.Items[i].FindControl("PersonalNumberTxt");
                TextBox VendorNumberTxt = (TextBox)EmpListView.Items[i].FindControl("VendorNumberTxt");
                TextBox CNICTxt = (TextBox)EmpListView.Items[i].FindControl("CNICTxt");
                DropDownList EmployeePoolsIdDDL = (DropDownList)EmpListView.Items[i].FindControl("EmployeePoolsIdDDL");
                personalnumber.SystemUsersId = Convert.ToInt32(SystemUsersId.Value);
                personalnumber.PersonalNumber = Convert.ToString(PersonalNumber.Text);
                personalnumber.VendorNumber = Convert.ToString(VendorNumberTxt.Text);
                personalnumber.EmployeePoolsId = Convert.ToInt32(EmployeePoolsIdDDL.SelectedValue);
                personalnumber.CNIC= Convert.ToString(CNICTxt.Text);
                new EmployeeHandler().UpdatePersonalNumbers(personalnumber);

            }
            BindLv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindLv();
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
            if (!(String.IsNullOrEmpty(ExpFrom.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " DATEDIFF(yy,emp_employments.GOVT_SERVICE_START_DATE,GetDate())>=" + ExpFrom.Text;
                CriteriaLbl.Text += ",<b> Job Exerience from:</b>" + ExpFrom.Text;
            }
            if (!(String.IsNullOrEmpty(ExpTo.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " DATEDIFF(yy,emp_employments.GOVT_SERVICE_START_DATE,GetDate())<=" + ExpTo.Text;
                CriteriaLbl.Text += ",<b> Job Experience to:</b>" + ExpTo.Text;
            }
            if (!(String.IsNullOrEmpty(PeronalNoTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " EMP_EMPLOYMENTS.PERSONAL_NO=" + PeronalNoTxt.Text;
                CriteriaLbl.Text += ",<b> Personal Number:</b>" + PeronalNoTxt.Text;
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
            CriteriaLbl.Text = "";
            string query = null;
            query = "SELECT SYSTEM_USERS.SYSTEM_USERS_ID, SYSTEM_USERS.F_NAME, SYSTEM_USERS.M_NAME, SYSTEM_USERS.L_NAME,SYSTEM_USERS.ImageUrl,SYSTEM_USERS.NIC_NUMBER, EMP_EMPLOYMENTS.POST_HELD,EMP_EMPLOYMENTS.PERSONAL_NO, EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID,EMP_EMPLOYMENTS.EMPLOYEE_POOLS_ID,EMP_EMPLOYMENTS.VENDOR_NUMBER, ";
            query += " BASIC_PAY_SCALES.DESCRIPTION AS BPS, POSTS.DESCRIPTION AS POST ";
            query += "FROM            SYSTEM_USERS INNER JOIN ";
            query += "EMP_EMPLOYMENTS ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_EMPLOYMENTS.SYSTEM_USERS_ID INNER JOIN ";
            query += "POSTS ON EMP_EMPLOYMENTS.POST_HELD = POSTS.POSTS_ID INNER JOIN ";
            query += " BASIC_PAY_SCALES ON EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID = BASIC_PAY_SCALES.BASIC_PAY_SCALES_ID ";
            string criteria = GetCriteria();
            if (criteria != null)
            {
                CriteriaLbl.Text = "<b><u>REPORT BASED ON FOLLOWING PARAMETERS</u></b><br>" + CriteriaLbl.Text;
                query += " WHERE SYSTEM_USERS.IS_ACTIVE=1 AND ";
                query += criteria;
            }
            query += " ORDER BY SYSTEM_USERS.F_NAME";
            List<PersonalNumbers> BranchesList = new EmployeeHandler().GetPersonalNumbers(query);
            EmpListView.DataSource = BranchesList;
            EmpListView.DataBind();

        }
        protected void ClearSearch_Click(object sender, EventArgs e)
        {
            bindListView();
        }

        protected void EmpListView_ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList EmployeePoolsIdDDL = new DropDownList();
            EmployeePoolsIdDDL = (e.Item.FindControl("EmployeePoolsIdDDL") as DropDownList);
            if (EmployeePoolsIdDDL != null)
            {
                List<EmployeePools> EmpPools = new AdministrationBIZ().GetEmpPools();
                foreach (EmployeePools row in EmpPools)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.EmpPoolsId.ToString();
                    EmployeePoolsIdDDL.Items.Add(li);
                }
            }
        }

        protected void EmpListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            DropDownList EmployeePoolsIdDDL = e.Item.FindControl("EmployeePoolsIdDDL") as DropDownList;
            HiddenField HidEmployeePoolsId = (e.Item.FindControl("HidEmployeePoolsId") as HiddenField);
            EmployeePoolsIdDDL.SelectedValue = HidEmployeePoolsId.Value.ToString();
        }
    }
}