using BIZ;
using Entities;
using ManBIZ;
using ManEntities;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Translation
{
    public partial class ManageUserQuestions : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<User> users = new ManBiz().GetApplicationUsersByRole(13, "Translator");
                if (users != null)
                {
                   
                    AssignedQuestionsUsersDDL.Items.Add(new ListItem
                    {
                        Value = "0",
                        Text = "Assigned User"
                    });
                    TranslatedQuestionsUsersDDL.Items.Add(new ListItem
                    {
                        Value = "0",
                        Text = "Translated By"
                    });
                    AssignQuestionsUsersDDL.Items.Add(new ListItem
                    {
                        Value = "0",
                        Text = "Assign To User"
                    });
                    foreach (User usr in users)
                    {
                        AssignedQuestionsUsersDDL.Items.Add(new ListItem
                        {
                            Value = usr.UserId.ToString(),
                            Text = usr.FullName
                        });
                        AssignQuestionsUsersDDL.Items.Add(new ListItem
                        {
                            Value = usr.UserId.ToString(),
                            Text = usr.FullName
                        });
                        TranslatedQuestionsUsersDDL.Items.Add(new ListItem
                        {
                            Value = usr.UserId.ToString(),
                            Text = usr.FullName
                        });
                    }
                }
                bindListView();

            }
        }

        private void bindListView()
        {
            List<Questions> AssignedQuestions = null;
            List<Questions> TranslatedQuestions = null;

            AssignedQuestions = new TranslationBiz().GetSentQuestionsToUsers();
            if (AssignedQuestions != null)
            {
                AssignedToUsersLV.DataSource = AssignedQuestions;
                AssignedToUsersLV.DataBind();
            }

            TranslatedQuestions = new TranslationBiz().GetTranslatedQuestionsByUsers();
            TranslatedByUsersLV.DataSource = TranslatedQuestions;
            TranslatedByUsersLV.DataBind();



        }
        public string GetMinText(string txt)
        {
            string text = Regex.Replace(txt, "<[^>]*>| &nbsp;", "").Trim();
            if (txt.Length >= 350)
                text = txt.Substring(0, 350).Trim() + ".................";
            else
                text = txt;
            return text;

        }
       
        protected void ReAssign_Click(object sender, EventArgs e)
        {
            int userid = Convert.ToInt32(AssignQuestionsUsersDDL.SelectedValue);
            int ischecked = 0;
            List<string> questions = new List<string>();
            foreach (ListViewItem li in AssignedToUsersLV.Items)
            {
                CheckBox cb = (CheckBox)li.FindControl("SelectCB");

                if (cb.Checked)
                {
                    ischecked = 1;
                    HiddenField questionid = (HiddenField)li.FindControl("HidQuestionId");
                    questions.Add(questionid.Value);
                }
            }

            //search();
            if (ischecked == 1)
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Questions Satus updated Successfully')", true);
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Question')", true);
            if (questions.Count > 0 && ischecked == 1)
            {
                new TranslationBiz().AssignQuestionForTranslation(userid, questions);
            }
            bindListView();
        }

        public string GetTime(DateTime time)
        {
            return time.ToShortTimeString();
        }
        public string GetDate(DateTime date)
        {
            if (date < Convert.ToDateTime("01/01/1900"))
                return "";
            else
                return date.ToString();

        }

        protected void TranslatedQuestionsUsersDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int UserId = Convert.ToInt32(TranslatedQuestionsUsersDDL.SelectedValue);
            List<Questions> questions = new TranslationBiz().GetTranslatedQuestionsByUser(UserId);
            TranslatedByUsersLV.DataSource = questions;
            TranslatedByUsersLV.DataBind();
        }

        protected void AssignedQuestionsUsersDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int UserId = Convert.ToInt32(AssignedQuestionsUsersDDL.SelectedValue);
            List<Questions> questions = new TranslationBiz().GetSentQuestionsToUser(UserId);
            AssignedToUsersLV.DataSource = questions;
            AssignedToUsersLV.DataBind();
        }
    }
}