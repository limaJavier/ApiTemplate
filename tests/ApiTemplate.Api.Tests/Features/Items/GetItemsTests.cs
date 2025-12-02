using System.Net.Http.Json;
using ApiTemplate.Api.Features.Items.Responses;
using ApiTemplate.Api.Tests.Features.Common;
using ApiTemplate.Api.Tests.Fixtures;
using Xunit.Abstractions;

namespace ApiTemplate.Api.Tests.Features.Items;

public class GetItemsTests(ITestOutputHelper output, PostgresContainerFixture postgresContainerFixture) : IsolatedTests(output, postgresContainerFixture)
{
    [Fact]
    public async Task ShouldReturnItems()
    {
        // Arrange

        // Act
        var httpResponse = await _client.GetAsync("/items");
        httpResponse.EnsureSuccessStatusCode();
        var response = (await httpResponse.Content.ReadFromJsonAsync<List<ItemResponse>>())!;

        // Assert
        foreach (var item in response)
            _output.WriteLine(item.Name);
    }
}
