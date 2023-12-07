using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Ioc.Infrastructure.Http
{
    public interface IGitHubRepositoriesRepository
    {
        Task<IEnumerable<GitHubRepositoryModel>> GetFiveOldestRepositories();
    }
}