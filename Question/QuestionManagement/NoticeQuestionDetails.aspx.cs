using Entities;
//using MODI;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class NoticeQuestionDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ReplyDateTxt.Text = DateTime.Now.ToShortDateString();
                //DivisionTxt.Attributes.Add("onblur", "javascript:CallMe('" + DivisionTxt.ClientID + "', '" + GroupTxt.ClientID + "', '" + SessionDDL.ClientID + "', '" + HidMemberId.ClientID  + "', '" + CategoryDDL.ClientID + "')");
                BindCombos();
                int QuestionId = Convert.ToInt32(Request.QueryString["QuestionsId"]);
                //PrintHL.NavigateUrl = "~/PrintQuestion.aspx?questionsId=" + QuestionId;
                //PrintUrduHL.NavigateUrl = "~/PrintUrduQuestion.aspx?questionsId=" + QuestionId;
                BindQuestion();
            }

        }
        [System.Web.Services.WebMethod]
        public string GetContactName(int divisionid, int assemblysessionid, int moverid, int CategoryId)
        {
            //int divisionid = Convert.ToInt32(HidDivisionId.Value);
            //int moverid = Convert.ToInt32(HidMemberId.Value);
            //int CategoryId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
            //int assemblysessionid = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            List<DivisionGroups> dgs = new AdministrationBiz().GetDivisionGroups(assemblysessionid, divisionid, CategoryId);
            int groupid = 0;
            foreach (DivisionGroups obj in dgs)
            {
                int numberofquestions = new QuestionBiz().GetMemberGroupQuestionsByStatus(moverid, obj.GroupId, CategoryId, 3);
                if (CategoryId == 1 && numberofquestions < 3 && obj.GroupSequence <= 10 && groupid == 0)
                {
                    groupid = obj.GroupId;
                }
                if (CategoryId == 2 && numberofquestions < 5 && obj.GroupSequence <= 5 && groupid == 0)
                {
                    groupid = obj.GroupId;
                }
                if (groupid == 0 && obj.GroupSequence > 10)
                    groupid = obj.GroupId;

            }
            Groups gp = new QuestionBiz().GetGroupById(groupid);
            //GroupTxt.Text = gp.Description;
            //HidGroupId.Value = gp.GroupsId.ToString();
            return gp.Description;
            //if (custid == null || custid.Length == 0)
            //    return String.Empty;
            ////SqlConnection conn = null;
            //try
            //{
            //    //string connection = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
            //    //conn = new SqlConnection(connection);
            //    //string sql = "Select ContactName from Customers where CustomerId = @CustID";
            //    //SqlCommand cmd = new SqlCommand(sql, conn);
            //    //cmd.Parameters.AddWithValue("CustID", custid);
            //    //conn.Open();
            //    //string contNm = Convert.ToString(cmd.ExecuteScalar());
            //    //return contNm;
            //    return "Masood";
            //}
            //catch (SqlException ex)
            //{
            //    return "error";
            //}
            //finally
            //{
            //    //conn.Close();
            //}
        }
        public void BindQuestion()
        {
            int QuestionId = Convert.ToInt32(Request.QueryString["QuestionsId"]);
            Questions question = new QuestionBiz().GetNoticeQuestionByIdMin(QuestionId);
            new QuestionBiz().SetNoticeQuestionCheckedStatus(QuestionId, 1);
            //if (question.SessionNumberId != 0)
            //{
            //    BindGroupsDDL(question.SessionNumberId, question.QuestionCategoriesId);
            //    GroupDDL.SelectedValue = question.MinistryGroupId.ToString();

            //}
            //if (question.DivisionId != 0)
            //{
            //    BindDivisionDDL(question.MinistryGroupId);
            //    DivisionDDL.SelectedValue = question.DivisionId.ToString();

            //}
            if (question.QuestionCategoriesId != 0)
            {
                CategoryDDL.SelectedValue = question.QuestionCategoriesId.ToString();

            }

            HidMemberId.Value = question.Mover.ToString();
            HidCurrentMemberId.Value = question.Mover.ToString();
            if (question.SessionNumber != null)
            {
                AssemblySessionDDL.SelectedValue = question.SessionNumberId.ToString();
            }
            NoticeDiaryNoTxt.Text = question.NoticeDiaryNo.ToString();
            QuestionIDTxt.Text = question.QuestionBranchId.ToString();
            PreviousQuestionsIdTxt.Text = question.PreviousQuestionsId.ToString();
            QuestionDiaryNoTxt.Text = question.QuestionDiaryNo.ToString();
            NoticeDiaryDateTxt.Text = question.NoticeDiaryDate.ToShortDateString();
            NoticeDiaryTimeTxt.Text = question.NoticeDiaryTime.ToShortTimeString();
            CategoryDDL.SelectedValue = question.QuestionCategoriesId.ToString();
            DeviceId.Value = question.DeviceId.ToString(); ;

            //if (question.DivisionId != 0)
            //    DivisionDDL.SelectedValue = question.DivisionId.ToString(); ;
            MemberNameTxt.Text = question.MoverName;
            HidMemberId.Value = question.Mover.ToString();
            QTxt.Value = question.QuestionText;
            UrduTxt.Value = question.UrduText;
            string file = question.QuestionFile;
            if (!string.IsNullOrEmpty(file))
            {
                HyperLink1.NavigateUrl = file;
                hidFileurl.Value = file;
                HyperLink1.Text = "View File";
                //ExtractTextFromImage(file);
                // ConvertImageToText(file);
            }
            else
            {
                HyperLink1.Text = "No File attached";
            }

            //if (question.Priority == 1)
            //    PriorityCB.Checked = true;
            //else
            //    PriorityCB.Checked = false;
            // PrintHL.NavigateUrl = "~/PrintQuestion.aspx?questionsId=" + QuestionId;

        }

        // "Read Text": runs OCR on the file the Notice Office attached. The file is looked up from the question id on the
        // server - the browser never supplies a path.
        [System.Web.Services.WebMethod]
        public static OcrResult ReadQuestionText(int questionId, string language, int rotation)
        {
            if (language != "eng" && language != "urd")
                return new OcrResult { Success = false, Message = "This language is not supported." };
            try
            {
                Questions q = new QuestionBiz().GetNoticeQuestionByIdMin(questionId);
                if (q == null || string.IsNullOrEmpty(q.QuestionFile))
                    return new OcrResult { Success = false, Message = "No file is attached to this question." };

                byte[] bytes = LoadAttachment(HttpContext.Current, q.QuestionFile);
                string extension = Path.GetExtension(q.QuestionFile.Split('?')[0]);

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

            Uri pageUrl = new Uri(ctx.Request.Url, ctx.Request.ApplicationPath.TrimEnd('/') + "/NoticeQuestionDetails.aspx");
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

        // Called from the page while the user types the question text (see the live check script).
        [System.Web.Services.WebMethod]
        public static SimilarityResult CheckSimilar(string text, int threshold)
        {
            if (threshold < 30 || threshold > 95) threshold = 50;
            int currentSessionId = new AdministrationBiz().GetCurrentAssemblySessions();
            return new SimilarityBiz().Check(text, currentSessionId, threshold, 15);
        }
        //public void ConvertImageToText(string path)
        //{
        //    var Ocr = new IronTesseract();
        //    string url = Server.MapPath(path);
        //    // Ocr.Language = OcrLanguage.Urdu;

        //    //using (var Input = new OcrInput(Server.MapPath("~//images//1.jpg")))
        //    //{
        //    //    QTxt.Value = Ocr.Read(Input).Text;

        //    //}
        //    try
        //    {
        //        string plainText = new IronTesseract().Read(Server.MapPath(path)).Text;
        //        QTxt.Value = plainText;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        protected int UpdateQuestion()
        {
            int userid = 0;
            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                userid = Convert.ToInt32(userInfo["userid"]);
            }
            Questions question = new Questions();
            // question.QuestionsId = Convert.ToInt32(NoticeDiaryNoTxt.Text);
            question.PreviousQuestionsId = Convert.ToInt32(QuestionIDTxt.Text);
            question.QuestionDiaryNo = Convert.ToInt32(QuestionDiaryNoTxt.Text);
            question.SessionNumberId = Convert.ToInt32(AssemblySessionDDL.SelectedValue);
            question.NoticeDiaryNo = Convert.ToInt32(NoticeDiaryNoTxt.Text);
            question.NoticeDiaryDate = Convert.ToDateTime(NoticeDiaryDateTxt.Text);
            string str = NoticeDiaryDateTxt.Text + " " + NoticeDiaryTimeTxt.Text;  // assumed date and time are textboxes
            DateTime dt = new DateTime();
            DateTime.TryParse(str, out (dt)); // returns datetime in dt if it is valid
            question.NoticeDiaryTime = dt;
            question.QuestionDate = Convert.ToDateTime(NoticeDiaryDateTxt.Text);
            question.QuestionCategoriesId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
            question.QuestionStatusId = 7;
            question.Mover = Convert.ToInt32(HidMemberId.Value);
            question.DivisionId = Convert.ToInt32(HidDivisionId.Value);
            question.MinistryGroupId = AssignGroup();//Convert.ToInt32(GroupDDL.SelectedItem.Value);
                                                     // question.Priority = (PriorityCB.Checked == true) ? 1 : 0;
            if (QTxt.Value.ToString() == "")
                QTxt.Value = "Contents not entered";
            else
                question.QuestionText = Convert.ToString(QTxt.Value);
            if (UrduTxt.Value.ToString() == "")
                UrduTxt.Value = "Contents not entered";
            else
                question.UrduText = Convert.ToString(UrduTxt.Value);
            if (!string.IsNullOrEmpty(hidFileurl.Value))
                question.QuestionFile = hidFileurl.Value;
            question.InsertedBy = userid;
            question.InsertedOn = DateTime.Now;
            question.DeviceId = Convert.ToInt32(DeviceId.Value);
            errorlbl.Text = "";

            int QuestionId = new QuestionBiz().InsertNoticeQuestions(question);

            return QuestionId;
        }

        protected int AssignGroup()
        {
            int divisionid = Convert.ToInt32(HidDivisionId.Value);
            int moverid = Convert.ToInt32(HidMemberId.Value);
            int CategoryId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
            int assemblysessionid = Convert.ToInt32(AssemblySessionDDL.SelectedValue);// Convert.ToInt32(HidSessionNumber.Value);
            List<DivisionGroups> dgs = new AdministrationBiz().GetDivisionGroups(assemblysessionid, divisionid, CategoryId);

            int groupid = 0;
            if (dgs != null)
            {
                foreach (DivisionGroups obj in dgs)
                {

                    groupid = obj.GroupId;


                }
            }
            // HidGroupId.Value = groupid.ToString();
            // Groups gp = new QuestionBiz().GetGroupById(groupid);
            //if (CategoryId == 1)
            //    GroupTxt.Text = gp.Description;
            //if (CategoryId == 2)
            //    GroupTxt.Text = gp.UnstarDesc;
            return groupid;
        }


        public void BindCombos()
        {

            List<AssemblySessions> ASessions = new AdministrationBiz().GetAssemblySessions();
            foreach (AssemblySessions row in ASessions)
            {
                ListItem li = new ListItem();
                li.Text = row.SessionNumber.ToString();
                li.Value = row.AssemblySessionsId.ToString();
                AssemblySessionDDL.Items.Add(li);
            }
            List<QuestionCategories> QCats = new AdministrationBiz().GetQuestionCategories();
            foreach (QuestionCategories row in QCats)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.QuestionCategoriesId.ToString();
                CategoryDDL.Items.Add(li);
            }
        }


        public void BindGroupsDDL(int AssemblySessionId, int CategoryId)
        {
            //List<Groups> gps = null;
            //gps = new QuestionBiz().GetSessionGroups(AssemblySessionId, CategoryId);
            //GroupDDL.Items.Clear();
            //GroupDDL.Items.Add(new ListItem("Select", "0"));

            //if (gps != null)
            //{

            //    foreach (Groups obj in gps)
            //    {
            //        ListItem li = new ListItem();
            //        li.Value = obj.GroupsId.ToString();
            //        if (CategoryId == 2)
            //            li.Text = obj.UnstarDesc;
            //        else
            //            li.Text = obj.Description;
            //        GroupDDL.Items.Add(li);
            //    }
            //}

        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {

            //int QuestionsId = Convert.ToInt32(QuestionIDTxt.Text);
            //new QuestionBiz().DeleteQuestion(QuestionsId);
            //Response.Redirect("SearchQuestion.aspx");
        }
        protected void UpdateQuestion_Click(object sender, EventArgs e)
        {
            int QuestionId = UpdateQuestion();
            Response.Redirect("QuestionDetails.aspx?QuestionsId=" + QuestionId);

        }
        protected void GroupDDL_SelectedIndexChanged(object sender, EventArgs e)
        {

            //int GroupId = Convert.ToInt32(GroupDDL.SelectedItem.Value);
            //BindDivisionDDL(GroupId);
        }
        public void BindDivisionDDL(int GroupId)
        {

            //DivisionDDL.Items.Clear();
            //DivisionDDL.Items.Add(new ListItem("Select", "0"));
            //List<Divisions> divs = new List<Divisions>();
            //divs = new AdministrationBiz().GetDivisions(GroupId);
            //if (divs != null)
            //{

            //    foreach (Divisions div in divs)
            //    {
            //        ListItem temp = new ListItem();
            //        temp.Value = div.DivisionsId.ToString();
            //        temp.Text = div.Description;
            //        DivisionDDL.Items.Add(temp);
            //    }
            //}

        }


        protected void CategoryDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int AssemblySessionId = Convert.ToInt32(AssemblySessionDDL.SelectedValue);
            int CategoryId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
            BindGroupsDDL(AssemblySessionId, CategoryId);
        }

        protected void AddNewBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NewQuestion.aspx");
        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();

        }
        protected void TranslateBtn_Click(object sender, EventArgs e)
        {
            int userid = 0;
            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                userid = Convert.ToInt32(userInfo["userid"]);
                int QuestionId = UpdateQuestion();
                //if (!string.IsNullOrEmpty(UrduTxt.Value))
                //{

                new QuestionBiz().SendForTranslation(QuestionId, userid);
                UrduLbl.Visible = false;
                Response.Redirect("QuestionDetails.aspx?QuestionsId=" + QuestionId);
                //}
                //else
                //{
                //    UrduLbl.Text = "No text found for translation";
                //    UrduLbl.Visible = true;
                //}
            }
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
            int QuestionId = Convert.ToInt32(Request.QueryString["QuestionsId"]);
            int ReviveQuestionId = Convert.ToInt32(PreviousQuestionsIdTxt.Text.Trim());
            Questions questions = new QuestionBiz().GetQuestionById(ReviveQuestionId);
            if (questions.QuestionsId == 0)
            {
                prviousIdError.InnerText = "Question does not exist";
                prviousIdError.Visible = true;
            }
            else
            {
                new QuestionBiz().SetNoticeQuestionRevived(QuestionId, ReviveQuestionId);
                RevivalHistory revivalHistory = new RevivalHistory();
                AssemblySessions assemblySessions = new AdministrationBiz().GetCurrentAssemblySessionDetails();
                revivalHistory.QuestionsId = questions.QuestionsId;
                revivalHistory.FromAssemblySessionId = questions.SessionNumberId;
                revivalHistory.ToAssemblySessionId = assemblySessions.AssemblySessionsId;
                revivalHistory.NoticeOfficediaryNumber = questions.NoticeDiaryNo;
                revivalHistory.RevivalDate = DateTime.Now;
                revivalHistory.InsertedBy = userid;
                revivalHistory.InsertedOn = DateTime.Now;
                new QuestionBiz().InsertQuestionRevivalHistory(revivalHistory);
                questions.SessionNumberId = assemblySessions.AssemblySessionsId;
                questions.NoticeDiaryNo = QuestionId;
                questions.NoticeDiaryDate = Convert.ToDateTime(NoticeDiaryDateTxt.Text);
                questions.NoticeDiaryTime = Convert.ToDateTime(NoticeDiaryTimeTxt.Text);
                questions.QuestionStatusId = 7;//Under Process
                questions.QuestionFile = hidFileurl.Value;
                questions.FileStatusId = 1;
                QuestionStatusHistory sh = new QuestionStatusHistory();
                sh.QuestionId = questions.QuestionsId;
                sh.QuestionStatusId = 7;
                sh.AssemblySessionId = questions.SessionNumberId;
                sh.StatusDate = DateTime.Now;
                sh.InsertedBy = userid;
                sh.InsertedOn = DateTime.Now;
                questions.UpdatedBy = userid;
                questions.UpdatedOn = DateTime.Now;
                new QuestionBiz().UpdateQuestionStatus(sh);
                new QuestionBiz().UpdateQuestions(questions);
                Response.Redirect("QuestionDetails.aspx?QuestionsId=" + ReviveQuestionId);
            }
        }

        protected void DivisionDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            // QTxt.Value ="Will the Minister for " + DivisionDDL.SelectedItem.Text + QTxt.Value.ToString();
        }
        protected void DuplicateQuestion()
        {
            int userid = 0;
            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                userid = Convert.ToInt32(userInfo["userid"]);
            }
            int QuestionId = Convert.ToInt32(Request.QueryString["QuestionsId"]);
            int DuplicateQuestionId = Convert.ToInt32(PreviousQuestionsIdTxt.Text.Trim());
            Questions questions = new QuestionBiz().GetQuestionById(DuplicateQuestionId);
            if (questions.QuestionsId == 0)
            {
                prviousIdError.InnerText = "Question does not exist";
                prviousIdError.Visible = true;
            }
            else
            {
                new QuestionBiz().SetNoticeQuestionDuplicate(DuplicateQuestionId, QuestionId, 5, userid);
            }
        }

        protected void DuplicateBtn_Click(object sender, EventArgs e)
        {
            DuplicateQuestion();
        }
        //private string ExtractTextFromImage(string filePath)
        //{
        //    //Document modiDocument = new Document();
        //    //modiDocument.Create(filePath);
        //    //modiDocument.OCR(MiLANGUAGES.miLANG_ENGLISH);
        //    //MODI.Image modiImage = (modiDocument.Images[0] as MODI.Image);
        //    //string extractedText = modiImage.Layout.Text;
        //    //modiDocument.Close();
        //    //return extractedText;
        //    //return "abc";
        //}
    }
}