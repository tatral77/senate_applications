using DAL;
using Entities;
using System.Collections.Generic;

namespace BIZ
{
    public class QuestionBiz
    {
        #region Questions
        public int GetQuestionPk()
        {
            return new QuestionDal().GetQuestionPk();
        }
        public List<Questions> GetQuestions(int AssemblySessionsId)
        {
            return new QuestionDal().GetQuestions(AssemblySessionsId);
        }
        public List<Questions> SearchQuestions(int AssemblySessionsId)
        {
            return new QuestionDal().SearchQuestions(AssemblySessionsId);
        }

        public List<Questions> GetQuestionsByStatus(int AssemblySessionsId, int StatusId)
        {
            return new QuestionDal().GetQuestionsByStatus(AssemblySessionsId, StatusId);
        }
        public Questions GetQuestionById(int QuestionId)
        {
            return new QuestionDal().GetQuestionById(QuestionId);
        }
        public Questions GetQuestionByIdFromQuestion(int QuestionId)
        {
            return new QuestionDal().GetQuestionByIdFromQuestion(QuestionId);
        }
            public Questions GetQuestionByIdMin(int QuestionId)
        {
            return new QuestionDal().GetQuestionByIdMin(QuestionId);
        }
        public void UpdateQuestions(Questions Temp)
        {
            new QuestionDal().UpdateQuestions(Temp);
        }
        public int InsertQuestions(Questions Temp)
        {
            return new QuestionDal().InsertQuestions(Temp);
        }
        public void InsertQuestionFile(string file, int QuestionId)
        {
            new QuestionDal().InsertQuestionFile(file, QuestionId);
        }
        public List<Questions> SearchQuestion(string query)
        {
            return new QuestionDal().SearchQuestion(query);
        }
        #endregion Questions
        public void DeleteQuestion(int QuestionId)
        {
            new QuestionDal().DeleteQuestion(QuestionId);
        }
        public List<QuestionStatusHistory> GetQuestionStatusHistory(int QuestionIdentifier)
        {
            return new QuestionDal().GetQuestionStatusHistory(QuestionIdentifier);

        }
        public List<QuestionMovementHistory> GetQuestionMovementHistory(int QuestionIdentifier)
        {
            return new QuestionDal().GetQuestionMovementHistory(QuestionIdentifier);
        }
        public string GetMemberNameById(int MemberId)
        {
            return new AdministrationDAL().GetMemberNameById(MemberId);
        }

        public void LapseQuestion(int AssemblySessionsId)
        {
            new QuestionDal().LapseQuestion(AssemblySessionsId);
        }
        public void LapseMotion(int AssemblySessionsId)
        {
            new QuestionDal().LapseMotion(AssemblySessionsId);
        }

        public void LapseResolution(int AssemblySessionsId)
        {
            new QuestionDal().LapseResolution(AssemblySessionsId);
        }
        public List<DeferQuestion> GetQuestionDeferment(int QuestionIdentifier)
        {
            return new QuestionDal().GetQuestionDeferment(QuestionIdentifier);
        }
        public List<Member> GetMembersByStatus(int StatusId)
        {
            return new QuestionDal().GetMembersByStatus(StatusId);
        }
        public List<Member> GetMembersByName(string MemberName)
        {
            return new QuestionDal().GetMemberByName(MemberName);
        }
        public List<Member> GetSeatMembersByName(string MemberName)
        {
            return new QuestionDal().GetSeatMemberByName(MemberName);
        }
    }
}
