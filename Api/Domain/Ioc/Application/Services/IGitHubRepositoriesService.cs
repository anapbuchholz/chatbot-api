using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Ioc.Application.Services
{
    public interface IGitHubRepositoriesService
    {
        Task<IEnumerable<GitHubRepositoryModel>> GetOldestGitHubRepositories();
    }
}
