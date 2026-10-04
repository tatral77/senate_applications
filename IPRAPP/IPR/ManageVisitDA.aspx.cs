using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IPRENTITIES;
using IPRBIZ;
using System.Web.UI.HtmlControls;

namespace IPR
{
    public partial class ManageVisitDA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindCompositionLV();
            }
            foreach (ListViewItem li in CompositionLV.Items)
            {
                HiddenField arr = (HiddenField)li.FindControl("arr");
                HtmlControl htmlDivControl = (HtmlControl)li.FindControl("facilitydiv");
                if (Convert.ToInt32(arr.Value) == 3)
                    (htmlDivControl.Style["display"]) = "normal";
                else
                    (htmlDivControl.Style["display"]) = "none";
                DropDownList FacilityDDL = (DropDownList)li.FindControl("FacilityDDL");
                int facillity = Convert.ToInt32(FacilityDDL.SelectedValue);
                HtmlControl div1 = (HtmlControl)li.FindControl("Div1");
                if (facillity == 2 || facillity == 4 || facillity == 5 || facillity == 7)
                {
                    (div1.Style["display"]) = "normal";
                }
                else
                {
                    (div1.Style["display"]) = "none";
                }

            }

        }
        protected void bindCompositionLV()
        {
            int VisitId = Convert.ToInt32(Request.QueryString["Id"]);
            List<Composition> composition = new IPRBiz().GetComposition(VisitId);
            CompositionLV.DataSource = composition;
            CompositionLV.DataBind();

        }
        protected string GetStyle(int ArrangementType)
        {
            if(ArrangementType==3)
            return "display:normal";
            else
                return "display:none";

        }

        protected void ArrangementDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem li in CompositionLV.Items)
            {
                DropDownList arrangementid = (DropDownList)li.FindControl("ArrangementDDL");
                HtmlControl htmlDivControl = (HtmlControl)li.FindControl("facilitydiv");
                  DropDownList FacilityDDL = (DropDownList)li.FindControl("FacilityDDL");
                int facillity = Convert.ToInt32(FacilityDDL.SelectedValue);
                HtmlControl div1 = (HtmlControl)li.FindControl("Div1");
                if (Convert.ToInt32(arrangementid.SelectedValue) == 3)
                {
                    (htmlDivControl.Style["display"]) = "normal";
                    (div1.Style["display"]) = "none";
                }
                else
                {
                    (htmlDivControl.Style["display"]) = "none";
                    (div1.Style["display"]) = "none";
                }
                if (facillity == 2 || facillity == 4 || facillity == 5 || facillity == 7)
                {
                    (div1.Style["display"]) = "normal";
                }
                else
                {
                    (div1.Style["display"]) = "none";
                }
            }
        }
        protected void FacilityDDL__SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem li in CompositionLV.Items)
            {
                DropDownList arrangementid = (DropDownList)li.FindControl("ArrangementDDL");
                DropDownList FacilityDDL = (DropDownList)li.FindControl("FacilityDDL");
                HtmlControl htmlDivControl = (HtmlControl)li.FindControl("facilitydiv");
                HtmlControl div1 = (HtmlControl)li.FindControl("Div1");
                int facillity = Convert.ToInt32(FacilityDDL.SelectedValue);
                if (Convert.ToInt32(arrangementid.SelectedValue) == 3)
                {
                    (htmlDivControl.Style["display"]) = "normal";
                    (div1.Style["display"]) = "none";
                }
                else
                {
                    (htmlDivControl.Style["display"]) = "none";
                    (div1.Style["display"]) = "none";
                }
                if ( facillity== 2 || facillity == 4 || facillity == 5 || facillity == 7)
                {
                    (div1.Style["display"]) = "normal";
                }
                else
                {
                    (div1.Style["display"]) = "none";
                }
            }
        }

        protected void SaveDADetails_Click(object sender, EventArgs e)
        {

        }
    }
}