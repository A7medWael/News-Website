using System.ComponentModel.DataAnnotations;

namespace RegisterWebSite.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<News>? news { get; set; }
    }
}
