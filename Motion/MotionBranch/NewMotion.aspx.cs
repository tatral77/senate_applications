using Entities;
//using MODI;
using MotionBIZ;
using MotionEntities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MotionBranch
{
    public partial class NewMotion : System.Web.UI.Page
    {
        List<MotionMoversEnt> motionmovers = null;
        [WebMethod]
        public static List<string> GetEmployeeName(string empName)
        {
            List<string> empResult = new List<string>();
            List<Member> mems = new AdministrationBiz().GetMembersByName(empName);
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
                AssemblySessions ASession = new MotionBiz().GetCurrentAssemblySessionDetails();
                ListItem li = new ListItem();
                li.Value = ASession.AssemblySessionsId.ToString();
                li.Text = ASession.SessionNumber.ToString();
                SessionsDDL.Items.Remove(li);
                SessionsDDL.SelectedValue = ASession.SessionNumber.ToString();
              

            }
        }
        protected void BindCombos()
        {
            List<AssemblySessions> AsSessions = new AdministrationBiz().GetAssemblySessions();
            foreach (AssemblySessions row in AsSessions)
            {
                ListItem li = new ListItem();
                li.Text = row.SessionNumber.ToString();
                li.Value = row.AssemblySessionsId.ToString();
                SessionsDDL.Items.Add(li);
            }
            List<MotionTypeEnt> motiontypes = new MotionBiz().GetMotionTypes();
            foreach (MotionTypeEnt row in motiontypes)
            {
                ListItem li = new ListItem();
                li.Text = row.Description.ToString();
                li.Value = row.MotionTypeId.ToString();
                MotionTypeDDL.Items.Add(li);
            }
            List<MotionWeek> motionweeks = new MotionBiz().GetMotionWeeks();
            foreach (MotionWeek row in motionweeks)
            {
                ListItem li = new ListItem();
                li.Text = row.WeekName.ToString();
                li.Value = row.WeekId.ToString();
                MotionWeekCB.Items.Add(li);
            }
            List<MotionStatusEnt> motionstatus = new MotionBiz().GetMotionStatuses();
            foreach (MotionStatusEnt row in motionstatus)
            {
                ListItem li = new ListItem();
                li.Text = row.Description.ToString();
                li.Value = row.MotionStatusId.ToString();
                MotionStatusDDL.Items.Add(li);
            }
            MotionStatusDDL.SelectedValue = "5";

        }
        protected void AddNewBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NewMotion.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            MotionEnt motion = new MotionEnt();
            motion.SessionNumber = Convert.ToInt32(SessionsDDL.SelectedValue);
            motion.FileNo = Convert.ToString(FileNoTxt.Text);
            motion.WeekId= Convert.ToInt32(MotionWeekCB.SelectedItem.Value);
            motion.NoticeDiaryNo = Convert.ToInt32(NoticeDiaryNoTxt.Text);
            motion.NoticeDiaryDate = Convert.ToDateTime(NoticeDiaryDateTxt.Text);
            DateTime noticedate = Convert.ToDateTime(NoticeDiaryDateTxt.Text);
            String datetime = NoticeDiaryDateTxt.Text + " " + NoticeDiaryTimeTxt.Text;
            //DateTime noticetime = DateTime.ParseExact(datetime,
            //                      "dd.MM.yyyy HH:mm",
            //                      CultureInfo.InvariantCulture);
            string str = NoticeDiaryDateTxt.Text + " " + NoticeDiaryTimeTxt.Text;  // assumed date and time are textboxes
            DateTime dt = new DateTime();
            DateTime.TryParse(str, out (dt)); // returns datetime in dt if it is valid
            motion.NoticeDiaryTime = dt;
           // motion.MotionDiaryNo = Convert.ToString(MotionDiaryNoTxt.Text);
            motion.MotionTypeId = Convert.ToInt32(MotionTypeDDL.SelectedItem.Value);
            motion.MotionStatusId = Convert.ToInt32(MotionStatusDDL.SelectedItem.Value);
            motion.Description = Convert.ToString(MotionTxt.Value);
            motion.Movers = new List<MotionMoversEnt>();
            motion.MotionMinistries = new List<MotionMinistriesEnt>();
            foreach (ListItem listItem in MoversLB.Items)
            {
                MotionMoversEnt mover = new MotionMoversEnt();
                mover.MotionMoversId = Convert.ToInt32(listItem.Value);
                motion.Movers.Add(mover);
            }
            foreach (ListItem listItem in MinistryLB.Items)
            {
                MotionMinistriesEnt motionministries = new MotionMinistriesEnt();
                motionministries.MinistryId = Convert.ToInt32(listItem.Value);
                motion.MotionMinistries.Add(motionministries);
            }
            motion.Processed = 1;
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
                string movername = new MotionBiz().GetMemberNameById(moverid);
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

        protected void AddMinistry_Click(object sender, EventArgs e)
        {
            int found = 0;
            int ministryid = Convert.ToInt32(HidMinistryId.Value);
            if (!String.IsNullOrEmpty(HidMinistryId.Value))
            {

                foreach (ListItem listItem in MinistryLB.Items)
                {
                    if (Convert.ToInt32(listItem.Value) == ministryid)
                        found = 1;
                }
            }
            if (found == 0)
            {
                string ministryname = new MotionBiz().GetMinistryNameById(ministryid);
                ListItem Temp = new ListItem();
                Temp.Value = Convert.ToString(ministryid);
                Temp.Text = Convert.ToString(ministryname);
                MinistryLB.Items.Add(Temp);
                HidMinistryId.Value = "";
                MinistryTxt.Text = "";
                err2.Text = "";
            }
            else
                err2.Text = "Ministry already exist";

        }
        protected void DeleteMinistry_Click(object sender, EventArgs e)
        {
            List<ListItem> itemsToRemove = new List<ListItem>();

            foreach (ListItem listItem in MinistryLB.Items)
            {
                if (listItem.Selected)
                    itemsToRemove.Add(listItem);
            }

            foreach (ListItem listItem in itemsToRemove)
            {
                MinistryLB.Items.Remove(listItem);
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