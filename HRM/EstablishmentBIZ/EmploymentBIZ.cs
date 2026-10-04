using EstablishmentDAL;
using EstablishmentENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentBIZ
{
    public class EmploymentBIZ
    {
        public List<EmpHistory> GetRegEmployment(int SystemUserId)
        {
            return new EmploymentDAL().GetRegEmployment(SystemUserId);
        }
        public void InsertRegularEmployment(RegularEmployee eh)
        {
            new EmploymentDAL().InsertRegularEmployment(eh);
        }
      
        public void UpdateEmpEmployment(RegularEmployee eh)
        {
            new EmploymentDAL().UpdateEmpEmployment(eh);
        }
        public int GetServingStatus(int SystemUserId, int EmpHistoryId)
        {
            return new EmploymentDAL().GetServingStatus(SystemUserId, EmpHistoryId);
        }
        public void DeleteRegularEmployment(int EmploymentHistId)
        {
            new EmploymentDAL().DeleteRegularEmployment(EmploymentHistId);
        }

        //public List<ContractEmployee> GetContracts(int SystemUserId)
        //{
        //    return new EmploymentDAL().GetContracts(SystemUserId);
        //}
        public List<Probation> GetEmployeeProbations(int Empid)
        {
            return new EmploymentDAL().GetEmployeeProbations(Empid);
        }
        public List<Probation> GetPromotionProbations(int Empid)
        {
            return new EmploymentDAL().GetPromotionProbations(Empid);
        }
        public void InsertProbation(Probation prob)
        {
            new EmploymentDAL().InsertProbation(prob);
        }
        public void UpdateProbation(Probation prob)
        {
            new EmploymentDAL().UpdateProbation(prob);
        }
        public void DeleteProbation(int ProbId,int EmpId)
        {
            new EmploymentDAL().DeleteProbation(ProbId,EmpId);
        }
        //public void InsertContract(ContractEmployee contract)
        //{
        //    new EmploymentDAL().InsertContract(contract);
        //}
        //public void DeleteContract(int ContractId)
        //{
        //    new EmploymentDAL().DeleteContract(ContractId);
        //}
        //public void UpdateContract(ContractEmployee contract)
        //{
        //    new EmploymentDAL().UpdateContract(contract);
        //}

        public void UpdatePromProbation(Probation prob)
        {
            new EmploymentDAL().UpdatePromProbation(prob);
        }
        public void InsertPromProbation(Probation prob)
        {
            new EmploymentDAL().InsertPromProbation(prob);
        }


        #region EMPLOYMENT
        public void UpdateRegEmployment(RegularEmployee eh)
        {
            new EmploymentDAL().UpdateRegEmployment(eh);

        }
        public void UpdatePostingEmployment(int EmpId, int BranchId)
        {
            new EmploymentDAL().UpdatePostingEmployment(EmpId, BranchId);
        }
        public void InsertOtherEmployment(EmpHistory eh)
        {
            new EmploymentDAL().InsertOtherEmployment(eh);
        }
        public void UpdateOtherEmployment(EmpHistory eh)
        {
            new EmploymentDAL().UpdateOtherEmployment(eh);
        }
        public List<EmpHistory> GetEmpHistory(int SystemUserId)
        {
            return new EmploymentDAL().GetEmpHistory(SystemUserId);
        }
        #endregion EMPLOYMENT
        
        public void InsertEmploymentOut(EmploymentOut EmplOut)
        {
            new EmploymentDAL().InsertEmploymentOut(EmplOut);
        }

        public void UpdateEmploymentOut(EmploymentOut EmplOut)
        {
            new EmploymentDAL().UpdateEmploymentOut(EmplOut);
        }
        public List<EmploymentOut> GetEmploymentOut(int SystemUserId)
        {
            return new EmploymentDAL().GetEmploymentOut(SystemUserId);
        }
        public void DeleteEmploymentOut(int EmplOutId)
        {
            new EmploymentDAL().DeleteEmploymentOut(EmplOutId);
        }
        public void InsertExtensionDetails(ExtensionDetails EmplOut)
        {
            new EmploymentDAL().InsertExtensionDetails(EmplOut);
        }
        public void UpdateExtensionDetails(ExtensionDetails EmplOut)
        {
            new EmploymentDAL().UpdateExtensionDetails(EmplOut);
        }

        public List<ExtensionDetails> GetExtensionDetails(int SystemUserId)
        {
            return new EmploymentDAL().GetExtensionDetails(SystemUserId);
        }
        public void DeleteExtensionDetails(int ExtensionId)
        {
            new EmploymentDAL().DeleteExtensionDetails(ExtensionId);
        }
        public void InsertPrevEmployments(PrevEmployments EmplOut)
        {
            new EmploymentDAL().InsertPrevEmployments(EmplOut);
        }
        public void UpdatePrevEmployments(PrevEmployments EmplOut)
        {
            new EmploymentDAL().UpdatePrevEmployments(EmplOut);
        }
        public List<PrevEmployments> GetPrevEmployments(int SystemUserId)
        {
            return new EmploymentDAL().GetPrevEmployments(SystemUserId);
        }
        public void DeletePrevEmployments(int EmplOutId)
        {
            new EmploymentDAL().DeletePrevEmployments(EmplOutId);
        }
        public List<OtherCharges> GetOtherCharges(int EmpId)
        {
            return new EmploymentDAL().GetOtherCharges(EmpId);
        }
        public void UpdateOtherCharges(OtherCharges EmpCharge)
        {
            new EmploymentDAL().UpdateOtherCharges(EmpCharge);    
        }
        public void InsertOtherCharges(OtherCharges EmpCharge)
        {
            new EmploymentDAL().InsertOtherCharges(EmpCharge);
        }
        public void DeleteOtherCharges(int PostingId)
        {
            new EmploymentDAL().DeleteOtherCharges(PostingId);
        }

        public List<SecurityClearance> GetSecurityClearance(int EmpId)
        {

            return new EmploymentDAL().GetSecurityClearance(EmpId);

        }



        public void UpdateSecurityClearance(SecurityClearance EmpSecClearance)
        {

            new EmploymentDAL().UpdateSecurityClearance(EmpSecClearance);
        }
        public void InsertSecurityClearance(SecurityClearance EmpSecClearance)
        {

            new EmploymentDAL().InsertSecurityClearance(EmpSecClearance);
        }
        public void DeleteSecurityClearance(int SecClearanceId)
        {
            new EmploymentDAL().DeleteSecurityClearance(SecClearanceId);
        }
        public List<DisciplinaryAction> GetDisciplinaryAction(int EmpId)
        {
            return new EmploymentDAL().GetDisciplinaryAction(EmpId);
        }
        public void UpdateDisciplinaryAction(DisciplinaryAction EmpDiscipAction)
        {
            new EmploymentDAL().UpdateDisciplinaryAction(EmpDiscipAction);
        }
        public void InsertDisciplinaryAction(DisciplinaryAction EmpDiscipAction)
        {
            new EmploymentDAL().InsertDisciplinaryAction(EmpDiscipAction);
        }
        public void DeleteDisciplinaryAction(int DiscipActionId)
        {
            new EmploymentDAL().DeleteDisciplinaryAction(DiscipActionId);
        }

        public List<EmpRetirement> GetEmpRetirement(int EmpId)
        {
            return new EmploymentDAL().GetEmpRetirement(EmpId);
        }
        public void UpdateEmpRetirement(EmpRetirement ERetirement)
        {
            new EmploymentDAL().UpdateEmpRetirement(ERetirement);
        }
        public void InsertEmpRetirement(EmpRetirement ERetirement)
        {
            new EmploymentDAL().InsertEmpRetirement(ERetirement);
        }
        public void DeleteEmpRetirement(int RetirementId)
        {
            new EmploymentDAL().DeleteEmpRetirement(RetirementId);
        }
        public void DeleteOtherEmployment(int Id)
        {
            new EmploymentDAL().DeleteOtherEmployment(Id);
        }
        public List<DisciplinaryAction> GetEmpSuspension(int EmpId)
        {
            return new EmploymentDAL().GetEmpSuspension(EmpId);
        }
        public void UpdateEmpSuspension(DisciplinaryAction EmpDiscipAction)
        {
            new EmploymentDAL().UpdateEmpSuspension(EmpDiscipAction);
        }
        public void InsertEmpSuspension(DisciplinaryAction EmpDiscipAction)
        {
            new EmploymentDAL().InsertEmpSuspension(EmpDiscipAction);
        }
        public void DeleteEmpSuspension(int DiscipActionId)
        {
            new EmploymentDAL().DeleteEmpSuspension(DiscipActionId);
        }
        public List<DisciplinaryAction> GetSuspensionDetails(int EmpId,DateTime FromDate, DateTime ToDate)
        {
            return new EmploymentDAL().GetSuspensionDetails(EmpId,FromDate,ToDate);
        }
        public List<DisciplinaryAction> GetEmpSuspensions(int EmpId)
        {
            return new EmploymentDAL().GetEmpSuspensions(EmpId);
        }
        public void InsertPersonalNumber(int EmpId,double personalnumber)
        {
            new EmploymentDAL().InsertPersonalNumber(EmpId,personalnumber);
        }
        public List<EmpPenalty> GetEmpPenalties(int EmpId)
        {
            return new EmploymentDAL().GetEmpPenalties(EmpId);

        }
        public void UpdateEmpPenalties(EmpPenalty EmpDiscipAction)
        {
            new EmploymentDAL().UpdateEmpPenalties(EmpDiscipAction);
        }
        public void InsertEmpPenalties(EmpPenalty EmpDiscipAction)
        {
            new EmploymentDAL().InsertEmpPenalties(EmpDiscipAction);
        }
        public void DeleteEmpPenalties(int EmpPenaltyId)
        {
            new EmploymentDAL().DeleteEmpPenalties(EmpPenaltyId);

        }
        public void UpdateEmploymentStatus(int EmployeeId)
        {
            new EmploymentDAL().UpdateEmploymentStatus(EmployeeId);
        }
        public DateTime GetServiceEndDate(int EmpId)
        {
            return new EmploymentDAL().GetServiceEndDate(EmpId);
        }
        public EmpHistory GetCurrentEmployment(int SystemUserId)
        {
            return new EmploymentDAL().GetCurrentEmployment(SystemUserId);
        }
        }
}
