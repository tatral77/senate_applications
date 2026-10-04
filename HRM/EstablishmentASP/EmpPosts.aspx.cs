using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EstablishmentENT;
using EstablishmentBIZ;

namespace EstablishmentASP
{
    public partial class EmpPosts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpCookie userinfo = Request.Cookies["loginstatus"];
            //if (userinfo != null)
            //{
            //    string role = userinfo.Value;
            //    if (role.Equals("entry") == false)
            //        Response.Redirect("~/Login.aspx");
            //}
            //else
            //{
            //    Response.Redirect("~/Login.aspx");
            //}
            if (!IsPostBack)
            {
                bindPostsLv();
            }

        }
        protected void bindPostsLv()
        {
            List<Post> Posts = new AdministrationBIZ().GetAllPosts();
            PostsLv.DataSource = Posts;
            PostsLv.DataBind();

        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {

            PostsLv.SelectedIndex = -1;
            PostsLv.EditIndex = -1;
            PostsLv.InsertItemPosition = InsertItemPosition.FirstItem;
            bindPostsLv();

        }
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            PostsLv.InsertItemPosition = InsertItemPosition.None;
            PostsLv.SelectedIndex = -1;
            PostsLv.EditIndex = e.NewEditIndex;
            bindPostsLv();
            e.Cancel = true;


        }
        protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (PostsLv.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.bindPostsLv();
        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (PostsLv.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList PostType = e.Item.FindControl("PostTypeDDL") as DropDownList;
                HiddenField HidPostTypeId = (e.Item.FindControl("HidPostTypeId") as HiddenField);
                PostType.SelectedValue = HidPostTypeId.Value.ToString();

                DropDownList PostSubType = e.Item.FindControl("GazNonGazDDL") as DropDownList;
                HiddenField HidPostSubTypeId = (e.Item.FindControl("HidGazNonGazId") as HiddenField);
                PostSubType.SelectedValue = HidPostSubTypeId.Value.ToString();

                DropDownList PostStatus = e.Item.FindControl("PostStatusDDL") as DropDownList;
                HiddenField HidPostStatusId = (e.Item.FindControl("HidPostStatusId") as HiddenField);
                PostStatus.SelectedValue = HidPostStatusId.Value.ToString();

                DropDownList IsActive = e.Item.FindControl("IsActiveDDL") as DropDownList;
                HiddenField HidIsActive = (e.Item.FindControl("HidIs_Active") as HiddenField);
                IsActive.SelectedValue = HidIsActive.Value.ToString();

           }
        }

        protected string GetStatus(int id)
        {
            if (id == 0)
                return "No";
            else
                return "Yes";
        
        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList PostStatus = new DropDownList();
            PostStatus = (e.Item.FindControl("PostStatusDDL") as DropDownList);
            if (PostStatus != null)
            {
                List<PostStatus> ps = new AdministrationBIZ().GetPostStatus();

                foreach (PostStatus row in ps)
                {
                    ListItem li = new ListItem();
                    li.Value = row.PostStatusID.ToString();
                    li.Text = row.Description.ToString();
                    PostStatus.Items.Add(li);
                }

            }
            DropDownList PostType = new DropDownList();
            PostType = (e.Item.FindControl("PostTypeDDL") as DropDownList);
            if (PostType != null)
            {
                List<PostType> pt = new AdministrationBIZ().GetPostType();

                foreach (PostType row in pt)
                {
                    ListItem ty = new ListItem();
                    ty.Value = row.PostTypeId.ToString();
                    ty.Text = row.Description.ToString();
                    PostType.Items.Add(ty);
                }

            }
            DropDownList PostSubType = new DropDownList();
            PostSubType = (e.Item.FindControl("GazNonGazDDL") as DropDownList);
            if (PostSubType != null)
            {
                List<PostSubType> pst = new AdministrationBIZ().GetPostSubType();

                foreach (PostSubType row in pst)
                {
                    ListItem lit = new ListItem();
                    lit.Value = row.PostSubTypeId.ToString();
                    lit.Text = row.Description.ToString();
                    PostSubType.Items.Add(lit);
                }

            }




        }

        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            PostsLv.EditIndex = -1;
            PostsLv.InsertItemPosition = InsertItemPosition.None;
            PostsLv.SelectedIndex = -1;
            bindPostsLv();
            e.Cancel = true;
        }


        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            // try
            //{
           
            DropDownList PostTypeId = (DropDownList)PostsLv.InsertItem.FindControl("PostTypeDDL");
            DropDownList PostSubTypeId = (DropDownList)PostsLv.InsertItem.FindControl("GazNonGazDDL");
            DropDownList PostStatusId = (DropDownList)PostsLv.InsertItem.FindControl("PostStatusDDL");
            DropDownList IsActive = (DropDownList)PostsLv.InsertItem.FindControl("IsActiveDDL");
            TextBox Description = (TextBox)PostsLv.InsertItem.FindControl("NomenclatureTxt");
            TextBox ScaleFrom = (TextBox)PostsLv.InsertItem.FindControl("ScaleFromTxt");
            TextBox ScaleTo= (TextBox)PostsLv.InsertItem.FindControl("ScaleToTxt");
            TextBox NumOfPosts = (TextBox)PostsLv.InsertItem.FindControl("NoOfPostsTxt");
            

            Post  ep = new Post();
            // if (fuControl != null && PhoneNum != null)
            // {
            ep.PostTypeId = Convert.ToInt32(PostTypeId.SelectedItem.Value);
            ep.Description = Convert.ToString(Description.Text);
            ep.GazNonGazId = Convert.ToInt32(PostSubTypeId.SelectedItem.Value);
            ep.PostStatusId = Convert.ToInt32(PostStatusId.SelectedItem.Value);
            ep.Is_active = Convert.ToInt32(IsActive.SelectedItem.Value);
            ep.ScaleFrom  = Convert.ToInt32(ScaleFrom.Text);
            ep.ScaleTo = Convert.ToInt32(ScaleTo.Text);
            ep.ScaleFrom = Convert.ToInt32(ScaleFrom.Text);
            ep.NumOfPosts = Convert.ToInt32(NumOfPosts.Text);
            new AdministrationBIZ().InsertPost(ep);
            PostsLv.EditIndex = -1;

            PostsLv.InsertItemPosition = InsertItemPosition.None;
            bindPostsLv();
            //  }
            e.Cancel = true;
            Response.Redirect("EmpPosts.aspx");

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            HiddenField PostId = PostsLv.EditItem.FindControl("HidPostId") as HiddenField;
            DropDownList PostTypeId = (DropDownList)PostsLv.EditItem.FindControl("PostTypeDDL");
            DropDownList PostSubTypeId = (DropDownList)PostsLv.EditItem.FindControl("GazNonGazDDL");
            DropDownList PostStatusId = (DropDownList)PostsLv.EditItem.FindControl("PostStatusDDL");
            DropDownList IsActive = (DropDownList)PostsLv.EditItem.FindControl("IsActiveDDL");
            TextBox Description = (TextBox)PostsLv.EditItem.FindControl("NomenclatureTxt");
            TextBox ScaleFrom = (TextBox)PostsLv.EditItem.FindControl("ScaleFromTxt");
            TextBox ScaleTo = (TextBox)PostsLv.EditItem.FindControl("ScaleToTxt");
            TextBox NumOfPosts = (TextBox)PostsLv.EditItem.FindControl("NoOfPostsTxt");


            Post ep = new Post();
            // if (fuControl != null && PhoneNum != null)
            // {
            ep.PostID = Convert.ToInt32(PostId.Value);
            ep.PostTypeId = Convert.ToInt32(PostTypeId.SelectedItem.Value);
            ep.Description = Convert.ToString(Description.Text);
            ep.GazNonGazId = Convert.ToInt32(PostSubTypeId.SelectedItem.Value);
            ep.PostStatusId = Convert.ToInt32(PostStatusId.SelectedItem.Value);
            ep.Is_active = Convert.ToInt32(IsActive.SelectedItem.Value);
            ep.ScaleFrom = Convert.ToInt32(ScaleFrom.Text);
            ep.ScaleTo = Convert.ToInt32(ScaleTo.Text);
            ep.ScaleFrom = Convert.ToInt32(ScaleFrom.Text);
            ep.NumOfPosts = Convert.ToInt32(NumOfPosts.Text);
            new AdministrationBIZ().UpdatePost(ep);
            PostsLv.EditIndex = -1;

            PostsLv.InsertItemPosition = InsertItemPosition.None;
            bindPostsLv();
            //  }
            e.Cancel = true;
        }
    }
}