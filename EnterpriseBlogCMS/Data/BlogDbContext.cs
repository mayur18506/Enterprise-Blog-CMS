using EnterpriseBlogCMS.Models;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseBlogCMS.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }

        public DbSet<Article> Articles { get; set; }
        public DbSet<AppUser> Users { get; set; }
    }
}