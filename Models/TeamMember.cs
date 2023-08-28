using System.ComponentModel.DataAnnotations;

namespace RegisterWebSite.Models
{
    public class TeamMember
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int  JobTitle { get; set; }
        public string Image { get; set; }
    }
}
