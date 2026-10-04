using System;

namespace ResolutionEntities
{
    public class ResolutionStatusHistoryEnt
    {
        public int ResolutionStatusHistoryId { get; set; }
        public int ResolutionsId { get; set; }
        public int ResolutionsStatusesId { get; set; }
        public DateTime StatusDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
