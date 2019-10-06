using System.Threading.Tasks;
using AutoMapper;
using Blog.Api.Domain.Entities;
using Blog.Api.Domain.Repositories;
using Blog.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace Blog.Api.Controllers
{
    [Route("api/articles")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepository articleRepository;
        private readonly IMapper mapper;
        private readonly IElasticClient elasticClient;

        public ArticlesController(IArticleRepository articleRepository, IMapper mapper, IElasticClient elasticClient)
        {
            this.articleRepository = articleRepository;
            this.mapper = mapper;
            this.elasticClient = elasticClient;
        }

        [HttpPost]
        public async Task<IActionResult> AddArticle(AddArticleViewModel model)
        {
            var article = new Article(model.Title, model.Content, model.Author);
            await articleRepository.AddArticleAsync(article);

            var searchModel = mapper.Map<SearchEngine.SearchModels.Article>(article);
            var indexResponse = await elasticClient.IndexDocumentAsync(searchModel);
            return Ok();
        }
    }
}