namespace ResolutionEntities
{
    public class ResolutionSubmittersEnt
    {
        public int ResolutionsSubmittersId { get; set; }
        public int ResolutionsId { get; set; }
        public int SystemUsersId { get; set; }
        public string MoverName { get; set; }
        public int ReligionId { get; set; }
        public int GenderId { get; set; }
        // Position in the printed list (1 = shown first). 0 means "not set" and is placed last on insert.
        public int SortOrder { get; set; }
    }
}
