using Application.Services;
using AutoFixture;
using Domain.CustomExceptions;
using Domain.Ioc.Infrastructure.Http;
using Domain.Models;
using Moq;
using System.Net;

namespace Chatbot.Api.Tests.Services
{
    public class GitHubRepositoriesServiceTest
    {
        private readonly Mock<IGitHubRepositoriesRepository> _gitHubRepositoriesRepository;
        private readonly GitHubRepositoriesService _gitHubRepositoriesService;
        private Fixture _fixture;

        public GitHubRepositoriesServiceTest()
        {
            _gitHubRepositoriesRepository = new Mock<IGitHubRepositoriesRepository>();
            _gitHubRepositoriesService = new GitHubRepositoriesService(_gitHubRepositoriesRepository.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetOldestGitHubRepositories_ShouldReturnTheOldestRepositories()
        {
            var repositoryReturnMock = _fixture.CreateMany<GitHubRepositoryModel>(5);

            _gitHubRepositoriesRepository.Setup(x => x.GetAll()).ReturnsAsync(repositoryReturnMock);

            var result = await _gitHubRepositoriesService.GetOldestGitHubRepositories();

            Assert.NotNull(result);
            Assert.Equivalent(5, result.body?.Count());
        }

        [Fact]
        public async Task GetOldestGitHubRepositories_ShouldHandleInternalServerError()
        {
            var repositoryReturnMock = _fixture.Create<IEnumerable<GitHubRepositoryModel>>();
            _gitHubRepositoriesRepository.Setup(x => x.GetAll()).ThrowsAsync(new Exception());

            var result = await _gitHubRepositoriesService.GetOldestGitHubRepositories();

            Assert.Null(result.body);
            Assert.Equal(HttpStatusCode.InternalServerError, result.status);
        }
    }
}
