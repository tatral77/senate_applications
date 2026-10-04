using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUDENTITIES
{
    public class Bills
    {
        public int BillId { get; set; }
        public int FinancialYearId { get; set; }
        public int BillTypeId { get; set; }
        public string BillType { get; set; }
        public string ID { get; set; }
        public int BillStatusId { get; set; }
        public int BillCategoryId { get; set; }
        public string BillCategory { get; set; }
        public string BillStatusDesc { get; set; }
        public int StatusBudgetEffect { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int SystemUserId { get; set; }
        public string EmployeeName { get; set; }
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public string BillDescription { get; set; }
        public string BillNumber { get; set; }
        public DateTime BillDate { get; set; }
        public string SanctionFileNumber { get; set; }
        public DateTime SanctionFileDate { get; set; }
        public int HeadOfAccountId { get; set; }
        public string HeadOfAccount { get; set; }
        public string VendorNumber { get; set; }
        public double TotalAmount { get; set; }
        public double IncomeTax { get; set; }
        public double Gst { get; set; }
        public string StockRegisterDetails { get; set; }
        public double NetAmount { get; set; }
        public string ChequeNumber { get; set; }
        public DateTime ChequeDate { get; set; }
        public string TokenNumber { get; set; }
        public string Remarks { get; set; }
        public int GeneratedBy { get; set; }
        public string DemandNumber { get; set; }
        public string MinorObject { get; set; }
        public string MajorObject { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public string MainId { get; set; }
        public DateTime GeneratedOn { get; set; }
    }
}
