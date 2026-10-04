using Entities;
using QuestionBIZ;
using ResolutionBIZ;
using ResolutionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class PrintResolutionList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Generate();
        }
        protected string GetMembers(int ResolutionId)
        {
            string moverslist = "";
            List<ResolutionSubmittersEnt> movers = new ResolutionBiz().GetResolutionSubmitters(ResolutionId);
            if (movers != null)
            {
                int count = movers.Count();
                int chk = 1;
                if (movers != null)
                {
                    foreach (ResolutionSubmittersEnt temp in movers)
                    {
                        moverslist += "Senator " + temp.MoverName;
                        if (chk != count)
                            moverslist += ",<br>";
                        chk++;

                    }
                }
            }
            return moverslist;
        }
        // Title handed to the PDF export (already safe to put inside a JavaScript string).
        protected string ExportTitle = "List of Resolutions";

        protected void Generate()
        {
            int ResolutionListId = Convert.ToInt32(Request.QueryString["ResolutionListId"]);
            ResolutionListEnt QL = new ResolutionBiz().GetResolutionListById(ResolutionListId);
            List<ResolutionEnt> resolutions = new List<ResolutionEnt>();
            if (QL != null && !String.IsNullOrEmpty(QL.Resolutions))
            {
                foreach (int id in QL.Resolutions.Split(',').Select(s => Convert.ToInt32(s)))
                {
                    ResolutionEnt r = new ResolutionBiz().GetResolution(id);
                    if (r != null) resolutions.Add(r);
                }
            }

            ResolutionLV.DataSource = resolutions;
            ResolutionLV.DataBind();

            // heading of the printed list
            string name = QL != null && !String.IsNullOrWhiteSpace(QL.ListName) ? QL.ListName : "Resolution List";
            ListNameLit.Text = Server.HtmlEncode(name);
            ExportTitle = HttpUtility.JavaScriptStringEncode(name);
            string meta = "";
            if (QL != null && QL.AssemblySessionsId != 0) meta += "Session No. " + GetSessionName(QL.AssemblySessionsId);
            if (QL != null && QL.ListDate > Convert.ToDateTime("01/01/1900"))
                meta += (meta.Length > 0 ? " &nbsp;|&nbsp; " : "") + "List Date: " + QL.ListDate.ToString("dd MMMM yyyy");
            MetaLit.Text = meta;
            CountLit.Text = "Total resolutions: <b>" + resolutions.Count + "</b>";
            PrintedLit.Text = DateTime.Now.ToString("dd MMM yyyy, HH:mm");
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