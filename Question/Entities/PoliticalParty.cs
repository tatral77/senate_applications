namespace Entities
{
    public class PoliticalParty
    {
        public int PartyId { get; set; }
        public string PartyName { get; set; }
        public int PartySortOrder { get; set; }
        public int CoalitionId { get; set; }
        public string Coalition { get; set; }
        public int CoalitionSortOrder { get; set; }

    }
}
