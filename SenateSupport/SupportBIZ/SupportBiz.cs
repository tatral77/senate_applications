using SupportEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupportDAL;
using SupportingEntities;

namespace SupportBIZ
{
    public class SupportBiz
    {
        #region CITY
        public List<City> GetCities()
        {
            return new SupportDal().GetCities();

        }
        public City GetCity(int cityId)
        {
            return new SupportDal().GetCity(cityId);
        }
        public List<City> GetCities(int countryid)
        {
            return new SupportDal().GetCities(countryid);
        }
        #endregion CITY

        #region TENURES
        public List<Tenures> GetTenures()
        {
            return new SupportDal().GetTenures();
        }
        public Tenures GetTenure(int Id)
        {
            return new SupportDal().GetTenure(Id);
        }
        public Tenures GetCurrentTenure(int Id)
        {
            return new SupportDal().GetCurrentTenure();
        }
        public void InsertTenures(Tenures obj)
        {
            new SupportDal().InsertTenures(obj);
        }
        public void UpdateTenures(Tenures obj)
        {
            new SupportDal().UpdateTenures(obj);
        }
        #endregion
        #region TERMS
        public List<Terms> GetTerms()
        {
            return new SupportDal().GetTerms();
        }
        public Terms GetTerm(int Id)
        {
            return new SupportDal().GetTerm(Id);
        }
        public Terms GetCurrentTerm()
        {
            return new SupportDal().GetCurrentTerm();
        }
        public void InsertTerm(Terms obj)
        {
            new SupportDal().InsertTerm(obj);
        }
        public void UpdateTerm(Terms obj)
        {
            new SupportDal().UpdateTerm(obj);
        }
        #endregion
        #region GENDER
        public List<Gender> GetGenders()
        {
            return new SupportDal().GetGenders();

        }
        #endregion
        #region MARITAL STATUS
        public List<MaritalStatus> GetMaritalStatuses()
        {
            return new SupportDal().GetMaritalStatuses();

        }
        #endregion
        #region RELIGION
        public List<Religion> GetReligions()
        {
            return new SupportDal().GetReligions();

        }

        #endregion

 
        #region COUNTRIES
        public List<Country> GetCountries()
        {
            return new SupportDal().GetCountries();
        }
        public Country GetCountry(int countryId)
        {
            return new SupportDal().GetCountry(countryId);

        }
        public List<City> GetCountryCities(int countryId)
        {
            return new SupportDal().GetCountryCities(countryId);
        }

        #endregion
        #region COURSE
        public List<CourseType> GetCourseTypes()
        {
            return new SupportDal().GetCourseTypes();
        }
        public CourseType GetCourseType(int courseTypeId)
        {
            return new SupportDal().GetCourseType(courseTypeId);

        }
        #endregion
        #region DEGREE LEVEL
        public List<DegreeLevel> GetDegreeLevels()
        {
            return new SupportDal().GetDegreeLevels();
        }
        public DegreeLevel GetDegreeLevel(int degreelevelid)
        {
            return new SupportDal().GetDegreeLevel(degreelevelid);

        }
        #endregion
        #region DISTRICT
        public List<District> GetDistricts()
        {
            return new SupportDal().GetDistricts();
        }
        public List<District> GetDistricts(int provinceId)
        {
            return new SupportDal().GetDistricts(provinceId);
        }
        public District GetDistrict(int districtid)
        {
            return new SupportDal().GetDistrict(districtid);

        }
        #endregion

        #region PASSPORT
        public List<PassportTypes> GetPassportTypes()
        {
            return new SupportDal().GetPassportTypes();

        }
        public PassportTypes GetPassportType(int PassportTypeId)
        {
            return new SupportDal().GetPassportType(PassportTypeId);
        }
        #endregion
        #region PHONE TYPES
        public List<PhoneTypes> GePhoneTypes()
        {
            return new SupportDal().GePhoneTypes();

        }
        #endregion

        #region PROVINCE
        public List<Province> GetProvinces()
        {
            return new SupportDal().GetProvinces();

        }
        #endregion
        #region DEPENDANTS

        public List<Relations> GetRelations()
        {
            return new SupportDal().GetRelations();

        }
        #endregion
        #region VISIT_TYPES
        public List<VistTypes> GetVisitTypes()
        {
            return new SupportDal().GetVisitTypes();
        }
        #endregion
        #region POLITICAL PARTIES

        #endregion
        public List<PoliticalParty> GetPoliticalParties()
        {
            return new SupportDal().GetPoliticalParties();
        }
        public List<MemberStatus> GetMemberStatuses()
        {
            return new SupportDal().GetMemberStatuses();
        }
        #region ASSEMBLIES
        public List<Assemblies> GetAssemblies()
        {
            return new SupportDal().GetAssemblies();
        }
        #endregion ASSEMBLIES
        #region ELECTION TYPES
        public List<ElectionTypes> GetElectionTypes()
        {
            return new SupportDal().GetElectionTypes();
        }
        #endregion
        #region Phone Types
        public List<PhoneTypes> GetPhoneTypes()
        {
            return new SupportDal().GetPhoneTypes();
        }
            #endregion



        }
}

