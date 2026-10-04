using System.Collections.Generic;

namespace ResolutionEntities
{
    public class ListResolutions
    {
        public int ResolutionId { get; set; }
        public int ResolutionDiaryNo { get; set; }
        public int SessionId { get; set; }
        public int ListNo { get; set; }
        public List<ResolutionSubmittersEnt> Movers = null;
        public int SessionNumber { get; set; }
        public int StatusId { get; set; }
        public string ResolutionText { get; set; }
        public string Status { get; set; }
        public string SessionName { get; set; }
    }
}
