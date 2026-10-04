using System;
using System.Collections.Generic;
using System.Globalization;

namespace Notice.Utilities
{
    // Helpers for values coming from the calendar and member-chip controls.
    public static class FormInput
    {
        private static readonly string[] DateFormats = { "dd/MM/yyyy", "dd.MM.yyyy", "dd-MM-yyyy", "d/M/yyyy", "d.M.yyyy", "d-M-yyyy" };

        // Dates from the calendar arrive as dd/MM/yyyy whatever the server culture is.
        public static DateTime ParseDate(string text)
        {
            DateTime date;
            if (DateTime.TryParseExact((text ?? "").Trim(), DateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return date;
            return Convert.ToDateTime(text);
        }

        public static string FormatDate(DateTime date)
        {
            return date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        // Ids kept by a member chip box ("12,15,15,x"): whole numbers only, each one once, in the order picked.
        public static List<int> ParseIds(string csv)
        {
            List<int> ids = new List<int>();
            foreach (string part in (csv ?? "").Split(','))
            {
                int id;
                if (int.TryParse(part.Trim(), out id) && id > 0 && !ids.Contains(id))
                    ids.Add(id);
            }
            return ids;
        }

        // The "12,15," style list the business objects expect (a comma after every id), or null when nothing was picked.
        public static string ToCsv(List<int> ids)
        {
            if (ids == null || ids.Count == 0)
                return null;
            return string.Join(",", ids) + ",";
        }
    }
}
