using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EstablishmentENT;
using EstablishmentBIZ;

namespace EstablishmentASP
{
    public partial class Passport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int empval;
                empval = Convert.ToInt32(Request.QueryString["EmpId"]);
                bindPassportsLv(empval);
            }
        }
        //protected void EditDDL_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string CountryId = ((DropDownList)sender).SelectedValue;
        //    DropDownList fuControl=new DropDownList();
        //    fuControl = PassportsLv.EditItem.FindControl("IssueCityDDL") as DropDownList;
        //    fuControl.Items.Clear();
        //    List<City> cities = new AdministrationBIZ().GetCountryCities(Convert.ToInt32(CountryId));
        //    fuControl.Items.Add(new ListItem("Select","0"));
        //    if (cities != null)
        //    {
        //        foreach (City row in cities)
        //        {
        //            ListItem li = new ListItem();
        //            li.Text = row.Description;
        //            li.Value = row.CityId.ToString();
        //            fuControl.Items.Add(li);
        //        }
        //    }

        //}
        //protected void InsertDDL_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string CountryId = ((DropDownList)sender).SelectedValue;
        //    DropDownList fuControl = new DropDownList();
        //    fuControl = PassportsLv.InsertItem.FindControl("IssueCityDDL") as DropDownList;
        //    fuControl.Items.Clear();
        //    fuControl.Items.Add(new ListItem("Select", "0"));
        //    List<City> cities = new AdministrationBIZ().GetCountryCities(Convert.ToInt32(CountryId));
        //    if (cities != null)
        //    {
        //        foreach (City row in cities)
        //        {
        //            ListItem li = new ListItem();
        //            li.Text = row.Description;
        //            li.Value = row.CityId.ToString();
        //            fuControl.Items.Add(li);
        //        }
        //    }
        //}
        protected void bindPassportsLv(int EmpId)
        {
            List<EmpPassports> EmpPassportList = new EmployeeHandler().GetPassports(EmpId);
            PassportsLv.DataSource = EmpPassportList;
            PassportsLv.DataBind();
        
        }
        protected void ItemEditing(object sender, ListViewEditEventArgs e)
        {
            int empval;
            // string test = null;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            PassportsLv.InsertItemPosition = InsertItemPosition.None;
            PassportsLv.SelectedIndex = -1;
            PassportsLv.EditIndex = e.NewEditIndex;
            bindPassportsLv(empval);
            e.Cancel = true;


        }

        protected void ItemDataBound(object sender, ListViewItemEventArgs e)
        {

           
                if (PassportsLv.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
                {
                   
                DropDownList fuControl = e.Item.FindControl("PassportTypeDDL") as DropDownList;
                HiddenField EmpPassportid = (e.Item.FindControl("HidEmpPassportTypeId") as HiddenField);
                fuControl.SelectedValue = EmpPassportid.Value.ToString();

                    DropDownList country = e.Item.FindControl("IssuePlaceDDL") as DropDownList;
                    HiddenField IssuePlace = (e.Item.FindControl("EmpPassportCountryId") as HiddenField);
                    country.SelectedValue = IssuePlace.Value.ToString();
                    //if (IssuePlace.Value != "0")
                    //{
                    //    DropDownList city = e.Item.FindControl("IssueCityDDL") as DropDownList;
                    //    List<City> Ct = new AdministrationBIZ().GetCountryCities(Convert.ToInt32(IssuePlace.Value));

                    //    city.Items.Clear();
                    //    city.Items.Add(new ListItem("Select", "0"));
                    //    foreach (City row in Ct)
                    //    {
                    //        ListItem cy = new ListItem();
                    //        cy.Value = row.CityId.ToString();
                    //        cy.Text = row.Description.ToString();
                    //        city.Items.Add(cy);
                    //    }

                    //    HiddenField IssueCity = (e.Item.FindControl("EmpPassportCityId") as HiddenField);
                    //    city.SelectedValue = IssueCity.Value.ToString();
                    //}
                    

               
            }



        }
        protected void ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            PassportsLv.EditIndex = -1;
            PassportsLv.InsertItemPosition = InsertItemPosition.None;
            PassportsLv.SelectedIndex = -1;
            int empval;
            // string test = null;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindPassportsLv(empval);
            e.Cancel = true;
        }

        protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            DropDownList PassportTypeId = PassportsLv.EditItem.FindControl("PassportTypeDDL") as DropDownList;
            DropDownList CountryId = PassportsLv.EditItem.FindControl("IssuePlaceDDL") as DropDownList;
            TextBox PassportNumber = PassportsLv.EditItem.FindControl("PassportNumberTxt") as TextBox;
            TextBox IssueDate = PassportsLv.EditItem.FindControl("IssueDateTxt") as TextBox;
            TextBox ValidUpto = PassportsLv.EditItem.FindControl("ValidUptoTxt") as TextBox;
            HiddenField EmpPassportId = PassportsLv.EditItem.FindControl("HidEmpPassportId") as HiddenField;
            EmpPassports ep = new EmpPassports();
            ep.EmpId = empval;
            ep.EmpPassportId = Convert.ToInt32(EmpPassportId.Value);
            ep.PassportNumber = Convert.ToString(PassportNumber.Text);
            ep.IssueDate = Convert.ToDateTime(IssueDate.Text);
            ep.ValidUpto = Convert.ToDateTime(ValidUpto.Text);
            ep.PassportTypeId = Convert.ToInt32(PassportTypeId.SelectedItem.Value);
            ep.CountryId = Convert.ToInt32(CountryId.SelectedItem.Value);
            new EmployeeHandler().SaveEmployeePassport(ep);
            PassportsLv.EditIndex = -1;
            bindPassportsLv(empval);
            PassportsLv.InsertItemPosition = InsertItemPosition.None;
            PassportsLv.SelectedIndex = -1;
            e.Cancel = true;

        }
        protected void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField EmpPassportId = (HiddenField)PassportsLv.Items[e.ItemIndex].FindControl("HidEmpPassportId");
            int EmpPassId = Convert.ToInt32(EmpPassportId.Value);
            new EmployeeHandler().DeleteEmployeePassport(EmpPassId);
            int empval;
            // string test = null;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindPassportsLv(empval);
        }

        /* protected void SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
         {
             int empval;
             // string test = null;
             empval = Convert.ToInt32(Request.QueryString["EmpId"]);
             PassportsLv.InsertItemPosition = InsertItemPosition.None;
             PassportsLv.SelectedIndex = e.NewSelectedIndex;
             PassportsLv.EditIndex = -1;
             bindPassportsLv(empval);
             e.Cancel = true;
         }*/
        //protected void ItemUpdating(object sender, ListViewUpdateEventArgs e)
        //{

        //    int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
        //    DropDownList PassportTypeId = PassportsLv.EditItem.FindControl("PassportTypesDDL") as DropDownList;
        //    DropDownList CountryId = PassportsLv.EditItem.FindControl("IssuePlaceDDL") as DropDownList;
        //    DropDownList CityId = PassportsLv.EditItem.FindControl("IssueCityDDL") as DropDownList;
        //    TextBox PassportNumber = PassportsLv.EditItem.FindControl("PassportNumberTxt") as TextBox;
        //    TextBox IssueDate = PassportsLv.EditItem.FindControl("IssueDateTxt") as TextBox;
        //    TextBox ValidUpto = PassportsLv.EditItem.FindControl("ValidUptoTxt") as TextBox;
        //    HiddenField EmpPassportId = PassportsLv.EditItem.FindControl("HidEmpPassportId") as HiddenField;
        //    EmpPassports ep = new EmpPassports();
        //    ep.EmpId = empval;
        //    ep.EmpPassportId = Convert.ToInt32(EmpPassportId.Value);
        //    ep.PassportNumber = Convert.ToString(PassportNumber.Text);
        //    ep.IssueDate = Convert.ToDateTime(IssueDate.Text);
        //    ep.ValidUpto = Convert.ToDateTime(ValidUpto.Text);
        //    ep.PassportTypeId = Convert.ToInt32(PassportTypeId.SelectedItem.Value);
        //    ep.CountryId = Convert.ToInt32(CountryId.SelectedItem.Value);
        //    ep.CityId = Convert.ToInt32(CityId.SelectedItem.Value);
        //    new EmployeeHandler().SaveEmployeePassport(ep);
        //    PassportsLv.EditIndex = -1;
        //    bindPassportsLv(empval);
        //    //EmpPhones.InsertItemPosition = InsertItemPosition.None;
        //    //EmpPhones.SelectedIndex = -1;
        //    //e.Cancel = true;



        //}

        protected void ItemInserting(object sender, ListViewInsertEventArgs e)
         {
             // try
             //{
             int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
             TextBox PassportNo = (TextBox)PassportsLv.InsertItem.FindControl("PassportNumberTxt");
             TextBox IssueDate = (TextBox)PassportsLv.InsertItem.FindControl("IssueDateTxt");
             TextBox ValidUpto = (TextBox)PassportsLv.InsertItem.FindControl("ValidUptoTxt");
             DropDownList CountryID = (DropDownList)PassportsLv.InsertItem.FindControl("IssuePlaceDDL");
             DropDownList PassTypeID = (DropDownList)PassportsLv.InsertItem.FindControl("PassportTypeDDL");
             EmpPassports ep = new EmpPassports();
            // if (fuControl != null && PhoneNum != null)
            // {
                 ep.EmpId = empval;
                 ep.PassportNumber = Convert.ToString(PassportNo.Text);
                 ep.IssueDate = Convert.ToDateTime(IssueDate.Text);
                 ep.ValidUpto = Convert.ToDateTime(ValidUpto.Text);
                 ep.CountryId = Convert.ToInt32(CountryID.SelectedItem.Value);
                 ep.PassportTypeId = Convert.ToInt32(PassTypeID.SelectedItem.Value);
                 new EmployeeHandler().InsertEmployeePassport(ep);
                 PassportsLv.EditIndex = -1;                 
                 PassportsLv.InsertItemPosition = InsertItemPosition.None;
                 bindPassportsLv(empval);
           //  }
            e.Cancel = true;
           Response.Redirect("Passport.aspx?empid=" + empval);

        }
        protected void ItemCreated(object sender, ListViewItemEventArgs e)
        {
            List<Country> cy = new AdministrationBIZ().GetCountries();
            // ListViewItem lvi = PassportsLv.EditItem;
            DropDownList ddl = new DropDownList();
            ddl = (e.Item.FindControl("IssuePlaceDDL") as DropDownList);
            if (ddl != null)
            {
                ddl.Items.Add(new ListItem("Select", "0"));
                foreach (Country row in cy)
                {
                    ListItem ty = new ListItem();
                    ty.Value = row.CountryId.ToString();
                    ty.Text = row.Description.ToString();
                    ddl.Items.Add(ty);
                }

            }
            List<PassportTypes> pt = new AdministrationBIZ().GetPassportTypes();
            DropDownList ptddl = new DropDownList();
            ptddl = (e.Item.FindControl("PassportTypeDDL") as DropDownList);
            if (ptddl != null)
            {
                ptddl.Items.Add(new ListItem("Select", "0"));
                foreach (PassportTypes row in pt)
                {
                    ListItem lpt = new ListItem();
                    lpt.Value = row.PassportTypeId.ToString();
                    lpt.Text = row.Description.ToString();
                    ptddl.Items.Add(lpt);
                }
            
            
            
            }
        }
        protected string GetPassportType(int PassportTypeId)
        {
            if (PassportTypeId == 0)
                return "Not Mentioned";
            else
            {
                PassportTypes pt = new PassportTypes();
                pt = new AdministrationBIZ().GetPassportType(PassportTypeId);
                return pt.Description;
            }
        
        }
        protected string GetCountry(int CountryId)
        {
            if (CountryId == 0)
                return "Not Mentioned";
            else
            {
                Country cy = new Country();
                cy = new AdministrationBIZ().GetCountry(CountryId);
                return cy.Description;
            }

        
        }
        //protected string GetCity(int CityId)
        //{
        //    if (CityId == 0)
        //        return "Not Mentioned";
        //    else
        //    {
        //        City cy = new City();
        //        cy = new AdministrationBIZ().GetCity(CityId);
        //        return cy.Description;
        //    }


        //}
        protected void newLinkButton_Click(object sender, EventArgs e)
        {

            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            PassportsLv.SelectedIndex = -1;
            PassportsLv.EditIndex = -1;
            PassportsLv.InsertItemPosition = InsertItemPosition.FirstItem;
            bindPassportsLv(empval);

        }
    }
}