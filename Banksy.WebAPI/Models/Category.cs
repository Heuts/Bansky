using System.Collections.Generic;

namespace Banksy.WebAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Category> SubCategories { get; set; }
    }
}
