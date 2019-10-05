using System;
using Blog.SearchEngine.Options;
using Blog.SearchEngine.SearchModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Nest;

namespace Blog.SearchEngine
{
    public static class ElasticSearchExtensions
    {
        public static IServiceCollection AddElasticSearchOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ElasticSearchOptions>(configuration.GetSection(nameof(ElasticSearchOptions)));
            return services;
        }

        public static IServiceCollection AddElasticSearchClient(this IServiceCollection services)
        {
            ElasticSearchOptions options;

            using (var provider = services.BuildServiceProvider())
            {
                options = provider.GetRequiredService<IOptions<ElasticSearchOptions>>().Value;
            }

            var settings = new ConnectionSettings(new Uri(options.Url))
                .DefaultIndex(options.IndexName)
                .DefaultMappingFor<Article>(x => x
                    .PropertyName(p => p.Id, "id")
                );

            var client = new ElasticClient(settings);
            services.AddSingleton<IElasticClient>(client);
            return services;
        }
    }
}