using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class EmpNOC
    {
        private int empNOCId;

        public int EmpNOCId
        {
            get { return empNOCId; }
            set { empNOCId = value; }
        }
        private int empId;

        public int EmpId
        {
            get { return empId; }
            set { empId = value; }
        }
        private string nocNumber;

        public string NocNumber
        {
            get { return nocNumber; }
            set { nocNumber = value; }
        }
        private DateTime nocDate;

        public DateTime NocDate
        {
            get { return nocDate; }
            set { nocDate = value; }
        }
        private int nocType;

        public int NocType
        {
            get { return nocType; }
            set { nocType = value; }
        }
        private int isactive;

        public int Isactive
        {
            get { return isactive; }
            set { isactive = value; }
        }
        private string remarks;

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
        public int UpdatedBy { get; set; }
        public int InsertedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime InsertedOn { get; set; }
    }
}
