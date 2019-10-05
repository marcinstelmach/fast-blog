using System.Threading.Tasks;
using Blog.Api.Domain.Entities;

namespace Blog.Api.Domain.Repositories
{
    public interface IArticleRepository
    {
        Task<Article> AddArticleAsync(Article article);
    }
}