using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MotionBIZ;
using MotionEntities;

namespace MotionBranch
{
    public partial class TranslatedMotionDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int MotionId = Convert.ToInt32(Request.QueryString["MotionId"]);
                //   PrintHL.NavigateUrl = "~/PrintQuestion.aspx?questionsId=" + QuestionId;
                Bind();
            }


        }
        public void Bind()
        {
            int MotionId = Convert.ToInt32(Request.QueryString["MotionId"]);
            MotionEnt motionEnt = new MotionBiz().GetMotion(MotionId);
            if (motionEnt != null)
            {
                QuestionIdLbl.Text = "Motion ID: " + motionEnt.MotionsId;
                QTxt.Value = motionEnt.Description;
                UrduTxt.Value = motionEnt.UrduText;
                string file = motionEnt.MotionFile;
                if (!string.IsNullOrEmpty(file))
                {
                    HyperLink1.NavigateUrl = file;
                    HyperLink1.Text = "View File";
                }
                else
                {
                    HyperLink1.Text = "No File attached";
                }
            }
            // PrintHL.NavigateUrl = "~/PrintQuestion.aspx?questionsId=" + QuestionId;

        }

        protected void ApprovedBtn_Click(object sender, EventArgs e)
        {
            int MotionId = Convert.ToInt32(Request.QueryString["MotionId"]);
            new MotionBiz().ApproveTranslation(MotionId);
            Response.Redirect("~/MotionDetail.aspx?MotionId=" + MotionId);

        }
        protected void TranslateBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(UrduTxt.Value))
            {
                int MotionId = Convert.ToInt32(Request.QueryString["MotionId"]);
                new MotionBiz().SendForTranslation(MotionId);
                UrduLbl.Visible = false;
                SuccessLbl.InnerText = "Motion sent for translation";
                SuccessLbl.Visible = true;
            }
            else
            {
                UrduLbl.Text = "No text found for translation";
                UrduLbl.Visible = true;
            }
        }
    }
}