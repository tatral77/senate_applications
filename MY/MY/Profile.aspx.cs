using EstablishmentBIZ;
using EstablishmentENT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using Utilities;

namespace MY
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            int empval;
            if (reqCookies == null || !int.TryParse(reqCookies["SystemUsersId"], out empval))
            {
                ErrLbl.Text = "Your employee record could not be found. Please sign in again.";
                return;
            }
            if (IsPostBack)
                return;
            bindPersonalInfo(empval);
            bindQualificationLv(empval);
            bindSummary(empval);
        }

        // headline details (post, branch, status) and the four summary tiles
        private void bindSummary(int empval)
        {
            try
            {
                DateTime floor = new DateTime(1900, 1, 1);
                EmpProfile ep = new EmployeeHandler().GetOnePage(empval);
                if (ep == null)
                    return;
                if (!String.IsNullOrEmpty(ep.CurrentDesignation))
                    HeroPost.Text = ep.CurrentDesignation + (String.IsNullOrEmpty(ep.CurrentBPS) ? "" : " (BPS-" + ep.CurrentBPS.Replace("BPS-", "").Replace("BPS", "").Trim() + ")");
                else
                    HeroPost.Text = "Post and BPS not mentioned";
                HeroBranch.Text = ep.CurrentBranch;
                HeroStatus.Text = ep.EmployeeStatus;
                HeroCnic.Text = String.IsNullOrEmpty(ep.Cnic) ? "" : "CNIC " + ep.Cnic;

                if (ep.Dob > floor && ep.Age < 100)
                    StatAge.Text = ep.Age + " years";
                DateTime serviceEnd = new EmploymentBIZ().GetServiceEndDate(empval);
                if (ep.SenateServiceStartDate > floor)
                {
                    Duration d = new DateTimeUtils().GetDuration(ep.SenateServiceStartDate, serviceEnd);
                    StatSenate.Text = d.Years + " yrs " + d.Months + " mos";
                }
                if (ep.GovtServiceStartDate > floor)
                {
                    Duration d = new DateTimeUtils().GetDuration(ep.GovtServiceStartDate, serviceEnd);
                    StatGovt.Text = d.Years + " yrs " + d.Months + " mos";
                }
                if (ep.Dob > floor && ep.SuperanuationDate > floor)
                    StatSuper.Text = ep.SuperanuationDate.ToString("dd/MM/yyyy");

                SheetLit.Text = BuildSheet(new string[][]
                {
                    new[] { "Name", (title.Text + " " + EmpNametxt.Text).Trim() },
                    new[] { "Designation", HeroPost.Text },
                    new[] { "Branch", ep.CurrentBranch },
                    new[] { "Employee Status", ep.EmployeeStatus },
                    new[] { "Age", StatAge.Text },
                    new[] { "Date of Birth", DOB.Text },
                    new[] { "Service in Senate", StatSenate.Text },
                    new[] { "Total Govt Service", StatGovt.Text },
                    new[] { "Superannuation Date", StatSuper.Text },
                    new[] { "CNIC", ep.Cnic }
                });
            }
            catch
            {
                // the tiles simply stay empty when the employment record is incomplete
            }
        }

        private void bindPersonalInfo(int empval)
        {

            PersonalDetail pd = new EmployeeHandler().GetPersonalDetails(empval);
            title.Text = pd.Title;

            EmpNametxt.Text = pd.FName;
            if (pd.MName != "")
                EmpNametxt.Text += " " + pd.MName;
            if (pd.LName != "")
                EmpNametxt.Text += " " + pd.LName;
            Gender.Text = new AdministrationBIZ().GetGender(pd.Gender).Description;
            BirthPlace.Text = new AdministrationBIZ().GetCity(pd.BirthPlace).Description;
            PermCity.Text = new AdministrationBIZ().GetCity(pd.PermCity).Description;
            LocalCity.Text = new AdministrationBIZ().GetCity(pd.LocalCity).Description;
            CNICIssuePlace.Text = new AdministrationBIZ().GetCity(pd.IssuePlace).Description;
            FatherNametxt.Text = pd.FatherNanme;
            DOB.Text = pd.Dob.ToShortDateString();
            CNIC.Text = pd.Cnic;
            CNICDate.Text = pd.CnicDate.ToShortDateString();
            CNICExpDateTxt.Text = GetDate(pd.cnicExpDate);
            //OldCNIC.Text = pd.OldCnic;
            NTN.Text = pd.Ntn;
            Religion.Text = new AdministrationBIZ().GetReligion(pd.Religion).Description;
            MaritalStatus.Text = new AdministrationBIZ().GetMaritalStatus(pd.MaritalStatus).Description;
            PermProvince.Text = new AdministrationBIZ().GetProvince(pd.PermProvince).Description;
            // Fill_Districts(pd.PermProvince);
            DomDistrict.Text = new AdministrationBIZ().GetDistrict(pd.DomDistrict).Description;
            PermAddress.Text = pd.PermAddress;
            LocalAddress.Text = pd.LocalAddress;
            string photo = new EmployeeHandler().GetImage(empval);
            PhotoImg.ImageUrl = PhotoUrl(photo);
            //    EmailTxt.Text = pd.EMail;         
            bindPhoneList(empval);
            bindEmailList(empval);
            bindCoursesLv(empval);
            bindEmpDependantLV(empval);
        }
    
        protected void bindPhoneList(int empval)
        {
            List<EmployeePhones> EmpPhoneList = new EmployeeHandler().GetEmployeePhones(empval);
            EmpPhones.DataSource = EmpPhoneList;
            EmpPhones.DataBind();

        }
      
        protected void bindEmpDependantLV(int empval)
        {
            List<EmployeeDependant> EmpDep = new EmployeeHandler().GetEmployeeDependants(empval);

            EmpDependantLV.DataSource = EmpDep;
            EmpDependantLV.DataBind();
        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }


        protected void bindEmailList(int empval)
        {
            List<UserEmails> emails = new EmployeeHandler().GetEmployeeEmails(empval);
            EmailLV.DataSource = emails;
            EmailLV.DataBind();

        }
        protected void bindQualificationLv(int EmpId)
        {
            List<EmpQualification> Eq = new EmployeeHandler().GetEmployeeQualifications(EmpId);
            EmpQualificationLv.DataSource = Eq;
            EmpQualificationLv.DataBind();


        }
        protected string GetDegreeLevel(int Degree_Level_Id)
        {
            if (Degree_Level_Id == 0)
                return "Not Mentioned";
            else
            {
                DegreeLevel dl = new DegreeLevel();
                dl = new AdministrationBIZ().GetDegreeLevel(Degree_Level_Id);
                return dl.Degree_Level;
            }


        }
        protected string GetCountry(int CountryId)
        {
            if (CountryId == 0)
                return "Not Mentioned";
            else
            {
                Country cy = new Country();
                cy = new AdministrationBIZ().GetCountry(CountryId);
                return cy.Description;
            }


        }
        protected void bindCoursesLv(int EmpId)
        {
            List<EmpCourses> EmpCoursesList = new EmployeeHandler().GetEmployeeCourses(EmpId);
            EmpCoursesLv.DataSource = EmpCoursesList;
            EmpCoursesLv.DataBind();
        }
        protected string GetCourseType(int CourseTypeId)
        {
            if (CourseTypeId == 0)
                return "Not Mentioned";
            else
            {
                CourseType cy = new CourseType();
                cy = new AdministrationBIZ().GetCourseType(CourseTypeId);
                return cy.Description;
            }


        }
        protected string GetCity(int CityId)
        {
            if (CityId == 0)
                return "Not Mentioned";
            else
            {
                City cy = new City();
                cy = new AdministrationBIZ().GetCity(CityId);
                return cy.Description;
            }


        }

        // key facts shown at the top of the printed profile and the PDF (the banner and tiles are screen-only)
        private string BuildSheet(string[][] rows)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class=\"unhid\" style=\"display:none\"><table class=\"pf-kvt\">");
            for (int i = 0; i < rows.Length; i += 2)
            {
                sb.Append("<tr><td class=\"k\">").Append(Server.HtmlEncode(rows[i][0])).Append("</td><td class=\"v\">").Append(Server.HtmlEncode(rows[i][1] ?? "")).Append("</td>");
                if (i + 1 < rows.Length)
                    sb.Append("<td class=\"k\">").Append(Server.HtmlEncode(rows[i + 1][0])).Append("</td><td class=\"v\">").Append(Server.HtmlEncode(rows[i + 1][1] ?? "")).Append("</td>");
                else
                    sb.Append("<td class=\"k\"></td><td class=\"v\"></td>");
                sb.Append("</tr>");
            }
            sb.Append("</table></div>");
            return sb.ToString();
        }

        private static readonly string[] PhotoTypes = { ".jpg", ".jpeg", ".png", ".gif" };

        private string PhotoUrl(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
                return "./images/uploads/missing.jpg";
            string path = Server.MapPath("~/images/uploads/" + fileName);
            if (!File.Exists(path))
                return "./images/uploads/missing.jpg";
            // the time stamp makes the browser show a newly uploaded photo at once
            return "./images/uploads/" + fileName + "?v=" + File.GetLastWriteTimeUtc(path).Ticks;
        }

        protected void SaveImage_Click(object sender, EventArgs e)
        {
            ErrLbl.Text = "";
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            int empval;
            if (reqCookies == null || !int.TryParse(reqCookies["SystemUsersId"], out empval))
                return;
            if (!FileUpload1.HasFile)
            {
                ErrLbl.Text = "Please choose a photo to upload.";
                return;
            }
            string ext = Path.GetExtension(FileUpload1.FileName).ToLowerInvariant();
            if (Array.IndexOf(PhotoTypes, ext) < 0)
            {
                ErrLbl.Text = "The photo must be a JPG, PNG or GIF file.";
                return;
            }
            if (FileUpload1.PostedFile.ContentLength > 2 * 1024 * 1024)
            {
                ErrLbl.Text = "The photo must be smaller than 2 MB.";
                return;
            }
            string fileName = empval + ext;
            string folder = Server.MapPath("~/images/uploads/");
            Directory.CreateDirectory(folder);
            FileUpload1.PostedFile.SaveAs(Path.Combine(folder, fileName));
            new EmployeeHandler().SaveImage(fileName, empval);
            PhotoImg.ImageUrl = PhotoUrl(fileName);
        }
    }
}
