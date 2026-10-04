using LegisEntities;
using LegisDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUDENTITIES;
using System.Data.SqlClient;
using System.Data;

namespace LegisBIZ
{
    public class LegislationBiz
    {
        public int GetPk(string TableName, string Field)
        {
            return new DalHelper().GetPk(TableName, Field);
        }
        public string GetMemberNameById(int MemberId)
        {
            return new LegislationDal().GetMemberNameById(MemberId);
        }
        public string GetMinistryNameById(int MinistryId)
        {
            return new LegislationDal().GetMinistryNameById(MinistryId);
        }

        #region BILLS
        public Bills GetBill(int BillsId)
        {
            return new LegislationDal().GetBill(BillsId);
        }
        public List<Bills> GetBills(int parliamentaryYearsId)
        {
            return new LegislationDal().GetBills(parliamentaryYearsId);
        }
        public List<Bills> GetBillsByStatus(int BillStatusId)
        {
            return new LegislationDal().GetBillsByStatus(BillStatusId);
        }

        public List<Bills> GetBillsByHouse(int ParliamentaryYearsId, int HouseTypesId)
        {
            return new LegislationDal().GetBillsByHouse(ParliamentaryYearsId,HouseTypesId);
        }
            public void InsertBill(Bills bill)
        {
             new LegislationDal().InsertBill(bill);
        }
        public int InsertNoticeBill(Bills bill,int NoticeId)
        {
            return new LegislationDal().InsertNoticeBill(bill,NoticeId);
        }
        public void InsertNABill(Bills bill)
        {
            new LegislationDal().InsertNABill(bill);
        }
        public void UpdateBill(Bills bill)
        {
            new LegislationDal().UpdateBill(bill);
        }
        public void UpdateNABill(Bills bill)
        {
            new LegislationDal().UpdateNABill(bill);
        }
        public void UpdateCommitteeDetails(Bills bill)
        {
            new LegislationDal().UpdateCommitteeDetails(bill);
        }
        public void UpdateNADetails(Bills bill)
        {
            new LegislationDal().UpdateNADetails(bill);
        }
        public void UpdateNABillNADetails(Bills bill)
        {
            new LegislationDal().UpdateNABillNADetails(bill);
        }
        public void UpdateBillMemberDetails(Bills bill)
        {
            new LegislationDal().UpdateBillMemberDetails(bill);
        }
        public List<Bills> SearchBills(string query)
        {
            return new LegislationDal().SearchBills(query);
        }



        #endregion Bills

        //------------------------------------END-------------------------------------//

        #region BILL STATUS
        public List<BillStatuses> GetBillStatuses()
        {
            return new LegislationDal().GetBillStatuses();
        }
        public List<BillStatuses> GetActiveBillStatuses()
        {
            return new LegislationDal().GetActiveBillStatuses();
        }
        public void UpdateBillStatuses(BillStatuses billStatuses)
        {
            new LegislationDal().UpdateBillStatuses(billStatuses);
        }
        public void InsertBillStatuses(BillStatuses billStatuses)
        {
            new LegislationDal().InsertBillStatuses(billStatuses);
        }
        #endregion BILL STATUS

        //------------------------------------END-------------------------------------//

        #region BILL TYPES
        public List<BillTypes> GetBillTypes()
        {
            return new LegislationDal().GetBillTypes();
        }
        #endregion BILL TYPES

        //------------------------------------END-------------------------------------//

        #region BILL CATEGORIES
        public List<BillCategories> GetBillCategories()
        {
            return new LegislationDal().GetBillCategories();
        }
        public List<BillCategories> GetAllBillCategories()
        {
            return new LegislationDal().GetAllBillCategories();
        }
        public void UpdateBillCategory(BillCategories billCategory)
        {
            new LegislationDal().UpdateBillCategory(billCategory);
        }
        public void InsertBillCategory(BillCategories billCategory)
        {
            new LegislationDal().InsertBillCategory(billCategory);
        }
        #endregion BILL CATEGORIES

        //------------------------------------END-------------------------------------//

        #region ASSEMBLY SESSIONS
        public AssemblySessions GetCurrentAssemblySessionDetails()
        {
            return new LegislationDal().GetCurrentAssemblySessionDetails();
        }
        public List<AssemblySessions> GetAssemblySessions()
        {
            return new LegislationDal().GetAssemblySessions();
        }
        public int GetCurrentAssemblySessions()
        {
            return new LegislationDal().GetCurrentAssemblySessions();
        }
        public void UpdateAssemblySessions(AssemblySessions Temp)
        {
            new LegislationDal().UpdateAssemblySessions(Temp);
        }
        public int InsertAssemblySessions(AssemblySessions Temp)
        {
            return new LegislationDal().InsertAssemblySessions(Temp);
        }
        #endregion ASSEMBLY SESSIONS

        //------------------------------------END-------------------------------------//

        #region  ParliamentaryTenures

        public List<ParliamentaryTenures> GetParliamentaryTenuress()
        {
            return new LegislationDal().GetParliamentaryTenures();
        }
        public void UpdateParliamentaryTerms(ParliamentaryTenures Temp)
        {
            new LegislationDal().UpdateParliamentaryTenures(Temp);
        }
        public void InsertParliamentaryTenure(ParliamentaryTenures Temp)
        {
            new LegislationDal().InsertParliamentaryTenures(Temp);
        }

        #endregion ParliamentaryTerms

        //------------------------------------END-------------------------------------//

        #region  ParliamentaryTerms

        public List<ParliamentaryTerms> GetParliamentaryTerms()
        {
            return new LegislationDal().GetParliamentaryTerms();
        }
        public ParliamentaryTerms GetCurrentParliamentaryTerms()
        {
            return new LegislationDal().GetCurrentParliamentaryTerm();
        }
        public ParliamentaryTerms GetParliamentaryTerm(int TermId)
        {
            return new LegislationDal().GetParliamentaryTerm(TermId);
        }
        public void UpdateParliamentaryTerm(ParliamentaryTerms Temp)
        {
            new LegislationDal().UpdateParliamentaryTerm(Temp);
        }
        public void InsertParliamentaryTerm(ParliamentaryTerms Temp)
        {
            new LegislationDal().InsertParliamentaryTerm(Temp);
        }

        #endregion ParliamentaryTerms
        #region Parliamentary_Years

        public List<ParliamentaryYears> GetParliamentaryYears()
        {
            return new LegislationDal().GetParliamentaryYears();
        }
        public ParliamentaryYears GetCurrentParliamentaryYear()
        {
            return new LegislationDal().GetCurrentParliamentaryYear();
        }
        public void UpdateParliamentaryYears(ParliamentaryYears Temp)
        {
            new LegislationDal().UpdateParliamentaryYears(Temp);
        }
        public void InsertParliamentaryYears(ParliamentaryYears Temp)
        {
            new LegislationDal().InsertParliamentaryYears(Temp);
        }

        #endregion Parliamentary_Years


        //------------------------------------END-------------------------------------//

        #region Assemblies
        public List<Assemblies> GetAssemblies()
        {
            return new LegislationDal().GetAssemblies();
        }
        public void UpdateAssemblies(Assemblies Temp)
        {
            new LegislationDal().UpdateAssemblies(Temp);
        }
        public void InsertAssemblies(Assemblies Temp)
        {
            new LegislationDal().InsertAssemblies(Temp);
        }

        #endregion Assemblies

        //------------------------------------END-------------------------------------//

        #region SittingTypes

        public List<SittingTypes> GetSittingTypes()
        {
            return new LegislationDal().GetSittingTypes();
        }
        public void UpdateSittingTypes(SittingTypes Temp)
        {
            new LegislationDal().UpdateSittingTypes(Temp);
        }
        public void InsertSittingTypes(SittingTypes Temp)
        {
            new LegislationDal().InsertSittingTypes(Temp);
        }

        #endregion SittingTypes

        //------------------------------------END-------------------------------------//

        #region SessionSittings

        public List<SessionSittings> GetSessionSitting()
        {
            return new LegislationDal().GetSessionSitting();
        }
        public void UpdateSessionSittings(SessionSittings Temp)
        {
            new LegislationDal().UpdateSessionSittings(Temp);
        }
        public void InsertSessionSittings(SessionSittings Temp)
        {
            new LegislationDal().InsertSessionSittings(Temp);
        }

        #endregion SessionSitting

        //------------------------------------END-------------------------------------//

        //#region Parliamentary Year
        //public ParliamentaryYears GetCurrentParliamentaryYear()
        //{
        //    return new LegislationDal().GetCurrentParliamentaryYear();
        //}
        //#endregion

        //------------------------------------END-------------------------------------//

        #region Session Groups
        public void CopySessionGroups(int CurrentSession, int PreviousSession)
        {
            new LegislationDal().CopySessionGroups(CurrentSession, PreviousSession);
        }
        #endregion

        //------------------------------------END-------------------------------------//

        #region Bill Documents
        public void InsertBillDocument(BillDocumentsEnt billDocumentsEnt)
        {
            new LegislationDal().InsertBillDocument(billDocumentsEnt);
        }
        public void UpdateBillDocument(BillDocumentsEnt billDocumentsEnt)
        {
            new LegislationDal().UpdateBillDocument(billDocumentsEnt);
        }
        public List<BillDocumentsEnt> GetBillDocuments(int BillId)
        {
            return new LegislationDal().GetBillDocuments(BillId);
        }
        #endregion

        #region Bill Document Types
        public List<DocumentTypes> GetDocumentTypes()
        {
            return new LegislationDal().GetDocumentTypes();
        }
        #endregion

        #region  Ministers
        public List<Ministers> GetMinistersByName(string MinisterName)
        {
            return new LegislationDal().GetMinistersByName(MinisterName);
        }
            public List<Ministers> GetActiveMinisters()
        {
            return new LegislationDal().GetActiveMinisters();
        }
        public List<Ministers> GetAllMinisters()
        {
            return new LegislationDal().GetAllMinisters();
        }
        public void UpdateMinister(Ministers Temp)
        {
          new LegislationDal().UpdateMinister(Temp);
        }
        public void InsertMinister(Ministers Temp)
        {
             new LegislationDal().InsertMinister(Temp);
        }

        #endregion
        #region  Political Parties

        public List<PoliticalParty> GetPoliticalParties()
        {
            return new LegislationDal().GetPoliticalParties();
        }

        #endregion

        #region Bill Ministers
        protected List<BillMinisters> GetBillMinisters(int BillId)
        {
            return new LegislationDal().GetBillMinisters(BillId);
        }
        protected void InsertBillMinisters(List<BillMinisters> billMovers, int BillId)
        {
            new LegislationDal().InsertBillMinisters(billMovers, BillId);

        }
        #endregion
        #region Bill Status History
        public void InsertBillStatusHistory(BillStatusHistory Temp)
        {
            new LegislationDal().InsertBillStatusHistory(Temp);
            
        }
        public List<BillStatusHistory> GetBillStatusHistory(int BillsId)
        {
            return new LegislationDal().GetBillStatusHistory(BillsId);
        }
        #endregion

        #region Ordinance
        public void InsertOrdinance(Ordinances ordinances)
        {
            new LegislationDal().InsertOrdinance(ordinances);
        }
        public void UpdateOrdinance(Ordinances ordinances)
        {
            new LegislationDal().UpdateOrdinance(ordinances);
        }
        public List<Ordinances> GetOrdinances(int ParliamentaryYearsId)
        {
            return new LegislationDal().GetOrdinances(ParliamentaryYearsId);
        }
        public Ordinances GetOrdinance(int OrdinanceId)
        {
            return new LegislationDal().GetOrdinance(OrdinanceId);
        }
        public List<Ordinances> SearchOrdinance(string query)
        {
            return new LegislationDal().SearchOrdinance(query);
        }
        #endregion

        #region Ordinance Documents

        public void InsertOrdinanceDocument(OrdinanceDocuments ordinanceDocuments)
        {
            new LegislationDal().InsertOrdinanceDocument(ordinanceDocuments);
        }
        public void UpdateOrdinanceDocument(OrdinanceDocuments ordinanceDocuments)
        {
            new LegislationDal().UpdateOrdinanceDocument(ordinanceDocuments);
        }
        public void DeleteOrdinanceDocument(int OrdinanceDocumentsId)
        {
            new LegislationDal().DeleteOrdinanceDocument(OrdinanceDocumentsId);
        }
            public List<OrdinanceDocuments> GetOrdinancelDocuments(int OrdinanceDocumentsId)
        {
            return new LegislationDal().GetOrdinanceDocuments(OrdinanceDocumentsId);
        }
        public OrdinanceDocuments GetOrdinanceDocument(int DocumentId)
        {
            return new LegislationDal().GetOrdinanceDocument(DocumentId);
        }

        #endregion Ordinance Documents
        #region Ordinance Statuses
        public List<OrdinanceStatuses> GetOrdinanceStatuses()
        {
            return new LegislationDal().GetOrdinanceStatuses();
        }
        #endregion
        #region Status History
        public void InsertOrdinanceStatusHistory(OrdinanceStatusHistory history)
        {
            new LegislationDal().InsertOrdinanceStatusHistory(history);
        }
        public List<OrdinanceStatusHistory> GetOrdinanceStatusHistory(int OrdinanceId)
        {
            return new LegislationDal().GetOrdinanceStatusHistory(OrdinanceId);
        }
        #endregion

        #region OD

        #region OD SITTINGS

        public List<SessionSittings> GetSittingsForOrdersOfDay(int assemblySessionsId)
        {
            return new LegislationDal().GetSittingsFortOrdersOfDay(assemblySessionsId);
        }

        #endregion OD SITTINGS
      
        #region ORDER OF THE DAY TYPES

        public List<OrderOfDayType> GetOrderOfDayTypes()
        {
            return new LegislationDal().GetOrderOfDayTypes();
        }


        public OrderOfDayType GetOrderOfDayTypeById(int odTypeId)
        {
            return new LegislationDal().GetOrderOfDayTypeById(odTypeId);
        }


        public int GetMaxOrderOfDayTypeId()
        {
            return new LegislationDal().GetMaxOrderOfDayTypeId();
        }


        public void InsertOrderOfDayType(OrderOfDayType orderOfDayType)
        {
           new LegislationDal().InsertOrderOfDayType(orderOfDayType);
        }


        public void UpdateOrderOfDayType(OrderOfDayType orderOfDayType)
        {
             new LegislationDal().UpdateOrderOfDayType(orderOfDayType);
        }

        #endregion ORDER OF THE DAY TYPES

        #region ORDERS OF THE DAY

        public List<OrderOfDay> GetOrdersOfDayBySession(int assemblySessionsId)
        {
            return new LegislationDal().GetOrdersOfDayBySession(assemblySessionsId);
        }
        public OrderOfDay GetActiveOrdersOfDayByCurrentSession()
        {
            return new LegislationDal().GetActiveOrdersOfDayByCurrentSession();
        }
            public OrderOfDay GetOrderOfDayById(int odId)
        {
            return new LegislationDal().GetOrderOfDayById(odId);
        }

        public int GetMaxOrderOfDayId()
        {
            return new LegislationDal().GetMaxOrderOfDayId();
        }

        public void InsertOrderOfDay(OrderOfDay orderOfDay)
        {
            new LegislationDal().InsertOrderOfDay(orderOfDay);
        }

        public void UpdateOrderOfDay(OrderOfDay orderOfDay)
        {
            new LegislationDal().UpdateOrderOfDay(orderOfDay);
        }

        #endregion ORDERS OF THE DAY

        #region BUSINESS TYPE 
        public List<BusinessType> GetBusinessTypes()
        {
            return new LegislationDal().GetBusinessTypes();
        }
            #endregion
            #region ORDERS OF THE DAY BUSINESS

            public List<OrderOfTheDayBusiness> GetOrderOfTheDayBusiness(int odId)
        {
            return new LegislationDal().GetOrderOfTheDayBusiness(odId);
        }

        public OrderOfTheDayBusiness GetOrderOfTheDayBusinessById(int odBusinessId)
        {
            return new LegislationDal().GetOrderOfTheDayBusinessById(odBusinessId);
        }

        public int GetMaxOrderOfTheDayBusinessId()
        {
            return new LegislationDal().GetMaxOrderOfTheDayBusinessId();
        }

        public int InsertOrderOfTheDayBusiness(OrderOfTheDayBusiness business)
        {
            return new LegislationDal().InsertOrderOfTheDayBusiness(business);
        }

        public void UpdateOrderOfTheDayBusiness(OrderOfTheDayBusiness business)
        {
            new LegislationDal().UpdateOrderOfTheDayBusiness(business);
        }

        public void DeleteOrderOfTheDayBusiness(int odBusinessId)
        {
            new LegislationDal().DeleteOrderOfTheDayBusiness(odBusinessId);
        }

        #endregion ORDERS OF THE DAY BUSINESS


        #region ORDERS OF THE DAY BUSINESS ATTACHMENTS

        public List<OrderOfDayBusinessAttachment> GetOrderOfDayBusinessAttachments(
            int odBusinessId)
        {
            return new LegislationDal()
                .GetOrderOfDayBusinessAttachments(odBusinessId);
        }

        public int GetMaxOrderOfDayBusinessAttachmentId()
        {
            return new LegislationDal()
                .GetMaxOrderOfDayBusinessAttachmentId();
        }

        public void InsertOrderOfDayBusinessAttachment(
            OrderOfDayBusinessAttachment attachment)
        {
            new LegislationDal()
                .InsertOrderOfDayBusinessAttachment(attachment);
        }

        public void UpdateOrderOfDayBusinessAttachment(
            OrderOfDayBusinessAttachment attachment)
        {
            new LegislationDal()
                .UpdateOrderOfDayBusinessAttachment(attachment);
        }

        public void DeleteOrderOfDayBusinessAttachments(int OdBusinessId)
        {
            new LegislationDal()
                .DeleteOrderOfDayBusinessAttachments(OdBusinessId);
        }

        #endregion ORDERS OF THE DAY BUSINESS ATTACHMENTS

        #endregion OD

    }




}

