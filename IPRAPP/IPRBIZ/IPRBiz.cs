using BUDENTITIES;
using IPRDAL;
using IPRENITITIES;
using IPRENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IPRBIZ
{
    public class IPRBiz
    {
        #region LOCATIONS
        public List<Location> GetCountryLocations(int CountryId)
        {
            return new IPRDal().GetCountryLocations(CountryId);
        }
        public List<Location> GetCountryLocationsByName(int CountryId, string LocationName)
        {
            return new IPRDal().GetCountryLocationsByName(CountryId, LocationName);
        }
        public Location GetLocation(int LocationId)
        {
            return new IPRDal().GetLocation(LocationId);
        }
        public void InsertLocation(Location location)
        {
            new IPRDal().InsertLocation(location);
        }
        public void UpdateLocation(Location location)
        {
            new IPRDal().UpdateLocation(location);
        }
        public void DeleteLocation(int LocationId)
        {
            new IPRDal().DeleteLocation(LocationId);
        }
        #endregion LOCATIONS
        #region RATES
        public List<LocationRate> GetLocationsRates(int RateListId, int LocationId)
        {
            return new IPRDal().GetLocationsRates(RateListId, LocationId);
        }
        public LocationRate GetLocationsCategoryRate(int RateListId, int LocationId, int CategoryId)
        {
            return new IPRDal().GetLocationsCategoryRate(RateListId, LocationId,CategoryId);
        }
        public void InsertLocationRate(LocationRate locationrate)
        {
            new IPRDal().InsertLocationRate(locationrate);
        }
        public void UpdateLocationRate(LocationRate locationrate)
        {
            new IPRDal().UpdateLocationRate(locationrate);
        }
        public LocationCategoriesRates GetLocationCategoriesRates(int LocationId, int RateListId)
        {
            return new IPRDal().GetLocationCategoriesRates(LocationId, RateListId);
        }
            #endregion RATES
            #region VISITS

            public List<OutgoingVisit> GetAllVisits(int ParliamentaryYearId)
        {
            return new IPRDal().GetAllVisits(ParliamentaryYearId);
        }
        public List<OutgoingVisit> GetPreviousVisits(int ParliamentaryYearId)
        {
            return new IPRDal().GetPreviousVisits(ParliamentaryYearId);
        }
        public List<OutgoingVisit> GetUpcomingVisits(int ParliamentaryYearId)
        {
            return new IPRDal().GetUpcomingVisits(ParliamentaryYearId);
        }
        public OutgoingVisit GetOutgoingVisit(int VisitId)
        {
            return new IPRDal().GetOutgoingVisit(VisitId);
        }

        public void InsertVisit(OutgoingVisit visit)
        {
            new IPRDal().InsertVisit(visit);

        }
        public void UpdateVisit(OutgoingVisit visit)
        {

            new IPRDal().UpdateVisit(visit);
        }
        #endregion VISITS
        #region COMPOSITION
        public List<Composition> GetComposition(int VisitId)
        {
            return new IPRDal().GetComposition(VisitId);
        }
        public void InsertComposition(Composition composition)
        {
            new IPRDal().InsertComposition(composition);
        }
        public void UpdateComposition(Composition composition)
        {
            new IPRDal().UpdateComposition(composition);
        }
        public void DeleteComposition(int CompositionId)
        {
            new IPRDal().DeleteComposition(CompositionId);
        }
        #endregion COMPOSITION
        #region VISITOR TYPE
        public List<VisitorType> GetVisitorTypes()
        {
            return new IPRDal().GetVisitorTypes();
        }
        #endregion
        #region VISTOR STATUS
        public List<VisitorStatus> GetVisitorStatuses()
        {
            return new IPRDal().GetVisitorStatuses();  
        }
        #endregion VISITOR STATUS
        #region VISITOR
        public List<Visitor> GetEmployeeByName(string empname)
        {
            return new IPRDal().GetEmployeeByName(empname);
        }
        public List<Visitor> GetSenatorByName(string empname)
        {
            return new IPRDal().GetSenatorByName(empname);
        }
        #endregion VISITOR
        #region TRAVEL SCHEDULE
        public List<TravelSchedule> GetTravelSchedules(int VisitId)
        {
            return new IPRDal().GetTravelSchedules(VisitId);
        }
        public void InsertTravelSchedule(TravelSchedule travelschedule)
        {
            new IPRDal().InsertTravelSchedule(travelschedule);
        }
        public void UpdateTravelSchedule(TravelSchedule travelschedule)
        {
            new IPRDal().UpdateTravelSchedule(travelschedule);
        }
        public void DeleteTravelSchedule(int TravelScheduleId)
        {
            new IPRDal().DeleteTravelSchedule(TravelScheduleId);
        }
        #endregion TRAVEL SCHEDULE
        #region VISIT DETAILS

        public List<OutgoingVisitDetailEnt> GetVisitDetails(int VisitId)
        {
            return new IPRDal().GetVisitDetails(VisitId);
        }


        public void InsertVisitDetail(OutgoingVisitDetailEnt visit)
        {

            new IPRDal().InsertVisitDetail(visit);

        }
        public void UpdateVisitDetail(OutgoingVisitDetailEnt visit)
        {

            new IPRDal().UpdateVisitDetail(visit);

        }
        public void DeleteVisitDetail(int VisitDetailId)
        {

            new IPRDal().DeleteVisitDetail(VisitDetailId);
        }
        #endregion VISITS DETAIL
        #region  IT_VENDORS
        public List<ITVendors> GetITVendors()
        {
            return new IPRDal().GetITVendors();
        }
        public ITVendors GetITVendor(int VendorId)
        {
            return new IPRDal().GetITVendors(VendorId);
        }
        public void UpdateITVendor(ITVendors Temp)
        {
            new IPRDal().UpdateITVendors(Temp);
        }
        public void InsertITVendor(ITVendors Temp)
        {
            new IPRDal().InsertITVendors(Temp);
        }

        #endregion IT_VENDORS
        #region FRIENDSHIP GROUPS
        public List<FriendshipGroup> GetFriendshipGroups(int TermId)
        {
            return new IPRDal().GetFriendshipGroups(TermId);
        }
        public FriendshipGroup GetFriendshipGroup(int FriendshipGroupId)
        {
            return new IPRDal().GetFriendshipGroup(FriendshipGroupId);
        }
        public void InsertFriendshipGroup(FriendshipGroup obj)
        {
            new IPRDal().InsertFriendshipGroup(obj);
        }
        public void updateFriendshipGroup(FriendshipGroup obj)
        {
            new IPRDal().updateFriendshipGroup(obj);
        }
        public void DeleteFriendshipGroup(int FriendshipGroupId)
        {
            new IPRDal().DeleteFriendshipGroup(FriendshipGroupId);
        }
        #endregion

        #region VISIT_ARRANGEMENT_TYPES
        public List<VisitArrangementType> GetVisitArrangementTypes()
        {
            return new IPRDal().GetVisitArrangementTypes();
        }

        public List<VisitArrangementType> GetActiveVisitArrangementTypes()
        {
            return new IPRDal().GetActiveVisitArrangementTypes();
        }
        public void InsertVisitArrangementType(VisitArrangementType visitArrangementType)
        {

            new IPRDal().InsertVisitArrangementType(visitArrangementType);
        }
        public void UpdateVisitArrangementType(VisitArrangementType visitArrangementType)
        {

            new IPRDal().UpdateVisitArrangementType(visitArrangementType);
        }

        #endregion VISIT_ARRANGEMENT_TYPES
        #region VISIT_FACILITIES
        public List<VisitFacility> GetVisitFacilities()
        {
            return new IPRDal().GetVisitFacilities();
        }

        public List<VisitFacility> GetActiveVisitFacilities()
        {
            return new IPRDal().GetActiveVisitFacilities();
        }
        public void InsertVisitFacility(VisitFacility visitFacility)
        {
            new IPRDal().InsertVisitFacility(visitFacility);
        }
        public void UpdateVisitFacility(VisitFacility visitFacility)
        {
            new IPRDal().UpdateVisitFacility(visitFacility);
        }
        #endregion VISIT_FACILITIES

        #region DA MEMBERS
        public List<DAMember> GetDAMembers(int DADetailId)
        {
           return  new IPRDal().GetDAMembers(DADetailId);
        }

        public void InsertDAMember(DAMember dAMember)
        {
            new IPRDal().InsertDAMember(dAMember);

        }

        #endregion DA MEMBERS
        #region DA_DETAILS
        public List<DADetails> GetDADetails(int VisitId)
        {
            return new IPRDal().GetDADetails(VisitId);
        }
        public double GetDADetailsTotal(int DADetailId)
        {
            return new IPRDal().GetDADetailsTotal(DADetailId);
        }
            public void InsertDADetails(DADetails dADetails)
        {
            new IPRDal().InsertDADetails(dADetails);

        }
        public void UpdateDADetails(DADetails dADetails, int PreviousDADetailId)
        {

            new IPRDal().UpdateDADetails(dADetails, PreviousDADetailId);
        }
        public void DeleteDADetails(int DADetailId)
        {

            new IPRDal().DeleteDADetails(DADetailId);

        }
        public int GetIsChairChargesPaid(int VisitId)
        {
            return new IPRDal().GetIsChairChargesPaid(VisitId);
        }

        #endregion  DA_DETAILS
        #region OUTGOING VISIT SANCTION

        public List<OutgoingVisitSanction> GetOutgoingVisitSanctions(int VisitId)
        {
            return new IPRDal().GetOutgoingVisitSanctions(VisitId);
        }
        public OutgoingVisitSanction GetOutgoingVisitSanction(int SanctionId)
        {
            return new IPRDal().GetOutgoingVisitSanction(SanctionId);
        }
        public void InsertOutgoingVisitSanction(OutgoingVisitSanction Temp)
        {
            new IPRDal().InsertOutgoingVisitSanction(Temp);
        }
        public void UpdateOutgoingVisitSanction(OutgoingVisitSanction Temp)
        {
            new IPRDal().UpdateOutgoingVisitSanction(Temp);
        }
        public void DeleteOutgoingVisitSanction(int SanctionId)
        {
            new IPRDal().DeleteOutgoingVisitSanction(SanctionId);
        }

        #endregion
    }
}
