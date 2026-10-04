using IPRBIZ;
using IPRENITITIES;
using IPRENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace IPR
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetEmployeeByName(string prefix)
        {
           
            List<string> empResult = new List<string>();
            List<Visitor> senators = new List<Visitor>();
            List<Visitor> employees = new List<Visitor>();
            List<Visitor> allvisitors = new List<Visitor>();
            senators = new IPRBiz().GetSenatorByName(prefix);
            employees = new IPRBiz().GetEmployeeByName(prefix);
            if (senators != null)
            {
                foreach (Visitor b in senators)
                {
                    empResult.Add(string.Format("{0}={1}={2}={3}={4}", b.VisitorName, b.SystemUsersId, b.CategoryId,b.IsEmployee,b.Designation));
                }
            }
            if (employees != null)
            {
                foreach (Visitor a in employees)
                {
                    empResult.Add(string.Format("{0}={1}={2}={3}={4}", a.VisitorName, a.SystemUsersId, a.CategoryId,a.IsEmployee,a.Designation));
                }
            }
            return empResult.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetCityByName(string prefix)
        {

            List<string> empResult = new List<string>();
            List<City> cities = new List<City>();
            cities = new DataManagementBIZ().GetCityByName(prefix);
         
            if (cities != null)
            {
                foreach (City a in cities)
                {
                    empResult.Add(string.Format("{0}={1}", a.CityName, a.CityId));
                }
            }
            return empResult.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetCountryLocationsByName(string prefix, string Id)
        {
            int id = Convert.ToInt32(Id);
            OutgoingVisit visit = new IPRBiz().GetOutgoingVisit(id);
            List<string> empResult = new List<string>();
            List<Location> locations = new List<Location>();
            locations = new IPRBiz().GetCountryLocationsByName(visit.CountryId, prefix);

            if (locations != null)
            {
                foreach (Location a in locations)
                {
                    empResult.Add(string.Format("{0}={1}", a.LocationName, a.LocationId));
                }
            }
            return empResult.ToArray();
        }

    }
}
