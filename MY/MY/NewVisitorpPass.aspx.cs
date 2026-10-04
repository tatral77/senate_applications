using Entities;
using MyBIZ;
using MyEntities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MY
{
    public partial class NewVisitorpPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Guid obj = Guid.NewGuid();
                string pk = obj.ToString();// vmsBiz().GetPK("VIS_VISITOR_PASSES", "PASS_ID");
                HidPassId.Value = pk.ToString();
               // new vmsBiz().DeleteTempVisitors(pk);
               // BindLV();
                BindCombos();
                PassDateTxt.Text = DateTime.Now.ToShortDateString();
                FromDateTxt.Text = DateTime.Now.ToShortDateString();
                ToDateTxt.Text = DateTime.Now.ToShortDateString();

                string copyFrom = Request.QueryString["CopyFrom"];
                if (!string.IsNullOrEmpty(copyFrom))
                    CopyFromPass(copyFrom);

            }
        }

        // Starts a new pass from an existing one: same purpose, type, branch, organisation, off days and visitors.
        // The dates start from today (keeping the same length of visit) and the visitors can be edited, removed or added to before saving.
        private void CopyFromPass(string sourcePassId)
        {
            int empval = 0;
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
                int.TryParse(reqCookies["SystemUsersId"], out empval);

            VisitorPasses src = new vmsBiz().GetVisitorPass(sourcePassId);
            // only the employee's own passes can be copied
            if (src == null || src.RequestedById != empval)
            {
                CopyNoticeLbl.Text = "<div class='alert alert-danger'>The pass to copy was not found.</div>";
                return;
            }

            VisitPurposeTxt.Text = src.VisitPurpose;
            if (PassTypeDDL.Items.FindByValue(src.PassTypeId.ToString()) != null)
                PassTypeDDL.SelectedValue = src.PassTypeId.ToString();
            if (BranchDDL.Items.FindByValue(src.BranchId.ToString()) != null)
                BranchDDL.SelectedValue = src.BranchId.ToString();
            if (src.Company != null)
            {
                CompanyNameTxt.Text = src.Company.CompanyName;
                HidCompanyId.Value = src.CompanyId.ToString();
            }
            SaturdayCB.Checked = src.Saturday == 1;
            SundayCB.Checked = src.Sunday == 1;

            int days = Math.Max(0, (src.ToDate.Date - src.FromDate.Date).Days);
            FromDateTxt.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            ToDateTxt.Text = DateTime.Now.AddDays(days).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            PassDateTxt.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            int copied = 0;
            if (src.Visitors != null)
            {
                foreach (Visitors v in src.Visitors)
                {
                    Visitors t = new Visitors();
                    t.VisitorName = v.VisitorName ?? "";
                    t.Cnic = v.Cnic ?? "";
                    t.Details = v.Details ?? "";
                    t.PassId = HidPassId.Value;
                    new vmsBiz().InsertTempVisitor(t);
                    copied++;
                }
            }
            BindLV();
            CopyNoticeLbl.Text = "<div class='alert alert-info'><b>Copied from pass " + Server.HtmlEncode(src.PassCode ?? "") + "</b> &mdash; " + copied +
                " visitor(s). Check the dates and purpose, add, edit or remove visitors, then save the new pass.</div>";
        }

        protected void AddVisitorBtn_Click(object sender, EventArgs e)
        {
            LV.SelectedIndex = -1;
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.FirstItem;
            BindLV();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {

        }
        #region ListView
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList PassTypesDDL = new DropDownList();
            PassTypesDDL = (e.Item.FindControl("PassTypeDDL") as DropDownList);
            if (PassTypesDDL != null)
            {
                //designation.Items.Add(new ListItem("Select", "0"));

                List<PassTypes> pt = new vmsBiz().GetPassTypes();

                foreach (PassTypes row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.PassTypeId.ToString();
                    cy.Text = row.Description.ToString();
                    PassTypesDDL.Items.Add(cy);
                }
            }
        }

        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (LV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList PassTypesDDL = e.Item.FindControl("PassTypesDDL") as DropDownList;
                HiddenField HidPassTypeId = (e.Item.FindControl("HidPassTypeId") as HiddenField);
                PassTypesDDL.SelectedValue = HidPassTypeId.Value.ToString();
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
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.None;
            LV.SelectedIndex = -1;
            e.Cancel = true;
            BindLV();
        }
        protected void BindCombos()
        {
            string BranchId = "0";
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                BranchId = reqCookies["BranchId"].ToString();
            }
            List<PassTypes> pt = new vmsBiz().GetPassTypes();
            if (pt != null)
            {
                foreach (PassTypes row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.PassTypeId.ToString();
                    cy.Text = row.Description.ToString();
                    PassTypeDDL.Items.Add(cy);
                }
            }
            //List<VehicleTypes> vt = new vmsBiz().GetVehicleTypes();
            //if (vt != null)
            //{
            //    VehicleTypeDDL.Items.Add(new ListItem
            //    {
            //        Value = "0",
            //        Text = "Select"
            //    });
            //    foreach (VehicleTypes row in vt)
            //    {
            //        ListItem vtl = new ListItem();
            //        vtl.Value = row.VehicleTypeId.ToString();
            //        vtl.Text = row.VehicleType.ToString();
            //        VehicleTypeDDL.Items.Add(vtl);
            //    }
            //}



            List<Branch> branches = new vmsBiz().GetBranches();
            if (branches != null)
            {
                ListItem temp = new ListItem();
                temp.Value = "0";
                temp.Text = "Select Branch";
                BranchDDL.Items.Add(temp);
                {
                    foreach (Branch branch in branches)
                    {
                        ListItem li = new ListItem();
                        li.Value = branch.BranchId.ToString();
                        li.Text = branch.BranchName.ToString();
                        BranchDDL.Items.Add(li);
                    }
                }
                BranchDDL.SelectedValue = BranchId;
            }
}
        protected void BindLV()
        {
            string id = HidPassId.Value;
            List<Visitors> visitors = new vmsBiz().GetTempVisitors(id);
            LV.DataSource = visitors;
            LV.DataBind();

        }

        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            LV.InsertItemPosition = InsertItemPosition.None;
            LV.SelectedIndex = -1;
            LV.EditIndex = e.NewEditIndex;
            BindLV();
            e.Cancel = true;


        }

        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField HidVisitorId = (HiddenField)LV.Items[e.ItemIndex].FindControl("HidVisitorId");
            int VisitorId = Convert.ToInt32(HidVisitorId.Value);
            new vmsBiz().DeleteTempVisitor(VisitorId);
            BindLV();
        }
        //protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        //{
        //    LV.EditIndex = -1;
        //    LV.InsertItemPosition = InsertItemPosition.None;
        //    LV.SelectedIndex = -1;

        //    BindLV();
        //    e.Cancel = true;
        //}

        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            string id = HidPassId.Value;
            HiddenField HidVisitorName = LV.InsertItem.FindControl("HidVisitorName") as HiddenField;
            HiddenField HidVisitorCnic = LV.InsertItem.FindControl("HidVisitorCnic") as HiddenField;
            TextBox VisitorNameTxt = LV.InsertItem.FindControl("VisitorNameTxt") as TextBox;
            TextBox CnicTxt = LV.InsertItem.FindControl("CnicTxt") as TextBox;
            TextBox DetailsTxt = LV.InsertItem.FindControl("DetailsTxt") as TextBox;
            Visitors b = new Visitors();
            if(!string.IsNullOrEmpty(HidVisitorName.Value))
                b.VisitorName = Convert.ToString(HidVisitorName.Value);
            else
                b.VisitorName = Convert.ToString(VisitorNameTxt.Text);
            if (!string.IsNullOrEmpty(HidVisitorCnic.Value))
                b.Cnic = Convert.ToString(HidVisitorCnic.Value);
            else
                b.Cnic = Convert.ToString(CnicTxt.Text);
            b.Details = Convert.ToString(DetailsTxt.Text);
            b.PassId = id;
            new vmsBiz().InsertTempVisitor(b);
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.LastItem;
            BindLV();
            e.Cancel = true;
           

        }
        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            string id =HidPassId.Value;
            HiddenField HidVisitorId = LV.EditItem.FindControl("HidVisitorId") as HiddenField;
            HiddenField HidVisitorName = LV.EditItem.FindControl("HidVisitorName") as HiddenField;
            HiddenField HidVisitorCnic = LV.EditItem.FindControl("HidVisitorCnic") as HiddenField;
            TextBox VisitorNameTxt = LV.EditItem.FindControl("VisitorNameTxt") as TextBox;
            TextBox CnicTxt = LV.EditItem.FindControl("CnicTxt") as TextBox;
            TextBox DetailsTxt = LV.EditItem.FindControl("DetailsTxt") as TextBox;
            Visitors b = new Visitors();
            b.VisitorId = Convert.ToInt32(HidVisitorId.Value);
            if (!string.IsNullOrEmpty(HidVisitorName.Value))
                b.VisitorName = Convert.ToString(HidVisitorName.Value);
            else
                b.VisitorName = Convert.ToString(VisitorNameTxt.Text);
            if (!string.IsNullOrEmpty(HidVisitorCnic.Value))
                b.Cnic = Convert.ToString(HidVisitorCnic.Value);
            else
                b.Cnic = Convert.ToString(CnicTxt.Text);
            b.Details = Convert.ToString(DetailsTxt.Text);
            b.PassId = id;
            new vmsBiz().UpdateTempVisitor(b);
            LV.EditIndex = -1;
            LV.InsertItemPosition = InsertItemPosition.None;
            BindLV();
            e.Cancel = true;
            
        }
        #endregion

        protected void SavePassBtn_Click(object sender, EventArgs e)
        {
            if (LV.Items.Count > 0)
            {
                viitorserror.Visible = false;
                int empval = 0;
                HttpCookie reqCookies = Request.Cookies["userInfo"];
                if (reqCookies != null)
                {
                    empval = Convert.ToInt32(reqCookies["SystemUsersId"]);
                }
                VisitorPasses b = new VisitorPasses();
                b.PassId = Convert.ToString(HidPassId.Value);
                b.RequestedById = empval;// Convert.ToInt32(RequestedById.Value);
                if (!string.IsNullOrEmpty(PassDateTxt.Text))
                {
                    DateTime fromdate = DateTime.ParseExact(PassDateTxt.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    b.PassDate = fromdate;
                }
                else
                {
                    b.PassDate = DateTime.Now;
                }
                b.CompanyId = Convert.ToInt32(HidCompanyId.Value);
                b.PassTypeId = Convert.ToInt32(PassTypeDDL.SelectedValue);
                b.BranchId = Convert.ToInt32(BranchDDL.SelectedValue);
                b.Company = new Companies();
                b.Company.CompanyName = Convert.ToString(CompanyNameTxt.Text);
                IFormatProvider culture = new CultureInfo("en-US", true);
                string Date = FromDateTxt.Text;
                if (!string.IsNullOrEmpty(FromDateTxt.Text))
                {
                    DateTime fromdate = DateTime.ParseExact(FromDateTxt.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    b.FromDate = fromdate;
                }
                else
                {
                    b.FromDate = DateTime.Now;
                }
                if (!string.IsNullOrEmpty(FromDateTxt.Text))
                {
                    DateTime todate = DateTime.ParseExact(ToDateTxt.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    b.ToDate = todate;
                }
                else
                {
                    b.ToDate = DateTime.Now;
                }
                b.VisitPurpose = Convert.ToString(VisitPurposeTxt.Text);
                //b.Remarks = Convert.ToString(RemarksTxt.Text);
                b.Saturday = (SaturdayCB.Checked == true) ? 1 : 0;
                b.Sunday = (SundayCB.Checked == true) ? 1 : 0;
                b.IsActive = Convert.ToInt32(IsActiveDDL.SelectedItem.Value);
                new vmsBiz().InsertVisitorPass(b);
                Response.Redirect("~/PrintPass.aspx?Id=" + b.PassId);
            }
            else
            {
                viitorserror.Visible = true;
            }
        }
    }
}