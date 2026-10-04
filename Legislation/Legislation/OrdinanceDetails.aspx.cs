using LegisBIZ;
using LegisEntities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;

namespace Legislation
{
    public partial class OrdinanceDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCombos();
                BindOrdinance();
                BindDocumentsLV();
            }

        }
        public void BindCombos()
        {
            List<AssemblySessions> assemblySessions = new LegislationBiz().GetAssemblySessions();

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
            List<OrdinanceStatuses> ordinanceStatuses = new LegislationBiz().GetOrdinanceStatuses();

            if (ordinanceStatuses != null)
            {
                foreach (OrdinanceStatuses row in ordinanceStatuses)
                {
                    ListItem li = new ListItem();
                    li.Text = row.OrdinanceStatus.ToString();
                    li.Value = row.OrdinanceStatusId.ToString();
                    StatusDDL.Items.Add(li);
                }
            }

            List<ParliamentaryYears> parliamentaryYears = new LegislationBiz().GetParliamentaryYears();

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
        }
        public void UpdateOrdinance()
        {
            int id = 0;
            int PreviousStatusId = Convert.ToInt32(HidStatusId.Value);
            id = Convert.ToInt32(Request.QueryString["Id"]);
            Ordinances ordinance = new Ordinances();
            ordinance.OrdinanceId = id;
            ordinance.ParliamentaryYearsId = Convert.ToInt32(ParliamentaryYearDDL.SelectedValue);
            ordinance.OrdinanceStatusId = Convert.ToInt32(StatusDDL.SelectedValue);

            ordinance.AssemblySessionsId = Convert.ToInt32(AssemblySessionDDL.SelectedValue);
            ordinance.Title = Convert.ToString(TitleTxt.Text);
            //ordinance.Remarks = Convert.ToString(Remarks.Text);
            ordinance.DateOfPromulgation = Convert.ToDateTime(DateOfPromulgationTxt.Text);
            ordinance.StatusDate = Convert.ToDateTime(StatusDateTxt.Text);
            ordinance.DateOfLaying = Convert.ToDateTime(LayingDateTxt.Text);
            ordinance.Remarks= Convert.ToString(RemarksTxt.Value);
            if (StatusDDL.SelectedItem.Value != HidStatusId.Value)
            {
                OrdinanceStatusHistory sh = new OrdinanceStatusHistory();
                sh.OrdinanceId = ordinance.OrdinanceId;
                sh.OrdinanceStatusesId = ordinance.OrdinanceStatusId;
                sh.StatusDate = ParseDate(StatusDateTxt.Text); //DateTime.ParseExact(.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); 
                new LegislationBiz().InsertOrdinanceStatusHistory(sh);
            }
            new LegislationBiz().UpdateOrdinance(ordinance);
            if (id != 0)
                Response.Redirect("~/OrdinanceDetails.aspx?Id=" + id);
        }
        public string GetDate(DateTime date)
        {
            if (date < Convert.ToDateTime("01/01/1900"))
                return "";
            else
                return date.ToShortDateString();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UpdateOrdinance();
        }
        public void BindStatusHistory(int OrdinanceId)
        {
            List<OrdinanceStatusHistory> OrdinanceStatusHistory = new List<OrdinanceStatusHistory>();
            OrdinanceStatusHistory = new LegislationBiz().GetOrdinanceStatusHistory(OrdinanceId);
            OrdinanceStatusHistoryLV.DataSource = OrdinanceStatusHistory;
            OrdinanceStatusHistoryLV.DataBind();
        }
        public DateTime ParseDate(string dateTime)
        {
            return Convert.ToDateTime(dateTime, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
        }
        protected void BindOrdinance()
        {
            int OrdinanceId= Convert.ToInt32(Request.QueryString["Id"]);
            Ordinances ordinance = null;
            if (OrdinanceId != 0)
            {
                ordinance = new Ordinances();
                ordinance = new LegislationBiz().GetOrdinance(OrdinanceId);
                if (ordinance != null)
                {
                    ParliamentaryYearDDL.SelectedValue = ordinance.ParliamentaryYearsId.ToString();
                    StatusDDL.SelectedValue= ordinance.OrdinanceStatusId.ToString();
                    HidStatusId.Value = ordinance.OrdinanceStatusId.ToString();
                    StatusDateTxt.Text = GetDate(ordinance.StatusDate);
                    TitleTxt.Text = ordinance.Title.ToString();
                    LayingDateTxt.Text = GetDate(ordinance.DateOfLaying);
                    DateOfPromulgationTxt.Text = GetDate(ordinance.DateOfPromulgation);
                    AssemblySessionDDL.SelectedValue = ordinance.AssemblySessionsId.ToString();
                    RemarksTxt.Value = ordinance.Remarks;
                }
                BindStatusHistory(OrdinanceId);
            }
        }

        protected void BindDocumentsLV()
        {
            int OrdinanceId = Convert.ToInt32(Request.QueryString["Id"]);
            List<OrdinanceDocuments> drivers = new LegislationBiz().GetOrdinancelDocuments(OrdinanceId);
            DriversLV.DataSource = drivers;
            DriversLV.DataBind();

        }
        protected void UploadBtn_Click(object sender, EventArgs e)
        {
            int DocumentId = new LegislationBiz().GetPk("ORDINANCE_DOCUMENTS", "ORDINANCE_DOCUMENTS_ID");
            int BillId = Convert.ToInt32(Request.QueryString["Id"]);
            errorlbl.Text = "";
            OrdinanceDocuments itb = new OrdinanceDocuments();
            itb.OrdinancesId = BillId;
            itb.OrdinanceDocumentsId = DocumentId;
            itb.Description = DocumentDescTxt.Text;
            itb.AttachmentDate = ParseDate(DocumentDateTxt.Text);
            if (BillDocumentFileUpload.HasFile)
            {
                string strname = BillDocumentFileUpload.FileName.ToString();
                //string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
                FileInfo fi = new FileInfo(strname);
                string ext = fi.Extension;
                string filename = "ORD-" + itb.OrdinancesId + "-" + itb.OrdinanceDocumentsId + ext;
                BillDocumentFileUpload.PostedFile.SaveAs(Server.MapPath("~//Contents//Ordinances//") + filename);
                itb.DocumentUrl = "./contents/Ordinances/" + filename;
                new LegislationBiz().InsertOrdinanceDocument(itb);


            }
            else
                errorlbl.Text = " Please select document";
            BindDocumentsLV();
        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField HidDocumentId = (HiddenField)DriversLV.Items[e.ItemIndex].FindControl("HidDocumentId");
            int DocumentId = Convert.ToInt32(HidDocumentId.Value);
            OrdinanceDocuments ordinanceDocuments = new LegislationBiz().GetOrdinanceDocument(DocumentId);
            File.Delete(Server.MapPath(ordinanceDocuments.DocumentUrl));
            new LegislationBiz().DeleteOrdinanceDocument(DocumentId);
            BindDocumentsLV();
        }
    }
}