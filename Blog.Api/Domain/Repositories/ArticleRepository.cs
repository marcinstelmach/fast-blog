using System.Threading.Tasks;
using Blog.Api.Domain.Entities;

namespace Blog.Api.Domain.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly BlogDbContext blogDbContext;

        public ArticleRepository(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        public async Task<Article> AddArticleAsync(Article article)
        {
            await blogDbContext.Articles.AddAsync(article);
            await blogDbContext.SaveChangesAsync();

            return article;
        }
    }
}