using Domain.Ioc.Infrastructure.Http;
using Domain.Models;

namespace Infrastructure.Http
{
    internal sealed class GitHubRepositoriesRepository : IGitHubRepositoriesRepository
    {
        private readonly HttpClient _httpClient;

        public GitHubRepositoriesRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<GitHubRepositoryModel>> GetFiveOldestRepositories()
        {
            throw new NotImplementedException();
        }
    }
}