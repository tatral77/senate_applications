using System;

namespace ResolutionEntities
{
    public class ResolutionListEnt
    {
        public int ResolutionsListId { get; set; }
        public int AssemblySessionsId { get; set; }
        public int StartNo { get; set; }
        public string ListName { get; set; }
        public DateTime ListDate { get; set; }
        public string Resolutions { get; set; }
    }
}
