using AutoMapper;
using Blog.Api.Domain.Entities;

namespace Blog.Api
{
    public class GlobalProfile : Profile
    {
        public GlobalProfile()
            :base("Global")
        {
            CreateMap<Article, SearchEngine.SearchModels.Article>();
        }
    }
}
