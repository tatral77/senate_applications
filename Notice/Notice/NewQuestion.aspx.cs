using BIZ;
using Entities;
using Notice.Utilities;
//using MODI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace Notice
{
    
    public partial class NewQuestion : System.Web.UI.Page
    {
        int QuestionsId = new QuestionBiz().GetQuestionPk();
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
                NoticeDiaryNoTxt.Text = QuestionsId.ToString();
                SessionTxt.Text = ASession.SessionNumber.ToString();
                HidSessionNumber.Value = ASession.AssemblySessionsId.ToString();
                NoticeDiaryDateTxt.Text = FormInput.FormatDate(DateTime.Now);
                NoticeDiaryTimeTxt.Text = DateTime.Now.ToString("HH:mm");
                QuestionTxt.Value = "No English Text";
                UrduTxt.Value = "No Urdu Text";
            }
        }
        public void BindCombos()
        {
            List<QuestionCategories> QCats = new AdministrationBiz().GetQuestionCategories();
            foreach (QuestionCategories row in QCats)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.QuestionCategoriesId.ToString();
                CategoryDDL.Items.Add(li);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = 0;
            DateTime notcedate = FormInput.ParseDate(NoticeDiaryDateTxt.Text);
            if (FormInput.ParseIds(HidMemberId.Value).Count == 0)
            {
                SenatorError.Text = "Please pick the senator from the list.";
                return;
            }
            SenatorError.Text = "";
            if (notcedate > DateTime.Now || notcedate < DateTime.Now.AddDays(-30))
            {
                DateError.Text = "Notice date must within 30 days and not greater than from current date.";
            }
            else
            {
                DateError.Text = "";
                Questions question = new Questions();
                question.QuestionsId = QuestionsId;
                question.SessionNumberId = Convert.ToInt32(HidSessionNumber.Value);
                 question.NoticeDiaryNo = Convert.ToInt32(NoticeDiaryNoTxt.Text);
                question.NoticeDiaryDate = notcedate;
                DateTime noticedate = notcedate;
                DateTime dt = notcedate.Date;
                DateTime noticetime;
                if (DateTime.TryParse(NoticeDiaryTimeTxt.Text, out noticetime))
                    dt = notcedate.Date + noticetime.TimeOfDay;
                question.NoticeDiaryTime = dt;
                question.QuestionDate = noticedate;
                question.QuestionCategoriesId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
                question.QuestionStatusId = 7;// Convert.ToInt32(QuestionStatusDDL.SelectedItem.Value);
                question.QuestionStatusDate = DateTime.Now;
                question.Mover = FormInput.ParseIds(HidMemberId.Value)[0];
                if (QuestionTxt.Value == "")
                    question.QuestionText = "No English Text";
                else
                    question.QuestionText = Convert.ToString(QuestionTxt.Value);
                if (UrduTxt.Value == "")
                    question.UrduText = "No Urdu Text";
                else
                    question.UrduText = Convert.ToString(UrduTxt.Value);

                id = new QuestionBiz().InsertQuestions(question);
                Button1.Enabled = false;
                if (FileUpload1.HasFile)
                {


                    string strname = FileUpload1.FileName.ToString();
                    ////string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
                    FileInfo fi = new FileInfo(strname);
                    string ext = fi.Extension;
                    string filename = Convert.ToString(question.QuestionsId) + ext;
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

                    new QuestionBiz().InsertQuestionFile(url, id);

                    //AddWaterMark(question.QuestionsId);
                    //string strname = FileUpload1.FileName.ToString();
                    //////string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
                    //FileInfo fi = new FileInfo(strname);
                    //string ext = fi.Extension;
                    //string filename = id + ".png";
                    ////FileUpload1.PostedFile.SaveAs(Server.MapPath("~//contents//") + filename);
                    //string url = "./contents/" + filename;
                    ////question.QuestionFile = url;
                    //new QuestionBiz().InsertQuestionFile(url, id);
                }
                Response.Redirect("~/QuestionDetails.aspx?QuestionsId=" + id);
            }
        }
        protected void AddNewBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NewQuestion.aspx");
        }
        protected void Upload(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string filePath = Server.MapPath("~/Uploads/" + Path.GetFileName(FileUpload1.PostedFile.FileName));
                FileUpload1.SaveAs(filePath);
                string extractText = this.ExtractTextFromImage(filePath);
                QuestionTxt.Value += extractText.Replace(Environment.NewLine, "<p>");
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
            return null;
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


        //protected int AddWaterMark(int id)
        //{
        //    string DiaryNo = "Notice Diary No.: " + NoticeDiaryNoTxt.Text;
        //    string DiaryDate = "Notice Diary Date: " + NoticeDiaryDateTxt.Text;
        //    string DiaryTime = "Notice Diary Time: " + Convert.ToDateTime(NoticeDiaryTimeTxt.Text).ToString("hh:mm tt");

        //    //Get the file name.
        //    // string fileName = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName) + ".png";
        //    string fileName = id + ".png";
        //    //Read the File into a Bitmap.
        //    using (Bitmap bmp = new Bitmap(FileUpload1.PostedFile.InputStream, false))
        //    {
        //        using (Graphics grp = Graphics.FromImage(bmp))
        //        {
        //            //Set the Color of the Watermark text.
        //            Brush brush = new SolidBrush(Color.Green);

        //            //Set the Font and its size.
        //            Font font = new System.Drawing.Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel);

        //            //Determine the size of the Watermark text.
        //            SizeF textSize = new SizeF();
        //            textSize = grp.MeasureString(DiaryNo, font);
        //            //Position the text and draw it on the image.
        //            Point Diaryposition = new Point((bmp.Width - ((int)textSize.Width + 100)), (bmp.Height - ((int)textSize.Height + 70)));
        //            grp.DrawString(DiaryNo, font, brush, Diaryposition);

        //            Point Dateposition = new Point((bmp.Width - ((int)textSize.Width + 100)), (bmp.Height - ((int)textSize.Height + 50)));
        //            grp.DrawString(DiaryDate, font, brush, Dateposition);

        //            Point Timeposition = new Point((bmp.Width - ((int)textSize.Width + 100)), (bmp.Height - ((int)textSize.Height + 30)));
        //            grp.DrawString(DiaryTime, font, brush, Timeposition);

        //            using (MemoryStream memoryStream = new MemoryStream())
        //            {
        //                //Save the Watermarked image to the MemoryStream.
        //                bmp.Save(memoryStream, ImageFormat.Png);
        //                memoryStream.Position = 0;

        //                //Start file download.
        //                //Response.Clear();
        //                //Response.ContentType = "image/png";
        //                //Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);

        //                //Write the MemoryStream to the Response.
        //                // memoryStream.WriteTo(Response.OutputStream);
        //                FileStream file = new FileStream(Server.MapPath("~//contents//" + fileName), FileMode.Create, FileAccess.Write);
        //                memoryStream.WriteTo(file);
        //                file.Close();
        //                memoryStream.Close();
        //                //Response.Flush();
        //                //Response.Close();
        //                //Response.End();
        //            }
        //        }
        //    }
        //    return 0;
        //}
    }
}
