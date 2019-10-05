using Blog.Api.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Blog.Api.Domain
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddBlogContext(this IServiceCollection services)
        {
            using (var provider = services.BuildServiceProvider())
            {
                var dbOptions = provider.GetRequiredService<IOptions<DbOptions>>();
                services.AddDbContext<BlogDbContext>(options => { options.UseSqlServer(dbOptions.Value.ConnectionString); });
            }

            return services;
        }
    }
}
