using AutoFixture;
using Chatbot.Api.Controllers;
using Domain.Ioc.Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace Chatbot.Api.Tests.Controllers
{
    public class GitHubRepositoriesControllerTest
    {
        private readonly Mock<IGitHubRepositoriesService> _gitHubRepositoryService;
        private readonly GitHubRepositoriesController _controller;
        private readonly Fixture _fixture;

        public GitHubRepositoriesControllerTest()
        {
            _gitHubRepositoryService = new Mock<IGitHubRepositoriesService>();
            _controller = new GitHubRepositoriesController(_gitHubRepositoryService.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task Get_ShouldReturnHttpCode200_WhenFlowWorks()
        {
            var bodyMock = _fixture.Create<IEnumerable<GitHubRepositoryModel>>();
            var expectedStatus = HttpStatusCode.OK;
            var errorMessageMock = _fixture.Create<string>();

            var serviceResponse = (body: bodyMock, status: expectedStatus, errorMessage: errorMessageMock);
            _gitHubRepositoryService.Setup(x => x.GetOldestGitHubRepositories()).ReturnsAsync(serviceResponse);

            var result = await _controller.Get();

            var okObjectResult = result as ObjectResult;

            Assert.NotNull(okObjectResult);
            Assert.Equal((int)expectedStatus, okObjectResult.StatusCode);
        }


        [Fact]
        public async Task Get_ShouldReturnHttpCode401_WhenUnauthorized()
        {
            var bodyMock = _fixture.Create<IEnumerable<GitHubRepositoryModel>>();
            var expectedStatus = HttpStatusCode.Unauthorized;
            var expectedErrorMessage = "Unauthorized Access";

            var serviceResponse = (body: bodyMock, status: expectedStatus, errorMessage: expectedErrorMessage);
            _gitHubRepositoryService.Setup(x => x.GetOldestGitHubRepositories()).ReturnsAsync(serviceResponse);

            var result = await _controller.Get();

            var unauthorizedObjectResult = result as ObjectResult;

            Assert.NotNull(unauthorizedObjectResult);
            Assert.Equal((int)expectedStatus, unauthorizedObjectResult.StatusCode);
        }
    }
}