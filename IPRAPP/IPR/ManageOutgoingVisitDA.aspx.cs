using IPRBIZ;
using IPRENITITIES;
using IPRENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace IPR
{
    public partial class ManageOutgoingVisitDA : System.Web.UI.Page
    {
        DADetails dADetails = new DADetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCombos();
                BindVisitLV();
            }
        }
        protected void BindVisitLV()
        {
            int VisitId = Convert.ToInt32(Request.QueryString["Id"]);
            double TotalDA = 0;
            List<DADetails> dADetails = new IPRBiz().GetDADetails(VisitId);
            var OutgoingVisit = new IPRBiz().GetOutgoingVisit(VisitId);
            double dollarRate = OutgoingVisit.DollarRate;
            if (dADetails != null)
            {
                foreach(DADetails dA in dADetails)
                {
                    TotalDA += Math.Round(dA.Total);
                }
                TotalLbl.Text = "Grand Total: $ " + TotalDA.ToString("N0");
                CurrentyRateLbl.Text = "Currency in PKR: " + dollarRate.ToString(); //by ismail
                decimal TotalPKR = Math.Round((decimal)TotalDA * (decimal)dollarRate); //by ismail
                TotalPkrLbl.Text = "Total Rs: " + TotalPKR.ToString("N0") +" (Rupees " + DACalculations.ToWords(TotalPKR)+ ")"; //by ismail

                //       ToString() Formatting of 1054.32179:
                //          N:                     1,054.32 
                //          N0:                    1,054 
                //          N1:                    1,054.3 
                //          N2:                    1,054.32 
                //          N3:                    1,054.322 

            }
            VisitLV.DataSource = dADetails;
            VisitLV.DataBind();
        }
            protected void BindCombos()
        {
            CountryDDL.Items.Clear();
            ArrangementTypeDDL.Items.Clear();
            FacilityTypeDDL.Items.Clear();

            CountryDDL.Items.Add(new ListItem("Select", "0"));
            List<Country> country = new DataManagementBIZ().GetAllCountries();
            if (country != null)
            {
                foreach (Country row in country)
                {
                    ListItem li = new ListItem();
                    li.Value = row.CountryId.ToString();
                    li.Text = row.CountryName.ToString();
                    CountryDDL.Items.Add(li);
                }
            }

            ArrangementTypeDDL.Items.Add(new ListItem("Select Arrangement Type", "0"));
            List<VisitArrangementType> visitArrangementTypes = new IPRBiz().GetActiveVisitArrangementTypes();
            if (visitArrangementTypes != null)
            {
                foreach (VisitArrangementType row in visitArrangementTypes)
                {
                    ListItem li = new ListItem();
                    li.Value = row.VisitArrangementTypeId.ToString();
                    li.Text = row.ArrangementType.ToString();
                    ArrangementTypeDDL.Items.Add(li);
                }
            }

            FacilityTypeDDL.Items.Add(new ListItem("Select", "6"));
            List<VisitFacility> visitFacilities = new IPRBiz().GetActiveVisitFacilities();
            if (visitFacilities != null)
            {
                foreach (VisitFacility row in visitFacilities)
                {
                    ListItem li = new ListItem();
                    li.Value = row.VisitFacilityId.ToString();
                    li.Text = row.Facility.ToString();
                    FacilityTypeDDL.Items.Add(li);
                }
            }

            int VisitId = Convert.ToInt32(Request.QueryString["Id"]);
            List<Composition> composition = new IPRBiz().GetComposition(VisitId);
            MembersLV.DataSource = composition;
            MembersLV.DataBind();
        }

        protected void VisitLV_ItemCreated(object sender, ListViewItemEventArgs e)
        {
            DropDownList CountryDDL = new DropDownList();
            CountryDDL = (e.Item.FindControl("CountryDDL") as DropDownList);
            if (CountryDDL != null)
            {
                List<Country> country = new DataManagementBIZ().GetAllCountries();

                foreach (Country row in country)
                {
                    ListItem li = new ListItem();
                    li.Value = row.CountryId.ToString();
                    li.Text = row.CountryName.ToString();
                    CountryDDL.Items.Add(li);
                }
            }
        }

        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }

        protected void VisitLV_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                var visit = (DADetails)e.Item.DataItem;
                // Find the inner ListView in the current item template
                var visitorsLV = (ListView)e.Item.FindControl("VisitorsLV");
                if (visitorsLV != null)
                {
                    visitorsLV.DataSource = visit.Members;
                    visitorsLV.DataBind();
                }
            }
        }

        protected void VisitLV_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {

        }

        protected void VisitLV_ItemUpdated(object sender, ListViewUpdatedEventArgs e)
        {

        }

        protected void CheckAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem li in MembersLV.Items)
            {
                CheckBox cb = (CheckBox)li.FindControl("SelectCB");
                if (cb != null)
                {
                    if (CheckAllCB.Checked == true)
                        cb.Checked = true;
                    else
                        cb.Checked = false;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //VisitLV.SelectedIndex = -1;
            //VisitLV.EditIndex = -1;
            //VisitLV.InsertItemPosition = InsertItemPosition.FirstItem;
        }

        protected void CountryDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocationDDL.Items.Clear();
            int countryid = Convert.ToInt16(CountryDDL.SelectedValue);

            List<Location> locations = new IPRBiz().GetCountryLocations(countryid);
            if (locations != null)
            {
                foreach (Location row in locations)
                {
                    ListItem li = new ListItem();
                    li.Value = row.LocationId.ToString();
                    li.Text = row.LocationName.ToString();
                    LocationDDL.Items.Add(li);
                }
            }
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            int VisitId = Convert.ToInt32(Request.QueryString["Id"]);
            dADetails.VisitId = VisitId;
            dADetails.CountryId = Convert.ToInt32(CountryDDL.SelectedValue);
            dADetails.LocationId = Convert.ToInt32(LocationDDL.SelectedValue);
            dADetails.Location = Convert.ToString(LocationDDL.SelectedItem);
            //dADetails.NoOfNights =Convert.ToInt32(NoOfNightTxt.Text);  Commented by Ismail
            dADetails.ArrangementTypeId = Convert.ToInt32(ArrangementTypeDDL.SelectedValue);
            dADetails.FacilityId = Convert.ToInt32(FacilityTypeDDL.SelectedValue);
            dADetails.HotelCharges = Convert.ToDouble(HotelChargesTxt.Text);
            //dADetails.HigerSidePayment = Convert.ToDouble(HigherSidePaymentTxt.Text); Commented by Ismail
            dADetails.EarlyCheckinCharges = Convert.ToDouble(EarlyCheckInChargesTxt.Text);
            dADetails.LatecheckOutCharges  = Convert.ToDouble(LateCheckOutChargesTxt.Text);
            dADetails.FromDate = Convert.ToDateTime(FromDateTxt.Text); //by Ismail
            dADetails.ToDate = Convert.ToDateTime(ToDateTxt.Text); //by Ismail
            dADetails.NoOfNights = DateTimeExtensions.NumberOfNights(dADetails.FromDate, dADetails.ToDate); //DateTimeExtensions is an extension method that returns the Number of Nights
            if (MembersLV.Items.Count != 0)
            {
                dADetails.Members = new List<DAMember>();
                foreach (ListViewDataItem item in MembersLV.Items)
                {
                    DAMember dAMember = new DAMember(); ;
                    CheckBox checkslct = item.FindControl("SelectCB") as CheckBox;
                    if (checkslct != null)
                    {
                        if (checkslct.Checked)
                        {
                            HiddenField CompositionId = item.FindControl("HidCompositionId") as HiddenField;
                            HiddenField SystemUserId = item.FindControl("HidSystemUserId") as HiddenField;
                            HiddenField CategoryId = item.FindControl("HidCategoryId") as HiddenField;
                            HiddenField IsChairman = item.FindControl("HidIsChairman") as HiddenField;
                            TextBox RemarksTxt = item.FindControl("RemarksTxt") as TextBox;
                            Label VisitorName = item.FindControl("VisitorNameLbl") as Label;
                            Label Category = item.FindControl("CategoryNameLbl") as Label;
                            Label Post = item.FindControl("PostLabel") as Label;
                            if (CompositionId != null)
                            {
                                dAMember.CompositionId = Convert.ToInt32(CompositionId.Value);
                                dAMember.SystemUserId = Convert.ToInt32(SystemUserId.Value);
                                dAMember.CategoryId = Convert.ToInt32(CategoryId.Value);
                                dAMember.VisitorName= Convert.ToString(VisitorName.Text);
                                dAMember.Category = Convert.ToString(Category.Text);
                                dAMember.IsChairman = Convert.ToInt32(IsChairman.Value);
                                dAMember.Post= Convert.ToString(Post.Text);
                                dAMember.DaRemarks= Convert.ToString(RemarksTxt.Text);
                            }
                            dADetails.Members.Add(dAMember);
                        }
                    }
                }
            }
            int members = dADetails.Members.Count;
                if (members > 0)
                {
                    CalculateDA();
                    new IPRBiz().InsertDADetails(dADetails);
                    BindVisitLV();
                    ErrorLbl.Text = "";
                }
                else
                {
                    ErrorLbl.Text = "Please select members";
                }
            Response.Redirect("~/ManageOutgoingVisitDA.aspx?Id=" + VisitId);
        }

        protected void CalculateDA()
        {
            LocationCategoriesRates locationCategoryRates = new IPRBiz().GetLocationCategoriesRates(dADetails.LocationId, RateListId: 1);
            if (dADetails.Members != null)
            {
                foreach (DAMember member in dADetails.Members)
                {
                    if (member.IsChairman == 1)
                    {
                        int IsChairChargesPaid = new IPRBiz().GetIsChairChargesPaid(dADetails.VisitId);
                        if (IsChairChargesPaid == 0)
                        {
                            member.DaRemarks += "In addition, $ 2,000 is being paid. $ 1,000 on account of Personal Discretionary Allowance/Entertainment Charges and $ 1,000 on account of Additional Miscellaneous Expenses Advance. ";
                            member.Formula = $"2000 + ";
                            member.TotalDA += 2000;
                            dADetails.IsChairChargesPaid = 1;
                        }
                    }
                    switch (dADetails.ArrangementTypeId)
                    {
                        case 1: //Own Arrangement
                            {
                                member.TotalDA += DACalculations.CalculateAsOwnArrangement(member, locationCategoryRates, dADetails);
                                break;
                            }
                        case 2: //State Guest
                            {
                                member.TotalDA += DACalculations.CalculateAsStateGuest(member, locationCategoryRates, dADetails);
                                break;
                            }
                        case 3: //Partial Arrangement
                            {
                                member.TotalDA += DACalculations.CalculateAsPartialArrangement(member, locationCategoryRates, dADetails);
                                break;
                            }
                        case 4: //Transit
                            {
                                member.TotalDA += DACalculations.CalculateAsTransit(member, locationCategoryRates, dADetails);
                                break;
                            }
                        case 5: //Early Check-In / Late Check-Out
                            {
                                member.TotalDA += DACalculations.CalculateEarlyCheckInLateCheckOut(member, locationCategoryRates, dADetails);
                                break;
                            }
                        default: //Full  Coverage by Hosts
                            member.TotalDA += 0;
                         break;
                    }
                }
            }
        }

        protected void VisitLV_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            int VisitId = Convert.ToInt32(Request.QueryString["Id"]);
            HiddenField HidDAdetailId = (HiddenField)VisitLV.Items[e.ItemIndex].FindControl("HidDADetailId");
            new IPRBiz().DeleteDADetails(Convert.ToInt32(HidDAdetailId.Value));
            dADetails = null;
            Response.Redirect("~/ManageOutgoingVisitDA.aspx?Id=" + VisitId);
        }
    }
}