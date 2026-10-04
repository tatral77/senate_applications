using BUDENTITIES;
using FinDal;
using FinEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinBiz
{
    public class FinBIZ
    {
        #region MEMBER
        public List<Member> GetMemberByName(string MemberName)
        {
            return new FinDAL().GetMemberByName(MemberName);
        }
        public List<Member> GetActiveMembers()
        {
            return new FinDAL().GetActiveMembers();
        }
        public List<Member> GetMemberWithoutBankAccount()
        {
            return new FinDAL().GetMemberWithoutBankAccount();
        }
        public List<Member> GetCatMemberWithoutBankAccount(int SalCategoryId)
        {
            return new FinDAL().GetCatMemberWithoutBankAccount(SalCategoryId);
        }
        public List<Member> GetCatMemberWithBankAccount(int SalCategoryId)
        {
            return new FinDAL().GetCatMemberWithBankAccount(SalCategoryId);
        }
        public void UpdateMemberSalaryStatus(int SystemUserId, int SalaryCategoryId, int SalaryStatus)
        {
            new FinDAL().UpdateMemberSalaryStatus(SystemUserId, SalaryCategoryId, SalaryStatus);
        }
        public List<MemberSalCategories> GetMemberSalCategories()
        {
            return new FinDAL().GetMemberSalCategories();
        }
        public List<MemberSalCategories> GetMemberActiveSalCategories()
        {
            return new FinDAL().GetMemberActiveSalCategories();
        }
        public List<Member> GetMembersByCategory(int SalCategoryId)
        {
            return new FinDAL().GetMembersByCategory(SalCategoryId);
        }
        public Member GetMemberById(int Id)
        {
            return new FinDAL().GetMemberById(Id);
        }
        #endregion MEMBER
            #region SALARY_STRUCTURE
        public List<SalaryStructure> GetSalaryStructures()
        {
            return new FinDAL().GetSalaryStructures();
        }
        public SalaryStructure GetSalaryStructureByCategory(int CategoryId)
        {
            return new FinDAL().GetSalaryStructureByCategory(CategoryId);
        }
        public SalaryStructure GetSalaryStructure(int SalaryStructureId)
        {
            return new FinDAL().GetSalaryStructure(SalaryStructureId);
        }
        public SalaryStructure GetCurrentSalaryStructure()
        {

            return new FinDAL().GetCurrentSalaryStructure();
        }
        public void InsertSalaryStructure(SalaryStructure Temp)
        {
            new FinDAL().InsertSalaryStructure(Temp);
        }
        public void UpdateSalaryStructure(SalaryStructure Temp)
        {
            new FinDAL().UpdateSalaryStructure(Temp);
        }
        public void AssignStructureToMembers(int SalaryStructureId)
        {
            new FinDAL().AssignStructureToMembers(SalaryStructureId);
        }
        public FundCenters GetIdByCategory(int CategoryId)
        {
            return new FinDAL().GetIdByCategory(CategoryId);
        }
        
        #endregion SALARY_STRUCTURE
            #region  STRUCTURE_ALLOWANCES
        public List<StructureAllowance> GetStructureAllownaces(int StructureId)
        {
            return new FinDAL().GetStructureAllownaces(StructureId);
        }
        public StructureAllowance GetStructureAllownace(int StructureId, int AllownaceId)
        {
            return new FinDAL().GetStructureAllownace(StructureId,AllownaceId);
        }

        public void InsertStructureAllownace(StructureAllowance Temp)
        {
            new FinDAL().InsertStructureAllownace(Temp);
        }
        public void UpdateStructureAllownace(StructureAllowance Temp)
        {
            new FinDAL().UpdateStructureAllownace(Temp);
        }
        public void DeleteStructureAllownace(int StructureId, int AllownaceId)
        {
            new FinDAL().DeleteStructureAllownace(StructureId, AllownaceId);
        }
        #endregion STRUCTURE ALLOWANCE
        #region  STRUCTURE_DEDUCTIONS
        public List<StructureDeduction> GetStructureDeductions(int StructureId)
        {
            return new FinDAL().GetStructureDeductions(StructureId);
        }
        public StructureDeduction GetStructureDeduction(int StructureId, int DeductionId)
        {
            return new FinDAL().GetStructureDeduction(StructureId,DeductionId);
        }

        public void InsertStructureDeduction(StructureDeduction Temp)
        {
            new FinDAL().InsertStructureDeduction(Temp);
        }
        public void UpdateStructureDeduction(StructureDeduction Temp)
        {
            new FinDAL().UpdateStructureDeduction(Temp);
        }
        public void DeleteStructureDeduction(int StructureId, int DeductionId)
        {
            new FinDAL().DeleteStructureDeduction(StructureId, DeductionId);
        }
        #endregion STRUCTURE DEDUCTION
        #region ALLOWANCES
        public List<Allowances> GetAllowances()
        {
            return new FinDAL().GetAllowances();
        }
        public Allowances GetAllowance(int AllowanceId)
        {
            return new FinDAL().GetAllowance(AllowanceId);
        }

        public void InsertAllowance(Allowances Temp)
        {
            new FinDAL().InsertAllowance(Temp);
        }
        public void UpdateAllowance(Allowances Temp)
        {
            new FinDAL().UpdateAllowance(Temp);
        }

        #endregion ALLOWANCE
        #region DEDUCTIONS
        public List<Deductions> GetDeductions()
        {
            return new FinDAL().GetDeductions();
        }
        public Deductions GetDeduction(int DeductionId)
        {
            return new FinDAL().GetDeduction(DeductionId);
        }

        public void InsertDeduction(Deductions Temp)
        {
            new FinDAL().InsertDeduction(Temp);
        }
        public void UpdateDeduction(Deductions Temp)
        {
            new FinDAL().UpdateDeduction(Temp);
        }
        #endregion DEDUCTION
        #region  CURRENT_DEDUCTIONS
        public List<CurrentDeduction> GetCurrentDeductions()
        {
            return new FinDAL().GetCurrentDeductions();
        }
        public CurrentDeduction GetCurrentDeduction(int CurrentDeductionId)
        {
            return new FinDAL().GetCurrentDeduction(CurrentDeductionId);
        }

        public void InsertCurrentDeduction(CurrentDeduction Temp)
        {
            new FinDAL().InsertCurrentDeduction(Temp);
        }
        public void UpdateCurrentDeduction(CurrentDeduction Temp)
        {
            new FinDAL().UpdateCurrentDeduction(Temp);
        }
        public void DeleteCurrentDeduction(int CurrentDeductionId)
        {
            new FinDAL().DeleteCurrentDeduction(CurrentDeductionId);
        }
        #endregion CURRENT DEDUCTION
        #region  CURRENT_ALLOWANCES
        public List<CurrentAllowance> GetCurrentAllowances(int MemberId)
        {
            return new FinDAL().GetCurrentAllowances(MemberId);
        }
        public CurrentAllowance GetCurrentAllowance(int CurrentAllowanceId)
        {
            return new FinDAL().GetCurrentAllowance(CurrentAllowanceId);
        }

        public void InsertCurrentAllowance(CurrentAllowance Temp)
        {
            new FinDAL().InsertCurrentAllowance(Temp);
        }
        public void UpdateCurrentAllowance(CurrentAllowance Temp)
        {
            new FinDAL().UpdateCurrentAllowance(Temp);
        }
        public void DeleteCurrentAllowance(int CurrentAllowanceId)
        {
            new FinDAL().DeleteCurrentAllowance(CurrentAllowanceId);
        }
        #endregion CURRENT ALLOWANCE
        #region  MONTHLY_ALLOWANCES
        public List<MonthlyAllowance> GetMonthlyAllowances(int MemberId, int FinancialYearId, int MonthId)
        {
            return new FinDAL().GetMonthlyAllowances(MemberId, FinancialYearId, MonthId);
        }
        public MonthlyAllowance GetMonthlyAllowance(int MemberId, int MonthId, int FinancialYearId, int AllowanceId)
        {
            return new FinDAL().GetMonthlyAllowance(MemberId, MonthId,  FinancialYearId, AllowanceId);
        }

        public int  InsertMonthlyAllowance(MonthlyAllowance Temp)
        {
            return new FinDAL().InsertMonthlyAllowance(Temp);
        }
        public void FinalizeMonthlyAllowance(MonthlyAllowance Temp)
        {
            new FinDAL().FinalizeMonthlyAllowance(Temp);
        }

        public void UpdateMonthlyAllowance(MonthlyAllowance Temp)
        {
           new FinDAL().UpdateMonthlyAllowance(Temp);
        }
        public void DeleteMonthlyAllowance(int MonthlyAllowanceId)
        {
            new FinDAL().DeleteMonthlyAllowance(MonthlyAllowanceId);
        }
        public List<MonthlyAllowance> GetDistinctMonthlyAllownacesList(int CategoryId, int FinancialYearId, int Month)
        {
            return new FinDAL().GetDistinctMonthlyAllownacesList(CategoryId, FinancialYearId, Month);
        }
            public List<MonthlyAllowance> GetMonthlyAllownacesList(int CategoryId, int FinancialYearId, int Month)
        {
            return new FinDAL().GetMonthlyAllownacesList(CategoryId, FinancialYearId, Month);
        }
        public List<MonthlyAllowance> GetMemberFinYearAllownacesList(int MemberId, int FinancialYearId)
        {
            return new FinDAL().GetMemberFinYearAllownacesList(MemberId, FinancialYearId);
        }
        #endregion MONTHLY ALLOWANCE
            #region  MONTHLY_DEDUCTIONS
        public List<MonthlyDeduction> GetMonthlyDeductions(int MemberId, int FinancialYearId, int MonthId)
        {
            return new FinDAL().GetMonthlyDeductions(MemberId, FinancialYearId, MonthId);
        }
        public MonthlyDeduction GetMonthlyDeduction(int MemberId, int MonthId, int FinancialYearId, int DeductionId)
        {
            return new FinDAL().GetMonthlyDeduction(MemberId, MonthId, FinancialYearId, DeductionId);
        }

        public void InsertMonthlyDeduction(MonthlyDeduction Temp)
        {
            new FinDAL().InsertMonthlyDeduction(Temp);
        }
        public void UpdateMonthlyDeduction(MonthlyDeduction Temp)
        {
            new FinDAL().UpdateMonthlyDeduction(Temp);
        }
        public void DeleteMonthlyDeduction(int MonthlyDeductionId)
        {
            new FinDAL().DeleteMonthlyDeduction(MonthlyDeductionId);
        }
        public List<MonthlyDeduction> GetMonthlyDeductionsList(int CategoryId, int FinancialYearId, int Month)
        {
            return new FinDAL().GetMonthlyDeductionsList(CategoryId, FinancialYearId,Month);
        }

        public List<MonthlyDeduction> GetMemberFinYearDeductionsList(int MemberId, int FinancialYearId)
        {
            return new FinDAL().GetMemberFinYearDeductionsList(MemberId, FinancialYearId);
        }
        #endregion MONTHLY DEDUCTION
            #region MEMBER_CURRENT_ALLOWANCES
        public List<CurrentAllowance> GetMemberCurrentAllowances(int MemberId)
        {
            return new FinDAL().GetMemberCurrentAllowances(MemberId);
        }
        public void InsertMemberCurrentAllowance(CurrentAllowance Temp)
        {
            new FinDAL().InsertMemberCurrentAllowance(Temp);
        }
        public void UpdateMemberCurrentAllowance(CurrentAllowance Temp)
        {
            new FinDAL().UpdateMemberCurrentAllowance(Temp);
        }
        #endregion  MEMBER_CURRENT_ALLOWANCES
            #region MEMBER_CURRENT_DEDUCTIONS
        public List<CurrentDeduction> GetMemberCurrentDeductions(int MemberId)
        {
            return new FinDAL().GetMemberCurrentDeductions(MemberId);
        }
        public void InsertMemberCurrentDeduction(CurrentDeduction Temp)
        {
            new FinDAL().InsertMemberCurrentDeduction(Temp);
        }
        public void UpdateMemberCurrentDeduction(CurrentDeduction Temp)
        {
            new FinDAL().UpdateMemberCurrentDeduction(Temp);
        }
        #endregion  MEMBER_CURRENT_DEDUCTIONS
        public double GetMembersTotalAllowanceAmount(int AllowanceId)
        {
            return new FinDAL().GetMembersTotalAllowanceAmount(AllowanceId);
        }
        #region MEMBER_BANK_ACCOUNTS
        public List<MemberBankAccounts> GetMemberBankAccounts(int MemberId)
        {
            return new FinDAL().GetMemberBankAccounts(MemberId);
        }
        public MemberBankAccounts GetMemberBankAccount(int BankAccountsId)
        {
            return new FinDAL().GetMemberBankAccount(BankAccountsId);
        }
        public MemberBankAccounts GetMemberSalaryAccount(int MemberId)
        {
            return new FinDAL().GetMemberSalaryAccount(MemberId);
        }
        public void InsertMemberBankAccount(MemberBankAccounts Temp)
        {
            new FinDAL().InsertMemberBankAccount(Temp);
        }
        public void UpdateMemberBankAccount(MemberBankAccounts Temp)
        {
            new FinDAL().UpdateMemberBankAccount(Temp);
        }
        public void DeleteMemberBankAccount(int BankAccountsId)
        {
            new FinDAL().DeleteMemberBankAccount(BankAccountsId);
        }
        #endregion MEMBER_BANK_ACCOUNTS
        #region MEMBER_SALARY_DETAILS
        public List<MemberSalaryDetails> GetMemberSalaryDetails(int MemberId)
        {
            return new FinDAL().GetMemberSalaryDetails(MemberId);
        }
        public MemberSalaryDetails GetMemberSalaryDetail(int MemberId, int FinancialYearId, int MonthId)
        {
            return new FinDAL().GetMemberSalaryDetail(MemberId, FinancialYearId,MonthId);
        }
        public void InsertMemberSalaryDetail(MemberSalaryDetails Temp)
        {
            new FinDAL().InsertMemberSalaryDetail(Temp);
        }
        public void UpdateMemberChequeDetail(MemberSalaryDetails Temp)
        {
            new FinDAL().UpdateMemberChequeDetail(Temp);
        }
        #endregion MEMBER_SALARY_DETAIL
        #region  MONTHLY_CHANGE
        public List<MonthlyChange> GetMonthlyChanges(int MemberId, int FinancialYearId, int MonthId)
        {
            return new FinDAL().GetMonthlyChanges(MemberId, FinancialYearId, MonthId);
        }
        public MonthlyChange GetMonthlyChange(int MemberId, int FinancialYearId, int MonthId, int AllowanceId)
        {
            return new FinDAL().GetMonthlyChange(MemberId, FinancialYearId, MonthId, AllowanceId);
        }

        public void InsertMonthlyChange(MonthlyChange Temp)
        {
            new FinDAL().InsertMonthlyChange(Temp);
        }
        public void DeleteMonthlyChange(int MonthlyChangeId)
        {
            new FinDAL().DeleteMonthlyChange(MonthlyChangeId);
        }
        public List<MonthlyChange> GetMonthlyChanges(int FinancialYearId, int MonthId)
        {
            return new FinDAL().GetMonthlyChanges(FinancialYearId, MonthId);
        }
        #endregion MONTHLY ALLOWANCE
        #region  MONTHLY_DEDUCTION_CHANGE
        public List<MonthlyChange> GetMonthlyDeductionChanges(int MemberId, int FinancialYearId, int MonthId)
        {
            return new FinDAL().GetMonthlyDeductionChanges(MemberId, FinancialYearId, MonthId);
        }
        public MonthlyChange GetMonthlyDeductionChange(int MemberId, int FinancialYearId, int MonthId, int DeductionId)
        {
            return new FinDAL().GetMonthlyDeductionChange(MemberId, FinancialYearId, MonthId, DeductionId);
        }

        public void InsertMonthlyDeductionChange(MonthlyChange Temp)
        {
            new FinDAL().InsertMonthlyDeductionChange(Temp);
        }
        public void DeleteMonthlyDeductionChange(int MonthlyChangeId)
        {
            new FinDAL().DeleteMonthlyDeductionChange(MonthlyChangeId);
        }
        public List<MonthlyChange> GetMonthlyDeductionChanges(int FinancialYearId, int MonthId)
        {
            return new FinDAL().GetMonthlyDeductionChanges(FinancialYearId, MonthId);
        }
        #endregion MONTHLY_DEDUCTION_CHANGE

        #region MEMBER
        //public MemberDetails GetPersonalDetails(int empId)
        //{
        //    return new FinDAL().GetMemberById
        //}
        #endregion MEMBER
        #region FINANCIAL_YEAR_SAL_DETAILS
        public void ResetAllowancesDeductions(int FinancialYearsId, int Month)
        {
            new FinDAL().ResetAllowancesDeductions(FinancialYearsId, Month);
        }

        public FinancialYearSalaryDetail GetFinancialYearSalaryDetails(int MonthId, int FinancialYearId)
        {
            return new FinDAL().GetFinancialYearSalaryDetails(MonthId, FinancialYearId);
        }

        public void InsertFinancialYearSalaryDetails(FinancialYearSalaryDetail Temp)
        {
            new FinDAL().InsertFinancialYearSalaryDetails(Temp);
        }
        public void UpdateFinalizeDetail(FinancialYearSalaryDetail Temp)
        {
            new FinDAL().UpdateFinalizeDetail(Temp);
        }
        #endregion
        #region UTILITIES
        public string NumberToWords(int number, bool isUK)
        {
            if (number == 0) return "Zero";
            string and = isUK ? "and " : ""; // deals with UK or US numbering
            if (number == -2147483648) return "Minus Two Billion One Hundred " + and +
            "Forty Seven Million Four Hundred " + and + "Eighty Three Thousand " +
            "Six Hundred " + and + "Forty Eight";
            int[] num = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }
            string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
            string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
            string[] words2 = { "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
            string[] words3 = { "Thousand ", "Million ", "Billion " };
            num[0] = number % 1000;           // units
            num[1] = number / 1000;
            num[2] = number / 1000000;
            num[1] = num[1] - 1000 * num[2];  // thousands
            num[3] = number / 1000000000;     // billions
            num[2] = num[2] - 1000 * num[3];  // millions
            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;
                u = num[i] % 10;              // ones
                t = num[i] / 10;
                h = num[i] / 100;             // hundreds
                t = t - 10 * h;               // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if (h > 0 || i < first) sb.Append(and);
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            return "Rupees " + sb.ToString().TrimEnd() + " Only";
        }
        #endregion

    }
}
