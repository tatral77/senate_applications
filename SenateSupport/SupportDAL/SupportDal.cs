using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPRDAL;
using SupportEntities;
using SupportingEntities;


namespace SupportDAL
{
    public class SupportDal
    {
        #region TENURES
        public List<Tenures> GetTenures()
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PARLIAMENTARY_TENURES";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                List<Tenures> objs = new List<Tenures>();
                while (dr.Read())
                {
                    Tenures obj = new Tenures();
                    obj.TenureId = Convert.ToInt32(dr["PARLIAMENTARY_TENURES_ID"]);
                    obj.Tenure = Convert.ToString(dr["DESCRIPTION"]);
                    obj.FromDate = Convert.ToDateTime(dr["FROM_DATE"]);
                    obj.ToDate = Convert.ToDateTime(dr["TO_DATE"]);
                    obj.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                    obj.IsCurrent = Convert.ToInt32(dr["IS_CURRENT"]);
                    objs.Add(obj);
                }
                return objs;
            }
            finally
            {
                con.Close();

            }
        }
        public Tenures GetTenure(int Id)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PARLIAMENTARY_TENURES";
                cmd.Parameters.Add("@ParliamentaryTenuresId", SqlDbType.Int).Value = Id;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                Tenures obj = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    obj = new Tenures();
                    obj.TenureId = Convert.ToInt32(dr["PARLIAMENTARY_TENURES_ID"]);
                    obj.Tenure = Convert.ToString(dr["DESCRIPTION"]);
                    obj.FromDate = Convert.ToDateTime(dr["FROM_DATE"]);
                    obj.ToDate = Convert.ToDateTime(dr["TO_DATE"]);
                    obj.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                    obj.IsCurrent = Convert.ToInt32(dr["IS_CURRENT"]);
                }
                return obj;
            }
            finally
            {
                con.Close();

            }
        }
        public Tenures GetCurrentTenure()
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CURRENT_PARLIAMENTARY_TENURE";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                Tenures obj = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    obj = new Tenures();
                    obj.TenureId = Convert.ToInt32(dr["PARLIAMENTARY_TENURES_ID"]);
                    obj.Tenure = Convert.ToString(dr["DESCRIPTION"]);
                    obj.FromDate = Convert.ToDateTime(dr["FROM_DATE"]);
                    obj.ToDate = Convert.ToDateTime(dr["TO_DATE"]);
                    obj.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                    obj.IsCurrent = Convert.ToInt32(dr["IS_CURRENT"]);
                }
                return obj;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertTenures(Tenures obj)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_PARLIAMENTARY_TENURE";
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = obj.Tenure;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = obj.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = obj.ToDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = obj.IsActive;
                cmd.Parameters.Add("@IsCurrent", SqlDbType.Int).Value = obj.IsCurrent;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
            }
            finally
            {
                con.Close();
            }

        }
        public void UpdateTenures(Tenures obj)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_PARLIAMENTARY_TENURE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ParliamentaryTenuresId", SqlDbType.Int).Value = obj.TenureId;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = obj.Tenure;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = obj.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = obj.ToDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = obj.IsActive;
                cmd.Parameters.Add("@IsCurrent", SqlDbType.Int).Value = obj.IsCurrent;
                SqlDataReader dr = cmd.ExecuteReader();
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region TERMS
        public List<Terms> GetTerms()
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PARLIAMENTARY_TERMS";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                List<Terms> objs = new List<Terms>();
                while (dr.Read())
                {
                    Terms obj = new Terms();
                    obj.TermId = Convert.ToInt32(dr["PARLIAMENTARY_TERMS_ID"]);
                    obj.TenureId = Convert.ToInt32(dr["PARLIAMENTARY_TENURE_ID"]);
                    obj.Tenure.TenureId = Convert.ToInt32(dr["PARLIAMENTARY_TENURE_ID"]);
                    obj.Tenure.Tenure = Convert.ToString(dr["PARLIAMENTARY_TENURE"]);
                    obj.Term = Convert.ToString(dr["DESCRIPTION"]);
                    obj.FromDate = Convert.ToDateTime(dr["FROM_DATE"]);
                    obj.ToDate = Convert.ToDateTime(dr["TO_DATE"]);
                    obj.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                    obj.IsCurrent = Convert.ToInt32(dr["IS_CURRENT"]);
                    objs.Add(obj);
                }
                return objs;
            }
            finally
            {
                con.Close();

            }
        }
        public Terms GetTerm(int Id)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PARLIAMENTARY_TERMS";
                cmd.Parameters.Add("@ParliamentaryTermsId", SqlDbType.Int).Value = Id;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                Terms obj = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    obj = new Terms();
                    obj.TermId = Convert.ToInt32(dr["PARLIAMENTARY_TERMS_ID"]);
                    obj.TenureId = Convert.ToInt32(dr["PARLIAMENTARY_TENURE_ID"]);
                    obj.Tenure.TenureId = Convert.ToInt32(dr["PARLIAMENTARY_TENURE_ID"]);
                    obj.Tenure.Tenure = Convert.ToString(dr["PARLIAMENTARY_TENURE"]);
                    obj.Term = Convert.ToString(dr["DESCRIPTION"]);
                    obj.FromDate = Convert.ToDateTime(dr["FROM_DATE"]);
                    obj.ToDate = Convert.ToDateTime(dr["TO_DATE"]);
                    obj.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                    obj.IsCurrent = Convert.ToInt32(dr["IS_CURRENT"]);
                }
                return obj;
            }
            finally
            {
                con.Close();

            }
        }
        public Terms GetCurrentTerm()
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CURRENT_PARLIAMENTARY_TERM";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                Terms obj = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    obj = new Terms();
                    obj.TermId = Convert.ToInt32(dr["PARLIAMENTARY_TERMS_ID"]);
                    obj.TenureId = Convert.ToInt32(dr["PARLIAMENTARY_TENURE_ID"]);
                    //obj.Tenure.TenureId = Convert.ToInt32(dr["PARLIAMENTARY_TENURE_ID"]);
                    obj.Tenure.Tenure= Convert.ToString(dr["PARLIAMENTARY_TENURE"]);
                    obj.Term = Convert.ToString(dr["DESCRIPTION"]);
                    obj.FromDate = Convert.ToDateTime(dr["FROM_DATE"]);
                    obj.ToDate = Convert.ToDateTime(dr["TO_DATE"]);
                    obj.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                    obj.IsCurrent = Convert.ToInt32(dr["IS_CURRENT"]);
                }
                return obj;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertTerm(Terms obj)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_PARLIAMENTARY_TERM";
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = obj.Term;
                cmd.Parameters.Add("@ParliamentaryTenuresId", SqlDbType.Int).Value = obj.TenureId;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = obj.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = obj.ToDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = obj.IsActive;
                cmd.Parameters.Add("@IsCurrent", SqlDbType.Int).Value = obj.IsCurrent;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
            }
            finally
            {
                con.Close();
            }

        }
        public void UpdateTerm(Terms obj)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_PARLIAMENTARY_TERM";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ParliamentaryTermsId", SqlDbType.Int).Value = obj.TermId;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = obj.Term;
                cmd.Parameters.Add("@ParliamentaryTenuresId", SqlDbType.Int).Value = obj.TenureId;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = obj.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = obj.ToDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = obj.IsActive;
                cmd.Parameters.Add("@IsCurrent", SqlDbType.Int).Value = obj.IsCurrent;
                SqlDataReader dr = cmd.ExecuteReader();
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region GENDER
        //public List<Gender> GetGenders()
        //{

        //    SqlCommand cmd = new SqlCommand("Select * from Genders where is_active=1 Order by Description", new DalHelper().GetConnection());
        //    return selectGenders(cmd);
        //}

        //public List<Gender> selectGenders(SqlCommand cmd)
        //{
        //    SqlConnection con = cmd.Connection;
        //    List<Gender> gender = null;

        //    using (con)
        //    {
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            gender = new List<Gender>();
        //            while (dr.Read())
        //            {
        //                Gender ad = new Gender();
        //                ad.GenderId = Convert.ToInt32(dr["genders_id"]);
        //                ad.Description = Convert.ToString(dr["Description"]);
        //                ad.Is_active = Convert.ToInt32(dr["Is_Active"]);
        //                gender.Add(ad);
        //            }
        //        }
        //    }
        //    if (gender != null) gender.TrimExcess();
        //    return gender;
        //}
        public List<Gender> GetGenders()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_GENDERS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Gender> gender = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        gender = new List<Gender>();
                        while (dr.Read())
                        {
                            Gender ad = new Gender();
                            ad.GenderId = Convert.ToInt32(dr["Genders_id"]);
                            ad.Description = Convert.ToString(dr["Description"]);
                            ad.IsActive = Convert.ToInt32(dr["Is_Active"]);
                            gender.Add(ad);
                        }
                    }
                }
                if (gender != null) gender.TrimExcess();
                return gender;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion GENDER
        #region MARITAL STATUS
        //public List<MaritalStatus> GetMaritalStatuses()
        //{

        //    SqlCommand cmd = new SqlCommand("Select * from marital_statuses where is_active=1 Order by Description", new DalHelper().GetConnection());
        //    return selectMaritalStatuses(cmd);
        //}

        //public List<MaritalStatus> selectMaritalStatuses(SqlCommand cmd)
        //{
        //    SqlConnection con = cmd.Connection;
        //    List<MaritalStatus> marital = null;

        //    using (con)
        //    {
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            marital = new List<MaritalStatus>();
        //            while (dr.Read())
        //            {
        //                MaritalStatus ad = new MaritalStatus();
        //                ad.MaritalStatusId = Convert.ToInt32(dr["marital_statuses_id"]);
        //                ad.Description = Convert.ToString(dr["Description"]);
        //                ad.Is_active = Convert.ToInt32(dr["Is_Active"]);
        //                marital.Add(ad);
        //            }
        //        }
        //    }
        //    if (marital != null) marital.TrimExcess();
        //    return marital;
        //}
        //******************************************************************************************************************
        //******************************************************************************************************************
        public List<MaritalStatus> GetMaritalStatuses()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MARITAL_STATUSES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<MaritalStatus> Mstatus = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Mstatus = new List<MaritalStatus>();
                    while (dr.Read())
                    {
                        MaritalStatus ad = new MaritalStatus();
                        ad.MaritalStatusId = Convert.ToInt32(dr["MARITAL_STATUSES_ID"]);
                        ad.Description = Convert.ToString(dr["Description"]);
                        ad.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        Mstatus.Add(ad);
                    }
                }

                if (Mstatus != null) Mstatus.TrimExcess();
                return Mstatus;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion MARITAL STATUS
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
                        cy.Description = Convert.ToString(dr["Description"]);
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
                cy.Description = Convert.ToString(dr["Description"]);
                cy.IsActive = Convert.ToInt32(dr["Is_Active"]);
                return cy;
            }
            finally
            {
                con.Close();

            }

        }
        //public City GetCity(int cityId)
        //{

        //    SqlCommand cmd = new SqlCommand("Select * from ities where cities_id=" + cityId + " Order by description", new DalHelper().GetConnection());
        //    SqlConnection con = cmd.Connection;
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    dr.Read();
        //    City cy = new City();
        //    cy.CityId = Convert.ToInt32(dr["cities_ID"]);
        //    cy.Description = Convert.ToString(dr["Description"]);
        //    cy.Is_active = Convert.ToInt32(dr["Is_Active"]);
        //    return cy;


        //}
        public List<City> GetCities(int countryid)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CITY_BY_COUNTRY";
                cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = countryid;
                List<City> cities = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    cities = new List<City>();
                    while (dr.Read())
                    {
                        City cy = new City();
                        cy.CityId = Convert.ToInt32(dr["cities_ID"]);
                        cy.Description = Convert.ToString(dr["Description"]);
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

        #endregion CITIES
        #region COUNTRIES
        public List<Country> GetCountries()
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
                        cy.Description = Convert.ToString(dr["Description"]);
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
                cy.Description = Convert.ToString(dr["Description"]);
                cy.IsActive = Convert.ToInt32(dr["Is_Active"]);
                return cy;
            }
            finally
            {
                con.Close();

            }
        }
        //public List<Country> GetCountries()
        //{

        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_COUNTRIES";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<Country> countries = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            countries = new List<Country>();
        //            while (dr.Read())
        //            {
        //                Country cy = new Country();
        //                cy.CountryId = Convert.ToInt32(dr["countries_ID"]);
        //                cy.Description = Convert.ToString(dr["Description"]);
        //                cy.Is_active = Convert.ToInt32(dr["Is_Active"]);
        //                countries.Add(cy);
        //            }
        //        }

        //        if (countries != null) countries.TrimExcess();
        //        return countries;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}

        //public Country GetCountry(int countryId)
        //{

        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_COUNTRY_BY_ID";
        //        cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = countryId;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        dr.Read();
        //        Country cy = new Country();
        //        cy.CountryId = Convert.ToInt32(dr["countries_ID"]);
        //        cy.Description = Convert.ToString(dr["Description"]);
        //        cy.Is_active = Convert.ToInt32(dr["Is_Active"]);
        //        return cy;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}

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
                        cy.Description = Convert.ToString(dr["Description"]);
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
        #endregion COUNTRIES
        #region PROVINCES
        public List<Province> GetProvinces()
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_PROVINCES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Province> prov = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    prov = new List<Province>();
                    while (dr.Read())
                    {
                        Province pr = new Province();
                        pr.ProvinceId = Convert.ToInt32(dr["Provinces_id"]);
                        pr.Description = Convert.ToString(dr["Description"]);
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



        public Province GetProvince(int ProvinceId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PROVINCE_BY_ID";
                cmd.Parameters.Add("@provinceId", SqlDbType.Int).Value = ProvinceId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                Province pr = new Province();
                pr.ProvinceId = Convert.ToInt32(dr["Provinces_id"]);
                pr.Description = Convert.ToString(dr["Description"]);
                pr.IsActive = Convert.ToInt32(dr["Is_Active"]);
                return pr;
            }
            finally
            {
                con.Close();

            }

        }
        #endregion PROVINCES
        #region DISTRICTS
        public List<District> GetDistricts()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("Select * from districts where is_active=1 Order by description", con);
                List<District> dist = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dist = new List<District>();
                    while (dr.Read())
                    {
                        District dt = new District();
                        dt.DistrictId = Convert.ToInt32(dr["Districts_id"]);
                        dt.Description = Convert.ToString(dr["Description"]);
                        dt.ProvinceId = Convert.ToInt32(dr["Provinces_id"]);
                        dt.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        dist.Add(dt);
                    }
                }

                if (dist != null) dist.TrimExcess();
                return dist;
            }
            finally
            {
                con.Close();

            }


        }
        public List<District> GetDistricts(int provinceId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("Select * from districts where provinces_id = " + provinceId + " and is_active=1 Order by description", con);
                List<District> dist = null;

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dist = new List<District>();
                    while (dr.Read())
                    {
                        District dt = new District();
                        dt.DistrictId = Convert.ToInt32(dr["Districts_id"]);
                        dt.Description = Convert.ToString(dr["Description"]);
                        dt.ProvinceId = Convert.ToInt32(dr["Provinces_id"]);
                        dt.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        dist.Add(dt);
                    }
                }

                if (dist != null) dist.TrimExcess();

                return dist;
            }
            finally
            {
                con.Close();

            }


        }
        public District GetDistrict(int districtId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("Select * from districts where distrits_id = " + districtId + "is_active=1 Order by description", con);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                District dt = new District();
                dt.DistrictId = Convert.ToInt32(dr["Districts_id"]);
                dt.Description = Convert.ToString(dr["Description"]);
                dt.ProvinceId = Convert.ToInt32(dr["Provinces_id"]);
                dt.IsActive = Convert.ToInt32(dr["Is_Active"]);
                return dt;
            }

            finally
            {
                con.Close();

            }

        }
        #endregion DISTRICTS
        #region PHONE TYPE
        public List<PhoneTypes> GePhoneTypes()
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PHONE_TYPES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<PhoneTypes> phonetypes = null;

                using (con)
                {

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        phonetypes = new List<PhoneTypes>();
                        while (dr.Read())
                        {
                            PhoneTypes pt = new PhoneTypes();
                            pt.PhoneTypeId = Convert.ToInt32(dr["Phone_Types_id"]);
                            pt.Description = Convert.ToString(dr["Description"]);
                            pt.IsActive = Convert.ToInt32(dr["Is_Active"]);
                            phonetypes.Add(pt);
                        }
                    }
                }
                if (phonetypes != null) phonetypes.TrimExcess();
                return phonetypes;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion PHONE TYPE
        #region DEGREE LEVEL
        //public List<DegreeLevel> GetDegreeLevels()
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("Select * from Education_Level where is_active=1 Order by sort_order", con);

        //        List<DegreeLevel> educationlevel = null;

        //        using (con)
        //        {

        //            SqlDataReader dr = cmd.ExecuteReader();
        //            if (dr.HasRows)
        //            {
        //                educationlevel = new List<DegreeLevel>();
        //                while (dr.Read())
        //                {
        //                    DegreeLevel dl = new DegreeLevel();
        //                    dl.Degree_Level_Id = Convert.ToInt32(dr["Education_Level_Id"]);
        //                    dl.Degree_Level = Convert.ToString(dr["Description"]);
        //                    dl.Is_Active = Convert.ToInt32(dr["Is_Active"]);
        //                    educationlevel.Add(dl);
        //                }
        //            }
        //        }
        //        if (educationlevel != null) educationlevel.TrimExcess();

        //        return educationlevel;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}




        //public DegreeLevel GetDegreeLevel(int degreelevelid)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {

        //        SqlCommand cmd = new SqlCommand("Select * from Education_Level where Education_Level_Id=" + degreelevelid + " Order by description", con);

        //        using (con)
        //        {
        //            SqlDataReader dr = cmd.ExecuteReader();
        //            DegreeLevel dl = new DegreeLevel();
        //            dr.Read();
        //            dl.Degree_Level_Id = Convert.ToInt32(dr["Education_Level_Id"]);
        //            dl.Degree_Level = Convert.ToString(dr["Description"]);
        //            dl.Is_Active = Convert.ToInt32(dr["Is_Active"]);
        //            return dl;
        //        }
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }

        //}

        #endregion
        #region PASSPORT
        public List<PassportTypes> GetPassportTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PASSPORT_TYPES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<PassportTypes> PassTypes = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    PassTypes = new List<PassportTypes>();
                    while (dr.Read())
                    {
                        PassportTypes ad = new PassportTypes();
                        ad.PassportTypeId = Convert.ToInt32(dr["Passport_Types_Id"]);
                        ad.Description = Convert.ToString(dr["Description"]);
                        ad.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        PassTypes.Add(ad);
                    }
                }

                if (PassTypes != null) PassTypes.TrimExcess();
                return PassTypes;
            }
            finally
            {
                con.Close();

            }

        }
        public PassportTypes GetPassportType(int PassportTypeId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PASSPORT_TYPES";
                cmd.Parameters.Add("@PassportTypeId", SqlDbType.Int).Value = PassportTypeId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                PassportTypes pt = new PassportTypes();
                pt.PassportTypeId = Convert.ToInt32(dr["Passport_Types_ID"]);
                pt.Description = Convert.ToString(dr["Description"]);
                pt.IsActive = Convert.ToInt32(dr["Is_Active"]);
                return pt;
            }
            finally
            {
                con.Close();

            }


        }
        #endregion PASSPORT
        #region RELIGION
        public List<Religion> GetReligions()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_RELIGIONS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Religion> Rlgn = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Rlgn = new List<Religion>();
                    while (dr.Read())
                    {
                        Religion ad = new Religion();
                        ad.ReligionId = Convert.ToInt32(dr["religions_id"]);
                        ad.Description = Convert.ToString(dr["Description"]);
                        ad.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        Rlgn.Add(ad);
                    }
                }

                if (Rlgn != null) Rlgn.TrimExcess();
                return Rlgn;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion RELIGION
        #region Visit Types
        public List<VistTypes> GetVisitTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_VISIT_TYPES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<VistTypes> visits = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    visits = new List<VistTypes>();
                    while (dr.Read())
                    {
                        VistTypes ad = new VistTypes();
                        ad.VisitTypeId = Convert.ToInt32(dr["VISIT_TYPES_ID"]);
                        ad.VistType = Convert.ToString(dr["VISIT_TYPE"]);

                        visits.Add(ad);
                    }
                }

                if (visits != null) visits.TrimExcess();
                return visits;
            }
            finally
            {
                con.Close();

            }

        }

        #endregion
        #region DEGREE LEVEL
        public List<DegreeLevel> GetDegreeLevels()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from Education_Level where is_active=1 Order by sort_order", con);

                List<DegreeLevel> educationlevel = null;

                using (con)
                {

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        educationlevel = new List<DegreeLevel>();
                        while (dr.Read())
                        {
                            DegreeLevel dl = new DegreeLevel();
                            dl.Degree_Level_Id = Convert.ToInt32(dr["Education_Level_Id"]);
                            dl.Degree_Level = Convert.ToString(dr["Description"]);
                            dl.Is_Active = Convert.ToInt32(dr["Is_Active"]);
                            educationlevel.Add(dl);
                        }
                    }
                }
                if (educationlevel != null) educationlevel.TrimExcess();

                return educationlevel;
            }
            finally
            {
                con.Close();

            }
        }




        public DegreeLevel GetDegreeLevel(int degreelevelid)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("Select * from Education_Level where Education_Level_Id=" + degreelevelid + " Order by description", con);

                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    DegreeLevel dl = new DegreeLevel();
                    dr.Read();
                    dl.Degree_Level_Id = Convert.ToInt32(dr["Education_Level_Id"]);
                    dl.Degree_Level = Convert.ToString(dr["Description"]);
                    dl.Is_Active = Convert.ToInt32(dr["Is_Active"]);
                    return dl;
                }
            }
            finally
            {
                con.Close();

            }

        }

        #endregion
        #region DEPENDANTS
        public List<Relations> GetRelations()
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RELATIONSHIPS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Relations> ps = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    ps = new List<Relations>();
                    while (dr.Read())
                    {
                        Relations ad = new Relations();

                        ad.RelationsId = Convert.ToInt32(dr["RelationId"]);
                        ad.RelationName = Convert.ToString(dr["RelationName"]);
                        // ad.Gender = Convert.ToString(dr["Gender"]);
                        // ad.SortOrder = Convert.ToInt32(dr["SortOrder"]);

                        ps.Add(ad);
                    }
                }
                if (ps != null) ps.TrimExcess();
                return ps;
            }
            finally
            {
                con.Close();

            }
        }

        #endregion
        #region COURSE
        public List<CourseType> GetCourseTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_COURSE_TYPE";
                cmd.CommandType = CommandType.StoredProcedure;
                List<CourseType> courses = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    courses = new List<CourseType>();
                    while (dr.Read())
                    {
                        CourseType cy = new CourseType();
                        cy.CourseTypeId = Convert.ToInt32(dr["Course_Types_ID"]);
                        cy.Description = Convert.ToString(dr["Description"]);
                        cy.Is_active = Convert.ToInt32(dr["Is_Active"]);
                        courses.Add(cy);
                    }
                }

                if (courses != null) courses.TrimExcess();
                return courses;
            }
            finally
            {
                con.Close();

            }
        }




        public CourseType GetCourseType(int courseTypeId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_COURSE_TYPE_BY_ID";
                cmd.Parameters.Add("@CourseTypeId", SqlDbType.Int).Value = courseTypeId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                CourseType cy = new CourseType();
                dr.Read();
                cy.CourseTypeId = Convert.ToInt32(dr["course_types_ID"]);
                cy.Description = Convert.ToString(dr["Description"]);
                cy.Is_active = Convert.ToInt32(dr["Is_Active"]);
                return cy;
            }
            finally
            {
                con.Close();

            }


        }
        #endregion
        #region POLITICAL PARTIES
        public List<PoliticalParty> GetPoliticalParties()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_POLITICAL_PARTIES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<PoliticalParty> Temp = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        Temp = new List<PoliticalParty>();
                        while (dr.Read())
                        {
                            PoliticalParty ad = new PoliticalParty();
                            ad.PoliticalPartyId = Convert.ToInt32(dr["POLITICAL_PARTIES_ID"]);
                            ad.Description = Convert.ToString(dr["DESCRIPTION"]);
                            Temp.Add(ad);
                        }
                    }
                }
                if (Temp != null) Temp.TrimExcess();
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion
        #region MEMBER STATUSES
        public List<MemberStatus> GetMemberStatuses()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBER_STATUSES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<MemberStatus> Temp = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        Temp = new List<MemberStatus>();
                        while (dr.Read())
                        {
                            MemberStatus ad = new MemberStatus();
                            ad.MemberStatusId = Convert.ToInt32(dr["MEMBER_STATUSES_ID"]);
                            ad.MemStatus = Convert.ToString(dr["DESCRIPTION"]);
                            Temp.Add(ad);
                        }
                    }
                }
                if (Temp != null) Temp.TrimExcess();
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion
        #region ASSEMBLIES
        public List<Assemblies> GetAssemblies()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Members_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ASSEBLIES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Assemblies> Temp = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        Temp = new List<Assemblies>();
                        while (dr.Read())
                        {
                            Assemblies ad = new Assemblies();
                            ad.AssembliesId = Convert.ToInt32(dr["ASSEMBLIES_ID"]);
                            ad.Term = Convert.ToString(dr["TERM"]);
                            Temp.Add(ad);
                        }
                    }
                }
                if (Temp != null) Temp.TrimExcess();
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion ASSEMBLIES
        #region ELECTION TYPES
        public List<ElectionTypes> GetElectionTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ELECTION_TYPES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<ElectionTypes> Temp = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        Temp = new List<ElectionTypes>();
                        while (dr.Read())
                        {
                            ElectionTypes ad = new ElectionTypes();
                            ad.ElectionTypesId = Convert.ToInt32(dr["ELECTION_TYPES_ID"]);
                            ad.Description = Convert.ToString(dr["DESCRIPTION"]);
                            Temp.Add(ad);
                        }
                    }
                }
                if (Temp != null) Temp.TrimExcess();
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion ELECTION_TYPES
        #region PHONE TYPES
        public List<PhoneTypes> GetPhoneTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[IPR_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PHONE_TYPES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<PhoneTypes> phonetypes = null;

                using (con)
                {

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        phonetypes = new List<PhoneTypes>();
                        while (dr.Read())
                        {
                            PhoneTypes pt = new PhoneTypes();
                            pt.PhoneTypeId = Convert.ToInt32(dr["Phone_Types_id"]);
                            pt.Description = Convert.ToString(dr["Description"]);
                            pt.IsActive = Convert.ToInt32(dr["Is_Active"]);
                            phonetypes.Add(pt);
                        }
                    }
                }
                if (phonetypes != null) phonetypes.TrimExcess();
                return phonetypes;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion PHONE TYPES
    }
}
