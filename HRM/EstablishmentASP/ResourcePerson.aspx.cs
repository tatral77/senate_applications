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
    public partial class ResourcePerson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int empval;
                empval = Convert.ToInt32(Request.QueryString["EmpId"]);
                bindResourseLv(empval);
            }

        }
        protected void bindResourseLv(int EmpId)
        {
            List<ResoursePerson> Eq = new EmployeeHandler().GetResourse(EmpId);
            ResoursePersonLV.DataSource = Eq;
            ResoursePersonLV.DataBind();


        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {

            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            ResoursePersonLV.SelectedIndex = -1;
            ResoursePersonLV.EditIndex = -1;
            ResoursePersonLV.InsertItemPosition = InsertItemPosition.FirstItem;
            bindResourseLv(empval);

        }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            ResoursePersonLV.EditIndex = -1;
            ResoursePersonLV.InsertItemPosition = InsertItemPosition.None;
            ResoursePersonLV.SelectedIndex = -1;
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindResourseLv(empval);
            e.Cancel = true;
        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList designation = new DropDownList();
            designation = (e.Item.FindControl("PostDDL") as DropDownList);
            if (designation != null)
            {
                //designation.Items.Add(new ListItem("Select", "0"));

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

        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
          
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
        
                ResoursePerson eh = new ResoursePerson();
                eh.SystemUsersId = empval;
                DropDownList PostDDL = ResoursePersonLV.InsertItem.FindControl("PostDDL") as DropDownList;
                DropDownList BPSDDL = ResoursePersonLV.InsertItem.FindControl("BPSDDL") as DropDownList;
                TextBox PresAs = ResoursePersonLV.InsertItem.FindControl("PresAsTxt") as TextBox;
                TextBox Details = ResoursePersonLV.InsertItem.FindControl("DetailsTxt") as TextBox;
                TextBox Station = ResoursePersonLV.InsertItem.FindControl("StationTxt") as TextBox;
                TextBox PresDate = ResoursePersonLV.InsertItem.FindControl("DateTxt") as TextBox;
               
                eh.PostId = Convert.ToInt32(PostDDL.SelectedValue);
                eh.BPSID = Convert.ToInt32(BPSDDL.SelectedItem.Value);
                eh.PresAs = Convert.ToString(PresAs.Text);
                eh.Details = Convert.ToString(Details.Text);
                eh.Station = Convert.ToString(Station.Text);
                eh.PresDate = Convert.ToDateTime(PresDate.Text);
                new EmployeeHandler().InsertEmployeeRes(eh);
                ResoursePersonLV.EditIndex = -1;
                ResoursePersonLV.InsertItemPosition = InsertItemPosition.None;
                ResoursePersonLV.SelectedIndex = -1;
                bindResourseLv(empval);
                e.Cancel = true;
            
        }
        public string GetDate(DateTime d)
        {
            return (Convert.ToString(d) == "01/01/0001 00:00:00") ? string.Empty : d.ToShortDateString();
        }
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            int empval;
            // string test = null;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            ResoursePersonLV.InsertItemPosition = InsertItemPosition.None;
            ResoursePersonLV.SelectedIndex = -1;
            ResoursePersonLV.EditIndex = e.NewEditIndex;
            bindResourseLv(empval);
            e.Cancel = true;

        }
        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (ResoursePersonLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
               
                DropDownList designation = e.Item.FindControl("PostDDL") as DropDownList;
                HiddenField DesigId = (e.Item.FindControl("HidPostId") as HiddenField);
                designation.SelectedValue = DesigId.Value.ToString();

                DropDownList BPS = e.Item.FindControl("BPSDDL") as DropDownList;
                HiddenField BrId = (e.Item.FindControl("HidBPSId") as HiddenField);
                BPS.SelectedValue = BrId.Value.ToString();
            }
        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
          
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            ResoursePerson eh = new ResoursePerson();
            eh.SystemUsersId = empval;
            HiddenField HidResId = ResoursePersonLV.EditItem.FindControl("HidResId") as HiddenField;
            DropDownList PostDDL = ResoursePersonLV.EditItem.FindControl("PostDDL") as DropDownList;
            DropDownList BPSDDL = ResoursePersonLV.EditItem.FindControl("BPSDDL") as DropDownList;
            TextBox PresAs = ResoursePersonLV.EditItem.FindControl("PresAsTxt") as TextBox;
            TextBox Details = ResoursePersonLV.EditItem.FindControl("DetailsTxt") as TextBox;
            TextBox Station = ResoursePersonLV.EditItem.FindControl("StationTxt") as TextBox;
            TextBox PresDate = ResoursePersonLV.EditItem.FindControl("DateTxt") as TextBox;
            eh.ResoursePersonId= Convert.ToInt32(HidResId.Value);
            eh.PostId = Convert.ToInt32(PostDDL.SelectedValue);
            eh.BPSID = Convert.ToInt32(BPSDDL.SelectedItem.Value);
            eh.PresAs = Convert.ToString(PresAs.Text);
            eh.Details = Convert.ToString(Details.Text);
            eh.Station = Convert.ToString(Station.Text);
            eh.PresDate = Convert.ToDateTime(PresDate.Text);
            new EmployeeHandler().UpdateEmployeeRes(eh);
            ResoursePersonLV.EditIndex = -1;
            ResoursePersonLV.InsertItemPosition = InsertItemPosition.None;
            ResoursePersonLV.SelectedIndex = -1;
            bindResourseLv(empval);
            e.Cancel = true;
            
        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
           
            HiddenField HidResId = (HiddenField)ResoursePersonLV.Items[e.ItemIndex].FindControl("HidResId");
            int ResId = Convert.ToInt32(HidResId.Value);
            new EmployeeHandler().DeleteResourse(ResId);
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindResourseLv(empval);
        }
    }
}