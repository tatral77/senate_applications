using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EstablishmentENT;
using EstablishmentDAL;
using System.IO;

namespace EstablishmentBIZ
{
    public class EmployeeHandler
    {
        public int InsertNewEmployee(BasicInfo newEmp)
        {
            return new EmployeeDAL().InsertNewEmployee(newEmp);
        }
        public List<EmpSearchList> GetEmployeesList()
        {
            return new EmployeeDAL().GetEmployeesList();

        }
        public List<EmpSearchList> GetAllEmployeesList()
        {
            return new EmployeeDAL().GetAllEmployeesList();
        }

        public List<EmpSearchList> SearchEmployee(string query)
        {
            return new EmployeeDAL().SearchEmployee(query);
        }
        public List<EmpSearchList> ForceSearchEmployee(string query)
        {
            return new EmployeeDAL().ForceSearchEmployee(query);
        }
        public PersonalDetail GetPersonalDetails(int empId)
        {
            return new EmployeeDAL().GetPersonalDetails(empId);
        }
        public void SavePersonalInfo(PersonalDetail pd)
        {
            new EmployeeDAL().SavePersonalInfo(pd);
        }
        public int DeleteEmployee(int EmpId)
        {
            return new EmployeeDAL().DeleteEmployee(EmpId);
        }
        public List<EmployeePhones> GetEmployeePhones(int empId)
        {
            return new EmployeeDAL().GetEmployeePhones(empId);
        }
        public void SaveEmployeePhones(EmployeePhones ef)
        {
            new EmployeeDAL().SaveEmployeePhones(ef);
        }
        public void DeleteEmployeePhones(int ef)
        {
            new EmployeeDAL().DeleteEmployeePhones(ef);
        }
        public void InsertEmployeePhones(EmployeePhones ef)
        {
            new EmployeeDAL().InsertEmployeePhones(ef);
        }
        public List<EmploymentHistory> GetEmploymentHist(int EmpId)
        {
            return new EmployeeDAL().GetEmploymentHist(EmpId);
        }
        public EmpEmployment GetEmpEmployment(int EmpId)
        {
            return new EmployeeDAL().GetEmpEmployment(EmpId);
        }
        public EmpHeaderInfo GetEmpName(int EmpId)
        {
            return new EmployeeDAL().GetEmpName(EmpId);
        }
        public List<PromotionHistory> GetPromotionBasedOnBPS(int EmpId, int FromBPS, int ToBPS)
        {
            return new EmployeeDAL().GetPromotionBasedOnBPS(EmpId,FromBPS,ToBPS);

        }
        public PromotionHistory GetCurrentPromotion(int EmpId)//GET_EMP_PROMOTION_HISTORY
        {
            return new EmployeeDAL().GetCurrentPromotion(EmpId);
        }
        public List<PromotionHistory> GetAppointmentBasedOnBPS(int EmpId, int FromBPS, int ToBPS)//GET_EMP_PROMOTION_HISTORY
        {
            return new EmployeeDAL().GetAppointmentBasedOnBPS(EmpId,FromBPS,ToBPS);
        }
        public PromotionHistory GetCurrentEmployment(int EmpId)//GET_EMP_PROMOTION_HISTORY
        {
            return new EmployeeDAL().GetCurrentEmployment(EmpId);
        }
        public List<PromotionHistory> GetPromotionHistory(int EmpId)
        {
            return new EmployeeDAL().GetPromotionHistory(EmpId);
        }
        public Probation GetEmployeeProbationStatus(int EmpId)
        {
            return new EmployeeDAL().GetEmployeeProbationStatus(EmpId);
        }
        public List<EmpPassports> GetPassports(int EmpId)
        {
            return new EmployeeDAL().GetPassports(EmpId);
        }
        public void DeleteEmployeePassport(int ef)
        {
            new EmployeeDAL().DeleteEmployeePassport(ef);

        }
        public void InsertEmployeePassport(EmpPassports ep)
        {
            new EmployeeDAL().InsertEmployeePassport(ep);
        }
        public void SaveEmployeePassport(EmpPassports ef)
        {
            new EmployeeDAL().SaveEmployeePassport(ef);
        }
        public void SaveEmployeeHistory(EmploymentHistory eh)
        {
            new EmployeeDAL().SaveEmployeeHistory(eh);
        }
        public void DeleteEmployementHistory(int EmpHistId)
        {
            new EmployeeDAL().DeleteEmployementHistory(EmpHistId);
        }
        public List<EmployeeLeave> GetEmployeeLeaves(int EmpId)
        {
            return new EmployeeDAL().GetEmployeeLeaves(EmpId);
        }
        public void InsertEmployeeLeave(EmployeeLeave el)
        {
            new EmployeeDAL().InsertEmployeeLeave(el);
        }
        public void DeleteEmployeeLeave(int el)
        {
            new EmployeeDAL().DeleteEmployeeLeave(el);
        }
        public void DeleteEmployeeDepenedent(int el)
        {
            new EmployeeDAL().DeleteEmployeeDependent(el);
        }
        public List<EmpCourses> GetEmployeeCourses(int EmpId)
        {
            return new EmployeeDAL().GetEmployeeCourses(EmpId);
        }
        public void SaveEmpCourses(EmpCourses Ec)
        {
            new EmployeeDAL().SaveEmpCourses(Ec);
        }
        public void InsertEmployeeCourse(EmpCourses Ec)
        {
            new EmployeeDAL().InsertEmployeeCourse(Ec);
        }
        public void DeleteEmployeeCourse(int ec)
        {
            new EmployeeDAL().DeleteEmployeeCourse(ec);
        }
        public List<EmpQualification> GetEmployeeQualifications(int EmpId)
        {
            return new EmployeeDAL().GetEmployeeQualifications(EmpId);
        }
        public void InsertEmployeeQualification(EmpQualification Eq)
        {
            new EmployeeDAL().InsertEmployeeQualification(Eq);

        }
        public void DeleteEmployeeQualification(int ec)
        {
            new EmployeeDAL().DeleteEmployeeQualification(ec);

        }
        public void UpdateEmployeeQualification(EmpQualification Eq)
        {
            new EmployeeDAL().UpdateEmployeeQualification(Eq);
        }
        public void InsertEmployeeHistory(EmploymentHistory eh)
        {
            new EmployeeDAL().InsertEmployeeHistory(eh);
        }
        public void InsertEmployeePromotion(PromotionHistory eh)
        {
            new EmployeeDAL().InsertEmployeePromotion(eh);
        }
        public void UpdateEmpEmployment(EmpEmployment El)
        {
            new EmployeeDAL().UpdateEmpEmployment(El);

        }
        public void DeletePromotionHistory(int EmpHistId)
        {
            new EmployeeDAL().DeletePromotionHistory(EmpHistId);
        }
        public void UpdateEmployeePromotion(PromotionHistory eh)
        {
            new EmployeeDAL().UpdateEmployeePromotion(eh);
        }
        public string GetImage(int EmpId)
        {
            return new EmployeeDAL().GetImage(EmpId);
        }
        public void SaveImage(string ImgUrl, int EmpId)
        {
            new EmployeeDAL().SaveImage(ImgUrl, EmpId);
        }
        public List<EmployeeDependant> GetEmployeeDependants(int EmpId)
        {
            return new EmployeeDAL().GetEmployeeDependants(EmpId);


        }
        public void InsertEmployeeDependants(EmployeeDependant Edep)
        {
            new EmployeeDAL().InsertEmployeeDependants(Edep);
        }
        public void UpdateEmployeeDependants(EmployeeDependant EDep)
        {
            new EmployeeDAL().UpdateEmployeeDependants(EDep);
        }

        public void SaveEmpLeave(EmployeeLeave El)
        {
            new EmployeeDAL().SaveEmpLeave(El);
        }
        public List<EmployeeLeave> GetLeavesBetweenDates(DateTime StartDate, DateTime EndDate, int EmpId)
        {
            return new EmployeeDAL().GetLeavesBetweenDates(StartDate, EndDate, EmpId);
        }
        public List<EmployeePosting> GetEmployeePostings(int EmpId)
        {
            return new EmployeeDAL().GetEmployeePostings(EmpId);
        }
        public void UpdateEmployeePosting(EmployeePosting EPosting)
        {
            new EmployeeDAL().UpdateEmployeePosting(EPosting);
        }
        public int InsertEmployeePosting(EmployeePosting EPosting)
        {
            return new EmployeeDAL().InsertEmployeePosting(EPosting);
        }
        public void DeleteEmployeePosting(int PostingId)
        {
            new EmployeeDAL().DeleteEmployeePosting(PostingId);
        }
        public void InsertEmployeeVisits(EmployeeVisits EmpVisit)
        {
            new EmployeeDAL().InsertEmployeeVisits(EmpVisit);
        }
        public void UpdateEmployeeVisits(EmployeeVisits EmpVisit)
        {

            new EmployeeDAL().UpdateEmployeeVisits(EmpVisit);
        }
        public List<EmployeeVisits> GetEmployeeVisits(int EmpId)
        {
            return new EmployeeDAL().GetEmployeeVisits(EmpId);

        }
        public void DeleteEmployeeVisit(int VisitId)
        {
            new EmployeeDAL().DeleteEmployeeVisit(VisitId);

        }
        public void InsertEmployeeNOC(NOC noc)
        {

            new EmployeeDAL().InsertEmployeeNOC(noc);

        }
        public void UpdateEmployeeNOC(NOC noc)
        {

            new EmployeeDAL().UpdateEmployeeNOC(noc);

        }
        public List<NOC> GetEmployeeNOCs(int EmpId)
        {
            return new EmployeeDAL().GetEmployeeNOCs(EmpId);
        }
        public void DeleteEmployeeNOC(int NocId)
        {
            new EmployeeDAL().DeleteEmployeeNOC(NocId);

        }
        public EmpProfile GetOnePage(int empId)
        {
            return new EmployeeDAL().GetOnePage(empId);

        }
        public List<AnnualConfRep> GetACRS(int empId)
        {
            return new EmployeeDAL().GetAcrs(empId);
        }
        public List<ReportingOfficers> GetReportingOfficers()
        {
            return new EmployeeDAL().GetReportingOfficers();
        }
        public void InsertEmployeeAcrs(AnnualConfRep eh)
        {
            new EmployeeDAL().InsertAnnualConfRep(eh);
        }
        public void UpdateEmployeeAcrs(AnnualConfRep eh)
        {
            new EmployeeDAL().UpdateAnnualConfRep(eh);
        }
        public void DeleteEmployeeACR(int EmpAcrId)
        {
            new EmployeeDAL().DeleteEmployeeACR(EmpAcrId);
        }

        public double GetWorkingStatus(int SystemUserId)
        {
            return new EmployeeDAL().GetWorkingStatus(SystemUserId);
        }
        public double GetCurrentStatus(int SystemUserId)
        {
            return new EmployeeDAL().GetCurrentStatus(SystemUserId);
        }
        public List<PostingSummary> GetPostingSummary(int empId)
        {
            return new EmployeeDAL().GetPostingSummary(empId);
        }
        public List<ResoursePerson> GetResourse(int EmpId)
        {
            return new EmployeeDAL().GetResourse(EmpId);
        }

        public void InsertEmployeeRes(ResoursePerson ea)
        {
            new EmployeeDAL().InsertEmployeeRes(ea);
        }
        public void UpdateEmployeeRes(ResoursePerson ea)
        {
            new EmployeeDAL().UpdateEmployeeRes(ea);
            

        }
        public void DeleteResourse(int ResId)
        {
            new EmployeeDAL().DeleteResourse(ResId);

        }
        public List<EmpMedical> GetEmpMedical(int EmpId)
        {
            return new EmployeeDAL().GetEmpMedical(EmpId);
        }

        public void InsertEmpMedical(EmpMedical ea)
        {
            new EmployeeDAL().InsertEmpMedical(ea);

        }
        public void UpdateEmpMedical(EmpMedical ea)
        {
            new EmployeeDAL().UpdateEmpMedical(ea);

        }
        public void DeleteEmpMedical(int EmpMedicalId)
        {
            new EmployeeDAL().DeleteEmpMedical(EmpMedicalId);
        }

        public List<EmpAssets> GetEmpAsset(int EmpId)
        {
            return new EmployeeDAL().GetEmpAsset(EmpId);
        }

        public void InsertEmpAsset(EmpAssets ea)
        {
            new EmployeeDAL().InsertEmpAsset(ea);

        }
        public void UpdateEmpAsset(EmpAssets ea)
        {
            new EmployeeDAL().UpdateEmpAsset(ea);

        }
        public void DeleteEmpAsset(int EmpAssetId)
        {
            new EmployeeDAL().DeleteEmpAsset(EmpAssetId);
        }

        public EmpHeaderInfo GetEmpDesignation(int EmpId)
        {
            return new EmployeeDAL().GetEmpDesignation(EmpId);
        }
        public EmpHeaderInfo GetEmpEmplStatus(int EmpId)
        {
            return new EmployeeDAL().GetEmpEmplStatus(EmpId);
        }
        public EmpHeaderInfo GetEmpBranch(int EmpId)
        {
            return new EmployeeDAL().GetEmpBranch(EmpId);
        }

        #region OTHER DUTIES

        public List<EmpOtherDuty> GetEmpOtherDuties(int EmpId)
        {
            return new EmployeeDAL().GetEmpOtherDuties(EmpId);
        }

        public void InsertEmpOtherDuty(EmpOtherDuty ea)
        {
            new EmployeeDAL().InsertEmpOtherDuty(ea);

        }
        public void UpdateEmpOtherDuty(EmpOtherDuty ea)
        {

            new EmployeeDAL().UpdateEmpOtherDuty(ea);

        }
        public void DeleteEmpOtherDuty(int EmpOtherDutyId)
        {
            new EmployeeDAL().DeleteEmpOtherDuty(EmpOtherDutyId);
        }
        #endregion OTHER DUTIES
        public List<EmployeeLeave> GetLeaveInSameYear(int EmpId, DateTime StartDate, DateTime EndDate)
        {
            return new EmployeeDAL().GetLeaveInSameYear(EmpId, StartDate, EndDate);
        }
        public List<EmployeeLeave> GetLeaveInDifferentYear(int EmpId, DateTime StartDate, DateTime EndDate)
        {
            return new EmployeeDAL().GetLeaveInDifferentYear(EmpId, StartDate, EndDate);
        }
        public List<EmployeeLeave> GetAllLeaves(int EmpId)
        {
            return new EmployeeDAL().GetAllLeaves(EmpId);
        }
        public List<EmployeeLeave> GetLeavesStatusBetweenDates(int EmpId,DateTime StartDate,DateTime EndDate)
        {
            return new EmployeeDAL().GetLeavesStatusBetweenDates(EmpId,StartDate,EndDate);
        }
        public List<EmployeeLeave> GetLeavesTillDate(int EmpId, DateTime EndDate)
        {
            return new EmployeeDAL().GetLeavesTillDate(EmpId,EndDate);
        }
        public List<T_LEAVES> GetLeavesFromT()
        {
            return new EmployeeDAL().GetLeavesFromT();
        }
        public List<BasicInfo> GetEmployeeByName()
        {
            return new EmployeeDAL().GetEmployeeByName();
        }
        public BasicInfo GetEmployeeByName(string EmpName)
        {
            return new EmployeeDAL().GetEmployeeByName(EmpName);

        }
        public List<PersonalNumbers> GetPersonalNumbers(string query)
        {
            return new EmployeeDAL().GetPersonalNumbers(query);
        }

        public void UpdatePersonalNumbers(PersonalNumbers personalnumber)
        {
            new EmployeeDAL().UpdatePersonalNumbers(personalnumber);
        }
        #region EMAILS

        public List<UserEmails> GetEmployeeEmails(int empId)
        {
            return new EmployeeDAL().GetEmployeeEmails(empId);

        }
        public void UpdateEmployeeEmail(UserEmails ef)
        {
            new EmployeeDAL().UpdateEmployeeEmail(ef);

        }
        public void DeleteEmployeeEmail(int ef)
        {
            new EmployeeDAL().DeleteEmployeeEmail(ef);
        }
        public void InsertEmployeeEmail(UserEmails ef)
        {
            new EmployeeDAL().InsertEmployeeEmail(ef);

        }
        #endregion EMAILS
        public DateTime GetDOB(int EmpId)
        {
            return new EmployeeDAL().GetDOB(EmpId);
        } 
        public DateTime GetSuperannuationDate(int EmpId)
        {
            return new EmployeeDAL().GetSuperannuationDate(EmpId);
        }
        #region Leave Enchashment Opt
        public LeaveEnchashmentOptEnt GetLeaveEncashmentOpted(int year, int systemusersid)
        {
            return new EmployeeDAL().GetLeaveEncashmentOpted(year, systemusersid);
        }
        public void DeleteLeaveEncashmentOpt(int year,int SystemUserId)
        {
            new EmployeeDAL().DeleteLeaveEncashmentOpt(year,SystemUserId);
        }
        public void InsertLeaveEncashmentOpt(int year, int systemuserid, int noofdays)
        {
            new EmployeeDAL().InsertLeaveEncashmentOpt(year, systemuserid,noofdays);
        }
        #endregion Leave Encashment Opt
        #region ADDITIONAL_BRANCHES
        public List<AdditionalBranchesEnt> GetAdditionalBranches(int PostingId)
        {
            return new EmployeeDAL().GetAdditionalBranches(PostingId);
        }
        public void InsertAdditionalBranch(AdditionalBranchesEnt ea)
        {
            new EmployeeDAL().InsertAdditionalBranch(ea);

        }
        public void UpdateBranchesInMainEmployment(string AdditionalBranches, int SystemUsersId)
        {
            new EmployeeDAL().UpdateBranchesInMainEmployment(AdditionalBranches, SystemUsersId);
        }
        public void DeleteAdditionalBranches(int EmpPostingId)
        {
            new EmployeeDAL().DeleteAdditionalBranches(EmpPostingId);
        }
        #endregion ADDITIONAL_BRANCHES

        #region CorrectionS
        public List<Correction> GetEmployeeCorrections(int SystemUsersId)
        {
            return new EmployeeDAL().GetEmployeeCorrections(SystemUsersId);
        }
        public List<Correction> GetEmployeeSolvedCorrections(int SystemUsersId)
        {
            return new EmployeeDAL().GetEmployeeSolvedCorrections(SystemUsersId);
        }
        public List<Correction> GetEmployeeUnSolvedCorrections(int SystemUsersId)
        {
            return new EmployeeDAL().GetEmployeeUnSolvedCorrections(SystemUsersId);
        }
        public List<Correction> GetSolvedCorrections()
        {
            return new EmployeeDAL().GetSolvedCorrections();
        }
        public List<Correction> GetUnSolvedCorrections()
        {
            return new EmployeeDAL().GetUnSolvedCorrections();
        }
        public void InsertCorrection(Correction Correction)
        {
            new EmployeeDAL().InsertCorrection(Correction);
        }
        public void UpdateCorrection(Correction Correction)
        {
            new EmployeeDAL().UpdateCorrection(Correction);

        }
        public void DeleteCorrection(int CorrectionId)
        {
            new EmployeeDAL().DeleteCorrection(CorrectionId);

        }
        public void SolveCorrection(int CorrectionId)
        {
            new EmployeeDAL().SolveCorrection(CorrectionId);

        }
        #endregion ADDITIONAL_BRANCHES

        #region BENEVOLENT FUND
        public List<EmpBenevolentFunds> GetEmpBenevolentFunds(int EmployeeId)
        {
            return new EmployeeDAL().GetEmpBenevolentFunds(EmployeeId);
        }
        public void InsertEmpBenevolentFund(EmpBenevolentFunds ea)
        {
            new EmployeeDAL().InsertEmpBenevolentFund(ea);
        }
        public void UpdateEmpBenevolentFund(EmpBenevolentFunds ea)
        {
            new EmployeeDAL().UpdateEmpBenevolentFund(ea);
        }
        public void DeleteEmpBenevolentFund(int Id)
        {
            new EmployeeDAL().DeleteEmpBenevolentFund(Id);
        }
        #endregion 

        }

}
