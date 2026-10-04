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
    public partial class NewMotion : System.Web.UI.Page
    {
        List<MotionMoversEnt> motionmovers = null;
        int MotionId = new MotionBiz().GetPk();
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
                NoticeDiaryNumberTxt.Text= MotionId.ToString();
                SessionTxt.Text = ASession.SessionNumber.ToString();
                HidSessionNumber.Value = ASession.AssemblySessionsId.ToString();
                NoticeDiaryDateTxt.Text = FormInput.FormatDate(DateTime.Now);
                NoticeDiaryTimeTxt.Text = DateTime.Now.ToString("HH:mm");
                MotionTxt.Value = "No English Text";
                UrduTxt.Value = "No Urdu Text";

            }
        }
        protected void BindCombos()
        {
            List<MotionTypeEnt> motiontypes = new AdministrationBiz().GetMotionTypes(1);
            foreach (MotionTypeEnt row in motiontypes)
            {
                ListItem li = new ListItem();
                li.Text = row.Description.ToString();
                li.Value = row.MotionTypeId.ToString();
                MotionTypeDDL.Items.Add(li);
            }

        }
        protected void AddNewBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NewMotion.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            MotionEnt motion = new MotionEnt();
            motion.MotionsId = MotionId;
            motion.NoticeDiaryNo = motion.MotionsId;
            motion.SessionNumber = Convert.ToInt32(HidSessionNumber.Value);
            // motion.NoticeDiaryNo = Convert.ToInt32(NoticeDiaryNoTxt.Text);
            motion.NoticeDiaryDate = FormInput.ParseDate(NoticeDiaryDateTxt.Text);
            motion.NoticeDiaryTime = Convert.ToDateTime(NoticeDiaryTimeTxt.Text);
            motion.MotionTypeId = Convert.ToInt32(MotionTypeDDL.SelectedValue);
            motion.MotionStatusId = 5;
            if (!string.IsNullOrEmpty(MotionTxt.Value))
                motion.Description = MotionTxt.Value;
            else
                motion.Description = "No English Text";
            if (!string.IsNullOrEmpty(UrduTxt.Value))
                motion.UrduText = UrduTxt.Value;
            else
                motion.UrduText = "No Urdu Text";
            // motion.Description = Convert.ToString(MotionTxt.Value);
            motion.Movers = new List<MotionMoversEnt>();
            string Movers = FormInput.ToCsv(FormInput.ParseIds(HidMemberId.Value));
            motion.Mover = Movers;
            int id = new MotionBiz().InsertMotion(motion, motionmovers);
            if (FileUpload1.HasFile)
            {
                string DiaryNo = " Notice Diary No.: " + NoticeDiaryNumberTxt.Text;
                string DiaryDate = " Notice Diary Date: " + NoticeDiaryDateTxt.Text;
                string DiaryTime = " Notice Diary Time: " + Convert.ToDateTime(NoticeDiaryTimeTxt.Text).ToString("hh:mm tt");
                string TextToAdd = DiaryNo + " " + DiaryDate + " " + DiaryTime;
                string strname = FileUpload1.FileName.ToString();
                FileInfo fi = new FileInfo(strname);
                string ext = fi.Extension;
                string filename = id + ext;
                string FilePath = Server.MapPath("~//contents//temp//" + filename);
                if (ext.Equals(".pdf"))
                {
                    string filePath = Server.MapPath("~//contents//temp//" + filename);
                    FileUpload1.SaveAs(filePath);
                    Utils.AddTextToPdf(FilePath, Server.MapPath("~//contents//motion//" + filename), TextToAdd);
                }
                else
                {
                    AddWaterMark(filename);
                }
                string url = "./contents/motion/" + filename;
                motion.MotionFile = url;
                new MotionBiz().InsertMotionFile(url, id);
            }
            Response.Redirect("~/MotionDetail.aspx?MotionId=" + id);
        }
        protected void PrintBtn_Click(object sender, EventArgs e)
        {
            // int id=InsertQuestion();
            // Response.Redirect("~/PrintQuestion.aspx?questionsId=" + id);

        }

        protected void Upload(object sender, EventArgs e)
        {
            //if (FileUpload1.HasFile)
            //{
            //    string filePath = Server.MapPath("~/Uploads/" + Path.GetFileName(FileUpload1.PostedFile.FileName));
            //    FileUpload1.SaveAs(filePath);
            //    string extractText = this.ExtractTextFromImage(filePath);
            //    MotionTxt.Value += extractText.Replace(Environment.NewLine, "<p>");
            //}
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
        protected int AddWaterMark(string filename)
        {
            string DiaryNo = "Notice Diary No.: " + NoticeDiaryNumberTxt.Text;
            string DiaryDate = "Notice Diary Date: " + NoticeDiaryDateTxt.Text;
            string DiaryTime = "Notice Diary Time: " + Convert.ToDateTime(NoticeDiaryTimeTxt.Text).ToString("hh:mm tt");

            //Get the file name.
            // string fileName = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName) + ".png";
            string fileName = filename;
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
                        FileStream file = new FileStream(Server.MapPath("~//contents//motion//" + fileName), FileMode.Create, FileAccess.Write);
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


        //    //Get the file name.
        //    // string fileName = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName) + ".png";
        //    string fileName = id + ".png";
        //    //Read the File into a Bitmap.
        //    using (Bitmap bmp = new Bitmap(FileUpload1.PostedFile.InputStream, false))
        //    {

        //        MemoryStream ms = GenerateWaterMark(bmp);


        //        //Start file download.
        //        //Response.Clear();
        //        //Response.ContentType = "image/png";
        //        //Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);

        //        //Write the MemoryStream to the Response.
        //        // memoryStream.WriteTo(Response.OutputStream);
        //        FileStream file = new FileStream(Server.MapPath("~//contents//motion//" + fileName), FileMode.Create, FileAccess.Write);
        //        ms.WriteTo(file);
        //        file.Close();
        //        ms.Close();
        //        //Response.Flush();
        //        //Response.Close();
        //        //Response.End();

        //    }
        //    return 0;
        //}

        //protected MemoryStream GenerateWaterMark(Bitmap bmp)
        //{
        //    string DiaryNo = "Notice Diary No.: " + NoticeDiaryNumberTxt.Text;
        //    string DiaryDate = "Notice Diary Date: " + NoticeDiaryDateTxt.Text;
        //    string DiaryTime = "Notice Diary Time: " + Convert.ToDateTime(NoticeDiaryTimeTxt.Text).ToString("hh:mm tt");
        //    using (Graphics grp = Graphics.FromImage(bmp))
        //    {
        //        //Set the Color of the Watermark text.
        //        Brush brush = new SolidBrush(Color.Green);

        //        //Set the Font and its size.
        //        Font font = new System.Drawing.Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel);

        //        //Determine the size of the Watermark text.
        //        SizeF textSize = new SizeF();
        //        textSize = grp.MeasureString(DiaryNo, font);
        //        //Position the text and draw it on the image.
        //        Point Diaryposition = new Point((bmp.Width - ((int)textSize.Width + 100)), (bmp.Height - ((int)textSize.Height + 70)));
        //        grp.DrawString(DiaryNo, font, brush, Diaryposition);

        //        Point Dateposition = new Point((bmp.Width - ((int)textSize.Width + 100)), (bmp.Height - ((int)textSize.Height + 50)));
        //        grp.DrawString(DiaryDate, font, brush, Dateposition);

        //        Point Timeposition = new Point((bmp.Width - ((int)textSize.Width + 100)), (bmp.Height - ((int)textSize.Height + 30)));
        //        grp.DrawString(DiaryTime, font, brush, Timeposition);

        //        using (MemoryStream memoryStream = new MemoryStream())
        //        {
        //            //Save the Watermarked image to the MemoryStream.
        //            bmp.Save(memoryStream, ImageFormat.Png);
        //            memoryStream.Position = 0;
        //            return memoryStream;
        //        }
        //    }
        //}
    }
}