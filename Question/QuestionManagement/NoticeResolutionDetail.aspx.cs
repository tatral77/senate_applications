using Entities;
using QuestionBIZ;
using ResolutionBIZ;
using ResolutionEntities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class NoticeResolutionDetail : System.Web.UI.Page
    {
        //[WebMethod]
        //public static List<string> GetEmployeeName(string empName)
        //{
        //    List<string> empResult = new List<string>();
        //    List<Member> mems = new ResolutionBiz().GetMembersByName(empName);
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
        // "Read Text": runs OCR on the file the Notice Office attached. The file is looked up from the question id on the
        // server - the browser never supplies a path.
        [System.Web.Services.WebMethod]
        public static OcrResult ReadResolutionText(int resolutionId, string language, int rotation)
        {
            if (language != "eng" && language != "urd")
                return new OcrResult { Success = false, Message = "This language is not supported." };
            try
            {
                ResolutionEnt r = new ResolutionBiz().GetNoticeResolution(resolutionId);
                if (r == null || string.IsNullOrEmpty(r.ResolutionFile))
                    return new OcrResult { Success = false, Message = "No file is attached to this resolution." };

                byte[] bytes = LoadAttachment(HttpContext.Current, r.ResolutionFile);
                string extension = Path.GetExtension(r.ResolutionFile.Split('?')[0]);

                OcrSettings settings = new OcrSettings
                {
                    TesseractPath = ConfigurationManager.AppSettings["Ocr:TesseractPath"],
                    TessdataPath = ConfigurationManager.AppSettings["Ocr:TessdataPath"],
                    GhostscriptPath = ConfigurationManager.AppSettings["Ocr:GhostscriptPath"],
                    MaxPdfPages = ToInt(ConfigurationManager.AppSettings["Ocr:MaxPdfPages"], 10),
                    TimeoutSeconds = ToInt(ConfigurationManager.AppSettings["Ocr:TimeoutSeconds"], 90)
                };
                return new OcrBiz().Read(settings, bytes, extension, language, rotation);
            }
            catch (Exception ex)
            {
                return new OcrResult { Success = false, Message = "Could not read the file: " + ex.Message };
            }
        }

        private static int ToInt(string value, int fallback)
        {
            int n;
            return int.TryParse(value, out n) && n > 0 ? n : fallback;
        }

        // Gets the attached file: from disk when it lives inside this site, otherwise over HTTP from the same server
        // (the Notice Office files are stored as "./contents/<id>.pdf" relative to the site).
        private static byte[] LoadAttachment(HttpContext ctx, string file)
        {
            const int MaxBytes = 25 * 1024 * 1024;
            file = file.Trim().Replace('\\', '/');

            Uri pageUrl = new Uri(ctx.Request.Url, ctx.Request.ApplicationPath.TrimEnd('/') + "/NoticeResolutionDetail.aspx");
            Uri target;
            if (file.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || file.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                target = new Uri(file);
                if (!string.Equals(target.Host, ctx.Request.Url.Host, StringComparison.OrdinalIgnoreCase))
                    throw new InvalidOperationException("The file is stored on another server and cannot be read from here.");
            }
            else
            {
                // inside this site? read it straight from disk
                try
                {
                    string virtualPath = VirtualPathUtility.Combine("~/", file.TrimStart('~'));
                    string physical = ctx.Server.MapPath(virtualPath);
                    if (File.Exists(physical))
                    {
                        if (new FileInfo(physical).Length > MaxBytes) throw new InvalidOperationException("The file is too large to read.");
                        return File.ReadAllBytes(physical);
                    }
                }
                catch (HttpException) { }            // path points outside this site - fall through to HTTP
                catch (ArgumentException) { }
                target = new Uri(pageUrl, file);
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(target);
            request.Timeout = 30000;
            request.UseDefaultCredentials = true;
            string cookies = ctx.Request.Headers["Cookie"];
            if (!string.IsNullOrEmpty(cookies)) request.Headers["Cookie"] = cookies;
            using (WebResponse response = request.GetResponse())
            {
                if (response.ContentLength > MaxBytes) throw new InvalidOperationException("The file is too large to read.");
                using (Stream stream = response.GetResponseStream())
                using (MemoryStream memory = new MemoryStream())
                {
                    stream.CopyTo(memory);
                    if (memory.Length > MaxBytes) throw new InvalidOperationException("The file is too large to read.");
                    return memory.ToArray();
                }
            }
        }

        protected void BindCombos()
        {
            List<ResolutionTypesEnt> resolutiontypes = new ResolutionBiz().GetResolutionTypes();
            foreach (ResolutionTypesEnt row in resolutiontypes)
            {
                ListItem li = new ListItem();
                li.Text = row.Description.ToString();
                li.Value = row.ResTypesId.ToString();
                ResolutionTypeDDL.Items.Add(li);
            }
            List<ResolutionStatusesEnt> resolutionstatus = new ResolutionBiz().GetResolutionStatuses();
            foreach (ResolutionStatusesEnt row in resolutionstatus)
            {
                ListItem li = new ListItem();
                li.Text = row.Description.ToString();
                li.Value = row.ResolutionStatusesId.ToString();
                ResolutionStatusDDL.Items.Add(li);
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
            int ResolutionId = SaveResolution();
            Response.Redirect("~/ResolutionDetail.aspx?ResolutionId=" + ResolutionId);

        }
        protected void TranslateBtn_Click(object sender, EventArgs e)
        {
            int ResolutionId = SaveResolution();
            int userid = 0;
            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                userid = Convert.ToInt32(userInfo["userid"]);
            }
            if (!string.IsNullOrEmpty(UrduTxt.Value))
            {

                new ResolutionBiz().SendForTranslation(ResolutionId, userid);
                UrduLbl.Visible = false;
                Response.Redirect("ResolutionDetail.aspx?ResolutionId=" + ResolutionId);
            }
            else
            {
                UrduLbl.Text = "No text found for translation";
                UrduLbl.Visible = true;
            }
        }
        protected int SaveResolution()
        {
            ResolutionEnt resolution = new ResolutionEnt();
            int NoticeId = Convert.ToInt32(Request.QueryString["ResolutionId"]);
            resolution.ResolutionsId = NoticeId;
            resolution.AssemblySessionsId = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            resolution.NoticeDiaryNo = NoticeId;
            resolution.NoticeDiaryDate = Convert.ToDateTime(NoticeDiaryDateTxt.Text);
            resolution.NoticeDiaryTime = Convert.ToDateTime(NoticeDiaryTimeTxt.Text);
            // resolution.ResolutionDiaryNo = Convert.ToString(ResolutionDiaryNoTxt.Text);
            resolution.ResTypesId = Convert.ToInt32(ResolutionTypeDDL.SelectedItem.Value);
            resolution.ResolutionStatusId = Convert.ToInt32(ResolutionStatusDDL.SelectedItem.Value);
            //if (!String.IsNullOrEmpty(HouseMovingDateTxt.Text))
            //    resolution.MovingHouseDate = Convert.ToDateTime(HouseMovingDateTxt.Text);
            //if (!String.IsNullOrEmpty(DiscussionDateTxt.Text))
            //    resolution.DiscussionDate = Convert.ToDateTime(DiscussionDateTxt.Text);
            //if (!String.IsNullOrEmpty(RefferingDateTxt.Text))
            //    resolution.RefferedScDate = Convert.ToDateTime(RefferingDateTxt.Text);
            resolution.Description = Convert.ToString(ResolutionTxt.Value);
            resolution.Subject = Convert.ToString(ResolutionTxt.Value);
            resolution.UrduText = Convert.ToString(UrduTxt.Value);
            if (!string.IsNullOrEmpty(HidResolutionFile.Value))
                resolution.ResolutionFile = Convert.ToString(HidResolutionFile.Value);
            resolution.Processed = 1;
            resolution.Submitters = new List<ResolutionSubmittersEnt>();
            foreach (ListItem listItem in MoversLB.Items)
            {
                ResolutionSubmittersEnt mover = new ResolutionSubmittersEnt();
                mover.SystemUsersId = Convert.ToInt32(listItem.Value);
                resolution.Submitters.Add(mover);
            }
            new ResolutionBiz().ChangeNoticeResolutionStatus(NoticeId, 1);

            //if (FileUpload1.HasFile)
            //{

            //    string strname = FileUpload1.FileName.ToString();
            //    //string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
            //    FileInfo fi = new FileInfo(strname);
            //    string ext = fi.Extension;
            //    string filename = resolution.ResolutionsId + ext;
            //    FileUpload1.PostedFile.SaveAs(Server.MapPath("~//contents//resolution//") + filename);
            //    string url = "./contents/resolution/" + filename;
            //    resolution.ResolutionFile = url;
            //    new ResolutionBiz().InsertResolutionFile(url, resolution.ResolutionsId);
            //}
            //else if (!string.IsNullOrEmpty(HidResolutionFile.Value))
            //{
            //    resolution.ResolutionFile = HidResolutionFile.Value;
            //}
            return new ResolutionBiz().InsertResolution(resolution);
        }
        protected void PrintBtn_Click(object sender, EventArgs e)
        {
            // int id=InsertResolution();
            // Response.Redirect("~/PrintResolution.aspx?questionsId=" + id);

        }

        protected void RevivedBtn_Click(object sender, EventArgs e)
        {
            int userid = 0;
            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                userid = Convert.ToInt32(userInfo["userid"]);
            }
            int ResolutionId = Convert.ToInt32(Request.QueryString["ResolutionId"]);
            int ReviveResolutionId = Convert.ToInt32(PreviousResolutionIdTxt.Text.Trim());
            ResolutionEnt resolution = new ResolutionBiz().GetResolution(ReviveResolutionId);
            if (resolution.ResolutionsId == 0)
            {
                prviousIdError.InnerText = "Resolution does not exist";
                prviousIdError.Visible = true;
            }
            else
            {
                new ResolutionBiz().SetNoticeResolutionRevived(ResolutionId, ReviveResolutionId);
                ResolutionRevivalHistory revivalHistory = new ResolutionRevivalHistory();
                AssemblySessions assemblySessions = new AdministrationBiz().GetCurrentAssemblySessionDetails();
                revivalHistory.ResolutionId = resolution.ResolutionsId;
                revivalHistory.FromAssemblySessionId = resolution.AssemblySessionsId;
                revivalHistory.ToAssemblySessionId = assemblySessions.AssemblySessionsId;
                revivalHistory.NoticeOfficediaryNumber = resolution.NoticeDiaryNo;
                revivalHistory.RevivalDate = DateTime.Now;
                revivalHistory.InsertedBy = userid;
                revivalHistory.InsertedOn = DateTime.Now;
                revivalHistory.PreviousFile = resolution.ResolutionFile;
                new ResolutionBiz().InsertResolutionRevivalHistory(revivalHistory);
                resolution.AssemblySessionsId = assemblySessions.AssemblySessionsId;
                resolution.NoticeDiaryNo = ResolutionId;
                resolution.NoticeDiaryDate = Convert.ToDateTime(NoticeDiaryDateTxt.Text);
                resolution.NoticeDiaryTime = Convert.ToDateTime(NoticeDiaryTimeTxt.Text);
                resolution.ResolutionStatusId = 5;//Under Process
                resolution.ResolutionFile = HidResolutionFile.Value;
               // resolution.FileStatusId = 1;
                ResolutionStatusHistory sh = new ResolutionStatusHistory();
                sh.ResolutionId = resolution.ResolutionsId;
                sh.ResolutionStatusId = 5;
                sh.AssemblySessionId = resolution.AssemblySessionsId;
                sh.StatusDate = DateTime.Now;
                sh.InsertedBy = userid;
                resolution.UpdatedBy = userid;
                resolution.UpdatedOn = DateTime.Now;
                new ResolutionBiz().UpdateResolutionStatus(sh);
                new ResolutionBiz().UpdateRevivedResolution(resolution);
                Response.Redirect("ResolutionDetail.aspx?ResolutionId=" + ReviveResolutionId);
            }
        }
        protected void DuplicateResolution()
        {
            int userid = 0;
            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                userid = Convert.ToInt32(userInfo["userid"]);
            }
            int ResolutionId = Convert.ToInt32(Request.QueryString["ResolutionId"]);
            int DuplicateResolutionId = Convert.ToInt32(PreviousResolutionIdTxt.Text.Trim());
            ResolutionEnt questions = new ResolutionBiz().GetResolution(DuplicateResolutionId);
            if (questions.ResolutionsId == 0)
            {
                prviousIdError.InnerText = "Resolution does not exist";
                prviousIdError.Visible = true;
            }
            else
            {
                new ResolutionBiz().SetNoticeResolutionDuplicate(DuplicateResolutionId, ResolutionId, 5, userid);
            }
        }

        protected void DuplicateBtn_Click(object sender, EventArgs e)
        {
            DuplicateResolution();
        }
        //protected void AddMover_Click(object sender, EventArgs e)
        //{
        //    int found = 0;
        //    int moverid = Convert.ToInt32(HidMemberId.Value);
        //    int ResolutionId = Convert.ToInt32(Request.QueryString["ResolutionId"]);
        //    if (!String.IsNullOrEmpty(HidMemberId.Value))
        //    {

        //        foreach (ListItem listItem in MoversLB.Items)
        //        {
        //            if (Convert.ToInt32(listItem.Value) == moverid)
        //                found = 1;
        //        }
        //    }
        //    if (found == 0)
        //    {
        //        string movername = new ResolutionBiz().GetMemberNameById(moverid);
        //        ListItem Temp = new ListItem();
        //        Temp.Value = Convert.ToString(moverid);
        //        Temp.Text = Convert.ToString(movername);
        //        MoversLB.Items.Add(Temp);
        //        HidMemberId.Value = "";
        //        MemberNameTxt.Text = "";
        //        err.Text = "";
        //        ResolutionSubmittersEnt motionmover = new ResolutionSubmittersEnt();
        //        motionmover.ResolutionsId = ResolutionId;
        //        motionmover.SystemUsersId = moverid;
        //        new ResolutionBiz().InsertResolutionSubmitters(motionmover);

        //    }
        //    else
        //        err.Text = "Mover already exist";

        //}
        protected void DeleteMover_Click(object sender, EventArgs e)
        {
            List<ListItem> itemsToRemove = new List<ListItem>();
            int ResolutionId = Convert.ToInt32(Request.QueryString["ResolutionId"]);
            foreach (ListItem temp in MoversLB.Items)
            {
                if (temp.Selected)
                {
                    itemsToRemove.Add(temp);
                }
            }

            foreach (ListItem listItem in itemsToRemove)
            {
                new ResolutionBiz().DeleteResolutionMover(ResolutionId, Convert.ToInt32(listItem.Value));
                MoversLB.Items.Remove(listItem);
            }

        }
        protected void BindFields()
        {
            ResolutionEnt resolution = new ResolutionEnt();
            int ResolutionId = Convert.ToInt32(Request.QueryString["ResolutionId"]);
            resolution = new ResolutionBiz().GetNoticeResolution(ResolutionId);
            if (resolution != null)
            {
                // ResolutionIDTxt.Text = Convert.ToString(resolution.ResolutionsId);
                //HidSessionNumber.Value = Convert.ToString(resolution.SessionNumber);
                //SessionTxt.Text = Convert.ToString(resolution.SessionDesc);
                SessionDDL.SelectedValue = Convert.ToString(resolution.AssemblySessionsId);
                NoticeDiaryNoTxt.Text = Convert.ToString(resolution.ResolutionsId);
                NoticeDiaryDateTxt.Text = resolution.NoticeDiaryDate.ToShortDateString();
                NoticeDiaryTimeTxt.Text = resolution.NoticeDiaryTime.ToShortTimeString();
                //ResolutionDiaryNoTxt.Text = resolution.ResolutionDiaryNo.ToString();
                ResolutionTypeDDL.SelectedValue = resolution.ResTypesId.ToString();
                ResolutionStatusDDL.SelectedValue = resolution.ResolutionStatusId.ToString();
                //HouseMovingDateTxt.Text = (resolution.MovingHouseDate < Convert.ToDateTime("01/01/1900")) ? "" : resolution.MovingHouseDate.ToShortDateString();
                //DiscussionDateTxt.Text = (resolution.DiscussionDate < Convert.ToDateTime("01/01/1900")) ? "" : resolution.DiscussionDate.ToShortDateString();
                //RefferingDateTxt.Text = (resolution.RefferedScDate < Convert.ToDateTime("01/01/1900")) ? "" : resolution.RefferedScDate.ToShortDateString();
                ResolutionTxt.Value = resolution.Description.ToString();
                UrduTxt.Value = resolution.UrduText;
                string file = resolution.ResolutionFile;
                if (!string.IsNullOrEmpty(file))
                {
                    HyperLink1.NavigateUrl = file + "?" + DateTime.Now.Ticks.ToString();
                    HyperLink1.Text = "View File";
                    HidResolutionFile.Value = resolution.ResolutionFile;
                }
                else
                {
                    HyperLink1.Text = "No File attached";
                }
                // PrintHL.NavigateUrl = "~/PrintResolution.aspx?ResolutionId=" + ResolutionId;
                if (resolution.Submitters != null)
                {
                    foreach (ResolutionSubmittersEnt movers in resolution.Submitters)
                    {
                        ListItem li = new ListItem();
                        li.Text = movers.MoverName.ToString();
                        li.Value = movers.ResolutionsSubmittersId.ToString();
                        MoversLB.Items.Add(li);
                    }
                }
            }

        }
    }
}