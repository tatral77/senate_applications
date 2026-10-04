using MotionEntities;
using MotionBIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;

namespace MotionBranch
{
    public partial class MotionDetail : System.Web.UI.Page
    {
       
        [WebMethod]
        //public static List<string> GetEmployeeName(string empName)
        //{
        //    List<string> empResult = new List<string>();
        //    List<Member> mems = new AdministrationBiz().GetMembersByName(empName);
        //    foreach (Member a in mems)
        //    {
        //        empResult.Add(a.MemberName);
        //    }
        //    return empResult;
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCombos();
                BindFields();
               

            }
        }
        protected void BindCombos()
        {
            List<MotionTypeEnt> motiontypes = new MotionBiz().GetMotionTypes();
            foreach (MotionTypeEnt row in motiontypes)
            {
                ListItem li = new ListItem();
                li.Text = row.Description.ToString();
                li.Value = row.MotionTypeId.ToString();
                MotionTypeDDL.Items.Add(li);
            }
            List<MotionStatusEnt> motionstatus = new MotionBiz().GetMotionStatuses();
            foreach (MotionStatusEnt row in motionstatus)
            {
                ListItem li = new ListItem();
                li.Text = row.Description.ToString();
                li.Value = row.MotionStatusId.ToString();
                MotionStatusDDL.Items.Add(li);
            }
            List<MotionWeek> motionweek = new MotionBiz().GetMotionWeeks();
            foreach (MotionWeek row in motionweek)
            {
                ListItem li = new ListItem();
                li.Text = row.WeekName.ToString();
                li.Value = row.WeekId.ToString();
                MotionWeekCB.Items.Add(li);
            }
            List<AssemblySessions> AsSessions = new AdministrationBiz().GetAssemblySessions();
            foreach (AssemblySessions row in AsSessions)
            {
                ListItem li = new ListItem();
                li.Text = row.SessionNumber.ToString();
                li.Value = row.AssemblySessionsId.ToString();
                SessionsDDL.Items.Add(li);
            }
          


        }
        protected int  SaveMotion()
        {
            MotionEnt motion = new MotionEnt();
            int MotionId = Convert.ToInt32(Request.QueryString["MotionId"]);
            motion.MotionsId = MotionId;
            motion.SessionNumber = Convert.ToInt32(SessionsDDL.SelectedValue);
            motion.NoticeDiaryNo = Convert.ToInt32(NoticeDiaryNoTxt.Text);
            motion.NoticeDiaryDate = Convert.ToDateTime(NoticeDiaryDateTxt.Text);
            motion.FileNo = Convert.ToString(FileNoTxt.Text);
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
            motion.WeekId = Convert.ToInt32(MotionWeekCB.SelectedItem.Value);
            motion.MotionStatusId = Convert.ToInt32(MotionStatusDDL.SelectedItem.Value);
            if (!String.IsNullOrEmpty(HouseMovingDateTxt.Text))
                motion.MovingHouseDate = Convert.ToDateTime(HouseMovingDateTxt.Text);
            if (!String.IsNullOrEmpty(DiscussionDateTxt.Text))
                motion.DiscussionDate = Convert.ToDateTime(DiscussionDateTxt.Text);
            if (!String.IsNullOrEmpty(RefferingDateTxt.Text))
                motion.RefferedScDate = Convert.ToDateTime(RefferingDateTxt.Text);
            motion.Description = Convert.ToString(MotionTxt.Value);
            motion.NoteDescription = Convert.ToString(NoteTxt.Value);
            if(!string.IsNullOrEmpty(HidMotionFile.Value))
            motion.MotionFile = Convert.ToString(HidMotionFile.Value);
            new MotionBiz().UpdateMotion(motion);
            if (!HidMotionStatusId.Value.Equals(MotionStatusDDL.SelectedItem.Value))
            {
                MotionStatusHistory motionStatusHistory = new MotionStatusHistory();
                motionStatusHistory.MotionId = MotionId;
                motionStatusHistory.StatusDate = DateTime.Now;
                motionStatusHistory.MotionStatusId = Convert.ToInt32(MotionStatusDDL.SelectedItem.Value);
                motionStatusHistory.AssemblySessionId = Convert.ToInt32(SessionsDDL.SelectedValue);
                new MotionBiz().InsertMotionStatusHistory(motionStatusHistory);
            }
            return MotionId;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int MotionId=SaveMotion();
            Response.Redirect("~/MotionDetail.aspx?MotionId=" + MotionId);

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
            int MotionId = Convert.ToInt32(Request.QueryString["MotionId"]);
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
                MotionMoversEnt motionmover = new MotionMoversEnt();
                motionmover.MotionId = MotionId;
                motionmover.MotionMoversId = moverid;
                new MotionBiz().InsertMotionMover(motionmover);
        
            }
            else
                err.Text = "Mover already exist";

        }
        public void BindStatusHistory(int MotionId)
        {
            List<MotionStatusHistory> sh = new List<MotionStatusHistory>();
            sh = new MotionBiz().GetMotionStatusHistory(MotionId);
            LVStatus.DataSource = sh;
            LVStatus.DataBind();
        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();

        }
        protected void TranslateBtn_Click(object sender, EventArgs e)
        {
            int MotionId = SaveMotion();
            if (!string.IsNullOrEmpty(UrduTxt.Value))
            {
                new MotionBiz().SendForTranslation(MotionId);
                UrduLbl.Visible = false;
                Response.Redirect("MotionDetail.aspx?MotionId=" + MotionId);
            }
            else
            {
                UrduLbl.Text = "No text found for translation";
                UrduLbl.Visible = true;
            }
        }
        protected void DeleteMover_Click(object sender, EventArgs e)
        {
            List<ListItem> itemsToRemove = new List<ListItem>();
            int MotionId = Convert.ToInt32(Request.QueryString["MotionId"]);
            foreach (ListItem temp in MoversLB.Items)
            {
                if (temp.Selected)
                {                  
                    itemsToRemove.Add(temp);
                }
            }

            foreach (ListItem listItem in itemsToRemove)
            {
                new MotionBiz().DeleteMotionMover(MotionId, Convert.ToInt32(listItem.Value));
                MoversLB.Items.Remove(listItem);
            }

        }

        protected void AddMinistry_Click(object sender, EventArgs e)
        {
            int found = 0;
            int ministry = Convert.ToInt32(HidMinistryId.Value);
            int MotionId = Convert.ToInt32(Request.QueryString["MotionId"]);
            if (!String.IsNullOrEmpty(HidMinistryId.Value))
            {

                foreach (ListItem listItem in MinistryLB.Items)
                {
                    if (Convert.ToInt32(listItem.Value) == ministry)
                        found = 1;
                }
            }
            if (found == 0)
            {
                string ministryname = new MotionBiz().GetMinistryNameById(ministry);
                ListItem Temp = new ListItem();
                Temp.Value = Convert.ToString(ministry);
                Temp.Text = Convert.ToString(ministryname);
                MinistryLB.Items.Add(Temp);
                HidMinistryId.Value = "";
                MinistryTxt.Text = "";
                err2.Text = "";
                MotionMinistriesEnt motionministry = new MotionMinistriesEnt();
                motionministry.MotionId = MotionId;
                motionministry.MinistryId = ministry;
                new MotionBiz().InsertMotionMinistries(motionministry);

            }
            else
                err2.Text = "Ministry already exist";

        }
        protected void DeleteMinistry_Click(object sender, EventArgs e)
        {
            List<ListItem> itemsToRemove = new List<ListItem>();
            int MotionId = Convert.ToInt32(Request.QueryString["MotionId"]);
            foreach (ListItem temp in MinistryLB.Items)
            {
                if (temp.Selected)
                {
                    itemsToRemove.Add(temp);
                }
            }

            foreach (ListItem listItem in itemsToRemove)
            {
                new MotionBiz().DeleteMotionMinistry(MotionId, Convert.ToInt32(listItem.Value));
                MinistryLB.Items.Remove(listItem);
            }

        }
        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            int MotionId = Convert.ToInt32(Request.QueryString["MotionId"]);
            new MotionBiz().DeleteMotion(MotionId);
            Response.Redirect("~/SearchMotion.aspx");

        }
        protected void BindFields()
        {
            MotionEnt motion = new MotionEnt();
            int MotionId = Convert.ToInt32(Request.QueryString["MotionId"]);
            PrintHL.NavigateUrl = "~/PrintMotion.aspx?MotionId=" + MotionId ;
            //PrintNoteHL.NavigateUrl = "~/PrintMotionNote.aspx?MotionId=" + MotionId;
            motion = new MotionBiz().GetMotion(MotionId);
            if (motion != null)
            {
                MotionIDTxt.Text = Convert.ToString(motion.MotionsId);
                FileNoTxt.Text = Convert.ToString(motion.FileNo);
                SessionsDDL.SelectedValue = Convert.ToString(motion.SessionNumber);
                NoticeDiaryNoTxt.Text = Convert.ToString(motion.NoticeDiaryNo);
                NoticeDiaryDateTxt.Text = motion.NoticeDiaryDate.ToShortDateString();
                NoticeDiaryTimeTxt.Text = motion.NoticeDiaryTime.ToShortTimeString();
               // MotionDiaryNoTxt.Text = motion.MotionDiaryNo.ToString();
                MotionTypeDDL.SelectedValue = motion.MotionTypeId.ToString();
                MotionStatusDDL.SelectedValue = motion.MotionStatusId.ToString();
                HidMotionStatusId.Value = motion.MotionStatusId.ToString();
                MotionWeekCB.SelectedValue = motion.WeekId.ToString();
                HouseMovingDateTxt.Text = (motion.MovingHouseDate < Convert.ToDateTime("01/01/1900")) ? "" : motion.MovingHouseDate.ToShortDateString();
                DiscussionDateTxt.Text = (motion.DiscussionDate < Convert.ToDateTime("01/01/1900")) ? "" : motion.DiscussionDate.ToShortDateString();
                RefferingDateTxt.Text = (motion.RefferedScDate < Convert.ToDateTime("01/01/1900")) ? "" : motion.RefferedScDate.ToShortDateString();
                if (!string.IsNullOrEmpty(motion.Description))
                    MotionTxt.Value = motion.Description.ToString();
                if(!string.IsNullOrEmpty(motion.UrduText))
                    UrduTxt.Value = motion.UrduText;
                if (!string.IsNullOrEmpty(motion.NoteDescription))
                    NoteTxt.Value = motion.NoteDescription.ToString();
                string file = motion.MotionFile;
                if (!string.IsNullOrEmpty(file))
                {
                    HyperLink1.NavigateUrl = file;
                    HyperLink1.Text = "View File";
                    HidMotionFile.Value = file;
                }
                else
                {
                    HyperLink1.Text = "No File attached";
                }
                if (motion.Movers != null)
                {
                    foreach (MotionMoversEnt movers in motion.Movers)
                    {
                        ListItem li = new ListItem();
                        li.Text = movers.MoverName.ToString();
                        li.Value = movers.MotionMoversId.ToString();
                        MoversLB.Items.Add(li);
                    }
                }

                if (motion.MotionMinistries != null)
                {
                    foreach (MotionMinistriesEnt ministries in motion.MotionMinistries)
                    {
                        ListItem li = new ListItem();
                        li.Text = ministries.MinistryName.ToString();
                        li.Value = ministries.MinistryId.ToString();
                        MinistryLB.Items.Add(li);
                    }
                }
                BindDeferDDL(motion.SessionNumber);
                BindStatusHistory(MotionId);
                BindRevivalHistory(MotionId);

            }
        }
        public void BindRevivalHistory(int MotionsId)
        {
            List<RevivalHistory> sh = new List<RevivalHistory>();
            sh = new MotionBiz().GetMotionRevivalHistory(MotionsId);
            LVMovement.DataSource = sh;
            LVMovement.DataBind();
        }
        protected void BindDeferDDL(int AssemblySessionId)
        {
            //List<AssemblySessions> AsSessions = new AdministrationBiz().GetAssemblySessions();
            //foreach (AssemblySessions row in AsSessions)
            //{
            //    ListItem li = new ListItem();
            //    li.Text = row.SessionNumber.ToString();
            //    li.Value = row.AssemblySessionsId.ToString();
            //    if (Convert.ToInt32(li.Value) > AssemblySessionId)
            //    {
            //        DefferAssemblySessionDDL.Items.Add(li);
            //        MoveAssemblySessionDDL.Items.Add(li);
            //    }

            //}
        }

        protected void DeferMotionBtn_Click(object sender, EventArgs e)
        {
           
                //int fromsession = Convert.ToInt32(HidSessionNumber.Value);
                //int tosession = Convert.ToInt32(DefferAssemblySessionDDL.SelectedItem.Value);
                //string sessionname = DefferAssemblySessionDDL.SelectedItem.Text;
                //int checkdeferment = new QuestionBiz().CheckQuestionDeferment(Convert.ToInt32(QuestionIDTxt.Text), tosession);
                //if (checkdeferment == 1)
                //    Deferror.Text = "Question already deffered to this session";
                //else
                //{
                //    Deferror.Text = "";
                //    DeferQuestion dq = new DeferQuestion();
                //    dq.QuestionId = Convert.ToInt32(QuestionIDTxt.Text);
                //    dq.AssemblySessionId = tosession;
                //    dq.DeferDate = Convert.ToDateTime(DeferDateTxt.Text);
                //    dq.Remarks = "Deferd to " + sessionname + " on " + DeferDateTxt.Text;
                //    new QuestionBiz().DeferQuestions(dq);
                //    BindQuestionDeferment(dq.QuestionId);
                //}
                //Response.Redirect("QuestionDetails.aspx?QuestionsId=" + Convert.ToInt32(QuestionIDTxt.Text));

            
        }

        protected void MoveMotionBtn_Click(object sender, EventArgs e)
        {

        }

        protected void MoveAssemblySessionDDL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}