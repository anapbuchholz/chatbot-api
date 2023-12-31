﻿using Domain.CustomExceptions;
using Domain.Ioc.Infrastructure.Http;
using Domain.Models;
using System.Net;
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
            var currentPage = 1;
            var allRepositories = new List<GitHubRepositoryModel>();

            while (true)
            {
                var result = await _httpClient.GetAsync($"/orgs/takenet/repos?per_page={repositoriesPerPage}&page={currentPage}");

                if (!result.IsSuccessStatusCode)
                {
                    InfrastructureFailuresValidator.Validate(result.StatusCode, "GitHubApi");
                }

                string jsonResponse = await result.Content.ReadAsStringAsync();
                var repositories = JsonSerializer.Deserialize<List<GitHubRepositoryModel>>(jsonResponse);

                if (repositories == null || repositories.Count == 0)
                {
                    break;
                }

                allRepositories.AddRange(repositories);
                currentPage++;
            }

            return allRepositories;
        }
    }
}