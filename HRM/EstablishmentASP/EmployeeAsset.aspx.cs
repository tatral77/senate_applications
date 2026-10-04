using EstablishmentBIZ;
using EstablishmentENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstablishmentASP
{
    public partial class EmployeeAsset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                BindAssetLv();
            }

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
            AssetLv.EditIndex = -1;
            AssetLv.InsertItemPosition = InsertItemPosition.None;
            AssetLv.SelectedIndex = -1;

            e.Cancel = true;

            BindAssetLv();
        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {

            AssetLv.SelectedIndex = -1;
            AssetLv.EditIndex = -1;
            AssetLv.InsertItemPosition = InsertItemPosition.FirstItem;
            BindAssetLv();

        }
        protected void BindAssetLv()
        {
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            List<EmpAssets> AssetesList = new EmployeeHandler().GetEmpAsset(empval);
            AssetLv.DataSource = AssetesList;
            AssetLv.DataBind();

        }

        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            AssetLv.InsertItemPosition = InsertItemPosition.None;
            AssetLv.SelectedIndex = -1;
            AssetLv.EditIndex = e.NewEditIndex;
            BindAssetLv();
            e.Cancel = true;


        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {


            if (AssetLv.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList PostDDL = e.Item.FindControl("PostDDL") as DropDownList;
                HiddenField PostId = (e.Item.FindControl("HidPostId") as HiddenField);
                PostDDL.SelectedValue = PostId.Value.ToString();

              

                DropDownList BPSDDL = e.Item.FindControl("BPSDDL") as DropDownList;
                HiddenField BPSID = (e.Item.FindControl("HidBPSID") as HiddenField);
                BPSDDL.SelectedValue = BPSID.Value.ToString();



                CheckBox SubmittedCB = e.Item.FindControl("SubmittedCB") as CheckBox;
                if (SubmittedCB != null)
                {
                    HiddenField IsSubmitted = (e.Item.FindControl("HidSubmitted") as HiddenField);
                    if (Convert.ToInt32(IsSubmitted.Value) == 1)
                        SubmittedCB.Checked = true;
                    else
                        SubmittedCB.Checked = false;
                }
            }
        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField AssetId = (HiddenField)AssetLv.Items[e.ItemIndex].FindControl("HidAssetId");
            int Assetid = Convert.ToInt32(AssetId.Value);
            new EmployeeHandler().DeleteEmpAsset(Assetid);
            BindAssetLv();
        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }
        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            DropDownList PostId = AssetLv.InsertItem.FindControl("PostDDL") as DropDownList;
            DropDownList BPSID = AssetLv.InsertItem.FindControl("BPSDDL") as DropDownList;
           TextBox YearTxt = AssetLv.InsertItem.FindControl("AssetYearTxt") as TextBox;
            CheckBox Submitted = (CheckBox)AssetLv.InsertItem.FindControl("SubmittedCB");
            EmpAssets eh = new EmpAssets();
            eh.SystemUserId = empval; ;
            eh.PostId = Convert.ToInt32(PostId.SelectedItem.Value);
            eh.BPSID = Convert.ToInt32(BPSID.SelectedItem.Value);
            eh.AssetYear = Convert.ToInt32(YearTxt.Text);
            eh.IsSubmitted = (Submitted.Checked == true) ? 1 : 0;
            new EmployeeHandler().InsertEmpAsset(eh);
            AssetLv.EditIndex = -1;
            AssetLv.InsertItemPosition = InsertItemPosition.None;
            AssetLv.SelectedIndex = -1;
            e.Cancel = true;
            BindAssetLv();
            //Response.Redirect("EmployeeAsset.aspx?EmpId" + empval);


        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField AssetId = (HiddenField)AssetLv.EditItem.FindControl("HidAssetId");
            DropDownList PostId = AssetLv.EditItem.FindControl("PostDDL") as DropDownList;
            DropDownList BPSID = AssetLv.EditItem.FindControl("BPSDDL") as DropDownList;
            TextBox YearTxt = AssetLv.EditItem.FindControl("AssetYearTxt") as TextBox;
            CheckBox Submitted = (CheckBox)AssetLv.EditItem.FindControl("SubmittedCB");
            EmpAssets eh = new EmpAssets();
            eh.EmpAssetId = Convert.ToInt32(AssetId.Value);
            eh.PostId = Convert.ToInt32(PostId.SelectedItem.Value);
            eh.BPSID = Convert.ToInt32(BPSID.SelectedItem.Value);
            eh.AssetYear = Convert.ToInt32(YearTxt.Text);
            eh.IsSubmitted = (Submitted.Checked == true) ? 1 : 0;
            new EmployeeHandler().UpdateEmpAsset(eh);
            AssetLv.EditIndex = -1;
            BindAssetLv();
            AssetLv.InsertItemPosition = InsertItemPosition.None;
            AssetLv.SelectedIndex = -1;
            e.Cancel = true;
        }


        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList designation = new DropDownList();
            designation = (e.Item.FindControl("PostDDL") as DropDownList);
            if (designation != null)
            {
                designation.Items.Add(new ListItem("Select", "0"));
                List<Post> pt = new AdministrationBIZ().GetActivePosts();

                foreach (Post row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.PostID.ToString();
                    cy.Text = row.Description.ToString();
                    designation.Items.Add(cy);
                }
            }


            DropDownList bps = new DropDownList();
            bps = (e.Item.FindControl("BPSDDL") as DropDownList);
            if (bps != null)
            {

                bps.Items.Add(new ListItem("Select", "0"));

                List<BPS> bpslist = new AdministrationBIZ().GetAllBPS();
                foreach (BPS row in bpslist)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.BpsId.ToString();
                    bps.Items.Add(li);
                }
            }
          

        }
    }
}