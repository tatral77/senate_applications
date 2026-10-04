using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class EmpHistory
    {
        public int EmploymentHistoryId { get; set; }
        public int SystemUsersId { get; set; }
        public int PostId { get; set; }
        public string Post { get; set; }
        public int BpsId { get; set; }
        public string BPS { get; set; }
        public int IsGazetted { get; set; }
        public int PostStatusId { get; set; }
        public string PostStatus { get; set; }
        public int EmploymentStatusId { get; set; }
        public string EmploymentStatus { get; set; }
        public int QuotaId { get; set; }
        public string Quota { get; set; }
        public DateTime EmploymentStatusDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Details { get; set; }
        public string Remarks { get; set; }
        public int CurrentStatusId { get; set; }
        public string CurrentStatus { get; set; }
        public DateTime CurrentStatusDate { get; set; }
        public int IsCurrent { get; set; }
        public Duration GovtServiceDuration { get; set; }
        public Duration SenateServiceDuration { get; set; }
    }
}
