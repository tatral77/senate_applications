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
    public partial class Rpt_NOC_Issued : System.Web.UI.Page
    {
        int lastrec = 0;
        int counter = 0;
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
            //string query = null;
            //query += "SELECT EMP_OTHER_CHARGES.EMP_OTHER_CHARGE_ID, EMP_OTHER_CHARGES.SYSTEM_USERS_ID, EMP_OTHER_CHARGES.OTHER_CHARGE_TYPE_ID, EMP_OTHER_CHARGES.POSTS_ID, EMP_OTHER_CHARGES.BPS_ID, ";
            //query += "EMP_OTHER_CHARGES.BRANCH_ID, EMP_OTHER_CHARGES.FROM_DATE, EMP_OTHER_CHARGES.TO_DATE, EMP_OTHER_CHARGES.REMARKS, EMP_OTHER_CHARGE_TYPES.EMP_OTHER_CHARGE_TYPE, ";
            //query += "SYSTEM_USERS.F_NAME, BASIC_PAY_SCALES.DESCRIPTION AS BPS, BRANCHES.DESCRIPTION AS BRANCH, POSTS.DESCRIPTION AS POST ";
            //query += "FROM            EMP_OTHER_CHARGES INNER JOIN ";
            //query += "EMP_OTHER_CHARGE_TYPES ON EMP_OTHER_CHARGES.OTHER_CHARGE_TYPE_ID = EMP_OTHER_CHARGE_TYPES.EMP_OTHER_CHARGE_TYPE_ID INNER JOIN ";
            //query += "SYSTEM_USERS ON EMP_OTHER_CHARGES.SYSTEM_USERS_ID = SYSTEM_USERS.SYSTEM_USERS_ID INNER JOIN ";
            //query += "POSTS ON EMP_OTHER_CHARGES.POSTS_ID = POSTS.POSTS_ID INNER JOIN ";
            //query += "BRANCHES ON EMP_OTHER_CHARGES.BRANCH_ID = BRANCHES.BRANCHES_ID INNER JOIN ";
            //query += "BASIC_PAY_SCALES ON EMP_OTHER_CHARGES.BPS_ID = BASIC_PAY_SCALES.BASIC_PAY_SCALES_ID ";
            //query += "ORDER BY EMP_OTHER_CHARGES.SYSTEM_USERS_ID, EMP_OTHER_CHARGES.FROM_DATE DESC ";
            //List<RptOtherCharges> EmpList = new ReportsBIZ().RptGetOtherCharges(query);
            //EmpListView.DataSource = EmpList;
            //EmpListView.DataBind();

        }

        protected string AddGroupingRow()
        {
            int currentSemesterValue = Convert.ToInt32(Eval("System_Users_Id"));
            if (currentSemesterValue != lastrec)
            {
                lastrec = currentSemesterValue;
                return String.Format("<tr class=group><td colspan=4><b>" + Eval("EmpName") + "</b> (" + Eval("Post") + "-"+ Eval("Bps") + ") </td></tr>");

            }
            else return String.Empty;
        }
        protected string GetCounter(int SystemUsersId)
        {
            if (SystemUsersId != lastrec)
            {
                lastrec = SystemUsersId;
                counter = 1;
                return Convert.ToString(counter);

            }
            else
            {
                counter++;
                return Convert.ToString(counter);
            }
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

            NOCTypeDDL.Items.Add(new ListItem("Select", "0"));
            List<NOCTypes> pt = new AdministrationBIZ().GetNOCTypes();

            foreach (NOCTypes row in pt)
            {
                ListItem cy = new ListItem();
                cy.Value = row.NocTypeId.ToString();
                cy.Text = row.Description.ToString();
                NOCTypeDDL.Items.Add(cy);
            }
            List<Post> posts = new AdministrationBIZ().GetActivePosts();
            foreach (Post row in posts)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.PostID.ToString();
                Designation.Items.Add(li);
            }
            List<CurrentStatuses> pt1 = new AdministrationBIZ().GetCurrentStatuses();

            foreach (CurrentStatuses row in pt1)
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
          //  EmpStatusDDL.SelectedValue = "1";
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
        protected void GetHeader()
        {
            if (NOCTypeDDL.SelectedItem.Value != "0")
            {
                lblHeader.Text = " ( " + NOCTypeDDL.SelectedItem.Text.ToUpper() + " ) ";
            }
            else
                lblHeader.Text = " ( All Types of NOCs ) ";
        }
        protected string GetHeading()
        {
            if (EmpStatusDDL.SelectedItem.Text == "Contract")
            {
                return "<th>Contract Type</th>";
            }
            else
                return null;
        }
        //protected Control GetFields()
        //{
        //    Label lbl = new Label();
        //    lbl.ID = "abc";
        //    lbl.Text = "<%#Eval(\"Quota\")%>";
        //    lbl.Attributes.Add("class", "table-data");
        //    TableRow ts = new TableRow();
        //    ts.Controls.Add(lbl);
        //    if (EmpStatusDDL.SelectedItem.Text == "Contract")
        //    {
        //        return ts;
        //    }
        //    else
        //        return null;
        //}



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
                query += " emp_employments.current_status=" + CurrentStatusDDL.SelectedItem.Value;

            }
            if (NOCTypeDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " EMP_NOC_ISSUED.EMP_NOC_TYPES_ID=" + NOCTypeDDL.SelectedItem.Value;

            }
            if (!(String.IsNullOrEmpty(DateFromTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " NOC_DATE>= CONVERT(datetime,'" + DateFromTxt.Text + "' , 103)";
            }
            if (!(String.IsNullOrEmpty(DateToTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " NOC_DATE<= CONVERT(datetime,'" + DateToTxt.Text + "' , 103)";
            }
            if (!(String.IsNullOrEmpty(RemarksTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " EMP_NOC_ISSUED.REMARKS like '%" + RemarksTxt.Text + "%'";

            }
            return query;

        }
        protected void Search_Click(object sender, EventArgs e)
        {

            string query = null;
            string criteria = null;
            query += "SELECT EMP_NOC_ISSUED.SYSTEM_USERS_ID, EMP_NOC_ISSUED.NOC_DATE, EMP_NOC_TYPES.DESCRIPTION, SYSTEM_USERS.F_NAME, SYSTEM_USERS.M_NAME, SYSTEM_USERS.L_NAME, EMP_NOC_ISSUED.REMARKS, ";
            query += "POSTS.DESCRIPTION AS POST, BASIC_PAY_SCALES.DESCRIPTION AS BPS ";
            query += "FROM            BASIC_PAY_SCALES INNER JOIN ";
            query += "EMP_NOC_ISSUED INNER JOIN ";
            query += "SYSTEM_USERS ON EMP_NOC_ISSUED.SYSTEM_USERS_ID = SYSTEM_USERS.SYSTEM_USERS_ID INNER JOIN ";
            query += "EMP_NOC_TYPES ON EMP_NOC_ISSUED.EMP_NOC_TYPES_ID = EMP_NOC_TYPES.NOC_TYPES_ID INNER JOIN ";
            query += "EMP_EMPLOYMENTS ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_EMPLOYMENTS.SYSTEM_USERS_ID ON BASIC_PAY_SCALES.BASIC_PAY_SCALES_ID = EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID INNER JOIN ";
            query += "POSTS ON EMP_EMPLOYMENTS.POST_HELD = POSTS.POSTS_ID ";
            criteria = GetCriteria();
            if (!String.IsNullOrEmpty(criteria))
            {
                query += " WHERE SYSTEM_USERS.IS_ACTIVE=1 AND ";
                query += criteria;
            }
            query += " ORDER BY SYSTEM_USERS.F_NAME, NOC_DATE DESC";
            List<Rpt_NOC> EmpList = new ReportsBIZ().RptGetNOC(query);
            EmpListView.DataSource = EmpList;
            EmpListView.DataBind();
            GetHeader();

        }

        protected void ClearSearch_Click(object sender, EventArgs e)
        {
            bindListView();
        }
        public string GetDate(DateTime date)
        {
            return (date < Convert.ToDateTime("01/01/1900")) ? string.Empty : date.ToShortDateString();
        }
      
    }
}