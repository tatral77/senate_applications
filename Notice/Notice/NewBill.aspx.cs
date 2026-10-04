using Entities;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Web;
using BIZ;
using LegisEntities;
using System.Drawing;
using System.Drawing.Imaging;
using Notice.Utilities;

namespace Notice
{
    public partial class NewBill : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //NoticeDocumentDate.Text = DateTime.Now.ToShortDateString();
                // BillDocumentDate.Text = DateTime.Now.ToShortDateString();
                BindCombos();
            }
        }
        public void BindCombos()
        {
            List<AssemblySessions> assemblySessions = new AdministrationBiz().GetAssemblySessions();

            if (assemblySessions != null)
            {
                List<AssemblySessions> sorted = assemblySessions;
                foreach (AssemblySessions row in sorted)
                {
                    ListItem li = new ListItem();
                    li.Text = row.SessionNumber.ToString();
                    li.Value = row.AssemblySessionsId.ToString();
                    AssemblySessionDDL.Items.Add(li);
                }
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
            if (QCats != null)
            {
                foreach (BillCategories row in QCats)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.BillCategoriesId.ToString();
                    BillCategoryDDL.Items.Add(li);
                }
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
            NoticedateTxt.Text = FormInput.FormatDate(DateTime.Now);
        }
        public void InsertBill()
        {
            int userid = 0;
            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                userid = Convert.ToInt32(userInfo["userid"]);
            }
            int id = 0;
            id = new BillBiz().GetPk("NOTICE_BILLS", "BILLS_ID");
            Bills bill = new Bills();
            bill.InsertedBy = userid;
            bill.ParliamentaryYearId = Convert.ToInt32(ParliamentaryYearDDL.SelectedValue);
            bill.FileNumber = Convert.ToString(FileNumberTxt.Text);
            bill.NoticeDiaryDate = ParseDate(NoticedateTxt.Text);// //DateTime.ParseExact(NoticedateTxt.Text, "dd/MM/yyyy", null);
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
            new BillBiz().InsertBill(bill);
            if (FileUpload2.HasFile)
            {
                string NoticeDiaryNo = " Notice Diary No.: " + id.ToString();
                string NoticeDiaryDate = " Notice Diary Date: " + NoticedateTxt.Text;
                //string DiaryTime = " Notice Diary Time: " + Convert.ToDateTime(NoticeDiaryTimeTxt.Text).ToString("hh:mm tt");
                string NoticeTextToAdd = NoticeDiaryNo + " " + NoticeDiaryDate;
                string Noticestrname = FileUpload2.FileName.ToString();
                FileInfo Noticefi = new FileInfo(Noticestrname);
                string Noticeext = Noticefi.Extension;
                string Noticefilename = id + Noticeext;
                string NoticeFilePath = Server.MapPath("~//contents//temp//Notice_" + Noticefilename);
                if (Noticeext.Equals(".pdf"))
                {
                    string filePath = Server.MapPath("~//contents//temp//Notice_" + Noticefilename);
                    FileUpload2.SaveAs(filePath);
                    Utils.AddTextToPdf(NoticeFilePath, Server.MapPath("~//contents//bills//Notice_" + Noticefilename), NoticeTextToAdd);
                }
                else
                {
                    AddWaterMark(id, Noticefilename);
                }
                string Noticeurl = "./contents/bills/Notice_" + Noticefilename;
                bill.NoticeFile = Noticeurl;
            }
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
                    AddWaterMark(id,filename);
                }
                string url = "./contents/bills/" + filename;
                bill.BillFile = url;
                new BillBiz().InsertBillFile(url, id);
            }
            if (id != 0)
                Response.Redirect("~/BillDetails.aspx?Id=" + id);
        }
        protected int AddWaterMark(int billid,string filename)
        {
            string DiaryNo = "Notice Diary No.: " + billid;
            string DiaryDate = "Notice Diary Date: " + NoticedateTxt.Text;
            //string DiaryTime = "Notice Diary Time: " + Convert.ToDateTime(NoticeDiaryTimeTxt.Text).ToString("hh:mm tt");

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
                        FileStream file = new FileStream(Server.MapPath("~//contents//bills//" + fileName), FileMode.Create, FileAccess.Write);
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
            InsertBill();
        }
    }
}
