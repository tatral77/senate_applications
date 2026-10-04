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

namespace QuestionManagement
{
    public partial class ResolutionDetail : System.Web.UI.Page
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
            List<ResolutionTypesEnt> resolutiontypes = new ResolutionBiz().GetResolutionTypes();
            foreach (ResolutionTypesEnt row in resolutiontypes)
            {
                ListItem li = new ListItem();
                li.Text = row.Description.ToString();
                li.Value = row.ResTypesId.ToString();
                ResolutionTypeDDL.Items.Add(li);
            }
            List<ResolutionStatusesEnt> motionstatus = new ResolutionBiz().GetResolutionStatuses();
            //foreach (ResolutionStatusesEnt row in motionstatus)
            //{
            //    ListItem li = new ListItem();
            //    li.Text = row.Description.ToString();
            //    li.Value = row.ResolutionStatusesId.ToString();
            //    ResolutionStatusDDL.Items.Add(li);
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
            ResolutionEnt resolution = new ResolutionEnt();
            int ResolutionId = Convert.ToInt32(Request.QueryString["ResolutionId"]);
            resolution.ResolutionsId = ResolutionId;
            // resolution.AssemblySessionsId = Convert.ToInt32(HidSessionNumber.Value);
            resolution.AssemblySessionsId = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            resolution.NoticeDiaryNo = Convert.ToInt32(NoticeDiaryNoTxt.Text);
            resolution.NoticeDiaryDate = FormInput.ParseDate(NoticeDiaryDateTxt.Text);
            resolution.NoticeDiaryTime = FormInput.ParseDate(NoticeDiaryDateTxt.Text).Date + Convert.ToDateTime(NoticeDiaryTimeTxt.Text).TimeOfDay;
            resolution.Description = Convert.ToString(ResolutionTxt.Value);
            resolution.ResolutionTypeId = Convert.ToInt32(ResolutionTypeDDL.SelectedItem.Value);
            string Movers = FormInput.ToCsv(FormInput.ParseIds(HidMemberId.Value));
            resolution.Mover = Movers;
            if (FileUpload1.HasFile)
            {
                string DiaryNo = " Notice Diary No.: " + NoticeDiaryNoTxt.Text;
                string DiaryDate = " Notice Diary Date: " + NoticeDiaryDateTxt.Text;
                string DiaryTime = " Notice Diary Time: " + Convert.ToDateTime(NoticeDiaryTimeTxt.Text).ToString("hh:mm tt");
                string TextToAdd = DiaryNo + " " + DiaryDate + " " + DiaryTime;
                string strname = FileUpload1.FileName.ToString();
                ////string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
                FileInfo fi = new FileInfo(strname);
                string ext = fi.Extension;
                string filename = resolution.ResolutionsId + ext;
                string FilePath = Server.MapPath("~//contents//temp//" + filename);
                string url = "./contents/resolution/" + filename;
                if (ext.Equals(".pdf"))
                {
                    url = "./contents/resolution/" + filename;
                    string filePath = Server.MapPath("~//contents//temp//" + filename);
                    FileUpload1.SaveAs(filePath);
                    Utils.AddTextToPdf(FilePath, Server.MapPath("~//contents//resolution//" + filename), TextToAdd);
                }
                else
                {
                    AddWaterMark(resolution.ResolutionsId, ext);
                }
                resolution.ResolutionFile = url;
                new ResolutionBiz().InsertResolutionFile(url, resolution.ResolutionsId);
            }
            else if (!string.IsNullOrEmpty(HidResolutionFile.Value))
            {
                resolution.ResolutionFile = HidResolutionFile.Value;
            }
            new ResolutionBiz().UpdateResolution(resolution);
            Response.Redirect("~/ResolutionDetail.aspx?ResolutionId=" + resolution.ResolutionsId);

        }
        protected void PrintBtn_Click(object sender, EventArgs e)
        {
            // int id=InsertQuestion();
            // Response.Redirect("~/PrintQuestion.aspx?questionsId=" + id);

        }

        protected void BindFields()
        {
            ResolutionEnt res = new ResolutionEnt();
            int ResolutionId = Convert.ToInt32(Request.QueryString["ResolutionId"]);
            res = new ResolutionBiz().GetResolution(ResolutionId);
           // ResolutionIDTxt.Text = Convert.ToString(res.ResolutionsId);
            //HidSessionNumber.Value = Convert.ToString(res.AssemblySessionsId);
            //SessionTxt.Text = Convert.ToString(res.SessionNumber);
            SessionDDL.SelectedValue = Convert.ToString(res.AssemblySessionsId);
            NoticeDiaryNoTxt.Text = ResolutionId.ToString();
            NoticeDiaryDateTxt.Text = FormInput.FormatDate(res.NoticeDiaryDate);
            NoticeDiaryTimeTxt.Text = res.NoticeDiaryTime.ToString("HH:mm");
            //  ResolutionDiaryNoTxt.Text = res.ResolutionDiaryNo.ToString();
            //  ResolutionNoTxt.Text = res.ResolutionNumber.ToString();
            ResolutionTypeDDL.SelectedValue = res.ResolutionTypeId.ToString();
          //  ResolutionStatusDDL.SelectedValue = res.ResolutionStatusId.ToString();
            //HouseMovingDateTxt.Text = (res.MovedDate < Convert.ToDateTime("01/01/1900")) ? "" : res.MovedDate.ToShortDateString();
            //DiscussionDateTxt.Text = (res.DiscussedDate < Convert.ToDateTime("01/01/1900")) ? "" : res.DiscussedDate.ToShortDateString();
            //PassingDateTxt.Text = (res.PassedDate < Convert.ToDateTime("01/01/1900")) ? "" : res.PassedDate.ToShortDateString();
            ResolutionTxt.Value = res.Description.ToString();
            UrduTxt.Value = res.UrduText;
            PrintHL.NavigateUrl = "~/PrintResolution.aspx?ResolutionId=" + ResolutionId;
            string file = res.ResolutionFile;
            if (!string.IsNullOrEmpty(file))
            {
                HyperLink1.NavigateUrl = file + "?" + DateTime.Now.Ticks.ToString();
                HyperLink1.Text = "View File";
            }
            else
            {
                HyperLink1.Text = "No File attached";
            }
            PrintHL.NavigateUrl = "~/PrintResolution.aspx?ResolutionId=" + ResolutionId;
            if (res.Submitters != null)
            {
                List<string> moverIds = new List<string>();
                List<string> moverNames = new List<string>();
                foreach (ResolutionSubmittersEnt movers in res.Submitters)
                {
                    moverIds.Add(movers.SystemUsersId.ToString());
                    moverNames.Add(Convert.ToString(movers.MoverName));
                }
                HidMemberId.Value = string.Join(",", moverIds);
                MemberNameTxt.Text = string.Join("|", moverNames);
            }

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
                        FileStream file = new FileStream(Server.MapPath("~//contents//resolution//" + fileName), FileMode.Create, FileAccess.Write);
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