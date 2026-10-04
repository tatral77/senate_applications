namespace Entities
{
    public class Gender
    {
        public int GenderId { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
        public static object SelectedValue { get; set; }
    }
}
