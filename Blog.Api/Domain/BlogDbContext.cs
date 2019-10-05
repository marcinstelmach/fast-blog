using Blog.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Api.Domain
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
    }
}
