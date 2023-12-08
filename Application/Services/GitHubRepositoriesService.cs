using Domain.Ioc.Application.Services;
using Domain.Ioc.Infrastructure.Http;
using Domain.Models;

namespace Application.Services
{
    public sealed class GitHubRepositoriesService : IGitHubRepositoriesService
    {
        private readonly IGitHubRepositoriesRepository _gitHubRepositoriesRepository;

        public GitHubRepositoriesService(IGitHubRepositoriesRepository gitHubRepositoriesRepository)
        {
            _gitHubRepositoriesRepository = gitHubRepositoriesRepository;
        }

        public async Task<IEnumerable<GitHubRepositoryModel>> GetOldestGitHubRepositories()
        {
            var repositories =  await _gitHubRepositoriesRepository.GetAll();

            var oldestRepositories = repositories.OrderBy(x => x.CreatedAt).ToList().Take(5);

            return oldestRepositories;
        }
    }
}