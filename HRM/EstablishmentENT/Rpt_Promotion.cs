using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class Rpt_Promotion
    {
        private int empPromotionId;

        public int EmpPromotionId
        {
            get { return empPromotionId; }
            set { empPromotionId = value; }
        }
        private int empId;

        public int EmpId
        {
            get { return empId; }
            set { empId = value; }
        }
        public string EmployeeName { get; set; }
        private DateTime promotionDate;

        public DateTime PromotionDate
        {
            get { return promotionDate; }
            set { promotionDate = value; }
        }
        private int postId;

        public int PostId
        {
            get { return postId; }
            set { postId = value; }
        }
        private string post;

        public string Post
        {
            get { return post; }
            set { post = value; }
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
        private int bps;

        public int Bps
        {
            get { return bps; }
            set { bps = value; }
        }
        private string bpsDesc;

        public string BpsDesc
        {
            get { return bpsDesc; }
            set { bpsDesc = value; }
        }
        public int IsCurrent { get; set; }
        private string remarks;

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
        public int PromotionTypeId { get; set; }
        public string PromotionType { get; set; }
        public int IsGazetted { get; set; }
        public int ProbationId { get; set; }
        public DateTime? ProbationFrom { get; set; }
        public DateTime? ProbationTo { get; set; }
        public int IsExtended { get; set; }
        public DateTime ExtendedTo { get; set; }
        public string ExtensionReason { get; set; }
        public int PromotionModeId { get; set; }
        public string PromotionMode { get; set; }

    }
}
