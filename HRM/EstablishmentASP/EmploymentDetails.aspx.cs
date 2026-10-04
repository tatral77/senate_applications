using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EstablishmentBIZ;
using EstablishmentENT;

namespace EstablishmentASP
{
    public partial class EmploymentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int empval;
         
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            if (!IsPostBack)
            {
                bindCombos();
                bindEmployment(empval);
                bindRegularEmployment(empval);
                bindProbationLV(empval);
                bindOtherEmployment(empval);
                bindEmploymentOutLV(empval);
                //bindEmploymentOutEmployment(empval);
                bindExtensionLV(empval);
                bindRetirementLV(empval); 
            }


        }
        protected void newLinkButton_Click(object sender, EventArgs e)
        {

            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            RegularEmploymentLV.SelectedIndex = -1;
            RegularEmploymentLV.EditIndex = -1;
            RegularEmploymentLV.InsertItemPosition = InsertItemPosition.FirstItem;
            bindRegularEmployment(empval);
           

        }
        protected void bindEmployment(int EmpId)
        {
            EmpEmployment Ep = new EmpEmployment();
            Ep = new EmployeeHandler().GetEmpEmployment(EmpId);
            FileNo.Text = Convert.ToString(Ep.File_no);
            PersonalNoTxt.Text= Convert.ToString(Ep.PersonalNo);
            GovtSrvEntry.Text = (Convert.ToString(Ep.GovtServStDate) == "01/01/0001 00:00:00") ? string.Empty : Ep.GovtServStDate.ToShortDateString();// ? String.Format("{0:dd/MM/yyyy}", Ep.GovtServStDate) : string.Empty;
            SenEntry.Text = (Convert.ToString(Ep.SenServStDate) == "01/01/0001 00:00:00") ? string.Empty : Ep.SenServStDate.ToShortDateString();// ? String.Format("{0:dd/MM/yyyy}", Ep.SenServStDate) : string.Empty;
            EmpPoolDDL.SelectedIndex = EmpPoolDDL.Items.IndexOf(EmpPoolDDL.Items.FindByValue(Ep.EmpPoolId.ToString()));
            QuotaDDL.SelectedIndex = QuotaDDL.Items.IndexOf(QuotaDDL.Items.FindByValue(Ep.QuotaId.ToString()));
            AppointmentModeDDL.SelectedIndex = AppointmentModeDDL.Items.IndexOf(AppointmentModeDDL.Items.FindByValue(Ep.AppointmentModeId.ToString()));
            SeniorityNumber.Text = Convert.ToString(Ep.SenNo);
            PrevLeaveCreditTxt.Text = Convert.ToString(Ep.PreviousLeaveCredit);
        }
        protected void bindCombos()
        {
            List<EmployeePools> EmpPools = new AdministrationBIZ().GetEmpPools();
            foreach (EmployeePools row in EmpPools)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.EmpPoolsId.ToString();
                EmpPoolDDL.Items.Add(li);
            }
            List<TempEntity> AppModes = new AdministrationBIZ().GetAppointmenModes();
            foreach (TempEntity row in AppModes)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.Id.ToString();
                AppointmentModeDDL.Items.Add(li);
            }
            List<TempEntity> EmpQuota = new AdministrationBIZ().GetEmplQuotas();
            foreach (TempEntity row in EmpQuota)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.Id.ToString();
                QuotaDDL.Items.Add(li);
            }
        }
        public string GetBranch(int BranchId)
        {
            Branch br = new AdministrationBIZ().GetBranch(BranchId);
            return br.Description;
        }
        public string GetBps(int Bpsid)
        {
            if (Bpsid <= 0)
                return "Not Mentioned";
            else
            {
                BPS br = new AdministrationBIZ().GetBPS(Bpsid);
                return br.Description;
            }
        }
        public string GetPost(int PostId)
        {
            Post pt = new AdministrationBIZ().GetPost(PostId);
            return pt.Description;

        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {
            EmpEmployment employment = new EmpEmployment();
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            employment.PersonalNo = PersonalNoTxt.Text;
            employment.File_no = FileNo.Text;
            employment.EmpId = empval;
            employment.File_no = FileNo.Text;
            employment.EmpPoolId = Convert.ToInt32(EmpPoolDDL.SelectedValue);
            employment.AppointmentModeId = Convert.ToInt32(AppointmentModeDDL.SelectedValue);
            employment.QuotaId = Convert.ToInt32(QuotaDDL.SelectedValue);
            if (GovtSrvEntry.Text != "")
                employment.GovtServStDate = Convert.ToDateTime(GovtSrvEntry.Text);
            if (SenEntry.Text != "")
                employment.SenServStDate = Convert.ToDateTime(SenEntry.Text);
            if (SeniorityNumber.Text != "")
                employment.SenNo = Convert.ToInt32(SeniorityNumber.Text);
            if (PrevLeaveCreditTxt.Text != "")
                employment.PreviousLeaveCredit = Convert.ToInt32(PrevLeaveCreditTxt.Text);
            new EmployeeHandler().UpdateEmpEmployment(employment);
            bindEmployment(empval);
        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }
        protected void bindRegularEmployment(int EmpId)
        {
            List<EmpHistory> re = new List<EmpHistory>();
            re = new EmploymentBIZ().GetRegEmployment(EmpId);
            RegularEmploymentLV.DataSource = re;
            RegularEmploymentLV.DataBind();
        }
        
        protected void RegularEmploymentLV_ItemCreated(object sender, ListViewItemEventArgs e)
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
            DropDownList employmentstatus = new DropDownList();
            employmentstatus = (e.Item.FindControl("EmploymentStatusDDL") as DropDownList);
            if (employmentstatus != null)
            {
                employmentstatus.Items.Add(new ListItem("Select", "0"));

                List<EmploymentStatus> pt = new AdministrationBIZ().GetEmploymentStatuses();

                foreach (EmploymentStatus row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.EmpStatusId.ToString();
                    cy.Text = row.EmpStatus.ToString();
                    employmentstatus.Items.Add(cy);
                }
            }


            DropDownList bps = new DropDownList();
            bps = (e.Item.FindControl("BPSDDL") as DropDownList);
            if (bps != null)
            {

                bps.Items.Add(new ListItem("Select", "0"));

                List<BPS> br = new AdministrationBIZ().GetAllBPS();
                foreach (BPS row in br)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.BpsId.ToString();
                    bps.Items.Add(li);
                }
            }
            DropDownList poststatus = new DropDownList();
            poststatus = (e.Item.FindControl("PostStatusDDL") as DropDownList);
            if (poststatus != null)
            {
                poststatus.Items.Add(new ListItem("Select", "0"));

                List<PostStatus> pt = new AdministrationBIZ().GetPostStatus();

                foreach (PostStatus row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.PostStatusID.ToString();
                    cy.Text = row.Description.ToString();
                    poststatus.Items.Add(cy);
                }
            }
            DropDownList currentstatus = new DropDownList();
            currentstatus = (e.Item.FindControl("CurrentStatusDDL") as DropDownList);
            if (currentstatus != null)
            {
                currentstatus.Items.Add(new ListItem("Select", "0"));

                List<CurrentStatuses> pt = new AdministrationBIZ().GetCurrentStatuses();

                foreach (CurrentStatuses row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.CurrentStatusId.ToString();
                    cy.Text = row.CurrentStatus.ToString();
                    currentstatus.Items.Add(cy);
                }
            }

        }

        protected void RegularEmploymentLV_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            if (!HrmDates.RangeOk(RegularEmploymentLV.InsertItem)) { e.Cancel = true; return; }
            Label err= (Label)RegularEmploymentLV.InsertItem.FindControl("ErrorLabel");
            DropDownList CurrentStatusDDL = (DropDownList)RegularEmploymentLV.InsertItem.FindControl("CurrentStatusDDL");
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            if (new EmploymentBIZ().GetServingStatus(empval,0) == 1 && Convert.ToInt32(CurrentStatusDDL.SelectedItem.Value) == 9)
                err.Text = "Employee already has a Serving Status";
            else
            {
                err.Text = "";
                DropDownList PostDDL = (DropDownList)RegularEmploymentLV.InsertItem.FindControl("PostDDL");
                DropDownList BPSDDL = (DropDownList)RegularEmploymentLV.InsertItem.FindControl("BPSDDL");
                //DropDownList EmploymentStatusDDL = (DropDownList)RegularEmploymentLV.InsertItem.FindControl("EmploymentStatusDDL");
                TextBox AppointmentDateTxt = (TextBox)RegularEmploymentLV.InsertItem.FindControl("AppointmentDateTxt");
                TextBox ProbationFrom = (TextBox)RegularEmploymentLV.InsertItem.FindControl("ProbationFromTxt");
                TextBox ProbationTo = (TextBox)RegularEmploymentLV.InsertItem.FindControl("ProbationToTxt");
                CheckBox IsGazetted = (CheckBox)RegularEmploymentLV.InsertItem.FindControl("IsGazetted");
                DropDownList PostStatusDDL = (DropDownList)RegularEmploymentLV.InsertItem.FindControl("PostStatusDDL");
                TextBox CurrentStatusDateTxt = (TextBox)RegularEmploymentLV.InsertItem.FindControl("CurrentStatusDateTxt");
                CheckBox IsCurrent = (CheckBox)RegularEmploymentLV.InsertItem.FindControl("IsCurrentCB");
                TextBox RemarksTxt = (TextBox)RegularEmploymentLV.InsertItem.FindControl("RemarksTxt");
                RegularEmployee eh = new RegularEmployee();
                eh.SystemUsersId = empval;
                eh.PostId = Convert.ToInt32(PostDDL.SelectedItem.Value);
                eh.BpsId = Convert.ToInt32(BPSDDL.SelectedItem.Value);
                eh.EmploymentStatusDate = Convert.ToDateTime(AppointmentDateTxt.Text);
                eh.IsGazetted = (IsGazetted.Checked) ? 1 : 0;
                eh.IsCurrent = (IsCurrent.Checked) ? 1 : 0;
                eh.PostStatusId = Convert.ToInt32(PostStatusDDL.SelectedItem.Value);
                eh.CurrentStatusId = Convert.ToInt32(CurrentStatusDDL.SelectedItem.Value);
                eh.CurrentStatusDate = Convert.ToDateTime(CurrentStatusDateTxt.Text);
                eh.EmploymentStatusId = 1;
                eh.Remarks = Convert.ToString(RemarksTxt.Text);
                eh.ProbationFrom = Convert.ToDateTime(ProbationFrom.Text);
                eh.ProbationTo = Convert.ToDateTime(ProbationTo.Text);

                //if (!String.IsNullOrEmpty(ExtendedTo.Text))
                //    eh.ExtendedTo = Convert.ToDateTime(ExtendedTo.Text);
                //eh.ExtensionReason = Convert.ToString(Reason.Text);
                new EmploymentBIZ().InsertRegularEmployment(eh);
                RegularEmploymentLV.EditIndex = -1;
                RegularEmploymentLV.InsertItemPosition = InsertItemPosition.None;
                bindRegularEmployment(empval);
                bindProbationLV(empval);
                e.Cancel = true;
                Response.Redirect("EmploymentDetails.aspx?empid=" + empval);
            }
        }

        protected void RegularEmploymentLV_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            RegularEmploymentLV.EditIndex = -1;
            RegularEmploymentLV.InsertItemPosition = InsertItemPosition.None;
            RegularEmploymentLV.SelectedIndex = -1;
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindRegularEmployment(empval);
            e.Cancel = true;
        }

        protected void RegularEmploymentLV_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            RegularEmploymentLV.InsertItemPosition = InsertItemPosition.None;
            RegularEmploymentLV.SelectedIndex = -1;
            RegularEmploymentLV.EditIndex = e.NewEditIndex;
            bindRegularEmployment(empval);
            e.Cancel = true;

        }
        protected void RegularEmploymentLV_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (RegularEmploymentLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)// || RegularEmploymentLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)  
            {
                DropDownList Post = e.Item.FindControl("PostDDL") as DropDownList;
                HiddenField PostId = (e.Item.FindControl("HidPostId") as HiddenField);
                Post.SelectedValue = PostId.Value.ToString();

                DropDownList BPS = e.Item.FindControl("BPSDDL") as DropDownList;
                HiddenField BPSId = (e.Item.FindControl("HidBpsId") as HiddenField);
                BPS.SelectedValue = BPSId.Value.ToString();

                DropDownList PostStatus = e.Item.FindControl("PostStatusDDL") as DropDownList;
                HiddenField PostStatusId = (e.Item.FindControl("HidPostStatusId") as HiddenField);
                PostStatus.SelectedValue = PostStatusId.Value.ToString();

                DropDownList CurrentStatus = e.Item.FindControl("CurrentStatusDDL") as DropDownList;
                HiddenField CurrentStatusId = (e.Item.FindControl("HidCurrentStatusId") as HiddenField);
                CurrentStatus.SelectedValue = CurrentStatusId.Value.ToString();

                //DropDownList EmploymentStatus = e.Item.FindControl("EmploymentStatusDDL") as DropDownList;
                //HiddenField EmploymentStatusId = (e.Item.FindControl("HidEmploymentStatusId") as HiddenField);
                //EmploymentStatus.SelectedValue = EmploymentStatusId.Value.ToString();

                CheckBox IsGazetted = e.Item.FindControl("GazettedCB") as CheckBox;
                HiddenField IsGazettedId = (e.Item.FindControl("HidIsGazetted") as HiddenField);
                //if (Convert.ToInt32(Eval("IsGazettedId")) == 1)
                //    IsGazetted.Checked = true;
                //else
                //    IsGazetted.Checked = false;l
                IsGazetted.Checked=((Convert.ToInt32(IsGazettedId.Value) == 1) ?  true :  false);
                CheckBox IsCurrentCB = e.Item.FindControl("IsCurrentCB") as CheckBox;
                if (IsCurrentCB != null)
                {
                    HiddenField IsCurrent = (e.Item.FindControl("HidIsCurrent") as HiddenField);
                    if (Convert.ToInt32(IsCurrent.Value) == 1)
                        IsCurrentCB.Checked = true;
                    else
                        IsCurrentCB.Checked = false;
                }
            }
        }
        protected void RegularEmploymentLV_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            Label err = (Label)RegularEmploymentLV.EditItem.FindControl("ErrorLabel");
            DropDownList CurrentStatusDDL = (DropDownList)RegularEmploymentLV.EditItem.FindControl("CurrentStatusDDL");
            HiddenField EmploymentHistoryId = RegularEmploymentLV.EditItem.FindControl("HidEmploymentHistoryId") as HiddenField;
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            int histid= Convert.ToInt32(EmploymentHistoryId.Value);
            int empstatus = new EmploymentBIZ().GetServingStatus(empval, histid);
            if (empstatus == 1 && Convert.ToInt32(CurrentStatusDDL.SelectedItem.Value)==9)
                err.Text = "Employee+ already has a Serving Status";
            else
            {
                err.Text = "";
                DropDownList PostId = (DropDownList)RegularEmploymentLV.EditItem.FindControl("PostDDL");
                DropDownList BpsId = (DropDownList)RegularEmploymentLV.EditItem.FindControl("BPSDDL");
                DropDownList PostStatusId = (DropDownList)RegularEmploymentLV.EditItem.FindControl("PostStatusDDL");
                //DropDownList EmploymentStatusDDL = (DropDownList)RegularEmploymentLV.EditItem.FindControl("EmploymentStatusDDL");
                CheckBox IsGazetted = (CheckBox)RegularEmploymentLV.EditItem.FindControl("GazettedCB");
                TextBox EmploymentDate = (TextBox)RegularEmploymentLV.EditItem.FindControl("EmploymentDateTxt");
                TextBox CurrentStatusDate = (TextBox)RegularEmploymentLV.EditItem.FindControl("CurrentStatusDateTxt");
                TextBox RemarksTxt = (TextBox)RegularEmploymentLV.EditItem.FindControl("RemarksTxt");
                CheckBox IsCurrent = (CheckBox)RegularEmploymentLV.EditItem.FindControl("IsCurrentCB");
                RegularEmployee eh = new RegularEmployee();
                eh.SystemUsersId = empval;
                eh.EmploymentHistoryId = Convert.ToInt32(EmploymentHistoryId.Value);
                eh.PostId = Convert.ToInt32(PostId.SelectedItem.Value);
                eh.BpsId = Convert.ToInt32(BpsId.SelectedItem.Value);
                eh.PostStatusId = Convert.ToInt32(PostStatusId.SelectedItem.Value);
                eh.CurrentStatusId = Convert.ToInt32(CurrentStatusDDL.SelectedItem.Value);
                eh.CurrentStatusDate = Convert.ToDateTime(CurrentStatusDate.Text);
                eh.IsCurrent = (IsCurrent.Checked == true) ? 1 : 0;
                eh.Remarks = RemarksTxt.Text;
                //eh.EmploymentStatusId= Convert.ToInt32(EmploymentStatusDDL.SelectedItem.Value);
                eh.EmploymentStatusDate = Convert.ToDateTime(EmploymentDate.Text);
                eh.IsGazetted = (IsGazetted.Checked == true) ? 1 : 0;
                new EmploymentBIZ().UpdateEmpEmployment(eh);
                RegularEmploymentLV.EditIndex = -1;
                RegularEmploymentLV.InsertItemPosition = InsertItemPosition.None;
                bindRegularEmployment(empval);
                e.Cancel = true;
            }

        }
        protected void RegularEmploymentLV_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField HistoryId = (HiddenField)RegularEmploymentLV.Items[e.ItemIndex].FindControl("HidEmploymentHistoryId");
            int EmpHistoryId = Convert.ToInt32(HistoryId.Value);
            new EmploymentBIZ().DeleteRegularEmployment(EmpHistoryId);
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindRegularEmployment(empval);
            bindProbationLV(empval);
        }


        //===============================================================================================================================
        #region PROBATION
        protected void newProbation_Click(object sender, EventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            ProbationLV.SelectedIndex = -1;
            ProbationLV.EditIndex = -1;
            ProbationLV.InsertItemPosition = InsertItemPosition.FirstItem;
            bindProbationLV(empval);

        }
        protected void bindProbationLV(int EmpId)
        {
            List<Probation> re = new List<Probation>();
            re = new EmploymentBIZ().GetEmployeeProbations(EmpId);
            ProbationLV.DataSource = re;
            ProbationLV.DataBind();
        }
        protected void Probation_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            HiddenField ProbationId = (HiddenField)ProbationLV.Items[e.ItemIndex].FindControl("HidProbationId");
            int EmpHistoryId = Convert.ToInt32(ProbationId.Value);
            new EmploymentBIZ().DeleteProbation(EmpHistoryId,empval);
          
            bindProbationLV(empval);
        }
        protected void Probation_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            if (!HrmDates.RangeOk(ProbationLV.EditItem)) { e.Cancel = true; return; }
            DropDownList ProbationTypeDDL = (DropDownList)ProbationLV.EditItem.FindControl("ProbationTypeDDL");
            HiddenField ProbationId = ProbationLV.EditItem.FindControl("HidProbationId") as HiddenField;
            HiddenField EmploymentHistoryId = ProbationLV.EditItem.FindControl("HidEmploymentHistoryId") as HiddenField;
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            int histid = Convert.ToInt32(EmploymentHistoryId.Value);
            TextBox ProbationFrom = (TextBox)ProbationLV.EditItem.FindControl("ProbationFromTxt");
            TextBox ProbationTo = (TextBox)ProbationLV.EditItem.FindControl("ProbationToTxt");
            TextBox Remarks = (TextBox)ProbationLV.EditItem.FindControl("RemarksTxt");
            Probation eh = new Probation();
            eh.EmploymentHistId = histid;
            eh.SystemUserId = empval;
            eh.ProbationId= Convert.ToInt32(ProbationId.Value);
            eh.ProbationTypeId = Convert.ToInt32(ProbationTypeDDL.SelectedItem.Value);
            eh.ProbationFrom = Convert.ToDateTime(ProbationFrom.Text);
            eh.ProbationTo = Convert.ToDateTime(ProbationTo.Text);
            eh.Remarks= Convert.ToString(Remarks.Text);
            new EmploymentBIZ().UpdateProbation(eh);
            ProbationLV.EditIndex = -1;
            ProbationLV.InsertItemPosition = InsertItemPosition.None;
            bindProbationLV(empval);
            e.Cancel = true;
            

        }

        protected void Probation_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            if (!HrmDates.RangeOk(ProbationLV.InsertItem)) { e.Cancel = true; return; }
            DropDownList ProbationTypeDDL = (DropDownList)ProbationLV.InsertItem.FindControl("ProbationTypeDDL");
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            TextBox EmpHistoryId = (TextBox)ProbationLV.InsertItem.FindControl("ReferenceIdTxt");
            TextBox ProbationFrom = (TextBox)ProbationLV.InsertItem.FindControl("ProbationFromTxt");
            TextBox ProbationTo = (TextBox)ProbationLV.InsertItem.FindControl("ProbationToTxt");
            TextBox Remarks = (TextBox)ProbationLV.InsertItem.FindControl("RemarksTxt");
            Probation eh = new Probation();
            eh.EmploymentHistId = Convert.ToInt32(EmpHistoryId.Text);
            eh.SystemUserId = empval;
            eh.ProbationTypeId = Convert.ToInt32(ProbationTypeDDL.SelectedItem.Value);
            eh.ProbationFrom = Convert.ToDateTime(ProbationFrom.Text);
            eh.ProbationTo = Convert.ToDateTime(ProbationTo.Text);
            eh.Remarks = Convert.ToString(Remarks.Text);
            new EmploymentBIZ().InsertProbation(eh);
            ProbationLV.EditIndex = -1;
            ProbationLV.InsertItemPosition = InsertItemPosition.None;
            bindProbationLV(empval);
            e.Cancel = true;
            Response.Redirect("EmploymentDetails.aspx?empid=" + empval);

        }
        protected void Probation_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            ProbationLV.EditIndex = -1;
            ProbationLV.InsertItemPosition = InsertItemPosition.None;
            ProbationLV.SelectedIndex = -1;
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindProbationLV(empval);
            e.Cancel = true;
        }

        protected void Probation_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
           ProbationLV.InsertItemPosition = InsertItemPosition.None;
            ProbationLV.SelectedIndex = -1;
            ProbationLV.EditIndex = e.NewEditIndex;
            bindProbationLV(empval);
            e.Cancel = true;

        }
        protected void Probation_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (ProbationLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)// || RegularEmploymentLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)  
            {
                DropDownList ProbationType = e.Item.FindControl("ProbationTypeDDL") as DropDownList;
                HiddenField ProbationTypeId = (e.Item.FindControl("HidProbationTypeId") as HiddenField);
                ProbationType.SelectedValue = ProbationTypeId.Value.ToString();

             }
        }
        protected void Probation_ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList ProbationType = new DropDownList();
            ProbationType = (e.Item.FindControl("ProbationTypeDDL") as DropDownList);
            if (ProbationType != null)
            {
                ProbationType.Items.Add(new ListItem("Select", "0"));

                List<ProbationTypes> pt = new AdministrationBIZ().GetProbationTypes();

                foreach (ProbationTypes row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.ProbationTypeId.ToString();
                    cy.Text = row.ProbationType.ToString();
                    ProbationType.Items.Add(cy);
                }
            }
        }

        #endregion PROBATION
            //===============================================================================================================================



            #region OTHER EMPLOYMENT

        protected void OtherEmploymentLV_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            if (!HrmDates.RangeOk(OtherEmploymentLV.InsertItem)) { e.Cancel = true; return; }
            Label err = (Label) OtherEmploymentLV.InsertItem.FindControl("ErrorLabel");
            DropDownList CurrentStatusDDL = (DropDownList) OtherEmploymentLV.InsertItem.FindControl("CurrentStatusDDL");
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            if (new EmploymentBIZ().GetServingStatus(empval, 0) == 1 && Convert.ToInt32(CurrentStatusDDL.SelectedItem.Value) == 9)
                err.Text = "Employee already has a Serving Status";
            else
            {
                err.Text = "";
                DropDownList PostDDL = (DropDownList) OtherEmploymentLV.InsertItem.FindControl("PostDDL");
                DropDownList BPSDDL = (DropDownList) OtherEmploymentLV.InsertItem.FindControl("BPSDDL");
                DropDownList QuotaDDL = (DropDownList)OtherEmploymentLV.InsertItem.FindControl("QuotaDDL");
                DropDownList EmploymentStatusDDL = (DropDownList)OtherEmploymentLV.InsertItem.FindControl("EmploymentTypeDDL");
                TextBox AppointmentDateTxt = (TextBox) OtherEmploymentLV.InsertItem.FindControl("AppointmentDateTxt");
                //TextBox EmploymentOutFrom = (TextBox) OtherEmploymentLV.InsertItem.FindControl("EmploymentOutFromTxt");
                TextBox ToDate = (TextBox) OtherEmploymentLV.InsertItem.FindControl("ToDateTxt");
                CheckBox IsGazetted = (CheckBox) OtherEmploymentLV.InsertItem.FindControl("IsGazetted");
                DropDownList PostStatusDDL = (DropDownList) OtherEmploymentLV.InsertItem.FindControl("PostStatusDDL");
               // TextBox DetailsTxt = (TextBox)OtherEmploymentLV.InsertItem.FindControl("DetailsTxt");
                TextBox RemarksTxt = (TextBox)OtherEmploymentLV.InsertItem.FindControl("RemarksTxt");
                TextBox CurrentStatusDateTxt = (TextBox) OtherEmploymentLV.InsertItem.FindControl("CurrentStatusDateTxt");
                EmpHistory eh = new EmpHistory();
                eh.SystemUsersId = empval;
                eh.PostId = Convert.ToInt32(PostDDL.SelectedItem.Value);
                eh.BpsId = Convert.ToInt32(BPSDDL.SelectedItem.Value);
                eh.EmploymentStatusDate = Convert.ToDateTime(AppointmentDateTxt.Text);
                eh.IsGazetted = (IsGazetted.Checked) ? 1 : 0;
                eh.PostStatusId = Convert.ToInt32(PostStatusDDL.SelectedItem.Value);
                eh.CurrentStatusId = Convert.ToInt32(CurrentStatusDDL.SelectedItem.Value);
                eh.CurrentStatusDate = Convert.ToDateTime(CurrentStatusDateTxt.Text);
                eh.EmploymentStatusId = Convert.ToInt32(EmploymentStatusDDL.SelectedItem.Value);
                eh.QuotaId= Convert.ToInt32(QuotaDDL.SelectedItem.Value);
                eh.Remarks = Convert.ToString(RemarksTxt.Text);
               // eh.Details = Convert.ToString(DetailsTxt.Text);
                eh.ToDate = Convert.ToDateTime(ToDate.Text);
                new EmploymentBIZ().InsertOtherEmployment(eh);
                OtherEmploymentLV.EditIndex = -1;
                OtherEmploymentLV.InsertItemPosition = InsertItemPosition.None;
                bindOtherEmployment(empval);
                e.Cancel = true;
                Response.Redirect("EmploymentDetails.aspx?empid=" + empval);
            }
        }

        protected void OtherEmploymentLV_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            OtherEmploymentLV.EditIndex = -1;
            OtherEmploymentLV.InsertItemPosition = InsertItemPosition.None;
            OtherEmploymentLV.SelectedIndex = -1;
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindOtherEmployment(empval);
            e.Cancel = true;
        }

        protected void OtherEmploymentLV_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            OtherEmploymentLV.InsertItemPosition = InsertItemPosition.None;
            OtherEmploymentLV.SelectedIndex = -1;
            OtherEmploymentLV.EditIndex = e.NewEditIndex;
            bindOtherEmployment(empval);
            e.Cancel = true;

        }
        protected void OtherEmploymentLV_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if ( OtherEmploymentLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)// || RegularEmploymentLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)  
            {
                DropDownList EmploymentType = e.Item.FindControl("EmploymentTypeDDL") as DropDownList;
                HiddenField HidEmploymentType = (e.Item.FindControl("HidEmploymentStatusId") as HiddenField);
                EmploymentType.SelectedValue = HidEmploymentType.Value.ToString();

                DropDownList Post = e.Item.FindControl("PostDDL") as DropDownList;
                HiddenField PostId = (e.Item.FindControl("HidPostId") as HiddenField);
                Post.SelectedValue = PostId.Value.ToString();

                DropDownList QuotaDDL = e.Item.FindControl("QuotaDDL") as DropDownList;
                HiddenField QuotaId = (e.Item.FindControl("HidQuotaId") as HiddenField);
                QuotaDDL.SelectedValue = QuotaId.Value.ToString();

                DropDownList BPS = e.Item.FindControl("BPSDDL") as DropDownList;
                HiddenField BPSId = (e.Item.FindControl("HidBpsId") as HiddenField);
                BPS.SelectedValue = BPSId.Value.ToString();

                DropDownList PostStatus = e.Item.FindControl("PostStatusDDL") as DropDownList;
                HiddenField PostStatusId = (e.Item.FindControl("HidPostStatusId") as HiddenField);
                PostStatus.SelectedValue = PostStatusId.Value.ToString();

                DropDownList CurrentStatus = e.Item.FindControl("CurrentStatusDDL") as DropDownList;
                HiddenField CurrentStatusId = (e.Item.FindControl("HidCurrentStatusId") as HiddenField);
                CurrentStatus.SelectedValue = CurrentStatusId.Value.ToString();

                //DropDownList EmploymentStatus = e.Item.FindControl("EmploymentStatusDDL") as DropDownList;
                //HiddenField EmploymentStatusId = (e.Item.FindControl("HidEmploymentStatusId") as HiddenField);
                //EmploymentStatus.SelectedValue = EmploymentStatusId.Value.ToString();

                CheckBox IsGazetted = e.Item.FindControl("GazettedCB") as CheckBox;
                HiddenField IsGazettedId = (e.Item.FindControl("HidIsGazetted") as HiddenField);
                //if (Convert.ToInt32(Eval("IsGazettedId")) == 1)
                //    IsGazetted.Checked = true;
                //else
                //    IsGazetted.Checked = false;l
                IsGazetted.Checked = ((Convert.ToInt32(IsGazettedId.Value) == 1) ? true : false);
            }
        }
        protected void OtherEmploymentLV_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            if (!HrmDates.RangeOk(OtherEmploymentLV.EditItem)) { e.Cancel = true; return; }
            Label err = (Label) OtherEmploymentLV.EditItem.FindControl("ErrorLabel");
            DropDownList CurrentStatusDDL = (DropDownList) OtherEmploymentLV.EditItem.FindControl("CurrentStatusDDL");
            HiddenField EmploymentHistoryId = OtherEmploymentLV.EditItem.FindControl("HidEmploymentHistoryId") as HiddenField;
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            int histid = Convert.ToInt32(EmploymentHistoryId.Value);
            int empstatus = new EmploymentBIZ().GetServingStatus(empval, histid);
            if (empstatus == 1 && Convert.ToInt32(CurrentStatusDDL.SelectedItem.Value) == 9)
                err.Text = "Employee already has a Serving Status";
            else
            {
                err.Text = "";
                DropDownList PostId = (DropDownList) OtherEmploymentLV.EditItem.FindControl("PostDDL");
                DropDownList BpsId = (DropDownList) OtherEmploymentLV.EditItem.FindControl("BPSDDL");
                DropDownList QuotaId = (DropDownList)OtherEmploymentLV.EditItem.FindControl("QuotaDDL");
                DropDownList PostStatusId = (DropDownList) OtherEmploymentLV.EditItem.FindControl("PostStatusDDL");
                DropDownList EmploymentStatusDDL = (DropDownList)OtherEmploymentLV.EditItem.FindControl("EmploymentTypeDDL");
                CheckBox IsGazetted = (CheckBox) OtherEmploymentLV.EditItem.FindControl("GazettedCB");
                TextBox EmploymentDate = (TextBox) OtherEmploymentLV.EditItem.FindControl("EmploymentDateTxt");
                TextBox ToDate = (TextBox)OtherEmploymentLV.EditItem.FindControl("ToDateTxt");
                TextBox CurrentStatusDate = (TextBox) OtherEmploymentLV.EditItem.FindControl("CurrentStatusDateTxt");
                //TextBox DetailsTxt = (TextBox)OtherEmploymentLV.EditItem.FindControl("DetailsTxt");
                TextBox RemarksTxt = (TextBox)OtherEmploymentLV.EditItem.FindControl("RemarksTxt");
                EmpHistory eh = new EmpHistory();
                eh.SystemUsersId = empval;
                eh.EmploymentHistoryId = Convert.ToInt32(EmploymentHistoryId.Value);
                eh.PostId = Convert.ToInt32(PostId.SelectedItem.Value);
                eh.BpsId = Convert.ToInt32(BpsId.SelectedItem.Value);
                eh.PostStatusId = Convert.ToInt32(PostStatusId.SelectedItem.Value);
                eh.CurrentStatusId = Convert.ToInt32(CurrentStatusDDL.SelectedItem.Value);
                eh.CurrentStatusDate = Convert.ToDateTime(CurrentStatusDate.Text);
                eh.EmploymentStatusId= Convert.ToInt32(EmploymentStatusDDL.SelectedItem.Value);
                eh.QuotaId= Convert.ToInt32(QuotaId.SelectedItem.Value);
                eh.EmploymentStatusDate = Convert.ToDateTime(EmploymentDate.Text);
                eh.Remarks = Convert.ToString(RemarksTxt.Text);
                //eh.Details = Convert.ToString(DetailsTxt.Text);
                eh.ToDate = Convert.ToDateTime(ToDate.Text);
                eh.IsGazetted = (IsGazetted.Checked == true) ? 1 : 0;
                new EmploymentBIZ().UpdateOtherEmployment(eh);
                OtherEmploymentLV.EditIndex = -1;
                OtherEmploymentLV.InsertItemPosition = InsertItemPosition.None;
                bindOtherEmployment(empval);
                e.Cancel = true;
            }

        }
        protected void OtherEmploymentLV_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField HistoryId = (HiddenField)OtherEmploymentLV.Items[e.ItemIndex].FindControl("HidEmploymentHistoryId");
            int EmpHistoryId = Convert.ToInt32(HistoryId.Value);
            new EmploymentBIZ().DeleteOtherEmployment(EmpHistoryId);
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindOtherEmployment(empval);
            //bindEmploymentOutLV(empval);
        }
        protected void bindOtherEmployment(int EmpId)
        {
            List<EmpHistory> re = new List<EmpHistory>();
            re = new EmploymentBIZ().GetEmpHistory(EmpId);
            OtherEmploymentLV.DataSource = re;
            OtherEmploymentLV.DataBind();
        }
        protected void newOtherEmpl_Click(object sender, EventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            OtherEmploymentLV.SelectedIndex = -1;
            OtherEmploymentLV.EditIndex = -1;
            OtherEmploymentLV.InsertItemPosition = InsertItemPosition.FirstItem;
            bindOtherEmployment(empval);

        }

        protected void OtherEmploymentLV_ItemCreated(object sender, ListViewItemEventArgs e)
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
            DropDownList employmentstatus = new DropDownList();
            employmentstatus = (e.Item.FindControl("EmploymentTypeDDL") as DropDownList);
            if (employmentstatus != null)
            {
                employmentstatus.Items.Add(new ListItem("Select", "0"));

                List<EmploymentStatus> pt = new AdministrationBIZ().GetOtherEmploymentStatuses();

                foreach (EmploymentStatus row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.EmpStatusId.ToString();
                    cy.Text = row.EmpStatus.ToString();
                    employmentstatus.Items.Add(cy);
                }
            }


            DropDownList bps = new DropDownList();
            bps = (e.Item.FindControl("BPSDDL") as DropDownList);
            if (bps != null)
            {

                bps.Items.Add(new ListItem("Select", "0"));

                List<BPS> br = new AdministrationBIZ().GetAllBPS();
                foreach (BPS row in br)
                {
                    ListItem li = new ListItem();
                    li.Text = row.Description;
                    li.Value = row.BpsId.ToString();
                    bps.Items.Add(li);
                }
            }
            DropDownList poststatus = new DropDownList();
            poststatus = (e.Item.FindControl("PostStatusDDL") as DropDownList);
            if (poststatus != null)
            {
                poststatus.Items.Add(new ListItem("Select", "0"));

                List<PostStatus> pt = new AdministrationBIZ().GetPostStatus();

                foreach (PostStatus row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.PostStatusID.ToString();
                    cy.Text = row.Description.ToString();
                    poststatus.Items.Add(cy);
                }
            }
            DropDownList currentstatus = new DropDownList();
            currentstatus = (e.Item.FindControl("CurrentStatusDDL") as DropDownList);
            if (currentstatus != null)
            {
                currentstatus.Items.Add(new ListItem("Select", "0"));

                List<CurrentStatuses> pt = new AdministrationBIZ().GetCurrentStatuses();

                foreach (CurrentStatuses row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.CurrentStatusId.ToString();
                    cy.Text = row.CurrentStatus.ToString();
                    currentstatus.Items.Add(cy);
                }
            }

            DropDownList QuotaDDL = new DropDownList();
            QuotaDDL = (e.Item.FindControl("QuotaDDL") as DropDownList);
            if (QuotaDDL != null)
            {
                QuotaDDL.Items.Add(new ListItem("Select Head of Account", "0"));

                List<TempEntity> pt = new AdministrationBIZ().GetOtherEmplQuotas();

                foreach (TempEntity row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.Id.ToString();
                    cy.Text = row.Description.ToString();
                    QuotaDDL.Items.Add(cy);
                }
            }

        }

        #endregion EmploymentOut




        //===============================================================================================================================
        #region EmploymentOut
        protected void bindEmploymentOutLV(int EmpId)
        {
            List<EmploymentOut> re = new List<EmploymentOut>();
            re = new EmploymentBIZ().GetEmploymentOut(EmpId);
            EmploymentOutLV.DataSource = re;
            EmploymentOutLV.DataBind();
        }

        protected void newEmploymentOut_Click(object sender, EventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            EmploymentOutLV.SelectedIndex = -1;
            EmploymentOutLV.EditIndex = -1;
            EmploymentOutLV.InsertItemPosition = InsertItemPosition.FirstItem;
            bindEmploymentOutLV(empval);

        }


        protected void EmploymentOut_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField HidEmploymentOutId = (HiddenField)EmploymentOutLV.Items[e.ItemIndex].FindControl("HidEmploymentOutId");
            int EmploymentOutId = Convert.ToInt32(HidEmploymentOutId.Value);
            new EmploymentBIZ().DeleteEmploymentOut(EmploymentOutId);
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindEmploymentOutLV(empval);
        }
        protected void EmploymentOut_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            if (!HrmDates.RangeOk(EmploymentOutLV.EditItem)) { e.Cancel = true; return; }
            DropDownList EmploymentOutTypeDDL = (DropDownList)EmploymentOutLV.EditItem.FindControl("EmploymentTypeDDL");
            HiddenField EmploymentOutId = EmploymentOutLV.EditItem.FindControl("HidEmploymentOutId") as HiddenField;
           int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            TextBox EmploymentOutFrom = (TextBox)EmploymentOutLV.EditItem.FindControl("EmploymentFromTxt");
            TextBox EmploymentOutTo = (TextBox)EmploymentOutLV.EditItem.FindControl("EmploymentToTxt");

            DropDownList OutBpsDDL = (DropDownList)EmploymentOutLV.EditItem.FindControl("OutBpsDDL");
            DropDownList OutPostDDL = (DropDownList)EmploymentOutLV.EditItem.FindControl("OutPostDDL");
            DropDownList InBPSDDL = (DropDownList)EmploymentOutLV.EditItem.FindControl("InBPSDDL");
            DropDownList InPOSTDDL = (DropDownList)EmploymentOutLV.EditItem.FindControl("InPOSTDDL");

            CheckBox Extension = (CheckBox)EmploymentOutLV.EditItem.FindControl("ExtensionCB");
            CheckBox IsActive = (CheckBox)EmploymentOutLV.EditItem.FindControl("IsActiveCB");
            TextBox Remarks = (TextBox)EmploymentOutLV.EditItem.FindControl("RemarksTxt");
            EmploymentOut eh = new EmploymentOut();
            eh.SystemUsersId = empval;
            eh.EmploymentOutId = Convert.ToInt32(EmploymentOutId.Value);
            eh.EmploymentOutTypeId = Convert.ToInt32(EmploymentOutTypeDDL.SelectedItem.Value);
            eh.FromDate = Convert.ToDateTime(EmploymentOutFrom.Text);
            eh.ToDate = Convert.ToDateTime(EmploymentOutTo.Text);
            eh.OutBps = Convert.ToInt32(OutBpsDDL.SelectedItem.Value);
            eh.OutPost = Convert.ToInt32(OutPostDDL.SelectedItem.Value);
            eh.InBps = Convert.ToInt32(InBPSDDL.SelectedItem.Value);
            eh.InPost = Convert.ToInt32(InPOSTDDL.SelectedItem.Value);
            eh.IsExtended = (Extension.Checked) ? 1 : 0;
            eh.IsActive = (IsActive.Checked) ? 1 : 0;

            eh.Remarks = Convert.ToString(Remarks.Text);
            new EmploymentBIZ().UpdateEmploymentOut(eh);
            EmploymentOutLV.EditIndex = -1;
            EmploymentOutLV.InsertItemPosition = InsertItemPosition.None;
            bindEmploymentOutLV(empval);
            e.Cancel = true;


        }

        protected void EmploymentOut_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            if (!HrmDates.RangeOk(EmploymentOutLV.InsertItem)) { e.Cancel = true; return; }
            DropDownList OutBpsDDL = new DropDownList();
            DropDownList OutPostDDL = new DropDownList();
            DropDownList InBPSDDL = new DropDownList();
            DropDownList InPOSTDDL = new DropDownList();

            DropDownList EmploymentOutTypeDDL = (DropDownList)EmploymentOutLV.InsertItem.FindControl("EmploymentTypeDDL");
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            TextBox EmploymentOutFrom = (TextBox)EmploymentOutLV.InsertItem.FindControl("EmploymentFromTxt");
            TextBox EmploymentOutTo = (TextBox)EmploymentOutLV.InsertItem.FindControl("EmploymentToTxt");
            CheckBox Extension = (CheckBox)EmploymentOutLV.InsertItem.FindControl("ExtensionCB");
            CheckBox IsActive = (CheckBox)EmploymentOutLV.InsertItem.FindControl("IsActiveCB");
            TextBox Remarks = (TextBox)EmploymentOutLV.InsertItem.FindControl("RemarksTxt");

             OutBpsDDL = (DropDownList)EmploymentOutLV.InsertItem.FindControl("OutBpsDDL");
             OutPostDDL = (DropDownList)EmploymentOutLV.InsertItem.FindControl("OutPostDDL");
             InBPSDDL = (DropDownList)EmploymentOutLV.InsertItem.FindControl("InBPSDDL");
             InPOSTDDL = (DropDownList)EmploymentOutLV.InsertItem.FindControl("InPOSTDDL");

            EmploymentOut eh = new EmploymentOut();
            eh.SystemUsersId = empval;
            eh.EmploymentOutTypeId = Convert.ToInt32(EmploymentOutTypeDDL.SelectedItem.Value);
            eh.FromDate = Convert.ToDateTime(EmploymentOutFrom.Text);
            eh.OutBps= Convert.ToInt32(OutBpsDDL.SelectedItem.Value);
            eh.OutPost = Convert.ToInt32(OutPostDDL.SelectedItem.Value);
            eh.InBps = Convert.ToInt32(InBPSDDL.SelectedItem.Value);
            eh.InPost = Convert.ToInt32(InPOSTDDL.SelectedItem.Value);
            eh.ToDate = Convert.ToDateTime(EmploymentOutTo.Text);
            eh.IsExtended = (Extension.Checked) ? 1 : 0;
            eh.IsActive = (IsActive.Checked) ? 1 : 0;
            eh.Remarks = Convert.ToString(Remarks.Text);
            new EmploymentBIZ().InsertEmploymentOut(eh);
            EmploymentOutLV.EditIndex = -1;
            EmploymentOutLV.InsertItemPosition = InsertItemPosition.None;
            bindEmploymentOutLV(empval);
            e.Cancel = true;
            Response.Redirect("EmploymentDetails.aspx?empid=" + empval);

        }
        protected void EmploymentOut_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            EmploymentOutLV.EditIndex = -1;
            EmploymentOutLV.InsertItemPosition = InsertItemPosition.None;
            EmploymentOutLV.SelectedIndex = -1;
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindEmploymentOutLV(empval);
            e.Cancel = true;
        }

        protected void EmploymentOut_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            EmploymentOutLV.InsertItemPosition = InsertItemPosition.None;
            EmploymentOutLV.SelectedIndex = -1;
            EmploymentOutLV.EditIndex = e.NewEditIndex;
            bindEmploymentOutLV(empval);
            e.Cancel = true;

        }
        protected void EmploymentOut_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (EmploymentOutLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)// || RegularEmploymentLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)  
            {
                DropDownList EmploymentOutType = e.Item.FindControl("EmploymentTypeDDL") as DropDownList;
                HiddenField EmploymentOutTypeId = (e.Item.FindControl("HidEmploymentOutTypeId") as HiddenField);
                EmploymentOutType.SelectedValue = EmploymentOutTypeId.Value.ToString();

                DropDownList OutBps = e.Item.FindControl("OutBpsDDL") as DropDownList;
                HiddenField HidOutBps = (e.Item.FindControl("HidOutBps") as HiddenField);
                OutBps.SelectedValue = HidOutBps.Value.ToString();
                DropDownList InBps = e.Item.FindControl("InBPSDDL") as DropDownList;
                HiddenField HidInBps = (e.Item.FindControl("HidInBps") as HiddenField);
                InBps.SelectedValue = HidInBps.Value.ToString();

                DropDownList OutPost = e.Item.FindControl("OutPostDDL") as DropDownList;
                HiddenField HidOutPost = (e.Item.FindControl("HidOutPost") as HiddenField);
                OutPost.SelectedValue = HidOutPost.Value.ToString();
                DropDownList InPost = e.Item.FindControl("InPOSTDDL") as DropDownList;
                HiddenField HidInPost = (e.Item.FindControl("HidInPost") as HiddenField);
                InPost.SelectedValue = HidInPost.Value.ToString();

                CheckBox ExtensionCB = e.Item.FindControl("ExtensionCB") as CheckBox;
                HiddenField IsExtended = (e.Item.FindControl("HidIsExtended") as HiddenField);
                ExtensionCB.Checked = (Convert.ToInt32(IsExtended.Value) == 1) ? true : false;

                CheckBox IsActiveCB = e.Item.FindControl("IsActiveCB") as CheckBox;
                HiddenField HidIsActive = (e.Item.FindControl("HidIsActive") as HiddenField);
                IsActiveCB.Checked = (Convert.ToInt32(HidIsActive.Value) == 1) ? true : false;
            }
        }
        protected void EmploymentOut_ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList EmploymentOutType = new DropDownList();
            EmploymentOutType = (e.Item.FindControl("EmploymentTypeDDL") as DropDownList);
            if (EmploymentOutType != null)
            {
                EmploymentOutType.Items.Add(new ListItem("Select", "0"));

                List<EmploymentOutTypes> pt = new AdministrationBIZ().GetEmploymentOutTypes();

                foreach (EmploymentOutTypes row in pt)
                {
                    ListItem cy = new ListItem();
                    cy.Value = row.EmploymentOutTypeId.ToString();
                    cy.Text = row.EmploymentOuType.ToString();
                    EmploymentOutType.Items.Add(cy);
                }
            }

            DropDownList Outbps = new DropDownList();
            DropDownList Inbps = new DropDownList();
            Outbps = (e.Item.FindControl("OutBpsDDL") as DropDownList);
            Inbps = (e.Item.FindControl("InBPSDDL") as DropDownList);
            if (Outbps != null || Inbps != null)
            {
                Outbps.Items.Add(new ListItem("Select", "0"));
                Inbps.Items.Add(new ListItem("Select", "0"));

                List<BPS> pt = new AdministrationBIZ().GetAllBPS(); ;

                foreach (BPS row in pt)
                {
                    ListItem cy = new ListItem();
                    ListItem cy2 = new ListItem();
                    cy.Value = row.BpsId.ToString();
                    cy.Text = row.Description.ToString();
                    cy2.Value = row.BpsId.ToString();
                    cy2.Text = row.Description.ToString();
                    Outbps.Items.Add(cy);
                    Inbps.Items.Add(cy2);
                }
            }
            DropDownList OutPost = new DropDownList();
            DropDownList InPost = new DropDownList();
            OutPost = (e.Item.FindControl("OutPostDDL") as DropDownList);
            InPost = (e.Item.FindControl("InPOSTDDL") as DropDownList);
            if (OutPost != null || InPost != null)
            {
                OutPost.Items.Add(new ListItem("Select", "0"));
                InPost.Items.Add(new ListItem("Select", "0"));

                List<Post> pt = new AdministrationBIZ().GetAllPosts();
                foreach (Post row in pt)
                {
                    ListItem post = new ListItem();
                    ListItem post2 = new ListItem();
                    post.Value = row.PostID.ToString();
                    post.Text = row.Description.ToString();
                    post2.Value = row.PostID.ToString();
                    post2.Text = row.Description.ToString();
                    OutPost.Items.Add(post);
                    InPost.Items.Add(post2);

                }
            }
        }

        #endregion EmploymentOut


        #region Extension

        protected void bindExtensionLV(int EmpId)
        {
            List<ExtensionDetails> re = new List<ExtensionDetails>();
            re = new EmploymentBIZ().GetExtensionDetails(EmpId);
            ExtensionLV.DataSource = re;
            ExtensionLV.DataBind();
        }

        protected void newExtension_Click(object sender, EventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            ExtensionLV.SelectedIndex = -1;
            ExtensionLV.EditIndex = -1;
            ExtensionLV.InsertItemPosition = InsertItemPosition.FirstItem;
            bindExtensionLV(empval);

        }


        protected void Extension_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField HidExtensionId = (HiddenField)ExtensionLV.Items[e.ItemIndex].FindControl("HidExtensionId");
            int ExtensionId = Convert.ToInt32(HidExtensionId.Value);
            new EmploymentBIZ().DeleteExtensionDetails(ExtensionId);
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindExtensionLV(empval);
        }
        protected void Extension_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            HiddenField ExtensionId = ExtensionLV.EditItem.FindControl("HidExtensionId") as HiddenField;
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            TextBox ExtensionTo = (TextBox)ExtensionLV.EditItem.FindControl("ExtendedToTxt");
            TextBox ReferenceId = (TextBox)ExtensionLV.EditItem.FindControl("ReferenceIdTxt");
            TextBox Remarks = (TextBox)ExtensionLV.EditItem.FindControl("RemarksTxt");
            ExtensionDetails eh = new ExtensionDetails();
            eh.SystemUsersId = empval;
            eh.ExtensionId = Convert.ToInt32(ExtensionId.Value);    
            eh.EmploymentHistoryId= Convert.ToInt32(ReferenceId.Text);
            eh.ExtendedTo = Convert.ToDateTime(ExtensionTo.Text);          
            eh.Remarks = Convert.ToString(Remarks.Text);
            new EmploymentBIZ().UpdateExtensionDetails(eh);
            ExtensionLV.EditIndex = -1;
            ExtensionLV.InsertItemPosition = InsertItemPosition.None;
            bindExtensionLV(empval);
            e.Cancel = true;


        }

        protected void Extension_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            TextBox ExtensionTo = (TextBox)ExtensionLV.InsertItem.FindControl("ExtendedToTxt");
            TextBox ReferenceId = (TextBox)ExtensionLV.InsertItem.FindControl("ReferenceIdTxt");
            TextBox Remarks = (TextBox)ExtensionLV.InsertItem.FindControl("RemarksTxt");
            ExtensionDetails eh = new ExtensionDetails();
            eh.SystemUsersId = empval;
            eh.EmploymentHistoryId = Convert.ToInt32(ReferenceId.Text);
            eh.ExtendedTo = Convert.ToDateTime(ExtensionTo.Text);
            eh.Remarks = Convert.ToString(Remarks.Text);
            new EmploymentBIZ().InsertExtensionDetails(eh);
            ExtensionLV.EditIndex = -1;
            ExtensionLV.InsertItemPosition = InsertItemPosition.None;
            bindExtensionLV(empval);
            e.Cancel = true;
            Response.Redirect("EmploymentDetails.aspx?empid=" + empval);

        }
        protected void Extension_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            ExtensionLV.EditIndex = -1;
            ExtensionLV.InsertItemPosition = InsertItemPosition.None;
            ExtensionLV.SelectedIndex = -1;
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindExtensionLV(empval);
            e.Cancel = true;
        }

        protected void Extension_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            ExtensionLV.InsertItemPosition = InsertItemPosition.None;
            ExtensionLV.SelectedIndex = -1;
            ExtensionLV.EditIndex = e.NewEditIndex;
            bindExtensionLV(empval);
            e.Cancel = true;

        }
        protected void Extension_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
          
        }
        protected void Extension_ItemCreated(object sender, ListViewItemEventArgs e)
        {
           
        }

        #endregion Extension


        #region RETIREMENT

        protected void bindRetirementLV(int EmpId)
        {
            List<EmpRetirement> re = new List<EmpRetirement>();
            re = new EmploymentBIZ().GetEmpRetirement(EmpId);
            RetirementLV.DataSource = re;
            RetirementLV.DataBind();
        }

        protected void newEmpRetirement_Click(object sender, EventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            RetirementLV.SelectedIndex = -1;
            RetirementLV.EditIndex = -1;
            RetirementLV.InsertItemPosition = InsertItemPosition.FirstItem;
            bindRetirementLV(empval);

        }


        protected void EmpRetirement_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField HidEmpRetirementId = (HiddenField)RetirementLV.Items[e.ItemIndex].FindControl("HidEmpRetirementId");
            int EmpRetirementId = Convert.ToInt32(HidEmpRetirementId.Value);
            new EmploymentBIZ().DeleteEmpRetirement(EmpRetirementId);
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindRetirementLV(empval);
        }
        protected void EmpRetirement_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            DropDownList RetirementTypeDDL = (DropDownList)RetirementLV.EditItem.FindControl("RetirementTypeDDL");
            HiddenField HidEmpRetirementId = RetirementLV.EditItem.FindControl("HidEmpRetirementId") as HiddenField;
            DropDownList RetirementModeDDL = (DropDownList)RetirementLV.EditItem.FindControl("RetirementModeDDL");
            TextBox RetirementDateTxt = (TextBox)RetirementLV.EditItem.FindControl("RetirementDateTxt");
            TextBox Remarks = (TextBox)RetirementLV.EditItem.FindControl("RemarksTxt");
            EmpRetirement eh = new EmpRetirement();
            eh.SystemUserId = empval;
            eh.EmpRetirementId = Convert.ToInt32(HidEmpRetirementId.Value);
            eh.RetirementTypeId = Convert.ToInt32(RetirementTypeDDL.SelectedItem.Value);
            eh.RetirementModeId = Convert.ToInt32(RetirementModeDDL.SelectedItem.Value);
            eh.RetirementDate = Convert.ToDateTime(RetirementDateTxt.Text);
            eh.Remarks = Convert.ToString(Remarks.Text);
            new EmploymentBIZ().UpdateEmpRetirement(eh);
            RetirementLV.EditIndex = -1;
            RetirementLV.InsertItemPosition = InsertItemPosition.None;
            bindRetirementLV(empval);
            e.Cancel = true;


        }

        protected void EmpRetirement_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            DropDownList RetirementTypeDDL = (DropDownList)RetirementLV.InsertItem.FindControl("RetirementTypeDDL");
            DropDownList RetirementModeDDL = (DropDownList)RetirementLV.InsertItem.FindControl("RetirementModeDDL");
            TextBox RetirementDateTxt = (TextBox)RetirementLV.InsertItem.FindControl("RetirementDateTxt");
            TextBox Remarks = (TextBox)RetirementLV.InsertItem.FindControl("RemarksTxt");
            EmpRetirement eh = new EmpRetirement();
            eh.SystemUserId = empval;
            eh.RetirementTypeId = Convert.ToInt32(RetirementTypeDDL.SelectedItem.Value);
            eh.RetirementModeId = Convert.ToInt32(RetirementModeDDL.SelectedItem.Value);
            eh.RetirementDate = Convert.ToDateTime(RetirementDateTxt.Text);
            eh.Remarks = Convert.ToString(Remarks.Text);
            new EmploymentBIZ().InsertEmpRetirement(eh);
            RetirementLV.EditIndex = -1;
            RetirementLV.InsertItemPosition = InsertItemPosition.None;
            bindRetirementLV(empval);
            e.Cancel = true;
            Response.Redirect("EmploymentDetails.aspx?empid=" + empval);

        }
        protected void EmpRetirement_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            RetirementLV.EditIndex = -1;
            RetirementLV.InsertItemPosition = InsertItemPosition.None;
            RetirementLV.SelectedIndex = -1;
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindRetirementLV(empval);
            e.Cancel = true;
        }

        protected void EmpRetirement_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            RetirementLV.InsertItemPosition = InsertItemPosition.None;
            RetirementLV.SelectedIndex = -1;
            RetirementLV.EditIndex = e.NewEditIndex;
            bindRetirementLV(empval);
            e.Cancel = true;

        }
        protected void EmpRetirement_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (RetirementLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)// || RegularEmploymentLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)  
            {
                DropDownList RetirementTypeDDL = e.Item.FindControl("RetirementTypeDDL") as DropDownList;
                HiddenField HidRetirementTypeId = (e.Item.FindControl("HidRetirementTypeId") as HiddenField);
                RetirementTypeDDL.SelectedValue = HidRetirementTypeId.Value.ToString();

                DropDownList RetirementModeDDL = e.Item.FindControl("RetirementModeDDL") as DropDownList;
                HiddenField HidRetirementModeId = (e.Item.FindControl("HidRetirementModeId") as HiddenField);
                RetirementModeDDL.SelectedValue = HidRetirementModeId.Value.ToString();

          }
        }
        protected void EmpRetirement_ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList EmpRetirementType = new DropDownList();
            TextBox RetirementDateTxt  = (e.Item.FindControl("RetirementDateTxt") as TextBox); 
             EmpRetirementType = (e.Item.FindControl("RetirementTypeDDL") as DropDownList);
            if (EmpRetirementType != null)
            {
                EmpRetirementType.Items.Add(new ListItem("Select", "0"));

                List<TempEntity> pt = new AdministrationBIZ().GetRetirementTypes();

                foreach (TempEntity row in pt)
                {
                    ListItem we = new ListItem();
                    we.Value = row.Id.ToString();
                    we.Text = row.Description.ToString();
                    EmpRetirementType.Items.Add(we);
                }
            }
            if (RetirementDateTxt != null)
            {
                int empval;
                empval = Convert.ToInt32(Request.QueryString["EmpId"]);
                RetirementDateTxt.Text= new EmployeeHandler().GetSuperannuationDate(empval).ToShortDateString();              
            }

            DropDownList RetirementModeDDL = new DropDownList();
            RetirementModeDDL = (e.Item.FindControl("RetirementModeDDL") as DropDownList);
            if (RetirementModeDDL != null)
            {
                RetirementModeDDL.Items.Add(new ListItem("Select", "0"));

                List<TempEntity> pt = new AdministrationBIZ().GetRetirementModes();

                foreach (TempEntity row in pt)
                {
                    ListItem qw = new ListItem();
                    qw.Value = row.Id.ToString();
                    qw.Text = row.Description.ToString();
                    RetirementModeDDL.Items.Add(qw);
                }
            }
        }
        #endregion RETIREMENT

    }
}