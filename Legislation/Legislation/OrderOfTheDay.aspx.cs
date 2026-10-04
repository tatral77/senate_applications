using LegisBIZ;
using LegisEntities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Legislation
{
    public partial class OrderOfTheDay : System.Web.UI.Page
    {
        private string LastBusinessType = null;

        private string LastBusinessRule = null;


        protected void Page_Load(
            object sender,
            EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOrderOfTheDayBusiness();
            }
        }


        private int GetOrderOfTheDayId()
        {
            int odId = 0;


            if (
                Request.QueryString["Id"]
                !=
                null
            )
            {
                int.TryParse(
                    Request.QueryString["Id"],
                    out odId
                );
            }


            return odId;
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
                OrderOfDay orderOfDay  = new LegislationBiz().GetActiveOrdersOfDayByCurrentSession();
                int odId = orderOfDay.OrderOfDaysId;
                SessionSittings sessionSittings = new AdministrationBiz().GetSessionSittingById(orderOfDay.SessionSittingsId);

                MeetingTimeSpan.InnerHtml = $"<strong>{sessionSittings.StartTime:h:mm tt}".ToLower() + $"</strong> on <strong>{sessionSittings.SittingDate:dddd}, {sessionSittings.SittingDate.Day}{GetOrdinalSuffix(sessionSittings.SittingDate.Day)} {sessionSittings.SittingDate:MMMM}, {sessionSittings.SittingDate:yyyy}</strong>";
                if (odId <= 0)
                {
                    lv.DataSource =
                        null;


                    lv.DataBind();


                    return;
                }


                List<OrderOfTheDayBusiness> list =
                    new LegislationBiz()
                        .GetOrderOfTheDayBusiness(
                            odId
                        );


                if (list == null)
                {
                    list =
                        new List<OrderOfTheDayBusiness>();
                }


                list.Sort(
                    delegate (
                        OrderOfTheDayBusiness x,
                        OrderOfTheDayBusiness y
                    )
                    {
                        int typeResult =
                            x.TypeSortOrder
                                .CompareTo(
                                    y.TypeSortOrder
                                );


                        if (typeResult != 0)
                        {
                            return typeResult;
                        }


                        return x.SortOrder
                            .CompareTo(
                                y.SortOrder
                            );
                    }
                );


                LastBusinessType =
                    null;


                LastBusinessRule =
                    null;


                lv.DataSource =
                    list;


                lv.DataBind();
            }
            catch (Exception ex)
            {
                ShowMessage(
                    "Unable to load Orders of the Day. "
                    +
                    ex.Message
                );
            }
        }


        protected void lv_ItemDataBound(
            object sender,
            ListViewItemEventArgs e)
        {
            if (
                e.Item.ItemType
                !=
                ListViewItemType.DataItem
            )
            {
                return;
            }


            ListViewDataItem dataItem =
                e.Item
                as
                ListViewDataItem;


            if (
                dataItem == null
                ||
                dataItem.DataItem == null
            )
            {
                return;
            }


            string businessType =
                Convert.ToString(
                    DataBinder.Eval(
                        dataItem.DataItem,
                        "BusinessTypesDescription"
                    )
                );


            string businessRule =
                Convert.ToString(
                    DataBinder.Eval(
                        dataItem.DataItem,
                        "BusinessRule"
                    )
                );


            Panel headerPanel =
                e.Item.FindControl(
                    "BusinessHeaderPanel"
                )
                as
                Panel;


            if (headerPanel == null)
            {
                return;
            }


            Literal businessTypeLiteral =
                e.Item.FindControl(
                    "BusinessTypeLiteral"
                )
                as
                Literal;


            Literal businessRuleLiteral =
                e.Item.FindControl(
                    "BusinessRuleLiteral"
                )
                as
                Literal;


            bool showHeader =
                !string.Equals(
                    LastBusinessType,
                    businessType,
                    StringComparison.OrdinalIgnoreCase
                )
                ||
                !string.Equals(
                    LastBusinessRule,
                    businessRule,
                    StringComparison.OrdinalIgnoreCase
                );


            headerPanel.Visible =
                showHeader;


            if (showHeader)
            {
                if (
                    businessTypeLiteral
                    !=
                    null
                )
                {
                    businessTypeLiteral.Text =
                        Server.HtmlEncode(
                            businessType
                        );
                }


                if (
                    businessRuleLiteral
                    !=
                    null
                )
                {
                    businessRuleLiteral.Text =
                        Server.HtmlEncode(
                            businessRule
                        );
                }
            }


            LastBusinessType =
                businessType;


            LastBusinessRule =
                businessRule;
        }


        private void ShowMessage(
            string message)
        {
            if (message == null)
            {
                message =
                    "";
            }


            string safeMessage =
                message
                    .Replace(
                        "\\",
                        "\\\\"
                    )
                    .Replace(
                        "'",
                        "\\'"
                    )
                    .Replace(
                        "\r",
                        ""
                    )
                    .Replace(
                        "\n",
                        "\\n"
                    );


            ClientScript
                .RegisterStartupScript(
                    GetType(),
                    Guid.NewGuid()
                        .ToString("N"),
                    "alert('"
                    +
                    safeMessage
                    +
                    "');",
                    true
                );
        }
    }
}