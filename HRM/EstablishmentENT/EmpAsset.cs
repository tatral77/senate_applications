using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class EmpAsset
    {
        public int EmpAssetId { get; set; }
        public int SystemUserId { get; set; }
        public int BPSID { get; set; }
        public string BPS { get; set; }
        public int PostId { get; set; }
        public string Post { get; set; }
        public int MedYear { get; set; }
     }
}
