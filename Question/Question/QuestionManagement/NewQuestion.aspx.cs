using Entities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class NewQuestion1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCombos();
                int AssemblySessionId = Convert.ToInt32(SessionDDL.SelectedItem.Value);
                BindGroupsDDL(AssemblySessionId);
            }
        }
        public void BindCombos()
        {

            List<AssemblySessions> ASessions = new QuestionBiz().GetAssemblySessions();
            foreach (AssemblySessions row in ASessions)
            {
                ListItem li = new ListItem();
                li.Text = row.SessionNumber.ToString();
                li.Value = row.AssemblySessionsId.ToString();
                SessionDDL.Items.Add(li);
            }
            List<QuestionCategories> QCats = new QuestionBiz().GetQuestionCategories();
            foreach (QuestionCategories row in QCats)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.QuestionCategoriesId.ToString();
                CategoryDDL.Items.Add(li);
            }

            List<QuestionStatuses> QStatuses = new AdministrationBiz().GetQuestionStatus();
            foreach (QuestionStatuses row in QStatuses)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.QuestionStatusesId.ToString();
                QuestionStatusDDL.Items.Add(li);
            }
            QuestionStatusDDL.SelectedValue = "7";

        }

        protected void SessionDDL_SelectedIndexChanged1(object sender, EventArgs e)
        {
            int AssemblySessionId = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            BindGroupsDDL(AssemblySessionId);
        }
        public void BindGroupsDDL(int AssemblySessionId)
        {
            GroupDDL.Items.Clear();
            DivisionDDL.Items.Clear();
            DivisionDDL.Items.Add(new ListItem("Select", "0"));
            GroupDDL.Items.Add(new ListItem("Select", "0"));
            List<Groups> gps = new QuestionBiz().GetSessionGroups(AssemblySessionId);
            if (gps != null)
            {

                foreach (Groups obj in gps)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.GroupsId.ToString();
                    li.Text = obj.Description;
                    GroupDDL.Items.Add(li);
                }
            }

        }
        

        protected void Button1_Click(object sender, EventArgs e)
        {
            Questions question = new Questions();
            question.NoticeDiaryNo = Convert.ToInt32(NoticeDiaryNoTxt.Text);
            question.NoticeDiaryDate = Convert.ToDateTime(NoticeDiaryDateTxt.Text);
            question.NoticeDiaryTime = Convert.ToDateTime(NoticeDiaryTimeTxt.Text);
            question.SessionNumberId = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            question.QuestionDiaryNo = Convert.ToInt32(QuestionDiaryNoTxt.Text);
            question.QuestionDiaryDate = Convert.ToDateTime(QuestionDiaryDateTxt.Text);
            question.QuestionStatusId = Convert.ToInt32(QuestionStatusDDL.SelectedItem.Value);
            question.Mover = Convert.ToInt32(SenatorDDL.SelectedItem.Value);
            question.QuestionCategoriesId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
            question.MinistryGroupId = Convert.ToInt32(GroupDDL.SelectedItem.Value);
            question.DivisionId = Convert.ToInt32(DivisionDDL.SelectedItem.Value);
            question.Subject = Convert.ToString(SubjectMatterTxt.Text);
            question.QuestionText = Convert.ToString(QuestionTxt.Text);
            new QuestionBiz().InsertQuestions(question);


        }

        protected void GroupDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            DivisionDDL.Items.Clear();
            DivisionDDL.Items.Add(new ListItem("Select", "0"));
            int GroupId = Convert.ToInt32(GroupDDL.SelectedItem.Value);
            List<Divisions> divs = new List<Divisions>();
            divs = new AdministrationBiz().GetDivisions(GroupId);
            if(divs!=null)
            {
                
                foreach (Divisions div in divs)
                {
                    ListItem temp = new ListItem();
                    temp.Value = div.DivisionsId.ToString();
                    temp.Text = div.Description;
                    DivisionDDL.Items.Add(temp);
                }
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

        }
    }
    }