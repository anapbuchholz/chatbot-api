using Domain.CustomExceptions;
using Domain.Ioc.Application.Services;
using Domain.Ioc.Infrastructure.Http;
using Domain.Models;
using System.Net;

namespace Application.Services
{
    public sealed class GitHubRepositoriesService : IGitHubRepositoriesService
    {
        private readonly IGitHubRepositoriesRepository _gitHubRepositoriesRepository;

        public GitHubRepositoriesService(IGitHubRepositoriesRepository gitHubRepositoriesRepository)
        {
            _gitHubRepositoriesRepository = gitHubRepositoriesRepository;
        }

        public async Task<(IEnumerable<GitHubRepositoryModel>? body, HttpStatusCode status, string errorMessage)> GetOldestGitHubRepositories()
        {
            try
            {
                var repositories = await _gitHubRepositoriesRepository.GetAll();

                var oldestRepositories = repositories.OrderBy(x => x.CreatedAt).ToList().Take(5);

                return (oldestRepositories, HttpStatusCode.OK, string.Empty);
            }
            catch (CustomExceptionBase ex)
            {
                return (default, ex.Status, ex.Message);
            }
            catch 
            {
                return (default, HttpStatusCode.InternalServerError, "Internal Error");
            }
            
        }
    }
}