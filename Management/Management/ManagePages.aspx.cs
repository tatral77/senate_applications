using BIZ;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Management
{
    public partial class ManagePages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpCookie Pageinfo = Request.Cookies["loginstatus"];
            //if (Pageinfo != null)
            //{
            //    string Page = Pageinfo.Value;
            //    if (Page.Equals("entry") == false)
            //        Response.Redirect("~/Login.aspx");
            //}
            //else
            //{
            //    Response.Redirect("~/Login.aspx");
            //}
            if (!IsPostBack)
            {

                BindPageLv();
            }

        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
           


        }

        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
        }

        public string GetStatus(int StatusId)
        {
            if (StatusId == 1)
                return "Yes";
            else
                return "No";
        }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            PageLv.EditIndex = -1;
            PageLv.InsertItemPosition = InsertItemPosition.None;
            PageLv.SelectedIndex = -1;
            e.Cancel = true;
            BindPageLv();
        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {
            PageLv.SelectedIndex = -1;
            PageLv.EditIndex = -1;
            PageLv.InsertItemPosition = InsertItemPosition.FirstItem;
            BindPageLv();

        }
        protected void BindPageLv()
        {
            int ApplicationId = Convert.ToInt32(Request.QueryString["Id"]);
            List<ApplicationPages> PageesList = new ManagementBiz().GetPages(ApplicationId);
            PageLv.DataSource = PageesList;
            PageLv.DataBind();

        }

        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            PageLv.InsertItemPosition = InsertItemPosition.None;
            PageLv.SelectedIndex = -1;
            PageLv.EditIndex = e.NewEditIndex;
            BindPageLv();
            e.Cancel = true;


        }

        //protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        //{
        //    HiddenField PageId = (HiddenField)PageLv.Items[e.ItemIndex].FindControl("HiddenField1");
        //    int Pageid = Convert.ToInt32(PageId.Value);
        //    new AdministrationBIZ().DeletePage(Pageid);
        //    BindPageLv();
        //}
        //protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        //{
        //    PageLv.EditIndex = -1;
        //    PageLv.InsertItemPosition = InsertItemPosition.None;
        //    PageLv.SelectedIndex = -1;

        //    BindPageLv();
        //    e.Cancel = true;
        //}

        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int ApplicationId = Convert.ToInt32(Request.QueryString["Id"]);
            TextBox PageTitleTxt = PageLv.InsertItem.FindControl("PageTitleTxt") as TextBox;
            TextBox UrlTxt = PageLv.InsertItem.FindControl("UrlTxt") as TextBox;
            TextBox InnerFunctionTxt = PageLv.InsertItem.FindControl("InnerFunctionTxt") as TextBox;
            TextBox InnerCssTxt = PageLv.InsertItem.FindControl("InnerCssTxt") as TextBox;
            ApplicationPages b = new ApplicationPages();
            b.PageTitle = Convert.ToString(PageTitleTxt.Text);
            b.Url = Convert.ToString(UrlTxt.Text);
            b.ApplicationId = ApplicationId;
            b.InnerFunction = InnerFunctionTxt.Text;
            b.InnerCss = InnerCssTxt.Text;
            new ManagementBiz().InsertPage(b);
            PageLv.EditIndex = -1;
            PageLv.InsertItemPosition = InsertItemPosition.None;
            BindPageLv();
            e.Cancel = true;
            Response.Redirect("ManagePages.aspx?Id=" + ApplicationId);

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField PageId = PageLv.EditItem.FindControl("HidPageId") as HiddenField;
            TextBox PageTitleTxt = PageLv.EditItem.FindControl("PageTitleTxt") as TextBox;
            TextBox UrlTxt = PageLv.EditItem.FindControl("UrlTxt") as TextBox;
            TextBox InnerFunctionTxt = PageLv.EditItem.FindControl("InnerFunctionTxt") as TextBox;
            TextBox InnerCssTxt = PageLv.EditItem.FindControl("InnerCssTxt") as TextBox;
            ApplicationPages b = new ApplicationPages();
            b.PageId = Convert.ToInt32(PageId.Value);
            b.PageTitle = Convert.ToString(PageTitleTxt.Text);
            b.Url = Convert.ToString(UrlTxt.Text);
            b.InnerFunction = InnerFunctionTxt.Text;
            b.InnerCss = InnerCssTxt.Text;
            new ManagementBiz().UpdatePage(b);
            PageLv.EditIndex = -1;
            BindPageLv();
            PageLv.InsertItemPosition = InsertItemPosition.None;
            PageLv.SelectedIndex = -1;
            e.Cancel = true;
        }
    }
}