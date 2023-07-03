using Xunit;
using Moq;
using GitHubAntiCorruptionAPI.Services;
using Octokit;

namespace GitHubAntiCorruptionAPI.Tests
{
    [Collection("GitHubServiceTests")]
    public class GitHubServiceTests
    {
        private readonly GitHubService _gitHubService;
        private readonly Mock<IGitHubClient> _gitHubClientMock;

        public GitHubServiceTests()
        {
            _gitHubClientMock = new Mock<IGitHubClient>();
            _gitHubService = new GitHubService(_gitHubClientMock.Object);
        }

        [Fact]
        public async Task CreateRepository_ValidInput_ReturnsNewRepository()
        {
            // Arrange
            var repositoryName = "test-repo";
            var expectedRepository = new Repository();

            _gitHubClientMock
                .Setup(client => client.Repository.Create(It.IsAny<NewRepository>()))
                .ReturnsAsync(expectedRepository);

            // Act
            var result = await _gitHubService.CreateRepository(repositoryName);

            // Assert
            Assert.Equal(expectedRepository, result);
        }

        [Fact]
        public async Task GetRepositoryBranches_ValidInput_ReturnsBranches()
        {
            // Arrange
            var owner = "test-owner";
            var repositoryName = "test-repo";
            var expectedBranches = new List<Branch>();

            _gitHubClientMock
                .Setup(client => client.Repository.Branch.GetAll(owner, repositoryName))
                .ReturnsAsync(expectedBranches);

            // Act
            var result = await _gitHubService.GetRepositoryBranches(owner, repositoryName);

            // Assert
            Assert.Equal(expectedBranches, result);
        }

        [Fact]
        public async Task GetRepositoryWebhooks_ValidInput_ReturnsWebhooks()
        {
            // Arrange
            var owner = "test-owner";
            var repositoryName = "test-repo";
            var expectedWebhooks = new List<RepositoryHook>();

            _gitHubClientMock
                .Setup(client => client.Repository.Hooks.GetAll(owner, repositoryName))
                .ReturnsAsync(expectedWebhooks);

            // Act
            var result = await _gitHubService.GetRepositoryWebhooks(owner, repositoryName);

            // Assert
            Assert.Equal(expectedWebhooks, result);
        }

        [Fact]
        public async Task AddRepositoryWebhook_ValidInput_ReturnsNewWebhook()
        {
            // Arrange
            var owner = "test-owner";
            var repositoryName = "test-repo";
            var newWebhook = new NewRepositoryHook("web", new Dictionary<string, string>());
            var expectedWebhook = new RepositoryHook();

            _gitHubClientMock
                .Setup(client => client.Repository.Hooks.Create(owner, repositoryName, newWebhook))
                .ReturnsAsync(expectedWebhook);

            // Act
            var result = await _gitHubService.AddRepositoryWebhook(owner, repositoryName, newWebhook);

            // Assert
            Assert.Equal(expectedWebhook, result);
        }

        [Fact]
        public async Task UpdateRepositoryWebhook_ValidInput_ReturnsUpdatedWebhook()
        {
            // Arrange
            var owner = "test-owner";
            var repositoryName = "test-repo";
            var webhookId = 123;
            var webhookUpdate = new EditRepositoryHook();
            var expectedWebhook = new RepositoryHook();

            _gitHubClientMock
                .Setup(client => client.Repository.Hooks.Edit(owner, repositoryName, webhookId, webhookUpdate))
                .ReturnsAsync(expectedWebhook);

            // Act
            var result = await _gitHubService.UpdateRepositoryWebhook(owner, repositoryName, webhookId, webhookUpdate);

            // Assert
            Assert.Equal(expectedWebhook, result);
        }
    }
}
