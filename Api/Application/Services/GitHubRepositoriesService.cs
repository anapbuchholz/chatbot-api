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
            var oldestRepositories =  await _gitHubRepositoriesRepository.GetFiveOldestRepositories();

            var orderedEvents = oldestRepositories.OrderBy(x => x.CreatedAt).ToList().Take(5);

            return orderedEvents;
        }
    }
}