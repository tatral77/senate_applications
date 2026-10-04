using EstablishmentENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EstablishmentDAL
{

    public class AdministrationDAL
    {
        #region BPS

        public List<TempEntity> GetPromotionModes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PROMOTION_MODES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<TempEntity> bps = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    bps = new List<TempEntity>();
                    while (dr.Read())
                    {
                        TempEntity ad = new TempEntity();

                        ad.Id = Convert.ToInt32(dr["PROMOTION_MODES_ID"]);
                        ad.Description = Convert.ToString(dr["Description"]);
                        ad.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        bps.Add(ad);
                    }
                }

                if (bps != null) bps.TrimExcess();
                return bps;
            }
            finally
            {
                con.Close();

            }
        }
        public List<TempEntity> GetDutyTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_DUTY_TYPES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<TempEntity> bps = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    bps = new List<TempEntity>();
                    while (dr.Read())
                    {
                        TempEntity ad = new TempEntity();

                        ad.Id = Convert.ToInt32(dr["OTHER_DUTY_TYPE_ID"]);
                        ad.Description = Convert.ToString(dr["OTHER_DUTY_TYPE"]);
                        bps.Add(ad);
                    }
                }

                if (bps != null) bps.TrimExcess();
                return bps;
            }
            finally
            {
                con.Close();

            }
        }
        public List<TempEntity> GetAppointmenModes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_APPOINTMENT_MODES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<TempEntity> bps = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    bps = new List<TempEntity>();
                    while (dr.Read())
                    {
                        TempEntity ad = new TempEntity();

                        ad.Id = Convert.ToInt32(dr["APPOINTMENT_MODES_ID"]);
                        ad.Description = Convert.ToString(dr["Description"]);
                        ad.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        bps.Add(ad);
                    }
                }

                if (bps != null) bps.TrimExcess();
                return bps;
            }
            finally
            {
                con.Close();

            }
        }
        public TempEntity GetAppointmenMode(int AppointModeId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_APPOINTMENT_MODE";
                cmd.Parameters.Add("@AppointmentModeId", SqlDbType.Int).Value = AppointModeId;
                cmd.CommandType = CommandType.StoredProcedure;
                TempEntity bps = new TempEntity();
                bps.Id = 0; bps.Description = "Not Mentioned";
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                   
                    dr.Read();
                    bps.Id = Convert.ToInt32(dr["APPOINTMENT_MODES_ID"]);
                    bps.Description = Convert.ToString(dr["Description"]);
                    bps.IsActive = Convert.ToInt32(dr["Is_Active"]);
                }
                return bps;
            }
            finally
            {
                con.Close();
            }
        }
        public List<BPS> GetAllBPS()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_BPS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<BPS> bps = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    bps = new List<BPS>();
                    while (dr.Read())
                    {
                        BPS ad = new BPS();

                        ad.BpsId = Convert.ToInt32(dr["Basic_Pay_Scales_ID"]);
                        ad.Description = Convert.ToString(dr["Description"]);
                        ad.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        bps.Add(ad);
                    }
                }

                if (bps != null) bps.TrimExcess();
                return bps;
            }
            finally
            {
                con.Close();

            }
        }
        public BPS GetBPS(int BPSId)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BPS_BY_ID";
                cmd.Parameters.Add("@BpsId", SqlDbType.Int).Value = BPSId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                BPS ad = null;
                if (dr.HasRows)
                {
                    ad = new BPS();
                    ad.BpsId = Convert.ToInt32(dr["Basic_Pay_Scales_id"]);
                    ad.Description = Convert.ToString(dr["Description"]);
                    ad.IsActive = Convert.ToInt32(dr["Is_Active"]);
                }
                return ad;

            }
            finally
            {
                con.Close();

            }


        }

        #endregion
        #region BRANCH
        public List<Branch> GetBranches()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_BRANCHES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Branch> branches = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    branches = new List<Branch>();
                    while (dr.Read())
                    {
                        Branch ad = new Branch();
                        ad.Branchid = Convert.ToInt32(dr["Branches_ID"]);
                        ad.Description = Convert.ToString(dr["Description"]);
                        ad.Is_active = Convert.ToInt32(dr["Is_Active"]);
                        branches.Add(ad);
                    }
                }

                if (branches != null) branches.TrimExcess();
                return branches;
            }
            finally
            {
                con.Close();

            }
        }
        public Branch GetBranch(int BranchId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                Branch ad = null;
                if (BranchId > 0)
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BRANCH_BY_ID";
                    cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = BranchId;
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (con)
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();
                        ad = new Branch();
                        ad.Branchid = Convert.ToInt32(dr["Branches_ID"]);
                        ad.Description = Convert.ToString(dr["Description"]);
                        ad.Is_active = Convert.ToInt32(dr["Is_Active"]);
                    }
                }
                return ad;
            }
            finally
            {
                con.Close();

            }
        }
        public void UpdateBranch(Branch Branch)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_BRANCH";
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = Branch.Branchid;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Branch.Description;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Branch.Is_active;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                AuditLogger.LogCommand(cmd);
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
        public void InsertBranch(Branch Branch)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_BRANCH";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Branch.Description;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Branch.Is_active;
                cmd.Connection = con;

                cmd.ExecuteNonQuery();
                AuditLogger.LogCommand(cmd);
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
        public List<Branch> GetAllBranches()
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ALL_BRANCHES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Branch> branches = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    branches = new List<Branch>();
                    while (dr.Read())
                    {
                        Branch ad = new Branch();
                        ad.Branchid = Convert.ToInt32(dr["Branches_ID"]);
                        ad.Description = Convert.ToString(dr["Description"]);
                        ad.Is_active = Convert.ToInt32(dr["Is_Active"]);
                        branches.Add(ad);
                    }
                }

                if (branches != null) branches.TrimExcess();
                return branches;
            }
            finally
            {
                con.Close();

            }
        }

        public void DeleteBranch(int b)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_BRANCH";
                cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = b;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }

        }



        #endregion BRANCH
        #region COURSE
        public List<CourseType> GetCourseTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try {
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
            try {
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
                        cy.Is_active = Convert.ToInt32(dr["Is_Active"]);
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
                cy.Is_active = Convert.ToInt32(dr["Is_Active"]);
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
            try {
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
                        cy.Is_active = Convert.ToInt32(dr["Is_Active"]);
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

            SqlConnection con = new DalHelper().GetConnection();

            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_COUNTRY";
            cmd.CommandType = CommandType.StoredProcedure;          
            cmd.Parameters.Add("@CountryName", SqlDbType.VarChar).Value = country.Description;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = country.Is_active;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);

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
            cmd.Parameters.Add("@CountryName", SqlDbType.VarChar).Value = country.Description;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = country.Is_active;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);

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
                        cy.Description = Convert.ToString(dr["Description"]);
                        cy.CountryId= Convert.ToInt32(dr["Countries_ID"]);
                        cy.CountryName = Convert.ToString(dr["Country_Name"]);
                        cy.ProvinceId = Convert.ToInt32(dr["Provinces_ID"]);
                        cy.ProvinceName = Convert.ToString(dr["Province_Name"]);
                        cy.IsDistrict = Convert.ToInt32(dr["Is_District"]);
                        cy.Is_active = Convert.ToInt32(dr["Is_Active"]);
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
                        cy.Description = Convert.ToString(dr["Description"]);
                        cy.Is_active = Convert.ToInt32(dr["Is_Active"]);
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
            try { 
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
                    cy.Is_active = Convert.ToInt32(dr["Is_Active"]);
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
            try { 
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
                            cy.Is_active = Convert.ToInt32(dr["Is_Active"]);
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

            SqlConnection con = new DalHelper().GetConnection();

            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_CITY";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CityName", SqlDbType.VarChar).Value = city.Description;
            cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = city.CountryId;
            cmd.Parameters.Add("@ProvinceId", SqlDbType.Int).Value = city.ProvinceId;
            cmd.Parameters.Add("@IsDistrict", SqlDbType.Int).Value = city.IsDistrict;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = city.Is_active;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);

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
            cmd.Parameters.Add("@CityName", SqlDbType.VarChar).Value = city.Description;
            cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = city.CountryId;
            cmd.Parameters.Add("@ProvinceId", SqlDbType.Int).Value = city.ProvinceId;
            cmd.Parameters.Add("@IsDistrict", SqlDbType.Int).Value = city.IsDistrict;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = city.Is_active;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);

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
        #region DEGREE LEVEL
        public List<DegreeLevel> GetDegreeLevels()
            {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from Education_Level where is_active=1 Order by sort_order",con);
            
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
        #region DISTRICTS
            public List<District> GetDistricts()
            {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("select * from DISTRICTS where IS_ACTIVE=1 order by DESCRIPTION", con);
                List<District> dist = null;
                 SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dist = new List<District>();
                        while (dr.Read())
                        {
                            District dt = new District();
                            dt.DistrictId = Convert.ToInt32(dr["DISTRICTS_ID"]);
                            dt.Description = Convert.ToString(dr["Description"]);
                            dt.Is_active = Convert.ToInt32(dr["Is_Active"]);
                            dist.Add(dt);
                        }
                    }
                
                if (dist != null)
                    dist.TrimExcess();
                 return dist;
            }
            finally
            {
                con.Close();

            }


        }
        public List<District> GetAllDistricts()
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ALL_DISTRICTS";

                cmd.CommandType = CommandType.StoredProcedure;
                List<District> dist = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dist = new List<District>();
                    if (dr.HasRows)
                    {
                        dist = new List<District>();
                        while (dr.Read())
                        {
                            District dt = new District();
                            dt.DistrictId = Convert.ToInt32(dr["Districts_id"]);
                            dt.Description = Convert.ToString(dr["Description"]);
                            dt.ProvinceId = Convert.ToInt32(dr["Provinces_id"]);
                            dt.ProvinceName= Convert.ToString(dr["PROVINCE_NAME"]);
                            dt.Is_active = Convert.ToInt32(dr["Is_Active"]);
                            dist.Add(dt);
                        }
                    }

                   
                }
                if (dist != null)
                    dist.TrimExcess();
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
                        dt.Is_active = Convert.ToInt32(dr["Is_Active"]);
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

                SqlCommand cmd = new SqlCommand("Select * from districts where districts_id = " + districtId , con);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                District dt = new District();
                dt.DistrictId = Convert.ToInt32(dr["Districts_id"]);
                dt.Description = Convert.ToString(dr["Description"]);
                dt.ProvinceId = Convert.ToInt32(dr["Provinces_id"]);
                dt.Is_active = Convert.ToInt32(dr["Is_Active"]);
                return dt;
            }

            finally
            {
                con.Close();

            }

        }
        public void InsertDistrict(District district)
        {

            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_DISTRICT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DistrictName", SqlDbType.VarChar).Value = district.Description;
            cmd.Parameters.Add("@ProvinceId", SqlDbType.Int).Value = district.ProvinceId;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = district.Is_active;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);
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
        public void UpdateDistrict(District district)
        {

            SqlConnection con = new DalHelper().GetConnection();
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_DISTRICT";          
            cmd.Parameters.Add("@DistrictId", SqlDbType.VarChar).Value = district.DistrictId;
            cmd.Parameters.Add("@DistrictName", SqlDbType.VarChar).Value = district.Description;
            cmd.Parameters.Add("@ProvinceId", SqlDbType.Int).Value = district.ProvinceId;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = district.Is_active;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            try
            {
                cmd.ExecuteReader();
                AuditLogger.LogCommand(cmd);

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
        #endregion DISTRICTS
        #region EMPLOYEE POOL
        public EmployeePools GetEmpPool(int PoolId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from employee_pools where Employee_pools_id= " + PoolId + "  Order by order_by", con);
                SqlDataReader dr = cmd.ExecuteReader();
                EmployeePools ad = new EmployeePools();
                ad.EmpPoolsId = 0;ad.Description = "Not Mentioned";
                ad.EmpPoolsId = 0;ad.Description = "Not Mentioned";
                if (dr.HasRows)
                {
                    dr.Read();
                    ad.EmpPoolsId = Convert.ToInt32(dr["Employee_pools_id"]);
                    ad.Description = Convert.ToString(dr["Description"]);
                    ad.IsActive = Convert.ToInt32(dr["Is_Active"]);
                    ad.SortOrder = Convert.ToInt32(dr["order_by"]);
                   
                }
                return ad;
            }
            finally
            {
                con.Close();

            }
        }
        public List<EmployeePools> GetEmpPools()
            {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                 SqlCommand cmd = new SqlCommand("Select * from employee_pools where is_active=1 Order by order_by", con);
                SqlDataReader dr = cmd.ExecuteReader();
                List<EmployeePools> EmpPools = null;
                if (dr.HasRows)
                {
                    EmpPools = new List<EmployeePools>();
                    while (dr.Read())
                    {
                        EmployeePools ad = new EmployeePools();
                        ad.EmpPoolsId = Convert.ToInt32(dr["Employee_pools_id"]);
                        ad.Description = Convert.ToString(dr["Description"]);
                        ad.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        ad.SortOrder = Convert.ToInt32(dr["order_by"]);
                        EmpPools.Add(ad);
                    }
                }

                if (EmpPools != null) EmpPools.TrimExcess();
                return EmpPools;
            }

            finally
            {
                con.Close();

            }
        }

            #endregion
        #region EMPLOYEE STATUS
            public List<EmpStatus> GetEmpStatusList()
            {
                SqlConnection con = new DalHelper().GetConnection();
                try
                {
                    SqlCommand cmd = new SqlCommand("Select emp_status_id,description,is_active from emp_status where is_active=1 Order by Description", con);
                   // List<EmpStatus> posts = null;
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<EmpStatus> EmpStatuses = new List<EmpStatus>();
                if (dr.HasRows)
                {
                  
                    while (dr.Read())
                    {
                        EmpStatus ad = new EmpStatus();
                        /*ad.BpsId = Convert.ToInt32(dr["bpsid"]);
                         ad.Description = Convert.ToString(dr["Description"]);
                         ad.IsActive  = Convert.ToInt32(dr["Is_Active"]);*/
                        ad.EmpStatusId = Convert.ToInt32(dr["emp_status_id"]);
                        ad.Description = Convert.ToString(dr["Description"]);
                        ad.Is_active = Convert.ToInt32(dr["Is_Active"]);
                        EmpStatuses.Add(ad);
                    }
                }

                if (EmpStatuses != null) EmpStatuses.TrimExcess();

                return EmpStatuses;
                }
                finally
                {
                    con.Close();

                }
            }
            public List<EmpStatus> selectPosts(SqlCommand cmd)
            {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                List<EmpStatus> posts = null;
                SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        posts = new List<EmpStatus>();
                        while (dr.Read())
                        {
                            EmpStatus ad = new EmpStatus();
                            /*ad.BpsId = Convert.ToInt32(dr["bpsid"]);
                             ad.Description = Convert.ToString(dr["Description"]);
                             ad.IsActive  = Convert.ToInt32(dr["Is_Active"]);*/
                            ad.EmpStatusId = Convert.ToInt32(dr["emp_status_id"]);
                            ad.Description = Convert.ToString(dr["Description"]);
                            ad.Is_active = Convert.ToInt32(dr["Is_Active"]);
                            posts.Add(ad);
                        }
                    }
              
                if (posts != null) posts.TrimExcess();

                return posts;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion
        #region GENDER
        public Gender GetGender(int GenderId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_GENDER";
                cmd.Parameters.Add("@TempId", SqlDbType.Int).Value = GenderId;
                cmd.CommandType = CommandType.StoredProcedure;
                Gender gender = null;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        gender = new Gender();
                        gender.GenderId = Convert.ToInt32(dr["Genders_id"]);
                        gender.Description = Convert.ToString(dr["Description"]);
                        gender.Is_active = Convert.ToInt32(dr["Is_Active"]);
                    }
                }
                return gender;
            }
            finally
            {
                con.Close();

            }
        }
        public List<Gender> GetGenders()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try { 
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
                        ad.Is_active = Convert.ToInt32(dr["Is_Active"]);
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
        #region LEAVE
            public LeaveType GetLeaveType(int LeaveTypeId)
            {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from Emp_Leave_Types where Emp_Leaves_Type_Id=" + LeaveTypeId + " Order by description", con);
               SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                LeaveType lt = new LeaveType();
                lt.LeaveTypeId = Convert.ToInt32(dr["Emp_Leaves_Type_Id"]);
                lt.Description = Convert.ToString(dr["Description"]);
                lt.Is_active = Convert.ToInt32(dr["Is_Active"]);
                lt.Daysallowed = Convert.ToInt32(dr["Days_Allowed"]);
                return lt;
            }
            finally
            {
                con.Close();

            }

        }
        public List<LeaveType> GetLeaveTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_LEAVE_TYPES";
                cmd.CommandType = CommandType.StoredProcedure;

                List<LeaveType> LeaveTypes = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    LeaveTypes = new List<LeaveType>();
                    while (dr.Read())
                    {
                        LeaveType Lt = new LeaveType();
                        Lt.LeaveTypeId = Convert.ToInt32(dr["Emp_Leaves_Type_Id"]);
                        Lt.Description = Convert.ToString(dr["Description"]);
                        Lt.Daysallowed = Convert.ToInt32(dr["Days_Allowed"]);
                        LeaveTypes.Add(Lt);
                    }
                }
                if (LeaveTypes != null) LeaveTypes.TrimExcess();
                return LeaveTypes;
            }
            finally
            {
                con.Close();
            }


        }
        #endregion LEAVE
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
        public MaritalStatus GetMaritalStatus(int MaritalStatusId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MARITAL_STATUS";
                cmd.Parameters.Add("@TempId", SqlDbType.Int).Value = MaritalStatusId;
                cmd.CommandType = CommandType.StoredProcedure;
                MaritalStatus Mstatus = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Mstatus = new MaritalStatus();
                    Mstatus.MaritalStatusId = Convert.ToInt32(dr["MARITAL_STATUSES_ID"]);
                    Mstatus.Description = Convert.ToString(dr["Description"]);
                    Mstatus.Is_active = Convert.ToInt32(dr["Is_Active"]);

                }

                return Mstatus;
            }
            finally
            {
                con.Close();

            }
        }
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
                        ad.Is_active = Convert.ToInt32(dr["Is_Active"]);
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
        #region POSTS
        public List<Post> GetAllPosts()
        {

            SqlConnection con = new DalHelper().GetConnection();
            try { 
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ALL_POSTS";
            cmd.CommandType = CommandType.StoredProcedure;
            List<Post> posts = null;

            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    posts = new List<Post>();
                    while (dr.Read())
                    {
                        Post ad = new Post();
                        ad.PostID = Convert.ToInt32(dr["Posts_Id"]);
                        if (dr["Description"] != DBNull.Value)
                            ad.Description = Convert.ToString(dr["Description"]);
                        ad.PostTypeId = Convert.ToInt32(dr["Post_Types_Id"]);
                        ad.PostType = Convert.ToString(dr["post_type"]);
                        ad.GazNonGazId = Convert.ToInt32(dr["Post_Sub_Types_Id"]);
                        ad.GazNonGaz = Convert.ToString(dr["sub_type"]);
                        ad.PostStatusId = Convert.ToInt32(dr["Post_Statuses_Id"]);
                        ad.PostStatus = Convert.ToString(dr["post_status"]);
                        if (dr["Scale_From"] != DBNull.Value)
                            ad.ScaleFrom = Convert.ToInt32(dr["Scale_From"]);
                        if (dr["Scale_To"] != DBNull.Value)
                            ad.ScaleTo = Convert.ToInt32(dr["Scale_to"]);
                        if (dr["No_of_Posts"] != DBNull.Value)
                            ad.NumOfPosts = Convert.ToInt32(dr["No_of_Posts"]);
                        ad.Is_active = Convert.ToInt32(dr["Is_Active"]);
                        ad.NumOfEmp = GetPostNoOfEmployees(Convert.ToInt32(dr["Posts_Id"]));
                        posts.Add(ad);
                    }
                }
            }
          
            if (posts != null) posts.TrimExcess();
            return posts;
            }
            finally
            {
                con.Close();

            }
        }
        public List<Post> GetActivePosts()
        {

            SqlConnection con = new DalHelper().GetConnection();
            try { 
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_POSTS";
            cmd.CommandType = CommandType.StoredProcedure;
            List<Post> posts = null;
            SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    posts = new List<Post>();
                    while (dr.Read())
                    {
                        Post ad = new Post();
                        ad.PostID = Convert.ToInt32(dr["Posts_Id"]);
                        if (dr["Description"] != DBNull.Value)
                            ad.Description = Convert.ToString(dr["Description"]);
                        ad.PostTypeId = Convert.ToInt32(dr["Post_Types_Id"]);
                        ad.PostType = Convert.ToString(dr["post_type"]);
                        ad.GazNonGazId = Convert.ToInt32(dr["Post_Sub_Types_Id"]);
                        ad.GazNonGaz = Convert.ToString(dr["sub_type"]);
                        ad.PostStatusId = Convert.ToInt32(dr["Post_Statuses_Id"]);
                        ad.PostStatus = Convert.ToString(dr["post_status"]);
                        if (dr["Scale_From"] != DBNull.Value)
                            ad.ScaleFrom = Convert.ToInt32(dr["Scale_From"]);
                        if (dr["Scale_To"] != DBNull.Value)
                            ad.ScaleTo = Convert.ToInt32(dr["Scale_to"]);
                        if (dr["No_of_Posts"] != DBNull.Value)
                            ad.NumOfPosts = Convert.ToInt32(dr["No_of_Posts"]);
                        ad.Is_active = Convert.ToInt32(dr["Is_Active"]);
                        posts.Add(ad);
                    }
                }
           
            if (posts != null) posts.TrimExcess();
            return posts;
            }
            finally
            {
                con.Close();

            }
        }
        public Post GetPost(int PostId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try { 
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_POST_BY_ID";
            cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = PostId;
            cmd.CommandType = CommandType.StoredProcedure;
            Post ad = new Post();
            SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {

                    ad.PostID = Convert.ToInt32(dr["Posts_Id"]);
                    ad.Description = Convert.ToString(dr["Description"]);
                    ad.PostTypeId = Convert.ToInt32(dr["Post_Types_Id"]);
                    ad.PostType = Convert.ToString(dr["posttype"]);
                    ad.GazNonGazId = Convert.ToInt32(dr["Post_Sub_Types_Id"]);
                    ad.GazNonGaz = Convert.ToString(dr["subtype"]);
                    ad.PostStatusId = Convert.ToInt32(dr["Post_Statuses_Id"]);
                    ad.PostStatus = Convert.ToString(dr["poststatus"]);
                    if (dr["Scale_From"] != DBNull.Value)
                        ad.ScaleFrom = Convert.ToInt32(dr["Scale_From"]);
                    if (dr["Scale_To"] != DBNull.Value)
                        ad.ScaleTo = Convert.ToInt32(dr["Scale_to"]);
                    if (dr["No_of_Posts"] != DBNull.Value)
                        ad.NumOfPosts = Convert.ToInt32(dr["No_of_Posts"]);
                    ad.Is_active = Convert.ToInt32(dr["Is_Active"]);


                }
                 return ad;
                }
            finally
            {
                con.Close();

            }
        }

        public int GetPostNoOfEmployees(int postid)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try { 
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_POST_NUM_OF_EMP";
            cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = postid;
            cmd.CommandType = CommandType.StoredProcedure;
            int NoOfEmp = 0;
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    NoOfEmp = Convert.ToInt32(dr["NoOfEmps"]);
                }
               
            }

         
            return NoOfEmp;
            }
            finally
            {
                con.Close();

            }




        }
        public void UpdatePost(Post Post)
        {
         
            SqlConnection con = new DalHelper().GetConnection();
            try { 
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_POST"; 
            cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = Post.PostID;
            cmd.Parameters.Add("@PostStatusId", SqlDbType.Int).Value = Post.PostStatusId;
            cmd.Parameters.Add("@PostTypeId", SqlDbType.Int).Value = Post.PostTypeId;
            cmd.Parameters.Add("@GazNonGazId", SqlDbType.Int).Value = Post.GazNonGazId;
            cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Post.Description;
            cmd.Parameters.Add("@ScaleFrom", SqlDbType.Int).Value = Post.ScaleFrom;
            cmd.Parameters.Add("@ScaleTo", SqlDbType.Int).Value = Post.ScaleTo;
            cmd.Parameters.Add("@NoOfPosts", SqlDbType.Int).Value = Post.NumOfPosts;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Post.Is_active;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }
        }
        public void InsertPost(Post Post)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try { 
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_POST";
            cmd.Parameters.Add("@PostTypeId", SqlDbType.Int).Value = Post.PostTypeId;
            cmd.Parameters.Add("@PostStatusId", SqlDbType.Int).Value = Post.PostStatusId;
            cmd.Parameters.Add("@GazNonGazId", SqlDbType.Int).Value = Post.GazNonGazId;
            cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Post.Description;
            cmd.Parameters.Add("@ScaleFrom", SqlDbType.Int).Value = Post.ScaleFrom;
            cmd.Parameters.Add("@ScaleTo", SqlDbType.Int).Value = Post.ScaleTo;
            cmd.Parameters.Add("@NoOfPosts", SqlDbType.Int).Value = Post.NumOfPosts;
            cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Post.Is_active;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            AuditLogger.LogCommand(cmd);
            }
            finally
            {
                con.Close();

            }
        }
        #endregion POSTS
        #region POST TYPES

        #endregion
        #region PROVINCES

        public List<Province> GetProvinces()
        {

            SqlConnection con = new DalHelper().GetConnection();
            try { 
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
                        pr.ProvincesID = Convert.ToInt32(dr["Provinces_id"]);
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
            try { 
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PROVINCE_BY_ID";
            cmd.Parameters.Add("@provinceId", SqlDbType.Int).Value = ProvinceId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
                Province pr = null;
                if (dr.HasRows)
                {
                    dr.Read();
                    pr = new Province();
                    pr.ProvincesID = Convert.ToInt32(dr["Provinces_id"]);
                    pr.Description = Convert.ToString(dr["Description"]);
                    pr.IsActive = Convert.ToInt32(dr["Is_Active"]);

                }
             
            return pr;
            }
            finally
            {
                con.Close();

            }

        }
        #endregion PROVINCES
        #region PHONE TYPE
        public List<PhoneTypes> GePhoneTypes()
        {

            SqlConnection con = new DalHelper().GetConnection();
            try { 
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
                        pt.PhoneTypeID = Convert.ToInt32(dr["Phone_Types_id"]);
                        pt.Description = Convert.ToString(dr["Description"]);
                        pt.Is_active = Convert.ToInt32(dr["Is_Active"]);
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
        #region PASSPORT
        public List<PassportTypes> GetPassportTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try { 
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
                        ad.Is_Active = Convert.ToInt32(dr["Is_Active"]);
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
            try { 
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PASSPORT_TYPES";
            cmd.Parameters.Add("@PassportTypeId", SqlDbType.Int).Value = PassportTypeId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            PassportTypes pt = new PassportTypes();
            pt.PassportTypeId = Convert.ToInt32(dr["Passport_Types_ID"]);
            pt.Description = Convert.ToString(dr["Description"]);
            pt.Is_Active = Convert.ToInt32(dr["Is_Active"]);
            return pt;
            }
            finally
            {
                con.Close();

            }


        }
        #endregion PASSPORT
        #region RELIGION
        public Religion GetReligion(int ReligionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RELIGION";
                cmd.Parameters.Add("@TempId", SqlDbType.Int).Value = ReligionId;
                cmd.CommandType = CommandType.StoredProcedure;
                Religion Rlgn = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Rlgn = new Religion();
                    Rlgn.ReligionId = Convert.ToInt32(dr["religions_id"]);
                    Rlgn.Description = Convert.ToString(dr["Description"]);
                    Rlgn.Is_active = Convert.ToInt32(dr["Is_Active"]);
                }

                return Rlgn;
            }
            finally
            {
                con.Close();

            }
        }
        public List<Religion> GetReligions()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try { 
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
                        ad.Is_active = Convert.ToInt32(dr["Is_Active"]);
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
        #region POST STATUS
        public List<PostStatus> GetPostStatus()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try { 
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_POST_STATUS";
            cmd.CommandType = CommandType.StoredProcedure;
            List<PostStatus> ps = null;
            SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    ps = new List<PostStatus>();
                    while (dr.Read())
                    {
                        PostStatus ad = new PostStatus();
                        ad.PostStatusID = Convert.ToInt32(dr["Post_Statuses_id"]);
                        ad.Description = Convert.ToString(dr["Description"]);
                        ad.IsActive = Convert.ToInt32(dr["Is_Active"]);
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
        #region POST TYPE
        public List<PostType> GetPostType()
        {

            SqlConnection con = new DalHelper().GetConnection();
            try { 
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_POST_TYPES";
            cmd.CommandType = CommandType.StoredProcedure;
            List<PostType> ps = null;
            SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    ps = new List<PostType>();
                    while (dr.Read())
                    {
                        PostType ad = new PostType();

                        ad.PostTypeId = Convert.ToInt32(dr["Post_Types_id"]);
                        ad.Description = Convert.ToString(dr["Description"]);
                        ad.Is_Active = Convert.ToInt32(dr["Is_Active"]);
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



        public List<PostSubType> GetPostSubType()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try { 
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_POST_SUB_TYPES";
            cmd.CommandType = CommandType.StoredProcedure;
            List<PostSubType> ps = null;
            SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    ps = new List<PostSubType>();
                    while (dr.Read())
                    {
                        PostSubType ad = new PostSubType();

                        ad.PostSubTypeId = Convert.ToInt32(dr["Post_Sub_Types_id"]);
                        ad.Description = Convert.ToString(dr["Description"]);
                        ad.Is_Active = Convert.ToInt32(dr["Is_Active"]);
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
        #region DEPENDANTS
        public List<Relations> GetRelations()
        {

            SqlConnection con = new DalHelper().GetConnection();
            try { 

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
        public List<VistTypes> GetVisitTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try { 
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
        public List<NOCTypes> GetNOCTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try { 
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_NOC_TYPES";
            cmd.CommandType = CommandType.StoredProcedure;
            List<NOCTypes> noctypes = null;

            using (con)
            {

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    noctypes = new List<NOCTypes>();
                    while (dr.Read())
                    {
                        NOCTypes ad = new NOCTypes();
                        ad.NocTypeId = Convert.ToInt32(dr["NOC_TYPES_ID"]);
                        ad.Description= Convert.ToString(dr["Description"]);

                        noctypes.Add(ad);
                    }
                }
            }
            if (noctypes != null) noctypes.TrimExcess();
            return noctypes;
            }
            finally
            {
                con.Close();

            }
        }
        #region CURRENT STATUS
        public List<CurrentStatuses> GetCurrentStatuses()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try { 
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CURRENT_STATUSES";
            cmd.CommandType = CommandType.StoredProcedure;
            List<CurrentStatuses> currentstatuses = null;
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    currentstatuses = new List<CurrentStatuses>();
                    while (dr.Read())
                    {
                        CurrentStatuses ad = new CurrentStatuses();

                        ad.CurrentStatusId = Convert.ToInt32(dr["CURRENT_STATUS_ID"]);
                        ad.CurrentStatus = Convert.ToString(dr["CURRENT_STATUS"]);
                       
                        currentstatuses.Add(ad);
                    }
                }
            }
            if (currentstatuses != null) currentstatuses.TrimExcess();
            return currentstatuses;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion
        public List<EmploymentStatus> GetEmploymentStatuses()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try { 
        SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMPLOYMENT_STATUSES";
            cmd.CommandType = CommandType.StoredProcedure;
            List<EmploymentStatus> empstatuses = null;
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    empstatuses = new List<EmploymentStatus>();
                    while (dr.Read())
                    {
                        EmploymentStatus ad = new EmploymentStatus();

                        ad.EmpStatusId= Convert.ToInt32(dr["EMPL_STATUS_ID"]);
                        ad.EmpStatus = Convert.ToString(dr["EMPL_STATUS"]);

                        empstatuses.Add(ad);
                    }
                }
            }
            if (empstatuses != null) empstatuses.TrimExcess();
            return empstatuses;
            }
            finally
            {
                con.Close();

            }
        }
        public List<ProbationTypes> GetProbationTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try { 
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PROBATION_TYPES";
            cmd.CommandType = CommandType.StoredProcedure;
            List<ProbationTypes> probtypes = null;
             SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    probtypes = new List<ProbationTypes>();
                    while (dr.Read())
                    {
                        ProbationTypes ad = new ProbationTypes();

                        ad.ProbationTypeId = Convert.ToInt32(dr["PROBATION_TYPE_ID"]);
                        ad.ProbationType = Convert.ToString(dr["PROBATION_TYPE"]);

                        probtypes.Add(ad);
                    }
                }
           
            if (probtypes != null) probtypes.TrimExcess();
            return probtypes;
            }
            finally
            {
                con.Close();

            }
        }
        public List<ContractTypes> GetContractTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try { 
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CONTRACT_TYPES";
            cmd.CommandType = CommandType.StoredProcedure;
            List<ContractTypes> probtypes = null;
            SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    probtypes = new List<ContractTypes>();
                    while (dr.Read())
                    {
                        ContractTypes ad = new ContractTypes();

                        ad.ContractTypeId = Convert.ToInt32(dr["CONTRACT_TYPES_ID"]);
                        ad.ContractType = Convert.ToString(dr["CONTRACT_TYPE"]);

                        probtypes.Add(ad);
                    }
                }
            
            if (probtypes != null) probtypes.TrimExcess();
            return probtypes;
            }
            finally
            {
                con.Close();

            }
        }
        public List<EmploymentStatus> GetOtherEmploymentStatuses()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try { 
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_OTHER_EMPLOYMENT_STATUS";
            cmd.CommandType = CommandType.StoredProcedure;
            List<EmploymentStatus> empstatuses = null;
            SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    empstatuses = new List<EmploymentStatus>();
                    while (dr.Read())
                    {
                        EmploymentStatus ad = new EmploymentStatus();

                        ad.EmpStatusId = Convert.ToInt32(dr["EMPL_STATUS_ID"]);
                        ad.EmpStatus = Convert.ToString(dr["EMPL_STATUS"]);

                        empstatuses.Add(ad);
                    }
                }
              if (empstatuses != null) empstatuses.TrimExcess();
            return empstatuses;
            }
            finally
            {
                con.Close();

            }
        }
        public List<EmploymentOutTypes> GetEmploymentOutTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try { 
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMPL_OUT_TYPES";
            cmd.CommandType = CommandType.StoredProcedure;
            List<EmploymentOutTypes> EmplOutTypes = null;
             SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    EmplOutTypes = new List<EmploymentOutTypes>();
                    while (dr.Read())
                    {
                        EmploymentOutTypes EmplOutType = new EmploymentOutTypes();

                        EmplOutType.EmploymentOutTypeId = Convert.ToInt32(dr["EMPL_OUT_TYPE_ID"]);
                        EmplOutType.EmploymentOuType = Convert.ToString(dr["EMPL_OUT_TYPE"]);

                        EmplOutTypes.Add(EmplOutType);
                    }
                }
   
            if (EmplOutTypes != null) EmplOutTypes.TrimExcess();
            return EmplOutTypes;
            }
            finally
            {
                con.Close();

            }
        }

        public List<TempEntity> GetAcrStatuses()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try { 
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACR_STATUSES";
            cmd.CommandType = CommandType.StoredProcedure;
            List<TempEntity> TempList = null;
            SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    TempList = new List<TempEntity>();
                    while (dr.Read())
                    {
                        TempEntity Temp = new TempEntity();

                        Temp.Id = Convert.ToInt32(dr["ACR_STATUS_ID"]);
                        Temp.Description = Convert.ToString(dr["ACR_STATUS"]);

                        TempList.Add(Temp);
                    }
                }
           
            if (TempList != null) TempList.TrimExcess();
            return TempList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<TempEntity> GetAcrGrades()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try { 
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACR_GRADES";
            cmd.CommandType = CommandType.StoredProcedure;
            List<TempEntity> TempList = null;
            SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    TempList = new List<TempEntity>();
                    while (dr.Read())
                    {
                        TempEntity Temp = new TempEntity();

                        Temp.Id = Convert.ToInt32(dr["ACR_GRADE_ID"]);
                        Temp.Description = Convert.ToString(dr["ACR_GRADE"]);

                        TempList.Add(Temp);
                    }
                }
            if (TempList != null) TempList.TrimExcess();
            return TempList;
            }
            finally
            {
                con.Close();

            }
        }

        public List<TempEntity> GetEmplQuotas()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try { 
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMPL_QUOTAS";
            cmd.CommandType = CommandType.StoredProcedure;
            List<TempEntity> TempList = null;
            SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    TempList = new List<TempEntity>();
                    while (dr.Read())
                    {
                        TempEntity Temp = new TempEntity();

                        Temp.Id = Convert.ToInt32(dr["EMPL_QUOTA_ID"]);
                        Temp.Description = Convert.ToString(dr["EMPL_QUOTA"]);

                        TempList.Add(Temp);
                    }
                }
            if (TempList != null) TempList.TrimExcess();
            return TempList;
            }
            finally
            {
                con.Close();

            }
        }

        public TempEntity GetEmplQuota(int QuotaId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMPL_QUOTA";
                cmd.Parameters.Add("@QuotaId", SqlDbType.Int).Value = QuotaId;
                cmd.CommandType = CommandType.StoredProcedure;
                TempEntity Temp = new TempEntity();
                Temp.Id = 0;Temp.Description = "Not Mentioned";
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                      dr.Read();
                      Temp.Id = Convert.ToInt32(dr["EMPL_QUOTA_ID"]);
                      Temp.Description = Convert.ToString(dr["EMPL_QUOTA"]);
                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        public List<TempEntity> GetOtherEmplQuotas()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try { 
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_OTHER_EMPL_QUOTAS";
            cmd.CommandType = CommandType.StoredProcedure;
            List<TempEntity> TempList = null;
            SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    TempList = new List<TempEntity>();
                    while (dr.Read())
                    {
                        TempEntity Temp = new TempEntity();

                        Temp.Id = Convert.ToInt32(dr["OTHER_EMPL_QUOTA_ID"]);
                        Temp.Description = Convert.ToString(dr["OTHER_EMPL_QUOTA"]);

                        TempList.Add(Temp);
                    }
                }
          
            if (TempList != null) TempList.TrimExcess();
            return TempList;
            }
            finally
            {
                con.Close();

            }
        }
        //public TempEntity GetQuota(int Id)
        //{

        //    SqlConnection con = new DalHelper().GetConnection();
        //    SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
        //    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_EMPL_QUOTA";
        //    cmd.Parameters.Add("@PassportTypeId", SqlDbType.Int).Value = Id;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    dr.Read();
        //    PassportTypes pt = new PassportTypes();
        //    pt.PassportTypeId = Convert.ToInt32(dr["Passport_Types_ID"]);
        //    pt.Description = Convert.ToString(dr["Description"]);
        //    pt.Is_Active = Convert.ToInt32(dr["Is_Active"]);
        //    return pt;


        //}
        
             public List<TempEntity> GetOtherChargeTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            { 
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_OTHER_CHARGE_TYPES";
            cmd.CommandType = CommandType.StoredProcedure;
            List<TempEntity> TempList = null;
            SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    TempList = new List<TempEntity>();
                    while (dr.Read())
                    {
                        TempEntity Temp = new TempEntity();

                        Temp.Id = Convert.ToInt32(dr["EMP_OTHER_CHARGE_TYPE_ID"]);
                        Temp.Description = Convert.ToString(dr["EMP_OTHER_CHARGE_TYPE"]);

                        TempList.Add(Temp);
                    }
                }
            if (TempList != null) TempList.TrimExcess();
            return TempList;
            }
            finally
            {
                con.Close();

            }
        }

        public List<TempEntity> GetSecClearanceTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try { 
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SEC_CLEARANCE_TYPES";
            cmd.CommandType = CommandType.StoredProcedure;
            List<TempEntity> TempList = null;
            SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    TempList = new List<TempEntity>();
                    while (dr.Read())
                    {
                        TempEntity Temp = new TempEntity();

                        Temp.Id = Convert.ToInt32(dr["SEC_CLEARANCE_TYPE_ID"]);
                        Temp.Description = Convert.ToString(dr["SEC_CLEARANCE_TYPE"]);

                        TempList.Add(Temp);
                    }
                }
            if (TempList != null) TempList.TrimExcess();
            return TempList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<TempEntity> GetDiscipActionTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try { 
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_DISCIP_ACTION_TYPES";
            cmd.CommandType = CommandType.StoredProcedure;
            List<TempEntity> TempList = null;
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    TempList = new List<TempEntity>();
                    while (dr.Read())
                    {
                        TempEntity Temp = new TempEntity();

                        Temp.Id = Convert.ToInt32(dr["DISCIPLINARY_ACTION_TYPE_ID"]);
                        Temp.Description = Convert.ToString(dr["DISCIPLINARY_ACTION_TYPE"]);

                        TempList.Add(Temp);
                    }
                }
            }
            if (TempList != null) TempList.TrimExcess();
            return TempList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<TempEntity> GetFinalDiscipActionTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try { 
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_FINAL_DISCIP_ACTION_TYPES";
            cmd.CommandType = CommandType.StoredProcedure;
            List<TempEntity> TempList = null;
             SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    TempList = new List<TempEntity>();
                    while (dr.Read())
                    {
                        TempEntity Temp = new TempEntity();

                        Temp.Id = Convert.ToInt32(dr["FINAL_DISCIP_ACTION_TYPE_ID"]);
                        Temp.Description = Convert.ToString(dr["FINAL_DISCIP_ACTION_TYPE"]);

                        TempList.Add(Temp);
                    }
                }
            if (TempList != null) TempList.TrimExcess();
            return TempList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<TempEntity> GetRetirementTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try { 
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RETIREMENT_TYPES";
            cmd.CommandType = CommandType.StoredProcedure;
            List<TempEntity> TempList = null;
            SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    TempList = new List<TempEntity>();
                    while (dr.Read())
                    {
                        TempEntity Temp = new TempEntity();

                        Temp.Id = Convert.ToInt32(dr["RETIREMENT_TYPE_ID"]);
                        Temp.Description = Convert.ToString(dr["RETIREMENT_TYPE"]);

                        TempList.Add(Temp);
                    }
                }
            if (TempList != null) TempList.TrimExcess();
            return TempList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<TempEntity> GetRetirementModes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_RETIREMENT_MODES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<TempEntity> TempList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    TempList = new List<TempEntity>();
                    while (dr.Read())
                    {
                        TempEntity Temp = new TempEntity();

                        Temp.Id = Convert.ToInt32(dr["RETIREMENT_MODE_ID"]);
                        Temp.Description = Convert.ToString(dr["RETIREMENT_MODE"]);

                        TempList.Add(Temp);
                    }
                }
                if (TempList != null) TempList.TrimExcess();
                return TempList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<TempEntity> GetPromotionTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try { 
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PROMOTION_TYPES";
            cmd.CommandType = CommandType.StoredProcedure;
            List<TempEntity> TempList = null;
            SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    TempList = new List<TempEntity>();
                    while (dr.Read())
                    {
                        TempEntity Temp = new TempEntity();

                        Temp.Id = Convert.ToInt32(dr["PROMOTION_TYPE_ID"]);
                        Temp.Description = Convert.ToString(dr["PROMOTION_TYPE"]);

                        TempList.Add(Temp);
                    }
                }
            if (TempList != null) TempList.TrimExcess();
            return TempList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<TempEntity> GetMedicalTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try { 
            SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEDICAL_TYPES";
            cmd.CommandType = CommandType.StoredProcedure;
            List<TempEntity> TempList = null;
             SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    TempList = new List<TempEntity>();
                    while (dr.Read())
                    {
                        TempEntity Temp = new TempEntity();

                        Temp.Id = Convert.ToInt32(dr["MEDICAL_TYPE_ID"]);
                        Temp.Description = Convert.ToString(dr["MEDICAL_TYPE"]);

                        TempList.Add(Temp);
                    }
                }
            if (TempList != null) TempList.TrimExcess();
            return TempList;
            }
            finally
            {
                con.Close();

            }
        }
        public List<TempEntity> GetLeaveSubTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_LEAVE_SUBTYPES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<TempEntity> TempList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    TempList = new List<TempEntity>();
                    while (dr.Read())
                    {
                        TempEntity Temp = new TempEntity();

                        Temp.Id = Convert.ToInt32(dr["EMP_LEAVE_SUBTYPE_ID"]);
                        Temp.Description = Convert.ToString(dr["EMP_LEAVE_SUBTYPE"]);

                        TempList.Add(Temp);
                    }
                }
                if (TempList != null) TempList.TrimExcess();
                return TempList;
            }
            finally
            {
                con.Close();

            }
        }

        public void UpdateEnteredData(EmpSearchList slist)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_ENTERED_DATA";
                cmd.Parameters.Add("@SystemUsersId", SqlDbType.Int).Value = slist.EmpId;
                cmd.Parameters.Add("@EnteredBy", SqlDbType.VarChar).Value = slist.EnteredBy;
                cmd.Parameters.Add("@EnteredOn", SqlDbType.DateTime).Value = slist.EnteredOn;
                cmd.Parameters.Add("@RecheckedBy", SqlDbType.VarChar).Value = slist.RecheckedBy;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                AuditLogger.LogCommand(cmd);
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
        public List<PenaltyTypes> GetPenaltyTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PENALTY_TYPES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<PenaltyTypes> penaltytype = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    penaltytype = new List<PenaltyTypes>();
                    while (dr.Read())
                    {
                        PenaltyTypes ad = new PenaltyTypes();

                        ad.PenaltyTypeId = Convert.ToInt32(dr["PENALTY_TYPES_ID"]);
                        ad.PenaltyType = Convert.ToString(dr["PENALTY_TYPE"]);
                        ad.IsMajor= Convert.ToInt32(dr["IS_MAJOR"]);
                        ad.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        penaltytype.Add(ad);
                    }
                }

                if (penaltytype != null) penaltytype.TrimExcess();
                return penaltytype;
            }
            finally
            {
                con.Close();

            }
        }
        public List<BenFundTypes> GetBenFundTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BENEVOLENT_FUND_TYPES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<BenFundTypes> noctypes = null;

                using (con)
                {

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        noctypes = new List<BenFundTypes>();
                        while (dr.Read())
                        {
                            BenFundTypes ad = new BenFundTypes();
                            ad.BenFundTypeId = Convert.ToInt32(dr["EMP_BEN_FUND_TYPE_ID"]);
                            ad.FundType = Convert.ToString(dr["BEN_FUND_TYPE"]);

                            noctypes.Add(ad);
                        }
                    }
                }
                if (noctypes != null) noctypes.TrimExcess();
                return noctypes;
            }
            finally
            {
                con.Close();

            }
        }
    }
}
