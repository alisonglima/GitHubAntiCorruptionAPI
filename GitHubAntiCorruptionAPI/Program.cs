using GitHubAntiCorruptionAPI.Services;
using Microsoft.OpenApi.Models;
using Octokit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configuração do serviço do GitHub
builder.Services.AddScoped<IGitHubClient>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var accessToken = configuration["GitHub:AccessToken"];
    var gitHubClient = new GitHubClient(new ProductHeaderValue("GitHubAntiCorruptionAPI"));
    gitHubClient.Credentials = new Credentials(accessToken);
    return gitHubClient;
});

builder.Services.AddScoped<GitHubService>(sp =>
{
    var gitHubClient = sp.GetRequiredService<IGitHubClient>();
    return new GitHubService(gitHubClient);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GitHubAntiCorruptionAPI", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GitHubAntiCorruptionAPI v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
