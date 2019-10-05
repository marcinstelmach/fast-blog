using System.Threading.Tasks;
using Blog.Api.Domain.Entities;
using Blog.Api.Domain.Repositories;
using Blog.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/articles")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepository articleRepository;

        public ArticlesController(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddArticle(AddArticleViewModel model)
        {
            var article = new Article(model.Title, model.Content, model.Author);
            return Ok(await articleRepository.AddArticleAsync(article));
        }
    }
}