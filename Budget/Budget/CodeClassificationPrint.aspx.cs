using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUDENTITIES;
using BUDBIZ;

namespace Budget
{
    public partial class CodeClassificationPrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int BillId=Convert.ToInt32(Request.QueryString["Id"]);
            Bills bill = new BudgetBiz().GetBillById(BillId);
           demandno.InnerHtml = GetHtml(bill.DemandNumber);
           vendornumber.InnerHtml = GetHtml(bill.VendorNumber);
            vendor.InnerText = bill.VendorName.ToUpper();
            bankaccount.InnerText = bill.BankAccountNumber;
            bank.InnerText = bill.BankName;
            ddo.InnerHtml = GetControllingHtml(bill.MainId.Substring(0,4));
            clcode.InnerHtml = GetCLCode(bill.MainId.Substring(3, 1));
            cncode.InnerHtml = GetCLCode(bill.MainId.Substring(3, 1));
            paymentminor.InnerText = bill.MajorObject.Substring(0,3);
            paymentobject.InnerText = bill.HeadOfAccount.Substring(0,6);
            paymentamount.InnerText = bill.TotalAmount.ToString();
            dedamounttax.InnerText = bill.IncomeTax.ToString();
            dedamountgst.InnerText = bill.Gst.ToString();
            netamount.InnerText = "Net Payable Rs. " + bill.NetAmount.ToString();
            totalpayment.InnerText = bill.TotalAmount.ToString();
            totaldeduction.InnerText = (bill.IncomeTax + bill.Gst).ToString();
        }
        protected string GetHtml(string text)
        {
            char[] charArr = text.ToCharArray();
            string html = "<table style='border-collapse:collapse;'><tr>";
            foreach (char ch in charArr)
            {
                html = html + "<td class='td-bordered'>" + ch + "</td>";
            }
            html = html + "</tr></table>";
            return html;
        }
        protected string GetControllingHtml(string text)
        {
            char[] charArr = text.ToCharArray();
            string html = "<table style='border-collapse:collapse;'><tr><td class='td-bordered'></td><td class='td-bordered'></td><td class='td-bordered'></td><td style='width:20px;'></td><td class='td-bordered'>I</td><td class='td-bordered'>D</td>";
            foreach (char ch in charArr)
            {
                html = html + "<td class='td-bordered'>" + ch + "</td>";
            }
            html = html + "</tr></table>";
            return html;
        }
        protected string GetCLCode(string text)
        {
            int code = Convert.ToInt32(text);
            if (code != 1)
                code++;
            //char[] charArr = text.ToCharArray();
            string html = "<table style='border-collapse:collapse;'><tr><td class='td-bordered'>0</td><td class='td-bordered'>" + code + "</td>";
            html = html + "</tr></table>";
            return html;
        }
    }
}

