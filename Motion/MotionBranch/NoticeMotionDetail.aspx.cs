using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using MotionBIZ;
using MotionEntities;

namespace MotionBranch
{
    public partial class NoticeMotionDetail : System.Web.UI.Page
    {
        //[WebMethod]
        //public static List<string> GetEmployeeName(string empName)
        //{
        //    List<string> empResult = new List<string>();
        //    List<Member> mems = new QuestionBiz().GetMembersByName(empName);
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
            List<AssemblySessions> ASessions = new AdministrationBiz().GetAssemblySessions();
            foreach (AssemblySessions row in ASessions)
            {
                ListItem li = new ListItem();
                li.Text = row.SessionNumber.ToString();
                li.Value = row.AssemblySessionsId.ToString();
                SessionDDL.Items.Add(li);
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int MotionId = SaveMotion();
            Response.Redirect("~/MotionDetail.aspx?MotionId=" + MotionId);

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
        protected int SaveMotion()
        {
            MotionEnt motion = new MotionEnt();
            int NoticeId = Convert.ToInt32(Request.QueryString["MotionId"]);
            motion.MotionsId = NoticeId;
            motion.SessionNumber = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            motion.NoticeDiaryNo = NoticeId;
            motion.NoticeDiaryDate = Convert.ToDateTime(NoticeDiaryDateTxt.Text);
            motion.NoticeDiaryTime = Convert.ToDateTime(NoticeDiaryTimeTxt.Text);
            // motion.MotionDiaryNo = Convert.ToString(MotionDiaryNoTxt.Text);
            motion.MotionTypeId = Convert.ToInt32(MotionTypeDDL.SelectedItem.Value);
            motion.MotionStatusId = Convert.ToInt32(MotionStatusDDL.SelectedItem.Value);
            //if (!String.IsNullOrEmpty(HouseMovingDateTxt.Text))
            //    motion.MovingHouseDate = Convert.ToDateTime(HouseMovingDateTxt.Text);
            //if (!String.IsNullOrEmpty(DiscussionDateTxt.Text))
            //    motion.DiscussionDate = Convert.ToDateTime(DiscussionDateTxt.Text);
            //if (!String.IsNullOrEmpty(RefferingDateTxt.Text))
            //    motion.RefferedScDate = Convert.ToDateTime(RefferingDateTxt.Text);
            motion.WeekId = 1;
            motion.Description = Convert.ToString(MotionTxt.Value);
            motion.UrduText = Convert.ToString(UrduTxt.Value);
            if (!string.IsNullOrEmpty(HidMotionFile.Value))
                motion.MotionFile = Convert.ToString(HidMotionFile.Value);
            motion.Movers = new List<MotionMoversEnt>();
            foreach (ListItem listItem in MoversLB.Items)
            {
                MotionMoversEnt mover = new MotionMoversEnt();
                mover.MotionMoversId = Convert.ToInt32(listItem.Value);
                motion.Movers.Add(mover);
            }
            motion.Processed = 1;
            //if (FileUpload1.HasFile)
            //{

            //    string strname = FileUpload1.FileName.ToString();
            //    //string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
            //    FileInfo fi = new FileInfo(strname);
            //    string ext = fi.Extension;
            //    string filename = motion.MotionsId + ext;
            //    FileUpload1.PostedFile.SaveAs(Server.MapPath("~//contents//motion//") + filename);
            //    string url = "./contents/motion/" + filename;
            //    motion.MotionFile = url;
            //    new MotionBiz().InsertMotionFile(url, motion.MotionsId);
            //}
            //else if (!string.IsNullOrEmpty(HidMotionFile.Value))
            //{
            //    motion.MotionFile = HidMotionFile.Value;
            //}
            return new MotionBiz().InsertMotion(motion, null);
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
        protected void BindFields()
        {
            MotionEnt motion = new MotionEnt();
            int MotionId = Convert.ToInt32(Request.QueryString["MotionId"]);
            motion = new MotionBiz().GetNoticeMotion(MotionId);
            // MotionIDTxt.Text = Convert.ToString(motion.MotionsId);
            //HidSessionNumber.Value = Convert.ToString(motion.SessionNumber);
            //SessionTxt.Text = Convert.ToString(motion.SessionDesc);
            SessionDDL.SelectedValue = Convert.ToString(motion.SessionNumber);
            NoticeDiaryNoTxt.Text = Convert.ToString(motion.NoticeDiaryNo);
            NoticeDiaryDateTxt.Text = motion.NoticeDiaryDate.ToShortDateString();
            NoticeDiaryTimeTxt.Text = motion.NoticeDiaryTime.ToShortTimeString();
            //MotionDiaryNoTxt.Text = motion.MotionDiaryNo.ToString();
            MotionTypeDDL.SelectedValue = motion.MotionTypeId.ToString();
            MotionStatusDDL.SelectedValue = motion.MotionStatusId.ToString();
            //HouseMovingDateTxt.Text = (motion.MovingHouseDate < Convert.ToDateTime("01/01/1900")) ? "" : motion.MovingHouseDate.ToShortDateString();
            //DiscussionDateTxt.Text = (motion.DiscussionDate < Convert.ToDateTime("01/01/1900")) ? "" : motion.DiscussionDate.ToShortDateString();
            //RefferingDateTxt.Text = (motion.RefferedScDate < Convert.ToDateTime("01/01/1900")) ? "" : motion.RefferedScDate.ToShortDateString();
            MotionTxt.Value = motion.Description.ToString();
            UrduTxt.Value = motion.UrduText;
            string file = motion.MotionFile;
            if (!string.IsNullOrEmpty(file))
            {
                HyperLink1.NavigateUrl = file + "?" + DateTime.Now.Ticks.ToString();
                HyperLink1.Text = "View File";
                HidMotionFile.Value = motion.MotionFile;
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
            // PrintHL.NavigateUrl = "~/PrintMotion.aspx?MotionId=" + MotionId;
            //if (motion.Movers != null)
            //{
            //    foreach (MotionMoversEnt movers in motion.Movers)
            //    {
            //        ListItem li = new ListItem();
            //        li.Text = movers.MoverName.ToString();
            //        li.Value = movers.MotionMoversId.ToString();
            //        MoversLB.Items.Add(li);
            //    }
            //}

        }
        protected void RevivedBtn_Click(object sender, EventArgs e)
        {
            int MotionId = Convert.ToInt32(Request.QueryString["MotionId"]);
            int ReviveMotionId = Convert.ToInt32(PreviousMotionIdTxt.Text);
            MotionEnt motionEnt = new MotionBiz().GetMotion(ReviveMotionId);
            if (motionEnt.MotionsId == 0)
            {
                prviousIdError.InnerText = "Motion does not exist";
                prviousIdError.Visible = true;
            }
            else
            {
                new MotionBiz().SetNoticeMotionRevived(MotionId, ReviveMotionId);
                RevivalHistory revivalHistory = new RevivalHistory();
                AssemblySessions assemblySessions = new AdministrationBiz().GetCurrentAssemblySessionDetails();
                revivalHistory.MotionsId = motionEnt.MotionsId;
                revivalHistory.FromAssemblySessionId = motionEnt.SessionNumber;
                revivalHistory.ToAssemblySessionId = assemblySessions.AssemblySessionsId;
                revivalHistory.NoticeOfficediaryNumber = motionEnt.NoticeDiaryNo;
                revivalHistory.RevivalDate = DateTime.Now;

                new MotionBiz().InsertMotionRevivalHistory(revivalHistory);
                motionEnt.SessionNumber = assemblySessions.AssemblySessionsId;
                motionEnt.NoticeDiaryNo = MotionId;
                motionEnt.NoticeDiaryDate = Convert.ToDateTime(NoticeDiaryDateTxt.Text);
                motionEnt.NoticeDiaryTime = Convert.ToDateTime(NoticeDiaryTimeTxt.Text);
                motionEnt.MotionStatusId = 5;//Under Process
                motionEnt.MotionFile = HidMotionFile.Value;

                MotionStatusHistory sh = new MotionStatusHistory();
                sh.MotionId = motionEnt.MotionsId;
                sh.MotionStatusId = 5;
                sh.AssemblySessionId = motionEnt.SessionNumber;
                sh.StatusDate = DateTime.Now;
                new MotionBiz().InsertMotionStatusHistory(sh);

                new MotionBiz().UpdateMotion(motionEnt);
                Response.Redirect("MotionDetails.aspx?MotionId=" + ReviveMotionId);
            }
        }
    }
}