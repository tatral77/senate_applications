using BIZ;
using Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Services;
using System.Web.UI.WebControls;
using Notice.Utilities;

namespace QuestionManagement
{
    public partial class MotionDetail : System.Web.UI.Page
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
            foreach (MotionTypeEnt row in motiontypes)
            {
                ListItem li = new ListItem();
                li.Text = row.Description.ToString();
                li.Value = row.MotionTypeId.ToString();
                MotionTypeDDL.Items.Add(li);
            }
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
            MotionEnt motion = new MotionEnt();
            int MotionId = Convert.ToInt32(Request.QueryString["MotionId"]);
            motion.MotionsId = MotionId;
            motion.SessionNumber = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            motion.NoticeDiaryNo = Convert.ToInt32(NoticeDiaryNoTxt.Text);
            motion.NoticeDiaryDate = FormInput.ParseDate(NoticeDiaryDateTxt.Text);
            motion.NoticeDiaryTime = Convert.ToDateTime(NoticeDiaryTimeTxt.Text);
            // motion.MotionDiaryNo = Convert.ToString(MotionDiaryNoTxt.Text);
            motion.MotionTypeId = Convert.ToInt32(MotionTypeDDL.SelectedItem.Value);
            //motion.MotionStatusId = Convert.ToInt32(MotionStatusDDL.SelectedItem.Value);
            //if (!String.IsNullOrEmpty(HouseMovingDateTxt.Text))
            //    motion.MovingHouseDate = Convert.ToDateTime(HouseMovingDateTxt.Text);
            //if (!String.IsNullOrEmpty(DiscussionDateTxt.Text))
            //    motion.DiscussionDate = Convert.ToDateTime(DiscussionDateTxt.Text);
            //if (!String.IsNullOrEmpty(RefferingDateTxt.Text))
            //    motion.RefferedScDate = Convert.ToDateTime(RefferingDateTxt.Text);
            motion.Description = Convert.ToString(MotionTxt.Value);
            motion.UrduText = Convert.ToString(UrduTxt.Value);
            string Movers = FormInput.ToCsv(FormInput.ParseIds(HidMemberId.Value));
            motion.Mover = Movers;
            if (FileUpload1.HasFile)
            {
                string DiaryNo = " Notice Diary No.: " + NoticeDiaryNoTxt.Text;
                string DiaryDate = " Notice Diary Date: " + NoticeDiaryDateTxt.Text;
                string DiaryTime = " Notice Diary Time: " + Convert.ToDateTime(NoticeDiaryTimeTxt.Text).ToString("hh:mm tt");
                string TextToAdd = DiaryNo +" "+ DiaryDate + " " + DiaryTime;
                string strname = FileUpload1.FileName.ToString();
                //string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
                FileInfo fi = new FileInfo(strname);
                string ext = fi.Extension;
                string filename = motion.MotionsId + ext;
                //string FilePath = FileUpload1.FileName;// System.IO.Path.GetFullPath(FileUpload1.FileName);
                string FilePath = Server.MapPath("~//contents//temp//" + filename);
                string url = "./contents/motion/" + filename;
                if (ext.Equals(".pdf"))
                {
                    url = "./contents/motion/" + filename;
                    string filePath = Server.MapPath("~//contents//temp//" + filename);
                    FileUpload1.SaveAs(filePath);
                    Utils.AddTextToPdf(FilePath, Server.MapPath("~//contents//motion//" + filename), TextToAdd);
                }
                else
                {
                    AddWaterMark(motion.MotionsId);
                }
              
                motion.MotionFile = url;
                new MotionBiz().InsertMotionFile(url, motion.MotionsId);
            }
            else if (!string.IsNullOrEmpty(HidMotionFile.Value))
            {
                motion.MotionFile = HidMotionFile.Value;
            }
            new MotionBiz().UpdateMotion(motion);
            Response.Redirect("~/MotionDetail.aspx?MotionId=" + MotionId);

        }
        //protected int AddWaterMark(int id)
        //{


        //    //Get the file name.
        //    // string fileName = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName) + ".png";
        //    string fileName = id + ".png";
        //    //Read the File into a Bitmap.
        //    using (Bitmap bmp = new Bitmap(FileUpload1.PostedFile.InputStream, false))
        //    {

        //        AddWaterMark(id);


        //        //Start file download.
        //        //Response.Clear();
        //        //Response.ContentType = "image/png";
        //        //Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);

        //        //Write the MemoryStream to the Response.
        //        // memoryStream.WriteTo(Response.OutputStream);
        //        //FileStream file = new FileStream(Server.MapPath("~//contents//motion//" + fileName), FileMode.Create, FileAccess.Write);
        //        //ms.WriteTo(file);
        //        //file.Close();
        //        //ms.Close();
        //        //Response.Flush();
        //        //Response.Close();
        //        //Response.End();

        //    }
        //    return 0;
        //}
        protected int AddWaterMark(int id)
        {
            string DiaryNo = "Notice Diary No.: " + NoticeDiaryNoTxt.Text;
            string DiaryDate = "Notice Diary Date: " + NoticeDiaryDateTxt.Text;
            string DiaryTime = "Notice Diary Time: " + Convert.ToDateTime(NoticeDiaryTimeTxt.Text).ToString("hh:mm tt");

            //Get the file name.
            string strname = FileUpload1.FileName.ToString();
            //string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
            FileInfo fi = new FileInfo(strname);
            string ext = fi.Extension;
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
        protected MemoryStream GenerateWaterMark(Bitmap bmp)
        {
            string DiaryNo = "Notice Diary No.: " + NoticeDiaryNoTxt.Text;
            string DiaryDate = "Notice Diary Date: " + NoticeDiaryDateTxt.Text;
            string DiaryTime = "Notice Diary Time: " + Convert.ToDateTime(NoticeDiaryTimeTxt.Text).ToString("hh:mm tt");
            using (Graphics grp = Graphics.FromImage(bmp))
            {
                //Set the Color of the Watermark text.
                Brush brush = new SolidBrush(Color.Green);

                //Set the Font and its size.
                Font font = new System.Drawing.Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel);

                //Determine the size of the Watermark text.
                SizeF textSize = new SizeF();
                textSize = grp.MeasureString(DiaryNo, font);
                //Position the text and draw it on the image.
                Point Diaryposition = new Point((bmp.Width - ((int)textSize.Width + 100)), (bmp.Height - ((int)textSize.Height + 70)));
                grp.DrawString(DiaryNo, font, brush, Diaryposition);

                Point Dateposition = new Point((bmp.Width - ((int)textSize.Width + 100)), (bmp.Height - ((int)textSize.Height + 50)));
                grp.DrawString(DiaryDate, font, brush, Dateposition);

                Point Timeposition = new Point((bmp.Width - ((int)textSize.Width + 100)), (bmp.Height - ((int)textSize.Height + 30)));
                grp.DrawString(DiaryTime, font, brush, Timeposition);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    //Save the Watermarked image to the MemoryStream.
                    bmp.Save(memoryStream, ImageFormat.Png);
                    memoryStream.Position = 0;
                    return memoryStream;
                }
            }
        }
        protected void PrintBtn_Click(object sender, EventArgs e)
        {
            // int id=InsertQuestion();
            // Response.Redirect("~/PrintQuestion.aspx?questionsId=" + id);

        }

        protected void BindFields()
        {
            MotionEnt motion = new MotionEnt();
            int MotionId = Convert.ToInt32(Request.QueryString["MotionId"]);
            motion = new MotionBiz().GetMotion(MotionId);
            // MotionIDTxt.Text = Convert.ToString(motion.MotionsId);
            //HidSessionNumber.Value = Convert.ToString(motion.SessionNumber);
            //SessionTxt.Text = Convert.ToString(motion.SessionDesc);
            SessionDDL.SelectedValue = Convert.ToString(motion.SessionNumber);
            NoticeDiaryNoTxt.Text = Convert.ToString(motion.NoticeDiaryNo);
            NoticeDiaryDateTxt.Text = FormInput.FormatDate(motion.NoticeDiaryDate);
            NoticeDiaryTimeTxt.Text = motion.NoticeDiaryTime.ToString("HH:mm");
            //MotionDiaryNoTxt.Text = motion.MotionDiaryNo.ToString();
            MotionTypeDDL.SelectedValue = motion.MotionTypeId.ToString();
            //MotionStatusDDL.SelectedValue = motion.MotionStatusId.ToString();
            //HouseMovingDateTxt.Text = (motion.MovingHouseDate < Convert.ToDateTime("01/01/1900")) ? "" : motion.MovingHouseDate.ToShortDateString();
            //DiscussionDateTxt.Text = (motion.DiscussionDate < Convert.ToDateTime("01/01/1900")) ? "" : motion.DiscussionDate.ToShortDateString();
            //RefferingDateTxt.Text = (motion.RefferedScDate < Convert.ToDateTime("01/01/1900")) ? "" : motion.RefferedScDate.ToShortDateString();
            MotionTxt.Value = motion.Description.ToString();
            UrduTxt.Value = motion.UrduText;
            string file = motion.MotionFile;
            if (!string.IsNullOrEmpty(file))
            {
                HyperLink1.NavigateUrl = file + "?" + DateTime.Now.Ticks.ToString();
                HidMotionFile.Value = file;
                HyperLink1.Text = "View File";
            }
            else
            {
                HyperLink1.Text = "No File attached";
            }
            PrintHL.NavigateUrl = "~/PrintMotion.aspx?MotionId=" + MotionId;
            if (motion.Movers != null)
            {
                List<string> moverIds = new List<string>();
                List<string> moverNames = new List<string>();
                foreach (MotionMoversEnt movers in motion.Movers)
                {
                    moverIds.Add(movers.MotionMoversId.ToString());
                    moverNames.Add(Convert.ToString(movers.MoverName));
                }
                HidMemberId.Value = string.Join(",", moverIds);
                MemberNameTxt.Text = string.Join("|", moverNames);
            }

        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            int MotionId = Convert.ToInt32(Request.QueryString["MotionId"]);
          //  new NoticeBiz().De
        }
    }
}