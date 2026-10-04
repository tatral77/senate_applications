namespace Entities
{
    public class Groups
    {
        public int GroupsId { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
        public int AssembliesSessionId { get; set; }
        public string AssembliesSession { get; set; }
        public int CorrespondingGroupId { get; set; }
        public int CorrespondingGroup { get; set; }
        public int GroupSequence { get; set; }
        public string UnstarDesc { get; set; }
    }
}
