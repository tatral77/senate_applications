using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class EmpEmployment
    {

        public string PersonalNo { get; set; }
        private int empEmplid;

        public int EmpEmplid
        {
            get { return empEmplid; }
            set { empEmplid = value; }
        }
        private int empId;

        public int EmpId
        {
            get { return empId; }
            set { empId = value; }
        }
        private int postheld;

        public int Postheld
        {
            get { return postheld; }
            set { postheld = value; }
        }
       
        private int branch;

        public int Branch
        {
            get { return branch; }
            set { branch = value; }
        }
        private int postStatus;

        public int PostStatus
        {
            get { return postStatus; }
            set { postStatus = value; }
        }
        private int gazzetted;

        public int Gazzetted
        {
            get { return gazzetted; }
            set { gazzetted = value; }
        }
private DateTime probFrom;

public DateTime ProbFrom
{
    get { return probFrom; }
    set { probFrom = value; }
}
private DateTime probTo;

public DateTime ProbTo
{
    get { return probTo; }
    set { probTo = value; }
}
private int isProbExt;

public int IsProbExt
{
    get { return isProbExt; }
    set { isProbExt = value; }
}
private DateTime probExtTo;

public DateTime ProbExtTo
{
    get { return probExtTo; }
    set { probExtTo = value; }
}
private string probExtReason;

public string ProbExtReason
{
    get { return probExtReason; }
    set { probExtReason = value; }
}
private DateTime govtServStDate;

public DateTime GovtServStDate
{
    get { return govtServStDate; }
    set { govtServStDate = value; }
}
private DateTime senServStDate;

public DateTime SenServStDate
{
    get { return senServStDate; }
    set { senServStDate = value; }
}
private int prevDept;

public int PrevDept
{
    get { return prevDept; }
    set { prevDept = value; }
}


private int prevPost;

public int PrevPost
{
    get { return prevPost; }
    set { prevPost = value; }
}
private int is_gazetted;

public int Is_gazetted
{
    get { return is_gazetted; }
    set { is_gazetted = value; }
}
private DateTime nonGazFrom;

public DateTime NonGazFrom
{
    get { return nonGazFrom; }
    set { nonGazFrom = value; }
}
private DateTime nonGazTo;

public DateTime NonGazTo
{
    get { return nonGazTo; }
    set { nonGazTo = value; }
}
private DateTime gazFrom;

public DateTime GazFrom
{
    get { return gazFrom; }
    set { gazFrom = value; }
}
private DateTime gazTo;

public DateTime GazTo
{
    get { return gazTo; }
    set { gazTo = value; }
}
private DateTime superDate;

public DateTime SuperDate
{
    get { return superDate; }
    set { superDate = value; }
}
private int bpsId;

public int BpsId
{
    get { return bpsId; }
    set { bpsId = value; }
}
private int empPoolId;

public int EmpPoolId
{
    get { return empPoolId; }
    set { empPoolId = value; }
}
private DateTime accommodDate;

public DateTime AccommodDate
{
    get { return accommodDate; }
    set { accommodDate = value; }
}
private int accommodTypeId;

public int AccommodTypeId
{
    get { return accommodTypeId; }
    set { accommodTypeId = value; }
}
private string remarks;

public string Remarks
{
    get { return remarks; }
    set { remarks = value; }
}
private string file_no;

public string File_no
{
    get { return file_no; }
    set { file_no = value; }
}
private string awards_granted;

public string Awards_granted
{
    get { return awards_granted; }
    set { awards_granted = value; }
}
private string otherInfo;

public string OtherInfo
{
    get { return otherInfo; }
    set { otherInfo = value; }
}
private int empStatusId;

public int EmpStatusId
{
    get { return empStatusId; }
    set { empStatusId = value; }
}
private DateTime reEmpFrom;

public DateTime ReEmpFrom
{
    get { return reEmpFrom; }
    set { reEmpFrom = value; }
}
private DateTime reEmpTo;

public DateTime ReEmpTo
{
    get { return reEmpTo; }
    set { reEmpTo = value; }
}
private string reEmpPeriod;

public string ReEmpPeriod
{
    get { return reEmpPeriod; }
    set { reEmpPeriod = value; }
}
private int senNo;

public int SenNo
{
    get { return senNo; }
    set { senNo = value; }
}
public int QuotaId { get; set;}
        public int AppointmentModeId { get; set; }
        //private string reportingOfficer;
        //public string reportingOfficer 
        //{
        //    get { return reportingOfficer; }
        //    set { reportingOfficer = value; }
        //}

        //private string grade;
        //public string grade
        //{
        //    get { return grade; }
        //    set { grade = value; }
        //}
        public int PreviousLeaveCredit { get; set; }

    }
    
}
