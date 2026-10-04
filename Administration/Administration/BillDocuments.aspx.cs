using BUDBIZ;
using BUDENTITIES;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administration
{
    public partial class BillDocuments : System.Web.UI.Page
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack == true)
        //    {
        //        BindDriversLV();
        //        int BillId = Convert.ToInt32(Request.QueryString["Id"]);
        //        Bills bill = new BudgetBiz().GetBill(BillId);
        //        if (bill != null)
        //            DriversLabel.Text = "BID:" + bill.BillId + "- " + bill.BillDescription;
        //        else
        //            DriversLabel.Text = "Documents";


        //    }

        //}
        //protected void BindDriversLV()
        //{
        //    int BillId = Convert.ToInt32(Request.QueryString["Id"]);
        //    List<BillDocumentsEnt> drivers = new BudgetBiz().GetBillDocuments(BillId);
        //    DriversLV.DataSource = drivers;
        //    DriversLV.DataBind();

        //}
        //protected void newLinkButton_Click(object sender, EventArgs e)
        //{

        //    int ModelId = Convert.ToInt32(Request.QueryString["Id"]);
        //    errorlbl.Text = "";
        //    BillDocumentsEnt itb = new BillDocumentsEnt();
        //    itb.BillId = ModelId;
        //    itb.DocumentDescription = DriverDesc.Text;
        //    if (driversFU.HasFile)
        //    {

        //        string strname = driversFU.FileName.ToString();
        //        //string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
        //        FileInfo fi = new FileInfo(strname);
        //        string ext = fi.Extension;
        //        string drivername = itb.BillId + "-" + itb.DocumentDescription + ext;
        //        driversFU.PostedFile.SaveAs(Server.MapPath("~//Bills//") + drivername);
        //        string url = drivername;
        //        itb.Url = url;
        //        new BudgetBiz().InsertBillDocument(itb);
        //        Response.Redirect("BillDocuments.aspx?Id=" + itb.BillId);
        //    }
        //    else
        //        errorlbl.Text = " Please select document";


        //}
        //protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        //{
        //    int ModelId = Convert.ToInt32(Request.QueryString["Id"]);
        //    HiddenField DriverId = (HiddenField)DriversLV.Items[e.ItemIndex].FindControl("HidDriverId");
        //    int driverid = Convert.ToInt32(DriverId.Value);
        //    BillDocumentsEnt driver = new BudgetBiz().GetBillDocument(driverid);
        //    File.Delete(Server.MapPath("~//Bills//" + driver.Url));
        //    new BudgetBiz().DeleteBillDocument(driverid);
        //    Response.Redirect("BillDocuments.aspx?Id=" + ModelId);
        //}
    }
}