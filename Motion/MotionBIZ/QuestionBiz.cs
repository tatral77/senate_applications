using Entities;
using MotionDAL;
using MotionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionBIZ
{
    public class QuestionBiz
    {
        public List<Member> GetAllMemberByName(string MemberName)
        {
            return new QuestionDal().GetAllMemberByName(MemberName);
        }
        public List<Question> GetQuestions(int AssemblySessionsId)
        {
            return new QuestionDal().GetQuestions(AssemblySessionsId);


        }
        public List<Question> SearchQuestion(string query)
        {
            return new QuestionDal().SearchQuestion(query);
        }

        public List<Groups> GetSessionGroups(int AssemblySessionsId, int CategoryId)
        {
            return new QuestionDal().GetSessionGroups(AssemblySessionsId, CategoryId);
        }
        public Groups GetGroupById(int GroupId)
        {
            return new QuestionDal().GetGroupById(GroupId);
        }
        public Question GetQuestionById(int QuestionId)
        {
            return new QuestionDal().GetQuestionById(QuestionId);
        }

    }
}
