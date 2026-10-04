using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Legislation
{
    /// <summary>
    /// Support for the searchable multi-select boxes (Scripts/qmschips.js).
    /// The browser keeps the selection in a hidden field as ids separated by commas and in a hidden text box as names
    /// separated by |. These helpers move that selection to and from the ListBox the save code already reads.
    /// </summary>
    public static class MultiPick
    {
        public static List<int> ParseIds(string csv)
        {
            List<int> ids = new List<int>();
            foreach (string part in (csv ?? "").Split(','))
            {
                int id;
                if (int.TryParse(part.Trim(), out id) && !ids.Contains(id))
                    ids.Add(id);
            }
            return ids;
        }

        /// <summary>Replaces the ListBox items with the selection made in the browser.</summary>
        public static void ToListBox(ListBox listBox, HiddenField ids, TextBox names)
        {
            List<int> idList = ParseIds(ids.Value);
            string[] nameList = (names.Text ?? "").Split('|');
            listBox.Items.Clear();
            for (int i = 0; i < idList.Count; i++)
            {
                string name = i < nameList.Length && nameList[i].Trim() != "" ? nameList[i].Trim() : "Item " + idList[i];
                listBox.Items.Add(new ListItem(name, idList[i].ToString()));
            }
        }

        /// <summary>Shows the ListBox items as chips in the browser.</summary>
        public static void FromListBox(ListBox listBox, HiddenField ids, TextBox names)
        {
            List<string> idList = new List<string>();
            List<string> nameList = new List<string>();
            foreach (ListItem item in listBox.Items)
            {
                idList.Add(item.Value);
                nameList.Add(item.Text.Replace("|", " ").Replace(",", " "));
            }
            ids.Value = string.Join(",", idList);
            names.Text = string.Join("|", nameList);
        }

        /// <summary>"(COLUMN LIKE '%,1,%' OR COLUMN LIKE '%,2,%')" for a column that stores ",1,2," style lists; empty when nothing is selected.</summary>
        public static string LikeAny(string column, string idsCsv)
        {
            List<string> parts = new List<string>();
            foreach (int id in ParseIds(idsCsv))
                parts.Add(column + " LIKE '%," + id + ",%'");
            return parts.Count == 0 ? "" : "(" + string.Join(" OR ", parts) + ")";
        }
    }
}
