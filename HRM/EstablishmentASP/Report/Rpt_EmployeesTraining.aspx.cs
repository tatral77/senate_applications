using EstablishmentBIZ;
using EstablishmentENT;
using EstablishmentENT.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace EstablishmentASP.Reports
{
    public partial class Rpt_EmployeesTraining : System.Web.UI.Page
    {
        public IEnumerable<Rpt_EmployeesTraining> TraininsgAttended { get; private set; }
        string lastrec = "";
        int i = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // bindListView();
                bindFields();

            }
        }
        protected string AddGroupingRow()
        {
            string currentSemesterValue = Convert.ToString(Eval("EmployeeName"));
           
            if (currentSemesterValue != lastrec)
            {
                string labeldiv = "<div style='font-size:9pt;font-weight:bold;float:left;'>";
                string datadiv = "<div style='font-size:9pt;float:left;'>";
                 lastrec = currentSemesterValue;
                i++;
                string html = "<tr class='group'><td colspan=2 style='background-color:#DCDCDC' class='td-top-border'><b>" + i + " - <a href='TrainingsProfile.aspx?EmpId=" + Eval("EmpId") + "' style='color:black;'>" + Eval("EmployeeName") + "</a></b> " + Eval("POST") + " (" + Eval("BPS") + ")</td><td colspan='3' style='background-color:#DCDCDC' class='td-top-border'><div style='font-size:9pt;font-weight:bold;float:left;'> DOB:</div><div style='font-size:9pt;float:left;'>" + Convert.ToDateTime(Eval("DateOfBirth")).ToShortDateString() + "</div><div style='font-size:9pt;font-weight:bold;float:left;'>&nbsp&nbsp&nbspAge:</div><div style='font-size:9pt;float:left;'> " + Eval("Age") + " Years " + (Convert.ToInt32(Eval("AgeMonths"))!=0?Eval("AgeMonths") + " Months" :"") + "</div> </td><tr>";
                html = html + "<tr class=group>";
                html = html + "<td colspan=5>";
                html = html + labeldiv + "Govt Joining Date:</div> "+ datadiv + Convert.ToDateTime(Eval("GovtJoiningDate")).ToShortDateString() + "</div>";
                html = html + labeldiv  + "&nbsp&nbsp&nbspGovt Service Length:" + "</div>" + datadiv +  Eval("ServiceYears") + " Years " + (Convert.ToInt32(Eval("ServiceMonths")) != 0 ? Eval("ServiceMonths") + " Months" : "") + " </div>";
                html = html + labeldiv + "&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbspAppointment/Promotion in 17-19:</div> " + datadiv + Convert.ToDateTime(Eval("DateOfPromotion")).ToShortDateString() + "</div>";
                html = html + labeldiv + "&nbsp&nbsp&nbspService Length:" + "</div>" + datadiv + Eval("PromotionYears") + " Years " + (Convert.ToInt32(Eval("PromotionMonths")) != 0 ? Eval("PromotionMonths") + " Months" : "") + " </div>";
                html = html + "</td>";

                return String.Format(html);
                
            }
            else return String.Empty;
        }
        protected string AddNameAndAge(int EmployeeId)
        {
           
            string labeldiv = "<div style='font-size:9pt;font-weight:bold;text-wrap:none;'>";
            string datadiv = "<div style='font-size:9pt;'>";
            string currentSemesterValue = Convert.ToString(Eval("EmployeeName"));
            string html = null;
            if (currentSemesterValue != lastrec)
            {
               // int EmployeeId = Convert.ToInt32(Eval("SystemUsersId"));
                Probation prob = new EmployeeHandler().GetEmployeeProbationStatus(EmployeeId);
                string probation = "Not on Probation";
                if (prob != null)
                {
                    probation = "On Probation from " + Convert.ToDateTime(prob.ProbationFrom).ToShortDateString() + " to " + Convert.ToDateTime(prob.ProbationTo).ToShortDateString();
                }
                // html = "<td style='font-size:10pt'>" + i.ToString() + "</td>";
                i++;
                lastrec = currentSemesterValue;
                string ageMonths = Convert.ToInt32(Eval("AgeMonths")) != 0 ? " " + Eval("AgeMonths") + " Months" : "";
                string serviceMonths = Convert.ToInt32(Eval("ServiceMonths")) != 0 ? " " + Eval("ServiceMonths") + " Months" : "";
                string promotionMonths = Convert.ToInt32(Eval("PromotionMonths")) != 0 ? " " + Eval("PromotionMonths") + " Months" : "";
                string k = "<span class='k'>";

                html = "<td class='emp-cell'><div class='emp-name'>" + Eval("EmployeeName").ToString() + "</div><div>" + Eval("POST").ToString() + " (" + Eval("BPS").ToString() + ")</div>";
                if (Convert.ToDateTime(Eval("DateOfBirth")) > Convert.ToDateTime("01/01/1900"))
                    html = html + "<div>" + k + "DOB:</span> " + Convert.ToDateTime(Eval("DateOfBirth")).ToShortDateString() + " (" + Eval("Age") + " Years" + ageMonths + ")</div>";
                html = html + "</td>";

                html = html + "<td class='emp-cell'><div>" + k + "Govt Joining Date:</span> " + Convert.ToDateTime(Eval("GovtJoiningDate")).ToShortDateString() + "</div>";
                html = html + "<div>" + k + "Govt Service Length:</span> " + Eval("ServiceYears") + " Years" + serviceMonths + "</div></td>";

                html = html + "<td class='emp-cell'><div>" + k + "Apptt/Prom in " + Eval("Bps") + ":</span> " + Convert.ToDateTime(Eval("DateOfPromotion")).ToShortDateString() + "</div>";
                html = html + "<div>" + k + "Service Length:</span> " + Eval("PromotionYears") + " Years" + promotionMonths + "</div></td>";

                html = html + "<td class='emp-cell'><div>" + k + "Probation Status:</span> " + probation + "</div></td>";

            }
            //else
            //{
            //    html = html + "<td></td><td></td><td></td>";
            //}
         
            return html;
        }
        protected string AddServiceDetail()
        {
            string currentSemesterValue = Convert.ToString(Eval("EmployeeName"));
            string html = null;
            //if (currentSemesterValue != lastrec)
            //{
               
                lastrec = currentSemesterValue;
                i++;
               
            //}
            return html;
           
        }
        protected string AddPromotionDetail()
        {
            string currentSemesterValue = Convert.ToString(Eval("EmployeeName"));
            string html = null;
            //if (currentSemesterValue != lastrec)
           // {
                string labeldiv = "<div style='font-size:9pt;font-weight:bold;float:left;'>";
                string datadiv = "<div style='font-size:9pt;float:left;'>";
                lastrec = currentSemesterValue;
                i++;
               
           // }
            return html;
        }

        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }
        private void bindListView()
        {
            string query = null;
            string CurrentDate = DateTime.Now.ToShortDateString();
            //query = "SELECT EMP_COURSES.EMP_COURSES_ID, EMP_COURSES.COURSE_NAME, EMP_COURSES.COURSE_TYPES_ID, EMP_COURSES.MANDATORY, EMP_COURSES.INSTITUTION, EMP_COURSES.FROM_DATE,  ";
            //query += " EMP_COURSES.TO_DATE, EMP_COURSES.SYSTEM_USERS_ID, EMP_COURSES.IS_FOREIGN, EMP_COURSES.CITIES_ID, EMP_COURSES.COUNTRIES_ID, EMP_COURSES.SPONSORED_BY,  ";
            //query += "  EMP_COURSES.DEGREE_DIPLOMA_CERT";
            //query += " FROM EMP_COURSES INNER JOIN ";
            //query += " CITIES ON EMP_COURSES.CITIES_ID = CITIES.CITIES_ID INNER JOIN";
            //query += " COUNTRIES ON EMP_COURSES.COUNTRIES_ID = COUNTRIES.COUNTRIES_ID";
            query = "SELECT EMP_COURSES.EMP_COURSES_ID, EMP_COURSES.COURSE_NAME, EMP_COURSES.COURSE_TYPES_ID, EMP_COURSES.MANDATORY, EMP_COURSES.INSTITUTION, EMP_COURSES.FROM_DATE,  ";
            query += " EMP_COURSES.TO_DATE, EMP_COURSES.SYSTEM_USERS_ID, EMP_COURSES.IS_FOREIGN, EMP_COURSES.CITIES_ID, EMP_COURSES.COUNTRIES_ID, EMP_COURSES.SPONSORED_BY,  ";
            query += " EMP_COURSES.DEGREE_DIPLOMA_CERT, POSTS.DESCRIPTION AS POST, BASIC_PAY_SCALES.DESCRIPTION AS BPS, SYSTEM_USERS.F_NAME ";
            query += " FROM            EMP_COURSES INNER JOIN ";
            query += " CITIES ON EMP_COURSES.CITIES_ID = CITIES.CITIES_ID INNER JOIN ";
            query += " COUNTRIES ON EMP_COURSES.COUNTRIES_ID = COUNTRIES.COUNTRIES_ID INNER JOIN ";
            query += " SYSTEM_USERS ON EMP_COURSES.SYSTEM_USERS_ID = SYSTEM_USERS.SYSTEM_USERS_ID INNER JOIN ";
            query += " EMP_EMPLOYMENTS ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_EMPLOYMENTS.SYSTEM_USERS_ID INNER JOIN ";
            query += " BASIC_PAY_SCALES ON EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID = BASIC_PAY_SCALES.BASIC_PAY_SCALES_ID INNER JOIN ";
            query += " POSTS ON EMP_EMPLOYMENTS.POST_HELD = POSTS.POSTS_ID ";
            List<RptEmployeesTraining> EmpList = new ReportsBIZ().GetEmployeesTraining(query);
            if (EmpList != null)
            {
                foreach (RptEmployeesTraining et in EmpList)
                {
                    EmpProfile ep = new EmpProfile();
                    ep = new EmployeeHandler().GetOnePage(et.SystemUsersId);
                    et.DateOfBirth = ep.Dob;
                    Duration duration = new DateTimeUtils().GetDuration(ep.Dob, DateTime.Now);
                    et.Age = duration.Years;
                    et.AgeMonths = duration.Months;
                    et.GovtJoiningDate = ep.GovtServiceStartDate;
                    duration = new DateTimeUtils().GetDuration(ep.GovtServiceStartDate, DateTime.Now);
                    et.ServiceYears = duration.Years;
                    et.ServiceMonths = duration.Months;
                    PromotionHistory promotion = new EmployeeHandler().GetCurrentPromotion(et.SystemUsersId);
                    if (promotion != null)
                    {
                        et.DateOfPromotion = promotion.PromotionDate;
                        duration = new DateTimeUtils().GetDuration(et.DateOfPromotion, DateTime.Now);
                        et.PromotionYears = duration.Years;
                        et.PromotionMonths = duration.Months;
                    }
                }
            }
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

            if (!(String.IsNullOrEmpty(TrainingsAttendedTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " EMP_COURSES.COURSE_NAME like '%" + TrainingsAttendedTxt.Text + "%'";
                CriteriaLbl.Text += ", <b>Training Attended:</b>" + TrainingsAttendedTxt.Text;

            }
            if (!(String.IsNullOrEmpty(TrainingInstituteTxt.Text)))
            {
                if (query != "")
                    query += " AND ";
                query += " EMP_COURSES.INSTITUTION like '%" + TrainingInstituteTxt.Text + "%'";
                CriteriaLbl.Text += ", <b>Trainings Institutet:</b>" + TrainingInstituteTxt.Text;

            }
            if (Mandatory.Checked==true)
            {
                if (query != "")
                    query += " AND ";
                query += "(EMP_COURSES.MANDATORY=1)";
            }
            if (Foreign.Checked == true)
            {
                if (query != "")
                    query += " AND ";
                query += "(EMP_COURSES.COUNTRIES_ID<>131)";
            }
            //if (!(String.IsNullOrEmpty(DateToTxt.Text)))
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += "(EMP_LEAVES.START_DATE <= CONVERT(DATETIME, '" + DateToTxt.Text + "', 104)) AND (EMP_LEAVES.END_DATE >= CONVERT(DATETIME, '" + DateToTxt.Text + "', 104))";
            //    CriteriaLbl.Text += ", <b>On Date:</b>" + DateToTxt.Text;

            //}
           // if (query != "")
           //     query += " AND ";
           //query += " AND (SYSTEM_USERS.IS_EMPLOYEE = 1)";
            //query += " AND (SYSTEM_USERS.IS_EMPLOYEE = 1)";

            return query;

        }

        protected void Search_Click(object sender, EventArgs e)
        {
            CriteriaLbl.Text = "";
            string query = null;
            query = "SELECT EMP_COURSES.EMP_COURSES_ID, EMP_COURSES.COURSE_NAME, EMP_COURSES.COURSE_TYPES_ID, EMP_COURSES.MANDATORY, EMP_COURSES.INSTITUTION, EMP_COURSES.FROM_DATE,  ";
            query += " EMP_COURSES.TO_DATE, EMP_COURSES.SYSTEM_USERS_ID, EMP_COURSES.IS_FOREIGN, EMP_COURSES.CITIES_ID, EMP_COURSES.COUNTRIES_ID, EMP_COURSES.SPONSORED_BY,  ";
            query += " EMP_COURSES.DEGREE_DIPLOMA_CERT, POSTS.DESCRIPTION AS POST, BASIC_PAY_SCALES.DESCRIPTION AS BPS, SYSTEM_USERS.F_NAME ";
            query += " FROM            EMP_COURSES INNER JOIN ";
            query += " CITIES ON EMP_COURSES.CITIES_ID = CITIES.CITIES_ID INNER JOIN ";
            query += " COUNTRIES ON EMP_COURSES.COUNTRIES_ID = COUNTRIES.COUNTRIES_ID INNER JOIN ";
            query += " SYSTEM_USERS ON EMP_COURSES.SYSTEM_USERS_ID = SYSTEM_USERS.SYSTEM_USERS_ID INNER JOIN ";
            query += " EMP_EMPLOYMENTS ON SYSTEM_USERS.SYSTEM_USERS_ID = EMP_EMPLOYMENTS.SYSTEM_USERS_ID INNER JOIN ";
            query += " BASIC_PAY_SCALES ON EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID = BASIC_PAY_SCALES.BASIC_PAY_SCALES_ID INNER JOIN ";
            query += " POSTS ON EMP_EMPLOYMENTS.POST_HELD = POSTS.POSTS_ID ";
            string Criteria = GetCriteria();
            if (!(String.IsNullOrEmpty(Criteria)))
                query += " WHERE "+ Criteria;
             query+= " ORDER BY EMP_EMPLOYMENTS.BASIC_PAY_SCALES_ID DESC,SYSTEM_USERS.F_NAME,EMP_COURSES.FROM_DATE DESC";
            List<RptEmployeesTraining> EmpList = new ReportsBIZ().GetEmployeesTraining(query);
           
            EmpListView.DataSource = EmpList;
            EmpListView.DataBind();
        }
        protected void ClearSearch_Click(object sender, EventArgs e)
        {
            bindListView();
        }
       
    }
}