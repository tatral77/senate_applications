using IPRENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPRDAL;

namespace IPRBIZ
{
    public class DataManagementBIZ
    {
        #region COUNTRIES
        public List<Country> GetActiveCountries()
        {
            return new DataManagementDAL().GetActiveCountries();
           
        }
        public List<Country> GetAllCountries()
        {
            return new DataManagementDAL().GetAllCountries();
        }

        public Country GetCountry(int countryId)
        {
            return new DataManagementDAL().GetCountry(countryId);
        }
        public void InsertCountry(Country country)
        {
            new DataManagementDAL().InsertCountry(country);
        }
        public void UpdateCountry(Country country)
        {
            new DataManagementDAL().UpdateCountry(country);

        }
        #endregion COUNTRIES
        //#region CITY
        //public List<City> GetCities()
        //{
        //    return new DataManagementDAL().GetCities();

        //}
        //public List<City> GetAllCities()
        //{
        //    return new DataManagementDAL().GetCities();

        //}
        //public City GetCity(int cityId)
        //{
        //    return new DataManagementDAL().GetCity(cityId);
        //}
        //public List<City> GetCities(int countryid)
        //{
        //    return new DataManagementDAL().GetCities(countryid);
        //}
        //public void InsertCity(City city)
        //{
        //    new DataManagementDAL().InsertCity(city);
        //}

        //public void UpdateCity(City city)
        //{
        //    new DataManagementDAL().UpdateCity(city);
        //}

        //#endregion CITY


        //#region  ParliamentaryTenures

        //public List<ParliamentaryTenures> GetParliamentaryTenures()
        //{
        //    return new DataManagementDAL().GetParliamentaryTenures();
        //}
        //public ParliamentaryTenures GetParliamentaryTenure(int ParliamentaryTenureId)
        //{
        //    return new DataManagementDAL().GetParliamentaryTenure(ParliamentaryTenureId);
        //}
        //public void UpdateParliamentaryTenure(ParliamentaryTenures Temp)
        //{
        //    new DataManagementDAL().UpdateParliamentaryTenures(Temp);
        //}
        //public void InsertParliamentaryTenure(ParliamentaryTenures Temp)
        //{
        //    new DataManagementDAL().InsertParliamentaryTenures(Temp);
        //}

        //#endregion ParliamentaryTerms
        //#region PARLIAMENTARY TERMS
        //public List<ParliamentaryTerms> GetParliamentaryTerms()
        //{
        //    return new DataManagementDAL().GetParliamentaryTerms();
        //}

        //public ParliamentaryTerms GetParliamentaryTerm(int ParliamentaryTermId)
        //{
        //    return new DataManagementDAL().GetParliamentaryTerm(ParliamentaryTermId);
        //}
        //public void UpdateParliamentaryTerm(ParliamentaryTerms Temp)
        //{
        //    new DataManagementDAL().UpdateParliamentaryTerm(Temp);  
        //}
        //public void InsertParliamentaryTerm(ParliamentaryTerms Temp)
        //{
        //    new DataManagementDAL().InsertParliamentaryTerm(Temp);
        //}
        //#endregion PARLIAMENTARY TERMS
        //#region PARLIAMENTARY TENURE TERM
        //public List<ParliamentaryTenureTerm> GetParliamentaryTenureTerms(int ParliamentaryTenureId)
        //{
        //    return new DataManagementDAL().GetParliamentaryTenureTerms(ParliamentaryTenureId);
        //}
        //public void UpdateParliamentaryTenureTerm(ParliamentaryTenureTerm Temp)
        //{
        //    new DataManagementDAL().UpdateParliamentaryTenureTerm(Temp);
        //}
        //public void InsertParliamentaryTenureTerm(ParliamentaryTenureTerm Temp)
        //{
        //    new DataManagementDAL().InsertParliamentaryTenureTerm(Temp);
        //}
        //#endregion  PARLIAMENTARY TENURE TERM
        #region CITIES
        public List<City> GetActiveCitiesByCountry(int CountryId)
        {
            return new DataManagementDAL().GetActiveCitiesByCountry(CountryId);

        }
        public List<City> GetAllCitiesByCountry(int CountryId)
        {
            return new DataManagementDAL().GetAllCitiesByCountry(CountryId);

        }
        public City GetCity(int cityId)
        {
            return new DataManagementDAL().GetCity(cityId);
        }

        public void InsertCity(City city)
        {
            new DataManagementDAL().InsertCity(city);
        }
        public void UpdateCity(City city)
        {
            new DataManagementDAL().UpdateCity(city);
        }
        public void DeleteCity(int CityId)
        {
            new DataManagementDAL().DeleteCity(CityId);
        }
        public List<City> GetCityByName(string cityname)
        {
            return new DataManagementDAL().GetCityByName(cityname);
        }
            #endregion CITIES


        }
}
