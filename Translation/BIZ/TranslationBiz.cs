using DAL;
using Entities;
using System.Collections.Generic;

namespace BIZ
{
    public class TranslationBiz
    {
        #region Assembly Session
        public int GetCurrentAssemblySessions()
        {
            return new TranslationDal().GetCurrentAssemblySessions();
        }
        public AssemblySessions GetCurrentAssemblySessionDetails()
        {
            return new TranslationDal().GetCurrentAssemblySessionDetails();
        }
        #endregion
        #region Question


        public int SaveQuestionTranslation(int QuestionId, string TranslatedText)
        {
            return new TranslationDal().SaveQuestionTranslation(QuestionId, TranslatedText);
        }
        public int FinalizeQuestionTranslation(int QuestionId, string TranslatedText)
        {
            return new TranslationDal().FinalizeQuestionTranslation(QuestionId, TranslatedText);
        }
        public int SubmitQuestionTranslationByUser(int QuestionId, string TranslatedText)
        {
            return new TranslationDal().SubmitQuestionTranslationByUser(QuestionId, TranslatedText);
        }
        public Questions GetQuestionByIdMin(int QuestionId)
        {
            return new TranslationDal().GetQuestionByIdMin(QuestionId);
        }

        public List<Questions> GetTranslationQuestions()
        {
            return new TranslationDal().GetTranslationQuestions();
        }
        public List<Questions> GetSentQuestionsToUsers()
        {
            return new TranslationDal().GetSentQuestionsToUsers();
        }
        public List<Questions> GetSentQuestionsToUser(int UserId)
        {
            return new TranslationDal().GetSentQuestionsToUser(UserId);
        }
        public List<Questions> GetTranslatedQuestionsByUsers()
        {
            return new TranslationDal().GetTranslatedQuestionsByUsers();
        }
        public List<Questions> GetTranslatedQuestions(int AssemblySessionsId)
        {
            return new TranslationDal().GetTranslatedQuestions(AssemblySessionsId);
        }
        public void SendQuestionForTranslation(int QuestionId)
        {
            new TranslationDal().SendQuestionForTranslation(QuestionId);
        }
        #endregion

        #region Motion
        public Motion GetMotion(int MotionId)
        {
            return new TranslationDal().GetMotion(MotionId);
        }
        public int SaveMotionTranslation(int MotionId, string TranslatedText)
        {
            return new TranslationDal().SaveMotionTranslation(MotionId, TranslatedText);
        }
        public int FinalizeMotionTranslation(int MotionId, string TranslatedText)
        {
            return new TranslationDal().FinalizeMotionTranslation(MotionId, TranslatedText);
        }

        public List<Motion> GetTranslationMotions(int AssemblySessionsId)
        {
            return new TranslationDal().GetTranslationMotions(AssemblySessionsId);
        }
        public List<Motion> GetTranslatedMotions(int AssemblySessionsId)
        {
            return new TranslationDal().GetTranslatedMotions(AssemblySessionsId);
        }
        public void SendMotionForTranslation(int MotionId)
        {
            new TranslationDal().SendMotionForTranslation(MotionId);
        }
        #endregion

        #region Resolution
        public Resolution GetResolution(int ResolutionId)
        {
            return new TranslationDal().GetResolution(ResolutionId);
        }
        public int SaveResolutionTranslation(int ResolutionId, string TranslatedText)
        {
            return new TranslationDal().SaveResolutionTranslation(ResolutionId, TranslatedText);
        }
        public int FinalizeResolutionTranslation(int ResolutionId, string TranslatedText)
        {
            return new TranslationDal().FinalizeResolutionTranslation(ResolutionId, TranslatedText);
        }

        public List<Resolution> GetTranslationResolutions(int AssemblySessionsId)
        {
            return new TranslationDal().GetTranslationResolutions(AssemblySessionsId);
        }
        public List<Resolution> GetTranslatedResolutions(int AssemblySessionsId)
        {
            return new TranslationDal().GetTranslatedResolutions(AssemblySessionsId);
        }
        public void SendResolutionForTranslation(int ResolutionId)
        {
            new TranslationDal().SendResolutionForTranslation(ResolutionId);
        }
        #endregion
        #region User Questions

        public void AssignQuestionForTranslation(int UserId, List<string> Questions)
        {
            new TranslationDal().AssignQuestionForTranslation(UserId, Questions);
        }
        public List<Questions> GetTranslationQuestionsByUser(int userid)
        {
            return new TranslationDal().GetTranslationQuestionsByUser( userid);

        }
        public List<Questions> GetTranslatedQuestionsByUser(int userid)
        {
            return new TranslationDal().GetTranslatedQuestionsByUser(userid);

        }
        #endregion
    }
}
