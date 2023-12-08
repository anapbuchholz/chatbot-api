using Domain.Ioc.Infrastructure.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

namespace Infrastructure.Repositories
{
    internal static class HttpRepositoryExtensions
    {
        public static IServiceCollection AddHttpRepositories(this IServiceCollection serviceCollection)
        {
            var GitHubToken = Environment.GetEnvironmentVariable("GITHUB_TOKEN");
            serviceCollection.AddScoped<IGitHubRepositoriesRepository, GitHubRepositoriesRepository>();
            serviceCollection.AddHttpClient<IGitHubRepositoriesRepository, GitHubRepositoriesRepository>(client =>
            {

                client.BaseAddress = new Uri("https://api.github.com");
                client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("AppName", "1.0"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GitHubToken);
            });

            return serviceCollection;
        }
    }
}
