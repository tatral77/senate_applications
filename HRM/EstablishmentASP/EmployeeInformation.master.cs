using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EstablishmentBIZ;
using System.IO;
using EstablishmentENT;

namespace EstablishmentASP
{
    public partial class EmployeeInformation : System.Web.UI.MasterPage
    {
        string empval;
      
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
            empval = Request.QueryString["EmpId"];
            ImageButton1.ImageUrl = PhotoUrl(new EmployeeHandler().GetImage(Convert.ToInt32(empval)));

            if (!IsPostBack)
                {
                PersonalDetails.NavigateUrl = "~/PersonalInformation.aspx?empid=" + empval;
                EmploymentHistory.NavigateUrl = "~/PreviousEmployments.aspx?empid=" + empval;
                PromotionDetails.NavigateUrl = "~/EmpPromotionDetails.aspx?empid=" + empval;
                EmploymentDetails.NavigateUrl = "~/EmploymentDetails.aspx?empid=" + empval;
                Leaves.NavigateUrl = "~/EmpLeaves.aspx?empid=" + empval;
                Passport.NavigateUrl = "~/Passport.aspx?empid=" + empval;
                NOC.NavigateUrl = "~/EmployeeNOC.aspx?empid=" + empval;
                Education.NavigateUrl = "~/EmpQualifications.aspx?empid=" + empval;
                Trainings.NavigateUrl = "~/EmpCourses.aspx?empid=" + empval;
                Dependants.NavigateUrl= "~/EmployeeDependants.aspx?empid=" + empval;
                EmpPostings.NavigateUrl= "~/EmployeePostings.aspx?empid=" + empval;
                Visits.NavigateUrl = "~/Visits.aspx?empid=" + empval;
                EmpProfile.NavigateUrl = "~/EmployeeProfile.aspx?empid=" + empval;
                EmpAcrs.NavigateUrl = "~/EmployeeAcr.aspx?empid=" + empval;
                ResPerson.NavigateUrl = "~/ResourcePerson.aspx?empid=" + empval;
                OtherCharges.NavigateUrl="~/EmpOtherCharges.aspx?empid=" + empval;
                SecClearance.NavigateUrl = "~/EmployeeSecClearance.aspx?empid=" + empval;
                DiscipActions.NavigateUrl = "~/EmpDisciplinaryActions.aspx?empid=" + empval;
                Medical.NavigateUrl = "~/EmployeeMedical.aspx?empid=" + empval;
                Assets.NavigateUrl = "~/EmployeeAsset.aspx?empid=" + empval;
                Suspension.NavigateUrl = "~/SuspensionDetails.aspx?empid=" + empval;
               // HLRetirement.NavigateUrl = "~/EmpRetirementRpt.aspx?empid=" + empval;
                OtherDuties.NavigateUrl = "~/EmpOtherDuties.aspx?empid=" + empval;
                BenFund.NavigateUrl= "~/EmpBenevolentFund.aspx?empid=" + empval;


                //NameLabel.Text = empval;
                //    // Item 0
                //    EmpDetails.Items.Add(new MenuItem
                //    {
                //        Text = "Personal Information",
                //        //NavigateUrl = "~/admin.aspx?empid=" + empval
                //    });
                //    EmpDetails.Items[0].ChildItems.Add(new MenuItem
                //    {
                //        Text = "Personal Details",
                //        NavigateUrl = "~/PersonalInformation.aspx?empid=" + empval
                //    });
                //    EmpDetails.Items[0].ChildItems.Add(new MenuItem
                //    {
                //        Text = "Medical/Assets",
                //        NavigateUrl = "~/Medical.aspx?empid=" + empval
                //    });
                //    //Item 1
                //    EmpDetails.Items.Add(new MenuItem
                //    {
                //        Text = "Employment Information",
                //        //NavigateUrl = "~/admin.aspx?empid=" + empval
                //    });
                //    EmpDetails.Items[1].ChildItems.Add(new MenuItem
                //    {
                //        Text = "Employment Details",
                //        NavigateUrl = "~/EmploymentDetails.aspx?empid=" + empval
                //    });
                //    EmpDetails.Items[1].ChildItems.Add(new MenuItem
                //    {
                //        Text = "Employment History",
                //        NavigateUrl = "~/EmpHistoryDetails.aspx?empid=" + empval
                //    });
                //    EmpDetails.Items[1].ChildItems.Add(new MenuItem
                //    {
                //        Text = "Promotion Details",
                //        NavigateUrl = "~/EmpPromotionDetails.aspx?empid=" + empval
                //    });
                //    EmpDetails.Items[1].ChildItems.Add(new MenuItem
                //    {
                //        Text = "Disciplinary Actions",
                //        NavigateUrl = "~/Disciplinary.aspx?empid=" + empval
                //    });
                //    EmpDetails.Items[1].ChildItems.Add(new MenuItem
                //    {
                //        Text = "Leaves",
                //        NavigateUrl = "~/Empleaves.aspx?empid=" + empval
                //    });
                //    EmpDetails.Items[1].ChildItems.Add(new MenuItem
                //    {
                //        Text = "Visits",
                //        NavigateUrl = "~/Empvisits.aspx?empid=" + empval
                //    });
                //    //Item 2
                //    EmpDetails.Items.Add(new MenuItem
                //    {
                //        Text = "Qualification/Trainings",

                //    });
                //    EmpDetails.Items[2].ChildItems.Add(new MenuItem
                //    {
                //        Text = "Qualification",
                //        NavigateUrl = "~/EmpQualifications.aspx?empid=" + empval
                //    });
                //    EmpDetails.Items[2].ChildItems.Add(new MenuItem
                //    {
                //        Text = "Courses/Trainings",
                //        NavigateUrl = "~/EmpCourses.aspx?empid=" + empval
                //    });

                //    //Item 3
                //    EmpDetails.Items.Add(new MenuItem
                //    {
                //        Text = "Documents Issued",
                //        //NavigateUrl = "~/admin.aspx?empid=" + empval
                //    });
                //    EmpDetails.Items[3].ChildItems.Add(new MenuItem
                //    {
                //        Text = "Passport",
                //        NavigateUrl = "~/Passport.aspx?empid=" + empval
                //    });
                //    EmpDetails.Items[3].ChildItems.Add(new MenuItem
                //    {
                //        Text = "NOC",
                //        NavigateUrl = "~/Empnocs.aspx?empid=" + empval
                //    });

                new EmploymentBIZ().UpdateEmploymentStatus(Convert.ToInt32(empval));
                EmpHeaderInfo EmpInfo = new EmpHeaderInfo();
                EmpInfo= new EmployeeHandler().GetEmpName(Convert.ToInt32(empval));
                EmpHeaderInfo EmpDesig = new EmployeeHandler().GetEmpDesignation(Convert.ToInt32(empval));
                NameLabel.Text = EmpInfo.EmpName.ToString();
                if (!String.IsNullOrEmpty(EmpDesig.POST))
                    DesignationLabel.Text = EmpDesig.POST.ToString() + " (" + EmpDesig.BPS.ToString() + ")";
                else
                    DesignationLabel.Text = "Post and BPS not mentioned";
                EmpInfo = new EmployeeHandler().GetEmpBranch(Convert.ToInt32(empval));
                if (!String.IsNullOrEmpty(EmpInfo.BRANCH))
                {
                    string branches = null;
                    branches = EmpInfo.BRANCH.ToString() + ", ";
                    if (EmpInfo.AdditionalBranches != null)
                    {
                        foreach (AdditionalBranchesEnt ab in EmpInfo.AdditionalBranches)
                        {
                            branches = branches + ab.AdditionalBranch + ", ";
                        }
                    }
                    BranchLabel.Text = branches.TrimEnd(',', ' ');
                }
                else
                    BranchLabel.Text = "Branch not mentioned";

                EmpInfo = new EmployeeHandler().GetEmpEmplStatus(Convert.ToInt32(empval));
                if (!String.IsNullOrEmpty(EmpInfo.EmploymentStatus))
                   StatusLabel.Text = EmpInfo.EmploymentStatus.ToString();
                else
                    StatusLabel.Text = "Employment status not mentioned";
                if (!String.IsNullOrEmpty(EmpInfo.EmploymentStatus))
                    CurrentStatusLbl.Text = EmpInfo.CurrentStatus.ToString();
                else
                    CurrentStatusLbl.Text = "Current status not mentioned";

              


            }


        }
        private static readonly string[] PhotoTypes = { ".jpg", ".jpeg", ".png", ".gif" };

        // the photo, or the placeholder when the employee has none (the time stamp makes a new photo show at once)
        private string PhotoUrl(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
                return "./images/uploads/missing.jpg";
            string path = Server.MapPath("~/images/uploads/" + fileName);
            if (!File.Exists(path))
                return "./images/uploads/missing.jpg";
            return "./images/uploads/" + fileName + "?v=" + File.GetLastWriteTimeUtc(path).Ticks;
        }

        protected void SaveImage_Click(object sender, EventArgs e)
        {
            int id;
            if (!FileUpload1.HasFile || !int.TryParse(Request.QueryString["EmpId"], out id))
                return;
            string ext = Path.GetExtension(FileUpload1.FileName).ToLowerInvariant();
            if (Array.IndexOf(PhotoTypes, ext) < 0 || FileUpload1.PostedFile.ContentLength > 2 * 1024 * 1024)
                return;                                   // only JPG, PNG or GIF up to 2 MB
            string fileName = id + ext;
            string folder = Server.MapPath("~/images/uploads/");
            Directory.CreateDirectory(folder);
            FileUpload1.PostedFile.SaveAs(Path.Combine(folder, fileName));
            new EmployeeHandler().SaveImage(fileName, id);
            ImageButton1.ImageUrl = PhotoUrl(fileName);
        }

    }
}
