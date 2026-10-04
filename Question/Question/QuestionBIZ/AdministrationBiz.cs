using Entities;
using QuestionDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionBIZ
{
    public class AdministrationBiz
    {
        #region  Divisions
        public List<Divisions> GetDivisions()
        {
            return new AdministrationDAL().GetDivisions();
        }
        public List<Divisions> GetDivisions(int GroupId)
        {
            return new AdministrationDAL().GetDivisions(GroupId);
        }
        public void UpdateDivision(Divisions Temp)
        {
            new AdministrationDAL().UpdateDivision(Temp);
        }
        public void InsertDivisions(Divisions Temp)
        {
            new AdministrationDAL().InsertDivisions(Temp);
        }
        public List<Divisions> GetUnAssignedDivisions(int AssemblySessionsId)
        {
            return new AdministrationDAL().GetUnAssignedDivisions(AssemblySessionsId);
        }

        #endregion Divisions
            #region  Ministries
        public List<Ministries> GetMinistries()
        {
            return new AdministrationDAL().GetMinistries();
        }
        public void UpdateMinistries(Ministries Temp)
        {
            new AdministrationDAL().UpdateMinistries(Temp);
        }
        public void InsertMinistries(Ministries Temp)
        {
            new AdministrationDAL().InsertMinistries(Temp);
           
        }

        #endregion Ministries
        #region Question_Status

        public List<QuestionStatuses> GetQuestionStatus()
        {
            return new AdministrationDAL().GetQuestionStatus();
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

        public void UpdateParliamentaryYears(ParliamentaryYears Temp)
        {
            new AdministrationDAL().UpdateParliamentaryYears(Temp);
        }
        public void InsertParliamentaryYears(ParliamentaryYears Temp)
        {
            new AdministrationDAL().InsertParliamentaryYears(Temp);
        }

        #endregion Parliamentary_Years


    }
}
