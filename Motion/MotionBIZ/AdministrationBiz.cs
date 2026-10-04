using Entities;
using MotionEntities;
using QuestionDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionBIZ
{
    public class AdministrationBiz
    {

        //#region  Divisions
        //public List<Divisions> GetDivisions()
        //{
        //    return new AdministrationDAL().GetDivisions();
        //}
        //public List<Divisions> GetDivisions(int GroupId)
        //{
        //    return new AdministrationDAL().GetDivisions(GroupId);
        //}
        //public void UpdateDivision(Divisions Temp)
        //{
        //    new AdministrationDAL().UpdateDivision(Temp);
        //}
        //public void InsertDivisions(Divisions Temp)
        //{
        //    new AdministrationDAL().InsertDivisions(Temp);
        //}
        //public List<Divisions> GetUnAssignedDivisions(int AssemblySessionsId)
        //{
        //    return new AdministrationDAL().GetUnAssignedDivisions(AssemblySessionsId);
        //}

        //#endregion Divisions
        //    #region  Ministries
        //public List<Ministries> GetMinistries()
        //{
        //    return new AdministrationDAL().GetMinistries();
        //}
        //public void UpdateMinistries(Ministries Temp)
        //{
        //    new AdministrationDAL().UpdateMinistries(Temp);
        //}
        //public void InsertMinistries(Ministries Temp)
        //{
        //    new AdministrationDAL().InsertMinistries(Temp);

        //}

        //#endregion Ministries
        #region Question_Status

        //public List<QuestionStatuses> GetQuestionStatus()
        //{
        //    return new AdministrationDAL().GetQuestionStatus();
        //}
        public List<QuestionStatuses> GetQuestionActiveStatus()
        {
            return new AdministrationDAL().GetQuestionActiveStatus();
        }

        public void UpdateQuestionStatuses(QuestionStatuses Temp)
        {
            new AdministrationDAL().UpdateQuestionStatuses(Temp);
        }
        public void InsertQuestionStatuses(QuestionStatuses Temp)
        {
            new AdministrationDAL().InsertQuestionStatuses(Temp);
        }



        #endregion Question_Status

        #region  QUESTION_CATEGORY

        public List<QuestionCategories> GetQuestionCategories()
        {
            return new AdministrationDAL().GetQuestionCategories();
        }
        public void UpdateQuestionCategory(QuestionCategories Temp)
        {
            new AdministrationDAL().UpdateQuestionCategory(Temp);
        }
        public void InsertQuestionCategory(QuestionCategories Temp)
        {
            new AdministrationDAL().InsertQuestionCategory(Temp);
        }
        #endregion QUESTION_CATEGORY
        //#region Parliamentary_Years

        //public List<ParliamentaryYears> GetParliamentaryYears()
        //{
        //    return new AdministrationDAL().GetParliamentaryYears();
        //}
        //public ParliamentaryYears GetCurrentParliamentaryYear()
        //{
        //    return new AdministrationDAL().GetCurrentParliamentaryYear();
        //}
        //public void UpdateParliamentaryYears(ParliamentaryYears Temp)
        //{
        //    new AdministrationDAL().UpdateParliamentaryYears(Temp);
        //}
        //public void InsertParliamentaryYears(ParliamentaryYears Temp)
        //{
        //    new AdministrationDAL().InsertParliamentaryYears(Temp);
        //}

        //#endregion Parliamentary_Years
        //#region Member
        ////public List<MemberStatuses> GetMemberStatuses()
        ////{
        ////    return new AdministrationDAL().GetMemberStatuses();
        ////}
        //public List<Member> GetMembersByStatus(int StatusId)
        //{
        //    return new AdministrationDAL().GetMembersByStatus(StatusId);
        //}
        public List<Member> GetMembersByName(string MemberName)
        {
            return new AdministrationDAL().GetMemberByName(MemberName);
        }
        //public List<NewMemberInfo> GetMemberBasicInfo()
        //{
        //    return new AdministrationDAL().GetMemberBasicInfo();
        //}
        //public int INSERT_NEW_MEMBER(NewMemberInfo EmpId)
        //{
        //    return new AdministrationDAL().INSERT_NEW_MEMBER(EmpId);
        //}
        //public void InsertMemberId(NewMemberInfo bi)
        //{
        //    new AdministrationDAL().InsertMemberId(bi);
        //}
        //public void UpdateMemberBasicInfo(NewMemberInfo bi)
        //{
        //    new AdministrationDAL().UpdateMemberBasicInfo(bi);
        //}
        //#endregion Member
        //public List<Divisions> GetDivisionsByName(string DivisionName)
        //{
        //    return new AdministrationDAL().GetDivisionsByName(DivisionName);
        //}
        //public List<Divisions> GetCurrentDivisionsByName(string DivisionName)
        //{
        //    return new AdministrationDAL().GetCurrentDivisionsByName(DivisionName);
        //}
        //public List<DivisionGroups> GetDivisionGroups(int AssemblySessionId, int DivisionId,int CategoryId)
        //{
        //    return new AdministrationDAL().GetDivisionGroups(AssemblySessionId, DivisionId);
        //}


        //#region Rota

        //public List<QuestionsRota> GetQuestionRotas()
        //{
        //    return new AdministrationDAL().GetQuestionRotas();
        //}

        //public QuestionsRota GetQuestionRota(int AssemblySessionsId)
        //{
        //    return new AdministrationDAL().GetQuestionRota(AssemblySessionsId);
        //}

        //public void UpdateQuestionRota(QuestionsRota Temp)
        //{
        //    new AdministrationDAL().UpdateQuestionRota(Temp);
        //}
        //public void InsertQuestionRota(QuestionsRota Temp)
        //{
        //    new AdministrationDAL().InsertQuestionRota(Temp);
        //}
        //public void DeleteQuestionRota(int RotaId)
        //{
        //    new AdministrationDAL().DeleteQuestionRota(RotaId);
        //}


        //#endregion Rota
        //public List<Assemblies> GetAssemblies()
        //{
        //    return new AdministrationDAL().GetAssemblies();
        //}

        //#region MEMBER STATUS
        //public List<MemberStatus> GetMemberStatuses()
        //{
        //    return new AdministrationDAL().GetMemberStatuses();
        //}
        //#endregion MEMBER STATUS

        //#region POLITICAL_PARTY
        //public List<PoliticalParty> GetPoliticalParties()
        //{
        //    return new AdministrationDAL().GetPoliticalParties();
        //}
        //#endregion POLITICAL_PARTY

        //#region ELECTION TYPES
        //public List<ElectionTypes> GetElectionTypes()
        //{
        //    return new AdministrationDAL().GetElectionTypes();
        //}
        //#endregion ELECTION_TYPES
        //#region GENDER
        //public List<Gender> GetGenders()
        //{
        //    return new AdministrationDAL().GetGenders();
        //}
        //#endregion
        //#region MARITAL STATUS
        //public List<MaritalStatus> GetMaritalStatuses()
        //{
        //    return new AdministrationDAL().GetMaritalStatuses();

        //}
        //#endregion
        //#region RELIGION
        //public List<Religion> GetReligions()
        //{
        //    return new AdministrationDAL().GetReligions();

        //}
        //#endregion RELIGION
        #region AssemblySessions
        public AssemblySessions GetAssemblySession(int AssemblySessionId)
        {
            return new AdministrationDAL().GetAssemblySession(AssemblySessionId);
        }
        public AssemblySessions GetCurrentAssemblySessionDetails()
        {
            return new AdministrationDAL().GetCurrentAssemblySessionDetails();
        }
        public List<AssemblySessions> GetAssemblySessions()
        {
            return new AdministrationDAL().GetAssemblySessions();
        }
        public void UpdateAssemblySessions(AssemblySessions Temp)
        {
            new AdministrationDAL().UpdateAssemblySessions(Temp);
        }
        public int InsertAssemblySessions(AssemblySessions Temp)
        {
            return new AdministrationDAL().InsertAssemblySessions(Temp);
        }
        public int GetCurrentAssemblySessions()
        {
            return new AdministrationDAL().GetCurrentAssemblySessions();
        }

        #endregion AssemblySessions
    }
}
