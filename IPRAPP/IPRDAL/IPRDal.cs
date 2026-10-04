using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPRENTITIES;
using System.Data.SqlClient;
using System.Data;
using IPRENITITIES;
using System.Globalization;
using BUDENTITIES;

namespace IPRDAL
{
    public class IPRDal
    {
        #region LOCATIONS
        public List<Location> GetCountryLocations(int CountryId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_COUNTRY_LOCATIONS";
                cmd.Parameters.Add("@CountriesId", SqlDbType.Int).Value = CountryId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Location> locations = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    locations = new List<Location>();
                    while (dr.Read())
                    {
                        Location cy = new Location();
                        cy.LocationId = Convert.ToInt32(dr["LOCATION_ID"]);
                        cy.LocationName = Convert.ToString(dr["LOCATION"]);
                        cy.CountryId = Convert.ToInt32(dr["COUNTRY_ID"]);
                        cy.CityId= Convert.ToInt32(dr["CITY_ID"]);
                        cy.CityName = Convert.ToString(dr["DESCRIPTION"]);

                        locations.Add(cy);
                    }
                }

                if (locations != null) locations.TrimExcess();
                return locations;
            }
            finally
            {
                con.Close();

            }
        }
        public List<Location> GetCountryLocationsByName(int CountryId, string LocationName)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_COUNTRY_LOCATIONS_BY_NAME";
                cmd.Parameters.Add("@CountriesId", SqlDbType.Int).Value = CountryId;
                cmd.Parameters.Add("@LocationName", SqlDbType.VarChar).Value = LocationName;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Location> locations = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    locations = new List<Location>();
                    while (dr.Read())
                    {
                        Location cy = new Location();
                        cy.LocationId = Convert.ToInt32(dr["LOCATION_ID"]);
                        cy.LocationName = Convert.ToString(dr["LOCATION"]);
                        cy.CountryId = Convert.ToInt32(dr["COUNTRY_ID"]);
                        cy.CityId = Convert.ToInt32(dr["CITY_ID"]);
                        cy.CityName = Convert.ToString(dr["DESCRIPTION"]);
                        locations.Add(cy);
                    }
                }

                if (locations != null) locations.TrimExcess();
                return locations;
            }
            finally
            {
                con.Close();

            }
        }
        public LocationCategoriesRates GetLocationCategoriesRates(int LocationId,int RateListId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_LOC_CATEGORIES_RATE";
                cmd.Parameters.Add("@LocationId", SqlDbType.Int).Value = LocationId;
                cmd.Parameters.Add("@RateListId", SqlDbType.Int).Value = RateListId; 
                cmd.CommandType = CommandType.StoredProcedure;
                LocationCategoriesRates cy = new LocationCategoriesRates();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {                        
                        cy.LocationId = Convert.ToInt32(dr["LOCATION_ID"]);
                        cy.RateListId = Convert.ToInt32(dr["RATE_LIST_ID"]);
                        if (Convert.ToInt32(dr["CATEGORY_ID"]) == 1)
                            cy.CatOneRate = Convert.ToInt32(dr["AMOUNT"]);
                        if (Convert.ToInt32(dr["CATEGORY_ID"]) == 2)
                            cy.CatTwoRate = Convert.ToInt32(dr["AMOUNT"]);
                        if (Convert.ToInt32(dr["CATEGORY_ID"]) == 3)
                            cy.CatThreeRate = Convert.ToInt32(dr["AMOUNT"]);
                        if (Convert.ToInt32(dr["CATEGORY_ID"]) == 4)
                            cy.CatFourRate = Convert.ToInt32(dr["AMOUNT"]);
                    }
                }
                return cy;
            }
            finally
            {
                con.Close();
            }

        }
        public Location GetLocation(int LocationId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_LOCATION_BY_ID";
                cmd.Parameters.Add("@LocationId", SqlDbType.Int).Value = LocationId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                Location cy = new Location();
                cy.LocationId = Convert.ToInt32(dr["LOCATION_ID"]);
                cy.LocationName = Convert.ToString(dr["LOCATION"]);
                cy.CountryId = Convert.ToInt32(dr["COUNTRY_ID"]);
                cy.CityId = Convert.ToInt32(dr["CITY_ID"]);
                cy.CityName = Convert.ToString(dr["DESCRIPTION"]);
                return cy;
            }
            finally
            {
                con.Close();

            }
        }
        public void DeleteLocation(int LocationId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_LOCATION";
                cmd.Parameters.Add("@LocationId", SqlDbType.Int).Value = LocationId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
              
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertLocation(Location location)
        {
            int Id = new DalHelper().GetPk("IPR_LOCATIONS", "LOCATION_ID");
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_LOCATION";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LocationId", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@CountriesId", SqlDbType.Int).Value = location.CountryId;
            cmd.Parameters.Add("@LocationName", SqlDbType.VarChar).Value = location.LocationName;
            cmd.Parameters.Add("@CityId", SqlDbType.Int).Value = location.CityId;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }
        public void UpdateLocation(Location location)
        {

            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_LOCATION";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LocationId", SqlDbType.VarChar).Value = location.LocationId;
            cmd.Parameters.Add("@CountriesId", SqlDbType.VarChar).Value = location.CountryId;
            cmd.Parameters.Add("@LocationName", SqlDbType.VarChar).Value = location.LocationName;
            cmd.Parameters.Add("@CityId", SqlDbType.Int).Value = location.CityId;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }
        #endregion COUNTRIES
        #region RATES

        public List<LocationRate> GetLocationsRates(int RateListId,int LocationId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_LOCATION_RATES";
                cmd.Parameters.Add("@RateListId", SqlDbType.Int).Value = RateListId;
                cmd.Parameters.Add("@LocationId", SqlDbType.Int).Value = LocationId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<LocationRate> locations = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    locations = new List<LocationRate>();
                    while (dr.Read())
                    {
                        LocationRate cy = new LocationRate();
                        cy.LocationRateId= Convert.ToInt32(dr["RATE_ID"]);
                        cy.LocationId = Convert.ToInt32(dr["LOCATION_ID"]);
                        cy.RateListId = Convert.ToInt32(dr["RATE_LIST_ID"]);
                        cy.CategoryId = Convert.ToInt32(dr["CATEGORY_ID"]);
                        cy.Rate = Convert.ToInt32(dr["AMOUNT"]);
                        locations.Add(cy);
                    }
                }

                if (locations != null) locations.TrimExcess();
                return locations;
            }
            finally
            {
                con.Close();

            }
        }
        public LocationRate GetLocationRates(int LocationId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_LOCATION_RATES";
                cmd.Parameters.Add("@LocationId", SqlDbType.Int).Value = LocationId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                LocationRate locationRate = new LocationRate();
                if (dr.HasRows)
                {

                    locationRate.LocationRateId = Convert.ToInt32(dr["RATE_ID"]);
                    locationRate.LocationId = Convert.ToInt32(dr["LOCATION_ID"]);
                    locationRate.RateListId = Convert.ToInt32(dr["RATE_LIST_ID"]);
                    locationRate.CategoryId = Convert.ToInt32(dr["CATEGORY_ID"]);
                    locationRate.Rate = Convert.ToInt32(dr["AMOUNT"]);
                }

                return locationRate;
            }
            finally
            {
                con.Close();

            }
        }

        public LocationRate GetLocationsCategoryRate(int RateListId, int LocationId, int CategoryId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_LOCATION_CAT_RATE";
                cmd.Parameters.Add("@RateListId", SqlDbType.Int).Value = RateListId;
                cmd.Parameters.Add("@LocationId", SqlDbType.Int).Value = LocationId;
                cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = CategoryId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                LocationRate cy = new LocationRate();
                if (dr.HasRows)
                {
                    dr.Read();
                   
                    cy.LocationRateId = Convert.ToInt32(dr["RATE_ID"]);
                    cy.LocationId = Convert.ToInt32(dr["LOCATION_ID"]);
                    cy.RateListId = Convert.ToInt32(dr["RATE_LIST_ID"]);
                    cy.CategoryId = Convert.ToInt32(dr["CATEGORY_ID"]);
                    cy.Rate = Convert.ToInt32(dr["AMOUNT"]);
                }
                return cy;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertLocationRate(LocationRate locationrate)
        {
                
                int Id = new DalHelper().GetPk("IPR_RATES", "RATE_ID");
                SqlConnection con = new DalHelper().GetConnection();
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_LOCATION_RATE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RateId", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@RateListId", SqlDbType.Int).Value = locationrate.RateListId;
                cmd.Parameters.Add("@LocationId", SqlDbType.Int).Value = locationrate.LocationId;
                cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = locationrate.CategoryId;
                cmd.Parameters.Add("@Amount", SqlDbType.Int).Value = locationrate.Rate;
                cmd.Connection = con;
            try
            {
                LocationRate lr = GetLocationsCategoryRate(locationrate.RateListId, locationrate.LocationId, locationrate.CategoryId);
                if (lr.LocationRateId==0)
                    cmd.ExecuteReader();
                else
                    UpdateLocationRate(locationrate);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }
        public void UpdateLocationRate(LocationRate locationrate)
        {

            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_LOCATION_RATE";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RateId", SqlDbType.Int).Value = locationrate.LocationRateId;
            cmd.Parameters.Add("@RateListId", SqlDbType.Int).Value = locationrate.RateListId;
            cmd.Parameters.Add("@LocationId", SqlDbType.Int).Value = locationrate.LocationId;
            cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = locationrate.CategoryId;
            cmd.Parameters.Add("@Amount", SqlDbType.Int).Value = locationrate.Rate;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }
        #endregion RATES
        #region VISITS

        public List<OutgoingVisit> GetAllVisits(int FinancialYearId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_IPR_ALL_OUT_VISITS";
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<OutgoingVisit> visit = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    visit = new List<OutgoingVisit>();
                    while (dr.Read())
                    {
                        OutgoingVisit cy = new OutgoingVisit();
                        cy.VisitId = Convert.ToInt32(dr["VISIT_ID"]);
                        cy.VisitTitle = Convert.ToString(dr["VISIT_TITLE"]);
                        cy.CountryId = Convert.ToInt32(dr["COUNTRY_ID"]);
                        cy.CountryName = Convert.ToString(dr["COUNTRY_NAME"]);
                        cy.FromDate = Convert.ToDateTime(dr["FROM_DATE"]);
                        cy.ToDate = Convert.ToDateTime(dr["TO_DATE"]);
                        cy.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                        cy.FinancialYear = Convert.ToString(dr["FINANCIAL_YEAR"]);
                        cy.DollarRate = Convert.ToDouble(dr["DOLLAR_RATE"]);
                        if (dr["TRANSPORT_CHARGES"] != DBNull.Value) { cy.TransportCharges = Convert.ToInt32(dr["TRANSPORT_CHARGES"]); }
                        cy.TransportChargesDescription = Convert.ToString(dr["TRANSPORT_CHARGES_DESCRIPTION"]);
                        visit.Add(cy);
                    }
                }

                if (visit != null) visit.TrimExcess();
                return visit;
            }
            finally
            {
                con.Close();

            }
        }
        public List<OutgoingVisit> GetPreviousVisits(int FinancialYearId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_IPR_PREVIOUS_OUT_VISITS";
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<OutgoingVisit> visit = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    visit = new List<OutgoingVisit>();
                    while (dr.Read())
                    {
                        OutgoingVisit cy = new OutgoingVisit();
                        cy.VisitId = Convert.ToInt32(dr["VISIT_ID"]);
                        cy.VisitTitle = Convert.ToString(dr["VISIT_TITLE"]);
                        cy.CountryId = Convert.ToInt32(dr["COUNTRY_ID"]);
                        cy.CountryName = Convert.ToString(dr["COUNTRY_NAME"]);
                        cy.FromDate = Convert.ToDateTime(dr["FROM_DATE"]);
                        cy.ToDate = Convert.ToDateTime(dr["TO_DATE"]);
                        cy.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                        cy.FinancialYear = Convert.ToString(dr["FINANCIAL_YEAR"]);
                        cy.DollarRate = Convert.ToDouble(dr["DOLLAR_RATE"]);
                        if (dr["TRANSPORT_CHARGES"] != DBNull.Value) { cy.TransportCharges = Convert.ToInt32(dr["TRANSPORT_CHARGES"]); }
                        cy.TransportChargesDescription = Convert.ToString(dr["TRANSPORT_CHARGES_DESCRIPTION"]);
                        visit.Add(cy);
                    }
                }

                if (visit != null) visit.TrimExcess();
                return visit;
            }
            finally
            {
                con.Close();

            }
        }
        public List<OutgoingVisit> GetUpcomingVisits(int FinancialYearId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_IPR_UPCOMING_OUT_VISITS";
                cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = FinancialYearId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<OutgoingVisit> visit = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    visit = new List<OutgoingVisit>();
                    while (dr.Read())
                    {
                        OutgoingVisit cy = new OutgoingVisit();
                        cy.VisitId = Convert.ToInt32(dr["VISIT_ID"]);
                        cy.VisitTitle = Convert.ToString(dr["VISIT_TITLE"]);
                        cy.CountryId = Convert.ToInt32(dr["COUNTRY_ID"]);
                        cy.CountryName = Convert.ToString(dr["COUNTRY_NAME"]);
                        cy.FromDate = Convert.ToDateTime(dr["FROM_DATE"]);
                        cy.ToDate = Convert.ToDateTime(dr["TO_DATE"]);
                        cy.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                        cy.FinancialYear = Convert.ToString(dr["FINANCIAL_YEAR"]);
                        cy.DollarRate = Convert.ToDouble(dr["DOLLAR_RATE"]);
                        if (dr["TRANSPORT_CHARGES"] != DBNull.Value) { cy.TransportCharges = Convert.ToInt32(dr["TRANSPORT_CHARGES"]); }
                        cy.TransportChargesDescription = Convert.ToString(dr["TRANSPORT_CHARGES_DESCRIPTION"]);
                        visit.Add(cy);
                    }
                }

                if (visit != null) visit.TrimExcess();
                return visit;
            }
            finally
            {
                con.Close();

            }
        }
        public OutgoingVisit GetOutgoingVisit(int VisitId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_IPR_OUT_VISIT";
                cmd.Parameters.Add("@VisitId", SqlDbType.Int).Value = VisitId;
                cmd.CommandType = CommandType.StoredProcedure;
                OutgoingVisit cy= null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();  
                    cy = new OutgoingVisit();
                    cy.VisitId = Convert.ToInt32(dr["VISIT_ID"]);
                    cy.VisitTitle = Convert.ToString(dr["VISIT_TITLE"]);
                    cy.CountryId = Convert.ToInt32(dr["COUNTRY_ID"]);
                    cy.CountryName = Convert.ToString(dr["COUNTRY_NAME"]);
                    cy.FromDate = Convert.ToDateTime(dr["FROM_DATE"]);
                    cy.ToDate = Convert.ToDateTime(dr["TO_DATE"]);
                    cy.FinancialYearId = Convert.ToInt32(dr["FINANCIAL_YEAR_ID"]);
                    cy.FinancialYear = Convert.ToString(dr["FINANCIAL_YEAR"]);
                    cy.DollarRate = Convert.ToDouble(dr["DOLLAR_RATE"]);
                    if (dr["TRANSPORT_CHARGES"] != DBNull.Value) { cy.TransportCharges = Convert.ToInt32(dr["TRANSPORT_CHARGES"]); }
                    cy.TransportChargesDescription = Convert.ToString(dr["TRANSPORT_CHARGES_DESCRIPTION"]);
                }

                return cy;
            }
            finally
            {
                con.Close();

            }
        }

        public void InsertVisit(OutgoingVisit visit)
        {
            int Id = new DalHelper().GetPk("IPR_OUTGOING_VISITS", "VISIT_ID");
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_OUT_VISIT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VisitId", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@VisitTitle", SqlDbType.VarChar).Value = visit.VisitTitle;
            cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = visit.CountryId;
            cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = visit.FinancialYearId;
            cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = visit.FromDate;
            cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = visit.ToDate;
            cmd.Parameters.Add("@DollarRate", SqlDbType.Float).Value = visit.DollarRate;
            cmd.Parameters.Add("@Details", SqlDbType.VarChar).Value = visit.Details;
            cmd.Parameters.Add("@TransportCharges", SqlDbType.Int).Value = visit.TransportCharges;
            cmd.Parameters.Add("@TransportChargesDescription", SqlDbType.VarChar).Value = visit.TransportChargesDescription;

            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }
        public void UpdateVisit(OutgoingVisit visit)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_OUT_VISIT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VisitId", SqlDbType.Int).Value = visit.VisitId;
            cmd.Parameters.Add("@VisitTitle", SqlDbType.VarChar).Value = visit.VisitTitle;
            cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = visit.CountryId;
            cmd.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value = visit.FinancialYearId;
            cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = visit.FromDate;
            cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = visit.ToDate;
            cmd.Parameters.Add("@DollarRate", SqlDbType.Float).Value = visit.DollarRate;
            cmd.Parameters.Add("@Details", SqlDbType.VarChar).Value = visit.Details;
            cmd.Parameters.Add("@TransportCharges", SqlDbType.Int).Value = visit.TransportCharges;
            cmd.Parameters.Add("@TransportChargesDescription", SqlDbType.VarChar).Value = visit.TransportChargesDescription;

            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }
        #endregion VISITS
        #region COMPOSITION
        public List<Composition> GetComposition(int VisitId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_VISIT_COMPOSITION";
                cmd.Parameters.Add("@VisitId", SqlDbType.Int).Value = VisitId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Composition> composition = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    composition = new List<Composition>();
                    while (dr.Read())
                    {
                        Composition cy = new Composition();
                        cy.CompositionId = Convert.ToInt32(dr["VISIT_COMP_ID"]);
                        cy.VisitId = Convert.ToInt32(dr["VISIT_ID"]);
                        cy.SystemUserId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        cy.VisitorName = Convert.ToString(dr["F_NAME"]);
                        cy.IsEmployee = Convert.ToInt32(dr["IS_EMPLOYEE"]);
                        cy.IsChairman = Convert.ToInt32(dr["IS_CHAIRMAN"]);
                        cy.Post = Convert.ToString(dr["POST"]);
                        //cy.VisitorTypeId = Convert.ToInt32(dr["VISITOR_TYPE_ID"]);
                        //cy.VisitorType = Convert.ToString(dr["VISITOR_TYPE"]);
                        cy.CategoryId = Convert.ToInt32(dr["CATEGORY_ID"]);
                        cy.CategoryName = Convert.ToString(dr["CATEGORY"]);
                        cy.VisitorStatusId = Convert.ToInt32(dr["VISITOR_STATUS_ID"]);
                        cy.VisitorStatus=Convert.ToString(dr["VISITOR_STATUS"]);
                        cy.VisitorStatusDate= Convert.ToDateTime(dr["VISITOR_STATUS_DATE"]);
                        cy.Remarks= Convert.ToString(dr["REMARKS"]);
                        if (cy.IsEmployee == 0)
                        {
                            if (cy.IsChairman == 1)
                                cy.VisitorName = "Chairman " + cy.VisitorName;
                            else
                                cy.VisitorName = "Senator " + cy.VisitorName;
                        }
                        else
                            cy.VisitorName = cy.VisitorName.TrimEnd() + ", (" + cy.Post + ")";

                        composition.Add(cy);
                    }
                }

                if (composition != null) composition.TrimExcess();
                return composition;
            }
            finally
            {
                con.Close();

            }
        }

        public List<Composition> GetCompositionByIds(int IPRDaDetailsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_VISIT_COMPOSITION_BY_IDS";
                cmd.Parameters.Add("@IprDAdetailId", SqlDbType.Int).Value = IPRDaDetailsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Composition> composition = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    composition = new List<Composition>();
                    while (dr.Read())
                    {
                        Composition cy = new Composition();
                        cy.CompositionId = Convert.ToInt32(dr["VISIT_COMP_ID"]);
                        cy.VisitId = Convert.ToInt32(dr["VISIT_ID"]);
                        cy.SystemUserId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        cy.VisitorName = Convert.ToString(dr["F_NAME"]);
                        cy.IsEmployee = Convert.ToInt32(dr["IS_EMPLOYEE"]);
                        cy.IsChairman = Convert.ToInt32(dr["IS_CHAIRMAN"]);
                        cy.Post = Convert.ToString(dr["POST"]);
                        //cy.VisitorType = Convert.ToString(dr["VISITOR_TYPE"]);
                        cy.CategoryId = Convert.ToInt32(dr["CATEGORY_ID"]);
                        cy.CategoryName = Convert.ToString(dr["CATEGORY"]);
                        cy.VisitorStatusId = Convert.ToInt32(dr["VISITOR_STATUS_ID"]);
                        cy.VisitorStatus = Convert.ToString(dr["VISITOR_STATUS"]);
                        cy.VisitorStatusDate = Convert.ToDateTime(dr["VISITOR_STATUS_DATE"]);
                        cy.Remarks = Convert.ToString(dr["REMARKS"]);
                        if (cy.IsEmployee == 0)
                            cy.VisitorName = cy.VisitorName + " (Senator)";
                        else
                            cy.VisitorName = cy.VisitorName + " (" + cy.Post + ")";

                        composition.Add(cy);
                    }
                }

                if (composition != null) composition.TrimExcess();
                return composition;
            }
            finally
            {
                con.Close();
            }
        }

        public void InsertComposition(Composition composition)
        {
            int Id = new DalHelper().GetPk("IPR_VISIT_COMPOSITION", "VISIT_COMP_ID");
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_VISIT_COMPOSITION";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VisitCompId", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@VisitId", SqlDbType.Int).Value = composition.VisitId;
            cmd.Parameters.Add("@Post", SqlDbType.VarChar).Value = composition.Post;
            cmd.Parameters.Add("@IsEmployee", SqlDbType.Int).Value = composition.IsEmployee;
            cmd.Parameters.Add("@IsChairman", SqlDbType.Int).Value = composition.IsChairman;
            cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = composition.SystemUserId;
            cmd.Parameters.Add("@VisitorStatusId", SqlDbType.Int).Value = composition.VisitorStatusId;
            cmd.Parameters.Add("@VisitorStatusDate", SqlDbType.DateTime).Value = composition.VisitorStatusDate;
            cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = composition.CategoryId;
            cmd.Parameters.Add("@VisitorTypeId", SqlDbType.Int).Value = composition.VisitorTypeId;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = composition.Remarks;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public void UpdateComposition(Composition composition)
        {
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_VISIT_COMPOSITION";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VisitCompId", SqlDbType.Int).Value = composition.CompositionId;
            cmd.Parameters.Add("@VisitId", SqlDbType.Int).Value = composition.VisitId;
            cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = composition.SystemUserId;
            cmd.Parameters.Add("@Post", SqlDbType.VarChar).Value = composition.Post;
            cmd.Parameters.Add("@IsEmployee", SqlDbType.Int).Value = composition.IsEmployee;
            cmd.Parameters.Add("@IsChairman", SqlDbType.Int).Value = composition.IsChairman;
            cmd.Parameters.Add("@VisitorStatusId", SqlDbType.Int).Value = composition.VisitorStatusId;
            cmd.Parameters.Add("@VisitorStatusDate", SqlDbType.DateTime).Value = composition.VisitorStatusDate;
            cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = composition.CategoryId;
            cmd.Parameters.Add("@VisitorTypeId", SqlDbType.Int).Value = composition.VisitorTypeId;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = composition.Remarks;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public void DeleteComposition(int CompositionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_VISIT_COMPOSITION";
                cmd.Parameters.Add("@VisitCompId", SqlDbType.Int).Value = CompositionId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
            }
            finally
            {
                con.Close();
            }
        }

        #endregion COMPOSITION
        #region VISITOR TYPE
        public List<VisitorType> GetVisitorTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_VISITOR_TYPES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<VisitorType> locations = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    locations = new List<VisitorType>();
                    while (dr.Read())
                    {
                        VisitorType cy = new VisitorType();
                        cy.VisitorTypeId = Convert.ToInt32(dr["VISITOR_TYPE_ID"]);
                        cy.VisitorTypeDesc = Convert.ToString(dr["VISITOR_TYPE"]);
                        cy.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        locations.Add(cy);
                    }
                }

                if (locations != null) locations.TrimExcess();
                return locations;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion
        #region VISTOR STATUS
        public List<VisitorStatus> GetVisitorStatuses()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_VISITOR_STATUSES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<VisitorStatus> locations = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    locations = new List<VisitorStatus>();
                    while (dr.Read())
                    {
                        VisitorStatus cy = new VisitorStatus();
                        cy.VisitorStatusId = Convert.ToInt32(dr["VISITOR_STATUS_ID"]);
                        cy.VisitorStatudDesc = Convert.ToString(dr["VISITOR_STATUS"]);
                        locations.Add(cy);
                    }
                }

                if (locations != null) locations.TrimExcess();
                return locations;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion VISITOR STATUS
        #region VISITOR
        public List<Visitor> GetEmployeeByName(string empname)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMPLOYEE_BY_NAME";
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = empname;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Visitor> locations = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    locations = new List<Visitor>();
                    while (dr.Read())
                    {
                        Visitor cy = new Visitor();
                        cy.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        cy.Designation = Convert.ToString(dr["POST"]);
                        cy.VisitorName = Convert.ToString(dr["F_NAME"]);
                        cy.CategoryId = Convert.ToInt32(dr["IPR_CATEGORY_ID"]);
                        cy.IsEmployee= Convert.ToInt32(dr["IS_EMPLOYEE"]);
                        locations.Add(cy);
                    }
                }

                if (locations != null) locations.TrimExcess();
                return locations;
            }
            finally
            {
                con.Close();

            }
        }
        public List<Visitor> GetSenatorByName(string empname)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SENATOR_BY_NAME";
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = empname;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Visitor> locations = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    locations = new List<Visitor>();
                    while (dr.Read())
                    {
                        Visitor cy = new Visitor();
                        cy.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        cy.Designation = Convert.ToString(dr["POST"]);
                        cy.VisitorName = Convert.ToString(dr["F_NAME"]);
                        cy.CategoryId = Convert.ToInt32(dr["IPR_CATEGORY_ID"]);
                        cy.IsEmployee = Convert.ToInt32(dr["IS_EMPLOYEE"]);
                        locations.Add(cy);
                    }
                }

                if (locations != null) locations.TrimExcess();
                return locations;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion VISITOR
        #region POST
        public EmployeePost GetEmployeePost(int SystemUsersId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                //cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CITY_BY_ID";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = SystemUsersId;
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMPLOYEE_POST";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                EmployeePost cy = new EmployeePost();
                dr.Read();
                cy.SystemUserId = SystemUsersId;
                cy.Post = Convert.ToString(dr["POST"]);
                return cy;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion POST
        #region TRAVEL SCHEDULE
        public List<TravelSchedule> GetTravelSchedules(int VisitId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_TRAVEL_SCHEDULE";
                cmd.Parameters.Add("@VisitId", SqlDbType.Int).Value = VisitId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<TravelSchedule> travelschedule = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    travelschedule = new List<TravelSchedule>();
                    while (dr.Read())
                    {
                        TravelSchedule cy = new TravelSchedule();
                        cy.TravelScheduleId = Convert.ToInt32(dr["TRAVEL_SCHEDULE_ID"]);
                        cy.VisitId = Convert.ToInt32(dr["VISIT_ID"]);
                        cy.DepCityId = Convert.ToInt32(dr["DEP_CITY_ID"]);
                        cy.DepCity = Convert.ToString(dr["DEP_CITY"]);
                        cy.DepDate = Convert.ToDateTime(dr["DEP_DATE"]);
                        cy.DepTime = DateTime.ParseExact(dr["DEP_TIME"].ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);
                        cy.ArrCityId = Convert.ToInt32(dr["ARR_CITY_ID"]);
                        cy.ArrCity = Convert.ToString(dr["ARR_CITY"]);
                        cy.ArrDate = Convert.ToDateTime(dr["ARR_DATE"]);
                        cy.ArrTime = DateTime.ParseExact(dr["ARR_TIME"].ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);
                        cy.FlighNumber = Convert.ToString(dr["FLIGHT_NO"]);
                        cy.TravellingCalculated = Convert.ToInt32(dr["TRAVELLING_CALCULATED"]);
                        travelschedule.Add(cy);
                    }
                }

                if (travelschedule != null) travelschedule.TrimExcess();
                return travelschedule;
            }
            finally
            {
                con.Close();

            }
        }


        public void InsertTravelSchedule(TravelSchedule travelschedule)
        {
            int Id = new DalHelper().GetPk("IPR_TRAVEL_SCHEDULE", "TRAVEL_SCHEDULE_ID");
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_TRAVEL_SCHEDULE";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TravelScheduleId", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@VisitId", SqlDbType.Int).Value = travelschedule.VisitId;
            cmd.Parameters.Add("@DepCityId", SqlDbType.Int).Value = travelschedule.DepCityId;
            cmd.Parameters.Add("@DepDate", SqlDbType.DateTime).Value = travelschedule.DepDate;
            cmd.Parameters.Add("@DepTime", SqlDbType.DateTime).Value = travelschedule.DepTime;
            cmd.Parameters.Add("@ArrCityId", SqlDbType.Int).Value = travelschedule.ArrCityId;
            cmd.Parameters.Add("@ArrDate", SqlDbType.DateTime).Value = travelschedule.ArrDate;
            cmd.Parameters.Add("@ArrTime", SqlDbType.DateTime).Value = travelschedule.ArrTime;
            cmd.Parameters.Add("@FlightNumber", SqlDbType.VarChar).Value = travelschedule.FlighNumber;
            cmd.Parameters.Add("@TravellingCalculated", SqlDbType.VarChar).Value = travelschedule.TravellingCalculated;
            cmd.Connection = con;
            try
            {

                cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }
        public void UpdateTravelSchedule(TravelSchedule travelschedule)
        {

            //int Id = new DalHelper().GetPk("IPR_TRAVEL_SCHEDULE", "TRAVEL_SCHEDULE_ID");
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_TRAVEL_SCHEDULE";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TravelScheduleId", SqlDbType.Int).Value = travelschedule.TravelScheduleId;
            cmd.Parameters.Add("@VisitId", SqlDbType.Int).Value = travelschedule.VisitId;
            cmd.Parameters.Add("@DepCityId", SqlDbType.Int).Value = travelschedule.DepCityId;
            cmd.Parameters.Add("@DepDate", SqlDbType.DateTime).Value = travelschedule.DepDate;
            cmd.Parameters.Add("@DepTime", SqlDbType.DateTime).Value = travelschedule.DepTime;
            cmd.Parameters.Add("@ArrCityId", SqlDbType.Int).Value = travelschedule.ArrCityId;
            cmd.Parameters.Add("@ArrDate", SqlDbType.DateTime).Value = travelschedule.ArrDate;
            cmd.Parameters.Add("@ArrTime", SqlDbType.DateTime).Value = travelschedule.ArrTime;
            cmd.Parameters.Add("@FlightNumber", SqlDbType.VarChar).Value = travelschedule.FlighNumber;
            cmd.Parameters.Add("@TravellingCalculated", SqlDbType.VarChar).Value = travelschedule.TravellingCalculated;
            cmd.Connection = con;
            try
            {

                cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }


        }
        public void DeleteTravelSchedule(int TravelScheduleId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_TRAVEL_SCHEDULE";
                cmd.Parameters.Add("@TravelScheduleId", SqlDbType.Int).Value = TravelScheduleId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

            }
            finally
            {
                con.Close();

            }
        }
        #endregion TRAVEL SCHEDULE
        #region VISIT DETAILS

        public List<OutgoingVisitDetailEnt> GetVisitDetails(int VisitId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_VISIT_DETAIL";
                cmd.Parameters.Add("@VisitId", SqlDbType.Int).Value = VisitId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<OutgoingVisitDetailEnt> visit = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    visit = new List<OutgoingVisitDetailEnt>();
                    while (dr.Read())
                    {
                        OutgoingVisitDetailEnt cy = new OutgoingVisitDetailEnt();
                        cy.OutgoingVisitDetailId = Convert.ToInt32(dr["VISIT_DETAIL_ID"]);
                        cy.VisitId = Convert.ToInt32(dr["VISIT_ID"]);
                        cy.LocationId = Convert.ToInt32(dr["LOCATION_ID"]);
                        cy.Location = Convert.ToString(dr["LOCATION"]);
                        cy.FromDate = Convert.ToDateTime(dr["FROM_DATE"]);
                        cy.ToDate = Convert.ToDateTime(dr["TO_DATE"]);
                        cy.NoOfNights = Convert.ToInt32(dr["NO_OF_NIGHTS"]);
                        visit.Add(cy);
                    }
                }

                if (visit != null) visit.TrimExcess();
                return visit;
            }
            finally
            {
                con.Close();

            }
        }


        public void InsertVisitDetail(OutgoingVisitDetailEnt visit)
        {

            int Id = new DalHelper().GetPk("IPR_VISIT_DETAILS", "VISIT_DETAIL_ID");
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_VISIT_DETAIL";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VisitDetailId", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@VisitId", SqlDbType.Int).Value = visit.VisitId;
            cmd.Parameters.Add("@LocationId", SqlDbType.Int).Value = visit.LocationId;
            cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = visit.FromDate;
            cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = visit.ToDate;
            cmd.Parameters.Add("@NoOfNights", SqlDbType.VarChar).Value = visit.NoOfNights;
            cmd.Connection = con;
            try
            {

                cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }
        public void UpdateVisitDetail(OutgoingVisitDetailEnt visit)
        {

            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_VISIT_DETAIL";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VisitDetailId", SqlDbType.Int).Value = visit.OutgoingVisitDetailId;
            cmd.Parameters.Add("@VisitId", SqlDbType.Int).Value = visit.VisitId;
            cmd.Parameters.Add("@LocationId", SqlDbType.Int).Value = visit.LocationId;
            cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = visit.FromDate;
            cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = visit.ToDate;
            cmd.Parameters.Add("@NoOfNights", SqlDbType.VarChar).Value = visit.NoOfNights;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }
        public void DeleteVisitDetail(int VisitDetailId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_VISIT_DETAIL";
                cmd.Parameters.Add("@VisitDetailId", SqlDbType.Int).Value = VisitDetailId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

            }
            finally
            {
                con.Close();

            }
        }
        #endregion VISITS DETAIL
        #region  IT_VENDORS
        public List<ITVendors> GetITVendors()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_VENDORS";
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = 13;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ITVendors> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ITVendors>();
                    while (dr.Read())
                    {
                        ITVendors Temp = new ITVendors();
                        Temp.VendorId = Convert.ToInt32(dr["VENDOR_ID"]);
                        Temp.Vendor = Convert.ToString(dr["VENDOR"]);
                        Temp.Address = Convert.ToString(dr["VEN_ADDRESS"]);
                        Temp.Contacts = Convert.ToString(dr["CONTACTS"]);
                        Temp.Emails = Convert.ToString(dr["EMAILS"]);
                        Temp.Details = Convert.ToString(dr["DETAILS"]);
                        Temp.NTN = Convert.ToString(dr["NTN"]);
                        Temp.VendorNumber = Convert.ToString(dr["VENDOR_NUMBER"]);
                        Temp.BankName = Convert.ToString(dr["BANK"]);
                        Temp.BankAccount = Convert.ToString(dr["BANK_ACCOUNT"]);

                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public ITVendors GetITVendors(int Vendors)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_VENDOR";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                ITVendors Temp = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = new ITVendors();
                    Temp.VendorId = Convert.ToInt32(dr["VENDOR_ID"]);
                    Temp.Vendor = Convert.ToString(dr["VENDOR"]);
                    Temp.Address = Convert.ToString(dr["VEN_ADDRESS"]);
                    Temp.Contacts = Convert.ToString(dr["CONTACTS"]);
                    Temp.Emails = Convert.ToString(dr["EMAILS"]);
                    Temp.Details = Convert.ToString(dr["DETAILS"]);
                    Temp.NTN = Convert.ToString(dr["NTN"]);
                    Temp.VendorNumber = Convert.ToString(dr["VENDOR_NUMBER"]);
                    Temp.BankName = Convert.ToString(dr["BANK"]);
                    Temp.BankAccount = Convert.ToString(dr["BANK_ACCOUNT"]);
                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public void UpdateITVendors(ITVendors Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_VENDOR";
                cmd.Parameters.Add("@VendorId", SqlDbType.Int).Value = Temp.VendorId;
                cmd.Parameters.Add("@Vendor", SqlDbType.VarChar).Value = Temp.Vendor;
                cmd.Parameters.Add("@VenAddress", SqlDbType.VarChar).Value = Temp.Address;
                cmd.Parameters.Add("@Contacts", SqlDbType.VarChar).Value = Temp.Contacts;
                cmd.Parameters.Add("@Emails", SqlDbType.VarChar).Value = Temp.Emails;
                cmd.Parameters.Add("@Details", SqlDbType.VarChar).Value = Temp.Details;
                cmd.Parameters.Add("@NTN", SqlDbType.VarChar).Value = Temp.NTN;
                cmd.Parameters.Add("@VendorNumber", SqlDbType.VarChar).Value = Temp.VendorNumber;
                cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = 23;
                cmd.Parameters.Add("@Bank", SqlDbType.VarChar).Value = Temp.BankName;
                cmd.Parameters.Add("@BankAccount", SqlDbType.VarChar).Value = Temp.BankAccount;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertITVendors(ITVendors Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[BUDGET_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_VENDOR";
                cmd.Parameters.Add("@Vendor", SqlDbType.VarChar).Value = Temp.Vendor;
                cmd.Parameters.Add("@VenAddress", SqlDbType.VarChar).Value = Temp.Address;
                cmd.Parameters.Add("@Contacts", SqlDbType.VarChar).Value = Temp.Contacts;
                cmd.Parameters.Add("@Emails", SqlDbType.VarChar).Value = Temp.Emails;
                cmd.Parameters.Add("@Details", SqlDbType.VarChar).Value = Temp.Details;
                cmd.Parameters.Add("@NTN", SqlDbType.VarChar).Value = Temp.NTN;
                cmd.Parameters.Add("@VendorNumber", SqlDbType.VarChar).Value = Temp.VendorNumber;
                cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = 13;
                cmd.Parameters.Add("@Bank", SqlDbType.VarChar).Value = Temp.BankName;
                cmd.Parameters.Add("@BankAccount", SqlDbType.VarChar).Value = Temp.BankAccount;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion IT_VENDORS
        #region FRIENDSHIP GROUPS
        public List<FriendshipGroup> GetFriendshipGroups(int TermId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_FRIENDSHIP_GROUPS";
                cmd.Parameters.Add("@TermId", SqlDbType.Int).Value = TermId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<FriendshipGroup> friendshipGroups = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    friendshipGroups = new List<FriendshipGroup>();
                    while (dr.Read())
                    {
                        FriendshipGroup cy = new FriendshipGroup();
                        cy.FriendshipGroupId = Convert.ToInt32(dr["FRIENDSHIP_GROUP_ID"]);
                        cy.GroupName = Convert.ToString(dr["FRIENDSHIP_GROUP"]);
                        cy.CountryId = Convert.ToInt32(dr["COUNTRY_ID"]);
                        cy.Country = Convert.ToString(dr["COUNTRY"]);
                        cy.ConvinerId = Convert.ToInt32(dr["CONVINER_ID"]);
                        cy.ConvinerName = Convert.ToString(dr["F_NAME"]);
                        cy.TermId = Convert.ToInt32(dr["TERM_ID"]);
                        cy.Term = Convert.ToString(dr["TERM"]);
                        friendshipGroups.Add(cy);
                    }
                }

                if (friendshipGroups != null) friendshipGroups.TrimExcess();
                return friendshipGroups;
            }
            finally
            {
                con.Close();

            }
        }
        public FriendshipGroup GetFriendshipGroup(int FriendshipGroupId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_FRIENDSHIP_GROUP";
                cmd.Parameters.Add("@FriendshipGroupId", SqlDbType.Int).Value = FriendshipGroupId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                FriendshipGroup cy = null;
                if (dr.HasRows)
                {
                        cy = new FriendshipGroup();
                        cy.FriendshipGroupId = Convert.ToInt32(dr["FRIENDSHIP_GROUP_ID"]);
                        cy.GroupName = Convert.ToString(dr["FRIENDSHIP_GROUP"]);
                        cy.CountryId = Convert.ToInt32(dr["COUNTRY_ID"]);
                        cy.Country = Convert.ToString(dr["COUNTRY"]);
                        cy.ConvinerId = Convert.ToInt32(dr["CONVINER_ID"]);
                        cy.ConvinerName = Convert.ToString(dr["F_NAME"]);
                        cy.TermId = Convert.ToInt32(dr["TERM_ID"]);
                        cy.Term = Convert.ToString(dr["TERM"]);
                }

                return cy;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertFriendshipGroup(FriendshipGroup obj)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_FRIENDSHIP_GROUP";
                cmd.Parameters.Add("@FriendshipGroup", SqlDbType.VarChar).Value = obj.GroupName;
                cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = obj.CountryId;
                cmd.Parameters.Add("@ConvinerId", SqlDbType.Int).Value = obj.ConvinerId;
                cmd.Parameters.Add("@TermId", SqlDbType.Int).Value = obj.TermId;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void updateFriendshipGroup(FriendshipGroup obj)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_FRIENDSHIP_GROUP";
                cmd.Parameters.Add("@FriendshipGroupId", SqlDbType.Int).Value = obj.FriendshipGroupId;
                cmd.Parameters.Add("@FriendshipGroup", SqlDbType.VarChar).Value = obj.GroupName;
                cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = obj.CountryId;
                cmd.Parameters.Add("@ConvinerId", SqlDbType.Int).Value = obj.ConvinerId;
                cmd.Parameters.Add("@TermId", SqlDbType.Int).Value = obj.TermId;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void DeleteFriendshipGroup(int FriendshipGroupId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_FRIENDSHIP_GROUP";
                cmd.Parameters.Add("@FriendshipGroupId", SqlDbType.Int).Value = FriendshipGroupId;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion

        #region VISIT_ARRANGEMENT_TYPES
        public List<VisitArrangementType> GetVisitArrangementTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_VISIT_ARRANGEMENT_TYPES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<VisitArrangementType> VisitArrangementType = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    VisitArrangementType = new List<VisitArrangementType>();
                    while (dr.Read())
                    {
                        VisitArrangementType cy = new VisitArrangementType();
                        cy.VisitArrangementTypeId = Convert.ToInt32(dr["IPR_VISIT_ARRANGEMENT_TYPE_ID"]);
                        cy.ArrangementType = Convert.ToString(dr["ARRANGEMENT_TYPE"]);
                        cy.Details = Convert.ToString(dr["DETAILS"]);
                        cy.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        VisitArrangementType.Add(cy);
                    }
                }

                if (VisitArrangementType != null) VisitArrangementType.TrimExcess();
                return VisitArrangementType;
            }
            finally
            {
                con.Close();

            }
        }

        public List<VisitArrangementType> GetActiveVisitArrangementTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_VISIT_ARRANGEMENT_TYPES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<VisitArrangementType> VisitArrangementType = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    VisitArrangementType = new List<VisitArrangementType>();
                    while (dr.Read())
                    {
                        VisitArrangementType cy = new VisitArrangementType();
                        cy.VisitArrangementTypeId = Convert.ToInt32(dr["IPR_VISIT_ARRANGEMENT_TYPE_ID"]);
                        cy.ArrangementType = Convert.ToString(dr["ARRANGEMENT_TYPE"]);
                        cy.Details = Convert.ToString(dr["DETAILS"]);
                        cy.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        VisitArrangementType.Add(cy);
                    }
                }

                if (VisitArrangementType != null) VisitArrangementType.TrimExcess();
                return VisitArrangementType;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertVisitArrangementType(VisitArrangementType visitArrangementType)
        {
            int Id = new DalHelper().GetPk("IPR_VISIT_ARRANGEMENT_TYPES", "IPR_VISIT_ARRANGEMENT_TYPE_ID");
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_VISIT_ARRANGEMENT_TYPES";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IprVisitArrangementTypeId", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@ArrangementType", SqlDbType.VarChar).Value = visitArrangementType.ArrangementType;
            cmd.Parameters.Add("@Details", SqlDbType.VarChar).Value = visitArrangementType.Details;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = 1;
            cmd.Connection = con;
            try
            {

                cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }
        public void UpdateVisitArrangementType(VisitArrangementType visitArrangementType)
        {

            //int Id = new DalHelper().GetPk("IPR_TRAVEL_SCHEDULE", "TRAVEL_SCHEDULE_ID");
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_VISIT_ARRANGEMENT_TYPES";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IprVisitArrangementTypeId", SqlDbType.Int).Value = visitArrangementType.VisitArrangementTypeId;
            cmd.Parameters.Add("@ArrangementType", SqlDbType.VarChar).Value = visitArrangementType.ArrangementType;
            cmd.Parameters.Add("@Details", SqlDbType.VarChar).Value = visitArrangementType.Details;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = visitArrangementType.IsActive;
            cmd.Connection = con;
            try
            {

                cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }


        }
        #endregion VISIT_ARRANGEMENT_TYPES

        #region VISIT_FACILITIES
        public List<VisitFacility> GetVisitFacilities()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_VISIT_FACILITIES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<VisitFacility> visitFacilities = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    visitFacilities = new List<VisitFacility>();
                    while (dr.Read())
                    {
                        VisitFacility cy = new VisitFacility();
                        cy.VisitFacilityId = Convert.ToInt32(dr["VISIT_FACILITIES_ID"]);
                        cy.Facility = Convert.ToString(dr["VISIT_FACILITY"]);
                        cy.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        visitFacilities.Add(cy);
                    }
                }

                if (visitFacilities != null) visitFacilities.TrimExcess();
                return visitFacilities;
            }
            finally
            {
                con.Close();

            }
        }

        public List<VisitFacility> GetActiveVisitFacilities()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_VISIT_FACILITIES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<VisitFacility> visitFacilities = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    visitFacilities = new List<VisitFacility>();
                    while (dr.Read())
                    {
                        VisitFacility cy = new VisitFacility();
                        cy.VisitFacilityId = Convert.ToInt32(dr["VISIT_FACILITIES_ID"]);
                        cy.Facility = Convert.ToString(dr["VISIT_FACILITY"]);
                        cy.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        visitFacilities.Add(cy);
                    }
                }

                if (visitFacilities != null) visitFacilities.TrimExcess();
                return visitFacilities;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertVisitFacility(VisitFacility visitFacility)
        {
            int Id = new DalHelper().GetPk("IPR_VISIT_FACILITIES", "VISIT_FACILITIES_ID");
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_VISIT_FACILITY";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VisitFacilityId", SqlDbType.Int).Value = visitFacility.VisitFacilityId;
            cmd.Parameters.Add(" @VisitFacility", SqlDbType.VarChar).Value = visitFacility.Facility;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = 1;
            cmd.Connection = con;
            try
            {

                cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }
        public void UpdateVisitFacility(VisitFacility visitFacility)
        {

            //int Id = new DalHelper().GetPk("IPR_TRAVEL_SCHEDULE", "TRAVEL_SCHEDULE_ID");
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_VISIT_FACILITY";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VisitFacilityId", SqlDbType.Int).Value = visitFacility.VisitFacilityId;
            cmd.Parameters.Add(" @VisitFacility", SqlDbType.VarChar).Value = visitFacility.Facility;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = 1;
            cmd.Connection = con;
            try
            {

                cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }


        }
        #endregion TRAVEL SCHEDULE
        #region DA MEMBERS
        public List<DAMember> GetDAMembers(int DADetailId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_DA_MEMBERS";
                cmd.Parameters.Add("@IprDAdetailId", SqlDbType.Int).Value = DADetailId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<DAMember> dAMembers = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dAMembers = new List<DAMember>();
                    while (dr.Read())
                    {
                        DAMember cy = new DAMember();
                        cy.DADetailMemberId= Convert.ToInt32(dr["DA_DETAIL_MEMBER_ID"]);
                        cy.DADetailId = Convert.ToInt32(dr["DA_DETAIL_ID"]);
                        cy.CategoryId = Convert.ToInt32(dr["CATEGORY_ID"]);
                        cy.Category = Convert.ToString(dr["CATEGORY"]);
                        cy.SystemUserId = Convert.ToInt32(dr["SYSTEM_USER_ID"]);
                        cy.Post = Convert.ToString(dr["POST"]);
                        cy.IsChairman = Convert.ToInt32(dr["IS_CHAIRMAN"]);
                        cy.Formula = Convert.ToString(dr["FORMULA"]);
                        cy.TotalDA = Convert.ToDouble(dr["TOTAL_DA"]);
                        cy.VisitorName = Convert.ToString(dr["F_NAME"]);
                        cy.DaRemarks = Convert.ToString(dr["DA_REMARKS"]);
                        dAMembers.Add(cy);
                    }
                }

                if (dAMembers != null) dAMembers.TrimExcess();
                return dAMembers;
            }
            finally
            {
                con.Close();

            }
        }

        public void InsertDAMember(DAMember dAMember)
        {
            int Id = new DalHelper().GetPk("IPR_DA_DETAIL_MEMBERS", "DA_DETAIL_MEMBER_ID");
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_DA_MEMBER";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DADetailMemberId", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@DADetailId", SqlDbType.Int).Value = dAMember.DADetailId;
            cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = dAMember.SystemUserId;
            cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = dAMember.CategoryId;
            cmd.Parameters.Add("@IsChairman", SqlDbType.Int).Value = dAMember.IsChairman;
            cmd.Parameters.Add("@TotalDA", SqlDbType.Float).Value = dAMember.TotalDA;
            cmd.Parameters.Add("@DaRemarks", SqlDbType.NVarChar).Value = dAMember.DaRemarks;
            cmd.Parameters.Add("@Formula", SqlDbType.NVarChar).Value = dAMember.Formula;
            cmd.Parameters.Add("@Post", SqlDbType.NVarChar).Value = dAMember.Post;
            cmd.Connection = con;
            try
            {

                cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }
    
        #endregion DA MEMBERS
        
        #region DA_DETAILS

        public List<DADetails> GetDADetails(int VisitId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_VISIT_DA_DETAILS";
                cmd.Parameters.Add("@VisitId", SqlDbType.Int).Value = VisitId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<DADetails> dADetails = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dADetails = new List<DADetails>();
                    while (dr.Read())
                    {
                        DADetails cy = new DADetails();
                        cy.DADetailsId = Convert.ToInt32(dr["IPR_DA_DETAIL_ID"]);
                        cy.VisitId = Convert.ToInt32(dr["VISIT_ID"]);
                        cy.CountryId = Convert.ToInt32(dr["COUNTRY_ID"]);
                        cy.LocationId = Convert.ToInt32(dr["LOCATION_ID"]);
                        cy.ArrangementTypeId = Convert.ToInt32(dr["ARRANGEMENT_TYPE_ID"]);
                        cy.FacilityId = Convert.ToInt32(dr["FACILITY_ID"]);
                        cy.NoOfNights = Convert.ToInt32(dr["NIGHTS"]);
                        cy.HigerSidePayment = Convert.ToInt32(dr["HIGHER_SIDE_PAYMENT"]);
                        cy.HotelCharges = Convert.ToInt32(dr["HOTEL_CHARGES"]);
                        cy.EarlyCheckinCharges = Convert.ToInt32(dr["EARLY_CHECK_IN_CHARGES"]);
                        cy.LatecheckOutCharges = Convert.ToInt32(dr["LATE_CHECKOUT_CHARGES"]);
                        cy.Country = Convert.ToString(dr["COUNTRY"]);
                        cy.Location = Convert.ToString(dr["LOCATION"]);
                        cy.Arrangement = Convert.ToString(dr["ARRANGEMENT_TYPE"]);
                        cy.Facility = Convert.ToString(dr["VISIT_FACILITY"]);
                        cy.IsChairChargesPaid = Convert.ToInt32(dr["IS_CHAIR_CHARGES_PAID"]);
                        if (!Convert.IsDBNull(dr["FROM_DATE"])) { cy.FromDate = Convert.ToDateTime(dr["FROM_DATE"]);  } //by Ismail
                        if (!Convert.IsDBNull(dr["TO_DATE"])) { cy.ToDate = Convert.ToDateTime(dr["TO_DATE"]); } //by Ismail
                        cy.Members = GetDAMembers(cy.DADetailsId);
                        if (cy.Members != null)
                        {
                            foreach (DAMember member in cy.Members)
                            {
                                cy.Total += member.TotalDA;
                            }
                        }
                        dADetails.Add(cy);
                    }
                }

                if (dADetails != null) dADetails.TrimExcess();
                return dADetails;
            }
            finally
            {
                con.Close();

            }
        }
        public double GetDADetailsTotal(int DADetailId)
        {
            SqlConnection con = new DalHelper().GetConnection();
          
            try
            {
                double total = 0;
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_DA_DETAILS_TOTAL";
                cmd.Parameters.Add("@IprDAdetailId", SqlDbType.Int).Value = DADetailId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
              
                if (dr.HasRows)
                {
                    dr.Read();
                    total = Convert.ToDouble(dr["TOTAL"]);
                }

               
                return total;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertDADetails(DADetails dADetails)
        {
            int Id = new DalHelper().GetPk("IPR_VISIT_DA_DETAILS", "IPR_DA_DETAIL_ID");
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_VISIT_DA_DETAILS";
            cmd.CommandType = CommandType.StoredProcedure;
           // ,,,,,,,,,,
            cmd.Parameters.Add("@IprDAdetailId", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@VisitId", SqlDbType.Int).Value = dADetails.VisitId;
            cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = dADetails.CountryId;
            cmd.Parameters.Add("@LocationId", SqlDbType.Int).Value = dADetails.LocationId;
            cmd.Parameters.Add("@IprVisitArrangementTypeId", SqlDbType.Int).Value = dADetails.ArrangementTypeId;
            cmd.Parameters.Add("@VisitFacilityId", SqlDbType.Int).Value = dADetails.FacilityId;
            cmd.Parameters.Add("@NoOfNights", SqlDbType.Int).Value = dADetails.NoOfNights;
            cmd.Parameters.Add("@HigerSidePayment", SqlDbType.Int).Value = dADetails.HigerSidePayment;
            cmd.Parameters.Add("@HotelCharges", SqlDbType.Int).Value = dADetails.HotelCharges;
            cmd.Parameters.Add("@EarlyCheckIncharges", SqlDbType.Int).Value = dADetails.EarlyCheckinCharges;
            cmd.Parameters.Add("@LateCheckoutCharges", SqlDbType.VarChar).Value = dADetails.LatecheckOutCharges;
            cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = dADetails.FromDate; //by Ismail
            cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = dADetails.ToDate; //by Ismail
            cmd.Parameters.Add("@IsChairChargesPaid", SqlDbType.Int).Value = dADetails.IsChairChargesPaid; //by Ismail
            if (dADetails.Members!=null)
            {
                foreach(DAMember member in dADetails.Members)
                {
                    member.DADetailId = Id;
                    InsertDAMember(member);
                }
            }
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }
        public void UpdateDADetails(DADetails dADetails, int PreviousDADetailId)
        {

            DeleteDADetails(PreviousDADetailId);
            InsertDADetails(dADetails);

        }
        public void DeleteDADetails(int DADetailId)
        {

            //int Id = new DalHelper().GetPk("IPR_TRAVEL_SCHEDULE", "TRAVEL_SCHEDULE_ID");
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_VISIT_DA_DETAILS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IprDAdetailId", SqlDbType.Int).Value = DADetailId;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }


        }
        public int GetIsChairChargesPaid(int VisitId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_IS_CHAIR_CHARGES_PAID";
                cmd.Parameters.Add("@VisitId", SqlDbType.Int).Value = VisitId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    return 1;
                else
                    return 0;
            }
            finally
            {
                con.Close();

            }
        }

        #endregion  DA_DETAILS

        #region OUTGOING VISIT SANCTION

        public List<OutgoingVisitSanction> GetOutgoingVisitSanctions(int VisitId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_OUTGOING_VISIT_SANCTIONS";
                cmd.Parameters.Add("@VisitId", SqlDbType.Int).Value = VisitId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<OutgoingVisitSanction> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<OutgoingVisitSanction>();
                    while (dr.Read())
                    {
                        OutgoingVisitSanction Temp = new OutgoingVisitSanction();
                        Temp.VisitId = Convert.ToInt32(dr["VISIT_ID"]);
                        Temp.SanctionId = Convert.ToInt32(dr["VISIT_SANCTION_ID"]);
                        Temp.FileNo = Convert.ToString(dr["FILE_NO"]);
                        Temp.SanctionDate = Convert.ToDateTime(dr["SANCTION_DATE"]);
                        Temp.Subject = Convert.ToString(dr["SUBJECT"]);
                        Temp.MovedBy = Convert.ToString(dr["MOVED_BY"]);
                        Temp.IncurredOn = Convert.ToString(dr["INCURRED_ON"]);
                        Temp.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public OutgoingVisitSanction GetOutgoingVisitSanction(int SanctionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_OUTGOING_VISIT_SANCTION";
                cmd.Parameters.Add("@SanctionId", SqlDbType.Int).Value = SanctionId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                OutgoingVisitSanction Temp = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp = new OutgoingVisitSanction();
                    Temp.SanctionId = Convert.ToInt32(dr["VISIT_SANCTION_ID"]);
                    Temp.VisitId = Convert.ToInt32(dr["VISIT_ID"]);
                    Temp.FileNo = Convert.ToString(dr["FILE_NO"]);
                    Temp.SanctionDate = Convert.ToDateTime(dr["SANCTION_DATE"]);
                    Temp.Subject = Convert.ToString(dr["SUBJECT"]);
                    Temp.MovedBy = Convert.ToString(dr["MOVED_BY"]);
                    Temp.IncurredOn = Convert.ToString(dr["INCURRED_ON"]);
                    Temp.RuleNo = Convert.ToString(dr["RULE_NO"]);
                    Temp.HeadOfAccount = Convert.ToString(dr["HEAD_OF_ACCOUNT"]);
                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertOutgoingVisitSanction(OutgoingVisitSanction Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_OUTGOING_VISIT_SANCTION";
                cmd.Parameters.Add("@VisitId", SqlDbType.Int).Value = Temp.VisitId;
                cmd.Parameters.Add("@SanctionDate", SqlDbType.DateTime).Value = Temp.SanctionDate;
                cmd.Parameters.Add("@MovedBy", SqlDbType.VarChar).Value = Temp.MovedBy;
                cmd.Parameters.Add("@Subject", SqlDbType.VarChar).Value = Temp.Subject;
                cmd.Parameters.Add("@IncurredOn", SqlDbType.VarChar).Value = Temp.IncurredOn;
                cmd.Parameters.Add("@FileNo", SqlDbType.VarChar).Value = Temp.FileNo;
                cmd.Parameters.Add("@RuleNo", SqlDbType.VarChar).Value = Temp.RuleNo;
                cmd.Parameters.Add("@HeadOfAccount", SqlDbType.VarChar).Value = Temp.HeadOfAccount;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void UpdateOutgoingVisitSanction(OutgoingVisitSanction Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_OUTGOING_VISIT_SANCTION";
                cmd.Parameters.Add("@SanctionId", SqlDbType.Int).Value = Temp.SanctionId;
                cmd.Parameters.Add("@VisitId", SqlDbType.Int).Value = Temp.VisitId;
                cmd.Parameters.Add("@SanctionDate", SqlDbType.DateTime).Value = Temp.SanctionDate;
                cmd.Parameters.Add("@MovedBy", SqlDbType.VarChar).Value = Temp.MovedBy;
                cmd.Parameters.Add("@Subject", SqlDbType.VarChar).Value = Temp.Subject;
                cmd.Parameters.Add("@IncurredOn", SqlDbType.VarChar).Value = Temp.IncurredOn;
                cmd.Parameters.Add("@FileNo", SqlDbType.VarChar).Value = Temp.FileNo;
                cmd.Parameters.Add("@RuleNo", SqlDbType.VarChar).Value = Temp.RuleNo;
                cmd.Parameters.Add("@HeadOfAccount", SqlDbType.VarChar).Value = Temp.HeadOfAccount;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void DeleteOutgoingVisitSanction(int SanctionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_OUTGOING_VISIT_SANCTION";
                cmd.Parameters.Add("@SanctionId", SqlDbType.Int).Value = SanctionId;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion
    }
}
