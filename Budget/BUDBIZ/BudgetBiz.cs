using BUDDAL;
using BUDENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUDBIZ
{
    public class BudgetBiz
    {
        #region GET FUND CENTER
        public List<FundCenters> GetFundCenters(int FinancialYearId)
        {
            return new BudgetDal().GetFundCenters(FinancialYearId);
        }
        public List<FundCenters> GetFundCentersList(int FinancialYearId)
        {
            return new BudgetDal().GetFundCentersList(FinancialYearId);
        }
        public FundCenters GetFundCenter(int FundCenterId)
        {
            return new BudgetDal().GetFundCenter(FundCenterId);
        }
        #endregion GET FUND CENTER
        #region FINANCIAL YEAR

        public List<FinancialYears> GetFinancialYears()
        {
            return new BudgetDal().GetFinancialYears();


        }
        public List<FinancialYears> GetActiveFinancialYears()
        {
            return new BudgetDal().GetActiveFinancialYears();
        }
        public FinancialYears GetFinancialYear(int FinancialYearId)
        {
            return new BudgetDal().GetFinancialYear(FinancialYearId);
        }

        public void InsertFinancialYear(FinancialYears financialyear)
        {
            new BudgetDal().InsertFinancialYear(financialyear);
        }
        public void UpdateFinancialYear(FinancialYears financialyear)
        {
            new BudgetDal().UpdateFinancialYear(financialyear);
        }
        public FinancialYears GetCurrentFinancialYear()
        {
            return new BudgetDal().GetCurrentFinancialYear();
        }
        #endregion FINANCIAL YEAR
        #region MAJOR OBJECT
        public List<MajorObjects> GetMajorObjects(int FinancialYearId)
        {
            return new BudgetDal().GetMajorObjects(FinancialYearId);
        }
        public List<MajorObjects> GetActiveMajorObjects()
        {
            return new BudgetDal().GetActiveMajorObjects();
        }
        public List<MajorObjects> GetActiveMajorObjectsByPool(int FundCenterId, int FinancialYearId)
        {
            return new BudgetDal().GetActiveMajorObjectsByPool(FundCenterId, FinancialYearId);
        }
        public MajorObjects GetMajorObject(int MajorObjectId)
        {
            return new BudgetDal().GetMajorObject(MajorObjectId);
        }

        public void InsertMajorObject(MajorObjects majorobject)
        {
            new BudgetDal().InsertMajorObject(majorobject);
        }
        public void UpdateMajorObject(MajorObjects majorobject)
        {
            new BudgetDal().UpdateMajorObject(majorobject);
        }
        public void DeleteMajorObject(int MajorObjectId)
        {
            new BudgetDal().DeleteMajorObject(MajorObjectId);
        }
        public int GetMajorMinors(int MajorObjectId)
        {
            return new BudgetDal().GetMajorMinors(MajorObjectId);
        }
        #endregion MAJOR OBJECT
        #region MINOR OBJECT
        public List<MinorObjects> GetMinorObjects(int FinancialYearId)
        {
            return new BudgetDal().GetMinorObjects(FinancialYearId);
        }
        public List<MinorObjects> GetActiveMinorObjects()
        {
            return new BudgetDal().GetActiveMinorObjects();
        }
        public List<MinorObjects> GetActiveMinorObjectsByMajorObject(int MajorObjectId, int FinancialYearId)
        {
            return new BudgetDal().GetActiveMinorObjectsByMajorObject(MajorObjectId, FinancialYearId);
        }
        public MinorObjects GetMinorObject(int MinorObjectId)
        {
            return new BudgetDal().GetMinorObject(MinorObjectId);
        }

        public void InsertMinorObject(MinorObjects Minorobject)
        {
            new BudgetDal().InsertMinorObject(Minorobject);
        }
        public void UpdateMinorObject(MinorObjects Minorobject)
        {
            new BudgetDal().UpdateMinorObject(Minorobject);
        }
        public void DeleteMinorObject(int MinorobjectId)
        {
            new BudgetDal().DeleteMinorObject(MinorobjectId);
        }
        public int GetMinorHOAs(int MinorObjectId)
        {
            return new BudgetDal().GetMinorHOAs(MinorObjectId);
        }
        #endregion MINOR OBJECT
        #region HEAD OF ACCOUNT
        public List<HeadOfAccounts> GetHeadOfAccounts(int MinorObjectId, int FinancialYearId)
        {
            return new BudgetDal().GetHeadOfAccounts(MinorObjectId, FinancialYearId);
        }
        public List<HeadOfAccounts> GetActiveHeadOfAccounts()
        {
            return new BudgetDal().GetActiveHeadOfAccounts();
        }
        public List<HeadOfAccounts> GetHeadOfAccountsByName(string HeadOfAccount, int FinancialYearId)
        {
            return new BudgetDal().GetHeadOfAccountsByName(HeadOfAccount, FinancialYearId);
        }
        public List<HeadOfAccounts> GetBranchHeadOfAccountsByName(string HeadOfAccount, int FinancialYearId, int BranchId)
        {
            return new BudgetDal().GetBranchHeadOfAccountsByName(HeadOfAccount, FinancialYearId, BranchId);
        }
        public List<HeadOfAccounts> GetEmployeeHeadOfAccountByName(string HeadOfAccount, int FinancialYearId, int EmpId, int BranchId)
        {
            return new BudgetDal().GetEmployeeHeadOfAccountByName(HeadOfAccount, FinancialYearId, EmpId, BranchId);
        }
        public List<HeadOfAccounts> GetFromHeadOfAccountsWithBudget(string HeadOfAccount, int fy)
        {
            return new BudgetDal().GetFromHeadOfAccountsWithBudget(HeadOfAccount, fy);
        }
        public List<HeadOfAccounts> GetToHeadOfAccountsWithBudget(string HeadOfAccount, int fy)
        {
            return new BudgetDal().GetToHeadOfAccountsWithBudget(HeadOfAccount, fy);
        }
        public List<HeadOfAccounts> GetActiveHeadOfAccountsByMinorObject(int MinorObjectId)
        {
            return new BudgetDal().GetActiveHeadOfAccountsByMinorObject(MinorObjectId);
        }
        public HeadOfAccounts GetHeadOfAccount(int HeadOfAccountId)
        {
            return new BudgetDal().GetHeadOfAccount(HeadOfAccountId);
        }

        public int InsertHeadOfAccount(HeadOfAccounts HeadOfAccount)
        {
            return new BudgetDal().InsertHeadOfAccount(HeadOfAccount);

        }
        public void UpdateHeadOfAccount(HeadOfAccounts HeadOfAccount)
        {
            new BudgetDal().UpdateHeadOfAccount(HeadOfAccount);
        }
        public void DeleteHeadOfAccount(int HeadOfAccountId)
        {
            new BudgetDal().DeleteHeadOfAccount(HeadOfAccountId);
        }
        public int GetHOABills(int HeadOfAccountId)
        {
            return new BudgetDal().GetHOABills(HeadOfAccountId);
        }
        #endregion HEAD OF ACCOUNT
        #region BUDGET

        public HeadOfAccountBudget GetHeadOfAccountBudget(int HeadOfAccountId, int FinancialYearId)
        {
            return new BudgetDal().GetHeadOfAccountBudget(HeadOfAccountId, FinancialYearId);
        }

        public void InsertHeadOfAccountBudget(HeadOfAccountBudget headOfAccountBudget)
        {
            new BudgetDal().InsertHeadOfAccountBudget(headOfAccountBudget);
        }
        public void UpdateHeadOfAccountBudget(HeadOfAccountBudget headOfAccountBudget)
        {
            new BudgetDal().UpdateHeadOfAccountBudget(headOfAccountBudget);
        }
        #endregion BUDGET
        #region HEAD_OF_ACCOUNT_BILLS
        public List<Bills> GetBranchFinancialYearsBills(int FinancialYearId, int HeadOfAccountId, int VendorId)
        {
            return new BudgetDal().GetBranchFinancialYearsBills(FinancialYearId, HeadOfAccountId, VendorId);
        }
        public HeadOfAccountBudget GetBranchBudget(int HeadOfAccountId, int FinancialYearId, int BranchId)
        {
            return new BudgetDal().GetBranchBudget(HeadOfAccountId, FinancialYearId, BranchId);
        }

        public List<Bills> GetBranchFinancialYearsBills(string query)
        {
            return new BudgetDal().GetBranchFinancialYearsBills(query);
        }

        public List<Bills> GetVendorFinancialYearsBills(int FinancialYearId, int HeadOfAccountId, int VendorId)
        {
            return new BudgetDal().GetVendorFinancialYearsBills(FinancialYearId, HeadOfAccountId, VendorId);
        }
        public List<Bills> GetEmployeeFinancialYearsBills(int FinancialYearId, int HeadOfAccountId, int EmployeeId)
        {
            return new BudgetDal().GetEmployeeFinancialYearsBills(FinancialYearId, HeadOfAccountId, EmployeeId);
        }
        public int InsertBill(Bills bill)
        {
            return new BudgetDal().InsertBill(bill);
        }
        public void UpdateBill(Bills bill)
        {
            new BudgetDal().UpdateBill(bill);
        }
        public void UpdateBillSanction(Bills bill)
        {
            new BudgetDal().UpdateBillSanction(bill);
        }
        public void DeleteBill(int BillId, int hoaId, int fyid, int BranchId)
        {
            new BudgetDal().DeleteBill(BillId, hoaId, fyid, BranchId);
        }
        public List<Branch> GetBranches()
        {
            return new BudgetDal().GetBranches();
        }
        public List<Branch> GetBudgetBranches()
        {
            return new BudgetDal().GetBudgetBranches();
        }
        public void UpdateBillDetails(Bills bill)
        {
            new BudgetDal().UpdateBillDetails(bill);
        }
        public void DeleteBill(int BillId, int hoaId, int fyid)
        {
            new BudgetDal().DeleteBill(BillId, hoaId, fyid);
        }

        public Bills GetBillById(int BillId)
        {
            return new BudgetDal().GetBillById(BillId);
        }
        #endregion HEAD_OF_ACCOUNT_BILLS

        #region VENDOR
        public List<Vendors> GetVendorByName(string vendorname)
        {
            return new BudgetDal().GetVendorByName(vendorname);
        }
        public List<Vendors> GetVendorByBranch(int BranchId)
        {
            return new BudgetDal().GetVendorByBranch(BranchId);
        }
        public List<Vendors> GetVendorById(int vendorId)
        {
            return new BudgetDal().GetVendorById(vendorId);
        }
        public List<Vendors> GetBranchVendorByName(int BranchId, string vendorname)
        {
            return new BudgetDal().GetBranchVendorByName(BranchId, vendorname);
        }
        #endregion VENDOR
        #region BRANCH HEADS
        public List<BranchHead> GetBranchHeads(int BranchId, int FinancialYearsId)
        {
            return new BudgetDal().GetBranchHeads(BranchId, FinancialYearsId);
        }
        public BranchHead GetBranchHead(int BranchId, int HeadOfAccountId, int FinancialYearsId)
        {
            return new BudgetDal().GetBranchHead(BranchId, HeadOfAccountId,FinancialYearsId);
        }
        public List<BranchHead> GetBranchFundCenterHeads(int BranchId, int FinancialYearsId, int FundCenterId)
        {
            return new BudgetDal().GetBranchFundCenterHeads(BranchId, FinancialYearsId,FundCenterId);
        }
        public void InsertBranchHead(BranchHead bh)
        {
            new BudgetDal().InsertBranchHead(bh);
        }
        public void UpdateBranchHead(BranchHead bh)
        {
            new BudgetDal().UpdateBranchHead(bh);
        }
        public void DeleteBranchHead(int BranchHeadId)
        {
            new BudgetDal().DeleteBranchHead(BranchHeadId);
        }

        #endregion BRANCH HEADS
        #region BRANCH
        public Branch GetBranch(int BranchId)
        {
            return new BudgetDal().GetBranch(BranchId);
        }
        #endregion
        #region RE APPROPRIATION
        public void InsertReAppropriation(ReApproprationEnt bh)
        {
            new BudgetDal().InsertReAppropriation(bh);
        }
        public List<ReApproprationEnt> GetHOAReAppropriation(int FY, int HOA)
        {
            return new BudgetDal().GetHOAReAppropriation(FY, HOA);
        }
        #endregion RE APPROPRIATION
        #region BCR
        public List<Bcr> GetBCR(int FinancialYearId, int HeadOfAccountId)
        {
            return new BudgetDal().GetBCR(FinancialYearId, HeadOfAccountId);
        }
        #endregion BCR
        #region OTHER
        public List<Employees> GetEmployeeByName(string EmployeeName)
        {
            return new BudgetDal().GetEmployeeByName(EmployeeName);
        }
        public void SendToAgpr(int billid)
        {
            new BudgetDal().SendToAgpr(billid);
        }
        #endregion OTHER
        #region Bill_Status
        public List<BillStatus> GetBillStatuses()
        {
            return new BudgetDal().GetBillStatuses();
        }
        #endregion Bill Status
        #region BILL_CATEGORY
        //public List<BillCategories> GetBillCategories()
        //{
        //    return new BudgetDal().GetBillCategories();
        //}
        //public BillCategories GetBillCategory(int CategoryId)
        //{
        //    return new BudgetDal().GetBillCategory(CategoryId);
        //}
        #endregion BILL_CATEGORY



    }
}
