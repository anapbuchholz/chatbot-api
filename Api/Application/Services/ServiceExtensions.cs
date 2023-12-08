using Domain.Ioc.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services
{
    internal static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IGitHubRepositoriesService, GitHubRepositoriesService>();

            return serviceCollection;
        }
    }
}
