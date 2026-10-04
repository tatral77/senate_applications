using Entities;
using MotionBIZ;
using MotionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MotionBranch
{
    public partial class PrintMotionList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Generate();
        }
        protected string GetMembers(int MotionId)
        {
            string moverslist = "";
            List<MotionMoversEnt> movers = new MotionBiz().GetMotionMovers(MotionId);
            int count = movers.Count();
            int chk = 0;
            if (movers != null)
            {
                foreach (MotionMoversEnt temp in movers)
                {
                    moverslist += "Senator " + temp.MoverName;
                    if (chk != count)
                        moverslist += ",<br>";
                    chk++;

                }
            }
            return moverslist;
        }
        protected string GetMinistries(int MotionId)
        {
            string moverslist = "";
            List<MotionMinistriesEnt> motionMinistriesEnts = new MotionBiz().GetMotionMinistries(MotionId);
            if (motionMinistriesEnts != null)
            {
                int count = motionMinistriesEnts.Count();
                int chk = 0;
                if (motionMinistriesEnts != null)
                {
                    foreach (MotionMinistriesEnt temp in motionMinistriesEnts)
                    {
                        moverslist += temp.MinistryName;
                        if (chk != count)
                            moverslist += ",<br>";
                        chk++;

                    }
                }
            }
            return moverslist;
        }
        protected void Generate()
        {

            int MotionListId = Convert.ToInt32(Request.QueryString["MotionListId"]);
            ListEntity QL = new ListEntity();

            QL = new MotionBiz().GetMotionListById(MotionListId);
            //  ListNameLbl.Text = QL.ListName;
            List<MotionEnt> DefferedMotions = new List<MotionEnt>();
            List<MotionEnt> Motions = new List<MotionEnt>();
            if (!String.IsNullOrEmpty(QL.DefferedMotions))
            {
                List<int> DefMotions = QL.DefferedMotions.Split(',').Select(s => Convert.ToInt32(s)).ToList();
                if (DefMotions != null)
                {
                    DefferedLabel.Visible = true;
                    DefferedLV.Visible = true;
                    DefferedLabel.Text=QL.MotionType + " DEFFERED DURING SESSION " + QL.AsseblySession.ToUpper();
                    foreach (int dq in DefMotions)
                        DefferedMotions.Add(new MotionBiz().GetMotion(dq));
                }
                DefferedLV.DataSource = DefferedMotions;
                DefferedLV.DataBind();
            }
            if (!String.IsNullOrEmpty(QL.ListMotions))
            {
                List<int> motions = QL.ListMotions.Split(',').Select(s => Convert.ToInt32(s)).ToList();
                if (motions != null)
                {
                    MotionListLbl.Visible = true;
                    MotionLV.Visible = true;
                    MotionListLbl.Text = QL.MotionType.ToUpper() + " FOR SESSION " + QL.AsseblySession.ToUpper();
                  
                    foreach (int dq in motions)
                        Motions.Add(new MotionBiz().GetMotion(dq));
                }
                MotionLV.DataSource = Motions;
                MotionLV.DataBind();
            }



        }

        public string GetSessionName(int AssemblySessionId)
        {
            AssemblySessions asession = new AdministrationBiz().GetAssemblySession(AssemblySessionId);
            if (asession != null)
                return asession.SessionNumber.ToString();
            else
                return "Not Mentioned";

        }
        public string GetDefSenatorName(int ListNo, string MoverName)
        {
            return "*(DEF.) QUESTION NO. " + ListNo + " SENATOR " + MoverName.ToUpper() + ":";
        }
        public string GetListSenatorName(int ListNo, string MoverName)
        {
            return "*QUESTION NO. " + ListNo + " SENATOR " + MoverName.ToUpper() + ":";
        }
        public string GetNoticeDateTime(DateTime DiaryDate, DateTime DiaryTime, int qid)
        {
            return "( Notice Received on " + DiaryDate.ToShortDateString() + " at " + DiaryTime.ToShortTimeString() + ") QID: " + qid;
        }
    }
}