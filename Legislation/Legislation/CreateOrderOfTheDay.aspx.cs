using LegisBIZ;
using LegisEntities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Legislation
{
    public partial class CreateOrderOfTheDay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSessionSittings();
                BindOrderOfDayTypes();
                bindListView1();
            }
        }

        private void BindSessionSittings()
        {
            SessionSittingDDL.Items.Clear();

            AssemblySessions ASession =
                new AdministrationBiz().GetCurrentAssemblySessionDetails();

            SessionSittingDDL.Items.Add(
                new ListItem("Select Session Sitting", "0")
            );

            if (ASession == null)
                return;

            List<SessionSittings> sessionSittings =
                new LegislationBiz()
                .GetSittingsForOrdersOfDay(ASession.AssemblySessionsId);

            if (sessionSittings == null)
                return;

            foreach (SessionSittings row in sessionSittings)
            {
                SessionSittingDDL.Items.Add(
                    new ListItem(
                        row.Description.ToString(),
                        row.SessionSittingsId.ToString()
                    )
                );
            }
        }

        private void BindOrderOfDayTypes()
        {
            ODTypeDDL.Items.Clear();

            ODTypeDDL.Items.Add(
                new ListItem("Select Order of the Day Type", "0")
            );

            List<OrderOfDayType> orderOfDayTypes =
                new LegislationBiz().GetOrderOfDayTypes();

            if (orderOfDayTypes == null)
                return;

            foreach (OrderOfDayType row in orderOfDayTypes)
            {
                ODTypeDDL.Items.Add(
                    new ListItem(
                        row.Description.ToString(),
                        row.OrderOfDayTypesId.ToString()
                    )
                );
            }
        }

        protected void bindListView1()
        {
            AssemblySessions ASession =
                new AdministrationBiz().GetCurrentAssemblySessionDetails();

            if (ASession == null)
            {
                lv.DataSource = null;
                lv.DataBind();
                return;
            }

            List<OrderOfDay> orderOfDays =
                new LegislationBiz()
                .GetOrdersOfDayBySession(ASession.AssemblySessionsId);

            lv.DataSource = orderOfDays;
            lv.DataBind();
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            if (SessionSittingDDL.SelectedValue == "0")
            {
                return;
            }

            if (ODTypeDDL.SelectedValue == "0")
            {
                return;
            }

            OrderOfDay orderOfDay = new OrderOfDay();

            orderOfDay.SessionSittingsId =
                Convert.ToInt32(SessionSittingDDL.SelectedValue);

            orderOfDay.OrderOfDayTypesId =
                Convert.ToInt32(ODTypeDDL.SelectedValue);

            orderOfDay.MainOrderDescription =
                Convert.ToString(MainDescriptionTxt.Text).Trim();

            orderOfDay.SupplementaryOrderDesc =
                Convert.ToString(SupplimentaryDescriptionTxt.Text).Trim();

            new LegislationBiz().InsertOrderOfDay(orderOfDay);

            lv.EditIndex = -1;

            bindListView1();
        }

        protected void lv_ItemEditing(
            object sender,
            ListViewEditEventArgs e)
        {
            lv.InsertItemPosition = InsertItemPosition.None;
            lv.SelectedIndex = -1;
            lv.EditIndex = e.NewEditIndex;

            bindListView1();

            e.Cancel = true;
        }

        protected void lv_ItemCanceling(
            object sender,
            ListViewCancelEventArgs e)
        {
            lv.EditIndex = -1;
            lv.InsertItemPosition = InsertItemPosition.None;
            lv.SelectedIndex = -1;

            bindListView1();

            e.Cancel = true;
        }

        protected void lv_ItemUpdating(
            object sender,
            ListViewUpdateEventArgs e)
        {
            ListViewDataItem item =
                lv.Items[e.ItemIndex] as ListViewDataItem;

            if (item == null)
                return;
          
             HiddenField HidSessionSittingsId =
                item.FindControl("HidSessionSittingsId") as HiddenField;
            HiddenField HidOrderOfDaysId =
                item.FindControl("HidOrderOfDaysId") as HiddenField;

            DropDownList EditODTypeDDL =
                item.FindControl("EditODTypeDDL") as DropDownList;

            TextBox MainOrderDescriptionTxt =
                item.FindControl("MainOrderDescriptionTxt") as TextBox;

            TextBox SupplementaryOrderDescTxt =
                item.FindControl("SupplementaryOrderDescTxt") as TextBox;

            DropDownList IsActiveDDL =
                item.FindControl("IsActiveDDL") as DropDownList;

            if (HidOrderOfDaysId == null ||
                EditODTypeDDL == null ||
                MainOrderDescriptionTxt == null ||
                SupplementaryOrderDescTxt == null ||
                IsActiveDDL == null)
            {
                return;
            }

            OrderOfDay ep = new OrderOfDay();

            ep.OrderOfDaysId =
                Convert.ToInt32(HidOrderOfDaysId.Value);
            ep.SessionSittingsId = Convert.ToInt32(HidSessionSittingsId.Value);

            ep.OrderOfDayTypesId =
                Convert.ToInt32(EditODTypeDDL.SelectedValue);

            ep.MainOrderDescription =
                MainOrderDescriptionTxt.Text.Trim();

            ep.SupplementaryOrderDesc =
                SupplementaryOrderDescTxt.Text.Trim();

            ep.IsActive =
                Convert.ToInt32(IsActiveDDL.SelectedValue);

            new LegislationBiz().UpdateOrderOfDay(ep);

            lv.EditIndex = -1;
            lv.InsertItemPosition = InsertItemPosition.None;
            lv.SelectedIndex = -1;

            bindListView1();

            e.Cancel = true;
        }

        protected void lv_DataBound(
            object sender,
            ListViewItemEventArgs e)
        {
            if (e.Item.ItemType != ListViewItemType.DataItem)
                return;

            ListViewDataItem dataItem =
                e.Item as ListViewDataItem;

            if (dataItem == null)
                return;

            if (lv.EditIndex != dataItem.DataItemIndex)
                return;

            DropDownList EditODTypeDDL =
                e.Item.FindControl("EditODTypeDDL") as DropDownList;

            HiddenField HidOrderOfDayTypesId =
                e.Item.FindControl("HidOrderOfDayTypesId") as HiddenField;

            DropDownList IsActiveDDL =
                e.Item.FindControl("IsActiveDDL") as DropDownList;

            HiddenField HidIsActive =
                e.Item.FindControl("HidIsActive") as HiddenField;

            if (EditODTypeDDL != null)
            {
                EditODTypeDDL.Items.Clear();

                List<OrderOfDayType> orderOfDayTypes =
                    new LegislationBiz().GetOrderOfDayTypes();

                if (orderOfDayTypes != null)
                {
                    foreach (OrderOfDayType row in orderOfDayTypes)
                    {
                        EditODTypeDDL.Items.Add(
                            new ListItem(
                                row.Description.ToString(),
                                row.OrderOfDayTypesId.ToString()
                            )
                        );
                    }
                }

                if (HidOrderOfDayTypesId != null)
                {
                    ListItem selectedItem =
                        EditODTypeDDL.Items.FindByValue(
                            HidOrderOfDayTypesId.Value
                        );

                    if (selectedItem != null)
                    {
                        EditODTypeDDL.ClearSelection();
                        selectedItem.Selected = true;
                    }
                }
            }

            if (IsActiveDDL != null && HidIsActive != null)
            {
                string activeValue =
                    Convert.ToString(HidIsActive.Value);

                ListItem selectedActiveItem =
                    IsActiveDDL.Items.FindByValue(activeValue);

                if (selectedActiveItem != null)
                {
                    IsActiveDDL.ClearSelection();
                    selectedActiveItem.Selected = true;
                }
            }
        }

        protected void lv_ItemDeleting(
            object sender,
            ListViewDeleteEventArgs e)
        {
            ListViewDataItem item =
                lv.Items[e.ItemIndex] as ListViewDataItem;

            if (item == null)
            {
                e.Cancel = true;
                return;
            }

            HiddenField HidOrderOfDaysId =
                item.FindControl("HidOrderOfDaysId") as HiddenField;

            if (HidOrderOfDaysId == null)
            {
                e.Cancel = true;
                return;
            }

            int orderOfDaysId =
                Convert.ToInt32(HidOrderOfDaysId.Value);

            /*
            Add your existing delete BIZ method here, for example:

            new LegislationBiz().DeleteOrderOfDay(orderOfDaysId);

            I have not invented the method because it was not present
            in the code you supplied.
            */

            e.Cancel = true;

            bindListView1();
        }

        public string GetLink(string Id)
        {
            return "~/OrderOfDayBusiness.aspx?Id=" + Id;
        }

        public string GetActiveText(object value)
        {
            if (value == null || value == DBNull.Value)
                return "Inactive";

            int isActive;

            if (int.TryParse(value.ToString(), out isActive))
            {
                return isActive == 1
                    ? "Active"
                    : "Inactive";
            }

            bool active;

            if (bool.TryParse(value.ToString(), out active))
            {
                return active
                    ? "Active"
                    : "Inactive";
            }

            return "Inactive";
        }

        public string GetActiveCss(object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return "status-badge status-inactive";
            }

            int isActive;

            if (int.TryParse(value.ToString(), out isActive))
            {
                return isActive == 1
                    ? "status-badge status-active"
                    : "status-badge status-inactive";
            }

            bool active;

            if (bool.TryParse(value.ToString(), out active))
            {
                return active
                    ? "status-badge status-active"
                    : "status-badge status-inactive";
            }

            return "status-badge status-inactive";
        }

        protected void AddNewBtn_Click(object sender, EventArgs e)
        {
            lv.SelectedIndex = -1;
            lv.EditIndex = -1;
            lv.InsertItemPosition = InsertItemPosition.FirstItem;

            bindListView1();
        }
    }
}