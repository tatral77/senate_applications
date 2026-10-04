using LegisBIZ;
using LegisEntities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Legislation
{
    public partial class OrderOfDayBusiness : System.Web.UI.Page
    {
        private string LastBusinessType = null;
        private string LastBusinessRule = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.Enctype = "multipart/form-data";

            if (!IsPostBack)
            {
                LoadBusinessTypes();
                LoadOrderOfTheDayBusiness();
            }
        }

        private int GetOrderOfTheDayId()
        {
            int odId = 0;

            if (Request.QueryString["Id"] != null)
                int.TryParse(Request.QueryString["Id"], out odId);

            return odId;
        }

        private void LoadBusinessTypes()
        {
            BusinessTypeDDL.Items.Clear();

            List<BusinessType> businessTypes = new LegislationBiz().GetBusinessTypes();

            if (businessTypes == null)
                return;

            foreach (BusinessType row in businessTypes)
            {
                ListItem item = new ListItem();
                item.Value = row.BusinessTypeId.ToString();

                string description = row.Description;
                if (!string.IsNullOrEmpty(row.Rule))
                    description += " (" + row.Rule + ")";

                item.Text = description;
                BusinessTypeDDL.Items.Add(item);
            }
        }

        static string GetOrdinalSuffix(int day)
        {
            if (day % 100 >= 11 && day % 100 <= 13)
                return "th";

            switch (day % 10)
            {
                case 1: return "st";
                case 2: return "nd";
                case 3: return "rd";
                default: return "th";
            }
        }

        private void LoadOrderOfTheDayBusiness()
        {
            try
            {
                int odId = GetOrderOfTheDayId();
                OrderOfDay OrderOfDay = new LegislationBiz().GetOrderOfDayById(odId);
                SessionSittings sessionSittings = new AdministrationBiz().GetSessionSittingById(OrderOfDay.SessionSittingsId);

                MeetingTimeSpan.InnerHtml = $"<strong>{sessionSittings.StartTime:h:mm tt}".ToLower() + $"</strong> on <strong>{sessionSittings.SittingDate:dddd}, {sessionSittings.SittingDate.Day}{GetOrdinalSuffix(sessionSittings.SittingDate.Day)} {sessionSittings.SittingDate:MMMM}, {sessionSittings.SittingDate:yyyy}</strong>";

                if (odId <= 0)
                {
                    lv.DataSource = null;
                    lv.DataBind();
                    return;
                }

                List<OrderOfTheDayBusiness> list = new LegislationBiz().GetOrderOfTheDayBusiness(odId);

                if (list == null)
                    list = new List<OrderOfTheDayBusiness>();

                list.Sort(delegate (OrderOfTheDayBusiness x, OrderOfTheDayBusiness y)
                {
                    int typeResult = x.TypeSortOrder.CompareTo(y.TypeSortOrder);

                    if (typeResult != 0)
                        return typeResult;

                    return x.SortOrder.CompareTo(y.SortOrder);
                });

                LastBusinessType = null;
                LastBusinessRule = null;

                lv.DataSource = list;
                lv.DataBind();
            }
            catch (Exception ex)
            {
                ShowMessage("Unable to load agenda items. " + ex.Message);
            }
        }

        protected void AddAgenda_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedBusinessType = BusinessTypeDDL.SelectedValue;
                int odId = GetOrderOfTheDayId();

                if (odId <= 0)
                {
                    ShowMessage("Order of the Day ID is not available.");
                    return;
                }

                int businessTypeId = 0;
                int.TryParse(BusinessTypeDDL.SelectedValue, out businessTypeId);

                if (businessTypeId <= 0)
                {
                    ShowMessage("Please select Business Type.");
                    return;
                }

                int sortOrder = 0;
                int.TryParse(SortOrderTxt.Text.Trim(), out sortOrder);

                if (sortOrder <= 0)
                {
                    ShowMessage("Please enter a valid Sort Order.");
                    return;
                }

                string description = DescriptionTxt.Value;

                if (string.IsNullOrWhiteSpace(description))
                {
                    ShowMessage("Please enter Description.");
                    return;
                }

                OrderOfTheDayBusiness business = new OrderOfTheDayBusiness
                {
                    OrderOfDayId = odId,
                    BusinessTypesId = businessTypeId,
                    Description = description,
                    SortOrder = sortOrder,
                    Attachemnts = new List<OrderOfDayBusinessAttachment>()
                };

                LegislationBiz biz = new LegislationBiz();
                int odBusinessId = biz.InsertOrderOfTheDayBusiness(business);

                if (odBusinessId <= 0)
                {
                    ShowMessage("Unable to add Agenda Item.");
                    return;
                }

                SaveBusinessAttachments(odBusinessId, BusinessAttachments);
                LoadOrderOfTheDayBusiness();

                if (BusinessTypeDDL.Items.FindByValue(selectedBusinessType) != null)
                    BusinessTypeDDL.SelectedValue = selectedBusinessType;

                SortOrderTxt.Text = (sortOrder + 1).ToString();
                DescriptionTxt.Value = "";

                ShowMessage("Agenda Item added successfully.");
            }
            catch (Exception ex)
            {
                ShowMessage("Unable to add Agenda Item. " + ex.Message);
            }
        }

        private void SaveBusinessAttachments(int odBusinessId, FileUpload uploadControl)
        {
            if (odBusinessId <= 0 || uploadControl == null || !uploadControl.HasFiles)
                return;

            string folderPath = Server.MapPath("./contents/OD/");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            foreach (HttpPostedFile file in uploadControl.PostedFiles)
            {
                if (file == null || file.ContentLength <= 0)
                    continue;

                string extension = Path.GetExtension(file.FileName);

                if (string.IsNullOrWhiteSpace(extension))
                    continue;

                extension = extension.ToLowerInvariant();

                if (extension != ".pdf")
                {
                    ShowMessage("Only PDF files are allowed.");
                    continue;
                }

                string uniqueFileName = Guid.NewGuid().ToString("N") + extension;
                string physicalPath = Path.Combine(folderPath, uniqueFileName);

                file.SaveAs(physicalPath);

                OrderOfDayBusinessAttachment attachment = new OrderOfDayBusinessAttachment
                {
                    OrderOfDayBusinessId = odBusinessId,
                    Attachment = "./contents/OD/" + uniqueFileName
                };

                new LegislationBiz().InsertOrderOfDayBusinessAttachment(attachment);
            }
        }

        protected void lv_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            try
            {
                lv.EditIndex = e.NewEditIndex;
                LoadOrderOfTheDayBusiness();
                PopulateEditControls();
                ScrollToEditItem();
            }
            catch (Exception ex)
            {
                ShowMessage("Unable to open Agenda Item for editing. " + ex.Message);
            }
        }

        private void ScrollToEditItem()
        {
            string script = "if(typeof(scrollToActiveEditItem)==='function'){scrollToActiveEditItem();}";
            ScriptManager scriptManager = ScriptManager.GetCurrent(Page);

            if (scriptManager != null)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ScrollToEditItem", script, true);
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "ScrollToEditItem", script, true);
            }
        }

        private void PopulateEditControls()
        {
            if (lv.EditIndex < 0)
                return;

            ListViewDataItem item = lv.Items[lv.EditIndex] as ListViewDataItem;

            if (item == null)
                return;

            int odBusinessId = GetBusinessIdFromItem(item);

            if (odBusinessId <= 0)
            {
                ShowMessage("Invalid Agenda Item.");
                return;
            }

            OrderOfTheDayBusiness business = new LegislationBiz().GetOrderOfTheDayBusinessById(odBusinessId);

            if (business == null)
            {
                ShowMessage("Agenda Item not found.");
                return;
            }

            DropDownList ddl = item.FindControl("EditBusinessTypeDDL") as DropDownList;

            if (ddl != null)
            {
                LoadEditBusinessTypes(ddl);

                string selectedValue = business.BusinessTypesId.ToString();
                ListItem selectedItem = ddl.Items.FindByValue(selectedValue);

                if (selectedItem != null)
                {
                    ddl.ClearSelection();
                    selectedItem.Selected = true;
                }
            }

            TextBox sortOrder = item.FindControl("EditSortOrderTxt") as TextBox;

            if (sortOrder != null)
                sortOrder.Text = business.SortOrder.ToString();

            TextBox description = item.FindControl("EditDescriptionTxt") as TextBox;

            if (description != null)
                description.Text = business.Description ?? "";
        }

        private int GetBusinessIdFromItem(ListViewDataItem item)
        {
            if (item == null)
                return 0;

            int index = item.DisplayIndex;

            if (index < 0 || index >= lv.DataKeys.Count)
                return 0;

            DataKey dataKey = lv.DataKeys[index];

            if (dataKey == null || dataKey.Value == null)
                return 0;

            int id = 0;
            int.TryParse(dataKey.Value.ToString(), out id);

            return id;
        }

        private void LoadEditBusinessTypes(DropDownList ddl)
        {
            if (ddl == null)
                return;

            ddl.Items.Clear();

            List<BusinessType> businessTypes = new LegislationBiz().GetBusinessTypes();

            if (businessTypes == null)
                return;

            foreach (BusinessType row in businessTypes)
            {
                ListItem item = new ListItem
                {
                    Value = row.BusinessTypeId.ToString(),
                    Text = row.Description + " ( " + row.Rule + " )"
                };

                ddl.Items.Add(item);
            }
        }

        protected void lv_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            try
            {
                ListViewDataItem item = lv.Items[e.ItemIndex] as ListViewDataItem;

                if (item == null)
                {
                    ShowMessage("Unable to find Agenda Item.");
                    return;
                }

                int odBusinessId = GetBusinessIdFromItem(item);

                if (odBusinessId <= 0)
                {
                    ShowMessage("Invalid Agenda Item.");
                    ScrollToEditItem();
                    return;
                }

                DropDownList ddl = item.FindControl("EditBusinessTypeDDL") as DropDownList;
                TextBox sortOrderTxt = item.FindControl("EditSortOrderTxt") as TextBox;
                TextBox descriptionTxt = item.FindControl("EditDescriptionTxt") as TextBox;
                FileUpload editAttachments = item.FindControl("EditBusinessAttachments") as FileUpload;

                int businessTypeId = 0;

                if (ddl != null)
                    int.TryParse(ddl.SelectedValue, out businessTypeId);

                if (businessTypeId <= 0)
                {
                    ShowMessage("Please select Business Type.");
                    ScrollToEditItem();
                    return;
                }

                int sortOrder = 0;

                if (sortOrderTxt != null)
                    int.TryParse(sortOrderTxt.Text.Trim(), out sortOrder);

                if (sortOrder <= 0)
                {
                    ShowMessage("Please enter a valid Sort Order.");
                    ScrollToEditItem();
                    return;
                }

                string description = "";

                if (descriptionTxt != null)
                    description = descriptionTxt.Text;

                if (string.IsNullOrWhiteSpace(description))
                {
                    ShowMessage("Please enter Description.");
                    ScrollToEditItem();
                    return;
                }

                LegislationBiz biz = new LegislationBiz();
                OrderOfTheDayBusiness business = biz.GetOrderOfTheDayBusinessById(odBusinessId);

                if (business == null)
                {
                    ShowMessage("Agenda Item not found.");
                    ScrollToEditItem();
                    return;
                }

                business.BusinessTypesId = businessTypeId;
                business.SortOrder = sortOrder;
                business.Description = description;

                biz.UpdateOrderOfTheDayBusiness(business);

                RemoveCheckedAttachmentsSafely(item, odBusinessId);
                SaveBusinessAttachments(odBusinessId, editAttachments);

                lv.EditIndex = -1;
                LoadOrderOfTheDayBusiness();

                ShowMessage("Agenda Item updated successfully.");
            }
            catch (Exception ex)
            {
                ShowMessage("Unable to update Agenda Item. " + ex.Message);
                ScrollToEditItem();
            }
        }

        private void RemoveCheckedAttachmentsSafely(ListViewDataItem item, int odBusinessId)
        {
            if (item == null || odBusinessId <= 0)
                return;

            ListView attachmentList = item.FindControl("lvEditAttachments") as ListView;

            if (attachmentList == null)
                return;

            List<string> keepPaths = new List<string>();
            List<string> removePaths = new List<string>();

            foreach (ListViewDataItem attachmentItem in attachmentList.Items)
            {
                HiddenField pathHidden = attachmentItem.FindControl("AttachmentPathHidden") as HiddenField;
                CheckBox removeCheckBox = attachmentItem.FindControl("RemoveAttachmentChk") as CheckBox;

                if (pathHidden == null)
                    continue;

                string attachmentPath = pathHidden.Value;

                if (string.IsNullOrWhiteSpace(attachmentPath))
                    continue;

                if (removeCheckBox != null && removeCheckBox.Checked)
                    removePaths.Add(attachmentPath);
                else
                    keepPaths.Add(attachmentPath);
            }

            if (removePaths.Count == 0)
                return;

            LegislationBiz biz = new LegislationBiz();
            biz.DeleteOrderOfDayBusinessAttachments(odBusinessId);

            foreach (string keepPath in keepPaths)
            {
                OrderOfDayBusinessAttachment attachment = new OrderOfDayBusinessAttachment
                {
                    OrderOfDayBusinessId = odBusinessId,
                    Attachment = keepPath
                };

                biz.InsertOrderOfDayBusinessAttachment(attachment);
            }

            foreach (string removePath in removePaths)
                DeletePhysicalAttachmentFile(removePath);
        }

        private void DeletePhysicalAttachmentFile(string attachmentPath)
        {
            if (string.IsNullOrWhiteSpace(attachmentPath))
                return;

            try
            {
                string physicalPath = Server.MapPath(attachmentPath);

                if (File.Exists(physicalPath))
                    File.Delete(physicalPath);
            }
            catch
            {
                // Keep the page working even when physical file cleanup fails.
            }
        }

        protected void lv_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            lv.EditIndex = -1;
            LoadOrderOfTheDayBusiness();
        }

        protected void lv_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            try
            {
                int odBusinessId = 0;

                if (e.ItemIndex >= 0 && e.ItemIndex < lv.DataKeys.Count)
                {
                    DataKey dataKey = lv.DataKeys[e.ItemIndex];

                    if (dataKey != null && dataKey.Value != null)
                        int.TryParse(dataKey.Value.ToString(), out odBusinessId);
                }

                if (odBusinessId <= 0)
                {
                    ShowMessage("Invalid Agenda Item.");
                    return;
                }

                LegislationBiz biz = new LegislationBiz();
                OrderOfTheDayBusiness business = biz.GetOrderOfTheDayBusinessById(odBusinessId);

                if (business == null)
                {
                    ShowMessage("Agenda Item not found.");
                    return;
                }

                List<string> attachmentPaths = new List<string>();

                if (business.Attachemnts != null)
                {
                    foreach (OrderOfDayBusinessAttachment attachment in business.Attachemnts)
                    {
                        if (attachment == null || string.IsNullOrWhiteSpace(attachment.Attachment))
                            continue;

                        attachmentPaths.Add(attachment.Attachment);
                    }
                }

                if (attachmentPaths.Count > 0)
                    biz.DeleteOrderOfDayBusinessAttachments(odBusinessId);

                biz.DeleteOrderOfTheDayBusiness(odBusinessId);

                foreach (string attachmentPath in attachmentPaths)
                    DeletePhysicalAttachmentFile(attachmentPath);

                lv.EditIndex = -1;
                LoadOrderOfTheDayBusiness();

                ShowMessage("Agenda Item deleted successfully.");
            }
            catch (Exception ex)
            {
                ShowMessage("Unable to delete Agenda Item. " + ex.Message);
            }
        }

        protected void lv_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            LinkButton updateButton = e.Item.FindControl("UpdateButton") as LinkButton;

            if (updateButton != null)
            {
                ScriptManager scriptManager = ScriptManager.GetCurrent(Page);

                if (scriptManager != null)
                    scriptManager.RegisterPostBackControl(updateButton);
            }

            if (e.Item.ItemType != ListViewItemType.DataItem)
                return;

            Panel headerPanel = e.Item.FindControl("BusinessHeaderPanel") as Panel;

            if (headerPanel == null)
                return;

            ListViewDataItem dataItem = e.Item as ListViewDataItem;

            if (dataItem == null || dataItem.DataItem == null)
                return;

            Literal businessTypeLiteral = e.Item.FindControl("BusinessTypeLiteral") as Literal;
            Literal businessRuleLiteral = e.Item.FindControl("BusinessRuleLiteral") as Literal;

            string businessType = Convert.ToString(DataBinder.Eval(dataItem.DataItem, "BusinessTypesDescription"));
            string businessRule = Convert.ToString(DataBinder.Eval(dataItem.DataItem, "BusinessRule"));

            bool showHeader =
                !string.Equals(LastBusinessType, businessType, StringComparison.OrdinalIgnoreCase) ||
                !string.Equals(LastBusinessRule, businessRule, StringComparison.OrdinalIgnoreCase);

            headerPanel.Visible = showHeader;

            if (showHeader)
            {
                if (businessTypeLiteral != null)
                    businessTypeLiteral.Text = Server.HtmlEncode(businessType);

                if (businessRuleLiteral != null)
                    businessRuleLiteral.Text = Server.HtmlEncode(businessRule);
            }

            LastBusinessType = businessType;
            LastBusinessRule = businessRule;
        }

        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            // Reserved for future initialization.
        }

        private void ClearAddControls()
        {
            SortOrderTxt.Text = "1";
            DescriptionTxt.Value = "";
        }

        protected void PrintBtn_Click(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(GetType(), "PrintOrdersOfDay", "window.print();", true);
        }

        private void ShowMessage(string message)
        {
            if (message == null)
                message = "";

            string safeMessage = message.Replace("\\", "\\\\").Replace("'", "\\'").Replace("\r", "").Replace("\n", "\\n");
            string script = "alert('" + safeMessage + "');";
            ScriptManager scriptManager = ScriptManager.GetCurrent(Page);

            if (scriptManager != null)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString("N"), script, true);
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString("N"), script, true);
            }
        }
    }
}