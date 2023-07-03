using Octokit;

namespace GitHubAntiCorruptionAPI.Services
{
    public class GitHubService
    {
        private readonly IGitHubClient _gitHubClient;

        public GitHubService(IGitHubClient gitHubClient)
        {
            _gitHubClient = gitHubClient;
        }

        public async Task<Repository> CreateRepository(string repositoryName)
        {
            var newRepository = new NewRepository(repositoryName);
            return await _gitHubClient.Repository.Create(newRepository);
        }

        public async Task<IReadOnlyList<Branch>> GetRepositoryBranches(string owner, string repositoryName)
        {
            return await _gitHubClient.Repository.Branch.GetAll(owner, repositoryName);
        }

        public async Task<IReadOnlyList<RepositoryHook>> GetRepositoryWebhooks(string owner, string repositoryName)
        {
            return await _gitHubClient.Repository.Hooks.GetAll(owner, repositoryName);
        }

        public async Task<RepositoryHook> AddRepositoryWebhook(string owner, string repositoryName, NewRepositoryHook newWebhook)
        {
            return await _gitHubClient.Repository.Hooks.Create(owner, repositoryName, newWebhook);
        }

        public async Task<RepositoryHook> UpdateRepositoryWebhook(string owner, string repositoryName, int webhookId, EditRepositoryHook webhookUpdate)
        {
            return await _gitHubClient.Repository.Hooks.Edit(owner, repositoryName, webhookId, webhookUpdate);
        }
    }
}

