using BUDBIZ;
using FinBiz;
using FinEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Finance
{
    public partial class ChequeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                int MemberId = Convert.ToInt32(Request.QueryString["MemId"]);
                int fy = Convert.ToInt32(Request.QueryString["fy"]);
                int Mon = Convert.ToInt32(Request.QueryString["Mon"]);
                string month = new BudgetBiz().GetMonth(Mon).MonthName.ToUpper() + " " + new BudgetBiz().GetMonthYear(Mon, fy) + ")";
                header.Text = "CHEQUE DETAILS FOR THE MONTH OF - " + month;
                List<Member> members = new FinBIZ().GetMemberWithoutBankAccount();
                foreach(Member mem in members)
                {
                    MemberSalaryDetails det = new FinBIZ().GetMemberSalaryDetail(mem.MemberId, fy, Mon);
                    mem.ChequeNumber = det.ChequeNumber;
                    mem.ChequeDate = det.ChequeDate;
                }
                MembersLV.DataSource = members;
                MembersLV.DataBind();
            }
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            int fy = Convert.ToInt32(Request.QueryString["fy"]);
            int Mon = Convert.ToInt32(Request.QueryString["Mon"]);
            foreach (ListViewItem li in MembersLV.Items)
            {
                TextBox chequenumber = (TextBox)li.FindControl("ChequeNoTxt");
                //TextBox chequedate = (TextBox)li.FindControl("ChequeDate");
                if (chequenumber!=null)
                {
                    if (!String.IsNullOrEmpty(chequenumber.Text))
                    {
                        HiddenField MemberId = (HiddenField)li.FindControl("HidMemberId");
                        MemberSalaryDetails sd = new MemberSalaryDetails();
                        sd.MemberId = Convert.ToInt32(MemberId.Value);
                        sd.FinancialYearId = fy;
                        sd.MonthId = Mon;
                        string ChequeNumber = (Convert.ToString(chequenumber.Text));
                        sd.ChequeNumber = ChequeNumber;
                        new FinBIZ().UpdateMemberChequeDetail(sd);
                    }
                }
            }
        }
    }
}
