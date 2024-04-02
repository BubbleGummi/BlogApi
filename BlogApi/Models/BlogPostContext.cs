using Microsoft.EntityFrameworkCore;

namespace BlogApi.Models
{
    public class BlogPostContext : DbContext
    {
        public BlogPostContext(DbContextOptions<BlogPostContext> options) : base(options) { }

        public DbSet<BlogPost> Blogs { get; set; }  
    }
}
