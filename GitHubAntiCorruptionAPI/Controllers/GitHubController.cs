using Octokit;
using GitHubAntiCorruptionAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GitHubAntiCorruptionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GitHubController : ControllerBase
    {
        private readonly GitHubService _gitHubService;

        public GitHubController(GitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        [HttpPost("repositories")]
        public async Task<ActionResult<Repository>> CreateRepository(string repositoryName)
        {
            var newRepository = await _gitHubService.CreateRepository(repositoryName);
            return Ok(newRepository);
        }

        [HttpGet("repositories/{owner}/{repositoryName}/branches")]
        public async Task<ActionResult<IReadOnlyList<Branch>>> GetRepositoryBranches(string owner, string repositoryName)
        {
            var branches = await _gitHubService.GetRepositoryBranches(owner, repositoryName);
            return Ok(branches);
        }

        [HttpGet("repositories/{owner}/{repositoryName}/webhooks")]
        public async Task<ActionResult<IReadOnlyList<RepositoryHook>>> GetRepositoryWebhooks(string owner, string repositoryName)
        {
            var webhooks = await _gitHubService.GetRepositoryWebhooks(owner, repositoryName);
            return Ok(webhooks);
        }

        [HttpPost("repositories/{owner}/{repositoryName}/webhooks")]
        public async Task<ActionResult<RepositoryHook>> AddRepositoryWebhook(string owner, string repositoryName, NewRepositoryHook newWebhook)
        {
            var webhook = await _gitHubService.AddRepositoryWebhook(owner, repositoryName, newWebhook);
            return Ok(webhook);
        }

        [HttpPut("repositories/{owner}/{repositoryName}/webhooks/{webhookId}")]
        public async Task<ActionResult<RepositoryHook>> UpdateRepositoryWebhook(string owner, string repositoryName, int webhookId, EditRepositoryHook webhookUpdate)
        {
            var updatedWebhook = await _gitHubService.UpdateRepositoryWebhook(owner, repositoryName, webhookId, webhookUpdate);
            return Ok(updatedWebhook);
        }
    }
}
