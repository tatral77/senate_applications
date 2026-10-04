using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EstablishmentENT;
using EstablishmentBIZ;
using System.Globalization;
using System.IO;

namespace EstablishmentASP
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (!IsPostBack)
                {
                    bindFields();
                   bindPersonalInfo();
                }
      
        }

        private void bindFields()
        {
            //Gender
            List<Gender> gender = new AdministrationBIZ().GetGenders();
            foreach (Gender row in gender)
            {
                ListItem li = new ListItem();
                li.Text = row.Description;
                li.Value = row.GenderId.ToString();
                Gender.Items.Add(li);
            }
            gender.Clear();
            //Citis
            List<City> cities = new AdministrationBIZ().GetCities();
            foreach (City row in cities)
            {
                ListItem BCity = new ListItem();
                BCity.Text = row.Description;
                BCity.Value = row.CityId.ToString();
                BirthPlace.Items.Add(BCity);

            }

            foreach (City row in cities)
            {
                ListItem PCity = new ListItem();
                PCity.Text = row.Description;
                PCity.Value = row.CityId.ToString();
                PermCity.Items.Add(PCity);

            }
            foreach (City row in cities)
            {
                ListItem LCity = new ListItem();
                LCity.Text = row.Description;
                LCity.Value = row.CityId.ToString();
                LocalCity.Items.Add(LCity);

            }
            foreach (City row in cities)
            {
                ListItem IssCity = new ListItem();
                IssCity.Text = row.Description;
                IssCity.Value = row.CityId.ToString();
                CNICIssuePlace.Items.Add(IssCity);

            }
            cities.Clear();

            //Religion
            List<Religion> religions = new AdministrationBIZ().GetReligions();
            foreach (Religion row in religions)
            {
                ListItem rel = new ListItem();
                rel.Text = row.Description;
                rel.Value = row.ReligionId.ToString();
                Religion.Items.Add(rel);
            }
            religions.Clear();

            //Marital Status
            List<MaritalStatus> MarStatus = new AdministrationBIZ().GetMaritalStatuses();
            foreach (MaritalStatus row in MarStatus)
            {
                ListItem ms = new ListItem();
                ms.Text = row.Description;
                ms.Value = row.MaritalStatusId.ToString();
                MaritalStatus.Items.Add(ms);
            }
            MarStatus.Clear();

            //Provinces
            List<Province> prov = new AdministrationBIZ().GetProvinces();
            foreach (Province row in prov)
            {
                ListItem pr = new ListItem();
                pr.Text = row.Description;
                pr.Value = row.ProvincesID.ToString();
                PermProvince.Items.Add(pr);
            }
            prov.Clear();
            
            //List<District> dist = new AdministrationBIZ().GetDistricts();
            //foreach (District row in dist)
            //{
            //    ListItem dt = new ListItem();
            //    dt.Text = row.Description;
            //    dt.Value = row.DistrictId.ToString();
            //    DomDistrict.Items.Add(dt);
            //}
            //dist.Clear();

  }
        private void bindPersonalInfo()
        {

            int empval;
            // string test = null;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            PersonalDetail pd = new EmployeeHandler().GetPersonalDetails(empval);
            title.Text = pd.Title;
            PreviousNameTxt.Text=pd.PreviousName;
            NameChangeDateTxt.Text= GetDate(pd.NameChangeDate);
            EmpNametxt.Text = pd.FName;
            if (pd.MName != "")
                EmpNametxt.Text += " " + pd.MName;
            if (pd.LName != "")
                EmpNametxt.Text += " " + pd.LName;
            ActiveDDL.SelectedIndex = ActiveDDL.Items.IndexOf(ActiveDDL.Items.FindByValue(pd.IsActive.ToString()));
            Gender.SelectedIndex = Gender.Items.IndexOf(Gender.Items.FindByValue(pd.Gender.ToString()));
            BirthPlace.SelectedIndex = BirthPlace.Items.IndexOf(BirthPlace.Items.FindByValue(pd.BirthPlace.ToString()));
            PermCity.SelectedIndex = PermCity.Items.IndexOf(PermCity.Items.FindByValue(pd.PermCity.ToString()));
            LocalCity.SelectedIndex = LocalCity.Items.IndexOf(LocalCity.Items.FindByValue(pd.LocalCity.ToString()));
            CNICIssuePlace.SelectedIndex = CNICIssuePlace.Items.IndexOf(CNICIssuePlace.Items.FindByValue(pd.IssuePlace.ToString()));
            FatherNametxt.Text = pd.FatherNanme;
            DOB.Text = pd.Dob.ToShortDateString();
            CNIC.Text = pd.Cnic;
            CNICDate.Text = pd.CnicDate.ToShortDateString();
            CNICExpDateTxt.Text = GetDate(pd.cnicExpDate);
           //OldCNIC.Text = pd.OldCnic;
            NTN.Text = pd.Ntn;
            Religion.SelectedIndex = Religion.Items.IndexOf(Religion.Items.FindByValue(pd.Religion.ToString()));
            MaritalStatus.SelectedIndex = MaritalStatus.Items.IndexOf(MaritalStatus.Items.FindByValue(pd.MaritalStatus.ToString()));
            PermProvince.SelectedIndex = PermProvince.Items.IndexOf(PermProvince.Items.FindByValue(pd.PermProvince.ToString()));
            Fill_Districts(pd.PermProvince);

            DomDistrict.SelectedIndex = DomDistrict.Items.IndexOf(DomDistrict.Items.FindByValue(pd.DomDistrict.ToString()));
            PermAddress.Text = pd.PermAddress;
            LocalAddress.Text = pd.LocalAddress;
        //    EmailTxt.Text = pd.EMail;         
            bindPhoneList(empval);
            bindEmailList(empval);
        }
        protected void bindPhoneList(int empval)
        {
            List<EmployeePhones> EmpPhoneList = new EmployeeHandler().GetEmployeePhones(empval);
            EmpPhones.DataSource = EmpPhoneList;
            EmpPhones.DataBind();

        }
            protected void Savebtn_Click(object sender, EventArgs e)
            {

                PersonalDetail pd = new PersonalDetail();
                pd.Userid =  Convert.ToInt32(Request.QueryString["EmpId"]);
                pd.PreviousName = PreviousNameTxt.Text;
            if (!String.IsNullOrEmpty(NameChangeDateTxt.Text))
                pd.NameChangeDate= Convert.ToDateTime(NameChangeDateTxt.Text);
                pd.FName = EmpNametxt.Text;
                pd.FatherNanme = FatherNametxt.Text;
                pd.Gender = Convert.ToInt32(Gender.SelectedValue);
                //pd.Dob = Convert.ToDateTime(DOB.Text,"mm/dd/yyy");
                pd.Dob = Convert.ToDateTime(DOB.Text);
                pd.BirthPlace = Convert.ToInt32(BirthPlace.SelectedValue);
                pd.Cnic = CNIC.Text;
            if (!String.IsNullOrEmpty(CNICDate.Text))
                pd.CnicDate = Convert.ToDateTime(CNICDate.Text);
                if(!String.IsNullOrEmpty(CNICExpDateTxt.Text))
                pd.cnicExpDate= Convert.ToDateTime(CNICExpDateTxt.Text);
            //pd.OldCnic = OldCNIC.Text;
         //   pd.EMail = EmailTxt.Text;
                pd.Ntn = NTN.Text;
                pd.LocalAddress = LocalAddress.Text;
                pd.PermAddress = PermAddress.Text;
                pd.LocalCity = Convert.ToInt32(LocalCity.SelectedValue);
                pd.PermCity = Convert.ToInt32(PermCity.SelectedValue);
                pd.Religion = Convert.ToInt32(Religion.SelectedValue);
                pd.Title = title.Text;
                pd.MaritalStatus = Convert.ToInt32(MaritalStatus.SelectedValue);
                pd.IssuePlace = Convert.ToInt32(CNICIssuePlace.SelectedValue);
                pd.PermProvince = Convert.ToInt32(PermProvince.SelectedValue);
                pd.DomDistrict = Convert.ToInt32(DomDistrict.SelectedValue);
                pd.IsActive = Convert.ToInt32(ActiveDDL.SelectedValue);
            new EmployeeHandler().SavePersonalInfo(pd);
                
                
            }
            protected void Phone_ItemInserting(object sender, ListViewInsertEventArgs e)
            {
                int empval;
                empval = Convert.ToInt32(Request.QueryString["EmpId"]);
                List<PhoneTypes> pt = new AdministrationBIZ().GePhoneTypes();
                ListViewItem lvi = EmpPhones.InsertItem;
                DropDownList fuControl = (DropDownList)lvi.FindControl("PhoneTypesDDL");
                foreach (PhoneTypes row in pt)
                {
                    ListItem ty = new ListItem();
                    ty.Value = row.PhoneTypeID.ToString();
                    ty.Text = row.Description.ToString();
                    fuControl.Items.Add(ty);
                }
                HiddenField empphoneid = (HiddenField)lvi.FindControl("HidEmpPhoneId");
                HiddenField empphonetype = (HiddenField)lvi.FindControl("HidPhoneTypeId");
            }


            protected void Phones_ItemEditing(object sender, ListViewEditEventArgs e)
            {
                int empval;
                empval = Convert.ToInt32(Request.QueryString["EmpId"]);
                EmpPhones.InsertItemPosition = InsertItemPosition.None;
                EmpPhones.SelectedIndex = -1;
                EmpPhones.EditIndex = e.NewEditIndex;
                bindPhoneList(empval);
                e.Cancel = true;
               
                
            }

            protected void OnItemDataBound(object sender, ListViewItemEventArgs e)
            {
                List<PhoneTypes> pt = new AdministrationBIZ().GePhoneTypes();
                if (EmpPhones.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
                {
                    DropDownList fuControl = e.Item.FindControl("PhoneTypesDDL") as DropDownList;
                    foreach (PhoneTypes row in pt)
                    {
                        ListItem ty = new ListItem();
                        ty.Value = row.PhoneTypeID.ToString();
                        ty.Text = row.Description.ToString();
                        fuControl.Items.Add(ty);
                    }
                    HiddenField empphoneid = (e.Item.FindControl("HidEmpPhoneId") as HiddenField);
                    HiddenField empphonetype = (e.Item.FindControl("HidPhoneTypeId") as HiddenField);
                    fuControl.SelectedValue = empphonetype.Value.ToString();
                }


            }
                             
                       
            
            
            protected void EmpPhones_ItemUpdating(object sender, ListViewUpdateEventArgs e)
            {
                      
                int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
                DropDownList fuControl = EmpPhones.EditItem.FindControl("PhoneTypesDDL") as DropDownList;
                TextBox PhoneNum = EmpPhones.EditItem.FindControl("PhoneNumberTxt") as TextBox;
                HiddenField empphoneid = EmpPhones.EditItem.FindControl("HidEmpPhoneId") as HiddenField;
                EmployeePhones ep = new EmployeePhones();
                ep.EmpId = empval;
                ep.EmpPhoneId = Convert.ToInt32(empphoneid.Value);
                ep.PhoneNumber = Convert.ToString(PhoneNum.Text);
                ep.PhoneTypeId = Convert.ToInt32(fuControl.SelectedItem.Value);
                new EmployeeHandler().SaveEmployeePhones(ep);
                EmpPhones.EditIndex = -1;
                bindPhoneList(empval);
            EmpPhones.InsertItemPosition = InsertItemPosition.None;
            EmpPhones.SelectedIndex = -1;
            e.Cancel = true;



        }
        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToShortDateString();
        }
        protected void EmpPhones_ItemDeleting(object sender, ListViewDeleteEventArgs e)
            {
                HiddenField EmpPhoneId=(HiddenField) EmpPhones.Items[e.ItemIndex].FindControl("HidEmpPhoneId");
                int EmpPhId = Convert.ToInt32(EmpPhoneId.Value);
                new EmployeeHandler().DeleteEmployeePhones(EmpPhId);
                int empval;
                empval = Convert.ToInt32(Request.QueryString["EmpId"]);
                bindPhoneList(empval);
            }
            
            protected void EmpPhones_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
            {
                int empval;
                empval = Convert.ToInt32(Request.QueryString["EmpId"]);
                EmpPhones.InsertItemPosition = InsertItemPosition.None;
                EmpPhones.SelectedIndex = e.NewSelectedIndex;
                EmpPhones.EditIndex = -1;
                bindPhoneList(empval);
                e.Cancel = true;
            }
            protected void EmpPhones_ItemCanceling(object sender, ListViewCancelEventArgs e)
            {
                EmpPhones.EditIndex = -1;
                EmpPhones.InsertItemPosition = InsertItemPosition.None;
                EmpPhones.SelectedIndex = -1;
                int empval;
                empval = Convert.ToInt32(Request.QueryString["EmpId"]);
                bindPhoneList(empval);
                e.Cancel = true;
            }
            protected void EmpPhones_ItemInserting(object sender, ListViewInsertEventArgs e)
            {
              
                    int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
                    DropDownList fuControl = (DropDownList)EmpPhones.InsertItem.FindControl("PhoneTypesDDL");
                    TextBox PhoneNum = (TextBox)EmpPhones.InsertItem.FindControl("PhoneNumberTxt");
                    EmployeePhones ep = new EmployeePhones();
                    Response.Write(Convert.ToString(PhoneNum.Text));
                    Response.Write("--" + Convert.ToInt32(fuControl.SelectedItem.Value));
                    Response.Write("--" + empval);
                 if (fuControl != null && PhoneNum != null)
                    {
                        ep.EmpId = empval;
                        ep.PhoneNumber = Convert.ToString(PhoneNum.Text);
                        ep.PhoneTypeId = Convert.ToInt32(fuControl.SelectedItem.Value);
                        new EmployeeHandler().InsertEmployeePhones(ep);
                        EmpPhones.EditIndex = -1;
                        EmpPhones.InsertItemPosition = InsertItemPosition.None;
                        bindPhoneList(empval);
                    }
                    e.Cancel = true;
                               
               
            }
          

            protected void newLinkButton_Click(object sender, EventArgs e)
            {
                List<PhoneTypes> pt = new AdministrationBIZ().GePhoneTypes();
                int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
                EmpPhones.SelectedIndex = -1;
                EmpPhones.EditIndex = -1;
                EmpPhones.InsertItemPosition = InsertItemPosition.FirstItem;
                bindPhoneList(empval);
                DropDownList fuControl = (DropDownList)EmpPhones.InsertItem.FindControl("PhoneTypesDDL");
                foreach (PhoneTypes row in pt)
                {
                    ListItem ty = new ListItem();
                    ty.Value = row.PhoneTypeID.ToString();
                    ty.Text = row.Description.ToString();
                    fuControl.Items.Add(ty);
                }
                HiddenField empphoneid = (EmpPhones.FindControl("HidEmpPhoneId") as HiddenField);
                HiddenField empphonetype = (EmpPhones.FindControl("HidPhoneTypeId") as HiddenField);
            
     
            }
            protected void Fill_Districts(object sender, EventArgs e)
            {
                DomDistrict.Items.Clear();
                DomDistrict.Items.Add(new ListItem("Select", "0"));
                int provinceid = Convert.ToInt32(PermProvince.SelectedValue);
                if (provinceid != 0)
                {
                    List<District> Dit = new AdministrationBIZ().GetDistricts(provinceid);
                    if (Dit != null)
                    {
                        foreach (District row in Dit)
                        {
                            ListItem dtl = new ListItem();
                            dtl.Value = row.DistrictId.ToString();
                            dtl.Text = row.Description.ToString();
                            DomDistrict.Items.Add(dtl);
                        }
                    }
                }
       
            }
        protected void Fill_Districts(int ProvinceId)
        {
            DomDistrict.Items.Clear();
            DomDistrict.Items.Add(new ListItem("Select", "0"));
            if (ProvinceId != 0)
            {
                List<District> Dit = new AdministrationBIZ().GetDistricts(ProvinceId);
                if (Dit != null)
                {
                    foreach (District row in Dit)
                    {
                        ListItem dtl = new ListItem();
                        dtl.Value = row.DistrictId.ToString();
                        dtl.Text = row.Description.ToString();
                        DomDistrict.Items.Add(dtl);
                    }
                }
            }

        }

        protected void bindEmailList(int empval)
        {
            List<UserEmails> emails = new EmployeeHandler().GetEmployeeEmails(empval);
            EmailLV.DataSource = emails;
            EmailLV.DataBind();

        }
        protected void Email_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            EmailLV.InsertItemPosition = InsertItemPosition.None;
            EmailLV.SelectedIndex = -1;
            EmailLV.EditIndex = e.NewEditIndex;
            bindEmailList(empval);
            e.Cancel = true;


        }

        protected void OnEmailItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (EmailLV.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                
                CheckBox IsOfficialCB = e.Item.FindControl("IsOfficial") as CheckBox;
                HiddenField HidIsOfficial = (e.Item.FindControl("HidIsOfficial") as HiddenField);
                int chk = Convert.ToInt32(HidIsOfficial.Value);
                if (chk == 1)
                    IsOfficialCB.Checked = true;
                else
                    IsOfficialCB.Checked = false;
            }


        }




        protected void Email_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            HiddenField useremailid = EmailLV.EditItem.FindControl("HidUserEmailId") as HiddenField; 
            TextBox email = EmailLV.EditItem.FindControl("EmailTxt") as TextBox;
            CheckBox isofficial = EmailLV.EditItem.FindControl("IsOfficial") as CheckBox;
            UserEmails ep = new UserEmails();
            ep.SystemUsersId = empval;
            ep.UserEmailId = Convert.ToInt32(useremailid.Value);
            ep.Email = Convert.ToString(email.Text);
            ep.IsOfficial = isofficial.Checked == true ? 1 : 0;
            new EmployeeHandler().UpdateEmployeeEmail(ep);
            EmailLV.EditIndex = -1;
             bindEmailList(empval);
            EmailLV.InsertItemPosition = InsertItemPosition.None;
            EmailLV.SelectedIndex = -1;
            EmailLV.EditIndex = -1;
            e.Cancel = true;



        }
       
        protected void Email_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            HiddenField useremailid = (HiddenField)EmailLV.Items[e.ItemIndex].FindControl("HidUserEmailId");
            int emailid = Convert.ToInt32(useremailid.Value);
            new EmployeeHandler().DeleteEmployeeEmail(emailid);
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindEmailList(empval);
        }

        protected void Email_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            EmailLV.InsertItemPosition = InsertItemPosition.None;
            EmailLV.SelectedIndex = e.NewSelectedIndex;
            EmailLV.EditIndex = -1;
            bindEmailList(empval);
            e.Cancel = true;
        }
        protected void Email_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            EmailLV.EditIndex = -1;
            EmailLV.InsertItemPosition = InsertItemPosition.None;
            EmailLV.SelectedIndex = -1;
            int empval;
            empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            bindEmailList(empval);
            e.Cancel = true;
        }
        protected void Email_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            TextBox email = (TextBox)EmailLV.InsertItem.FindControl("EmailTxt");
            CheckBox isofficial= (CheckBox)EmailLV.InsertItem.FindControl("IsOfficial");
            UserEmails ep = new UserEmails();
         
                ep.SystemUsersId = empval;
                ep.Email = Convert.ToString(email.Text);
                 ep.IsOfficial = isofficial.Checked == true ? 1 : 0;
                new EmployeeHandler().InsertEmployeeEmail(ep);
            EmailLV.EditIndex = -1;
            EmailLV.InsertItemPosition = InsertItemPosition.None;
            bindEmailList(empval);

            e.Cancel = true;


        }


        protected void NewEmailBtn_Click(object sender, EventArgs e)
        {

            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            EmailLV.SelectedIndex = -1;
            EmailLV.EditIndex = -1;
            EmailLV.InsertItemPosition = InsertItemPosition.FirstItem;
            bindEmailList(empval);          


        }
        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            int empval = Convert.ToInt32(Request.QueryString["EmpId"]);
            int chk = new EmployeeHandler().DeleteEmployee(empval);
            if (chk == 0)
                err.Text = "Please delete all data before deleting an employee.";
            else
                Response.Redirect("/SearchEmployee.aspx");
        }


    }
}