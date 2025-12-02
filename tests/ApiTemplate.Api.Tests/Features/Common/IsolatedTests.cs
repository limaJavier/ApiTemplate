using ApiTemplate.Api.Tests.ApiFactories;
using ApiTemplate.Api.Tests.Fixtures;
using ApiTemplate.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Testcontainers.PostgreSql;
using Xunit.Abstractions;

namespace ApiTemplate.Api.Tests.Features.Common;

public class IsolatedTests(
    ITestOutputHelper output,
    PostgresContainerFixture postgresContainerFixture
) : IClassFixture<PostgresContainerFixture>, IAsyncLifetime
{
    protected ITestOutputHelper _output = output;
    private readonly PostgreSqlContainer _container = postgresContainerFixture.Container;
    private IsolatedApiFactory _factory = null!;
    protected HttpClient _client = null!;
    protected IServiceScope _scope = null!;
    protected ApiTemplateDbContext _dbContext = null!;

    public async Task InitializeAsync()
    {
        // Resolve dependencies
        var connectionString = await CreateDatabaseAsync(_container);
        _factory = new IsolatedApiFactory(connectionString);
        _client = _factory.CreateClient();
        _scope = _factory.Services.CreateScope();
        _dbContext = _scope.ServiceProvider.GetRequiredService<ApiTemplateDbContext>();

        await _dbContext.Database.MigrateAsync();
    }

    public async Task DisposeAsync()
    {
        // Dispose dependencies
        await _factory.DisposeAsync();
        _scope.Dispose();
        await _dbContext.DisposeAsync();
    }

    private static async Task<string> CreateDatabaseAsync(PostgreSqlContainer container)
    {
        var dbName = $"test_{Guid.NewGuid():N}";
        var connectionString = container.GetConnectionString();

        await using var dbConnection = new NpgsqlConnection(connectionString);

        await dbConnection.OpenAsync();
        await new NpgsqlCommand(
            $"CREATE DATABASE \"{dbName}\";",
            dbConnection
        ).ExecuteNonQueryAsync();

        var connectionStringBuilder = new NpgsqlConnectionStringBuilder(connectionString)
        {
            Database = dbName
        };

        return connectionStringBuilder.ToString();
    }
}
