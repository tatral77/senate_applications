using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class DisciplinaryAction
    {
        public int DisciplinaryActionId { get; set; }
        public int SystemUserId { get; set; }
        public int DisciplinaryActionTypeId { get; set; }
        public string DisciplinaryActionType { get; set; }
        public int PostId { get; set; }
        public string Post { get; set; }
        public int BPSID { get; set; }
        public string BPS { get; set; }
        public DateTime ActionDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int FinalActionTypeId { get; set; }
        public string  FinalActionType { get; set; }
        public DateTime FinalActionDate{get;set;}
        public string Details { get; set; }
        public int IsLfpCalculated { get; set; }
        public int IsServiceCalculated { get; set; }


    }
}
