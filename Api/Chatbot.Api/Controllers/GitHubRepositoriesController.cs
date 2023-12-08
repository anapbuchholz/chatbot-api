using Domain.Ioc.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Chatbot.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GitHubRepositoriesController : BaseController
    {
        private readonly IGitHubRepositoriesService _gitHubRepositoriesService;

        public GitHubRepositoriesController(IGitHubRepositoriesService gitHubRepositoriesService)
        {
            _gitHubRepositoriesService = gitHubRepositoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
           var result = await _gitHubRepositoriesService.GetOldestGitHubRepositories();

            return GetHttpResponse(result.status, result.body, result.errorMessage);
        }
    }
}