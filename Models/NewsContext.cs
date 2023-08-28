using Microsoft.EntityFrameworkCore;

namespace RegisterWebSite.Models
{
    public class NewsContext:DbContext
    {
        public DbSet<News> news { get; set; }
        public DbSet<Category> Categories { get; set; } 
       public DbSet<ContactUs> ContactUss { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public NewsContext(DbContextOptions options):base(options)
        {

        }
    }
}
