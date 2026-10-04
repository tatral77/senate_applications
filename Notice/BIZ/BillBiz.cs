using DAL;
using Entities;
using LegisEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    public class BillBiz
    {
        #region BILL CATEGORIES
        public List<BillCategories> GetBillCategories()
        {
            return new BillDal().GetBillCategories();
        }
        public List<BillCategories> GetAllBillCategories()
        {
            return new BillDal().GetAllBillCategories();
        }
        public void UpdateBillCategory(BillCategories billCategory)
        {
            new BillDal().UpdateBillCategory(billCategory);
        }
        public void InsertBillCategory(BillCategories billCategory)
        {
            new BillDal().InsertBillCategory(billCategory);
        }
        #endregion BILL CATEGORIES
        #region BILL TYPES
        public List<BillTypes> GetBillTypes()
        {
            return new BillDal().GetBillTypes();
        }
        #endregion BILL TYPES
        public int GetPk(string Table, string Field)
        {
            return new DalHelper().GetPk(Table, Field);
        }

  
        #region BILLS
        public Bills GetBill(int BillsId)
        {
            return new BillDal().GetBill(BillsId);
        }
        public List<Bills> GetBills(int parliamentaryYearsId)
        {
            return new BillDal().GetBills(parliamentaryYearsId);
        }
        public List<Bills> GetBillsByStatus(int BillStatusId)
        {
            return new BillDal().GetBillsByStatus(BillStatusId);
        }

        public List<Bills> GetBillsByHouse(int ParliamentaryYearsId, int HouseTypesId)
        {
            return new BillDal().GetBillsByHouse(ParliamentaryYearsId, HouseTypesId);
        }
        public void InsertBill(Bills bill)
        {
            new BillDal().InsertBill(bill);
        }
        public void InsertNABill(Bills bill)
        {
            new BillDal().InsertNABill(bill);
        }
        public void UpdateBill(Bills bill)
        {
            new BillDal().UpdateBill(bill);
        }
        public void UpdateNABill(Bills bill)
        {
            new BillDal().UpdateNABill(bill);
        }
        public void UpdateCommitteeDetails(Bills bill)
        {
            new BillDal().UpdateCommitteeDetails(bill);
        }
        public void UpdateNADetails(Bills bill)
        {
            new BillDal().UpdateNADetails(bill);
        }
        public void UpdateNABillNADetails(Bills bill)
        {
            new BillDal().UpdateNABillNADetails(bill);
        }
        public void UpdateBillMemberDetails(Bills bill)
        {
            new BillDal().UpdateBillMemberDetails(bill);
        }
        public List<Bills> SearchBills(string query)
        {
            return new BillDal().SearchBills(query);
        }



        #endregion Bills
        #region Misc
        #region MEMBER
        //public List<MemberStatuses> GetMemberStatuses()
        //{
        //    return new AdministrationDAL().GetMemberStatuses();
        //}
        public List<Member> GetMembersByStatus(int StatusId)
        {
            return new BillDal().GetMembersByStatus(StatusId);
        }
        public List<Member> GetMembersByName(string MemberName)
        {
            return new BillDal().GetMemberByName(MemberName);
        }
        public List<Member> GetMemberMinisterByName(string MemberName)
        {
            return new BillDal().GetMemberMinisterByName(MemberName);
        }
        public List<Member> GetAllMemberByName(string MemberName)
        {
            return new BillDal().GetAllMemberByName(MemberName);
        }
        public List<Divisions> GetCurrentDivisionsByName(string DivisionName)
        {
            return new BillDal().GetCurrentDivisionsByName(DivisionName);
        }
        public List<Ministers> GetMinistersByName(string MinisterName)
        {
            return new BillDal().GetMinistersByName(MinisterName);
        }
        #endregion MEMBER
        #endregion
        public void InsertBillFile(string url, int id)
        {
            new BillDal().InsertBillFile(url, id);
        }
        public void InsertNoticeFile(string url, int id)
        {
            new BillDal().InsertNoticeFile(url, id);
        }

    }

}
