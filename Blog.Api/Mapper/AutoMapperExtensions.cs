using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Api.Mapper
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GlobalProfile>();
            });

            services.AddSingleton<IMapper>(config.CreateMapper());
            return services;
        }
    }
}