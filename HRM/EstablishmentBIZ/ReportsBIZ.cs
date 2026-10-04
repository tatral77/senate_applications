using EstablishmentDAL;
using EstablishmentENT;
using EstablishmentENT.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;

namespace EstablishmentBIZ
{
    public class ReportsBIZ
    {
        public List<EmpSearchList> EmployeeContact(string query)
        {
            return new ReportsDAL().EmployeeContact(query);
        }
        public List<ReportEntity> Get_Superanuation(string query)
        {
            return new ReportsDAL().Get_Superanuation(query);
        }
        public List<ReportEntity> Get_17_Deputation(string query)
        {
            List <ReportEntity> temp= new ReportsDAL().Get_17_Deputation(query);
            foreach(ReportEntity rpt in temp)
            {
                if(rpt.Extensions!=null)
                {
                    foreach(ExtensionDetails ed in rpt.Extensions)
                    {
                        rpt.ExtensionDetails += "<b>Extended to:</b> " + ed.ExtendedTo.ToShortDateString() + "<br><b>Remarks :</b> " + ed.Remarks  + "<br>";
                    }
                    
                }
            }
            return temp;
            
        }
        public List<ReportEntity> Get_03_Probation(string query)
        {
            return new ReportsDAL().Get_03_Probation(query);
        }
        public List<Probation> Get_All_Probations(int EmpId)
        {
            return new ReportsDAL().Get_All_Probations(EmpId);
        }
        
        public List<ReportEntity> Get_05_Designation(string query)
        {
            return new ReportsDAL().Get_05_Designation(query);
        }
        public List<ReportEntity> Get_08_Extension(string query)
        {
            return new ReportsDAL().Get_08_Extension(query);
        }
        public List<RptEmployeesOnLeave> GetEmployeesOnLeave(string query)
        {
            return new ReportsDAL().GetEmployeesOnLeave(query);
        }
        public List<RptEmployeesTraining> GetEmployeesTraining(string query)
        {
            List<RptEmployeesTraining> EmpList = new ReportsDAL().GetEmployeesTraining(query);
            foreach (RptEmployeesTraining et in EmpList)
            {
                EmpProfile ep = new EmpProfile();
                ep = new EmployeeHandler().GetOnePage(et.EmpId);
                et.DateOfBirth = ep.Dob;
                Duration duration = new DateTimeUtils().GetDuration(ep.Dob, DateTime.Now);
                et.Age = duration.Years;
                et.AgeMonths = duration.Months;
                et.GovtJoiningDate = ep.GovtServiceStartDate;
                duration = new DateTimeUtils().GetDuration(ep.GovtServiceStartDate, DateTime.Now);
                et.ServiceYears = duration.Years;
                et.ServiceMonths = duration.Months;
                PromotionHistory promotion = new EmployeeHandler().GetCurrentPromotion(et.EmpId);
                if (promotion == null)
                    promotion = new EmployeeHandler().GetCurrentEmployment(et.EmpId);
                if (promotion != null)
                {
                    et.DateOfPromotion = promotion.PromotionDate;
                    duration = new DateTimeUtils().GetDuration(et.DateOfPromotion, DateTime.Now);
                    et.PromotionYears = duration.Years;
                    et.PromotionMonths = duration.Months;
                }
            }
            return EmpList;
        }
        public List<RptEmployeeEducation> GetEmployeesEducation(string query)
        {
            return new ReportsDAL().GetEmployeesEducation(query);
        }
        public List<Rpt_Lien> RptGetEmploymentOut(string query)
        {
            return new ReportsDAL().RptGetEmploymentOut(query);
        }
        public List<Rpt_OtherDuties> RptGetOtherDuties(string query)
        {
            return new ReportsDAL().RptGetOtherDuties(query);
        }
        public List<RptOtherCharges> RptGetOtherCharges(string query)
        {
            return new ReportsDAL().RptGetOtherCharges(query);
        }
        public List<Rpt_Promotion> GetPromotionHistory(string query)//GET_EMP_PROMOTION_HISTORY
        {
            return new ReportsDAL().GetPromotionHistory(query);
        }
        public List<Rpt_NOC> RptGetNOC(string query)
        {
            return new ReportsDAL().RptGetNOC(query);
        }
        public string GetEmpHighestQualification(int SystemUsersId)
        {
            return new ReportsDAL().GetEmpHighestQualification(SystemUsersId);
        }
        public List<RptCurrentPosting> GetCurrentPostings(string query)
        {
            return new ReportsDAL().GetCurrentPostings(query);
        }
        public List<EmpSearchList> EmployyesBranch(string query)
        {
            return new ReportsDAL().EmployyesBranch(query);
        }
        public List<PopSuperannuation> GetPopSuperannuation()
        {
            return new ReportsDAL().GetPopSuperannuation();
        }
        public List<PopProbation> GetPopProbation()
        {
            return new ReportsDAL().GetPopProbation();
        }
        public List<PopEmployment> GetPopEmployment()
        {
            return new ReportsDAL().GetPopEmployment();
        }
        public List<EmpSearchList> SearchEmploymentsMade(string query)
        {
            return new ReportsDAL().SearchEmploymentsMade(query);
        }
        public List<EmpSearchList> PromotionReport(string query)
        {
            return new ReportsDAL().PromotionReport(query);
        }
        public int Get2017Leaves(int SystemUsersId)
        {
            return new ReportsDAL().Get2017Leaves(SystemUsersId);
        }
        }
    }
