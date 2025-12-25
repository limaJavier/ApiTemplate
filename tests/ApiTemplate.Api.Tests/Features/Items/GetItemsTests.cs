using System.Net.Http.Json;
using ApiTemplate.Api.Features.Items.Common;
using ApiTemplate.Api.Tests.Features.Common;
using ApiTemplate.Api.Tests.Features.Utils;
using ApiTemplate.Api.Tests.Fixtures;
using Xunit.Abstractions;

namespace ApiTemplate.Api.Tests.Features.Items;

public class GetItemsTests(ITestOutputHelper output, PostgresContainerFixture postgresContainerFixture) : IsolatedTests(output, postgresContainerFixture)
{
    [Fact]
    public async Task ShouldReturnItems()
    {
        //** Arrange and Act
        var response = await _client.SendAsync<List<ItemResponse>>(
            method: HttpMethod.Get,
            route: "/items"
        );

        foreach (var item in response)
            _output.WriteLine(item.Name);

        //** Assert
        Assert.NotEmpty(response);
        Assert.Equal(4, response.Count);
    }
}
