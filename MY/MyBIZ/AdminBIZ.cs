using DAL;
using Entities;
using MyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBIZ
{
    public class AdminBIZ
    {
        #region SEARCH
        public List<Items> SearchItems(string query)
        {
            return new AdminDAL().SearchItems(query);
        }
        public List<Employees> GetEmployeeByName(string EmployeeName)
        {
            return new AdminDAL().GetEmployeeByName(EmployeeName);
        }
        public List<Items> GetItemByName(string Item)
        {
            return new AdminDAL().GetItemByName(Item);
        }
        public List<Items> GetItemNameNotAssigned(string Item,int Id)
        {
            return new AdminDAL().GetItemNameNotAssigned(Item,Id);
        }
        public List<Items> GetEmpItemNameNotAssigned(string Item, int Id)
        {
            return new AdminDAL().GetEmpItemNameNotAssigned(Item, Id);
        }
        #endregion
        #region  VENDORS
        public List<AdminVendor> GetAdminVendor()
        {
            return new AdminDAL().GetAdminVendor(); 
        }
        public AdminVendor GetAdminVendor(int VendorId)
        {
            return new AdminDAL().GetAdminVendor(VendorId);
        }
        public void UpdateAdminVendor(AdminVendor Temp)
        {
            new AdminDAL().UpdateAdminVendor(Temp);
        }
        public void InsertAdminVendor(AdminVendor Temp)
        {
            new AdminDAL().InsertAdminVendor(Temp);
        }
        #endregion VENDORS
        #region CATEGORIES
        public List<Categories> GetCategories()
        {
            return new AdminDAL().GetCategories();
        }
        public Categories GetCategory(int CategoryId)
        {
            return new AdminDAL().GetCategory(CategoryId);
        }
        public void UpdateCategory(Categories Temp)
        {
            new AdminDAL().UpdateCategory(Temp);  
        }
        public void InsertCategory(Categories Temp)
        {
            new AdminDAL().InsertCategory(Temp);
        }

        #endregion
        #region  MAIN_ITEMS
        public List<MainItems> GetMainItems()
        {
           return  new AdminDAL().GetMainItems(); 
        }
        public List<MainItems> GetMainItemsByCat(int CategoryId)
        {
            return new AdminDAL().GetMainItemsByCat(CategoryId);
        }
        public MainItems GetMainItem(int MainItemId)
        {
            return new AdminDAL().GetMainItem(MainItemId);
        }
        public void UpdateMainItem(MainItems Temp)
        {
            new AdminDAL().UpdateMainItem(Temp);
        }
        public void InsertMainItem(MainItems Temp)
        {
            new AdminDAL().InsertMainItem(Temp);
        }

        #endregion MAIN_TYPES
        #region  ITEMS
        public List<Items> GetItems()
        {
            return new AdminDAL().GetItems();
        }
        public List<Items> GetThresholdItems()
        {
            return new AdminDAL().GetThresholdItems();
        }
        public List<Items> GetItemsByMainItem(int MainItemId)
        {
            return new AdminDAL().GetItemsByMainItem(MainItemId);
        }
        public Items GetItem(int ItemId)
        {
            return new AdminDAL().GetItem(ItemId);
        }
        public void UpdateItem(Items Temp)
        {
            new AdminDAL().UpdateItem(Temp);
        }
        public void InsertItem(Items Temp)
        {
            new AdminDAL().InsertItem(Temp);
        }
        public List<Items> GetItemsNotInRateList(string Item, int Id)
        {
            return new AdminDAL().GetItemsNotInRateList(Item, Id);
        }
        public void DeleteItem(int ItemId)
        {
            new AdminDAL().DeleteItem(ItemId);
        }
        #endregion ITEM
            #region  BRANDS
        public List<Brands> GetBrands()
        {
            return new AdminDAL().GetBrands();
        }
        public Brands GetBrand(int BrandId)
        {
            return new AdminDAL().GetBrand(BrandId);
        }
        public void UpdateBrand(Brands Temp)
        {
            new AdminDAL().UpdateBrand(Temp);
        }
        public void InsertBrand(Brands Temp)
        {
            new AdminDAL().InsertBrand(Temp);
        }

        #endregion BRANDS
        #region REQUISITIONS
        public List<Requisitions> GetEmployeeRequisitions(int EmployeeId)
        {
            return new AdminDAL().GetEmployeeRequisitions(EmployeeId);
           
        }
        public List<Requisitions> GetRequisitionsByStatus(int StatusId)
        {
            return new AdminDAL().GetRequisitionsByStatus(StatusId);
        }
        public List<Requisitions> GetBranchRequisitions(int BranchId)
        {
            return new AdminDAL().GetBranchRequisitions(BranchId); 
        }
        public Requisitions GetRequisition(int RequisitionId)
        {
            return new AdminDAL().GetRequisition(RequisitionId);
        }
        public void UpdateRequisition(Requisitions Temp)
        {
            new AdminDAL().UpdateRequisition(Temp);
        }
        public int InsertRequisition(Requisitions Temp)
        {
            return new AdminDAL().InsertRequisition(Temp);
        }
        public void DeleteRequisition(int RequisitionId)
        {
            new AdminDAL().DeleteRequisition(RequisitionId);
        }

        #endregion
            #region REQUISITION_ITEM
        public List<RequisitionItems> GetRequistionItems(int RequisitionId)
        {
            return new AdminDAL().GetRequistionItems(RequisitionId);
        }

        public RequisitionItems GetRequisitionItemByItem(int RequisitionId, int ItemId)
        {
            return new AdminDAL().GetRequisitionItemByItem(RequisitionId, ItemId);
        }
        public void UpdateRequisitionItem(RequisitionItems Temp)
        {
            new AdminDAL().UpdateRequisitionItem(Temp);            
        }
        public void InsertRequisitionItem(RequisitionItems Temp)
        {
            new AdminDAL().InsertRequisitionItem(Temp);           
        }
        public void DeleteRequisitionItem(int RequisitionItemId)
        {
            new AdminDAL().DeleteRequisitionItem(RequisitionItemId);
        }
        public RequisitionItems GetRequisitionItem(int RequisitionItemId)
        {
            return new AdminDAL().GetRequisitionItem(RequisitionItemId);
        }


        #endregion
        public List<Branch> GetBranches()
        {
            return new AdminDAL().GetBranches();
        }
        #region  IT_PURCHASES
        public List<Purchases> GetPurchases()
        {
            return new AdminDAL().GetPurchases();
        }
        public Purchases GetPurchase(int PurchaseId)
        {
            return new AdminDAL().GetPurchase(PurchaseId);
        }
        public void UpdatePurchase(Purchases Temp)
        {
            new AdminDAL().UpdatePurchases(Temp);
        }
        public void InsertPurchases(Purchases Temp)
        {
            new AdminDAL().InsertPurchases(Temp);
        }
        #endregion IT_PURCHASES
        #region  UNITS
        public List<CalcUnit> GetUnits()
        {
            return new AdminDAL().GetUnits();
        }
        public CalcUnit GetUnit(int UnitId)
        {
            return new AdminDAL().GetUnit(UnitId);            
        }
        public void UpdateUnit(CalcUnit Temp)
        {
            new AdminDAL().UpdateUnit(Temp);  
        }
        public void InsertUnit(CalcUnit Temp)
        {
            new AdminDAL().InsertUnit(Temp);
        }
        #endregion UNIT
        #region RATE_LIST
        public List<RateList> GetRateListByVendor(int VendorId)
        {
            return new AdminDAL().GetRateListByVendor(VendorId);
        }
        public RateList GetRateList(int RateListId)
        {
            return new AdminDAL().GetRateList(RateListId);
        }
        public void UpdateRateList(RateList Temp)
        {
            new AdminDAL().UpdateRateList(Temp);
        }
        public void InsertRateList(RateList Temp)
        {
            new AdminDAL().InsertRateList(Temp);
        }
        //public void DeleteRequisitionItem(int RequisitionItemId)
        //{

        //}
        #endregion
        #region RATE_LIST_ITEMS
        public List<RateListItem> GetRateListItems(int RateListID)
        {
            return new AdminDAL().GetRateListItems(RateListID);
        }
        public RateListItem GetRateListItem(int RateListId, int ItemId)
        {
            return new AdminDAL().GetRateListItem(RateListId, ItemId);
        }
        public void UpdateRateListItem(RateListItem Temp)
        {
            new AdminDAL().UpdateRateListItem(Temp);
        }
        public void InsertRateListItem(RateListItem Temp)
        {
            new AdminDAL().InsertRateListItem(Temp);
        }
        public void DeleteRateListItem(int RateListItemId)
        {
            new AdminDAL().DeleteRateListItem(RateListItemId);
        }
        #endregion
        #region PURCHASE_ITEMS
        public List<PurchaseItem> GetPurchaseItems(int PurchaseID)
        {
            return new AdminDAL().GetPurchaseItems(PurchaseID);
        }

        public PurchaseItem GetPurchaseItem(int PurchaseItemId)
        {
            return new AdminDAL().GetPurchaseItem(PurchaseItemId);          
        }
        public void UpdatePurchaseItem(PurchaseItem Temp)
        {
            new AdminDAL().UpdatePurchaseItem(Temp);
        }
        public void InsertPurchaseItem(PurchaseItem Temp)
        {
            new AdminDAL().InsertPurchaseItem(Temp);
        }
        public List<Items> GetItemsNotInPurchase(string Item, int Id)
        {
            return new AdminDAL().GetItemsNotInPurchase(Item, Id);
        }
        public void DeletePurchaseItem(int PurchaseItemId)
        {
            new AdminDAL().DeletePurchaseItem(PurchaseItemId);
        }

        #endregion
        #region LOG
        public List<AppLog> GetLog()
        {
            return new AdminDAL().GetLog();

        }
            #endregion



        }
}
