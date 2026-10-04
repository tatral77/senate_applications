using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class EmploymentHistory
    {
        private int historyId;
        public int HistoryId
        {
            get { return historyId; }
            set { historyId = value; }
        }



        private int empId;
        public int EmpId
        {
            get { return empId; }
            set { empId = value; }
        }


        private int desigId;
        public int DesigId
        {
            get { return desigId; }
            set { desigId = value; }
        }
        
        private string designation;
        public string Designation
        {
            get { return designation; }
            set { designation = value; }
        }
        
        private int branchId;
        public int BranchId
        {
            get { return branchId; }
            set { branchId = value; }
        }

        private string branch;
        public string Branch
        {
            get { return branch; }
            set { branch = value; }
        }

        private DateTime stayFrom;
        public DateTime StayFrom
        {
            get { return stayFrom; }
            set { stayFrom = value; }
        }
        private DateTime stayTo;

        public DateTime StayTo
        {
            get { return stayTo; }
            set { stayTo = value; }
        }
        private string rems;

        public string Rems
        {
            get { return rems; }
            set { rems = value; }
        }
        private int bpsId;

        public int BpsId
        {
            get { return bpsId; }
            set { bpsId = value; }
        }
        private string bps;

        public string Bps
        {
            get { return bps; }
            set { bps = value; }
        }

        private int isPromotion;

        public int IsPromotion
        {
            get { return isPromotion; }
            set { isPromotion = value; }
        }
        private int isGazetted;

        public int IsGazetted
        {
            get { return isGazetted; }
            set { isGazetted = value; }
        }
        public int UpdatedBy { get; set; }
        public int InsertedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime InsertedOn { get; set; }

    }
}
