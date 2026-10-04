using DataEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataManagementDAL
    {
        #region COUNTRIES
        public List<Country> GetActiveCountries()
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_COUNTRIES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Country> countries = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    countries = new List<Country>();
                    while (dr.Read())
                    {
                        Country cy = new Country();
                        cy.CountryId = Convert.ToInt32(dr["countries_ID"]);
                        cy.CountryName = Convert.ToString(dr["Description"]);
                        cy.Cities = GetCountryCities(cy.CountryId);
                        cy.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        countries.Add(cy);
                    }
                }

                if (countries != null) countries.TrimExcess();
                return countries;
            }
            finally
            {
                con.Close();

            }
        }
        public List<Country> GetAllCountries()
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ALL_COUNTRIES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Country> countries = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    countries = new List<Country>();
                    while (dr.Read())
                    {
                        Country cy = new Country();
                        cy.CountryId = Convert.ToInt32(dr["countries_ID"]);
                        cy.CountryName = Convert.ToString(dr["Description"]);
                        cy.Cities = GetCountryCities(cy.CountryId);
                        cy.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        countries.Add(cy);
                    }
                }

                if (countries != null) countries.TrimExcess();
                return countries;
            }
            finally
            {
                con.Close();

            }
        }

        public Country GetCountry(int countryId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_COUNTRY_BY_ID";
                cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = countryId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                Country cy = new Country();
                cy.CountryId = Convert.ToInt32(dr["countries_ID"]);
                cy.CountryName = Convert.ToString(dr["Description"]);
                cy.Cities = GetCountryCities(cy.CountryId);
                cy.IsActive = Convert.ToInt32(dr["Is_Active"]);
                return cy;
            }
            finally
            {
                con.Close();

            }
        }

        public List<City> GetCountryCities(int countryId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_COUNTRY_CITIES";
                cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = countryId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                List<City> cities = null;
                if (dr.HasRows)
                {
                    cities = new List<City>();
                    while (dr.Read())
                    {
                        City cy = new City();
                        cy.CityId = Convert.ToInt32(dr["cities_ID"]);
                        cy.CityName = Convert.ToString(dr["Description"]);
                        cy.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        cities.Add(cy);
                    }
                }
                if (cities != null) cities.TrimExcess();

                return cities;
            }
            finally
            {
                con.Close();

            }



        }
        public void InsertCountry(Country country)
        {
            int Id = new DalHelper().GetPk("countries", "countries_id");
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_COUNTRY";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@CountryName", SqlDbType.VarChar).Value = country.CountryName;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = country.IsActive;
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
        public void UpdateCountry(Country country)
        {

            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_COUNTRY";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CountryId", SqlDbType.VarChar).Value = country.CountryId;
            cmd.Parameters.Add("@CountryName", SqlDbType.VarChar).Value = country.CountryName;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = country.IsActive;
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
        #region CITIES
        public List<City> GetCities()
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_CITIES";

                cmd.CommandType = CommandType.StoredProcedure;
                List<City> cities = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    cities = new List<City>();
                    while (dr.Read())
                    {
                        City cy = new City();
                        cy.CityId = Convert.ToInt32(dr["cities_ID"]);
                        cy.CityName = Convert.ToString(dr["Description"]);
                        cy.CountryId = Convert.ToInt32(dr["Countries_ID"]);
                        cy.CountryName = Convert.ToString(dr["Country_Name"]);
                        cy.CountryDivisionId = Convert.ToInt32(dr["Provinces_ID"]);
                        cy.CountryDivisionName = Convert.ToString(dr["Province_Name"]);
                        cy.IsDistrict = Convert.ToInt32(dr["Is_District"]);
                        cy.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        cities.Add(cy);
                    }
                }

                if (cities != null) cities.TrimExcess();
                return cities;
            }
            finally
            {
                con.Close();

            }
        }
        public List<City> GetAllCities()
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ALL_CITIES";

                cmd.CommandType = CommandType.StoredProcedure;
                List<City> cities = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    cities = new List<City>();
                    while (dr.Read())
                    {
                        City cy = new City();
                        cy.CityId = Convert.ToInt32(dr["cities_ID"]);
                        cy.CityName = Convert.ToString(dr["Description"]);
                        cy.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        cities.Add(cy);
                    }
                }

                if (cities != null) cities.TrimExcess();
                return cities;
            }
            finally
            {
                con.Close();

            }
        }




        public City GetCity(int cityId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                //cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CITY_BY_ID";
                cmd.Parameters.Add("@CityId", SqlDbType.Int).Value = cityId;
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CITY_BY_ID";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                City cy = new City();
                dr.Read();
                cy.CityId = Convert.ToInt32(dr["cities_ID"]);
                cy.CityName = Convert.ToString(dr["Description"]);
                cy.IsActive = Convert.ToInt32(dr["Is_Active"]);
                return cy;
            }
            finally
            {
                con.Close();

            }

        }

        public List<City> GetCities(int countryid)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ALL_CITIES_BY_COUNTRY";
                cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = countryid;
                cmd.CommandType = CommandType.StoredProcedure;
                List<City> cities = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    cities = new List<City>();
                    while (dr.Read())
                    {
                        City cy = new City();
                        cy.CityId = Convert.ToInt32(dr["cities_ID"]);
                        cy.CityName = Convert.ToString(dr["Description"]);
                        cy.CountryDivisionId= Convert.ToInt32(dr["Provinces_Id"]);
                        cy.CountryDivisionName = Convert.ToString(dr["Province_Name"]);
                        cy.CountryId = Convert.ToInt32(dr["countries_ID"]);
                        cy.CountryName = Convert.ToString(dr["country_Name"]);
                        cy.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        cities.Add(cy);
                    }
                }

                if (cities != null) cities.TrimExcess();
                return cities;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertCity(City city)
        {
            int Id = new DalHelper().GetPk("CITIES", "CITIES_ID");
            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@CityId", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_CITY";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CityName", SqlDbType.VarChar).Value = city.CityName;
            cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = city.CountryId;
            cmd.Parameters.Add("@ProvinceId", SqlDbType.Int).Value = city.CountryDivisionId;
            cmd.Parameters.Add("@IsDistrict", SqlDbType.Int).Value = city.IsDistrict;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = city.IsActive;
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
        public void UpdateCity(City city)
        {

            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_CITY";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CityId", SqlDbType.VarChar).Value = city.CityId;
            cmd.Parameters.Add("@CityName", SqlDbType.VarChar).Value = city.CityName;
            cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = city.CountryId;
            cmd.Parameters.Add("@ProvinceId", SqlDbType.Int).Value = city.CountryDivisionId;
            cmd.Parameters.Add("@IsDistrict", SqlDbType.Int).Value = city.IsDistrict;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = city.IsActive;
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


        #endregion CITIES
        #region COUNTRY DIVISIONS
        public List<CountryDivision> GetActiveCountryDivisions(int CountryId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_CountryDivisionS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<CountryDivision> prov = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    prov = new List<CountryDivision>();
                    while (dr.Read())
                    {
                        CountryDivision pr = new CountryDivision();
                        pr.CountryDivisionId = Convert.ToInt32(dr["CountryDivisions_id"]);
                        pr.CountryDivisionName = Convert.ToString(dr["Description"]);
                        pr.CountryDivisionTypeId = Convert.ToInt32(dr["Country_Division_Type_Id"]);
                        pr.CountryDivisionType = Convert.ToString(dr["Country_Division_Type"]);
                        pr.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        prov.Add(pr);
                    }
                }

                if (prov != null) prov.TrimExcess();
                return prov;
            }
            finally
            {
                con.Close();
            }
        }
        public List<CountryDivision> GetCountryDivisions(int CountryId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PROVINCES";
                cmd.Parameters.Add("@CountryId", SqlDbType.VarChar).Value = CountryId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<CountryDivision> prov = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    prov = new List<CountryDivision>();
                    while (dr.Read())
                    {
                        CountryDivision pr = new CountryDivision();
                        pr.CountryDivisionId = Convert.ToInt32(dr["Provinces_id"]);
                        pr.CountryDivisionName = Convert.ToString(dr["Description"]);
                        pr.CountryDivisionTypeId = Convert.ToInt32(dr["Country_Division_Type_Id"]);
                        pr.CountryDivisionType = Convert.ToString(dr["Country_Division_Type"]);
                        pr.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        prov.Add(pr);
                    }
                }

                if (prov != null) prov.TrimExcess();
                return prov;
            }
            finally
            {
                con.Close();
            }
        }
        public CountryDivision GetCountryDivision(int CountryDivisionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PROVINCE_BY_ID";
                cmd.Parameters.Add("@CountryDivisionId", SqlDbType.Int).Value = CountryDivisionId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                CountryDivision pr = new CountryDivision();
                pr.CountryDivisionId = Convert.ToInt32(dr["CountryDivisions_id"]);
                pr.CountryDivisionName = Convert.ToString(dr["Description"]);
                pr.CountryDivisionTypeId = Convert.ToInt32(dr["Country_Division_Type_Id"]);
                pr.CountryDivisionType = Convert.ToString(dr["Country_Division_Type"]);
                pr.IsActive = Convert.ToInt32(dr["Is_Active"]);
                return pr;
            }
            finally
            {
                con.Close();

            }

        }
        public void InsertCountryDivision(CountryDivision countrydivision)
        {

            SqlConnection con = new DalHelper().GetConnection();

            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_PROVINCE";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = countrydivision.CountryDivisionName;
            cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = countrydivision.CountryId;
            cmd.Parameters.Add("@CountryDivisionTypeId", SqlDbType.Int).Value = countrydivision.CountryDivisionTypeId;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = countrydivision.IsActive;
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
        public void UpdateCountryDivision(CountryDivision countrydivision)
        {

            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_PROVINCE";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProvinceId", SqlDbType.Int).Value = countrydivision.CountryDivisionId;
            cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = countrydivision.CountryDivisionName;
            cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = countrydivision.CountryId;
            cmd.Parameters.Add("@CountryDivisionTypeId", SqlDbType.Int).Value = countrydivision.CountryDivisionTypeId;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = countrydivision.IsActive;
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
        #endregion COUNTRY DIVISIONS
        #region COUNTRY DIVISION TYPES
        public List<CountryDivisionType> GetCountryDivisionTypes()
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_COUNTRY_DIVISION_TYPES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<CountryDivisionType> countrydivisiontypes = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    countrydivisiontypes = new List<CountryDivisionType>();
                    while (dr.Read())
                    {
                        CountryDivisionType cy = new CountryDivisionType();
                        cy.CountryDivisionTypeId = Convert.ToInt32(dr["COUNTRY_DIVISION_TYPE_ID"]);
                        cy.CountryDivisionTypeDesc = Convert.ToString(dr["COUNTRY_DIVISION_TYPE"]);

                        countrydivisiontypes.Add(cy);
                    }
                }

                if (countrydivisiontypes != null) countrydivisiontypes.TrimExcess();
                return countrydivisiontypes;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion
        #region PARLIAMENTARY TENURES
        public List<ParliamentaryTenures> GetParliamentaryTenures()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PARLIAMENTARY_TENURES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<ParliamentaryTenures> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ParliamentaryTenures>();
                    while (dr.Read())
                    {
                        ParliamentaryTenures Temp = new ParliamentaryTenures();
                        Temp.ParliamentaryTenuresId = Convert.ToInt32(dr["Parliamentary_Tenures_Id"]);
                        Temp.Description = Convert.ToString(dr["Description"]);
                        Temp.FromDate = Convert.ToDateTime(dr["From_Date"]);
                        Temp.ToDate = Convert.ToDateTime(dr["To_Date"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
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
        public ParliamentaryTenures GetParliamentaryTenure(int ParliamentaryTenureId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PARLIAMENTARY_TENURE";
                cmd.Parameters.Add("@ParliamentaryTenuresId", SqlDbType.Int).Value = ParliamentaryTenureId;
                cmd.CommandType = CommandType.StoredProcedure;
                ParliamentaryTenures Temp = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Temp = new ParliamentaryTenures();
                    dr.Read();
                    Temp.ParliamentaryTenuresId = Convert.ToInt32(dr["Parliamentary_Tenures_Id"]);
                        Temp.Description = Convert.ToString(dr["Description"]);
                        Temp.FromDate = Convert.ToDateTime(dr["From_Date"]);
                        Temp.ToDate = Convert.ToDateTime(dr["To_Date"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                }

                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public void UpdateParliamentaryTenures(ParliamentaryTenures Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_PARLIAMENTARY_TENURE";
                cmd.Parameters.Add("@ParliamentaryTenuresId", SqlDbType.Int).Value = Temp.ParliamentaryTenuresId;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = Temp.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = Temp.ToDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
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
        public void InsertParliamentaryTenures(ParliamentaryTenures Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                int Id = new DalHelper().GetPk("PARLIAMENTARY_TENURES", "PARLIAMENTARY_TENURES_ID");
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_PARLIAMENTARY_TENURE";
                cmd.Parameters.Add("@ParliamentaryTenuresId", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = Temp.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = Temp.ToDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
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

        #endregion PARLIAMENTARY TENURES
        #region PARLIAMENTARY TERMS
      
        public List<ParliamentaryTerms> GetParliamentaryTerms()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PARLIAMENTARY_TERMS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<ParliamentaryTerms> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ParliamentaryTerms>();
                    while (dr.Read())
                    {
                        ParliamentaryTerms Temp = new ParliamentaryTerms();
                        Temp.ParliamentaryTermsId = Convert.ToInt32(dr["Parliamentary_Terms_Id"]);
                        Temp.Description = Convert.ToString(dr["Description"]);
                        Temp.FromDate = Convert.ToDateTime(dr["From_Date"]);
                        Temp.ToDate = Convert.ToDateTime(dr["To_Date"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                       // Temp.ParliamentaryTenureId = Convert.ToInt32(dr["PARLIAMENTARY_TENURE_ID"]);
                       // Temp.ParliamentaryTenure = Convert.ToString(dr["PARLIAMENTARY_TENURE"]);
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
        public ParliamentaryTerms GetParliamentaryTerm(int ParliamentaryTermId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PARLIAMENTARY_TERM";
               // cmd.Parameters.Add("@ParliamentaryTenuresId", SqlDbType.VarChar).Value = ParliamentaryTermId;
                cmd.CommandType = CommandType.StoredProcedure;
                ParliamentaryTerms Temp = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                        Temp = new ParliamentaryTerms();
                        Temp.ParliamentaryTermsId = Convert.ToInt32(dr["Parliamentary_Terms_Id"]);
                        Temp.Description = Convert.ToString(dr["Description"]);
                        Temp.FromDate = Convert.ToDateTime(dr["From_Date"]);
                        Temp.ToDate = Convert.ToDateTime(dr["To_Date"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                       // Temp.ParliamentaryTenureId = Convert.ToInt32(dr["PARLIAMENTARY_TENURE_ID"]);
                       // Temp.ParliamentaryTenure = Convert.ToString(dr["PARLIAMENTARY_TENURE"]);
                }

                
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public void UpdateParliamentaryTerm(ParliamentaryTerms Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_PARLIAMENTARY_TERM";
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@ParliamentaryTermsId", SqlDbType.Int).Value = Temp.ParliamentaryTermsId;
              //  cmd.Parameters.Add("@ParliamentaryTenuresId", SqlDbType.Int).Value = Temp.ParliamentaryTenureId;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = Temp.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = Temp.ToDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
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
        public void InsertParliamentaryTerm(ParliamentaryTerms Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                int Id = new DalHelper().GetPk("PARLIAMENTARY_TERMS", "PARLIAMENTARY_TERMS_ID");
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_PARLIAMENTARY_TERM";
                cmd.Parameters.Add("@ParliamentaryTermsId", SqlDbType.Int).Value = Id;
              //  cmd.Parameters.Add("@ParliamentaryTenuresId", SqlDbType.Int).Value = Temp.ParliamentaryTenureId;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = Temp.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = Temp.ToDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
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
        #endregion PARLIAMENTARY TERMS
        #region PARLIAMENTARY TENURE TERM
        public List<ParliamentaryTenureTerm> GetParliamentaryTenureTerms(int ParliamentaryTenureId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_TENURE_TERMS";
                cmd.Parameters.Add("@ParliamentaryTenuresId", SqlDbType.VarChar).Value = ParliamentaryTenureId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ParliamentaryTenureTerm> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ParliamentaryTenureTerm>();
                    while (dr.Read())
                    {
                        ParliamentaryTenureTerm Temp = new ParliamentaryTenureTerm();
                        Temp.ParliamentaryTenureTermId = Convert.ToInt32(dr["Parliamentary_TENURE_Term_Id"]);
                        Temp.ParliamentaryTermId = Convert.ToInt32(dr["Parliamentary_TENURE_Id"]);
                        Temp.ParliamentaryTenureId = Convert.ToInt32(dr["Parliamentary_Term_Id"]);
                        Temp.Description = Convert.ToString(dr["Description"]);
                        Temp.FromDate = Convert.ToDateTime(dr["From_Date"]);
                        Temp.ToDate = Convert.ToDateTime(dr["To_Date"]);
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
        public void UpdateParliamentaryTenureTerm(ParliamentaryTenureTerm Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_TENURE_TERM";
                cmd.Parameters.Add("@ParliamentaryTenureTermId", SqlDbType.Int).Value = Temp.ParliamentaryTenureTermId;
                cmd.Parameters.Add("@ParliamentaryTenuresId", SqlDbType.Int).Value = Temp.ParliamentaryTenureId;
                cmd.Parameters.Add("@ParliamentaryTermsId", SqlDbType.Int).Value = Temp.ParliamentaryTermId;
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
        public void InsertParliamentaryTenureTerm(ParliamentaryTenureTerm Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                int Id = new DalHelper().GetPk("PARLIAMENTARY_TENURE_TERMS", "PARLIAMENTARY_Tenure_TERM_ID");
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_TENURE_TERM";
                cmd.Parameters.Add("@ParliamentaryTenureTermId", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@ParliamentaryTenuresId", SqlDbType.Int).Value = Temp.ParliamentaryTenureId;
                cmd.Parameters.Add("@ParliamentaryTermsId", SqlDbType.Int).Value = Temp.ParliamentaryTermId;
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
        #endregion  PARLIAMENTARY TENURE TERM
        #region PARLIAMENTARY YEARS
        #endregion PARLIAMENTARY YEARS




    }
}
