namespace Banksy.WebAPI.DTOs
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int[] SubCategoryIds { get; set; }
    }
}