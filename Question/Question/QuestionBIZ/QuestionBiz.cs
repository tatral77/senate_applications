using Entities;
using QuestionDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionBIZ
{
    public class QuestionBiz
    {
        #region  QUESTION_CATEGORY

        public List<QuestionCategories> GetQuestionCategories()
        {
            return new QuestionDal().GetQuestionCategories();
        }
        public void UpdateQuestionCategory(QuestionCategories Temp)
        {
            new QuestionDal().UpdateQuestionCategory(Temp);
        }
        public void InsertQuestionCategory(QuestionCategories Temp)
        {
            new QuestionDal().InsertQuestionCategory(Temp);
        }
        #endregion QUESTION_CATEGORY

        //------------------------------------END----------------------------------------//

        //#region  Ministries
        //public List<Ministries> GetMinistries()
        //{
        //    return new QuestionDal().GetMinistries();
        //}
        //public void UpdateMinistries(Ministries Temp)
        //{
        //    new QuestionDal().UpdateMinistries(Temp);
        //}
        //public void InsertMinistries(Ministries Temp)
        //{
        //    new QuestionDal().InsertMinistries(Temp);
        //}

        //#endregion Ministries
        //------------------------------------END-------------------------------------//

        #region  GroupDivisions

        public List<GroupDivisions> GetGroupDivisions(int AssemblySessionId)
        {
            return new QuestionDal().GetGroupDivisions(AssemblySessionId);
        }
        
        //public void UpdateGroupDivision(GroupDivisions Temp)
        //{
        //    new QuestionDal().UpdateGroupDivision(Temp);
        //}
        public void InsertGroupDivisions(GroupDivisions Temp)
        {
            new QuestionDal().InsertGroupDivisions(Temp);
        }
        public void DeleteGroupDivisions(int GroupsId,int DivisionsId)
        {
            new QuestionDal().DeleteGroupDivisions(GroupsId,DivisionsId);
        }

        #endregion Divisions

            //------------------------------------END-------------------------------------//

            #region  Groups

        public List<Groups> GetSessionGroups(int AssemblySessionsId)
        {
            return new QuestionDal().GetSessionGroups(AssemblySessionsId);
        }
        public void UpdateGroups(Groups Temp)
        {
            new QuestionDal().UpdateGroups(Temp);
        }
        public void InsertGroups(Groups Temp)
        {
            new QuestionDal().InsertGroups(Temp);
        }
        public List<Groups> GetSessionCorrespondingGroup(int AssemplySessionsId, int CorrespondingGroupId)
        {
            return new QuestionDal().GetSessionCorrespondingGroup(AssemplySessionsId, CorrespondingGroupId);
        }

        #endregion Groups

            //------------------------------------END-------------------------------------//

            #region  ParliamentaryPeriods

        public List<ParliamentaryPeriods> GetParliamentaryPeriods()
        {
            return new QuestionDal().GetParliamentaryPeriods();
        }
        public void UpdateParliamentaryPeriods(ParliamentaryPeriods Temp)
        {
            new QuestionDal().UpdateParliamentaryPeriods(Temp);
        }
        public void InsertParliamentaryPeriods(ParliamentaryPeriods Temp)
        {
            new QuestionDal().InsertParliamentaryPeriods(Temp);
        }

        #endregion ParliamentaryPeriods

        //------------------------------------END-------------------------------------//

        #region Assemblies
        public List<Assemblies> GetAssemblies()
        {
            return new QuestionDal().GetAssemblies();
        }
        public void UpdateAssemblies(Assemblies Temp)
        {
            new QuestionDal().UpdateAssemblies(Temp);
        }
        public void InsertAssemblies(Assemblies Temp)
        {
            new QuestionDal().InsertAssemblies(Temp);
        }

        #endregion Assemblies

        //------------------------------------END-------------------------------------//

        #region SittingTypes

        public List<SittingTypes> GetSittingTypes()
        {
            return new QuestionDal().GetSittingTypes();
        }
        public void UpdateSittingTypes(SittingTypes Temp)
        {
            new QuestionDal().UpdateSittingTypes(Temp);
        }
        public void InsertSittingTypes(SittingTypes Temp)
        {
            new QuestionDal().InsertSittingTypes(Temp);
        }

        #endregion SittingTypes

        //------------------------------------END-------------------------------------//

        #region SessionSittings

        public List<SessionSittings> GetSessionSitting()
        {
            return new QuestionDal().GetSessionSitting();
        }
        public void UpdateSessionSittings(SessionSittings Temp)
        {
            new QuestionDal().UpdateSessionSittings(Temp);
        }
        public void InsertSessionSittings(SessionSittings Temp)
        {
            new QuestionDal().InsertSessionSittings(Temp);
        }

        #endregion SessionSitting

        //------------------------------------END-------------------------------------//

        #region AssemblySessions


        public List<AssemblySessions> GetAssemblySessions()
        {
            return new QuestionDal().GetAssemblySessions();
        }
        public void UpdateAssemblySessions(AssemblySessions Temp)
        {
            new QuestionDal().UpdateAssemblySessions(Temp);
        }
        public void InsertAssemblySessions(AssemblySessions Temp)
        {
            new QuestionDal().InsertAssemblySessions(Temp);
        }
        public int GetCurrentAssemblySessions()
        {
            return new QuestionDal().GetCurrentAssemblySessions();
        }

        #endregion AssemblySessions
            //------------------------------------END-------------------------------------//

            #region Questions

        public List<Questions> GetQuestions(int AssemblySessionsId)
        {
            return new QuestionDal().GetQuestions(AssemblySessionsId);


        }
        public Questions GetQuestionById(int QuestionId)
        {
            return new QuestionDal().GetQuestionById(QuestionId);
        }
        public void UpdateQuestions(Questions Temp)
        {
            new QuestionDal().UpdateQuestions(Temp);
        }

        public void InsertQuestions(Questions Temp)
        {
            new QuestionDal().InsertQuestions(Temp);
        }

        #endregion Questions
    }
}
