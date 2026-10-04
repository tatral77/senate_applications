using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EstablishmentBIZ;
using EstablishmentENT;
namespace MY
{
    public partial class EmploymentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int empval=0;
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                empval = Convert.ToInt32(reqCookies["SystemUsersId"]);
            }
            if (!IsPostBack && empval != 0)
            {
                bindPrintHead(empval);
                bindEmployment(empval);
                bindRegularEmployment(empval);
                bindProbationLV(empval);
                bindOtherEmployment(empval);
                bindEmploymentOutLV(empval);
                //bindEmploymentOutEmployment(empval);
                bindExtensionLV(empval);
                bindRetirementLV(empval);
                bindEmpPromotion(empval);
                bindPromProbationLV(empval);
                bindPostingLv(empval);
                BindNOCLV(empval);
            }


        }
        // name and designation printed above the details (the page itself shows them in the navbar)
        private void bindPrintHead(int empval)
        {
            EmpHeaderInfo info = new EmployeeHandler().GetEmpName(empval);
            EmpHeaderInfo desig = new EmployeeHandler().GetEmpDesignation(empval);
            string line = info.EmpName;
            if (!String.IsNullOrEmpty(desig.POST))
                line += " -- " + desig.POST + " (" + desig.BPS + ")";
            PrintHeadLit.Text = "<div class=\"unhid page-header\" style=\"display:none\">" + Server.HtmlEncode(line) + "</div>";
        }

        protected void bindPromProbationLV(int EmpId)
        {
            List<Probation> re = new List<Probation>();
            re = new EmploymentBIZ().GetPromotionProbations(EmpId);
            PromProbationLV.DataSource = re;
            PromProbationLV.DataBind();
        }
        protected void bindEmpPromotion(int empval)
        {
            List<PromotionHistory> PromHist = new EmployeeHandler().GetPromotionHistory(empval);
            EmpPromotion.DataSource = PromHist;
            EmpPromotion.DataBind();

        }
        protected void bindPostingLv(int EmpId)
        {
            List<EmployeePosting> Eq = new EmployeeHandler().GetEmployeePostings(EmpId);
            EmpPostingLv.DataSource = Eq;
            EmpPostingLv.DataBind();


        }
        protected void bindEmployment(int EmpId)
        {
            EmpEmployment Ep = new EmpEmployment();
            Ep = new EmployeeHandler().GetEmpEmployment(EmpId);
            FileNo.Text = Convert.ToString(Ep.File_no);
            PersonalNoTxt.Text = Convert.ToString(Ep.PersonalNo);
            GovtSrvEntry.Text = (Convert.ToString(Ep.GovtServStDate) == "01/01/0001 00:00:00") ? string.Empty : Ep.GovtServStDate.ToShortDateString();// ? String.Format("{0:dd/MM/yyyy}", Ep.GovtServStDate) : string.Empty;
            SenEntry.Text = (Convert.ToString(Ep.SenServStDate) == "01/01/0001 00:00:00") ? string.Empty : Ep.SenServStDate.ToShortDateString();// ? String.Format("{0:dd/MM/yyyy}", Ep.SenServStDate) : string.Empty;
            PoolLbl.Text = new AdministrationBIZ().GetEmpPool(Ep.EmpPoolId).Description;
            QuotaLbl.Text = new AdministrationBIZ().GetEmplQuota(Ep.QuotaId).Description;
            AppointmentModeLbl.Text = new AdministrationBIZ().GetAppointmenMode(Ep.AppointmentModeId).Description;
            SeniorityNumber.Text = Convert.ToString(Ep.SenNo);
        }
        protected void bindCombos()
        {
          
        }
        public string GetBranch(int BranchId)
        {
            Branch br = new AdministrationBIZ().GetBranch(BranchId);
            return br.Description;
        }
        public string GetBps(int Bpsid)
        {
            if (Bpsid <= 0)
                return "Not Mentioned";
            else
            {
                BPS br = new AdministrationBIZ().GetBPS(Bpsid);
                return br.Description;
            }
        }
        public string GetPost(int PostId)
        {
            Post pt = new AdministrationBIZ().GetPost(PostId);
            return pt.Description;

        }

        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }
        protected void bindRegularEmployment(int EmpId)
        {
            List<EmpHistory> re = new List<EmpHistory>();
            re = new EmploymentBIZ().GetRegEmployment(EmpId);
            if (re == null)
                regulardiv.Visible = false;
            else
            {
                RegularEmploymentLV.DataSource = re;
                RegularEmploymentLV.DataBind();
            }
        }

        //===============================================================================================================================
        #region PROBATION
       
        protected void bindProbationLV(int EmpId)
        {
            List<Probation> re = new List<Probation>();
            re = new EmploymentBIZ().GetEmployeeProbations(EmpId);
            if (re == null)
                probationdiv.Visible = false;
            else
            {
                ProbationLV.DataSource = re;
                ProbationLV.DataBind();
            }
        }
      

        #endregion PROBATION
        //===============================================================================================================================



        #region OTHER EMPLOYMENT

        protected void bindOtherEmployment(int EmpId)
        {
            List<EmpHistory> re = new List<EmpHistory>();
            re = new EmploymentBIZ().GetEmpHistory(EmpId);
            if (re == null)
                otheremploymentdiv.Visible = false;
            else
            {
                OtherEmploymentLV.DataSource = re;
                OtherEmploymentLV.DataBind();
            }
        }
       
        #endregion EmploymentOut




        //===============================================================================================================================
        #region EmploymentOut
        protected void bindEmploymentOutLV(int EmpId)
        {
            List<EmploymentOut> re = new List<EmploymentOut>();
            re = new EmploymentBIZ().GetEmploymentOut(EmpId);
            if (re == null)
                deputationdiv.Visible = false;
            else
            {
                EmploymentOutLV.DataSource = re;
                EmploymentOutLV.DataBind();
            }
        }

     
        #endregion EmploymentOut


        #region Extension

        protected void bindExtensionLV(int EmpId)
        {
            List<ExtensionDetails> re = new List<ExtensionDetails>();
            re = new EmploymentBIZ().GetExtensionDetails(EmpId);
            if (re == null)
                extensiondiv.Visible = false;
            else
            {
                ExtensionLV.DataSource = re;
                ExtensionLV.DataBind();
            }
        }

     

        #endregion Extension


        #region RETIREMENT

        protected void bindRetirementLV(int EmpId)
        {
            List<EmpRetirement> re = new List<EmpRetirement>();
            re = new EmploymentBIZ().GetEmpRetirement(EmpId);
            if (re == null)
                retirementdiv.Visible = false;
            else
            {
                RetirementLV.DataSource = re;
                RetirementLV.DataBind();
            }
        }

        #endregion RETIREMENT

        #region NOC
        public void BindNOCLV(int empval)
        {
            List<NOC> EmpNocs = new List<NOC>();
            EmpNocs = new EmployeeHandler().GetEmployeeNOCs(empval);
            EmpNocsLv.DataSource = EmpNocs;
            EmpNocsLv.DataBind();
        }
        #endregion
    }
}