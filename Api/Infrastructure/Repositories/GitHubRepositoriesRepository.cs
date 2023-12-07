using Domain.Ioc.Infrastructure.Http;
using Domain.Models;
using System.Text.Json;

namespace Infrastructure.Repositories
{
    internal sealed class GitHubRepositoriesRepository : IGitHubRepositoriesRepository
    {
        private readonly HttpClient _httpClient;

        public GitHubRepositoriesRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<GitHubRepositoryModel>> GetFiveOldestRepositories()
        {
            var result = await _httpClient.GetAsync("/orgs/takenet/repos");

            if (!result.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            string jsonResponse = await result.Content.ReadAsStringAsync();
            var repositories = JsonSerializer.Deserialize<List<GitHubRepositoryModel>>(jsonResponse);

            return repositories;
        }
    }
}