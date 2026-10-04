using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class PersonalDetail
    {
        private int userid;

        public int Userid
        {
            get { return userid; }
            set { userid = value; }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string PreviousName { get; set; }
        public DateTime NameChangeDate { get; set; }
        private string fName;

        public string FName
        {
            get { return fName; }
            set { fName = value; }
        }
        private string mName;

        public string MName
        {
            get { return mName; }
            set { mName = value; }
        }
        private string lName;

        public string LName
        {
            get { return lName; }
            set { lName = value; }
        }
        private string fatherNanme;

        public string FatherNanme
        {
            get { return fatherNanme; }
            set { fatherNanme = value; }
        }
        private int gender;

        public int Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        private DateTime dob;

        public DateTime Dob
        {
            get { return dob; }
            set { dob = value; }
        }
        private int birthPlace;

        public int BirthPlace
        {
            get { return birthPlace; }
            set { birthPlace = value; }
        }
        private string cnic;

        public string Cnic
        {
            get { return cnic; }
            set { cnic = value; }
        }
        private DateTime cnicDate;

        public DateTime CnicDate
        {
            get { return cnicDate; }
            set { cnicDate = value; }
        }
        public DateTime cnicExpDate { get; set; }
        private int issuePlace;

        public int IssuePlace
        {
            get { return issuePlace; }
            set { issuePlace = value; }
        }
        private string oldCnic;

        public string OldCnic
        {
            get { return oldCnic; }
            set { oldCnic = value; }
        }
        private string ntn;

        public string Ntn
        {
            get { return ntn; }
            set { ntn = value; }
        }
        private int religion;

        public int Religion
        {
            get { return religion; }
            set { religion = value; }
        }
        private int maritalStatus;

        public int MaritalStatus
        {
            get { return maritalStatus; }
            set { maritalStatus = value; }
        }
        private int permProvince;

        public int PermProvince
        {
            get { return permProvince; }
            set { permProvince = value; }
        }
        private int domDistrict;

        public int DomDistrict
        {
            get { return domDistrict; }
            set { domDistrict = value; }
        }
        private string permAddress;

        public string PermAddress
        {
            get { return permAddress; }
            set { permAddress = value; }
        }
        private int permCity;

        public int PermCity
        {
            get { return permCity; }
            set { permCity = value; }
        }
        private string localAddress;

        public string LocalAddress
        {
            get { return localAddress; }
            set { localAddress = value; }
        }
        private int localCity;

        public int LocalCity
        {
            get { return localCity; }
            set { localCity = value; }
        }
        private string eMail;
     

        public string EMail
        {
            get { return eMail; }
            set { eMail = value; }
        }
        public int IsActive { get; set; }
        public int UpdatedBy { get; set; }
        public int InsertedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime InsertedOn { get; set; }

    }
}
