using DAL;
using Entities;
using LegisEntities;
using System.Collections.Generic;


namespace BIZ
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

        public List<QuestionStatuses> GetQuestionStatuses()
        {
            return new AdministrationDAL().GetQuestionStatuses();
        }
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

        #region Parliamentary_Years

        public List<ParliamentaryYears> GetParliamentaryYears()
        {
            return new AdministrationDAL().GetParliamentaryYears();
        }
        public ParliamentaryYears GetCurrentParliamentaryYear()
        {
            return new AdministrationDAL().GetCurrentParliamentaryYear();
        }
        public void UpdateParliamentaryYears(ParliamentaryYears Temp)
        {
            new AdministrationDAL().UpdateParliamentaryYears(Temp);
        }
        public void InsertParliamentaryYears(ParliamentaryYears Temp)
        {
            new AdministrationDAL().InsertParliamentaryYears(Temp);
        }

        #endregion Parliamentary_Years

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

        //------------------------------------END----------------------------------------//

        //#region  Ministries
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
        //------------------------------------END-------------------------------------//


        //#region  ParliamentaryTenures

        //public List<ParliamentaryTenures> GetParliamentaryTenuress()
        //{
        //    return new AdministrationDAL().GetParliamentaryTenures();
        //}
        //public void UpdateParliamentaryPeriods(ParliamentaryTenures Temp)
        //{
        //    new AdministrationDAL().UpdateParliamentaryTenures(Temp);
        //}
        //public void InsertParliamentaryTenure(ParliamentaryTenures Temp)
        //{
        //    new AdministrationDAL().InsertParliamentaryTenures(Temp);
        //}

        //#endregion ParliamentaryTerms


        //#region  ParliamentaryTenures

        //public List<ParliamentaryTerms> GetParliamentaryTerms()
        //{
        //    return new AdministrationDAL().GetParliamentaryTerms();
        //}
        //public void UpdateParliamentaryTerm(ParliamentaryTerms Temp)
        //{
        //    new AdministrationDAL().UpdateParliamentaryTerm(Temp);
        //}
        //public void InsertParliamentaryTerm(ParliamentaryTerms Temp)
        //{
        //    new AdministrationDAL().InsertParliamentaryTerm(Temp);
        //}

        //#endregion ParliamentaryTerms

        //------------------------------------END-------------------------------------//

        //#region Assemblies
        //public List<Assemblies> GetAssemblies()
        //{
        //    return new AdministrationDAL().GetAssemblies();
        //}
        //public void UpdateAssemblies(Assemblies Temp)
        //{
        //    new AdministrationDAL().UpdateAssemblies(Temp);
        //}
        //public void InsertAssemblies(Assemblies Temp)
        //{
        //    new AdministrationDAL().InsertAssemblies(Temp);
        //}

        //#endregion Assemblies

        //------------------------------------END-------------------------------------//

        #region SittingTypes

        public List<SittingTypes> GetSittingTypes()
        {
            return new AdministrationDAL().GetSittingTypes();
        }
        public void UpdateSittingTypes(SittingTypes Temp)
        {
            new AdministrationDAL().UpdateSittingTypes(Temp);
        }
        public void InsertSittingTypes(SittingTypes Temp)
        {
            new AdministrationDAL().InsertSittingTypes(Temp);
        }

        #endregion SittingTypes

        //------------------------------------END-------------------------------------//

        #region SessionSittings

        public List<SessionSittings> GetSessionSitting()
        {
            return new AdministrationDAL().GetSessionSitting();
        }
        public List<SessionSittings> GetSessionSittingBySession(int AssebmblySessionId)
        {
            return new AdministrationDAL().GetSessionSittingBySession(AssebmblySessionId);
        }

        public SessionSittings GetSessionSittingById(int SittingId)
        {
            return new AdministrationDAL().GetSessionSittingById(SittingId);
        }
        public void UpdateSessionSittings(SessionSittings Temp)
        {
            new AdministrationDAL().UpdateSessionSittings(Temp);
        }
        public void InsertSessionSittings(SessionSittings Temp)
        {
            new AdministrationDAL().InsertSessionSittings(Temp);
        }

        #endregion SessionSitting

        //------------------------------------END-------------------------------------//

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

        #region  MOTION_TYPES
        public List<MotionTypeEnt> GetMotionTypes(int IsForMotion)
        {
            return new AdministrationDAL().GetMotionTypes(IsForMotion);
        }
        public void UpdateMotionType(MotionTypeEnt Temp)
        {
            new AdministrationDAL().UpdateMotionType(Temp);
        }
        public void InsertMotionType(MotionTypeEnt Temp)
        {
            new AdministrationDAL().InsertMotionType(Temp);
        }
        #endregion MOTION_MOVERS

        #region  MOTION_STATUSES
        public List<MotionStatusEnt> GetMotionStatuses()
        {
            return new AdministrationDAL().GetMotionStatuses();
        }
        public void UpdateMotionStatus(MotionStatusEnt Temp)
        {
            new AdministrationDAL().UpdateMotionStatus(Temp);
        }
        public void InsertMotionStatus(MotionStatusEnt Temp)
        {
            new AdministrationDAL().InsertMotionStatus(Temp);
        }
        #endregion MOTION_STATUSES
        public List<MotionWeek> GetMotionWeeks()
        {
            return new AdministrationDAL().GetMotionWeeks();
        }
        public MotionWeek GetMotionWeek(int weekid)
        {
            return new AdministrationDAL().GetMotionWeek(weekid);
        }

        public List<MemberSeat> GetMemberSeats()
        {
            return new AdministrationDAL().GetMemberSeats();
        }
        public List<MemberSeat> GetMemberSeatsList()
        {
            return new AdministrationDAL().GetMemberSeatsList();
        }
        public void UpdateMemberSeat(MemberSeat memberSeats)
        {
            new AdministrationDAL().UpdateMemberSeat(memberSeats);
        }
        public void UpdateMemberSeats(List<MemberSeat> memberSeats)
        {
            new AdministrationDAL().UpdateMemberSeats(memberSeats);
        }
        public void UnAssignAllSeats(string UpdatedBy)
        {
            new AdministrationDAL().UnAssignAllSeats(UpdatedBy);
        }
        public void UnAssignAllColours(string UpdatedBy)
        {
            new AdministrationDAL().UnAssignAllColours(UpdatedBy);
        }
        public List<AttendanceStatuses> GetAttendanceStatuses()
        {
            return new AdministrationDAL().GetAttendanceStatuses();
        }


    }
}
