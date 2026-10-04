using EstablishmentDAL;
using EstablishmentENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentBIZ
{
    public class AdministrationBIZ
    {
        public List<TempEntity> GetPromotionModes()
        {
            return new AdministrationDAL().GetPromotionModes();
        }

        public List<TempEntity> GetAppointmenModes()
        {
            return new AdministrationDAL().GetAppointmenModes();
        }
        public TempEntity GetAppointmenMode(int AppointmentModeId)
        {
            return new AdministrationDAL().GetAppointmenMode(AppointmentModeId);
        }
        #region BPS
        public List<BPS> GetAllBPS()
        {
            return new AdministrationDAL().GetAllBPS();

        }
        public BPS GetBPS(int BPSId)
        {
            return new AdministrationDAL().GetBPS(BPSId);
        }
        #endregion
        #region BRANCH
        public List<Branch> GetBranches()
        {
            return new AdministrationDAL().GetBranches();

        }
        public Branch GetBranch(int BranchId)
        {
            return new AdministrationDAL().GetBranch(BranchId);
        }
        public List<Branch> GetAllBranches()
        {
            return new AdministrationDAL().GetAllBranches();

        }
        public void UpdateBranch(Branch Branch)
        {
            new AdministrationDAL().UpdateBranch(Branch);
        }
        public void InsertBranch(Branch Branch)
        {
            new AdministrationDAL().InsertBranch(Branch);
        }
        #endregion
        #region GENDER
        public Gender GetGender(int GenderId)
        {
            return new AdministrationDAL().GetGender(GenderId);
        }

        public List<Gender> GetGenders()
        {
            return new AdministrationDAL().GetGenders();

        }
        #endregion
        #region MARITAL STATUS
        public MaritalStatus GetMaritalStatus(int MaritalStatuId)
        {
            return new AdministrationDAL().GetMaritalStatus(MaritalStatuId);

        }
        public List<MaritalStatus> GetMaritalStatuses()
        {
            return new AdministrationDAL().GetMaritalStatuses();

        }
        #endregion
        #region RELIGION
        public Religion GetReligion(int ReligionId)
        {
            return new AdministrationDAL().GetReligion(ReligionId);

        }
        public List<Religion> GetReligions()
        {
            return new AdministrationDAL().GetReligions();

        }

        #endregion
        #region POSTS
        public List<Post> GetAllPosts()
        {
            return new AdministrationDAL().GetAllPosts();

        }
        public Post GetPost(int PostId)
        {
            return new AdministrationDAL().GetPost(PostId);
        }
        public void UpdatePost(Post Post)
        {
            new AdministrationDAL().UpdatePost(Post);
        }
        public void InsertPost(Post Post)
        {
            new AdministrationDAL().InsertPost(Post);
        }
        public List<Post> GetActivePosts()
        {
            return new AdministrationDAL().GetActivePosts();

        }
        #endregion
        #region POST TYPES
        public List<PostType> GetPostType()
        {
            return new AdministrationDAL().GetPostType();
        }
        public List<PostSubType> GetPostSubType()
        {
            return new AdministrationDAL().GetPostSubType();
        }
        #endregion
        #region CITY
        public List<City> GetCities()
        {
            return new AdministrationDAL().GetCities();

        }
        public List<City> GetAllCities()
        {
            return new AdministrationDAL().GetCities();

        }
        public City GetCity(int cityId)
        {
            return new AdministrationDAL().GetCity(cityId);
        }
        public List<City> GetCities(int countryid)
        {
            return new AdministrationDAL().GetCities(countryid);
        }
        public void InsertCity(City city)
        {
            new AdministrationDAL().InsertCity(city);
        }

        public void UpdateCity(City city)
        {
            new AdministrationDAL().UpdateCity(city);
        }

        #endregion
        #region COUNTRIES
        public List<Country> GetCountries()
        {
            return new AdministrationDAL().GetCountries();
        }
        public Country GetCountry(int countryId)
        {
            return new AdministrationDAL().GetCountry(countryId);

        }
        public List<City> GetCountryCities(int countryId)
        {
            return new AdministrationDAL().GetCountryCities(countryId);
        }

        #endregion
        #region COURSE
        public List<CourseType> GetCourseTypes()
        {
            return new AdministrationDAL().GetCourseTypes();
        }
        public CourseType GetCourseType(int courseTypeId)
        {
            return new AdministrationDAL().GetCourseType(courseTypeId);

        }
        #endregion
        #region DEGREE LEVEL
        public List<DegreeLevel> GetDegreeLevels()
        {
            return new AdministrationDAL().GetDegreeLevels();
        }
        public DegreeLevel GetDegreeLevel(int degreelevelid)
        {
            return new AdministrationDAL().GetDegreeLevel(degreelevelid);

        }
        #endregion
        #region DISTRICT
        public List<District> GetDistricts()
        {
            return new AdministrationDAL().GetDistricts();
        }
        public List<District> GetAllDistricts()
        {
            return new AdministrationDAL().GetAllDistricts();
        }
        public List<District> GetDistricts(int provinceId)
        {
            return new AdministrationDAL().GetDistricts(provinceId);
        }
        public District GetDistrict(int districtid)
        {
            return new AdministrationDAL().GetDistrict(districtid);

        }
        public void UpdateDistrict(District districts)
        {
             new AdministrationDAL().UpdateDistrict(districts);

        }
        public void InsertDistrict(District districts)
        {
            new AdministrationDAL().InsertDistrict(districts);

        }
        #endregion
        #region EMPLOYEE POOL
        public EmployeePools GetEmpPool(int PoolId)
        {
            return new AdministrationDAL().GetEmpPool(PoolId);
        }
        public List<EmployeePools> GetEmpPools()
        {

            return new AdministrationDAL().GetEmpPools();
        }
        #endregion
        #region EMPLOYEE STATUS
        public List<EmpStatus> GetEmpStatusList()
        {
            return new AdministrationDAL().GetEmpStatusList();

        }
        #endregion       
        #region LEAVE TYPE
        public List<LeaveType> GetLeaveTypes()
        {
            return new AdministrationDAL().GetLeaveTypes();

        }
        public LeaveType GetLeaveType(int LeaveTypeId)
        {
            return new AdministrationDAL().GetLeaveType(LeaveTypeId);
        }
        #endregion       
        #region PASSPORT
        public List<PassportTypes> GetPassportTypes()
        {
            return new AdministrationDAL().GetPassportTypes();

        }
        public PassportTypes GetPassportType(int PassportTypeId)
        {
            return new AdministrationDAL().GetPassportType(PassportTypeId);
        }
        #endregion
        #region PHONE TYPES
        public List<PhoneTypes> GePhoneTypes()
        {
            return new AdministrationDAL().GePhoneTypes();

        }
        #endregion
        #region POST STATUS

        public List<PostStatus> GetPostStatus()
        {
            return new AdministrationDAL().GetPostStatus();

        }
        #endregion
        #region PROVINCE
        public Province GetProvince(int ProvinceId)
        {
            return new AdministrationDAL().GetProvince(ProvinceId);

        }
        public List<Province> GetProvinces()
        {
            return new AdministrationDAL().GetProvinces();

        }
        #endregion
        #region DEPENDANTS

        public List<Relations> GetRelations()
        {
            return new AdministrationDAL().GetRelations();

        }
        #endregion
        #region VISIT_TYPES
        public List<VistTypes> GetVisitTypes()
        {
            return new AdministrationDAL().GetVisitTypes();
        }
        #endregion
        public List<NOCTypes> GetNOCTypes()
        {
            return new AdministrationDAL().GetNOCTypes();
        }
        public List<CurrentStatuses> GetCurrentStatuses()
        {
            return new AdministrationDAL().GetCurrentStatuses();
        }
        public List<EmploymentStatus> GetEmploymentStatuses()
        {
            return new AdministrationDAL().GetEmploymentStatuses();
        }
        public List<ProbationTypes> GetProbationTypes()
        {
            return new AdministrationDAL().GetProbationTypes();
        }
        public List<ContractTypes> GetContractTypes()
        {
            return new AdministrationDAL().GetContractTypes();
        }
        public List<EmploymentStatus> GetOtherEmploymentStatuses()
        {
            return new AdministrationDAL().GetOtherEmploymentStatuses();
        }
        public List<EmploymentOutTypes> GetEmploymentOutTypes()
        {
            return new AdministrationDAL().GetEmploymentOutTypes();
        }
        public List<TempEntity> GetAcrGrades()
        {
            return new AdministrationDAL().GetAcrGrades();
        }
        public List<TempEntity> GetAcrStatuses()
        {
            return new AdministrationDAL().GetAcrStatuses();
        }
        public List<TempEntity> GetEmplQuotas()
        {
            return new AdministrationDAL().GetEmplQuotas();
        }
        public TempEntity GetEmplQuota(int QuotaId)
        {
            return new AdministrationDAL().GetEmplQuota(QuotaId);
        }
        public List<TempEntity> GetOtherEmplQuotas()
        {
            return new AdministrationDAL().GetOtherEmplQuotas();
        }
        public List<TempEntity> GetOtherChargeTypes()
        {
            return new AdministrationDAL().GetOtherChargeTypes();
        }
        public List<TempEntity> GetSecClearanceTypes()
        {
            return new AdministrationDAL().GetSecClearanceTypes();
        }
        public List<TempEntity> GetDiscipActionTypes()
        {
            return new AdministrationDAL().GetDiscipActionTypes();
        }
        public List<TempEntity> GetFinalDiscipActionTypes()
        {
            return new AdministrationDAL().GetFinalDiscipActionTypes();
        }
        public List<TempEntity> GetRetirementTypes()
        {
            return new AdministrationDAL().GetRetirementTypes();
        }
        public List<TempEntity> GetRetirementModes()
        {
            return new AdministrationDAL().GetRetirementModes();
        }
        public List<TempEntity> GetPromotionTypes()
        {
            return new AdministrationDAL().GetPromotionTypes();
        }
        public List<TempEntity> GetMedicalTypes()
        {
            return new AdministrationDAL().GetMedicalTypes();
        }
        public List<TempEntity> GetDutyTypes()
        {
            return new AdministrationDAL().GetDutyTypes();
        }
        public List<TempEntity> GetLeaveSubTypes()
        {
            return new AdministrationDAL().GetLeaveSubTypes();
        }
        public void UpdateEnteredData(EmpSearchList slist)
        {
            new AdministrationDAL().UpdateEnteredData(slist);
        }
        public List<PenaltyTypes> GetPenaltyTypes()
        {
            return new AdministrationDAL().GetPenaltyTypes();
        }
        public List<BenFundTypes> GetBenFundTypes()
        {
            return new AdministrationDAL().GetBenFundTypes();
        }

        }
}
