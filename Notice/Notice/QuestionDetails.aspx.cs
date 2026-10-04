using BIZ;
using Entities;
using Notice.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Services;
using System.Web.UI.WebControls;



namespace Notice
{
    public partial class QuestionDetails : System.Web.UI.Page
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
                int QuestionId = Convert.ToInt32(Request.QueryString["QuestionsId"]);
                // PrintHL.NavigateUrl = "~/PrintQuestion.aspx?questionsId=" + QuestionId;
                BindQuestion();
            }
        }

        public void BindQuestion()
        {
            int QuestionId = Convert.ToInt32(Request.QueryString["QuestionsId"]);
            Questions question = new QuestionBiz().GetQuestionByIdMin(QuestionId);

            if (question.QuestionCategoriesId != 0)
            {
                CategoryDDL.SelectedValue = question.QuestionCategoriesId.ToString();

            }
            HidMemberId.Value = question.Mover.ToString();
            HidCurrentMemberId.Value = question.Mover.ToString();
            if (question.SessionNumber != null)
            {
                SessionTxt.Text = question.SessionNumber.ToString();
                HidSessionNumber.Value = question.SessionNumberId.ToString();
            }
            NoticeDiaryNoTxt.Text = question.NoticeDiaryNo.ToString();
            QuestionIDTxt.Text = question.QuestionsId.ToString();
            if (!string.IsNullOrEmpty(question.UrduText))
                UrduTxt.Value = question.UrduText.ToString();
            NoticeDiaryDateTxt.Text = FormInput.FormatDate(question.NoticeDiaryDate);
            NoticeDiaryTimeTxt.Text = question.NoticeDiaryTime.ToString("HH:mm");
            CategoryDDL.SelectedValue = question.QuestionCategoriesId.ToString();
            MemberNameTxt.Text = question.MoverName;
            HidMemberId.Value = question.Mover.ToString();
            if (!string.IsNullOrEmpty(question.QuestionText))
                QTxt.Value = question.QuestionText;
            string file = question.QuestionFile;
            if (!string.IsNullOrEmpty(file))
            {
                HyperLink1.NavigateUrl = file + "?" + DateTime.Now.Ticks.ToString();
                HyperLink1.Text = "View File";
            }
            else
            {
                HyperLink1.Text = "No File attached";
            }

            // PrintHL.NavigateUrl = "~/PrintQuestion.aspx?questionsId=" + QuestionId;
            BindStatusHistory(QuestionId);
            BindMovementHistory(QuestionId);
            BindQuestionDeferment(QuestionId);

        }

        public void BindCombos()
        {

            List<AssemblySessions> ASessions = new AdministrationBiz().GetAssemblySessions();
            foreach (AssemblySessions row in ASessions)
            {
                ListItem li = new ListItem();
                li.Text = row.SessionNumber.ToString();
                li.Value = row.AssemblySessionsId.ToString();
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
        public void BindStatusHistory(int QuestionId)
        {
            List<QuestionStatusHistory> sh = new List<QuestionStatusHistory>();
            sh = new QuestionBiz().GetQuestionStatusHistory(QuestionId);
            LVStatus.DataSource = sh;
            LVStatus.DataBind();
        }
        public void BindMovementHistory(int QuestionId)
        {
            List<QuestionMovementHistory> sh = new List<QuestionMovementHistory>();
            sh = new QuestionBiz().GetQuestionMovementHistory(QuestionId);
            LVMovement.DataSource = sh;
            LVMovement.DataBind();
        }

        public void BindQuestionDeferment(int QuestionId)
        {
            List<DeferQuestion> sh = new List<DeferQuestion>();
            sh = new QuestionBiz().GetQuestionDeferment(QuestionId);
            DeferLv.DataSource = sh;
            DeferLv.DataBind();
        }
        public string GetSession(int SessionNumber)
        {
            AssemblySessions ASession = new AssemblySessions();
            ASession = new AdministrationBiz().GetAssemblySession(SessionNumber);
            return ASession.SessionNumber.ToString();
        }
        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            int QuestionsId = Convert.ToInt32(QuestionIDTxt.Text);
            new QuestionBiz().DeleteQuestion(QuestionsId);
            Response.Redirect("SearchQuestion.aspx");
        }
        protected void CategoryDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int AssemblySessionId = Convert.ToInt32(HidSessionNumber.Value);
            int CategoryId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
        }

        protected void AddNewBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NewQuestion.aspx");
        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();

        }

        protected void UpdateQuestionBtn_Click(object sender, EventArgs e)
        {
            Questions question = new Questions();
            question.QuestionsId = Convert.ToInt32(QuestionIDTxt.Text);
            question.SessionNumberId = Convert.ToInt32(HidSessionNumber.Value);
            question.NoticeDiaryNo = Convert.ToInt32(NoticeDiaryNoTxt.Text);
            DateTime noticeDate = FormInput.ParseDate(NoticeDiaryDateTxt.Text);
            question.NoticeDiaryDate = noticeDate;
            DateTime dt = noticeDate.Date;
            DateTime noticeTime;
            if (DateTime.TryParse(NoticeDiaryTimeTxt.Text, out noticeTime))
                dt = noticeDate.Date + noticeTime.TimeOfDay;
            question.NoticeDiaryTime = dt;
            question.QuestionDate = noticeDate;
            question.QuestionCategoriesId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
            question.QuestionText = Convert.ToString(QTxt.Value);
            if (!string.IsNullOrEmpty(UrduTxt.Value))
                question.UrduText = Convert.ToString(UrduTxt.Value);
            question.Mover = Convert.ToInt32(HidMemberId.Value);
            new QuestionBiz().UpdateQuestions(question);

            if (FileUpload1.HasFile)
            {
               
                string strname = FileUpload1.FileName.ToString();
                ////string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
                FileInfo fi = new FileInfo(strname);
                string ext = fi.Extension;
                string filename = question.QuestionsId + ext;
                if (!ext.Contains("pdf"))
                    AddWaterMark(question.QuestionsId, ext);
                else
                {
                    string DiaryNo = " Notice Diary No.: " + NoticeDiaryNoTxt.Text;
                    string DiaryDate = " Notice Diary Date: " + NoticeDiaryDateTxt.Text;
                    string DiaryTime = " Notice Diary Time: " + Convert.ToDateTime(NoticeDiaryTimeTxt.Text).ToString("hh:mm tt");
                    string TextToAdd = DiaryNo + " " + DiaryDate + " " + DiaryTime;
                    string filePath = Server.MapPath("~//contents//temp//" + filename);
                    FileUpload1.SaveAs(filePath);
                    Utils.AddTextToPdf(filePath, Server.MapPath("~//contents//" + filename), TextToAdd);
                }
             
                string url = "./contents/" + filename;
                question.QuestionFile = url;
                new QuestionBiz().InsertQuestionFile(url, question.QuestionsId);


                //string strname = FileUpload1.FileName.ToString();
                ////string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
                //FileInfo fi = new FileInfo(strname);
                //string ext = fi.Extension;
                //string filename = question.QuestionsId + ext;
                //FileUpload1.PostedFile.SaveAs(Server.MapPath("~//contents//") + filename);
                //string url = "./contents/" + filename;
                //question.QuestionFile = url;
                //new QuestionBiz().InsertQuestionFile(url, question.QuestionsId);
            }
            Response.Redirect("QuestionDetails.aspx?QuestionsId=" + Convert.ToInt32(QuestionIDTxt.Text));
        }
        public static Bitmap ConvertToNonIndexed(System.Drawing.Image img)
        {
            // Create a new Bitmap with 24bppRgb format
            Bitmap newBitmap = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);

            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                g.DrawImage(img, 0, 0);
            }

            return newBitmap;
        }

        protected int AddWaterMark(int id, string ext)
        {
            string DiaryNo = "Notice Diary No.: " + NoticeDiaryNoTxt.Text;
            string DiaryDate = "Notice Diary Date: " + NoticeDiaryDateTxt.Text;
            string DiaryTime = "Notice Diary Time: " + Convert.ToDateTime(NoticeDiaryTimeTxt.Text).ToString("hh:mm tt");

            //Get the file name.
            // string fileName = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName) + ".png";
            string fileName = id + ext;
            //Read the File into a Bitmap.
         
            using (Bitmap bmp = new Bitmap(FileUpload1.PostedFile.InputStream, false))
            {
                Bitmap originalBmp = new Bitmap(bmp);

                // Create a blank bitmap with the same dimensions
                Bitmap tempBitmap = new Bitmap(bmp.Width, bmp.Height);

                using (Graphics grp = Graphics.FromImage(tempBitmap))
                {
                    grp.DrawImage(originalBmp, 0, 0);
                    //Set the Color of the Watermark text.
                    Brush brush = new SolidBrush(Color.Green);

                    //Set the Font and its size.
                    Font font = new System.Drawing.Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel);

                    //Determine the size of the Watermark text.
                    SizeF textSize = new SizeF();
                    textSize = grp.MeasureString(DiaryNo, font);
                    //Position the text and draw it on the image.
                    Point Diaryposition = new Point((tempBitmap.Width - ((int)textSize.Width + 100)), (tempBitmap.Height - ((int)textSize.Height + 70)));
                    grp.DrawString(DiaryNo, font, brush, Diaryposition);

                    Point Dateposition = new Point((tempBitmap.Width - ((int)textSize.Width + 100)), (tempBitmap.Height - ((int)textSize.Height + 50)));
                    grp.DrawString(DiaryDate, font, brush, Dateposition);

                    Point Timeposition = new Point((tempBitmap.Width - ((int)textSize.Width + 100)), (tempBitmap.Height - ((int)textSize.Height + 30)));
                    grp.DrawString(DiaryTime, font, brush, Timeposition);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        //Save the Watermarked image to the MemoryStream.
                        tempBitmap.Save(memoryStream, ImageFormat.Png);
                        memoryStream.Position = 0;

                        //Start file download.
                        //Response.Clear();
                        //Response.ContentType = "image/png";
                        //Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);

                        //Write the MemoryStream to the Response.
                        // memoryStream.WriteTo(Response.OutputStream);
                        FileStream file = new FileStream(Server.MapPath("~//contents//" + fileName), FileMode.Create, FileAccess.Write);
                        memoryStream.WriteTo(file);
                        file.Close();
                        memoryStream.Close();
                        //Response.Flush();
                        //Response.Close();
                        //Response.End();
                    }
                }
            }
            return 0;
        }
    }
}