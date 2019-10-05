using Blog.Api.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Api.Domain
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddBlogContext(this IServiceCollection services)
        {
            using (var provider = services.BuildServiceProvider())
            {
                var dbOptions = provider.GetRequiredService<DbOptions>();
                services.AddDbContext<BlogDbContext>(options => { options.UseSqlServer(dbOptions.ConnectionString); });
            }

            return services;
        }
    }
}
