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

        public async Task<IEnumerable<GitHubRepositoryModel>> GetAll()
        {
            var repositoriesPerPage = 30;
            var allRepositories = new List<GitHubRepositoryModel>();

            bool morePageExists = true;
            int paginaAtual = 1;

            while (morePageExists)
            {
                var result = await _httpClient.GetAsync($"/orgs/takenet/repos?per_page={repositoriesPerPage}&page={paginaAtual}");

                if (result.IsSuccessStatusCode)
                {
                    string jsonResponse = await result.Content.ReadAsStringAsync();
                    var repositories = JsonSerializer.Deserialize<List<GitHubRepositoryModel>>(jsonResponse);

                    if (repositories == null || repositories.Count == 0)
                    {
                        morePageExists = false;
                    }
                    else
                    {
                        allRepositories.AddRange(repositories);
                        paginaAtual++;
                    }
                }
            }

            return allRepositories;
        }
    }
}