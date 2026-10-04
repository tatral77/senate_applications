using Entities;
using ManBIZ;
using ManEntities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class QuestionDocuments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindListView();
            }
        }
        protected void BindListView()
        {
            int QuestionId = Convert.ToInt32(Request.QueryString["QuestionsId"]);
            List<BusinessDocuments> businessDocuments = new QuestionBiz().GetBusinessDocuments(QuestionId);
            ListView1.DataSource = businessDocuments;
            ListView1.DataBind();
        }
        public string GetUserName(int UserId)
        {
            User user = new ManBiz().GetUser(UserId);
            if (user != null)
            {
                return user.FullName;
            }
            return "";
        }
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            ListView1.InsertItemPosition = InsertItemPosition.None;
            ListView1.SelectedIndex = -1;
            ListView1.EditIndex = e.NewEditIndex;
            BindListView();
            e.Cancel = true;


        }
        //protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        //{
        //    (ListView1.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        //    this.bindListView1();
        //}
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (ListView1.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList IsListedDDL = e.Item.FindControl("IsListedDDL") as DropDownList;
                HiddenField HidIsListed = (e.Item.FindControl("HidIsListed") as HiddenField);
                IsListedDDL.SelectedValue = HidIsListed.Value.ToString();
            }
        }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            ListView1.SelectedIndex = -1;
            BindListView();
            e.Cancel = true;
        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {

            int QuestionId = Convert.ToInt32(Request.QueryString["QuestionsId"]);
            BusinessDocuments itb = new BusinessDocuments();
            itb.BusinessId = QuestionId;
            itb.Description = DriverDesc.Text;
            itb.IsListed = Convert.ToInt32(IsListedDDL.SelectedValue);
            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                itb.InsertedById = Convert.ToInt32(userInfo["userid"]);
            }
            if (DocumentUpload.HasFile)
            {
               
                string strname = DocumentUpload.FileName.ToString();
                //string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
                FileInfo fi = new FileInfo(strname);
                string ext = fi.Extension;
                string filename = Guid.NewGuid().ToString() + ext;
                DocumentUpload.PostedFile.SaveAs(Server.MapPath("~//contents//QuestionFiles//") + filename);
                itb.DocumentUrl = filename;
                new QuestionBiz().InsertBusinessDocument(itb);
                Response.Redirect("QuestionDocuments.aspx?QuestionsId=" + QuestionId);

            }
            else
                errorlbl.Text = " Please select document";


        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
           
            HiddenField HidDocumentId = ListView1.EditItem.FindControl("HidDocumentId") as HiddenField;
            HiddenField HidDocumentUrl = ListView1.EditItem.FindControl("HidDocumentUrl") as HiddenField;
            FileUpload fileUpload = (FileUpload)ListView1.EditItem.FindControl("DocumentUpload");
            TextBox Description = (TextBox)ListView1.EditItem.FindControl("DescriptionTxt");
            DropDownList IsListed = (DropDownList)ListView1.EditItem.FindControl("IsListedDDL");
            BusinessDocuments ep = new BusinessDocuments();
            ep.DocumentId = Convert.ToInt32(HidDocumentId.Value);
            ep.Description = Convert.ToString(Description.Text);
            ep.IsListed = Convert.ToInt32(IsListed.SelectedItem.Value);
            if (fileUpload.HasFile)
            {

                string strname = fileUpload.FileName.ToString();
                //string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
                FileInfo fi = new FileInfo(strname);
                string ext = fi.Extension;
                string drivername = ep.DocumentId + ext;
                fileUpload.PostedFile.SaveAs(Server.MapPath("~//QuestionFiles//") + drivername);
                string url = drivername;
                ep.DocumentUrl = url;
            }
            else
                ep.DocumentUrl = HidDocumentUrl.Value;

            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                ep.UpdatedById = Convert.ToInt32(userInfo["userid"]);
            }

            new QuestionBiz().UpdateBusinessDocument(ep);
            ListView1.EditIndex = -1;
            ListView1.InsertItemPosition = InsertItemPosition.None;
            BindListView();
            e.Cancel = true;

        }

        protected void ListView1_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {

        }
    }
}