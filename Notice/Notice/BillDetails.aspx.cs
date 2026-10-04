using BIZ;
using Entities;
using LegisEntities;
using Notice.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Notice
{
    public partial class BillDetails : System.Web.UI.Page
    {
        //[WebMethod]
        //public static List<string> GetEmployeeName(string empName)
        //{
        //    List<string> empResult = new List<string>();
        //    List<Member> mems = new QuestionBiz().GetMembersByName(empName);
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
                int QuestionId = Convert.ToInt32(Request.QueryString["QuestionsId"]);
                // PrintHL.NavigateUrl = "~/PrintQuestion.aspx?questionsId=" + QuestionId;
                BindBill();
            }
        }

        public void BindBill()
        {
            int BillId = Convert.ToInt32(Request.QueryString["BillsId"]);
            Bills Bill = new BillBiz().GetBill(BillId);

            if (Bill.BillCategoriesId != 0)
            {
                BillCategoryDDL.SelectedValue = Bill.BillCategoriesId.ToString();

            }
            if (Bill.AssemblySessionsId != null)
            {
                AssemblySessionDDL.SelectedValue = Bill.AssemblySessionsId.ToString();
            }
            if (Bill.BillTypeId != null)
            {
                BillTypeDDL.SelectedValue = Bill.BillTypeId.ToString();
            }
            NoticedateTxt.Text = FormInput.FormatDate(Bill.NoticeDiaryDate);
            //QuestionIDTxt.Text = question.QuestionsId.ToString();
            //if (!string.IsNullOrEmpty(question.UrduText))
            //    UrduTxt.Value = question.UrduText.ToString();
           
            //MemberNameTxt.Text = question.MoverName;
            //HidMemberId.Value = question.Mover.ToString();
            if (!string.IsNullOrEmpty(Bill.Subject))
                SubjectTxt.Value = Bill.Subject;
            if (!string.IsNullOrEmpty(Bill.BillTitle))
                BillTitleTxt.Value = Bill.BillTitle;
            string file = Bill.BillFile;
            if (Bill.BillMovers != null)
            {
                List<string> ids = new List<string>(), names = new List<string>();
                foreach (BillMovers var in Bill.BillMovers)
                {
                    ids.Add(var.SystemUsersId.ToString());
                    names.Add(Convert.ToString(var.Mover));
                }
                HidMemberId.Value = string.Join(",", ids);
                MemberNameTxt.Text = string.Join("|", names);
            }
            if (Bill.BillMinisters != null)
            {
                List<string> ids = new List<string>(), names = new List<string>();
                foreach (BillMinisters var in Bill.BillMinisters)
                {
                    ids.Add(var.MinisterId.ToString());
                    names.Add(Convert.ToString(var.MinisterName));
                }
                HidMinisterId.Value = string.Join(",", ids);
                MinisterNameTxt.Text = string.Join("|", names);
            }
            if (Bill.BillDivisions != null)
            {
                List<string> ids = new List<string>(), names = new List<string>();
                foreach (BillDivisions var in Bill.BillDivisions)
                {
                    ids.Add(var.DivisionsId.ToString());
                    names.Add(Convert.ToString(var.Division));
                }
                HidMinistryId.Value = string.Join(",", ids);
                MinistryTxt.Text = string.Join("|", names);
            }
            if (!string.IsNullOrEmpty(Bill.NoticeFile))
            {
                HyperLink2.NavigateUrl = Bill.NoticeFile + "?" + DateTime.Now.Ticks.ToString();
                HyperLink2.Text = "View File";
            }
            else
            {
                HyperLink2.Text = "No File attached";
            }
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
            List<ParliamentaryYears> parliamentaryYears = new AdministrationBiz().GetParliamentaryYears();

            if (parliamentaryYears != null)
            {
                List<ParliamentaryYears> sorted = parliamentaryYears.OrderByDescending(o => o.FromDate).ToList();
                foreach (ParliamentaryYears row in sorted)
                {
                    ListItem li = new ListItem();
                    li.Text = row.ParliamentaryYear;
                    li.Value = row.ParliamentaryYearsId.ToString();
                    ParliamentaryYearDDL.Items.Add(li);
                }
            }
            List<BillCategories> QCats = new BillBiz().GetBillCategories();
            foreach (BillCategories row in QCats)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.BillCategoriesId.ToString();
                BillCategoryDDL.Items.Add(li);
            }
            List<BillTypes> billTypes = new BillBiz().GetBillTypes();
            if (billTypes != null)
            {
                foreach (BillTypes row in billTypes)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.BillTypesId.ToString();
                    BillTypeDDL.Items.Add(li);
                }
            }
        }

        //public void BindStatusHistory(int QuestionId)
        //{
        //    List<QuestionStatusHistory> sh = new List<QuestionStatusHistory>();
        //    sh = new QuestionBiz().GetQuestionStatusHistory(QuestionId);
        //    LVStatus.DataSource = sh;
        //    LVStatus.DataBind();
        //}
        //public void BindMovementHistory(int QuestionId)
        //{
        //    List<QuestionMovementHistory> sh = new List<QuestionMovementHistory>();
        //    sh = new QuestionBiz().GetQuestionMovementHistory(QuestionId);
        //    LVMovement.DataSource = sh;
        //    LVMovement.DataBind();
        //}

        //public void BindQuestionDeferment(int QuestionId)
        //{
        //    List<DeferQuestion> sh = new List<DeferQuestion>();
        //    sh = new QuestionBiz().GetQuestionDeferment(QuestionId);
        //    DeferLv.DataSource = sh;
        //    DeferLv.DataBind();
        //}
        public string GetSession(int SessionNumber)
        {
            AssemblySessions ASession = new AssemblySessions();
            ASession = new AdministrationBiz().GetAssemblySession(SessionNumber);
            return ASession.SessionNumber.ToString();
        }
        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            //int QuestionsId = Convert.ToInt32(QuestionIDTxt.Text);
            //new QuestionBiz().DeleteQuestion(QuestionsId);
            //Response.Redirect("SearchQuestion.aspx");
        }
        protected void CategoryDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int AssemblySessionId = Convert.ToInt32(HidSessionNumber.Value);
            //int CategoryId = Convert.ToInt32(CategoryDDL.SelectedItem.Value);
        }

        protected void AddNewBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NewQuestion.aspx");
        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();

        }

        public void UpdateBill()
        {
            int userid = 0;
            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                userid = Convert.ToInt32(userInfo["userid"]);
            }
            int id =  Convert.ToInt32(Request.QueryString["BillsId"]);
            //id = new BillBiz().GetPk("NOTICE_BILLS", "BILLS_ID");
            Bills bill = new Bills();
            bill.UpdatedBy = userid;
            bill.ParliamentaryYearId = Convert.ToInt32(ParliamentaryYearDDL.SelectedValue);
            bill.FileNumber = Convert.ToString(FileNumberTxt.Text);
            bill.NoticeDiaryDate = FormInput.ParseDate(NoticedateTxt.Text);// //DateTime.ParseExact(NoticedateTxt.Text, "dd/MM/yyyy", null);
            bill.BillYear = bill.NoticeDiaryDate.Year;
            bill.BillCategoryId = Convert.ToInt32(BillCategoryDDL.SelectedValue);
            bill.HouseTypesId = 1;//1= Senate,2 = NA  Convert.ToInt32(OriginatedInDDL.SelectedValue);
                                  //bill.CommitteeId= Convert.ToInt32(CommitteeDDL.SelectedValue);
            bill.AssemblySessionsId = Convert.ToInt32(AssemblySessionDDL.SelectedValue);
            bill.BillTitle = Convert.ToString(BillTitleTxt.Value);
            bill.Subject = Convert.ToString(SubjectTxt.Value);
            bill.BillTypeId = Convert.ToInt32(BillTypeDDL.SelectedValue);
            bill.BillStatusId = 2; //Under Process
            bill.StatusDate = DateTime.Now;
            bill.BillStagesId = 1; //First Reading
            bill.IsActive = 1;
            // the picked members and ministries arrive as comma separated ids from the chip boxes
            string movers = FormInput.ToCsv(FormInput.ParseIds(HidMemberId.Value));
            if (movers != null)
                bill.MembersCSV = movers;
            string ministers = FormInput.ToCsv(FormInput.ParseIds(HidMinisterId.Value));
            if (ministers != null)
                bill.MinistersCSV = ministers;
            string ministries = FormInput.ToCsv(FormInput.ParseIds(HidMinistryId.Value));
            if (ministries != null)
                bill.DivisionsCSV = ministries;
            new BillBiz().UpdateBill(bill);
            if (FileUpload1.HasFile)
            {
                string DiaryNo = " Notice Diary No.: " + id.ToString();
                string DiaryDate = " Notice Diary Date: " + NoticedateTxt.Text;
                //string DiaryTime = " Notice Diary Time: " + Convert.ToDateTime(NoticeDiaryTimeTxt.Text).ToString("hh:mm tt");
                string TextToAdd = DiaryNo + " " + DiaryDate;
                string strname = FileUpload1.FileName.ToString();
                FileInfo fi = new FileInfo(strname);
                string ext = fi.Extension;
                string filename = id + ext;
                string FilePath = Server.MapPath("~//contents//temp//" + filename);
                if (ext.Equals(".pdf"))
                {
                    string filePath = Server.MapPath("~//contents//temp//" + filename);
                    FileUpload1.SaveAs(filePath);
                    Utils.AddTextToPdf(FilePath, Server.MapPath("~//contents//bills//" + filename), TextToAdd);
                }
                else
                {
                    AddWaterMark(id, filename,FileUpload1);
                }
                string url = "./contents/bills/" + filename;
                bill.BillFile = url;
                new BillBiz().InsertBillFile(url, id);
            }
            if (FileUpload2.HasFile)
            {
                string DiaryNo = " Notice Diary No.: " + id.ToString();
                string DiaryDate = " Notice Diary Date: " + NoticedateTxt.Text;
                //string DiaryTime = " Notice Diary Time: " + Convert.ToDateTime(NoticeDiaryTimeTxt.Text).ToString("hh:mm tt");
                string TextToAdd = DiaryNo + " " + DiaryDate;
                string strname = FileUpload2.FileName.ToString();
                FileInfo fi = new FileInfo(strname);
                string ext = fi.Extension;
                string filename = id + ext;
                string FilePath = Server.MapPath("~//contents//temp//NOTICE_" + filename);
                if (ext.Equals(".pdf"))
                {
                    string filePath = Server.MapPath("~//contents//temp//NOTICE_" + filename);
                    FileUpload2.SaveAs(filePath);
                    Utils.AddTextToPdf(FilePath, Server.MapPath("~//contents//bills//NOTICE_" + filename), TextToAdd);
                }
                else
                {
                    AddWaterMark(id, filename, FileUpload2);
                }
                string url = "./contents/bills/NOTICE_" + filename;
                bill.BillFile = url;
                new BillBiz().InsertNoticeFile(url, id);
            }
            //if (FileUpload2.HasFile)
            //{
            //    string DiaryNo = " Notice Diary No.: " + id.ToString();
            //    string DiaryDate = " Notice Diary Date: " + NoticedateTxt.Text;
            //    //string DiaryTime = " Notice Diary Time: " + Convert.ToDateTime(NoticeDiaryTimeTxt.Text).ToString("hh:mm tt");
            //    string TextToAdd = DiaryNo + " " + DiaryDate;
            //    string strname = FileUpload2.FileName.ToString();
            //    FileInfo fi = new FileInfo(strname);
            //    string ext = fi.Extension;
            //    string filename =id + ext;
            //    string FilePath = Server.MapPath("~//contents//temp//Notice_" + filename);
            //    if (ext.Equals(".pdf"))
            //    {
            //        string filePath = Server.MapPath("~//contents//temp//Notice_" + filename);
            //        FileUpload2.SaveAs(filePath);
            //        Utils.AddTextToPdf(FilePath, Server.MapPath("~//contents//bills//Notice_" + filename), TextToAdd);
            //    }
            //    else
            //    {
            //        AddWaterMark(id, filename,FileUpload2);
            //    }
            //    string url = "./contents/bills/Notice_" + filename;
            //    bill.BillFile = url;
            //    new BillBiz().InsertNoticeFile(url, id);
            //}
            if (id != 0)
                Response.Redirect("~/BillDetails.aspx?BillsId=" + id);
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

        protected int AddWaterMark(int id, string ext, FileUpload fileUpload)
        {
            string DiaryNo = "Notice Diary No.: " + id;
            string DiaryDate = "Notice Diary Date: " + NoticedateTxt.Text;
            //string DiaryTime = "Notice Diary Time: " + Convert.ToDateTime(NoticeDiaryTimeTxt.Text).ToString("hh:mm tt");

            //Get the file name.
            // string fileName = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName) + ".png";
            string fileName = id + ext;
            //Read the File into a Bitmap.

            using (Bitmap bmp = new Bitmap(fileUpload.PostedFile.InputStream, false))
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

                    //Point Timeposition = new Point((tempBitmap.Width - ((int)textSize.Width + 100)), (tempBitmap.Height - ((int)textSize.Height + 30)));
                    //grp.DrawString(DiaryTime, font, brush, Timeposition);

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


        public DateTime ParseDate(string dateTime)
        {
            return FormInput.ParseDate(dateTime);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            UpdateBill();
        }
    }
}
