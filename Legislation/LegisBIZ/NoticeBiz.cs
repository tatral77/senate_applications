using LegisDAL;
using LegisEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisBIZ
{
    public class NoticeBiz
    {
        #region Bills
        public List<Bills> GetNoticeBills()
        {
            return new NoticeDal().GetNoticeBills();
        }
        #region BILL CATEGORIES
        public List<BillCategories> GetBillCategories()
        {
            return new NoticeDal().GetBillCategories();
        }
        public List<BillCategories> GetAllBillCategories()
        {
            return new NoticeDal().GetAllBillCategories();
        }
        public void UpdateBillCategory(BillCategories billCategory)
        {
            new NoticeDal().UpdateBillCategory(billCategory);
        }
        public void InsertBillCategory(BillCategories billCategory)
        {
            new NoticeDal().InsertBillCategory(billCategory);
        }
        #endregion BILL CATEGORIES
        #region BILL TYPES
        public List<BillTypes> GetBillTypes()
        {
            return new NoticeDal().GetBillTypes();
        }
        #endregion BILL TYPES
        public int GetPk(string Table, string Field)
        {
            return new DalHelper().GetPk(Table, Field);
        }


        #region BILLS
        public Bills GetBill(int BillsId)
        {
            return new NoticeDal().GetBill(BillsId);
        }
        public List<Bills> GetBills(int parliamentaryYearsId)
        {
            return new NoticeDal().GetBills(parliamentaryYearsId);
        }
        public List<Bills> GetBillsByStatus(int BillStatusId)
        {
            return new NoticeDal().GetBillsByStatus(BillStatusId);
        }

        public List<Bills> GetBillsByHouse(int ParliamentaryYearsId, int HouseTypesId)
        {
            return new NoticeDal().GetBillsByHouse(ParliamentaryYearsId, HouseTypesId);
        }
        public void InsertBill(Bills bill)
        {
            new NoticeDal().InsertBill(bill);
        }
        public void InsertNABill(Bills bill)
        {
            new NoticeDal().InsertNABill(bill);
        }
        public void UpdateBill(Bills bill)
        {
            new NoticeDal().UpdateBill(bill);
        }
        public void UpdateNABill(Bills bill)
        {
            new NoticeDal().UpdateNABill(bill);
        }
        public void UpdateCommitteeDetails(Bills bill)
        {
            new NoticeDal().UpdateCommitteeDetails(bill);
        }
        public void UpdateNADetails(Bills bill)
        {
            new NoticeDal().UpdateNADetails(bill);
        }
        public void UpdateNABillNADetails(Bills bill)
        {
            new NoticeDal().UpdateNABillNADetails(bill);
        }
        public void UpdateBillMemberDetails(Bills bill)
        {
            new NoticeDal().UpdateBillMemberDetails(bill);
        }
        public List<Bills> SearchBills(string query)
        {
            return new NoticeDal().SearchBills(query);
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
            return new NoticeDal().GetMembersByStatus(StatusId);
        }
        public List<Member> GetMembersByName(string MemberName)
        {
            return new NoticeDal().GetMemberByName(MemberName);
        }
        public List<Member> GetMemberMinisterByName(string MemberName)
        {
            return new NoticeDal().GetMemberMinisterByName(MemberName);
        }
        public List<Member> GetAllMemberByName(string MemberName)
        {
            return new NoticeDal().GetAllMemberByName(MemberName);
        }
        public List<Divisions> GetCurrentDivisionsByName(string DivisionName)
        {
            return new NoticeDal().GetCurrentDivisionsByName(DivisionName);
        }
        public List<Ministers> GetMinistersByName(string MinisterName)
        {
            return new NoticeDal().GetMinistersByName(MinisterName);
        }
        #endregion MEMBER
        #endregion
        public void InsertBillFile(string url, int id)
        {
            new NoticeDal().InsertBillFile(url, id);
        }

        #endregion
    }
}
