using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstablishmentASP
{
    /// <summary>Server-side check that a "To" date is not earlier than its "From" date inside a ListView item.</summary>
    public static class HrmDates
    {
        private static readonly Dictionary<string, string> Pairs = new Dictionary<string, string>
        {
            { "ToDateTxt", "FromDateTxt" },
            { "DateToTxt", "DateFromTxt" },
            { "ProbationToTxt", "ProbationFromTxt" },
            { "PostedToTxt", "PostedFromTxt" },
            { "EmploymentToTxt", "EmploymentFromTxt" }
        };

        /// <summary>True when every From/To pair in the item is in order. Otherwise the item's DateRangeVal validator shows its message.</summary>
        public static bool RangeOk(Control item)
        {
            if (item == null) { return true; }
            bool ok = true;
            foreach (KeyValuePair<string, string> pair in Pairs)
            {
                TextBox to = item.FindControl(pair.Key) as TextBox;
                TextBox from = item.FindControl(pair.Value) as TextBox;
                if (from == null && pair.Key == "ToDateTxt")
                {
                    from = item.FindControl("EmploymentDateTxt") as TextBox;
                    if (from == null) { from = item.FindControl("AppointmentDateTxt") as TextBox; }
                }
                if (to == null || from == null) { continue; }
                DateTime dTo, dFrom;
                if (DateTime.TryParse(to.Text, CultureInfo.CurrentCulture, DateTimeStyles.None, out dTo) &&
                    DateTime.TryParse(from.Text, CultureInfo.CurrentCulture, DateTimeStyles.None, out dFrom) && dTo < dFrom)
                {
                    ok = false;
                    CustomValidator v = item.FindControl("DateRangeVal") as CustomValidator;
                    if (v != null) { v.IsValid = false; }
                }
            }
            return ok;
        }
    }
}
