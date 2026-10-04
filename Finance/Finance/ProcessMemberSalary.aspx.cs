using BUDBIZ;
using BUDENTITIES;
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
    public partial class ProcessMemberSalary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                List<Member> members = new FinBIZ().GetMembersByCategory(1);
                MembersLV.DataSource = members;
                MembersLV.DataBind();
                List<Member> chairman = new FinBIZ().GetMembersByCategory(2);
                ChairmanLV.DataSource = chairman;
                ChairmanLV.DataBind();


                List<FinancialYears> fys = new BudgetBiz().GetFinancialYears();
                if (fys != null)
                {
                    foreach (FinancialYears row in fys)
                    {
                        ListItem li = new ListItem();
                        li.Text = row.FinancialYear;
                        li.Value = row.FinancialYearId.ToString();
                        FinancialYearDDL.Items.Add(li);
                    }

                }
                List<Months> months = new BudgetBiz().GetMonths();
                if (months != null)
                {
                    foreach (Months month in months)
                    {
                        ListItem li = new ListItem();
                        li.Text = month.MonthName;
                        li.Value = month.MonthId.ToString();
                        MonthsDDL.Items.Add(li);
                    }

                }
            }
        }

        protected void ProcessBtn_Click(object sender, EventArgs e)
        {

            int month = Convert.ToInt32(MonthsDDL.SelectedValue);
            int fy = Convert.ToInt32(FinancialYearDDL.SelectedValue);
            FinancialYearSalaryDetail fydetail = new FinBIZ().GetFinancialYearSalaryDetails(month, fy);
            if (fydetail.Finalized == 0)
            {
                new FinBIZ().ResetAllowancesDeductions(fy, month);
                List<MemberSalCategories> salCategories = new FinBIZ().GetMemberActiveSalCategories();
                if (month != 0)
                {
                    foreach (MemberSalCategories sc in salCategories)
                    {
                        List<Member> members = new FinBIZ().GetMembersByCategory(sc.MemberSalCategoryId);
                        string error = CheckHOABudget();
                        if (String.IsNullOrEmpty(error))
                        {
                            foreach (Member mem in members)
                            {
                                MemberSalaryDetails saldetail = new FinBIZ().GetMemberSalaryDetail(mem.MemberId, fy, month);
                                double TotalAllowances = 0;
                                double TotalDeductions = 0;
                                List<CurrentAllowance> StructureAllowances = new FinBIZ().GetMemberCurrentAllowances(mem.MemberId);
                                List<MonthlyChange> ChangeAllowances = new FinBIZ().GetMonthlyChanges(mem.MemberId,fy,month);
                                CurrentAllowance TempCurrentAllowance = new CurrentAllowance();
                                if (ChangeAllowances != null)
                                {
                                    /////////////////      APPLY MONTHLY CHANGES
                                    foreach (MonthlyChange monthlyChangeAllowances in ChangeAllowances)
                                    {
                                        int found = 0;
                                        if (StructureAllowances != null)
                                        {
                                            foreach (CurrentAllowance structureAllowances in StructureAllowances)
                                            {
                                                if (monthlyChangeAllowances.Id == structureAllowances.AllowanceId)
                                                {
                                                    structureAllowances.Amount = monthlyChangeAllowances.Amount;
                                                    found = 1;
                                                }
                                            }
                                            if(found==0)
                                            {
                                                TempCurrentAllowance.AllowanceId = monthlyChangeAllowances.Id;
                                                TempCurrentAllowance.Amount = monthlyChangeAllowances.Amount;
                                                StructureAllowances.Add(TempCurrentAllowance);
                                            }
                                        }
                                    }
                                }

                                if (StructureAllowances != null)
                                {
                                    // INSERT INTO MONTHLY CHANGE TABLE
                                    foreach (CurrentAllowance structureAllowances in StructureAllowances)
                                    {
                                        MonthlyAllowance monallow = new MonthlyAllowance();
                                        monallow.MonthId = month;
                                        monallow.FinancialYearId = fy;
                                        monallow.MemberId = mem.MemberId;
                                        monallow.AllowanceId = structureAllowances.AllowanceId;
                                        monallow.MonthlyRate = structureAllowances.Amount;
                                        MonthlyChange ch = new FinBIZ().GetMonthlyChange(mem.MemberId, fy, month, structureAllowances.AllowanceId);
                                        if (ch.MonthId == 0)
                                            monallow.Amount = structureAllowances.Amount;

                                        else
                                            monallow.Amount = ch.Amount;
                                            monallow.MonthlyRate = structureAllowances.Amount;

                                        new FinBIZ().InsertMonthlyAllowance(monallow);
                                        TotalAllowances = TotalAllowances + monallow.Amount;
                                    }







                                    List<CurrentDeduction> StructureDeductions = new FinBIZ().GetMemberCurrentDeductions(mem.MemberId);
                                    List<MonthlyChange> ChangeDeductions = new FinBIZ().GetMonthlyDeductionChanges(mem.MemberId, fy, month);
                                    List<MonthlyChange> NextChangeDeductions = new List<MonthlyChange>();
                                    CurrentDeduction TempCurrentDeduction = new CurrentDeduction();
                                    if (ChangeDeductions != null && (StructureAllowances != null))
                                    {
                                        foreach (MonthlyChange changeDeductions in ChangeDeductions)
                                        {
                                            int found = 0;
                                            foreach (CurrentDeduction structureDeductions in StructureDeductions)
                                            {
                                                    if (changeDeductions.Id == structureDeductions.DeductionId)
                                                    {
                                                        if (changeDeductions.Amount <= changeDeductions.Limit || changeDeductions.Limit==0)
                                                        {
                                                            structureDeductions.Amount = changeDeductions.Amount;
                                                        }
                                                        else
                                                        {
                                                            structureDeductions.Amount = changeDeductions.Limit;
                                                            MonthlyChange TempMonthlyChange = new MonthlyChange();
                                                            TempMonthlyChange.MemberId = mem.MemberId;
                                                            if ((month + 1) == 7)
                                                                TempMonthlyChange.FinancialYearId = fy + 1;
                                                            else
                                                                TempMonthlyChange.FinancialYearId = fy;
                                                            TempMonthlyChange.MonthId = month + 1;
                                                            TempMonthlyChange.Id = changeDeductions.Id;
                                                            TempMonthlyChange.Limit = changeDeductions.Limit;
                                                            TempMonthlyChange.Amount = changeDeductions.Amount - changeDeductions.Limit;
                                                            TempMonthlyChange.ReferenceId = changeDeductions.MonthlyChangeId;
                                                            new FinBIZ().InsertMonthlyDeductionChange(TempMonthlyChange);
                                                        }
                                                        found = 1;
                                                    }
                                             }

                                                if (found == 0)
                                                {
                                                    TempCurrentDeduction.DeductionId = changeDeductions.Id;
                                                    if (changeDeductions.Amount <= changeDeductions.Limit || changeDeductions.Limit == 0)
                                                    {
                                                        TempCurrentDeduction.Amount = changeDeductions.Amount;
                                                    }
                                                    else
                                                    {
                                                        TempCurrentDeduction.Amount = changeDeductions.Limit;
                                                        StructureDeductions.Add(TempCurrentDeduction);
                                                        MonthlyChange MDC = new MonthlyChange();
                                                        MDC.MemberId = mem.MemberId;
                                                        if ((month + 1) == 7)
                                                            MDC.FinancialYearId = fy + 1;
                                                        else
                                                            MDC.FinancialYearId = fy;
                                                        MDC.MonthId = month + 1;
                                                        MDC.Id = changeDeductions.Id;
                                                        MDC.Limit = changeDeductions.Limit;
                                                        MDC.Amount = changeDeductions.Amount - changeDeductions.Limit;
                                                        new FinBIZ().InsertMonthlyDeductionChange(MDC);
                                                    }
                                                    StructureDeductions.Add(TempCurrentDeduction);
                                            }
                                        }

                                    }
                                    foreach (CurrentDeduction cd in StructureDeductions)
                                    {
                                        MonthlyDeduction monded = new MonthlyDeduction();
                                        monded.MonthId = month;
                                        monded.FinancialYearId = fy;
                                        monded.MemberId = mem.MemberId;
                                        monded.DeductionId = cd.DeductionId;
                                        monded.Amount = cd.Amount;
                                        new FinBIZ().InsertMonthlyDeduction(monded);
                                        TotalDeductions = TotalDeductions + cd.Amount;
                                    }
                                    MemberSalaryDetails sd = new MemberSalaryDetails();
                                    MemberBankAccounts ba = new FinBIZ().GetMemberSalaryAccount(mem.MemberId);
                                    sd.MemberId = mem.MemberId;
                                    sd.FinancialYearId = fy;
                                    sd.MonthId = month;
                                    sd.TotalAllowances = TotalAllowances;
                                    sd.TotalDeductions = TotalDeductions;
                                    //if (ba.MemberBankAccountId==0)
                                    // {
                                    sd.BankName = ba.BankName;
                                    sd.BankAccount = ba.AccountNumber;
                                    //}
                                    new FinBIZ().InsertMemberSalaryDetail(sd);
                                    //}

                                }
                                else
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Members are not assigned any salary structure.')", true);
                            }
                        }
                    }
                    string msg = "Members salary is processed successfully for the month of " + MonthsDDL.SelectedItem;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + msg + "')", true);
                    FinancialYearSalaryDetail fydetails = new FinancialYearSalaryDetail();
                    fydetails.FinancialYearId = fy;
                    fydetails.MonthId = month;
                    fydetails.Processed = 1;
                    new FinBIZ().InsertFinancialYearSalaryDetails(fydetails);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Month')", true);
                }
            }
            else
            {
                string msg = "Failed ! Finalized salary cannot processed";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + msg + "')", true);
            }
        }
        protected string CheckHOABudget()
        {
            string error = null;
            int fy = Convert.ToInt32(FinancialYearDDL.SelectedValue);
            List<MemberSalCategories> salCategories = new FinBIZ().GetMemberSalCategories();
            foreach (MemberSalCategories sc in salCategories)
            {
                List<Member> members = new FinBIZ().GetMembersByCategory(sc.MemberSalCategoryId);
                foreach (Member mem in members)
                {
                    List<CurrentAllowance> currallow = new FinBIZ().GetMemberCurrentAllowances(mem.MemberId);
                    if (currallow != null)
                    {
                        foreach (CurrentAllowance ca in currallow)
                        {
                            double TotalAmount = 0;
                            HeadOfAccountBudget hoabudget = new BudgetBiz().GetBranchBudget(ca.HeadOfAccountId, fy, 10);
                            if (hoabudget.RemainingBalance > 0)
                            {
                                TotalAmount = new FinBIZ().GetMembersTotalAllowanceAmount(ca.AllowanceId);
                                if (hoabudget.RemainingBalance < TotalAmount)
                                    error = error + " Less budget in " + new BudgetBiz().GetHeadOfAccount(ca.HeadOfAccountId).HeadOfAccount.ToString() + " to process the salary of " + mem.MemberName + " </br>";
                            }
                            else
                            {
                                error = error + " Less budget in " + new BudgetBiz().GetHeadOfAccount(ca.HeadOfAccountId).HeadOfAccount.ToString() + " to process the salary of " + mem.MemberName + " </br>";
                            }
                        }
                    }
                    else
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Members are not assigned any salary structure.')", true);
                }

            }
            return error;
        }
        protected void PrintSlipBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int MemberId = Convert.ToInt32(btn.CommandArgument);
            int fy = Convert.ToInt32(FinancialYearDDL.SelectedValue);
            int mon = Convert.ToInt32(MonthsDDL.SelectedValue);
            Response.Redirect("~/SalarySlip.aspx?MemId=" + MemberId + "&FY=" + fy + "&Mon=" + mon);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            int MemberId = Convert.ToInt32(btn.CommandArgument);
            int fy = Convert.ToInt32(FinancialYearDDL.SelectedValue);
            int mon = Convert.ToInt32(MonthsDDL.SelectedValue);

            Response.Redirect("~/ManageMonthlyChange.aspx?MemId=" + MemberId + "&fy=" + fy + "&Mon=" + mon);
        }

        protected void ChequeDetailsBtn_Click(object sender, EventArgs e)
        {
            success.InnerText = "";
            err.InnerText = "";
            int fy = Convert.ToInt32(FinancialYearDDL.SelectedValue);
            int mon = Convert.ToInt32(MonthsDDL.SelectedValue);
            if (mon == 0)
                err.InnerText = "Please Select Month.";
            else
                Response.Redirect("~/ChequeDetails.aspx?fy=" + fy + "&Mon=" + mon);

        }

        protected void PrintMemsSalSheetBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int CatId = Convert.ToInt32(btn.CommandArgument);
            int fy = Convert.ToInt32(FinancialYearDDL.SelectedValue);
            int mon = Convert.ToInt32(MonthsDDL.SelectedValue);
            Response.Redirect("~/StatementSheet.aspx?CatId=" + CatId + "&fy=" + fy + "&Mon=" + mon);
        }

        protected void FinalizeSalaryBtn_Click(object sender, EventArgs e)
        {
           
            int month = Convert.ToInt32(MonthsDDL.SelectedValue);
            int fy = Convert.ToInt32(FinancialYearDDL.SelectedValue);
            FinancialYearSalaryDetail fydetail = new FinBIZ().GetFinancialYearSalaryDetails(month, fy);
            if (fydetail.Finalized == 0 && fydetail.Processed == 1)
            {
                List<MemberSalCategories> salCategories = new FinBIZ().GetMemberSalCategories();
                if (month != 0)
                {


                    foreach (MemberSalCategories sc in salCategories)
                    {
                        List<MonthlyAllowance> Allowances = new FinBIZ().GetMonthlyAllownacesList(sc.MemberSalCategoryId, fy, month);
                        List<Member> members = new FinBIZ().GetMembersByCategory(sc.MemberSalCategoryId);
                        foreach (Member mem in members)
                        {
                            foreach (MonthlyAllowance structureallowance in Allowances)
                            {
                                MonthlyAllowance ma = new FinBIZ().GetMonthlyAllowance(mem.MemberId, month, fy, structureallowance.AllowanceId);
                                if (!String.IsNullOrEmpty(ma.AllowanceDesc))
                                {
                                    new FinBIZ().FinalizeMonthlyAllowance(ma);
                                }
                            }
                        }
                    }
                    new FinBIZ().UpdateFinalizeDetail(fydetail);
                    string msg = "Salary finalized succeessfully";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + msg + "')", true);
                }
            }
            else
            {
                string msg = "Salary not processed or already finalized";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + msg + "')", true);
            }
        }

        protected void PrintAnnualStatement_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int MemberId = Convert.ToInt32(btn.CommandArgument);
            int fy = Convert.ToInt32(FinancialYearDDL.SelectedValue);
            Response.Redirect("~/AnnualSalaryStatement.aspx?MemberId=" + MemberId + "&fy=" + fy);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int CatId = Convert.ToInt32(btn.CommandArgument);
            int fy = Convert.ToInt32(FinancialYearDDL.SelectedValue);
            int mon = Convert.ToInt32(MonthsDDL.SelectedValue);
            Response.Redirect("~/AllMembersSalarySlips.aspx?CatId=" + CatId + "&fy=" + fy + "&Mon=" + mon);
        }

        protected void MonthlyChangesList_Click(object sender, EventArgs e)
        {
            int fy = Convert.ToInt32(FinancialYearDDL.SelectedValue);
            int mon = Convert.ToInt32(MonthsDDL.SelectedValue);
            Response.Redirect("~/MonthlyChangesList.aspx?fy=" + fy + "&Mon=" + mon);
        }

        protected void Bank_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int CatId = Convert.ToInt32(btn.CommandArgument);
            int fy = Convert.ToInt32(FinancialYearDDL.SelectedValue);
            int mon = Convert.ToInt32(MonthsDDL.SelectedValue);
            Response.Redirect("~/StatementByPaymentMethod.aspx?CatId=" + CatId + "&fy=" + fy + "&Mon=" + mon + "&ptype=" + 1);
        }
        protected void Cheque_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int CatId = Convert.ToInt32(btn.CommandArgument);
            int fy = Convert.ToInt32(FinancialYearDDL.SelectedValue);
            int mon = Convert.ToInt32(MonthsDDL.SelectedValue);
            Response.Redirect("~/StatementByPaymentMethod.aspx?CatId=" + CatId + "&fy=" + fy + "&Mon=" + mon + "&ptype=" + 2);
        }
    }
}