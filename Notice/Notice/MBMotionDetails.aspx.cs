using BIZ;
using Entities;
using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace Notice
{
    public partial class MBMotionDetails : System.Web.UI.Page
    {
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
                BindFields();

            }
        }
        protected void BindCombos()
        {
            List<MotionTypeEnt> motiontypes = new AdministrationBiz().GetMotionTypes(2);
            //foreach (MotionTypeEnt row in motiontypes)
            //{
            //    ListItem li = new ListItem();
            //    li.Text = row.Description.ToString();
            //    li.Value = row.MotionTypeId.ToString();
            //    MotionTypeDDL.Items.Add(li);
            //}
            //List<MotionStatusEnt> motionstatus = new AdministrationBiz().GetMotionStatuses();
            //foreach (MotionStatusEnt row in motionstatus)
            //{
            //    ListItem li = new ListItem();
            //    li.Text = row.Description.ToString();
            //    li.Value = row.MotionStatusId.ToString();
            //    MotionStatusDDL.Items.Add(li);
            //}
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
            MBMotion motion = new MBMotion();
            int MotionId = Convert.ToInt32(Request.QueryString["MotionId"]);
            motion.MotionsId = MotionId;
            motion.SessionNumber = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            motion.NoticeDiaryNo = Convert.ToInt32(NoticeDiaryNoTxt.Text);
            motion.NoticeDiaryDate = Convert.ToDateTime(NoticeDiaryDateTxt.Text);
            motion.NoticeDiaryTime = Convert.ToDateTime(NoticeDiaryTimeTxt.Text);
            // motion.MotionDiaryNo = Convert.ToString(MotionDiaryNoTxt.Text);
            //motion.MotionTypeId = Convert.ToInt32(MotionTypeDDL.SelectedItem.Value);
            //motion.MotionStatusId = Convert.ToInt32(MotionStatusDDL.SelectedItem.Value);
            //if (!String.IsNullOrEmpty(HouseMovingDateTxt.Text))
            //    motion.MovingHouseDate = Convert.ToDateTime(HouseMovingDateTxt.Text);
            //if (!String.IsNullOrEmpty(DiscussionDateTxt.Text))
            //    motion.DiscussionDate = Convert.ToDateTime(DiscussionDateTxt.Text);
            //if (!String.IsNullOrEmpty(RefferingDateTxt.Text))
            //    motion.RefferedScDate = Convert.ToDateTime(RefferingDateTxt.Text);
            motion.Description = Convert.ToString(MotionTxt.Value);
            new MBMotionBiz().UpdateMotion(motion);
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
                string movername = new QuestionBiz().GetMemberNameById(moverid);
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
                new MBMotionBiz().InsertMotionMover(motionmover);

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
                new MBMotionBiz().DeleteMotionMover(MotionId, Convert.ToInt32(listItem.Value));
                MoversLB.Items.Remove(listItem);
            }

        }
        protected void BindFields()
        {
            MBMotion motion = new MBMotion();
            int MotionId = Convert.ToInt32(Request.QueryString["MotionId"]);
            motion = new MBMotionBiz().GetMotion(MotionId);
            MotionIDTxt.Text = Convert.ToString(motion.MotionsId);
            //HidSessionNumber.Value = Convert.ToString(motion.SessionNumber);
            //SessionTxt.Text = Convert.ToString(motion.SessionDesc);
            SessionDDL.SelectedValue = Convert.ToString(motion.SessionNumber);
            NoticeDiaryNoTxt.Text = Convert.ToString(motion.NoticeDiaryNo);
            NoticeDiaryDateTxt.Text = motion.NoticeDiaryDate.ToShortDateString();
            NoticeDiaryTimeTxt.Text = motion.NoticeDiaryTime.ToShortTimeString();
            //MotionDiaryNoTxt.Text = motion.MotionDiaryNo.ToString();
            //MotionTypeDDL.SelectedValue = motion.MotionTypeId.ToString();
            //MotionStatusDDL.SelectedValue = motion.MotionStatusId.ToString();
            //HouseMovingDateTxt.Text = (motion.MovingHouseDate < Convert.ToDateTime("01/01/1900")) ? "" : motion.MovingHouseDate.ToShortDateString();
            //DiscussionDateTxt.Text = (motion.DiscussionDate < Convert.ToDateTime("01/01/1900")) ? "" : motion.DiscussionDate.ToShortDateString();
            //RefferingDateTxt.Text = (motion.RefferedScDate < Convert.ToDateTime("01/01/1900")) ? "" : motion.RefferedScDate.ToShortDateString();
            MotionTxt.Value = motion.Description.ToString();
            PrintHL.NavigateUrl = "~/PrintMotion.aspx?MotionId=" + MotionId;
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

        }
    }
}