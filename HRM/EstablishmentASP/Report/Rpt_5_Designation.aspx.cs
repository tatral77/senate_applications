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
    public partial class Rpt_5_Designation : System.Web.UI.Page
    {
        string lastrec = "";
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
        protected string AddGroupingRow()
        {
            string currentSemesterValue = Convert.ToString(Eval("EmployeeName"));
            if (currentSemesterValue != lastrec)
            {
                lastrec = currentSemesterValue;
                return String.Format("<tr class=group><td colspan=5><b>" + Eval("EmployeeName") + "</b></td></tr>");

            }
            else return String.Empty;
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
           // CurrentStatusDDL.SelectedValue = "9";
            List<EmpStatus> ps = new AdministrationBIZ().GetEmpStatusList();
            foreach (EmpStatus row in ps)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.EmpStatusId.ToString();
                EmpStatusDDL.Items.Add(li);
            }
            //EmpStatusDDL.SelectedValue = "1";
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
                query += " emp_employments.emp_status_id=" + EmpStatusDDL.SelectedItem.Value;

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
                query += "EMP_PROMOTION_HIST.post=" + Designation.SelectedItem.Value;

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
                query += " emp_employments.current_status=" + CurrentStatusDDL.SelectedItem.Value;

            }
            if (!(String.IsNullOrEmpty(DateFromTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += "  (EMP_PROMOTION_HIST.DATED <= (SELECT TOP(1) DATED FROM EMP_PROMOTION_HIST WHERE(DATED <= CONVERT(datetime, '" + DateFromTxt.Text + "', 103)) ORDER BY DATED DESC) )";
            }
            //if (!(String.IsNullOrEmpty(DateToTxt.Text)))
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " (EMP_PROMOTION_HIST.DATED <= (SELECT TOP(1) DATED FROM EMP_PROMOTION_HIST WHERE DATED>=CONVERT(datetime,'" + DateToTxt.Text + "' , 103))) ";
            //}
            return query;

        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }
        public string GetExperience(int years,int months)
        {
            string y="", m="";
            if(years!=0)
            {
                y = years + " Years ";
            }
            if(months!=0)
            {
                m = months + " Months";
            }
            return y + m;
        }

        protected void ClearSearch_Click(object sender, EventArgs e)
        {
            //bindListView();
        }
        protected void Search_Click(object sender, EventArgs e)
        {

            string query = null;
            string criteria = null;
            query = " SELECT SYSTEM_USERS.SYSTEM_USERS_ID,SYSTEM_USERS.F_NAME, POSTS.DESCRIPTION AS POST, BASIC_PAY_SCALES.DESCRIPTION AS BPS, EMP_PROMOTION_HIST.DATED ";
            query += " FROM EMP_PROMOTION_HIST INNER JOIN ";
            query += " BASIC_PAY_SCALES ON EMP_PROMOTION_HIST.BASIC_PAY_SCALES_ID = BASIC_PAY_SCALES.BASIC_PAY_SCALES_ID INNER JOIN ";
            query += " POSTS ON EMP_PROMOTION_HIST.POST = POSTS.POSTS_ID INNER JOIN ";
            query += " SYSTEM_USERS ON EMP_PROMOTION_HIST.SYSTEM_USERS_ID = SYSTEM_USERS.SYSTEM_USERS_ID  INNER JOIN";
            query += " emp_employments ON SYSTEM_USERS.SYSTEM_USERS_ID = emp_employments.SYSTEM_USERS_ID ";
            criteria = GetCriteria();
            if (criteria != null)
            {
                query += " WHERE SYSTEM_USERS.IS_ACTIVE=1 AND ";
                query += criteria;
            }
            query += " ORDER BY EMP_PROMOTION_HIST.SYSTEM_USERS_ID , EMP_PROMOTION_HIST.BASIC_PAY_SCALES_ID DESC, DATED DESC";
            List<ReportEntity> EmpList = new ReportsBIZ().Get_05_Designation(query);
            var res = from element in EmpList
                      group element by element.SystemUsersId
                  into groups
                      select groups.OrderBy(p => p.EmployeeName).First();
            EmpListView.DataSource = res;
            EmpListView.DataBind();


        }

    }
}