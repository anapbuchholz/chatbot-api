using Domain.Ioc.Infrastructure.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

namespace Infrastructure.Repositories
{
    internal static class HttpRepositoryExtensions
    {
        public static IServiceCollection AddHttpRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IGitHubRepositoriesRepository, GitHubRepositoriesRepository>();
            serviceCollection.AddHttpClient<IGitHubRepositoriesRepository, GitHubRepositoriesRepository>(client =>
            {

                client.BaseAddress = new Uri("https://api.github.com");
                client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("AppName", "1.0"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "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");
            });

            return serviceCollection;
        }
    }
}
