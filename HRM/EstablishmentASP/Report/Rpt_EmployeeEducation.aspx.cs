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
    public partial class Rpt_EmployeeEducation : System.Web.UI.Page
    {
        public IEnumerable<Rpt_EmployeesTraining> TraininsgAttended { get; private set; }
        string lastrec = "";
        int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindListView();
                bindFields();

            }
        }
        protected string AddGroupingRow()
        {
            string currentSemesterValue = Convert.ToString(Eval("EmployeeName"));

            if (currentSemesterValue != lastrec)
            {
                lastrec = currentSemesterValue;
                i++;
                return String.Format("<tr class=group><td colspan=11><b>" + i + " - <a href='TrainingsProfile.aspx?EmpId=" + Eval("EmpId") + "' style='color: black;'>" + Eval("EmployeeName") + "</a></b> " + Eval("POST") + " (" + Eval("BPS") + ")</td></tr>");

            }
            else return String.Empty;
        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }
        private void bindListView()
        {
            string query = null;
            string CurrentDate = DateTime.Now.ToShortDateString();
            query = "SELECT POSTS.DESCRIPTION AS POST, BASIC_PAY_SCALES.DESCRIPTION AS BPS, SYSTEM_USERS.F_NAME, COUNTRIES.DESCRIPTION AS COUNTRY, EDUCATION_LEVEL.DESCRIPTION AS EDUCATION_LEVEL, EMP_QUALIFICATION.INSTITUTION_NAME, ";
            query+= " EMP_QUALIFICATION.DEGREE_OBTAINED,EMP_QUALIFICATION.SUBJECTS, EMP_QUALIFICATION.COMPLETION_YEAR, EMP_QUALIFICATION.GRADE, EMP_QUALIFICATION.CGPA, EMP_QUALIFICATION.PERCENTAGE, EMP_QUALIFICATION.DIVISION ";
            query += " FROM            EMP_EMPLOYMENTS INNER JOIN ";
            query += " SYSTEM_USERS ON EMP_EMPLOYMENTS.SYSTEM_USERS_ID = SYSTEM_USERS.SYSTEM_USERS_ID INNER JOIN ";
            query += " BASIC_PAY_SCALES ON EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID = BASIC_PAY_SCALES.BASIC_PAY_SCALES_ID INNER JOIN ";
            query += " POSTS ON EMP_EMPLOYMENTS.POST_HELD = POSTS.POSTS_ID INNER JOIN ";
            query += " EMP_QUALIFICATION ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_QUALIFICATION.SYSTEM_USERS_ID INNER JOIN ";
            query += " COUNTRIES ON EMP_QUALIFICATION.COUNTRY_ID = COUNTRIES.COUNTRIES_ID INNER JOIN ";
            query += " EDUCATION_LEVEL ON EMP_QUALIFICATION.DEGREE_LEVEL_ID = EDUCATION_LEVEL.EDUCATION_LEVEL_ID ";
            query += " ORDER BY EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID DESC,SYSTEM_USERS.F_NAME,EMP_QUALIFICATION.DEGREE_LEVEL_ID DESC";
            List<RptEmployeeEducation> EmpList = new ReportsBIZ().GetEmployeesEducation(query);
            EmpListView.DataSource = EmpList;
            EmpListView.DataBind();

        }
        private void bindFields()
        {
            DateTxt.Text = DateTime.Now.ToShortDateString();
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
            //CurrentStatusDDL.SelectedValue = "9";
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


            // List<EmpCourses> TrainingsAttended = new ReportsBIZ().GetEmployeesTraining();
            //TrainingsAttendedTxt.Items.Add(new ListItem("Select", "0"));
            //foreach (EmpCourses row in TrainingsAttended)
            //    {
            //        ListItem ty = new ListItem();
            //        ty.Value = row.CourseName.ToString();
            //        ty.Text = row.CourseName.ToString();
            //    //TrainingsAttendedTxt.Items.Add(ty);
            //    }

            //List<EmpCourses> TrainingInstitute = new AdministrationBIZ().GetEmployeesTraining();
            ////TrainingInstituteTxt.Items.Add(new ListItem("Select", "0"));
            //foreach (EmpCourses row in TrainingInstitute)
            //{
            //    ListItem ty = new ListItem();
            //    ty.Value = row.InstitutionName.ToString();
            //    ty.Text = row.InstitutionName.ToString();
            //   // TrainingInstituteTxt.Items.Add(ty);
            //}

            //    List<EmpCourses> TrainingField = new AdministrationBIZ().GetEmployeesTraining();
            ////TrainingFieldTxt.Items.Add(new ListItem("Select", "0"));
            //foreach (EmpCourses row in TrainingField)
            //{
            //    ListItem ty = new ListItem();
            //    ty.Value = row.ToString();
            //    ty.Text = row.TrainingFieldTxt.ToString();
            //    //TrainingFieldTxt.Items.Add(ty);
            //}
            //   List<EmpCourses> TrainingStation = new AdministrationBIZ().GetEmployeesTraining();
            //TrainingStationTxt.Items.Add(new ListItem("Select", "0"));
            //foreach (EmpCourses row in TrainingStation)
            //   {
            //     ListItem ty = new ListItem();
            //     ty.Value = row.CityId.ToString();
            //     ty.Text = row.CityId.ToString();
            //     //TrainingStationTxt.Items.Add(ty);
            //   }
            List<DegreeLevel> dl = new AdministrationBIZ().GetDegreeLevels();
            foreach (DegreeLevel row in dl)
            {
                ListItem li = new ListItem();
                li.Text = row.Degree_Level;
                li.Value = row.Degree_Level_Id.ToString();
                EducationLevelDDL.Items.Add(li);
            }


        }
        protected string  GetResult(string result)
        {
            if((String.Compare(result,"0.0")==0) || (String.Compare(result, "0") == 0) || (String.Compare(result, "Not Applicable") == 0 ))
                return "";
            else
                return result;
        }

        protected string GetCriteria()
        {
            CriteriaLbl.Text = "";
            string query =" (SYSTEM_USERS.IS_EMPLOYEE = 1)"; ;
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
            // return query;
            //////////////////////////////////////////////////////// REPORT SPECIFIC/////////////////////////////////////////////

            if (EducationLevelDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " EMP_QUALIFICATION.DEGREE_LEVEL_ID=" + EducationLevelDDL.SelectedValue  ;
                CriteriaLbl.Text += ", <b>Education Level:</b>" + EducationLevelDDL.SelectedItem.Text;

            }
            if (!(String.IsNullOrEmpty(DisciplineTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " EMP_QUALIFICATION.DEGREE_OBTAINED like '%" + DisciplineTxt.Text + "%'";
                CriteriaLbl.Text += ", <b>Discipline:</b>" + DisciplineTxt.Text;

            }
            if (!(String.IsNullOrEmpty(InstitutionTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " EMP_QUALIFICATION.INSTITUTION_NAME like '%" + InstitutionTxt.Text + "%'";
                CriteriaLbl.Text += ", <b>Institution:</b>" + InstitutionTxt.Text;

            }
            if (!(String.IsNullOrEmpty(SubjectsTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " EMP_QUALIFICATION.SUBJECTS like '%" + SubjectsTxt.Text + "%'";
                CriteriaLbl.Text += ", <b>Subjects:</b>" + SubjectsTxt.Text;

            }

            if (Foreign.Checked == true)
            {
                if (query != "")
                    query += " AND ";
                query += "(EMP_QUALIFICATION.COUNTRY_ID<>131)";
            }
            //if (!(String.IsNullOrEmpty(DateToTxt.Text)))
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += "(EMP_LEAVES.START_DATE <= CONVERT(DATETIME, '" + DateToTxt.Text + "', 104)) AND (EMP_LEAVES.END_DATE >= CONVERT(DATETIME, '" + DateToTxt.Text + "', 104))";
            //    CriteriaLbl.Text += ", <b>On Date:</b>" + DateToTxt.Text;

            //}
          
          

            return query;

        }

        protected void Search_Click(object sender, EventArgs e)
        {
            CriteriaLbl.Text = "";
            string query = null;
            query = "SELECT POSTS.DESCRIPTION AS POST, BASIC_PAY_SCALES.DESCRIPTION AS BPS, SYSTEM_USERS.F_NAME, COUNTRIES.DESCRIPTION AS COUNTRY, EDUCATION_LEVEL.DESCRIPTION AS EDUCATION_LEVEL, EMP_QUALIFICATION.INSTITUTION_NAME, ";
            query += " EMP_QUALIFICATION.DEGREE_OBTAINED,EMP_QUALIFICATION.SUBJECTS, EMP_QUALIFICATION.COMPLETION_YEAR, EMP_QUALIFICATION.GRADE, EMP_QUALIFICATION.CGPA, EMP_QUALIFICATION.PERCENTAGE, EMP_QUALIFICATION.DIVISION ";
            query += " FROM            EMP_EMPLOYMENTS INNER JOIN ";
            query += " SYSTEM_USERS ON EMP_EMPLOYMENTS.SYSTEM_USERS_ID = SYSTEM_USERS.SYSTEM_USERS_ID INNER JOIN ";
            query += " BASIC_PAY_SCALES ON EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID = BASIC_PAY_SCALES.BASIC_PAY_SCALES_ID INNER JOIN ";
            query += " POSTS ON EMP_EMPLOYMENTS.POST_HELD = POSTS.POSTS_ID INNER JOIN ";
            query += " EMP_QUALIFICATION ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_QUALIFICATION.SYSTEM_USERS_ID INNER JOIN ";
            query += " COUNTRIES ON EMP_QUALIFICATION.COUNTRY_ID = COUNTRIES.COUNTRIES_ID INNER JOIN ";
            query += " EDUCATION_LEVEL ON EMP_QUALIFICATION.DEGREE_LEVEL_ID = EDUCATION_LEVEL.EDUCATION_LEVEL_ID ";
            string Criteria = GetCriteria();
            if (!(String.IsNullOrEmpty(Criteria)))
                query += " WHERE " + Criteria;
            query += " ORDER BY EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID DESC,SYSTEM_USERS.F_NAME,EMP_QUALIFICATION.DEGREE_LEVEL_ID DESC";
            List<RptEmployeeEducation> EmpList = new ReportsBIZ().GetEmployeesEducation(query);
            EmpListView.DataSource = EmpList;
            EmpListView.DataBind();
        }
        protected void ClearSearch_Click(object sender, EventArgs e)
        {
            bindListView();
        }
    }
}