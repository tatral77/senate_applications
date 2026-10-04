using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIZ;
using Entities;
using Notice.Utilities;

namespace Notice
{
    public partial class SearchBills : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindListView();
            }
        }

        // the list is read once, the category list is built from it, then the filters narrow it down
        private void bindListView()
        {
            List<Bills> bills = new NoticeBiz().GetNoticeBills() ?? new List<Bills>();

            if (BillCategoryDDL.Items.Count == 0)
            {
                BillCategoryDDL.Items.Add(new ListItem("All categories", ""));
                foreach (string category in bills.Where(b => b.BillCategories != null && !string.IsNullOrEmpty(b.BillCategories.Description))
                                                 .Select(b => b.BillCategories.Description).Distinct().OrderBy(c => c))
                    BillCategoryDDL.Items.Add(new ListItem(category, category));
            }

            IEnumerable<Bills> found = bills;
            FilterError.Text = "";

            string keyword = (KeywordTxt.Text ?? "").Trim();
            if (keyword != "")
            {
                found = found.Where(b => Contains(b.BillTitle, keyword) || Contains(b.Subject, keyword));
            }
            if (BillCategoryDDL.SelectedValue != "")
            {
                string category = BillCategoryDDL.SelectedValue;
                found = found.Where(b => b.BillCategories != null && b.BillCategories.Description == category);
            }
            try
            {
                if (!string.IsNullOrWhiteSpace(DateFromTxt.Text))
                {
                    DateTime from = FormInput.ParseDate(DateFromTxt.Text).Date;
                    found = found.Where(b => b.NoticeDiaryDate.Date >= from);
                }
                if (!string.IsNullOrWhiteSpace(DateToTxt.Text))
                {
                    DateTime to = FormInput.ParseDate(DateToTxt.Text).Date;
                    found = found.Where(b => b.NoticeDiaryDate.Date <= to);
                }
            }
            catch (FormatException)
            {
                FilterError.Text = "Enter the dates as dd/mm/yyyy.";
            }

            List<Bills> result = found.ToList();
            ListView1.DataSource = result;
            ListView1.DataBind();
            CountLbl.Text = result.Count == 0 ? "No bills found." : result.Count + (result.Count == 1 ? " bill found" : " bills found");
        }

        private static bool Contains(string text, string keyword)
        {
            return !string.IsNullOrEmpty(text) && text.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            bindListView();
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            KeywordTxt.Text = "";
            DateFromTxt.Text = "";
            DateToTxt.Text = "";
            if (BillCategoryDDL.Items.Count > 0)
                BillCategoryDDL.SelectedIndex = 0;
            bindListView();
        }

        public string GetDate(DateTime date)
        {
            if (date < new DateTime(1900, 1, 1))
                return "";
            else
                return FormInput.FormatDate(date);
        }

        public string GetLink(string BillId, string HouseTypeId)
        {
            string link = "~/NoticeBillDetail.aspx?Id=" + BillId;
            if (!string.IsNullOrEmpty(BillId) && !string.IsNullOrEmpty(HouseTypeId))
            {
                int typeid = Convert.ToInt32(HouseTypeId);
                if (typeid == 2)
                {
                    link = "~/NoticeNABillDetail.aspx?Id=" + BillId;
                }
            }
            return link;
        }
    }
}
