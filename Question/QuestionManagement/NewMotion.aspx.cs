using Entities;
//using MODI;
using MotionBIZ;
using MotionEntities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class MotionManagement : System.Web.UI.Page
    {
        List<MotionMoversEnt> motionmovers = null;
        [WebMethod]
        public static List<string> GetEmployeeName(string empName)
        {
            List<string> empResult = new List<string>();
            List<Member> mems = new QuestionBiz().GetMembersByName(empName);
            foreach (Member a in mems)
            {
                empResult.Add(a.MemberName);
            }
            return empResult;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCombos();
                AssemblySessions ASession = new AdministrationBiz().GetCurrentAssemblySessionDetails();
                SessionTxt.Text = ASession.SessionNumber.ToString();
                HidSessionNumber.Value = ASession.AssemblySessionsId.ToString();

            }
        }
        protected void BindCombos()
        {
            List<MotionTypeEnt> motiontypes = new AdministrationBiz().GetMotionTypes();
            foreach (MotionTypeEnt row in motiontypes)
            {
                ListItem li = new ListItem();
                li.Text = row.Description.ToString();
                li.Value = row.MotionTypeId.ToString();
                MotionTypeDDL.Items.Add(li);
            }

        }
        protected void AddNewBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NewMotion.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            MotionEnt motion = new MotionEnt();
            motion.SessionNumber = Convert.ToInt32(HidSessionNumber.Value);
            motion.NoticeDiaryNo = Convert.ToInt32(NoticeDiaryNoTxt.Text);
            motion.NoticeDiaryDate = Convert.ToDateTime(NoticeDiaryDateTxt.Text);
            motion.NoticeDiaryTime = Convert.ToDateTime(NoticeDiaryTimeTxt.Text);
            motion.MotionDiaryNo = Convert.ToInt32(MotionDiaryNoTxt.Text);
            motion.MotionTypeId = Convert.ToInt32(MotionTypeDDL.SelectedItem.Value);
            motion.MotionStatusId = 5;
            motion.Description = Convert.ToString(MotionTxt.Value);
            motion.Movers = new List<MotionMoversEnt>();
            foreach (ListItem listItem in MoversLB.Items)
            {
                MotionMoversEnt mover = new MotionMoversEnt();
                mover.MotionMoversId = Convert.ToInt32(listItem.Value);
                motion.Movers.Add(mover);
            }
            motion.IsUrdu = UrduCB.Checked == true ? 1 : 0;
            int id = new MotionBiz().InsertMotion(motion, motionmovers);
            Response.Redirect("~/MotionDetail.aspx?MotionId=" + id);

        }
        protected void PrintBtn_Click(object sender, EventArgs e)
        {
            // int id=InsertQuestion();
            // Response.Redirect("~/PrintQuestion.aspx?questionsId=" + id);

        }

        protected void AddMover_Click(object sender, EventArgs e)
        {
            int found = 0;
            int moverid = Convert.ToInt32(HidMemberId.Value);
            if (!String.IsNullOrEmpty(HidMemberId.Value))
            {

                foreach (ListItem listItem in MoversLB.Items)
                {
                    if (Convert.ToInt32(listItem.Value) == moverid)
                        found = 1;
                }
            }
            if (found == 0)
            {
                string movername = new QuestionBiz().GetMemberNameById(moverid);
                ListItem Temp = new ListItem();
                Temp.Value = Convert.ToString(moverid);
                Temp.Text = Convert.ToString(movername);
                MoversLB.Items.Add(Temp);
                HidMemberId.Value = "";
                MemberNameTxt.Text = "";
                err.Text = "";
            }
            else
                err.Text = "Mover already exist";

        }
        protected void DeleteMover_Click(object sender, EventArgs e)
        {
            List<ListItem> itemsToRemove = new List<ListItem>();

            foreach (ListItem listItem in MoversLB.Items)
            {
                if (listItem.Selected)
                    itemsToRemove.Add(listItem);
            }

            foreach (ListItem listItem in itemsToRemove)
            {
                MoversLB.Items.Remove(listItem);
            }

        }
        protected void Upload(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string filePath = Server.MapPath("~/Uploads/" + Path.GetFileName(FileUpload1.PostedFile.FileName));
                FileUpload1.SaveAs(filePath);
                string extractText = this.ExtractTextFromImage(filePath);
                MotionTxt.Value += extractText.Replace(Environment.NewLine, "<p>");
            }
        }

        private string ExtractTextFromImage(string filePath)
        {
            //Document modiDocument = new Document();
            //modiDocument.Create(filePath);
            //modiDocument.OCR(MiLANGUAGES.miLANG_ENGLISH);
            //MODI.Image modiImage = (modiDocument.Images[0] as MODI.Image);
            //string extractedText = modiImage.Layout.Text;
            //modiDocument.Close();
            //return extractedText;
            return "abc";
        }

    }
}